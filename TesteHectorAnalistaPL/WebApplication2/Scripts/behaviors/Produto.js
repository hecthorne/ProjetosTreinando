(function () {
    var _id = '';

    $(document).ready(function () {

        carregarTabela();

        $("#criarProduto").click(function () {
            $("#Modal").modal();
            $("#Salvar").show();
            $("#Atualizar").hide();

            limparCampos();
        });

        $("#Salvar").click(function () {

            var _descricao = $('#Descricao').val();
            var _valor = $('#Valor').val();

            var _produto = {
                Descricao: _descricao,
                Valor: _valor
            };

            produtoController.salvar({
                postdata: { produto: JSON.stringify(_produto) },
                success: function (response, textStatus, jqXHR) {

                    location.reload();
                }
            });

        });

        $('#Atualizar').click(function () {
            SalvarAtualizar();
        })

    });

    function limparCampos() {
        $('#Descricao').val('');
        $('#Valor').val('');
    }

    function Editar(vProdutoId, vDescricao, vValor) {

        $("#Modal").modal();

        $('#Descricao').val(vDescricao);
        $('#Valor').val(vValor);

        _id = vProdutoId;

        $("#Atualizar").show();
        $("#Salvar").hide();
    }

    function SalvarAtualizar() {

        var _produtoId = _id;
        var _descricao = $('#Descricao').val();
        var _valor = $('#Valor').val();

        var _produto = {
            ProdutoId: _produtoId,
            Descricao: _descricao,
            Valor: _valor
        };

        produtoController.atualizar({
            postdata: { produto: JSON.stringify(_produto) },
            success: function (response, textStatus, jqXHR) {
                location.reload();
            }
        });
    }

    function Excluir(vProdutoId) {

        var _produto = {
            ProdutoId: vProdutoId
        };

        produtoController.excluir({
            postdata: { produto: JSON.stringify(_produto) },
            success: function (response, textStatus, jqXHR) {
                location.reload();
            }
        });
    }

    function carregarTabela() {
        produtoController.obterLista({
            success: function (response) {

                var obj = JSON.parse(response.d);

                $('#tabela').dataTable({
                    processing: true,
                    data: obj,
                    columns: [
                        { data: "ProdutoId" },
                        { data: "Descricao" },
                        { data: "Valor" },

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