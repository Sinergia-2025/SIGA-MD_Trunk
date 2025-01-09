Public Class Fichas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Fichas_I(ByVal idSucursal As Int32, _
                        ByVal nroOperacion As Integer, _
                        ByVal IdCliente As Long, _
                        ByVal fechaOperacion As DateTime, _
                        ByVal montoTotalBruto As Double, _
                        ByVal anticipo As Double, _
                        ByVal cuotas As Integer, _
                        ByVal idFormasPago As Integer, _
                        ByVal interes As Double, _
                        ByVal totalNeto As Double, _
                        ByVal saldo As Double, _
                        ByVal IdCobrador As Integer, _
                        ByVal idEstado As String, _
                        ByVal nroFactura As Integer, _
                        ByVal comentario As String, _
                        ByVal IdVendedor As Integer, _
                        ByVal usuario As String)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO Fichas  ")
         .Append("           ([IdSucursal]  ")
         .Append("           ,[NroOperacion]  ")
         .Append("           ,[IdCliente]  ")
         .Append("           ,[FechaOperacion]")
         .Append("           ,[MontoTotalBruto]")
         .Append("           ,[Anticipo]")
         .Append("           ,[Cuotas]")
         .Append("           ,[IdFormasPago]")
         .Append("           ,[Interes]")
         .Append("           ,[TotalNeto]")
         .Append("           ,[Saldo]")
         .Append("           ,[IdCobrador]")
         .Append("           ,[IdEstado]")
         .Append("           ,[NroFactura]")
         .Append("           ,[Comentario]")
         .Append("           ,[IdVendedor]")
         .Append("           ,[Usuario])")
         .Append("     VALUES(")
         .Append(idSucursal.ToString() & ", ")
         .Append(nroOperacion.ToString() & ", ")
         .Append(IdCliente.ToString() & ", ")
         .Append("'" & Me.ObtenerFecha(fechaOperacion, True) & "', ")
         .Append("" & montoTotalBruto.ToString() & ", ")
         .Append("" & anticipo.ToString() & ", ")
         .Append("" & cuotas & ", ")
         .Append("" & idFormasPago & ", ")
         .Append("" & interes.ToString() & ", ")
         .Append("" & totalNeto.ToString() & ", ")
         .Append("" & saldo.ToString() & ", ")
         .Append("" & IdCobrador & ", ")
         .Append("'" & idEstado & "', ")
         .Append("" & nroFactura & ", ")
         .Append("'" & comentario & "', ")
         .Append(IdVendedor.ToString() & ", ")
         .Append("'" & usuario & "' ")
         .Append(") ")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Fichas")
   End Sub

   Public Sub Fichas_USaldo(ByVal idSucursal As Int32, ByVal nroOperacion As Integer, ByVal IdCliente As Long, ByVal saldo As Double)

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append(" UPDATE Fichas ")
         .Append("    SET Saldo = " & saldo.ToString() & " ")
         .Append(" WHERE NroOperacion = " & nroOperacion)
         .Append(" AND IdSucursal = " & idSucursal & " ")
         .Append(" AND IdCliente = " & IdCliente.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Fichas")
   End Sub

   Public Sub Fichas_UEstado(ByVal idSucursal As Int32, ByVal nroOperacion As Integer, ByVal IdCliente As Long, ByVal idEstado As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("UPDATE Fichas ")
         .Append("   SET IdEstado = '" & idEstado & "' ")
         .Append(" WHERE NroOperacion = " & nroOperacion.ToString())
         .Append(" AND IdSucursal = " & idSucursal.ToString())
         .Append(" AND IdCliente = " & IdCliente.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Fichas")
   End Sub

   Public Sub Fichas_D(ByVal idSucursal As Int32, ByVal nroOperacion As Integer, ByVal IdCliente As Long)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM Fichas")
         .Append(" WHERE NroOperacion = " & nroOperacion)
         .Append(" AND IdSucursal = " & idSucursal & " ")
         .Append(" AND IdCliente = " & IdCliente.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Fichas")
   End Sub

   Public Function Fichas_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("SELECT  ")
         .Append("* ")
         .Append("FROM Fichas ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Sub Fichas_UComentario(ByVal idSucursal As Int32, ByVal nroOperacion As Integer, ByVal IdCliente As Long, ByVal comentario As String)

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append(" UPDATE Fichas ")
         .Append("    SET Comentario = '" & comentario & "' ")
         .Append(" WHERE NroOperacion = " & nroOperacion)
         .Append(" AND IdSucursal = " & idSucursal & " ")
         .Append(" AND IdCliente = " & IdCliente.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Fichas")
   End Sub

End Class
