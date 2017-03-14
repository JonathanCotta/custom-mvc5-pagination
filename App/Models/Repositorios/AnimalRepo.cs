using App.Models.Dominio;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models.Repositorios
{
    public class AnimalRepo : Repositorio<Animal>
    {  
        public List<Animal> Search(string s)
        {
            using (var session = factory.OpenSession())
            {
                return session.Query<Animal>().Where(a => a.Nome.Contains(s) || a.Habitat.Contains(s) || a.Tipo.Contains(s)).ToList();
            }
        } 
    }
}