using B4RX63_HFT_2021221.Logic;
using B4RX63_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
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

        public DogController(IDogLogic dl)
        {
            this.dl = dl;
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
        }

        // PUT /dog
        [HttpPut]
        public void Put([FromBody] Dog value)
        {
            dl.Update(value);
        }

        // DELETE dog/
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dl.Delete(id);
        }
    }
}

