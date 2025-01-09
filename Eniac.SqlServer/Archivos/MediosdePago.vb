Public Class MediosdePago
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub MediosDePago_I(idMedioDePago As Integer, nombreMedioDePago As String, idCuenta As Long)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO MediosDePago (")
         .AppendFormatLine("     IdMedioDePago")
         .AppendFormatLine("   , NombreMedioDePago")
         .AppendFormatLine("   , IdCuenta")
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("      {0} ", idMedioDePago)
         .AppendFormatLine("   , '{0}'", nombreMedioDePago)
         .AppendFormatLine("      {0} ", GetStringFromNumber(idCuenta))
         .AppendFormatLine(" )")
      End With
      Execute(stb)
   End Sub
   Public Sub MediosDePago_U(idMedioDePago As Integer, nombreMedioDePago As String, idCuenta As Long)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE MediosDePago")
         .AppendFormatLine("   SET NombreMedioDePago = '{0}'", nombreMedioDePago)
         .AppendFormatLine("     , IdCuenta = {0}", GetStringFromNumber(idCuenta))
         .AppendFormatLine(" WHERE IdMedioDePago = {0}", idMedioDePago)
      End With
      Execute(stb)
   End Sub
   Public Sub MediosDePago_D(id As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM MediosDePago")
         .AppendFormatLine(" WHERE IdMedioDePago = {0}", id)
      End With
      Execute(stb)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT IdMedioDePago")
         .AppendLine("     , NombreMedioDePago")
         .AppendLine("     , ISNULL(IdCuenta,0) as IdCuenta")
         .AppendLine("     , ISNULL((SELECT NombreCuenta FROM ContabilidadCuentas WHERE ISNULL(MediosDePago.IdCuenta,0) = IdCuenta),'') AS NombreCuenta")
         .AppendLine("  FROM MediosDePago")
      End With
   End Sub

   Public Function MediosDePago_GA() As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         stb.AppendLine(" ORDER BY idMedioDePago")
      End With
      Return GetDataTable(stb)
   End Function
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb1) SelectTexto(stb1), String.Empty)
   End Function
   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo("IdMedioDePago", "MediosDePago").ToInteger()
   End Function
End Class
