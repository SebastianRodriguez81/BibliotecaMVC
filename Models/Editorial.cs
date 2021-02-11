using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaMVC.Models
{
    public class Editorial
    {
        //atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDEditorial { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public ICollection<Libro> Libros { get; set; }

    }
}
