const validate = new JustValidate('#SubmittingAForm');
const selector = document.querySelector("input[type='tel']");
const im = new Inputmask("+7 (999)-999-99-99");


im.mask(selector);


validate.addField('#Name', [{
    rule: 'required',
    errorMessage: 'Поле имени не должно быть пустым',
},
{
    rule: 'minLength',
    value: 3,
    errorMessage: "Имя должно быть больше 2 симвлов"
},
{
    rule: 'maxLength',
    value: 10,
    errorMessage: "Имя не может быть больше 11 сомволов"
},
{
    rule: 'customRegexp',
    value: /[а-яА-я]+$/gi,
    errorMessage: 'Имя должен состоять из букв русского алфавита'
},
]);


validate.addField('#Surname', [{
    rule: 'required',
    errorMessage: 'Поле фамилии не должно быть пустым',
},
{
    rule: 'minLength',
    value: 3,
    errorMessage: "Фамилия должна быть больше 2 симвлов"
},
{
    rule: 'maxLength',
    value: 10,
    errorMessage: "Фамилия не может быть больше 11 сомволов"
},
{
    rule: 'customRegexp',
    value: /[а-яА-я]+$/gi,
    errorMessage: 'Фамилия должна состоять из букв русского алфавита'
},
]);


validate.addField('#Patronymic', [{
    rule: 'required',
    errorMessage: 'Поле отчество не должно быть пустым',
},
{
    rule: 'minLength',
    value: 3,
    errorMessage: "Отчество должно быть больше 2 симвлов"
},
{
    rule: 'maxLength',
    value: 10,
    errorMessage: "Отчество не может быть больше 11 сомволов"
},
{
    rule: 'customRegexp',
    value: /[а-яА-я]+$/gi,
    errorMessage: 'Отчество должно состоять из букв русского алфавита'
},
]);


validate.addField('#Description', [{
    rule: 'required',
    errorMessage: 'Поле описание не должно быть пустым',
},
{
    rule: 'minLength',
    value: 10,
    errorMessage: "Описание должно быть больше 10 симвлов"
},
{
    rule: 'maxLength',
    value: 300,
    errorMessage: "Описание не может быть больше 300 сомволов"
}
]);


validate.addField('#phone', [{
    rule: "function",
    validator: function (name, value) {
        const phone = selector.inputmask.unmaskedvalue();
        return phone.length === 10
    },
    errorMessage: 'Не достаточное количество символов в строке',
},
]);


validate.addField('#addres', [
    {
        rule: 'required',
        errorMessage: 'Поле адреса не должно быть пустым',
    },
    {
        rule: 'maxLength',
        value: 300,
        errorMessage: "Адрес не может быть больше 100 сомволов"
    },
    {
        rule: 'minLength',
        value: 10,
        errorMessage: "Адрес должен быть больше 10 симвлов"
    },
    {
        rule: 'customRegexp',
        value: /[а-яА-я0-9]+$/gi,
        errorMessage: 'Адресс должен состоять из букв русского алфавита и цифв'
    },
]);




validate.onSuccess((event) => {
    let id = document.querySelector('#id');
    let name = document.querySelector('#Name');
    let surname = document.querySelector('#Surname');
    let patronymic = document.querySelector('#Patronymic');
    let addres = document.querySelector('#addres');
    let description = document.querySelector('#Description');
    let phone = document.querySelector('#phone');
    let dataID = document.querySelector('#data-id');

    $.ajax({
        method: 'put',
        url: 'https://localhost:7248/Home/DataChangesView?ID=' + id.textContent
            + '&Name=' + name.value
            + '&Surname=' + surname.value
            + '&Patomic=' + patronymic.value 
            + '&ID=' +  dataID.textContent
            + '&ID_Person=' + id.textContent
            + '&PhoneNumber=' + phone.value
            + '&Address=' + addres.value
            + '&Description=' + description.value,


        success: function () {
            window.location.href = 'https://localhost:7248/Home/Info?id=' + id.textContent;
        },
    });
});








