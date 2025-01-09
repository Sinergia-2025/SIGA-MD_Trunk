Imports actual = Eniac.Entidades.Usuario.Actual
'Imports System.Data.DataColumn

Public Class ProductosNrosSerie

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Dim oMarca As Reglas.Marcas = New Reglas.Marcas()
         Me.cmbMarca.ValueMember = "IdMarca"
         Me.cmbMarca.DisplayMember = "NombreMarca"

         Me.cmbMarca.DataSource = oMarca.GetAll()
         Me.cmbMarca.SelectedIndex = -1

         Dim oRubro As Reglas.Rubros = New Reglas.Rubros()
         Me.cmbRubro.ValueMember = "IdRubro"
         Me.cmbRubro.DisplayMember = "NombreRubro"

         Me.cmbRubro.DataSource = oRubro.GetAll()
         Me.cmbRubro.SelectedIndex = -1

         Me._publicos.CargaComboSubRubros(Me.cmbSubRubro)

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            Me.chbSubRubro.Visible = False
            Me.cmbSubRubro.Visible = False
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub UtilidadesPorProducto_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      If Me.ugdNrosSerie.Rows.Count = 0 Then Exit Sub

      Try

         'Dim Filtros As String

         'Me.Cursor = Cursors.WaitCursor

         'Filtros = "Rango de Fechas: desde el " & dtpDesde.Text & " hasta el " & dtpHasta.Text

         'If Me.chbProducto.Checked Then
            '   Filtros = Filtros & " / Producto: " & Me.bscCodigoProducto2.Text & " - " & Me.bscProducto2.Text
            'End If

            'If Me.chbMarca.Checked Then
            '   Filtros = Filtros & " / Marca: " & Me.cmbMarca.Text
            'End If

            'If Me.chbRubro.Checked Then
            '   Filtros = Filtros & " / Rubro: " & Me.cmbRubro.Text
            'End If

            'If Me.chbSubRubro.Checked Then
            '   Filtros = Filtros & " / SubRubro: " & Me.cmbSubRubro.Text
            'End If

            'Dim dt As DataTable

            'dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)

            'Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

            'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresa))
            'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
            'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

            'Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.InfUtilidadesPorProducto.rdlc", "SistemaDataSet_UtilidadesPorProducto", dt, parm, True)
            'frmImprime.Text = Me.Text
            'frmImprime.WindowState = FormWindowState.Maximized
            'frmImprime.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub chbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMarca.CheckedChanged
        Me.cmbMarca.Enabled = Me.chbMarca.Checked
        If Not Me.chbMarca.Checked Then
            Me.cmbMarca.SelectedIndex = -1
        Else
            If Me.cmbMarca.Items.Count > 0 Then
                Me.cmbMarca.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub chbRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRubro.CheckedChanged
        Me.cmbRubro.Enabled = Me.chbRubro.Checked
        If Not Me.chbRubro.Checked Then
            Me.cmbRubro.SelectedIndex = -1
        Else
            If Me.cmbRubro.Items.Count > 0 Then
                Me.cmbRubro.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub chbSubRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSubRubro.CheckedChanged
        Try
            Me.cmbSubRubro.Enabled = Me.chbSubRubro.Checked

            If Not Me.chbSubRubro.Checked Then
                Me.cmbSubRubro.SelectedIndex = -1
            Else
                If Me.cmbSubRubro.Items.Count > 0 Then
                    Me.cmbSubRubro.SelectedIndex = 0
                End If
            End If

            Me.cmbSubRubro.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
        Try
            Dim oProductos As Reglas.Productos = New Reglas.Productos
            Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarProducto(e.FilaDevuelta)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
        Try
            Dim oProductos As Reglas.Productos = New Reglas.Productos
            Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
            Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarProducto(e.FilaDevuelta)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.CargaGrillaDetalle()

            If Me.ugdNrosSerie.Rows.Count > 0 Then
                Me.btnConsultar.Focus()
            Else
                Me.Cursor = Cursors.Default
                MessageBox.Show("ATENCION: NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

#End Region

#Region "Metodos"

    Private Sub CargarProducto(ByVal dr As DataGridViewRow)

        Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
        Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
        Me.bscProducto2.Enabled = False
        Me.bscCodigoProducto2.Enabled = False

    End Sub

    Private Sub RefrescarDatosGrilla()


        Me.chbMarca.Checked = False
        Me.chbRubro.Checked = False
        Me.bscProducto2.Text = ""
        Me.bscCodigoProducto2.Enabled = True
        Me.bscProducto2.Enabled = True
        Me.bscCodigoProducto2.Text = ""


        If Not Me.ugdNrosSerie.DataSource Is Nothing Then
            DirectCast(Me.ugdNrosSerie.DataSource, DataTable).Rows.Clear()
        End If

    End Sub

    Private Sub CargaGrillaDetalle()

        Dim oNrosSerie As Reglas.ProductosNrosSerie = New Reglas.ProductosNrosSerie()

        Dim Marca As Integer
        Dim Rubro As Integer
        Dim idSubRubro As Integer = 0
        Dim vendidos As Boolean
        Dim todos As Boolean
        Dim enStock As Boolean

        If Me.chbMarca.Checked Then
            Marca = Int32.Parse(Me.cmbMarca.SelectedValue.ToString())
        Else
            Marca = 0
        End If
        If Me.chbRubro.Checked Then
            Rubro = Int32.Parse(Me.cmbRubro.SelectedValue.ToString())
        Else
            Rubro = 0
        End If

        If Me.cmbSubRubro.Enabled Then
            idSubRubro = Int32.Parse(Me.cmbSubRubro.SelectedValue.ToString())
        End If

        If Me.rbtVendidos.Checked Then
            vendidos = True
        Else
            vendidos = False
        End If

        If Me.rbtTodos.Checked Then
            todos = True
        Else
            todos = False
        End If

        If Me.rbtStock.Checked Then
            enStock = True
        Else
            enStock = False
        End If

        Dim dt As DataTable

        Try

            dt = oNrosSerie.GetNrosSerieProductoConsulta(actual.Sucursal.Id, bscCodigoProducto2.Text, Marca, Rubro, idSubRubro, vendidos, todos, enStock)

            Me.ugdNrosSerie.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

#End Region

End Class