Option Strict Off
Public Class CuentaCorrienteProveedorV2

#Region "Campos"

   Private _dt As DataTable
   Private _fechaFactura As DateTime
   Private _diasCC As Integer
   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
   Private _NroCuota As Integer = 0
   Private _ModificaFecha As Boolean = False
   Private _CantidadCuotas As Integer = 0
   Private _DiasPrimerCuota As Integer = 0

#End Region

#Region "Propiedades"

   Public ReadOnly Property Pagos() As DataTable
      Get
         Return Me._dt
      End Get
   End Property

   Public ReadOnly Property IdFormaDePago() As Integer
      Get
         Return Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString())
      End Get
   End Property

#End Region

#Region "Constructores"

   Public Sub New(ByVal fechaFactura As DateTime, ByVal montoACancelar As Decimal, ByVal IdFormaDePago As Integer)

      MyBase.New()

      Me.InitializeComponent()

      Try

         Me._dt = New DataTable()
         Me._dt.Columns.Add("MontoAPagar", System.Type.GetType("System.Decimal"))
         Me._dt.Columns.Add("Cuota", System.Type.GetType("System.Int32"))
         Me._dt.Columns.Add("Dias", System.Type.GetType("System.Int32"))
         Me._dt.Columns.Add("FechaAPagar", System.Type.GetType("System.DateTime"))

         Me._publicos = New Publicos()

         Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, "COMPRAS")
         Me.cmbFormaPago.SelectedValue = IdFormaDePago

         Dim Dias As Integer = DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias

         Me._CantidadCuotas = DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).CantidadCuotas
         Me._DiasPrimerCuota = DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).DiasPrimerCuota

         Me.chbDiaFijo.Checked = Reglas.Publicos.Facturacion.FacturacionCtaCteSolicitaDiaFijo

         Me.txtSaldo.Text = montoACancelar.ToString("N2")
         Me.txtMonto.Text = montoACancelar.ToString("N2")
         Me.txtDias.Text = Dias.ToString()
         Me.dtpFechaAPagar.Value = fechaFactura.AddDays(Dias)


         Me.dtpPrimerVencimiento.Value = fechaFactura.AddDays(Dias)

         Me._diasCC = Dias
         Me._fechaFactura = fechaFactura

         Me.CalcularResto()

         Me._estaCargando = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         If Me._CantidadCuotas <> 0 Then
            Me.dtpPrimerVencimiento.Value = Me._fechaFactura.AddDays(Me._DiasPrimerCuota)
            Me.txtCuotas.Text = Me._CantidadCuotas.ToString()
            Me._ModificaFecha = True
            Me.btnInsertarVC.PerformClick()
         End If

         Me.dgvCuotas.DataSource = Me._dt

         'Me.dtpFechaAPagar.Value = Me._fechaFactura.AddDays(30)

         'Me.txtDias.Text = "0"   'Antes 30. La mayoria no va a usar cuotas, por lo tanto el vencimiento es el mismo dia.

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub txtDias_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDias.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.dtpFechaAPagar.Focus()
      End If
   End Sub

   Private Sub txtDias_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDias.Leave
      If Me.txtDias.Text.Trim().Length = 0 Then Me.txtDias.Text = "0"
      Me.dtpFechaAPagar.Value = Me._fechaFactura.AddDays(Int32.Parse(Me.txtDias.Text))
   End Sub

   Private Sub dtpFechaAPagar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaAPagar.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.btnInsertar.Focus()
      End If
   End Sub

   Private Sub dtpFechaAPagar_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaAPagar.Leave
      Me.txtDias.Text = (Me.dtpFechaAPagar.Value - Me._fechaFactura).Days.ToString()
   End Sub

   Private Sub txtMonto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMonto.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtDias.Focus()
      End If
   End Sub

   Private Sub btnInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertar.Click
      Try

         If Me.chbDiaFijo.Checked Then
            If Not Me._ModificaFecha Then
               MessageBox.Show("El Vencimiento no fue modificado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If
         End If

         If Decimal.Parse(Me.txtMonto.Text) <= 0 Then
            MessageBox.Show("El monto debe ser mayor a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMonto.Focus()
            Exit Sub
         End If

         If Decimal.Parse(Me.txtMonto.Text) > Decimal.Parse(Me.txtRestan.Text) Then
            MessageBox.Show("El monto a pagar no puede ser mayor que el resto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMonto.Focus()
            Exit Sub
         End If

         Me.InsertarCuota()

         If Decimal.Parse(Me.txtRestan.Text) > 0 Then
            Me.txtMonto.Focus()
         Else
            Me.btnAceptar.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
      Try
         If Me.dgvCuotas.SelectedCells.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el item seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLinea()
               Me.txtMonto.Focus()
               Me._ModificaFecha = False
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Decimal.Parse(Me.txtRestan.Text) >= 0.1 Then
         MessageBox.Show("El Resto debe ser Cero para Aceptar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         If Integer.Parse(Me.txtCuotas.Text) > 1 Then
            Me.btnEliminarVC.Focus()
         Else
            Me.txtMonto.Focus()
         End If
         Exit Sub
      Else
         If Decimal.Parse(Me.txtRestan.Text) <> 0 AndAlso Decimal.Parse(Me.txtRestan.Text) < 0.1 Then
            If MessageBox.Show(String.Format("Tiene una diferencia de {0}. ¿Desea agregar el monto a la ultima cuota?", Decimal.Parse(Me.txtRestan.Text)), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
               Exit Sub
            End If
            'por aca sigue si presiono el boton "yes"
            Me._dt.Rows(Me._dt.Rows.Count - 1)("MontoAPagar") += Decimal.Parse(Me.txtRestan.Text)
         End If
      End If
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub

   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub btnInsertarVC_Click(sender As Object, e As EventArgs) Handles btnInsertarVC.Click

      Try
         If Me.chbDiaFijo.Checked Then
            If Not Me._ModificaFecha Then
               MessageBox.Show("El Primer Vencimiento no fue modificado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub

            End If
         Else
            Me.chbDiaFijo.Checked = Reglas.Publicos.Facturacion.FacturacionCtaCteSolicitaDiaFijo
            If Not Me._ModificaFecha Then
               MessageBox.Show("El Primer Vencimiento no fue modificado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If
         End If

         If Decimal.Parse(Me.txtMonto.Text) = 0 Then
            MessageBox.Show("El monto debe ser mayor a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMonto.Focus()
            Exit Sub
         End If

         If Integer.Parse(Me.txtCuotas.Text) < 2 Then
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

         Me.InsertarCuotas()

         If Decimal.Parse(Me.txtRestan.Text) > 0 Then
            Me.txtCuotas.Focus()
         Else
            Me.btnAceptar.Focus()
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
               Me._ModificaFecha = False
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub cmbFormaPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFormaPago.SelectedIndexChanged

      If Me._estaCargando Then Exit Sub

      Dim Dias As Integer = DirectCast(Me.cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias

      Me.dtpPrimerVencimiento.Value = Me._fechaFactura.AddDays(Dias)

      Me.EliminarLineas()

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

   Private Sub btnLimpiarProducto_Click(sender As Object, e As EventArgs) Handles btnLimpiarProducto.Click
      Try
         Me.dtpPrimerVencimiento.Value = Date.Today()
         Me.txtCuotas.Text = "1"
         Me.chbDiaFijo.Checked = False
         Me.chbPrimerCuota.Checked = False

         Me.EliminarLineas()
         Me._ModificaFecha = False
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dtpPrimerVencimiento_ValueChanged(sender As Object, e As EventArgs) Handles dtpPrimerVencimiento.ValueChanged
      Try
         If Not Me._estaCargando Then
            Me._ModificaFecha = True

            Me.chbDiaFijo.Checked = Reglas.Publicos.Facturacion.FacturacionCtaCteSolicitaDiaFijo

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dtpPrimerVencimiento_DropDown(sender As Object, e As EventArgs) Handles dtpPrimerVencimiento.DropDown
      Try
         If Not Me._estaCargando Then
            Me._ModificaFecha = True

            Me.chbDiaFijo.Checked = Reglas.Publicos.Facturacion.FacturacionCtaCteSolicitaDiaFijo

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Metodos"
   Private Sub InsertarCuota()

      Dim dr As DataRow = Me._dt.NewRow()

      Me._NroCuota += 1
      dr("MontoAPagar") = Me.txtMonto.Text
      dr("Cuota") = Me._NroCuota
      dr("Dias") = Me.txtDias.Text
      dr("FechaAPagar") = Me.dtpFechaAPagar.Value

      Me._dt.Rows.Add(dr)


      Me.dgvCuotas.DataSource = Me._dt
      Me.dgvCuotas.FirstDisplayedScrollingRowIndex = Me.dgvCuotas.Rows.Count - 1

      Me.CalcularResto()

      Me.LimpiarCampos()


   End Sub

   Private Sub EliminarLinea()

      Me._NroCuota = 0

      Me._dt.Rows.RemoveAt(Me.dgvCuotas.SelectedCells(0).RowIndex)

      For Each dr As DataRow In Me._dt.Rows
         Me._NroCuota += 1
         dr("Cuota") = Me._NroCuota
      Next

      Me.dgvCuotas.DataSource = Me._dt

      Me.CalcularResto()

      Me.LimpiarCampos()

   End Sub

   Private Sub LimpiarCampos()
      'Me.txtDias.Text = Me._diasCC
      Me.txtMonto.Text = Me.txtRestan.Text
      'Me.dtpFechaAPagar.Value = Me._fechaFactura.AddDays(Int32.Parse(Me.txtDias.Text))
   End Sub

   Private Sub CalcularResto()
      Dim resto As Decimal = 0
      resto = Decimal.Parse(Me.txtSaldo.Text)

      For Each dr As DataRow In Me._dt.Rows
         resto -= Decimal.Parse(dr("MontoAPagar").ToString())
      Next

      Me.txtRestan.Text = resto.ToString("#,##0.00")

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

   Private Sub EliminarLineas()

      Me._dt.Clear()
      Me._NroCuota = 0
      Me.dgvCuotas.DataSource = Me._dt

      Me.CalcularResto()

      Me.LimpiarCampos()

   End Sub

#End Region

   Private Sub dtpFechaAPagar_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaAPagar.ValueChanged
      Try
         If Not Me._estaCargando Then
            Me._ModificaFecha = True
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dtpFechaAPagar_DropDown(sender As Object, e As EventArgs) Handles dtpFechaAPagar.DropDown
      Try
         If Not Me._estaCargando Then
            Me._ModificaFecha = True

            Me.chbDiaFijo.Checked = Reglas.Publicos.Facturacion.FacturacionCtaCteSolicitaDiaFijo

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

End Class