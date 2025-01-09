Public Class CRMNovedadCambioEstado
   Inherits CRMEntidad

   Public Const NombreTabla As String = "CRMNovedadesCambiosEstados"

   Public Enum Columnas
      IdTipoNovedad
      Letra
      CentroEmisor
      IdNovedad
      IdCambioEstado
      FechaCambioEstado
      IdEstadoNovedad
      IdUsuario
      IdUsuarioAsignado
      IdSucursalNovedad

   End Enum


   Public Sub New()
   End Sub
   Public Sub New(novedad As CRMNovedad)
      Me.New()
      TipoNovedad = novedad.TipoNovedad
      Letra = novedad.Letra
      CentroEmisor = novedad.CentroEmisor
      IdNovedad = novedad.IdNovedad

   End Sub

   'Public Property IdTipoNovedad As String
   Public Property Letra As String
   Public Property CentroEmisor As Short
   Public Property IdNovedad As Long
   Public Property IdCambioEstado As Integer
   Public Property FechaCambioEstado As Date
   Public Property EstadoNovedad As CRMEstadoNovedad
   Public Property IdUsuario As String
   Public Property IdUsuarioAsignado As String
   Public Property IdSucursalNovedad As Integer?

   Public Property NombreSucursalNovedad As String    'Para mostrar en grillas

#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdEstadoNovedad As Integer
      Get
         Return If(EstadoNovedad IsNot Nothing, EstadoNovedad.IdEstadoNovedad, 0)
      End Get
   End Property
   Public ReadOnly Property NombreEstadoNovedad As String
      Get
         Return If(EstadoNovedad IsNot Nothing, EstadoNovedad.NombreEstadoNovedad, String.Empty)
      End Get
   End Property

#End Region

End Class