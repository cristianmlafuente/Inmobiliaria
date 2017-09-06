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
});