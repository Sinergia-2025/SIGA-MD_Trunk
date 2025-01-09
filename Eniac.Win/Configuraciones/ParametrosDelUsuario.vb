Public Class ParametrosDelUsuario
#Region "Campos"

   Private _ucConfig As List(Of ucConfBase)

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            Reglas.ParametrosCache.Instancia.LimpiarCache()
            Reglas.ParametrosCache.Instancia.CargarTodos()

            _ucConfig = New List(Of ucConfBase)() From
                              {UcConfDatosEmpresa1, UcConfFichas1, UcConfPedidosPedidos1, UcConfPedidosWeb1, UcConfPedidosVisualizacion1,
                               UcConfPedidosProvPedidosProv1, UcConfPedidosProvVisualizacion1, UcConfPedidosProvRequerimiento1,
                               UcConfVentas11, UcConfVentas21, UcConfVentas31, UcConfVentas41,
                               UcConfVentasCajero1, UcConfVentasFacturacionRapida1, UcConfVentasVisualizacion1, UcConfVentasImpresion1, UcConfVentasExportacion1,
                               UcConfFacturacionElectronica1, UcConfCompras1, UcConfStock1, UcConfPrecios1, UcConfPrecios21,
                               UcConfCtaCteClienteGeneral1, UcConfCtaCteClienteGeneral21, UcConfCtaCteClienteDebitoAutomatico1, UcConfCtaCteClienteInformes1,
                               UcConfCargos1, UcConfCRMGenerales1, UcConfCRMEnvioCorreo1,
                               UcConfArchivos1, UcConfArchivosClientes1, UcConfArchivosProductos1, UcConfArchivosWeb1, UcConfArchivosSync1,
                               UcConfCtaCteProv1, UcConfCaja1, UcConfBanco1, UcConfProcesos1, UcConfSueldos1,
                               UcConfRMA1, UcConfProduccion1, UcConfContabilidad1, UcConfAFIP1, UcConfTurnos1, UcConfEstadisticas1,
                               UcConfAppMovilesConfiguraciones1, UcConfLogistica1, UcConfAppMovilesURLsBase1, UcConfAppMovilesSoporte1, UcConfAppMovilesFTP1,
                               UcConfCalidad1, UcConfTurismo1, UcConfTiendaNube1, UcConfMercadoLibre1, UcConfGenerales1, UcConfArborea1, UcConfMRP1}

            tbcParametros.SelectedTab = tbpArchivos
            tbcArchivos.SelectedTab = tbpArchivosSync

            tbcArchivos.SelectedTab = tbpArchivosGeneral
            tbcParametros.SelectedTab = tbpDatosEmpresa

            _ucConfig.ForEach(Sub(uc) uc.Inicializar())

            CargarParametros()

            Dim rFunc = New Reglas.Funciones()

            If Not Reglas.Publicos.TieneModuloCaja Then tbcParametros.TabPages.Remove(tbpCaja)

            If Not Reglas.Publicos.TieneModuloBanco Then tbcParametros.TabPages.Remove(tbpBanco)

            If Not Reglas.Publicos.TieneModuloCuentaCorrienteClientes Then tbcParametros.TabPages.Remove(tbpCtaCteClientes)

            If Not Reglas.Publicos.TieneModuloCuentaCorrienteProveedores Then tbcParametros.TabPages.Remove(tbpCtaCteProveedores)

            If Not Reglas.Publicos.TieneModuloFacturacionElectronica Then tbcParametros.TabPages.Remove(tbpFactElectronica)

            If Not Reglas.Publicos.TieneModuloSueldos Then tbcParametros.TabPages.Remove(tbpSueldos)

            If Not Reglas.Publicos.TieneModuloProduccion Then tbcParametros.TabPages.Remove(tbpProduccion)

            If Not Reglas.Publicos.TieneModuloContabilidad Then tbcParametros.TabPages.Remove(tbpContabilidad)

            If Not Reglas.Publicos.TieneModuloFichas Then tbcParametros.TabPages.Remove(tbpFichas)

            If Not Reglas.Publicos.TieneModuloCargos Then tbcParametros.TabPages.Remove(tbpCargos)

            If Not rFunc.ExisteFuncion("CRMNovedadesABMSERVICE") Then tbcParametros.TabPages.Remove(tbpRMA)

            If Not rFunc.ExisteFuncion("TURISMO") Then tbcParametros.TabPages.Remove(tbpTurismo)

            If Not Reglas.Publicos.TieneModuloMRP Then tbcParametros.TabPages.Remove(tbpMRP)

         End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         Grabar()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(
         Sub()
            If ValidaDetalle() Then
               Grabar()
               ShowMessage("Para que se apliquen estos seteos debe salir y volver a ingresar a la aplicacion.")
            End If
         End Sub,
         onFinallyAction:=Sub(owner) Reglas.ParametrosCache.Instancia.LimpiarCache())
   End Sub


   Private Sub lnkSimovilURLBase_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSimovilURLBase_01.LinkClicked, lnkSimovilURLBase_02.LinkClicked, lnkSimovilURLBase_03.LinkClicked, lnkSimovilURLBase_04.LinkClicked
      TryCatched(
         Sub()
            tbcParametros.SelectedTab = tbpAplicacionesMoviles
            tbcAplicacionesMoviles.SelectedTab = tbpAplicacionesMoviles_Urls
         End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarParametros()
      Try
         Dim sw = New Stopwatch()
         sw.Start()

         _ucConfig.ForEach(Sub(uc) uc.CargarParametros())

         sw.Stop()
      Catch ex As Exception
         Dim err = New StringBuilder()
         With err
            .AppendFormatLine("Error cargando Parametros: {0}", ex.Message).AppendLine()
            .AppendFormatLine("Stack Trace: {0}", ex.StackTrace)
         End With
         ShowMessage(err.ToString())
      End Try
   End Sub

   Private Sub LocateControlOnTabs(uc As Control)
      uc.LocateControlOnTabs(Sub(tc, tp) tc.SelectTab(tp))
   End Sub

   Private Function ValidaDetalle() As Boolean
      Dim stb = New StringBuilder()
      Dim algunError As Boolean = False
      Dim debeReposicionarConError As Boolean = True

      _ucConfig.ForEach(
         Sub(uc)
            If uc.ValidarParametros(stb) Then
               algunError = True
               If debeReposicionarConError Then
                  LocateControlOnTabs(uc)
                  debeReposicionarConError = False
               End If
            End If
         End Sub)

      If algunError Then
         ShowMessage(stb.ToString())
      End If
      Return Not algunError
   End Function

   Private Sub Grabar()
      Reglas.ParametrosCache.Instancia().CargarTodos()
      Reglas.ParametrosCache.Editor.Instancia().Clear()

      _ucConfig.ForEach(Sub(uc) uc.GrabarParametros())

      Reglas.ParametrosCache.Editor.Instancia().Commit()
   End Sub

   Private Sub lnkRoelaSirPlus_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRoelaSirPlus.LinkClicked
      TryCatched(
         Sub()
            tbcParametros.SelectedTab = tbpCtaCteClientes
            tbcCtaCteClientes.SelectedTab = tbpCtaCteClientes_DebitoAutomatico
         End Sub)

   End Sub

#End Region

End Class