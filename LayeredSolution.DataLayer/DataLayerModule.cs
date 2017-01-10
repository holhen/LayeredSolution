using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace LayeredSolution.DataLayer
{
    public class DataLayerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SampleContext>()
                .As<ISampleContext>()
                .WithParameter("connectionString", "Webshop")
                .InstancePerLifetimeScope();
        }
    }
}
