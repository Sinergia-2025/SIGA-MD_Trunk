Public Class SincronizacionSubidaTiendaWeb

#Region "Properties"
   Private _resumenDataSource As List(Of Resumen)
   Private _detallesErrorDataSource As List(Of DetalleErrores)
   Private _controles As Object()
   Public _TiendaWeb As Entidades.TiendasWeb
#End Region

   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      _resumenDataSource = New List(Of Resumen)()
      ugResumen.DataSource = _resumenDataSource
      _detallesErrorDataSource = New List(Of DetalleErrores)()
      ugDetallesError.DataSource = _detallesErrorDataSource

      '# Controles en pantalla
      _controles = {btnSincronizar, tsbRefrescar, chbReenviarTodos, pnlTiendas, pnlModulos}
   End Sub

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() pnlModulos.Visible = New Reglas.Usuarios().TienePermisos("SincronizacionSubidaAdmin"))
      TryCatched(Sub() RefrescarDatos())

   End Sub
#End Region

#Region "Eventos"
   Private Sub btnSincronizar_Click(sender As Object, e As EventArgs) Handles btnSincronizar.Click
      TryCatched(Sub() InicializaBackgroundWorker())
   End Sub
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatos())
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

#Region "Eventos Background Worker"
   Private Sub bwSincronizacion_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwSincronizacion.DoWork
      Dim param = DirectCast(e.Argument, BkwParams)

      Try
         Reglas.Publicos.VerificaConfiguracionRegional()

         'Dim rProductos = New Reglas.Productos()
         'rProductos.CalculaProductosOfertas()

      Catch ex As Exception
         bwSincronizacion.ReportProgress(0, ex)
         bwSincronizacion.CancelAsync()
      End Try
      '-- Tienda Nube.- --
      If param.SincronizaTiendaTiendaNube Then
         Try
            '-- Define Tipo de Proceso.- --
            _TiendaWeb = Entidades.TiendasWeb.TIENDANUBE
            bwSincronizacion.ReportProgress(0, Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeURLBase)

            Dim tiendaNube = New Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaNube()
            Dim PublicarPrecioPorEmbalaje As Boolean = Reglas.Publicos.ProductoPrecioPorEmbalajeTN

            '# Estos handlers son los encargados de escuchar los eventos de la regla.
            '# Cuando se disparen dichos eventos en la regla, estos van a disparar el evento ProgressChanged del BW.
            AddHandler tiendaNube.Avance, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
            AddHandler tiendaNube.Estado, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
            AddHandler tiendaNube.ProcesoFinalizado, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
            AddHandler tiendaNube.InformarError, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)

            tiendaNube.SubirInformacion(param.ReenviarTodos, param.SincronizaCategorias, param.SincronizaProductos, PublicarPrecioPorEmbalaje)

         Catch ex As Exception
            bwSincronizacion.ReportProgress(0, ex)
            bwSincronizacion.CancelAsync()
         End Try
      End If
      '-- Mercado Libre.- --
      If param.SincronizaTiendaMercadoLibre Then
         Try
            '-- Define Tipo de Proceso.- --
            _TiendaWeb = Entidades.TiendasWeb.MERCADOLIBRE
            bwSincronizacion.ReportProgress(0, Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreURLBase)
            '--REQ-30521.- --
            Dim MercadoLib = New Reglas.ServiciosRest.TiendasWeb.SincronizacionMercadoLibre()

            AddHandler MercadoLib.Avance, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
            AddHandler MercadoLib.Estado, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
            AddHandler MercadoLib.ProcesoFinalizado, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
            AddHandler MercadoLib.InformarError, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)

            '----------------

            '--REQ-30521.- --
            '-- Recupero Fecha de Token.- --
            If Date.Parse(Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreFechaRefreshTokenML) < Date.Now() Then
               '-- Asigna Fecha del Dia.- --
               Dim FechaToken = Date.Now()
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
            Dim PublicarPrecioPorEmbalaje As Boolean = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibrePrecioPorEmbalaje

            '-- Proceso de Subida de Datos.
            MercadoLib.SubirInformacion(param.ReenviarTodos, param.SincronizaProductos, PublicarPrecioPorEmbalaje)

         Catch ex As Exception
            bwSincronizacion.ReportProgress(0, ex)
            bwSincronizacion.CancelAsync()
         End Try
      End If
      '-- Arborea.- --
      If param.SincronizaTiendaArborea Then
         Try
            '-- Define Tipo de Proceso.- --
            _TiendaWeb = Entidades.TiendasWeb.ARBOREA

            Dim PublicarPrecioPorEmbalaje As Boolean = Reglas.Publicos.TiendasWeb.Arborea.ArboreaPrecioPorEmbalaje

            bwSincronizacion.ReportProgress(0, Reglas.Publicos.TiendasWeb.Arborea.ArboreaURLBase)

            Dim Arborea = New Reglas.ServiciosRest.TiendasWeb.SincronizacionArborea()

            AddHandler Arborea.Avance, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
            AddHandler Arborea.Estado, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
            AddHandler Arborea.ProcesoFinalizado, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)
            AddHandler Arborea.InformarError, Sub(sender1, e1) bwSincronizacion.ReportProgress(0, e1)

            '-- Proceso de Subida de Datos.
            Arborea.SincronizacionSubida(param.ReenviarTodos, param.SincronizaClientes, param.SincronizaCategorias,
                                         param.SincronizaProductos, param.SincronizaPrecios, PublicarPrecioPorEmbalaje)
         Catch ex As Exception
            bwSincronizacion.ReportProgress(0, ex)
            bwSincronizacion.CancelAsync()
         End Try
      End If

   End Sub

   Private Sub bwSincronizacion_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwSincronizacion.RunWorkerCompleted
      HabilitarControlers(True)
   End Sub

   Private Sub bwSincronizacion_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bwSincronizacion.ProgressChanged
      '# Recibiendo la información disparada por el primer evento dentro de la regla en "e", puedo realizar actualizaciones en la pantalla
      If TypeOf (e.UserState) Is Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebEventArgs Then
         MostrarAvance(DirectCast(e.UserState, Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebEventArgs))

      ElseIf TypeOf (e.UserState) Is Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebEstadoEventArgs Then
         MostrarEstado(DirectCast(e.UserState, Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebEstadoEventArgs))

      ElseIf TypeOf (e.UserState) Is Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebProcesoFinalizadoEventArgs Then
         ProcesoFinalizado(DirectCast(e.UserState, Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebProcesoFinalizadoEventArgs))

      ElseIf TypeOf (e.UserState) Is Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebErrorEventArgs Then
         MostrarError(DirectCast(e.UserState, Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebErrorEventArgs))

      ElseIf TypeOf (e.UserState) Is Exception Then
         tssInfo.Text = String.Empty
         ShowError(DirectCast(e.UserState, Exception))
      End If
   End Sub
#End Region
#End Region

#Region "Métodos"
   Private Sub RefrescarDatos()
      tssInfo.Text = String.Empty
      chbReenviarTodos.Checked = False
      _resumenDataSource.Clear()
      _detallesErrorDataSource.Clear()
      ugResumen.Rows.Refresh(RefreshRow.ReloadData)
      ugResumen.Rows.Refresh(RefreshRow.RefreshDisplay)
      ugResumen.Rows.Refresh(RefreshRow.FireInitializeRow)

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

   Public Sub InicializaBackgroundWorker()
      HabilitarControlers(False)
      _resumenDataSource.Clear()
      ugResumen.Rows.Refresh(RefreshRow.ReloadData)
      ugResumen.Rows.Refresh(RefreshRow.RefreshDisplay)
      ugResumen.Rows.Refresh(RefreshRow.FireInitializeRow)
      If bwSincronizacion IsNot Nothing Then
         Dim param = New BkwParams With
                           {
                              .ReenviarTodos = chbReenviarTodos.Checked,
                              .SincronizaTiendaTiendaNube = chbSincronizaTiendaNube.Checked,
                              .SincronizaTiendaMercadoLibre = chbSincronizaMercadoLibre.Checked,
                              .SincronizaTiendaArborea = chbSincronizaArborea.Checked,
                              .SincronizaClientes = chbClientes.Checked,
                              .SincronizaCategorias = chbCategorias.Checked,
                              .SincronizaProductos = chbProductos.Checked,
                              .SincronizaPrecios = chbPrecios.Checked
                           }
         bwSincronizacion.RunWorkerAsync(param)
      Else
         bwSincronizacion_RunWorkerCompleted(Nothing, Nothing)
      End If
   End Sub

   Private Sub ProcesoFinalizado(avance As Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebProcesoFinalizadoEventArgs)
      Dim msg = New StringBuilder()
      With msg
         .AppendFormatLine("{0}", avance.Mensaje)
         .AppendFormatLine("Nuevos Elementos: {0}", avance.Nuevos)
         If avance.Actualizados > 0 Then .AppendFormatLine("Elementos Actualizados: {0}", avance.Actualizados)
         If _detallesErrorDataSource.Any() Then
            .AppendFormatLine("Se encontraron {0} errores", _detallesErrorDataSource.Count)
         End If
      End With

      ShowMessage(msg.ToString())
   End Sub
   Private Sub MostrarError(estado As Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebErrorEventArgs)
      Dim Resumen = New DetalleErrores() With
                     {
                        .Tienda = estado.Tienda,
                        .Mensaje = estado.Mensaje,
                        .ElementoTransmitido = estado.ElementoTransmitido
                     }
      _detallesErrorDataSource.Add(Resumen)

      ugDetallesError.Rows.Refresh(RefreshRow.ReloadData)
      ugDetallesError.Rows.Refresh(RefreshRow.RefreshDisplay)
      ugDetallesError.Rows.Refresh(RefreshRow.FireInitializeRow)
   End Sub
   Private Sub MostrarEstado(estado As Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebEstadoEventArgs)
      Dim resumen = _resumenDataSource.FirstOrDefault(Function(x) x.Nombre = estado.Nombre And x.Tienda = estado.Tienda)
      If resumen Is Nothing Then
         resumen = New Resumen() With
                     {
                        .Tienda = estado.Tienda,
                        .Nombre = estado.Nombre,
                        .Estado = estado.Estado.ToString(),
                        .NroRegistro = estado.TotalRegistrosSubidos,
                        .TotalRegistros = estado.TotalRegistros,
                        .TotalRegistrosExitosos = estado.TotalRegistrosExitosos,
                        .TotalRegistrosError = estado.TotalRegistrosError,
                        .Metodo = estado.Metodo.ToString()
                     }
         _resumenDataSource.Add(resumen)
      Else
         resumen.Tienda = estado.Tienda
         resumen.Nombre = estado.Nombre
         resumen.Estado = estado.Estado.ToString()
         resumen.NroRegistro = estado.TotalRegistrosSubidos
         resumen.TotalRegistros = estado.TotalRegistros
         resumen.TotalRegistrosExitosos = estado.TotalRegistrosExitosos
         resumen.TotalRegistrosError = estado.TotalRegistrosError
         resumen.Metodo = estado.Metodo.ToString()
      End If

      ugResumen.Rows.Refresh(RefreshRow.ReloadData)
      ugResumen.Rows.Refresh(RefreshRow.RefreshDisplay)
      ugResumen.Rows.Refresh(RefreshRow.FireInitializeRow)
   End Sub
   Private Sub MostrarAvance(avance As Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaWebEventArgs)
      tssInfo.Text = avance.Mensaje
   End Sub

#End Region

   Private Class BkwParams
      Public Property ReenviarTodos As Boolean
      Public Property SincronizaTiendaTiendaNube As Boolean
      Public Property SincronizaTiendaMercadoLibre As Boolean
      Public Property SincronizaTiendaArborea As Boolean
      Public Property SincronizaClientes As Boolean
      Public Property SincronizaCategorias As Boolean
      Public Property SincronizaProductos As Boolean
      Public Property SincronizaPrecios As Boolean
   End Class
   Public Class Resumen
      Public Property Tienda As Entidades.TiendasWeb
      Public Property Estado As String
      Public Property Metodo As String
      Public Property Nombre As String
      Public Property NroRegistro As Long
      Public Property TotalRegistros As Long

      Public Property TotalRegistrosExitosos As Long
      Public Property TotalRegistrosError As Long
   End Class
   Public Class DetalleErrores
      Public Property Tienda As Entidades.TiendasWeb
      Public Property ElementoTransmitido As String
      Public Property Mensaje As String
   End Class

End Class