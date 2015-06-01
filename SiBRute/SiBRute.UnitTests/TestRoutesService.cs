using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SiBRute.Model;
using SiBRute.Repository.Common;
using SiBRute.Service;
using System;
using System.Collections.Generic;

namespace SiBRute.UnitTests
{
    [TestClass]
    public class TestRoutesService
    {
        static List<BikeRoute> Routes { get; set; }

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
        public void Test_GetAllRoutesAsync()
        {
            // Arange  
            Mock<IRouteRepository> mock = new Mock<IRouteRepository>();

            mock.Setup(m => m.GetAllAsync(null)).ReturnsAsync(Routes);

            RoutesService service = new RoutesService(mock.Object);

            // Act
            List<BikeRoute> result = service.GetAllRoutesAsync().Result;

            // Assert
            Assert.AreEqual(result.Count, 3);            
            
        }      
       
    }
}
