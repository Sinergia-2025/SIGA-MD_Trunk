Option Strict Off
Imports Infragistics.Win.UltraWinGrid
Public Class ProductosModelosDetalle

#Region "Campos"

   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
#End Region

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.ProductoModelo)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me._publicos = New Publicos()
      Me._publicos.CargaComboTiposModelos(Me.cmbTipoModelo)
      Me.cmbTipoModelo.SelectedIndex = 0
      Me._publicos.CargaComboSubTiposModelos(Me.cmbSubTipoModelo, Integer.Parse(Me.cmbTipoModelo.SelectedValue.ToString()))
      Me.cmbSubTipoModelo.SelectedIndex = 0

      _estaCargando = False

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoNumero()

         DirectCast(Me._entidad, Entidades.ProductoModelo).Usuario = actual.Nombre
         Me.txtNombreProductoModelo.Focus()
      Else
         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()

         If Not String.IsNullOrEmpty(DirectCast(Me._entidad, Entidades.ProductoModelo).IdProductoModeloTipo) Then
            Me.cmbTipoModelo.SelectedValue = DirectCast(Me._entidad, Entidades.ProductoModelo).IdProductoModeloTipo
         End If

         If Not String.IsNullOrEmpty(DirectCast(Me._entidad, Entidades.ProductoModelo).IdProductoModeloSubTipo) Then
            Me.cmbSubTipoModelo.SelectedValue = DirectCast(Me._entidad, Entidades.ProductoModelo).IdProductoModeloSubTipo
         End If

         'Me.txtNombreProductoModelo.ReadOnly = Not oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProductosModelosABM_ModModelo")
      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ProductosModelos()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()
      If cmbTipoModelo.SelectedIndex <> -1 Then
         DirectCast(Me._entidad, Entidades.ProductoModelo).IdProductoModeloTipo = Integer.Parse(cmbTipoModelo.SelectedValue.ToString())
      End If

      If cmbSubTipoModelo.SelectedIndex <> -1 Then
         DirectCast(Me._entidad, Entidades.ProductoModelo).IdProductoModeloSubTipo = Integer.Parse(cmbSubTipoModelo.SelectedValue.ToString())
      End If

      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"

   Private Sub CargarProximoNumero()
      Me.txtIdProductoModelo.Text = New Reglas.ProductosModelos().GetCodigoMaximo().ToString()
   End Sub

   Private Sub cmbTipoModelo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoModelo.SelectedIndexChanged
      Try
         If Not _estaCargando Then

            Me._publicos.CargaComboSubTiposModelos(Me.cmbSubTipoModelo, Integer.Parse(Me.cmbTipoModelo.SelectedValue.ToString()))
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

End Class