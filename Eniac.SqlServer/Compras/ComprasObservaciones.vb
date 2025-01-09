Public Class ComprasObservaciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ComprasObservaciones_I(ByVal IdSucursal As Integer, _
                                    ByVal IdTipoComprobante As String, _
                                    ByVal Letra As String, _
                                    ByVal CentroEmisor As Integer, _
                                    ByVal NumeroComprobante As Long, _
                                    ByVal IdProveedor As Long, _
                                    ByVal Linea As Integer, _
                                    ByVal Observacion As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO ComprasObservaciones ")
         .AppendLine("   (IdSucursal")
         .AppendLine("   ,IdTipoComprobante")
         .AppendLine("   ,Letra")
         .AppendLine("   ,CentroEmisor")
         .AppendLine("   ,NumeroComprobante")
         .AppendLine("   ,IdProveedor")
         .AppendLine("   ,Linea")
         .AppendLine("   ,Observacion")
         .AppendLine(") VALUES (")
         .Append(IdSucursal.ToString())
         .Append(" ,'" & IdTipoComprobante & "'")
         .Append(" ,'" & Letra & "'")
         .Append(" ," & CentroEmisor.ToString())
         .Append(" ," & NumeroComprobante.ToString())
         .Append(" , " & IdProveedor.ToString())
         .Append(" ," & Linea.ToString())
         .Append(" ,'" & Observacion & "'")
         .Append(" )")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ComprasObservaciones")

   End Sub

   Public Sub ComprasObservaciones_U(ByVal IdSucursal As Integer, _
                                    ByVal IdTipoComprobante As String, _
                                    ByVal Letra As String, _
                                    ByVal CentroEmisor As Integer, _
                                    ByVal NumeroComprobante As Long, _
                                    ByVal IdProveedor As Long, _
                                    ByVal Linea As Integer, _
                                    ByVal Observacion As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE ComprasObservaciones SET ")
         .AppendLine("  Observacion = '" & Observacion & "'")
         .AppendLine(" WHERE IdSucursal = " & IdSucursal.ToString())
         .AppendLine("   AND idTipoComprobante = '" & IdTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & Letra & "'")
         .AppendLine("   AND CentroEmisor = " & CentroEmisor.ToString())
         .AppendLine("   AND NumeroComprobante = " & NumeroComprobante.ToString())
         .AppendLine("   AND IdProveedor = " & IdProveedor.ToString())
         .AppendLine("   AND Linea = " & Linea.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ComprasObservaciones")

   End Sub

   Public Sub ComprasObservaciones_D(ByVal IdSucursal As Integer, _
                                    ByVal IdTipoComprobante As String, _
                                    ByVal Letra As String, _
                                    ByVal CentroEmisor As Integer, _
                                    ByVal NumeroComprobante As Long, _
                                    ByVal IdProveedor As Long, _
                                    ByVal Linea As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("DELETE FROM VentasObservaciones ")
         .AppendLine(" WHERE IdSucursal = " & IdSucursal.ToString())
         .AppendLine("   AND idTipoComprobante = '" & IdTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & Letra & "'")
         .AppendLine("   AND CentroEmisor = " & CentroEmisor.ToString())
         .AppendLine("   AND NumeroComprobante = " & NumeroComprobante.ToString())
         .AppendLine("   AND IdProveedor = " & IdProveedor.ToString())
         If Linea > 0 Then
            .AppendLine("   AND Linea = " & Linea.ToString())
         End If
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "VentasObservaciones")

   End Sub

   Public Sub ComprasObservaciones_D2(ByVal IdSucursal As Integer, _
                                     ByVal IdTipoComprobante As String, _
                                     ByVal Letra As String, _
                                     ByVal CentroEmisor As Integer, _
                                     ByVal NumeroComprobante As Long, _
                                     ByVal IdProveedor As Long)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM ComprasObservaciones ")
         .AppendLine(" WHERE IdSucursal = " & IdSucursal.ToString())
         .AppendLine("   AND idTipoComprobante = '" & IdTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & Letra & "'")
         .AppendLine("   AND CentroEmisor = " & CentroEmisor.ToString())
         .AppendLine("   AND NumeroComprobante = " & NumeroComprobante.ToString())
         .AppendLine("   AND IdProveedor = " & IdProveedor.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ComprasObservaciones")

   End Sub

End Class
