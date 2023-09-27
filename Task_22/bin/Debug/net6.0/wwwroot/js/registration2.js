const validateRegistrations = new JustValidate("#LogInForm-registrations");



validateRegistrations.addField('#Login-registrations', [{
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
  value: 20,
  errorMessage: "Логин не может быть больше 21 сомволов"
},
{
  rule: 'customRegexp',
  value: /[a-zA-Z0-9]+$/gi,
  errorMessage: 'Логин должен состоять из латинского алфавита или цифв'
},
]);


validateRegistrations.addField('#Password-registrations', [
  {
    rule: 'required',
    errorMessage: 'Поле пароль не должно быть пустым',
  },
  {
    rule: 'minLength',
    value: 5,
    errorMessage: "Пароль должен быть долее 5 символов"
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

validateRegistrations.addField('#Password-confirmation', [
  {
    rule: 'required',
    errorMessage: 'Повторите пароль',
  },
  {
    rule: "function",
    validator: function (name, value) {

      var password = document.querySelector("#Password-registrations");
      var passwordConfirmation = document.querySelector("#Password-confirmation");

      return password.value == passwordConfirmation.value;
    },
    errorMessage: 'Пароль не совпадает',
  },
 

]);

validateRegistrations.onSuccess((event) => {
  document.getElementById("LogInForm-registrations").submit();
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