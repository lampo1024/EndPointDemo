using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EndpointDemo.Endpoints.v1.Students
{
    /// <summary>
    /// 获取指定ID的学生信息
    /// </summary>
    public class GetById : BaseEndpoint<int, StudentResponse>
    {
        /// <summary>
        /// 获取指定ID的学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet, Route("api/v1/student/{id:int}")]
        [SwaggerOperation(
            Summary = "获取指定ID的学生信息",
            Description = "获取指定ID的学生信息",
            OperationId = "Student.GetById",
            Tags = new[] { "StudentEndpoint" }
            )]
        public override ActionResult<StudentResponse> Handle(int id)
        {
            var response = new StudentResponse
            {
                Id = id,
                Name = "Rector"
            };
            return Ok(response);
        }
    }
}
