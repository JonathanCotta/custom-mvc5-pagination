using App.Models.Dominio;
using App.Models.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.App_Start
{
    public static class Db
    {
        public static void Seed()
        {
            using (var repo = new AnimalRepo())
            {
                repo.Add(new Animal { Nome = "Gato", Habitat = "Domestico", Tipo = "Mamifero" });
                repo.Add(new Animal { Nome = "Cachorro", Habitat = "Domestico", Tipo = "Mamifero" });
                repo.Add(new Animal { Nome = "Borboleta", Habitat = "Selvagem", Tipo = "Inseto" });
                repo.Add(new Animal { Nome = "Golfinho", Habitat = "Marinho", Tipo = "Mamifero" });
                repo.Add(new Animal { Nome = "Barata", Habitat = "Urbano", Tipo = "Inseto" });
                repo.Add(new Animal { Nome = "Crocodilo", Habitat = "Locostre", Tipo = "Reptil" });
                repo.Add(new Animal { Nome = "Abelha", Habitat = "Selvagem", Tipo = "Inseto" });
                repo.Add(new Animal { Nome = "Vaca", Habitat = "Rural", Tipo = "Mamifero" });
                repo.Add(new Animal { Nome = "Jabuti", Habitat = "Selvagem", Tipo = "Reptil" });
                repo.Add(new Animal { Nome = "Tubarão", Habitat = "Marinho", Tipo = "Peixe" });
                repo.Add(new Animal { Nome = "Camaleão", Habitat = "Selvagem", Tipo = "Reptil" });
                repo.Add(new Animal { Nome = "Aranha", Habitat = "Selvagem", Tipo = "Inseto" });
                repo.Add(new Animal { Nome = "Ovelha", Habitat = "Rural", Tipo = "Mamifero" });
                repo.Add(new Animal { Nome = "Tartaruga", Habitat = "Marinho", Tipo = "Reptil" });
                repo.Add(new Animal { Nome = "Arraia", Habitat = "Marinho", Tipo = "Peixe" });
            }
        }

        public static void Clean()
        {
            using (var repo = new AnimalRepo())
            {               
                foreach (var animal in repo.GetAll())
                {
                    repo.Delete(animal.Id);
                }
            }
        }
    }
}