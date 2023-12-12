<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Groups.aspx.cs" Inherits="WorldCupManagementSystem.Groups" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <div class="row mt-3">
        <div class="col-12">
            <asp:Button Text="Generate Groups" ID="btnGenerate" CssClass="btn btn-primary" OnClick="btnGenerate_Click" runat="server" />
        </div>
    </div>
    <div class="row mt-3">
        <asp:Repeater runat="server" ID="rptGroups">
            <ItemTemplate>
                <div class="col-3">
                    <div class="card">
                        <div class="card-header">
                            <asp:Label Text='<%# Eval("Name") %>' runat="server" />
                            <asp:HiddenField ID="hfCountries" runat="server" Value='<%#Eval("CountryList") %>' />
                        </div>
                        <div class="card-body">
                            <ul>
                                <asp:Repeater runat="server" ID="rptCountry">
                                    <ItemTemplate>
                                        <li><%#Eval("Name") %></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
