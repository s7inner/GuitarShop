<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="reportingGuitars.aspx.cs" Inherits="ElibraryManagement.reportingGuitars" %>
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
                    <h3>Звітність по таблиці гітар в БД</h3>
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDB2ConnectionString %>" SelectCommand="SELECT * FROM [guitar_master_tbl]"></asp:SqlDataSource>
                    <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"  DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" InsertVisible="False" ReadOnly="True" />

                                <asp:BoundField DataField="guitar_name" HeaderText="guitar_name" SortExpression="guitar_name" />
                                <asp:BoundField DataField="guitar_type" HeaderText="guitar_type" SortExpression="guitar_type" />
                                <asp:BoundField DataField="guitar_color" HeaderText="guitar_color" SortExpression="guitar_color" />
                                <asp:BoundField DataField="guitar_weight" HeaderText="guitar_weight" SortExpression="guitar_weight" />
                                <asp:BoundField DataField="guitar_material" HeaderText="guitar_material" SortExpression="guitar_material" />
                                <asp:BoundField DataField="number_of_strings" HeaderText="number_of_strings" SortExpression="number_of_strings" />

                                <asp:BoundField DataField="guitar_price" HeaderText="guitar_price" SortExpression="guitar_price" />
                                <asp:BoundField DataField="guitar_img_link" HeaderText="guitar_img_link" SortExpression="guitar_img_link" />
                                <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
                                <asp:BoundField DataField="publish_date" HeaderText="publish_date" SortExpression="publish_date" />
                                <asp:BoundField DataField="guitar_description" HeaderText="guitar_description" SortExpression="guitar_description" />

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
