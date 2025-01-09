Public Class MovimientosNumeros
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub MovimientosNumeros_U(ByVal idSucursal As Integer, _
                              ByVal idTipoMovimiento As String, _
                             ByVal numero As Long)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .Append("IF NOT EXISTS ( ")
         .Append("SELECT ")
         .Append(" Numero ")
         .Append(" FROM MovimientosNumeros")
         .Append(" WHERE ")
         .Append(" IdSucursal = " & idSucursal.ToString)
         .Append(" AND IdTipoMovimiento = '" & idTipoMovimiento & "'")
         .Append(") ")
         .Append("BEGIN ")
         .Append(" INSERT INTO MovimientosNumeros")
         .Append(" (IdSucursal, ")
         .Append(" IdTipoMovimiento, ")
         .Append(" Numero) ")
         .Append("VALUES ( ")
         .Append(idSucursal.ToString & ", ")
         .Append(" '" & idTipoMovimiento & "', ")
         .Append(numero.ToString & ")")
         .Append("END ")
      End With

      Me.Execute(myQuery.ToString())

      With myQuery
         .Length = 0
         .Append("UPDATE  ")
         .Append("MovimientosNumeros  ")
         .Append("SET  ")
         .Append("Numero = " & numero & " ")
         .Append("WHERE ")
         .Append(" IdSucursal = " & idSucursal.ToString)
         .Append(" AND IdTipoMovimiento = '" & idTipoMovimiento & "'")
      End With

      Me.Execute(myQuery.ToString())

      Me.Sincroniza_I(myQuery.ToString(), "MovimientosNumeros")

   End Sub

End Class
