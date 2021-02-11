using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaMVC.Models
{
    public class Usuario
    {   //atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Contraseña { get; set; }
        //public ArrayList librosLeidos { get; set; }

        



    }
}
