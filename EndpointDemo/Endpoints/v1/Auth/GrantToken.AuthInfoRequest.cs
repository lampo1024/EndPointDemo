using System.ComponentModel.DataAnnotations;

namespace EndpointDemo.Endpoints.v1.Auth
{
    /// <summary>
    /// 登录登录(请求获取令牌)的实体类
    /// </summary>
    public class AuthInfoRequest
    {
        /// <summary>
        /// 登录名
        /// </summary>
        [Required]
        public string Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
