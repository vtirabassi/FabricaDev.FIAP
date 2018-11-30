$().ready(function () {



    $('body').on("click", 'button[data-id="editarCarro"]', function () {
        let id = $(this).data('codigo');

        $.ajax({
            type: "GET",
            url: `/Carro/ListarCarro?codigo=${id}`,
            success: function (data) {
                $("#modalEditarCarro").remove();
                $("body").append(data);
                $("#modalEditarCarro").modal('show');
            },
            error: function (data) {
                alert("Erro ao editar");
            }
        })
    });

    $().ready(function () {
        $('#Documento_Categoria').change(function () {
            if ($(this).val() == "") {
                $('#botoes').css('display', 'none');
            }
            else {
                $('#botoes').css('display', '');
            }
        });
    });

    $().ready(function () {
        $('tr').hover(function () {
            $(this).find('td').css('background-color', '#15141421');
        }, function () {
            $(this).find('td').css('background-color', 'white');
        });
    });

    $().ready(function () {
        $('div[name=botoesMarca]').hover(function () {
            $(this).css('display', '');
        });
    });

    $('#Placa').blur(function () {
        var placa = $('#Placa').val();
        $.ajax({
            type: "GET",
            url: `/Carro/ValidarPlaca?placa=${placa}`,
            success: function (data) {
                if (data.valido != true) {
                    $('[data-valmsg-for=Placa]').text("Placa Valida!").css('color', 'red');
                } else {
                    $('[data-valmsg-for=Placa]').text("Placa já utilizada!").css('color', 'red');
                }
            },
            error: function () {
                alert("Erro ao requisitar o servidor");
            }
        })
    });

    $('#MarcaId').change(function () {
        var marcaId = $('#MarcaId').val();
        if (marcaId == "") {
            $("#modelos").empty();
            $("#modelos").append(linha);
        }
        else {
            $.ajax({
                url: `/Carro/BuscarModelos?marcaId=${marcaId}`,
                type: "GET", success: function (data) {
                    $("#modelos").empty();
                    $.each(data, function (index, modelo) {
                        var linha = $("<option>").text(modelo.Nome).val(modelo.id);
                        $("#modelos").append(linha);
                    });
                }
            });
        }
    });


    //arrumar isso aqui
    $('#Documento_DataFabricacao').datepicker({
        dateFormat: 'dd/mm/yy',
        dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
        dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
        dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
        monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
        nextText: 'Próximo',
        prevText: 'Anterior'
    });

    $('#Placa').inputmask('aaa-9999');
});