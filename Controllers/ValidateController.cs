using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using validator.Models;
using System;
using System.Threading.Tasks;

namespace validatorControllers
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
        public IEnumerable<Validate> Get()
        {

            Random rng = new Random();
            bool randomBool = rng.Next(0, 2) > 0;
            return Enumerable.Range(1, 1).Select(index => new Validate
            {
                Date = DateTime.Now.AddDays(index),
                Validation = randomBool
            })
            .ToArray();
        }

        // GET by Id action

        // POST action

        // PUT action

        // DELETE action
    }
}