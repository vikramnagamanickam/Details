using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyDataAccessLayer;
using MyDataAccessLayer.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CricketersDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class CricketersDetailsController : ControllerBase
    {
        ICricketersDetailsRepository crics = null;
       
        public CricketersDetailsController(ICricketersDetailsRepository Regs)
        {
            crics = Regs;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<CricketDetails> Get()
        {
            return crics.SelectALLUser();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{username}")]
        public CricketDetails Get(string username)
        {
            return crics.SelectUserByUsername(username);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] CricketDetails cric)
        {
            crics.RegisterUser(cric);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] CricketDetails value)
        {
            crics.UpdateUser(value);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            crics.DeleteUser(id);
        }
    }
}
