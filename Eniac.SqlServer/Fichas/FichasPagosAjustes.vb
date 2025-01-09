Public Class FichasPagosAjustes
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub FichasPagosAjustes_I(ByVal idSucursal As Integer, _
                                   ByVal IdCliente As Long, _
                                   ByVal nroOperacion As Integer, _
                                   ByVal fechaPago As Date, _
                                   ByVal importe As Double, _
                                   ByVal concepto As String, _
                                   ByVal IdCaja As Integer, _
                                   ByVal NumeroPlanilla As Integer, _
                                   ByVal NumeroMovimiento As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO FichasPagosAjustes")
         .AppendLine("           (IdSucursal")
         .AppendLine("           ,IdCliente  ")
         .AppendLine("           ,NroOperacion")
         .AppendLine("           ,FechaPago")
         .AppendLine("           ,Importe")
         .AppendLine("           ,Concepto")
         .AppendLine("           ,IdCaja")
         .AppendLine("           ,NumeroPlanilla")
         .AppendLine("           ,NumeroMovimiento)")
         .AppendLine("     VALUES(")
         .AppendLine(idSucursal.ToString())
         .AppendLine(", " & IdCliente.ToString())
         .AppendLine(", " & nroOperacion.ToString())
         .AppendLine(", '" & Me.ObtenerFecha(fechaPago, True) & "'")
         .AppendLine(", " & importe.ToString())
         .AppendLine(", '" & concepto & "'")
         .AppendLine(", " & IdCaja.ToString())
         .AppendLine(", " & NumeroPlanilla.ToString())
         .AppendLine(", " & NumeroMovimiento.ToString())
         .AppendLine(") ")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "FichasPagosAjustes")

   End Sub

End Class
