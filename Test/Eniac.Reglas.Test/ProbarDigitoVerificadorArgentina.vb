Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class ProbarDigitoVerificadorArgentina
   <TestMethod()> Public Sub ProbarCuitsExitosos()
      Entidades.Usuario.Actual.CurrentUICulture = "es-AR"
      Reglas.Validaciones.Impositivo.ValidarDigitoVerificador.ResetInstancia()

      Dim rucResult As Dictionary(Of String, Validaciones.ValidacionResult) = New Dictionary(Of String, Validaciones.ValidacionResult)()
      Dim rucs As String() = {
                              "24259000056",
                              ""
                             }

      For Each ruc As String In rucs
         If Not String.IsNullOrWhiteSpace(ruc) Then
            rucResult.Add(ruc, Reglas.Validaciones.Impositivo.ValidarDigitoVerificador.Instancia.Validar(ruc))
         End If
      Next

      Dim algunError As Boolean = False
      For Each result As KeyValuePair(Of String, Validaciones.ValidacionResult) In rucResult
         Console.WriteLine(String.Format("{0} : {1} - {2}", result.Key, result.Value.Error, result.Value.MensajeError))
         algunError = algunError Or result.Value.Error
      Next
      Assert.AreEqual(False, algunError)
   End Sub

   <TestMethod()> Public Sub ProbarCuitsConError()
      Entidades.Usuario.Actual.CurrentUICulture = "es-AR"
      Reglas.Validaciones.Impositivo.ValidarDigitoVerificador.ResetInstancia()

      Dim rucResult As Dictionary(Of String, Validaciones.ValidacionResult) = New Dictionary(Of String, Validaciones.ValidacionResult)()
      Dim rucs As String() = {
                              "24259000050",
                              "24259000051",
                              "24259000052",
                              "24259000053",
                              "24259000054",
                              "24259000055",
                              "24259000057",
                              "24259000058",
                              "24259000059",
                              ""
                             }

      For Each ruc As String In rucs
         If Not String.IsNullOrWhiteSpace(ruc) Then
            rucResult.Add(ruc, Reglas.Validaciones.Impositivo.ValidarDigitoVerificador.Instancia.Validar(ruc))
         End If
      Next

      Dim algunExitoso As Boolean = False
      For Each result As KeyValuePair(Of String, Validaciones.ValidacionResult) In rucResult
         Console.WriteLine(String.Format("{0} : {1} - {2}", result.Key, result.Value.Error, result.Value.MensajeError))
         algunExitoso = algunExitoso Or Not result.Value.Error
      Next
      Assert.AreEqual(False, algunExitoso)
   End Sub

End Class