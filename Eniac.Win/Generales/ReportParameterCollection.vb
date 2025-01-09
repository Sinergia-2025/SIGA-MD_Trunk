Public Class ReportParameterCollection
   Inherits List(Of Microsoft.Reporting.WinForms.ReportParameter)

   Public Sub New()
      MyBase.New()
   End Sub
   Public Sub New(filtros As String)
      Me.New()
      Add("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion)
      Add("NombreSucursal", actual.Sucursal.Nombre)
      Add("Filtros", filtros)
   End Sub

   Public Overloads Function Add(name As String, value As String) As Microsoft.Reporting.WinForms.ReportParameter
      Dim p = New Microsoft.Reporting.WinForms.ReportParameter(name, value)
      Add(p)
      Return p
   End Function
   Public Overloads Function Add(name As String, value As Date) As Microsoft.Reporting.WinForms.ReportParameter
      Return Add(name, value.ToString())
   End Function
   Public Overloads Function Add(name As String, value As Boolean) As Microsoft.Reporting.WinForms.ReportParameter
      Return Add(name, value.ToString())
   End Function
   Public Overloads Function Add(name As String, value As Long) As Microsoft.Reporting.WinForms.ReportParameter
      Return Add(name, value.ToString())
   End Function
   Public Overloads Function Add(name As String, value As Decimal) As Microsoft.Reporting.WinForms.ReportParameter
      Return Add(name, value.ToString())
   End Function
   Public Overloads Function Add(name As String, name2 As String, value As Image) As IEnumerable(Of Microsoft.Reporting.WinForms.ReportParameter)
      Return {Add(name, value.ConvertImageToBase64()), Add(name2, value.MimeType)}
   End Function
   Public Overloads Function Add(Of T)(name As String, value As IEnumerable(Of T), listSeparator As String) As Microsoft.Reporting.WinForms.ReportParameter
      Return Add(name, String.Join(listSeparator, value))
   End Function

End Class