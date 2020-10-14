using System;
using Course.Common.Commands;
using Course.Common.Events;
using Course.Common.RabbitMq;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;

namespace Course.Api.Controllers
{
    [Route("[controller]")]
    public class CoursesController : Controller
    {
        private readonly IModel _model;

        public CoursesController(
            IModel model
            )
        {
            _model = model;
        }

        [HttpPost("Publish")]
        public IActionResult Publish([FromQuery]Guid courseId)
        {
            var userId = Guid.NewGuid(); // will be extracted from  Guid.Parse(User.Identity.Name) when authentication will be implemented
            var coursePublished = new PublishCourse(courseId, userId);
            byte[] body = coursePublished.ObjectToByteArray();
            _model.BasicPublish(exchange: "",
                routingKey: Extensions.GetCommandQueueName<PublishCourse>(),
                basicProperties: null,
                body: body);

            return Ok();
        }

        [HttpPost("Complete")]
        public IActionResult Complete([FromQuery]Guid courseId, [FromQuery]Guid userId)
        {
            var completeCourse = new CompleteCourse(courseId, userId);
            byte[] body = completeCourse.ObjectToByteArray();
            _model.BasicPublish(exchange: "",
                routingKey: Extensions.GetCommandQueueName<CompleteCourse>(),
                basicProperties: null,
                body: body);

            return Ok();
        }
    }
}
