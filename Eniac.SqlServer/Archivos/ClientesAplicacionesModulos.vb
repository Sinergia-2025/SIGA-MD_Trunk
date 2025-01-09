Imports System.Text

Public Class ClientesAplicacionesModulos
   Inherits Comunes
   Private Property ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto

   Public Sub New(ByVal da As Eniac.Datos.DataAccess, ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto)
      MyBase.New(da)
      Me.ModoClienteProspecto = ModoClienteProspecto
   End Sub

   Public Sub ClientesAplicacionesModulos_I(ByVal IdCliente As Long, _
                                        ByVal IdModulo As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendFormat("INSERT INTO {0}sAplicacionesModulos", ModoClienteProspecto.ToString())
         .AppendFormat("   (Id{0}", ModoClienteProspecto.ToString())
         .AppendLine("   ,IdModulo")
         .AppendLine(" ) VALUES (")
         .AppendLine("   " & IdCliente)
         .AppendLine("   ," & IdModulo)
         .AppendLine(")")
      End With

      Me.Execute(myQuery.ToString())
      '-- OBSOLETO.- --
      Me.Sincroniza_I(myQuery.ToString(), "ClientesAplicacionesModulos")

   End Sub

   Public Sub ClientesAplicacionesModulos_D(ByVal IdCliente As Long)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendFormat("DELETE FROM {0}sAplicacionesModulos ", ModoClienteProspecto.ToString())
         .AppendFormat(" WHERE Id{0} = {1}", ModoClienteProspecto.ToString(), IdCliente)
      End With

      Me.Execute(myQuery.ToString())
      '-- OBSOLETO.- --
      Me.Sincroniza_I(myQuery.ToString(), "ClientesAplicacionesModulos")

   End Sub

   Public Function GetClientesAplicacionesModulos(ByVal IdCliente As Long) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendFormat("SELECT CM.Id{0} as IdCliente", ModoClienteProspecto.ToString())
         .AppendLine(" ,CM.IdModulo       ,AM.NombreModulo  ")
         .AppendFormat(" FROM {0}sAplicacionesModulos CM  ", ModoClienteProspecto.ToString())
         .AppendLine(" INNER JOIN AplicacionesModulos AM ON AM.IdModulo = CM.IdModulo ")
         If IdCliente <> 0 Then
            .AppendFormat("	WHERE CM.Id{0} = {1}", ModoClienteProspecto.ToString(), IdCliente)
         End If
         .AppendLine(" ORDER BY AM.NombreModulo")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function GetModulosCliente(ByVal IdCliente As Long, ByVal IdModulo As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendFormat("SELECT CM.Id{0} as IdCliente", ModoClienteProspecto.ToString())
         .AppendLine(" ,CM.IdModulo     ")
         .AppendLine(" FROM ClientesAplicacionesModulos CM  ")
         .AppendLine(" INNER JOIN AplicacionesModulos AM ON AM.IdModulo = CM.IdModulo ")
         .AppendFormat("	WHERE CD.Id{0} = {1}", ModoClienteProspecto.ToString(), IdCliente)
         .AppendLine(" AND CD.IdModulo = " & IdModulo)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   'Public Function GetDirecciones(ByVal IdCliente As Long) As DataTable

   '   Dim stb As StringBuilder = New StringBuilder("")

   '   With stb
   '      .Length = 0
   '      .AppendLine("  SELECT 0 as IdDireccion, C.Direccion  + ' - ' + L.NombreLocalidad + ' - '+ P.NombreProvincia as DireccionAMostrar ")
   '      .AppendLine("       , L.IdLocalidad, P.IdProvincia")
   '      .AppendLine(" FROM CLientes  C ")
   '      .AppendLine(" INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad  ")
   '      .AppendLine(" INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia ")
   '      If IdCliente <> 0 Then
   '         .AppendLine(" WHERE C.IdCliente = " & IdCliente)
   '      End If
   '      .AppendLine("UNION ALL SELECT CD.IdDireccion, CD.Direccion  + ' - ' + L.NombreLocalidad  + ' - '+ P.NombreProvincia as DireccionAMostrar ")
   '      .AppendLine("       , L.IdLocalidad, P.IdProvincia")
   '      .AppendLine(" FROM ClientesAplicacionesModulos CD  ")
   '      .AppendLine(" INNER JOIN Localidades L ON L.IdLocalidad = CD.IdLocalidad ")
   '      .AppendLine(" INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia  ")
   '      If IdCliente <> 0 Then
   '         .AppendLine("	WHERE CD.IdCliente = " & IdCliente)
   '      End If
   '   End With

   '   Return Me.GetDataTable(stb.ToString())
   'End Function


End Class
