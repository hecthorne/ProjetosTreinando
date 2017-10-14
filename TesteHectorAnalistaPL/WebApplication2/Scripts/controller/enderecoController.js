var enderecoController = (function () {

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

    function listarClientes(obj) {
        setDefaultAjaxSetup(obj);
        $.ajax({
            url: 'EnderecoPagina.aspx/ListarClientes'
        });
    }

    function salvarEndereco(obj) {
        setDefaultAjaxSetup(obj);
        $.ajax({
            url: 'EnderecoPagina.aspx/Salvar'
        });
    }

    function atualizarEndereco(obj) {
        setDefaultAjaxSetup(obj);
        $.ajax({
            url: 'EnderecoPagina.aspx/Atualizar'
        });
    }

    function excluirEndereco(obj) {
        setDefaultAjaxSetup(obj);
        $.ajax({
            url: 'EnderecoPagina.aspx/Excluir'
        });
    }

    function obterListaEndereco(obj) {
        setDefaultAjaxSetup(obj);
        $.ajax({
            url: 'EnderecoPagina.aspx/ListarEnderecos'
        });
    }

    return {
        salvarEndereco: salvarEndereco,
        atualizarEndereco: atualizarEndereco,
        excluirEndereco: excluirEndereco,
        obterListaEndereco: obterListaEndereco,
        listarClientes: listarClientes
    };

}());


