Public Class Calendario
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "Calendarios"
   Public Enum Columnas
      IdCalendario
      NombreCalendario
      Activo
      IdSucursal
      LapsoPorDefecto
      LapsoPorDefectoFijo
      IdUsuario
      DiasDesde
      DiasHasta
      Cupo
      DiasHabilitacionReserva
      IdProducto
      UtilizaSesion
      UtilizaZonas
      IdCaja
      PublicarEnWeb
      IdNave
      IdTipoCalendario
      SolicitaEmbarcacion
      SolicitaBotado
      SolicitaVehiculo
      PermiteImpresion
   End Enum

   Public Sub New()
      Activo = True
      Horarios = New List(Of CalendarioHorario)()
      LapsoPorDefecto = 30
      DiasHabilitacionReserva = 365
   End Sub

   Public Property IdTipoCalendario As Short
   Public Property IdCalendario As Integer
   Public Property NombreCalendario As String
   Public Property Activo As Boolean
   Public Property LapsoPorDefecto As Integer
   Public Property LapsoPorDefectoFijo As Boolean

   Public Property Horarios As List(Of CalendarioHorario)
   Public Property Usuarios As DataTable

   Public Property IdUsuario As String
   Public Property DiasDesde As Integer
   Public Property DiasHasta As Integer
   Public Property Cupo As Integer
   Public Property DiasHabilitacionReserva As Integer

   Public Property IdProducto As String
   'Public Property IdCaja As Integer

   Private _CalendarioSucursal As Eniac.Entidades.CalendarioSucursal
   Public Property CalendarioSucursal As CalendarioSucursal
      Get
         If Me._CalendarioSucursal Is Nothing Then
            Me._CalendarioSucursal = New Eniac.Entidades.CalendarioSucursal()
         End If
         Return _CalendarioSucursal
      End Get
      Set(ByVal value As CalendarioSucursal)
         _CalendarioSucursal = value
      End Set
   End Property

   Public Property UtilizaSesion As Boolean
   Public Property UtilizaZonas As Boolean
   Public Property PublicarEnWeb As Boolean
   Public Property IdNave As Short?

   Public Property SolicitaEmbarcacion As Boolean
   Public Property SolicitaBotado As Boolean
   Public Property SolicitaVehiculo As Boolean
   Public Property PermiteImpresion As Boolean

End Class