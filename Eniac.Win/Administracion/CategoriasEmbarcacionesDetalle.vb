Public Class CategoriasEmbarcacionesDetalle
#Region "Campos"
   Private _publicos As Publicos
   'PE-31303
   Private _publicosEniac As Eniac.Win.Publicos
#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.CategoriaEmbarcacion)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      Me._tituloNuevo = "Nueva"


      MyBase.OnLoad(e)

      Me._publicos = New Publicos()
      Me._publicosEniac = New Eniac.Win.Publicos()

      Me._publicos.CargaComboTipoEmbarcacion(Me.cmbTiposEmbarcacion)

      'PE-31303
      _publicosEniac.CargaComboIntereses(cmbIntereses)
      cmbIntereses.SelectedIndex = -1

      Me._liSources.Add("Interes", DirectCast(Me._entidad, Entidades.CategoriaEmbarcacion).Interes)

      Me.BindearControles(Me._entidad, Me._liSources)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoCodigo()
         If Me.cmbTiposEmbarcacion.Items.Count = 1 Then
            Me.cmbTiposEmbarcacion.SelectedIndex = 0
         End If
         'PE-31303
         'If DirectCast(Me._entidad, Entidades.CategoriaEmbarcacion).IdInteres <> 0 Then
         '   Me.cmbIntereses.SelectedValue = DirectCast(Me._entidad, Entidades.CategoriaEmbarcacion).IdInteres
         '   Me.chbIntereses.Checked = True
         'Else
         '   Me.chbIntereses.Checked = False
         'End If
      Else
         'PE-31303
         If DirectCast(Me._entidad, Entidades.CategoriaEmbarcacion).IdInteres <> 0 Then
            Me.cmbIntereses.SelectedValue = DirectCast(Me._entidad, Entidades.CategoriaEmbarcacion).IdInteres
            Me.chbIntereses.Checked = True
         Else
            Me.chbIntereses.Checked = False
         End If
      End If

      'cmbIntereses.SelectedValue = DirectCast(Me._entidad, Entidades.CategoriaEmbarcacion).IdInteres
      'chbIntereses.Checked = DirectCast(Me._entidad, Entidades.CategoriaEmbarcacion).Interes IsNot Nothing

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CategoriasEmbarcaciones()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      If Me.cmbTiposEmbarcacion.SelectedIndex = -1 Then
         Return "Debe Elegir una Tipo de Embarcación."
      End If
      If Decimal.Parse(Me.txtPorcDescAlquiler.Text) < 0 Or Decimal.Parse(Me.txtPorcDescAlquiler.Text) > 100 Then
         Return "El Porcentaje de Descuento del Alquiler debe ser entre 0 y 100."
      End If
      'PE-31303
      If Me.chbIntereses.Checked And Me.cmbIntereses.SelectedIndex = -1 Then
         Me.cmbIntereses.Focus()
         Return "ATENCION: Activo el Interés por Defecto. Debe elegir uno."
      End If
      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub LimpiarControles()
      MyBase.LimpiarControles()
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtIdCategoriaEmbarcacion.Focus()
   End Sub

   'PE-31303
   Private Sub chbIntereses_CheckedChanged(sender As Object, e As EventArgs) Handles chbIntereses.CheckedChanged
      If Not Me.chbIntereses.Checked Then
         Me.cmbIntereses.SelectedIndex = -1
         DirectCast(Me._entidad, Entidades.CategoriaEmbarcacion).Interes = Nothing
      End If

      Me.cmbIntereses.Enabled = Me.chbIntereses.Checked
   End Sub


#End Region

#Region "Metodos"

   Private Sub CargarProximoCodigo()
      Dim oRegCategoriasEmbarcacion As Reglas.CategoriasEmbarcaciones = New Reglas.CategoriasEmbarcaciones()
      Dim ProximaCategoria As Integer
      ProximaCategoria = oRegCategoriasEmbarcacion.GetCodigoMaximo() + 1
      Me.txtIdCategoriaEmbarcacion.Text = ProximaCategoria.ToString()
   End Sub
#End Region

End Class
