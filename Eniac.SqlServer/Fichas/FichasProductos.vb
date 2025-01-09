Public Class FichasProductos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

    Public Sub FichasProductos_I(ByVal idSucursal As Int32, _
                                  ByVal nroOperacion As Integer, _
                                 ByVal IdCliente As Long, _
                                 ByVal idProducto As String, _
                                 ByVal cantidad As Integer, _
                                 ByVal precio As Double, _
                                 ByVal fechaEntrega As DateTime, _
                                 ByVal garantia As Integer, _
                                 ByVal IdProveedor As Long)
        Dim myQuery As StringBuilder = New StringBuilder("")

        With myQuery
            .Append("INSERT INTO FichasProductos")
            .Append("           ([IdSucursal]")
            .Append("           ,[NroOperacion]")
            .Append("           ,[IdCliente]  ")
            .Append("           ,[IdProducto]")
            .Append("           ,[Cantidad]")
            .Append("           ,[Precio]")
            .Append("           ,[FechaEntrega]")
            .Append("           ,[Garantia]")
            .Append("           ,[IdProveedor])")
            .Append("     VALUES(")
            .Append(idSucursal & ", ")
            .Append(nroOperacion & ", ")
            .Append(IdCliente.ToString() & ", ")
            .Append("'" & idProducto & "', ")
            .Append("" & cantidad & ", ")
            .Append("" & precio.ToString() & ", ")
            If fechaEntrega <= New DateTime(1900, 1, 1) Then
                .Append("null,")
            Else
                .Append("'" & Me.ObtenerFecha(fechaEntrega, True) & "', ")
            End If
            .Append("" & garantia & ", ")
            If IdProveedor = Nothing Then
                .Append("null")
            Else
                .Append("" & IdProveedor)
            End If
            .Append(") ")
        End With

        Me.Execute(myQuery.ToString())
        Me.Sincroniza_I(myQuery.ToString(), "FichasProductos")
    End Sub

   Public Sub FichasProductos_UFechaEntrega(ByVal idsucursal As Int32, _
                                    ByVal nroOperacion As Integer, _
                                  ByVal IdCliente As Long, _
                                  ByVal idProducto As String, _
                                  ByVal fechaEntrega As DateTime)
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append(" UPDATE  ")
         .Append(" FichasProductos  ")
         .Append(" SET  ")

         If fechaEntrega <= New DateTime(1900, 1, 1) Then
            .Append(" FechaEntrega = null ")
         Else
            .Append(" FechaEntrega = '" & Me.ObtenerFecha(fechaEntrega, True) & "' ")
         End If

         .Append(" WHERE ")
         .Append(" NroOperacion = " & nroOperacion)
         .Append(" AND IdSucursal = " & idsucursal & " ")
         .Append(" AND IdCliente = " & IdCliente.ToString())
         .Append(" AND IdProducto = '" & idProducto & "' ")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "FichasProductos")
   End Sub

   Public Sub FichasProductos_D(ByVal idSucursal As Int32, _
                           ByVal nroOperacion As Integer, _
                           ByVal IdCliente As Long, _
                           ByVal idProducto As String)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append(" DELETE FROM  ")
         .Append(" FichasProductos  ")
         .Append(" WHERE  ")
         .Append(" nroOperacion = " & nroOperacion)
         .Append(" AND idSucursal = " & idSucursal & " ")
         .Append(" AND IdCliente = " & IdCliente.ToString())
         .Append(" AND idProducto = '" & idProducto & "' ")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "FichasProductos")
   End Sub

   Public Function FichasProductos_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("SELECT  ")
         .Append("* ")
         .Append("FROM FichasProductos ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class
