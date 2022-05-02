<%@ Page Language="C#" MasterPageFile="../Notfy.master" AutoEventWireup="true" CodeBehind="CadastroNotificacao.aspx.cs" Inherits="Notfy_LinqToSql.Pgs.CadastroNotificacao" %>

<%@ Register Src="~/Uc/FormNotificacao.ascx" TagPrefix="uc1" TagName="FormNotificacao" %>
<%@ Register Src="~/Uc/MdlObservacoesNotificacao.ascx" TagPrefix="uc1" TagName="MdlObservacoesNotificacao" %>

<asp:Content ContentPlaceHolderID="content" runat="server">

    <script src="../Js/Notificacao.js"></script>

    <uc1:FormNotificacao runat="server" id="FormNotificacao" />
    <uc1:MdlObservacoesNotificacao runat="server" ID="MdlObservacoesNotificacao" />

    <script type="text/javascript">
        $("#titulo_form_notificacao").text("CADASTRO");
        $("#titulo_btn_form_notificacao").text("CADASTRAR");
    </script>

</asp:Content>
