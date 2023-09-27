using System;
using System.ComponentModel;


namespace Wpf_Task_22.Model.Data
{
    internal class PersonValidates : Person, IDataErrorInfo
    {
        private bool validatesName,
                     validatesSurname,
                     validatesPatomic;

        public string this[string columnName]
        { 
            get 
            {
                string error = String.Empty;

                switch (columnName)
                {
                    case "Name":

                        validatesName = ValidatesStr(ref error, Name, 1);

                        break;

                    case "Surname":

                        validatesSurname = ValidatesStr(ref error, Surname, 2);

                        break;

                    case "Patomic":

                        validatesPatomic = ValidatesStr(ref error, Patomic, 3);
                        
                        break;
                }

                return error;
            }
        
        }


        private bool ValidatesStr(ref string error, string Field, byte numberField)
        {
            if (Field != null)
            {
                string str = GetField(numberField);

                if (Field.Length == 0)
                {
                    error = $"Поле {str} не должно быть пустым";

                    return false;
                }
                else if (Field.Length <= 2)
                {
                    error = $"Поле {str} должно быть больше 2 симвлов";

                    return false;
                }
                else if (Field.Length >= 20)
                {
                    error = $"Поле {str} не может быть больше 20 сомволов";

                    return false;
                }

                string text = Field.ToLower();

                byte[] Ch = System.Text.Encoding.Default.GetBytes(text);

                foreach (var ch in Ch)
                {
                    if (!(ch >= 224 && ch <= 255) && !(ch >= 184))
                    {
                        error = $"Поле {str} должно состоять из букв русского алфавита";

                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        private string GetField(byte numberField)
        {
            switch (numberField)
            {
                case 1:
                    return "Имя";

                case 2:
                    return "Фамилия";

                case 3:
                    return "Отчество";

                default:
                    return "";
            }

        }

        public bool Validates()
        {
            if (validatesName &&
                validatesSurname &&
                validatesPatomic)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public string Error
        {
            get 
            {
                return "Что то не так";
            
            }
        
        }
    }
}
