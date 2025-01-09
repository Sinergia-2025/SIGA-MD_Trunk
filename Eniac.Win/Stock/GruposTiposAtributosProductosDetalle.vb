Option Strict On
Option Explicit On
#Region "Option"
Imports Eniac.Controles
#End Region
Public Class GruposTiposAtributosProductosDetalle

#Region "Campos"
   Private _Publicos As Publicos
   Private _onLoad As Boolean = False
#End Region

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.GrupoTipoAtributoProducto)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub
#End Region

#Region "Propiedades"
   Protected ReadOnly Property GrupoTipoAtributo() As Entidades.GrupoTipoAtributoProducto
      Get
         Return DirectCast(_entidad, Entidades.GrupoTipoAtributoProducto)
      End Get
   End Property
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      Try
         _onLoad = True
         MyBase.OnLoad(e)
         _Publicos = New Publicos()

         If Me.StateForm = Eniac.Win.StateForm.Actualizar Then
            bscCodigoTipoAtributo.Text = DirectCast(_entidad, Entidades.GrupoTipoAtributoProducto).IdTipoAtributoProducto.ToString()
            bscCodigoTipoAtributo.PresionarBoton()
            txtIdGrupo.Text = DirectCast(_entidad, Entidades.GrupoTipoAtributoProducto).IdGrupoTipoAtributoProducto.ToString()
            txtDescripcion.Text = DirectCast(_entidad, Entidades.GrupoTipoAtributoProducto).Descripcion.ToString()
         Else
            bscCodigoTipoAtributo.Text = String.Empty
            bscDescripcionTipoAtributo.Text = String.Empty
            txtIdGrupo.Text = String.Empty
            txtDescripcion.Text = String.Empty
         End If
         '-- Deshabilita Campos.- ---------------
         bscCodigoTipoAtributo.Enabled = (Me.StateForm = Eniac.Win.StateForm.Insertar)
         bscDescripcionTipoAtributo.Enabled = (Me.StateForm = Eniac.Win.StateForm.Insertar)
      Finally
         _onLoad = False
      End Try
   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.GruposTiposAtributosProductos()
   End Function
#End Region

   Private Sub bscCodigoTipoAtributo_Buscadorclick() Handles bscCodigoTipoAtributo.BuscadorClick
      TryCatched(
         Sub()
            _Publicos.PreparaGrillaTipoAtributoProducto2(bscCodigoTipoAtributo)
            bscCodigoTipoAtributo.Datos = New Reglas.TiposAtributosProductos().GetFiltradoPorCodigo(bscCodigoTipoAtributo.Text.ValorNumericoPorDefecto(0S))
         End Sub)
   End Sub
   Private Sub bscCodigoTipoAtributo_BuscadorSeleccion(sender As Object, e As BuscadorEventArgs) Handles bscCodigoTipoAtributo.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosTipoAtributo(e.FilaDevuelta)
            End If
         End Sub)
   End Sub

   Private Sub bscDescripcionTipoAtributo_Buscadorclick() Handles bscDescripcionTipoAtributo.BuscadorClick
      TryCatched(
         Sub()
            _Publicos.PreparaGrillaTipoAtributoProducto2(bscDescripcionTipoAtributo)
            bscDescripcionTipoAtributo.Datos = New Reglas.TiposAtributosProductos().GetFiltradoPorDescripcion(bscDescripcionTipoAtributo.Text)
         End Sub)
   End Sub
   Private Sub bscDescripcionTipoAtributo_BuscadorSeleccion(sender As Object, e As BuscadorEventArgs) Handles bscDescripcionTipoAtributo.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosTipoAtributo(e.FilaDevuelta)
            End If
         End Sub)
   End Sub

   Private Sub CargarDatosTipoAtributo(dr As DataGridViewRow)
      bscCodigoTipoAtributo.Text = dr.Cells("IdTipoAtributoProducto").Value.ToString()
      bscDescripcionTipoAtributo.Text = dr.Cells("Descripcion").Value.ToString()
      txtIdGrupo.Text = (DirectCast(GetReglas(), Reglas.GruposTiposAtributosProductos).GetCodigoMaximo(Short.Parse(dr.Cells("IdTipoAtributoProducto").Value.ToString())) + 1).ToString()
      txtDescripcion.Focus()
   End Sub

   Protected Overrides Sub Aceptar()
      If ValidarDetalle() Then
         With GrupoTipoAtributo
            .IdGrupoTipoAtributoProducto = Integer.Parse(txtIdGrupo.Text)
            .IdTipoAtributoProducto = Short.Parse(bscCodigoTipoAtributo.Text)
            .Descripcion = txtDescripcion.Text
         End With
         MyBase.Aceptar()
      End If
   End Sub
   Private Function ValidarDetalle() As Boolean
      If bscCodigoTipoAtributo.Selecciono And bscDescripcionTipoAtributo.Selecciono Then
         ShowMessage("ATENCIÓN: Debe seleccionar un Tipo de Atributo de Producto.")
         bscCodigoTipoAtributo.Focus()
         Return False
      End If
      If String.IsNullOrEmpty(txtDescripcion.Text) Then
         ShowMessage("ATENCIÓN: Debe establecer una Descripcion para el Grupo.")
         txtDescripcion.Focus()
         Return False
      End If
      Return True
   End Function
End Class