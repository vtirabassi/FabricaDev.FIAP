$('body').on("click", 'button[data-id="editarMarca"]', function () {
    let id = $(this).data('codigo');

    $.ajax({
        type: "GET",
        url: `/Marca/ListarMarca?codigo=${id}`,
        success: function (data)
        {
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