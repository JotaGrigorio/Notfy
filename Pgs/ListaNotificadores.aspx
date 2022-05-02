<%@ Page Language="C#" MasterPageFile="../Notfy.master" AutoEventWireup="true" CodeBehind="ListaNotificadores.aspx.cs" Inherits="Notfy_LinqToSql.Pgs.ListaNotificadores" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <script src="../Js/Notificador.js"></script>

    <div class="container-listagem">
        <div class="mt-3">
            <h3>NOTIFICADORES</h3>
        </div>

        <div class="mb-2">
            <button type="button" class="btn btn-primary" id="btn_incluir_notificador">
                <i class="fa fa-plus" title="Incluir novo notificador"></i>
            </button>
        </div>

        <div class="row">
            <div class="col-lg-12 m-top-sm">
                <div id="divTbNotificadores" style="min-height: 410px;">
                    <table id="tbNotificadores" class="table table-striped table-hover">
                        <thead>
                            <tr>
                                <th style="width: 23%;">Nome</th>
                                <th style="width: 23%;">Email</th>
                                <th style="width: 14%;">Telefone</th>
                                <th style="width: 14%;">CPF</th>                               
                                <th style="width: 10%;">Tipo</th>
                                <th style="width: 8%;">Editar</th>
                                <th style="width: 8%;">Excluir</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>
            </div>
        </div>
        <div id="pgNotificadores" class="paginacao"></div>
    </div>

</asp:Content>
