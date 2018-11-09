$('body').on("click", 'button[data-id="editarCarro"]', function () {
    let id = $(this).data('codigo');

    $.ajax({
        type: "GET",
        url: `/Carro/ListarCarro?codigo=${id}`,
        success: function (data)
        {
            $("main").append(data);
            $("#modalEditar").modal('show');
            alert(data);
        },
        error: function (data) {
            alert("teste");
        }
    })
});