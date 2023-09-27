using System;
using System.ComponentModel;


namespace Wpf_Task_22.Model.Data.Validates
{
    internal class PersonalDataValidates : PersonalData, IDataErrorInfo
    {
        private bool validatesPhoneNumber,
                     validatesAddress,
                     validatesDescription;


        public string this[string columnName]
        {
            get
            {


                string error = String.Empty;

                switch (columnName)
                {
                    case "PhoneNumber":

                        PhoneNumberValidate(ref error);

                        break;

                    case "Address":

                        AddressValidate(ref error);

                        break;

                    case "Description":

                        DescriptionValidate(ref error);

                        break;
                }

                return error;
            }
        }

        private void PhoneNumberValidate(ref string error)
        {
            if (PhoneNumber != null)
            {

                if (PhoneNumber.Length == 1)
                {
                    validatesPhoneNumber = false;
                    return;
                }
                else if (PhoneNumber.Length <= 10)
                {
                    validatesPhoneNumber = false;
                    error = $"Заполните поле Номер телефона до конца";
                    return;
                }

                string text = PhoneNumber.ToLower();

                byte[] Ch = System.Text.Encoding.Default.GetBytes(text);

                foreach (var ch in Ch)
                {
                    if (!(ch >= 48 && ch <= 57))
                    {
                        error = $"Поле Номер телефона должно состоять цифр";
                        validatesPhoneNumber = false;
                        return;
                    }
                }

                validatesPhoneNumber = true;
            }

        }


        private void AddressValidate(ref string error)
        {
            if (Address != null)
            {
                if (Address.Length == 0)
                {
                    error = "Поле Адрес не должно быть пустым";
                    validatesAddress = false;
                    return;
                }
                else if (Address.Length <= 20)
                {
                    error = "Поле Адрес должно быть больше 20 симвлов";
                    validatesAddress = false;
                    return;
                }
                else if (Address.Length >= 100)
                {
                    error = "Поле Адрес должно быть меньше 100 симвлов";
                    validatesAddress = false;
                    return;
                }

                string text = Address.ToLower();

                byte[] Ch = System.Text.Encoding.Default.GetBytes(text);

                foreach (var ch in Ch)
                {
                    if (!(ch >= 224 && ch <= 255) 
                        && !(ch >= 184)
                        && !(ch >= 48 && ch <= 57) 
                        && !(ch >= 32 && ch <= 47)
                        && !(ch >= 58 && ch <= 64))
                    {
                        error = $"Поле Адрес должно состоять из букв русского алфавита";
                        validatesAddress = false;
                        return;
                    }
                }

                validatesAddress = true;
            }
        }


        private void DescriptionValidate(ref string error)
        {
            if (Description != null)
            {
                if (Description.Length == 0)
                {
                    error = "Поле Описание не должно быть пустым";
                    validatesDescription = false;
                    return;
                }
                else if (Description.Length <= 20)
                {
                    error = "Поле Описание должно быть больше 20 симвлов";
                    validatesDescription = false;
                    return;
                }
                else if (Description.Length >= 500)
                {
                    error = "Поле Описание должно быть меньше 500 симвлов";
                    validatesDescription = false;
                    return;
                }

                validatesDescription = true;
            }
        }


        public bool Validates()
        {
            if (validatesAddress &&
                validatesDescription &&
                validatesPhoneNumber)
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
