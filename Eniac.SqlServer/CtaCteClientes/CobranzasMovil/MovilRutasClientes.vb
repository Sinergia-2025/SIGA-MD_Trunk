Public Class MovilRutasClientes
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub MovilRutasClientes_I(idRuta As Integer, dia As Integer, orden As Integer, idCliente As Long)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0}", Entidades.MovilRutaCliente.NombreTabla).AppendLine()
         .AppendFormat("           ({0}, {1}, {2}, {3})",
                       Entidades.MovilRutaCliente.Columnas.IdRuta.ToString(),
                       Entidades.MovilRutaCliente.Columnas.Dia.ToString(),
                       Entidades.MovilRutaCliente.Columnas.Orden.ToString(),
                       Entidades.MovilRutaCliente.Columnas.IdCliente.ToString()).AppendLine()
         .AppendFormat("    VALUES ({0}, {1}, {2}, {3}",
                       idRuta, dia, orden, idCliente)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   'Public Sub MovilRutasClientes_U(idRuta As Integer, nombreMovilRutaCliente As String, activa As Boolean)
   '   Dim myQuery As StringBuilder = New StringBuilder()
   '   With myQuery
   '      .AppendFormat("UPDATE {0} ", Entidades.MovilRutaCliente.NombreTabla)
   '      .AppendFormat("   SET {0} = '{1}'", Entidades.MovilRutaCliente.Columnas.NombreRuta.ToString(), nombreMovilRutaCliente).AppendLine()
   '      .AppendFormat("     , {0} =  {1} ", Entidades.MovilRutaCliente.Columnas.Activa.ToString(), GetStringFromBoolean(activa)).AppendLine()
   '      .AppendFormat(" WHERE {0} =  {1} ", Entidades.MovilRutaCliente.Columnas.IdRuta.ToString(), idRuta)
   '   End With
   '   Me.Execute(myQuery.ToString())
   'End Sub

   Public Sub MovilRutasClientes_D(idRuta As Integer?, dia As Integer?, orden As Integer?, idCliente As Long?)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} ", Entidades.MovilRutaCliente.NombreTabla)
         .AppendFormat(" WHERE 1 = 1")
         If idRuta.HasValue Then
            .AppendFormat("   AND {0} = {1}", Entidades.MovilRutaCliente.Columnas.IdRuta.ToString(), idRuta.Value)
         End If
         If dia.HasValue Then
            .AppendFormat("   AND {0} = {1}", Entidades.MovilRutaCliente.Columnas.Dia.ToString(), dia)
         End If
         If orden.HasValue Then
            .AppendFormat("   AND {0} = {1}", Entidades.MovilRutaCliente.Columnas.Orden.ToString(), orden)
         End If
         If idCliente.HasValue Then
            .AppendFormat("   AND {0} = {1}", Entidades.MovilRutaCliente.Columnas.IdCliente.ToString(), idCliente)
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT MRC.* FROM {0} AS MRC", Entidades.MovilRutaCliente.NombreTabla).AppendLine()
         .AppendFormat(" INNER JOIN {0} AS MR ON MR.{1} = MRC.{2}",
                       Entidades.MovilRuta.NombreTabla,
                       Entidades.MovilRuta.Columnas.IdRuta.ToString(),
                       Entidades.MovilRutaCliente.Columnas.IdRuta.ToString()).AppendLine()
      End With
   End Sub
   Public Function OrdenRutaCliente_G(idRuta As Integer, dia As Integer) As Integer
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormat(" {0} = {1}", Entidades.MovilRutaCliente.Columnas.IdRuta.ToString(), idRuta)
         .AppendFormat(" AND  {0} = {1}", Entidades.MovilRutaCliente.Columnas.Dia.ToString(), dia)
      End With
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.MovilRutaCliente.Columnas.Orden.ToString(), Entidades.MovilRutaCliente.NombreTabla, stb.ToString()))
   End Function
   Public Function MovilRutasClientes_GA(activas As Boolean?, soloConSaldo As Boolean) As DataTable
      Return MovilRutasClientes_G(idRuta:=Nothing, dia:=Nothing, orden:=Nothing, idCliente:=Nothing, activas:=activas, soloConSaldo:=soloConSaldo)
   End Function
   Public Function MovilRutasClientes_GA(idRuta As Integer) As DataTable
      Return MovilRutasClientes_G(idRuta, dia:=Nothing, orden:=Nothing, idCliente:=Nothing, activas:=Nothing, soloConSaldo:=False)
   End Function
   Private Function MovilRutasClientes_G(idRuta As Integer?, dia As Integer?, orden As Integer?, idCliente As Long?, activas As Boolean?, soloConSaldo As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" WHERE 1 = 1")
         If idRuta.HasValue Then
            .AppendFormat("   AND MRC.{0} = {1}", Entidades.MovilRutaCliente.Columnas.IdRuta.ToString(), idRuta.Value)
         End If
         If dia.HasValue Then
            .AppendFormat("   AND MRC.{0} = {1}", Entidades.MovilRutaCliente.Columnas.Dia.ToString(), dia)
         End If
         If orden.HasValue Then
            .AppendFormat("   AND MRC.{0} = {1}", Entidades.MovilRutaCliente.Columnas.Orden.ToString(), orden)
         End If
         If idCliente.HasValue Then
            .AppendFormat("   AND MRC.{0} = {1}", Entidades.MovilRutaCliente.Columnas.IdCliente.ToString(), idCliente)
         End If
         If activas.HasValue Then
            .AppendFormat("   AND MR.{0} = {1}", Entidades.MovilRuta.Columnas.Activa.ToString(), GetStringFromBoolean(activas.Value))
         End If

         If soloConSaldo Then
            .AppendFormat("   AND EXISTS (SELECT CC.IdSucursal")
            .AppendFormat("                 FROM CuentasCorrientes CC")
            .AppendFormat("        WHERE CC.IdCliente = MRC.IdCliente")
            .AppendFormat("                  AND CC.Saldo > 0)")
         End If

      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function MovilRutasClientes_GA_ParaSincronizar() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT MRC.IdRuta")
         .AppendFormatLine("     , MRC.Dia")
         .AppendFormatLine("     , MRC.Orden")
         .AppendFormatLine("     , MRC.IdCliente")
         .AppendFormatLine("     , C.CodigoCliente")
         .AppendFormatLine("     , MR.EsDePedidos")
         .AppendFormatLine("     , MR.EsDeCobranza")
         .AppendFormatLine("  FROM MovilRutasClientes AS MRC")
         .AppendFormatLine(" INNER JOIN Clientes C ON C.IdCliente = MRC.IdCliente")
         .AppendFormatLine(" INNER JOIN MovilRutas AS MR ON MR.IdRuta = MRC.IdRuta")
         .AppendFormatLine(" WHERE MR.{0} = 'True'", Entidades.MovilRuta.Columnas.Activa.ToString())
         .AppendFormatLine("   AND C.{0}  = 'True'", Entidades.Cliente.Columnas.Activo.ToString())

         .AppendFormatLine("UNION")

         .AppendFormatLine("SELECT MR.IdRuta")
         .AppendFormatLine("     , 7 Dia")
         .AppendFormatLine("     , CONVERT(INT, ROW_NUMBER () OVER (PARTITION BY MR.IdRuta ORDER BY MR.IdRuta, C.CodigoCliente)) Orden")
         .AppendFormatLine("     , C.IdCliente")
         .AppendFormatLine("     , C.CodigoCliente")
         .AppendFormatLine("     , CONVERT(BIT, (CASE WHEN C.IdVendedor = MR.IdVendedor AND MR.EsDePedidos  = 'True' THEN 1 ELSE 0 END)) EsDePedidos")
         .AppendFormatLine("     , CONVERT(BIT, (CASE WHEN C.IdCobrador = MR.IdVendedor AND MR.EsDeCobranza = 'True' THEN 1 ELSE 0 END)) EsDeCobranza")
         .AppendFormatLine("  FROM MovilRutas MR")
         .AppendFormatLine(" INNER JOIN Clientes C ON (C.IdVendedor = MR.IdVendedor AND MR.EsDePedidos = 'True') OR (C.IdCobrador = MR.IdVendedor AND MR.EsDeCobranza = 'True')")
         .AppendFormatLine(" WHERE MR.ConfiguraClienteSegun = '{0}'", Entidades.OrigenConfiguraClienteSegun.CLIENTE.ToString())
         .AppendFormatLine("   AND MR.{0} = 'True'", Entidades.MovilRuta.Columnas.Activa.ToString())
         .AppendFormatLine("   AND C.{0}  = 'True'", Entidades.Cliente.Columnas.Activo.ToString())

      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function MovilRutasClientes_G1(idRuta As Integer, dia As Integer, orden As Integer, idCliente As Long) As DataTable
      Return MovilRutasClientes_G(idRuta, dia, orden, idCliente, activas:=Nothing, soloConSaldo:=False)
   End Function
   Public Function MovilRutasClientes_GA(idRuta As Integer, dia As Integer, idCliente As Long) As DataTable
      Return MovilRutasClientes_G(idRuta, dia, orden:=Nothing, idCliente:=idCliente, activas:=Nothing, soloConSaldo:=False)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      'If columna = "NombreSucursal" Then
      '   columna = "S." + columna
      'Else
      columna = "MRC." + columna
      'End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Private Sub SelectTextoParaAsignacionCampos(ByVal stb As StringBuilder)
      With stb
         .AppendLine("SELECT C.IdCliente")
         .AppendLine("     , C.CodigoCliente")
         .AppendLine("     , C.NombreCliente")
         .AppendLine("     , C.NombreDeFantasia")
         .AppendLine("     , C.Direccion")
         .AppendLine("     , C.IdLocalidad")
         .AppendLine("     , L.NombreLocalidad")
         .AppendLine("     , P.NombreProvincia")
         .AppendLine("     , C.LimiteDeCredito")
         .AppendLine("     , C.TipoDocCliente")
         .AppendLine("     , C.NroDocCliente")
         .AppendLine("     , ZG.NombreZonaGeografica")
         .AppendLine("     , C.CantidadVisitas")
         .AppendLine("     , ISNULL(V.CantidadVisitasAsignadas, 0) AS CantidadVisitasAsignadas")
         .AppendFormatLine("      ,E.NombreEmpleado AS Vendedor")
         .AppendFormatLine("		 ,Cob.NombreEmpleado As Cobrador")
      End With
   End Sub

   Private Sub SelectTextoParaAsignacionFrom(ByVal stb As StringBuilder)
      With stb
         .AppendLine("  FROM Clientes C")
         .AppendLine("  LEFT JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine("  LEFT JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         .AppendLine("  LEFT JOIN CategoriasFiscales CF ON C.IdCategoriaFiscal = CF.IdCategoriaFiscal  ")
         .AppendLine("  LEFT JOIN ZonasGeograficas ZG ON ZG.IdZonaGeografica = C.IdZonaGeografica ")
         .AppendLine(" LEFT JOIN Empleados E ON C.IdVendedor = E.IdEmpleado ")
         .AppendFormat(" LEFT OUTER JOIN Empleados Cob ON Cob.IdEmpleado = C.IdCobrador")
         .AppendLine("  LEFT JOIN (SELECT IdCliente, COUNT(1) CantidadVisitasAsignadas")
         .AppendLine("               FROM MovilRutasClientes GROUP BY IdCliente) V ON V.IdCliente = C.IdCliente")
      End With
   End Sub

   Public Function GetClientesParaRutas(tablaVacia As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         SelectTextoParaAsignacionCampos(myQuery)
         .AppendLine("     , CONVERT(bit, 0) DiaActual")
         SelectTextoParaAsignacionFrom(myQuery)
         If tablaVacia Then
            .AppendLine("  WHERE 1 = 2")
            .AppendLine("    AND C.CantidadVisitas > 0")
         End If
         .AppendLine(" ORDER BY C.NombreCliente ")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetClientesAsignados(tablaVacia As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         SelectTextoParaAsignacionCampos(myQuery)

         .AppendLine("     , MRC.IdRuta")
         .AppendLine("     , MRC.Dia")
         .AppendLine("     , MRC.Orden")

         SelectTextoParaAsignacionFrom(myQuery)
         .AppendLine(" INNER JOIN MovilRutasClientes MRC ON MRC.IdCliente = C.IdCliente")
         If tablaVacia Then
            .AppendLine("  WHERE 1 = 2")
         End If
         .AppendLine(" ORDER BY MRC.IdRuta, MRC.Dia, MRC.Orden, C.NombreCliente ")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class