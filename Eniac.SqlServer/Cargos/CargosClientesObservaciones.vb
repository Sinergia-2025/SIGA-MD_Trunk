Public Class CargosClientesObservaciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CargosClientesObservaciones_I(idSucursal As Integer,
                                            idCliente As Long,
                                            linea As Integer,
                                            observacion As String,
                                            idTipoLiquidacion As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO CargosClientesObservaciones ")
         .AppendFormatLine("   (IdSucursal")
         .AppendFormatLine("   ,IdCliente")
         .AppendFormatLine("   ,Linea")
         .AppendFormatLine("   ,Observacion")
         .AppendFormatLine("   ,IdTipoLiquidacion")
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("   {0} ", idSucursal)
         .AppendFormatLine(" , {0} ", idCliente)
         .AppendFormatLine(" , {0} ", linea)
         .AppendFormatLine(" ,'{0}'", observacion)
         .AppendFormatLine(" , {0} ", idTipoLiquidacion)
         .AppendFormatLine(" )")
      End With
      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CargosClientesObservaciones")
   End Sub
   Public Sub CargosClientesObservaciones_U(idSucursal As Integer,
                                            idCliente As Long,
                                            linea As Integer,
                                            observacion As String,
                                            idTipoLiquidacion As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CargosClientesObservaciones ")
         .AppendFormatLine("   SET Observacion = '{0}'", observacion)
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdCliente = {0}", idCliente)
         .AppendFormatLine("   AND Linea = {0}", linea)
         .AppendFormatLine("   AND IdTipoLiquidacion = {0}", linea)
      End With
      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CargosClientesObservaciones")
   End Sub

   Public Sub CargosClientesObservaciones_D(idSucursal As Integer, idTipoLiquidacion As Integer)
      CargosClientesObservaciones_D(IdSucursal, IdTipoLiquidacion, 0)
   End Sub

   Public Sub CargosClientesObservaciones_D(idSucursal As Integer, idTipoLiquidacion As Integer, idCliente As Long)
      CargosClientesObservaciones_D(idSucursal, idTipoLiquidacion, idCliente, idCategoria:=0, idZonaGeografica:=String.Empty, idCobrador:=0, filtroPcs:=String.Empty, cantidadPcs:=0)
   End Sub

   Public Sub CargosClientesObservaciones_D(idSucursal As Integer, idTipoLiquidacion As Integer, idCliente As Long,
                                            idCategoria As Integer, idZonaGeografica As String, idCobrador As Integer, filtroPcs As String, cantidadPcs As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("DELETE CargosClientesObservaciones ")
         .AppendFormatLine("  FROM CargosClientesObservaciones CC")
         .AppendFormatLine(" INNER JOIN Clientes C ON C.IdCliente = CC.IdCliente")
         .AppendFormatLine(" WHERE CC.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND CC.IdTipoLiquidacion = {0}", idTipoLiquidacion)
         If idCliente > 0 Then
            .AppendFormatLine("   AND CC.IdCliente = {0}", idCliente)
         End If

         'Filtros de pantalla de asignación de cargos
         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormatLine("   AND C.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If
         If idCategoria > 0 Then
            .AppendFormatLine("   AND C.IdCategoria = {0}", idCategoria)
         End If
         If idCobrador > 0 Then
            .AppendFormatLine("   AND C.IdCobrador = {0} ", idCobrador)
         End If
         If cantidadPcs > 0 Then
            .AppendFormatLine("   AND C.CantidadDePCs {0} {1}", filtroPcs, cantidadPcs)
         End If

      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CargosClientesObservaciones")
   End Sub

   Public Sub CargosClientesObservaciones_D(idSucursal As Integer,
                                            idCliente As Long,
                                            linea As Integer,
                                            idTipoLiquidacion As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM CargosClientesObservaciones ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdCliente = " & idCliente.ToString())
         .AppendLine("   AND Linea = " & linea.ToString())
         .AppendLine("   AND IdTipoLiquidacion = " & linea.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CargosClientesObservaciones")

   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT O.IdSucursal")
         .AppendLine("      ,O.IdCliente")
         .AppendLine("      ,O.Linea")
         .AppendLine("      ,O.Observacion")
         .AppendLine("      ,O.IdTipoLiquidacion")
         .Append("  FROM CargosClientesObservaciones O ")
      End With
   End Sub

   Private Sub SelectTextoConDatosCliente(stb As StringBuilder)
      With stb
         .AppendLine("SELECT O.IdSucursal")
         .AppendLine("      ,O.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,C.NombreDeFantasia")
         .AppendLine("      ,O.Linea")
         .AppendLine("      ,O.Observacion")
         .AppendLine("      ,O.IdTipoLiquidacion")
         .AppendLine("  FROM CargosClientesObservaciones O ")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = O.IDCliente ")
      End With
   End Sub

   Public Function CargosClientesObservacion_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append("  ORDER BY O.IdSucursal, O.IdCliente, O.Linea")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function CargosClientesObservacion_GA(ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat("   WHERE O.IdSucursal = {0}", IdSucursal)
         .AppendLine(" AND O.IdTipoLiquidacion = " & IdTipoLiquidacion)
         .Append("  ORDER BY O.Linea")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function CargosClientesObservacionConNombres_GA(ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTextoConDatosCliente(stb)
         .AppendFormat("   WHERE O.IdSucursal = {0}", IdSucursal)
         .AppendLine(" AND O.IdTipoLiquidacion = " & IdTipoLiquidacion)
         .Append("  ORDER BY C.NombreCliente, O.Linea")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function CargosClientesObservacion_G1(ByVal IdSucursal As Integer, _
                                             ByVal IdCliente As Long, _
                                             ByVal Linea As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE O.IdSucursal = {0} AND O.IdCliente = {1} AND O.Linea = {3}", IdSucursal, IdCliente, Linea)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function
End Class