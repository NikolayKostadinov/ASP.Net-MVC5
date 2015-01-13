namespace SportsStore.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SportStore.Domain.Abstract;
    using SportStore.Domain.Entities;
    using SportStore.WebUI.Controllers;
    using SportStore.WebUI.Models;
    using SportStore.WebUI.HtmlHelpers;

    [TestClass]
    public class ControllersTest
    {
        private static Mock<IProductRepository> mock;

        static ControllersTest()
        {
            mock = new Mock<IProductRepository>();
            mock.Setup(p => p.Products).Returns(new Product[]
            {
                new Product { ProductID = 1, Name = "P1", Category = "cat1" },
                new Product { ProductID = 2, Name = "P2", Category = "cat2"},
                new Product { ProductID = 3, Name = "P3", Category = "cat1"},
                new Product { ProductID = 4, Name = "P4", Category = "cat2"},
                new Product { ProductID = 5, Name = "P5", Category = "cat3"},
            });
        }

        [TestMethod]
        public void Can_Paginate()
        {
            //Arrange
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //Act
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;

            //Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            // Arrange - define an HTML helper - we need to do this
            // in order to apply the extension method
            HtmlHelper myHelper = null;
            // Arrange - create PagingInfo data
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            // Arrange - set up the delegate using a lambda expression
            Func<int, string> pageUrlDelegate = i => "Page" + i;
            // Act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);
            // Assert
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>" +
                            @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>" +
                            @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            // Act
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }

        [TestMethod]
        public void Can_Filter_Products()
        {
            //Arrange
            var controler = new ProductController(mock.Object);

            //Act
            Product[] result = ((ProductsListViewModel)controler.List("cat2", 1).Model).Products.ToArray();

            //Assert
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result[0].Name == "P2" && result[0].Category == "cat2");
            Assert.IsTrue(result[1].Name == "P4" && result[1].Category == "cat2");
        }

        [TestMethod]
        public void Can_Create_Categories()
        {
            //Arrange
            var controller = new NavController(mock.Object);

            //Act
            string[] categories = ((CategoryListView)controller.Menu().Model).Categories.ToArray();

            //Assert
            Assert.AreEqual(3, categories.Length);
            Assert.IsTrue(categories[0] == "cat1");
            Assert.IsTrue(categories[1] == "cat2");
            Assert.IsTrue(categories[2] == "cat3");
        }

        [TestMethod]
        public void Indicates_Selected_Category()
        {
            //Arrange
            var controller = new NavController(mock.Object);
            string selectedCategory = "cat2";

            //Act
            var actualSelectedCategory = ((CategoryListView)controller.Menu(selectedCategory).Model).CurrentCategory;

            //Assert
            Assert.AreEqual(selectedCategory, actualSelectedCategory);
        }

        [TestMethod]
        public void Generate_Category_Specific_Product_Count()
        {
            //Arrange
            var controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //Act
            // Action - test the product counts for different categories
            int res1 = ((ProductsListViewModel)controller.List("cat1").Model).PagingInfo.TotalItems;
            int res2 = ((ProductsListViewModel)controller.List("cat2").Model).PagingInfo.TotalItems;
            int res3 = ((ProductsListViewModel)controller.List("cat3").Model).PagingInfo.TotalItems;
            int resAll = ((ProductsListViewModel)controller.List(null).Model).PagingInfo.TotalItems;

            //Assert
            Assert.AreEqual(2, res1);
            Assert.AreEqual(2, res2);
            Assert.AreEqual(1, res3);
            Assert.AreEqual(5, resAll);
        }
    }
}