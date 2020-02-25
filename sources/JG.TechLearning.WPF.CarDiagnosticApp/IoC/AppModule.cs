using Autofac;
using JG.TechLearning.WPF.CarDiagnosticApp.UI;
using JG.TechLearning.WPF.CarDiagnosticApp.Version;
using JG.TechLearning.WPF.CarDiagnosticApp.ViewModel;
using JG.TechLearning.WPF.CarDiagnosticApp.Windows;
using NLog;
using NLog.Config;
using NLog.Targets;

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
            builder.RegisterType<DialogWindowService>().As<IWindowService>();
            builder.RegisterType<AssemblyVersionResolver>().As<IVersionResolver>();

            //viewmodels
            builder.Register(ctx => new MainViewModel(ctx.Resolve<IVersionResolver>(), ctx.Resolve<IWindowService>(), new LiveDataViewModel()));
            builder.RegisterType<ProgressBarViewModel>();
            builder.RegisterType<LiveDataViewModel>();

            builder.RegisterType<ProgressWindow>();

            builder.Register((ctx) =>
            {
                var config = new LoggingConfiguration();
                var fileTarget = new FileTarget("logfile")
                {
                    FileName = $"CarDiagnostic-logfile.txt",
                    Layout = "${longdate} [${level:uppercase=true}][${threadid}]:${message}"
                };
                config.AddRule(LogLevel.Info, LogLevel.Fatal, fileTarget);
                return config;
            }).As<LoggingConfiguration>();
        }
    }
}
