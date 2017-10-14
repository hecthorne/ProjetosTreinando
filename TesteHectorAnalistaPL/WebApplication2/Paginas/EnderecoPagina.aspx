<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnderecoPagina.aspx.cs" Inherits="WebApp.Paginas.EnderecoPagina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="jumbotron">
        <form>
            <a id="criarEndereco" class="btn btn-primary" href="#">Novo</a>
        </form>
        <div class="row"></div>

    </div>

    <div class="row-fluid">
        <div class="span12">
            <table id="tabela" class="table table-bordered table-radmin" cellspacing="0" width="100%">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>EnderecoCompleto</th>
                        <th>Bairro</th>
                        <th>Cep</th>
                        <th>Cliente</th>

                        <th>Excluir</th>
                        <th>Editar</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>

    <div class="modal fade" id="Modal" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Cadastro de Endereço</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Endereco Completo</label>
                        <input class="form-control" id="EnderecoCompleto" placeholder="Digite o endereço">
                        <label>Bairro</label>
                        <input class="form-control" id="Bairro" placeholder="Digite o bairro">
                        <label>Cep</label>
                        <input class="form-control" id="Cep" placeholder="Digite o cep">
                        <label>Cliente</label>
                        <select id="comboCliente" class="form-control" style="width: 100%"></select>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
                    <button id="Salvar" type="button" class="btn btn-primary" data-dismiss="modal">Salvar</button>
                    <button id="Atualizar" type="button" class="btn btn-primary" data-dismiss="modal">Atualizar</button>
                </div>
            </div>
        </div>
    </div>

    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <script src="../Scripts/DataTables/dataTables.bootstrap.min.js"></script>
    <script src="../Scripts/controller/enderecoController.js"></script>
    <script src="../Scripts/behaviors/endereco.js"></script>
    
</asp:Content>
