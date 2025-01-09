Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class TestCodigoBarraDocumento
   Private Const codigoBarrasDNI8 = "00244705703""CARROZZO""SEBASTIAN PABLO""M""25900005""A""12-06-1977""07-02-2014"
   Private Const codigoBarrasDNI9 = "00478051781""ROLLA""GERARDO AUGUSTO""M""24478592""B""26-05-1975""08-02-2017""202"
   Private Const codigoBarrasDNIViejo = """37815294    ""A""1""ERENU""BARBARA ANAHI""ARGENTINA""12-01-1994""F""16-12-2010""00030465560""354  ""16-12-2025""226""0""ILRÑ01.2 CÑ100817.01""UNIDAD #13 ]] S-NÑ 0040:2008::0010"
   Private Const codigoBarrasDNIViejo2 = """21690212    ""A""1""FERNANDEZ""CARLOS MARCELO""ARGENTINA""17-07-1970""M""08-07-2011""00058668798""8036 ""08-07-2026""374""0""ILRÑ2.01 CÑ110613.02 )No Cap.=""UNIDAD #06 ]] S-NÑ 0040:2008::0008"
   Private Const codigoBarrasDNI8ConLetra = "00140035977""SCHINDER""HUMBERTO RUBEN""M""M5834317""A""20-10-1945""02-10-2012"
   Private Const codigoBarrasDNI9ConLetra = "00140035977""SCHINDER""HUMBERTO RUBEN""M""M5834317""A""20-10-1945""02-10-2012""202"

   <TestMethod()> Public Sub PruebaLecturaDNI8()
      Dim codigoString As String = codigoBarrasDNI8

      Dim codigoBarraDocumento As Entidades.CodigoBarraDocumento = Entidades.CodigoBarraDocumento.Parse(codigoString)

      Assert.AreEqual(244705703L, codigoBarraDocumento.NumeroTramite)
      Assert.AreEqual("CARROZZO", codigoBarraDocumento.Apellidos)
      Assert.AreEqual("SEBASTIAN PABLO", codigoBarraDocumento.Nombres)
      Assert.AreEqual("M", codigoBarraDocumento.Sexo)
      Assert.AreEqual(25900005L, codigoBarraDocumento.NumeroDocumento)
      Assert.AreEqual("A", codigoBarraDocumento.Ejemplar)
      Assert.AreEqual(New DateTime(1977, 6, 12), codigoBarraDocumento.FechaNacimiento)
      Assert.AreEqual(New DateTime(2014, 2, 7), codigoBarraDocumento.FechaEmision)
      Assert.AreEqual("", codigoBarraDocumento.PrefSufCuil)
   End Sub

   <TestMethod()> Public Sub PruebaLecturaDNI8ConLetra()
      Dim codigoString As String = codigoBarrasDNI8ConLetra

      Dim codigoBarraDocumento As Entidades.CodigoBarraDocumento = Entidades.CodigoBarraDocumento.Parse(codigoString)

      Assert.AreEqual(140035977L, codigoBarraDocumento.NumeroTramite)
      Assert.AreEqual("SCHINDER", codigoBarraDocumento.Apellidos)
      Assert.AreEqual("HUMBERTO RUBEN", codigoBarraDocumento.Nombres)
      Assert.AreEqual("M", codigoBarraDocumento.Sexo)
      Assert.AreEqual(5834317L, codigoBarraDocumento.NumeroDocumento)
      Assert.AreEqual("A", codigoBarraDocumento.Ejemplar)
      Assert.AreEqual(New DateTime(1945, 10, 20), codigoBarraDocumento.FechaNacimiento)
      Assert.AreEqual(New DateTime(2012, 10, 2), codigoBarraDocumento.FechaEmision)
      Assert.AreEqual("", codigoBarraDocumento.PrefSufCuil)
   End Sub

   <TestMethod()> Public Sub PruebaLecturaDNI9()
      Dim codigoString As String = codigoBarrasDNI9

      Dim codigoBarraDocumento As Entidades.CodigoBarraDocumento = Entidades.CodigoBarraDocumento.Parse(codigoString)

      Assert.AreEqual(478051781L, codigoBarraDocumento.NumeroTramite)
      Assert.AreEqual("ROLLA", codigoBarraDocumento.Apellidos)
      Assert.AreEqual("GERARDO AUGUSTO", codigoBarraDocumento.Nombres)
      Assert.AreEqual("M", codigoBarraDocumento.Sexo)
      Assert.AreEqual(24478592L, codigoBarraDocumento.NumeroDocumento)
      Assert.AreEqual("B", codigoBarraDocumento.Ejemplar)
      Assert.AreEqual(New DateTime(1975, 5, 26), codigoBarraDocumento.FechaNacimiento)
      Assert.AreEqual(New DateTime(2017, 2, 8), codigoBarraDocumento.FechaEmision)
      Assert.AreEqual("202", codigoBarraDocumento.PrefSufCuil)
   End Sub

   <TestMethod()> Public Sub PruebaLecturaDNI9ConLetra()
      Dim codigoString As String = codigoBarrasDNI9ConLetra

      Dim codigoBarraDocumento As Entidades.CodigoBarraDocumento = Entidades.CodigoBarraDocumento.Parse(codigoString)

      Assert.AreEqual(140035977L, codigoBarraDocumento.NumeroTramite)
      Assert.AreEqual("SCHINDER", codigoBarraDocumento.Apellidos)
      Assert.AreEqual("HUMBERTO RUBEN", codigoBarraDocumento.Nombres)
      Assert.AreEqual("M", codigoBarraDocumento.Sexo)
      Assert.AreEqual(5834317L, codigoBarraDocumento.NumeroDocumento)
      Assert.AreEqual("A", codigoBarraDocumento.Ejemplar)
      Assert.AreEqual(New DateTime(1945, 10, 20), codigoBarraDocumento.FechaNacimiento)
      Assert.AreEqual(New DateTime(2012, 10, 2), codigoBarraDocumento.FechaEmision)
      Assert.AreEqual("202", codigoBarraDocumento.PrefSufCuil)
   End Sub

   <TestMethod()> Public Sub PruebaLecturaDNIViejo()
      Dim codigoString As String = codigoBarrasDNIViejo

      Dim codigoBarraDocumento As Entidades.CodigoBarraDocumento = Entidades.CodigoBarraDocumento.Parse(codigoString)

      Assert.AreEqual(30465560L, codigoBarraDocumento.NumeroTramite)
      Assert.AreEqual("ERENU", codigoBarraDocumento.Apellidos)
      Assert.AreEqual("BARBARA ANAHI", codigoBarraDocumento.Nombres)
      Assert.AreEqual("F", codigoBarraDocumento.Sexo)
      Assert.AreEqual(37815294L, codigoBarraDocumento.NumeroDocumento)
      Assert.AreEqual("A", codigoBarraDocumento.Ejemplar)
      Assert.AreEqual(New DateTime(1994, 1, 12), codigoBarraDocumento.FechaNacimiento)
      Assert.AreEqual(New DateTime(2010, 12, 16), codigoBarraDocumento.FechaEmision)
      Assert.AreEqual("", codigoBarraDocumento.PrefSufCuil)
   End Sub

   <TestMethod()> Public Sub PruebaLecturaDNIViejo2()
      Dim codigoString As String = codigoBarrasDNIViejo2

      Dim codigoBarraDocumento As Entidades.CodigoBarraDocumento = Entidades.CodigoBarraDocumento.Parse(codigoString)

      Assert.AreEqual(58668798L, codigoBarraDocumento.NumeroTramite)
      Assert.AreEqual("FERNANDEZ", codigoBarraDocumento.Apellidos)
      Assert.AreEqual("CARLOS MARCELO", codigoBarraDocumento.Nombres)
      Assert.AreEqual("M", codigoBarraDocumento.Sexo)
      Assert.AreEqual(21690212L, codigoBarraDocumento.NumeroDocumento)
      Assert.AreEqual("A", codigoBarraDocumento.Ejemplar)
      Assert.AreEqual(New DateTime(1970, 7, 17), codigoBarraDocumento.FechaNacimiento)
      Assert.AreEqual(New DateTime(2011, 7, 8), codigoBarraDocumento.FechaEmision)
      Assert.AreEqual("", codigoBarraDocumento.PrefSufCuil)
   End Sub

   <TestMethod()> Public Sub PruebaLecturaDNI8ToString()
      Dim codigoString As String = codigoBarrasDNI8

      Dim codigoBarraDocumento As Entidades.CodigoBarraDocumento = Entidades.CodigoBarraDocumento.Parse(codigoString)

      Assert.AreEqual(codigoString, codigoBarraDocumento.ToString())
      Assert.AreEqual(codigoString, codigoBarraDocumento.ToString(True))
   End Sub

   <TestMethod()> Public Sub PruebaLecturaDNI9ToString()
      Dim codigoString As String = codigoBarrasDNI9

      Dim codigoBarraDocumento As Entidades.CodigoBarraDocumento = Entidades.CodigoBarraDocumento.Parse(codigoString)

      Assert.AreEqual(codigoString, codigoBarraDocumento.ToString())
      Assert.AreEqual(codigoString, codigoBarraDocumento.ToString(True))
   End Sub

   <TestMethod()> Public Sub PruebaLecturaDNIViejoToString()
      Dim codigoString As String = codigoBarrasDNIViejo

      Dim codigoBarraDocumento As Entidades.CodigoBarraDocumento = Entidades.CodigoBarraDocumento.Parse(codigoString)

      Assert.AreNotEqual(codigoString, codigoBarraDocumento.ToString())
      Assert.AreEqual(codigoString, codigoBarraDocumento.ToString(True))
   End Sub

End Class