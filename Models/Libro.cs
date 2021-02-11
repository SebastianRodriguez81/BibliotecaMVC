using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaMVC.Models
{
    public class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDLibro { get; set; }
        public string Titulo { get; set; }
        public int IDAutor { get; set; }
        public Autor Autor { get; set; }
        public int IDGenero { get; set; }
        public Genero Genero { get; set; }
        public int IDEditorial { get; set; }
        public Editorial Editorial { get; set; }
        



    }
}
