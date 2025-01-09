Option Strict On
Option Explicit On
#Region "Option"
Imports Eniac.Controles
#End Region
Public Class AtributosProductosDetalle

#Region "Campos"
   Private _Publicos As Publicos
   Private _onLoad As Boolean = False
#End Region

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.AtributoProducto)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub
#End Region

#Region "Propiedades"
   Protected ReadOnly Property AtributoProducto() As Entidades.AtributoProducto
      Get
         Return DirectCast(_entidad, Entidades.AtributoProducto)
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
            bscCodigoTipoAtributo.Text = DirectCast(_entidad, Entidades.AtributoProducto).IdTipoAtributoProducto.ToString()
            bscCodigoTipoAtributo.PresionarBoton()
            bscCodigoGrupoTipoAtributo.Text = DirectCast(_entidad, Entidades.AtributoProducto).IdGrupoTipoAtributoProducto.ToString()
            bscCodigoGrupoTipoAtributo.PresionarBoton()
            txtIdAtributo.Text = DirectCast(_entidad, Entidades.AtributoProducto).IdAtributoProducto.ToString()
            txtDescripcion.Text = DirectCast(_entidad, Entidades.AtributoProducto).Descripcion.ToString()
            txtOrden.Text = DirectCast(_entidad, Entidades.AtributoProducto).Orden.ToString()
         Else
            bscCodigoGrupoTipoAtributo.Text = String.Empty
            bscDescripcionGrupoTipoAtributo.Text = String.Empty
            LimpiaCamposAtributo()
         End If
         '-- Deshabilita Campos.- ---------------
         bscCodigoTipoAtributo.Enabled = (Me.StateForm = Eniac.Win.StateForm.Insertar)
         bscDescripcionTipoAtributo.Enabled = (Me.StateForm = Eniac.Win.StateForm.Insertar)
         bscCodigoGrupoTipoAtributo.Enabled = (Me.StateForm = Eniac.Win.StateForm.Insertar)
         bscDescripcionGrupoTipoAtributo.Enabled = (Me.StateForm = Eniac.Win.StateForm.Insertar)
      Finally
         _onLoad = False
      End Try
   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.AtributosProductos()
   End Function
#End Region

#Region "Metodos"
   Private Sub bscCodigoTipoAtributo_Buscadorclick() Handles bscCodigoTipoAtributo.BuscadorClick
      TryCatched(
         Sub()
            _Publicos.PreparaGrillaTipoAtributoProducto2(bscCodigoTipoAtributo)
            bscCodigoTipoAtributo.Datos = New Reglas.TiposAtributosProductos().GetFiltradoPorCodigo(bscCodigoTipoAtributo.Text.ValorNumericoPorDefecto(0S))
         End Sub)
   End Sub
   Private Sub bscCodigoTipoAtributo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoTipoAtributo.BuscadorSeleccion
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
   Private Sub bscDescripcionTipoAtributo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscDescripcionTipoAtributo.BuscadorSeleccion
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
      '-- Limpia los datos anteriores.- --
      bscCodigoGrupoTipoAtributo.Text = String.Empty
      bscDescripcionGrupoTipoAtributo.Text = String.Empty
      '-- Limpia los datos anteriores.- --
      LimpiaCamposAtributo()
      bscCodigoGrupoTipoAtributo.Focus()
   End Sub

   Private Sub bscCodigoGrupoTipoAtributo_BuscadorClick() Handles bscCodigoGrupoTipoAtributo.BuscadorClick
      TryCatched(
         Sub()
            _Publicos.PreparaGrillaGrupoTipoAtributoProducto2(bscCodigoGrupoTipoAtributo)
            bscCodigoGrupoTipoAtributo.Datos = New Reglas.GruposTiposAtributosProductos().GetFiltradoPorCodigo(bscCodigoGrupoTipoAtributo.Text.ValorNumericoPorDefecto(0S),
                                                                                                               bscCodigoTipoAtributo.Text.ValorNumericoPorDefecto(0S))
         End Sub)
   End Sub
   Private Sub bscCodigoGrupoTipoAtributo_BuscadorSeleccion(sender As Object, e As BuscadorEventArgs) Handles bscCodigoGrupoTipoAtributo.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosGrupoTipoAtributo(e.FilaDevuelta)
            End If
         End Sub)
   End Sub
   Private Sub bscDescripcionGrupoTipoAtributo_BuscadorClick() Handles bscDescripcionGrupoTipoAtributo.BuscadorClick
      TryCatched(
         Sub()
            _Publicos.PreparaGrillaTipoAtributoProducto2(bscDescripcionGrupoTipoAtributo)
            bscDescripcionGrupoTipoAtributo.Datos = New Reglas.GruposTiposAtributosProductos().GetFiltradoPorDescripcion(bscDescripcionGrupoTipoAtributo.Text,
                                                                                                                         bscCodigoTipoAtributo.Text.ValorNumericoPorDefecto(0S))
         End Sub)
   End Sub
   Private Sub bscDescripcionGrupoTipoAtributo_BuscadorSeleccion(sender As Object, e As BuscadorEventArgs) Handles bscDescripcionGrupoTipoAtributo.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosGrupoTipoAtributo(e.FilaDevuelta)
            End If
         End Sub)
   End Sub
   Private Sub CargarDatosGrupoTipoAtributo(dr As DataGridViewRow)
      bscCodigoGrupoTipoAtributo.Text = dr.Cells("IdGrupoTipoAtributoProducto").Value.ToString()
      bscDescripcionGrupoTipoAtributo.Text = dr.Cells("Descripcion").Value.ToString()
      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         '-- Limpia los datos anteriores.- --
         LimpiaCamposAtributo()
         txtIdAtributo.Text = (DirectCast(GetReglas(), Reglas.AtributosProductos).GetCodigoMaximo(Integer.Parse(dr.Cells("IdGrupoTipoAtributoProducto").Value.ToString()),
                                                                                               Short.Parse(dr.Cells("IdTipoAtributoProducto").Value.ToString())) + 1).ToString()
         txtDescripcion.Focus()
         txtOrden.Text = (DirectCast(GetReglas(), Reglas.AtributosProductos).GetOrdenMaximo(Integer.Parse(dr.Cells("IdGrupoTipoAtributoProducto").Value.ToString()),
                                                                                            Short.Parse(dr.Cells("IdTipoAtributoProducto").Value.ToString())) + 1).ToString()
      End If
   End Sub

   Private Sub LimpiaCamposAtributo()
      '-- Limpia los datos anteriores.- --
      txtIdAtributo.Text = String.Empty
      txtDescripcion.Text = String.Empty
      txtOrden.Text = String.Empty
   End Sub
   Protected Overrides Sub Aceptar()
      If ValidarDetalle() Then
         With AtributoProducto
            .IdGrupoTipoAtributoProducto = Integer.Parse(bscCodigoGrupoTipoAtributo.Text)
            .IdTipoAtributoProducto = Short.Parse(bscCodigoTipoAtributo.Text)
            .IdAtributoProducto = Integer.Parse(txtIdAtributo.Text)
            .Descripcion = txtDescripcion.Text
            .Orden = Integer.Parse(txtOrden.Text)
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
      If bscCodigoGrupoTipoAtributo.Selecciono And bscDescripcionGrupoTipoAtributo.Selecciono Then
         ShowMessage("ATENCIÓN: Debe seleccionar un Tipo de Atributo de Producto.")
         bscCodigoTipoAtributo.Focus()
         Return False
      End If

      If String.IsNullOrEmpty(txtIdAtributo.Text) Then
         ShowMessage("ATENCIÓN: Debe establecer un Id para el Atributo.")
         txtIdAtributo.Focus()
         Return False
      End If
      If String.IsNullOrEmpty(txtDescripcion.Text) Then
         ShowMessage("ATENCIÓN: Debe establecer una Descripcion para el Atributo.")
         txtDescripcion.Focus()
         Return False
      End If
      If String.IsNullOrEmpty(txtOrden.Text) Then
         ShowMessage("ATENCIÓN: Debe establecer un numero de Orden para el Atributo.")
         txtOrden.Focus()
         Return False
      End If

      Return True
   End Function
#End Region
End Class