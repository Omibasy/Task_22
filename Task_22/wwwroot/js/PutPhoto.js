const fileInfo = document.querySelector('.input-file-text');
const validate = new JustValidate('#SubmittingAForm');



validate.addField('#file', [
    {
        rule: 'minFilesCount',
        value: 1,
        errorMessage: 'Файл не вывбран'
    },
    {
        rule: 'maxFilesCount',
        value: 1,
    },
    {
        rule: 'files',
        value: {
            files: {
                extensions: ['jpg'],
            },
        },
        errorMessage: 'Неверный формат файла'
    },
]);

validate.onSuccess((event) => {
    document.getElementById("SubmittingAForm").submit();
});


function myFunc(input) {


    let [file] = input.files
    let blah = document.querySelector('#blah');

    if (file) {
        blah.src = URL.createObjectURL(file)
    }

    if (input.files[0] != null) {
        fileInfo.style.color = 'aliceblue';
        fileInfo.innerHTML = input.files[0].name;
    }
    else {
        fileInfo.style.color = '#757570';
        fileInfo.innerHTML = "Файл формата jpg 350x310";
    }

}