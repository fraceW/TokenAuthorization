using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenAuthorization.Filter;
using TokenAuthorization.Models;
using TokenAuthorization.Utils;

namespace TokenAuthorization.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetUserInformation")]
        public RetuenResult<string> GetUserInformation()
        {
            return new RetuenResult<string>() {
                code = 200,
                msg = "success",
                data = "hello"
            };
        }

        [HttpPost("Login")]
        [SkipAttribute]
        public RetuenResult<Token> Login(string name,string pwd) 
        {
            if (name == "admin" && pwd == "123")
            {
                Token token = TokenHelp.GetToken(name, pwd);
                MemoryCacheHelper.AddMemoryCache(token.accessToken, User);
                return new RetuenResult<Token>
                {
                    code = 200,
                    msg = "登录成功",
                    data = token
                };
            }
            else
            {
                return new RetuenResult<Token>
                {
                    code = 201,
                    msg = "登录失败，账号或密码错误",
                    data = new Token
                    {
                    }
                };
            }
        }
    }
}
