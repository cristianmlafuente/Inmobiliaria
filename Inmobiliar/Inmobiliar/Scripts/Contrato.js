$(function () {
    var list = [];
    $("#AltaContrato").val({
        debugger: true,
        rules: {
            datosPropiedad: {
                required: true,
            minLength:2}
        }
    });

    $('#btnAddImp').click( function () {

        $("select option:selected").each(function () {
            debugger;
            str = $(this).val() + "";
            sel = $(this).text();                   
            var object = { "idImpuesto": $(this).val(), "descripcionImp": $(this).text() }
            list.push(object);
            $('#listImpuestos').val(JSON.parse(list));
            $('#impuestoList').val(JSON.parse(list));
            
            debugger;
        });
       
    });
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
                            label: item.Calle + ', ' + item.Numero + ', ' + item.Piso + ', ' + item.Dto + ', ' + item.Barrio + ', ' + item.CP + ', ' + item.Apellido + ', ' + item.Nombre + ', ' + item.Du + ', ' + item.TelLabo + ', ' + item.IdPropiedad + ', ' + item.IdPropietario,
                            impuesto: item.Impuesto,
                            ciudad: item.Ciudad,
                            nrocontratoepec: item.NroContratoEpec,
                            nomcatrastal: item.NomCatrastal,
                            numeroctarenta: item.NumeroCtaRenta,
                            unidadcacturacion: item.UnidadFacturacion,
                            value: item.Calle + ', ' + item.Numero
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
            var idName = $("#owner").attr("data-detalle");
            var arr = ui.item.label.split(',');            
            $("#Calle").val(arr[0]);           
            $("#Numero").val(arr[1]);
            $("#Piso").val(arr[2]);
            $("#Dto").val(arr[3]);
            $("#Barrio").val(arr[4]);
            $("#CP").val(arr[5]);
            $("#Ciudad").val(ui.item.ciudad);
            $("#datosPropiedad").addClass("data-idtarjeta=" + arr[10]);
            $("#idPropiedad").val($.trim(arr[10]));
            $("#datosPropiedad").attr("placeholder", "Seleccione...");
            $("#datosPropiedad").val('');
            $("#NroContratoEpec").val(ui.item.nrocontratoepec);
            $("#NomenclaturaCatastral").val(ui.item.nomcatrastal);
            $("#NumeroCtaRenta").val(ui.item.numeroctarenta);
            $("#UnidadFacturacion").val(ui.item.unidadcacturacion);
            $("#idPersona").val($.trim(arr[11]));
            if ("Propietario" == idName)
            {
                $("#idPropietario").val($.trim(arr[11]));
                $("#divBuscarPropietario").hide();
                $("#ownerApellidoPropietario").val(arr[6]);
                $("#ownerNamePropietario").val(arr[7]);
                $("#DUPropietario").val(arr[8]);
                $("#TelLaboralPropietario").val(arr[9]);
            }            
            if ("edit" == idName)
            {
                $("#idPersona").val($.trim(arr[11]));
                $("#ownerName").val(arr[6] + ',' + arr[7]);
            }
            var datos = ui.item.impuesto;
            var sele = $(document.createElement('option'));
            sele.text('Seleccione...');
            sele.val('-1');
            $("#Impuestos").append(sele);

            $(datos).each(function () {
                var option = $(document.createElement('option'));
                option.text(this.Descripcion);
                option.val(this.Codigo);

                $("#Impuestos").append(option);
            });


            
    },
    open: function() {
        $( this ).removeClass( "ui-corner-all" ).addClass( "ui-corner-top" );
    },
    close: function() {
        $( this ).removeClass( "ui-corner-top" ).addClass( "ui-corner-all" );
    }
    });

    $('input[data-detalle=Inquilino]').autocomplete({ 
        idName: $("#owner").attr("#data-id"),
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
                            label: item.Nombre + ', ' + item.Apellido + ', ' + item.DU + ', ' + item.TelefonoLaboral + ', ' + item.PersonasId,
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
            $('#idInquilino').val($.trim(arr[4]));
            $("#ownerApellidoInquilino").val(arr[1]);
            $("#ownerNameInquilino").val(arr[0]);
            $("#DUInquilino").val(arr[2]);
            $("#TelLaboralInquilino").val(arr[3]);


        },
        open: function() {
            $( this ).removeClass( "ui-corner-all" ).addClass( "ui-corner-top" );
        },
        close: function() {
            $( this ).removeClass( "ui-corner-top" ).addClass( "ui-corner-all" );
        }

    });

    $('input[data-detalle=Garante_Propietario]').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Owner/GetUser/',
                data: "{ 'nombre': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.Nombre + ', ' + item.Apellido + ', ' + item.DU + ', ' + item.TelefonoLaboral + ', ' + item.PersonasId,
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
        select: function (event, ui) {
            debugger;
            var arr = ui.item.label.split(',');
            $('#idGarantePropietario').val($.trim(arr[4]));
            $("#garanteApellido").val(arr[1]);
            $("#garanteName").val(arr[0]);
            $("#garanteDU").val(arr[2]);
            $("#garanteTelefonoLaboral").val(arr[3]);
        },
        open: function () {
            $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
        },
        close: function () {
            $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
        }

    });

    $('input[data-detalle=1er_Garante]').autocomplete({        
        source: function (request, response) {
            $.ajax({
                url: '/Owner/GetUser/',
                data: "{ 'nombre': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.Nombre + ', ' + item.Apellido + ', ' + item.DU + ', ' + item.TelefonoLaboral + ', ' + item.PersonasId,
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
        select: function (event, ui) {
            debugger;
            var arr = ui.item.label.split(',');            
            $('#idGaranteLaboral1').val($.trim(arr[4]));
            $("#ownerApellido1er_Garante").val(arr[1]);
            $("#ownerName1er_Garante").val(arr[0]);
            $("#DU1er_Garante").val(arr[2]);
            $("#TelLaboral1er_Garante").val(arr[3]);
        },
        open: function () {
            $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
        },
        close: function () {
            $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
        }

    });

    $('input[data-detalle=2do_Garante]').autocomplete({        
        source: function (request, response) {
            $.ajax({
                url: '/Owner/GetUser/',
                data: "{ 'nombre': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.Nombre + ', ' + item.Apellido + ', ' + item.DU + ', ' + item.TelefonoLaboral + ', ' + item.PersonasId,
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
        select: function (event, ui) {
            debugger;
            var arr = ui.item.label.split(',');
            $('#idGaranteLaboral2').val($.trim(arr[4]));
            $("#ownerApellido2do_Garante").val(arr[1]);
            $("#ownerName2do_Garante").val(arr[0]);
            $("#DU2do_Garante").val(arr[2]);
            $("#TelLaboral2do_Garante").val(arr[3]);


        },
        open: function () {
            $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
        },
        close: function () {
            $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
        }

    });

    $('input[data-detalle=3er_Garante]').autocomplete({        
        source: function (request, response) {
            $.ajax({
                url: '/Owner/GetUser/',
                data: "{ 'nombre': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.Nombre + ', ' + item.Apellido + ', ' + item.DU + ', ' + item.TelefonoLaboral + ', ' + item.PersonasId,
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
        select: function (event, ui) {
            debugger;
            var arr = ui.item.label.split(',');            
            $('#idGaranteLaboral3').val($.trim(arr[4]));
            $("#ownerApellido3er_Garante").val(arr[1]);
            $("#ownerName3er_Garante").val(arr[0]);
            $("#DU3er_Garante").val(arr[2]);
            $("#TelLaboral3er_Garante").val(arr[3]);


        },
        open: function () {
            $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
        },
        close: function () {
            $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
        }

    });

    $("#owner").autocomplete({ 
        idName: $("#owner").attr("#data-id"),
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
                            label: item.Nombre + ', ' + item.Apellido + ', ' + item.DU + ', ' + item.TelefonoLaboral + ', ' + item.Email + ', ' + item.Telefono + ', ' + item.Celular,
                            value: "Seleccionar...",
                            id: item.PersonasId
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
            debugger;
            if ($('form[id="frmEditOwner"]').length > 0)
            {
                $("#idInquilino").val(ui.item.id);
                $("#NombreEdit").val(arr[0]);
                $("#ApellidoEdit").val(arr[1]);
                $("#DUEdit").val(arr[2]);
                $("#TelefonoLaboralEdit").val(arr[3]);
                $("#EmailEdit").val(arr[4]);
                $("#TelefonoEdit").val(arr[5]);
                $("#CelularEdit").val(arr[6]);
            }
            else
            {                                
                if ($("#ownerinquilino").attr("#data-id") == idName) {
                    $("#ownerInquilino").addClass("data-idtarjeta=" + ui.item.id);
                }
                $("#divBuscarPropietario" + idName).hide();
                $("#"+ idName + "PropietarioownerApellido").val(arr[1]);
                $("#" + idName + "ownerName").val(arr[0]);
                $("#" + idName + "DU").val(arr[8]);
                $("#" + idName + "TelefonoLaboral").val(arr[9]);
                
            }

        },
        open: function() {
            $( this ).removeClass( "ui-corner-all" ).addClass( "ui-corner-top" );
        },
        close: function() {
            $( this ).removeClass( "ui-corner-top" ).addClass( "ui-corner-all" );
        }

    });

    //$(".btn-add").click(function (event)
    //    {
    //        event.preventDefault();
            
    //        var control = $('.controls'),
    //            currentEntry = $(this).parents('.entry:first'),
    //            newEntry = $(currentEntry.clone()).appendTo(control);

    //        controlForm.find('.entry:not(:last) .btn-add')
    //        .removeClass('btn-add').addClass('btn-remove')
    //        .removeClass('btn-success').addClass('btn-danger')
    //        .html('<span class="glyphicon glyphicon-minus"></span>');
    //    }
    //).click();


    $(function () {
        $(document).on('click', '.btn-add', function (e) {
            e.preventDefault();
            debugger;
            var sel = "";
            var str = "";
            
            $("select option:selected").each(function () {
                debugger;
                str = $(this).val() + "";
                sel = $(this).text();
                $(this).parent('.select').attr('id', 'Impuestos' + str);
                debugger;
            });
                       
            //var control = $('.controls');
            //var sele = control.find('.entry .form-control');

            //control.currentEntry = $(this).parents('.entry:first'),
            //    newEntry = $(control.clone()).appendTo(control);
            var cbo = $("#Impuestos");
            cbo.before('<div id="in' + str + '" ><input type="text" class="form-control" name="inImpuesto" value="' + sel + '" disabled=""><button id="' + str + '" class="btn btn-danger btn-remove" type="button"><span class="glyphicon glyphicon-minus"></span></button></div>');
            var TipoImpuestosServicios = new Object();
            TipoImpuestosServicios['Codigo'] = str;
            TipoImpuestosServicios['Descripcion'] = sel;
            if ($("#hImpuestos").val() != '')
                $("#hImpuestos").val($("#hImpuestos").val() + ',' + str);
            else
                $("#hImpuestos").val(str);
            //control.find('.entry:not(:last) .btn-add')
            //    .removeClass('btn-add').addClass('btn-remove')
            //    .removeClass('btn-success').addClass('btn-danger')
            //    .html('<span class="glyphicon glyphicon-minus"></span>');
            
            //sele.attr("id", "Impuestos" + str).before('<input type="text" class="form-control" id="inImpuesto" name="inImpuesto" value="' + sel + '" disabled="">');
            //sele.remove();
           
        }).on('click', '.btn-remove', function (e) {
            debugger;
            //$(this).parents('.entry:first').remove();
            var cant = $("#hImpuestos").val().split(',');

            var id = $(this).attr("id");

            cant = jQuery.grep(cant, function (value) {
                return value != id;
            });

            debugger;
            $("#hImpuestos").val(cant.toString());
            $("#in" + id).remove();
            //$(this).remove();
            e.preventDefault();
            return false;
        });
    });

    $("#contratoInquilino").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Contratos/GetInquilino/',
                data: "{ 'nombre': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    response($.map(data, function (item) {                        
                        return {
                            label: item.Nombre + ', ' + item.Apellido + ', ' + item.DU + ', ' + item.TelefonoLaboral + ', ' + item.Calle + ', ' + item.Numero + ', ' + item.Piso + ', ' + item.Departamento + ', ' + item.Barrio + ', ' + item.CP + ', ' + item.InquilinoId + ', ' + item.PropiedadId + ', ' + item.ContratoId,
                            periodos: item.PeriodosAdeudados,
                            pagos: item.PeriodosPagados,
                            observaciones: item.Observaciones,
                            propietario: item.Propietario,
                            garante1: item.Garante1,
                            garante2: item.Garante2,
                            garante3: item.Garante3,
                            garantePropie: item.GarantePropie,
                            nroContrato: item.NroContrato,
                            fechaInicio: item.FechaInicio,
                            duracion: item.Duracion,
                            cantidadIncrementos: item.CantidadIncrementos,
                            porcentajeIncremento: item.PorcentajeIncremento,
                            montoIncial: item.MontoIncial,
                            porcentajeInmo: item.PorcentajeInmo,
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
            $('#idContrato').val($.trim(arr[12]));
            $("#contratoApellidoInquilino").val(arr[1]);
            $("#contratoInquilinoName").val(arr[0]);            
            $("#contratoInquilinoDU").val(arr[2]);
            $("#contratoInquilinoTelefonoLaboral").val(arr[3]);


            $("#contratoCalle").val(arr[4]);
            $("#contratoNumero").val(arr[5]);
            $("#contratoPiso").val(arr[6]);
            $("#contratoDto").val(arr[7]);
            $("#contratoBarrio").val(arr[8]);
            $("#contratoCP").val(arr[9]);

            if (ui.item.propietario != null && ui.item.propietario.PersonasId != null) {
                $("#ownerPropietario").val(ui.item.propietario.Apellido + ', ' + ui.item.propietario.Nombre);
            }
            if (ui.item.garante1 != null && ui.item.garante1.PersonasId != null) {
                $("#ownerGarante1").val(ui.item.garante1.Apellido + ', ' + ui.item.garante1.Nombre);
            }
            if (ui.item.garante2 != null && ui.item.garante2.PersonasId != null) {
                $("#ownerGarante2").val(ui.item.garante2.Apellido + ', ' + ui.item.garante2.Nombre);
            }
            if (ui.item.garante3 != null && ui.item.garante3.PersonasId != null) {
                $("#ownerGarante3").val(ui.item.garante3.Apellido + ', ' + ui.item.garante3.Nombre);
            }
            if (ui.item.garantePropie != null && ui.item.garantePropie.PersonasId != null) {
                $("#ownerGarantePropietario").val(ui.item.garantePropie.Apellido + ', ' + ui.item.garantePropie.Nombre);
            }
            $("#idNroContrato").val(ui.item.nroContrato);
            $("#idFechaContrato").val(ui.item.fechaInicio);
            $("#idPeriodoMeses").val(ui.item.duracion);
            $("#idIncrementos").val(ui.item.cantidadIncrementos);
            $("#idPorcentajeIncremento").val(ui.item.porcentajeIncremento);
            $("#idMontoInicialAlquiler").val(ui.item.montoIncial);
            $("#idPorcentajeInmobiliaria").val(ui.item.porcentajeInmo);

        },

    });

    var validarContrato = function ()
    {




        return true;
    }

});

