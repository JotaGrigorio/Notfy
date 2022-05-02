<%@ Page Language="C#" MasterPageFile="../Notfy.master" AutoEventWireup="true" CodeBehind="CadastroNotificador.aspx.cs" Inherits="Notfy_LinqToSql.Pgs.CadastroNotificador" %>

<%@ Register Src="~/Uc/FormNotificador.ascx" TagPrefix="uc1" TagName="FormNotificador" %>

<asp:Content ContentPlaceHolderID="content" runat="server">

    <script src="../Js/Notificador.js"></script>

    <uc1:FormNotificador runat="server" id="FormNotificador" />

    <script type="text/javascript">
        $("#titulo_form_notificador").text("CADASTRO");
        $("#titulo_btn_form_notificador").text("CADASTRAR");
    </script>

</asp:Content>

