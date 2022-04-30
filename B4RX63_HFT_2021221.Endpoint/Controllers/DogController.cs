using B4RX63_HFT_2021221.Endpoint.Services;
using B4RX63_HFT_2021221.Logic;
using B4RX63_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace B4RX63_HFT_2021221.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {

        IDogLogic dl;
        IHubContext<SignalRHub> hub;

        public DogController(IDogLogic dl, IHubContext<SignalRHub> hub)
        {
            this.dl = dl;
            this.hub = hub;
        }

        // GET: /dog
        [HttpGet]
        public IEnumerable<Dog> Get()
        {
            return dl.ReadAll();
        }

        // GET /dog
        [HttpGet("{id}")]
        public Dog Get(int id)
        {
            return dl.Read(id);
        }

        // POST /dog
        [HttpPost]
        public void Post([FromBody] Dog value)
        {
            dl.Create(value);
            this.hub.Clients.All.SendAsync("DogCreated", value);
        }

        // PUT /dog
        [HttpPut]
        public void Put([FromBody] Dog value)
        {
            dl.Update(value);
            this.hub.Clients.All.SendAsync("DogUpdated", value);
        }

        // DELETE dog/
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var dog = dl.Read(id);
            dl.Delete(id);
            this.hub.Clients.All.SendAsync("DogDeleted", dog);
        }
    }
}

