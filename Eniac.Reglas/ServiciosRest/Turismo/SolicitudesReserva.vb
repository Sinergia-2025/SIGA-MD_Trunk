#Region "Option"
Option Explicit On
Option Strict On
Option Infer On
#End Region
Namespace ServiciosRest.Turismo
   Public Class SolicitudesReserva
      Private Property BaseUri As Uri
      Private Property Metodo As String
      Private Property IdEmpresa As Integer

      Public Sub New(baseUri As Uri)
         Me.BaseUri = baseUri
         Me.Metodo = "SolicitudReserva"

         Dim codigoClienteSinergia As String = Publicos.CodigoClienteSinergia
         If Not IsNumeric(codigoClienteSinergia) Then
            Throw New Exception("No está configurado el Codigo de Empresa.")
         End If
         Me.IdEmpresa = Integer.Parse(codigoClienteSinergia)
      End Sub

      Public Sub ImportarAutomaticamente()
         GuardarSolicitudes()
         ''DescargarSolicitudesReserva()
      End Sub

      Private Function DescargarSolicitudesReserva() As List(Of Entidades.JSonEntidades.Turismo.SolicitudesReserva)
         Try
            Dim archWeb As New Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.Turismo.SolicitudesReserva)()

            Dim uri As Uri = New Uri(BaseUri, String.Concat(Metodo, "?procesado=False"))

            OnAvanceImportarAutomaticamente(String.Format("Descargando información de {0}.", Metodo))

            Dim headers As HeadersDictionary = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarVersion()

            Dim result As List(Of Entidades.JSonEntidades.Turismo.SolicitudesReserva)
            result = archWeb.Get(uri.ToString(), 0, Integer.MaxValue, Today, headers)

            Return result
         Catch ex As System.Net.WebException
            NetExceptionHelper.NetExceptionHandler(ex)
            Return Nothing
         End Try
      End Function


      Private Sub GuardarSolicitudes()

         Dim solicitudesReserva As List(Of Entidades.JSonEntidades.Turismo.SolicitudesReserva)
         OnAvanceImportarAutomaticamente("Obteniendo Solicitudes de Reserva")
         solicitudesReserva = DescargarSolicitudesReserva()

         Dim cache As BusquedasCacheadas = New BusquedasCacheadas()

         Dim tipoComprobante As Entidades.TipoComprobante = cache.BuscaTipoComprobante("RESERVA")
         Dim letra As String = tipoComprobante.LetrasHabilitadas
         Dim impresora As Entidades.Impresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, tipoComprobante.IdTipoComprobante)
         Dim centroEmisor As Short = impresora.CentroEmisor

         Dim idEstadoTurismo As Integer = New Reglas.EstadosTurismo().GetEstadoPorDefecto()

         For Each solicitudWeb As Entidades.JSonEntidades.Turismo.SolicitudesReserva In solicitudesReserva
            Dim stbErrores As StringBuilder = New StringBuilder()
            Dim algunError As Boolean = False

            OnAvanceImportarAutomaticamente(String.Format("Cargando reserva {0}", solicitudWeb.IdUnicoReserva))

            Dim reserva As Entidades.ReservaTurismo = New Entidades.ReservaTurismo()

            'SPC - Cambiar tipo de dato
            ''reserva.IdUnicoReserva = solicitudWeb.IdUnicoReserva

            reserva.IdSucursal = actual.Sucursal.Id
            reserva.IdTipoReserva = tipoComprobante.IdTipoComprobante
            reserva.Letra = letra
            reserva.CentroEmisor = centroEmisor

            reserva.NumeroReserva = 0 'Para que la regla le asigne el próximo número

            reserva.IdEstadoTurismo = idEstadoTurismo

            reserva.Fecha = If(solicitudWeb.Fecha.HasValue, solicitudWeb.Fecha.Value, Now)

            reserva.IdEstablecimiento = If(solicitudWeb.IdEstablecimiento.HasValue, solicitudWeb.IdEstablecimiento.Value, 0)
            reserva.IdCurso = If(solicitudWeb.IdCurso.HasValue, solicitudWeb.IdCurso.Value, 0)

            If Not Reglas.Ayudante.Cache.Turismo.CacheTurismoCursos.Instancia.Existe(reserva.IdCurso) Then
               stbErrores.AppendFormatLine("No existe Curso con Código ´{0}´", reserva.IdCurso)
               algunError = True
            End If

            reserva.Division = solicitudWeb.Division
            reserva.IdTurno = If(solicitudWeb.IdTurno.HasValue, solicitudWeb.IdTurno.Value, 0)

            If Not Reglas.Ayudante.Cache.Turismo.CacheTurismoTurnos.Instancia.Existe(reserva.IdTurno) Then
               stbErrores.AppendFormatLine("No existe Turno con Código ´{0}´", reserva.IdTurno)
               algunError = True
            End If

            reserva.IdResponsable = If(solicitudWeb.IdResponsable.HasValue, Convert.ToInt32(solicitudWeb.IdResponsable.Value), 0)
            reserva.IdPrograma = solicitudWeb.IdPrograma

            If Not cache.ExisteProductoPorIdRapido(reserva.IdPrograma) Then
               stbErrores.AppendFormatLine("No existe Programa con Código ´{0}´", reserva.IdPrograma)
               algunError = True
            End If

            reserva.Mes = solicitudWeb.Mes
            reserva.QuincenaSemana = solicitudWeb.QuincenaSemana
            reserva.Dia = solicitudWeb.Dia
            reserva.IdTipoVehiculo = If(solicitudWeb.IdTipoVehiculo.HasValue, solicitudWeb.IdTipoVehiculo.Value, 0)

            If Not Reglas.Ayudante.Cache.Archivos.CacheTiposVehiculos.Instancia.Existe(reserva.IdTipoVehiculo) Then
               stbErrores.AppendFormatLine("No existe Tipo de Vehículo con Código ´{0}´", reserva.IdTipoVehiculo)
               algunError = True
            End If

            reserva.CapacidadMax = If(solicitudWeb.CapacidadMax.HasValue, solicitudWeb.CapacidadMax.Value, 0)
            reserva.LugarSalida = solicitudWeb.LugarSalida
            reserva.CantidadAlumnos = If(solicitudWeb.CantidadAlumnos.HasValue, solicitudWeb.CantidadAlumnos.Value, 0)
            reserva.Costo = If(solicitudWeb.Costo.HasValue, solicitudWeb.Costo.Value, 0)
            reserva.BaseAlumnos = If(solicitudWeb.BaseAlumnos.HasValue, solicitudWeb.BaseAlumnos.Value, 0)
            reserva.IdFormaPago = If(solicitudWeb.IdFormaPago.HasValue, solicitudWeb.IdFormaPago.Value, 0)

            If Not cache.ExisteFormasPago(reserva.IdFormaPago) Then
               stbErrores.AppendFormatLine("No existe Forma de Pago con Código ´{0}´", reserva.IdFormaPago)
               algunError = True
            End If

            reserva.Liberados = solicitudWeb.Liberados
            reserva.Seguimiento = If(solicitudWeb.Seguimiento.HasValue, solicitudWeb.Seguimiento.Value, False)
            reserva.CDDigital = If(solicitudWeb.CDDigital.HasValue, solicitudWeb.CDDigital.Value, False)

            reserva.IdUsuarioAlta = If(String.IsNullOrWhiteSpace(solicitudWeb.IdUsuarioMovil), actual.Nombre, solicitudWeb.IdUsuarioMovil)
            reserva.IdUsuarioEstadoTurismo = actual.Nombre
            reserva.FechaEstadoTurismo = solicitudWeb.FechaEnvioWeb

            reserva.ObservacionesVendedor = solicitudWeb.Observacion.Truncar(2000)
            If solicitudWeb.Observacion IsNot Nothing AndAlso solicitudWeb.Observacion.Length > 2000 Then
               stbErrores.AppendFormatLine("Se truncaron las observaciones para que no superen los 2000 caracteres")
               algunError = True
            End If

            reserva.Visitas = New List(Of Entidades.ReservaTurismoProducto)
            reserva.Gastronomia = New List(Of Entidades.ReservaTurismoProducto)

            Dim cant As Integer = 0
            Dim reservaProducto As Entidades.ReservaTurismoProducto
            If solicitudWeb.SolicitudesReservaActividades IsNot Nothing Then
               For Each actividadWeb As Entidades.JSonEntidades.Turismo.SolicitudesReservaActividades In solicitudWeb.SolicitudesReservaActividades
                  cant += 1

                  reservaProducto = New Entidades.ReservaTurismoProducto()
                  'Actividad
                  reservaProducto.IdProducto = actividadWeb.IdVisita
                  reservaProducto.IdProductoComponente = actividadWeb.IdActividad
                  reservaProducto.IdFormula = Reglas.Publicos.TurismoFormulaVisitasID
                  reservaProducto.Orden = cant

                  If Not cache.ExisteProductoPorIdRapido(actividadWeb.IdVisita) Or
                     Not cache.ExisteProductoPorIdRapido(actividadWeb.IdActividad) Then
                     stbErrores.AppendFormatLine("No se encontró la Visita ({0}) ´{1}´ // ({2}) ´{3}´", actividadWeb.IdVisita, actividadWeb.NombreVisita, actividadWeb.IdActividad, actividadWeb.NombreActividad)
                     algunError = True
                  Else
                     reserva.Visitas.Add(reservaProducto)
                  End If
               Next
            End If

            If solicitudWeb.SolicitudesReservaLugaresGastronomicos IsNot Nothing Then
               For Each lugaresWeb As Entidades.JSonEntidades.Turismo.SolicitudesReservaLugaresGastronomicos In solicitudWeb.SolicitudesReservaLugaresGastronomicos
                  cant += 1

                  reservaProducto = New Entidades.ReservaTurismoProducto()
                  'Actividad
                  reservaProducto.IdProducto = lugaresWeb.IdPrograma
                  reservaProducto.IdProductoComponente = lugaresWeb.IdLugarGastronomico
                  reservaProducto.IdFormula = Reglas.Publicos.TurismoFormulaGastronomiaID
                  reservaProducto.Orden = cant

                  If Not cache.ExisteProductoPorIdRapido(lugaresWeb.IdLugarGastronomico) Then
                     stbErrores.AppendFormatLine("No se encontró el Lugar Gastronómico ({0}) ´{1}´", lugaresWeb.IdLugarGastronomico, lugaresWeb.NombreLugarGastronomico)
                     algunError = True
                  Else
                     reserva.Gastronomia.Add(reservaProducto)
                  End If
               Next
            End If

            If algunError Then
               reserva.ErroresSincronizacion = stbErrores.ToString()
            End If

            Dim da As Datos.DataAccess = New Datos.DataAccess()
            da.OpenConection()
            Try
               da.BeginTransaction()

               Dim rReserva As Reglas.ReservasTurismo = New ReservasTurismo(da)

               OnAvanceImportarAutomaticamente(String.Format("Grabando {0} {1} {2:0000}-{3:00000000}", reserva.IdTipoReserva, reserva.Letra, reserva.CentroEmisor, reserva.NumeroReserva))
               'IRENE: (Agregado) No existe el método sin transacción. No se aplicaron los métodos nuevos para manejo de transacción
               rReserva._Insertar(reserva)

               OnAvanceImportarAutomaticamente(String.Format("Marcando {0} {1} {2:0000}-{3:00000000} como procesada", reserva.IdTipoReserva, reserva.Letra, reserva.CentroEmisor, reserva.NumeroReserva))
               MarcarSolicitud(solicitudWeb)
               da.CommitTransaction()
            Catch
               da.RollbakTransaction()
               Throw
            Finally
               da.CloseConection()
            End Try
         Next
      End Sub

      Public Sub MarcarSolicitud(solicitud As Entidades.JSonEntidades.Turismo.SolicitudesReserva)

         Try
            Dim archWeb As New Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.Turismo.SolicitudesReserva)()

            Dim headers As HeadersDictionary = New HeadersDictionary().AgregarEmpresa(IdEmpresa).AgregarVersion()

            Dim uri As Uri = New Uri(BaseUri, Metodo)

            'archWeb.Delete(uri.ToString(), New System.Web.Script.Serialization.JavaScriptSerializer().Serialize(solicitud), headers:=Nothing)
            archWeb.Put(solicitud, uri.ToString(), headers)

         Catch ex As System.Net.WebException
            NetExceptionHelper.NetExceptionHandler(ex)
         End Try
      End Sub


#Region "Evento Control de Avance"
      Public Event AvanceImportarAutomaticamente(sender As Object, e As AvanceImportarAutomaticamenteEventArgs)
      Protected Overridable Sub OnAvanceImportarAutomaticamente(etapa As String)
         RaiseEvent AvanceImportarAutomaticamente(Me, New AvanceImportarAutomaticamenteEventArgs(etapa))
      End Sub
      Public Class AvanceImportarAutomaticamenteEventArgs
         Inherits EventArgs
         Public Property Etapa As String
         Public Sub New(etapa As String)
            Me.Etapa = etapa
         End Sub
      End Class

#End Region

   End Class
End Namespace