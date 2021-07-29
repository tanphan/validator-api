
using System;

namespace validator.Models
{
    public class Validate
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

    }

    public class ValidateResponse
    {
        public DateTime Date { get; set; }
        public bool Validation { get; set; }
    }
}
