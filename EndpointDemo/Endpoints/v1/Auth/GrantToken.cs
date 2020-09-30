using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace EndpointDemo.Endpoints.v1.Auth
{
    /// <summary>
    /// 
    /// </summary>
    public class GrantToken : BaseEndpoint<AuthInfoRequest, TokenResponse>
    {
        private readonly IConfiguration _config;

        public GrantToken(IConfiguration config)
        {
            _config = config;
        }

        [SwaggerOperation(
            Summary = "用户登录",
            Description = "用户登录",
            OperationId = "Auth.GrantToken",
            Tags = new[] { "AuthEndpoint" }
        )]
        [AllowAnonymous]
        [HttpPost, Route("api/v1/auth/grant_token")]
        public override ActionResult<TokenResponse> Handle(AuthInfoRequest request)
        {
            if (request == null) return Unauthorized();
            var validUser = Authenticate(request);
            var token = "";
            if (validUser)
            {
                token = BuildToken();
            }
            else
            {
                return Unauthorized();
            }
            var response = new TokenResponse
            {
                Token = token
            };
            return Ok(response);
        }

        private string BuildToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtToken:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["JwtToken:Issuer"],
                _config["JwtToken:Issuer"],
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool Authenticate(AuthInfoRequest login)
        {
            var validUser = login.Username == "admin" && login.Password == "123456";

            return validUser;
        }
    }
}
