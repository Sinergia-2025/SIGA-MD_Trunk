Imports Eniac.Entidades

Public Class PedidosAdminCambioUbicacion
#Region "Campos/Constantes"
   Public dr As DataRow

   Private sucOrigen As Integer
   Private depOrigen As Integer
   Private ubiOrigen As Integer

   Private _cargaComboDestino As Boolean = True

   Private depOrigenII As Integer
   Private ubiOrigenII As Integer

   Private IdProducto As String

   Private _decimalesEnCantidad As Integer = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnCantidad

   Private cantOrigen As Decimal
   Private cantFinal As Decimal

   Private _publicos As Publicos
#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(_drs As DataRow)
      Me.New()
      dr = _drs
      sucOrigen = Integer.Parse(dr("IdSucursal").ToString())
      depOrigen = Integer.Parse(dr("IdDepositoDefecto").ToString())
      ubiOrigen = Integer.Parse(dr("IdUbicacionDefecto").ToString())
      IdProducto = dr("IdProducto").ToString()
      cantOrigen = Decimal.Parse(dr("CantEntregada").ToString())
   End Sub
#End Region

#Region "Overrides/Overloads"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._publicos = New Publicos()
         LimpiaCamposCargaI()

         '-- Nombre Sucursal.-
         CargaDescripcionsucursal(sucOrigen)
         '-- Carga Combos de Depositos-Ubicaciones.-
         _cargaComboDestino = True
         _publicos.CargaComboDepositos(cmbDepositos, sucOrigen, miraUsuario:=True, PermiteEscritura:=True, disponibleventa:=True)
         _publicos.CargaComboDepositos(cmbDepositosII, sucOrigen, miraUsuario:=True, PermiteEscritura:=True, disponibleventa:=True)
         _cargaComboDestino = False
         If cmbDepositos.Items.Count > 0 Then
            cmbDepositos.SelectedValue = depOrigen
            _publicos.CargaComboUbicaciones(cmbUbicacion, depOrigen, sucOrigen)
            cmbUbicacion.SelectedValue = ubiOrigen
         Else
            cmbDepositos.SelectedIndex = -1
         End If
         cmbDepositosII.SelectedIndex = -1

         txtCantidadAfectada.Text = Decimal.Parse(dr("CantEntregada").ToString()).ToString("N2")
         txtStockActual.Text = Decimal.Parse(dr("Stock").ToString()).ToString("N2")
         txtStockReserva.Text = Decimal.Parse(dr("StockActual").ToString()).ToString("N2")
         _cargaComboDestino = True
         LimpiaCamposCargaII()
         _cargaComboDestino = False


      Catch ex As Exception

      End Try
   End Sub
#End Region

#Region "Eventos"

#End Region

#Region "Metodos"
   Private Sub LimpiaCamposCargaI()
      lblSucursal.Text = String.Empty

      cmbDepositos.SelectedIndex = -1
      cmbUbicacion.SelectedIndex = -1

      txtCantidadAfectada.Text = "0." + New String("0"c, Me._decimalesEnCantidad)
      txtCantidadAfectada.Formato = "N" + _decimalesEnCantidad.ToString()
      txtStockActual.Text = "0." + New String("0"c, Me._decimalesEnCantidad)
      txtStockActual.Formato = "N" + _decimalesEnCantidad.ToString()
      txtStockReserva.Text = "0." + New String("0"c, Me._decimalesEnCantidad)
      txtStockReserva.Formato = "N" + _decimalesEnCantidad.ToString()

   End Sub
   Private Sub LimpiaCamposCargaII()
      lblSucursalII.Text = String.Empty
      _cargaComboDestino = True
      cmbDepositosII.SelectedIndex = -1
      cmbUbicacionII.SelectedIndex = -1
      _cargaComboDestino = False

      txtCantidadAfectadaII.Text = "0." + New String("0"c, Me._decimalesEnCantidad)
      txtCantidadAfectadaII.Formato = "N" + _decimalesEnCantidad.ToString()
      txtStockActualII.Text = "0." + New String("0"c, Me._decimalesEnCantidad)
      txtStockActualII.Formato = "N" + _decimalesEnCantidad.ToString()
      txtStockReservaII.Text = "0." + New String("0"c, Me._decimalesEnCantidad)
      txtStockReservaII.Formato = "N" + _decimalesEnCantidad.ToString()

      gpbAgregarUbicacion.Enabled = False

   End Sub


   Private Sub CargaDescripcionsucursal(nSuc As Integer)
      Dim eSuc = New Reglas.Sucursales().GetUna(nSuc, False)
      lblSucursal.Text = eSuc.Nombre
   End Sub

   Private Sub cmbDepositos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositos.SelectedIndexChanged
      TryCatched(
      Sub()
         If Not _cargaComboDestino Then
            Dim dr = cmbDepositos.ItemSeleccionado(Of DataRow)()
            If dr IsNot Nothing Then
               depOrigen = dr.Field(Of Integer)("IdDeposito")
               sucOrigen = dr.Field(Of Integer)("IdSucursal")
               _publicos.CargaComboUbicaciones(cmbUbicacion, depOrigen, sucOrigen)
               cmbUbicacion.SelectedIndex = 0
            End If
         End If
      End Sub)
   End Sub

   Private Sub cmbDepositosII_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositosII.SelectedIndexChanged
      TryCatched(
      Sub()
         If Not _cargaComboDestino Then
            Dim dr = cmbDepositosII.ItemSeleccionado(Of DataRow)()
            If dr IsNot Nothing Then
               depOrigenII = dr.Field(Of Integer)("IdDeposito")
               _publicos.CargaComboUbicaciones(cmbUbicacionII, depOrigenII, sucOrigen)
               cmbUbicacion.SelectedIndex = 0
            End If
         End If
      End Sub)
   End Sub

   Private Sub chbAgregaUbicacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbAgregaUbicacion.CheckedChanged
      LimpiaCamposCargaII()
      If chbAgregaUbicacion.Checked Then
         '-- Sucursal.-
         lblSucursalII.Text = lblSucursal.Text
         txtCantidadAfectadaII.Text = "0.00"
         gpbAgregarUbicacion.Enabled = True
      End If
   End Sub

   Private Sub cmbUbicacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUbicacion.SelectedIndexChanged
      ubiOrigen = Integer.Parse(cmbUbicacion.SelectedValue.ToString())
      Dim dt = New Reglas.ProductosUbicaciones().GetSucursalDepositoProducto(sucOrigen, depOrigen, ubiOrigen, IdProducto)
      If dt.Count <> 0 Then
         txtStockActual.Text = dt.Rows(0).Field(Of Decimal)("Stock").ToString(String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad))
      End If
   End Sub
   Private Sub cmbUbicacionII_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUbicacionII.SelectedIndexChanged
      If Not _cargaComboDestino Then
         ubiOrigenII = Integer.Parse(cmbUbicacionII.SelectedValue.ToString())
         Dim dt = New Reglas.ProductosUbicaciones().GetSucursalDepositoProducto(sucOrigen, depOrigenII, ubiOrigenII, IdProducto)
         If dt.Count <> 0 Then
            txtStockActualII.Text = dt.Rows(0).Field(Of Decimal)("Stock").ToString(String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad))
         End If
      End If
   End Sub

   Private Function ValidaCantidadTotal() As Boolean
      cantFinal = (Decimal.Parse(txtCantidadAfectada.Text()) + Decimal.Parse(txtCantidadAfectadaII.Text()))
      Return cantFinal <> cantOrigen
   End Function

   Private Sub CalculaCantidadAfectada()
      TryCatched(
         Sub()
            txtStockReserva.Text = (Decimal.Parse(txtStockActual.Text()) - Decimal.Parse(txtCantidadAfectada.Text())).ToString()
         End Sub)
   End Sub

   Private Sub CalculaCantidadAfectadaII()
      TryCatched(
         Sub()
            txtStockReservaII.Text = (Decimal.Parse(txtStockActualII.Text()) - Decimal.Parse(txtCantidadAfectadaII.Text())).ToString()
         End Sub)
   End Sub

   Private Sub txtCantidadAfectada_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidadAfectada.KeyDown
      TryCatched(
         Sub()
            If e.KeyCode = Keys.Enter And Not String.IsNullOrEmpty(txtCantidadAfectada.Text) Then
               CalculaCantidadAfectada()
               btnAceptar.Select()
            End If
         End Sub)

   End Sub
   Private Sub txtCantidadAfectadaII_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidadAfectadaII.KeyDown
      TryCatched(
         Sub()
            If e.KeyCode = Keys.Enter Then
               CalculaCantidadAfectadaII()
               btnAceptar.Select()
            End If
         End Sub)

   End Sub
   Private Sub txtStockActual_TextChanged(sender As Object, e As EventArgs) Handles txtStockActual.TextChanged
      CalculaCantidadAfectada()
   End Sub

   Private Sub txtStockActualII_TextChanged(sender As Object, e As EventArgs) Handles txtStockActualII.TextChanged
      CalculaCantidadAfectadaII()
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      If Not ValidaCantidadTotal() Then
         dr("IdDepositoDefecto") = Integer.Parse(cmbDepositos.SelectedValue.ToString())
         dr("NombreDeposito") = cmbDepositos.Text
         dr("IdUbicacionDefecto") = cmbUbicacion.ValorSeleccionado(Of Integer)
         dr("NombreUbicacion") = cmbUbicacion.Text
         dr("CantEntregada") = txtCantidadAfectada.ValorNumericoPorDefecto(0D)
         dr("Stock") = txtStockActual.ValorNumericoPorDefecto(0D)

         If chbAgregaUbicacion.Checked Then
            If dr IsNot Nothing Then
               dr.CopyAdd(Sub(NewRow)
                             NewRow("Stock") = txtStockActualII.ValorNumericoPorDefecto(0D)
                             NewRow("CantEntregada") = txtCantidadAfectadaII.ValorNumericoPorDefecto(0D)
                             NewRow("IdDepositoDefecto") = cmbDepositosII.ValorSeleccionado(Of Integer)
                             NewRow("NombreDeposito") = cmbDepositosII.Text.ToString()
                             NewRow("IdUbicacionDefecto") = cmbUbicacionII.ValorSeleccionado(Of Integer)
                             NewRow("NombreUbicacion") = cmbUbicacionII.Text.ToString()
                          End Sub)
            End If
         End If
         Me.Close()
      Else
         MessageBox.Show(String.Format("La Cantidad Ingresada ({0}) no coincide con la Cantidad Original({1})", cantFinal, cantOrigen), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         txtCantidadAfectada.Select()
      End If
   End Sub

#End Region

End Class