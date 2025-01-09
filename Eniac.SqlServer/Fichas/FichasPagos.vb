Public Class FichasPagos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub FichasPagos_I(ByVal idSucursal As Integer, _
                            ByVal nroOperacion As Integer, _
                            ByVal IdCliente As Long, _
                            ByVal nroCuota As Integer, _
                            ByVal fechaVencimiento As Date, _
                            ByVal importe As Double, _
                            ByVal saldo As Double)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO FichasPagos")
         .Append("           ([IdSucursal]")
         .Append("           ,[NroOperacion]")
         .Append("           ,[IdCliente]  ")
         .Append("           ,[NroCuota]  ")
         .Append("           ,[FechaVencimiento]")
         .Append("           ,[Importe]")
         .Append("           ,[Saldo])")
         .Append("     VALUES(")
         .Append(idSucursal.ToString() & ", ")
         .Append(nroOperacion.ToString() & ", ")
         .Append(IdCliente.ToString() & ", ")
         .Append("" & nroCuota & ", ")
         .Append("'" & Me.ObtenerFecha(fechaVencimiento, True) & "', ")
         .Append("" & importe.ToString() & ", ")
         .Append("" & saldo.ToString() & " ")
         .Append(") ")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "FichasPagos")
   End Sub

   Public Sub FichasPagos_USaldo(ByVal idSucursal As Integer, _
                                 ByVal nroOperacion As Integer, _
                                 ByVal IdCliente As Long, _
                                 ByVal nroCuota As Integer, _
                                 ByVal saldo As Double)

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append(" UPDATE FichasPagos  ")
         .Append(" SET  ")

         .Append(" saldo = " & saldo.ToString() & " ")

         .Append(" WHERE NroOperacion = " & nroOperacion)
         .Append(" AND IdSucursal = " & idSucursal & " ")
         .Append(" AND IdCliente = " & IdCliente.ToString())
         .Append(" AND NroCuota = '" & nroCuota & "'")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "FichasPagos")
   End Sub

   Public Sub FichasPagos_D(ByVal idSucursal As Integer, _
                            ByVal nroOperacion As Integer, _
                            ByVal IdCliente As Long, _
                            ByVal nroCuota As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM  ")
         .Append("FichasPagos  ")
         .Append("WHERE  ")
         .Append(" nroOperacion = " & nroOperacion)
         .Append(" AND IdSucursal = " & idSucursal & " ")
         .Append(" AND IdCliente = " & IdCliente.ToString())
         .Append(" AND NroCuota = " & nroCuota)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "FichasPagos")
   End Sub

   Public Function FichasPagos_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("SELECT  ")
         .Append("* ")
         .Append("FROM FichasPagos ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class
