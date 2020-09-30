using System;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EndpointDemo.Endpoints.v1.Students
{
    /// <summary>
    /// 创建新的学生记录
    /// </summary>
    public class Create : BaseEndpoint<NewStudentRequest, StudentResponse>
    {
        /// <summary>
        /// 创建新的学生记录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPost, Route("api/v1/student/create")]
        [SwaggerOperation(
            Summary = "创建新的学生记录",
            Description = "创建新的学生记录",
            OperationId = "Student.Create",
            Tags = new[] { "StudentEndpoint" }
        )]
        public override ActionResult<StudentResponse> Handle(NewStudentRequest request)
        {
            var response = new StudentResponse
            {
                Name = request.Name,
                Id = new Random().Next(1, 100)
            };
            return Ok(response);
        }
    }
}
