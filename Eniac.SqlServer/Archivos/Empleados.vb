Public Class Empleados
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Empleados_I(tipoDocEmpleado As String,
                          nroDocEmpleado As String,
                          nombreEmpleado As String,
                          telefonoEmpleado As String,
                          celularEmpleado As String,
                          esVendedor As Boolean,
                          esComprador As Boolean,
                          esCobrador As Boolean,
                          idUsuario As String,
                          idUsuarioMovil As String,
                          comisionPorVenta As Decimal,
                          direccion As String,
                          idLocalidad As Integer,
                          geoLocalizacionLat As Double,
                          geoLocalizacionLng As Double,
                          idEmpleado As Integer,
                          color As Integer?,
                          nivelAutorizacion As Short,
                          clave As String,
                          debitoDirecto As Boolean,
                          idBanco As Integer,
                          idDispositivo As String,
                          debitoTarjeta As Boolean,
                          idTarjeta As Integer,
                          esChofer As Boolean,
                          idTransportista As Integer,
                          esRespProd As Boolean,
                          idCategoriaEmp As Integer,
                          valorHorasProd As Decimal,
                          cobraPremioCobranza As Boolean,
                          entidadCobranza As String)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("INSERT INTO Empleados  ")
         .AppendLine("   (TipoDocEmpleado ")
         .AppendLine("   ,NroDocEmpleado ")
         .AppendLine("   ,NombreEmpleado ")
         .AppendLine("   ,TelefonoEmpleado ")
         .AppendLine("   ,CelularEmpleado ")
         .AppendLine("   ,EsVendedor ")
         .AppendLine("   ,EsComprador ")
         .AppendLine("   ,EsCobrador ")
         '-- REQ37326.- ---------------------
         .AppendLine("   ,EsRespProd ")
         '-- REQ33530.- ---------------------
         .AppendLine("   ,EsChofer")
         .AppendLine("   ,IdTransportista")
         '-----------------------------------
         .AppendLine("   ,IdUsuario ")
         .AppendLine("   ,IdUsuarioMovil ")
         .AppendLine("   ,ComisionPorVenta ")
         .AppendLine("   ,Direccion ")
         .AppendLine("   ,IdLocalidad ")
         .AppendLine("   ,GeoLocalizacionLat")
         .AppendLine("   ,GeoLocalizacionLng")
         .AppendLine("   ,IdEmpleado")
         .AppendLine("   ,Color")
         .AppendLine("   ,NivelAutorizacion")
         .AppendLine("   ,Clave")
         .AppendLine("   ,DebitoDirecto")
         .AppendLine("   ,idBanco")
         .AppendLine("   ,IdDispositivo")
         '-.PE-31509.-
         .AppendLine("  ,DebitoTarjeta")
         .AppendLine("  ,IdTarjeta")
         '-- REQ38946.- ---------------------
         .AppendLine("   ,IdCategoriaEmpleado")
         .AppendLine("   ,ValorHoraProd")
         '-- REQ-42860.- ---------------------
         .AppendLine("   ,CobraPremioCobranza")
         '-- REQ-43851.- ---------------------
         .AppendLine("   ,EntidadCobranza")
         '-----------------------------------


         .AppendLine(" ) VALUES ( ")
         .AppendFormatLine("    '{0}'", tipoDocEmpleado)
         .AppendFormatLine("   ,'{0}'", nroDocEmpleado)
         .AppendFormatLine("   ,'{0}'", nombreEmpleado)
         .AppendFormatLine("   ,'{0}'", telefonoEmpleado)
         .AppendFormatLine("   ,'{0}'", celularEmpleado)
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(esVendedor))
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(esComprador))
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(esCobrador))
         '-- REQ37326.- --------------------------------------------------------
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(esRespProd))
         '-- REQ33530.- --------------------------------------------------------
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(esChofer))
         If idTransportista <> 0 Then
            .AppendFormatLine("    , {0}", idTransportista)
         Else
            .AppendLine("    , NULL")
         End If
         '----------------------------------------------------------------------
         .AppendFormatLine("   , {0} ", GetStringParaQueryConComillas(idUsuario))
         .AppendFormatLine("   , {0} ", GetStringParaQueryConComillas(idUsuarioMovil))

         .AppendFormatLine("   , {0} ", comisionPorVenta)
         .AppendFormatLine("   ,'{0}'", direccion)
         .AppendFormatLine("   , {0} ", idLocalidad)
         .AppendFormatLine("   , {0} ", If(geoLocalizacionLat > 0, geoLocalizacionLat.ToString(), "NULL"))
         .AppendFormatLine("   , {0} ", If(geoLocalizacionLng > 0, geoLocalizacionLng.ToString(), "NULL"))

         .AppendFormatLine("   , {0} ", idEmpleado)
         .AppendFormatLine("   , {0} ", GetStringFromNumber(color))
         .AppendFormatLine("   , {0} ", nivelAutorizacion)
         .AppendFormatLine("   ,'{0}'", clave)
         .AppendLine("   ,'" & GetStringFromBoolean(debitoDirecto) & "'")
         If debitoDirecto Then
            .AppendLine("   ," & idBanco)
         Else
            .AppendLine("   ,NULL")
         End If
         If Not String.IsNullOrWhiteSpace(idDispositivo) Then
            .AppendFormat("   ,'{0}'", idDispositivo).AppendLine()
         Else
            .AppendLine("   ,NULL")
         End If

         '-.PE-31509.-
         .AppendLine("  ,'" & GetStringFromBoolean(debitoTarjeta) & "'")
         If debitoTarjeta Then
            .AppendLine("  ," & idTarjeta)
         Else
            .AppendLine("  ,NULL")
         End If
         '-- REQ38946.- --------------------------------------------------------
         If idCategoriaEmp <> 0 Then
            .AppendFormatLine("    , {0}", idCategoriaEmp)
         Else
            .AppendLine("    , NULL")
         End If
         If valorHorasProd <> 0 Then
            .AppendFormatLine("    , {0}", valorHorasProd)
         Else
            .AppendLine("    , NULL")
         End If
         '-- REQ-42860.- -------------------------------------------------------
         .AppendLine("  ,'" & GetStringFromBoolean(cobraPremioCobranza) & "'")
         '-- REQ-43851.- -------------------------------------------------------
         .AppendLine("  ,'" & entidadCobranza & "'")
         '----------------------------------------------------------------------
         .Append(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Empleados")
   End Sub

   Public Sub Empleados_U(tipoDocEmpleado As String,
                          nroDocEmpleado As String,
                          nombreEmpleado As String,
                          telefonoEmpleado As String,
                          celularEmpleado As String,
                          esVendedor As Boolean,
                          esComprador As Boolean,
                          esCobrador As Boolean,
                          idUsuario As String,
                          idUsuarioMovil As String,
                          comisionPorVenta As Decimal,
                          direccion As String,
                          idLocalidad As Integer,
                          geoLocalizacionLat As Double,
                          geoLocalizacionLng As Double,
                          idEmpleado As Integer,
                          color As Integer?,
                          nivelAutorizacion As Short,
                          clave As String,
                          debitoDirecto As Boolean,
                          idBanco As Integer,
                          idDispositivo As String,
                          debitoTarjeta As Boolean,
                          idTarjeta As Integer,
                          esChofer As Boolean,
                          idTransportista As Integer,
                          esRespProd As Boolean,
                          idCategoriaEmp As Integer,
                          valorHorasProd As Decimal,
                          cobraPremioCobranza As Boolean,
                          entidadCobranza As String)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE Empleados")

         .AppendFormatLine("   SET NombreEmpleado = '{0}'", nombreEmpleado)
         .AppendFormatLine("      ,TelefonoEmpleado = '{0}'", telefonoEmpleado)
         .AppendFormatLine("      ,CelularEmpleado = '{0}'", celularEmpleado)
         .AppendFormatLine("      ,EsVendedor = {0}", GetStringFromBoolean(esVendedor))
         .AppendFormatLine("      ,EsComprador = {0}", GetStringFromBoolean(esComprador))
         .AppendFormatLine("      ,EsCobrador = {0}", GetStringFromBoolean(esCobrador))
         '-- REQ-37326.- -------------------------------------------------------------------------
         .AppendFormatLine("      ,EsRespProd = {0}", GetStringFromBoolean(esRespProd))
         '-- REQ-33530.- -------------------------------------------------------------------------
         .AppendFormatLine("      ,EsChofer = {0}", GetStringFromBoolean(esChofer))
         If idTransportista <> 0 Then
            .AppendLine("  ,idTransportista = " & idTransportista)
         Else
            .AppendLine("  ,idTransportista = NULL")
         End If
         '----------------------------------------------------------------------------------------

         .AppendFormatLine("      ,IdUsuario = {0} ", GetStringParaQueryConComillas(idUsuario))
         .AppendFormatLine("      ,IdUsuarioMovil = {0} ", GetStringParaQueryConComillas(idUsuarioMovil))

         .AppendFormatLine("      ,ComisionPorVenta = {0}", comisionPorVenta)
         .AppendFormatLine("      ,Direccion = '{0}'", direccion)
         .AppendFormatLine("      ,IdLocalidad = {0}", idLocalidad)

         .AppendFormatLine("      ,GeoLocalizacionLat = {0} ", If(geoLocalizacionLat > 0, geoLocalizacionLat.ToString(), "NULL"))
         .AppendFormatLine("      ,GeoLocalizacionLng = {0} ", If(geoLocalizacionLng > 0, geoLocalizacionLng.ToString(), "NULL"))

         .AppendFormatLine("      ,TipoDocEmpleado = '{0}'", tipoDocEmpleado)

         .AppendFormatLine("      ,NroDocEmpleado = '{0}'", nroDocEmpleado)

         .AppendFormatLine("      ,Color = {0} ", GetStringFromNumber(color))

         .AppendFormatLine("      ,NivelAutorizacion = {0}", nivelAutorizacion)
         .AppendFormatLine("      ,Clave = '{0}'", clave)

         .AppendLine("   ,DebitoDirecto = '" & GetStringFromBoolean(debitoDirecto) & "'")
         '-- REQ-42860.- -----------------------------------------------------------------------------
         .AppendLine("   ,CobraPremioCobranza = '" & GetStringFromBoolean(cobraPremioCobranza) & "'")
         '--------------------------------------------------------------------------------------------
         If debitoDirecto Then
            .AppendLine("   ,idBanco = " & idBanco)
         Else
            .AppendLine("   ,idBanco = NULL")
         End If
         If Not String.IsNullOrWhiteSpace(idDispositivo) Then
            .AppendFormat("   ,IdDispositivo = '{0}'", idDispositivo).AppendLine()
         Else
            .AppendLine("   ,IdDispositivo = NULL")
         End If

         '-.PE-31509.-
         .AppendLine("  ,DebitoTarjeta = '" & GetStringFromBoolean(debitoTarjeta) & "'")
         If debitoTarjeta Then
            .AppendLine("  ,idTarjeta = " & idTarjeta)
         Else
            .AppendLine("  ,idTarjeta = NULL")
         End If

         '-- REQ-33530.- -------------------------------------------------------------------------
         If idCategoriaEmp <> 0 Then
            .AppendLine("  ,idCategoriaEmpleado = " & idCategoriaEmp)
         Else
            .AppendLine("  ,idCategoriaEmpleado = NULL")
         End If
         If valorHorasProd <> 0 Then
            .AppendLine("  ,ValorHoraProd = " & valorHorasProd)
         Else
            .AppendLine("  ,ValorHoraProd = NULL")
         End If
         '-- REQ-43851.- -------------------------------------------------------------------------
         .AppendFormat("   ,EntidadCobranza = '{0}'", entidadCobranza)
         '----------------------------------------------------------------------------------------

         .AppendFormatLine(" WHERE IdEmpleado = {0}", idEmpleado)

      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Empleados")
   End Sub

   Public Sub Empleados_D(ByVal IdEmpleado As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM Empleados")
         .AppendFormatLine(" WHERE IdEmpleado = {0}", IdEmpleado)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Empleados")
   End Sub

   Protected Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT E.*")
         .AppendFormatLine("      ,L.NombreLocalidad")
         .AppendFormatLine("      ,B.NombreBanco")
         .AppendFormatLine("      ,CS.IdCaja")
         .AppendFormatLine("      ,CN.NombreCaja")
         .AppendFormatLine("      ,CS.Observacion")
         '-.PE-31509.-
         .AppendFormatLine("      ,T.NombreTarjeta")
         '- REQ-38946.-
         .AppendFormatLine("      ,CE.CodigoCategoriaEmpleado as CodigoCategoria")
         .AppendFormatLine("      ,CE.Descripcion AS DescripcionCategoria")

         .AppendFormatLine("  FROM Empleados E")
         .AppendFormatLine("  LEFT JOIN Localidades L ON L.IdLocalidad = E.IdLocalidad ")
         .AppendFormatLine("  LEFT JOIN Bancos B ON B.Idbanco = E.IdBanco")
         .AppendFormatLine("  LEFT JOIN EmpleadosSucursales CS ON CS.IdEmpleado = E.IdEmpleado AND CS.IdSucursal = {0}", actual.Sucursal.Id)
         .AppendFormatLine("  LEFT JOIN CajasNombres CN ON CN.IdSucursal = CS.IdSucursal AND CN.IdCaja = CS.IdCaja")
         '-.PE-31509.-
         .AppendFormatLine("  LEFT JOIN Tarjetas T ON T.IdTarjeta = E.IdTarjeta")
         '- REQ-38946.-
         .AppendFormatLine("  LEFT JOIN MRPCategoriasEmpleados CE ON CE.IdCategoriaEmpleado = E.IdCategoriaEmpleado")
      End With
   End Sub

   Public Function Empleados_G1_PorClave(clave As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE Clave = '{0}'", clave)
         .AppendFormatLine(" ORDER BY NombreEmpleado")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function Empleados_G1(IdEmpleado As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         SelectTexto(myQuery)
         If IdEmpleado > 0 Then
            .AppendFormatLine(" WHERE E.IdEmpleado = {0}", IdEmpleado)
         End If
         .AppendFormatLine(" ORDER BY NombreEmpleado")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Function Empleados_Buscador(IdEmpleado As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("SELECT E.IdEmpleado, E.NombreEmpleado, E.EsVendedor, E.EsComprador, E.EsCobrador")
         .AppendFormatLine("  FROM Empleados E")

         If IdEmpleado > 0 Then
            .AppendFormatLine(" WHERE E.IdEmpleado = {0}", IdEmpleado)
         End If
         .AppendFormatLine(" ORDER BY E.NombreEmpleado")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function Empleados_G(tipoDocEmpleado As String, nroDocEmpleado As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE E.TipoDocEmpleado = '{0}'", tipoDocEmpleado)
         .AppendFormatLine("   AND E.NroDocEmpleado = '{0}'", nroDocEmpleado)
         .AppendFormatLine(" ORDER BY NombreEmpleado")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function Empleados_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" ORDER BY NombreEmpleado")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function Empleados_GA(tipoEmpleado As Entidades.Publicos.TiposEmpleados,
                                idUsuario As String,
                                nombreExacto As String,
                                nombreParcial As String,
                                conDebitoTarjeta As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If tipoEmpleado = Entidades.Publicos.TiposEmpleados.VENDEDOR Then
            .AppendLine(" AND E.EsVendedor = 'True'")
         ElseIf tipoEmpleado = Entidades.Publicos.TiposEmpleados.COMPRADOR Then
            .AppendLine(" AND E.EsComprador = 'True'")
         ElseIf tipoEmpleado = Entidades.Publicos.TiposEmpleados.COBRADOR Then
            .AppendLine(" AND E.EsCobrador = 'True'")
         ElseIf tipoEmpleado = Entidades.Publicos.TiposEmpleados.RESPPROD Then
            .AppendLine(" AND E.EsRespProd = 'True'")
            ' no filtro
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendFormatLine(" AND E.IdUsuario = '{0}'", idUsuario)
         End If

         If Not String.IsNullOrEmpty(nombreExacto) Then
            .AppendFormatLine(" AND E.NombreEmpleado = '{0}'", nombreExacto)
         End If

         If Not String.IsNullOrEmpty(nombreParcial) Then
            .AppendFormatLine(" AND E.NombreEmpleado LIKE '%{0}%'", nombreParcial)
         End If

         If conDebitoTarjeta Then
            .AppendFormatLine(" AND E.DebitoTarjeta = 'True'")
         End If

         .AppendLine(" ORDER BY E.NombreEmpleado")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      If columna = "NombreLocalidad" Then
         columna = "L." + columna
      Else
         columna = "E." + columna
      End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Empleados_GetIdMaximo() As Integer
      Return Empleados_GetIdMaximo("IdEmpleado")
   End Function

   'Public Function Empleados_GetIdMaximo(campo As String) As Integer
   '   Return Empleados_GetIdMaximo(campo)
   'End Function

   Public Function Empleados_GetIdMaximo(campo As String) As Integer
      Return Convert.ToInt32(GetCodigoMaximo(campo, "Empleados"))
   End Function

   Public Function GetVendedoresDelCliente(idCliente As Long) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         SelectTexto(myQuery)
         .AppendLine("  INNER JOIN MovilRutas AS R ON R.IdVendedor = E.IdEmpleado ")
         .AppendLine("  INNER JOIN MovilRutasClientes AS RC ON RC.IdRuta = R.IdRuta")
         .AppendLine(" WHERE E.EsVendedor = 1")
         .AppendLine("   AND RC.IdCliente = " + idCliente.ToString())
         .AppendLine(" ORDER BY NombreEmpleado")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetUnCobrador() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("SELECT E.*")
         .AppendLine("  FROM Empleados E")
         .AppendLine(" WHERE E.EsCobrador = 1")
         .AppendLine(" ORDER BY NombreEmpleado")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function


   Public Function Empleados_DebitosDirectos() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append("  WHERE E.DebitoDirecto = 'True' ")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Chofer_Transportista(idTransportista As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .AppendLine(" SELECT E.IdEmpleado, E.NombreEmpleado, Direccion, TelefonoEmpleado")
         .AppendLine(" FROM Empleados as E")
         .AppendLine(" WHERE E.EsChofer = 1")
         .AppendFormatLine(" AND E.IdTRansportista = {0}", idTransportista)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Empleados_GetPrimerIdEmpleado() As Integer
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT TOP 1 E.IdEmpleado")
         .AppendLine("  FROM Empleados E")
      End With
      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      Return Integer.Parse(dt.Rows(0).Item("IdEmpleado").ToString())
   End Function

   Public Function GetTop1() As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT TOP(1) IdEmpleado FROM Empleados WHERE EsCobrador = 'True'")
      End With
      Return Me.GetDataTable(query.ToString())
   End Function
End Class