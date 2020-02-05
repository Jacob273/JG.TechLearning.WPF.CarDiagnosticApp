using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JG.TechLearning.WPF.CarDiagnosticApp.IoC
{
    public static class IoCKernel
    {
        private static IContainer _container;

        public static T Get<T>()
        {
            return _container.Resolve<T>();
        }

        public static void Initialize(Module module)
        {
            if (_container == null)
            {
                var builder = new ContainerBuilder();
                builder.RegisterModule(module);
                _container = builder.Build();
            }
        }
    }
}
