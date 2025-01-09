Imports Aspose.Words

Public Class ucConfAppMovilesURLsBase

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboDesdeEnum(cmbPedidosWebFormato, GetType(Entidades.PreVenta.FormatoWebPeridos), , True)

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)
      Dim rFunc = New Reglas.Funciones()

      '########################### tbpPedidosCobranzas ########################### 
      'Simovil Cobranzas
      txtSimovilCobranzaURLBase.Text = Reglas.Publicos.SimovilCobranzaURLBase
      txtSimovilGestionURLBase.Text = Reglas.Publicos.SimovilGestionURLBase

      'Pedidos Clientes - WEB
      'GET
      txtPedidosURLWebGET.Text = Reglas.Publicos.PedidosURLWebGET
      cmbPedidosWebFormato.SelectedValue = Reglas.Publicos.PedidosWebFormato
      'PUT
      txtPedidosURLWebPUT.Text = Reglas.Publicos.PedidosURLWebPUT


      '########################### tbpSimovilOficina ########################### 
      txtSimovilOficinaURLProduccion.Text = Reglas.Publicos.SimovilOficinaURLProduccion
      txtSimovilOficinaURLTesting.Text = Reglas.Publicos.SimovilOficinaURLTesting


      '########################### tbpOtros ########################### 
      'Simovil Turnos
      txtSimovilGestionTurnoURLBase.Text = Reglas.Publicos.SimovilGestionTurnosURLBase
      txtSimovilTurnoURLBase.Text = Reglas.Publicos.SimovilTurnosURLBase

      'Simovil Soporte
      txtSimovilSoporteURLBase.Text = Reglas.Publicos.SimovilSoporteURLBase

      'Simovil Turismo
      txtSimovilTurismoURLBase.Text = Reglas.Publicos.SimovilTurismoURLBase

      '########################### tbpConcesionarios ########################### 
      'Concesionarios Moviles
      txtConcesionariosURLBase.Text = Reglas.Publicos.ConcesionarioMovilURLBase
      txtConcesionarioUsuarioMovil.Text = Reglas.Publicos.ConcesionarioMovilUsuario
      txtConcesionarioClaveMovil.Text = Reglas.Publicos.ConcesionarioMovilClave

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      '########################### tbpPedidosCobranzas ########################### 
      'Simovil Cobranzas
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILCOBRANZAURLBASE, txtSimovilCobranzaURLBase, Nothing, lblSimovilCobranzaURLBase.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILGESTIONURLBASE, txtSimovilGestionURLBase, Nothing, lblSimovilGestionURLBase.Text)

      'Pedidos Clientes - WEB
      'GET
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSURLWEBGET, txtPedidosURLWebGET, Nothing, lblPedidosURLWebGET.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.PEDIDOSWEBFORMATO, cmbPedidosWebFormato, Nothing, lblPedidosWebFormato.Text)
      'PUT
      ActualizarParametro(Entidades.Parametro.Parametros.PEDIDOSURLWEBPUT, txtPedidosURLWebPUT, Nothing, lblPedidosURLWebPUT.Text)


      '########################### tbpSimovilOficina ########################### 
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILOFICINAURLPRODUCCION, txtSimovilOficinaURLProduccion, Nothing, lblSimovilOficinaURLProduccion.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILOFICINAURLTESTING, txtSimovilOficinaURLTesting, Nothing, lblSimovilOficinaURLTesting.Text)


      '########################### tbpOtros ########################### 
      'Simovil Turnos
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILGESTIONTURNOSURLBASE, txtSimovilGestionTurnoURLBase, Nothing, lblSimovilCobranzaURLBase.Text + "Turnos")
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILTURNOSURLBASE, txtSimovilTurnoURLBase, Nothing, lblSimovilTurnoURLBase.Text)

      'Simovil Soporte
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILSOPORTEURLBASE, txtSimovilSoporteURLBase, Nothing, lblSimovilSoporteURLBase.Text)

      'Simovil Turismo
      ActualizarParametro(Entidades.Parametro.Parametros.SIMOVILTURISMOURLBASE, txtSimovilTurismoURLBase, Nothing, lblSimovilTurismoURLBase.Text)

      'Concesionarios Moviles
      ActualizarParametro(Entidades.Parametro.Parametros.CONCESIONARIOMOVILURLBASE, txtConcesionariosURLBase, Nothing, lblConcesionariosURLBase.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CONCESIONARIOMOVILUSUARIO, txtConcesionarioUsuarioMovil, Nothing, lblConcesionarioUsuarioMovil.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CONCESIONARIOMOVILCLAVE, txtConcesionarioClaveMovil, Nothing, lblConcesionarioClaveMovil.Text)

   End Sub

End Class