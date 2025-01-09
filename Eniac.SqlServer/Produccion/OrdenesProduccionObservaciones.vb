Public Class OrdenesProduccionObservaciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub OrdenesProduccionObservaciones_I(idSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Integer,
                                     NumeroOrdenProduccion As Long,
                                     linea As Integer,
                                     observacion As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("INSERT INTO OrdenesProduccionObservaciones ")
         .AppendLine("   (IdSucursal")
         .AppendLine("   ,IdTipoComprobante")
         .AppendLine("   ,Letra")
         .AppendLine("   ,CentroEmisor")
         .AppendLine("   ,NumeroOrdenProduccion")
         .AppendLine("   ,Linea")
         .AppendLine("   ,Observacion")
         .AppendLine(") VALUES ")
         .AppendFormat("  ({0}", idSucursal).AppendLine()
         .AppendFormat(" ,'{0}'", idTipoComprobante).AppendLine()
         .AppendFormat(" ,'{0}'", letra).AppendLine()
         .AppendFormat(" , {0}", centroEmisor).AppendLine()
         .AppendFormat(" , {0}", NumeroOrdenProduccion).AppendLine()
         .AppendFormat(" , {0}", linea).AppendLine()
         .AppendFormat(" ,'{0}'", observacion).AppendLine()
         .AppendFormat(" )").AppendLine()
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "OrdenesProduccionObservaciones")
   End Sub

   Public Sub OrdenesProduccionObservaciones_U(idSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Integer,
                                     NumeroOrdenProduccion As Long,
                                     linea As Integer,
                                     observacion As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE OrdenesProduccionObservaciones SET ").AppendLine()
         .AppendFormat("  Observacion = '{0}'", observacion).AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND idTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroOrdenProduccion = {0}", NumeroOrdenProduccion).AppendLine()
         .AppendFormat("   AND Linea = {0}", linea).AppendLine()
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "OrdenesProduccionObservaciones")
   End Sub

   Public Sub OrdenesProduccionObservaciones_D(idSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Integer,
                                     NumeroOrdenProduccion As Long,
                                     linea As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("DELETE FROM OrdenesProduccionObservaciones ")
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND idTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroOrdenProduccion = {0}", NumeroOrdenProduccion).AppendLine()
         If linea > 0 Then
            .AppendFormat("   AND Linea = {0}", linea).AppendLine()
         End If
      End With
      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "OrdenesProduccionObservaciones")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT PO.*").AppendLine()
         .AppendFormat("  FROM OrdenesProduccionObservaciones AS PO").AppendLine()
      End With
   End Sub

   Public Function OrdenesProduccionObservaciones_GA(idSucursal As Integer,
                                           idTipoComprobante As String,
                                           letra As String,
                                           centroEmisor As Integer,
                                           NumeroOrdenProduccion As Long) As DataTable
      Return OrdenesProduccionObservaciones_G(idSucursal,
                                    idTipoComprobante,
                                    letra,
                                    centroEmisor,
                                    NumeroOrdenProduccion,
                                    0)
   End Function
   Private Function OrdenesProduccionObservaciones_G(idSucursal As Integer,
                                            idTipoComprobante As String,
                                            letra As String,
                                            centroEmisor As Integer,
                                            NumeroOrdenProduccion As Long,
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
         If NumeroOrdenProduccion > 0 Then
            .AppendFormat("   AND PO.NumeroOrdenProduccion = {0}", NumeroOrdenProduccion).AppendLine()
         End If
         If linea > 0 Then
            .AppendFormat("   AND PO.Linea = {0}", linea).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function OrdenesProduccionObservaciones_G1(idSucursal As Integer,
                                           idTipoComprobante As String,
                                           letra As String,
                                           centroEmisor As Integer,
                                           NumeroOrdenProduccion As Long,
                                           linea As Integer) As DataTable
      Return OrdenesProduccionObservaciones_G(idSucursal,
                                    idTipoComprobante,
                                    letra,
                                    centroEmisor,
                                    NumeroOrdenProduccion,
                                    linea)
   End Function

   'Public Sub CopiarPedidoObservacion(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, NumeroOrdenProduccion As Long,
   '                                   idSucursalNuevo As Integer, idTipoComprobanteNuevo As String, letraNuevo As String, centroEmisorNuevo As Integer, NumeroOrdenProduccionNuevo As Long)
   '   Dim myQuery As StringBuilder = New StringBuilder()
   '   With myQuery
   '      .AppendFormat("INSERT INTO OrdenesProduccionObservaciones").AppendLine()
   '      .AppendFormat("      (IdSucursal").AppendLine()
   '      .AppendFormat("      ,IdTipoComprobante").AppendLine()
   '      .AppendFormat("      ,Letra").AppendLine()
   '      .AppendFormat("      ,CentroEmisor").AppendLine()
   '      .AppendFormat("      ,NumeroOrdenProduccion").AppendLine()
   '      .AppendFormat("      ,Linea").AppendLine()
   '      .AppendFormat("      ,Observacion)").AppendLine()
   '      .AppendFormat("SELECT {0} idSucursal", idSucursalNuevo).AppendLine()
   '      .AppendFormat("      ,'{0}' IdTipoComprobante", idTipoComprobanteNuevo).AppendLine()
   '      .AppendFormat("      ,'{0}' Letra", letraNuevo).AppendLine()
   '      .AppendFormat("      ,{0} CentroEmisor", centroEmisorNuevo).AppendLine()
   '      .AppendFormat("      ,{0} NumeroOrdenProduccion", NumeroOrdenProduccionNuevo).AppendLine()
   '      .AppendFormat("      ,Linea").AppendLine()
   '      .AppendFormat("      ,Observacion").AppendLine()
   '      .AppendFormat("  FROM OrdenesProduccionObservaciones").AppendLine()
   '      .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
   '      .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
   '      .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
   '      .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
   '      .AppendFormat("   AND NumeroOrdenProduccion = {0}", NumeroOrdenProduccion).AppendLine()

   '   End With
   '   Me.Execute(myQuery.ToString())
   'End Sub
End Class