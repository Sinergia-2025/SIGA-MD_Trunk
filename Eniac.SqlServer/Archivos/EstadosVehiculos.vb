Public Class EstadosVehiculos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EstadosVehiculos_I(idEstadoVehiculo As Integer, nombreEstadoVehiculo As String,
                                 enStock As Boolean, solicitaFecha As Boolean, idEstadoVehiculoLuegoVencer As Integer?, predeterminado As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.EstadoVehiculo.NombreTabla)
         .AppendFormatLine("     {0} ", Entidades.EstadoVehiculo.Columnas.IdEstadoVehiculo.ToString())
         .AppendFormatLine("  ,  {0} ", Entidades.EstadoVehiculo.Columnas.NombreEstadoVehiculo.ToString())
         .AppendFormatLine("  ,  {0} ", Entidades.EstadoVehiculo.Columnas.EnStock.ToString())
         .AppendFormatLine("  ,  {0} ", Entidades.EstadoVehiculo.Columnas.SolicitaFecha.ToString())
         .AppendFormatLine("  ,  {0} ", Entidades.EstadoVehiculo.Columnas.IdEstadoVehiculoLuegoVencer.ToString())
         .AppendFormatLine("  ,  {0} ", Entidades.EstadoVehiculo.Columnas.Predeterminado.ToString())
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("     {0} ", idEstadoVehiculo)
         .AppendFormatLine("  , '{0}'", nombreEstadoVehiculo)
         .AppendFormatLine("  ,  {0} ", GetStringFromBoolean(enStock))
         .AppendFormatLine("  ,  {0} ", GetStringFromBoolean(solicitaFecha))
         .AppendFormatLine("  ,  {0} ", GetStringFromNumber(idEstadoVehiculoLuegoVencer))
         .AppendFormatLine("  ,  {0} ", GetStringFromBoolean(predeterminado))
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub EstadosVehiculos_U(idEstadoVehiculo As Integer, nombreEstadoVehiculo As String,
                                 enStock As Boolean, solicitaFecha As Boolean, idEstadoVehiculoLuegoVencer As Integer?, predeterminado As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.EstadoVehiculo.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.EstadoVehiculo.Columnas.NombreEstadoVehiculo.ToString(), nombreEstadoVehiculo)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.EstadoVehiculo.Columnas.EnStock.ToString(), GetStringFromBoolean(enStock))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.EstadoVehiculo.Columnas.SolicitaFecha.ToString(), GetStringFromBoolean(solicitaFecha))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.EstadoVehiculo.Columnas.IdEstadoVehiculoLuegoVencer.ToString(), GetStringFromNumber(idEstadoVehiculoLuegoVencer))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.EstadoVehiculo.Columnas.Predeterminado.ToString(), GetStringFromBoolean(predeterminado))
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.EstadoVehiculo.Columnas.IdEstadoVehiculo.ToString(), idEstadoVehiculo)
      End With
      Execute(myQuery)
   End Sub

   Public Sub EstadosVehiculos_D(idEstadoVehiculo As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.EstadoVehiculo.NombreTabla, Entidades.EstadoVehiculo.Columnas.IdEstadoVehiculo.ToString(), idEstadoVehiculo)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT EV.*")
         .AppendFormatLine("     , EVV.{0} AS NombreEstadoVehiculoLuevoVencer", Entidades.EstadoVehiculo.Columnas.NombreEstadoVehiculo.ToString())
         .AppendFormatLine("  FROM {0} AS EV", Entidades.EstadoVehiculo.NombreTabla)
         .AppendFormatLine("  LEFT JOIN {0} AS EVV ON EVV.{1} = EV.{2}", Entidades.EstadoVehiculo.NombreTabla, Entidades.EstadoVehiculo.Columnas.IdEstadoVehiculo.ToString(), Entidades.EstadoVehiculo.Columnas.IdEstadoVehiculoLuegoVencer.ToString())
      End With
   End Sub

   Public Function EstadosVehiculos_GA() As DataTable
      Return EstadosVehiculos_G(idEstadoVehiculo:=0, idEstadoVehiculoCeroTodos:=True, nombreEstadoVehiculo:=String.Empty, nombreExacto:=False)
   End Function
   Private Function EstadosVehiculos_G(idEstadoVehiculo As Integer, idEstadoVehiculoCeroTodos As Boolean, nombreEstadoVehiculo As String, nombreExacto As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idEstadoVehiculo > 0 Or Not idEstadoVehiculoCeroTodos Then
            .AppendFormatLine("   AND EV.IdEstadoVehiculo = {0}", idEstadoVehiculo)
         End If
         If Not String.IsNullOrWhiteSpace(nombreEstadoVehiculo) Then
            If nombreExacto Then
               .AppendFormatLine("   AND EV.NombreEstadoVehiculo = '{0}'", nombreEstadoVehiculo)
            Else
               .AppendFormatLine("   AND EV.NombreEstadoVehiculo LIKE '%{0}%'", nombreEstadoVehiculo)
            End If
         End If
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function EstadosVehiculos_G1(idEstadoVehiculo As Integer) As DataTable
      Return EstadosVehiculos_G(idEstadoVehiculo:=idEstadoVehiculo, idEstadoVehiculoCeroTodos:=False, nombreEstadoVehiculo:=String.Empty, nombreExacto:=False)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "EV.",
                    New Dictionary(Of String, String) From {{"NombreEstadoVehiculoLuevoVencer", "EVV.NombreEstadoVehiculo"}})
   End Function
   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo(Entidades.EstadoVehiculo.Columnas.IdEstadoVehiculo.ToString(), Entidades.EstadoVehiculo.NombreTabla).ToInteger()
   End Function

End Class