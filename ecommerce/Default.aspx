<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v22.2, Version=22.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v22.2, Version=22.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <dx:bootstraplistbox runat="server" SelectionMode="CheckColumn" DataSourceID="db">
        
    </dx:bootstraplistbox>
<asp:SqlDataSource ID="db" runat="server" ConnectionString="<%$ ConnectionStrings:ecom_db %>" SelectCommand="SELECT * FROM [category] ORDER BY [name]"></asp:SqlDataSource>
</asp:Content>

