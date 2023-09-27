let allSelect = true;

let checkbox = document.querySelectorAll(".checkbox-cell");

const row = document.querySelectorAll(".row-target");

  function setUnchecked(){


    if(allSelect)
    {
        checkbox.forEach(element => {
            element.checked = true;
        });
        allSelect = false;
    }
    else
    {
        checkbox.forEach(element => {
            element.checked = false;
        });
        allSelect = true;
    }


};

function onDelete() {

    let str = "names=y";

    row.forEach(el => {

        if (el.querySelector(".checkbox-cell").checked) {
            str +=  "&names=" + el.querySelector(".cell-name").innerText;
        }

    });


    $.ajax({
        method: 'delete',
        url: 'https://localhost:7147/Admin/DeleteUser?' + str,

        success: function () {
            window.location.href = 'https://localhost:7147/Admin/ViewUsers';
        },
    });

}
  