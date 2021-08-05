
using System;

namespace validator.Models
{
    public class Validate
    {

        public int Id { get; set; }
        // public string messageid { get; set; }
        public bool flag { get; set; }
      

    }

    public class ValidateResponse
    {
        public DateTime Date { get; set; }
        // public bool Validation { get; set; }
        public string ResponseDotNet { get; set; }
    }
}
