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
    public class ValidatorController : ControllerBase
    {
        public ValidatorController()
        {
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<Validate>> GetAll() =>
            ValidateService.GetAll();

        // [HttpGet]
        // public IEnumerable<Validate> Get()
        // {

        //     Random rng = new Random();
        //     bool randomBool = rng.Next(0, 2) > 0;
        //     return Enumerable.Range(1, 1).Select(index => new Validate
        //     {
        //         Date = DateTime.Now.AddDays(index),
        //         Validation = randomBool
        //     })
        //     .ToArray();
        // }

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
            var envelope = $"{{ \"Date\": \"{date}\", \"Validation\": {validation} }}";
            return CreatedAtAction(nameof(Create), new { id = validate.Id }, envelope);
            // return Content(envelope, "application/json", Encoding.UTF8);
        }

        // PUT action

        // DELETE action
    }
}