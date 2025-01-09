#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class ParametrosSucursalesDetalle
   Private _publicos As Publicos

   Private ReadOnly Property ParametroSucursal As Entidades.ParametroSucursal
      Get
         Return DirectCast(_entidad, Entidades.ParametroSucursal)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.ParametroSucursal)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      _publicos = New Publicos()

      Me.BindearControles(Me._entidad)

      If Not String.IsNullOrWhiteSpace(ParametroSucursal.IdParametro) Then
         bscParametro.Text = ParametroSucursal.IdParametro
         bscParametro.Enabled = True
         bscParametro.PresionarBoton()
         bscParametro.Enabled = StateForm = Win.StateForm.Insertar
      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ParametrosSucursales()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      If Not bscParametro.Selecciono Then
         bscParametro.Focus()
         Return "Debe seleccionar un parámetro."
      End If
      Return MyBase.ValidarDetalle()
   End Function

   Protected Overrides Sub Aceptar()
      ParametroSucursal.IdParametro = bscParametro.Text
      MyBase.Aceptar()
      Reglas.ParametrosCache.Instancia.LimpiarCache(bscParametro.Text)
   End Sub

#End Region

   Private Sub bscParametro_BuscadorClick() Handles bscParametro.BuscadorClick

      Try
         Me._publicos.PreparaGrillaParametros2(Me.bscParametro)
         Dim regla As Eniac.Reglas.Parametros = New Eniac.Reglas.Parametros()
         Me.bscParametro.Datos = regla.GetPorCodigo(actual.Sucursal.IdEmpresa, Me.bscParametro.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscParametro_BuscadorSeleccion(ByVal sender As System.Object, ByVal e As Eniac.Controles.BuscadorEventArgs) Handles bscParametro.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            'Me.CargarDatosCuentasBancarias(e.FilaDevuelta)
            Me.bscParametro.Text = e.FilaDevuelta.Cells(Entidades.ParametroSucursal.Columnas.IdParametro.ToString()).Value.ToString()
            If StateForm = Win.StateForm.Insertar Then
               txtValorParametro.Text = e.FilaDevuelta.Cells(Entidades.ParametroSucursal.Columnas.ValorParametro.ToString()).Value.ToString()
            End If
            txtCategoria.Text = e.FilaDevuelta.Cells("CategoriaParametro").Value.ToString()
            txtNombreParametro.Text = e.FilaDevuelta.Cells("DescripcionParametro").Value.ToString()
            Me.txtValorParametro.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub



End Class