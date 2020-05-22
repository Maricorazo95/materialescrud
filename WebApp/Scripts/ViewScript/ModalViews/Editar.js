$(document).ready(function () {
    var id = $("#valorId").val();
    $('.modal-title').text("Editar");
    var serviceUrl = "http://localhost:50173/api/familias";
    $.ajax({
        async: false,
        type: "GET",
        url: serviceUrl,
        data: "{}",
        success: function (data) {
            data = JSON.parse(JSON.stringify(data));
            var s = '<option value="-1">Selecciona una familia</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].TipoMaterialId + '">' + data[i].Descripcion + '</option>';
            }
            $("#familiasDropdown").html(s);
        }
    });
    $("#familiasDropdown").change(function () {
        var end = this.value;
        var firstDropVal = $('#pick').val();
        console.log(firstDropVal);
        console.log(end);
    });

    $.ajax({
        aync: false,
        type: "GET",
        url: "http://localhost:50173/api/Unidades",
        data: "{}",
        success: function (data) {
            data = JSON.parse(JSON.stringify(data));
            var s = '<option value="-1">Selecciona una Unidad</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].UnidadId + '">' + data[i].Descripcion + '</option>';
            }
            $("#almacenDropdown").html(s);
            $("#compraDropdown").html(s);
        }
    });
    $("#almacenDropdown").change(function () {
        var end = this.value;
        var firstDropVal = $('#pick').val();
        console.log(firstDropVal);
        console.log(end);
    });
    $("#compraDropdown").change(function () {
        var end = this.value;
        var firstDropVal = $('#pick').val();
        console.log(firstDropVal);
        console.log(end);
    });
    $.ajax({
        async: false,
        type: "GET",
        url: "http://localhost:50173/api/materiales/obtenermaterial/" + id,
        data: "{}",
        success: function (data) {
            data = JSON.parse(JSON.stringify(data));

            Familia = data.FamiliaId
            $('#Nombre').val(data.Nombre);
            $('#familiasDropdown').val(Familia);
            console.log($('#familiasDropdown').val())
            $('#almacenDropdown').val(data.UnidadAlmacenId);
            console.log($('#almacenDropdown').val())
            $('#compraDropdown').val(data.UnidadCompraId);
            console.log($('#compraDropdown').val())
            $('#PiezasUnidad').val(data.PiezasUnidad);
            $('#Costo').val(data.Costo);
            $('#TipoMaterialId').val(data.TipoMaterialId);
            $('#EstatusId').val(data.EstatusId);
        }
    });

    $(document).on("click", '#btn-GuardarMaterial', onEditarMaterial);
    function onEditarMaterial() {

        $('#ddFamId').val($('#familiasDropdown option:selected').val());
        $('#ddAlmId').val($('#almacenDropdown option:selected').val());
        $('#ddComId').val($('#compraDropdown option:selected').val());
        $('#MatId').val(id);

        if ($('#ddFamId').val() < 1) {
            alert("!Familia no Válida!");
            return;
        }
        if ($('#ddAlmId').val() < 1) {
            alert("¡Unidad no Válida!");
            return;
        }
        if ($('#ddComId').val() < 1) {
            alert("¡Unidad no Válida!");
            return;
        }
        $.ajax({
            url: 'http://localhost:50173/api/Materiales/ActualizarMaterial',
            method: 'PUT', data: $('#ActualizarMaterialForm').serialize()
        }).then(function () {
            location.reload();
        })
        .catch(function (err) {
            err
        });
    }
})