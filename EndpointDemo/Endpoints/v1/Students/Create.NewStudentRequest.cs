using System.ComponentModel.DataAnnotations;

namespace EndpointDemo.Endpoints.v1.Students
{
    /// <summary>
    /// 创建学生的实体类
    /// </summary>
    public class NewStudentRequest
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
