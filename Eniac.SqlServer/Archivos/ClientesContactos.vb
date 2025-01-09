Imports System.Text

Public Class ClientesContactos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Private Property ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto

   Public Sub New(ByVal da As Eniac.Datos.DataAccess, ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto)
      MyBase.New(da)
      Me.ModoClienteProspecto = ModoClienteProspecto
   End Sub

   Public Sub ClientesContactos_I(ByVal IdCliente As Long, _
                                        ByVal IdContacto As Long, _
                        ByVal NombreContacto As String, _
                        ByVal direccion As String, _
                        ByVal idLocalidad As Integer, _
                        ByVal telefono As String, _
                        ByVal correoElectronico As String, _
                        ByVal celular As String, _
                        ByVal observacion As String, _
                        ByVal Activo As Boolean, _
                        ByVal Usuario As String, _
                        ByVal IdtipoContacto As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         '.AppendLine("INSERT INTO ClientesContactos")
         .AppendFormat("INSERT INTO {0}sContactos ", ModoClienteProspecto.ToString())
         .AppendFormat("(Id{0},", ModoClienteProspecto.ToString())
         '  .AppendLine("   (IdCliente, ")
         .Append("IdContacto,")
         .Append("NombreContacto, ")
         .Append("Direccion, ")
         .Append("IdLocalidad, ")
         .Append("Telefono, ")
         .Append("CorreoElectronico, ")
         .Append("Celular, ")
         .Append("Observacion, ")
         .Append("Activo, ")
         .Append(" IdUsuario,")
         .Append(" IdTipoContacto")
         .AppendLine(" ) VALUES (")
         .AppendLine("   " & IdCliente & ", ")
         .Append(IdContacto.ToString() & ", ")
         .Append("'" & NombreContacto & "', ")
         .Append("'" & direccion & "', ")
         .Append("" & idLocalidad & ", ")
         .Append("'" & telefono & "', ")
         .Append("'" & correoElectronico & "', ")
         .Append("'" & celular & "', ")
         .Append(" '" & observacion & "', ")
         .Append(" '" & Activo.ToString() & "',")
         .Append("'" & Usuario & "',")
         .Append(IdtipoContacto)
         .AppendLine(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ClientesContactos")

   End Sub

   Public Sub ClientesContactos_U(IdCliente As Long,
                                  IdContacto As Long,
                                  NombreContacto As String,
                                  direccion As String,
                                  idLocalidad As Integer,
                                  telefono As String,
                                  correoElectronico As String,
                                  celular As String,
                                  observacion As String,
                                  Activo As Boolean,
                                  Usuario As String,
                                  IdtipoContacto As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}sContactos ", ModoClienteProspecto.ToString()).AppendLine()
         .AppendFormat("   SET NombreContacto = '{0}'", NombreContacto).AppendLine()
         .AppendFormat("     , Direccion = '{0}'", direccion).AppendLine()
         .AppendFormat("     , IdLocalidad = {0}", idLocalidad).AppendLine()
         .AppendFormat("     , Telefono = '{0}'", telefono).AppendLine()
         .AppendFormat("     , CorreoElectronico = '{0}'", correoElectronico).AppendLine()
         .AppendFormat("     , Celular = '{0}'", celular).AppendLine()
         .AppendFormat("     , Observacion = '{0}'", observacion).AppendLine()
         .AppendFormat("     , Activo = {0}", GetStringFromBoolean(Activo)).AppendLine()
         .AppendFormat("     , IdUsuario= '{0}'", Usuario).AppendLine()
         .AppendFormat("     , IdTipoContacto= '{0}'", IdtipoContacto).AppendLine()
         .AppendFormat(" WHERE Id{0} = {1}", ModoClienteProspecto.ToString(), IdCliente)
         .AppendFormat("   AND IdContacto = {0}", IdContacto)
      End With
      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ClientesContactos")
   End Sub

   Public Sub ClientesContactos_D(ByVal IdCliente As Long, idContacto As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         ' .AppendLine("DELETE FROM ClientesContactos ")
         .AppendFormat("DELETE FROM {0}sContactos ", ModoClienteProspecto.ToString())
         .AppendFormat("WHERE Id{0} = {1}", ModoClienteProspecto.ToString(), IdCliente.ToString())
         If idContacto > 0 Then
            .AppendFormat("  AND IdContacto = {0}", idContacto)
         End If
         ' .AppendLine(" WHERE IdCliente = " & IdCliente)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ClientesContactos")

   End Sub

   Public Function GetClientesContactos(ByVal IdCliente As Long, idContacto As Integer, activo As Boolean?) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendFormat("SELECT C.Id{0} ", ModoClienteProspecto.ToString())
         ' .AppendLine("SELECT C.IdCliente ")
         .AppendLine("      ,C.IdTipoContacto")
         .AppendLine("      ,TC.NombreTipoContacto")
         .AppendLine("      ,C.IdContacto")
         .AppendLine("      ,C.NombreContacto")
         .AppendLine("      ,C.Telefono")
         .AppendLine("      ,C.Celular")
         .AppendLine("      ,C.Observacion")
         .AppendLine("      ,C.CorreoElectronico")
         .AppendLine("      ,C.Direccion")
         .AppendLine("      ,C.IdLocalidad")
         .AppendLine("      ,L.NombreLocalidad")
         .AppendLine("      ,P.NombreProvincia")

         .AppendLine("      ,C.Activo ")
         .AppendLine("      ,C.IdUsuario")
         'Desde Prospectos no tiene que validar si esta en uso el contacto
         If ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente Then
            .AppendLine("      ,CONVERT (bit, CASE WHEN ")
            .AppendLine("           (SELECT COUNT(1) FROM PedidosClientesContactos PCC WHERE PCC.IdCliente = C.IdCliente AND PCC.IdContacto = C.IdContacto) +")
            .AppendLine("           (SELECT COUNT(1) FROM VentasClientesContactos VCC WHERE VCC.IdCliente = C.IdCliente AND VCC.IdContacto = C.IdContacto) ")
            .AppendLine("                 > 0 THEN 1 ELSE 0 END) AS EnUso")
         End If

         '.AppendLine("      ,CONVERT(bit, CASE WHEN PCC.IdCliente IS NULL AND VCC.IdCliente IS NULL THEN 0 ELSE 1 END) EnUso")
         .AppendFormat(" FROM {0}sContactos C ", ModoClienteProspecto.ToString())
         ' .AppendLine(" FROM ClientesContactos C")
         .AppendLine(" LEFT JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad ")
         .AppendLine(" LEFT JOIN Provincias P ON P.IdProvincia = L.IdProvincia ")
         .AppendLine(" LEFT JOIN TiposContactos TC ON TC.IdTipoContacto = C.IdTipoContacto")

         '.AppendLine(" LEFT JOIN PedidosClientesContactos PCC ON PCC.IdCliente = C.IdCliente AND PCC.IdContacto = C.IdContacto")
         '.AppendLine(" LEFT JOIN VentasClientesContactos VCC ON VCC.IdCliente = C.IdCliente AND VCC.IdContacto = C.IdContacto")

         .AppendFormat(" WHERE 1 = 1")
         If IdCliente <> 0 Then
            .AppendFormat("  AND C.Id{0} = {1}", ModoClienteProspecto.ToString(), IdCliente.ToString())
         End If
         If idContacto <> 0 Then
            .AppendFormat("  AND C.idContacto = {0}", idContacto.ToString())
         End If
         If activo.HasValue Then
            .AppendFormat("  AND C.Activo = {0}", GetStringFromBoolean(activo.Value))
         End If

         .AppendLine(" ORDER BY C.Direccion")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function GetContactoCliente(ByVal IdCliente As Long, ByVal IdContacto As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT CD.IdCliente ")
         .AppendLine("      ,C.IdTipoContacto")
         .AppendLine("      ,TC.NombreTipoContacto")
         .AppendLine("      ,C.NombreContacto")
         .AppendLine("      ,C.Direccion")
         .AppendLine("      ,C.IdLocalidad")
         .AppendLine("      ,L.NombreLocalidad")
         .AppendLine("      ,P.NombreProvincia")
         .AppendLine("      ,C.Telefono")
         .AppendLine("      ,C.Celular")
         .AppendLine("      ,C.CorreoElectronico")
         .AppendLine("      ,C.Observacion")
         .AppendLine("      ,C.Activo ")
         .AppendLine("      ,C.IdUsuario")
         .AppendLine(" FROM Contactos C")
         .AppendLine(" LEFT JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad ")
         .AppendLine(" LEFT JOIN Provincias P ON P.IdProvincia = L.IdProvincia ")
         .AppendLine(" LEFT JOIN TiposContactos TC ON TC.IdTipoContacto = C.IdTipoContacto")
         .AppendLine("	WHERE CD.IdCliente = " & IdCliente)
         .AppendLine(" AND CD.IdContacto = " & IdContacto)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   'Public Function GetContactos(ByVal IdCliente As Long) As DataTable

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
   '      .AppendLine(" FROM ClientesContactos CD  ")
   '      .AppendLine(" INNER JOIN Localidades L ON L.IdLocalidad = CD.IdLocalidad ")
   '      .AppendLine(" INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia  ")
   '      If IdCliente <> 0 Then
   '         .AppendLine("	WHERE CD.IdCliente = " & IdCliente)
   '      End If
   '   End With

   '   Return Me.GetDataTable(stb.ToString())
   'End Function

   Public Overloads Function GetCodigoMaximo(idCliente As Long) As Integer
      Return Convert.ToInt32(GetCodigoMaximo("IdContacto",
                                             String.Format("{0}sContactos", ModoClienteProspecto.ToString()),
                                             String.Format("Id{0} = {1}", ModoClienteProspecto.ToString(), idCliente)))
   End Function

   Public Function GetCodigoPorContactoNombre(nombreContacto As String, idCliente As Long) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT {0} FROM {1} ", Entidades.ClienteContacto.Columnas.IdContacto.ToString(), Entidades.ClienteContacto.NombreTabla)
         .AppendLine("     WHERE 1=1")

         ' # Nombre del Contacto
         If Not String.IsNullOrEmpty(nombreContacto) Then
            .AppendFormatLine("  AND {0} = '{1}'", Entidades.ClienteContacto.Columnas.NombreContacto.ToString(), nombreContacto)
         End If

         ' # Id del Cliente
         If idCliente <> 0 Then
            .AppendFormatLine("  AND {0} = {1}", Entidades.ClienteContacto.Columnas.IdCliente.ToString(), idCliente)
         End If

         Return GetDataTable(query.ToString())
      End With
   End Function

   Public Function Existe(nombreContacto As String, idCliente As Long) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT * FROM {0} ", Entidades.ClienteContacto.NombreTabla)
         .AppendLine("     WHERE 1=1")

         ' # Nombre del Contacto
         If Not String.IsNullOrEmpty(nombreContacto) Then
            .AppendFormatLine("  AND {0} = '{1}'", Entidades.ClienteContacto.Columnas.NombreContacto.ToString(), nombreContacto)
         End If

         ' # Id del Cliente
         If idCliente <> 0 Then
            .AppendFormatLine("  AND {0} = {1}", Entidades.ClienteContacto.Columnas.IdCliente.ToString(), idCliente)
         End If

         Return GetDataTable(query.ToString())
      End With
   End Function

End Class
