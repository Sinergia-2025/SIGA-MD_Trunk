Public Class SincronizacionBajadaCobranzas

#Region "Campos"
   Private WithEvents sincronizacion As Reglas.ServiciosRest.CobranzasMovil.SincronizacionSubidaMovil
   Private cobranzas As List(Of Entidades.JSonEntidades.CobranzasMovil.Cobranzas)

   Private _titCobranzas As Dictionary(Of String, String)
#End Region

#Region "Constructor/Factory"
   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      TryCatched(
         Sub()
            sincronizacion = New Reglas.ServiciosRest.CobranzasMovil.SincronizacionSubidaMovil()
            RefrescarGrilla()
         End Sub)
   End Sub

   Private _regla As Reglas.Cobranzas
   Private Function GetRegla() As Reglas.Cobranzas
      Return New Reglas.Cobranzas(sincronizacion)
   End Function
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _titCobranzas = GetColumnasVisiblesGrilla(ugCobranzas)
            CargarColumnasASumar()
            ugCobranzas.AgregarFiltroEnLinea({"IdDispositivo", "NombreCliente", "Observaciones", "MensajeError"})
            PreferenciasLeer(ugCobranzas, tsbPreferencias)
         End Sub)
   End Sub

#End Region

#Region "Eventos"
#Region "Eventos ToolBar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarGrilla())
   End Sub
   Private Sub tsbBajarDatos_Click(sender As Object, e As EventArgs) Handles tsbBajarDatos.Click
      TryCatched(Sub() BajarDatos())
   End Sub
   Private Sub tsbImportar_Click(sender As Object, e As EventArgs) Handles tsbImportar.Click
      TryCatched(
         Sub()
            tstBarra.Enabled = False
            If ShowPregunta("¿Desea importar las cobranzas pendientes?" + Environment.NewLine + Environment.NewLine +
                         "(se importarán Pendientes y con Advertencia)") = Windows.Forms.DialogResult.Yes Then
               ImportarCobranzas()
            End If
         End Sub,
         onFinallyAction:=
         Sub(owner)
            ugCobranzas.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
            Cursor = Cursors.Default
            tstBarra.Enabled = True
         End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

   Private Sub ugCobranzas_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles ugCobranzas.InitializeRow
      TryCatched(
         Sub()
            If e.Row.ListObject IsNot Nothing AndAlso
               TypeOf (e.Row.ListObject) Is Entidades.JSonEntidades.CobranzasMovil.Cobranzas Then
               Dim cobranza As Entidades.JSonEntidades.CobranzasMovil.Cobranzas = DirectCast(e.Row.ListObject, Entidades.JSonEntidades.CobranzasMovil.Cobranzas)

               Dim key As String = "EstadoImportacion"
               If cobranza.EstadoImportacion = Entidades.JSonEntidades.CobranzasMovil.Cobranzas.EstadosImportacion.Pendiente Then
                  ColorEstadoImportacion(e.Row.Cells(key), Color.LightGreen, Color.Black, DefaultableBoolean.Default)
               ElseIf cobranza.EstadoImportacion = Entidades.JSonEntidades.CobranzasMovil.Cobranzas.EstadosImportacion.Advertencia Then
                  ColorEstadoImportacion(e.Row.Cells(key), Color.Yellow, Color.Black, DefaultableBoolean.Default)
               ElseIf cobranza.EstadoImportacion = Entidades.JSonEntidades.CobranzasMovil.Cobranzas.EstadosImportacion.Error Then
                  ColorEstadoImportacion(e.Row.Cells(key), Color.Red, Color.White, DefaultableBoolean.True)
               ElseIf cobranza.EstadoImportacion = Entidades.JSonEntidades.CobranzasMovil.Cobranzas.EstadosImportacion.Procesado Then
                  ColorEstadoImportacion(e.Row.Cells(key), Color.Gray, Color.DarkGray, DefaultableBoolean.Default)
               Else
                  ColorEstadoImportacion(e.Row.Cells(key), Nothing, Nothing, DefaultableBoolean.Default)
               End If

            End If
         End Sub)
   End Sub

   Private Sub rCobranzas_Avance(sender As Object, e As Reglas.Cobranzas.ReglasCobranzasEventArgs)
      TryCatched(Sub() MostrarInfo(e.Mensaje))
   End Sub
#End Region

#Region "Metodos"
   Private Sub CargarColumnasASumar()

      ugCobranzas.AgregarTotalesSuma({"ImportePesos"})

   End Sub
   Private Sub RefrescarGrilla()

      If cobranzas IsNot Nothing Then
         cobranzas.Clear()
         ugCobranzas.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
      End If

      MostrarInfo(String.Empty)
      MuestraCantidadRegistros()
   End Sub

   Private Sub BajarDatos()
      Try
         Cursor = Cursors.WaitCursor
         MostrarInfo(String.Empty)
         Dim rCobranzas As Reglas.Cobranzas = GetRegla()

         Dim sucursales = New Reglas.Sucursales().GetTodosParaSincronizarSegunIncluir(Reglas.Publicos.SimovilCobranzaSucursales).
                                                   ConvertAll(Function(s) s.IdSucursal).ToArray()

         cobranzas = rCobranzas.ValidarCobranzas(sincronizacion.ObtenerCobranzas(sucursales))

         ugCobranzas.DataSource = cobranzas
         AjustarColumnasGrilla(ugCobranzas, _titCobranzas)

         MuestraCantidadRegistros()

         If cobranzas.Count = 0 Then
            ShowMessage("No existen cobranzas para importar.")
         End If
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub MuestraCantidadRegistros()
      Dim cant As Long = 0
      If cobranzas IsNot Nothing Then cant = cobranzas.LongCount
      tssRegistros.Text = String.Format("{0} Registros", cant)
   End Sub

   Private Sub ImportarCobranzas()
      If cobranzas IsNot Nothing AndAlso cobranzas.Count > 0 Then

         Dim reglas As Reglas.Cobranzas = GetRegla()
         Try
            AddHandler reglas.Avance, AddressOf rCobranzas_Avance

            reglas.Importar(cobranzas, IdFuncion)

            ShowMessage("Actualización exitosa!")

         Finally
            RemoveHandler reglas.Avance, AddressOf rCobranzas_Avance
         End Try

         BajarDatos()
      Else
         ShowMessage("No hay cobranzas para importar.")
      End If
   End Sub

   Private Sub MostrarInfo(mensaje As String)
      tssInfo.Text = mensaje
      Application.DoEvents()
   End Sub

   Private Sub ColorEstadoImportacion(cell As UltraGridCell, backColor As Color, foreColor As Color, bold As DefaultableBoolean)
      cell.Appearance.BackColor = backColor
      cell.Appearance.ForeColor = foreColor
      cell.Appearance.FontData.Bold = bold
      cell.ActiveAppearance.BackColor = backColor
      cell.ActiveAppearance.ForeColor = foreColor
      cell.ActiveAppearance.FontData.Bold = bold
      If cell.HasSelectedAppearance Then
         cell.SelectedAppearance.BackColor = backColor
         cell.SelectedAppearance.ForeColor = foreColor
         cell.SelectedAppearance.FontData.Bold = bold
      End If
   End Sub
#End Region

   Private Sub tsbImportarAutomaticamente_Click(sender As Object, e As EventArgs) Handles tsbImportarAutomaticamente.Click
      TryCatched(
         Sub()
            Dim r = New Reglas.Cobranzas(sincronizacion)
            r.ImportarAutomaticamente(IdFuncion)

            ShowMessage("Actualización exitosa!")
            RefrescarGrilla()
         End Sub)
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(
     Sub()
        If Me.ugCobranzas.Rows.Count() = 0 Then Exit Sub

        Dim titulo = String.Format("{1}{0}{0}{2}{0}{0}{3}", Environment.NewLine, Publicos.NombreEmpresaImpresion, Text, CargarFiltrosImpresion())
        Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
        UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

        UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
        UltraPrintPreviewD.Name = Me.Text

        UltraGridPrintDocument1.Header.TextCenter = titulo
        UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
        UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
        UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
        UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
        UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
        UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
        UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
        UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
        UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

        UltraPrintPreviewD.MdiParent = Me.MdiParent
        UltraPrintPreviewD.Show()
        UltraPrintPreviewD.Focus()
     End Sub)
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(
       Sub()
          If Me.ugCobranzas.Rows.Count = 0 Then Exit Sub
          Me.ugCobranzas.Exportar(Name & ".xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
       End Sub)
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(
       Sub()
          If Me.ugCobranzas.Rows.Count = 0 Then Exit Sub
          Me.ugCobranzas.Exportar(Name & ".pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
       End Sub)
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(Me.ugCobranzas, tsbPreferencias))
   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro = New StringBuilder()
      Dim primero As Boolean = True

      With filtro
      End With

      Return filtro.ToString()
   End Function
End Class