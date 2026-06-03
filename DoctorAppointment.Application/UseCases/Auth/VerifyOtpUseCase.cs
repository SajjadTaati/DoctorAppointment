using DoctorAppointment.Application.Common;
using DoctorAppointment.Application.DTOs.Auth;
using DoctorAppointment.Domain.Interfaces.Repositories;
using DoctorAppointment.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Application.UseCases.Auth
{
    public class VerifyOtpUseCase(IUserRepository userRepo, IJwtService jwt)
    {
        public async Task<Result<AuthResponse>> ExecuteAsync(VerifyOtpRequest request)
        {
            var user = await userRepo.GetByPhoneAsync(request.Phone);

            if (user is null || user.OtpCode != request.Code || user.OtpExpiry < DateTime.UtcNow)
                return Result<AuthResponse>.Failure("کد نامعتبر یا منقضی شده");

            user.OtpCode = null;
            user.OtpExpiry = null;
            await userRepo.UpdateAsync(user);

            var token = jwt.GenerateUserToken(user.Id, user.Phone);
            return Result<AuthResponse>.Success(new AuthResponse(token, user.Phone, user.Name));
        }
    }
}
