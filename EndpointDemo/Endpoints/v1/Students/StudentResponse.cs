namespace EndpointDemo.Endpoints.v1.Students
{
    /// <summary>
    /// 返回的学生信息响应实体类
    /// </summary>
    public class StudentResponse
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
    }
}
