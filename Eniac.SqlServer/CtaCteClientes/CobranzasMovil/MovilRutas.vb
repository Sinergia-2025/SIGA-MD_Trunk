Public Class MovilRutas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub MovilRutas_I(idMovilRuta As Integer, nombreMovilRuta As String, activa As Boolean, idDispositivoPorDefecto As String,
                           idVendedor As Integer, idTransportista As Integer,
                           puedeModificarPrecio As Boolean, precioConImpuestos As Boolean, usuario As String,
                           permiteIngresarPorcentajeDescuentos As Boolean, permiteCobroParcial As Boolean,
                           esDeCobranza As Boolean, esDePedidos As Boolean, esDeGestion As Boolean,
                           configuraClienteSegun As Entidades.OrigenConfiguraClienteSegun, descuentoMax As Decimal, recargaMax As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.MovilRuta.NombreTabla).AppendLine()
         .AppendFormatLine("           ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16})",
                           Entidades.MovilRuta.Columnas.IdRuta.ToString(),
                           Entidades.MovilRuta.Columnas.NombreRuta.ToString(),
                           Entidades.MovilRuta.Columnas.Activa.ToString(),
                           Entidades.MovilRuta.Columnas.IdDispositivoPorDefecto.ToString(),
                           Entidades.MovilRuta.Columnas.IdVendedor.ToString(),
                           Entidades.MovilRuta.Columnas.IdTransportista.ToString(),
                           Entidades.MovilRuta.Columnas.PuedeModificarPrecio.ToString(),
                           Entidades.MovilRuta.Columnas.PrecioConImpuestos.ToString(),
                           Entidades.MovilRuta.Columnas.Usuario.ToString(),
                           Entidades.MovilRuta.Columnas.PermiteIngresarPorcentajeDescuentos.ToString(),
                           Entidades.MovilRuta.Columnas.PermiteCobroParcial.ToString(),
                           Entidades.MovilRuta.Columnas.EsDeCobranza.ToString(),
                           Entidades.MovilRuta.Columnas.EsDePedidos.ToString(),
                           Entidades.MovilRuta.Columnas.EsDeGestion.ToString(),
                           Entidades.MovilRuta.Columnas.ConfiguraClienteSegun.ToString(),
                           Entidades.MovilRuta.Columnas.DescuentoMax.ToString(),
                           Entidades.MovilRuta.Columnas.RecargaMax.ToString())
         .AppendFormatLine("    VALUES ({0}, '{1}', {2}, '{3}', {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, '{14}', {15}, {16}",
                       idMovilRuta, nombreMovilRuta, GetStringFromBoolean(activa), idDispositivoPorDefecto,
                       idVendedor, GetStringFromNumber(idTransportista),
                       GetStringFromBoolean(puedeModificarPrecio), GetStringFromBoolean(precioConImpuestos), GetStringParaQueryConComillas(usuario),
                       GetStringFromBoolean(permiteIngresarPorcentajeDescuentos), GetStringFromBoolean(permiteCobroParcial),
                       GetStringFromBoolean(esDeCobranza), GetStringFromBoolean(esDePedidos), GetStringFromBoolean(esDeGestion),
                       configuraClienteSegun.ToString(), GetStringFromDecimal(descuentoMax), GetStringFromDecimal(recargaMax))
         .AppendLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub MovilRutas_U(idMovilRuta As Integer, nombreMovilRuta As String, activa As Boolean, idDispositivoPorDefecto As String,
                           idVendedor As Integer, idTransportista As Integer,
                           puedeModificarPrecio As Boolean, precioConImpuestos As Boolean, usuario As String,
                           permiteIngresarPorcentajeDescuentos As Boolean, permiteCobroParcial As Boolean,
                           esDeCobranza As Boolean, esDePedidos As Boolean, esDeGestion As Boolean,
                           configuraClienteSegun As Entidades.OrigenConfiguraClienteSegun, descuentoMax As Decimal, recargaMax As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0} ", Entidades.MovilRuta.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.MovilRuta.Columnas.NombreRuta.ToString(), nombreMovilRuta)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.MovilRuta.Columnas.Activa.ToString(), GetStringFromBoolean(activa))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.MovilRuta.Columnas.IdDispositivoPorDefecto.ToString(), idDispositivoPorDefecto)
         .AppendFormatLine("     , {0} =  {1}", Entidades.MovilRuta.Columnas.IdVendedor.ToString(), idVendedor)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.MovilRuta.Columnas.IdTransportista.ToString(), GetStringFromNumber(idTransportista))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.MovilRuta.Columnas.PuedeModificarPrecio.ToString(), GetStringFromBoolean(puedeModificarPrecio))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.MovilRuta.Columnas.PrecioConImpuestos.ToString(), GetStringFromBoolean(precioConImpuestos))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.MovilRuta.Columnas.Usuario.ToString(), GetStringParaQueryConComillas(usuario))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.MovilRuta.Columnas.PermiteIngresarPorcentajeDescuentos.ToString(), GetStringFromBoolean(permiteIngresarPorcentajeDescuentos))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.MovilRuta.Columnas.PermiteCobroParcial.ToString(), GetStringFromBoolean(permiteCobroParcial))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.MovilRuta.Columnas.EsDeCobranza.ToString(), GetStringFromBoolean(esDeCobranza))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.MovilRuta.Columnas.EsDePedidos.ToString(), GetStringFromBoolean(esDePedidos))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.MovilRuta.Columnas.EsDeGestion.ToString(), GetStringFromBoolean(esDeGestion))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.MovilRuta.Columnas.ConfiguraClienteSegun.ToString(), configuraClienteSegun)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.MovilRuta.Columnas.DescuentoMax.ToString(), GetStringFromDecimal(descuentoMax))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.MovilRuta.Columnas.RecargaMax.ToString(), GetStringFromDecimal(recargaMax))
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.MovilRuta.Columnas.IdRuta.ToString(), idMovilRuta)
      End With
      Execute(myQuery)
   End Sub

   Public Sub MovilRutas_D(idMovilRuta As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}",
                       Entidades.MovilRuta.NombreTabla, Entidades.MovilRuta.Columnas.IdRuta.ToString(), idMovilRuta)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT MR.*, E.NombreEmpleado AS NombreVendedor, E.IdUsuarioMovil AS IdUsuarioMovilVendedor, T.NombreTransportista")
         .AppendFormatLine("  FROM {0} AS MR", Entidades.MovilRuta.NombreTabla)
         .AppendFormatLine("  LEFT JOIN Empleados E ON E.IdEmpleado = MR.IdVendedor ")
         .AppendFormatLine("  LEFT JOIN Transportistas T ON T.IdTransportista = MR.IdTransportista")
      End With
   End Sub

   Public Function MovilRutas_GA() As DataTable
      Return MovilRutas_G(idMovilRuta:=0, nombreMovilRuta:=String.Empty, nombreExacto:=False, activa:=Nothing, IdVendedor:=0)
   End Function
   Public Function MovilRutas_GA(activa As Boolean?) As DataTable
      Return MovilRutas_G(idMovilRuta:=0, nombreMovilRuta:=String.Empty, nombreExacto:=False, activa:=activa, IdVendedor:=0)
   End Function
   Public Function MovilRutas_GA(IdVendedor As Integer) As DataTable
      Return MovilRutas_G(idMovilRuta:=0, nombreMovilRuta:=String.Empty, nombreExacto:=False, activa:=True, IdVendedor:=IdVendedor)
   End Function

   Public Function GetClientesRutas(idRuta As Integer, idCliente As Long, idCobrador As Integer, IdVendedor As Integer, dia As Entidades.Publicos.Dias?) As DataTable
      Return GetClientesRutas(idRuta, idCliente, idCobrador, IdVendedor, dia, -1)
   End Function

   Public Function GetUsuariosRutas() As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT COUNT(Distinct(IdVendedor)) as Cantidad FROM MovilRutas WHERE Activa = 1 AND IdVendedor IS NOT NULL")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetClientesRutas(idRuta As Integer, idCliente As Long, idCobrador As Integer, idVendedor As Integer, dia As Entidades.Publicos.Dias?, idLocalidad As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("         SELECT MRC.IdRuta")
         .AppendLine("                ,MR.NombreRuta")
         .AppendLine("                ,CB.NombreEmpleado AS Cobrador")
         .AppendLine("                ,E.NombreEmpleado AS Vendedor")
         .AppendLine("                ,E.IdUsuarioMovil AS IdUsuarioMovilVendedor")
         .AppendLine("                ,MRC.Dia")
         .AppendLine("                ,MRC.Orden")
         .AppendLine("                ,Cl.CodigoCliente")
         .AppendLine("                ,MRC.IdCliente")
         .AppendLine("                ,Cl.NombreCliente")
         .AppendLine("                ,Cl.Direccion")
         .AppendLine("                ,Cl.Telefono")
         .AppendLine("                ,LC.NombreLocalidad")
         .AppendLine("         FROM MovilRutasClientes AS MRC")
         .AppendLine("                     LEFT JOIN MovilRutas AS MR ON MRC.IdRuta = MR.IdRuta")
         .AppendLine("                     LEFT JOIN Clientes AS Cl ON MRC.IdCliente = Cl.IdCliente")
         .AppendLine("                     LEFT JOIN Empleados AS E ON E.IdEmpleado = Cl.IdVendedor")
         .AppendLine("                     LEFT JOIN Empleados AS CB ON Cl.IdCobrador = CB.IdEmpleado")
         .AppendLine("                     LEFT JOIN Localidades AS LC ON LC.IdLocalidad = CL.IdLocalidad")
         .AppendFormatLine(" WHERE 1 = 1")
         .AppendFormatLine("      AND E.EsVendedor = 1")
         If idRuta > 0 Then
            .AppendFormatLine("   AND MRC.IdRuta = {0}", idRuta)
         End If
         If idCliente > 0 Then
            .AppendFormatLine("   AND MRC.idCliente = {0}", idCliente)
         End If
         If dia.HasValue Then
            .AppendFormatLine("   AND MRC.Dia = {0}", CInt(dia.Value))
         End If
         If idCobrador > 0 Then
            .AppendFormatLine("   AND Cl.IdCobrador = {0}", idCobrador)
         End If
         If idVendedor > 0 Then
            .AppendFormatLine("   AND Cl.IdVendedor = '{0}'", idVendedor)
         End If

         If idLocalidad > 0 Then
            .AppendFormatLine("   AND Cl.IdLocalidad = '{0}'", idLocalidad)
         End If
      End With

      Return GetDataTable(stb)

   End Function
   Private Function MovilRutas_G(idMovilRuta As Integer, nombreMovilRuta As String, nombreExacto As Boolean, activa As Boolean?,
                                 IdVendedor As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idMovilRuta > 0 Then
            .AppendFormatLine("   AND MR.{0} = {1}", Entidades.MovilRuta.Columnas.IdRuta.ToString(), idMovilRuta)
         End If
         If Not String.IsNullOrWhiteSpace(nombreMovilRuta) Then
            If nombreExacto Then
               .AppendFormatLine("   AND MR.{0} = '{1}'", Entidades.MovilRuta.Columnas.NombreRuta.ToString(), nombreMovilRuta)
            Else
               .AppendFormatLine("   AND MR.{0} LIKE '%{1}%'", Entidades.MovilRuta.Columnas.NombreRuta.ToString(), nombreMovilRuta)
            End If
         End If
         If IdVendedor > 0 Then
            .AppendFormatLine("   AND MR.{0} = '{1}'", Entidades.MovilRuta.Columnas.IdVendedor.ToString(), IdVendedor)
         End If

         If activa.HasValue Then
            .AppendFormatLine("   AND MR.{0} = {1}", Entidades.MovilRuta.Columnas.Activa.ToString(), GetStringFromBoolean(activa.Value))
         End If
         .AppendFormatLine(" ORDER BY MR.{0}", Entidades.MovilRuta.Columnas.NombreRuta.ToString())
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function MovilRutas_G_PorNombre(nombreMovilRuta As String) As DataTable
      Return MovilRutas_G(idMovilRuta:=0, nombreMovilRuta:=nombreMovilRuta, nombreExacto:=False, activa:=Nothing, IdVendedor:=0)
   End Function
   Public Function MovilRutas_G1(idMovilRuta As Integer) As DataTable
      Return MovilRutas_G(idMovilRuta:=idMovilRuta, nombreMovilRuta:=String.Empty, nombreExacto:=False, activa:=Nothing, IdVendedor:=0)
   End Function
   Public Function MovilRutas_G_Vendedor(IdVendedor As Integer) As DataTable
      Return MovilRutas_G(idMovilRuta:=0, nombreMovilRuta:=String.Empty, nombreExacto:=False, activa:=Nothing, IdVendedor:=IdVendedor)
   End Function
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      If columna = "NombreVendedor" Then
         columna = "E.NombreEmpleado"
      ElseIf columna = "NombreTransportista" Then
         columna = "T." + columna
      Else
         columna = "MR." + columna
      End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.MovilRuta.Columnas.IdRuta.ToString(), Entidades.MovilRuta.NombreTabla))
   End Function

End Class