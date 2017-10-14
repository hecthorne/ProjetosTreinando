(function () {

    var _id = '';
    var _nome = '';

    $(document).ready(function () {

        carregarTabelaCliente();

        $("#AbrirModalCliente").click(function () {
            $("#ClienteModal").modal();
            $("#SalvarCliente").show();
            $("#AtualizarCliente").hide();

            limparCampos();
        });

        $("#SalvarCliente").click(function () {

            var _nome = $('#NomeCliente').val();

            var _cliente = {
                Nome: _nome
            };

            clienteController.salvarCliente({
                postdata: { cliente: JSON.stringify(_cliente) },
                success: function (response, textStatus, jqXHR) {
                    location.reload();
                }
            });

        });

        $('#AtualizarCliente').click(function () {
            SalvarAtualizar();
        })

    });

    function limparCampos() {
        $('#NomeCliente').val('');
    }

    function SalvarAtualizar() {

        var _nome = $('#NomeCliente').val();

        var _cliente = {
            ClienteId: _id,
            Nome: _nome
        };

        clienteController.atualizarCliente({
            postdata: { cliente: JSON.stringify(_cliente) },
            success: function (response, textStatus, jqXHR) {
                location.reload();
            }
        });

    }

    function Editar(vClienteId, vNome) {

        $("#ClienteModal").modal();

        $('#NomeCliente').val(vNome);

        _id = vClienteId;

        $("#AtualizarCliente").show();
        $("#SalvarCliente").hide();

    }

    function Excluir(vClienteId, vNome) {

        var _cliente = {
            clienteId: vClienteId,
            Nome: vNome
        };

        clienteController.excluirCliente({
            postdata: { cliente: JSON.stringify(_cliente) },
            success: function (response, textStatus, jqXHR) {
                location.reload();
            }
        });
    }

    function carregarTabelaCliente() {
        clienteController.obterListaCliente({
            success: function (response) {

                var obj = JSON.parse(response.d);

                $('#tabelaListaCliente').dataTable({
                    processing: true,
                    data: obj,
                    columns: [
                        { data: "ClienteId" },
                        { data: "Nome" },
                        { data: "Excluir" },
                        { data: "Editar" }
                    ],
                    "language": {
                        "sEmptyTable": "Nenhum registro encontrado",
                        "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
                        "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
                        "sInfoFiltered": "(Filtrados de _MAX_ registros)",
                        "sInfoPostFix": "",
                        "sInfoThousands": ".",
                        "sLengthMenu": "_MENU_ Resultados por página",
                        "sLoadingRecords": "Carregando...",
                        "sProcessing": "Processando...",
                        "sZeroRecords": "Nenhum registro encontrado",
                        "sSearch": "Pesquisar ",
                        "oPaginate": {
                            "sNext": "Próximo",
                            "sPrevious": "Anterior",
                            "sFirst": "Primeiro",
                            "sLast": "Último"
                        },
                        "oAria": {
                            "sSortAscending": ": Ordenar colunas de forma ascendente",
                            "sSortDescending": ": Ordenar colunas de forma descendente"
                        }
                    }
                });
            }
        });
    }

})();

