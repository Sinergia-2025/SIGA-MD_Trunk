Public Class CuentaCorrienteModificar

#Region "Campos"

   Private _dt As DataTable
   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
   Private _cuotas As Entidades.Venta

#End Region

#Region "Propiedades"

   Public ReadOnly Property Pagos() As DataTable
      Get
         Return _dt
      End Get
   End Property


#End Region

#Region "Constructores"

   Public Sub New(cuotas As Entidades.Venta)

      MyBase.New()

      InitializeComponent()

      TryCatched(
         Sub()
            _cuotas = cuotas
            CargarCuotas()
            _estaCargando = False
         End Sub)

   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         ugDetalle.AgregarFiltroEnLinea({"Cuota", "FechaAPagar", "MontoAPagar", "SaldoCuota", "ReferenciaCuota"})
         ugDetalle.AgregarTotalesSuma({"MontoAPagar", "SaldoCuota"})
         ugDetalle.DataSource = _dt
         For Each dr As UltraGridRow In Me.ugDetalle.Rows
            If Decimal.Parse(dr.Cells("SaldoCuota").Value.ToString()) = 0 Then
               dr.Cells("FechaAPagar").Activation = Activation.NoEdit
               dr.Cells("FechaAPagar").Appearance.BackColor = Color.White
            End If
         Next
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      ElseIf keyData = Keys.Escape Then
         btnCancelar.PerformClick()
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

#Region "Eventos"
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(
         Sub()
            Dim octacte = New Reglas.CuentasCorrientesPagos()
            octacte.ActualizaFechasVencimiento(_dt)
            DialogResult = DialogResult.OK
            Close()
         End Sub)
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(
         Sub()
            DialogResult = DialogResult.Cancel
            Close()
         End Sub)
   End Sub

   Private Sub btnLimpiarProducto_Click(sender As Object, e As EventArgs)
      TryCatched(Sub() ugDetalle.DataSource = _dt)
   End Sub
#End Region

#Region "Metodos"
   Private Sub CargarCuotas()
      _dt = New DataTable()
      _dt.Columns.Add("IdSucursal", GetType(Integer))
      _dt.Columns.Add("IdTipoComprobante", GetType(String))
      _dt.Columns.Add("Letra", GetType(String))
      _dt.Columns.Add("CentroEmisor", GetType(Integer))
      _dt.Columns.Add("NumeroComprobante", GetType(Long))
      _dt.Columns.Add("MontoAPagar", GetType(Decimal))
      _dt.Columns.Add("Cuota", GetType(Integer))
      _dt.Columns.Add("SaldoCuota", GetType(Decimal))
      _dt.Columns.Add("FechaAPagar", GetType(Date))
      _dt.Columns.Add("ReferenciaCuota", GetType(Long))

      _publicos = New Publicos()

      For Each cuota In _cuotas.CuentaCorriente.Pagos
         Dim dr As DataRow = _dt.NewRow()
         dr("IdSucursal") = cuota.IdSucursal
         dr("IdTipoComprobante") = cuota.IdTipoComprobante
         dr("Letra") = cuota.Letra
         dr("CentroEmisor") = cuota.CentroEmisor
         dr("NumeroComprobante") = cuota.NumeroComprobante
         dr("MontoAPagar") = cuota.ImporteCuota
         dr("Cuota") = cuota.Cuota
         dr("FechaAPagar") = cuota.FechaVencimiento
         dr("SaldoCuota") = cuota.SaldoCuota
         dr("ReferenciaCuota") = cuota.ReferenciaCuota

         _dt.Rows.Add(dr)
      Next

   End Sub

#End Region



End Class