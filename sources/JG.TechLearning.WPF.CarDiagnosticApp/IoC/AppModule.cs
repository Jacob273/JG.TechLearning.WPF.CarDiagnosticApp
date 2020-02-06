using Autofac;
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
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<ProgressBarViewModel>();
            builder.RegisterType<AssemblyVersionResolver>().As<IVersionResolver>();
            builder.RegisterType<ProgressWindow>();

            builder.Register((c) =>
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
