using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using LayeredSolution.DataLayer;

namespace LayeredSolution.BusinessLayer
{
    public class BusinessLayerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>()
                .As<IProductService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<OrderService>()
                .As<IOrderService>()
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyModules(
                typeof (ISampleContext).Assembly);
        }
    }
}
