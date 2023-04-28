﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WonderlandAnimal.Models
{
    [Table("accounts")]
    public class Account :Entity
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }

    }
}
