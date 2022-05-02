<%@ Page Language="C#" MasterPageFile="../Notfy.master" AutoEventWireup="true" CodeBehind="CadastroNotificando.aspx.cs" Inherits="Notfy_LinqToSql.Pgs.CadastroNotificando" %>

<%@ Register Src="~/Uc/FormNotificando.ascx" TagPrefix="uc1" TagName="FormNotificando" %>
<%@ Register Src="~/Uc/MdlEnderecosNotificando.ascx" TagPrefix="uc1" TagName="MdlEnderecosNotificando" %>


<asp:Content ContentPlaceHolderID="content" runat="server">

    <script src="../Js/Notificando.js"></script>

    <uc1:FormNotificando runat="server" id="FormNotificando" />

    <script type="text/javascript">
        $("#titulo_form_notificando").text("CADASTRO");
        $("#titulo_btn_form_notificando").text("CADASTRAR");
    </script>

    <uc1:MdlEnderecosNotificando runat="server" id="MdlEnderecosNotificando" />

</asp:Content>

