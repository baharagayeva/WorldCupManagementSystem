<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddOrEditCountry.aspx.cs" Inherits="WorldCupManagementSystem.AddOrEditCountry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <div class="row mt-3">
        <div class="col-6">
            <asp:Label Text="ID" runat="server" />
        </div>
        <div class="col-6">
            <asp:TextBox runat="server" ID="txtId" Enabled="false" CssClass="form-control" />
        </div>
    </div>
    <div class="row mt-3">
        <div class="col-6">
            <asp:Label Text="Name" runat="server" />
        </div>
        <div class="col-6">
            <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />
        </div>
    </div>
    <div class="row mt-3">
        <div class="col-6">
            <asp:Label Text="Location" runat="server" />
        </div>
        <div class="col-6">
            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlLocation" />
        </div>
    </div>
     <div class="row mt-3">
        <div class="col-12 d-flex justify-content-end">
            <asp:Button Text="Save" ID="btnSave" CssClass="btn btn-primary" OnClick="btnSave_Click" runat="server" />
            <asp:Button Text="Cancel" ID="btnCancel" CssClass="btn btn-primary" OnClick="btnCancel_Click" runat="server" />
        </div>
    </div>
</asp:Content>
