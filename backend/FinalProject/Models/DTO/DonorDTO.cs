﻿using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models.DTO
{
    public class DonorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
