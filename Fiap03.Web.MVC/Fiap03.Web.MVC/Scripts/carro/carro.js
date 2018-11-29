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
            alert($('#Documento_Categoria').val());
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


    $('#Documento_DataFabricacao').datepicker();
    $('#Placa').inputmask('aaa-9999');
});