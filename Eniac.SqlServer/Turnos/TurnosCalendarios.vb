Public Class TurnosCalendarios
   Inherits Comunes
   Private _idAplicacionSinergia As String
   Public Sub New(da As Eniac.Datos.DataAccess, idAplicacionSinergia As String)
      MyBase.New(da)
      Me._idAplicacionSinergia = idAplicacionSinergia
   End Sub

   Public Sub TurnosCalendarios_I(idTurno As Integer,
                                  idTurnoUnico As String,
                                  idCalendario As Integer,
                                  fechaDesde As DateTime,
                                  fechaHasta As DateTime,
                                  idCliente As Long,
                                  observaciones As String,
                                  idTipoTurno As String,
                                  idProducto As String,
                                  precioLista As Decimal?,
                                  precio As Decimal?,
                                  descuentoRecargoPorcGral As Decimal?,
                                  descuentoRecargoPorc1 As Decimal?,
                                  descuentoRecargoPorc2 As Decimal?,
                                  precioNeto As Decimal?,
                                  numeroSesion As Integer,
                                  idEstadoTurno As String,
                                  idEmbarcacion As Long,
                                  idDestino As Short,
                                  destinoLibre As String,
                                  cantidadPasajeros As Integer,
                                  fechaHoraLlegada As DateTime?,
                                  idPatenteVehiculo As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO TurnosCalendarios")
         .AppendFormatLine("           ({0}", Entidades.TurnoCalendario.Columnas.IdTurno.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.IdTurnoUnico.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.IdCalendario.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.FechaDesde.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.FechaHasta.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.IdCliente.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.Observaciones.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.IdTipoTurno.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.IdProducto.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.PrecioLista.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.Precio.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorcGral.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc1.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc2.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.PrecioNeto.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.NumeroSesion.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.IdEstadoTurno.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.IdEmbarcacion.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.IdDestino.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.DestinoLibre.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.CantidadPasajeros.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.IdPatenteVehiculo.ToString())
         .AppendFormatLine("           ,{0}", Entidades.TurnoCalendario.Columnas.FechaHoraLlegada.ToString())
         .AppendFormatLine("           )")
         .AppendFormatLine("    VALUES ( {0} ", idTurno)
         .AppendFormatLine("           ,'{0}'", idTurnoUnico)
         .AppendFormatLine("           , {0} ", idCalendario)
         .AppendFormatLine("           ,'{0}'", ObtenerFecha(fechaDesde, True))
         .AppendFormatLine("           ,'{0}'", ObtenerFecha(fechaHasta, True))
         .AppendFormatLine("           , {0} ", idCliente)
         .AppendFormatLine("           ,'{0}'", observaciones)
         .AppendFormatLine("           ,'{0}'", idTipoTurno)
         .AppendFormatLine("           , {0} ", GetStringParaQueryConComillas(idProducto))
         .AppendFormatLine("           , {0} ", If(precioLista.HasValue, precioLista.Value.ToString(), "NULL"))
         .AppendFormatLine("           , {0} ", If(precio.HasValue, precio.Value.ToString(), "NULL"))
         .AppendFormatLine("           , {0} ", If(descuentoRecargoPorcGral.HasValue, descuentoRecargoPorcGral.Value.ToString(), "NULL"))
         .AppendFormatLine("           , {0} ", If(descuentoRecargoPorc1.HasValue, descuentoRecargoPorc1.Value.ToString(), "NULL"))
         .AppendFormatLine("           , {0} ", If(descuentoRecargoPorc2.HasValue, descuentoRecargoPorc2.Value.ToString(), "NULL"))
         .AppendFormatLine("           , {0} ", If(precioNeto.HasValue, precioNeto.Value.ToString(), "NULL"))
         .AppendFormatLine("           , {0} ", numeroSesion)
         .AppendFormatLine("           ,'{0}'", idEstadoTurno)
         .AppendFormatLine("           , {0} ", GetStringFromNumber(idEmbarcacion))

         .AppendFormatLine("           , {0} ", GetStringFromNumber(idDestino))
         .AppendFormatLine("           ,'{0}'", destinoLibre)
         .AppendFormatLine("           , {0} ", GetStringFromNumber(cantidadPasajeros))

         .AppendFormatLine("           ,'{0}'", idPatenteVehiculo)

         If fechaHoraLlegada.HasValue Then
            .AppendFormatLine("           ,'{0}'", ObtenerFecha(fechaHoraLlegada.Value, True))
         Else
            .AppendFormatLine("           ,NULL ")
         End If
         .AppendFormatLine("           )")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TurnosCalendarios_U(idTurno As Integer,
                                  idTurnoUnico As String,
                                  idCalendario As Integer,
                                  fechaDesde As DateTime,
                                  fechaHasta As DateTime,
                                  idCliente As Long,
                                  observaciones As String,
                                  idTipoTurno As String,
                                  idProducto As String,
                                  precioLista As Decimal?,
                                  precio As Decimal?,
                                  descuentoRecargoPorcGral As Decimal?,
                                  descuentoRecargoPorc1 As Decimal?,
                                  descuentoRecargoPorc2 As Decimal?,
                                  precioNeto As Decimal?,
                                  numeroSesion As Integer,
                                  idEstadoTurno As String,
                                  idEmbarcacion As Long,
                                  idDestino As Short,
                                  destinoLibre As String,
                                  cantidadPasajeros As Integer,
                                  fechaHoraLlegada As DateTime?,
                                  idPatenteVehiculo As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE TurnosCalendarios ")
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.TurnoCalendario.Columnas.IdCalendario.ToString(), idCalendario)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.TurnoCalendario.Columnas.FechaDesde.ToString(), ObtenerFecha(fechaDesde, True))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.TurnoCalendario.Columnas.FechaHasta.ToString(), ObtenerFecha(fechaHasta, True))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TurnoCalendario.Columnas.IdCliente.ToString(), idCliente)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.TurnoCalendario.Columnas.Observaciones.ToString(), observaciones)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.TurnoCalendario.Columnas.IdTipoTurno.ToString(), idTipoTurno)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TurnoCalendario.Columnas.IdProducto.ToString(), GetStringParaQueryConComillas(idProducto))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TurnoCalendario.Columnas.PrecioLista.ToString(), If(precioLista.HasValue, precioLista.Value.ToString(), "NULL"))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TurnoCalendario.Columnas.Precio.ToString(), If(precio.HasValue, precio.Value.ToString(), "NULL"))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorcGral.ToString(), If(descuentoRecargoPorc1.HasValue, descuentoRecargoPorcGral.Value.ToString(), "NULL"))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc1.ToString(), If(descuentoRecargoPorc1.HasValue, descuentoRecargoPorc1.Value.ToString(), "NULL"))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc2.ToString(), If(descuentoRecargoPorc2.HasValue, descuentoRecargoPorc2.Value.ToString(), "NULL"))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TurnoCalendario.Columnas.PrecioNeto.ToString(), If(precioNeto.HasValue, precioNeto.Value.ToString(), "NULL"))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TurnoCalendario.Columnas.NumeroSesion.ToString(), numeroSesion)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.TurnoCalendario.Columnas.IdEstadoTurno.ToString(), idEstadoTurno)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TurnoCalendario.Columnas.IdEmbarcacion.ToString(), GetStringFromNumber(idEmbarcacion))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TurnoCalendario.Columnas.IdDestino.ToString(), GetStringFromNumber(idDestino))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.TurnoCalendario.Columnas.DestinoLibre.ToString(), destinoLibre)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TurnoCalendario.Columnas.CantidadPasajeros.ToString(), GetStringFromNumber(cantidadPasajeros))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.TurnoCalendario.Columnas.IdPatenteVehiculo.ToString(), idPatenteVehiculo)
         If fechaHoraLlegada.HasValue Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.TurnoCalendario.Columnas.FechaHoraLlegada.ToString(), ObtenerFecha(fechaHoraLlegada.Value, True))
         Else
            .AppendFormatLine("     , {0} = NULL ", Entidades.TurnoCalendario.Columnas.FechaHoraLlegada.ToString())
         End If
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.TurnoCalendario.Columnas.IdTurno.ToString(), idTurno)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TurnosCalendarios_U(idTurno As Integer,
                                  idSucursal As Integer?,
                                  idTipoComprobante As String,
                                  letra As String,
                                  centroEmisor As Short?,
                                  numeroComprobante As Long?)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE TurnosCalendarios ")
         .AppendFormatLine("   SET {0} = {1}", Entidades.TurnoCalendario.Columnas.IdSucursal.ToString(), GetStringFromNumber(idSucursal))
         .AppendFormatLine("     , {0} = {1}", Entidades.TurnoCalendario.Columnas.IdTipoComprobante.ToString(), GetStringParaQueryConComillas(idTipoComprobante))
         .AppendFormatLine("     , {0} = {1}", Entidades.TurnoCalendario.Columnas.Letra.ToString(), GetStringParaQueryConComillas(letra))
         .AppendFormatLine("     , {0} = {1}", Entidades.TurnoCalendario.Columnas.CentroEmisor.ToString(), GetStringFromNumber(centroEmisor))
         .AppendFormatLine("     , {0} = {1}", Entidades.TurnoCalendario.Columnas.NumeroComprobante.ToString(), GetStringFromNumber(numeroComprobante))

         .AppendFormat(" WHERE {0} =  {1} ", Entidades.TurnoCalendario.Columnas.IdTurno.ToString(), idTurno)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TurnosCalendarios_M_Guid(idTurno As Integer,
                                       idTurnoUnico As String,
                                       idCalendario As Integer,
                                       fechaDesde As DateTime,
                                       fechaHasta As DateTime,
                                       idCliente As Long,
                                       observaciones As String,
                                       idTipoTurno As String,
                                       idProducto As String,
                                       precioLista As Decimal?,
                                       precio As Decimal?,
                                       descuentoRecargoPorcGral As Decimal?,
                                       descuentoRecargoPorc1 As Decimal?,
                                       descuentoRecargoPorc2 As Decimal?,
                                       precioNeto As Decimal?,
                                       numeroSesion As Integer,
                                       idEstadoTurno As String,
                                       idEmbarcacion As Long,
                                       idDestino As Short,
                                       destinoLibre As String,
                                       cantidadPasajeros As Integer,
                                       fechaHoraLlegada As DateTime?)
      Dim myQuery = New StringBuilder()
      With myQuery

         .AppendFormatLine("MERGE INTO TurnosCalendarios AS DEST")
         .AppendFormatLine("        USING (SELECT  {1}  AS {0}", Entidades.TurnoCalendario.Columnas.IdCalendario.ToString(), idCalendario)
         If idTurno = 0 Then
            .AppendFormatLine("                    ,  (SELECT MAX({0}) + 1 FROM TurnosCalendarios) AS {0}", Entidades.TurnoCalendario.Columnas.IdTurno.ToString(), idTurno)
         Else
            .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.TurnoCalendario.Columnas.IdTurno.ToString(), idTurno)
         End If
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.TurnoCalendario.Columnas.IdTurnoUnico.ToString(), idTurnoUnico)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.TurnoCalendario.Columnas.FechaDesde.ToString(), ObtenerFecha(fechaDesde, True))
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.TurnoCalendario.Columnas.FechaHasta.ToString(), ObtenerFecha(fechaHasta, True))
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.TurnoCalendario.Columnas.IdCliente.ToString(), idCliente)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.TurnoCalendario.Columnas.Observaciones.ToString(), observaciones)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.TurnoCalendario.Columnas.IdTipoTurno.ToString(), idTipoTurno)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.TurnoCalendario.Columnas.IdProducto.ToString(), GetStringParaQueryConComillas(idProducto))
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.TurnoCalendario.Columnas.PrecioLista.ToString(), If(precioLista.HasValue, precioLista.Value.ToString(), "NULL"))
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.TurnoCalendario.Columnas.Precio.ToString(), If(precio.HasValue, precio.Value.ToString(), "NULL"))
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorcGral.ToString(), If(descuentoRecargoPorc1.HasValue, descuentoRecargoPorcGral.Value.ToString(), "NULL"))
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc1.ToString(), If(descuentoRecargoPorc1.HasValue, descuentoRecargoPorc1.Value.ToString(), "NULL"))
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc2.ToString(), If(descuentoRecargoPorc2.HasValue, descuentoRecargoPorc2.Value.ToString(), "NULL"))
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.TurnoCalendario.Columnas.PrecioNeto.ToString(), If(precioNeto.HasValue, precioNeto.Value.ToString(), "NULL"))
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.TurnoCalendario.Columnas.NumeroSesion.ToString(), numeroSesion)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.TurnoCalendario.Columnas.IdEstadoTurno.ToString(), idEstadoTurno)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.TurnoCalendario.Columnas.IdEmbarcacion.ToString(), GetStringFromNumber(idEmbarcacion))
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.TurnoCalendario.Columnas.IdDestino.ToString(), GetStringFromNumber(idDestino))
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.TurnoCalendario.Columnas.DestinoLibre.ToString(), destinoLibre)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.TurnoCalendario.Columnas.CantidadPasajeros.ToString(), GetStringFromNumber(cantidadPasajeros))
         If fechaHoraLlegada.HasValue Then
            .AppendFormatLine("                    , '{1}' AS {0}", Entidades.TurnoCalendario.Columnas.FechaHoraLlegada.ToString(), ObtenerFecha(fechaHoraLlegada.Value, True))
         Else
            .AppendFormatLine("                    , NULL  AS {0}", Entidades.TurnoCalendario.Columnas.FechaHoraLlegada.ToString())
         End If

         .AppendFormatLine("               ) AS ORIG ON DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.IdTurnoUnico.ToString())
         .AppendFormatLine("    WHEN MATCHED THEN")
         .AppendFormatLine("        UPDATE SET DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.IdCalendario.ToString())
         '.AppendFormatLine("                 , DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.IdTurno.ToString())
         .AppendFormatLine("                 , DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.IdTurnoUnico.ToString())
         .AppendFormatLine("                 , DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.FechaDesde.ToString())
         .AppendFormatLine("                 , DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.FechaHasta.ToString())
         .AppendFormatLine("                 , DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.IdCliente.ToString())
         .AppendFormatLine("                 , DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.Observaciones.ToString())
         .AppendFormatLine("                 , DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.IdTipoTurno.ToString())
         .AppendFormatLine("                 , DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.IdProducto.ToString())
         .AppendFormatLine("                 , DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.PrecioLista.ToString())
         .AppendFormatLine("                 , DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.Precio.ToString())
         .AppendFormatLine("                 , DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorcGral.ToString())
         .AppendFormatLine("                 , DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc1.ToString())
         .AppendFormatLine("                 , DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc2.ToString())
         .AppendFormatLine("                 , DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.PrecioNeto.ToString())
         .AppendFormatLine("                 , DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.NumeroSesion.ToString())
         .AppendFormatLine("                 , DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.IdEstadoTurno.ToString())
         .AppendFormatLine("                 , DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.IdEmbarcacion.ToString())
         .AppendFormatLine("                 , DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.IdDestino.ToString())
         .AppendFormatLine("                 , DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.DestinoLibre.ToString())
         .AppendFormatLine("                 , DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.CantidadPasajeros.ToString())
         .AppendFormatLine("                 , DEST.{0} = ORIG.{0}", Entidades.TurnoCalendario.Columnas.FechaHoraLlegada.ToString())

         .AppendFormatLine("    WHEN NOT MATCHED THEN")
         .AppendFormatLine("        INSERT ({0},", Entidades.TurnoCalendario.Columnas.IdCalendario.ToString())
         .AppendFormatLine("                {0},", Entidades.TurnoCalendario.Columnas.IdTurno.ToString())
         .AppendFormatLine("                {0},", Entidades.TurnoCalendario.Columnas.IdTurnoUnico.ToString())
         .AppendFormatLine("                {0},", Entidades.TurnoCalendario.Columnas.FechaDesde.ToString())
         .AppendFormatLine("                {0},", Entidades.TurnoCalendario.Columnas.FechaHasta.ToString())
         .AppendFormatLine("                {0},", Entidades.TurnoCalendario.Columnas.IdCliente.ToString())
         .AppendFormatLine("                {0},", Entidades.TurnoCalendario.Columnas.Observaciones.ToString())
         .AppendFormatLine("                {0},", Entidades.TurnoCalendario.Columnas.IdTipoTurno.ToString())
         .AppendFormatLine("                {0},", Entidades.TurnoCalendario.Columnas.IdProducto.ToString())
         .AppendFormatLine("                {0},", Entidades.TurnoCalendario.Columnas.PrecioLista.ToString())
         .AppendFormatLine("                {0},", Entidades.TurnoCalendario.Columnas.Precio.ToString())
         .AppendFormatLine("                {0},", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorcGral.ToString())
         .AppendFormatLine("                {0},", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc1.ToString())
         .AppendFormatLine("                {0},", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc2.ToString())
         .AppendFormatLine("                {0},", Entidades.TurnoCalendario.Columnas.PrecioNeto.ToString())
         .AppendFormatLine("                {0},", Entidades.TurnoCalendario.Columnas.NumeroSesion.ToString())
         .AppendFormatLine("                {0},", Entidades.TurnoCalendario.Columnas.IdEstadoTurno.ToString())
         .AppendFormatLine("                {0},", Entidades.TurnoCalendario.Columnas.IdEmbarcacion.ToString())
         .AppendFormatLine("                {0},", Entidades.TurnoCalendario.Columnas.IdDestino.ToString())
         .AppendFormatLine("                {0},", Entidades.TurnoCalendario.Columnas.DestinoLibre.ToString())
         .AppendFormatLine("                {0},", Entidades.TurnoCalendario.Columnas.CantidadPasajeros.ToString())
         .AppendFormatLine("                {0} ", Entidades.TurnoCalendario.Columnas.FechaHoraLlegada.ToString())

         .AppendFormatLine("               ) VALUES (")
         .AppendFormatLine("                ORIG.{0},", Entidades.TurnoCalendario.Columnas.IdCalendario.ToString())
         .AppendFormatLine("                ORIG.{0},", Entidades.TurnoCalendario.Columnas.IdTurno.ToString())
         .AppendFormatLine("                ORIG.{0},", Entidades.TurnoCalendario.Columnas.IdTurnoUnico.ToString())
         .AppendFormatLine("                ORIG.{0},", Entidades.TurnoCalendario.Columnas.FechaDesde.ToString())
         .AppendFormatLine("                ORIG.{0},", Entidades.TurnoCalendario.Columnas.FechaHasta.ToString())
         .AppendFormatLine("                ORIG.{0},", Entidades.TurnoCalendario.Columnas.IdCliente.ToString())
         .AppendFormatLine("                ORIG.{0},", Entidades.TurnoCalendario.Columnas.Observaciones.ToString())
         .AppendFormatLine("                ORIG.{0},", Entidades.TurnoCalendario.Columnas.IdTipoTurno.ToString())
         .AppendFormatLine("                ORIG.{0},", Entidades.TurnoCalendario.Columnas.IdProducto.ToString())
         .AppendFormatLine("                ORIG.{0},", Entidades.TurnoCalendario.Columnas.PrecioLista.ToString())
         .AppendFormatLine("                ORIG.{0},", Entidades.TurnoCalendario.Columnas.Precio.ToString())
         .AppendFormatLine("                ORIG.{0},", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorcGral.ToString())
         .AppendFormatLine("                ORIG.{0},", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc1.ToString())
         .AppendFormatLine("                ORIG.{0},", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc2.ToString())
         .AppendFormatLine("                ORIG.{0},", Entidades.TurnoCalendario.Columnas.PrecioNeto.ToString())
         .AppendFormatLine("                ORIG.{0},", Entidades.TurnoCalendario.Columnas.NumeroSesion.ToString())
         .AppendFormatLine("                ORIG.{0},", Entidades.TurnoCalendario.Columnas.IdEstadoTurno.ToString())
         .AppendFormatLine("                ORIG.{0},", Entidades.TurnoCalendario.Columnas.IdEmbarcacion.ToString())
         .AppendFormatLine("                ORIG.{0},", Entidades.TurnoCalendario.Columnas.IdDestino.ToString())
         .AppendFormatLine("                ORIG.{0},", Entidades.TurnoCalendario.Columnas.DestinoLibre.ToString())
         .AppendFormatLine("                ORIG.{0},", Entidades.TurnoCalendario.Columnas.CantidadPasajeros.ToString())
         .AppendFormatLine("                ORIG.{0} ", Entidades.TurnoCalendario.Columnas.FechaHoraLlegada.ToString())

         .AppendFormatLine("               )")

         .AppendFormatLine(";")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TurnosCalendarios_D(idTurno As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM TurnosCalendarios WHERE {0} = {1}", Entidades.TurnoCalendario.Columnas.IdTurno.ToString(), idTurno)
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub TurnosCalendarios_D(idTurnoUnico As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM TurnosCalendarios WHERE {0} = '{1}'", Entidades.TurnoCalendario.Columnas.IdTurnoUnico.ToString(), idTurnoUnico)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Protected Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT T.*, C.CodigoCliente, C.NombreCliente, C.NroDocCliente, TT.NombreTipoTurno, P.NombreProducto, ET.NombreEstadoTurno")
         If Me._idAplicacionSinergia = "SISEN" Then
            .AppendFormatLine("     , E.IdEmbarcacion, E.CodigoEmbarcacion, E.NombreEmbarcacion")
         End If
         SelectTexto_AgregarCampos(stb)
         .AppendFormatLine("  FROM TurnosCalendarios AS T")
         .AppendFormatLine("  LEFT JOIN Clientes C ON C.IdCliente = T.IdCliente")
         .AppendFormatLine("  LEFT JOIN TiposTurnos TT ON TT.IdTipoTurno = T.IdTipoTurno")
         .AppendFormatLine("  LEFT JOIN Productos P ON P.IdProducto = T.IdProducto")
         .AppendFormatLine("  LEFT JOIN EstadosTurnos ET ON ET.IdEstadoTurno = T.IdEstadoTurno")
         If Me._idAplicacionSinergia = "SISEN" Then
            .AppendFormatLine("  LEFT JOIN Embarcaciones E ON E.IdEmbarcacion = T.IdEmbarcacion")
         End If
         SelectTexto_AgregarJoins(stb)
      End With
   End Sub

   Protected Overridable Sub SelectTexto_AgregarCampos(ByVal stb As StringBuilder)

   End Sub
   Protected Overridable Sub SelectTexto_AgregarJoins(ByVal stb As StringBuilder)

   End Sub
   Public Function GetTurnosDelDia(idUsuario As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT C.IdCalendario, C.NombreCalendario, COUNT(*) AS Turnos")
         .AppendFormatLine("  FROM TurnosCalendarios AS T")
         .AppendFormatLine(" INNER JOIN Calendarios C ON C.IdCalendario = T.IdCalendario")
         .AppendFormatLine(" INNER JOIN CalendariosUsuarios CU ON CU.IdCalendario = C.IdCalendario")
         .AppendFormatLine(" WHERE T.FechaDesde >= '{0}'", ObtenerFecha(Date.Now, False))
         .AppendFormatLine("   AND T.FechaDesde <= '{0}'", ObtenerFecha(Date.Now.UltimoSegundoDelDia(), True))
         .AppendFormatLine("   AND CU.IdUsuario = '{0}'", idUsuario)
         .AppendFormatLine(" GROUP BY C.IdCalendario,C.NombreCalendario")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TurnosCalendarios_GA() As DataTable
      Return TurnosCalendarios_G(idTurno:=0, idTurnoUnico:=String.Empty, idCalendario:=0, idCliente:=0, fechaDesdeDesde:=Nothing, fechaDesdeHasta:=Nothing, idTipoTurno:=String.Empty,
                                 idSucursal:=0, idTipoComprobante:="", letra:="", centroEmisor:=0, numeroComprobante:=0, idEstadoTurno:=String.Empty)
   End Function
   Public Function TurnosCalendarios_GA(idCalendario As Integer, fechaDesdeDesde As DateTime?, fechaDesdeHasta As DateTime?) As DataTable
      Return TurnosCalendarios_G(idTurno:=0, idTurnoUnico:=String.Empty, idCalendario:=idCalendario, idCliente:=0, fechaDesdeDesde:=fechaDesdeDesde, fechaDesdeHasta:=fechaDesdeHasta, idTipoTurno:=String.Empty,
                                 idSucursal:=0, idTipoComprobante:="", letra:="", centroEmisor:=0, numeroComprobante:=0, idEstadoTurno:=String.Empty)
   End Function
   Public Function TurnosCalendarios_GA(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As DataTable
      Return TurnosCalendarios_G(idTurno:=0, idTurnoUnico:=String.Empty, idCalendario:=0, idCliente:=0, fechaDesdeDesde:=Nothing, fechaDesdeHasta:=Nothing, idTipoTurno:=String.Empty,
                                 idSucursal:=idSucursal, idTipoComprobante:=idTipoComprobante, letra:=letra, centroEmisor:=centroEmisor, numeroComprobante:=numeroComprobante, idEstadoTurno:=String.Empty)
   End Function
   Private Function TurnosCalendarios_G(idTurno As Integer, idTurnoUnico As String, idCalendario As Integer, idCliente As Long, fechaDesdeDesde As DateTime?, fechaDesdeHasta As DateTime?,
                                        idTipoTurno As String, idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long, idEstadoTurno As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idTurno > 0 Then
            .AppendFormat("   AND T.IdTurno = {0}", idTurno).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTurnoUnico) Then
            .AppendFormatLine("   AND T.IdTurnoUnico = '{0}'", idTurnoUnico)
         End If
         If idCalendario > 0 Then
            .AppendFormat("   AND T.IdCalendario = {0}", idCalendario).AppendLine()
         End If
         If idCliente > 0 Then
            .AppendFormat("   AND T.IdCliente = {0}", idCliente).AppendLine()
         End If
         If fechaDesdeDesde.HasValue Then
            .AppendFormat("   AND T.FechaDesde >= '{0}'", ObtenerFecha(fechaDesdeDesde.Value.Date, True)).AppendLine()
         End If
         If fechaDesdeHasta.HasValue Then
            .AppendFormat("   AND T.FechaDesde <= '{0}'", ObtenerFecha(fechaDesdeHasta.Value.Date.AddDays(1).AddSeconds(-1), True)).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoTurno) Then
            .AppendFormat("   AND T.IdTipoTurno = '{0}'", idTipoTurno).AppendLine()
         End If

         If idSucursal > 0 Then
            .AppendFormatLine("   AND T.IdSucursal = {0}", idSucursal)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND T.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND T.Letra = '{0}'", letra).AppendLine()
         End If
         If centroEmisor > 0 Then
            .AppendFormatLine("   AND T.CentroEmisor = {0}", centroEmisor)
         End If
         If numeroComprobante > 0 Then
            .AppendFormatLine("   AND T.NumeroComprobante = {0}", numeroComprobante)
         End If
         If Not String.IsNullOrWhiteSpace(idEstadoTurno) Then
            .AppendFormat("   AND T.IdEstadoTurno = '{0}'", idEstadoTurno).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TurnosCalendarios_G1(idTurno As Integer) As DataTable
      Return TurnosCalendarios_G(idTurno:=idTurno, idTurnoUnico:=String.Empty, idCalendario:=0, idCliente:=0, fechaDesdeDesde:=Nothing, fechaDesdeHasta:=Nothing, idTipoTurno:=String.Empty,
                                 idSucursal:=0, idTipoComprobante:="", letra:="", centroEmisor:=0, numeroComprobante:=0, idEstadoTurno:=String.Empty)
   End Function
   Public Function TurnosCalendarios_G1(idTurnoUnico As String) As DataTable
      Return TurnosCalendarios_G(idTurno:=0, idTurnoUnico:=idTurnoUnico, idCalendario:=0, idCliente:=0, fechaDesdeDesde:=Nothing, fechaDesdeHasta:=Nothing, idTipoTurno:=String.Empty,
                                 idSucursal:=0, idTipoComprobante:="", letra:="", centroEmisor:=0, numeroComprobante:=0, idEstadoTurno:=String.Empty)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      If columna = Entidades.Cliente.Columnas.CodigoCliente.ToString() Or columna = Entidades.Cliente.Columnas.NombreCliente.ToString() Then
         columna = "C." + columna
      ElseIf columna = Entidades.TipoTurno.Columnas.NombreTipoTurno.ToString() Then
         columna = "TT." + columna
      ElseIf columna = Entidades.EstadoTurno.Columnas.NombreEstadoTurno.ToString() Then
         columna = "ET." + columna
      ElseIf columna = Entidades.Producto.Columnas.NombreProducto.ToString() Then
         columna = "P." + columna
      Else
         columna = "T." + columna
      End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE {0} LIKE '%{1}%'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorRangoFechas(filtros As Entidades.Filtros.GetPorRangoFechasFiltros) As DataTable
      If filtros Is Nothing Then Throw New NullReferenceException("No se ha pasado una instancia de filtro de tipo GetPorRangoFechasFiltros.")
      Dim stb As StringBuilder = New StringBuilder()
      GetPorRangoFechas_Campos(stb, filtros)
      GetPorRangoFechas_From(stb, filtros)
      GetPorRangoFechas_Where(stb, filtros)
      GetPorRangoFechas_Order(stb, filtros)

      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function GetPorRangoFechasZonas(filtros As Entidades.Filtros.GetPorRangoFechasFiltros) As DataTable
      If filtros Is Nothing Then Throw New NullReferenceException("No se ha pasado una instancia de filtro de tipo GetPorRangoFechasFiltros.")
      Dim stb As StringBuilder = New StringBuilder()
      GetPorRangoFechasZonas_Campos(stb, filtros)
      GetPorRangoFechasZonas_From(stb, filtros)
      GetPorRangoFechasZonas_Where(stb, filtros)
      GetPorRangoFechasZonas_Order(stb, filtros)

      Return Me.GetDataTable(stb.ToString())
   End Function

   Protected Overridable Sub GetPorRangoFechas_Campos(stb As StringBuilder, filtros As Entidades.Filtros.GetPorRangoFechasFiltros)
      With stb
         .AppendFormatLine("SELECT T.{0}", Entidades.TurnoCalendario.Columnas.IdTurno.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.IdCalendario.ToString())
         .AppendFormatLine("      ,CL.{0}", Entidades.Calendario.Columnas.NombreCalendario.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.FechaDesde.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.FechaHasta.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.IdCliente.ToString())
         .AppendFormatLine("      ,C.{0}", Entidades.Cliente.Columnas.CodigoCliente.ToString())
         .AppendFormatLine("      ,C.{0}", Entidades.Cliente.Columnas.NombreCliente.ToString())
         .AppendFormatLine("      ,C.{0}", Entidades.Cliente.Columnas.Telefono.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.IdTipoTurno.ToString())
         .AppendFormatLine("      ,TT.{0}", Entidades.TipoTurno.Columnas.NombreTipoTurno.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.Observaciones.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.IdProducto.ToString())
         .AppendFormatLine("      ,P.{0}", Entidades.Producto.Columnas.NombreProducto.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.PrecioLista.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.Precio.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorcGral.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc1.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc2.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.PrecioNeto.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.NumeroSesion.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.IdEstadoTurno.ToString())
         .AppendFormatLine("      ,ET.{0}", Entidades.EstadoTurno.Columnas.NombreEstadoTurno.ToString())
         .AppendFormatLine("      ,VH.{0}", Entidades.Vehiculo.Columnas.PatenteVehiculo.ToString())
         .AppendFormatLine("      ,MA.{0}", Entidades.MarcaVehiculo.Columnas.NombreMarcaVehiculo.ToString())
         .AppendFormatLine("      ,MO.{0}", Entidades.ModeloVehiculo.Columnas.NombreModeloVehiculo.ToString())


         If Me._idAplicacionSinergia = "SISEN" Then
            .AppendFormatLine("      ,E.IdEmbarcacion")
            .AppendFormatLine("      ,E.CodigoEmbarcacion")
            .AppendFormatLine("      ,E.NombreEmbarcacion")
            .AppendFormatLine("      ,T.IdDestino")
            .AppendFormatLine("      ,CASE WHEN DE.EsLibre = 'True' THEN T.DestinoLibre ELSE DE.NombreDestino END DestinoLibre")
            .AppendFormatLine("      ,T.CantidadPasajeros")
            .AppendFormatLine("      ,T.FechaHoraLlegada")

         End If

      End With
   End Sub
   Protected Overridable Sub GetPorRangoFechasZonas_Campos(stb As StringBuilder, filtros As Entidades.Filtros.GetPorRangoFechasFiltros)
      With stb
         .AppendFormatLine("SELECT T.{0}", Entidades.TurnoCalendario.Columnas.IdTurno.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.IdCalendario.ToString())
         .AppendFormatLine("      ,CL.{0}", Entidades.Calendario.Columnas.NombreCalendario.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.FechaDesde.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.FechaHasta.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.IdCliente.ToString())
         .AppendFormatLine("      ,C.{0}", Entidades.Cliente.Columnas.CodigoCliente.ToString())
         .AppendFormatLine("      ,C.{0}", Entidades.Cliente.Columnas.NombreCliente.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.IdTipoTurno.ToString())
         .AppendFormatLine("      ,TT.{0}", Entidades.TipoTurno.Columnas.NombreTipoTurno.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.Observaciones.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.IdProducto.ToString())
         .AppendFormatLine("      ,P.{0}", Entidades.Producto.Columnas.NombreProducto.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.PrecioLista.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.Precio.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorcGral.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc1.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc2.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.PrecioNeto.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.NumeroSesion.ToString())
         .AppendFormatLine("      ,PZ.{0} As NombreZona", Entidades.Producto.Columnas.NombreProducto.ToString())
         .AppendFormatLine("      ,TCP.{0} As NumeroSesionZona", Entidades.TurnosCalendariosProductos.Columnas.NumeroSesion.ToString())
         .AppendFormatLine("      ,TCP.{0}", Entidades.TurnosCalendariosProductos.Columnas.ValorFluencia.ToString())
         .AppendFormatLine("      ,T.{0}", Entidades.TurnoCalendario.Columnas.IdEstadoTurno.ToString())
         .AppendFormatLine("      ,ET.{0}", Entidades.EstadoTurno.Columnas.NombreEstadoTurno.ToString())
      End With
   End Sub
   Protected Overridable Sub GetPorRangoFechas_From(stb As StringBuilder, filtros As Entidades.Filtros.GetPorRangoFechasFiltros)
      With stb
         .AppendFormatLine("  FROM TurnosCalendarios T")
         .AppendFormatLine("  LEFT JOIN Calendarios CL ON CL.{0} = T.{1}", Entidades.Calendario.Columnas.IdCalendario.ToString, Entidades.TurnoCalendario.Columnas.IdCalendario.ToString())
         .AppendFormatLine("  LEFT JOIN Clientes C ON C.{0} = T.{1}", Entidades.Cliente.Columnas.IdCliente.ToString, Entidades.TurnoCalendario.Columnas.IdCliente.ToString())
         .AppendFormatLine("  LEFT JOIN TiposTurnos TT ON TT.{0} = T.{1}", Entidades.TipoTurno.Columnas.IdTipoTurno.ToString, Entidades.TurnoCalendario.Columnas.IdTipoTurno.ToString())
         .AppendFormatLine("  LEFT JOIN Productos P ON P.{0} = T.{1}", Entidades.Producto.Columnas.IdProducto.ToString(), Entidades.TurnoCalendario.Columnas.IdProducto.ToString())
         .AppendFormatLine("  LEFT JOIN EstadosTurnos ET ON ET.{0} = T.{1}", Entidades.EstadoTurno.Columnas.IdEstadoTurno.ToString, Entidades.TurnoCalendario.Columnas.IdEstadoTurno.ToString())
         .AppendFormatLine("  LEFT JOIN Vehiculos VH ON VH.{0} = T.{1}", Entidades.Vehiculo.Columnas.PatenteVehiculo.ToString, Entidades.TurnoCalendario.Columnas.IdPatenteVehiculo.ToString())
         .AppendFormatLine("  LEFT JOIN MarcasVehiculos MA ON VH.{0} = MA.{1}", Entidades.Vehiculo.Columnas.IdMarcaVehiculo.ToString, Entidades.MarcaVehiculo.Columnas.IdMarcaVehiculo.ToString())
         .AppendFormatLine("  LEFT JOIN ModelosVehiculos MO ON VH.{0} = MO.{1}", Entidades.Vehiculo.Columnas.IdModeloVehiculo.ToString, Entidades.ModeloVehiculo.Columnas.IdModeloVehiculo.ToString())


         If Me._idAplicacionSinergia = "SISEN" Then
            .AppendFormatLine("  LEFT JOIN Embarcaciones E ON E.IdEmbarcacion = T.IdEmbarcacion")
            .AppendFormatLine("  LEFT JOIN Destinos DE ON DE.IdDestino = T.IdDestino")
         End If

      End With
   End Sub
   Protected Overridable Sub GetPorRangoFechasZonas_From(stb As StringBuilder, filtros As Entidades.Filtros.GetPorRangoFechasFiltros)
      With stb
         .AppendFormatLine("  FROM TurnosCalendarios T")
         .AppendFormatLine("  LEFT JOIN TurnosCalendariosProductos TCP ON TCP.{0} = T.{1}", Entidades.TurnosCalendariosProductos.Columnas.IdTurno.ToString, Entidades.TurnoCalendario.Columnas.IdTurno.ToString())
         .AppendFormatLine("  LEFT JOIN Productos PZ ON PZ.{0} = TCP.{1}", Entidades.Producto.Columnas.IdProducto.ToString(), Entidades.TurnosCalendariosProductos.Columnas.IdProducto.ToString())
         .AppendFormatLine("  LEFT JOIN Calendarios CL ON CL.{0} = T.{1}", Entidades.Calendario.Columnas.IdCalendario.ToString, Entidades.TurnoCalendario.Columnas.IdCalendario.ToString())
         .AppendFormatLine("  LEFT JOIN Clientes C ON C.{0} = T.{1}", Entidades.Cliente.Columnas.IdCliente.ToString, Entidades.TurnoCalendario.Columnas.IdCliente.ToString())
         .AppendFormatLine("  LEFT JOIN TiposTurnos TT ON TT.{0} = T.{1}", Entidades.TipoTurno.Columnas.IdTipoTurno.ToString, Entidades.TurnoCalendario.Columnas.IdTipoTurno.ToString())
         .AppendFormatLine("  LEFT JOIN Productos P ON P.{0} = T.{1}", Entidades.Producto.Columnas.IdProducto.ToString(), Entidades.TurnoCalendario.Columnas.IdProducto.ToString())
         .AppendFormatLine("  LEFT JOIN EstadosTurnos ET ON ET.{0} = T.{1}", Entidades.EstadoTurno.Columnas.IdEstadoTurno.ToString, Entidades.TurnoCalendario.Columnas.IdEstadoTurno.ToString())

      End With
   End Sub
   Protected Overridable Sub GetPorRangoFechas_Where(stb As StringBuilder, filtros As Entidades.Filtros.GetPorRangoFechasFiltros)
      With stb
         .AppendFormatLine(" WHERE T.{0} >= '{1}'", Entidades.TurnoCalendario.Columnas.FechaDesde.ToString(), ObtenerFecha(filtros.FechaDesde, True))
         .AppendFormatLine("   AND T.{0} <= '{1}'", Entidades.TurnoCalendario.Columnas.FechaHasta.ToString(), ObtenerFecha(filtros.FechaHasta, True))

         If filtros.IdSucursal > 0 Then
            .AppendFormatLine("   AND (CL.{0} IS NULL OR CL.{0} = {1})", Entidades.Calendario.Columnas.IdSucursal.ToString(), filtros.IdSucursal)
         End If

         If filtros.IdCalendario > 0 Then
            .AppendFormatLine("   AND T.{0} = {1}", Entidades.TurnoCalendario.Columnas.IdCalendario.ToString(), filtros.IdCalendario).AppendLine()
         End If

         If filtros.IdCliente > 0 Then
            .AppendFormatLine("   AND T.{0} = {1}", Entidades.TurnoCalendario.Columnas.IdCliente.ToString(), filtros.IdCliente).AppendLine()
         End If

         If Not String.IsNullOrEmpty(filtros.IdTipoTurno) Then
            .AppendFormatLine("   AND T.{0} = '{1}'", Entidades.TurnoCalendario.Columnas.IdTipoTurno.ToString(), filtros.IdTipoTurno)
         End If

         If Not String.IsNullOrEmpty(filtros.IdEstadoTurno) Then
            .AppendFormatLine("   AND T.{0} = '{1}'", Entidades.TurnoCalendario.Columnas.IdEstadoTurno.ToString(), filtros.IdEstadoTurno)
         End If

         If Me._idAplicacionSinergia = "SISEN" Then
            If filtros.IdEmbarcacion > 0 Then
               .AppendFormatLine("   AND T.IdEmbarcacion = {0}", filtros.IdEmbarcacion)
            End If
         End If

      End With
   End Sub

   Protected Overridable Sub GetPorRangoFechasZonas_Where(stb As StringBuilder, filtros As Entidades.Filtros.GetPorRangoFechasFiltros)
      With stb
         .AppendFormat(" WHERE T.{0} >= '{1}'", Entidades.TurnoCalendario.Columnas.FechaDesde.ToString(), ObtenerFecha(filtros.FechaDesde, True)).AppendLine()
         .AppendFormat("   AND T.{0} <= '{1}'", Entidades.TurnoCalendario.Columnas.FechaHasta.ToString(), ObtenerFecha(filtros.FechaHasta, True)).AppendLine()

         If filtros.IdSucursal > 0 Then
            .AppendFormat("   AND (CL.{0} IS NULL OR CL.{0} = {1})", Entidades.Calendario.Columnas.IdSucursal.ToString(), filtros.IdSucursal)
         End If

         If filtros.IdCalendario > 0 Then
            .AppendFormat("   AND T.{0} = {1}", Entidades.TurnoCalendario.Columnas.IdCalendario.ToString(), filtros.IdCalendario).AppendLine()
         End If

         If filtros.IdCliente > 0 Then
            .AppendFormat("   AND T.{0} = {1}", Entidades.TurnoCalendario.Columnas.IdCliente.ToString(), filtros.IdCliente).AppendLine()
         End If

         If Not String.IsNullOrEmpty(filtros.IdTipoTurno) Then
            .AppendFormat("   AND T.{0} = '{1}'", Entidades.TurnoCalendario.Columnas.IdTipoTurno.ToString(), filtros.IdTipoTurno)
         End If

         If Not String.IsNullOrEmpty(filtros.idProducto) Then
            .AppendFormat("   AND TCP.{0} = '{1}'", Entidades.TurnosCalendariosProductos.Columnas.IdProducto.ToString(), filtros.idProducto)
         End If

         If Not String.IsNullOrEmpty(filtros.IdEstadoTurno) Then
            .AppendFormat("   AND T.{0} = '{1}'", Entidades.TurnoCalendario.Columnas.IdEstadoTurno.ToString(), filtros.IdEstadoTurno)
         End If
      End With
   End Sub
   Protected Overridable Sub GetPorRangoFechas_Order(stb As StringBuilder, filtros As Entidades.Filtros.GetPorRangoFechasFiltros)
      With stb
         .AppendFormat(" ORDER BY T.{0}", Entidades.TurnoCalendario.Columnas.FechaDesde.ToString()).AppendLine()
         .AppendFormat("        , T.{0}", Entidades.TurnoCalendario.Columnas.FechaHasta.ToString()).AppendLine()
      End With
   End Sub
   Protected Overridable Sub GetPorRangoFechasZonas_Order(stb As StringBuilder, filtros As Entidades.Filtros.GetPorRangoFechasFiltros)
      With stb
         .AppendFormat(" ORDER BY T.{0}", Entidades.TurnoCalendario.Columnas.FechaDesde.ToString()).AppendLine()
         .AppendFormat("        , T.{0}", Entidades.TurnoCalendario.Columnas.FechaHasta.ToString()).AppendLine()
      End With
   End Sub

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.TurnoCalendario.Columnas.IdTurno.ToString(), "TurnosCalendarios"))
   End Function

   Public Function GetAusentesConTurnos(ByVal idCalendario As Integer, ByVal fecha As DateTime) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .Append("  WHERE ")
         .AppendFormat("	  T.IdCalendario = {0}", idCalendario)
         .AppendFormat("	  AND T.FechaDesde >= '{0} 00:00:00'", fecha.ToString("yyyyMMdd"))
         .AppendFormat("	  AND T.FechaDesde <= '{0} 23:59:59'", fecha.ToString("yyyyMMdd"))
         '  .Append("		AND T.IdTipoTurno = 'A'")
         .Append("		AND T.IdEstadoTurno = 'A'")
         .Append("  ORDER BY T.FechaDesde ASC")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetPresentesConTurnos(ByVal idCalendario As Integer, _
                                       ByVal fecha As DateTime, _
                                       ByVal Efectivo As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine("  WHERE ")
         .AppendFormat("	  T.IdCalendario = {0}", idCalendario)
         .AppendFormat("	  AND T.FechaDesde >= '{0} 00:00:00'", fecha.ToString("yyyyMMdd"))
         .AppendFormat("	  AND T.FechaDesde <= '{0} 23:59:59'", fecha.ToString("yyyyMMdd"))
         '  .AppendLine("		AND T.IdTipoTurno = 'E'")
         .AppendLine("		AND T.IdEstadoTurno = 'E'")

         'If Efectivo Then
         '   .AppendFormat("		AND T.EsEfectivo = {0}", Me.GetStringFromBoolean(Efectivo))
         'Else
         '   .AppendFormat("		AND (T.EsEfectivo = {0} OR T.EsEfectivo is null)", Me.GetStringFromBoolean(Efectivo))
         'End If
         .AppendLine("  ORDER BY T.FechaDesde ASC")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetTurnosxCliente(ByVal IdCliente As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("SELECT T.*, C.CodigoCliente, C.NombreCliente, TT.NombreTipoTurno, CA.NombreCalendario, ET.NombreEstadoTurno").AppendLine()
         ' .AppendLine(", CONVERT(bit, 0) AS Sel").AppendLine()
         .AppendFormat("  FROM TurnosCalendarios AS T").AppendLine()
         .AppendFormat("  LEFT JOIN Clientes C ON C.IdCliente = T.IdCliente").AppendLine()
         .AppendFormat("  LEFT JOIN TiposTurnos TT ON TT.IdTipoTurno = T.IdTipoTurno").AppendLine()
         .AppendFormat("  LEFT JOIN Calendarios CA ON CA.IdCalendario = T.IdCalendario").AppendLine()
         .AppendFormat("  LEFT JOIN EstadosTurnos ET ON ET.IdEstadoTurno = T.IdEstadoTurno").AppendLine()
         .AppendLine("  WHERE ")
         .AppendFormat("	  T.IdCliente = {0}", IdCliente)
         '  .AppendLine("		AND (T.IdTipoTurno = 'E' OR T.IdTipoTurno = 'A')")
         .AppendLine("		AND (T.IdEstadoTurno = 'E' OR T.IdEstadoTurno = 'A')")
         ' .AppendLine("		AND T.EsEfectivo = 0")
         .AppendLine("  ORDER BY T.FechaDesde ASC")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetTurnosxClienteHistorial(ByVal IdCliente As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("SELECT T.*, C.CodigoCliente, C.NombreCliente, TT.NombreTipoTurno, CA.NombreCalendario , ET.NombreEstadoTurno").AppendLine()
         .AppendFormat("  FROM TurnosCalendarios AS T").AppendLine()
         .AppendFormat("  LEFT JOIN Clientes C ON C.IdCliente = T.IdCliente").AppendLine()
         .AppendFormat("  LEFT JOIN TiposTurnos TT ON TT.IdTipoTurno = T.IdTipoTurno").AppendLine()
         .AppendFormat("  LEFT JOIN Calendarios CA ON CA.IdCalendario = T.IdCalendario").AppendLine()
         .AppendFormat("  LEFT JOIN EstadosTurnos ET ON ET.IdEstadoTurno = T.IdEstadoTurno").AppendLine()
         .AppendLine("  WHERE ")
         .AppendFormat("	  T.IdCliente = {0}", IdCliente)
         ' .AppendLine("		AND (T.IdTipoTurno = 'T' OR T.IdTipoTurno = 'C')")
         .AppendLine("		AND (T.IdEstadoTurno = 'T' OR T.IdEstadoTurno = 'C')")
         .AppendLine("  ORDER BY T.FechaDesde ASC")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetAtendidos(ByVal idCalendario As Integer, _
                                      ByVal fecha As DateTime, _
                                      ByVal Efectivo As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine("  WHERE ")
         .AppendFormat("	  T.IdCalendario = {0}", idCalendario)
         .AppendFormat("	  AND T.FechaDesde >= '{0} 00:00:00'", fecha.ToString("yyyyMMdd"))
         .AppendFormat("	  AND T.FechaDesde <= '{0} 23:59:59'", fecha.ToString("yyyyMMdd"))
         ' .AppendLine("		AND T.IdTipoTurno = 'T'")
         .AppendLine("		AND T.IdEstadoTurno = 'T'")
         ' .AppendFormat("		AND T.EsEfectivo = {0}", Me.GetStringFromBoolean(Efectivo))
         .AppendLine("  ORDER BY T.FechaDesde ASC")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TurnosCalendarios_G1xTurno(ByVal IdCliente As Long, _
                                 ByVal idCalendario As Integer, _
                                 ByVal fechaHoraInicio As DateTime, _
                                 ByVal fechaHoraFin As DateTime) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE  T.IdCliente = {0}", IdCliente)
         .AppendFormat("   AND T.IdCalendario = {0}", idCalendario)
         .AppendFormat("   AND T.FechaDesde = '{0}'", Me.ObtenerFecha(fechaHoraInicio, True))
         .AppendFormat("   AND T.FechaHasta = '{0}'", Me.ObtenerFecha(fechaHoraFin, True))
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Sub ActualizarAtencion(idTurno As Integer,
                                 idEstadoTurno As String)
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendFormatLine("UPDATE TurnosCalendarios")
         ' .AppendFormatLine("   SET EsEfectivo = {0} ", Me.GetStringFromBoolean(atendio))
         '   .AppendFormatLine("      ,IdTipoTurno = '{0}'", idTipoTurno)
         .AppendFormatLine("      SET IdEstadoTurno = '{0}'", idEstadoTurno)
         .AppendFormatLine(" WHERE IdTurno = {0}", idTurno)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub ActualizarComprobantePorComprobante(idSucursalActual As Integer,
                                                  idTipoComprobanteActual As String,
                                                  letraActual As String,
                                                  centroEmisorActual As Integer,
                                                  numeroComprobanteActual As Long,
                                                  idSucursalNuevo As Integer,
                                                  idTipoComprobanteNuevo As String,
                                                  letraNuevo As String,
                                                  centroEmisorNuevo As Integer,
                                                  numeroComprobanteNuevo As Long)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}", Entidades.TurnoCalendario.NombreTabla)
         .AppendFormat("   SET {0} =  {1} ", Entidades.TurnoCalendario.Columnas.IdSucursal.ToString(), idSucursalNuevo)
         .AppendFormat("      ,{0} = '{1}'", Entidades.TurnoCalendario.Columnas.IdTipoComprobante.ToString(), idTipoComprobanteNuevo)
         .AppendFormat("      ,{0} = '{1}'", Entidades.TurnoCalendario.Columnas.Letra.ToString(), letraNuevo)
         .AppendFormat("      ,{0} =  {1} ", Entidades.TurnoCalendario.Columnas.CentroEmisor.ToString(), centroEmisorNuevo)
         .AppendFormat("      ,{0} =  {1} ", Entidades.TurnoCalendario.Columnas.NumeroComprobante.ToString(), numeroComprobanteNuevo)

         .AppendFormat("   WHERE {0} =  {1} ", Entidades.TurnoCalendario.Columnas.IdSucursal.ToString(), idSucursalActual)
         .AppendFormat("     AND {0} = '{1}'", Entidades.TurnoCalendario.Columnas.IdTipoComprobante.ToString(), idTipoComprobanteActual)
         .AppendFormat("     AND {0} = '{1}'", Entidades.TurnoCalendario.Columnas.Letra.ToString(), letraActual)
         .AppendFormat("     AND {0} =  {1} ", Entidades.TurnoCalendario.Columnas.CentroEmisor.ToString(), centroEmisorActual)
         .AppendFormat("     AND {0} =  {1} ", Entidades.TurnoCalendario.Columnas.NumeroComprobante.ToString(), numeroComprobanteActual)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Turnos_U_EsEfectivo(idEmbarcacion As Long, idTipoTurno As String)
      If Me._idAplicacionSinergia = "SISEN" Then
         Dim stb As StringBuilder = New StringBuilder()

         With stb
            .AppendFormatLine("UPDATE T")
            .AppendFormatLine("   SET IdEstadoTurno = (SELECT TOP 1 IdEstadoTurno FROM EstadosTurnos E WHERE E.Finalizado = 'True')")
            .AppendFormatLine("  FROM TurnosCalendarios T")
            .AppendFormatLine(" INNER JOIN EstadosTurnos ET ON ET.IdEstadoTurno = T.IdEstadoTurno")
            .AppendFormatLine(" WHERE T.IdEmbarcacion = {0}", idEmbarcacion)
            .AppendFormatLine("   AND T.{0} IN ('{1}')", Eniac.Entidades.TurnoCalendario.Columnas.IdTipoTurno.ToString(), idTipoTurno.Replace(",", "','"))
            .AppendFormatLine("   AND ET.{0} = 'False'", Eniac.Entidades.EstadoTurno.Columnas.Finalizado.ToString())
         End With

         Me.Execute(stb.ToString())
      End If
   End Sub

End Class