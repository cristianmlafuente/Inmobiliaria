$(function () {
    $("#ownerInquilino").autocomplete({     
        source: function (request, response) {
            $.ajax({
                url: '/Contratos/GetInquilino/',
                data: "{ 'nombre': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) 
                {                               
                    response($.map(data, function (item)
                    {                                                                       
                        return {
                            label: item.Nombre + ', ' + item.Apellido + ', ' + item.DU + ', ' + item.TelefonoLaboral + ', ' + item.Calle + ', ' + item.Numero + ', ' + item.Piso + ', ' + item.Departamento + ', ' + item.Barrio + ', ' + item.CP + ', ' + item.PersonasId + ', ' + item.PropiedadId,
                            value: "Seleccione..."
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
            var arr = ui.item.label.split(',');                        
            $('#idInquilino').val($.trim(arr[10]));
            $("#InquilinoName").val(arr[0]);
            $("#InquilinoApellido").val(arr[1]);            
            $("#InquilinoDU").val(arr[2]);
            $("#InquilinoTelefonoLaboral").val(arr[3]);

            $("#idPropiedad").val(arr[11]);
            $("#PropiedadCalle").val(arr[4]);
            $("#PropiedadNumero").val(arr[5]);
            $("#PropiedadPiso").val(arr[6]);
            $("#PropiedadDto").val(arr[7]);
            $("#PropiedadBarrio").val(arr[8]);
            $("#PropiedadCP").val(arr[9]);

            $('#coloniasSel option[value=' + datos.localidad + ']').attr('selected', true);
        },
        open: function() {
            $( this ).removeClass( "ui-corner-all" ).addClass( "ui-corner-top" );
        },
        close: function() {
            $( this ).removeClass( "ui-corner-top" ).addClass( "ui-corner-all" );
        }
    });
});