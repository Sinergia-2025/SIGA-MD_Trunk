Imports Eniac.Entidades

Public Class Sucursales
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Sucursales_I(idSucursal As Integer,
                           nombre As String,
                           direccion As String,
                           idLocalidad As Integer,
                           telefono As String,
                           correo As String,
                           fechaInicioActividad As Date,
                           estoyAca As Boolean,
                           soyLaCentral As Boolean,
                           idSucursalAsociada As Integer,
                           colorSucursal As Integer,
                           logoSucursal As Drawing.Image,
                           direccionComercial As String,
                           idLocalidadComercial As Integer,
                           redesSociales As String,
                           idSucursalAsociadaPrecios As Integer,
                           publicarEnWeb As Boolean,
                           idEmpresa As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO Sucursales (")
         .AppendFormatLine("     IdSucursal ")
         .AppendFormatLine("   , Id ")
         .AppendFormatLine("   , Nombre ")
         .AppendFormatLine("   , Direccion ")
         .AppendFormatLine("   , IdLocalidad ")
         .AppendFormatLine("   , Telefono ")
         .AppendFormatLine("   , Correo ")
         .AppendFormatLine("   , FechaInicioActiv ")
         .AppendFormatLine("   , EstoyAca ")
         .AppendFormatLine("   , SoyLaCentral ")
         .AppendFormatLine("   , IdSucursalAsociada ")
         .AppendFormatLine("   , ColorSucursal ")
         .AppendFormatLine("   , DireccionComercial ")
         .AppendFormatLine("   , IdLocalidadComercial ")
         .AppendFormatLine("   , RedesSociales ")
         .AppendFormatLine("   , IdSucursalAsociadaPrecios")
         .AppendFormatLine("   , PublicarEnWeb")
         .AppendFormatLine("   , IdEmpresa")
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("      {0} ", idSucursal)
         .AppendFormatLine("   ,  {0} ", idSucursal)
         .AppendFormatLine("   , '{0}'", nombre)
         .AppendFormatLine("   , '{0}'", direccion)
         .AppendFormatLine("   ,  {0} ", idLocalidad)
         .AppendFormatLine("   , '{0}'", telefono)
         .AppendFormatLine("   , '{0}'", correo)
         .AppendFormatLine("   , '{0}'", ObtenerFecha(fechaInicioActividad, False))
         .AppendFormatLine("   ,  {0} ", GetStringFromBoolean(estoyAca))
         .AppendFormatLine("   ,  {0} ", GetStringFromBoolean(soyLaCentral))

         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idSucursalAsociada))

         .AppendFormatLine("   ,  {0} ", colorSucursal)
         .AppendFormatLine("   , '{0}'", direccionComercial)
         .AppendFormatLine("   ,  {0} ", idLocalidadComercial)
         .AppendFormatLine("   , '{0}'", redesSociales)

         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idSucursalAsociadaPrecios))
         .AppendFormatLine("   ,  {0} ", GetStringFromBoolean(publicarEnWeb))
         .AppendFormatLine("   ,  {0} ", idEmpresa)
         .AppendFormatLine(" )")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Sucursales")
   End Sub

   Public Sub Sucursales_U(idSucursal As Integer,
                           nombre As String,
                           direccion As String,
                           idLocalidad As Integer,
                           telefono As String,
                           correo As String,
                           fechaInicioActividad As Date,
                           estoyAca As Boolean,
                           soyLaCentral As Boolean,
                           idSucursalAsociada As Integer,
                           colorSucursal As Integer,
                           logoSucursal As Drawing.Image,
                           direccionComercial As String,
                           idLocalidadComercial As Integer,
                           redesSociales As String,
                           idSucursalAsociadaPrecios As Integer,
                           publicarEnWeb As Boolean,
                           idEmpresa As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE Sucursales")

         .AppendFormatLine("   SET Nombre = '{0}'", nombre)
         .AppendFormatLine("     , Direccion = '{0}'", direccion)
         .AppendFormatLine("     , IdLocalidad = {0}", idLocalidad)
         .AppendFormatLine("     , Telefono = '{0}'", telefono)
         .AppendFormatLine("     , Correo = '{0}'", correo)
         .AppendFormatLine("     , FechaInicioActiv = '{0}'", ObtenerFecha(fechaInicioActividad, False))
         .AppendFormatLine("     , EstoyAca = {0}", GetStringFromBoolean(estoyAca))
         .AppendFormatLine("     , SoyLaCentral = {0}", GetStringFromBoolean(soyLaCentral))

         .AppendFormatLine("     , idSucursalAsociada = {0}", GetStringFromNumber(idSucursalAsociada))

         .AppendFormatLine("     , ColorSucursal = {0}", colorSucursal)
         .AppendFormatLine("     , DireccionComercial = '{0}'", direccionComercial)
         .AppendFormatLine("     , IdLocalidadComercial = {0}", idLocalidadComercial)
         .AppendFormatLine("     , RedesSociales = '{0}'", redesSociales)
         .AppendFormatLine("     , IdSucursalAsociadaPrecios = {0}", GetStringFromNumber(idSucursalAsociadaPrecios))
         .AppendFormatLine("     , PublicarEnWeb = {0}", GetStringFromBoolean(publicarEnWeb))
         .AppendFormatLine("     , IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
      End With

      Execute(myQuery)
      GrabarLogo(logoSucursal, idSucursal)
      Sincroniza_I(myQuery.ToString(), "Sucursales")
   End Sub

   Public Sub Sucursales_D(idSucursal As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM Sucursales")
         .AppendFormatLine("   WHERE IdSucursal = {0}", idSucursal)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Sucursales")
   End Sub

   'Private Sub SelectTexto(stb As StringBuilder, joinFuncion As Boolean, incluirLogo As Boolean)
   Private Sub SelectTexto(stb As StringBuilder, incluirLogo As Boolean)
      With stb
         .AppendLine("SELECT S.IdSucursal")
         .AppendLine("      ,S.Id")
         .AppendLine("      ,S.Nombre")
         .AppendLine("      ,S.Direccion")
         .AppendLine("      ,S.IdLocalidad")
         .AppendLine("      ,L.NombreLocalidad")
         .AppendLine("      ,S.Telefono")
         .AppendLine("      ,S.Correo")
         .AppendLine("      ,S.FechaInicioActiv")
         .AppendLine("      ,S.EstoyAca")
         .AppendLine("      ,S.SoyLaCentral")
         .AppendLine("      ,S.IdSucursalAsociada")
         .AppendLine("      ,S.ColorSucursal")
         If incluirLogo Then
            .AppendLine("      ,S.LogoSucursal")
         Else
            .AppendLine("      ,NULL LogoSucursal")
         End If
         .AppendLine("      ,SA.Nombre AS NombreSucursalAsociada")
         .AppendLine("      ,S.DireccionComercial")
         .AppendLine("      ,S.IdLocalidadComercial")
         .AppendLine("      ,L1.NombreLocalidad AS NombreLocalidadComercial")
         .AppendLine("      ,S.RedesSociales")
         .AppendLine("      ,S.IdSucursalAsociadaPrecios")
         .AppendLine("      ,SAP.Nombre AS NombreSucursalAsociadaPrecios")
         .AppendLine("      ,S.PublicarEnWeb")
         .AppendLine("      ,S.IdEmpresa")
         .AppendLine("      ,EM.NombreEmpresa")
         .AppendLine("  FROM Sucursales S")
         .AppendLine(" INNER JOIN Empresas EM ON EM.IdEmpresa = S.IdEmpresa")
         .AppendLine("  LEFT JOIN Localidades L ON S.IdLocalidad = L.IdLocalidad")
         .AppendLine("  LEFT JOIN Localidades L1 ON S.IdLocalidadComercial = L1.IdLocalidad")
         .AppendLine("  LEFT OUTER JOIN Sucursales SA ON S.IdSucursalAsociada = SA.IdSucursal")
         .AppendLine("  LEFT OUTER JOIN Sucursales SAP ON S.IdSucursalAsociadaPrecios = SAP.IdSucursal")
         'If joinFuncion Then
         '   .AppendFormatLine(" INNER JOIN UsuariosRoles UR ON UR.IdSucursal = S.IdSucursal")
         '   .AppendFormatLine(" INNER JOIN RolesFunciones RF ON RF.IdRol = UR.IdRol")
         'End If
      End With
   End Sub

   Public Function Sucursales_GA(idEmpresa As Integer?, idSucursal As Integer?) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         'SelectTexto(myQuery, joinFuncion:=False, incluirLogo:=False)
         SelectTexto(myQuery, incluirLogo:=False)
         .AppendFormatLine(" WHERE 1 = 1")
         If idEmpresa.HasValue Then
            .AppendFormatLine("   AND S.IdEmpresa = {0}", idEmpresa.Value)
         End If
         If idSucursal.HasValue Then
            .AppendFormatLine("   AND (S.IdSucursal = {0} OR S.IdSucursalAsociada = {0})", idSucursal.Value)
         End If
         OrdenPredeterminado(myQuery)
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function Sucursales_GA(incluirLogo As Boolean) As DataTable
      Return Sucursales_G(id:=0, nombre:=String.Empty, idEmpresa:=Nothing, idFuncion:=String.Empty, estoyAca:=Nothing, soyLaCentral:=Nothing, idSucursalExcluir:=0, publicarEnWeb:=Entidades.Publicos.SiNoTodos.TODOS, incluirLogo:=incluirLogo)
   End Function
   Public Function Sucursales_GA(idFuncion As String, publicarEnWeb As Entidades.Publicos.SiNoTodos, incluirLogo As Boolean) As DataTable
      Return Sucursales_GA(idFuncion, idEmpresa:=Nothing, publicarEnWeb, incluirLogo)
   End Function
   Public Function Sucursales_GA(idFuncion As String, idEmpresa As Integer?, publicarEnWeb As Entidades.Publicos.SiNoTodos, incluirLogo As Boolean) As DataTable
      Return Sucursales_G(id:=0, nombre:=String.Empty, idEmpresa, idFuncion:=idFuncion, estoyAca:=Nothing, soyLaCentral:=Nothing, idSucursalExcluir:=0, publicarEnWeb:=publicarEnWeb, incluirLogo:=incluirLogo)
   End Function
   Public Function Sucursales_GA_Excluye(idSucursalExcluir As Integer, incluirLogo As Boolean) As DataTable
      Return Sucursales_G(id:=0, nombre:=String.Empty, idEmpresa:=Nothing, idFuncion:=String.Empty, estoyAca:=Nothing, soyLaCentral:=Nothing, idSucursalExcluir:=idSucursalExcluir, publicarEnWeb:=Entidades.Publicos.SiNoTodos.TODOS, incluirLogo:=incluirLogo)
   End Function

   Public Function Sucursales_G1(idSucursal As Integer, incluirLogo As Boolean) As DataTable
      Return Sucursales_G(idSucursal, nombre:=String.Empty, idEmpresa:=Nothing, idFuncion:=String.Empty, estoyAca:=Nothing, soyLaCentral:=Nothing, idSucursalExcluir:=0, publicarEnWeb:=Entidades.Publicos.SiNoTodos.TODOS, incluirLogo:=incluirLogo)
   End Function

   Public Function Sucursales_GA(estoyAca As Boolean?, soyLaCentral As Boolean?, incluirLogo As Boolean) As DataTable
      Return Sucursales_G(id:=0, nombre:=String.Empty, idEmpresa:=Nothing, idFuncion:=String.Empty, estoyAca:=estoyAca, soyLaCentral:=soyLaCentral, idSucursalExcluir:=0, publicarEnWeb:=Entidades.Publicos.SiNoTodos.TODOS, incluirLogo:=incluirLogo)
   End Function

   Public Function GetPorCodigoNombre(id As Integer, nombre As String, idFuncion As String, incluirLogo As Boolean) As DataTable
      Return Sucursales_G(id, nombre, idEmpresa:=Nothing, idFuncion, estoyAca:=Nothing, soyLaCentral:=Nothing, idSucursalExcluir:=0, publicarEnWeb:=Entidades.Publicos.SiNoTodos.TODOS, incluirLogo:=incluirLogo)
   End Function
   Private Function Sucursales_G(id As Integer, nombre As String, idEmpresa As Integer?,
                                 idFuncion As String, estoyAca As Boolean?, soyLaCentral As Boolean?,
                                 idSucursalExcluir As Integer, publicarEnWeb As Entidades.Publicos.SiNoTodos, incluirLogo As Boolean) As DataTable
      Dim myQuery = New StringBuilder()

      With myQuery
         'SelectTexto(myQuery, Not String.IsNullOrWhiteSpace(idFuncion), incluirLogo)
         SelectTexto(myQuery, incluirLogo)
         .AppendLine(" WHERE 1 = 1")
         If id > 0 Then
            .AppendFormat("   AND S.IdSucursal = {0}", id).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(nombre) Then
            .AppendFormat("   AND S.Nombre LIKE '%{0}%'", nombre).AppendLine()
         End If
         If idEmpresa.HasValue Then
            .AppendFormatLine("   AND S.{0} = {1}", Entidades.Sucursal.Columnas.IdEmpresa.ToString(), idEmpresa.Value)
         End If

         If Not String.IsNullOrWhiteSpace(idFuncion) Then
            '.AppendFormatLine("   AND RF.IdFuncion = '{0}'", idFuncion)
            '.AppendFormatLine("   AND UR.IdUsuario = '{0}'", actual.Nombre)
            .AppendFormatLine("   AND EXISTS(SELECT 1")
            .AppendFormatLine("                FROM RolesFunciones RF")
            .AppendFormatLine("               INNER JOIN UsuariosRoles UR ON RF.IdRol = UR.IdRol")
            .AppendFormatLine("               WHERE RF.IdFuncion = '{0}'", idFuncion)
            .AppendFormatLine("                 AND UR.IdUsuario = '{0}'", actual.Nombre)
            .AppendFormatLine("                 AND UR.IdSucursal = S.IdSucursal)")
         End If

         If estoyAca.HasValue Then
            .AppendFormatLine("   AND S.EstoyAca = {0}", GetStringFromBoolean(estoyAca.Value))
         End If

         If soyLaCentral.HasValue Then
            .AppendFormatLine("   AND S.SoyLaCentral = {0}", GetStringFromBoolean(soyLaCentral.Value))
         End If

         If idSucursalExcluir > 0 Then
            .AppendFormatLine("   AND S.IdSucursal <> {0}", idSucursalExcluir)
         End If

         If publicarEnWeb <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND S.PublicarEnWeb = {0}", GetStringFromBoolean(publicarEnWeb = Entidades.Publicos.SiNoTodos.SI))
         End If

         OrdenPredeterminado(myQuery)
      End With

      Return GetDataTable(myQuery)

   End Function
   Public Function Sucursales_GetParaAlerta() As DataTable
      Dim myQuery = New StringBuilder()

      With myQuery
         SelectTexto(myQuery, False)
         .AppendLine(" WHERE 1 = 1")
         .AppendFormatLine("  AND (S.IdEmpresa = {0})  OR (SA.IdEmpresa = {0}) ", actual.Sucursal.IdEmpresa)
         OrdenPredeterminado(myQuery)
      End With

      Return GetDataTable(myQuery)

   End Function
   Public Sub GrabarLogo(imagen As System.Drawing.Image, idSucursal As Integer)
      If Not IO.Directory.Exists(Entidades.Publicos.DriverBase + "Eniac\") Then
         IO.Directory.CreateDirectory(Entidades.Publicos.DriverBase + "Eniac\")
      End If
      Dim path = String.Format("{0}{1}\{2}{3}", Entidades.Publicos.DriverBase, "Eniac", idSucursal, ".jpg")

      Dim stbQuery = New StringBuilder()
      If imagen IsNot Nothing Then
         imagen.Save(path)

         Dim fsArchivo = New IO.FileStream(path, IO.FileMode.Open, System.IO.FileAccess.Read)

         Dim iFileLength = Convert.ToInt32(fsArchivo.Length)

         Dim logo(Integer.Parse(fsArchivo.Length.ToString())) As Byte

         fsArchivo.Read(logo, 0, iFileLength)

         fsArchivo.Close()

         With stbQuery
            .Append(" UPDATE Sucursales ")
            .Append(" SET LogoSucursal = ")
            .Append(" @Logo ")
            .AppendFormat(" WHERE idSucursal = '{0}'", idSucursal)
         End With

         _da.Command.CommandText = stbQuery.ToString()
         _da.Command.CommandType = CommandType.Text
         Dim oParameter = _da.Command.CreateParameter()
         oParameter.ParameterName = "@Logo"
         oParameter.DbType = DbType.Binary
         oParameter.Size = logo.Length
         oParameter.Value = logo
         _da.Command.Parameters.Add(oParameter)
         _da.Command.Connection = _da.Connection
         _da.ExecuteNonQuery(_da.Command)
      Else
         With stbQuery
            .Append(" UPDATE Sucursales ")
            .Append(" SET LogoSucursal = ")
            .Append(" null ")
            .AppendFormat(" WHERE idSucursal = '{0}'", idSucursal)
         End With

         Execute(stbQuery)
      End If
   End Sub

   Public Function GetSoloIdsDeTodas() As List(Of Integer)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT S.IdSucursal")
         .AppendLine("  FROM Sucursales S")
         .AppendLine("  ORDER BY S.IdSucursal")
      End With

      Using dt = GetDataTable(stbQuery.ToString())
         Dim ids As List(Of Integer) = New List(Of Integer)()
         For Each dr As DataRow In dt.Rows
            ids.Add(Integer.Parse(dr("IdSucursal").ToString()))
         Next
         Return ids
      End Using
   End Function

   Public Sub EjecutaLimpiezaDeSucursales(idSucursal As Integer)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormat("EXECUTE dbo.LimpiaSucursal @IdSucursal")
      End With

      _da.Command.CommandText = stb.ToString()
      _da.Command.CommandType = CommandType.Text
      Dim oParameter = _da.Command.CreateParameter()
      oParameter.ParameterName = "@IdSucursal"
      oParameter.DbType = DbType.Int32
      oParameter.Value = idSucursal
      _da.Command.Parameters.Add(oParameter)
      _da.Command.Connection = _da.Connection
      _da.ExecuteNonQuery(_da.Command)
   End Sub

   Protected Overrides Sub OrdenPredeterminado(stb As StringBuilder)
      stb.AppendFormatLine(" ORDER BY S.Nombre")
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb1) SelectTexto(stb1, incluirLogo:=False), "S.",
                    New Dictionary(Of String, String) From {{"NombreLocalidad", "L.NombreLocalidad"},
                                                            {"NombreLocalidadComercial", "L1.NombreLocalidad"},
                                                            {"NombreSucursalAsociada", "SA.Nombre"},
                                                            {"NombreSucursalAsociadaPrecios", "SAP.Nombre"}})
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo("IdSucursal", "Sucursales"))
   End Function

   Public Function GetDepositoUbicacionPorDefectoPorSucursal() As DataTable
      Dim stbQuery = New StringBuilder()

      With stbQuery
         .AppendFormatLine("SELECT S.IdSucursal, S.NombreSucursal, SD.IdDeposito, SD.NombreDeposito, SU.IdUbicacion, SU.NombreUbicacion")
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("        SELECT SD.*")
         .AppendFormatLine("             , (SELECT MIN(SU.IdUbicacion) FROM SucursalesUbicaciones SU WHERE SU.IdSucursal = SD.IdSucursal AND SU.IdDeposito = SD.IdDeposito) IdUbicacion")
         .AppendFormatLine("          FROM (")
         .AppendFormatLine("                SELECT S.IdSucursal, S.Nombre NombreSucursal")
         .AppendFormatLine("                     , (SELECT MIN(SD.IdDeposito) FROM SucursalesDepositos SD WHERE SD.IdSucursal = S.IdSucursal AND SD.TipoDeposito = '{0}') IdDeposito",
                           Entidades.SucursalDeposito.TiposDepositos.OPERATIVO.ToString())
         .AppendFormatLine("                  FROM Sucursales S) SD")
         .AppendFormatLine("        ) S")
         .AppendFormatLine(" INNER JOIN SucursalesDepositos SD ON SD.IdSucursal = S.IdSucursal AND SD.IdDeposito = S.IdDeposito")
         .AppendFormatLine(" INNER JOIN SucursalesUbicaciones SU ON SU.IdSucursal = S.IdSucursal AND SU.IdDeposito = S.IdDeposito AND SU.IdUbicacion = S.IdUbicacion")
      End With

      Return GetDataTable(stbQuery)

   End Function

End Class