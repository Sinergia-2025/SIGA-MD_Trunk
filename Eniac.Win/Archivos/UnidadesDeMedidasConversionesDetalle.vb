Public Class UnidadesDeMedidasConversionesDetalle

   Private _publicos As Publicos
   Private _cargandoPantalla As Boolean

   Public ReadOnly Property Conversion As Entidades.UnidadDeMedidaConversion
      Get
         Return DirectCast(_entidad, Entidades.UnidadDeMedidaConversion)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.UnidadDeMedidaConversion)
      InitializeComponent()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _cargandoPantalla = True

         _publicos = New Publicos()

         BindearControles(_entidad)


         If StateForm = Win.StateForm.Insertar Then

            bscCodigoUMDesde.Focus()
         Else

            bscCodigoUMDesde.Text = Conversion.IdUnidadMedidaDesde
            bscCodigoUMDesde.PresionarBoton()

            bscCodigoUMHacia.Text = Conversion.IdUnidadMedidaHacia
            bscCodigoUMHacia.PresionarBoton()

            bscCodigoUMDesde.Permitido = False
            bscUMDesde.Permitido = False
            bscCodigoUMHacia.Permitido = False
            bscUMHacia.Permitido = False

            MostrarAyuda()

            txtFactorConversion.Focus()
         End If

         _cargandoPantalla = False
      End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.UnidadesDeMedidasConversiones()
   End Function

   Protected Overrides Sub Aceptar()

      Conversion.IdUnidadMedidaDesde = bscCodigoUMDesde.Text
      Conversion.IdUnidadMedidaHacia = bscCodigoUMHacia.Text

      MyBase.Aceptar()
   End Sub

   Protected Overrides Function ValidarDetalle() As String

      If Not bscCodigoUMDesde.Selecciono Then
         bscCodigoUMDesde.Focus()
         Return "Debe seleccionar una Unidad de Medida Desde"
      End If
      If Not bscCodigoUMHacia.Selecciono Then
         bscCodigoUMHacia.Focus()
         Return "Debe seleccionar una Unidad de Medida Hacia"
      End If

      If Decimal.Parse(txtFactorConversion.Text.ToString()) = 0 Then
         txtFactorConversion.Focus()
         Return "Completar factor de Conversión, no puede ser 0."
      End If

      Return MyBase.ValidarDetalle()
   End Function

#End Region

#Region "Eventos"
#Region "Eventos Busqueda Unidad de Medida Desde"
   Private Sub bscCodigoUMDesde_BuscadorClick() Handles bscCodigoUMDesde.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaUnidadesDeMedida(bscCodigoUMDesde)
         If _cargandoPantalla Then
            bscCodigoUMDesde.Datos = New Reglas.UnidadesDeMedidas().Get1(bscCodigoUMDesde.Text)
         Else
            bscCodigoUMDesde.Datos = New Reglas.UnidadesDeMedidas().GetBuscaPorCodigo(bscCodigoUMDesde.Text)
         End If
      End Sub)
   End Sub
   Private Sub bscUMDesde_BuscadorClick() Handles bscUMDesde.BuscadorClick
      TryCatched(
      Sub()
         'aca busca en la tabla de Clientes
         _publicos.PreparaGrillaUnidadesDeMedida(bscUMDesde)
         bscUMDesde.Datos = New Reglas.UnidadesDeMedidas().GetBuscaPorNombre(bscUMDesde.Text)
      End Sub)
   End Sub
   Private Sub bscCodigoUMDesde_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoUMDesde.BuscadorSeleccion, bscUMDesde.BuscadorSeleccion
      TryCatched(Sub() CargarDatosUnidadMedida(e.FilaDevuelta, bscCodigoUMDesde, bscUMDesde, bscCodigoUMHacia))
   End Sub
#End Region
#Region "Eventos Busqueda Unidad de Medida Hacia"
   Private Sub bscCodigoUMHacia_BuscadorClick() Handles bscCodigoUMHacia.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaUnidadesDeMedida(bscCodigoUMHacia)
         If _cargandoPantalla Then
            bscCodigoUMHacia.Datos = New Reglas.UnidadesDeMedidas().Get1(bscCodigoUMHacia.Text)
         Else
            bscCodigoUMHacia.Datos = New Reglas.UnidadesDeMedidas().GetBuscaPorCodigo(bscCodigoUMHacia.Text)
         End If
      End Sub)
   End Sub
   Private Sub bscUMHacia_BuscadorClick() Handles bscUMHacia.BuscadorClick
      TryCatched(
      Sub()
         'aca busca en la tabla de Clientes
         _publicos.PreparaGrillaUnidadesDeMedida(bscUMHacia)
         bscUMHacia.Datos = New Reglas.UnidadesDeMedidas().GetBuscaPorNombre(bscUMHacia.Text)
      End Sub)
   End Sub
   Private Sub bscCodigoUMHacia_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoUMHacia.BuscadorSeleccion, bscUMHacia.BuscadorSeleccion
      TryCatched(Sub() CargarDatosUnidadMedida(e.FilaDevuelta, bscCodigoUMHacia, bscUMHacia, txtFactorConversion))
   End Sub
   Private Sub txtFactorConversion_TextChanged(sender As Object, e As EventArgs) Handles txtFactorConversion.TextChanged
      TryCatched(Sub() MostrarAyuda())
   End Sub
#End Region

#End Region

#Region "Métodos"
   Private Sub CargarDatosUnidadMedida(dr As DataGridViewRow, bscCodigoUM As Controles.Buscador2, bscUM As Controles.Buscador2, nextControl As Control)
      If dr IsNot Nothing Then
         bscCodigoUM.Text = dr.Cells("IdUnidadDeMedida").Value.ToString()
         bscUM.Text = dr.Cells("NombreUnidadDeMedida").Value.ToString()
         bscCodigoUM.Selecciono = True
         bscUM.Selecciono = True
         MostrarAyuda()
         nextControl.Focus()
      End If
   End Sub

   Private Sub MostrarAyuda()
      lblAyudaFactorConversion.Text = String.Format("1 {0} = {1} {2}", bscUMDesde.Text, txtFactorConversion.Text, bscUMHacia.Text)
   End Sub

#End Region

End Class
