Public Class ReservasTurismo
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ReservasTurismo_I(idSucursal As Integer,
                                idTipoReserva As String,
                                letra As String,
                                centroEmisor As Short,
                                numeroReserva As Long,
                                fecha As Date,
                                idEstablecimiento As Long,
                                idCurso As Integer,
                                division As String,
                                idTurno As Integer,
                                idResponsable As Integer,
                                idPrograma As String,
                                mes As String,
                                quincenaSemana As String,
                                dia As String,
                                idTipoVehiculo As Integer,
                                capacidadMax As Integer,
                                lugarSalida As String,
                                cantidadAlumnos As Integer,
                                costo As Decimal,
                                baseAlumnos As Integer,
                                idFormaPago As Integer,
                                liberados As String,
                                seguimiento As Boolean,
                                cDDigital As Boolean,
                                idEstadoTurismo As Integer,
                                idUsuarioAlta As String,
                                idUsuarioEstadoTurismo As String,
                                fechaEstadoTurimo As Date,
                                banderaColor As Drawing.Color?,
                                idUnicoReserva As Long,
                                fechaViaje As Date,
                                observacionesVendedor As String,
                                observacionesInternas As String,
                                erroresSincronizacion As String,
                                idTipoViaje As Integer?)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO ReservasTurismo")
         .AppendFormatLine(" ({0} ", Entidades.ReservaTurismo.Columnas.IdSucursal.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.IdTipoReserva.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.Letra.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.CentroEmisor.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.NumeroReserva.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.Fecha.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.IdEstablecimiento.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.IdCurso.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.Division.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.IdTurno.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.IdResponsable.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.IdPrograma.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.Mes.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.QuincenaSemana.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.Dia.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.IdTipoVehiculo.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.CapacidadMax.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.LugarSalida.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.CantidadAlumnos.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.Costo.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.BaseAlumnos.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.IdFormaPago.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.Liberados.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.Seguimiento.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.CDDigital.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.IdEstadoTurismo.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.IdUsuarioAlta.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.IdUsuarioEstadoTurismo.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.FechaEstadoTurismo.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.BanderaColor.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.IdUnicoReserva.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.FechaViaje.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.ObservacionesVendedor.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismo.Columnas.ObservacionesInternas.ToString())
         .AppendFormatLine(" ,{0}", Entidades.ReservaTurismo.Columnas.ErroresSincronizacion.ToString())
         .AppendFormatLine(" ,{0}", Entidades.ReservaTurismo.Columnas.IdTipoViaje.ToString())
         .AppendFormatLine(")")
         .AppendFormatLine(" VALUES")
         .AppendFormatLine(" ({0}", idSucursal)
         .AppendFormatLine(" ,'{0}'", idTipoReserva)
         .AppendFormatLine(" ,'{0}'", letra)
         .AppendFormatLine(" , {0} ", centroEmisor)
         .AppendFormatLine(" , {0} ", numeroReserva)
         .AppendFormatLine(" ,'{0}'", ObtenerFecha(fecha, True))
         .AppendFormatLine(" ,{0}", idEstablecimiento)
         If idCurso > 0 Then
            .AppendFormatLine(" ,{0}", idCurso)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         If Not String.IsNullOrWhiteSpace(division) Then
            .AppendFormatLine(" ,'{0}'", division)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         If idTurno > 0 Then
            .AppendFormatLine(" ,{0}", idTurno)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         .AppendFormatLine(" ,{0}", idResponsable)
         If Not String.IsNullOrWhiteSpace(idPrograma) Then
            .AppendFormatLine(" ,'{0}' ", idPrograma)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         If Not String.IsNullOrWhiteSpace(mes) Then
            .AppendFormatLine(" ,'{0}' ", mes)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         If Not String.IsNullOrWhiteSpace(quincenaSemana) Then
            .AppendFormatLine(" ,'{0}' ", quincenaSemana)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         If Not String.IsNullOrWhiteSpace(dia) Then
            .AppendFormatLine(" ,'{0}'", dia)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         If idTipoVehiculo > 0 Then
            .AppendFormatLine(" ,{0}", idTipoVehiculo)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         If idTipoVehiculo > 0 Then
            .AppendFormatLine(" ,{0}", capacidadMax)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         If Not String.IsNullOrWhiteSpace(lugarSalida) Then
            .AppendFormatLine(" ,'{0}'", lugarSalida)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         If cantidadAlumnos > 0 Then
            .AppendFormatLine(" ,{0}", cantidadAlumnos)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         If costo > 0 Then
            .AppendFormatLine(" ,{0}", costo)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         If baseAlumnos > 0 Then
            .AppendFormatLine(" ,{0}", baseAlumnos)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         If idFormaPago > 0 Then
            .AppendFormatLine(" ,{0}", idFormaPago)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         If Not String.IsNullOrWhiteSpace(liberados) Then
            .AppendFormatLine(" ,'{0}'", liberados)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         .AppendFormatLine(" , '{0}'", GetStringFromBoolean(seguimiento))
         .AppendFormatLine(" , '{0}'", GetStringFromBoolean(cDDigital))
         If idEstadoTurismo > 0 Then
            .AppendFormatLine(" ,{0}", idEstadoTurismo)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         .AppendFormatLine(" , '{0}' ", idUsuarioAlta)
         .AppendFormatLine(" , '{0}' ", idUsuarioEstadoTurismo)
         .AppendFormatLine(" , '{0}' ", ObtenerFecha(fechaEstadoTurimo, True))
         If banderaColor.HasValue Then
            .AppendFormatLine(" ,  {0} ", banderaColor.Value.ToArgb())
         Else
            .AppendFormatLine(" , NULL")
         End If
         If idUnicoReserva > 0 Then
            .AppendFormatLine(" ,{0}", idUnicoReserva)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         If fechaViaje <> Nothing Then
            .AppendFormatLine(" ,'{0}'", ObtenerFecha(fechaViaje, False))
         Else
            .AppendFormatLine(" ,NULL")
         End If
         .AppendFormatLine(" ,'{0}'", observacionesVendedor)
         .AppendFormatLine(" ,'{0}'", observacionesInternas)
         .AppendFormatLine(" ,'{0}'", erroresSincronizacion)
         .AppendFormatLine(" , {0} ", GetStringFromNumber(idTipoViaje))
         .AppendFormatLine(")")
      End With
      Execute(stb)
   End Sub

   Public Sub ReservasTurismo_U(idSucursal As Integer,
                                idTipoReserva As String,
                                letra As String,
                                centroEmisor As Short,
                                numeroReserva As Long,
                                fecha As Date,
                                idEstablecimiento As Long,
                                idCurso As Integer,
                                division As String,
                                idTurno As Integer,
                                idResponsable As Long,
                                idPrograma As String,
                                mes As String,
                                quincenaSemana As String,
                                dia As String,
                                idTipoVehiculo As Integer,
                                capacidadMax As Integer,
                                lugarSalida As String,
                                cantidadAlumnos As Integer,
                                costo As Decimal,
                                baseAlumnos As Integer,
                                idFormaPago As Integer,
                                liberados As String,
                                seguimiento As Boolean,
                                cDDigital As Boolean,
                                idEstadoTurismo As Integer,
                                idUsuarioAlta As String,
                                idUsuarioEstadoTurismo As String,
                                fechaEstadoTurimo As Date,
                                banderaColor As Drawing.Color?,
                                fechaViaje As Date,
                                observacionesVendedor As String,
                                observacionesInternas As String,
                                erroresSincronizacion As String,
                                idTipoViaje As Integer?)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE ReservasTurismo ")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.ReservaTurismo.Columnas.Fecha.ToString(), ObtenerFecha(fecha, True))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ReservaTurismo.Columnas.IdEstablecimiento.ToString(), idEstablecimiento)
         .AppendFormatLine("     , {0} = {1} ", Entidades.ReservaTurismo.Columnas.IdCurso.ToString(), idCurso)
         .AppendFormatLine("     , {0} = '{1}' ", Entidades.ReservaTurismo.Columnas.Division.ToString(), division)
         .AppendFormatLine("     , {0} = {1} ", Entidades.ReservaTurismo.Columnas.IdTurno.ToString(), idTurno)
         .AppendFormatLine("     , {0} = {1}", Entidades.ReservaTurismo.Columnas.IdResponsable.ToString(), idResponsable)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ReservaTurismo.Columnas.IdPrograma.ToString(), idPrograma)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ReservaTurismo.Columnas.Mes.ToString(), mes)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ReservaTurismo.Columnas.QuincenaSemana.ToString(), quincenaSemana)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ReservaTurismo.Columnas.Dia.ToString(), dia)
         .AppendFormatLine("     , {0} = {1}", Entidades.ReservaTurismo.Columnas.IdTipoVehiculo.ToString(), idTipoVehiculo)
         .AppendFormatLine("     , {0} = {1}", Entidades.ReservaTurismo.Columnas.CapacidadMax.ToString(), capacidadMax)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ReservaTurismo.Columnas.LugarSalida.ToString(), lugarSalida)
         .AppendFormatLine("     , {0} = {1}", Entidades.ReservaTurismo.Columnas.CantidadAlumnos.ToString(), cantidadAlumnos)
         .AppendFormatLine("     , {0} = {1}", Entidades.ReservaTurismo.Columnas.Costo.ToString(), costo)
         .AppendFormatLine("     , {0} = {1}", Entidades.ReservaTurismo.Columnas.BaseAlumnos.ToString(), baseAlumnos)
         .AppendFormatLine("     , {0} = {1}", Entidades.ReservaTurismo.Columnas.IdFormaPago.ToString(), idFormaPago)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ReservaTurismo.Columnas.Liberados.ToString(), liberados)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ReservaTurismo.Columnas.Seguimiento.ToString(), seguimiento)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ReservaTurismo.Columnas.CDDigital.ToString(), cDDigital)
         .AppendFormatLine("     , {0} = {1}", Entidades.ReservaTurismo.Columnas.IdEstadoTurismo.ToString(), idEstadoTurismo)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ReservaTurismo.Columnas.IdUsuarioAlta.ToString(), idUsuarioAlta)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ReservaTurismo.Columnas.IdUsuarioEstadoTurismo.ToString(), idUsuarioEstadoTurismo)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ReservaTurismo.Columnas.FechaEstadoTurismo.ToString(), ObtenerFecha(fechaEstadoTurimo, True))
         If banderaColor.HasValue Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.ReservaTurismo.Columnas.BanderaColor.ToString(), banderaColor.Value.ToArgb())
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.ReservaTurismo.Columnas.BanderaColor.ToString())
         End If

         'If Not String.IsNullOrWhiteSpace(idUsuarioAsignado) Then
         '   .AppendFormat("     , {0} = '{1}'", Entidades.Reserva.Columnas.IdUsuarioAsignado.ToString(), idUsuarioAsignado)
         'Else
         '   .AppendFormat("     , {0} = NULL", Entidades.Reserva.Columnas.IdUsuarioAsignado.ToString())
         'End If
         If fechaViaje <> Nothing Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.ReservaTurismo.Columnas.FechaViaje.ToString(), ObtenerFecha(fechaViaje, False))
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.ReservaTurismo.Columnas.FechaViaje.ToString())
         End If
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ReservaTurismo.Columnas.ObservacionesVendedor.ToString(), observacionesVendedor)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ReservaTurismo.Columnas.ObservacionesInternas.ToString(), observacionesInternas)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ReservaTurismo.Columnas.ErroresSincronizacion.ToString(), erroresSincronizacion)

         .AppendFormatLine("     , {0} =  {1} ", Entidades.ReservaTurismo.Columnas.IdTipoViaje.ToString(), GetStringFromNumber(idTipoViaje))

         .AppendFormatLine(" WHERE {0} = {1}", Entidades.ReservaTurismo.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ReservaTurismo.Columnas.IdTipoReserva.ToString(), idTipoReserva)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ReservaTurismo.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ReservaTurismo.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ReservaTurismo.Columnas.NumeroReserva.ToString(), numeroReserva)
      End With
      Execute(stb)
   End Sub

   Public Sub ReservasTurismo_D(idSucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, NumeroReserva As Long)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM ReservasTurismo")
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.ReservaTurismo.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ReservaTurismo.Columnas.IdTipoReserva.ToString(), idTipoReserva)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ReservaTurismo.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ReservaTurismo.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ReservaTurismo.Columnas.NumeroReserva.ToString(), NumeroReserva)
      End With

      Execute(stb)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT  S.*,ET.Color AS ColorEstado , C.NombreCLiente AS NombreEstablecimiento, P.NombreProducto AS NombrePrograma,CC.NombreContacto,CC.IdTipoContacto, ")
         .AppendLine(" TV.NombreTipoVehiculo, FP.DescripcionFormasPago, TC.Descripcion AS NombreTipoReserva , CONVERT(DATE, S.Fecha) AS Fecha_Fecha  ")
         .AppendLine(" , CONVERT(VARCHAR(5), S.Fecha, 108) AS Fecha_Hora, ET.NombreEstadoTurismo")
         .AppendLine(" , CONVERT(DATE, S.FechaEstadoTurismo) AS FechaEstadoTurismo_Fecha , CONVERT(VARCHAR(5), S.FechaEstadoTurismo, 108) AS FechaEstadoTurismo_Hora")
         .AppendLine(" ,CU.NombreCurso, TU.NombreTurno, TTV.DescripcionTipoViaje")
         .AppendLine(" FROM ReservasTurismo S")
         .AppendLine(" LEFT JOIN EstadosTurismo ET ON ET.IdEstadoTurismo = S.IdEstadoTurismo")
         .AppendLine(" LEFT JOIN Clientes C ON C.IdCliente = S.IdEstablecimiento")
         .AppendLine("  LEFT JOIN ClientesContactos CC ON CC.IdContacto = S.IdResponsable  AND CC.IdCliente = S.IdEstablecimiento")
         .AppendLine(" LEFT JOIN Productos P ON P.IdProducto = S.IdPrograma")
         .AppendLine(" LEFT JOIN TiposVehiculos TV ON TV.IdTipoVehiculo = S.IdTipoVehiculo")
         .AppendLine(" LEFT JOIN VentasFormasPago FP ON FP.IdFormasPago = S.IdFormaPago ")
         .AppendLine(" LEFT JOIN TiposComprobantes TC ON TC.IdTipoComprobante = S.IdTipoReserva ")
         .AppendLine(" LEFT JOIN TurismoCursos CU ON CU.IdCurso = S.IdCurso")
         .AppendLine(" LEFT JOIN TurismoTurnos TU ON TU.IdTurno = S.IdTurno")
         .AppendLine(" LEFT JOIN TurismoTiposViajes TTV ON TTV.IdTipoViaje = S.IdTipoViaje")
      End With
   End Sub

   Public Function ReservasTurismo_G1(idSucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, Numero As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE S.{0} = {1}", Entidades.ReservaTurismo.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormat("   AND S.{0} = '{1}'", Entidades.ReservaTurismo.Columnas.IdTipoReserva.ToString(), idTipoReserva)
         .AppendFormat("   AND S.{0} = '{1}'", Entidades.ReservaTurismo.Columnas.Letra.ToString(), letra)
         .AppendFormat("   AND S.{0} =  {1} ", Entidades.ReservaTurismo.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormat("   AND S.{0} =  {1} ", Entidades.ReservaTurismo.Columnas.NumeroReserva.ToString(), Numero)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function ReservasTurismo_GA() As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor)
   End Function

   Private Sub PreparaColumnaParaBuscar(ByRef columna As String)
      If columna = "Color" Then
         columna = "ET." + columna
      ElseIf columna = "NombreEstablecimiento" Then
         columna = "C.NombreCliente"
      ElseIf columna = "NombrePrograma" Then
         columna = "P.NombreProducto"
      ElseIf columna = "NombreContacto" Then
         columna = "CC." + columna
      ElseIf columna = "NombreTipoVehiculo" Then
         columna = "TV." + columna
      ElseIf columna = "DescripcionFormasPago" Then
         columna = "FP." + columna
      ElseIf columna = "NombreTipoReserva" Then
         columna = "TC.Descripcion"
      ElseIf columna = "NombreEstadoTurismo" Then
         columna = "ET." + columna
      ElseIf columna = "NombreCurso" Then
         columna = "CU." + columna
      ElseIf columna = "NombreUsuarioResponsable" Then
         columna = "UR." + columna
      ElseIf columna = "NombreTurno" Then
         columna = "TU." + columna
      ElseIf columna = "Fecha_Fecha" Then
         columna = "S.Fecha"
      ElseIf columna = "Fecha_Hora" Then
         columna = "S.Fecha"
      ElseIf columna = "FechaEstadoTurismo_Fecha" Then
         columna = "S.FechaEstadoTurismo"
      ElseIf columna = "FechaEstadoTurismo_Hora" Then
         columna = "S.FechaEstadoTurismo"
      ElseIf columna = "DescripcionTipoViaje" Then
         columna = "TTV.DescripcionTipoViaje"
      Else
         columna = "S." + columna
      End If
   End Sub

   Public Function GetInfReservas(idCliente As Long, desde As Date?, hasta As Date?) As DataTable

      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendLine("WHERE 1=1 ")

         If idCliente > 0 Then
            .AppendFormatLine("AND S.idCliente = {0}", idCliente)
         End If
         If desde.HasValue Then
            .AppendFormatLine("AND S.Fecha >= '{0}'", ObtenerFecha(desde.Value, True))
         End If
         If hasta.HasValue Then
            .AppendFormatLine("AND S.Fecha <= '{0}'", ObtenerFecha(hasta.Value, True))
         End If

      End With
      Return GetDataTable(stb)

   End Function

   Public Function GetReservas(buscarABM As Entidades.Buscar, idCliente As Long, fechaDesde As Date?, fechaHasta As Date?,
                               IdUsuario As String, IdEstadoTurismo As Integer, Numero As Long,
                               finalizado As String) As DataTable

      If buscarABM IsNot Nothing Then PreparaColumnaParaBuscar(buscarABM.Columna)

      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendLine("WHERE 1=1 ")

         If idCliente > 0 Then
            .AppendFormatLine("AND S.idEstablecimiento = {0}", idCliente)
         End If
         If fechaDesde.HasValue Then
            .AppendFormatLine("AND S.Fecha >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("AND S.Fecha <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
         End If
         If finalizado <> "TODOS" Then
            .AppendLine("  AND ET.Finalizado = " & IIf(finalizado = "SI", "1", "0").ToString())
         End If
         If IdEstadoTurismo <> 0 Then
            .AppendFormatLine("AND S.IdEstadoTurismo = {0}", IdEstadoTurismo)
         End If
         If Numero <> 0 Then
            .AppendFormatLine("AND S.NumeroReserva = {0}", Numero)
         End If
         If Not String.IsNullOrEmpty(IdUsuario) Then
            .AppendFormatLine("AND S.IdUsuarioEstadoTurismo = '{0}'", IdUsuario)
         End If
         If buscarABM IsNot Nothing Then
            .AppendFormatLine(FormatoBuscarAnd, buscarABM.Columna, buscarABM.Valor.ToString())
         End If

      End With
      Return GetDataTable(stb)

   End Function

   Public Function GetReservasPorEstado(estados As List(Of Integer), idSucursal As Integer,
                                        idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE 1 = 1")
         If estados.Count > 0 Then
            .AppendFormatLine("   AND S.IdEstadoTurismo IN ({0})", String.Join(",", estados))
         End If
         If Not String.IsNullOrWhiteSpace(idTipoReserva) Then
            .AppendFormatLine("   AND S.IdTipoReserva = '{0}'", idTipoReserva)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND S.Letra = '{0}'", letra)
         End If
         If centroEmisor <> 0 Then
            .AppendFormatLine("   AND S.CentroEmisor = {0}", centroEmisor)
         End If
         If numeroReserva <> 0 Then
            .AppendFormatLine("   AND S.NumeroReserva = {0}", numeroReserva)
         End If

      End With
      Return GetDataTable(stb)
   End Function

   Public Sub ActualizarReserva(idSucursal As Integer,
                                idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long,
                                idTipoGeneracion As Entidades.ReservaTurismo.TipoGeneracionOpciones)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE ReservasTurismo")
         .AppendFormatLine("   SET TipoGeneracion = '{0}'", idTipoGeneracion)
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoReserva = '{0}'", idTipoReserva)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroReserva = {0}", numeroReserva)
      End With

      Execute(stb)
   End Sub

   Public Function GetFiltradoPorCodigo(numeroReserva As Integer?, establecimiento As String, busquedaParcial As Boolean) As DataTable
      Dim stb = New StringBuilder()
      SelectTexto(stb)
      With stb
         .AppendLine(" WHERE 1=1 ")

         If numeroReserva.HasValue AndAlso numeroReserva.Value > -1 Then
            If busquedaParcial Then
               .AppendFormat(" AND S.NumeroReserva{1} LIKE '%{0}%'", numeroReserva.Value)
            End If
         Else
            .AppendFormat(" AND S.NumeroReserva{1} = {0}", numeroReserva.Value)
         End If

         If Not String.IsNullOrWhiteSpace(establecimiento) Then
            For Each palabra As String In establecimiento.Split(" "c)
               If Not String.IsNullOrWhiteSpace(palabra) Then
                  'C.NombreCliente es el Nombre del Establecimiento
                  .AppendFormatLine("   AND (C.NombreCliente{1} LIKE '%{0}%')", palabra)
               End If
            Next
         End If

         .AppendFormat(" ORDER BY S.IdTipoReserva")
      End With
      Return GetDataTable(stb)
   End Function

End Class