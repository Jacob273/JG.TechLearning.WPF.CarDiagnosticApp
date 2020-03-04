WPF application to simulate car diagnostics.

Mvvm, C#, Blend '19 used for controls design.

  ##### CI-Build: [![Build status](https://ci.appveyor.com/api/projects/status/lylpjrda9ji1v7hy?svg=true)](https://ci.appveyor.com/project/Jacob273/jg-techlearning-wpf-cardiagnosticapp)

| Project name                                                     | Description                                                                          | Type                                  |
|------------------------------------------------------------------|--------------------------------------------------------------------------------------|---------------------------------------|
| JG.TechLearning.WPF.CarDiagnosticApp                             | Main app for car diagnostic.                                                         | WPF App targeting .NET Core 3.0       |
| JG.TechLearning.WPF.CarDiagnostic.Converter                      | IValueConverters implementations.                                                    | Class Library targeting .NET Core 3.0 |
| JG.TechLearning.WPF.CarDiagnostic.DataSources.CarsMockDataSource | Data source (car) mock.                                                              | .NET Standard 2.0                     |
| JG.TechLearning.WPF.CarDiagnostic.DataSources.IDataSource        | Interfaces and necessary models that are required by  data source to be implemented. | .NET Standard 2.0                     |
| JG.TechLearning.WPF.CarDiagnostic.DataSources.IRegistry          | Interface for data sources registry.                                                 | .NET Standard 2.0                     |
| JG.TechLearning.WPF.CarDiagnostic.DataSources.MockRegistry       | Mock of data sources registry.                                                       | .NET Standard 2.0                     |
| JG.TechLearning.WPF.CarDiagnostic.Common                         | Common types / implementations used across several projects.                         | .NET Standard 2.0                     |
| JG.TechLearning.WPF.CarDiagnostic.ICommon                        | Common Interfaces.                                                                   | .NET Standard 2.0                     |
| JG.TechLearning.WPF.CarDiagnostic.MvvmMessages                   | Messages flying around the system  to which registration can be made.                | .NET Standard 2.0                     |
| JG.TechLearning.WPF.CarDiagnostic.UserControl                    | WPF xaml controls library (car-related).                                             | Class Library targeting .NET Core 3.0 |
| JG.TechLearning.WPF.CarDiagnostic.ViewModel                      | Viewmodels represents data that can  be shown in car diagnostic system.              | .NET Standard 2.0                     |
  
   ### Main view of the application (icons were made in blend)
  ![app main screen](./app_main_screen.jpg)

  ### Progress bar control
  ![Progress bar control](./car_diagnostic_progresscontrol.gif)
  

