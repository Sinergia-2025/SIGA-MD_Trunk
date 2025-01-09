Public Class ListaDePreciosDetalle

#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.ListaDePrecios)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As System.EventArgs)
      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me._publicos.CargaComboListaDePrecios(cmbListaPrecios)
      _publicos.CargaComboFormasDePago(cmbFormaDePago, "TODAS")
      cmbFormaDePago.SelectedIndex = -1

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoNumero()
         _entidad.Usuario = actual.Nombre
         Me.dtpVigencia.Value = Date.Today
         Me.chbActiva.Checked = True
         chbFormaDePago.Checked = False
      Else
         'controlo que la lista de precios no este puesta por defecto en los parametros
         Dim esPredeterminada = Publicos.ListaPreciosPredeterminada = Me.txtNumero.ValorNumericoPorDefecto(-1I)
         Me.chbActiva.Enabled = Not esPredeterminada
         If esPredeterminada Then
            Me.Text += " - PREDETERMINADA"
         End If
         chbFormaDePago.Checked = DirectCast(_entidad, Entidades.ListaDePrecios).FormaPago IsNot Nothing
         If chbFormaDePago.Checked Then
            cmbFormaDePago.SelectedValue = DirectCast(_entidad, Entidades.ListaDePrecios).FormaPago.IdFormasPago
         End If
      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         DirectCast(_entidad, Entidades.ListaDePrecios).IdListaPreciosCopiar = cmbListaPrecios.ValorSeleccionado(Of Integer)
      End If
      Return New Reglas.ListasDePrecios()
   End Function

   Protected Overrides Sub Aceptar()
      If Not chbFormaDePago.Checked Then
         DirectCast(_entidad, Entidades.ListaDePrecios).FormaPago = Nothing
      Else
         DirectCast(_entidad, Entidades.ListaDePrecios).FormaPago = cmbFormaDePago.ItemSeleccionado(Of Entidades.VentaFormaPago)
      End If

      MyBase.Aceptar()

      If Not Me.HayError Then Me.Close()

      Me.txtNombre.Focus()

   End Sub

   Protected Overrides Function ValidarDetalle() As String
      If txtOrden.ValorNumericoPorDefecto(0D) <= 0 Then
         txtOrden.Focus()
         Return "El Orden no puede ser igual o menor a cero"
      End If
      Return MyBase.ValidarDetalle()
   End Function
#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoNumero()
      End If
      Me.txtNumero.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Me.txtNumero.Text = (New Reglas.ListasDePrecios().GetCodigoMaximo() + 1).ToString()
   End Sub

#End Region

   Private Sub lblFormaDePago_Click(sender As Object, e As EventArgs) Handles lblFormaDePago.Click
      chbFormaDePago.Checked = Not chbFormaDePago.Checked
   End Sub

   Private Sub chbFormaDePago_CheckedChanged(sender As Object, e As EventArgs) Handles chbFormaDePago.CheckedChanged
      Try
         If chbFormaDePago.Checked Then
            cmbFormaDePago.Enabled = True
         Else
            cmbFormaDePago.Enabled = False
            cmbFormaDePago.SelectedIndex = -1
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbActiva_CheckedChanged(sender As Object, e As EventArgs) Handles chbActiva.CheckedChanged
      If chbActiva.Checked = False Then
         Dim olistadeprecios As Reglas.ListasDePrecios = New Reglas.ListasDePrecios()
         Dim dt As DataTable = olistadeprecios.GetPedidosPorListaDePrecios(Integer.Parse(txtNumero.Text.ToString()))
         If dt.Count > 0 Then
            MessageBox.Show("No es posible inhabilitar la lista de precios porque hay Pedido/Presupuesto/s pendientes o en proceso.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            chbActiva.Checked = True
         End If
      End If
   End Sub
End Class