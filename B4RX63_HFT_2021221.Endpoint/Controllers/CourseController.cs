using B4RX63_HFT_2021221.Endpoint.Services;
using B4RX63_HFT_2021221.Logic;
using B4RX63_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace B4RX63_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        ICourseLogic cl;
        IHubContext<SignalRHub> hub;

        public CourseController(ICourseLogic cl, IHubContext<SignalRHub> hub)
        {
            this.cl = cl;
        }

        // GET: /course
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return cl.ReadAll();
        }

        // GET /course/
        [HttpGet("{id}")]
        public Course Get(int id)
        {
            return cl.Read(id);
        }

        // POST /course
        [HttpPost]
        public void Post([FromBody] Course value)
        {
            cl.Create(value);
            this.hub.Clients.All.SendAsync("CourseCreated", value);
        }

        // PUT /course
        [HttpPut]
        public void Put([FromBody] Course value)
        {
            cl.Update(value);
            this.hub.Clients.All.SendAsync("CourseUpdated", value);
        }

        // DELETE course/x
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var course = cl.Read(id);
            cl.Delete(id);
            this.hub.Clients.All.SendAsync("CourseDeleted", course);
        }
    }
}
