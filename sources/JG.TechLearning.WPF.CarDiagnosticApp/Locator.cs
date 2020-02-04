using Autofac;
using JG.TechLearning.WPF.CarDiagnosticApp.Version;
using JG.TechLearning.WPF.CarDiagnosticApp.ViewModel;

namespace JG.TechLearning.WPF.CarDiagnosticApp
{
    public class Locator
    {

        private readonly ContainerBuilder containerBuilder;
        private readonly IContainer container;

        public Locator()
        {
            containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<MainViewModel>();
            containerBuilder.RegisterType<AssemblyVersionResolver>().As<IVersionResolver>();

            container = containerBuilder.Build();
        }

        public MainViewModel MainViewModel
        {
            get
            {
                return container.Resolve<MainViewModel>();
            }
        }

    }
}
