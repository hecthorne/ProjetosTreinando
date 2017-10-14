var clienteController = (function () {

    function setDefaultAjaxSetup(obj) {

        $.ajaxSetup({
            type: "POST",
            dataType: "json",
            data: (obj.postdata != undefined) ? JSON.stringify(obj.postdata) : "{}",
            contentType: "application/json; charset=utf-8",
            success: obj.success || function () { },
            error: obj.error || function () { },
            complete: obj.complete || function () { }
        });
    }

    function salvarCliente(obj) {
        setDefaultAjaxSetup(obj);
        $.ajax({
            url: 'ClientePagina.aspx/Salvar'
        });
    }

    function atualizarCliente(obj) {
        setDefaultAjaxSetup(obj);
        $.ajax({
            url: 'ClientePagina.aspx/Atualizar'
        });
    }

    function excluirCliente(obj) {
        setDefaultAjaxSetup(obj);
        $.ajax({
            url: 'ClientePagina.aspx/Excluir'
        });
    }

    function obterListaCliente(obj) {
        setDefaultAjaxSetup(obj);
        $.ajax({
            url: 'ClientePagina.aspx/ListarClientes'
        });
    }

    return {
        salvarCliente: salvarCliente,
        atualizarCliente: atualizarCliente,
        excluirCliente: excluirCliente,
        obterListaCliente: obterListaCliente
    };

}());