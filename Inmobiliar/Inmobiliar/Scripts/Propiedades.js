$(function () {    
    $("#ownerName").autocomplete({        

        source: function (request, response) {
            $.ajax({
                url: '/Owner/GetUser/',
                data: "{ 'nombre': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    debugger;
                    response($.map(data, function (item) {
                        $('#idPersona').val(item.PersonasId);
                        return { label: item.Nombre + item.Apellido, value: item.Nombre };
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
        minLength: 1
    });

    $("#ownerNameEdit").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Owner/GetUser/',
                data: "{ 'nombre': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    debugger;
                    response($.map(data, function (item) {
                        return {
                            label: item.Nombre + ', ' + item.Apellido,
                            id: item.PersonasId,
                            value: item.Nombre + ', ' + item.Apellido
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
        select: function (event, ui) {                        
            $('#ownerNameEdit').val(ui.item.label);
            $("#idPersona").val(ui.item.id);
        }
    });

    $("#Tipo").change(function () 
    {
        debugger;
        var str = "";
        $("select option:selected").each(function () 
        {
            str = $(this).val();
            switch(str)
            {
                case "1":
                    $("#DetalleVenta").hide();
                    $("#DetalleAlquiler").show();
                    break;
                case "2":
                    $("#DetalleVenta").show();
                    $("#DetalleAlquiler").hide();
                    break;
                default: 
                    $("#DetalleVenta").hide();
                    $("#DetalleAlquiler").hide();
            }            
        });
    }).change();
});