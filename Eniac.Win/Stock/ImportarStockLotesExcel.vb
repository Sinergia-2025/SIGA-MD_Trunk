Public Class ImportarStockLotesExcel

#Region "Campos"
   Private _publicos As Publicos

   Public ReadOnly Property dtDetalle As DataTable
      Get
         Return ugDetalle.DataSource(Of DataTable)
      End Get
   End Property

   Private Const ImportaColumnName = Reglas.ProductosSucursales.ImportarStockLotes.ImportaColumnName
   Private Const AccionColumnName = Reglas.ProductosSucursales.ImportarStockLotes.AccionColumnName
   Private Const DescripcionColumnName = Reglas.ProductosSucursales.ImportarStockLotes.DescripcionColumnName
   Private Const MensajeColumnName = Reglas.ProductosSucursales.ImportarStockLotes.MensajeColumnName
   Private Const AccionAlta = Reglas.ProductosSucursales.ImportarStockLotes.AccionAlta
   Private Const AccionModif = Reglas.ProductosSucursales.ImportarStockLotes.AccionModif
   Private Const AccionError = Reglas.ProductosSucursales.ImportarStockLotes.AccionError
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         CargarValoresIniciales()
         _publicos = New Publicos()
         ugDetalle.AgregarFiltroEnLinea({DescripcionColumnName})
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbImportar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnLeerExel.PerformClick()
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
         ugDetalle.UpdateData()

         Dim dtDetalle = ugDetalle.DataSource(Of DataTable)
         If dtDetalle Is Nothing Then Exit Sub

         Dim totalRegistros = dtDetalle.Count
         Dim totalSinError = dtDetalle.Count(Function(dr) dr.Field(Of Boolean)(ImportaColumnName))
         Dim totalConError = dtDetalle.Count(Function(dr) Not dr.Field(Of Boolean)(ImportaColumnName))

         Dim stb = New StringBuilder()
         stb.AppendFormatLine("Cantidad de registros leidos del Excel: {0}", totalRegistros)
         stb.AppendFormatLine("Cantidad de registros a Importar: {0}", totalSinError)
         If totalConError > 0 Then
            stb.AppendLine().AppendFormatLine("Cantidad de registros a con Error: {0}", totalSinError)
         End If
         stb.AppendLine().AppendFormat("¿Esta Seguro de Actualizar el Stock de los Productos?")

         If ShowPregunta(stb.ToString()) = DialogResult.Yes Then
            Enabled = False
            Dim rProductosSucursales = New Reglas.ProductosSucursales.ImportarStockLotes()
            Try
               AddHandler rProductosSucursales.AvanceAjusteMasivoStock, Sub(sender1, e1) MostrarInfo(e1.Mensaje)
               rProductosSucursales.Importar(dtDetalle, reprocesa:=False, idFuncion:=IdFuncion)
            Catch ex As Reglas.ProductosSucursales.ValidacionAjusteMasivoStockException
               If ShowPregunta(ex.Message) = Windows.Forms.DialogResult.Yes Then
                  rProductosSucursales.Importar(dtDetalle, reprocesa:=True, idFuncion:=IdFuncion)
               Else
                  Throw New Exception("Actualización cancelada por el usuario", ex)
               End If
            End Try

            ShowMessage("¡Actualización relizada exitosamente!")

            Mostrar()
         End If
      End Sub)
      Enabled = True
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub
#End Region

   Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
      TryCatched(
      Sub()
         Dim DialogoAbrirArchivo = New OpenFileDialog With {
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop,
            .Filter = "Libro de Excel 97-2003 (*.xls)|*.xls|Libro de Excel 2007-2010 (*.xlsx)|*.xlsx|Todos los Archivos (*.*)|*.*",
            .FilterIndex = 1,
            .RestoreDirectory = True
         }
         If DialogoAbrirArchivo.ShowDialog() = DialogResult.OK Then
            txtArchivoOrigen.Text = DialogoAbrirArchivo.FileName
            txtRangoCeldasFilaHasta.Focus()
         End If
      End Sub)
   End Sub

   Private Sub btnLeerExel_Click(sender As Object, e As EventArgs) Handles btnLeerExel.Click
      TryCatched(
      Sub()
         Enabled = False

         tsbImportar.Enabled = True

         If Not Reglas.Publicos.VisualizaLote Then
            ShowMessage("ATENCION: Los productos no utilizan Lote.")
            Exit Sub
         End If

         If String.IsNullOrWhiteSpace(txtArchivoOrigen.Text) Then
            Exit Sub
         End If

         If Not My.Computer.FileSystem.FileExists(txtArchivoOrigen.Text) Then
            ShowMessage("ATENCION: El archivo a Importar NO Existe")
            Exit Sub
         End If

         Mostrar()
      End Sub)
      Enabled = True

      MostrarInfo(String.Empty)
   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            Dim accion = dr.Field(Of String)(AccionColumnName)
            If accion = AccionAlta Then
               e.Row.Cells(ImportaColumnName).Color(Nothing, Color.LimeGreen)
            ElseIf accion = AccionModif Then
               e.Row.Cells(ImportaColumnName).Color(Nothing, Color.Yellow)
            ElseIf accion = AccionError Then
               e.Row.Cells(ImportaColumnName).Color(Color.White, Color.Red)
            Else
               e.Row.Cells(ImportaColumnName).ColorClear()
            End If
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()
      tsbImportar.Enabled = False

      txtArchivoOrigen.Clear()
      txtRangoCeldasColumnaDesde.Text = "A"
      txtRangoCeldasFilaDesde.Text = "4"
      txtRangoCeldasColumnaHasta.Text = ":G"
      txtRangoCeldasFilaHasta.Clear()

      ugDetalle.ClearFilas()

      txtArchivoOrigen.Focus()
   End Sub

   Private Sub Mostrar()
      Dim rangoExcel = String.Format("[{0}{1}{2}{3}]",
                                     txtRangoCeldasColumnaDesde.Text.Trim(), txtRangoCeldasFilaDesde.Text.Trim(),
                                     txtRangoCeldasColumnaHasta.Text.Trim(), txtRangoCeldasFilaHasta.Text.Trim())
      Mostrar(rangoExcel)
   End Sub
   Private Sub Mostrar(rangoExcel As String)
      Try
         tsbImportar.Enabled = False
         tsbSalir.Enabled = False

         Dim regla = New Reglas.ProductosSucursales.ImportarStockLotes()
         Dim dt = regla.LeerExcel(txtArchivoOrigen.Text, rangoExcel, Sub(msg) MostrarInfo(msg))

         ugDetalle.DataSource = dt

         ugDetalle.DisplayLayout.Bands(0).Columns(MensajeColumnName).PerformAutoResize(PerformAutoSizeType.AllRowsInBand)
      Catch
         txtRangoCeldasFilaHasta.Focus()
         Throw
      Finally
         tsbImportar.Enabled = True
         tsbSalir.Enabled = True
      End Try
   End Sub
   Private Sub MostrarInfo(mensaje As String)
      tssInfo.Text = mensaje
      Application.DoEvents()
   End Sub

#End Region
End Class