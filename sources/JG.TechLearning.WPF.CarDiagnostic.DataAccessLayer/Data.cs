using System;

namespace JG.TechLearning.WPF.CarDiagnostic.IDataSourceNS
{
    public class Data
    {
        public Data(object value, string adddress)
        {
            Value = value;
            Address = adddress;
        }

        private object _value;

        public object Value 
        {
            get
            {
                return _value;
            }
            
            set
            {
                _value = value;
                ValueChanged?.Invoke(this, _value);
            }
        }
        public string Address { get;}

        public event EventHandler<object> ValueChanged;

    }
}
