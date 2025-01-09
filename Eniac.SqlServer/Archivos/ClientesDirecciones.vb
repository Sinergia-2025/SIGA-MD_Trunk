Public Class ClientesDirecciones
   Inherits Comunes

   Private Property ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto

   Public Sub New(da As Datos.DataAccess, modo As Entidades.Cliente.ModoClienteProspecto)
      MyBase.New(da)
      ModoClienteProspecto = modo
   End Sub

   Public Sub ClientesDirecciones_I(idCliente As Long, idDireccion As Integer,
                                    direccion As String, idLocalidad As Integer, idTipoDireccion As Integer,
                                    direccionAdicional As String, descripcion As String, observacion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}sDirecciones ", ModoClienteProspecto.ToString())
         .AppendFormatLine("  (Id{0}", ModoClienteProspecto.ToString())
         .AppendFormatLine("  , IdDireccion")
         .AppendFormatLine("  , Direccion")
         .AppendFormatLine("  , IdLocalidad")
         .AppendFormatLine("  , IdTipoDireccion")
         .AppendFormatLine("  , DireccionAdicional")
         .AppendFormatLine("  , Descripcion")
         .AppendFormatLine("  , Observacion")
         .AppendFormatLine("  ) VALUES (")
         .AppendFormatLine("     {0} ", idCliente)
         .AppendFormatLine("  ,  {0} ", idDireccion)
         .AppendFormatLine("  , '{0}'", direccion)
         .AppendFormatLine("  ,  {0} ", idLocalidad)
         .AppendFormatLine("  ,  {0} ", idTipoDireccion)
         .AppendFormatLine("  , '{0}'", direccionAdicional)
         If String.IsNullOrEmpty(descripcion) Then
            .AppendLine("  , NULL")
         Else
            .AppendFormatLine("  , '{0}'", descripcion)
         End If
         .AppendFormatLine("  , '{0}'", observacion)
         .AppendFormatLine("  )")
      End With

      Execute(myQuery)
      '-- Obsoleto.- --
      Sincroniza_I(myQuery.ToString(), "ClientesDirecciones")
   End Sub
   Public Sub ClientesDirecciones_U(idCliente As Long, idDireccion As Integer,
                                    direccion As String, idLocalidad As Integer, idTipoDireccion As Integer,
                                    direccionAdicional As String, descripcion As String, observacion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}sDirecciones SET", ModoClienteProspecto.ToString())
         .AppendFormatLine("       Direccion = '{0}'", direccion)
         .AppendFormatLine("     , IdLocalidad = {0}", idLocalidad)
         .AppendFormatLine("     , IdTipoDireccion = {0}", idTipoDireccion)
         .AppendFormatLine("     , DireccionAdicional = '{0}'", direccionAdicional)
         .AppendFormatLine("     , Descripcion = '{0}'", descripcion)
         .AppendFormatLine("     , Observacion = '{0}'", observacion)
         .AppendFormatLine(" WHERE Id{1} = {0}", idCliente, ModoClienteProspecto.ToString())
         .AppendFormatLine("   AND IdDireccion = {0}", idDireccion)
      End With
      Execute(myQuery)
      '-- Obsoleto.- --
      Sincroniza_I(myQuery.ToString(), "ClientesDirecciones")
   End Sub

   Public Sub ClientesDirecciones_D(idCliente As Long)
      ClientesDirecciones_D(idCliente, idDireccion:=0)
   End Sub
   Public Sub ClientesDirecciones_D(idCliente As Long, idDireccion As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}sDirecciones", ModoClienteProspecto.ToString())
         .AppendFormatLine(" WHERE Id{0} = {1}", ModoClienteProspecto.ToString(), idCliente)
         If idDireccion <> 0 Then
            .AppendFormatLine("   AND IdDireccion = {0}", idDireccion)
         End If
      End With

      Execute(myQuery)
      '-- Obsoleto.- --
      Sincroniza_I(myQuery.ToString(), "ClientesDirecciones")
   End Sub

   Public Function GetClientesDirecciones(idCliente As Long, idDireccion As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT CD.Id{0} as IdCliente", ModoClienteProspecto.ToString())
         .AppendFormatLine("     , CD.IdDireccion")
         .AppendFormatLine("     , CD.Direccion")
         .AppendFormatLine("     , CD.IdLocalidad")
         .AppendFormatLine("     , L.NombreLocalidad")
         .AppendFormatLine("     , P.NombreProvincia")
         .AppendFormatLine("     , CD.IdTipoDireccion")
         .AppendFormatLine("     , TD.NombreAbrevTipoDireccion,CD.DireccionAdicional")
         .AppendFormatLine("     , CD.Descripcion,CD.Observacion")

         .AppendFormatLine("  FROM {0}sDirecciones CD  ", ModoClienteProspecto.ToString())
         .AppendFormatLine(" INNER JOIN Localidades L ON L.IdLocalidad = CD.IdLocalidad")
         .AppendFormatLine(" INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         .AppendFormatLine(" INNER JOIN TiposDirecciones TD ON TD.IdTipoDireccion = CD.IdTipoDireccion")
         If idCliente <> 0 Then
            .AppendFormatLine(" WHERE CD.Id{0} = {1}", ModoClienteProspecto.ToString(), idCliente)
         End If
         If idDireccion <> 0 Then
            .AppendFormatLine("   AND CD.IdDireccion = {0}", idDireccion)
         End If
         .AppendFormatLine(" ORDER BY CD.Direccion")
      End With
      Return GetDataTable(stb)
   End Function
   'Public Function GetDireccionCliente(idCliente As Long, idDireccion As Integer) As DataTable
   '   Dim stb = New StringBuilder()
   '   With stb
   '      .AppendFormatLine("SELECT CD.Id{0} as IdCliente", ModoClienteProspecto.ToString())
   '      .AppendFormatLine("     , CD.Direccion")
   '      .AppendFormatLine("     , CD.IdLocalidad")
   '      .AppendFormatLine("     , L.NombreLocalidad")
   '      .AppendFormatLine("     , P.NombreProvincia")
   '      .AppendFormatLine("     , TD.NombreAbrevTipoDireccion,CD.DireccionAdicional")
   '      .AppendFormatLine("  FROM ClientesDirecciones CD")
   '      .AppendFormatLine(" INNER JOIN Localidades L ON L.IdLocalidad = CD.IdLocalidad")
   '      .AppendFormatLine(" INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
   '      .AppendFormatLine(" INNER JOIN TiposDirecciones TD ON TD.IdTipoDireccion = CD.IdTipoDireccion")
   '      .AppendFormatLine(" WHERE CD.Id{0} = {1}", ModoClienteProspecto.ToString(), idCliente)
   '      .AppendFormatLine("   AND CD.IdDireccion = {0}", idDireccion)
   '   End With
   '   Return GetDataTable(stb)
   'End Function
   Public Function GetDirecciones(idCliente As Long, buscaDireccion2 As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT 0 as IdDireccion")
         .AppendFormatLine("     , 'Casa Central -' + C.Direccion + ' - ' + L.NombreLocalidad + ' - '+ P.NombreProvincia DireccionAMostrar")
         .AppendFormatLine("     , C.Direccion")
         .AppendFormatLine("     , L.IdLocalidad")
         .AppendFormatLine("     , P.IdProvincia")
         .AppendFormatLine("  FROM {0}s  C ", ModoClienteProspecto.ToString())
         .AppendFormatLine(" INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendFormatLine(" INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         If idCliente <> 0 Then
            .AppendFormatLine(" WHERE C.Id{0} = {1}", ModoClienteProspecto.ToString(), idCliente)
         End If
         If buscaDireccion2 Then
            .AppendFormatLine(" UNION ALL ")
            .AppendFormatLine("SELECT -1 as IdDireccion")
            .AppendFormatLine("     , S.NombreCalle + ' ' + CONVERT(VARCHAR(MAX), C.Altura2) + ' '+ C.DireccionAdicional2 + ' - ' + L.NombreLocalidad + ' - '+ P.NombreProvincia DireccionAMostrar")
            .AppendFormatLine("     , S.NombreCalle + ' ' + CONVERT(VARCHAR(MAX), C.Altura2)  + ' '+ C.DireccionAdicional2  Direccion")
            .AppendFormatLine("     , L.IdLocalidad")
            .AppendFormatLine("     , P.IdProvincia")
            .AppendFormatLine("  FROM {0}s  C ", ModoClienteProspecto.ToString())
            .AppendFormatLine(" INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad2")
            .AppendFormatLine(" INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
            .AppendFormatLine(" INNER JOIN Calles S ON S.IdCalle = C.IdCalle2")
            If idCliente <> 0 Then
               .AppendFormatLine(" WHERE C.Id{0} = {1}", ModoClienteProspecto.ToString(), idCliente)
            End If
         End If
         '.AppendFormatLine("   AND (C.Direccion   <> C.Direccion2 OR C.IdLocalidad <> C.IdLocalidad2)")
         .AppendFormatLine(" UNION ALL ")
         .AppendFormatLine("SELECT CD.IdDireccion")
         .AppendFormatLine("     , CASE WHEN CD.Descripcion IS NULL OR CD.Descripcion = '' THEN '' ELSE  CD.Descripcion + ' - ' END   + CD.Direccion  + ' - ' + L.NombreLocalidad  + ' - '+ P.NombreProvincia DireccionAMostrar")
         .AppendFormatLine("     , CD.Direccion")
         .AppendFormatLine("     , L.IdLocalidad")
         .AppendFormatLine("     , P.IdProvincia")
         .AppendFormatLine("  FROM {0}sDirecciones CD  ", ModoClienteProspecto.ToString())
         .AppendFormatLine(" INNER JOIN Localidades L ON L.IdLocalidad = CD.IdLocalidad")
         .AppendFormatLine(" INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         If idCliente <> 0 Then
            .AppendFormatLine(" WHERE CD.Id{0} = {1}", ModoClienteProspecto.ToString(), idCliente)
         End If
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function GetCodigoMaximo(idCliente As Long) As Integer
      Return GetCodigoMaximo("IdDireccion", "ClientesDirecciones", String.Format("IdCliente = {0}", idCliente)).ToInteger()
   End Function

End Class