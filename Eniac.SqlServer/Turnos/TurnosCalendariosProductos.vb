Public Class TurnosCalendariosProductos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub
   Public Sub TurnosCalendariosProductos_I(idTurno As Integer, idProducto As String, orden As Integer, numeroSesion As Integer, valorFluencia As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO TurnosCalendariosProductos")
         .AppendFormatLine("           ({0}", Entidades.TurnosCalendariosProductos.Columnas.IdTurno.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnosCalendariosProductos.Columnas.IdProducto.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnosCalendariosProductos.Columnas.Orden.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnosCalendariosProductos.Columnas.NumeroSesion.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnosCalendariosProductos.Columnas.ValorFluencia.ToString())
         .AppendFormatLine("           )")
         .AppendFormatLine("    VALUES ( {0} ", idTurno)
         .AppendFormatLine("           ,'{0}' ", idProducto)
         .AppendFormatLine("           , {0} ", orden)
         .AppendFormatLine("           , {0} ", numeroSesion)
         .AppendFormatLine("           , {0} ", valorFluencia)
         .AppendFormatLine("           )")
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub TurnosCalendariosProductos_U(idTurno As Integer, idProducto As String, orden As Integer, numeroSesion As Integer, valorFluencia As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE TurnosCalendariosProductos ")
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.TurnosCalendariosProductos.Columnas.NumeroSesion.ToString(), numeroSesion)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.TurnosCalendariosProductos.Columnas.ValorFluencia.ToString(), valorFluencia)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.TurnosCalendariosProductos.Columnas.IdTurno.ToString(), idTurno)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.TurnosCalendariosProductos.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.TurnosCalendariosProductos.Columnas.Orden.ToString(), orden)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TurnosCalendariosProductos_D(idTurno As Integer, idProducto As String, orden As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM TurnosCalendariosProductos")
         .AppendFormatLine(" WHERE IdTurno = {0}", idTurno)
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND IdProducto = '{0}'", idProducto)
         End If
         If orden > 0 Then
            .AppendFormatLine("   AND Orden = {0}", orden)
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Protected Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT TP.*, P.NombreProducto")
         .AppendFormatLine("  FROM TurnosCalendariosProductos AS TP")
         .AppendFormatLine("  LEFT JOIN TurnosCalendarios T ON T.IdTurno = TP.Idturno")
         .AppendFormatLine("  LEFT JOIN Productos P ON P.IdProducto = TP.IdProducto")
      End With
   End Sub
   Public Function TurnosCalendariosCliente_G_GetAll(idCliente As Long, idProducto As String, FechaDesde As Date) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT TOP 1 TP.NumeroSesion")
         .AppendFormatLine("  FROM TurnosCalendariosProductos AS TP")
         .AppendFormatLine("  LEFT JOIN TurnosCalendarios T ON T.IdTurno = TP.Idturno")
         .AppendFormatLine("  LEFT JOIN Productos P ON P.IdProducto = TP.IdProducto")
         
         .AppendFormatLine(" WHERE T.IdCliente = {0}", idCliente)
         .AppendFormatLine("   AND T.IdTipoTurno <> 'C'")
         .AppendFormatLine("   AND TP.IdProducto= '{0}'", idProducto)
         .AppendFormatLine("   AND T.FechaDesde< '{0}'", ObtenerFecha(FechaDesde, True))

         .AppendFormatLine(" ORDER BY T.FechaDesde DESC")

      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Function TurnosCalendariosProductos_G_GetAll(idTurno As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If IsNumeric(IdTurno) Then
            .AppendFormat("   AND TP.IdTurno = {0}", IdTurno).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "TP." + columna
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
End Class