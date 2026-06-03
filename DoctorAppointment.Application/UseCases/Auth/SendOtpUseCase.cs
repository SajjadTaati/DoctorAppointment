using DoctorAppointment.Application.Common;
using DoctorAppointment.Application.DTOs.Auth;
using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Domain.Interfaces.Repositories;
using DoctorAppointment.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Application.UseCases.Auth
{
    public class SendOtpUseCase(IUserRepository userRepo, ISmsService sms)
    {
        public async Task<Result<string>> ExecuteAsync(SendOtpRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Phone) || request.Phone.Length != 11)
                return Result<string>.Failure("شماره موبایل معتبر نیست");

            var user = await userRepo.GetByPhoneAsync(request.Phone)
                       ?? await userRepo.CreateAsync(new User { Phone = request.Phone });

            var code = new Random().Next(100000, 999999).ToString();
            user.OtpCode = code;
            user.OtpExpiry = DateTime.UtcNow.AddMinutes(5);
            await userRepo.UpdateAsync(user);

            await sms.SendOtpAsync(request.Phone, code);
            return Result<string>.Success("کد ارسال شد");
        }
    }
}
