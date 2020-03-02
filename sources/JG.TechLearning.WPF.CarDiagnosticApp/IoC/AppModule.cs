using Autofac;
using JG.TechLearning.WPF.CarDiagnostic.GlobalCommonTypes;
using JG.TechLearning.WPF.CarDiagnostic.IDataSourceNS;
using JG.TechLearning.WPF.CarDiagnostic.IDataSourcesPossessorNS;
using JG.TechLearning.WPF.CarDiagnostic.Mock;
using JG.TechLearning.WPF.CarDiagnostic.UserControlNS.Dialogs;
using JG.TechLearning.WPF.CarDiagnostic.ViewModel;
using JG.TechLearning.WPF.CarDiagnosticApp.Windows;
using NLog;
using NLog.Config;
using NLog.Targets;
using System.Linq;
using System.Windows.Media;
using JG.TechLearning.WPF.CarDiagnostic.Common;
using JG.TechLearning.WPF.CarDiagnostic.Common.Interfaces;

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
            builder.RegisterType<MockDataPossessor>().As<IDataSourcesPossessor>().SingleInstance();

            builder.Register((ctx) =>
            {
                var possesor = ctx.Resolve<IDataSourcesPossessor>();
                var carsDA = possesor.DataSources
                                     .Select(x => x)
                                     .Where(x => x.Name.Equals(Constants.CarsDataSourceName))
                                     .FirstOrDefault();
                return carsDA;
            }).Keyed<IDataSource>(Constants.CarsDataSourceName).SingleInstance();

            builder.RegisterType<DialogWindowService>().As<IWindowService>();
            builder.RegisterType<AssemblyVersionResolver>().As<IVersionResolver>();
            builder.RegisterType<Languages>().As<ILanguages>();
            //viewmodels
            builder.Register((ctx) =>
            {
                var carsDataSource = ctx.ResolveNamed<IDataSource>(Constants.CarsDataSourceName);
                return new LiveDataViewModel(carsDataSource);

            }).As<LiveDataViewModel>().SingleInstance();
            
            builder.RegisterType<ApplicationSettingsViewModel>();

            builder.Register(ctx => new MainViewModel(ctx.Resolve<IVersionResolver>(), ctx.Resolve<IWindowService>(), ctx.Resolve<LiveDataViewModel>(), ctx.Resolve<ApplicationSettingsViewModel>()));
            builder.RegisterType<ProgressBarViewModel>();
            

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
