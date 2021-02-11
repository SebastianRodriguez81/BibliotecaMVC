using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;

namespace BibliotecaMVC.Models
{
    public class Autor
    {
        //atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDAutor { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public ICollection<Libro> Libros { get; set; }

    }
}
