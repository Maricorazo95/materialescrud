$(document).ready(function () {
    var serviceUrl = "http://localhost:50173/api/materiales"
    var id = 0;
    console.log("Leyendo");
    $('#gridMateriales').DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "GET",
            url: serviceUrl,
            contentType: "application/json; charset-utf-8",
            dataType: "json",
            data: function (d) {
                console.log(d);
                return JSON.stringify(d);
            },
            dataSrc: ""
        },
        columns: [
            { "data": "Nombre" },
            { "data": "Unidad.Descripcion" },
            { "data": "TipoMaterial.Descripcion" },
            { "data": "Familia.Descripcion" },
            {
                "data": "MaterialId",
                "render": function (data, type, full, meta) {
                    return "<button type='button' class='btn btn-info btn-md editor_edit' data-toggle='modal' data-id=" + data + " data-target='#winModal' onClick='edit(" + data + ")'> Edit </button> <button type='button' class='btn btn-info btn-md editor_edit' data-toggle='modal' data-id=" + data + " data-target='#winModal' onClick='deletes(" + data +")'> Delete </button>";
                }
            }
        ]
    });

});

$('#btnNuevoMaterial').click(function (eve) {
    $('#modal-content').load('/Home/Nuevo');
})

function edit(id) {
    
    $('#modal-content').load('/Home/Editar');
    $('#valorId').val(id)
}

function deletes(id) {
    $('#modal-content').load('/Home/Eliminar');
    $('#valorId').val(id)
}