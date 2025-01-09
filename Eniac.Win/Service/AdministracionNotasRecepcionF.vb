Option Explicit On
Option Strict On

Imports System
Imports Eniac.Service.Reglas
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class AdministracionNotasRecepcionF

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me.CargaComboEstados()

         Me._publicos = New Eniac.Win.Publicos()

         Me.CargarValoresIniciales()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub AdministracionNotasRecepcionF_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.CargarValoresIniciales()
         Me.tslRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbEditarNota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditarNota.Click

      Try

         If Me.dgvDetalle.SelectedRows.Count > 0 Then

            Dim nota As Eniac.Entidades.RecepcionNotaF = New Eniac.Entidades.RecepcionNotaF()
            Dim rNotas As Eniac.Reglas.RecepcionNotasF = New Eniac.Reglas.RecepcionNotasF()

            nota = rNotas.GetUno(actual.Sucursal.IdSucursal, Integer.Parse(Me.dgvDetalle.SelectedRows(0).Cells("NroNota").Value.ToString()))

            'Quien lo esta modificando ahora.
            nota.Usuario = actual.Nombre

            'abre el formulario de nota de recepcion enviandole la nota
            Dim frm As NotaRecepcionF = New NotaRecepcionF(nota)

            frm.StateForm = Eniac.Win.StateForm.Actualizar
            frm.ShowDialog()

            Me.btnConsultar.PerformClick()

         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbImprimirNota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirNota.Click

      Try
         If Me.dgvDetalle.SelectedRows.Count > 0 Then
            Dim nota As Eniac.Entidades.RecepcionNotaF = New Eniac.Entidades.RecepcionNotaF()
            nota = New Eniac.Reglas.RecepcionNotasF().GetUno(actual.Sucursal.IdSucursal, Integer.Parse(Me.dgvDetalle.SelectedRows(0).Cells("NroNota").Value.ToString()))
            Me.ImprimirNotaRecepcion(nota)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCliente.Enabled = Me.chbCliente.Checked
      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      
      If Not Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Text = ""
         Me.bscCliente.Text = ""
      Else
         Me.bscCodigoCliente.Focus()
      End If

   End Sub

   Private Sub bscNroDoc_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes
         Dim codigoCliente As Long = -1
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNroDoc_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), True)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: Activo el filtro de Cliente, Debe seleccionar uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         Dim idEstado As Integer = 0
         Dim fec1 As DateTime = Nothing
         Dim fec2 As DateTime = Nothing
         Dim IdCliente As Long = 0

         Dim prodRec As Eniac.Reglas.ProductosRecepcionF = New Eniac.Reglas.ProductosRecepcionF()

         idEstado = Integer.Parse(Me.cmbEstado.SelectedValue.ToString())

         If Me.dtpFechaEnvioDesde.Checked Then
            fec1 = Me.dtpFechaEnvioDesde.Value
         End If
         If Me.dtpFechaEnvioHasta.Checked Then
            fec2 = Me.dtpFechaEnvioHasta.Value
         End If

         If Me.chbCliente.Checked Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         Me.dgvDetalle.DataSource = prodRec.GetProductosEnReparacion(actual.Sucursal.Id, idEstado, fec1, fec2, IdCliente)

         Me.tslRegistros.Text = Me.dgvDetalle.RowCount.ToString() + " Registros"

         Me.dgvDetalle.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Metodos"

   Private Sub CargaComboEstados()
      Dim oEstado As Eniac.Reglas.RecepcionEstadosF = New Eniac.Reglas.RecepcionEstadosF()

      With Me.cmbEstado
         .DisplayMember = "NombreEstado"
         .ValueMember = "IdEstado"
         .DataSource = oEstado.GetTodos()
      End With
   End Sub

   Private Sub CargarValoresIniciales()

      Me.cmbEstado.SelectedValue = 10

      Me.dtpFechaEnvioDesde.Value = Date.Now
      Me.dtpFechaEnvioDesde.Checked = False

      Me.dtpFechaEnvioHasta.Value = Date.Now
      Me.dtpFechaEnvioHasta.Checked = False

      Me.chbCliente.Checked = False

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)
      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()

      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

      Me.btnConsultar.Focus()
   End Sub

   Private Sub ImprimirNotaRecepcion(ByVal Nota As Eniac.Entidades.RecepcionNotaF)

      Me.Cursor = Cursors.WaitCursor

      Try
         Dim oImprimir As ImpresionNotaF = New ImpresionNotaF(Nota)
         oImprimir.ImprimirNotaRecepcion()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#End Region

End Class