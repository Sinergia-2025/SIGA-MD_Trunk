Option Explicit On
Option Strict On

Public Class ConsultarClienteMarcaLDePrecio

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me._publicos.CargaComboListaDePrecios(Me.cmbListasDePrecios)
         Me.cmbListasDePrecios.SelectedIndex = -1

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ClientesListaDePreciosMarca_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Refrescar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
      UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

      UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
      UltraPrintPreviewD.Name = Me.Text

      UltraPrintPreviewD.MdiParent = Me.MdiParent
      UltraPrintPreviewD.Show()
      UltraPrintPreviewD.Focus()

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCliente.Enabled = Me.chbCliente.Checked
      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked

      If Not Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Text = ""
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscCliente.Text = ""
      Else
         Me.bscCodigoCliente.Focus()
      End If

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscMarca_BuscadorClick() Handles bscMarca.BuscadorClick
      Try
         Me._publicos.PreparaGrillaMarcas(Me.bscMarca)
         Dim oMarcas As Reglas.Marcas = New Reglas.Marcas
         Me.bscMarca.Datos = oMarcas.GetPorNombre(Me.bscMarca.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscMarca_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscMarca.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosMarca(e.FilaDevuelta)
            Me.cmbListasDePrecios.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ckbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbMarca.CheckedChanged

      Me.bscMarca.Enabled = Me.ckbMarca.Checked

      If Not Me.ckbMarca.Checked Then
         Me.bscMarca.Text = ""
      End If

   End Sub

   Private Sub ckbListaPrecios_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbListaPrecios.CheckedChanged

      Me.cmbListasDePrecios.Enabled = Me.ckbListaPrecios.Checked

      If Not Me.ckbListaPrecios.Checked Then
         Me.cmbListasDePrecios.SelectedIndex = -1
      End If

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If dgvDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged
      If chkExpandAll.Checked Then
         Me.dgvDetalle.Rows.ExpandAll(True)
      Else
         Me.dgvDetalle.Rows.CollapseAll(True)
      End If
   End Sub

#End Region

#Region "Metodos"

   Private Sub Refrescar()
      Me.tsbImprimir.Enabled = False
      Me.chbCliente.Checked = False
      Me.ckbMarca.Checked = False
      Me.ckbListaPrecios.Checked = False
      Me.RefrescarDatosGrilla()
      Me.bscCodigoCliente.Focus()
   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   'Private Sub AgregarListaMarca()

   '   Dim dr As DataRow = Me._listasMarca.NewRow()

   '   dr(0) = Me.cmbTipoDoc.Text
   '   dr(1) = Me.bscCodigoCliente.Text
   '   dr(2) = Me.bscMarca.FilaDevuelta.Cells("IdMarca").Value.ToString()
   '   dr(3) = Me.bscMarca.FilaDevuelta.Cells("NombreMarca").Value.ToString()
   '   dr(4) = Me.cmbListasDePrecios.SelectedValue
   '   dr(5) = Me.cmbListasDePrecios.Text

   '   Me._listasMarca.Rows.Add(dr)

   '   Me.dgvDetalle.DataSource = Me._listasMarca

   'End Sub

   Private Sub CargarDatosMarca(ByVal dr As DataGridViewRow)

      Me.bscMarca.Text = dr.Cells("NombreMarca").Value.ToString()

   End Sub

   'Private Sub CargarDatosListasPrecios(ByVal dr As DataGridViewRow)

   '   Me.bscListaPrecios.Text = dr.Cells("NombreListaPrecios").Value.ToString()

   'End Sub

   Private Sub RefrescarDatosGrilla()

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.bscCodigoCliente.Focus()

   End Sub

   Private _listasMarca As DataTable

   Private Sub CargaGrillaDetalle()
      Try
         Dim IdCliente As Long = 0

         Dim IdMarca As Integer = 0
         Dim IdListaDePrecios As Integer = -1

         If Me.bscCodigoCliente.Text.Length > 0 Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.bscMarca.Text.Length > 0 Then
            IdMarca = Integer.Parse(Me.bscMarca.FilaDevuelta.Cells("IdMarca").Value.ToString())
         End If

         If Me.ckbListaPrecios.Checked Then
            IdListaDePrecios = Integer.Parse(Me.cmbListasDePrecios.SelectedValue.ToString())
         End If

         Dim reg As Reglas.ClientesMarcasListasDePrecios

         reg = New Reglas.ClientesMarcasListasDePrecios()

         Me._listasMarca = reg.ClientesMarcasListasDePrecios(IdCliente, IdMarca, IdListaDePrecios)

         Me.dgvDetalle.DataSource = Me._listasMarca

         Me.chkExpandAll.Enabled = True

         Me.tsbImprimir.Enabled = True

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#End Region

End Class