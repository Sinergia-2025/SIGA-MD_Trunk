Public Class ObservacionesDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.Observacion)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      'Me.cboTipo.Items.Insert(0, "VENTA")
      'Me.cboTipo.Items.Insert(1, "COMPRA")

      Dim dicTipos As List(Of KeyValuePair(Of Object, String)) = New List(Of KeyValuePair(Of Object, String))()
      dicTipos.Add(New KeyValuePair(Of Object, String)("VENTA", Entidades.Observacion.GetNombreTipo("VENTA")))
      dicTipos.Add(New KeyValuePair(Of Object, String)("COMPRA", Entidades.Observacion.GetNombreTipo("COMPRA")))
      dicTipos.Add(New KeyValuePair(Of Object, String)("NOTA", Entidades.Observacion.GetNombreTipo("NOTA")))
      dicTipos.Add(New KeyValuePair(Of Object, String)("BONIF", Entidades.Observacion.GetNombreTipo("BONIF")))
      dicTipos.Add(New KeyValuePair(Of Object, String)("CAMBIO", Entidades.Observacion.GetNombreTipo("CAMBIO")))
      cboTipo.DataSource = dicTipos
      cboTipo.DisplayMember = "Value"
      cboTipo.ValueMember = "Key"

      Me.BindearControles(Me._entidad)

      'Me.cboTipo.SelectedIndex = 0

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoNumero()
         'DirectCast(Me._entidad, Entidades.Observacion).Tipo = Me.cboTipo.SelectedValue
      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Observaciones
   End Function

   'Protected Overrides Function ValidarDetalle() As String

   '   Dim vacio As String = ""

   '   If Math.Abs(Decimal.Parse(Me.txtDescuentoRecargo.Text)) >= 100 Then
   '      Return "El Descuento/Recargo NO es Válido."
   '   End If

   '   Return vacio

   'End Function

   'Protected Overrides Sub LimpiarControles()
   '   MyBase.LimpiarControles()
   '   Me.txtDescuentoRecargo.Text = "0.00"
   'End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtIdObservacion.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Dim oObs As Reglas.Observaciones = New Reglas.Observaciones()
      Me.txtIdObservacion.Text = (oObs.GetCodigoMaximo() + 1).ToString()
   End Sub

#End Region

End Class