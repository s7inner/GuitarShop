<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="guitarinventory.aspx.cs" Inherits="ElibraryManagement.guitarinventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       });

       function readURL(input) {
           if (input.files && input.files[0]) {
               var reader = new FileReader();

               reader.onload = function (e) {
                   $('#imgview').attr('src', e.target.result);
               };

               reader.readAsDataURL(input.files[0]);
           }
       }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <br/>
      <div class="row">
         <div class="col-md-5">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Додати гітару</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img id="imgview" Height="120px" Width="100px" src="guitar_inventory/inventory_logo.png" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <asp:FileUpload onchange="readURL(this);" class="form-control" ID="FileUpload1" runat="server" />
                     </div>
                  </div>
                  
                   

                  
                    <div class="row">
                     <div class="col-md-4">
                        <label>ID гітари</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="ID гітари"></asp:TextBox>
                              <asp:Button class="form-control btn btn-primary" ID="Button5" runat="server" Text="Go" OnClick="Button4_Click" />
                           </div>
                        </div>
                     </div>

                     <div class="col-md-4">
                        <label>Назва</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" placeholder="Назва"></asp:TextBox>
                        </div>
                     </div>
                        
                     <div class="col-md-4">
                        <label>Тип</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList4" runat="server">
                              <asp:ListItem Text="Класична" Value="Класична" />
                              <asp:ListItem Text="Акустична" Value="Акустична" />
                              <asp:ListItem Text="Електроакустична" Value="Електроакустична" />
                              <asp:ListItem Text="Електрогітара" Value="Електрогітара" />
                              <asp:ListItem Text="Ритм-гітара" Value="Ритм-гітара" />
                              <asp:ListItem Text="Соло-гітара" Value="Соло-гітара" />
                              <asp:ListItem Text="Бас-гітара" Value="Бас-гітара" />
                           </asp:DropDownList>
                        </div>  
                     </div>   
                  </div>

                  <div class="row">
                     <div class="col-md-4">
                        <label>Колір</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox13" runat="server" placeholder="Колір"></asp:TextBox>
                        </div>   
                     </div>

                     <div class="col-md-4">
                        <label>Вага</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox14" runat="server" placeholder="Вага"></asp:TextBox>
                        </div>     
                     </div>
                        
                     <div class="col-md-4">
                        <label>Матеріал</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox15" runat="server" placeholder="Матеріал"></asp:TextBox>
                        </div> 
                     </div>   
                  </div>  

                    <div class="row">
                     <div class="col-md-4">
                        <label>Всього струн</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox16" runat="server" placeholder="Всього струн"></asp:TextBox>
                        </div>   
                     </div>

                     <div class="col-md-4">
                        <label>Ціна</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox17" runat="server" placeholder="Ціна"></asp:TextBox>
                        </div>     
                     </div>
                        
                     <div class="col-md-4">
                        <label>Дата публікації</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox18" runat="server" placeholder="Дата публікації" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>   
                  </div>  

                   <div class="row">
                     <div class="col-12">
                        <label>Опис гітари</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox19" runat="server" placeholder="Опис гітари" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col-4">
                        <asp:Button ID="Button1" class="btn btn-lg btn-block btn-success" runat="server" Text="Додати" OnClick="Button1_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Оновити" OnClick="Button3_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-danger" runat="server" Text="Видалити" OnClick="Button2_Click" />
                     </div>
                  </div>
               </div>
            </div>
          
            <br>
         </div>
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Дані про добавлені гітари</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDB2ConnectionString %>" SelectCommand="SELECT * FROM [guitar_master_tbl]"></asp:SqlDataSource>
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
                           <Columns>
                              <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" SortExpression="Id" />
                              
                               <asp:TemplateField>
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
                                                    <asp:Image ID="Image1"  Height="170px" Width="150px" runat="server" ImageUrl='<%# Eval("guitar_img_link") %>' BorderColor="Black" BorderStyle="Solid" BorderWidth="1" />
                                                </div>
                                            </div>
                                        </div>
                                   </ItemTemplate>
                               </asp:TemplateField>
                              
                           </Columns>
                        </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
        <br/>
   </div>
</asp:Content>