using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDataWorks2App
{
    public class Employee : IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Name":
                        break;
                    case "Age":
                        if((Age < 0) || (Age > 100))
                        {
                            error = "Age in range 0..100";
                        }
                        break;
                    case "Position":
                        if (Position == "President")
                            error = "Position Prseident is not available";
                        break;
                }
                return error;
            }
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }

        public string Error => throw new NotImplementedException();
    }
}
