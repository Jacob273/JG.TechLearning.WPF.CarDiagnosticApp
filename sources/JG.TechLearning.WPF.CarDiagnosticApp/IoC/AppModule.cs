using Autofac;
using JG.TechLearning.WPF.CarDiagnosticApp.Version;
using JG.TechLearning.WPF.CarDiagnosticApp.ViewModel;
using JG.TechLearning.WPF.CarDiagnosticApp.Windows;

namespace JG.TechLearning.WPF.CarDiagnosticApp.IoC
{
    /// <summary>
    /// 
    /// </summary>
    public class AppModule : Module
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<ProgressBarViewModel>();
            builder.RegisterType<AssemblyVersionResolver>().As<IVersionResolver>();
            builder.RegisterType<ProgressWindow>();
        }
    }
}
