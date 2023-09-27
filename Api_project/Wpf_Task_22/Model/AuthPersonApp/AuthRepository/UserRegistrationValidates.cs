using System;
using System.ComponentModel;

namespace Wpf_Task_22.Model.AuthPersonApp.AuthRepository
{
    internal class UserRegistrationValidates : UserRegistration, IDataErrorInfo

    {
        private byte value;

        private bool LoginPropValidates;
        private bool PasswordValidates;
        private bool ConfirmPasswordValidates;

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;

                if (value >= 3)
                {
                    switch (columnName)
                    {
                        case "LoginProp":

                            LoginValidatesMethad(ref error);
                            break;

                        case "Password":

                            PasswordValidatesMethad(ref error);
                            break;

                        case "ConfirmPassword":

                            ConfirmPasswordValidatesMethad(ref error);
                            break;
                    }

                    return error;
                }
                else
                {
                    ++value;
                    return error;
                }
            }
        }

        private void LoginValidatesMethad(ref string error)
        {
            if (LoginProp.Length < 3 || LoginProp.Length > 11)
            {
                error = "Логин должен быть больше 2 букв но меньше 11";
                LoginPropValidates = false;
                return;
            }

            string text = LoginProp.ToLower();

            byte[] Ch = System.Text.Encoding.Default.GetBytes(text);

            foreach (var ch in Ch)
            {
                if (!(ch >= 97 && ch <= 122) && !(ch >= 48 && ch <= 57))
                {
                    error = "Логин должен состоять из букв английского алфавита";
                    LoginPropValidates = false;
                    break;
                }
            }

            if (error.Length <= 3)
            {
                LoginPropValidates = true;
            }
        }


        private void PasswordValidatesMethad(ref string error)
        {
            if (Password.Length < 5 || Password.Length >= 15)
            {
                error = "Пароль должен быть больше 5 букв но меньше 15";
                PasswordValidates = false;
                return;
            }

            int countNumber = 0;
            int countSimbol = 0;

            string textPassword = Password.ToLower();

            byte[] ChPassword = System.Text.Encoding.Default.GetBytes(textPassword);

            foreach (var ch in ChPassword)
            {
                if (!(ch >= 97 && ch <= 122) &&
                    !(ch >= 48 && ch <= 57) &&
                    !(ch >= 33 && ch <= 47) &&
                    !(ch >= 58 && ch <= 64))
                {
                    error = "Пароль должен состоять из букв английского алфавита";
                    PasswordValidates = false;
                    break;
                }
                else if ((ch >= 48 && ch <= 57))
                {
                    ++countNumber;

                }
                else if (((ch >= 33 && ch <= 47) || (ch >= 58 && ch <= 64)))
                {
                    ++countSimbol;

                }
            }

            if (error != null && error.Length > 3)
            {
                return;
            }
            else if (countNumber < 2)
            {
                error = "Пароль должено быть хотя бы 2 цифры";
                PasswordValidates = false;

            }
            else if (countSimbol < 1)
            {
                error = "Пароль должено быть хотя бы 1 знак препинания или пунктуации";
                PasswordValidates = false;
            }
            else
            {
                PasswordValidates = true;
            }

        }

        private void ConfirmPasswordValidatesMethad(ref string error)
        {
            if (Password != ConfirmPassword)
            {
                ConfirmPasswordValidates = false;
                error = "Пароль должен совпадать";
                
            }
            else
            {
                ConfirmPasswordValidates = true;
            }

        }

        public string Error
        {
            get
            {
                return "что то пошло не так";
            }
        }

        public bool TrueValidates()
        {
            if (LoginPropValidates &&
                PasswordValidates &&
                ConfirmPasswordValidates)
            {
                return true;
            }

            return false;
        }
    }
}
