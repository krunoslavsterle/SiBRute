using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SiBRute.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using SiBRute.WebAPI.Controllers;
using System.Web.Mvc;

using SiBRute.Service.Common;

namespace SiBRute.UnitTests
{
    [TestClass]
    public class TestRoutesController
    {       
        private List<BikeRoute> Routes { get; set; }        

        [TestInitialize]
        public void Initialize()
        {            
            Routes = new List<BikeRoute>
            {
                new BikeRoute {Name = "Ruta po Baranji", Description = "Kratka ruta po Baranji, podloga je cesta, makadam i šumski put.", Author = "krunoslav", Distance = 75, Places = "Osijek, Bilje, Kopačevo, Kopački rit, Tikveš", DateCreated = DateTime.Now},
                new BikeRoute {Name = "Ruta do Valpova", Description = "Vožnja do valpova preko nasipa, podloga je makadam i cesta. Treba paziti na promet u Valpovu i blizini Osijeka.", Author = "krunoslav", Distance = 70, Places = "Osijek, Belišće, Valpovo, Ladimirevci, Satnica, Petrijevci.", DateCreated = DateTime.Now},
                new BikeRoute {Name = "Slavonska ruta", Description = "Dulja kružna vožnja po Slavoniji, jedan jači uspon kod Aljmaša, vozi se uglavnom po cesti tako da treba paziti na promet.", Author = "krunosalv", Distance = 125, Places = "Osijek, Bijelo Brdo, Aljmaš, Erdut, Dalj, Borovo, Vukovar, Trpinja, Klisa.", DateCreated = DateTime.Now}
            };            
        }

        [TestMethod]
        public void Test_ListAsync_Action()
        {
            // Arange
            Mock<IRoutesService> mock = new Mock<IRoutesService>();
            mock.Setup(m => m.GetAllRoutesAsync()).ReturnsAsync(Routes);

            RoutesController controller = new RoutesController(mock.Object);

            // Act
            var result = controller.ListAsync().Result as ViewResult;
            var data = (List<BikeRoute>)result.ViewData.Model;

            // Assert
            Assert.AreEqual(3, data.Count);
        }

        [TestMethod]
        public void Test_DetailsAsync_Action()
        {
            // Arange
            Mock<IRoutesService> mock = new Mock<IRoutesService>();
            mock.Setup(m => m.GetRouteAsync(1)).ReturnsAsync(Routes.ElementAt(1));
            string name = Routes.ElementAt(1).Name;

            RoutesController controller = new RoutesController(mock.Object);

            // Act
            var result = controller.DetailsAsync(1).Result as ViewResult;
            var data = (BikeRoute)result.ViewData.Model;            

            // Assert
            Assert.AreEqual(name, data.Name);
        }
    }
}
