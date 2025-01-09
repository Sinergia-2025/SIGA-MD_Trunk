Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Eniac.Entidades.Extensiones
<TestClass()> Public Class ListOfExtensionsTests
   <TestMethod()> Public Sub CountSecure_Null_Count0()
      Dim a As List(Of String) = Nothing

      Dim c = a.CountSecure()

      Assert.AreEqual(0I, c)
   End Sub
   <TestMethod()> Public Sub CountSecure_NotNullEmpty_Count0()
      Dim a = New List(Of String)()

      Dim c = a.CountSecure()

      Assert.AreEqual(0I, c)
   End Sub
   <TestMethod()> Public Sub CountSecure_NotNullWith3Strings_Count3()
      Dim a = {"", "", ""}.ToList()

      Dim c = a.CountSecure()

      Assert.AreEqual(3I, c)
   End Sub

End Class