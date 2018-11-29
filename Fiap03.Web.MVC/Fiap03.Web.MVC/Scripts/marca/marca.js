//$().ready(function () {
//    $('#Nome').blur(function () {
//        alert($('#Nome').val());
//    });
//});

$().ready(function () {

    $('body').on("click", 'button[data-id="editarMarca"]', function () {
        let id = $(this).data('codigo');

        $.ajax({
            type: "GET",
            url: `/Marca/ListarMarca?codigo=${id}`,
            success: function (data) {
                $("#modalEditarMarca").remove();
                $("body").append(data);
                $("#modalEditarMarca").modal('show');
            },
            error: function (data) {
                alert("Erro ao editar");
            }
        })
    });

    $('body').on("click", 'button[data-id="listarCarros"]', function () {
        let id = $(this).data('codigo');

        $.ajax({
            type: "GET",
            url: `/Marca/ListarCarrosAtrelados?id=${id}`,
            success: function (data) {

                $("#modalListarCarrosAtrelados").remove();
                $("body").append(data);
                $("#modalListarCarrosAtrelados").modal('show');
            },
            error: function (data) {
                alert("Erro ao listar");
            }
        })
    });

    $('body').on("click", 'button[data-id="listarModelos"]', function () {
        let id = $(this).data('codigo');

        $.ajax({
            type: "GET",
            url: `/Modelo/Listar?marcaId=${id}`,
            success: function (data) {

                $("#modalListarModelos").remove();
                $("body").append(data);
                $("#modalListarModelos").modal('show');
            },
            error: function (data) {
                alert("Erro ao listar");
            }
        })
    });


    //$('.btn').css('visibility', 'hidden');
    //$('tr').hover(
    //    function () {
    //        $(this).find('.btn').css('visibility', 'visible');
    //    },
    //    function () {
    //        $(this).find('.btn').css('visibility', 'hidden');
    //    }
    //);

    $('#DataCriacao').datepicker();
    $('#Cnpj').inputmask('99.999.999/9999-99');
});



