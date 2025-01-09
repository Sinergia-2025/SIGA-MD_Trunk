Public Class Vehiculos
    Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Vehiculos_I(patenteVehiculo As String, idMarcaVehiculo As Integer, idModeloVehiculo As Integer, color As String, vencimientoSeguro As Date,
                          ruta As Date?, vtv As Date?, activo As Boolean, estaAdentro As Boolean,            ', IdCliente As Long
                          idTipoUnidad As Integer, subTipoUnidad As String, anioPatentamiento As Integer, medidasVehiculo As String,
                          llantasVehiculo As Entidades.ConcesionarioLlantasVehiculo, auxilioVehiculo As Entidades.Publicos.SiNo, neumaticosVehiculo As String,
                          otrosVehiculo As String, identificacionVehiculo As Entidades.Publicos.SiNo, observacionesVehiculo As String,
                          idEstadoVehiculo As Integer,
                          precioCompra As Decimal, precioReferencia As Decimal, idProductoReferencia As String, precioLista As Decimal,
                          idMarcaOperacionIngreso As Integer?, anioOperacionIngreso As Integer?, numeroOperacionIngreso As Integer?, secuenciaOperacionIngreso As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.Vehiculo.NombreTabla)
         .AppendFormatLine("            {0} ", Entidades.Vehiculo.Columnas.PatenteVehiculo.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.IdMarcaVehiculo.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.IdModeloVehiculo.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.Color.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.VencimientoSeguro.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.Ruta.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.Vtv.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.Activo.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.EstaAdentro.ToString())      'Entidades.Vehiculo.Columnas.IdCliente.ToString(),

         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.IdTipoUnidad.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.SubTipoUnidad.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.AnioPatentamiento.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.MedidasVehiculo.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.LlantasVehiculo.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.AuxilioVehiculo.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.NeumaticosVehiculo.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.OtrosVehiculo.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.IdentificacionVehiculo.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.ObservacionesVehiculo.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.IdEstadoVehiculo.ToString())

         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.PrecioCompra.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.PrecioReferencia.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.IdProductoReferencia.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.PrecioLista.ToString())

         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.IdMarcaOperacionIngreso.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.AnioOperacionIngreso.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.NumeroOperacionIngreso.ToString())
         .AppendFormatLine("          , {0} ", Entidades.Vehiculo.Columnas.SecuenciaOperacionIngreso.ToString())


         .AppendFormatLine("   ) VALUES ('{0}' ", patenteVehiculo)
         .AppendFormatLine("            , {0}  ", idMarcaVehiculo)
         .AppendFormatLine("            , {0}  ", idModeloVehiculo)
         .AppendFormatLine("            ,'{0}' ", color)
         .AppendFormatLine("            ,'{0}' ", vencimientoSeguro)
         .AppendFormatLine("            , {0} ", ObtenerFecha(ruta, False))
         .AppendFormatLine("            , {0} ", ObtenerFecha(vtv, False))

         .AppendFormatLine("            , {0} ", GetStringFromBoolean(activo))
         '.AppendFormatLine("            , {0} ", IdCliente)
         .AppendFormatLine("            , {0} ", GetStringFromBoolean(estaAdentro))

         .AppendFormatLine("            , {0}  ", idTipoUnidad)
         .AppendFormatLine("            ,'{0}' ", subTipoUnidad)
         .AppendFormatLine("            , {0}  ", anioPatentamiento)
         .AppendFormatLine("            ,'{0}' ", medidasVehiculo)
         .AppendFormatLine("            ,'{0}' ", llantasVehiculo)
         .AppendFormatLine("            ,'{0}' ", auxilioVehiculo)
         .AppendFormatLine("            ,'{0}' ", neumaticosVehiculo)
         .AppendFormatLine("            ,'{0}' ", otrosVehiculo)
         .AppendFormatLine("            ,'{0}' ", identificacionVehiculo)
         .AppendFormatLine("            ,'{0}' ", observacionesVehiculo)
         .AppendFormatLine("            , {0}  ", idEstadoVehiculo)

         .AppendFormatLine("            , {0}  ", precioCompra)
         .AppendFormatLine("            , {0}  ", precioReferencia)
         .AppendFormatLine("            , {0}  ", GetStringParaQueryConComillas(idProductoReferencia))
         .AppendFormatLine("            , {0}  ", precioLista)

         .AppendFormatLine("            , {0} ", GetStringFromNumber(idMarcaOperacionIngreso))
         .AppendFormatLine("            , {0} ", GetStringFromNumber(anioOperacionIngreso))
         .AppendFormatLine("            , {0} ", GetStringFromNumber(numeroOperacionIngreso))
         .AppendFormatLine("            , {0} ", GetStringFromNumber(secuenciaOperacionIngreso))

         .AppendFormatLine(" )")
      End With
      Execute(myQuery)
   End Sub

   Public Sub Vehiculos_U(patenteVehiculo As String, idMarcaVehiculo As Integer, idModeloVehiculo As Integer, color As String, vencimientoSeguro As Date,
                          ruta As Date?, vtv As Date?, activo As Boolean, estaAdentro As Boolean,            ', IdCliente As Long
                          idTipoUnidad As Integer, subTipoUnidad As String, anioPatentamiento As Integer, medidasVehiculo As String,
                          llantasVehiculo As Entidades.ConcesionarioLlantasVehiculo, auxilioVehiculo As Entidades.Publicos.SiNo, neumaticosVehiculo As String,
                          otrosVehiculo As String, identificacionVehiculo As Entidades.Publicos.SiNo, observacionesVehiculo As String,
                          idEstadoVehiculo As Integer,
                          precioCompra As Decimal, precioReferencia As Decimal, idProductoReferencia As String, precioLista As Decimal,
                          idMarcaOperacionIngreso As Integer?, anioOperacionIngreso As Integer?, numeroOperacionIngreso As Integer?, secuenciaOperacionIngreso As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.Vehiculo.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.Vehiculo.Columnas.IdMarcaVehiculo.ToString(), idMarcaVehiculo)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Vehiculo.Columnas.IdModeloVehiculo.ToString(), idModeloVehiculo)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Vehiculo.Columnas.Color.ToString(), color)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Vehiculo.Columnas.VencimientoSeguro.ToString(), ObtenerFecha(vencimientoSeguro, False))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Vehiculo.Columnas.Ruta.ToString(), ObtenerFecha(ruta, False))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Vehiculo.Columnas.Vtv.ToString(), ObtenerFecha(vtv, False))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Vehiculo.Columnas.Activo.ToString(), GetStringFromBoolean(activo))
         '.AppendFormat("     , {0} =  {1} ", Entidades.Vehiculo.Columnas.IdCliente.ToString(), IdCliente).AppendLine()
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Vehiculo.Columnas.EstaAdentro.ToString(), GetStringFromBoolean(estaAdentro))

         .AppendFormatLine("     , {0} =  {1} ", Entidades.Vehiculo.Columnas.IdTipoUnidad.ToString(), idTipoUnidad)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Vehiculo.Columnas.SubTipoUnidad.ToString(), subTipoUnidad)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Vehiculo.Columnas.AnioPatentamiento.ToString(), anioPatentamiento)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Vehiculo.Columnas.MedidasVehiculo.ToString(), medidasVehiculo)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Vehiculo.Columnas.LlantasVehiculo.ToString(), llantasVehiculo)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Vehiculo.Columnas.AuxilioVehiculo.ToString(), auxilioVehiculo)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Vehiculo.Columnas.NeumaticosVehiculo.ToString(), neumaticosVehiculo)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Vehiculo.Columnas.OtrosVehiculo.ToString(), otrosVehiculo)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Vehiculo.Columnas.IdentificacionVehiculo.ToString(), identificacionVehiculo)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Vehiculo.Columnas.ObservacionesVehiculo.ToString(), observacionesVehiculo)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Vehiculo.Columnas.IdEstadoVehiculo.ToString(), idEstadoVehiculo)

         .AppendFormatLine("     , {0} =  {1} ", Entidades.Vehiculo.Columnas.PrecioCompra.ToString(), precioCompra)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Vehiculo.Columnas.PrecioReferencia.ToString(), precioReferencia)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Vehiculo.Columnas.IdProductoReferencia.ToString(), GetStringParaQueryConComillas(idProductoReferencia))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Vehiculo.Columnas.PrecioLista.ToString(), precioLista)

         .AppendFormatLine("     , {0} =  {1} ", Entidades.Vehiculo.Columnas.IdMarcaOperacionIngreso.ToString(), GetStringFromNumber(idMarcaOperacionIngreso))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Vehiculo.Columnas.AnioOperacionIngreso.ToString(), GetStringFromNumber(anioOperacionIngreso))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Vehiculo.Columnas.NumeroOperacionIngreso.ToString(), GetStringFromNumber(numeroOperacionIngreso))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Vehiculo.Columnas.SecuenciaOperacionIngreso.ToString(), GetStringFromNumber(secuenciaOperacionIngreso))

         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.Vehiculo.Columnas.PatenteVehiculo.ToString(), patenteVehiculo)
      End With
      Execute(myQuery)
   End Sub
   Public Sub Vehiculos_M(patenteVehiculo As String, idMarcaVehiculo As Integer, idModeloVehiculo As Integer, color As String, vencimientoSeguro As Date,
                          ruta As Date?, vtv As Date?, activo As Boolean, estaAdentro As Boolean,            ', IdCliente As Long
                          idTipoUnidad As Integer, subTipoUnidad As String, anioPatentamiento As Integer, medidasVehiculo As String,
                          llantasVehiculo As Entidades.ConcesionarioLlantasVehiculo, auxilioVehiculo As Entidades.Publicos.SiNo, neumaticosVehiculo As String,
                          otrosVehiculo As String, identificacionVehiculo As Entidades.Publicos.SiNo, observacionesVehiculo As String,
                          idEstadoVehiculo As Integer,
                          precioCompra As Decimal, precioReferencia As Decimal, idProductoReferencia As String, precioLista As Decimal,
                          idMarcaOperacionIngreso As Integer?, anioOperacionIngreso As Integer?, numeroOperacionIngreso As Integer?, secuenciaOperacionIngreso As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO Vehiculos AS D")
         .AppendFormatLine("        USING (SELECT '{0}' PatenteVehiculo, {1} IdMarcaVehiculo, {2} IdModeloVehiculo, '{3}' Color, '{4}' ObservacionesVehiculo",
                           patenteVehiculo, idMarcaVehiculo, idModeloVehiculo, color, observacionesVehiculo)
         .AppendFormatLine("                    , '{0}' VencimientoSeguro, {1} Ruta, {2} Vtv, {3} Activo, {4} EstaAdentro, {5} IdEstadoVehiculo",
                           ObtenerFecha(vencimientoSeguro, False), ObtenerFecha(ruta, False), ObtenerFecha(vtv, False), GetStringFromBoolean(activo), GetStringFromBoolean(estaAdentro), idEstadoVehiculo)
         .AppendFormatLine("                    , {0} IdTipoUnidad, '{1}' SubTipoUnidad, {2} AnioPatentamiento, '{3}' MedidasVehiculo",
                           idTipoUnidad, subTipoUnidad, anioPatentamiento, medidasVehiculo)
         .AppendFormatLine("                    , '{0}' LlantasVehiculo, '{1}' AuxilioVehiculo, '{2}' NeumaticosVehiculo, '{3}' OtrosVehiculo, '{4}' IdentificacionVehiculo",
                           llantasVehiculo, auxilioVehiculo, neumaticosVehiculo, otrosVehiculo, identificacionVehiculo)
         .AppendFormatLine("                    , {0} PrecioCompra , {1} PrecioReferencia, {2} IdProductoReferencia, {3} PrecioLista",
                           precioCompra, precioReferencia, GetStringParaQueryConComillas(idProductoReferencia), precioLista)
         .AppendFormatLine("                    , {0} IdMarcaOperacionIngreso, {1} AnioOperacionIngreso, {2} NumeroOperacionIngreso, {3} SecuenciaOperacionIngreso",
                           GetStringFromNumber(idMarcaOperacionIngreso), GetStringFromNumber(anioOperacionIngreso), GetStringFromNumber(numeroOperacionIngreso), GetStringFromNumber(secuenciaOperacionIngreso))

         .AppendFormatLine("               ) AS O ON D.PatenteVehiculo = O.PatenteVehiculo")
         .AppendFormatLine("    WHEN MATCHED THEN")
         .AppendFormatLine("        UPDATE SET D.PatenteVehiculo                 = O.PatenteVehiculo")
         .AppendFormatLine("                 , D.IdMarcaVehiculo                 = O.IdMarcaVehiculo")
         .AppendFormatLine("                 , D.IdModeloVehiculo                = O.IdModeloVehiculo")
         .AppendFormatLine("                 , D.Color                           = O.Color")
         .AppendFormatLine("                 , D.VencimientoSeguro               = O.VencimientoSeguro")
         .AppendFormatLine("                 , D.Ruta                            = O.Ruta")
         .AppendFormatLine("                 , D.Vtv                             = O.Vtv")
         .AppendFormatLine("                 , D.Activo                          = O.Activo")
         .AppendFormatLine("                 , D.EstaAdentro                     = O.EstaAdentro")
         .AppendFormatLine("                 , D.IdTipoUnidad                    = O.IdTipoUnidad")
         .AppendFormatLine("                 , D.SubTipoUnidad                   = O.SubTipoUnidad")
         .AppendFormatLine("                 , D.AnioPatentamiento               = O.AnioPatentamiento")
         .AppendFormatLine("                 , D.MedidasVehiculo                 = O.MedidasVehiculo")
         .AppendFormatLine("                 , D.LlantasVehiculo                 = O.LlantasVehiculo")
         .AppendFormatLine("                 , D.AuxilioVehiculo                 = O.AuxilioVehiculo")
         .AppendFormatLine("                 , D.NeumaticosVehiculo              = O.NeumaticosVehiculo")
         .AppendFormatLine("                 , D.OtrosVehiculo                   = O.OtrosVehiculo")
         .AppendFormatLine("                 , D.IdentificacionVehiculo          = O.IdentificacionVehiculo")
         .AppendFormatLine("                 , D.ObservacionesVehiculo           = O.ObservacionesVehiculo")
         .AppendFormatLine("                 , D.IdEstadoVehiculo                = O.IdEstadoVehiculo")
         .AppendFormatLine("                 , D.PrecioCompra                    = O.PrecioCompra")
         .AppendFormatLine("                 , D.PrecioReferencia                = O.PrecioReferencia")
         .AppendFormatLine("                 , D.IdProductoReferencia            = O.IdProductoReferencia")
         .AppendFormatLine("                 , D.PrecioLista                     = O.PrecioLista")

         .AppendFormatLine("                 , D.IdMarcaOperacionIngreso         = O.IdMarcaOperacionIngreso")
         .AppendFormatLine("                 , D.AnioOperacionIngreso            = O.AnioOperacionIngreso")
         .AppendFormatLine("                 , D.NumeroOperacionIngreso          = O.NumeroOperacionIngreso")
         .AppendFormatLine("                 , D.SecuenciaOperacionIngreso       = O.SecuenciaOperacionIngreso")

         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormatLine("        INSERT (    PatenteVehiculo,   IdMarcaVehiculo,   IdModeloVehiculo,   Color,   ObservacionesVehiculo")
         .AppendFormatLine("                ,   VencimientoSeguro,   Ruta,   Vtv,   Activo,   EstaAdentro,   IdEstadoVehiculo")
         .AppendFormatLine("                ,   IdTipoUnidad,   SubTipoUnidad,   AnioPatentamiento,   MedidasVehiculo")
         .AppendFormatLine("                ,   LlantasVehiculo,   AuxilioVehiculo,   NeumaticosVehiculo,   OtrosVehiculo,   IdentificacionVehiculo")
         .AppendFormatLine("                ,   PrecioCompra,   PrecioReferencia,   IdProductoReferencia,   PrecioLista")
         .AppendFormatLine("                ,   IdMarcaOperacionIngreso,   AnioOperacionIngreso,   NumeroOperacionIngreso,   SecuenciaOperacionIngreso) VALUES ")
         .AppendFormatLine("               (  O.PatenteVehiculo, O.IdMarcaVehiculo, O.IdModeloVehiculo, O.Color, O.ObservacionesVehiculo")
         .AppendFormatLine("                , O.VencimientoSeguro, O.Ruta, O.Vtv, O.Activo, O.EstaAdentro, O.IdEstadoVehiculo")
         .AppendFormatLine("                , O.IdTipoUnidad, O.SubTipoUnidad, O.AnioPatentamiento, O.MedidasVehiculo")
         .AppendFormatLine("                , O.LlantasVehiculo, O.AuxilioVehiculo, O.NeumaticosVehiculo, O.OtrosVehiculo, O.IdentificacionVehiculo")
         .AppendFormatLine("                , O.PrecioCompra, O.PrecioReferencia, O.IdProductoReferencia, O.PrecioLista")
         .AppendFormatLine("                , O.IdMarcaOperacionIngreso, O.AnioOperacionIngreso, O.NumeroOperacionIngreso, O.SecuenciaOperacionIngreso)")
         .AppendFormatLine(";")
      End With
      Execute(myQuery)
   End Sub

   Public Sub Vehiculos_D(PatenteVehiculo As String)
      Dim myQuery As New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = '{2}'", Entidades.Vehiculo.NombreTabla,
                         Entidades.Vehiculo.Columnas.PatenteVehiculo.ToString(), PatenteVehiculo)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT V.*")
         .AppendFormatLine("     , M.NombreMarcaVehiculo")
         .AppendFormatLine("     , D.NombreModeloVehiculo")
         .AppendFormatLine("     , P.NombreProducto")
         .AppendFormatLine("     , CTU.NombreTipoUnidad")
         .AppendFormatLine("     , EV.NombreEstadoVehiculo")
         .AppendFormatLine("     , (SELECT C.NombreCliente + ' / '")
         .AppendFormatLine("          FROM Clientes C")
         .AppendFormatLine("         INNER JOIN VehiculosClientes VC ON VC.IdCliente = C.IdCliente")
         .AppendFormatLine("         WHERE VC.PatenteVehiculo = V.PatenteVehiculo")
         .AppendFormatLine("         FOR XML PATH('')) AS NombreCliente")
         .AppendFormatLine("     , CO.CodigoOperacion CodigoOperacionIngreso")
         .AppendFormatLine("  FROM {0} AS V  ", Entidades.Vehiculo.NombreTabla)
         .AppendFormatLine(" INNER JOIN MarcasVehiculos M ON v.IdMarcaVehiculo = M.IdMarcaVehiculo ")
         .AppendFormatLine(" INNER JOIN ModelosVehiculos D ON v.IdModeloVehiculo = d.IdModeloVehiculo ")
         .AppendFormatLine("  LEFT JOIN Productos P ON P.IdProducto = V.IdProductoReferencia")
         .AppendFormatLine("  LEFT JOIN ConcesionarioTiposUnidades CTU ON CTU.IdTipoUnidad = V.IdTipoUnidad")
         .AppendFormatLine("  LEFT JOIN EstadosVehiculos EV ON EV.IdEstadoVehiculo = V.IdEstadoVehiculo")
         .AppendFormatLine("  LEFT JOIN ConcesionarioOperaciones CO")
         .AppendFormatLine("         ON CO.IdMarca             = V.IdMarcaOperacionIngreso")
         .AppendFormatLine("        AND CO.AnioOperacion       = V.AnioOperacionIngreso")
         .AppendFormatLine("        AND CO.NumeroOperacion     = V.NumeroOperacionIngreso")
         .AppendFormatLine("        AND CO.SecuenciaOperacion  = V.SecuenciaOperacionIngreso")
         '.AppendLine(" LEFT JOIN Clientes C on v.IdCliente = c.IdCliente ")

      End With
   End Sub

   Public Function Vehiculos_GA() As DataTable
        Return Vehiculos_G(PatenteVehiculo:="")
    End Function

   Private Function Vehiculos_G(PatenteVehiculo As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(PatenteVehiculo) Then
            .AppendFormat("   AND V.PatenteVehiculo = '{0}'", PatenteVehiculo).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function Vehiculos_G1(PatenteVehiculo As String) As DataTable
      Return Vehiculos_G(PatenteVehiculo:=PatenteVehiculo)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable

      columna = "V." + columna

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return GetDataTable(stb)
   End Function
   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.Vehiculo.Columnas.PatenteVehiculo.ToString(), "Vehiculos"))
   End Function

   Public Function GetFiltradoPorPatente(codigoPatente As String, idCliente As Long, soloActivos As Boolean, conOperacionIngreso As Entidades.Publicos.SiNoTodos) As DataTable
      Dim stb = New StringBuilder()
      SelectTexto(stb)
      With stb
         .AppendFormatLine(" WHERE 1 = 1")
         If soloActivos Then
            .AppendFormatLine("   AND V.Activo = 1 ")
         End If
         If Not String.IsNullOrWhiteSpace(codigoPatente) Then
            .AppendFormatLine("   AND V.PatenteVehiculo LIKE '%{0}%'", codigoPatente)
         End If
         If idCliente <> 0 Then
            .AppendFormat("   AND EXISTS (SELECT * FROM VehiculosClientes VC WHERE VC.PatenteVehiculo = V.PatenteVehiculo AND VC.idCliente = {0})", idCliente)
         End If
         If conOperacionIngreso <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND V.NumeroOperacionIngreso IS {0} NULL", If(conOperacionIngreso = Entidades.Publicos.SiNoTodos.SI, "NOT", ""))
         End If
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetFiltradoPorCliente(idCliente As Long, soloActivos As Boolean) As DataTable
      Dim stb = New StringBuilder()

      SelectTexto(stb)
      With stb
         If soloActivos Then
            .AppendLine(" WHERE V.Activo = 1 ")
         Else
            .AppendLine(" WHERE 1=1 ")
         End If
         .AppendFormat(" AND EXISTS (SELECT * FROM VehiculosClientes VC WHERE VC.PatenteVehiculo = V.PatenteVehiculo AND VC.idCliente = {0})", idCliente)
      End With

      Return GetDataTable(stb)
   End Function

   Public Sub Vehiculos_U_OperacionIngreso(patenteVehiculo As String,
                                           idMarcaOperacionIngreso As Integer?, anioOperacionIngreso As Integer?, numeroOperacionIngreso As Integer?, secuenciaOperacionIngreso As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE Vehiculos")
         .AppendFormatLine("   SET IdMarcaOperacionIngreso   =  {0} ", GetStringFromNumber(idMarcaOperacionIngreso))
         .AppendFormatLine("      ,AnioOperacionIngreso      =  {0} ", GetStringFromNumber(anioOperacionIngreso))
         .AppendFormatLine("      ,NumeroOperacionIngreso    =  {0} ", GetStringFromNumber(numeroOperacionIngreso))
         .AppendFormatLine("      ,SecuenciaOperacionIngreso =  {0} ", GetStringFromNumber(secuenciaOperacionIngreso))
         .AppendFormatLine(" WHERE PatenteVehiculo           = '{0}'", patenteVehiculo)
         If idMarcaOperacionIngreso.HasValue Then
            .AppendFormatLine("   AND IdMarcaOperacionIngreso   IS NULL")
         End If
      End With
      Execute(myQuery)

   End Sub

End Class