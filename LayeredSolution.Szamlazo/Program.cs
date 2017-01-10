using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using LayeredSolution.BusinessLayer;
using LayeredSolution.BusinessLayer.EmployeeModels;
using LayeredSolution.DataLayer;
using LayeredSolution.Szamlazo.EmployeeViews;
using LayeredSolution.Szamlazo.OrderViews;

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
            builder.RegisterType<EmployeeService>()
                .As<IEmployeeService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<LoginViewModel>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<LoginForm>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<LoggedInEmployeeService>()
                .As<ILoggedInEmployeeService>()
                .SingleInstance();
            builder.RegisterType<MessageService>()
                .As<IMessageService>()
                .SingleInstance();

            builder.RegisterType<EmployeeListViewModel>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<EmployeeListForm>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<EmployeeEditViewModel>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<EmployeeEditForm>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<NewItemForm>()
               .AsSelf()
               .InstancePerLifetimeScope();
            builder.RegisterType<NewItemViewModel>()
               .AsSelf()
               .InstancePerLifetimeScope();

            //builder.RegisterInstance(new object());
            Container = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
