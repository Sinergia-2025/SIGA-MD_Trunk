Imports Eniac.Reglas.Clientes
Public Class SincronizacionBajada

   Private Const EstadoColumnName As String = "___estado"
   Private Const MensajeErrorColumnName As String = "___mensajeError"

#Region "Propiedades"

   Private _objetosClientes As ObjetosDt(Of Entidades.JSonEntidades.Archivos.ClienteJSonTransporte)
   Private _objetosProductos As ObjetosDt(Of Entidades.JSonEntidades.Archivos.ProductoJSonTransporte)
   Private _objetosProductosSucursales As ObjetosDt(Of Entidades.JSonEntidades.Archivos.ProductoSucursalJSonTransporte)
   Private _objetosProductosSucursalesPrecios As ObjetosDt(Of Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSonTransporte)

   Private _objetosLocalidades As ObjetosDt(Of Entidades.JSonEntidades.Archivos.LocalidadJSonTransporte)
   Private _objetosRubros As ObjetosDt(Of Entidades.JSonEntidades.Archivos.RubroJSonTransporte)
   Private _objetosSubRubros As ObjetosDt(Of Entidades.JSonEntidades.Archivos.SubRubroJSonTransporte)
   Private _objetosSubSubRubros As ObjetosDt(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSonTransporte)

   Private _objetosMarcas As ObjetosEntidad(Of Entidades.JSonEntidades.Archivos.MarcaJSonTransporte, Entidades.JSonEntidades.Archivos.MarcaJSon)

   Private _objetosRubrosCompras As ObjetosEntidad(Of Entidades.JSonEntidades.Archivos.RubroCompraJSonTransporte, Entidades.JSonEntidades.Archivos.RubroCompraJson)

   Private _objetosProveedores As ObjetosEntidad(Of Entidades.JSonEntidades.Archivos.ProveedorJSonTransporte, Entidades.JSonEntidades.Archivos.ProveedorJSon)

#End Region

   Public Sub New()
      InitializeComponent()
      _objetosClientes = New ObjetosDt(Of Entidades.JSonEntidades.Archivos.ClienteJSonTransporte)("Clientes", ugClientes, lblClientesPaginaActual, lblClientesTotalPaginas, tbpClientes,
                                                                                                chbClientes, lblCantidadClientes, dtpClientes, chbTodosClientes,
                                                                                                AddressOf Me.CargaGrillaClientes)
      _objetosProductos = New ObjetosDt(Of Entidades.JSonEntidades.Archivos.ProductoJSonTransporte)("Productos", ugProductos, lblProductosPaginaActual, lblProductosTotalPaginas, tbpProductos,
                                                                                                  chbProductos, lblCantidadProductos, dtpProductos, chbTodosProductos,
                                                                                                  AddressOf Me.CargaGrillaProductos)
      _objetosProductosSucursales = New ObjetosDt(Of Entidades.JSonEntidades.Archivos.ProductoSucursalJSonTransporte)("Stock", ugProductosSucursales, lblProductosSucursalesPaginaActual, lblProductosSucursalesTotalPaginas, tbpProductosSucursales,
                                                                                                                    chbProductos, lblCantidadProductosSucursales, dtpProductosSucursales, chbTodosProductosSucursales,
                                                                                                                    AddressOf Me.CargaGrillaProductosSucursales)
      _objetosProductosSucursalesPrecios = New ObjetosDt(Of Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSonTransporte)("Precios", ugProductosSucursalesPrecios, lblProductosSucursalesPreciosPaginaActual, lblProductosSucursalesPreciosTotalPaginas, tbpProductosSucursalesPrecios,
                                                                                                                                 chbProductos, lblCantidadProductosSucursalesPrecios, dtpProductosSucursalesPrecios, chbTodosProductosSucursalesPrecios,
                                                                                                                                 AddressOf Me.CargaGrillaProductosSucursalesPrecios)

      _objetosLocalidades = New ObjetosDt(Of Entidades.JSonEntidades.Archivos.LocalidadJSonTransporte)("Localidades", ugLocalidades, lblLocalidadesPaginaActual, lblLocalidadesTotalPaginas, tbpLocalidades,
                                                                                                     chbLocalidades, lblCantidadLocalidades, dtpLocalidades, chbTodosLocalidades,
                                                                                                     AddressOf Me.CargaGrillaLocalidades)
      _objetosRubros = New ObjetosDt(Of Entidades.JSonEntidades.Archivos.RubroJSonTransporte)("Rubros", ugRubros, lblRubrosPaginaActual, lblRubrosTotalPaginas, tbpRubros,
                                                                                            chbRubros, lblCantidadRubros, dtpRubros, chbTodosRubros,
                                                                                            AddressOf Me.CargaGrillaRubros)
      _objetosSubRubros = New ObjetosDt(Of Entidades.JSonEntidades.Archivos.SubRubroJSonTransporte)("Sub Rubros", ugSubRubros, lblSubRubrosPaginaActual, lblSubRubrosTotalPaginas, tbpSubRubro,
                                                                                                  chbRubros, lblCantidadSubRubros, dtpSubRubros, chbTodosSubRubros,
                                                                                                  AddressOf Me.CargaGrillaSubRubros)
      _objetosSubSubRubros = New ObjetosDt(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSonTransporte)("Sub Sub Rubros", ugSubSubRubros, lblSubSubRubrosPaginaActual, lblSubSubRubrosTotalPaginas, tbpSubSubRubros,
                                                                                                        chbRubros, lblCantidadSubSubRubros, dtpSubSubRubros, chbTodosSubSubRubros,
                                                                                                        AddressOf Me.CargaGrillaSubSubRubros)

      _objetosMarcas = New ObjetosEntidad(Of Entidades.JSonEntidades.Archivos.MarcaJSonTransporte, Entidades.JSonEntidades.Archivos.MarcaJSon) _
                                                                                                   ("Marcas", ugMarcas, lblMarcasPaginaActual, lblMarcasTotalPaginas, tbpMarcas,
                                                                                                     chbMarcas, lblCantidadMarcas, dtpMarcas, chbTodosMarcas,
                                                                                                     AddressOf Me.CargaGrillaMarcas)

      _objetosRubrosCompras = New ObjetosEntidad(Of Entidades.JSonEntidades.Archivos.RubroCompraJSonTransporte, Entidades.JSonEntidades.Archivos.RubroCompraJson) _
                                                                                                 ("RubrosCompras", ugRubrosCompras, lblRubrosComprasPaginaActual, lblRubrosComprasTotalPaginas,
                                                                                                  tbpRubrosCompras, chbRubrosCompras, lblCantidadRubrosCompras, dtpRubrosCompras, chbTodosRubrosCompras,
                                                                                                   AddressOf Me.CargaGrillaRubrosCompras)

      _objetosProveedores = New ObjetosEntidad(Of Entidades.JSonEntidades.Archivos.ProveedorJSonTransporte, Entidades.JSonEntidades.Archivos.ProveedorJSon) _
                                                                                                 ("Proveedores", ugProveedores, lblProveedoresPaginaActual, lblProveedoresTotalPaginas,
                                                                                                  tbpProveedores, chbProveedores, lblCantidadProveedores, dtpProveedores, chbTodosProveedores,
                                                                                                   AddressOf Me.CargaGrillaProveedores)

      'FolderBrowserDialog1.SelectedPath = "c:\temp\_json\export\"

   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         RefrescarGrillas()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#Region "Eventos"
#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         RefrescarGrillas()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbBajarDatos_Click(sender As Object, e As EventArgs) Handles tsbBajarDatos.Click
      BajarContinuar(limpiar:=True)
   End Sub

   Private Sub tsbContinuarBajando_Click(sender As Object, e As EventArgs) Handles tsbContinuarBajando.Click
      BajarContinuar(limpiar:=False)
   End Sub

   Private Sub BajarContinuar(limpiar As Boolean)
      Try
         Cursor = Cursors.WaitCursor
         DeshabilitaControles()

         Dim _inicioBajarDatos As DateTime = Now

         If limpiar Then LimpiarDatos()
         DescargarDatos()

         ValidarDatosAImportar()

         ugMarcas.Rows.Refresh(RefreshRow.ReloadData)

         Dim tiempo As TimeSpan = Now.Subtract(_inicioBajarDatos)

         Dim mensajeExitoso As String = String.Format("Bajada de información realizado exitosamente. Tiempo transcurrido: {0:00}:{1:00}:{2:00}", tiempo.Hours, tiempo.Minutes, tiempo.Seconds)
         MostrarInfo(mensajeExitoso)
         ShowMessage(mensajeExitoso)

      Catch ex As Exception
         ShowError(ex)
      Finally
         Cursor = Cursors.Default
         HabilitaControles()
      End Try
   End Sub

   Private Sub tsbLeerArchivos_Click(sender As Object, e As EventArgs) Handles tsbLeerArchivos.Click
      Try
         Cursor = Cursors.WaitCursor
         DeshabilitaControles()

         Dim _inicioBajarDatos As DateTime = Now

         If FolderBrowserDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            LeerDeArchivos(FolderBrowserDialog1.SelectedPath)
            ValidarDatosAImportar()

            Dim tiempo As TimeSpan = Now.Subtract(_inicioBajarDatos)

            Dim mensajeExitoso As String = String.Format("Lectura de archivos realizada exitosamente. Tiempo transcurrido: {0:00}:{1:00}:{2:00}", tiempo.Hours, tiempo.Minutes, tiempo.Seconds)
            MostrarInfo(mensajeExitoso)
            ShowMessage(mensajeExitoso)
         End If

      Catch ex As Exception
         ShowError(ex)
      Finally
         Cursor = Cursors.Default

         HabilitaControles()
      End Try
   End Sub

   Private Sub tsbImportar_Click(sender As Object, e As EventArgs) Handles tsbImportar.Click
      If chbClientes.Checked Or chbProductos.Checked Or chbLocalidades.Checked Or chbRubros.Checked Or chbMarcas.Checked Or chbRubrosCompras.Checked Or chbProveedores.Checked Then
         Try
            Cursor = Cursors.WaitCursor
            DeshabilitaControles()

            Dim stb As StringBuilder = New StringBuilder()
            Dim conError As Boolean = False

            If chbClientes.Checked AndAlso _objetosClientes.Dt.HasErrors Then
               conError = True
               stb.AppendFormatLine("Existe {0} clientes con errores.", _objetosClientes.Dt.GetErrors.Length)
            End If
            If chbLocalidades.Checked AndAlso _objetosLocalidades.Dt.HasErrors Then
               conError = True
               stb.AppendFormatLine("Existe {0} localidades con errores.", _objetosLocalidades.Dt.GetErrors.Length)
            End If
            If chbRubros.Checked AndAlso _objetosRubros.Dt.HasErrors Then
               conError = True
               stb.AppendFormatLine("Existe {0} rubros con errores.", _objetosRubros.Dt.GetErrors.Length)
            End If
            If chbRubros.Checked AndAlso _objetosSubRubros.Dt.HasErrors Then
               conError = True
               stb.AppendFormatLine("Existe {0} sub rubros con errores.", _objetosSubRubros.Dt.GetErrors.Length)
            End If
            If chbRubros.Checked AndAlso _objetosSubSubRubros.Dt.HasErrors Then
               conError = True
               stb.AppendFormatLine("Existe {0} sub sub rubros con errores.", _objetosSubSubRubros.Dt.GetErrors.Length)
            End If
            If chbMarcas.Checked AndAlso _objetosMarcas.ConErrores Then
               conError = True
               stb.AppendFormatLine("Existe {0} marcas con errores.", _objetosMarcas.CountConErrores)
            End If
            If chbRubrosCompras.Checked AndAlso _objetosRubrosCompras.ConErrores Then
               conError = True
               stb.AppendFormatLine("Existe {0} Rubros Compras con errores.", _objetosRubrosCompras.CountConErrores)
            End If

            If chbProveedores.Checked AndAlso _objetosProveedores.ConErrores Then
               conError = True
               stb.AppendFormatLine("Existe {0} Proveedores con errores.", _objetosProveedores.CountConErrores)
            End If
            If chbProductos.Checked AndAlso _objetosProductos.Dt.HasErrors Then
               conError = True
               stb.AppendFormatLine("Existe {0} productos con errores.", _objetosProductos.Dt.GetErrors.Length)
            End If
            If chbProductos.Checked AndAlso _objetosProductosSucursalesPrecios.Dt.HasErrors Then
               conError = True
               stb.AppendFormatLine("Existe {0} precios con errores.", _objetosProductosSucursalesPrecios.Dt.GetErrors.Length)
            End If
            If chbProductos.Checked AndAlso _objetosProductosSucursales.Dt.HasErrors Then
               conError = True
               stb.AppendFormatLine("Existe {0} stock con errores.", _objetosProductosSucursales.Dt.GetErrors.Length)
            End If

            If conError Then
               stb.AppendLine().AppendLine()
            End If

            'Dim stb As StringBuilder = New StringBuilder()
            stb.AppendLine("Está por importar: ")
            If chbClientes.Checked Then
               stb.AppendFormat("    {0} Clientes", _objetosClientes.CountDt - _objetosClientes.Dt.GetErrors.Length).AppendLine()
            End If

            If chbLocalidades.Checked Then
               stb.AppendFormat("    {0} Localidades", _objetosLocalidades.CountDt - _objetosLocalidades.Dt.GetErrors.Length).AppendLine()
            End If

            If chbRubros.Checked Then
               stb.AppendFormat("    {0} Rubros", _objetosRubros.CountDt - _objetosRubros.Dt.GetErrors.Length).AppendLine()
               stb.AppendFormat("    {0} Sub Rubros", _objetosSubRubros.CountDt - _objetosSubRubros.Dt.GetErrors.Length).AppendLine()
               stb.AppendFormat("    {0} Sub Sub Rubros", _objetosSubSubRubros.CountDt - _objetosSubSubRubros.Dt.GetErrors.Length).AppendLine()
            End If

            If chbMarcas.Checked Then
               stb.AppendFormat("    {0} Marcas", _objetosMarcas.CountSinErrores).AppendLine()
            End If

            If chbRubrosCompras.Checked Then
               stb.AppendFormat("    {0} RubrosCompras", _objetosRubrosCompras.CountSinErrores).AppendLine()
            End If

            If chbProveedores.Checked Then
               stb.AppendFormat("    {0} Proveedores", _objetosProveedores.CountSinErrores).AppendLine()
            End If

            If chbProductos.Checked Then
               stb.AppendFormat("    {0} Productos", _objetosProductos.CountDt - _objetosProductos.Dt.GetErrors.Length).AppendLine()
               stb.AppendFormat("    {0} Stock", _objetosProductosSucursales.CountDt - _objetosProductosSucursales.Dt.GetErrors.Length).AppendLine()
               stb.AppendFormat("    {0} Precios", _objetosProductosSucursalesPrecios.CountDt - _objetosProductosSucursalesPrecios.Dt.GetErrors.Length).AppendLine()
            End If

            stb.AppendLine("¿Desea continuar?")

            If ShowPregunta(stb.ToString()) = Windows.Forms.DialogResult.Yes Then

               Dim _inicioBajarDatos As DateTime = Now

               ImportarDatos()

               Dim tiempo As TimeSpan = Now.Subtract(_inicioBajarDatos)

               Dim mensajeExitoso As String = String.Format("Importación realizada exitosamente. Tiempo transcurrido: {0:00}:{1:00}:{2:00}", tiempo.Hours, tiempo.Minutes, tiempo.Seconds)
               MostrarInfo(mensajeExitoso)
               ShowMessage(mensajeExitoso)

            End If

         Catch ex As Exception
            ShowError(ex)
         Finally
            Cursor = Cursors.Default
            HabilitaControles()
         End Try
      End If
   End Sub

   Private Sub tsbRevalidar_Click(sender As Object, e As EventArgs) Handles tsbRevalidar.Click
      Try
         Cursor = Cursors.WaitCursor

         Dim _inicioBajarDatos As DateTime = Now

         InicializaValidacion()
         DeshabilitaControles()
         ValidarDatosAImportar()

         Dim tiempo As TimeSpan = Now.Subtract(_inicioBajarDatos)

         Dim mensajeExitoso As String = String.Format("Revalidación realizada exitosamente. Tiempo transcurrido: {0:00}:{1:00}:{2:00}", tiempo.Hours, tiempo.Minutes, tiempo.Seconds)
         MostrarInfo(mensajeExitoso)
         ShowMessage(mensajeExitoso)

      Catch ex As Exception
         ShowError(ex)
      Finally
         Cursor = Cursors.Default
         HabilitaControles()
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub
#End Region
#Region "Eventos Filtros"
   Private Sub chbClientes_CheckedChanged(sender As Object, e As EventArgs) Handles chbClientes.CheckedChanged
      HabilitaBotonBajar()
      lblCantidadClientes.Visible = chbClientes.Checked
   End Sub

   Private Sub chbProductos_CheckedChanged(sender As Object, e As EventArgs) Handles chbProductos.CheckedChanged
      HabilitaBotonBajar()
      lblCantidadProductos.Visible = chbProductos.Checked
      lblCantidadProductosSucursales.Visible = chbProductos.Checked
      lblCantidadProductosSucursalesPrecios.Visible = chbProductos.Checked
   End Sub

   Private Sub chbLocalidades_CheckedChanged(sender As Object, e As EventArgs) Handles chbLocalidades.CheckedChanged
      HabilitaBotonBajar()
      lblCantidadLocalidades.Visible = chbLocalidades.Checked
   End Sub

   Private Sub chbRubros_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubros.CheckedChanged
      HabilitaBotonBajar()
      lblCantidadRubros.Visible = chbRubros.Checked
      lblCantidadSubRubros.Visible = chbRubros.Checked
      lblCantidadSubSubRubros.Visible = chbRubros.Checked
   End Sub

   Private Sub chbMarcas_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarcas.CheckedChanged
      HabilitaBotonBajar()
      lblCantidadMarcas.Visible = chbMarcas.Checked
   End Sub
   Private Sub chbRubrosCompras_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubrosCompras.CheckedChanged
      HabilitaBotonBajar()
      lblCantidadRubrosCompras.Visible = chbRubrosCompras.Checked
   End Sub
   Private Sub chbProveedores_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedores.CheckedChanged
      HabilitaBotonBajar()
      lblCantidadProveedores.Visible = chbProveedores.Checked
   End Sub

#End Region
#Region "Eventos Reglas"
   Private Sub reglas_AvanceValidarDatos(sender As Object, e As AvanceProcesarDatosEventArgs)
      MostrarInfo(String.Format("Validando {2}: {0}/{1}...", e.RegistroActual, e.TotalRegistros, e.Modulo))
   End Sub

   Private Sub reglas_AvanceImportarDatos(sender As Object, e As AvanceProcesarDatosEventArgs)
      MostrarInfo(String.Format("Importando {2}: {0}/{1}...", e.RegistroActual, e.TotalRegistros, e.Modulo))
   End Sub

#End Region

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodosClientes.CheckedChanged, chbTodosProductos.CheckedChanged, chbTodosProductosSucursales.CheckedChanged, chbTodosProductosSucursalesPrecios.CheckedChanged, chbLocalidades.CheckedChanged, chbTodosRubros.CheckedChanged, chbTodosSubRubros.CheckedChanged, chbTodosSubSubRubros.CheckedChanged, chbTodosLocalidades.CheckedChanged, chbTodosMarcas.CheckedChanged, chbTodosRubrosCompras.CheckedChanged, chbTodosProveedores.CheckedChanged
      dtpClientes.Enabled = Not chbTodosClientes.Checked
      dtpProductos.Enabled = Not chbTodosProductos.Checked
      dtpProductosSucursales.Enabled = Not chbTodosProductosSucursales.Checked
      dtpProductosSucursalesPrecios.Enabled = Not chbTodosProductosSucursalesPrecios.Checked
      dtpLocalidades.Enabled = Not chbTodosLocalidades.Checked
      dtpRubros.Enabled = Not chbTodosRubros.Checked
      dtpSubRubros.Enabled = Not chbTodosSubRubros.Checked
      dtpSubSubRubros.Enabled = Not chbTodosSubSubRubros.Checked
      dtpMarcas.Enabled = Not chbTodosMarcas.Checked
      dtpRubrosCompras.Enabled = Not chbTodosRubrosCompras.Checked
      dtpProveedores.Enabled = Not chbTodosProveedores.Checked
   End Sub

   Private Sub grillas_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugClientes.InitializeRow, ugProductos.InitializeRow, ugProductosSucursales.InitializeRow, ugProductosSucursalesPrecios.InitializeRow, ugSubSubRubros.InitializeRow, ugSubRubros.InitializeRow, ugRubros.InitializeRow, ugLocalidades.InitializeRow, ugMarcas.InitializeRow
      Try
         If e.Row.Cells.Exists(EstadoColumnName) Then
            Dim celda As UltraGridCell = e.Row.Cells(EstadoColumnName)
            Dim estado As String = celda.Value.ToString()
            Select Case estado
               Case "E"
                  celda.Appearance.BackColor = Color.Red
                  celda.ActiveAppearance.BackColor = Color.Red
                  celda.Appearance.ForeColor = Color.White
                  celda.ActiveAppearance.ForeColor = Color.White
               Case "M", "M/A"
                  celda.Appearance.BackColor = Color.Yellow
                  celda.ActiveAppearance.BackColor = Color.Yellow
                  celda.Appearance.ForeColor = Color.Black
                  celda.ActiveAppearance.ForeColor = Color.Black
               Case "A"
                  celda.Appearance.BackColor = Color.Cyan
                  celda.ActiveAppearance.BackColor = Color.Cyan
                  celda.Appearance.ForeColor = Color.Black
                  celda.ActiveAppearance.ForeColor = Color.Black
               Case "I"
                  celda.Appearance.BackColor = Color.LimeGreen
                  celda.ActiveAppearance.BackColor = Color.LimeGreen
                  celda.Appearance.ForeColor = Color.Black
                  celda.ActiveAppearance.ForeColor = Color.Black
               Case Else
                  celda.Appearance.BackColor = Nothing
                  celda.ActiveAppearance.BackColor = Nothing
                  celda.Appearance.ForeColor = Nothing
                  celda.ActiveAppearance.ForeColor = Nothing
            End Select
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Metodos"
   Public Sub RefrescarGrillas()
      Me.chbClientes.Checked = Reglas.Publicos.ClientesBajarDeLaWeb
      Me.chbClientes.Enabled = Me.chbClientes.Checked

      Me.chbProductos.Checked = Reglas.Publicos.ProductosBajarDeLaWeb
      Me.chbProductos.Enabled = Me.chbProductos.Checked

      Me.chbRubros.Checked = Reglas.Publicos.RubrosBajarDeLaWeb
      Me.chbRubros.Enabled = Me.chbRubros.Checked

      Me.chbMarcas.Checked = Reglas.Publicos.MarcasBajarDeLaWeb
      Me.chbMarcas.Enabled = Me.chbMarcas.Checked

      Me.chbLocalidades.Checked = Reglas.Publicos.LocalidadesBajarDeLaWeb
      Me.chbLocalidades.Enabled = Me.chbLocalidades.Checked

      Me.chbProveedores.Checked = Reglas.Publicos.ProveedoresBajarDeLaWeb
      Me.chbProveedores.Enabled = Me.chbProveedores.Checked

      Me.chbRubrosCompras.Checked = Reglas.Publicos.RubrosComprasBajarDeLaWeb
      Me.chbRubrosCompras.Enabled = Me.chbRubrosCompras.Checked

      MostrarFechas(Reglas.Publicos.WebArchivos.Clientes.FechaUltimaDescarga, dtpClientes, chbTodosClientes)
      MostrarFechas(Reglas.Publicos.WebArchivos.Productos.FechaUltimaDescarga, dtpProductos, chbTodosProductos)
      MostrarFechas(Reglas.Publicos.WebArchivos.ProductosSucursales.FechaUltimaDescarga, dtpProductosSucursales, chbTodosProductosSucursales)
      MostrarFechas(Reglas.Publicos.WebArchivos.ProductosSucursalesPrecios.FechaUltimaDescarga, dtpProductosSucursalesPrecios, chbTodosProductosSucursalesPrecios)

      MostrarFechas(Reglas.Publicos.WebArchivos.Localidades.FechaUltimaDescarga, dtpLocalidades, chbTodosLocalidades)
      MostrarFechas(Reglas.Publicos.WebArchivos.Rubros.FechaUltimaDescarga, dtpRubros, chbTodosRubros)
      MostrarFechas(Reglas.Publicos.WebArchivos.SubRubros.FechaUltimaDescarga, dtpSubRubros, chbTodosSubRubros)
      MostrarFechas(Reglas.Publicos.WebArchivos.SubSubRubros.FechaUltimaDescarga, dtpSubSubRubros, chbTodosSubSubRubros)

      MostrarFechas(Reglas.Publicos.WebArchivos.Marcas.FechaUltimaDescarga, dtpMarcas, chbTodosMarcas)

      MostrarFechas(Reglas.Publicos.WebArchivos.RubrosCompras.FechaUltimaDescarga, dtpRubrosCompras, chbTodosRubrosCompras)

      MostrarFechas(Reglas.Publicos.WebArchivos.Proveedores.FechaUltimaDescarga, dtpProveedores, chbTodosProveedores)
   End Sub
   Private Shared Function NewDataTable() As DataTable
      Dim dt As DataTable = New DataTable()

      dt.Columns.Add(EstadoColumnName, GetType(String)).Caption = "Estado"
      dt.Columns.Add(MensajeErrorColumnName, GetType(String)).Caption = "Mensaje"

      Return dt
   End Function
   Private Function GetFechaDesde(dtp As DateTimePicker, chb As CheckBox) As DateTime
      If chb.Checked Then
         Return New Date(1900, 1, 1)
      Else
         Return dtp.Value
      End If
   End Function

#Region "Metodos Habilitar Controles"
   Private Sub HabilitaBotonBajar()
      tsbBajarDatos.Enabled = chbClientes.Checked Or chbProductos.Checked Or chbLocalidades.Checked Or chbRubros.Checked Or chbMarcas.Checked Or chbRubrosCompras.Checked Or chbProveedores.Checked
      tsbContinuarBajando.Enabled = tsbBajarDatos.Enabled
   End Sub
   Private Sub DeshabilitaControles()
      tsbRefrescar.Enabled = False
      tsbBajarDatos.Enabled = False
      tsbContinuarBajando.Enabled = False
      tsbLeerArchivos.Enabled = False
      tsbImportar.Enabled = False
      tsbRevalidar.Enabled = False
      chbClientes.Enabled = False
      chbProductos.Enabled = False
      chbLocalidades.Enabled = False
      chbRubros.Enabled = False
      chbMarcas.Enabled = False
      chbRubrosCompras.Enabled = False
      chbProveedores.Enabled = False
   End Sub
   Private Sub HabilitaControles()
      tsbRefrescar.Enabled = True
      HabilitaBotonBajar()
      tsbLeerArchivos.Enabled = True
      tsbImportar.Enabled = True
      tsbRevalidar.Enabled = True
      chbClientes.Enabled = True
      chbProductos.Enabled = True
      chbLocalidades.Enabled = True
      chbRubros.Enabled = True
      chbMarcas.Enabled = True
      chbRubrosCompras.Enabled = True
      chbProveedores.Enabled = True
   End Sub
#End Region
#Region "Metodos Mostrar Informacion"
   Private Sub MostrarAvanceDescargasDatos(key As String, offset As Long, cantidadRegistros As Long)
      MostrarInfo(String.Format("Descargando {0} - registros {1}/{2}", key, offset, cantidadRegistros))
   End Sub

   Private Sub MostrarCantidadRegistros(control As Control, cantidad As Long)
      If cantidad < 0 Then
         control.Text = String.Format(control.Tag.ToString(), "...")
      Else
         control.Text = String.Format(control.Tag.ToString(), cantidad)
      End If
      Application.DoEvents()
   End Sub

   Private Sub MostrarInfo(texto As String)
      tssInfo.Text = texto
      Application.DoEvents()
   End Sub

   Private Sub MuestraPaginaActual(control As Control, cantidad As Long)
      control.Text = cantidad.ToString()
      Application.DoEvents()
   End Sub

   Private Sub MostrarFechas(fecha As DateTime?, dtp As DateTimePicker, chb As CheckBox)
      chb.Checked = Not fecha.HasValue
      If fecha.HasValue Then
         dtp.Value = fecha.Value
      Else
         dtp.Value = New Date(1900, 1, 1, 0, 0, 0)
      End If
   End Sub
#End Region

#Region "Metodos Descarga desde Web"
   'urlGet = Reglas.Publicos.WebArchivos.Clientes.UrlGET
   'urlCount = Reglas.Publicos.WebArchivos.Clientes.UrlGETCount
   'tamanoPagina = Reglas.Publicos.WebArchivos.Clientes.TamanoPaginaGet
   Private Sub DescargarDatosIndividual(Of T)(controles As Objetos(Of T),
                                              urlCount As String,
                                              urlGet As String,
                                              tamanoPagina As Integer)
      If controles.Seleccionado.Checked Then
         MostrarInfo(String.Format("Bajando los {0} de la web...", controles.Nombre))
         MostrarCantidadRegistros(controles.Cantidad, -1)
         'controles.Transporte.Clear()
         DescargarDatos(controles, controles.Transporte, tamanoPagina, urlCount, urlGet, GetFechaDesde(controles.FechaActualizacion, controles.ReenviarTodo))
         controles.CargaGrillaCallback.Invoke()
      End If
      MostrarCantidadRegistros(controles.Cantidad, controles.Transporte.Count)

   End Sub

   Private Sub LimpiarDatosIndividual(Of T)(controles As ObjetosDt(Of T))
      controles.Transporte.Clear()
      controles.Dt.Clear()
      controles.PaginaActual.Text = "0"
      controles.TotalPaginas.Text = "0"
      MostrarCantidadRegistros(controles.Cantidad, controles.Transporte.Count)
   End Sub
   Private Sub LimpiarDatosIndividual(Of T, U As Entidades.JSonEntidades.Archivos.IValidable)(controles As ObjetosEntidad(Of T, U))
      controles.Transporte.Clear()
      controles.Entidades.Clear()
      controles.PaginaActual.Text = "0"
      controles.TotalPaginas.Text = "0"
      MostrarCantidadRegistros(controles.Cantidad, controles.Transporte.Count)
   End Sub

   Private Sub LimpiarDatos()
      LimpiarDatosIndividual(_objetosClientes)
      LimpiarDatosIndividual(_objetosProductos)
      LimpiarDatosIndividual(_objetosProductosSucursales)
      LimpiarDatosIndividual(_objetosProductosSucursalesPrecios)
      LimpiarDatosIndividual(_objetosLocalidades)
      LimpiarDatosIndividual(_objetosRubros)
      LimpiarDatosIndividual(_objetosSubRubros)
      LimpiarDatosIndividual(_objetosSubSubRubros)
      LimpiarDatosIndividual(_objetosMarcas)
      LimpiarDatosIndividual(_objetosRubrosCompras)
      LimpiarDatosIndividual(_objetosProveedores)
   End Sub

   Private Sub DescargarDatos()

      DescargarDatosIndividual(_objetosClientes,
                               Reglas.Publicos.WebArchivos.Clientes.UrlGETCount,
                               Reglas.Publicos.WebArchivos.Clientes.UrlGET,
                               Reglas.Publicos.WebArchivos.Clientes.TamanoPaginaGet)

      DescargarDatosIndividual(_objetosProductos,
                               Reglas.Publicos.WebArchivos.Productos.UrlGETCount,
                               Reglas.Publicos.WebArchivos.Productos.UrlGET,
                               Reglas.Publicos.WebArchivos.Productos.TamanoPaginaGet)

      DescargarDatosIndividual(_objetosProductosSucursales,
                               Reglas.Publicos.WebArchivos.ProductosSucursales.UrlGETCount,
                               Reglas.Publicos.WebArchivos.ProductosSucursales.UrlGET,
                               Reglas.Publicos.WebArchivos.ProductosSucursales.TamanoPaginaGet)

      DescargarDatosIndividual(_objetosProductosSucursalesPrecios,
                               Reglas.Publicos.WebArchivos.ProductosSucursalesPrecios.UrlGETCount,
                               Reglas.Publicos.WebArchivos.ProductosSucursalesPrecios.UrlGET,
                               Reglas.Publicos.WebArchivos.ProductosSucursalesPrecios.TamanoPaginaGet)

      DescargarDatosIndividual(_objetosLocalidades,
                               Reglas.Publicos.WebArchivos.Localidades.UrlGETCount,
                               Reglas.Publicos.WebArchivos.Localidades.UrlGET,
                               Reglas.Publicos.WebArchivos.Localidades.TamanoPaginaGet)

      DescargarDatosIndividual(_objetosRubros,
                               Reglas.Publicos.WebArchivos.Rubros.UrlGETCount,
                               Reglas.Publicos.WebArchivos.Rubros.UrlGET,
                               Reglas.Publicos.WebArchivos.Rubros.TamanoPaginaGet)

      DescargarDatosIndividual(_objetosSubRubros,
                               Reglas.Publicos.WebArchivos.SubRubros.UrlGETCount,
                               Reglas.Publicos.WebArchivos.SubRubros.UrlGET,
                               Reglas.Publicos.WebArchivos.SubRubros.TamanoPaginaGet)

      DescargarDatosIndividual(_objetosSubSubRubros,
                               Reglas.Publicos.WebArchivos.SubSubRubros.UrlGETCount,
                               Reglas.Publicos.WebArchivos.SubSubRubros.UrlGET,
                               Reglas.Publicos.WebArchivos.SubSubRubros.TamanoPaginaGet)

      DescargarDatosIndividual(_objetosMarcas,
                               Reglas.Publicos.WebArchivos.Marcas.UrlGETCount,
                               Reglas.Publicos.WebArchivos.Marcas.UrlGET,
                               Reglas.Publicos.WebArchivos.Marcas.TamanoPaginaGet)

      DescargarDatosIndividual(_objetosRubrosCompras,
                             Reglas.Publicos.WebArchivos.RubrosCompras.UrlGETCount,
                             Reglas.Publicos.WebArchivos.RubrosCompras.UrlGET,
                             Reglas.Publicos.WebArchivos.RubrosCompras.TamanoPaginaGet)

      DescargarDatosIndividual(_objetosProveedores,
                          Reglas.Publicos.WebArchivos.Proveedores.UrlGETCount,
                          Reglas.Publicos.WebArchivos.Proveedores.UrlGET,
                          Reglas.Publicos.WebArchivos.Proveedores.TamanoPaginaGet)

      Me.tssRegistros.Text = String.Format("{0} Registros", _objetosClientes.CountDt +
                                                            _objetosProductos.CountDt +
                                                            _objetosProductosSucursales.CountDt +
                                                            _objetosProductosSucursalesPrecios.CountDt +
                                                            _objetosLocalidades.CountDt +
                                                            _objetosRubros.CountDt +
                                                            _objetosSubRubros.CountDt +
                                                            _objetosSubSubRubros.CountDt +
                                                            _objetosMarcas.Entidades.Count +
                                                            _objetosRubrosCompras.Entidades.Count +
                                                            _objetosProveedores.Entidades.Count)

   End Sub

   Private Sub DescargarDatos(Of T)(controles As Objetos(Of T), ByRef datos As List(Of T), registrosPorPagina As Integer, urlCount As String, urlGet As String, fechaActualizacion As DateTime) '', archivoLocal As String)
      Dim servicioRest As Reglas.ServiciosRest.Archivos.BaseArchivosWeb(Of T)
      servicioRest = New Reglas.ServiciosRest.Archivos.BaseArchivosWeb(Of T)()

      MostrarInfo(String.Format("Obteniendo la cantidad de registros de {0}.", controles.Nombre))
      Dim cantidadRegistros As Long = registrosPorPagina
      If Not String.IsNullOrWhiteSpace(urlCount) Then
         cantidadRegistros = servicioRest.GetCount(urlCount, fechaActualizacion)(0).cantidadRegistros
      End If
      Dim totalPaginas As Long = Convert.ToInt64(Math.Ceiling(cantidadRegistros / registrosPorPagina))

      controles.TotalPaginas.Text = totalPaginas.ToString()

      If Not String.IsNullOrWhiteSpace(urlGet) Then
         Dim paginaInicial As Integer = Integer.Parse(controles.PaginaActual.Text)
         Dim offset As Long = paginaInicial * registrosPorPagina
         While offset < cantidadRegistros
            Console.WriteLine(String.Format("Tabla: {0} - PaginaInicial: {1} - Offset: {2} - RegistrosPorPagina: {3} - CantidadRegistros: {4}", controles.Nombre, controles.PaginaActual.Text, offset, registrosPorPagina, cantidadRegistros))
            datos.AddRange(servicioRest.Get(urlGet, offset, registrosPorPagina, fechaActualizacion))
            MostrarAvanceDescargasDatos(controles.Nombre, offset, cantidadRegistros)
            MuestraPaginaActual(controles.PaginaActual, (paginaInicial + 1))
            offset += registrosPorPagina
            paginaInicial += 1
         End While
      End If
      cantidadRegistros = datos.Count
      MostrarAvanceDescargasDatos(controles.Nombre, cantidadRegistros, cantidadRegistros)
      '_objetosProductos.Transporte = servicioRest.Get(urlGet)
   End Sub
#End Region

#Region "Metodos Lectura de Archivos"
   Private Sub LeerDeArchivos(directorio As String)
      Dim tamanoPagina As Integer = 0
      Dim urlCount As String = String.Empty
      Dim urlGet As String = String.Empty
      Dim archivoLocal As String = String.Empty

      _objetosClientes.Transporte.Clear()
      _objetosProductos.Transporte.Clear()
      _objetosProductosSucursales.Transporte.Clear()
      _objetosProductosSucursalesPrecios.Transporte.Clear()
      _objetosLocalidades.Transporte.Clear()
      _objetosRubros.Transporte.Clear()
      _objetosSubRubros.Transporte.Clear()
      _objetosSubSubRubros.Transporte.Clear()
      _objetosMarcas.Transporte.Clear()
      _objetosRubrosCompras.Transporte.Clear()
      _objetosProveedores.Transporte.Clear()

      MostrarCantidadRegistros(lblCantidadClientes, _objetosClientes.Transporte.Count)
      MostrarCantidadRegistros(lblCantidadProductos, _objetosProductos.Transporte.Count)
      MostrarCantidadRegistros(lblCantidadProductosSucursales, _objetosProductosSucursales.Transporte.Count)
      MostrarCantidadRegistros(lblCantidadProductosSucursalesPrecios, _objetosProductosSucursalesPrecios.Transporte.Count)
      MostrarCantidadRegistros(lblCantidadLocalidades, _objetosLocalidades.Transporte.Count)
      MostrarCantidadRegistros(lblCantidadRubros, _objetosRubros.Transporte.Count)
      MostrarCantidadRegistros(lblCantidadSubRubros, _objetosSubRubros.Transporte.Count)
      MostrarCantidadRegistros(lblCantidadSubSubRubros, _objetosSubSubRubros.Transporte.Count)
      MostrarCantidadRegistros(lblCantidadMarcas, _objetosMarcas.Transporte.Count)
      MostrarCantidadRegistros(lblCantidadRubrosCompras, _objetosRubrosCompras.Transporte.Count)
      MostrarCantidadRegistros(lblCantidadProveedores, _objetosProveedores.Transporte.Count)

      If chbClientes.Checked Then
         MostrarInfo("Leyendo los Clientes de archivos...")
         MostrarCantidadRegistros(lblCantidadClientes, -1)
         _objetosClientes.Transporte.Clear()

         LeerDatosDeArchivo("Clientes", _objetosClientes.Transporte, directorio, "clientes_*.json")     ''"c:\temp\_json\export\"

         CargaGrillaClientes()
      End If
      MostrarCantidadRegistros(lblCantidadClientes, _objetosClientes.Transporte.Count)

      If chbProductos.Checked Then
         MostrarInfo("Leyendo los productos de archivos...")
         MostrarCantidadRegistros(lblCantidadProductos, -1)
         _objetosProductos.Transporte.Clear()

         LeerDatosDeArchivo("Productos", _objetosProductos.Transporte, directorio, "productos_*.json")

         CargaGrillaProductos()
      End If
      MostrarCantidadRegistros(lblCantidadProductos, _objetosProductos.Transporte.Count)

      If chbProductos.Checked Then
         MostrarInfo("Leyendo los stock de archivos...")
         MostrarCantidadRegistros(lblCantidadProductosSucursales, -1)
         _objetosProductosSucursales.Transporte.Clear()

         LeerDatosDeArchivo("Stock", _objetosProductosSucursales.Transporte, directorio, "productossucursales_*.json")

         CargaGrillaProductosSucursales()
      End If
      MostrarCantidadRegistros(lblCantidadProductosSucursales, _objetosProductosSucursales.Transporte.Count)

      If chbProductos.Checked Then
         MostrarInfo("Leyendo los precios de archivos...")
         MostrarCantidadRegistros(lblCantidadProductosSucursalesPrecios, -1)
         _objetosProductosSucursalesPrecios.Transporte.Clear()

         LeerDatosDeArchivo("Precios", _objetosProductosSucursalesPrecios.Transporte, directorio, "productossucursalesprecios_*.json")

         CargaGrillaProductosSucursalesPrecios()
      End If
      MostrarCantidadRegistros(lblCantidadProductosSucursalesPrecios, _objetosProductosSucursalesPrecios.Transporte.Count)


      If chbLocalidades.Checked Then
         MostrarInfo("Leyendo los Localidades de archivos...")
         MostrarCantidadRegistros(lblCantidadLocalidades, -1)
         _objetosClientes.Transporte.Clear()

         LeerDatosDeArchivo("Localidades", _objetosClientes.Transporte, directorio, "localidades_*.json")     ''"c:\temp\_json\export\"

         CargaGrillaLocalidades()
      End If
      MostrarCantidadRegistros(lblCantidadLocalidades, _objetosLocalidades.Transporte.Count)

      If chbRubros.Checked Then
         MostrarInfo("Leyendo los rubros de archivos...")
         MostrarCantidadRegistros(lblCantidadRubros, -1)
         _objetosRubros.Transporte.Clear()

         LeerDatosDeArchivo("Rubros", _objetosRubros.Transporte, directorio, "rubros_*.json")

         CargaGrillaRubros()
      End If
      MostrarCantidadRegistros(lblCantidadRubros, _objetosRubros.Transporte.Count)

      If chbRubros.Checked Then
         MostrarInfo("Leyendo los sub rubros de archivos...")
         MostrarCantidadRegistros(lblCantidadSubRubros, -1)
         _objetosSubRubros.Transporte.Clear()

         LeerDatosDeArchivo("Sub Rubros", _objetosSubRubros.Transporte, directorio, "subrubros_*.json")

         CargaGrillaSubRubros()
      End If
      MostrarCantidadRegistros(lblCantidadSubRubros, _objetosSubRubros.Transporte.Count)

      If chbRubros.Checked Then
         MostrarInfo("Leyendo los sub sub rubros de archivos...")
         MostrarCantidadRegistros(lblCantidadSubSubRubros, -1)
         _objetosSubSubRubros.Transporte.Clear()

         LeerDatosDeArchivo("Sub Sub Rubros", _objetosSubSubRubros.Transporte, directorio, "subsubrubros_*.json")

         CargaGrillaSubSubRubros()
      End If
      MostrarCantidadRegistros(lblCantidadSubSubRubros, _objetosSubSubRubros.Transporte.Count)

      If chbMarcas.Checked Then
         MostrarInfo("Leyendo las Marcas de archivos...")
         MostrarCantidadRegistros(lblCantidadMarcas, -1)
         _objetosMarcas.Transporte.Clear()

         LeerDatosDeArchivo("Marcas", _objetosClientes.Transporte, directorio, "marcas_*.json")     ''"c:\temp\_json\export\"

         CargaGrillaMarcas()
      End If
      MostrarCantidadRegistros(lblCantidadMarcas, _objetosMarcas.Transporte.Count)

      If chbRubrosCompras.Checked Then
         MostrarInfo("Leyendo los Rubros Compras de archivos...")
         MostrarCantidadRegistros(lblCantidadRubrosCompras, -1)
         _objetosRubrosCompras.Transporte.Clear()

         LeerDatosDeArchivo("RubrosCompras", _objetosRubrosCompras.Transporte, directorio, "rubrosCompras_*.json")     ''"c:\temp\_json\export\"

         CargaGrillaRubrosCompras()
      End If
      MostrarCantidadRegistros(lblCantidadRubrosCompras, _objetosRubrosCompras.Transporte.Count)

      If chbProveedores.Checked Then
         MostrarInfo("Leyendo los Proveedores de archivos...")
         MostrarCantidadRegistros(lblCantidadProveedores, -1)
         _objetosProveedores.Transporte.Clear()

         LeerDatosDeArchivo("Proveedores", _objetosProveedores.Transporte, directorio, "proveedores_*.json")     ''"c:\temp\_json\export\"

         CargaGrillaProveedores()
      End If
      MostrarCantidadRegistros(lblCantidadProveedores, _objetosProveedores.Transporte.Count)



      Me.tssRegistros.Text = String.Format("{0} Registros", _objetosClientes.CountDt +
                                                            _objetosProductos.CountDt +
                                                            _objetosProductosSucursales.CountDt +
                                                            _objetosProductosSucursalesPrecios.CountDt +
                                                            _objetosLocalidades.CountDt +
                                                            _objetosRubros.CountDt +
                                                            _objetosSubRubros.CountDt +
                                                            _objetosSubSubRubros.CountDt +
                                                            _objetosMarcas.Entidades.Count)

   End Sub

   Private Sub LeerDatosDeArchivo(Of T)(key As String, ByRef datos As List(Of T), pathArchivos As String, searchPattern As String) '', archivoLocal As String)

      Dim json As String
      For Each archivo As String In IO.Directory.GetFiles(pathArchivos, searchPattern)
         json = IO.File.ReadAllText(archivo)

         MostrarInfo(String.Format("Leyendo el archivo {0}", archivo))

         Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
         datos.AddRange(serializer.Deserialize(Of List(Of T))(json))
      Next

   End Sub
#End Region

#Region "Metodos CargarGrillas"
   Private Sub CargaGrillaClientes()
      Dim rClientes As Reglas.Clientes = New Reglas.Clientes()
      _objetosClientes.Dt.Clear()
      rClientes.CargarJSonEnDataTable(_objetosClientes.Transporte, _objetosClientes.Dt)

      If _objetosClientes.CountDt > 0 Then
         CargaGrilla(ugClientes, _objetosClientes.Dt, {Entidades.Cliente.Columnas.IdCliente.ToString(),
                                               Entidades.Cliente.Columnas.CodigoCliente.ToString(),
                                               Entidades.Cliente.Columnas.NombreCliente.ToString()})
      End If
   End Sub
   Private Sub CargaGrillaProductos()
      Dim rProductos As Reglas.Productos = New Reglas.Productos()
      _objetosProductos.Dt.Clear()
      rProductos.CargarJSonEnDataTable(_objetosProductos.Transporte, _objetosProductos.Dt)

      If _objetosProductos.CountDt > 0 Then
         CargaGrilla(ugProductos, _objetosProductos.Dt, {Entidades.Producto.Columnas.IdProducto.ToString(),
                                                 Entidades.Producto.Columnas.NombreProducto.ToString(),
                                                 Entidades.Producto.Columnas.CodigoLargoProducto.ToString(),
                                                 Entidades.Producto.Columnas.NombreCorto.ToString(),
                                                 Entidades.Producto.Columnas.Observacion.ToString()})
      End If
   End Sub
   Private Sub CargaGrillaProductosSucursales()
      Dim rProdSuc As Reglas.ProductosSucursales = New Reglas.ProductosSucursales()
      _objetosProductosSucursales.Dt.Clear()
      rProdSuc.CargarJSonEnDataTable(_objetosProductosSucursales.Transporte, _objetosProductosSucursales.Dt)

      If _objetosProductosSucursales.CountDt > 0 Then
         CargaGrilla(ugProductosSucursales, _objetosProductosSucursales.Dt, {Entidades.Producto.Columnas.IdProducto.ToString()})
      End If
   End Sub
   Private Sub CargaGrillaProductosSucursalesPrecios()
      Dim rProdSuc As Reglas.ProductosSucursalesPrecios = New Reglas.ProductosSucursalesPrecios()
      _objetosProductosSucursalesPrecios.Dt.Clear()
      rProdSuc.CargarJSonEnDataTable(_objetosProductosSucursalesPrecios.Transporte, _objetosProductosSucursalesPrecios.Dt)

      If _objetosProductosSucursalesPrecios.CountDt > 0 Then
         CargaGrilla(ugProductosSucursalesPrecios, _objetosProductosSucursalesPrecios.Dt, {Entidades.Producto.Columnas.IdProducto.ToString()})
      End If
   End Sub

   Private Sub CargaGrillaLocalidades()
      Dim rLocalidades As Reglas.Localidades = New Reglas.Localidades()
      _objetosLocalidades.Dt.Clear()
      rLocalidades.CargarJSonEnDataTable(_objetosLocalidades.Transporte, _objetosLocalidades.Dt)

      If _objetosLocalidades.CountDt > 0 Then
         CargaGrilla(ugLocalidades, _objetosLocalidades.Dt, {Entidades.Localidad.Columnas.NombreLocalidad.ToString()})
      End If
   End Sub
   Private Sub CargaGrillaRubros()
      Dim rRubros As Reglas.Rubros = New Reglas.Rubros()
      _objetosRubros.Dt.Clear()
      rRubros.CargarJSonEnDataTable(_objetosRubros.Transporte, _objetosRubros.Dt)

      If _objetosRubros.CountDt > 0 Then
         CargaGrilla(ugRubros, _objetosRubros.Dt, {Entidades.Rubro.Columnas.NombreRubro.ToString()})
      End If
   End Sub
   Private Sub CargaGrillaSubRubros()
      Dim rSubRubros As Reglas.SubRubros = New Reglas.SubRubros()
      _objetosSubRubros.Dt.Clear()
      rSubRubros.CargarJSonEnDataTable(_objetosSubRubros.Transporte, _objetosSubRubros.Dt)

      If _objetosSubRubros.CountDt > 0 Then
         CargaGrilla(ugSubRubros, _objetosSubRubros.Dt, {Entidades.SubRubro.Columnas.NombreSubRubro.ToString()})
      End If
   End Sub
   Private Sub CargaGrillaSubSubRubros()
      Dim rSubSubRubros As Reglas.SubSubRubros = New Reglas.SubSubRubros()
      _objetosSubSubRubros.Dt.Clear()
      rSubSubRubros.CargarJSonEnDataTable(_objetosSubSubRubros.Transporte, _objetosSubSubRubros.Dt)

      If _objetosSubSubRubros.CountDt > 0 Then
         CargaGrilla(ugSubSubRubros, _objetosSubSubRubros.Dt, {Entidades.SubSubRubro.Columnas.NombreSubSubRubro.ToString()})
      End If
   End Sub

   Private Sub CargaGrillaMarcas()
      Dim rMarcas As Reglas.Marcas = New Reglas.Marcas()
      _objetosMarcas.Entidades.Clear()
      rMarcas.CargarJSonEnLista(_objetosMarcas.Transporte, _objetosMarcas.Entidades)

      If _objetosMarcas.Transporte.Count > 0 Then
         CargaGrilla(ugMarcas, _objetosMarcas.Entidades, {Entidades.Marca.Columnas.NombreMarca.ToString()})
      End If
   End Sub

   Private Sub CargaGrillaRubrosCompras()
      Dim rRubrosCompras As Reglas.RubrosCompras = New Reglas.RubrosCompras()
      _objetosRubrosCompras.Entidades.Clear()
      rRubrosCompras.CargarJSonEnLista(_objetosRubrosCompras.Transporte, _objetosRubrosCompras.Entidades)

      If _objetosRubrosCompras.Transporte.Count > 0 Then
         CargaGrilla(ugRubrosCompras, _objetosRubrosCompras.Entidades, {"NombreRubro"})
      End If
   End Sub

   Private Sub CargaGrillaProveedores()
      Dim rProveedores As Reglas.Proveedores = New Reglas.Proveedores()
      _objetosProveedores.Entidades.Clear()
      rProveedores.CargarJSonEnLista(_objetosProveedores.Transporte, _objetosProveedores.Entidades)

      If _objetosProveedores.Transporte.Count > 0 Then
         CargaGrilla(ugProveedores, _objetosProveedores.Entidades, {Entidades.Proveedor.Columnas.NombreProveedor.ToString(), Entidades.Proveedor.Columnas.NombreDeFantasia.ToString()})
      End If
   End Sub

   Private Sub CargaGrilla(grilla As UltraGrid, dt As Object, columnasContains As String())
      grilla.DataSource = dt
      MostrarInfo("Ajustando Grilla.")
      grilla.DisplayLayout.PerformAutoResizeColumns(False, UltraWinGrid.PerformAutoSizeType.VisibleRows)
      Ayudante.Grilla.InicializaTotales(grilla)
      With grilla.DisplayLayout.Bands(0)
         .Columns(EstadoColumnName).CellAppearance.TextHAlign = HAlign.Center
         .Columns(EstadoColumnName).Header.VisiblePosition = 0
         .Columns(MensajeErrorColumnName).Hidden = False
         .Columns(MensajeErrorColumnName).Header.VisiblePosition = 1
         Ayudante.Grilla.AgregarCountColumna(grilla, .Columns(EstadoColumnName))
      End With
      Ayudante.Grilla.AgregarFiltroEnLinea(grilla, columnasContains)
      For Each columna As String In columnasContains
         grilla.DisplayLayout.Bands(0).Columns(columna).FilterOperandDropDownItems = FilterOperandDropDownItems.ShowNone
      Next
      grilla.Rows.Refresh(RefreshRow.ReloadData)
   End Sub
#End Region
#Region "Metodos Manejo de Error"
   Private Sub InicializaValidacionIndividual(Of T)(controles As ObjetosDt(Of T))
      controles.Solapa.ImageIndex = -1
      LimpiaErroresDatatable(controles.Dt)
      EvaluaMuestraMensajeError(controles)
   End Sub
   Private Sub InicializaValidacionIndividual(Of T, U As Entidades.JSonEntidades.Archivos.IValidable)(controles As ObjetosEntidad(Of T, U))
      controles.Solapa.ImageIndex = -1
      LimpiaErroresDatatable(controles.Entidades)
      EvaluaMuestraMensajeError(controles)
   End Sub
   Private Sub InicializaValidacion()
      MostrarInfo("Inicializando Validaciones...")
      InicializaValidacionIndividual(_objetosClientes)
      InicializaValidacionIndividual(_objetosProductos)
      InicializaValidacionIndividual(_objetosProductosSucursales)
      InicializaValidacionIndividual(_objetosProductosSucursalesPrecios)

      InicializaValidacionIndividual(_objetosLocalidades)
      InicializaValidacionIndividual(_objetosRubros)
      InicializaValidacionIndividual(_objetosSubRubros)
      InicializaValidacionIndividual(_objetosSubSubRubros)

      InicializaValidacionIndividual(_objetosMarcas)

      InicializaValidacionIndividual(_objetosRubrosCompras)

      InicializaValidacionIndividual(_objetosProveedores)
   End Sub

   Private Sub ValidarDatosAImportar()
      'Orden de Validación:
      '  1.- Localidades
      '  2.- Marcas
      '  3.- Rubros
      '  4.- SubRubros                    (requiere de SubRubros y SubSubRubros)
      '  5.- SubSubRubros                 (requiere de SubSubRubros)
      '  6.- Clientes                     (requiere de Localidades)
      '  7.- Productos                    (requiere de Rubros, SubRubros y SubSubRubros)
      '  8.- ProductosSucursales          (requiere de Productos)
      '  9.- ProductosSucursalesPrecios   (requiere de Productos)

      If chbLocalidades.Checked AndAlso _objetosLocalidades.CountDt > 0 Then
         tbcDatos.SelectedTab = tbpLocalidades
         MostrarInfo("Validando información de localidades.")
         Dim rLocalidades As Reglas.Localidades = New Reglas.Localidades()
         Try
            AddHandler rLocalidades.AvanceValidarDatosLocalidades, AddressOf reglas_AvanceValidarDatos
            rLocalidades.ValidarDatos(_objetosLocalidades.Dt)
         Finally
            RemoveHandler rLocalidades.AvanceValidarDatosLocalidades, AddressOf reglas_AvanceValidarDatos
         End Try
         EvaluaMuestraMensajeError(_objetosLocalidades)
         _objetosLocalidades.Dt.AcceptChanges()

      End If

      If chbMarcas.Checked AndAlso _objetosMarcas.Entidades.Count > 0 Then
         tbcDatos.SelectedTab = tbpMarcas
         MostrarInfo("Validando información de marcas.")
         Dim rMarcas As Reglas.Marcas = New Reglas.Marcas()
         Try
            AddHandler rMarcas.AvanceValidarDatosMarcas, AddressOf reglas_AvanceValidarDatos
            rMarcas.ValidarDatos(_objetosMarcas.Entidades)
         Finally
            RemoveHandler rMarcas.AvanceValidarDatosMarcas, AddressOf reglas_AvanceValidarDatos
         End Try
         EvaluaMuestraMensajeError(_objetosMarcas)
         '_objetosMarcas.Dt.AcceptChanges()

      End If

      If chbRubrosCompras.Checked AndAlso _objetosRubrosCompras.Entidades.Count > 0 Then
         tbcDatos.SelectedTab = tbpRubrosCompras
         MostrarInfo("Validando información de rubros compras.")
         Dim rRubrosCompras As Reglas.RubrosCompras = New Reglas.RubrosCompras()
         Try
            AddHandler rRubrosCompras.AvanceValidarDatosRubrosCompras, AddressOf reglas_AvanceValidarDatos
            rRubrosCompras.ValidarDatos(_objetosRubrosCompras.Entidades, Nothing)
         Finally
            RemoveHandler rRubrosCompras.AvanceValidarDatosRubrosCompras, AddressOf reglas_AvanceValidarDatos
         End Try
         EvaluaMuestraMensajeError(_objetosRubrosCompras)
         '_objetosMarcas.Dt.AcceptChanges()

      End If

      If chbProveedores.Checked AndAlso _objetosProveedores.Entidades.Count > 0 Then
         tbcDatos.SelectedTab = tbpProveedores
         MostrarInfo("Validando información de proveedores.")
         Dim rProveedores As Reglas.Proveedores = New Reglas.Proveedores()
         Try
            AddHandler rProveedores.AvanceValidarDatosProveedores, AddressOf reglas_AvanceValidarDatos
            rProveedores.ValidarDatos(_objetosProveedores.Entidades)
         Finally
            RemoveHandler rProveedores.AvanceValidarDatosProveedores, AddressOf reglas_AvanceValidarDatos
         End Try
         EvaluaMuestraMensajeError(_objetosProveedores)
         '_objetosMarcas.Dt.AcceptChanges()
         _objetosProveedores.Grilla.Rows.Refresh(RefreshRow.ReloadData)
      End If

      If chbRubros.Checked Then
         If _objetosRubros.CountDt > 0 Then
            tbcDatos.SelectedTab = tbpRubros
            MostrarInfo("Validando información de rubros.")
            Dim rRubros As Reglas.Rubros = New Reglas.Rubros()
            Try
               AddHandler rRubros.AvanceValidarDatosRubros, AddressOf reglas_AvanceValidarDatos
               rRubros.ValidarDatos(_objetosRubros.Dt)
            Finally
               RemoveHandler rRubros.AvanceValidarDatosRubros, AddressOf reglas_AvanceValidarDatos
            End Try
            EvaluaMuestraMensajeError(_objetosRubros)
            _objetosRubros.Dt.AcceptChanges()
         End If

         If _objetosSubRubros.CountDt > 0 Then
            tbcDatos.SelectedTab = tbpSubRubro
            MostrarInfo("Validando información de Sub Rubros.")
            Dim rSubRubros As Reglas.SubRubros = New Reglas.SubRubros()
            Try
               AddHandler rSubRubros.AvanceValidarDatosSubRubros, AddressOf reglas_AvanceValidarDatos
               rSubRubros.ValidarDatos(_objetosSubRubros.Dt, _objetosRubros.Dt)
            Finally
               RemoveHandler rSubRubros.AvanceValidarDatosSubRubros, AddressOf reglas_AvanceValidarDatos
            End Try
            EvaluaMuestraMensajeError(_objetosSubRubros)
            _objetosSubRubros.Dt.AcceptChanges()
         End If

         If _objetosSubSubRubros.CountDt > 0 Then
            tbcDatos.SelectedTab = tbpProductosSucursalesPrecios
            MostrarInfo("Validando información de Sub Sub Rubros.")
            Dim rSubSubRubros As Reglas.SubSubRubros = New Reglas.SubSubRubros()
            Try
               AddHandler rSubSubRubros.AvanceValidarDatosSubSubRubros, AddressOf reglas_AvanceValidarDatos
               rSubSubRubros.ValidarDatos(_objetosSubSubRubros.Dt, _objetosSubRubros.Dt)
            Finally
               RemoveHandler rSubSubRubros.AvanceValidarDatosSubSubRubros, AddressOf reglas_AvanceValidarDatos
            End Try
            EvaluaMuestraMensajeError(_objetosSubSubRubros)
            _objetosSubSubRubros.Dt.AcceptChanges()
         End If

      End If


      If chbClientes.Checked AndAlso _objetosClientes.CountDt > 0 Then
         tbcDatos.SelectedTab = tbpClientes
         MostrarInfo("Validando información de clientes.")
         Dim rClientes As Reglas.Clientes = New Reglas.Clientes()
         Try
            AddHandler rClientes.AvanceValidarDatosClientes, AddressOf reglas_AvanceValidarDatos
            rClientes.ValidarDatos(_objetosClientes.Dt, _objetosLocalidades.Dt)
         Finally
            RemoveHandler rClientes.AvanceValidarDatosClientes, AddressOf reglas_AvanceValidarDatos
         End Try
         EvaluaMuestraMensajeError(_objetosClientes)
         _objetosClientes.Dt.AcceptChanges()

      End If
      If chbProductos.Checked Then
         Dim cache As Reglas.BusquedasCacheadas = New Reglas.BusquedasCacheadas()
         If _objetosProductos.CountDt > 0 Then
            tbcDatos.SelectedTab = tbpProductos
            MostrarInfo("Validando información de productos.")
            Dim rProductos As Reglas.Productos = New Reglas.Productos()
            Try
               AddHandler rProductos.AvanceValidarDatosProductos, AddressOf reglas_AvanceValidarDatos
               rProductos.ValidarDatosProductos(_objetosProductos.Dt, cache,
                                                _objetosRubros.Dt,
                                                _objetosSubRubros.Dt,
                                                _objetosSubSubRubros.Dt,
                                                _objetosMarcas.Transporte)
            Finally
               RemoveHandler rProductos.AvanceValidarDatosProductos, AddressOf reglas_AvanceValidarDatos
            End Try
            EvaluaMuestraMensajeError(_objetosProductos)
            _objetosProductos.Dt.AcceptChanges()
         End If

         If _objetosProductosSucursales.CountDt > 0 Then
            tbcDatos.SelectedTab = tbpProductosSucursales
            MostrarInfo("Validando información de Stock.")
            Dim rProductosSucursales As Reglas.ProductosSucursales = New Reglas.ProductosSucursales()
            Try
               AddHandler rProductosSucursales.AvanceValidarDatosProductosSucursales, AddressOf reglas_AvanceValidarDatos
               rProductosSucursales.ValidarDatos(_objetosProductosSucursales.Dt, cache, _objetosProductos.Dt)
            Finally
               RemoveHandler rProductosSucursales.AvanceValidarDatosProductosSucursales, AddressOf reglas_AvanceValidarDatos
            End Try
            EvaluaMuestraMensajeError(_objetosProductosSucursales)
            _objetosProductosSucursales.Dt.AcceptChanges()
         End If

         If _objetosProductosSucursalesPrecios.CountDt > 0 Then
            tbcDatos.SelectedTab = tbpProductosSucursalesPrecios
            MostrarInfo("Validando información de Precios.")
            Dim rProductosSucursalesPrecios As Reglas.ProductosSucursalesPrecios = New Reglas.ProductosSucursalesPrecios()
            Try
               AddHandler rProductosSucursalesPrecios.AvanceValidarDatosProductosSucursalesPrecios, AddressOf reglas_AvanceValidarDatos
               rProductosSucursalesPrecios.ValidarDatosPrecios(_objetosProductosSucursalesPrecios.Dt, cache, _objetosProductos.Dt)
            Finally
               RemoveHandler rProductosSucursalesPrecios.AvanceValidarDatosProductosSucursalesPrecios, AddressOf reglas_AvanceValidarDatos
            End Try
            EvaluaMuestraMensajeError(_objetosProductosSucursalesPrecios)
            _objetosProductosSucursalesPrecios.Dt.AcceptChanges()
         End If
      End If

   End Sub

   Private Sub LimpiaErroresDatatable(dt As DataTable)
      For Each dr As DataRow In dt.Rows
         dr(EstadoColumnName) = String.Empty
         dr(MensajeErrorColumnName) = String.Empty
         dr.ClearErrors()
      Next
   End Sub
   Private Sub LimpiaErroresDatatable(Of T As Entidades.JSonEntidades.Archivos.IValidable)(dt As List(Of T))
      For Each dr As Entidades.JSonEntidades.Archivos.IValidable In dt
         dr.___Estado = String.Empty
         dr.___MensajeError = String.Empty
         dr.ConErrores = False
      Next
   End Sub
   Private Sub EvaluaMuestraMensajeError(Of T)(controles As ObjetosDt(Of T))
      If controles.Dt.Rows.Count = 0 Then Exit Sub

      controles.Grilla.DisplayLayout.Bands(0).Columns(MensajeErrorColumnName).Hidden = Not controles.Dt.HasErrors
      controles.Grilla.DisplayLayout.Bands(0).Columns(MensajeErrorColumnName).MaxWidth = 450
      controles.Grilla.DisplayLayout.Bands(0).Columns(MensajeErrorColumnName).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, False)
      If controles.Dt.HasErrors Then
         controles.Solapa.ImageIndex = 0
      Else
         controles.Solapa.ImageIndex = -1
      End If
   End Sub
   Private Sub EvaluaMuestraMensajeError(Of T, U As Entidades.JSonEntidades.Archivos.IValidable)(controles As ObjetosEntidad(Of T, U))
      If controles.Entidades.Count = 0 Then Exit Sub

      'controles.Grilla.DisplayLayout.Bands(0).Columns(MensajeErrorColumnName).Hidden = Not controles.Dt.HasErrors
      'controles.Grilla.DisplayLayout.Bands(0).Columns(MensajeErrorColumnName).MaxWidth = 450
      'controles.Grilla.DisplayLayout.Bands(0).Columns(MensajeErrorColumnName).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, False)
      'If controles.Dt.HasErrors Then
      '   controles.Solapa.ImageIndex = 0
      'Else
      '   controles.Solapa.ImageIndex = -1
      'End If
   End Sub
#End Region

#Region "Importar Datos"
   Private Sub ImportarDatosIndividual(Of T)(controles As ObjetosDt(Of T), regla As Reglas.IRestServices)
      If controles.Seleccionado.Checked Then
         Try
            tbcDatos.SelectedTab = controles.Solapa
            AddHandler regla.AvanceImportarDatos, AddressOf reglas_AvanceImportarDatos
            regla.ImportarDesdeWebSiga(controles.Dt)
         Finally
            RemoveHandler regla.AvanceImportarDatos, AddressOf reglas_AvanceImportarDatos
         End Try
      End If
   End Sub

   Private Sub ImportarDatosIndividual(Of T, U As Entidades.JSonEntidades.Archivos.IValidable)(controles As ObjetosEntidad(Of T, U), regla As Reglas.IRestServices)
      If controles.Seleccionado.Checked Then
         Try
            tbcDatos.SelectedTab = controles.Solapa
            AddHandler regla.AvanceImportarDatos, AddressOf reglas_AvanceImportarDatos
            regla.ImportarDesdeWebSiga(controles.Entidades)
         Finally
            controles.Grilla.Rows.Refresh(RefreshRow.ReloadData)
            RemoveHandler regla.AvanceImportarDatos, AddressOf reglas_AvanceImportarDatos
         End Try
      End If
   End Sub

   Private Sub ImportarDatos()

      ImportarDatosIndividual(_objetosLocalidades, New Reglas.Localidades())

      ImportarDatosIndividual(_objetosMarcas, New Reglas.Marcas())

      ImportarDatosIndividual(_objetosRubrosCompras, New Reglas.RubrosCompras())

      ImportarDatosIndividual(_objetosProveedores, New Reglas.Proveedores())

      ImportarDatosIndividual(_objetosRubros, New Reglas.Rubros())
      ImportarDatosIndividual(_objetosSubRubros, New Reglas.SubRubros())
      ImportarDatosIndividual(_objetosSubSubRubros, New Reglas.SubSubRubros())

      ImportarDatosIndividual(_objetosClientes, New Reglas.Clientes())

      ImportarDatosIndividual(_objetosProductos, New Reglas.Productos())
      ImportarDatosIndividual(_objetosProductosSucursales, New Reglas.ProductosSucursales())
      ImportarDatosIndividual(_objetosProductosSucursalesPrecios, New Reglas.ProductosSucursalesPrecios())

   End Sub
#End Region

#End Region

   Public Class ObjetosDt(Of T)
      Inherits Objetos(Of T)
      Public Property Dt As DataTable

      Public Sub New(nombre As String, grilla As UltraGrid, paginaActual As Label, totalPaginas As Label, solapa As TabPage,
               seleccionado As CheckBox, cantidad As Label, fechaActualizacion As DateTimePicker, reenviarTodo As CheckBox,
               cargaGrillaClientesCallback As CargaGrillaCallbackDelegate)
         MyBase.New(nombre, grilla, paginaActual, totalPaginas, solapa, seleccionado, cantidad, fechaActualizacion, reenviarTodo,
                    cargaGrillaClientesCallback)
         Dt = SincronizacionBajada.NewDataTable()
      End Sub

      Public ReadOnly Property CountDt As Integer
         Get
            If Dt Is Nothing Then Return 0
            Return Dt.Rows.Count
         End Get
      End Property

   End Class

   Public Class ObjetosEntidad(Of T, U As Entidades.JSonEntidades.Archivos.IValidable)
      Inherits Objetos(Of T)
      Public Property Entidades As List(Of U)

      Public Sub New(nombre As String, grilla As UltraGrid, paginaActual As Label, totalPaginas As Label, solapa As TabPage,
               seleccionado As CheckBox, cantidad As Label, fechaActualizacion As DateTimePicker, reenviarTodo As CheckBox,
               cargaGrillaClientesCallback As CargaGrillaCallbackDelegate)
         MyBase.New(nombre, grilla, paginaActual, totalPaginas, solapa, seleccionado, cantidad, fechaActualizacion, reenviarTodo,
                    cargaGrillaClientesCallback)
         'Dt = SincronizacionBajada.NewDataTable()
         Entidades = New List(Of U)()
      End Sub

      Public ReadOnly Property ConErrores As Boolean
         Get
            Return CountConErrores > 0
         End Get
      End Property

      Public ReadOnly Property CountConErrores As Integer
         Get
            Return Entidades.Where(Function(x) x.ConErrores).Count()
         End Get
      End Property

      Public ReadOnly Property CountSinErrores As Integer
         Get
            Return Entidades.Where(Function(x) Not x.ConErrores).Count()
         End Get
      End Property

   End Class

   Public Class Objetos(Of T)
      Public Delegate Sub CargaGrillaCallbackDelegate()
      Public Property Nombre As String

      Public Property Transporte As List(Of T)
      ''Public Property Dt As DataTable
      Public Property Grilla As UltraGrid

      Public Property PaginaActual As Label
      Public Property TotalPaginas As Label
      Public Property Solapa As TabPage

      Public Property Seleccionado As CheckBox
      Public Property Cantidad As Label

      Public Property FechaActualizacion As DateTimePicker
      Public Property ReenviarTodo As CheckBox
      Public Property CargaGrillaCallback As CargaGrillaCallbackDelegate

      Public Sub New(nombre As String, grilla As UltraGrid, paginaActual As Label, totalPaginas As Label, solapa As TabPage,
                     seleccionado As CheckBox, cantidad As Label, fechaActualizacion As DateTimePicker, reenviarTodo As CheckBox,
                     cargaGrillaClientesCallback As CargaGrillaCallbackDelegate)
         Transporte = New List(Of T)()
         'Dt = SincronizacionBajada.NewDataTable()
         Me.Nombre = nombre
         Me.Grilla = grilla
         Me.PaginaActual = paginaActual
         Me.TotalPaginas = totalPaginas
         Me.FechaActualizacion = fechaActualizacion
         Me.ReenviarTodo = reenviarTodo
         Me.Seleccionado = seleccionado
         Me.Cantidad = cantidad
         Me.CargaGrillaCallback = cargaGrillaClientesCallback
         Me.Solapa = solapa
      End Sub

   End Class

End Class