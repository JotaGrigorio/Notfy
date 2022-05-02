<%@ Page Language="C#" MasterPageFile="../Notfy.master" AutoEventWireup="true" CodeBehind="ListaNotificandos.aspx.cs" Inherits="Notfy_LinqToSql.Pgs.ListaNotificandos" %>

<%@ Register Src="~/Uc/MdlEnderecosNotificando.ascx" TagPrefix="uc1" TagName="MdlEnderecosNotificando" %>


<asp:Content ContentPlaceHolderID="content" runat="server">
    <script src="../Js/Notificando.js"></script>

    <div class="container-listagem">
        <div class="mt-3">
            <h3>NOTIFICANDOS</h3>
        </div>

        <div class="mb-2">
            <button type="button" class="btn btn-primary" id="btn_incluir_notificando">
                <i class="fa fa-plus" title="Incluir novo notificando"></i>
            </button>
        </div>

        <div class="row">
            <div class="col-lg-12 m-top-sm">
                <div id="divTbNotificandos" style="min-height: 410px;">
                    <table id="tbNotificandos" class="table table-striped table-hover">
                        <thead>
                            <tr>
                                <th style="width: 23%;">Nome</th>
                                <th style="width: 23%;">Email</th>
                                <th style="width: 14%;">Telefone</th>
                                <th style="width: 14%;">CPF</th>
                                <th style="width: 10%;">Endereço</th>
                                <th style="width: 8%;">Editar</th>
                                <th style="width: 8%;">Excluir</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>
            </div>
        </div>
        <div id="pgNotificandos" class="paginacao"></div>
    </div>

    <uc1:MdlEnderecosNotificando runat="server" id="MdlEnderecosNotificando" />

</asp:Content>
