Public Class FichasPagosDetalle
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub FichasPagosDetalle_I(ByVal idSucursal As Integer, _
                                   ByVal IdCliente As Long, _
                                   ByVal nroOperacion As Integer, _
                                   ByVal nroCuota As Integer, _
                                   ByVal fechaPago As Date, _
                                   ByVal importe As Double, _
                                   ByVal IdCobrador As Integer, _
                                   ByVal IdCaja As Integer, _
                                   ByVal NumeroPlanilla As Integer, _
                                   ByVal NumeroMovimiento As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO FichasPagosDetalle ")
         .AppendLine("           (IdSucursal")
         .AppendLine("           ,IdCliente  ")
         .AppendLine("           ,NroOperacion")
         .AppendLine("           ,NroCuota  ")
         .AppendLine("           ,FechaPago ")
         .AppendLine("           ,Importe ")
         .AppendLine("           ,IdCobrador ")
         .AppendLine("           ,IdCaja")
         .AppendLine("           ,NumeroPlanilla")
         .AppendLine("           ,NumeroMovimiento)")
         .AppendLine("     VALUES(")
         .AppendLine(idSucursal.ToString())
         .AppendLine(", " & IdCliente.ToString())
         .AppendLine(", " & nroOperacion.ToString())
         .AppendLine(", " & nroCuota)
         .AppendLine(", '" & Me.ObtenerFecha(fechaPago, True) & "'")
         .AppendLine(", " & importe.ToString())
         .AppendLine(", " & IdCobrador & "")
         .AppendLine(", " & IdCaja.ToString())
         .AppendLine(", " & NumeroPlanilla.ToString())
         .AppendLine(", " & NumeroMovimiento.ToString())
         .AppendLine(") ")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "FichasPagosDetalle")

   End Sub

   Public Sub FichasPagosDetalle_USaldo(ByVal idSucursal As Integer, _
                                    ByVal nroOperacion As Integer, _
                                   ByVal IdCliente As Long, _
                                   ByVal nroCuota As Integer, _
                                   ByVal saldo As Double)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("UPDATE FichasPagos SET ")
         .AppendLine(" Saldo = " & saldo.ToString() & " ")
         .AppendLine(" WHERE nroOperacion = " & nroOperacion)
         .AppendLine("   AND IdSucursal = " & idSucursal & " ")
         .AppendLine("   AND IdCliente = " & IdCliente.ToString())
         .AppendLine("   AND NroCuota = " & nroCuota)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "FichasPagosDetalle")

   End Sub

   Public Sub FichasPagosDetalle_D(ByVal idSucursal As Integer, _
                                   ByVal nroOperacion As Integer, _
                                   ByVal IdCliente As Long, _
                                   ByVal nroCuota As Integer, _
                                   ByVal fechaPago As Date)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM FichasPagosDetalle")
         .AppendLine(" WHERE nroOperacion = " & nroOperacion)
         .AppendLine("   AND IdSucursal = " & idSucursal & " ")
         .AppendLine("   AND IdCliente = " & IdCliente.ToString())
         .AppendLine("   AND NroCuota = " & nroCuota)
         .AppendLine("   AND FechaPago = '" & Me.ObtenerFecha(fechaPago, True) & "'")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "FichasPagosDetalle")

   End Sub

   Public Function FichasPagosDetalle_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .AppendLine(" SELECT  ")
         .AppendLine(" * ")
         .AppendLine(" FROM FichasPagosDetalle ")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Sub FichasPagosDetalle_MovimientoCaja_U(ByVal idSucursal As Integer, _
                                                  ByVal IdCliente As Long, _
                                                  ByVal nroOperacion As Integer, _
                                                  ByVal nroCuota As Integer, _
                                                  ByVal fechaPago As Date, _
                                                  ByVal idCaja As Integer, _
                                                  ByVal numeroPlanilla As Integer, _
                                                  ByVal numeroMovimiento As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE FichasPagosDetalle")
         .AppendLine("   SET idCaja = " & idCaja.ToString())
         .AppendLine("      ,numeroPlanilla = " & numeroPlanilla.ToString())
         .AppendLine("      ,numeroMovimiento = " & numeroMovimiento.ToString())
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdCliente = " & IdCliente.ToString())
         .AppendLine("   AND nroOperacion = " & nroOperacion.ToString())
         .AppendLine("   AND NroCuota = " & nroCuota.ToString())
         .AppendLine("   AND FechaPago = '" & Me.ObtenerFecha(fechaPago, True) & "'")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "FichasPagosDetalle")

   End Sub
End Class
