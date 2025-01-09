Public Class ucNDConfModulos
   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Facturacion Electronica
      chbUtilizaModuloFactElectronica.Checked = Reglas.Publicos.TieneModuloFacturacionElectronica
      'Cta. Cte. CLIENTES
      chbUtilizaModuloCtaCteClientes.Checked = Reglas.Publicos.TieneModuloCuentaCorrienteClientes
      'Cta. Cte. PROVEEDORES
      chbUtilizaModuloCtaCteProveedores.Checked = Reglas.Publicos.TieneModuloCuentaCorrienteProveedores
      'Caja
      chbUtilizaModuloCaja.Checked = Reglas.Publicos.TieneModuloCaja
      'Banco
      chbUtilizaModuloBanco.Checked = Reglas.Publicos.TieneModuloBanco
      'Pedidos
      chbUtilizaModuloPedidos.Checked = Reglas.Publicos.TieneModuloPedidos
      'Pedidos Proveedores
      chbUtilizaModuloPedidosProv.Checked = Reglas.Publicos.TieneModuloPedidosProv
      'Produccion
      chbUtilizaModuloProduccion.Checked = Reglas.Publicos.TieneModuloProduccion
      'Contabilidad
      chbUtilizaModuloContabilidad.Checked = Reglas.Publicos.TieneModuloContabilidad
      'Cargos
      chbUtilizaModuloCargos.Checked = Reglas.Publicos.TieneModuloCargos


      'Control de Licencias
      chbUtilizaModuloControlLicencias.Checked = Reglas.Publicos.TieneModuloControlDeLicencias
      'Fichas
      chbUtilizaModuloFichas.Checked = Reglas.Publicos.TieneModuloFichas
      'Sueldos
      chbUtilizaModuloSueldos.Checked = Reglas.Publicos.TieneModuloSueldos
      'Expensas
      chbUtilizaModuloExpensas.Checked = Reglas.Publicos.TieneModuloExpensas
      'Contratistas
      chbUtilizaModuloContratistas.Checked = Reglas.Publicos.TieneModuloContratistas
      'Alquileres
      chbUtilizaModuloAlquileres.Checked = Reglas.Publicos.TieneModuloAlquiler
      'Extras Sinergia
      chbExtrasSinergia.Checked = Reglas.Publicos.ExtrasSinergia
      'MRP
      chbUtilizaModuloMRP.Checked = Reglas.Publicos.TieneModuloMRP

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      Dim parms = New Reglas.ParametrosModulos()

      'Facturacion Electronica
      parms.TieneModuloFacturacionElectronica = chbUtilizaModuloFactElectronica.Checked
      'Cta. Cte. CLIENTES
      parms.TieneModuloCuentaCorrienteClientes = chbUtilizaModuloCtaCteClientes.Checked
      'Cta. Cte. PROVEEDORES
      parms.TieneModuloCuentaCorrienteProveedores = chbUtilizaModuloCtaCteProveedores.Checked
      'Caja
      parms.TieneModuloCaja = chbUtilizaModuloCaja.Checked
      'Banco
      parms.TieneModuloBanco = chbUtilizaModuloBanco.Checked
      'Pedidos
      parms.TieneModuloPedidos = chbUtilizaModuloPedidos.Checked
      'Pedidos Proveedores
      parms.TieneModuloPedidosProv = chbUtilizaModuloPedidosProv.Checked
      'Produccion
      parms.TieneModuloProduccion = chbUtilizaModuloProduccion.Checked
      'Contabilidad
      parms.TieneModuloContabilidad = chbUtilizaModuloContabilidad.Checked
      'Cargos
      parms.TieneModuloCargos = chbUtilizaModuloCargos.Checked

      'Control de Licencias
      parms.TieneModuloControlDeLicencias = chbUtilizaModuloControlLicencias.Checked
      'Fichas
      parms.TieneModuloFichas = chbUtilizaModuloFichas.Checked
      'Sueldos
      parms.TieneModuloSueldos = chbUtilizaModuloSueldos.Checked
      'Expensas
      parms.TieneModuloExpensas = chbUtilizaModuloExpensas.Checked
      'Contratistas
      parms.TieneModuloContratistas = chbUtilizaModuloContratistas.Checked
      'Alquileres
      parms.TieneModuloAlquiler = chbUtilizaModuloAlquileres.Checked
      'Extras Sinergia
      parms.ExtrasSinergia = chbExtrasSinergia.Checked
      'MRP
      parms.TieneModuloMRP = chbUtilizaModuloMRP.Checked


      Dim valor = New Reglas.ParametrosModulosConverter().ConvertToString(parms)
      ActualizarParametroTexto(Entidades.Parametro.Parametros.TIENEMODULOS, valor, Nothing, "Tiene Modulos")
   End Sub

End Class