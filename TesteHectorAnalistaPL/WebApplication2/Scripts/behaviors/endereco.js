(function () {

    var _id = '';

    $(document).ready(function () {

        carregarTabela();

        $("#criarEndereco").click(function () {
            $("#Modal").modal();
            $("#Salvar").show();
            $("#Atualizar").hide();

            limparCampos();
        });

        $("#Salvar").click(function () {

            var _enderecoCompleto = $('#EnderecoCompleto').val();
            var _bairro = $('#Bairro').val();
            var _cep = $('#Cep').val();
            var _clienteId = $('#comboCliente').val();

            var _endereco = {
                EnderecoCompleto: _enderecoCompleto,
                Bairro: _bairro,
                Cep: _cep,
                ClienteId: _clienteId
            };

            enderecoController.salvarEndereco({
                postdata: { endereco: JSON.stringify(_endereco) },
                success: function (response, textStatus, jqXHR) {

                    location.reload();
                }
            });

        });

        $('#Atualizar').click(function () {
            SalvarAtualizar();
        })

    });

    function popularListaClientes() {

        enderecoController.listarClientes({
            success: function (response) {
                var obj = JSON.parse(response.d);
                carregarDropDown('comboCliente', obj);
            }
        });
    }

    function limparCampos() {
        $('#EnderecoCompleto').val('');
        $('#Bairro').val('');
        $('#Cep').val('');
        $('#comboCliente').val('select');
    }

    function Editar(vEnderecoId, vEnderecoCompleto, vBairro, vCep, vClienteId) {

        $("#Modal").modal();

        $('#EnderecoCompleto').val(vEnderecoCompleto);
        $('#Bairro').val(vBairro);
        $('#Cep').val(vCep);

        _id = vEnderecoId;

        $("#Atualizar").show();
        $("#Salvar").hide();

        //document.getElementById('comboCliente').value = '"' + vClienteId + '"';
        $('#comboCliente').val(vClienteId);

    }

    function SalvarAtualizar() {

        var _enderecoId = _id;
        var _enderecoCompleto = $('#EnderecoCompleto').val();
        var _bairro = $('#Bairro').val();
        var _cep = $('#Cep').val();
        var _clienteId = $('#comboCliente').val();


        var _endereco = {
            EnderecoId: _enderecoId,
            EnderecoCompleto: _enderecoCompleto,
            Bairro: _bairro,
            Cep: _cep,
            ClienteId: _clienteId
        };

        enderecoController.atualizarEndereco({
            postdata: { cliente: JSON.stringify(_endereco) },
            success: function (response, textStatus, jqXHR) {
                location.reload();
            }
        });
    }

    function Excluir(vEnderecoId) {

        var _endereco = {
            EnderecoId: vEnderecoId
        };

        enderecoController.excluirEndereco({
            postdata: { endereco: JSON.stringify(_endereco) },
            success: function (response, textStatus, jqXHR) {
                location.reload();
            }
        });
    }

    function carregarDropDown(id, lista) {
        $("#" + id).empty();
        var options = '<option value="select">Selecione</option>';
        $("#" + id).html(options);
        for (var i = 0; i < ($(lista).length); i++) {
            options += '<option value="' + lista[i].ClienteId + '">' + lista[i].Nome + '</option>';
            $("#" + id).html(options);
        };
    }

    function carregarTabela() {
        enderecoController.obterListaEndereco({
            success: function (response) {
                popularListaClientes();
                var obj = JSON.parse(response.d);

                $('#tabela').dataTable({
                    processing: true,
                    data: obj,
                    columns: [
                        { data: "EnderecoId" },
                        { data: "EnderecoCompleto" },
                        { data: "Bairro" },
                        { data: "Cep" },
                        { data: "NomeCliente" },
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
            },
            error: function (response) {
                popularListaClientes();
            }
        });
    }

})();