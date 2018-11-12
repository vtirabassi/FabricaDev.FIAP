$('body').on("click", 'button[data-id="editarMarca"]', function () {
    let id = $(this).data('codigo');

    $.ajax({
        type: "GET",
        url: `/Marca/ListarMarca?codigo=${id}`,
        success: function (data)
        {
            $("body").append(data);
            $("#modalEditarMarca").modal('show');
        },
        error: function (data) {
            alert("Erro ao editar");
        }
    })
});