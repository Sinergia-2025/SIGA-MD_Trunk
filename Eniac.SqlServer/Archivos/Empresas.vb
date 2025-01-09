Public Class Empresas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Empresas_I(idEmpresa As Integer, nombreEmpresa As String, cuitEmpresa As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.Empresa.NombreTabla).AppendLine()
         .AppendFormatLine("           ({0}", Entidades.Empresa.Columnas.IdEmpresa.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Empresa.Columnas.NombreEmpresa.ToString())
         .AppendFormatLine("           ,{0}", Entidades.Empresa.Columnas.CuitEmpresa.ToString())
         .AppendFormatLine("  ) VALUES (")
         .AppendFormatLine("            {0}", idEmpresa)
         .AppendFormatLine("          ,'{0}'", nombreEmpresa)
         .AppendFormatLine("          ,'{0}'", cuitEmpresa)
         .AppendLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub Empresas_U(idEmpresa As Integer, nombreEmpresa As String, cuitEmpresa As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0} ", Entidades.Empresa.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.Empresa.Columnas.NombreEmpresa.ToString(), nombreEmpresa)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Empresa.Columnas.CuitEmpresa.ToString(), cuitEmpresa)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.Empresa.Columnas.IdEmpresa.ToString(), idEmpresa)
      End With
      Execute(myQuery)
   End Sub

   Public Sub Empresas_D(idEmpresa As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.Empresa.NombreTabla, Entidades.Empresa.Columnas.IdEmpresa.ToString(), idEmpresa)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder, idFuncion As String)
      With stb
         .AppendFormatLine("SELECT EM.*")
         .AppendFormatLine("     , P.ValorParametro AS IdCategoriaFiscal")
         .AppendFormatLine("     , CF.NombreCategoriaFiscal")
         .AppendFormatLine("  FROM {0} AS EM ", Entidades.Empresa.NombreTabla)
         .AppendFormatLine("  LEFT JOIN (SELECT * FROM  Parametros WHERE (IdParametro = 'CATEGORIAFISCALEMPRESA')) AS P ON EM.IdEmpresa = P.IdEmpresa")
         .AppendFormatLine(" INNER JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = P.ValorParametro")
         If Not String.IsNullOrWhiteSpace(idFuncion) Then
            .AppendFormatLine(" INNER JOIN (SELECT DISTINCT S.IdEmpresa")
            .AppendFormatLine("               FROM Sucursales S")
            .AppendFormatLine("              INNER JOIN UsuariosRoles  UR ON UR.IdSucursal = S.IdSucursal")
            .AppendFormatLine("              INNER JOIN RolesFunciones RF ON RF.IdRol      = UR.IdRol")
            .AppendFormatLine("             WHERE RF.IdFuncion = '{0}'", idFuncion)
            .AppendFormatLine("               AND UR.IdUsuario = '{0}') S ON S.IdEmpresa = EM.IdEmpresa", actual.Nombre)
         End If
      End With
   End Sub

   Public Function Empresas_GA() As DataTable
      Return Empresas_G(idEmpresa:=0, nombreEmpresa:=String.Empty, nombreExacto:=False, cuitEmpresa:=String.Empty, cuitExacto:=False, idFuncion:=String.Empty)
   End Function
   Public Function Empresas_GA(nombreEmpresa As String, nombreExacto As Boolean, idFuncion As String) As DataTable
      Return Empresas_G(idEmpresa:=0, nombreEmpresa:=nombreEmpresa, nombreExacto:=nombreExacto, cuitEmpresa:=String.Empty, cuitExacto:=False, idFuncion:=idFuncion)
   End Function
   Public Function Empresas_GA_Cuit(cuitEmpresa As String, cuitExacto As Boolean) As DataTable
      Return Empresas_G(idEmpresa:=0, nombreEmpresa:=String.Empty, nombreExacto:=False, cuitEmpresa:=cuitEmpresa, cuitExacto:=cuitExacto, idFuncion:=String.Empty)
   End Function
   Public Function Empresas_GA(idFuncion As String) As DataTable
      Return Empresas_G(idEmpresa:=0, nombreEmpresa:=String.Empty, nombreExacto:=False, cuitEmpresa:=String.Empty, cuitExacto:=False, idFuncion:=idFuncion)
   End Function
   Private Function Empresas_G(idEmpresa As Integer, nombreEmpresa As String, nombreExacto As Boolean, cuitEmpresa As String, cuitExacto As Boolean,
                               idFuncion As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery, idFuncion)

         .AppendLine(" WHERE 1 = 1")
         If idEmpresa > 0 Then
            .AppendFormatLine("   AND EM.{0} = {1}", Entidades.Empresa.Columnas.IdEmpresa.ToString(), idEmpresa)
         End If
         If Not String.IsNullOrWhiteSpace(nombreEmpresa) Then
            If nombreExacto Then
               .AppendFormatLine("   AND EM.{0} = '{1}'", Entidades.Empresa.Columnas.NombreEmpresa.ToString(), nombreEmpresa)
            Else
               .AppendFormatLine("   AND EM.{0} LIKE '%{1}%'", Entidades.Empresa.Columnas.NombreEmpresa.ToString(), nombreEmpresa)
            End If
         End If
         If Not String.IsNullOrWhiteSpace(cuitEmpresa) Then
            If cuitExacto Then
               .AppendFormatLine("   AND EM.{0} = '{1}'", Entidades.Empresa.Columnas.CuitEmpresa.ToString(), cuitEmpresa)
            Else
               .AppendFormatLine("   AND EM.{0} LIKE '%{1}%'", Entidades.Empresa.Columnas.CuitEmpresa.ToString(), cuitEmpresa)
            End If
         End If

         .AppendFormatLine(" ORDER BY EM.{0}", Entidades.Empresa.Columnas.NombreEmpresa.ToString())
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function Empresas_G1(idEmpresa As Integer, idFuncion As String) As DataTable
      Return Empresas_G(idEmpresa:=idEmpresa, nombreEmpresa:=String.Empty, nombreExacto:=False, cuitEmpresa:=String.Empty, cuitExacto:=False, idFuncion:=idFuncion)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      If columna = "NombreCategoriaFiscal" Then
         columna = "CF.NombreCategoriaFiscal"
      Else
         columna = "EM." + columna
      End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb, idFuncion:=String.Empty)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.Empresa.Columnas.IdEmpresa.ToString(), Entidades.Empresa.NombreTabla))
   End Function

End Class