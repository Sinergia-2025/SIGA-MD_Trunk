Public Class CuentaCorrienteTurismo

#Region "Campos"
   Public Const MontoAPagarColumnName As String = "MontoAPagar"
   Public Const CuotaColumnName As String = "Cuota"
   Public Const FechaAPagarColumnName As String = "FechaAPagar"
   Private Property Reserva As Entidades.ReservaTurismo

   Private _dt As DataTable
   Private _publicos As Publicos

#End Region

#Region "Propiedades"

   Public ReadOnly Property Pagos() As DataTable
      Get
         Return _dt
      End Get
   End Property

   'Public ReadOnly Property IdFormaDePago() As Integer
   '   Get
   '      Return Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString())
   '   End Get
   'End Property

#End Region

#Region "Constructores"

   Public Sub New(reserva As Entidades.ReservaTurismo)
      MyBase.New()
      InitializeComponent()

      Me.Reserva = reserva

      _dt = New DataTable()
      _dt.Columns.Add(MontoAPagarColumnName, GetType(Decimal))
      _dt.Columns.Add(CuotaColumnName, GetType(Integer))
      _dt.Columns.Add(FechaAPagarColumnName, GetType(Date))
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      Try
         Me.cmbFormaPago.SelectedValue = Reserva.IdFormaPago

         Dim fp As Entidades.VentaFormaPago = cmbFormaPago.ItemSeleccionado(Of Entidades.VentaFormaPago)()
         If fp IsNot Nothing Then
            Dim Dias As Integer = fp.Dias

            Me.txtSaldo.Text = Reserva.Costo.ToString(txtSaldo.Formato)

            Me.dtpPrimerVencimiento.Value = Date.Today
            Me.dtpFechaViaje.Value = Reserva.FechaViaje

         Else
            ShowMessage(String.Format("La forma de pago {0} de la Reserva {1} no existe o se encuentra inactiva", Reserva.IdFormaPago, Reserva))
            Cancelar()
         End If

         dgvCuotas.AgregarTotalesSuma({MontoAPagarColumnName})
         MuestraCantidadCuotas()

      Catch ex As Exception
         ShowError(ex)
         Cancelar()
      End Try
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS", False)

         Me.dgvCuotas.DataSource = Me._dt

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Console.WriteLine(keyData.ToString())
      If keyData = (Keys.Add Or Keys.Control) Then
         btnInsertarVC.PerformClick()
      ElseIf keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      ElseIf keyData = Keys.Escape Then
         btnCancelar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(Sub() Aceptar())
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      Cancelar()
   End Sub

   Private Sub btnInsertarVC_Click(sender As Object, e As EventArgs) Handles btnInsertarVC.Click
      TryCatched(
         Sub()
            '# Valido que el importe de ANTICIPO no sea negativo.
            If Decimal.Parse(txtAdelanto.Text) < 0 Then
               txtAdelanto.Focus()
               Throw New Exception("El Importe de ANTICIPO no puede ser menor a $0.00.")
            End If

            RecalculaCuotas()

            txtAdelanto.ReadOnly = True
         End Sub)
   End Sub

   Private Sub cmbFormaPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFormaPago.SelectedIndexChanged
      TryCatched(
         Sub()
            dtpPrimerVencimiento.Value = Reserva.FechaViaje
            EliminarLineas()
         End Sub)
   End Sub

   Private Sub btnLimpiarProducto_Click(sender As Object, e As EventArgs) Handles btnLimpiarProducto.Click
      TryCatched(
         Sub()
            dtpPrimerVencimiento.Value = Date.Today
            MuestraCantidadCuotas()

            txtAdelanto.ReadOnly = False
            EliminarLineas()
         End Sub)
   End Sub

   Private Sub dtpPrimerVencimiento_ValueChanged(sender As Object, e As EventArgs) Handles dtpPrimerVencimiento.ValueChanged
      TryCatched(Sub() MuestraCantidadCuotas())
   End Sub

   Private Sub dtpPrimerVencimiento_DropDown(sender As Object, e As EventArgs) Handles dtpPrimerVencimiento.DropDown
      TryCatched(Sub() MuestraCantidadCuotas())
   End Sub

#End Region

#Region "Metodos"
   Private Sub LimpiarCampos()

   End Sub

   Private Function NuevaCuota(cuota As Integer, fecha As Date, importe As Decimal) As DataRow
      Dim dr As DataRow = _dt.NewRow()
      dr(CuotaColumnName) = cuota
      dr(FechaAPagarColumnName) = fecha
      dr(MontoAPagarColumnName) = importe

      ' # Si el importe de la Cuota es $0.00, se arroja una Exception
      If importe = 0 Then
         Throw New Exception("No se puede generar una cuota con Importe $0.00. El anticipo ingresado cubre la totalidad del viaje y no queda saldo para definir las cuotas restantes.")
      End If
      Return dr
   End Function

   Private Sub RecalculaCuotas()
      EliminarLineas()

      Dim importeTotal = Reserva.Costo ' Decimal.Parse(txtSaldo.Text)

      'realizo el calculo para que no queden centavos en las cuotas, si son $10000 en 3 cuotas la primer cuota tendria que ser de $3.333,34 y las otras de $3.333,33
      'Dim dr As DataRow
      Dim fechaCuota = dtpPrimerVencimiento.Value
      Dim cantidadCuotas = CalculaCantidadCuotas()

      Dim anticipo = txtAdelanto.Text.ValorNumericoPorDefecto(0D)
      If anticipo > 0 Then

         ' # Si el anticipo ingresado es > al importe total del viaje, arrojo una Exception
         If anticipo > importeTotal Then
            txtAdelanto.Focus()
            Throw New Exception("El Importe de ANTICIPO no puede ser mayor al Importe Total del viaje.")
         End If

         _dt.Rows.Add(NuevaCuota(0, fechaCuota, anticipo))
         cantidadCuotas -= 1
      End If

      Dim cuotasParc = cantidadCuotas - 1
      'Dim importeTotalCuotas As Decimal = Math.Round((importeTotal - anticipo) / cantidadCuotas, 2) * cuotasParc 'Importe total - 1 cuota (para calcular la ultima)
      Dim importeTotalCuotas As Decimal = (importeTotal - anticipo) / cantidadCuotas * cuotasParc 'Importe total - 1 cuota (para calcular la ultima)
      Dim importeCuota As Decimal = (importeTotal - anticipo) / cantidadCuotas
      Dim importeCuotaRedondeada As Decimal = Math.Round(importeCuota / 10) * 10
      'Dim dif As Decimal = Math.Round(((importeCuotaRedondeada * cuotasParc) - importeCuota) / 10) * 10 'Calculo de Dif entre todas las cuotas redondeadas - importeCuota
      'Dim ultimaCuota As Decimal = importeCuotaRedondeada - dif
      Dim dif As Decimal = ((importeCuotaRedondeada * cuotasParc) - importeTotalCuotas) 'Calculo de Dif entre todas las cuotas redondeadas - importeCuota
      Dim ultimaCuota As Decimal = importeCuota - dif

      For i As Integer = 1 To cantidadCuotas
         'Cuando llega a la ultima cuota se le resta la diferencia
         If i = cantidadCuotas Then
            _dt.Rows.Add(NuevaCuota(i, fechaCuota.AddMonths(i - 1), ultimaCuota))
         Else
            _dt.Rows.Add(NuevaCuota(i, fechaCuota.AddMonths(i - 1), importeCuotaRedondeada)) 'redondeo
         End If
      Next

      dgvCuotas.DataSource = _dt
      'Me.dgvCuotas.FirstDisplayedScrollingRowIndex = Me.dgvCuotas.Rows.Count - 1

      LimpiarCampos()

   End Sub

   Private Sub EliminarLineas()
      _dt.Clear()
      dgvCuotas.DataSource = _dt

      LimpiarCampos()
   End Sub

#End Region

   Private Function ValidarAceptar() As Boolean
      Dim cantidadCuotasCalculadas As Integer = CalculaCantidadCuotas()
      If _dt.Rows.Count <> cantidadCuotasCalculadas Then
         ShowMessage(String.Format("La cantidad de cuotas calculadas ({0}) es menor a la cantidad de cuotas necesarias ({1}). Recalcule las cuotas.", _dt.Rows.Count, cantidadCuotasCalculadas))
         Return False
      End If

      Dim importeTotal As Decimal = 0
      importeTotal = _dt.Select().Sum(Function(dr) dr.Field(Of Decimal)(MontoAPagarColumnName))
      '_dt.Select().ToArray().All(Function(dr)
      '                              importeTotal += dr.Field(Of Decimal)(MontoAPagarColumnName)
      '                              Return True
      '                           End Function)
      importeTotal = Math.Round(importeTotal, 2)
      If importeTotal <> Reserva.Costo Then
         ShowMessage(String.Format("El importe total de las cuotas ({0}) es diferente al Importe de Viaje ({1})", importeTotal, Reserva.Costo))
         Return False
      End If

      Return True
   End Function

   Private Sub Aceptar()
      If ValidarAceptar() Then
         DialogResult = DialogResult.OK
         Close()
      End If
   End Sub

   Private Sub Cancelar()
      DialogResult = DialogResult.Cancel
      Close()
   End Sub

   Private Function CalculaCantidadCuotas() As Integer
      Dim cantCuotas As Integer
      cantCuotas = Convert.ToInt32(DateDiff(DateInterval.Month, dtpPrimerVencimiento.Value, dtpFechaViaje.Value))
      If dtpPrimerVencimiento.Value.AddMonths(cantCuotas) > dtpFechaViaje.Value.AddDays(-1) Then
         cantCuotas -= 1
      End If
      Return cantCuotas
   End Function

   Private Sub MuestraCantidadCuotas()
      txtCuotas.Text = CalculaCantidadCuotas().ToString()
   End Sub

End Class