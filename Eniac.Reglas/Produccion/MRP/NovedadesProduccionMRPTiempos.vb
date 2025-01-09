Public Class NovedadesProduccionMRPTiempos
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.NovedadProduccionMRPTiempo.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   '-- Con Transaccion.- -----------------------------------------------------------------------------
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.NovedadProduccionMRPTiempo), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.NovedadProduccionMRPTiempo), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.NovedadProduccionMRPTiempo), TipoSP._D))
   End Sub
   '-- Sin transacciones.- ---------------------------------------------------------------------------
   Public Sub _Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.NovedadProduccionMRPTiempo), TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.NovedadProduccionMRPTiempo), TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.NovedadProduccionMRPTiempo), TipoSP._D)
   End Sub
   '-------------------------------------------------------------------------------------------------
#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.NovedadesProduccionMRPTiempos
      Return New SqlServer.NovedadesProduccionMRPTiempos(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.NovedadProduccionMRPTiempo, tipo As TipoSP)
      Dim sqlC = GetSql()
      Select Case tipo
         Case TipoSP._I
            '-- Inserta Novedades de Produccion Tiempos.- --------
            sqlC.NovedadesProduccionMRPTiempos_I(en.NumeroNovedadesProducccion, en.CodigoOperacion, en.FechaHoraInicio, en.FechaHoraFin, en.IdTipoDeclaracion, en.IdConcepto)
      End Select
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub ActualizaNovedadesTiempos(entidad As Entidades.NovedadProduccionMRP)
      If entidad.TiemposNovedades IsNot Nothing Then
         '-- Elimina los Borrados.- --------------------------------------------------
         For Each ent In entidad.TiemposNovedades.Borrados
            _Borrar(ent)
         Next
         '----------------------------------------------------------------------------
         For Each oPN In entidad.TiemposNovedades
            If oPN.NumeroNovedadesProducccion = 0 Then
               oPN.NumeroNovedadesProducccion = entidad.NumeroNovedadesProducccion
               _Insertar(oPN)
            End If
         Next
         '----------------------------------------------------------------------------
      End If
   End Sub

   Public Function GetInformeDeclaraciones(idResponsable As Integer, idTarea As Integer, fechaDesde As Date?, fechaHasta As Date?,
                                           idTipoDeclaracion As Publicos.TipoOperacionesTiempos?, idConceptoNoProductivo As Integer,
                                           idTipoComprobante As String, letraFiscal As String, centroEmisor As Integer, numeroDesde As Long, numeroHasta As Long,
                                           idProducto As String, idCliente As Long?, idProcesoProductivo As Long,
                                           idTipoComprobantePedido As String, letraFiscalPedido As String, centroEmisorPedido As Integer, numeroPedidoDesde As Long, numeroPedidoHasta As Long, lineaPedido As Integer,
                                           planMaestroNumero As Integer) As DataTable
      Dim dt = GetSql().GetInformeDeclaraciones(idResponsable, idTarea, fechaDesde, fechaHasta,
                                                If(idTipoDeclaracion.HasValue, idTipoDeclaracion.ToString(), String.Empty), idConceptoNoProductivo,
                                                idTipoComprobante, letraFiscal, centroEmisor, numeroDesde, numeroHasta,
                                                idProducto, idCliente, idProcesoProductivo,
                                                idTipoComprobantePedido, letraFiscalPedido, centroEmisorPedido, numeroPedidoDesde, numeroPedidoHasta, lineaPedido,
                                                planMaestroNumero)
      dt.Columns.Add("DescripcionTipoDeclaracion", GetType(String))

      dt.ForEach(Sub(dr)
                    Dim idTipo = dr.Field(Of String)(Entidades.NovedadProduccionMRPTiempo.Columnas.IdTipoDeclaracion.ToString())
                    Dim descr = String.Empty
                    If Not String.IsNullOrWhiteSpace(idTipo) Then
                       Dim e = idTipo.StringToEnum(Publicos.TipoOperacionesTiempos.PUESTAPUNTO)
                       descr = e.GetDescription()
                    End If
                    dr("DescripcionTipoDeclaracion") = descr
                 End Sub)

      Return dt
   End Function

#End Region

End Class