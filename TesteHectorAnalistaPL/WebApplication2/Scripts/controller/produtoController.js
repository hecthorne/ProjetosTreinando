    var produtoController = (function () {

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

        function salvar(obj) {
            setDefaultAjaxSetup(obj);
            $.ajax({
                url: 'ProdutoPagina.aspx/Salvar'
            });
        }

        function atualizar(obj) {
            setDefaultAjaxSetup(obj);
            $.ajax({
                url: 'ProdutoPagina.aspx/Atualizar'
            });
        }

        function excluir(obj) {
            setDefaultAjaxSetup(obj);
            $.ajax({
                url: 'ProdutoPagina.aspx/Excluir'
            });
        }

        function obterLista(obj) {
            setDefaultAjaxSetup(obj);
            $.ajax({
                url: 'ProdutoPagina.aspx/ObterLista'
            });
        }

        return {
            salvar: salvar,
            atualizar: atualizar,
            excluir: excluir,
            obterLista: obterLista
        };

    }());

