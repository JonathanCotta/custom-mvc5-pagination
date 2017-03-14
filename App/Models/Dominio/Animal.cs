using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models.Dominio
{
    public class Animal
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Tipo { get; set; }
        public virtual string Habitat { get; set; }
    }
}