using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using LayeredSolution.BusinessLayer;
using LayeredSolution.DataLayer;
using LayeredSolution.BusinessLayer.EmployeeViews;
using LayeredSolution.BusinessLayer.EmployeeModels;

namespace LayeredSolution.Szamlazo
{
    static class Program
    {
        public static IContainer Container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(
                typeof(IProductService).Assembly);
            builder.RegisterType<ProductsForm>()
                .Named<Form>("Products")
                .InstancePerLifetimeScope();
            builder.Register(context => new OrdersForm(context.Resolve<IOrderService>()))
                .Named<Form>("Orders")
                .InstancePerLifetimeScope();
            builder.RegisterType<LoginViewModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<LoginForm>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<LoggedInEmployeeService>().As<ILoggedInEmployeeService>().SingleInstance();
            builder.RegisterType<MessageService>().As<IMessageService>().SingleInstance();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerLifetimeScope();
            //builder.RegisterInstance(new object());
            Container = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
