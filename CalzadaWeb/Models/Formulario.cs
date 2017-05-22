using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CalzadaWeb.Models
{
    public class Formulario
    {
        [Required(ErrorMessage = "El nombre es un campo requerido")]
        public string Name { get; set; }

      
        [Required(ErrorMessage = "El mail es un campo requerido")]
        [EmailAddress(ErrorMessage = "Direccion de correo invalida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El mensaje es un campo requerido")]
        public string Message { get; set; }

        [Required(ErrorMessage = "El telefono es un campo requerido")]
        [Phone(ErrorMessage = "Numero de telefono invalido")]
        public string Phone { get; set; }

     
    }
}