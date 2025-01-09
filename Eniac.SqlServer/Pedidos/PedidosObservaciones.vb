Public Class PedidosObservaciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub PedidosObservaciones_I(idSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Integer,
                                     numeroPedido As Long,
                                     linea As Integer,
                                     observacion As String, idTipoObservacion As Short)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("INSERT INTO PedidosObservaciones ")
         .AppendLine("   (IdSucursal")
         .AppendLine("   ,IdTipoComprobante")
         .AppendLine("   ,Letra")
         .AppendLine("   ,CentroEmisor")
         .AppendLine("   ,NumeroPedido")
         .AppendLine("   ,Linea")
         .AppendLine("   ,Observacion")
         .AppendLine("   ,IdTipoObservacion")
         .AppendLine(") VALUES ")
         .AppendFormat("  ({0}", idSucursal).AppendLine()
         .AppendFormat(" ,'{0}'", idTipoComprobante).AppendLine()
         .AppendFormat(" ,'{0}'", letra).AppendLine()
         .AppendFormat(" , {0}", centroEmisor).AppendLine()
         .AppendFormat(" , {0}", numeroPedido).AppendLine()
         .AppendFormat(" , {0}", linea).AppendLine()
         .AppendFormat(" ,'{0}'", observacion).AppendLine()
         .AppendFormat(" , {0}", idTipoObservacion).AppendLine()
         .AppendFormat(" )").AppendLine()
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "PedidosObservaciones")
   End Sub

   Public Sub PedidosObservaciones_U(idSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Integer,
                                     numeroPedido As Long,
                                     linea As Integer,
                                     observacion As String, idTipoObservacion As Short)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE PedidosObservaciones SET ").AppendLine()
         .AppendFormat("  IdTipoObservacion = {0}, ", idTipoObservacion).AppendLine()
         .AppendFormat("  Observacion = '{0}'", observacion).AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND idTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()
         .AppendFormat("   AND Linea = {0}", linea).AppendLine()
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "PedidosObservaciones")
   End Sub

   Public Sub PedidosObservaciones_D(idSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Integer,
                                     numeroPedido As Long,
                                     linea As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("DELETE FROM PedidosObservaciones ")
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND idTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()
         If linea > 0 Then
            .AppendFormat("   AND Linea = {0}", linea).AppendLine()
         End If
      End With
      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "PedidosObservaciones")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT PO.*, TOB.Descripcion").AppendLine()
         .AppendFormat("  FROM PedidosObservaciones AS PO").AppendLine()
         .AppendFormat("  INNER JOIN TiposObservaciones AS TOB ON PO.IdTipoObservacion = TOB.IdObservaciones").AppendLine()
      End With
   End Sub

   Public Function PedidosObservaciones_GA(idSucursal As Integer,
                                           idTipoComprobante As String,
                                           letra As String,
                                           centroEmisor As Integer,
                                           numeroPedido As Long) As DataTable
      Return PedidosObservaciones_G(idSucursal,
                                    idTipoComprobante,
                                    letra,
                                    centroEmisor,
                                    numeroPedido,
                                    0)
   End Function
   Private Function PedidosObservaciones_G(idSucursal As Integer,
                                            idTipoComprobante As String,
                                            letra As String,
                                            centroEmisor As Integer,
                                            numeroPedido As Long,
                                            linea As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal > 0 Then
            .AppendFormat("   AND PO.IdSucursal = {0}", idSucursal).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND PO.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND PO.Letra = '{0}'", letra).AppendLine()
         End If
         If centroEmisor > 0 Then
            .AppendFormat("   AND PO.CentroEmisor = {0}", centroEmisor).AppendLine()
         End If
         If numeroPedido > 0 Then
            .AppendFormat("   AND PO.NumeroPedido = {0}", numeroPedido).AppendLine()
         End If
         If linea > 0 Then
            .AppendFormat("   AND PO.Linea = {0}", linea).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function PedidosObservaciones_G1(idSucursal As Integer,
                                           idTipoComprobante As String,
                                           letra As String,
                                           centroEmisor As Integer,
                                           numeroPedido As Long,
                                           linea As Integer) As DataTable
      Return PedidosObservaciones_G(idSucursal,
                                    idTipoComprobante,
                                    letra,
                                    centroEmisor,
                                    numeroPedido,
                                    linea)
   End Function

   'Public Sub CopiarPedidoObservacion(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
   '                                   idSucursalNuevo As Integer, idTipoComprobanteNuevo As String, letraNuevo As String, centroEmisorNuevo As Integer, numeroPedidoNuevo As Long)
   '   Dim myQuery As StringBuilder = New StringBuilder()
   '   With myQuery
   '      .AppendFormat("INSERT INTO PedidosObservaciones").AppendLine()
   '      .AppendFormat("      (IdSucursal").AppendLine()
   '      .AppendFormat("      ,IdTipoComprobante").AppendLine()
   '      .AppendFormat("      ,Letra").AppendLine()
   '      .AppendFormat("      ,CentroEmisor").AppendLine()
   '      .AppendFormat("      ,NumeroPedido").AppendLine()
   '      .AppendFormat("      ,Linea").AppendLine()
   '      .AppendFormat("      ,Observacion)").AppendLine()
   '      .AppendFormat("SELECT {0} idSucursal", idSucursalNuevo).AppendLine()
   '      .AppendFormat("      ,'{0}' IdTipoComprobante", idTipoComprobanteNuevo).AppendLine()
   '      .AppendFormat("      ,'{0}' Letra", letraNuevo).AppendLine()
   '      .AppendFormat("      ,{0} CentroEmisor", centroEmisorNuevo).AppendLine()
   '      .AppendFormat("      ,{0} NumeroPedido", numeroPedidoNuevo).AppendLine()
   '      .AppendFormat("      ,Linea").AppendLine()
   '      .AppendFormat("      ,Observacion").AppendLine()
   '      .AppendFormat("  FROM PedidosObservaciones").AppendLine()
   '      .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
   '      .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
   '      .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
   '      .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
   '      .AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()

   '   End With
   '   Me.Execute(myQuery.ToString())
   'End Sub
End Class