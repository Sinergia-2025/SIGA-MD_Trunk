Public Class Produccion
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Produccion_I(idSucursal As Integer, idProduccion As Integer, fecha As Date, usuario As String, idResponsable As Integer, idEstado As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO Produccion")
         .AppendFormatLine("   (IdSucursal")
         .AppendFormatLine("  , IdProduccion")
         .AppendFormatLine("  , Fecha")
         .AppendFormatLine("  , Usuario ")
         .AppendFormatLine("  , IdResponsable")
         .AppendFormatLine("  , IdEstado")
         .AppendFormatLine("  ) VALUES ( ")
         .AppendFormatLine("     {0} ", idSucursal)
         .AppendFormatLine("  ,  {0} ", idProduccion)
         .AppendFormatLine("  , '{0}'", ObtenerFecha(fecha, True))
         .AppendFormatLine("  , '{0}'", usuario)
         .AppendFormatLine("  ,  {0} ", idResponsable)
         .AppendFormatLine("  , '{0}'", idEstado.ToUpper())
         .AppendFormatLine("  ) ")
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Produccion")
   End Sub
   Public Sub Produccion_U(idSucursal As Integer, idproduccion As Integer, idEstado As String, idResponsable As Integer, usuario As String)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("UPDATE Produccion")
         .AppendFormatLine("   SET IdEstado = '{0}'", idEstado)
         .AppendFormatLine("     , IdResponsable = {0}", idResponsable)
         .AppendFormatLine("     , Usuario = '{0}'", usuario)
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdProduccion = {0}", idproduccion)
      End With
      Execute(stbQuery)
   End Sub

   Public Function GetPorRangoFechas(idSucursal As Integer, desde As Date, hasta As Date) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT 'FALSE' as Anula")
         .AppendFormatLine("     , P.*")
         .AppendFormatLine("     , E.NombreEmpleado ")
         .AppendFormatLine("  FROM Produccion P ")
         .AppendFormatLine("  LEFT JOIN Empleados E ON E.IdEmpleado = P.IdResponsable ")
         .AppendFormatLine("  WHERE P.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("	  AND P.Fecha >= '{0}'", ObtenerFecha(desde, True))
         .AppendFormatLine("	  AND P.Fecha <= '{0}'", ObtenerFecha(hasta, True))
         .AppendFormatLine("    AND P.IdEStado <> 'ANULADA'")

         .AppendFormatLine(" ORDER BY P.Fecha")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function Produccion_G1(idSucursal As Integer, idproduccion As Integer) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT P.*")
         .AppendFormatLine("  FROM Produccion P")
         .AppendFormatLine(" WHERE P.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND P.IdProduccion = {0}", idproduccion)
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetNumeroMaximo() As Integer
      Return GetCodigoMaximo("IdProduccion", "Produccion").ToInteger()
   End Function

End Class