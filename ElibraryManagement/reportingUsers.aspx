<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="reportingUsers.aspx.cs" Inherits="ElibraryManagement.reportingUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">

            <div class="col-sm-12">
                <br />


                <center>
                    <h3>Звітність по таблиці користувачів в БД</h3>
                </center>
                <div class="row">
                    <div class="col-sm-12 col-md-12">
                        <asp:Panel class="alert alert-success" role="alert" ID="Panel1" runat="server" Visible="False">
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </asp:Panel>
                    </div>
                </div>
                <br />
                <div class="row">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDB2ConnectionString %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                    <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id"  DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="full_name" HeaderText="full_name" SortExpression="full_name" />

                                <asp:BoundField DataField="dob" HeaderText="dob" SortExpression="dob" />
                                <asp:BoundField DataField="contact_no" HeaderText="contact_no" SortExpression="contact_no" />
                                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                                <asp:BoundField DataField="member_id" HeaderText="member_id" SortExpression="member_id" ReadOnly="True" />
                                <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                                <asp:BoundField DataField="account_status" HeaderText="account_status" SortExpression="account_status" />

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <br/>

                

                
                <br/>
            </div>

            <asp:LinkButton ID="LinkButton52" class="btn btn-lg btn-block btn-success" runat="server" OnClick="LinkButton52_Click">Звітність в Excel</asp:LinkButton>
            <asp:LinkButton ID="LinkButton53" class="btn btn-lg btn-block btn-danger" runat="server" OnClick="LinkButton53_Click">Звітність в PDF</asp:LinkButton>

            <br />
            

        </div>
        <br/>
   </div>
</asp:Content>
