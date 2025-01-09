Public Class SincronizacionBajadaTiendaWeb

#Region "Properties"
   Private _resumenDataSource As List(Of Resumen)
   Private _controles As Object()
#End Region

#Region "Eventos"
   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      _resumenDataSource = New List(Of Resumen)
      ugResumen.DataSource = _resumenDataSource
      tssInfo.Text = Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeURLBase

      '# Controles en pantalla
      _controles = {btnSincronizar, tsbRefrescar, chbBajarTodos}
   End Sub
   Private Sub btnSincronizar_Click(sender As Object, e As EventArgs) Handles btnSincronizar.Click
      TryCatched(
      Sub()
         RefrescarPantalla()
         InicializaBackgroundWorker()
      End Sub)
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarPantalla())
   End Sub

#End Region

#Region "Métodos"
   Private Sub RefrescarPantalla()
      _resumenDataSource.Clear()
      ugResumen.Rows.Refresh(RefreshRow.ReloadData)
      ugResumen.Rows.Refresh(RefreshRow.RefreshDisplay)

      chbSincronizaTiendaNube.Checked = Not String.IsNullOrEmpty(Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeToken)
      chbSincronizaMercadoLibre.Checked = Not String.IsNullOrEmpty(Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreToken)
      chbSincronizaArborea.Checked = Not String.IsNullOrEmpty(Reglas.Publicos.TiendasWeb.Arborea.ArboreaUsuarioToken)

      chbSincronizaTiendaNube.Enabled = chbSincronizaTiendaNube.Checked
      chbSincronizaMercadoLibre.Enabled = chbSincronizaMercadoLibre.Checked
      chbSincronizaArborea.Enabled = chbSincronizaArborea.Checked
   End Sub
   Private Sub HabilitarControlers(habilitar As Boolean)
      For Each ctrl As Object In _controles
         If TypeOf (ctrl) Is Control Then
            DirectCast(ctrl, Control).Enabled = habilitar
         ElseIf TypeOf (ctrl) Is ToolStripItem Then
            DirectCast(ctrl, ToolStripItem).Enabled = habilitar
         End If
      Next
   End Sub

   Private Class BkwParams
      Public Property BajarTodos As Boolean
      Public Property SincronizaTiendaTiendaNube As Boolean
      Public Property SincronizaTiendaMercadoLibre As Boolean
      Public Property SincronizaTiendaArborea As Boolean
   End Class
   Public Sub InicializaBackgroundWorker()
      HabilitarControlers(False)
      If bwSincronizacion IsNot Nothing Then
         Dim param = New BkwParams With
                           {
                              .BajarTodos = chbBajarTodos.Checked,
                              .SincronizaTiendaTiendaNube = chbSincronizaTiendaNube.Checked,
                              .SincronizaTiendaMercadoLibre = chbSincronizaMercadoLibre.Checked,
                              .SincronizaTiendaArborea = chbSincronizaArborea.Checked
                           }
         bwSincronizacion.RunWorkerAsync(param)
      Else
         bwSincronizacion_RunWorkerCompleted(Nothing, Nothing)
      End If
   End Sub

   Private Sub MostrarEstado(estado As Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebEstadoEventArgs)
      Dim resumen = _resumenDataSource.FirstOrDefault(Function(x) x.Nombre = estado.Nombre And x.Estado = estado.Estado.ToString())
      If resumen Is Nothing Then
         resumen = New Resumen() With {.Nombre = estado.Nombre,
                                       .Estado = estado.Estado.ToString(),
                                       .NroRegistro = estado.TotalRegistrosSubidos,
                                       .TotalRegistros = estado.TotalRegistros,
                                       .Metodo = estado.Metodo.ToString()}
         _resumenDataSource.Add(resumen)
      Else
         resumen.Estado = estado.Estado.ToString()
         resumen.Nombre = estado.Nombre
         resumen.NroRegistro = estado.TotalRegistrosSubidos
         resumen.TotalRegistros = estado.TotalRegistros
         resumen.Metodo = estado.Metodo.ToString()
      End If

      ugResumen.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
      ugResumen.Rows.Refresh(UltraWinGrid.RefreshRow.RefreshDisplay)
   End Sub

   Private Sub MostrarAvance(avance As Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebEventArgs)
      Me.lblInformacion.Text = avance.Mensaje
   End Sub

   Private Sub ProcesoFinalizado(avance As Reglas.ServiciosRest.TiendasWeb.ProcesoFinalizadoEventArgs)
      Dim msg As StringBuilder = New StringBuilder
      With msg
         .AppendFormatLine("{0}", avance.Mensaje)
         .AppendFormatLine("Nuevos Pedidos: {0}", avance.Correctos)
         If avance.NuevosClientes > 0 Then .AppendFormatLine("Nuevos Clientes: {0}", avance.NuevosClientes)
         .AppendFormatLine("Pedidos con Error: {0}", avance.ConError)
         If avance.ConError > 0 Then .AppendLine().AppendFormatLine("Ver el Administrador de Pedidos Tiendas Web para el detalle de los errores.")
      End With

      ShowMessage(msg.ToString())
   End Sub

#End Region

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub bwSincronizacion_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwSincronizacion.DoWork
      Dim param = DirectCast(e.Argument, BkwParams)
      Dim ProcesoTW As Entidades.Publicos.SiNo = Entidades.Publicos.SiNo.NO


      '############################################ 
      '#       Proceso de Bajada de Pedidos       #
      '############################################ 

      '-- Tienda Nube.- --
      If param.SincronizaTiendaTiendaNube Then
         If Not String.IsNullOrEmpty(Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeToken) Then
            Try
               Dim tiendaNube = New Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaNube()

               '# Estos handlers son los encargados de escuchar los eventos de la regla.
               '# Cuando se disparen dichos eventos en la regla, estos van a disparar el evento ProgressChanged del BW.
               AddHandler tiendaNube.Avance, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
               AddHandler tiendaNube.Estado, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)

               Reglas.Publicos.VerificaConfiguracionRegional()
               tiendaNube.BajarInformacion(param.BajarTodos)
               '-- Marca Proceso de Tienda Nube.- --
               ProcesoTW = Entidades.Publicos.SiNo.SI
            Catch ex As Exception
               bwSincronizacion.ReportProgress(0, ex)
               bwSincronizacion.CancelAsync()
            End Try

            '################################################# 
            '#       Proceso de Importación de Pedidos       #
            '################################################# 
            Try
               '-- Verifica Marca de Proceso Tiendas Web.- --
               If ProcesoTW = Entidades.Publicos.SiNo.SI Then
                  Dim importacionPedidos = New Reglas.ServiciosRest.TiendasWeb.ImportacionPedidosTiendasWeb()

                  '# Estos handlers son los encargados de escuchar los eventos de la regla.
                  '# Cuando se disparen dichos eventos en la regla, estos van a disparar el evento ProgressChanged del BW.
                  AddHandler importacionPedidos.Avance, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
                  AddHandler importacionPedidos.Estado, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
                  AddHandler importacionPedidos.ProcesoFinalizado, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
                  '-- Verifica Configuracion REgional.- --
                  Reglas.Publicos.VerificaConfiguracionRegional()
                  '-- Ejecuta Proceso de Importacion de Pedidos.- --
                  importacionPedidos.Importar(Entidades.TiendasWeb.TIENDANUBE)
               End If
            Catch ex As Exception
               bwSincronizacion.ReportProgress(0, ex)
               bwSincronizacion.CancelAsync()
            End Try

         End If
      End If

      '-- Mercado Libre.- -REQ-30522.- --
      If param.SincronizaTiendaMercadoLibre Then
         If Not String.IsNullOrEmpty(Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreToken) Then
            Try

               Dim mercadolibre = New Reglas.ServiciosRest.TiendasWeb.SincronizacionMercadoLibre()
               '# Estos handlers son los encargados de escuchar los eventos de la regla.
               '# Cuando se disparen dichos eventos en la regla, estos van a disparar el evento ProgressChanged del BW.
               AddHandler mercadolibre.Avance, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
               AddHandler mercadolibre.Estado, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)

               '-- Recupero Fecha de Token.- --
               If CDate(Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreFechaRefreshTokenML) < DateTime.Now() Then
                  '-- Asigna Fecha del Dia.- --
                  Dim FechaToken = DateTime.Now()
                  '-- Sincronizacion .- 
                  Dim sincML As New Reglas.ServiciosRest.TiendasWeb.SincronizacionMercadoLibre()
                  '-- Ejecuto autorizacion sobre Mercado Libre - Obtengo Valor Token.- --
                  Dim token = sincML.GetRefreshToken(Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCodigoAppIdML,
                                                     Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCodigoSecretML,
                                                     Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCodigoRefreshTokenML)
                  '-- Actualiza Fecha de Expiracion.- --
                  FechaToken = FechaToken.AddSeconds(token.expires_in)
                  '-- Proceso de Gabado de Datos al sistema.- --
                  sincML.GuardarToken(token.access_token, FechaToken.ToString(), token.refresh_token, token.user_id)
               End If

               '-- comprueba Configuracion Regional.- --
               Reglas.Publicos.VerificaConfiguracionRegional()
               '-- Ejecuta proceso de Bajada de Pedidos.- --
               mercadolibre.BajarInformacion(param.BajarTodos)
               '-- Marca Proceso de Mercado Libre.- --
               ProcesoTW = Entidades.Publicos.SiNo.SI
            Catch ex As Exception
               '-- Marca Proceso de Mercado Libre.- --
               ProcesoTW = Entidades.Publicos.SiNo.NO
               '--
               bwSincronizacion.ReportProgress(0, ex)
               bwSincronizacion.CancelAsync()
            End Try
            '################################################# 
            '#       Proceso de Importación de Pedidos       #
            '################################################# 
            Try
               '-- Verifica Marca de Proceso Tiendas Web.- --
               If ProcesoTW = Entidades.Publicos.SiNo.SI Then
                  Dim importacionPedidos = New Reglas.ServiciosRest.TiendasWeb.ImportacionPedidosTiendasWeb()

                  '# Estos handlers son los encargados de escuchar los eventos de la regla.
                  '# Cuando se disparen dichos eventos en la regla, estos van a disparar el evento ProgressChanged del BW.
                  AddHandler importacionPedidos.Avance, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
                  AddHandler importacionPedidos.Estado, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
                  AddHandler importacionPedidos.ProcesoFinalizado, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
                  '-- Verifica Configuracion REgional.- --
                  Reglas.Publicos.VerificaConfiguracionRegional()
                  '-- Ejecuta Proceso de Importacion de Pedidos.- --
                  importacionPedidos.Importar(Entidades.TiendasWeb.MERCADOLIBRE)
               End If
            Catch ex As Exception
               bwSincronizacion.ReportProgress(0, ex)
               bwSincronizacion.CancelAsync()
            End Try

         End If
      End If

      '-- Arborea.- -REQ-31721.- --
      If param.SincronizaTiendaArborea Then
         If Not String.IsNullOrEmpty(Reglas.Publicos.TiendasWeb.Arborea.ArboreaUsuarioToken) Then
            Try

               Dim arborea = New Reglas.ServiciosRest.TiendasWeb.SincronizacionArborea()
               '# Estos handlers son los encargados de escuchar los eventos de la regla.
               '# Cuando se disparen dichos eventos en la regla, estos van a disparar el evento ProgressChanged del BW.
               AddHandler arborea.Avance, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
               AddHandler arborea.Estado, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)

               '-- comprueba Configuracion Regional.- --
               Reglas.Publicos.VerificaConfiguracionRegional()
               '-- Ejecuta proceso de Bajada de Pedidos.- --
               arborea.SincronizacionBajada(param.BajarTodos)

               '-- Marca Proceso de Arborea.- --
               ProcesoTW = Entidades.Publicos.SiNo.SI
            Catch ex As Exception
               '-- Marca Proceso de Mercado Libre.- --
               ProcesoTW = Entidades.Publicos.SiNo.NO
               '--
               bwSincronizacion.ReportProgress(0, ex)
               bwSincronizacion.CancelAsync()
            End Try
            '################################################# 
            '#       Proceso de Importación de Pedidos       #
            '################################################# 
            Try
               '-- Verifica Marca de Proceso Tiendas Web.- --
               If ProcesoTW = Entidades.Publicos.SiNo.SI Then
                  Dim importacionPedidos = New Reglas.ServiciosRest.TiendasWeb.ImportacionPedidosTiendasWeb()

                  '# Estos handlers son los encargados de escuchar los eventos de la regla.
                  '# Cuando se disparen dichos eventos en la regla, estos van a disparar el evento ProgressChanged del BW.
                  AddHandler importacionPedidos.Avance, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
                  AddHandler importacionPedidos.Estado, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
                  AddHandler importacionPedidos.ProcesoFinalizado, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
                  '-- Verifica Configuracion REgional.- --
                  Reglas.Publicos.VerificaConfiguracionRegional()
                  '-- Ejecuta Proceso de Importacion de Pedidos.- --
                  importacionPedidos.Importar(Entidades.TiendasWeb.ARBOREA)
               End If
            Catch ex As Exception
               bwSincronizacion.ReportProgress(0, ex)
               bwSincronizacion.CancelAsync()
            End Try

         End If
      End If

   End Sub

   Private Sub bwSincronizacion_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwSincronizacion.RunWorkerCompleted
      HabilitarControlers(True)
   End Sub

   Private Sub bwSincronizacion_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bwSincronizacion.ProgressChanged

      '# Recibiendo la información disparada por el primer evento dentro de la regla en "e", puedo realizar actualizaciones en la pantalla

      '# Error handler
      If TypeOf (e.UserState) Is Exception Then
         Me.lblInformacion.Text = String.Empty
         ShowError(DirectCast(e.UserState, Exception))
      End If
      '------------------------------------------
      If TypeOf (e.UserState) Is Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebEstadoEventArgs Then
         MostrarEstado(DirectCast(e.UserState, Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebEstadoEventArgs))
      End If
      '------------------------------------------
      If TypeOf (e.UserState) Is Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebEventArgs Then
         MostrarAvance(DirectCast(e.UserState, Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebEventArgs))
      End If
      If TypeOf (e.UserState) Is Reglas.ServiciosRest.TiendasWeb.ProcesoFinalizadoEventArgs Then
         ProcesoFinalizado(DirectCast(e.UserState, Reglas.ServiciosRest.TiendasWeb.ProcesoFinalizadoEventArgs))
      End If

   End Sub

   Public Class Resumen
      Public Property Estado As String
      Public Property Metodo As String
      Public Property Nombre As String
      Public Property NroRegistro As Long
      Public Property TotalRegistros As Long
   End Class

End Class