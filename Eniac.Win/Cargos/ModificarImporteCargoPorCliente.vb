Option Strict Off
#Region "Imports"

Imports actual = Eniac.Entidades.Usuario.Actual

Imports Infragistics.Win.UltraWinGrid

Imports System.Data
Imports System.IO

#End Region

Public Class ModificarImporteCargoPorCliente

#Region "Campos"

   Private _publicos As Publicos
   Private _cargo As Boolean = False
   Private _tit As Dictionary(Of String, String)
   Private _mostrarDescRec As Boolean = Reglas.Publicos.CargosUtilizaDescuentosRecargos

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me._publicos.CargaComboTiposLiquidacion(cmbTiposLiquidacion)
      Me.cmbTiposLiquidacion.SelectedIndex = 0

      ugDetalle.DisplayLayout.Bands(0).Columns(Entidades.CargoCliente.Columnas.PrecioLista.ToString()).Hidden = Not _mostrarDescRec
      ugDetalle.DisplayLayout.Bands(0).Columns(Entidades.CargoCliente.Columnas.DescuentoRecargoPorc1.ToString()).Hidden = Not _mostrarDescRec

      _tit = GetColumnasVisiblesGrilla(ugDetalle)

      Me.CargarValoresIniciales()
   End Sub
#End Region

#Region "Eventos"

   Private Sub ModificarImporteCargoPorCliente_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      ElseIf e.KeyCode = Keys.F4 And Me.tsbGrabar.Enabled Then
         Me.tsbGrabar_Click(Me.tsbGrabar, New EventArgs())
      End If
   End Sub

   Private Sub btnActualizaImporte_Click(sender As Object, e As EventArgs) Handles btnActualizaImporte.Click
      Try

         If MessageBox.Show("¿Está seguro de desea aplicar el importe guardado en el cargo a todos los clientes seleccionadas?",
                            "Por favor confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

            Dim oadi As Reglas.Cargos = New Reglas.Cargos()
            Dim adi As Entidades.Cargo = New Entidades.Cargo()
            adi = oadi.GetUno(CInt(Me.bscCodigoCargo.Text), CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))

            For Each dr As UltraGridRow In Me.ugDetalle.Rows
               If Boolean.Parse(dr.Cells("Check").Value.ToString()) Then
                  dr.Cells("PrecioLista").Value = adi.Monto
                  dr.Cells("Monto").Value = adi.Monto * (1 + (Decimal.Parse(dr.Cells("DescuentoRecargoPorc1").Value.ToString()) / 100))
                  dr.Cells("Importe").Value = adi.Monto * dr.Cells("Cantidad").Value
               End If
            Next

            Me.ugDetalle.Update()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoCargo_BuscadorClick() Handles bscCodigoCargo.BuscadorClick

      Dim idCargo As Integer = -1

      Try

         Dim oAdicionales As Reglas.Cargos = New Reglas.Cargos()
         Publicos.PreparaGrillaAutomatico(Me.bscCodigoCargo, "Cargos")
         If Me.bscCodigoCargo.Text.Trim.Length > 0 Then
            idCargo = Integer.Parse(Me.bscCodigoCargo.Text.Trim())
         End If

         Me.bscCodigoCargo.Datos = oAdicionales.GetCargosModificaImporte(idCargo, String.Empty, CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoCargo_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCargo.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosAdicional(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreCargo_BuscadorClick() Handles bscNombreCargo.BuscadorClick
      Try
         Dim oAdicionales As Reglas.Cargos = New Reglas.Cargos()
         Publicos.PreparaGrillaAutomatico(Me.bscNombreCargo, "Cargos")
         Me.bscNombreCargo.Datos = oAdicionales.GetCargosModificaImporte(0, bscNombreCargo.Text, CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreCargo_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreCargo.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosAdicional(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Me.LimpiarDatosAdicional()
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.CargarValoresIniciales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         Me.CargarGrillaDetalles()
         Me.btnConsultar.Enabled = False
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
      Try
         Dim oAdicional As Reglas.CargosClientes = New Reglas.CargosClientes()
         Dim listaDatos As List(Of DataRow) = New List(Of DataRow)()

         Me.ugDetalle.UpdateData()

         For Each dr As UltraGridRow In Me.ugDetalle.Rows

            If CBool(dr.Cells("Check").Value) AndAlso
               dr.ListObject IsNot Nothing AndAlso TypeOf (dr.ListObject) Is DataRowView AndAlso
               DirectCast(dr.ListObject, DataRowView).Row IsNot Nothing Then

               listaDatos.Add(DirectCast(dr.ListObject, DataRowView).Row)
            End If
         Next

         oAdicional.Actualizar(listaDatos.ToArray())

         MessageBox.Show("Los Adicionales fueron grabados exitosamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         'Me.chbActualizaImporte.Checked = False
         'Me.chbClientesSeleccionarTodos.Checked = False

         Me.CargarValoresIniciales()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugvClientes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ugDetalle.KeyDown
      Select Case e.KeyCode
         Case Keys.Tab
            Me.ugDetalle.PerformAction(UltraGridAction.ExitEditMode)
            Me.ugDetalle.PerformAction(UltraGridAction.BelowCell)
            e.Handled = True
         Case Keys.Enter
            Me.ugDetalle.PerformAction(UltraGridAction.ExitEditMode)
            Me.ugDetalle.PerformAction(UltraGridAction.BelowCell)
            e.Handled = True
         Case Keys.Up
            Me.ugDetalle.PerformAction(UltraGridAction.ExitEditMode)
            Me.ugDetalle.PerformAction(UltraGridAction.AboveCell)
            e.Handled = True
         Case Keys.Down
            Me.ugDetalle.PerformAction(UltraGridAction.ExitEditMode)
            Me.ugDetalle.PerformAction(UltraGridAction.BelowCell)
            e.Handled = True
         Case Else
            If Me.ugDetalle.ActiveCell IsNot Nothing AndAlso (Not Me.ugDetalle.ActiveCell.IsInEditMode) Then
               Me.ugDetalle.PerformAction(UltraGridAction.EnterEditMode)
            End If
      End Select
   End Sub

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      Try
         Me.Cursor = Cursors.WaitCursor
         For Each dr As UltraGridRow In Me.ugDetalle.Rows
            dr.Cells("Check").Value = Me.chbTodos.Checked
         Next
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub ugvClientes_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      If CBool(e.Row.Cells("Check").Value) Then
         If CBool(e.Row.Cells(Entidades.Cargo.Columnas.ModificaImporte.ToString()).Value) Then
            e.Row.Cells(Entidades.CargoCliente.Columnas.Monto.ToString()).Activation = Activation.AllowEdit
         End If
         If CBool(e.Row.Cells(Entidades.Cargo.Columnas.ModificaCantidad.ToString()).Value) Then
            e.Row.Cells(Entidades.CargoCliente.Columnas.Cantidad.ToString()).Activation = Activation.AllowEdit
         End If
      Else
         e.Row.Cells(Entidades.CargoCliente.Columnas.Monto.ToString()).Activation = Activation.NoEdit
         e.Row.Cells(Entidades.CargoCliente.Columnas.Cantidad.ToString()).Activation = Activation.NoEdit
      End If
   End Sub

   Private Sub ugvClientes_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalle.CellChange
      If e.Cell.Column.Key = "Check" Then
         If CBool(e.Cell.Text) Then
            If CBool(e.Cell.Row.Cells(Entidades.Cargo.Columnas.ModificaImporte.ToString()).Value) Then
               e.Cell.Row.Cells(Entidades.CargoCliente.Columnas.Monto.ToString()).Activation = Activation.AllowEdit
            End If
            If CBool(e.Cell.Row.Cells(Entidades.Cargo.Columnas.ModificaCantidad.ToString()).Value) Then
               e.Cell.Row.Cells(Entidades.CargoCliente.Columnas.Cantidad.ToString()).Activation = Activation.AllowEdit
            End If
         Else
            e.Cell.Row.Cells(Entidades.CargoCliente.Columnas.Monto.ToString()).Activation = Activation.NoEdit
            e.Cell.Row.Cells(Entidades.CargoCliente.Columnas.Cantidad.ToString()).Activation = Activation.NoEdit
         End If
      End If
   End Sub

   Private Sub cmbTiposLiquidacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposLiquidacion.SelectedIndexChanged
      Try
         Me.bscCodigoCargo.Text = ""
         Me.bscCodigoCargo.Enabled = True
         Me.bscNombreCargo.Text = ""
         Me.bscNombreCargo.Tag = ""
         Me.bscNombreCargo.Enabled = True
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarGrillaDetalles()

      Me.btnActualizaImporte.Enabled = True
      Me.chbTodos.Checked = False

      Dim oCargClientes As Reglas.CargosClientes = New Reglas.CargosClientes()
      Dim dt As DataTable
      Dim Cargo As Integer
      Cargo = Integer.Parse(Me.bscCodigoCargo.Text)

      dt = oCargClientes.Get(Nothing, Cargo, True, actual.Sucursal.IdSucursal, CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()), IdCobrador:=0)

      Me.ugDetalle.DataSource = dt

      Me.AjustarColumnasGrilla()

   End Sub

   Private Sub CargarValoresIniciales()

      Me._cargo = False

      Me.bscNombreCargo.Enabled = True
      Me.bscCodigoCargo.Enabled = True
      Me.bscCodigoCargo.Text = ""
      Me.bscNombreCargo.Text = ""
      Me.txtMonto.Text = "0.00"
      btnActualizaImporte.Enabled = False
      btnConsultar.Enabled = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

   End Sub

   Private Sub CargarDatosAdicional(ByVal dr As DataGridViewRow)

      Me.bscNombreCargo.Text = dr.Cells(Entidades.Cargo.Columnas.NombreCargo.ToString()).Value.ToString()
      Me.bscNombreCargo.Enabled = False
      Me.bscCodigoCargo.Text = dr.Cells(Entidades.Cargo.Columnas.IdCargo.ToString()).Value.ToString()
      Me.bscCodigoCargo.Enabled = False
      Me.txtMonto.Text = dr.Cells(Entidades.Cargo.Columnas.Monto.ToString()).Value.ToString()

      Me.btnConsultar.Enabled = True
      Me.btnConsultar.Focus()

   End Sub

   Private Sub LimpiarDatosAdicional()
      Me.bscCodigoCargo.Text = ""
      Me.bscCodigoCargo.Enabled = True
      Me.bscNombreCargo.Text = ""
      Me.bscNombreCargo.Tag = ""
      Me.bscNombreCargo.Enabled = True
      Me.btnConsultar.Enabled = True
      Me.bscCodigoCargo.Focus()
   End Sub

   Private Overloads Sub AjustarColumnasGrilla()
      AjustarColumnasGrilla(ugDetalle, _tit)

      'Dim tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()

      'tit.Add("Check", "")
      'tit.Add(Entidades.Cliente.Columnas.CodigoCliente.ToString(), "")
      'tit.Add(Entidades.Cliente.Columnas.NombreCliente.ToString(), "")
      'tit.Add(Entidades.Cliente.Columnas.NombreDeFantasia.ToString(), "")
      'tit.Add(Entidades.Categoria.Columnas.NombreCategoria.ToString(), "")
      'tit.Add(Entidades.ZonaGeografica.Columnas.NombreZonaGeografica.ToString(), "")
      'tit.Add(Entidades.CargoCliente.Columnas.Cantidad.ToString(), "")
      'tit.Add(Entidades.CargoCliente.Columnas.Monto.ToString(), "")
      'tit.Add("NombreTipoLiquidacion", "")

      'For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.ugDetalle.DisplayLayout.Bands(0).Columns
      '   If Not tit.ContainsKey(col.Key) Then
      '      col.Hidden = True
      '   End If
      'Next

   End Sub

#End Region

End Class