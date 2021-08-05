using validator.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace validator.Services
{
    public static class ValidateService
    {
        static List<Validate> Validates { get; }
        static int nextId = 3;
        static ValidateService()
        {
            Validates = new List<Validate>
            {
                new Validate { Id = 1, messageid = "Transaction 1"},
                new Validate { Id = 2, messageid = "Transaction 2"}
            };
        }

        public static List<Validate> GetAll() => Validates;

        public static Validate Get(int id) => Validates.FirstOrDefault(p => p.Id == id);

        public static void Add(Validate Validate)
        {
            Validate.Id = nextId++;
            Validates.Add(Validate);
        }

        public static void Delete(int id)
        {
            var Validate = Get(id);
            if(Validate is null)
                return;

            Validates.Remove(Validate);
        }

        public static void Update(Validate Validate)
        {
            var index = Validates.FindIndex(p => p.Id == Validate.Id);
            if(index == -1)
                return;

            Validates[index] = Validate;
        }
    }
}