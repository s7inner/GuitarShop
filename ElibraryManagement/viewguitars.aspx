<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewguitars.aspx.cs" Inherits="ElibraryManagement.viewguitars" %>

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
                    <h3>Список всіх гітар</h3>
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
                                <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" SortExpression="Id" />

                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <div class="container-fluid">
                                            <div class="row">
                                                <div class="col-lg-9">
                                                    <div class="row">
                                                        <div class="col-12">

                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("guitar_name") %>' Font-Size="X-Large" Font-Bold="True"></asp:Label>

                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-12">
                                                            Тип -
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("guitar_type") %>' Font-Bold="True" Font-Italic="True"></asp:Label>
                                                            &nbsp;| Колір -
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("guitar_color") %>' Font-Bold="True" Font-Italic="True"></asp:Label>
                                                            &nbsp;| Вага -
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("guitar_weight") %>' Font-Bold="True" Font-Italic="True"></asp:Label>

                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-12">
                                                            Матеріал -
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("guitar_material") %>' Font-Bold="True" Font-Italic="True"></asp:Label>
                                                            &nbsp;| К-сть струн -
                                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("number_of_strings") %>' Font-Bold="True" Font-Italic="True"></asp:Label>
                                                            &nbsp;| Ціна -
                                                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("guitar_price") %>' Font-Bold="True" Font-Italic="True"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-12">
                                                            Ім'я публікатора -
                                                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("publisher_name") %>' Font-Bold="True" Font-Italic="True"></asp:Label>
                                                            &nbsp;| Дата публікації -
                                                            <asp:Label ID="Label9" runat="server" Text='<%# Eval("publish_date") %>' Font-Bold="True" Font-Italic="True"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-12">
                                                            Опис -
                                                            <asp:Label ID="Label10" runat="server" Text='<%# Eval("guitar_description") %>' Font-Bold="True" Font-Italic="True"></asp:Label>
                                                        </div>
                                                    </div>
                                                

                                                </div>

                                                <div class="col-lg-3">
                                                    <asp:Image ID="Image1" Height="170px" Width="150px" runat="server" ImageUrl='<%# Eval("guitar_img_link") %>' BorderColor="Black" BorderStyle="Solid" BorderWidth="1" />
                                                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("guitar_img_link") %>' Visible="False"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <br/>

                

                <div class="row">
                    
                    <div class="col-6">
                        <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="ID гітари" ></asp:TextBox>

                    </div>
                    <div class="col-3">
                        <asp:Button ID="Button3" class="btn btn-lg btn-block btn-success" runat="server" Text="В корзину"  OnClick="Button1_Click" Font-Size="Medium"  />

                    </div>
                    <div class="col-3">
                        <asp:Button ID="Button6" class="btn btn-lg btn-block btn-danger" runat="server" Text="Видалити"  OnClick="Button2_Click" Font-Size="Medium"  />

                    </div>
                   
                </div>
               
                <br/>
            </div>

            <br />

        </div>
   </div>
</asp:Content>
