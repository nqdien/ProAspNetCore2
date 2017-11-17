using DependencyInjection.Controllers;
using DependencyInjection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Tests
{
    public class DITests
    {
        [Fact]
        public void ControllerTest()
        {
            // Arrange
            var data = new[] { new Product { Name = "Test", Price = 100 } };
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(data);
            HomeController controller = new HomeController
            {
                Repository = mock.Object
            };
            // Act
            ViewResult result = controller.Index();
            // Assert
            Assert.Equal(data, result.ViewData.Model);
        }
    }
}
