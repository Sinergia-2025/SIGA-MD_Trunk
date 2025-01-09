Namespace JSonEntidades.Turismo
   Public Class SolicitudesReserva
      Public Property IdEmpresa As Integer
      Public Property IdUnicoReserva As System.Guid
      Public Property IdSucursal As Nullable(Of Integer)
      Public Property IdTipoReserva As String
      Public Property Letra As String
      Public Property CentroEmisor As Nullable(Of Short)
      Public Property Numero As Nullable(Of Long)
      Public Property Fecha As Nullable(Of Date)
      Public Property IdEstablecimiento As Nullable(Of Long)
      Public Property IdCurso As Nullable(Of Integer)
      Public Property Division As String
      Public Property IdTurno As Nullable(Of Integer)
      Public Property IdResponsable As Nullable(Of Long)
      Public Property IdPrograma As String
      Public Property Mes As String
      Public Property QuincenaSemana As String
      Public Property Dia As String
      Public Property IdTipoVehiculo As Nullable(Of Integer)
      Public Property CapacidadMax As Nullable(Of Integer)
      Public Property LugarSalida As String
      Public Property CantidadAlumnos As Nullable(Of Integer)
      Public Property Costo As Nullable(Of Decimal)
      Public Property BaseAlumnos As Nullable(Of Integer)
      Public Property IdFormaPago As Nullable(Of Integer)
      Public Property Liberados As String
      Public Property Seguimiento As Nullable(Of Boolean)
      Public Property CDDigital As Nullable(Of Boolean)
      Public Property FechaEnvioWeb As Date
      Public Property FechaRecepcionWeb As Date
      Public Property FechaDescargaSiga As Nullable(Of Date)
      Public Property FechaProcesoSiga As Nullable(Of Date)
      Public Property Procesado As Boolean
      Public Property IdUsuarioMovil As String
      Public Property Observacion As String

      Public Property SolicitudesReservaActividades As List(Of SolicitudesReservaActividades)
      Public Property SolicitudesReservaLugaresGastronomicos As List(Of SolicitudesReservaLugaresGastronomicos)

   End Class
End Namespace