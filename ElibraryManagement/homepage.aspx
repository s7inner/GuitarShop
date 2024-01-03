<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="ElibraryManagement.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"  runat="server">
    <div class="container" style="padding-top: 10px;">
        <section id="carousel" style="margin-top: 0px;padding-right: 15px;padding-left: 15px;">
            <div class="carousel slide" data-ride="carousel" id="carousel-1">
                <div class="carousel-inner">
                    <div class="carousel-item">
                        <div class="jumbotron pulse animated hero-nature carousel-hero">
                            <h1 class="hero-title">Легендарні гітари</h1>
                            <p class="hero-subtitle" style="background: #4C5C7A;transform: perspective(0px);opacity: 1;border-radius: 21px;">Перейди на сторінку "Список гітар",&nbsp; де ти зможеш дізнатись про них більше та замовити одну з них собі!<br></p>
                        </div>
                    </div>
                    <div class="carousel-item active">
                        <div class="jumbotron pulse animated hero-technology carousel-hero">
                            <h1 class="hero-title">Вистави на продаж свою гітару</h1>
                            <p class="hero-subtitle" style="background: #4C5C7A;transform: perspective(0px);opacity: 1;border-radius: 21px;">Перейди на сторінку "Додати гітару",<br>представ свою гітару іншим і незабаром хтось точно захоче її придбати!</p>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <div class="jumbotron pulse animated hero-photography carousel-hero">
                            <h1 class="hero-title">Відслідковуй вподобані товари</h1>
                            <p class="hero-subtitle" style="background: #4C5C7A;transform: perspective(0px);opacity: 1;border-radius: 21px;">Перейди на сторінку "Корзина",&nbsp; де ти зможеш переглянути список гітар, які тобі сподобались!<br></p>
                        </div>
                    </div>
                </div>
                <div><a class="carousel-control-prev" href="#carousel-1" role="button" data-slide="prev"><i class="fa fa-chevron-left"></i><span class="sr-only">Previous</span></a><a class="carousel-control-next" href="#carousel-1" role="button" data-slide="next"><i class="fa fa-chevron-right"></i><span class="sr-only">Next</span></a></div>
                <ol class="carousel-indicators">
                    <li data-target="#carousel-1" data-slide-to="0" class=""></li>
                    <li data-target="#carousel-1" data-slide-to="1" class="active"></li>
                    <li data-target="#carousel-1" data-slide-to="2" class=""></li>
                </ol>
            </div>
        </section>
        <section class="article-list">
            <div class="container">
                <div class="intro">
                    <h2 class="text-center" style="margin-bottom: 10px;padding-top: 30px;">Переваги нашого сайту</h2>
                    <p class="text-center">Тут ви можете знайти таку інформацію:</p>
                </div>
                <div class="row articles" style="padding-bottom: 0px;">
                    
                    <div class="col-sm-6 col-md-4 item" style="padding-top: 30px;"><img class="img-fluid" src="imgs/index_photo1.jpg" style="height: 200px;max-width: 100%;width: 340px;max-height: 100%;"></a>
                        <h3 class="name">Кастомні гітари</h3>
                        <p class="description">Ви будете мати можливість ознайомитись з цікавими музичними інструментами, переглянути їх фото, характеристики, зрівняти з іншими.</p>
                    </div>
                    <div class="col-sm-6 col-md-4 item" style="padding-top: 30px;"><img class="img-fluid" src="imgs/index_photo2.jpg" style="height: 200px;width: 340px;max-width: 100%;max-height: 100%;"></a>
                        <h3 class="name">Зручне додавання товарів</h3>
                        <p class="description">Ви з легкістю зможете додати власний кастомний виріб на наш сайт. Наш менеджер відразу вас сповістить про те, що ваш товар хочуть придбати.&nbsp;</p>
                    </div>
                    
                    <div class="col-sm-6 col-md-4 mx-sm-auto item" style="padding-top: 30px;"><img class="img-fluid" src="imgs/index_photo3.png" style="height: 200px;max-height: 100%;width: 340px;max-width: 100%;"></a>
                        <h3 class="name">Управління вподобаними товарами</h3>
                        <p class="description">Перейшовши на вкладку "Корзина" ви зможете відслідкувати всі товари, які ви в неї добавили та видалити з неї неактуальні.</p>
                    </div>
                </div>
                <div>
                    <h4 style="text-align: center;">Де нас знайти?</h4><iframe allowfullscreen="" frameborder="0" loading="lazy" src="https://www.google.com/maps/embed/v1/place?key=AIzaSyCmUAI0bIpdjGPBpHQl4f8qEPNMA5srQb4&amp;q=%D0%9B%D1%8C%D0%B2%D1%96%D0%B2%D1%81%D1%8C%D0%BA%D0%B0+%D0%BF%D0%BE%D0%BB%D1%96%D1%82%D0%B5%D1%85%D0%BD%D1%96%D0%BA%D0%B0&amp;zoom=11" width="100%" height="400" style="padding-bottom: 10px;"></iframe>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
