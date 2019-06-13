using Microsoft.AspNetCore.Mvc;
using System;

namespace slx.auto.com.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost(nameof(Send_QQ))]
        public void Send_QQ(SendEmailRequest model)
        {
            Console.WriteLine($"通过QQ邮件接口向{model.Email}发送邮件，标题{model.Title}，内 容：{model.Body}");
        }
    }
}