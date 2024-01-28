﻿var dataTable;
$(document).ready(function () {
    loadDataTable();
})
function loadDataTable() {
    dataTable = $('#tdData').DataTable({
        "ajax": {
            "url": "Trail/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "nationalPark.name", "width": "20%" },
            { "data": "name", "width": "20%" },
            { "data": "distance", "width": "20%" },
            { "data": "elevation", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <div class="text-center">
                    <a href="Trail/Upsert/${data}" class="btn btn-info" style="background-color:aliceblue ">
                    <i class="fas fa-edit"></i>
                    </a>
                    <a class="btn btn-danger" onclick=Delete("Trail/Delete/${data}")>
                    <i class="fas fa-trash-alt"></i>
                    </a>
                    </div>
                    `;
                }
            }
        ]
    })
}
function Delete(url) {
    // alert(url)
    swal({
        title: "Want to delete data ?",
        text: "Delete Information",
        buttons: true,
        icon: "warning",
        dangerMode: true

    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: url,
                type: "Delete",
                success: function (data) {
                    if (data.success) {

                        toastr.success(data.message);
                        dataTable.ajax.reload()
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}



