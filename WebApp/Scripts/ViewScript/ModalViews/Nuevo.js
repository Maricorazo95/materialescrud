$(document).ready(function () {
    $('.modal-title').text("Nuevo");
    $.ajax({
        type: "GET",
        url: "http://localhost:50173/api/Familias",
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
        type: "GET",
        url: "http://localhost:50173/api/Unidades",
        data: "{}",
        success: function (data) {
            data = JSON.parse(JSON.stringify(data));
            var s_ = '<option value="-1">Selecciona una Unidad</option>';
            for (var i = 0; i < data.length; i++) {
                s_ += '<option value="' + data[i].UnidadId + '">' + data[i].Descripcion + '</option>';
            }
            $("#almacenDropdown").html(s_);
            $("#compraDropdown").html(s_);
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

    $(document).on("click", '#btn-GuardarMaterial', onGuardarMaterial);
    function onGuardarMaterial() {

        $('#ddFamId').val($('#familiasDropdown option:selected').val());
        $('#ddAlmId').val($('#almacenDropdown option:selected').val());
        $('#ddComId').val($('#compraDropdown option:selected').val());

        if ($('#ddFamId').val() < 1) {
            alert("Departamento No valido!");
            return;
        }
        if ($('#ddAlmId').val() < 1) {
            alert("Departamento No valido!");
            return;
        }
        if ($('#ddComId').val() < 1) {
            alert("Departamento No valido!");
            return;
        }
        $.post("http://localhost:50173/api/Materiales/GuardarMaterial",
            $('#NuevoMaterialForm').serialize())
            .done(function () {
                location.reload();
            })
            .fail(function () {
                console.log("Fail");
            })
    }
})