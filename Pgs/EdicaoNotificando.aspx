<%@ Page Language="C#" MasterPageFile="../Notfy.master" AutoEventWireup="true" CodeBehind="EdicaoNotificando.aspx.cs" Inherits="Notfy_LinqToSql.Pgs.EdicaoNotificando" %>

<%@ Register Src="~/Uc/FormNotificando.ascx" TagPrefix="uc1" TagName="FormNotificando" %>
<%@ Register Src="~/Uc/MdlEnderecosNotificando.ascx" TagPrefix="uc1" TagName="MdlEnderecosNotificando" %>



<asp:Content ContentPlaceHolderID="content" runat="server">

    <script src="../Js/Notificando.js"></script>

    <script type="text/javascript">
        var IdNotificandoParam = ValorParamContexto("id");
        BuscarDadosNotificando(IdNotificandoParam);
    </script>

    <uc1:FormNotificando runat="server" ID="FormNotificando" />
    <uc1:MdlEnderecosNotificando runat="server" ID="MdlEnderecosNotificando" />
</asp:Content>
