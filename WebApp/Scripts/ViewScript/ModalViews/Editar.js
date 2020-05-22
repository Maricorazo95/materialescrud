$(document).ready(function () {
    var id = $("#valorId").val();
    $("#PiezasUnidad").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });
    $("#Costo").keydown(function (evt) {
        var theNum = $("#Costo").val();
        var formatLine = theNum.match(/^\d+(\.\d{1,2})?$/);;
        console.log(formatLine);
        if (!formatLine)
            alert("Ingrese un Número valido");
    });
    //$('#Costo').keyup(function () {
    //    if ($(this).val().indexOf('.') != -1) {
    //        if ($(this).val().split(".")[1].length > 2) {
    //            if (isNaN(parseFloat(this.value))) return;
    //            this.value = parseFloat(this.value).toFixed(2);
    //        }
    //    }
    //    return this;
    //});
    $('.modal-title').text("Editar");
    var serviceUrl = "http://localhost:50173/api/familias";

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
        type: "GET",
        url: "http://localhost:50173/api/materiales/obtenermaterial/" + id,
        data: "{}",
        success: function (data) {
            data = JSON.parse(JSON.stringify(data));
            Familia = data.FamiliaId;
            Almacen = data.UnidadAlmacenId;
            Compra = data.UnidadCompraId;

            console.log(data)
            $('#Nombre').val(data.Nombre);
            $('#familiasDropdown').val(Familia);
            console.log($('#familiasDropdown').val())
            $('#almacenDropdown').val(Almacen);
            console.log($('#almacenDropdown').val())
            $('#compraDropdown').val(Compra);
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

        var campo_nombre = $("#Nombre").val().trim();
        var campo_punidad = $("#PiezasUnidad").val().trim();
        var campo_costo = $("#Costo").val().trim();

        //si esta vacio lanza error
        if (campo_nombre.length == 0 ||
            campo_costo.length == 0 ||
            campo_punidad.length == 0) {
            alert("No puede haber campos vacios");
            return;
        }

        console.log($('#EstatusId').val())

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
        if ($('#EstatusId').val() < 1) {
            alert("¡Seleccione un Estatus!");
            return;
        }
        if ($('#TipoMaterialId').val() < 1) {
            alert("¡Seleccione un Tipo!");
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