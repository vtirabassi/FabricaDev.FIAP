$('body').on("click", 'button[data-id="editarCarro"]', function () {
    let id = $(this).data('codigo');

    $.ajax({
        type: "GET",
        url: `/Carro/ListarCarro?codigo=${id}`,
        success: function (data)
        {
            $("#modalEditarCarro").remove();
            $("body").append(data);
            $("#modalEditarCarro").modal('show');
        },
        error: function (data) {
            alert("Erro ao editar");
        }
    })
});