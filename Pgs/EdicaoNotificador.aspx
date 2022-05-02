<%@ Page Language="C#" MasterPageFile="../Notfy.master" AutoEventWireup="true" CodeBehind="EdicaoNotificador.aspx.cs" Inherits="Notfy_LinqToSql.Pgs.EdicaoNotificador" %>

<%@ Register Src="~/Uc/FormNotificador.ascx" TagPrefix="uc1" TagName="FormNotificador" %>


<asp:Content ContentPlaceHolderID="content" runat="server">

    <script src="../Js/Notificador.js"></script>

    <script type="text/javascript">
        var IdNotificadorParam = ValorParamContexto("id");
        BuscarDadosNotificador(IdNotificadorParam);
    </script>

    <uc1:FormNotificador runat="server" ID="FormNotificador" />

</asp:Content>
