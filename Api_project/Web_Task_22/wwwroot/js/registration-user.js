const validateRegistrations = new JustValidate("#RegistrationsUserForm");



validateRegistrations.addField('#Login', [{
    rule: 'required',
    errorMessage: 'Поле логина не должно быть пустым',
},
{
  rule: 'minLength',
  value: 3,
  errorMessage: "Логин должен быть больше 2 симвлов"
},
{
  rule: 'maxLength',
  value: 10,
  errorMessage: "Логин не может быть больше 11 сомволов"
},
{
  rule: 'customRegexp',
  value: /[a-zA-Z0-9]+$/gi,
  errorMessage: 'Логин должен состоять из латинского алфавита или цифв'
},
]);


validateRegistrations.addField('#Pssword', [
  {
    rule: 'required',
    errorMessage: 'Поле пароль не должно быть пустым',
  },
  {
    rule: 'minLength',
    value: 5,
    errorMessage: "Пароль должен быть более 5 символов"
  },
  {
    rule: 'maxLength',
    value: 15,
    errorMessage: "Пароль не должен превышать 15 символов"
  },
  {
     rule: 'strongPassword',
     errorMessage: 'В пароле должны быть буквы латинского алфавиты, цифры и не буквенно-цифровой символ(ы)',
  },


]);

validateRegistrations.addField('#Try-pssword', [
  {
    rule: 'required',
    errorMessage: 'Повторите пароль',
  },
  {
    rule: "function",
    validator: function (name, value) {

      var password = document.querySelector("#Pssword");
      var passwordConfirmation = document.querySelector("#Try-pssword");

      return password.value == passwordConfirmation.value;
    },
    errorMessage: 'Пароль не совпадает',
  },
 

]);

validateRegistrations.onSuccess((event) => {
  document.getElementById("RegistrationsUserForm").submit();
});




const defaultSelect = () => {
  const element = document.querySelector('.select-default');
  const choices = new Choices(element, {
      searchEnabled: false,
      noResultsText: false,
      shouldSort: false,
  });
};

defaultSelect();