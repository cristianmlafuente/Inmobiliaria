$(function () {    
    $("#datosPropiedad").autocomplete({ 
        
        source: function (request, response) {
            $.ajax({
                url: '/Contratos/GetPropiedad/',
                data: "{ 'prop': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data)
                {                    
                    response($.map(data, function (item)
                    {                                                                       
                        return {
                            label: item.Calle + ', ' + item.Numero + ', ' + item.Piso + ', ' + item.Dto + ', ' + item.Barrio + ', ' + item.CP + ', ' + item.Apellido + ', ' + item.Nombre + ', ' + item.Du + ', ' + item.TelLabo,
                            value: item.IdPropiedad + ', ' + item.PersonasId
                        };                        
                    }))
                },
                error: function (response) {
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                }
            });
        },
        minLength: 1, 
        select: function (event, ui)
        {
            debugger;
            var idName = $("#ownerinquilino").attr("#data-id");
            var arr = ui.item.label.split(',');
            var id = ui.item.value.split(',');
            $("#Calle").val(arr[0]);           
            $("#Numero").val(arr[1]);
            $("#Piso").val(arr[2]);
            $("#Dto").val(arr[3]);
            $("#Barrio").val(arr[4]);
            $("#CP").val(arr[5]);
            $("#datosPropiedad").val(ui.item.label);
            $("#datosPropiedad").addClass("data-idtarjeta=" + id[0]);
            if ($("#ownerinquilino").attr("#data-id") == idName)
            {
                $("#ownerInquilino").addClass("data-idtarjeta=" + id[1]);
            }            
            $("#divBuscarPropietario").hide();
            $("#PropietarioownerApellido").val(arr[6]);
            $("#PropietarioownerName").val(arr[7]);
            $("#PropietarioDU").val(arr[8]);
            $("#PropietarioTelefonoLaboral").val(arr[9]);                        
            
    },
    open: function() {
        $( this ).removeClass( "ui-corner-all" ).addClass( "ui-corner-top" );
    },
    close: function() {
        $( this ).removeClass( "ui-corner-top" ).addClass( "ui-corner-all" );
    }
    });

    $("#ownerinquilino").autocomplete({ 
        idName: $("#ownerinquilino").attr("#data-id"),
        source: function (request, response) {
            $.ajax({
                url: '/Owner/GetUser/',
                data: "{ 'nombre': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) 
                {                               
                    response($.map(data, function (item)
                    {                                                                       
                        return {
                            label: item.Nombre + ', ' + item.Apellido + ', ' + item.DU + ', ' + item.TelefonoLaboral,
                            value: item.PersonasId
                            };                        
                    }))
                },
                error: function (response) {
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                }
            });
        },
        minLength: 1, 
        select: function (event, ui)
        {
            var arr = ui.item.label.split(',');
            if ($("#ownerinquilino").attr("#data-id") == idName) {
                $("#ownerInquilino").addClass("data-idtarjeta=" + value);
            }
            $("#divBuscarPropietario" + idName).hide();
            $("#"+ idName + "PropietarioownerApellido").val(arr[1]);
            $("#" + idName + "ownerName").val(arr[0]);
            $("#" + idName + "DU").val(arr[8]);
            $("#" + idName + "TelefonoLaboral").val(arr[9]);


        },
        open: function() {
            $( this ).removeClass( "ui-corner-all" ).addClass( "ui-corner-top" );
        },
        close: function() {
            $( this ).removeClass( "ui-corner-top" ).addClass( "ui-corner-all" );
        }

    });

    $("#RegistrarContrato").click({
        
        if (validarContrato() == true)
        {
        source: function (request, response) {
    }
        }

    });

    var validarContrato = function ()
    {




        return true;
    }

});

