Option Strict Off
Imports Infragistics.Win.UltraWinGrid

Public Class AcuerdosDePagosDetalle
   Dim CtaCte As Entidades.CuentaCorriente

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.CuentaCorriente)
      Me.InitializeComponent()
      CtaCte = entidad
      '  Me._entidad = entidad
   End Sub

#End Region

   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
   Private _fechaFactura As DateTime
   Private _dt As DataTable
   Private _diasCC As Integer
   Private _NroCuota As Integer = 0
   Private _ModificaFecha As Boolean = False
   Private _CantidadCuotas As Integer = 0
   Private _DiasPrimerCuota As Integer = 0

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      'Me._tituloNuevo = "Nueva"

      MyBase.OnLoad(e)

      Try

         Dim entidad As Entidades.CuentaCorriente = DirectCast(CtaCte, Entidades.CuentaCorriente)

         Me._publicos = New Publicos()

         Me.Cursor = Cursors.WaitCursor

         Dim oLoca As Eniac.Reglas.Localidades = New Eniac.Reglas.Localidades()
         Dim dt As DataTable = oLoca.GetAll()
         Me.cmbLocalidad2.DisplayMember = "NombreLocalidad"
         Me.cmbLocalidad2.ValueMember = "IdLocalidad"
         Me.cmbLocalidad2.DataSource = dt.Copy()
         Me.cmbLocalidad2.SelectedIndex = -1

         Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
         Me.cmbFormaPago.SelectedIndex = 1

         'Porcentaje por MONTO (Parametro)
         Dim par As Eniac.Reglas.Parametros = New Eniac.Reglas.Parametros()
      
         '/***  Usuario ingreso desde un vehiculo particular ***/
         Dim dato As Entidades.Cliente = entidad.Cliente

         Me.txtNombre.Text = dato.NombreCliente
         Me.txtTelefono2.Text = dato.Telefono
         Me.txtDomicilio2.Text = dato.Direccion
         Me.cmbLocalidad2.Text = dato.Localidad.NombreLocalidad

         Me.ugDetalle.DataSource = (New Reglas.ClientesDeudas)._GetPendientes(dato.IdCliente)

         Me.InsertarColumnaCheckBox(Me.dgvPeriodosAdeudados)

         Me.CargarColumnasASumar2()

         '/*
         '**  Si esta editando un registro. (=> hiZO Click en la tabla de Datos del ABM)
         '*/
         'FORMA DE PAGO
         Me._dt = New DataTable()
         Me._dt.Columns.Add("MontoAPagar", System.Type.GetType("System.Decimal"))
         Me._dt.Columns.Add("Cuota", System.Type.GetType("System.Int32"))
         Me._dt.Columns.Add("Dias", System.Type.GetType("System.Int32"))
         Me._dt.Columns.Add("FechaAPagar", System.Type.GetType("System.DateTime"))

         Dim Dias As Integer = DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias

         Me._CantidadCuotas = DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).CantidadCuotas
         Me._DiasPrimerCuota = DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).DiasPrimerCuota

         Me.txtSaldo.Text = Me.txtPendiente.Text


         Me.dtpPrimerVencimiento.Value = DateTime.Now.AddDays(Dias)

         Me._diasCC = Dias

         Me._fechaFactura = DateTime.Now

         Me.CalcularTotalesPlanDePagos()

         Me.recalcularImporteDeCuota()
         Me._estaCargando = False

      Catch ex As Exception
         Throw
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub


   'Private Sub cargarDetalle(ByVal detalle As System.Collections.Generic.List(Of Entidades.PromesaDePagoDetalle))

   '   For Each en As Entidades.PromesaDePagoDetalle In detalle

   '      If Me.ugvPromesaDePago.DataSource Is Nothing Then
   '         Me.LimpiarGrillaCuotas()
   '      End If

   '      Dim dr As System.Data.DataRow = DirectCast(Me.ugvPromesaDePago.DataSource, DataTable).NewRow()

   '      dr("Cuota") = Integer.Parse(en.NumeroCuota.ToString)
   '      dr("Periodo") = en.Periodo.ToString
   '      dr("ImporteAproximado") = Decimal.Parse(en.importe.ToString)
   '      dr("FechaVencimiento") = Date.Parse(en.FechaCuota.ToString)
   '      If Not (en.FechaPago = Nothing) Then
   '         dr("FechaPago") = Date.Parse(en.FechaPago.ToString)
   '      End If
   '      dr("Usuario") = en.IdUsuario.ToString

   '      DirectCast(Me.ugvPromesaDePago.DataSource, DataTable).Rows.Add(dr)
   '   Next

   '   Me.txtCantPeriodos.Text = Me.ugvPromesaDePago.Rows.Count.ToString()

   'End Sub

   '/*
   '**   Toma las BaseABM Lee para obtener las reglas. ie. (Insert(entidad), Delete(entidad), Buscar, GetAll, Get_G1)
   '*/


   '/*
   '**   Es llamado cuando por BaseABM2 cuando se Acepta la Promesa de Pago y antes de llamar a Reglas(entidad) para guardar los datos.
   '*/

#End Region

#Region "Eventos"

   Private Sub ActualizarImporteCuotaDetallePago(ByVal nroCuota As Integer, ByVal totalCuota As Decimal)
      Dim nuevoValorCuota As Decimal = 0
      'For Each dr As UltraGridRow In ugvPromesaDePago.Rows
      '   If (nuevoValorCuota = 0) And (Integer.Parse(dr.Cells("Cuota").Value.ToString) = nroCuota) Then
      '      nuevoValorCuota = Decimal.Parse(dr.Cells("ImporteCuota").Value.ToString) + totalCuota
      '   End If
      '   If (Integer.Parse(dr.Cells("Cuota").Value.ToString) = nroCuota) Then
      '      dr.Cells("ImporteCuota").Value = nuevoValorCuota
      '   End If
      'Next
   End Sub

   Private Sub InsertarDetallePago(ByVal pila As Stack(Of Long), ByVal nroCuota As Integer, ByVal totalCuota As Decimal)
      Dim rw As System.Data.DataRow

      For Each dbIdPago As Decimal In pila
         For Each dr As DataGridViewRow In dgvPeriodosAdeudados.Rows

            If dbIdPago = Long.Parse(dr.Cells("ppIdPago").Value.ToString) Then

               'rw = DirectCast(Me.ugvPromesaDePago.DataSource, DataTable).NewRow()


               'rw("Cuota") = nroCuota
               'rw("Periodo") = dr.Cells("ppPeriodo").Value.ToString
               'rw("ImporteAproximado") = Decimal.Parse(dr.Cells("ppImporteAproximado").Value.ToString) 'totalCuota
               'rw("ImporteCuota") = totalCuota
               'If nroCuota > 0 Then
               '   rw("FechaVencimiento") = Me.txtPrimerVencimiento.Value.AddMonths(Integer.Parse(rw("Cuota").ToString()) - 1)
               'Else
               '   rw("FechaVencimiento") = Me.txtPrimerVencimiento.Value
               'End If
               'rw("Usuario") = Eniac.Entidades.Usuario.Actual.Nombre


               'DirectCast(Me.ugvPromesaDePago.DataSource, DataTable).Rows.Add(rw)

            End If

         Next
      Next

   End Sub

   Private Sub ugvPromesaDePago_AfterExitEditMode(ByVal sender As Object, ByVal e As System.EventArgs)
      Me.recalcularImporteDeCuota()
   End Sub

   Private Sub ugvPromesaDePago_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs)
      ' ugvPromesaDePago.ActiveRow.Cells("Usuario").Value = Eniac.Entidades.Usuario.Actual.Nombre
   End Sub

   Private Sub chbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTodos.CheckedChanged
      Me.Cursor = Cursors.WaitCursor

      For Each dr As UltraGridRow In Me.ugDetalle.Rows
         dr.Cells("CheckBox").Value = Me.chbTodos.Checked
      Next

      ' Me.CalcularTotalesPlanDePagos()
      Me.Cursor = Cursors.Default
   End Sub

   Private Sub dgvPlanPagos_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPeriodosAdeudados.CellContentClick
      Me.dgvPeriodosAdeudados.EndEdit()
      If Not (dgvPeriodosAdeudados.CurrentCell Is Nothing) Then
         If dgvPeriodosAdeudados.CurrentCell.ColumnIndex <> -1 And dgvPeriodosAdeudados.Columns(dgvPeriodosAdeudados.CurrentCell.ColumnIndex).Name = "CheckBox" Then
            Me.CalcularTotalesPlanDePagos()
         End If
      End If
   End Sub

   Private Sub txtNroCuotas_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
      Me.CalcularTotalesPlanDePagos()
   End Sub

   Private Sub cmbFormaPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFormaPago.SelectedIndexChanged
      If Me._estaCargando Then Exit Sub

      Dim Dias As Integer = DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias

      Me.dtpPrimerVencimiento.Value = Me._fechaFactura.AddDays(Dias)

      Me.EliminarLineas()
   End Sub

   Private Sub btnLimpiarProducto_Click(sender As Object, e As EventArgs) Handles btnLimpiarProducto.Click
      Try
         Me.dtpPrimerVencimiento.Value = Date.Today()
         Me.txtCuotas.Text = "1"
         Me.chbDiaFijo.Checked = False
         Me.chbPrimerCuota.Checked = False
         Me.btnInsertarVC.Enabled = True
         Me.EliminarLineas()
         Me._ModificaFecha = False
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugDetalle_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles ugDetalle.AfterCellUpdate
      Try

         Dim MontoAcordado As Decimal = 0
         Dim observacion As String = String.Empty

         For Each dr As UltraGridRow In ugDetalle.Rows
            If Boolean.Parse(dr.Cells("CheckBox").Value.ToString()) Then
               If Not String.IsNullOrEmpty(dr.Cells("ImporteAcordado").Value.ToString()) Then
                  MontoAcordado += Decimal.Parse(dr.Cells("ImporteAcordado").Value.ToString())
                  observacion += dr.Cells("nro_prestamo").Value.ToString() & "     "
               End If
            End If
         Next
         Me.txtSaldo.Text = MontoAcordado.ToString("#,##0.00")
         Me.txtRestan.Text = MontoAcordado.ToString("#,##0.00")
         Me.txtObservacion.Text = observacion.ToString()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnInsertarVC_Click(sender As Object, e As EventArgs) Handles btnInsertarVC.Click

      Try
         'If Me.chbDiaFijo.Checked Then
         '   If Not Me._ModificaFecha Then
         '      MessageBox.Show("El Primer Vencimiento no fue modificado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '      Exit Sub

         '   End If
         'Else
         '   Me.chbDiaFijo.Checked = Reglas.Publicos.FacturacionCtaCteSolicitaDiaFijo
         '   If Not Me._ModificaFecha Then
         '      MessageBox.Show("El Primer Vencimiento no fue modificado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '      Exit Sub
         '   End If
         'End If

         'If Decimal.Parse(Me.txtMonto.Text) = 0 Then
         '   MessageBox.Show("El monto debe ser mayor a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.txtMonto.Focus()
         '   Exit Sub
         'End If

         If Integer.Parse(Me.txtCuotas.Text) < 0 Then
            MessageBox.Show("La Cantidad de Cuotas debe ser mayor a uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtCuotas.Focus()
            Exit Sub
         End If

         If Me.dtpPrimerVencimiento.Value.Date < Me._fechaFactura.Date Then
            MessageBox.Show("El Primer Vencimiento NO Puede Ser Anterior a HOY.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpPrimerVencimiento.Focus()
            Exit Sub
         End If

         If DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias = 0 Then
            MessageBox.Show("La Forma de Pago NO Puede Ser Contado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpPrimerVencimiento.Focus()
            Exit Sub
         End If

         If Me.txtPrimeraCuota.Enabled And Me.txtPrimeraCuota.Text = "" Then
            MessageBox.Show("La primer cuota no puede ser 0.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtPrimeraCuota.Focus()
            Exit Sub
         End If

         Me.tsbGrabar.Enabled = True
         Me.btnInsertarVC.Enabled = False
         Me.cmbFormaPago.SelectedIndex = 1

         Me.InsertarCuotas()

         If Decimal.Parse(Me.txtRestan.Text) > 0 Then
            Me.txtCuotas.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnEliminarVC_Click(sender As Object, e As EventArgs) Handles btnEliminarVC.Click
      Try
         If Me.dgvCuotas.Rows.Count > 0 Then
            If MessageBox.Show("Esta seguro de Eliminar todas las Cuotas?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineas()
               Me.CalcularResto()
               Me.LimpiarCampos()
               Me.txtCuotas.Focus()
               Me.btnInsertarVC.Enabled = True
               Me._ModificaFecha = False
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbPrimerCuota_CheckedChanged(sender As Object, e As EventArgs) Handles chbPrimerCuota.CheckedChanged
      Try
         If Me.chbPrimerCuota.Checked And Me.dgvCuotas.Rows.Count <> 0 Then
            MessageBox.Show("Debe eliminar las cuotas para ingresar la primera cuota.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.chbPrimerCuota.Checked = False
            Exit Sub
         End If
         Me.txtPrimeraCuota.Enabled = Me.chbPrimerCuota.Checked
         If Me.chbPrimerCuota.Checked Then
            Me.txtPrimeraCuota.Focus()
         Else
            Me.txtPrimeraCuota.Text = ""
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

#Region "Metodos"
   Private Sub recalcularImporteDeCuota()
      Dim ImporteCuota As New Dictionary(Of Integer, Decimal)
      Dim tmp As Decimal = 0

      'For Each dr As UltraGridRow In ugvPromesaDePago.Rows
      '   If ImporteCuota.ContainsKey(CInt(dr.Cells("Cuota").Value)) Then
      '      tmp = ImporteCuota(CInt(dr.Cells("Cuota").Value))
      '      ImporteCuota.Remove(CInt(dr.Cells("Cuota").Value))
      '      ImporteCuota.Add(CInt(dr.Cells("Cuota").Value), tmp + Decimal.Parse(dr.Cells("ImporteAproximado").Value.ToString()))
      '   Else
      '      ImporteCuota.Add(CInt(dr.Cells("Cuota").Value), Decimal.Parse(dr.Cells("ImporteAproximado").Value.ToString()))
      '   End If
      'Next

      'For Each dr As UltraGridRow In ugvPromesaDePago.Rows
      '   dr.Cells("ImporteCuota").Value = ImporteCuota(CInt(dr.Cells("Cuota").Value))
      'Next

   End Sub

   Private Sub CalcularTotalesPlanDePagos()
      Dim selec As Double = 0
      Dim nselec As Double = 0
      Dim count As Integer = 0

      For Each dr As DataGridViewRow In dgvPeriodosAdeudados.Rows
         If Not dr.Cells("CheckBox").Value Is Nothing Then
            If Boolean.Parse(dr.Cells("CheckBox").Value.ToString()) Then
               selec = selec + Double.Parse(dr.Cells("ppImporteAproximado").Value.ToString)
               count = count + 1
            Else
               nselec = nselec + Double.Parse(dr.Cells("ppImporteAproximado").Value.ToString)
            End If
         Else
            nselec = nselec + Double.Parse(dr.Cells("deuda_exigible").Value.ToString)
         End If
         'If CBool(dr.Cells("CheckBox").Value) = True Then
         'Else
         'End If
      Next

      'Dim dnom As Double = 1
      'If IsNumeric(txtNroCuotas.Text) Then
      '   dnom = Double.Parse(txtNroCuotas.Text)
      '   If dnom < 1 Then dnom = 1
      'End If

      'txtSeleccionado.Text = selec.ToString("0.00")
      'txtPendiente.Text = nselec.ToString("0.00")
      'txtPromedio.Text = (selec / dnom).ToString("0.00")
      'txtRegistrosSeleccionados.Text = count.ToString
   End Sub

   Private Sub CargarColumnasASumar()
      If Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Count = 0 Then

         Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
         Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

         Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("deuda_exigible")
         Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("deuda_exigible", SummaryType.Sum, columnToSummarize1)
         summary1.DisplayFormat = "{0:c}"
         summary1.Appearance.TextHAlign = Infragistics.Win.HAlign.Right


         Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("capital_total")
         Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("capital_total", SummaryType.Sum, columnToSummarize2)
         summary2.DisplayFormat = "{0:c}"
         summary2.Appearance.TextHAlign = Infragistics.Win.HAlign.Right

         Dim columnToSummarize3 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("deuda_exigible_con_quita")
         Dim summary3 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("deuda_exigible_con_quita", SummaryType.Sum, columnToSummarize3)
         summary3.DisplayFormat = "{0:c}"
         summary3.Appearance.TextHAlign = Infragistics.Win.HAlign.Right

         Dim columnToSummarize4 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteAcordado")
         Dim summary4 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteAcordado", SummaryType.Sum, columnToSummarize4)
         summary4.DisplayFormat = "{0:c}"
         summary4.Appearance.TextHAlign = Infragistics.Win.HAlign.Right

         Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Importe Total:"

      End If
   End Sub

   Private Sub InsertarColumnaCheckBox(ByVal dgv As Eniac.Controles.DataGridView)
      Dim column As New DataGridViewCheckBoxColumn()
      With column
         .HeaderText = ""
         .Name = "CheckBox"
         .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .FlatStyle = FlatStyle.Standard
         .CellTemplate = New DataGridViewCheckBoxCell()
         .CellTemplate.Style.BackColor = Color.Beige
      End With
      dgv.Columns.Insert(0, column)
   End Sub


   Private Sub LimpiarGrillaCuotas()
      'If (Me.ugvPromesaDePago.DataSource Is Nothing) Then

      Dim dt As New DataTable

      With dt
         .Columns.Add("Cuota", GetType(Integer))
         .Columns.Add("Periodo", GetType(String))
         .Columns.Add("ImporteAproximado", GetType(Decimal))
         .Columns.Add("ImporteCuota", GetType(Decimal))
         .Columns.Add("FechaVencimiento", GetType(Date))
         .Columns.Add("FechaPago", GetType(Date))
         .Columns.Add("Usuario", GetType(String))
      End With

      ' Me.ugvPromesaDePago.DataSource = dt

      Me.txtCantPeriodos.Text = ""

      'Aca podemos dar formato a la tabla. Ver VB.UltraWinDataGrid.Formato
      'End If
   End Sub

   Private Function CalcularNumeroDeCuota(ByVal coe As Double, ByVal nro As Integer) As Integer
      Dim ret As Integer = 1

      Dim tmp As Double = Math.Truncate(nro * coe)

      ret = Integer.Parse(tmp.ToString) + 1
      Return ret
   End Function

   Private Sub CargarColumnasASumar2()

      If Not Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Exists("deuda_exigible") Then

         Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
         Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

         Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("deuda_exigible")
         Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("deuda_exigible", SummaryType.Sum, columnToSummarize1)
         summary1.DisplayFormat = "{0:N2}"
         summary1.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("capital_total")
         Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("capital_total", SummaryType.Sum, columnToSummarize2)
         summary2.DisplayFormat = "{0:N2}"
         summary2.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize10 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("deuda_exigible_con_quita")
         Dim summary10 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("deuda_exigible_con_quita", SummaryType.Sum, columnToSummarize10)
         summary10.DisplayFormat = "{0:N2}"
         summary10.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize4 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteAcordado")
         Dim summary4 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteAcordado", SummaryType.Sum, columnToSummarize4)
         summary4.DisplayFormat = "{0:N2}"
         summary4.Appearance.TextHAlign = HAlign.Right

         Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"
      End If


   End Sub

   Private Sub EliminarLineas()

      Me._dt.Clear()
      Me._NroCuota = 0
      Me.dgvCuotas.DataSource = Me._dt

      Me.CalcularResto()

      Me.LimpiarCampos()

   End Sub

   Private Sub LimpiarCampos()
      'Me.txtDias.Text = Me._diasCC
      ' Me.txtMonto.Text = Me.txtRestan.Text
      'Me.dtpFechaAPagar.Value = Me._fechaFactura.AddDays(Int32.Parse(Me.txtDias.Text))
   End Sub

   Private Sub InsertarCuotas()

      Dim DiasCC As Integer = New Reglas.VentasFormasPago().GetUna(Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString())).Dias
      Dim ImporteCuota As Decimal = 0
      Dim FechaVencimiento As Date = Me.dtpPrimerVencimiento.Value
      Dim montoRestan As Decimal
      Dim cuotas As Integer

      montoRestan = Decimal.Parse(Me.txtRestan.Text)
      cuotas = Integer.Parse(Me.txtCuotas.Text)

      If Me.chbPrimerCuota.Checked Then
         ImporteCuota = Decimal.Round((montoRestan - Decimal.Parse(Me.txtPrimeraCuota.Text)) / (cuotas - 1), 2)
      Else
         ImporteCuota = Decimal.Round(montoRestan / cuotas, 2)
      End If

      'realizo el calculo para que no queden centavos en las cuotas, si son $10000 en 3 cuotas la primer cuota tendria que ser de $3.333,34 y las otras de $3.333,33
      Dim dr As DataRow

      For i As Integer = 0 To cuotas - 1

         Me._NroCuota += 1
         dr = Me._dt.NewRow()

         If Me.chbPrimerCuota.Checked And i = 0 Then
            dr("MontoAPagar") = Decimal.Parse(Me.txtPrimeraCuota.Text.ToString())
         Else
            dr("MontoAPagar") = ImporteCuota
            'pongo en cero el ajuste porque ya lo use
         End If

         dr("Cuota") = Me._NroCuota

         dr("Dias") = DateDiff(DateInterval.Day, Me._fechaFactura, FechaVencimiento)
         dr("FechaAPagar") = FechaVencimiento

         Me._dt.Rows.Add(dr)

         If Me.chbDiaFijo.Checked Then
            FechaVencimiento = FechaVencimiento.AddMonths(1)
         Else
            FechaVencimiento = FechaVencimiento.AddDays(DiasCC)
         End If
      Next

      Me.dgvCuotas.DataSource = Me._dt
      Me.dgvCuotas.FirstDisplayedScrollingRowIndex = Me.dgvCuotas.Rows.Count - 1

      Me.CalcularResto()

      Me.LimpiarCampos()

   End Sub

   Private Sub CalcularResto()
      Dim resto As Decimal = 0
      resto = Decimal.Parse(Me.txtSaldo.Text)

      For Each dr As DataRow In Me._dt.Rows
         resto -= Decimal.Parse(dr("MontoAPagar").ToString())
      Next

      Me.txtRestan.Text = resto.ToString("#,##0.00")

   End Sub

#End Region

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.GrabarComprobante()
         Me.Close()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub GrabarComprobante()

      Try

         Me.tsbGrabar.Enabled = False
   
         If Decimal.Parse(Me.txtRestan.Text) <> 0 Then
            'If MessageBox.Show(String.Format("Tiene una diferencia de {0}. ¿Desea agregar el monto a la ultima cuota?", Decimal.Parse(Me.txtRestan.Text)), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            '   Exit Sub
            'End If
            Me._dt.Rows(Me._dt.Rows.Count - 1)("MontoAPagar") += Decimal.Parse(Me.txtRestan.Text)
         End If

         'Dim coe As Integer = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).CoeficienteValores
         Dim coe As Integer = 1
         'cargo el comprobante en el objeto CuentasCorrientes
         Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
         Dim CC As Entidades.CuentaCorriente = New Entidades.CuentaCorriente()
         ' Dim oVentasNumeros As New Reglas.VentasNumeros
         Dim Numero As Long

         Dim Deudas As DataTable

         With CC
            .IdSucursal = actual.Sucursal.Id
            .TipoComprobante.IdTipoComprobante = "MUTUAL"
            .Letra = "X"
            .CentroEmisor = 1

            Numero = oCtaCte.GetProximoNumeroCC(actual.Sucursal.Id, _
                                                                      .TipoComprobante.IdTipoComprobante, _
                                                                      .Letra, _
                                                                      .CentroEmisor).ToString()

            .NumeroComprobante = Numero
            .Fecha = DateTime.Now
            .FechaVencimiento = DateTime.Now
            .Cliente = CtaCte.Cliente
            .Vendedor = New Reglas.Empleados().GetUno(1)
            .FormaPago.IdFormasPago = 3
            .ImporteTotal = Decimal.Parse(Me.txtSaldo.Text) * coe
            .Saldo = .ImporteTotal
            .CantidadCuotas = Me.txtCuotas.Text
            .Observacion = ""
            .Usuario = actual.Nombre
            .IdEstado = "NORMAL"
            .Observacion = Me.txtObservacion.Text
            .Referencia = Me.txtReferencia.Text

            If .Cliente.IdClienteCtaCte <> 0 Then
               .IdClienteCtaCte = .Cliente.IdClienteCtaCte
            Else
               .IdClienteCtaCte = .Cliente.IdCliente
            End If

            .IdCategoria = .Cliente.IdCategoria
            .CotizacionDolar = 1
            .Direccion = .Cliente.Direccion
            .IdLocalidad = .Cliente.IdLocalidad
         End With


         Dim CCP As Entidades.CuentaCorrientePago = New Entidades.CuentaCorrientePago()

         For Each dr As DataRow In Me._dt.Rows
            CCP = New Entidades.CuentaCorrientePago()
            CCP.ImporteCuota = Decimal.Parse(dr("MontoAPagar").ToString())
            CCP.SaldoCuota = CCP.ImporteCuota
            CCP.FechaVencimiento = Date.Parse(dr("FechaAPagar").ToString())
            CCP.CuentaCorriente = CC
            CCP.Cuota = Integer.Parse(dr("Cuota").ToString())
            CC.Pagos.Add(CCP)
         Next

         Deudas = DirectCast(Me.ugDetalle.DataSource, DataTable)

         oCtaCte.GrabaCtaCteDominios(CC, Entidades.Entidad.MetodoGrabacion.Manual, "GestionMutual", Deudas)

         MessageBox.Show("Los datos se grabaron correctamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   'Private Function ValidarComprobante() As Boolean

   '   If Me.cmbTiposComprobantes.SelectedIndex = -1 Then
   '      MessageBox.Show("Debe Informar el Tipo de Comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '      Me.cmbTiposComprobantes.Focus()
   '      Return False
   '   End If

   '   If Integer.Parse("0" & Me.txtEmisorComprobante.Text) <= 0 Then
   '      MessageBox.Show("Debe Informar el Emisor de Comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '      Me.txtEmisorComprobante.Focus()
   '      Return False
   '   End If

   '   If Long.Parse("0" & Me.txtNumeroComprobante.Text) <= 0 Then
   '      MessageBox.Show("Debe Informar el Numero de Comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '      Me.txtNumeroComprobante.Focus()
   '      Return False
   '   End If

   '   If Decimal.Parse(Me.txtImporte.Text) <= 0 Then
   '      MessageBox.Show("Debe Informar el Importe.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '      Me.txtImporte.Focus()
   '      Return False
   '   End If

   '   Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes
   '   If oCtaCte.Existe(actual.Sucursal.Id, _
   '                     Me.cmbTiposComprobantes.SelectedValue.ToString(), _
   '                     Me.txtLetra.Text, _
   '                     Short.Parse(Me.txtEmisorComprobante.Text), _
   '                     Long.Parse(Me.txtNumeroComprobante.Text)) Then

   '      MessageBox.Show("El Comprobante YA Existe en la Cuenta Corriente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '      Me.txtImporte.Focus()
   '      Return False
   '   End If

   '   Dim oVentas As Reglas.Ventas = New Reglas.Ventas
   '   If oVentas.Existe(actual.Sucursal.Id, _
   '                     Me.cmbTiposComprobantes.SelectedValue.ToString(), _
   '                     Me.txtLetra.Text, _
   '                     Short.Parse(Me.txtEmisorComprobante.Text), _
   '                     Long.Parse(Me.txtNumeroComprobante.Text)) Then

   '      Dim ImporteTotal As Decimal
   '      ImporteTotal = oVentas.GetUna(actual.Sucursal.Id, _
   '                                 Me.cmbTiposComprobantes.SelectedValue.ToString(), _
   '                                 Me.txtLetra.Text, _
   '                                 Short.Parse(Me.txtEmisorComprobante.Text), _
   '                                 Long.Parse(Me.txtNumeroComprobante.Text)).ImporteTotal

   '      If Math.Abs(ImporteTotal) = Decimal.Parse(Me.txtImporte.Text) Then
   '         MessageBox.Show("El Comprobante YA Existe como Contado!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '         Me.txtImporte.Focus()
   '         Return False
   '      Else
   '         MessageBox.Show("El Comprobante Existe en Ventas y no coincide el Importe, el cual es " & Math.Abs(ImporteTotal).ToString("N2"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '         Me.txtImporte.Focus()
   '         Return False
   '      End If

   '   End If

   '   Return True

   'End Function
   'Private Sub CargarProximoNumero()

   '   If Me.txtLetra.Text <> "" Then

   '      Dim oVentasNumeros As New Reglas.VentasNumeros
   '      Dim oCtaCte As New Reglas.CuentasCorrientes
   '      Dim CentroEmisor As Short

   '      CentroEmisor = Short.Parse(Me.txtEmisorComprobante.Text)   'oImpresora.CentroEmisor

   '      If Me.chbNumeroDeCtaCte.Checked Then

   '         Me.txtNumeroComprobante.Text = oCtaCte.GetProximoNumeroCC(actual.Sucursal.Id, _
   '                                                               DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante, _
   '                                                               Me.txtLetra.Text, _
   '                                                               CentroEmisor).ToString()

   '      Else

   '         Me.txtNumeroComprobante.Text = oVentasNumeros.GetProximoNumero(actual.Sucursal.Id, _
   '                                                               DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante, _
   '                                                               Me.txtLetra.Text, _
   '                                                               CentroEmisor).ToString()
   '      End If

   '   Else

   '      Me.txtNumeroComprobante.Text = ""

   '   End If

   'End Sub

   Private Sub tbsSalir_Click(sender As Object, e As EventArgs) Handles tbsSalir.Click
      Me.Close()
   End Sub
End Class