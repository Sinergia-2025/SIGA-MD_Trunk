Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.IO

Public Class DebitosAutTarjetasPresentacion

#Region "Campos"

   Private _publicos As Publicos
   Private _publicosEniac As Eniac.Win.Publicos
   Private _detalle As DataTable
   Private _banco As Eniac.Entidades.Banco
   Private _cobrador As Eniac.Entidades.Empleado

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         'TODO: DB
         ' ''Dim existeAlgunaFoto As Boolean = New Reglas.Liquidaciones().ExisteFoto(0, Nothing)
         ' ''chbTomaFoto.Visible = existeAlgunaFoto
         ' ''chbTomaFoto.Checked = existeAlgunaFoto

         Me._publicos = New Publicos()
         Me._publicosEniac = New Eniac.Win.Publicos()

         Me._publicosEniac.CargaComboTarjetas(Me.cmbTarTarjeta)

         Me.tssRegistros.Text = ""

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.FormatearColumnas()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub ugDetalle_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout

      e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow

      e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)

      e.Layout.Override.SpecialRowSeparatorHeight = 6

      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft

      e.Layout.ViewStyle = ViewStyle.SingleBand

      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If Me.ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbGenerar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGenerar.Click

      Try

         Me.ugDetalle.UpdateData()

         If Me.cmbTarTarjeta.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe Seleccionar el Tipo de Tarjeta !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         Me.ugDetalle.EndUpdate()

         Dim Cant As Integer = 0
         For Each dr As UltraGridRow In Me.ugDetalle.Rows
            If dr.Cells("Selec").Value IsNot Nothing AndAlso CBool(dr.Cells("Selec").Value.ToString()) Then
               Cant = Cant + 1
            End If
         Next

         If Cant = 0 Then
            MessageBox.Show("ATENCION: NO Seleccionó Ningún Registro !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         If Me.dtpFechaVencimiento.Value.Subtract(Date.Now).Days < 2 Then
            MessageBox.Show("ATENCION: Va a Generar los Débito a Clientes con Fecha menor a 2 Dias Habiles!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If

         Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()

         stb.AppendFormat("¿Realmente desea generar el archivo para el Banco?", Me.ugDetalle.Rows.Count.ToString())

         If MessageBox.Show(stb.ToString(), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim dga As SaveFileDialog = New SaveFileDialog()

            dga.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            dga.Filter = "Archivos de Texto (*.txt)|*.txt|Todos los Archivos (*.*)|*.*"
            dga.FilterIndex = 1
            If Me.cmbTarTarjeta.Text = "VISA - CREDITO" Then
               dga.FileName = "DEBLIQC"
            ElseIf Me.cmbTarTarjeta.Text = "VISA - DEBITO" Then
               dga.FileName = "DEBLIQD"
            Else
               dga.FileName = "DA168D"
            End If
            dga.RestoreDirectory = True

            If dga.ShowDialog() = Windows.Forms.DialogResult.OK Then
               If Not String.IsNullOrEmpty(dga.FileName) Then
                  Me.Generar(dga.FileName)
               End If
            End If
         Else
            MessageBox.Show("Ha cancelado la exportación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAExcel_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridDocumentExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbTodos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbTodos.CheckedChanged
      Me.Cursor = Cursors.WaitCursor
      For Each dr As UltraGridRow In Me.ugDetalle.Rows
         ' If Not String.IsNullOrEmpty(dr.Cells("CBU").Value.ToString()) And Not String.IsNullOrEmpty(dr.Cells("IdBanco").Value.ToString()) And Not String.IsNullOrEmpty(dr.Cells("IdCuentaBancariaClase").Value.ToString()) And Not String.IsNullOrEmpty(dr.Cells("NumeroCuentaBancaria").Value.ToString()) And IsNumeric(dr.Cells("NumeroCuentaBancaria").Value.ToString().Replace("-", "").Replace("/", "")) Then
         If dr.Cells("NroTarjeta").Value.ToString.Trim.Length = 16 Then
            dr.Cells("Selec").Value = Me.chbTodos.Checked
            If chbTodos.Checked Then
               If Decimal.Parse(dr.Cells("SaldoCtaCte").Value.ToString()) = 0 Then
                  dr.Cells("SaldoCtaCte").Value = dr.Cells("SaldoCtaCteOriginal").Value
               End If
            Else
               dr.Cells("SaldoCtaCte").Value = 0
            End If
         End If
         ' End If
      Next
      Me.Cursor = Cursors.Default
   End Sub

   Private Sub ugDetalle_CellChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.CellChange

      If e.Cell.Row.Index <> -1 AndAlso e.Cell.Column.ToString() = "Selec" Then
         'If Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CBU").Text = "" Then
         '    MessageBox.Show("NO puede Seleccionarlo porque NO tiene CBU !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '    Me.ugDetalle.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Value = False
         '    Exit Sub
         'End If
         'If Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CBU").Text.Trim.Length <> 22 Then
         '    MessageBox.Show("NO puede Seleccionarlo porque el CBU es Inválido!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '    Me.ugDetalle.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Value = False
         '    Exit Sub
         'End If
         'If Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdBanco").Text = "" Then
         '    MessageBox.Show("NO puede Seleccionarlo porque NO tiene Banco !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '    Me.ugDetalle.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Value = False
         '    Exit Sub
         'End If
         'If Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdCuentaBancariaClase").Text = "" Then
         '    MessageBox.Show("NO puede Seleccionarlo porque NO tiene Clase de Cuenta!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '    Me.ugDetalle.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Value = False
         '    Exit Sub
         'End If
         'If Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroCuentaBancaria").Text = "" Then
         '    MessageBox.Show("NO puede Seleccionarlo porque NO tiene Numero de Cuenta Bancaria!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '    Me.ugDetalle.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Value = False
         '    Exit Sub
         'End If
         'If Not IsNumeric(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroCuentaBancaria").Text.Replace("-", "").Replace("/", "")) Then
         '    MessageBox.Show("NO puede Seleccionarlo porque NO el Numero de Cuenta Bancaria tiene letras!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '    Me.ugDetalle.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Value = False
         '    Exit Sub
         'End If
         'If Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroCuentaBancaria").Text.Replace("-", "").Replace("/", "").Trim.Length > 15 Then
         '    MessageBox.Show("NO puede Seleccionarlo porque el Numero de Cuenta es Inválido (tiene mas de 15 Digitos)!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '    Me.ugDetalle.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Value = False
         '    Exit Sub
         'End If

         ugDetalle.UpdateData()

         If e.Cell.Value.Equals(1) Then
            e.Cell.Row.Cells("SaldoCtaCte").Value = e.Cell.Row.Cells("SaldoCtaCteOriginal").Value
         Else
            e.Cell.Row.Cells("SaldoCtaCte").Value = 0
         End If

      End If

   End Sub

#End Region

#Region "Metodos"

   Private Sub FormatearColumnas()

      ugDetalle.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True

      With Me.ugDetalle.DisplayLayout.Bands(0)

         'oculto todas las columnas por si en algún momento agrego mas al query de la consulta
         For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.ugDetalle.DisplayLayout.Bands(0).Columns
            col.Hidden = True
            col.CellActivation = UltraWinGrid.Activation.NoEdit
         Next

         .Columns("Selec").Hidden = False
         .Columns("Selec").CellActivation = Activation.AllowEdit
         .Columns("Selec").Style = ColumnStyle.CheckBox
         .Columns("Selec").Header.Caption = "Selec"
         .Columns("Selec").Width = 40

         .Columns("CodigoCliente").Hidden = False
         .Columns("CodigoCliente").Header.Caption = "Codigo"
         .Columns("CodigoCliente").CellAppearance.TextHAlign = HAlign.Right
         .Columns("CodigoCliente").Width = 80

         .Columns("NombreCliente").Hidden = False
         .Columns("NombreCliente").Header.Caption = "Cliente"
         .Columns("NombreCliente").Width = 220

         .Columns("NombreCategoria").Hidden = False
         .Columns("NombreCategoria").Header.Caption = "Categoria"
         .Columns("NombreCategoria").Width = 150

         .Columns("NombreTarjeta").Hidden = False
         .Columns("NombreTarjeta").Header.Caption = "Tarjeta"
         .Columns("NombreTarjeta").Width = 150

         .Columns("NroTarjeta").Hidden = False
         .Columns("NroTarjeta").Header.Caption = "Nro. Tarjeta"
         .Columns("NroTarjeta").CellAppearance.TextHAlign = HAlign.Right
         .Columns("NroTarjeta").Width = 120

         .Columns("SaldoCtaCte").Hidden = False
         .Columns("SaldoCtaCte").CellActivation = Activation.AllowEdit
         .Columns("SaldoCtaCte").Header.Caption = "Importe a Cobrar"
         .Columns("SaldoCtaCte").Format = "N2"
         .Columns("SaldoCtaCte").MaskInput = "{double:9.2}"
         .Columns("SaldoCtaCte").CellAppearance.TextHAlign = HAlign.Right
         .Columns("SaldoCtaCte").Width = 80

         .Columns("SaldoCtaCteOriginal").Hidden = False
         .Columns("SaldoCtaCteOriginal").Header.Caption = "Saldo C.C."
         .Columns("SaldoCtaCteOriginal").Format = "N2"
         .Columns("SaldoCtaCteOriginal").CellAppearance.TextHAlign = HAlign.Right
         .Columns("SaldoCtaCteOriginal").Width = 80


         .Columns("CodigoCliente").Header.VisiblePosition = 1
         .Columns("NombreCliente").Header.VisiblePosition = 2
         .Columns("NombreCategoria").Header.VisiblePosition = 3
         .Columns("NombreTarjeta").Header.VisiblePosition = 4
         .Columns("NroTarjeta").Header.VisiblePosition = 5
         .Columns("SaldoCtaCteOriginal").Header.VisiblePosition = 7
         .Columns("SaldoCtaCte").Header.VisiblePosition = 8

         Eniac.Win.Ayudante.Grilla.AgregarTotalesSuma(ugDetalle, {"SaldoCtaCte", "SaldoCtaCteOriginal"})

      End With

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.cmbTarTarjeta.SelectedIndex = -1
      Me.dtpFechaVencimiento.Value = Date.Now
      Me.chbTodos.Checked = False

      'Limpio la Grilla.
      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oC As Reglas.Cargos = New Reglas.Cargos()

         'TODO: DB
         ''_detalle = oC.GetCargosDebitosTarjetas(Me.cmbTarTarjeta.Text, chbTomaFoto.Checked)

         '_detalle.Columns.Add("Selec", Type.GetType("System.Boolean"))
         '_detalle.Columns("Selec").SetOrdinal(0)
         'For Each dr As DataRow In _detalle.Rows
         '   dr("Selec") = False
         'Next

         '_banco = New Eniac.Reglas.Bancos().GetUno(Me._cobrador.IdBanco)

         Me.ugDetalle.DataSource = _detalle
         Me.FormatearColumnas()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub Generar(nombreArchivo As String)

      Dim arc As IDebitosTarjetasProceso

      If Me.cmbTarTarjeta.Text = "VISA - CREDITO" Or Me.cmbTarTarjeta.Text = "VISA - DEBITO" Then
         arc = New VisaDebitoCreditoProceso()
      Else 'MASTER
         arc = New MasterDebitoCreditoProceso()
      End If

      arc.CrearDT(Me._detalle, Me._banco, nombreArchivo, Me.dtpFechaVencimiento.Value, Me.cmbTarTarjeta.Text)

      MessageBox.Show("Se Exportaron " & arc.NumeroDeRegistros.ToString() & " comprobantes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

   End Sub

#End Region


End Class