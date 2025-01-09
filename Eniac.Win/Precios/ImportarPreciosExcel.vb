Public Class ImportarPreciosExcel

#Region "Campos"

   'Public Resultado As Boolean
   Public Property IdListaDePrecios As Integer
   Public Property NombreListaDePrecios As String
   Public Property Precios As DataTable

   Private _publicos As Publicos
   Private _listaPrecios As List(Of Entidades.ListaDePrecios)

   Private _rangoCeldasColumnaDesde As String
   Private _rangoCeldasFilaDesde As String
   Private _rangoCeldasColumnaHasta As String
   Private _rangoCeldasFilaHasta As String

#End Region
   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(listaPrecios As List(Of Entidades.ListaDePrecios))
      Me.New()
      _listaPrecios = listaPrecios
   End Sub

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _rangoCeldasColumnaDesde = txtRangoCeldasColumnaDesde.Text
         _rangoCeldasFilaDesde = txtRangoCeldasFilaDesde.Text
         _rangoCeldasColumnaHasta = txtRangoCeldasColumnaHasta.Text
         _rangoCeldasFilaHasta = txtRangoCeldasFilaHasta.Text

         If _listaPrecios IsNot Nothing Then
            _publicos.CargaComboListaDePrecios(cmbListaDePrecios, _listaPrecios)
         Else
            _publicos.CargaComboListaDePrecios(cmbListaDePrecios)
         End If
         CargarValoresIniciales()

         ugPrecios.AgregarFiltroEnLinea({Reglas.ImportarPreciosExcel.NombreProductoColumnName})

      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbImportar.PerformClick()
      ElseIf keyData = Keys.Escape Then
         Close(DialogResult.Cancel)
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() CargarValoresIniciales())
   End Sub
   Private Sub tsbImportar_Click(sender As Object, e As EventArgs) Handles tsbImportar.Click
      TryCatched(
      Sub()
         If cmbListaDePrecios.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Debe seleccionar una lista de Precios...")
            Exit Sub
         End If

         IdListaDePrecios = cmbListaDePrecios.ValorSeleccionado(Of Integer)
         NombreListaDePrecios = cmbListaDePrecios.Text
         Precios = ugPrecios.DataSource(Of DataTable)
         Close(DialogResult.OK)
      End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close(DialogResult.Cancel)
   End Sub
#End Region

   Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
      TryCatched(
      Sub()
         frmOpenFile.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop

         If frmOpenFile.ShowDialog() = DialogResult.OK Then
            txtArchivoOrigen.Text = frmOpenFile.FileName
            txtRangoCeldasFilaHasta.Focus()
         End If
      End Sub)
   End Sub
   Private Sub btnLeerExel_Click(sender As Object, e As EventArgs) Handles btnLeerExel.Click
      TryCatched(
      Sub()
         If String.IsNullOrWhiteSpace(txtArchivoOrigen.Text) Then
            ShowMessage("ATENCION: No ha seleccionado un archivo para Importar")
            Exit Sub
         End If

         If Not IO.File.Exists(txtArchivoOrigen.Text) Then
            ShowMessage("ATENCION: El archivo a Importar NO Existe")
            Exit Sub
         End If

         If cmbListaDePrecios.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Debe seleccionar una lista de Precios...")
            Exit Sub
         End If

         tsbImportar.Enabled = False
         tsbSalir.Enabled = False
         CargaGrillaDetalle()
      End Sub,
      onFinallyAction:=
      Sub(owner)
         tsbImportar.Enabled = True
         tsbSalir.Enabled = True
      End Sub)
   End Sub

#Region "Eventos Filtros"
   Private Sub chbLeeCosto_CheckedChanged(sender As Object, e As EventArgs) Handles chbLeeCosto.CheckedChanged
      TryCatched(
      Sub()
         txtIncrementoCosto.Enabled = chbLeeCosto.Checked
         If Not chbLeeCosto.Checked Then
            txtIncrementoCosto.SetValor(0)
         Else
            txtIncrementoCosto.Focus()
         End If
      End Sub)
   End Sub
   Private Sub chbLeeVenta_CheckedChanged(sender As Object, e As EventArgs) Handles chbLeeVenta.CheckedChanged
      TryCatched(
      Sub()
         txtIncrementoVenta.Enabled = chbLeeVenta.Checked
         If Not chbLeeVenta.Checked Then
            txtIncrementoVenta.SetValor(0)
         Else
            txtIncrementoVenta.Focus()
         End If
      End Sub)
   End Sub
#End Region

   Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRangoCeldasFilaHasta.KeyDown, txtRangoCeldasFilaDesde.KeyDown, txtRangoCeldasColumnaHasta.KeyDown, txtRangoCeldasColumnaDesde.KeyDown, txtPrefijo.KeyDown, txtIncrementoCosto.KeyDown, txtArchivoOrigen.KeyDown, cmbListaDePrecios.KeyDown
      PresionarTab(e)
   End Sub
   Private Sub txtIncrementoVenta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIncrementoVenta.KeyDown
      TryCatched(
      Sub()
         If e.KeyCode = Keys.Enter Then
            btnLeerExel.Focus()
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()
      txtArchivoOrigen.Clear()

      txtRangoCeldasColumnaDesde.Text = _rangoCeldasColumnaDesde
      txtRangoCeldasFilaDesde.Text = _rangoCeldasFilaDesde
      txtRangoCeldasColumnaHasta.Text = _rangoCeldasColumnaHasta
      txtRangoCeldasFilaHasta.Text = _rangoCeldasFilaHasta

      txtPrefijo.Clear()

      chbLeeCosto.Checked = True
      txtIncrementoCosto.SetValor(0)
      chbLeeVenta.Checked = True
      txtIncrementoVenta.SetValor(0)

      cmbListaDePrecios.SelectedValue = Reglas.Publicos.ListaPreciosPredeterminada
      If cmbListaDePrecios.SelectedIndex = -1 AndAlso cmbListaDePrecios.Items.Count > 0 Then
         cmbListaDePrecios.SelectedIndex = 0
      End If

      ugPrecios.ClearFilas()
      tssRegistros.Text = ugPrecios.CantidadRegistrosParaStatusbar

      txtArchivoOrigen.Focus()
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim dtPrecios = New Reglas.ImportarPreciosExcel().
                  LeerPreciosDesdeExcel(txtArchivoOrigen.Text,
                                        txtRangoCeldasColumnaDesde.Text, txtRangoCeldasFilaDesde.ValorNumericoPorDefecto(0I),
                                        txtRangoCeldasColumnaHasta.Text, txtRangoCeldasFilaHasta.ValorNumericoPorDefecto(0I),
                                        txtPrefijo.Text,
                                        chbLeeCosto.Checked, txtIncrementoCosto.ValorNumericoPorDefecto(0D),
                                        chbLeeVenta.Checked, txtIncrementoVenta.ValorNumericoPorDefecto(0D))

      ugPrecios.DataSource = dtPrecios
      tssRegistros.Text = ugPrecios.CantidadRegistrosParaStatusbar
   End Sub

#End Region

End Class