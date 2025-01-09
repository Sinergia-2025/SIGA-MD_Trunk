Imports Infragistics.Win.UltraWinGrid

Public Class ClientesDebitosAutomaticos

#Region "Campos"

   Private _publicos As Publicos
   Private _detalle As DataTable
   Private _banco As Eniac.Entidades.Banco
   Private _cobrador As Eniac.Entidades.Empleado
   Private _tieneModuloCargos As Boolean

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         ' Me._publicos.CargaComboEmpleados(Me.cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)

         Dim oCobra As Reglas.Empleados = New Reglas.Empleados()

         With Me.cmbCobrador
            .DisplayMember = "NombreEmpleado"
            .ValueMember = "IdEmpleado"
            .DataSource = oCobra.GetDebitosDirectos()
            If .Items.Count > 0 Then
               .SelectedIndex = 0
            End If
         End With

         Me.dtpPeriodo.Value = DateTime.Now
         Me.lblCantDias.Text = Me.dtpFechaVencimiento.Value.Subtract(Date.Now).Days.ToString() + " día/s"

         Me._tieneModuloCargos = Reglas.Publicos.TieneModuloCargos

         If Me._tieneModuloCargos Then
            Me._publicos.CargaComboTiposLiquidacion(cmbTiposLiquidacion)
            Me.cmbTiposLiquidacion.SelectedIndex = 0
            Me.chbCargo.Checked = True
         Else
            Me.chbCargo.Visible = False
            Me.chbPeriodo.Visible = False
            Me.dtpPeriodo.Visible = False
            Me.lblTipoLiquidacion.Visible = False
            Me.cmbTiposLiquidacion.Visible = False
         End If


         Me.tssRegistros.Text = ""

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As System.Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         If TypeOf (Me.ugDetalle.DataSource) Is DataTable Then

            Me.RefrescarDatosGrilla()

            Me.FormatearColumnas()
         End If         'If TypeOf (Me.ugDetalle.DataSource) Is DataTable Then

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As System.Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub ugDetalle_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout

      e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow

      e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)

      e.Layout.Override.SpecialRowSeparatorHeight = 6

      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft

      e.Layout.ViewStyle = ViewStyle.SingleBand

      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

   End Sub

   Private Sub cmbCobrador_SelectedIndexChanged(sender As System.Object, e As EventArgs) Handles cmbCobrador.SelectedIndexChanged
      Try
         Dim oCobrador As New Reglas.Empleados()
         Dim cobrador As New Entidades.Empleado()
         If Me.cmbCobrador.SelectedItem IsNot Nothing Then
            cobrador = oCobrador.GetUno(Integer.Parse(Me.cmbCobrador.SelectedValue.ToString()))
            Me.txtBanco.Text = cobrador.NombreEmpleado
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(sender As System.Object, e As EventArgs) Handles btnConsultar.Click

      Try

         Me.Cursor = Cursors.WaitCursor

         If Me.cmbCobrador.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar un Cobrador.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         Me.CargaGrillaDetalle()

         Me.chbTodos.Checked = False

         If Me.ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
            Me.chbTodos.Enabled = True
         Else
            Me.Cursor = Cursors.Default
            Me.chbTodos.Enabled = False
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbGenerar_Click(sender As System.Object, e As EventArgs) Handles tsbGenerar.Click

      Try

         Me.ugDetalle.UpdateData()


         Me.ugDetalle.EndUpdate()

         If TypeOf (Me.ugDetalle.DataSource) Is DataTable Then
            Dim Cant As Integer = 0
            For Each dr As DataRow In DirectCast(Me.ugDetalle.DataSource, DataTable).Rows
               If dr("Selec") IsNot Nothing AndAlso Boolean.Parse(dr("Selec").ToString()) Then
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
               dga.FileName = Reglas.Publicos.NombreEmpresa + "_" + Me._banco.NombreBanco + "_" + DateTime.Now().ToString("yyyyMMddHHmmss")
               dga.RestoreDirectory = True

               If dga.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  If Not String.IsNullOrEmpty(dga.FileName) Then
                     Me.Generar(dga.FileName)
                  End If
               End If
            Else
               MessageBox.Show("Ha cancelado la exportación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
         End If         'If TypeOf (Me.ugDetalle.DataSource) Is DataTable Then
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAExcel_Click(sender As System.Object, e As EventArgs) Handles tsmiAExcel.Click
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

   Private Sub tsmiAPDF_Click(sender As System.Object, e As EventArgs) Handles tsmiAPDF.Click
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

   Private Sub chbTodos_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbTodos.CheckedChanged
      Try
         Me.Cursor = Cursors.WaitCursor
         'For Each dr As UltraGridRow In Me.ugDetalle.Rows
         For Each dr As DataRow In DirectCast(ugDetalle.DataSource, DataTable).Rows
            If Me.chbTodos.Checked Then
               If Not String.IsNullOrEmpty(dr("CBU").ToString()) And
                  Not String.IsNullOrEmpty(dr("IdBanco").ToString()) And
                  Not String.IsNullOrEmpty(dr("IdCuentaBancariaClase").ToString()) And
                  Not String.IsNullOrEmpty(dr("NumeroCuentaBancaria").ToString()) And
                  IsNumeric(dr("NumeroCuentaBancaria").ToString().Replace("-", "").Replace("/", "")) And
                  Int32.Parse(dr("NC").ToString()) = 0 Then
                  If dr("CBU").ToString.Trim.Length = 22 And dr("NumeroCuentaBancaria").ToString.Trim.Replace("-", "").Replace("/", "").Length <= 15 Then
                     dr("Selec") = Me.chbTodos.Checked
                     If chbTodos.Checked Then
                        If Decimal.Parse(dr("SaldoCtaCte").ToString()) = 0 Then
                           dr("SaldoCtaCte") = dr("SaldoCtaCteOriginal")
                        End If
                     Else
                        dr("SaldoCtaCte") = 0
                     End If
                  End If
               End If
            Else
               'para destildar siempre destildo todo
               dr("Selec") = Me.chbTodos.Checked
               dr("SaldoCtaCte") = 0
            End If
         Next
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub ugDetalle_CellChange(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.CellChange

      If e.Cell.Row.Index <> -1 AndAlso e.Cell.Column.ToString() = "Selec" Then
         If Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CBU").Text = "" Then
            MessageBox.Show("NO puede Seleccionarlo porque NO tiene CBU !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ugDetalle.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Value = False
            Exit Sub
         End If
         If Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CBU").Text.Trim.Length <> 22 Then
            MessageBox.Show("NO puede Seleccionarlo porque el CBU es Inválido!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ugDetalle.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Value = False
            Exit Sub
         End If
         If Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdBanco").Text = "" Then
            MessageBox.Show("NO puede Seleccionarlo porque NO tiene Banco !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ugDetalle.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Value = False
            Exit Sub
         End If
         If Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdCuentaBancariaClase").Text = "" Then
            MessageBox.Show("NO puede Seleccionarlo porque NO tiene Clase de Cuenta!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ugDetalle.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Value = False
            Exit Sub
         End If
         If Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroCuentaBancaria").Text = "" Then
            MessageBox.Show("NO puede Seleccionarlo porque NO tiene Numero de Cuenta Bancaria!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ugDetalle.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Value = False
            Exit Sub
         End If
         If Not IsNumeric(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroCuentaBancaria").Text.Replace("-", "").Replace("/", "")) Then
            MessageBox.Show("NO puede Seleccionarlo porque NO el Numero de Cuenta Bancaria tiene letras!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ugDetalle.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Value = False
            Exit Sub
         End If
         If Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroCuentaBancaria").Text.Replace("-", "").Replace("/", "").Trim.Length > 15 Then
            MessageBox.Show("NO puede Seleccionarlo porque el Numero de Cuenta es Inválido (tiene mas de 15 Digitos)!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ugDetalle.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Value = False
            Exit Sub
         End If

         If Boolean.Parse(e.Cell.Value.ToString()) = False AndAlso Int32.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NC").Text) > 0 Then
            If MessageBox.Show("Este cliente tiene Notas de Credito SIN APLICAR, ¿Desea generarlo de todas formas?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> Windows.Forms.DialogResult.Yes Then
               Me.ugDetalle.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Value = False
               Exit Sub
            End If
         End If

         ugDetalle.UpdateData()

         If e.Cell.Value.Equals(True) Then
            e.Cell.Row.Cells("SaldoCtaCte").Value = e.Cell.Row.Cells("SaldoCtaCteOriginal").Value
         Else
            e.Cell.Row.Cells("SaldoCtaCte").Value = 0
         End If

      End If

   End Sub

#End Region

#Region "Metodos"

   'Private Sub PeriodoLiquidacion()

   '   Dim oliq As Cliente.Liquidaciones = New Cliente.Liquidaciones()
   '   Dim UltimaLiquidacion As Integer

   '   UltimaLiquidacion = oliq.GetUltimoPeriodoLiquidacion()

   '   Dim Fecha As Date
   '   If UltimaLiquidacion > 1 Then
   '      Fecha = Date.Parse(UltimaLiquidacion.ToString.Substring(0, 4) & "-" & UltimaLiquidacion.ToString.Substring(4, 2) & "-01")
   '   Else
   '      Fecha = Date.Now.AddMonths(-1)
   '   End If

   '   Me.dtpPeriodo.Value = Fecha
   '   'Me.dtpPeriodo.Enabled = Not (UltimaLiquidacion > 1)

   'End Sub

   Private Sub FormatearColumnas()

      ugDetalle.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True
      'ugDetalle.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
      With Me.ugDetalle.DisplayLayout.Bands(0)

         'oculto todas las columnas por si en algún momento agrego mas al query de la consulta
         For Each dc As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.ugDetalle.DisplayLayout.Bands(0).Columns
            dc.Hidden = True
            dc.CellActivation = UltraWinGrid.Activation.NoEdit
         Next

         Dim col As Integer = 0
         .Columns("Selec").FormatearColumna("S.", col, 30, , , , , Activation.AllowEdit).Style = ColumnStyle.CheckBox
         .Columns("CodigoCliente").FormatearColumna("Código", col, 60, HAlign.Right)
         .Columns("NombreCliente").FormatearColumna("Cliente", col, 160)
         .Columns("PeriodoLiquidacion").FormatearColumna("Periodo", col, 60, HAlign.Right)
         .Columns("NombreTipoLiquidacion").FormatearColumna("Tipo", col, 60)

         .Columns("NombreCategoria").FormatearColumna("Categoría", col, 75)
         .Columns("CBU").FormatearColumna("CBU", col, 150, HAlign.Right).MinWidth = 150
         .Columns("IdBanco").FormatearColumna("Banco", col, 45, HAlign.Right)
         .Columns("NumeroCuentaBancaria").FormatearColumna("Nro. Cuenta", col, 80, HAlign.Right)

         .Columns("SaldoCtaCteOriginal").FormatearColumna("Saldo C.C.", col, 70, HAlign.Right, , "N2")
         .Columns("SaldoCtaCte").FormatearColumna("Importe a Cobrar", col, 70, HAlign.Right, , "N2", "{double:9.2}", Activation.AllowEdit)

         .Columns("NC").FormatearColumna("NC", col, 40, HAlign.Right).Style = ColumnStyle.CheckBox
         .Columns("NC").Header.ToolTipText = "Notas de Crédito"

         .Columns("IdTipoComprobante").FormatearColumna("Tipo", col, 80)
         .Columns("Letra").FormatearColumna("L.", col, 30, HAlign.Center)
         .Columns("CentroEmisor").FormatearColumna("Emis.", col, 60, HAlign.Right)
         .Columns("NumeroComprobante").FormatearColumna("Comprobante", col, 80, HAlign.Right)

         Eniac.Win.Ayudante.Grilla.AgregarTotalesSuma(ugDetalle, {"SaldoCtaCte", "SaldoCtaCteOriginal"})

      End With

      Me.ugDetalle.AgregarFiltroEnLinea({"CodigoCliente", "NombreCliente", "PeriodoLiquidacion", "NumeroComprobante"})

   End Sub

   Private Sub RefrescarDatosGrilla()

      'Me.PeriodoLiquidacion()
      'Me.cmbCobrador.Text = ""
      'Me.txtBanco.Text = ""

      With Me.cmbCobrador
         .SelectedIndex = -1
         If .Items.Count > 0 Then
            .SelectedIndex = 0
         End If
      End With

      Me.dtpFechaVencimiento.Value = Date.Now
      Me.lblCantDias.Text = Me.dtpFechaVencimiento.Value.Subtract(Date.Now).Days.ToString() + " día/s"

      Me.chbTodos.Checked = False

      'Limpio la Grilla.
      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.cmbCobrador.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Try
         Dim oC As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()

         Me._cobrador = New Reglas.Empleados().GetUno(Integer.Parse(Me.cmbCobrador.SelectedValue.ToString()))

         Dim periodo As DateTime?
         Dim idTipoLiquidacion As Integer?


         If Me._tieneModuloCargos AndAlso Me.chbCargo.Checked Then
            If chbPeriodo.Checked Then
               periodo = Me.dtpPeriodo.Value
            End If
            idTipoLiquidacion = Int32.Parse(Me.cmbTiposLiquidacion.SelectedValue.ToString())
         End If

         _detalle = oC.GetCtasCtesParaBanco(Me._cobrador.IdEmpleado, periodo, idTipoLiquidacion)

         _detalle.Columns.Add("Selec", GetType(Boolean))
         _detalle.Columns("Selec").SetOrdinal(0)
         _detalle.Columns.Add("SaldoCtaCteOriginal", GetType(Decimal))
         For Each dr As DataRow In _detalle.Rows
            dr("Selec") = False
            dr("SaldoCtaCteOriginal") = dr("SaldoCtaCte")
            dr("SaldoCtaCte") = 0
         Next

         _banco = New Eniac.Reglas.Bancos().GetUno(Me._cobrador.IdBanco)

         Me.ugDetalle.DataSource = _detalle
         Me.FormatearColumnas()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub Generar(nombreArchivo As String)
      Dim arc As IDebitosDirectosProceso
      Select Case Me._banco.IdBanco
         'Pasado a SIGA, en la proxima compilacion aparece.
         Case Eniac.Entidades.Banco.Codigos.Macro
            arc = New DebitosDirectosProcesoMacro()
         Case Eniac.Entidades.Banco.Codigos.Santander_Rio
            arc = New DebitosDirectosProcesoRio()
         Case Else
            Throw New Exception("Banco no implementado.")
      End Select

      For Each dr As DataRow In _detalle.GetErrors()
         dr.ClearErrors()
      Next

      arc.CrearDD(Me._detalle, Me._banco, nombreArchivo, Me.dtpFechaVencimiento.Value, NroRefinanciacion:=1)

      MessageBox.Show("Se Exportaron " & arc.NumeroDeRegistros.ToString() & " comprobantes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

   End Sub

#End Region


   Private Sub chbCargo_CheckedChanged(sender As Object, e As EventArgs) Handles chbCargo.CheckedChanged
      Try
         If Me.chbCargo.Checked Then
            Me.cmbTiposLiquidacion.Enabled = True
            Me.chbPeriodo.Checked = True
            chbPeriodo.Enabled = True
            'Me.dtpPeriodo.Enabled = chbPeriodo.Checked
         Else
            Me.cmbTiposLiquidacion.Enabled = False
            Me.chbPeriodo.Checked = False
            chbPeriodo.Enabled = False
            'Me.dtpPeriodo.Enabled = False
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dtpPeriodo_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodo.ValueChanged
      dtpPeriodo.Value = dtpPeriodo.Value.PrimerDiaMes()
   End Sub

   Private Sub lblPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles chbPeriodo.CheckedChanged
      Try
         If Me.chbPeriodo.Checked Then
            Me.dtpPeriodo.Enabled = True
         Else
            Me.dtpPeriodo.Enabled = False
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


   Private Sub dtpFechaVencimiento_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaVencimiento.ValueChanged
      Try
         Me.lblCantDias.Text = Me.dtpFechaVencimiento.Value.Subtract(Date.Now).Days.ToString() + " día/s"

         If Me.dtpFechaVencimiento.Value.Subtract(Date.Now).Days > 7 Then
            MessageBox.Show("La cantidad de días es mayor a 7.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class