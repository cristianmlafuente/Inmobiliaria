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
                        
                        //return
                        //{
                        //    $("#domicilio.Calle").val(item.Calle);

                        //}

                        return {
                            label: item.Calle + ', ' + item.Numero + ', ' + item.Piso + ', ' + item.Dto + ', ' + item.Barrio + ', ' + item.CP,
                            value: item.Id 
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
            $("#Calle").val(arr[0]);           
            $("#Numero").val(arr[1]);
            $("#Piso").val(arr[2]);
            $("#Dto").val(arr[3]);
            $("#Barrio").val(arr[4]);
            $("#CP").val(arr[5]);
            $("#datosPropiedad").val(ui.item.value);
    },
    open: function() {
        $( this ).removeClass( "ui-corner-all" ).addClass( "ui-corner-top" );
    },
    close: function() {
        $( this ).removeClass( "ui-corner-top" ).addClass( "ui-corner-all" );
    }
    });
});