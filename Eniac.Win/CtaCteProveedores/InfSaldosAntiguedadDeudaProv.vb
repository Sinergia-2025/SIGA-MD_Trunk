Public Class InfSaldosAntiguedadDeudaProv
#Region "Campos"
   Private _publicos As Publicos
   Private IdUsuario As String = actual.Nombre
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me._publicos.CargaComboCategoriasProveedores(Me.cmbCategoria)
         Me._publicos.CargaComboDesdeEnum(Me.cmbGrabanLibro, GetType(Entidades.Publicos.SiNoTodos))
         Me.cmbGrabanLibro.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
         Me._publicos.CargaComboProvincias(Me.cmbProvincia)
         Me._publicos.CargaComboGrupos(Me.cmbGrupos)
         Me.cmbGrupos.SelectedIndex = -1

         _publicos.CargaComboDesdeEnum(cmbFechasCalculo, GetType(Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme))
         cmbFechasCalculo.SelectedValue = Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme.Fecha

         _publicos.CargaComboAntiguedadSaldoConfigProveedor(cmbRangoDias)

         Me.CargarColumnasASumar()

         Me.PreferenciasLeer(Me.ugDetalle, tsbPreferencias)

         AgregarFiltroEnLinea(ugDetalle, {"NombreProveedor"})

         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         Me.ugDetalle.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = Not Me.cmbSucursal.Enabled
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
#End Region


#Region "Eventos"

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick, bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscCodigoProveedor)
         Dim oProveedors As Reglas.Proveedores = New Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedors.GetFiltradoPorCodigo(codigoProveedor, True)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscProveedor)
         Dim oProveedors As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedors.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProveedor.CheckedChanged

      Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
      Me.bscProveedor.Enabled = Me.chbProveedor.Checked

      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscCodigoProveedor.Tag = Nothing
      Me.bscProveedor.Text = String.Empty

      Me.bscCodigoProveedor.Focus()

   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.RefrescarDatos()
         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub chbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles chbProvincia.CheckedChanged

      Me.cmbProvincia.Enabled = Me.chbProvincia.Checked

      If Not Me.chbProvincia.Checked Then
         Me.cmbProvincia.SelectedIndex = -1
      Else
         If Me.cmbProvincia.Items.Count > 0 Then
            Me.cmbProvincia.SelectedIndex = 0
         End If
         Me.cmbProvincia.Focus()
      End If

   End Sub

   Private Sub chbCategoria_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCategoria.CheckedChanged

      Me.cmbCategoria.Enabled = Me.chbCategoria.Checked
      If Not Me.chbCategoria.Checked Then
         Me.cmbCategoria.SelectedIndex = -1
      Else
         If Me.cmbCategoria.Items.Count > 0 Then
            Me.cmbCategoria.SelectedIndex = 0
         End If

         Me.cmbCategoria.Focus()

      End If

   End Sub

   Private Sub chbGrupo_CheckedChanged(sender As Object, e As EventArgs) Handles chbGrupo.CheckedChanged
      Try
         Me.cmbGrupos.Enabled = Me.chbGrupo.Checked

         If Not Me.chbGrupo.Checked Then
            Me.cmbGrupos.SelectedIndex = -1
         Else
            If Me.cmbGrupos.Items.Count > 0 Then
               Me.cmbGrupos.SelectedIndex = 0
            End If
         End If

         Me.cmbGrupos.Focus()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbProveedor.Checked AndAlso Not bscCodigoProveedor.Selecciono() AndAlso Not bscProveedor.Selecciono() Then
            ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro")
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If Me.ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
            Exit Sub
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
         Me.PreferenciasLeer(Me.ugDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".xls", Me.Text, UltraGridExcelExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".pdf", Me.Text, UltraGridDocumentExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Métodos"

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False

   End Sub

   Private Sub RefrescarDatos()

      cmbFechasCalculo.SelectedValue = Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme.Fecha
      cmbRangoDias.SelectedItem = cmbRangoDias.Items.OfType(Of Entidades.CuentaCorrienteAntiguedadSaldoConfig).FirstOrDefault(Function(c) c.PorDefecto)

      Me.chbExcluirSaldosNegativos.Checked = False
      Me.chbCategoria.Checked = False
      Me.cmbGrabanLibro.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      Me.chbGrupo.Checked = False
      Me.chbExcluirAnticipos.Checked = False
      Me.chbExcluirPreComprobantes.Checked = False
      Me.chbProvincia.Checked = False
      Me.chbProveedor.Checked = False

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If
      Me.btnConsultar.Focus()

      Me.cmbSucursal.Refrescar()

   End Sub

   Private Sub CargaGrillaDetalle()
      Dim Total1 As Decimal = 0
      Dim Total2 As Decimal = 0

      Dim IdVendedor As Integer = 0

      Dim idZonaGeografica As String = String.Empty
      Dim FechaHasta As Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme

      Dim rangosDias = cmbRangoDias.ItemSeleccionado(Of Entidades.CuentaCorrienteAntiguedadSaldoConfig)

      Dim IdProveedor As Long = 0
      Dim ExcluirSaldosNegativos As String = "NO"
      Dim IdCategoria As Integer = 0
      Dim Grupo As String = String.Empty
      Dim ExcluirAnticipos As String = "NO"
      Dim ExcluirPreComprobantes As String = "NO"
      Dim IdProvincia As String = String.Empty

      Try

         'Me.ugDetalle.DisplayLayout.Bands(0).Columns("MA30").Hidden = cmbFechasCalculo.ValorSeleccionado(Of Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme)() = Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme.Fecha
         'Me.ugDetalle.DisplayLayout.Bands(0).Columns("MA60").Hidden = cmbFechasCalculo.ValorSeleccionado(Of Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme)() = Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme.Fecha
         'Me.ugDetalle.DisplayLayout.Bands(0).Columns("MA90").Hidden = cmbFechasCalculo.ValorSeleccionado(Of Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme)() = Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme.Fecha
         'Me.ugDetalle.DisplayLayout.Bands(0).Columns("MA120").Hidden = cmbFechasCalculo.ValorSeleccionado(Of Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme)() = Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme.Fecha

         If Me.bscCodigoProveedor.Text.Length > 0 Then
            IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
         End If

         If Me.chbExcluirSaldosNegativos.Checked Then
            ExcluirSaldosNegativos = "SI"
         End If

         If Me.cmbCategoria.Enabled Then
            IdCategoria = Integer.Parse(Me.cmbCategoria.SelectedValue.ToString())
         End If

         If Me.cmbGrupos.Enabled Then
            Grupo = Me.cmbGrupos.SelectedValue.ToString()
         End If

         If Me.chbExcluirAnticipos.Checked Then
            ExcluirAnticipos = "SI"
         End If

         If Me.chbExcluirPreComprobantes.Checked Then
            ExcluirPreComprobantes = "SI"
         End If

         If Me.chbProvincia.Checked Then
            IdProvincia = Me.cmbProvincia.SelectedValue.ToString()
         End If

         FechaHasta = cmbFechasCalculo.ValorSeleccionado(Of Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme)()

         Me.ugDetalle.DataSource = New Reglas.CuentasCorrientesProvPagos().GetSaldosPorVencimientos(cmbSucursal.GetSucursales(),
                                                                                                    FechaHasta,
                                                                                                    IdProveedor,
                                                                                                    ExcluirSaldosNegativos,
                                                                                                    IdCategoria,
                                                                                                    Me.cmbGrabanLibro.Text,
                                                                                                    Grupo,
                                                                                                    ExcluirAnticipos,
                                                                                                    ExcluirPreComprobantes,
                                                                                                    rangosDias,
                                                                                                    IdProvincia)


         ugDetalle.AgregarTotalesSuma({"Total", "Saldo"})

         With ugDetalle.DisplayLayout.Bands(0)
            .Columns("IdSucursal").Hidden = Not cmbSucursal.GetSucursales().Count > 1

            Dim grpVencido = .Groups.Item("Vencidos")
            Dim grpPorVencer = .Groups.Item("PorVencer")
            Dim grpCero = .Groups.Item("Cero")

            Dim pos = .Columns("Saldo").Header.VisiblePosition + 1
            For Each r In rangosDias.Rangos.OrderBy(Function(o) o.Orden)
               Dim col = .Columns(r.EtiquetaColumna).FormatearColumna(String.Format("{1}", Environment.NewLine, r.EtiquetaColumna, r.DiasDesde, r.DiasHasta), pos, .Columns("Saldo").Width, HAlign.Right, , "N2")
               col.Header.Appearance.TextHAlign = HAlign.Center
               If r.DiasDesde > 0 Then
                  col.Group = grpVencido
               ElseIf r.DiasDesde < 0 Then
                  col.Group = grpPorVencer
               Else
                  col.Group = grpCero
               End If
               ugDetalle.AgregarTotalSumaColumna(col)
            Next

            grpPorVencer.Hidden = cmbFechasCalculo.ValorSeleccionado(Of Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme)() = Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme.Fecha

         End With

         Me.ugDetalle.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = True

         If Me.cmbSucursal.SelectedValue.ToString() = "-2" Then
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = False
         End If

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub CargarColumnasASumar()

      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

      Dim n2 As String = "{0:N2}"
      With Me.ugDetalle.DisplayLayout.Bands(0)
         AgregarTotalSumaColumna(Me.ugDetalle, .Columns("Total"), n2)
         AgregarTotalSumaColumna(Me.ugDetalle, .Columns("Saldo"), n2)
         AgregarTotalSumaColumna(Me.ugDetalle, .Columns("Total"), n2)
         AgregarTotalSumaColumna(Me.ugDetalle, .Columns("MOROSO"), n2)
         AgregarTotalSumaColumna(Me.ugDetalle, .Columns("IMPORTE2"), n2)
         AgregarTotalSumaColumna(Me.ugDetalle, .Columns("ME120"), n2)
         AgregarTotalSumaColumna(Me.ugDetalle, .Columns("ME90"), n2)
         AgregarTotalSumaColumna(Me.ugDetalle, .Columns("ME60"), n2)
         AgregarTotalSumaColumna(Me.ugDetalle, .Columns("ME30"), n2)
         AgregarTotalSumaColumna(Me.ugDetalle, .Columns("ALDIA"), n2)
         AgregarTotalSumaColumna(Me.ugDetalle, .Columns("MA30"), n2)
         AgregarTotalSumaColumna(Me.ugDetalle, .Columns("MA60"), n2)
         AgregarTotalSumaColumna(Me.ugDetalle, .Columns("MA90"), n2)
         AgregarTotalSumaColumna(Me.ugDetalle, .Columns("MA120"), n2)
      End With

   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()

      With filtro

         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, False, True)

         If Me.bscCodigoProveedor.Text.Length > 0 And Me.bscProveedor.Text.Length > 0 Then
            .AppendFormat("Proveedor: {0} - {1} - ", Me.bscCodigoProveedor.Text, Me.bscProveedor.Text)
         End If

         If Me.chbExcluirSaldosNegativos.Checked Then
            .AppendFormat("Excluir Saldos Negativos - ")
         End If

         If Me.cmbGrabanLibro.SelectedIndex > 0 Then     '0 Es TODOS
            .AppendFormat("Graban Libro {0} - ", Me.cmbGrabanLibro.Text)
         End If

         If Me.chbProvincia.Checked Then
            .AppendFormat("Provincia {0} - ", Me.cmbProvincia.Text)
         End If

         If Me.chbExcluirAnticipos.Checked Then
            .AppendFormat("Excluir Anticipos")
         End If

         .AppendFormat(" - Por: {0} - Rangos: {1}", cmbFechasCalculo.Text, cmbRangoDias.Text)

      End With
      Return filtro.ToString.Trim().Trim("-"c)
   End Function

#End Region

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Try
         Me.close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub


         Dim Titulo As String
         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Me.CargarFiltrosImpresion()

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class