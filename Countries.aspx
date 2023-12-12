<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Countries.aspx.cs" Inherits="WorldCupManagementSystem.Countries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <div class="row mt-3">
    <div class="col-12">
        <asp:Button Text="New" CssClass="btn btn-primary" ID="btnNew" OnClick="btnNew_Click" runat="server" />
        <asp:Button Text="Generate Fake countries" ID="btnGenerate" CssClass="btn btn-primary" OnClick="btnGenerate_Click" runat="server" />
    </div>
</div>
<div class="row mt-3">
    <div class="col-12">
        <table class="table table-bordered border-dark table-striped table-hover">
            <thead>
                <tr>
                    <th colspan="2"></th>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Location</th>
                    <th>Group</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="rptData" OnItemCommand="rptData_ItemCommand" >
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:LinkButton CssClass="btn btn-warning" Text="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EDIT" runat="server" />
                            </td>
                            <td>
                                <asp:LinkButton CssClass="btn btn-danger" Text="Delete" CommandArgument='<%# Eval("ID") %>' CommandName="DELETE" runat="server" />
                            </td>
                            <td>
                                <asp:Label Text='<%# Eval("ID") %>' runat="server" />
                            </td>
                            <td>
                                <asp:Label Text='<%# Eval("Name") %>' runat="server" />
                            </td>
                            <td>
                                <asp:Label Text='<%# Eval("Location") %>' runat="server" />
                            </td>
                            <td>
                                <asp:Label Text='<%# Eval("Group") %>' runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</div>
</asp:Content>
