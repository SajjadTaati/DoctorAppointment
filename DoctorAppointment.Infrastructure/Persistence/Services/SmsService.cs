using DoctorAppointment.Domain.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Infrastructure.Persistence.Services
{
    // Infrastructure/Services/SmsService.cs
    //public class SmsService(IConfiguration config) : ISmsService
    //{
    //    public async Task SendOtpAsync(string phone, string code)
    //    {
    //        // ادغام با پنل SMS ایرانی (مثلاً Melipayamak یا Kavenegar)
    //        var apiKey = config["Sms:ApiKey"];
    //        var sender = config["Sms:Sender"];

    //        using var client = new HttpClient();
    //        // درخواست به API پنل SMS
    //        await client.PostAsJsonAsync("https://api.sms-provider.ir/send", new
    //        {
    //            api_key = apiKey,
    //            sender,
    //            receptor = phone,
    //            message = $"کد تایید: {code}"
    //        });
    //    }
    //}

}
