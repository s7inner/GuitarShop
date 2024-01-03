<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="ElibraryManagement.userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script type="text/javascript">
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       });
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <div class="container-fluid">
       <br/>
      <div class="row">
         <div class="col-md-4">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="imgs/generaluser.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Ваш профіль</h4>
                           <span>Статус аккаунту - </span>
                           <asp:Label class="badge badge-pill badge-info" ID="Label1" runat="server" Text="Ваш статус"></asp:Label>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                    <div class="row">
                     <div class="col-md-6">
                        <label>Ім'я</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Ім'я"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Дата народження</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" placeholder="Дата народження" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Телефон</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox13" runat="server" placeholder="Телефон" TextMode="Phone"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Email</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox14" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col">
                        <center>
                           <span class="badge badge-pill badge-info">Авторизаційні дані</span>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>Логін</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder="Логін" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Старий пароль</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="Старий пароль" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Новий пароль</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder="Новий пароль" TextMode="Password"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-8 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Оновити дані" OnClick="Button1_Click" />
                           </div>
                        </center>
                     </div>
                  </div>
               </div>
            </div>
           
         </div>
        
          <div class="col-md-8">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="imgs/main_logo.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Добавлені гітари</h4>
                           <asp:Label class="badge badge-pill badge-info" ID="Label2" runat="server" Text="Детальна інформація про добавлені товари"></asp:Label>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                   <div class="row">

                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDB2ConnectionString %>" SelectCommand="SELECT * FROM [guitar_master_tbl] WHERE ([publisher_name] LIKE '%' + @publisher_name + '%')">
                         <SelectParameters>
                             <asp:ControlParameter ControlID="TextBox11" Name="publisher_name" PropertyName="Text" Type="String" />
                         </SelectParameters>
                       </asp:SqlDataSource>
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
                           <Columns>
                              <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" InsertVisible="False" >
                              </asp:BoundField>
                               <asp:BoundField DataField="publisher_name" HeaderText="Публікатор" SortExpression="publisher_name" />
                               <asp:BoundField DataField="guitar_name" HeaderText="Назва" SortExpression="guitar_name" />
                               <asp:BoundField DataField="guitar_type" HeaderText="Тип" SortExpression="guitar_type" />
                               <asp:BoundField DataField="guitar_color" HeaderText="Колір" SortExpression="guitar_color" />
                               <asp:BoundField DataField="guitar_weight" HeaderText="Вага" SortExpression="guitar_weight" />
                               <asp:BoundField DataField="guitar_material" HeaderText="Матеріал" SortExpression="guitar_material" />
                               <asp:BoundField DataField="number_of_strings" HeaderText="Струн" SortExpression="number_of_strings" />
                               <asp:BoundField DataField="guitar_price" HeaderText="Ціна" SortExpression="guitar_price" />
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