<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientePagina.aspx.cs" Inherits="WebApp.Paginas.ClientePagina1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="jumbotron">
        <form>
            <a id="AbrirModalCliente" class="btn btn-primary" href="#">Novo</a>
        </form>
        <div class="row"></div>
        
    </div>
    <div class="row-fluid">
            <div class="span12">
                <table id="tabelaListaCliente" class="table table-bordered table-radmin" cellspacing="0" width="100%">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Nome</th>
                            <th>Excluir</th>
                            <th>Editar</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>

    <div class="modal fade" id="ClienteModal" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Cadastro de Cliente</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="exampleInputPassword1">Nome</label>
                        <input class="form-control" id="NomeCliente" placeholder="Digite o nome do Cliente">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
                    <button id="SalvarCliente" type="button" class="btn btn-primary" data-dismiss="modal">Salvar</button>
                    <button id="AtualizarCliente" type="button" class="btn btn-primary" data-dismiss="modal">Atualizar</button>
                </div>
            </div>
        </div>
    </div>

    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <script src="../Scripts/DataTables/dataTables.bootstrap.min.js"></script>
        
<%--    @Scripts.Render("~/bundles/controllerJs")
    @Scripts.Render("~/bundles/behaviorsJs")--%>    

    <script src="../Scripts/controller/clienteController.js"></script>
    <script src="../Scripts/behaviors/cliente.js"></script>

</asp:Content>
