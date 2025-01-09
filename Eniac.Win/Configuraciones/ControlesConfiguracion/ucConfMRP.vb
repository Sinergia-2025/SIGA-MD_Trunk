Public Class ucConfMRP
   Private Property _Cargando As Boolean = False

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)
      '----------------------------------------------------------------------------------------
      e.Publicos.CargaComboTiposComprobantes(cmbTipoComprobanteOP, False, "PRODUCCION", , , , True)
      e.Publicos.CargaComboEstadosOrdenesProduccion(cmbEstadoPlanificacion, False, False, False, False, String.Empty)
      e.Publicos.CargaComboTiposComprobantes(cmbTipoComprobanteRQ, False, "REQCOMPRAS", , , , True)
      e.Publicos.CargaComboEstadosOrdenesProduccion(cmbEstadosPlanificacionRequerimiento, False, False, False, False, String.Empty)
      e.Publicos.CargaComboEstadosOrdenesProduccion(cmbEstadosFinalOrdenProduccion, True, False, False, False, "FINALIZADO")

      e.Publicos.CargaComboEstadosPedidosProv(cmbEstadoOPaVincularFuncionalidadTE, False, False, False, False, False, Entidades.TipoComprobante.Tipos.ORDENCOMPRAPROV.ToString(), Entidades.Publicos.LecturaEscrituraTodos.TODOS)
      e.Publicos.CargaComboEstadosPedidosProv(cmbEstadoOPVincularFuncionalidadTE, False, False, False, False, False, Entidades.TipoComprobante.Tipos.ORDENCOMPRAPROV.ToString(), Entidades.Publicos.LecturaEscrituraTodos.TODOS)

      e.Publicos.CargaComboEmpleados(cmbOperarioProductosNecesariosTE, Entidades.Publicos.TiposEmpleados.RESPPROD)
      '----------------------------------------------------------------------------------------
   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)
      '----------------------------------------------------------------------------------------
      If cmbTipoComprobanteOP.Items.Count > 0 Then cmbTipoComprobanteOP.SelectedValue = Reglas.Publicos.TipoComprobanteOrdenProduccionPlanificacion
      If cmbEstadoPlanificacion.Items.Count > 0 Then cmbEstadoPlanificacion.SelectedValue = Reglas.Publicos.EstadoOrdenProduccionPlanificacion
      If cmbTipoComprobanteRQ.Items.Count > 0 Then cmbTipoComprobanteRQ.SelectedValue = Reglas.Publicos.TipoComprobanteOrdenProduccionRequerimiento
      If cmbEstadosPlanificacionRequerimiento.Items.Count > 0 Then cmbEstadosPlanificacionRequerimiento.SelectedValue = Reglas.Publicos.EstadoOrdenProduccionPlanificacionRQ
      If cmbEstadosFinalOrdenProduccion.Items.Count > 0 Then cmbEstadosFinalOrdenProduccion.SelectedValue = Reglas.Publicos.EstadoFinalOrdenProduccion

      If cmbEstadoOPaVincularFuncionalidadTE.Items.Count > 0 Then cmbEstadoOPaVincularFuncionalidadTE.SelectedValue = Reglas.Publicos.EstadoOrdenCompraAVincular
      If cmbEstadoOPVincularFuncionalidadTE.Items.Count > 0 Then cmbEstadoOPVincularFuncionalidadTE.SelectedValue = Reglas.Publicos.EstadoOrdenCompraVinculada

      If cmbOperarioProductosNecesariosTE.Items.Count > 0 Then cmbOperarioProductosNecesariosTE.SelectedValue = Reglas.Publicos.OperarioInformaTalleresExternos
      '----------------------------------------------------------------------------------------
   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)
      '----------------------------------------------------------------------------------------
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.TIPOCOMPROBANTEORDENPRODUCCIONPLANIFICACION, cmbTipoComprobanteOP, Nothing, cmbTipoComprobanteOP.LabelAsoc.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.ESTADOORDENPRODUCCIONPLANIFICACION, cmbEstadoPlanificacion, Nothing, cmbEstadoPlanificacion.LabelAsoc.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.TIPOCOMPROBANTEORDENPRODUCCIONREQUERIMIENTO, cmbTipoComprobanteRQ, Nothing, cmbTipoComprobanteRQ.LabelAsoc.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.ESTADOORDENPRODUCCIONPLANIFICACIONRQ, cmbEstadosPlanificacionRequerimiento, Nothing, cmbEstadosPlanificacionRequerimiento.LabelAsoc.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.ESTADOFINALORDENPRODUCCION, cmbEstadosFinalOrdenProduccion, Nothing, cmbEstadosFinalOrdenProduccion.LabelAsoc.Text)

      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.ESTADOORDENCOMPRAAVINCULAR, cmbEstadoOPaVincularFuncionalidadTE, Nothing, cmbEstadoOPaVincularFuncionalidadTE.LabelAsoc.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.ESTADOORDENCOMPRAVINCULADA, cmbEstadoOPVincularFuncionalidadTE, Nothing, cmbEstadoOPVincularFuncionalidadTE.LabelAsoc.Text)

      ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.OPERARIOINFORMATALLERESEXTERNOS, cmbOperarioProductosNecesariosTE, Nothing, cmbOperarioProductosNecesariosTE.LabelAsoc.Text)
      '----------------------------------------------------------------------------------------
   End Sub

   Protected Overrides Sub OnValidando(e As ValidacionEventArgs)
      MyBase.OnValidando(e)

      If cmbEstadoOPVincularFuncionalidadTE.SelectedIndex > -1 Then
         Dim estadoPedidoPrv = New Reglas.EstadosPedidosProveedores().GetUno(cmbEstadoOPVincularFuncionalidadTE.SelectedValue.ToString(), "ORDENCOMPRAPROV")
         If String.IsNullOrEmpty(estadoPedidoPrv.IdTipoComprobante) Then
            e.AgregarError(String.Format("El estado seleccionado no tiene asociado un tipo de comprobante.{0} 
                                          Por favor seleccione un estado que tenga asociado un tipo de comprobante.{0}
                                          Para  asociar  un comprobante a un estado abra el menú Orden de compra Prov, Abm de estados de orden de compra prov.", Environment.NewLine))
            cmbEstadoOPVincularFuncionalidadTE.Focus()
         End If
      End If
   End Sub

End Class
