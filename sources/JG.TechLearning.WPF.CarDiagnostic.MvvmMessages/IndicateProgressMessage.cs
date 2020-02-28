using JG.TechLearning.WPF.CarDiagnostic.GlobalCommonTypes.Enums;
using System;

namespace JG.TechLearning.WPF.CarDiagnostic.MvvmMessages
{
    public class IndicateProgressMessage
    {
        public Action<ProgressResult> OnLoadingEndedCallback;
    }
}
