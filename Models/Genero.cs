using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaMVC.Models
{
    public class Genero
    {
        //atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDGenero { get; set; }
        public string NombreGenero { get; set; }
        public ICollection<Libro> Libros { get; set; }
        //constructor



    }
}
