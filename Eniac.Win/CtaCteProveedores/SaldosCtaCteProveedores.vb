Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid

Public Class SaldosCtaCteProveedores

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         'Me.dtpDesde.Value = DateTime.Now
         'Me.dtpHasta.Value = DateTime.Now

         Me._publicos.CargaComboCategoriasProveedores(Me.cmbCategoria)
         Me._publicos.CargaComboRubrosCompras(Me.cmbRubroCompra)

         Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
         Me.cmbGrabanLibro.Items.Insert(1, "SI")
         Me.cmbGrabanLibro.Items.Insert(2, "NO")
         Me.cmbGrabanLibro.SelectedIndex = 0

         '# Filtros Contiene 
         AgregarFiltroEnLinea(Me.ugDetalle, {Entidades.Proveedor.Columnas.CodigoProveedor.ToString(),
                                             Entidades.Proveedor.Columnas.NombreProveedor.ToString()})
         AgregarTotalesSuma(Me.ugDetalle, {"Total", "Saldo", "SaldoVencido"})

         Me.PreferenciasLeer(Me.ugDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub chbRubroCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubroCompra.CheckedChanged
      Try
         Me.cmbRubroCompra.Enabled = Me.chbRubroCompra.Checked
         If Not Me.chbRubroCompra.Checked Then
            Me.cmbRubroCompra.SelectedIndex = -1
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub SaldosCtaCteProveedores_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True

      With filtro

         If Me.chbProveedor.Checked Then
            filtro.AppendFormat(" - Proveedor: {0} - {1}", Me.bscCodigoProveedor.Text, Me.bscProveedor.Text)
         End If

         If Me.chbFecha.Checked Then
            filtro.AppendFormat(" - Fechas Hasta {0:dd/MM/yyyy}", dtpHasta.Value)
         End If

         If Me.chbSaldosPositivos.Checked Then
            filtro.AppendFormat(" - Solo Saldos Positivos")
         End If

         If Me.chbCategoria.Checked Then
            filtro.AppendFormat(" - Categoria: {0}", Me.cmbCategoria.Text)
         End If

         If Me.cmbGrabanLibro.SelectedIndex > -1 Then
            filtro.AppendFormat(" - Graba Libro: {0}", Me.cmbGrabanLibro.Text)
         End If

         If Me.cmbRubroCompra.SelectedIndex > -1 Then
            filtro.AppendFormat(" - Rubro: {0}", Me.cmbRubroCompra.Text)
         End If
      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function
   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim dt As DataTable

         Me.Cursor = Cursors.WaitCursor

         dt = DirectCast(Me.ugDetalle.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Me.CargarFiltrosImpresion))

         Dim frmImprime As VisorReportes

         If Not Me.chbFecha.Checked Then
            frmImprime = New VisorReportes("Eniac.Win.SaldosCtaCteProveedores.rdlc", "SistemaDataSet_SaldosCtaCteProveedores", dt, parm, True, 1) '# 1 = Cantidad de Copias
         Else
            frmImprime = New VisorReportes("Eniac.Win.SaldosCtaCteProveedoresT.rdlc", "SistemaDataSet_SaldosCtaCteProveedores", dt, parm, True, 1) '# 1 = Cantidad de Copias
         End If


         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         If chbProveedor.Checked Then
            If bscCodigoProveedor.Selecciono Then
               If Not String.IsNullOrWhiteSpace(bscCodigoProveedor.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()) Then
                  frmImprime.Destinatarios = bscCodigoProveedor.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()
               End If
            ElseIf bscProveedor.Selecciono Then
               If Not String.IsNullOrWhiteSpace(bscProveedor.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()) Then
                  frmImprime.Destinatarios = bscProveedor.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()
               End If
            End If
         End If
         frmImprime.Show()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFecha.CheckedChanged

      Me.dtpHasta.Enabled = Me.chbFecha.Checked

      If Me.chbFecha.Checked Then
         Me.dtpHasta.Value = Date.Now
      End If

      Me.dtpHasta.Focus()

   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick

      Dim codigoProveedor As Long = -1

      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscCodigoProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
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
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
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

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbProveedor.Checked And Me.bscCodigoProveedor.Text.Length = 0 Then
            ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro")
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         If Me.chbRubroCompra.Checked And Me.cmbRubroCompra.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó un Rubro aunque activó ese Filtro")
            Me.cmbRubroCompra.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
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

#End Region

#Region "Metodos"

   Private Sub FormatearGrilla()

      Dim pos As Integer = 0
      With Me.ugDetalle.DisplayLayout.Bands(0)
         .Columns("IdProveedor").FormatearColumna("IdProveedor", pos, 60, HAlign.Right, True)
         .Columns("CodigoProveedor").FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns("NombreProveedor").FormatearColumna("Proveedor", pos, 220, HAlign.Left)
         .Columns("IdRubroCompra").FormatearColumna("Cód. Rubro", pos, 100, HAlign.Right, True)
         .Columns("NombreRubro").FormatearColumna("Rubro", pos, 110, HAlign.Left)
         .Columns("Cuit").FormatearColumna("CUIT", pos, 85, HAlign.Right)
         .Columns("TelefonoProveedor").FormatearColumna("Teléfono", pos, 100, HAlign.Right)
         .Columns("Saldo").FormatearColumna("Saldo", pos, 100, HAlign.Right)
         .Columns("SaldoVencido").FormatearColumna("Vencido", pos, 100, HAlign.Right)
         .Columns("Total").FormatearColumna("Total", pos, 100, HAlign.Right)
      End With

   End Sub

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chbProveedor.Checked = False
      Me.chbFecha.Checked = False
      Me.chbSaldosPositivos.Checked = False
      Me.chbCategoria.Checked = False
      Me.cmbGrabanLibro.SelectedIndex = 0
      Me.chbRubroCompra.Checked = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

   End Sub

   Private Sub CargaGrillaDetalle()

      'Dim oCtaCte As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv()
      Dim oCtaCteDet As Reglas.CuentasCorrientesProvPagos = New Reglas.CuentasCorrientesProvPagos()

      Dim idProveedor As Long = 0
      Dim Total1 As Decimal = 0
      Dim Total2 As Decimal = 0

      Dim FechaHasta As Date = Nothing

      Dim TipoSaldo As String = "TODOS"

      Dim IdCategoria As Integer = 0

      Try

         If Me.chbFecha.Checked Then
            FechaHasta = Me.dtpHasta.Value
         End If

         If Me.chbSaldosPositivos.Checked Then
            TipoSaldo = "POSITIVOS"
         End If

         If Me.cmbCategoria.Enabled Then
            IdCategoria = Integer.Parse(Me.cmbCategoria.SelectedValue.ToString())
         End If

         'Me.dgvDetalle.DataSource = oCtaCte.GetSaldosCtaCte(actual.Sucursal.Id, Desde, Hasta, IdProveedor)
         If bscCodigoProveedor.Tag IsNot Nothing AndAlso bscCodigoProveedor.Tag.ToString() IsNot String.Empty Then
            idProveedor = Long.Parse(CStr(bscCodigoProveedor.Tag))
         End If

         Dim idRubroCompra As Integer = 0
         If Me.chbRubroCompra.Checked Then
            idRubroCompra = Me.cmbRubroCompra.ValorSeleccionado(Of Integer)()
         End If

         Me.ugDetalle.DataSource = oCtaCteDet.GetSaldosCtaCte(actual.Sucursal.Id, _
                                                               FechaHasta, _
                                                               idProveedor, _
                                                               TipoSaldo, _
                                                               IdCategoria, _
                                                               Me.cmbGrabanLibro.Text,
                                                               idRubroCompra)

         Me.FormatearGrilla()

         '# Se ajusta la visibilidad de algunas columnas
         With Me.ugDetalle.DisplayLayout.Bands(0)
            If Me.chbFecha.Checked Then
               .Columns("Total").Hidden = False
               .Columns("Saldo").Hidden = True
               .Columns("SaldoVencido").Hidden = True
            Else
               .Columns("Total").Hidden = True
               .Columns("Saldo").Hidden = False
               .Columns("SaldoVencido").Hidden = False
            End If
         End With

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#End Region

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

End Class