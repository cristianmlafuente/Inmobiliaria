$(function () {
    debugger;
    $("#datosPropiedad").autocomplete({ 
        
        source: function (request, response) {
            $.ajax({
                url: '/Contratos/GetPropiedad/',
                data: "{ 'prop': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    debugger;
                    response($.map(data, function (item) {
                        return item.Calle + ' ' + item.Numero + ' ' + item.Piso + '-' + item.Dto + ' ' + item.Barrio;
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

    });
});