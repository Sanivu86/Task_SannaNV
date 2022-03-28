using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


//@author Sanna Nieminen-Vuorio
//Last modified 2.3.2022
//Non-functional class for all the attributes

namespace RiihiTask_SannaNV.Models
{
    public class Info
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Etunimi on pakollinen")]
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public bool Permission { get; set; }
    }
}