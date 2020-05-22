$(document).ready(function () {
    var id = $("#valorId").val();
    $('.modal-title').text("Eliminar");
    $('#btn-GuardarMaterial').text("Eliminar");
    console.log(id)
    $.ajax({
        type: "GET",
        url: "http://localhost:50173/api/materiales/obtenermaterial/" + id,
        data: "{}",
        success: function (data) {
            data = JSON.parse(JSON.stringify(data));
            console.log(data);

            $('#Nombre').text(data.Nombre);
        }
    });

    $(document).on("click", '#btn-GuardarMaterial', onEliminarMaterial);
    function onEliminarMaterial() {
        uri = "http://localhost:50173/api/Materiales/EliminarMaterial/" + id;
        $.ajax({ url: uri, method: "DELETE" })
            .then(function (data) {
                location.reload();
            })
            .catch(function (err) {
                err
            });
    }
})