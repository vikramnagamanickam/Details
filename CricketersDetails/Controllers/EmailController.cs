using BussinessLayer;
using BussinessLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CricketersDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailRepository _mailSending;
        private readonly IConfiguration _configuration;

        public EmailController(IEmailRepository mailSending,IConfiguration configuration)
        {
            _configuration = configuration;
            _mailSending = mailSending;
        }
        // GET: api/<EmailController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EmailController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmailController>
        [HttpPost]
        public ActionResult<Email> Post([FromBody] Email value)
        {
            var fromaddress = _configuration.GetValue<string>("SMTP:Fromaddress");
            var password = _configuration.GetValue<string>("SMTP:Password");
            _mailSending.SendEmail(fromaddress, password, value.ToAddress, value.Subject, value.Body);
            return Ok();

        }
         
        // PUT api/<EmailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
