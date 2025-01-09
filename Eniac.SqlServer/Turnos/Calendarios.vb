Public Class Calendarios
   Inherits Comunes
   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Calendarios_I(idCalendario As Integer,
                            idTipoCalendario As Short,
                            nombreCalendario As String,
                            activo As Boolean,
                            idSucursal As Integer,
                            lapsoPorDefecto As Integer,
                            lapsoPorDefectoFijo As Boolean,
                            diasDesde As Integer,
                            diasHasta As Integer,
                            cupo As Integer,
                            idUsuario As String,
                            diasHabilitacionReserva As Integer,
                            idProducto As String,
                            utilizaSesion As Boolean,
                            utilizaZona As Boolean,
                            publicarEnWeb As Boolean,
                            idNave As Short?,
                            solicitaEmbarcacion As Boolean,
                            solicitaBotado As Boolean,
                            solicitaVehiculo As Boolean,
                            permiteImpresion As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO Calendarios (")
         .AppendFormatLine("       {0}", Entidades.Calendario.Columnas.IdCalendario.ToString())
         .AppendFormatLine("     , {0}", Entidades.Calendario.Columnas.IdTipoCalendario.ToString())
         .AppendFormatLine("     , {0}", Entidades.Calendario.Columnas.NombreCalendario.ToString())
         .AppendFormatLine("     , {0}", Entidades.Calendario.Columnas.Activo.ToString())
         .AppendFormatLine("     , {0}", Entidades.Calendario.Columnas.IdSucursal.ToString())
         .AppendFormatLine("     , {0}", Entidades.Calendario.Columnas.LapsoPorDefecto.ToString())
         .AppendFormatLine("     , {0}", Entidades.Calendario.Columnas.LapsoPorDefectoFijo.ToString())
         .AppendFormatLine("     , {0}", Entidades.Calendario.Columnas.DiasDesde.ToString())
         .AppendFormatLine("     , {0}", Entidades.Calendario.Columnas.DiasHasta.ToString())
         .AppendFormatLine("     , {0}", Entidades.Calendario.Columnas.Cupo.ToString())
         .AppendFormatLine("     , {0}", Entidades.Calendario.Columnas.IdUsuario.ToString())
         .AppendFormatLine("     , {0}", Entidades.Calendario.Columnas.DiasHabilitacionReserva.ToString())
         .AppendFormatLine("     , {0}", Entidades.Calendario.Columnas.IdProducto.ToString())
         .AppendFormatLine("     , {0}", Entidades.Calendario.Columnas.UtilizaSesion.ToString())
         .AppendFormatLine("     , {0}", Entidades.Calendario.Columnas.UtilizaZonas.ToString())
         .AppendFormatLine("     , {0}", Entidades.Calendario.Columnas.PublicarEnWeb.ToString())
         .AppendFormatLine("     , {0}", Entidades.Calendario.Columnas.IdNave.ToString())
         .AppendFormatLine("     , {0}", Entidades.Calendario.Columnas.SolicitaEmbarcacion.ToString())
         .AppendFormatLine("     , {0}", Entidades.Calendario.Columnas.SolicitaBotado.ToString())
         .AppendFormatLine("     , {0}", Entidades.Calendario.Columnas.SolicitaVehiculo.ToString())
         .AppendFormatLine("     , {0}", Entidades.Calendario.Columnas.PermiteImpresion.ToString())
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("  {0}, ", idCalendario)
         .AppendFormatLine("  {0}, ", idTipoCalendario)
         .AppendFormatLine(" '{0}', ", nombreCalendario)
         .AppendFormatLine("  {0}, ", GetStringFromBoolean(activo))
         If idSucursal > 0 Then
            .AppendFormat("  {0}, ", idSucursal)
         Else
            .AppendFormatLine("NULL,")
         End If
         .AppendFormatLine("  {0}, ", lapsoPorDefecto)
         .AppendFormatLine("  {0}, ", GetStringFromBoolean(lapsoPorDefectoFijo))
         .AppendFormatLine("  {0}, ", diasDesde)
         .AppendFormatLine("  {0}, ", diasHasta)
         .AppendFormatLine("  {0}, ", cupo)

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendFormatLine(" '{0}',", idProducto)
         Else
            .AppendFormatLine(" NULL,")
         End If
         .AppendFormatLine(" {0},", diasHabilitacionReserva)
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine(" '{0}',", idProducto)
         Else
            .AppendFormatLine(" NULL,")
         End If
         .AppendFormatLine(" '{0}',", utilizaSesion)
         .AppendFormatLine(" '{0}'", utilizaZona)
         .AppendFormatLine(" , {0}", GetStringFromBoolean(publicarEnWeb))
         .AppendFormatLine(" , {0}", GetStringFromNumber(idNave))

         .AppendFormatLine(" , {0}", GetStringFromBoolean(solicitaEmbarcacion))
         .AppendFormatLine(" , {0}", GetStringFromBoolean(solicitaBotado))
         '-- REQ-33401.- -------
         .AppendFormatLine(" , {0}", GetStringFromBoolean(solicitaVehiculo))
         '-- REQ-33330.- -------
         .AppendFormatLine(" , {0}", GetStringFromBoolean(permiteImpresion))
         '----------------------

         .AppendLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub Calendarios_U(idCalendario As Integer,
                            idTipoCalendario As Short,
                            nombreCalendario As String,
                            activo As Boolean,
                            idSucursal As Integer,
                            lapsoPorDefecto As Integer,
                            lapsoPorDefectoFijo As Boolean,
                            diasDesde As Integer,
                            diasHasta As Integer,
                            cupo As Integer,
                            idUsuario As String,
                            diasHabilitacionReserva As Integer,
                            idProducto As String,
                            utilizaSesion As Boolean,
                            utilizaZona As Boolean,
                            publicarEnWeb As Boolean,
                            idNave As Short?,
                            solicitaEmbarcacion As Boolean,
                            solicitaBotado As Boolean,
                            solicitaVehiculo As Boolean,
                            permiteImpresion As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE Calendarios ")
         .AppendFormat("   SET {0} = '{1}'", Entidades.Calendario.Columnas.NombreCalendario.ToString(), nombreCalendario).AppendLine()
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Calendario.Columnas.IdTipoCalendario.ToString(), idTipoCalendario)
         .AppendFormat("     , {0} =  {1} ", Entidades.Calendario.Columnas.Activo.ToString(), GetStringFromBoolean(activo)).AppendLine()
         .AppendFormat("     , {0} =  {1} ", Entidades.Calendario.Columnas.IdSucursal.ToString(), IIf(idSucursal > 0, idSucursal, "NULL")).AppendLine()
         .AppendFormat("     , {0} =  {1} ", Entidades.Calendario.Columnas.LapsoPorDefecto.ToString(), lapsoPorDefecto).AppendLine()
         .AppendFormat("     , {0} =  {1} ", Entidades.Calendario.Columnas.LapsoPorDefectoFijo.ToString(), GetStringFromBoolean(lapsoPorDefectoFijo)).AppendLine()
         .AppendFormat("     , {0} =  {1} ", Entidades.Calendario.Columnas.DiasDesde.ToString(), diasDesde).AppendLine()
         .AppendFormat("     , {0} =  {1} ", Entidades.Calendario.Columnas.DiasHasta.ToString(), diasHasta).AppendLine()
         .AppendFormat("     , {0} =  {1} ", Entidades.Calendario.Columnas.Cupo.ToString(), cupo).AppendLine()

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendFormat("     , {0} =  '{1}' ", Entidades.Calendario.Columnas.IdUsuario.ToString(), idUsuario).AppendLine()
         Else
            .AppendFormat("     , {0} =  NULL ", Entidades.Calendario.Columnas.IdUsuario.ToString()).AppendLine()
         End If
         .AppendFormat("     , {0} =  {1} ", Entidades.Calendario.Columnas.DiasHabilitacionReserva.ToString(), diasHabilitacionReserva).AppendLine()

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("     , {0} =  '{1}' ", Entidades.Calendario.Columnas.IdProducto.ToString(), idProducto)
         Else
            .AppendFormatLine("     , {0} =  NULL ", Entidades.Calendario.Columnas.IdProducto.ToString())
         End If
         .AppendFormatLine("     , {0} =  '{1}' ", Entidades.Calendario.Columnas.UtilizaSesion.ToString(), utilizaSesion)

         .AppendFormatLine("     , {0} =  '{1}' ", Entidades.Calendario.Columnas.UtilizaZonas.ToString(), utilizaZona)

         .AppendFormatLine("     , {0} =  {1} ", Entidades.Calendario.Columnas.PublicarEnWeb.ToString(), GetStringFromBoolean(publicarEnWeb))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Calendario.Columnas.IdNave.ToString(), GetStringFromNumber(idNave))

         .AppendFormatLine("     , {0} =  {1} ", Entidades.Calendario.Columnas.SolicitaEmbarcacion.ToString(), GetStringFromBoolean(solicitaEmbarcacion))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Calendario.Columnas.SolicitaBotado.ToString(), GetStringFromBoolean(solicitaBotado))
         '-- REQ-33401.- ------------------------
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Calendario.Columnas.SolicitaVehiculo.ToString(), GetStringFromBoolean(solicitaVehiculo))
         '-- REQ-33330.- ------------------------
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Calendario.Columnas.PermiteImpresion.ToString(), GetStringFromBoolean(permiteImpresion))
         '---------------------------------------

         .AppendFormat(" WHERE {0} =  {1} ", Entidades.Calendario.Columnas.IdCalendario.ToString(), idCalendario)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Calendarios_D(idCalendario As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM Calendarios WHERE {0} = {1}", Entidades.Calendario.Columnas.IdCalendario.ToString(), idCalendario)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT CAL.*, S.Nombre AS NombreSucursal, P.NombreProducto, NombreCaja, CS.IdCaja, TC.NombreTipoCalendario FROM Calendarios CAL")
         .AppendFormatLine("  LEFT JOIN TiposCalendarios TC ON TC.IdTipoCalendario = CAL.IdTipoCalendario")
         .AppendFormatLine("  LEFT JOIN Sucursales S ON S.IdSucursal = CAL.IdSucursal")
         .AppendFormatLine("  LEFT JOIN Productos P ON P.IdProducto = CAL.IdProducto")
         .AppendFormatLine("  LEFT JOIN CalendariosSucursales CS ON CAL.IdCalendario = CS.IdCalendario AND CS.IdSucursal = {0}", actual.Sucursal.Id)
         .AppendFormatLine("  LEFT JOIN CajasNombres CN ON CS.IdCaja = CN.IdCaja AND CS.IdSucursal = CN.IdSucursal")
      End With
   End Sub

   Public Function Calendarios_GA() As DataTable
      Return Calendarios_G(idCalendario:=0, nombreCalendario:=String.Empty, idSucursal:=0, activo:=Nothing, nombreExacto:=False, publicarEnWeb:=Nothing)
   End Function
   Public Function Calendarios_GA(idSucursal As Integer, activo As Boolean?) As DataTable
      Return Calendarios_G(idCalendario:=0, nombreCalendario:=String.Empty, idSucursal:=idSucursal, activo:=activo, nombreExacto:=False, publicarEnWeb:=Nothing)
   End Function
   Private Function Calendarios_G(idCalendario As Integer, nombreCalendario As String, idSucursal As Integer, activo As Boolean?, nombreExacto As Boolean, publicarEnWeb As Entidades.Publicos.SiNoTodos) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idCalendario > 0 Then
            .AppendFormatLine("   AND CAL.IdCalendario = {0}", idCalendario)
         End If
         If idSucursal > 0 Then
            .AppendFormatLine("   AND (CAL.IdSucursal IS NULL OR CAL.IdSucursal = {0})", idSucursal)
         End If
         If Not String.IsNullOrWhiteSpace(nombreCalendario) Then
            If nombreExacto Then
               .AppendFormatLine("   AND CAL.NombreCalendario = '{0}'", nombreCalendario)
            Else
               .AppendFormatLine("   AND CAL.NombreCalendario LIKE '%{0}%'", nombreCalendario)
            End If
         End If
         If activo.HasValue Then
            .AppendFormatLine("   AND CAL.Activo = {0}", GetStringFromBoolean(activo.Value))
         End If
         If publicarEnWeb <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND CAL.PublicarEnWeb = '{0}'", publicarEnWeb = Entidades.Publicos.SiNoTodos.SI)
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function Calendarios_G1(idCalendario As Integer) As DataTable
      Return Calendarios_G(idCalendario:=idCalendario, nombreCalendario:=String.Empty, idSucursal:=0, activo:=Nothing, nombreExacto:=False, publicarEnWeb:=Nothing)
   End Function

   Public Function GetCalendarios(activo As Boolean?, publicarEnWeb As Entidades.Publicos.SiNoTodos) As DataTable
      Return Calendarios_G(idCalendario:=0, nombreCalendario:=String.Empty, idSucursal:=0, activo:=activo, nombreExacto:=True, publicarEnWeb:=publicarEnWeb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      If columna = "NombreSucursal" Then
         columna = "S." + columna
      ElseIf columna = "NombreProducto" Then
         columna = "P." + columna
      Else
         columna = "CAL." + columna
      End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.Calendario.Columnas.IdCalendario.ToString(), "Calendarios"))
   End Function

End Class