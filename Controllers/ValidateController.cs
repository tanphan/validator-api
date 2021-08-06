using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using validator.Models;
using validator.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace validator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ValidatorController : ControllerBase
    {
        public ValidatorController()
        {
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<Validate>> GetAll() =>
            ValidateService.GetAll();

        [HttpGet("random")]
        public IEnumerable<RandomFlag> Get()
        {

            Random rng = new Random();
            bool randomBool = rng.Next(0, 2) > 0;
            return Enumerable.Range(1, 1).Select(index => new RandomFlag
            {
                flag = randomBool
            })
            .ToArray();
        }

        // GET by Id action

        [HttpGet("{id}")]
        public ActionResult<Validate> Get(int id)
        {
            var validate = ValidateService.Get(id);

            if(validate == null)
                return NotFound();

            return validate;
        }
        // POST action
        [HttpPost]
        public IActionResult Create(Validate validate)
        {   
            Random rng = new Random();
            bool randomBool = rng.Next(0, 2) > 0;

            DateTime date = DateTime.Now;
            bool validation = randomBool;

            ValidateService.Add(validate);
            
            if (validate.flag==false)
            {
                var envelope = Enumerable.Range(1, 1).Select(index => new ValidateResponse
                {
                    Date = DateTime.Now.AddDays(index),
                    ResponseDotNet = "Message not accepted"
                })
                .ToArray();

                return new JsonResult(envelope);
            }else
            {
                var envelope = Enumerable.Range(1, 1).Select(index => new ValidateResponse
                {
                    Date = DateTime.Now.AddDays(index),
                    ResponseDotNet = "Message accepted"
                })
                .ToArray();

                return new JsonResult(envelope);
            }
            // var envelope = $"{{ \"Date\": \"{date}\", \"Validation\": {validation} }}";
            
            // return CreatedAtAction(nameof(Create), new { id = validate.Id }, validate);
            // return Content(envelope, "application/json", Encoding.UTF8);
        }

        // PUT action

        // DELETE action
    }
}