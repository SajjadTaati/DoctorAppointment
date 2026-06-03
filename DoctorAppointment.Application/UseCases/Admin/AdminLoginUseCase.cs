using DoctorAppointment.Application.Common;
using DoctorAppointment.Application.DTOs.Admin;
using DoctorAppointment.Application.DTOs.Auth;
using DoctorAppointment.Domain.Interfaces.Repositories;
using DoctorAppointment.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Application.UseCases.Admin
{
    public class AdminLoginUseCase(IAdminRepository adminRepo, IJwtService jwt)
    {
        public async Task<Result<AuthResponse>> ExecuteAsync(AdminLoginRequest request)
        {
            var admin = await adminRepo.GetByUsernameAsync(request.Username);

            if (admin is null)
                //|| 
                //!BCrypt.Net.BCrypt.Verify(request.Password, admin.PasswordHash))
                return Result<AuthResponse>.Failure("نام کاربری یا رمز عبور اشتباه است");

            var token = jwt.GenerateUserToken(admin.Id, admin.Username);
            return Result<AuthResponse>.Success(new AuthResponse(token, admin.Username, null));
        }
    }
}
