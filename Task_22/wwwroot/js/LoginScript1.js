const validate = new JustValidate('#LogInForm');


validate.addField('#Login', [{
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
    value: /[a-zA-z0-9]+$/gi,
    errorMessage: 'Логин должен состоять из букв латинского алфавита или цифв'
},
]);


validate.addField('#Password', [
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

validate.onSuccess((event) => {
    document.getElementById("LogInForm").submit();
});
