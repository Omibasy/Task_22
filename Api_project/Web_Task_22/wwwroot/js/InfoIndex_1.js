const id = document.querySelector('#recordID');

$(".button-delete").on("click", function (e) {
    deleteUser(id.textContent);
});


const deleteUser = function (userId) {
    $.ajax({
        method: 'delete',
        url: 'https://localhost:7147/Admin/DeleteRecord?id=' + userId,

        success: function () {
            window.location.href = 'https://localhost:7147/Admin/DeleteView';
        },
    });
};

