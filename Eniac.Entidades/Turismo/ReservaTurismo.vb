Imports System.Drawing

Public Class ReservaTurismo
   Inherits Entidad

   Public Enum Columnas
      IdSucursal
      IdTipoReserva
      Letra
      CentroEmisor
      NumeroReserva
      Fecha
      IdEstablecimiento
      IdCurso
      Division
      IdTurno
      IdResponsable
      IdPrograma
      Mes
      QuincenaSemana
      Dia
      IdTipoVehiculo
      CapacidadMax
      LugarSalida
      CantidadAlumnos
      Costo
      BaseAlumnos
      IdFormaPago
      Liberados
      Seguimiento
      CDDigital
      IdEstadoTurismo
      BanderaColor
      NombreTipoReserva
      IdUsuarioAlta
      IdUsuarioEstadoTurismo
      FechaEstadoTurismo
      NombreEstadoTurismo
      NombreEstablecimiento
      NombreContacto
      NombrePrograma
      NombreTipoVehiculo
      NombreCurso
      NombreTurno
      IdUnicoReserva
      TipoGeneracion
      FechaViaje
      ObservacionesVendedor
      ObservacionesInternas
      ErroresSincronizacion
      IdTipoViaje

   End Enum

   Public Enum TipoGeneracionOpciones
      <Description("PASAJERO")> Pasajero
      <Description("ESTABLECIMIENTO")> Establecimiento
   End Enum

   Public Sub New()
      Pasajeros = New ListConBorrados(Of ReservaTurismoPasajero)()
      Visitas = New List(Of ReservaTurismoProducto)()
      Gastronomia = New List(Of ReservaTurismoProducto)()
      Pasajeros = New ListConBorrados(Of ReservaTurismoPasajero)()
      Facturacion = New List(Of ReservaTurismoProductoFacturacion)()
      CuentasCorrientes = New CuentaCorriente()
   End Sub

   Public Property IdTipoReserva As String
   Public Property Letra As String
   Public Property CentroEmisor As Short
   Public Property NumeroReserva As Long
   Public Property Fecha As Date
   Public Property IdEstablecimiento As Long
   Public Property IdCurso As Integer
   Public Property Division As String
   Public Property IdTurno As Integer
   Public Property IdResponsable As Integer
   Public Property IdPrograma As String
   Public Property Mes As String
   Public Property QuincenaSemana As String
   Public Property Dia As String
   Public Property IdTipoVehiculo As Integer
   Public Property CapacidadMax As Integer
   Public Property LugarSalida As String
   Public Property CantidadAlumnos As Integer
   Public Property Costo As Decimal
   Public Property BaseAlumnos As Integer
   Public Property IdFormaPago As Integer
   Public Property Liberados As String
   Public Property Seguimiento As Boolean
   Public Property CDDigital As Boolean
   Public Property IdEstadoTurismo As Integer
   Public Property BanderaColor As Color?
   Public Property NombreTipoReserva As String
   Public Property IdUsuarioAlta As String
   Public Property IdUsuarioEstadoTurismo As String
   Public Property FechaEstadoTurismo As Date
   Public Property NombreEstablecimiento As String
   Public Property NombreContacto As String
   Public Property NombrePrograma As String
   Public Property NombreTipoVehiculo As String
   Public Property NombreEstadoTurismo As String
   Public Property NombreCurso As String
   Public Property NombreTurno As String

   Public Shared Function NombreBanderaColor(banderaColor As Color?) As String
      If banderaColor.HasValue Then
         If banderaColor.Value.ToArgb().Equals(Color.Red.ToArgb()) Then
            Return "Rojo"
         ElseIf banderaColor.Value.ToArgb().Equals(Color.Yellow.ToArgb()) Then
            Return "Amarillo"
         ElseIf banderaColor.Value.ToArgb().Equals(Color.Green.ToArgb()) Then
            Return "Verde"
         End If
      End If
      Return String.Empty
   End Function

   Public Property Visitas() As List(Of ReservaTurismoProducto)

   Public Property Gastronomia() As List(Of ReservaTurismoProducto)

   Public Property Pasajeros() As ListConBorrados(Of ReservaTurismoPasajero)

   Public Property CuentasCorrientes() As Entidades.CuentaCorriente

   Public Property Facturacion As List(Of ReservaTurismoProductoFacturacion)

   'Public Property CuentasCorrientesPagos() As List(Of CuentaCorrientePago)

   Public Property IdUnicoReserva As Long

   Public Property FechaViaje As Date

   Public Property ObservacionesVendedor As String
   Public Property ObservacionesInternas As String
   Public Property ErroresSincronizacion As String
   Public Property IdTipoViaje As Integer?

   Public Overrides Function ToString() As String
      Return String.Format("{0} {1} {2:0000}-{3:00000000}", IdTipoReserva, Letra, CentroEmisor, NumeroReserva)
   End Function

End Class