Public Class LiquidacionesObservaciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub LiquidacionesObservaciones_I(ByVal en As Entidades.LiquidacionObservacion)
      LiquidacionesObservaciones_I(en.IdSucursal, en.PeriodoLiquidacion, en.IdCliente, en.Linea, en.Observacion, en.IdTipoLiquidacion)
   End Sub
   Public Sub LiquidacionesObservaciones_I(ByVal IdSucursal As Integer, _
                                             ByVal PeriodoLiquidacion As Integer, _
                                             ByVal IdCliente As Long, _
                                             ByVal Linea As Integer, _
                                             ByVal Observacion As String, _
                                             ByVal IdTipoLiquidacion As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO LiquidacionesObservaciones ")
         .AppendLine("   (IdSucursal")
         .AppendLine("   ,PeriodoLiquidacion")
         '.AppendLine("   ,IdLiquidacionCargo")
         .AppendLine("   ,IdCliente")
         .AppendLine("   ,Linea")
         .AppendLine("   ,Observacion")
         .AppendLine("   ,IdTipoLiquidacion")
         .AppendLine(") VALUES (")
         .Append(IdSucursal.ToString())
         .Append(" ," & PeriodoLiquidacion.ToString())
         .Append(" ," & IdCliente.ToString())
         .Append(" ," & Linea.ToString())
         .Append(" ,'" & Observacion & "'")
         .Append(" ," & IdTipoLiquidacion.ToString())
         .Append(" )")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "LiquidacionesObservaciones")

   End Sub
   Public Sub LiquidacionesObservaciones_U(ByVal en As Entidades.LiquidacionObservacion)
      LiquidacionesObservaciones_U(en.IdSucursal, en.PeriodoLiquidacion, en.IdCliente, en.Linea, en.Observacion, en.IdTipoLiquidacion)
   End Sub
   Public Sub LiquidacionesObservaciones_U(ByVal IdSucursal As Integer, _
                                             ByVal PeriodoLiquidacion As Integer, _
                                             ByVal IdCliente As Long, _
                                             ByVal Linea As Integer, _
                                             ByVal Observacion As String, _
                                             ByVal IdTipoLiquidacion As Integer)


      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE LiquidacionesObservaciones SET ")
         .AppendLine("  Observacion = '" & Observacion & "'")
         .AppendLine("  WHERE IdSucursal = " & IdSucursal.ToString())
         .AppendLine("  AND PeriodoLiquidacion = " & PeriodoLiquidacion.ToString())
         '.AppendLine("  AND IdLiquidacionCargo = " & IdLiquidacionCargo.ToString())
         .AppendLine("  AND IdCliente = " & IdCliente.ToString())
         .AppendLine("  AND Linea = " & Linea.ToString())
         .AppendLine("  AND IdTipoLiquidacion = " & IdTipoLiquidacion.ToString())

      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "LiquidacionesObservaciones")

   End Sub
   Public Sub LiquidacionesObservaciones_D(ByVal en As Entidades.LiquidacionObservacion)
      LiquidacionesObservaciones_D(en.IdSucursal, en.PeriodoLiquidacion, en.IdCliente, en.Linea, en.IdTipoLiquidacion)
   End Sub

   Public Sub LiquidacionesObservaciones_D(ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM LiquidacionesObservaciones ")
         .AppendLine(" WHERE IdSucursal = " & IdSucursal.ToString())
         .AppendLine("  AND IdTipoLiquidacion = " & IdTipoLiquidacion.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "LiquidacionesObservaciones")
   End Sub

   Public Sub LiquidacionesObservaciones_D(ByVal Periodo As Integer, ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM LiquidacionesObservaciones ")
         .AppendLine(" WHERE IdSucursal = " & IdSucursal.ToString())
         .AppendLine(" AND PeriodoLiquidacion = " & Periodo.ToString())
         .AppendLine("  AND IdTipoLiquidacion = " & IdTipoLiquidacion.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "LiquidacionesObservaciones")
   End Sub

   Public Sub LiquidacionesObservaciones_D(ByVal IdSucursal As Integer, _
                                             ByVal PeriodoLiquidacion As Integer, _
                                             ByVal IdCliente As Long, _
                                             ByVal Linea As Integer, _
                                             ByVal IdTipoLiquidacion As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM LiquidacionesObservaciones ")
         .AppendLine(" WHERE IdSucursal = " & IdSucursal.ToString())
         .AppendLine("   AND PeriodoLiquidacion = " & PeriodoLiquidacion.ToString())
         .AppendLine("   AND IdCliente = " & IdCliente.ToString())
         .AppendLine("   AND Linea = " & Linea.ToString())
         .AppendLine("   AND IdTipoLiquidacion = " & IdTipoLiquidacion.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "LiquidacionesObservaciones")

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Append("SELECT LO.IdSucursal")
         .Append("      ,LO.PeriodoLiquidacion")
         '.Append("      ,LO.IdLiquidacionCargo")
         .Append("      ,LO.IdCliente")
         .Append("      ,LO.Linea")
         .Append("      ,LO.Observacion")
         .AppendLine("  ,LO.IdTipoLiquidacion")
         .Append("  FROM LiquidacionesObservaciones LO ")
      End With
   End Sub

   Private Sub SelectTextoConDatosCliente(ByVal stb As StringBuilder)
      With stb
         .Append("SELECT LO.IdSucursal")
         '.Append("      ,LO.IdLiquidacionCargo")
         .Append("      ,LO.PeriodoLiquidacion")
         .Append("      ,LO.IdCliente")
         .Append("      ,C.CodigoCliente")
         .Append("      ,C.NombreCliente")
         .Append("      ,C.NombreDeFantasia")
         .Append("      ,LO.Linea")
         .Append("      ,LO.Observacion")
         .AppendLine("  ,LO.IdTipoLiquidacion")
         .Append("  FROM LiquidacionesObservaciones LO ")
         '.AppendLine(" INNER JOIN LiquidacionesCargos L ON L.IdLiquidacionCargo = LO.IdLiquidacionCargo ")
         .AppendLine(" LEFT JOIN Clientes C ON C.IdCliente = LO.IDCliente ")

      End With
   End Sub

   Public Function LiquidacionesObservaciones_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append("  ORDER BY LO.IdSucursal, LO.IdCliente, LO.Linea")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function LiquidacionesObservaciones_GA(ByVal IdSucursal As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat("   WHERE LO.IdSucursal = {0}", IdSucursal)
         .Append("  ORDER BY LO.Linea")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function LiquidacionesObservaciones_GA(ByVal IdSucursal As Integer, ByVal Periodo As Integer, ByVal IdTipoLiquidacion As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat("   WHERE LO.IdSucursal = {0} AND LO.PeriodoLiquidacion = {1} AND LO.IdTipoLiquidacion = {2}", IdSucursal, Periodo, IdTipoLiquidacion)
         .Append("  ORDER BY LO.Linea")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function LiquidacionesObservacionesConNombres_GA(ByVal IdSucursal As Integer, ByVal periodo As Integer, ByVal IdTipoLiquidacion As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTextoConDatosCliente(stb)
         .AppendFormat("   WHERE LO.IdSucursal = {0} AND LO.PeriodoLiquidacion = {1} AND LO.IdTipoLiquidacion = {2}", IdSucursal, periodo, IdTipoLiquidacion)
         .Append("  ORDER BY C.NombreCliente, LO.Linea")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function LiquidacionesObservaciones_G1(ByVal IdSucursal As Integer, _
                                             ByVal PeriodoLiquidacion As Integer, _
                                             ByVal IdCliente As Long, _
                                             ByVal Linea As Integer, _
                                             ByVal IdTipoLiquidacion As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE LO.IdSucursal = {0} AND LO.IdCliente = {1} AND LO.PeriodoLiquidacion = {3} AND LO.Linea = {4} AND LO.IdTipoLiquidacion = {5}", _
                       IdSucursal, IdCliente, PeriodoLiquidacion, Linea, IdTipoLiquidacion)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

End Class