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
    public class OwnerController : ControllerBase
    {

        IOwnerLogic ol;
        IHubContext<SignalRHub> hub;

        public OwnerController(IOwnerLogic ol, IHubContext<SignalRHub> hub)
        {
            this.ol = ol;
        }

        // GET: /owner
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return ol.ReadAll();
        }

        // GET /owner/
        [HttpGet("{id}")]
        public Owner Get(int id)
        {
            return ol.Read(id);
        }

        // POST /owner
        [HttpPost]
        public void Post([FromBody] Owner value)
        {
            ol.Create(value);
            this.hub.Clients.All.SendAsync("OwnerCreated", value);
        }

        // PUT /owner
        [HttpPut]
        public void Put([FromBody] Owner value)
        {
            ol.Update(value);
            this.hub.Clients.All.SendAsync("OwnerUpdated", value);
        }

        // DELETE owner/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var owner = ol.Read(id);
            ol.Delete(id);
            this.hub.Clients.All.SendAsync("OwnerDeleted", owner);
        }
    }
}
