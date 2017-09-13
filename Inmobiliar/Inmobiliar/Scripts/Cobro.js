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
                            label: item.Nombre + ', ' + item.Apellido + ', ' + item.DU + ', ' + item.TelefonoLaboral + ', ' + item.Calle + ', ' + item.Numero + ', ' + item.Piso + ', ' + item.Departamento + ', ' + item.Barrio + ', ' + item.CP + ', ' + item.InquilinoId + ', ' + item.PropiedadId + ', ' + item.ContratoId,
                            object: item.PeriodosAdeudados,
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
            $("#idContrato").val(arr[12]);
            $("#PropiedadCalle").val(arr[4]);
            $("#PropiedadNumero").val(arr[5]);
            $("#PropiedadPiso").val(arr[6]);
            $("#PropiedadDto").val(arr[7]);
            $("#PropiedadBarrio").val(arr[8]);
            $("#PropiedadCP").val(arr[9]);
                                  
            var datos = ui.item.object;
            var sele = $(document.createElement('option'));
            sele.text('Periodo...');
            sele.val('-1');
            $("#Periodo").append(sele);

            $(datos).each(function () {
                var option = $(document.createElement('option'));
                option.text(this.Detalle);
                option.val(this.sMesAño);

                $("#Periodo").append(option);
            });
            

            //$('#Periodo option[value=' + ui.object + ']').attr('selected', true);
        },
        open: function() {
            $( this ).removeClass( "ui-corner-all" ).addClass( "ui-corner-top" );
        },
        close: function() {
            $( this ).removeClass( "ui-corner-top" ).addClass( "ui-corner-all" );
        }
    });
    debugger;

    $("#Periodo").change(function () {
        var str = "";
        $("select option:selected").each(function () {                        
            str += $(this).val() + " ";
        });

        debugger;
        if (str != "") {
            var indice = str.substr(4, 4) + str.substr(2, 2) + str.substr(0, 2);
            var idContrato = $("#idContrato").val();
            minLength: 1,
            $.ajax({
                url: '/CobroAlquiler/GetCobro/',
                data: "{ 'fecha': '" + indice + "', 'idContrato': '" + idContrato + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                },
                error: function (response) {
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                }
            });
        }
        //alert(new Date(str.substr(4,4), str.substr(2, 2) -1, str.substr(0,2)));
    }).change();

      


    //$("#Periodo").change({        
    //    source: function (request, response) {
    //        $("#prueba").val('TOPU')
    //        //source: function (request, response) {
    //        //$.ajax({
    //        //    url: '/CobroAlquiler/GetCobro/',
    //        //    data: "{ 'periodo': '" + request.term + "'}",
    //        //    dataType: "json",
    //        //    type: "POST",
    //        //    contentType: "application/json; charset=utf-8",
    //        //    success: function (data) {
    //        //        response($.map(data, function (item) {

    //        //            return {
                            
    //        //                label: item.Nombre + ', ' + item.Apellido + ', ' + item.DU + ', ' + item.TelefonoLaboral + ', ' + item.Calle + ', ' + item.Numero + ', ' + item.Piso + ', ' + item.Departamento + ', ' + item.Barrio + ', ' + item.CP + ', ' + item.PersonasId + ', ' + item.PropiedadId,
    //        //                object: item.PeriodosAdeudados,
    //        //                value: "Seleccione..."
    //        //            };
    //        //        }))
    //        //    },
    //        //    error: function (response) {
    //        //        alert(response.responseText);
    //        //    },
    //        //    failure: function (response) {
    //        //        alert(response.responseText);
    //        //    }
    //        //});
            
    //        //},      
    //    },
    //    minLength: 1,
        
    //});

});