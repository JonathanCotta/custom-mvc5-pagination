using App.Models.Dominio;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models
{
    public class DbConf
    {   
        public static ISessionFactory CreateSessionFactory()
        {
            var cfg = new StoreConfiguration();                       
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString("Server=JONATHAN-PC;Database=NatureDB;User ID=sa;password=kilo1234;"))
                .Mappings(m =>m.AutoMappings.Add(AutoMap.AssemblyOf<Animal>(cfg)
                .Conventions.Add(
                       Table.Is(x => x.EntityType.Name + "s"),
                       PrimaryKey.Name.Is(x => "id")                       
                    )))
                .BuildSessionFactory();
        } 
    }

    public class StoreConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.Namespace == "App.Models.Dominio";
        }         
    }
}