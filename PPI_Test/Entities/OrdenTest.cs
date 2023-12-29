
using DB.Entities;
using DB.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPI_Test.Entities
{
    [TestClass]
    public class OrdenTest
    {


        [DataRow(10,190.8, 1921.852)]
        [DataRow(50,78.15, 3935.868)]
        [DataRow(100,260, 26188.76)]
        [TestMethod]
        public void MontoTotal_OrdenAccionDTO_DebeCalcularMismoValor(int _cantidad, double _precio, double _esperado)
        {
            //Arrange
            OrdenAccionDTO ordenSeteada = new OrdenAccionDTO();
            ordenSeteada.Cantidad = _cantidad;
            ordenSeteada.Precio = _precio; 

            //Act
            double result = Math.Round(ordenSeteada.MontoTotal,3);

            //Assert
            Assert.AreEqual( _esperado, result);
        }

        [DataRow(10, 190.8, 1912.617)]
        [DataRow(50, 78.15, 3916.956)]
        [DataRow(100, 260, 26062.92)]
        [TestMethod]
        public void MontoTotal_OrdenBonoDTO_DebeCalcularMismoValor(int _cantidad, double _precio, double _esperado)
        {
            //Arrange
            OrdenBonoDTO ordenSeteada = new OrdenBonoDTO();
            ordenSeteada.Cantidad = _cantidad;
            ordenSeteada.Precio = _precio;

            //Act
            double result = Math.Round(ordenSeteada.MontoTotal, 3);

            //Assert
            Assert.AreEqual(_esperado, result);
        }

        [DataRow(10, 190.8, 1908)]
        [DataRow(50, 78.15, 3907.5)]
        [DataRow(100, 260, 26000)]
        [TestMethod]
        public void MontoTotal_OrdenFCIDTO_DebeCalcularMismoValor(int _cantidad, double _precio, double _esperado)
        {
            //Arrange
            OrdenFCIDTO ordenSeteada = new OrdenFCIDTO();
            ordenSeteada.Cantidad = _cantidad;
            ordenSeteada.Precio = _precio;

            //Act
            double result = Math.Round(ordenSeteada.MontoTotal, 3);

            //Assert
            Assert.AreEqual(_esperado, result);
        }
    }
}
