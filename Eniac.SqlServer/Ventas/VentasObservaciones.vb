Public Class VentasObservaciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VentasObservaciones_I(ByVal IdSucursal As Integer,
                                    ByVal IdTipoComprobante As String,
                                    ByVal Letra As String,
                                    ByVal CentroEmisor As Integer,
                                    ByVal NumeroComprobante As Long,
                                    ByVal Linea As Integer,
                                    ByVal Observacion As String, idTipoObservacion As Short)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO VentasObservaciones ")
         .AppendLine("   (IdSucursal")
         .AppendLine("   ,IdTipoComprobante")
         .AppendLine("   ,Letra")
         .AppendLine("   ,CentroEmisor")
         .AppendLine("   ,NumeroComprobante")
         .AppendLine("   ,Linea")
         .AppendLine("   ,Observacion")
         .AppendLine("   ,IdTipoObservacion")
         .AppendLine(") VALUES (")
         .Append(IdSucursal.ToString())
         .Append(" ,'" & IdTipoComprobante & "'")
         .Append(" ,'" & Letra & "'")
         .Append(" , " & CentroEmisor.ToString())
         .Append(" , " & NumeroComprobante.ToString())
         .Append(" , " & Linea.ToString())
         .Append(" ,'" & Observacion & "'")
         .Append(" , " & idTipoObservacion.ToString())
         .Append(" )")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "VentasObservaciones")

   End Sub

   Public Sub VentasObservaciones_U(ByVal IdSucursal As Integer,
                                    ByVal IdTipoComprobante As String,
                                    ByVal Letra As String,
                                    ByVal CentroEmisor As Integer,
                                    ByVal NumeroComprobante As Long,
                                    ByVal Linea As Integer,
                                    ByVal Observacion As String, idTipoObservacion As Short)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE VentasObservaciones SET ")
         .AppendLine("  Observacion = '" & Observacion & "'")
         .AppendLine("  ,IdTipoObservacion = " & idTipoObservacion.ToString())
         .AppendLine(" WHERE IdSucursal = " & IdSucursal.ToString())
         .AppendLine("   AND idTipoComprobante = '" & IdTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & Letra & "'")
         .AppendLine("   AND CentroEmisor = " & CentroEmisor.ToString())
         .AppendLine("   AND NumeroComprobante = " & NumeroComprobante.ToString())
         .AppendLine("   AND Linea = " & Linea.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "VentasObservaciones")

   End Sub

   Public Sub VentasObservaciones_D(ByVal IdSucursal As Integer, _
                                    ByVal IdTipoComprobante As String, _
                                    ByVal Letra As String, _
                                    ByVal CentroEmisor As Integer, _
                                    ByVal NumeroComprobante As Long, _
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
         If Linea > 0 Then
            .AppendLine("   AND Linea = " & Linea.ToString())
         End If
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "VentasObservaciones")

   End Sub

   Public Sub VentasObservaciones_D2(ByVal IdSucursal As Integer, _
                                     ByVal IdTipoComprobante As String, _
                                     ByVal Letra As String, _
                                     ByVal CentroEmisor As Integer, _
                                     ByVal NumeroComprobante As Long)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM VentasObservaciones ")
         .AppendLine(" WHERE IdSucursal = " & IdSucursal.ToString())
         .AppendLine("   AND idTipoComprobante = '" & IdTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & Letra & "'")
         .AppendLine("   AND CentroEmisor = " & CentroEmisor.ToString())
         .AppendLine("   AND NumeroComprobante = " & NumeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "VentasObservaciones")

   End Sub

End Class
