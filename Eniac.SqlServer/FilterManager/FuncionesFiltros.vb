Namespace FilterManager
   Public Class FuncionesFiltros
      Inherits Comunes

      Public Sub New(ByVal da As Eniac.Datos.DataAccess)
         MyBase.New(da)
      End Sub

      Public Sub FuncionesFiltros_I(idFuncion As String,
                                    idFiltro As Integer,
                                    idSucursal As Integer,
                                    idUsuario As String,
                                    nombreFiltro As String)
         Dim myQuery As StringBuilder = New StringBuilder()

         With myQuery
            .AppendFormat("INSERT INTO {0} ", Entidades.FilterManager.FuncionFiltro.NombreTabla)
            .AppendFormatLine("({0}, {1}, {2}, {3}, {4})",
                              Entidades.FilterManager.FuncionFiltro.Columnas.IdFuncion.ToString(),
                              Entidades.FilterManager.FuncionFiltro.Columnas.IdFiltro.ToString(),
                              Entidades.FilterManager.FuncionFiltro.Columnas.IdSucursal.ToString(),
                              Entidades.FilterManager.FuncionFiltro.Columnas.IdUsuario.ToString(),
                              Entidades.FilterManager.FuncionFiltro.Columnas.NombreFiltro.ToString())
            .AppendFormatLine("     VALUES ('{0}', {1}, {2}, {3}, '{4}'",
                              idFuncion,
                              idFiltro,
                              GetStringFromNumber(idSucursal),
                              GetStringParaQueryConComillas(idUsuario),
                              nombreFiltro)
            .AppendLine(")")
         End With
         Me.Execute(myQuery.ToString())
      End Sub

      Public Sub FuncionesFiltros_U(idFuncion As String,
                                    idFiltro As Integer,
                                    idSucursal As Integer,
                                    idUsuario As String,
                                    nombreFiltro As String)

         Dim myQuery As StringBuilder = New StringBuilder()

         With myQuery
            .AppendFormatLine("UPDATE {0} ", Entidades.FilterManager.FuncionFiltro.NombreTabla)
            .AppendFormatLine("   SET {0} =  {1} ", Entidades.FilterManager.FuncionFiltro.Columnas.IdSucursal.ToString(), GetStringFromNumber(idSucursal))
            .AppendFormatLine("     , {0} =  {1} ", Entidades.FilterManager.FuncionFiltro.Columnas.IdUsuario.ToString(), GetStringParaQueryConComillas(idUsuario))
            .AppendFormatLine("     , {0} = '{1}'", Entidades.FilterManager.FuncionFiltro.Columnas.NombreFiltro.ToString(), nombreFiltro)
            .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.FilterManager.FuncionFiltro.Columnas.IdFuncion.ToString(), idFuncion)
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.FilterManager.FuncionFiltro.Columnas.IdFiltro.ToString(), idFiltro)
         End With
         Me.Execute(myQuery.ToString())
      End Sub

      Public Sub FuncionesFiltros_D(idFuncion As String, idFiltro As Integer)
         Dim myQuery As StringBuilder = New StringBuilder()

         With myQuery
            .AppendFormatLine("DELETE FROM {0}", Entidades.FilterManager.FuncionFiltro.NombreTabla)
            .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.FilterManager.FuncionFiltro.Columnas.IdFuncion.ToString(), idFuncion)
            If idFiltro > 0 Then
               .AppendFormatLine("   AND {0} =  {1} ", Entidades.FilterManager.FuncionFiltro.Columnas.IdFiltro.ToString(), idFiltro)
            End If
         End With

         Me.Execute(myQuery.ToString())
      End Sub

      Private Sub SelectTexto(stb As StringBuilder)
         With stb
            .AppendFormatLine("SELECT FF.*")
            .AppendFormatLine("  FROM {0} AS FF", Entidades.FilterManager.FuncionFiltro.NombreTabla)
         End With
      End Sub

      Public Function FuncionesFiltros_GA() As DataTable
         Return FuncionesFiltros_G(idFuncion:=String.Empty, idFiltro:=0, idSucursal:=0, idUsuario:=String.Empty, nullOrIdSucursal:=0, nullOrIdUsuario:=String.Empty, idUsuarioParaDefault:=String.Empty, idSucursalParaDefault:=0)
      End Function
      Public Function FuncionesFiltros_GA(idFuncion As String,
                                          nullOrIdSucursal As Integer,
                                          nullOrIdUsuario As String) As DataTable
         Return FuncionesFiltros_G(idFuncion:=idFuncion, idFiltro:=0, idSucursal:=0, idUsuario:=String.Empty, nullOrIdSucursal:=nullOrIdSucursal, nullOrIdUsuario:=nullOrIdUsuario, idUsuarioParaDefault:=String.Empty, idSucursalParaDefault:=0)
      End Function
      Private Function FuncionesFiltros_G(idFuncion As String,
                                          idFiltro As Integer,
                                          idSucursal As Integer,
                                          idUsuario As String,
                                          nullOrIdSucursal As Integer,
                                          nullOrIdUsuario As String,
                                          idUsuarioParaDefault As String,
                                          idSucursalParaDefault As Integer) As DataTable
         Dim myQuery As StringBuilder = New StringBuilder()
         With myQuery
            Me.SelectTexto(myQuery)
            .AppendFormatLine(" WHERE 1 = 1")

            If Not String.IsNullOrWhiteSpace(idFuncion) Then
               .AppendFormatLine("   AND FF.{0} = '{1}'", Entidades.FilterManager.FuncionFiltro.Columnas.IdFuncion.ToString(), idFuncion)
            End If
            If idFiltro > 0 Then
               .AppendFormatLine("   AND FF.{0} =  {1} ", Entidades.FilterManager.FuncionFiltro.Columnas.IdFiltro.ToString(), idFiltro)
            End If
            If idSucursal > 0 Then
               .AppendFormatLine("   AND FF.{0} =  {1} ", Entidades.FilterManager.FuncionFiltro.Columnas.IdSucursal.ToString(), idSucursal)
            End If
            If Not String.IsNullOrWhiteSpace(idUsuario) Then
               .AppendFormatLine("   AND FF.{0} = '{1}'", Entidades.FilterManager.FuncionFiltro.Columnas.IdUsuario.ToString(), idUsuario)
            End If

            If nullOrIdSucursal > 0 Then
               .AppendFormatLine("   AND (FF.{0} IS NULL OR FF.{0} =  {1})", Entidades.FilterManager.FuncionFiltro.Columnas.IdSucursal.ToString(), nullOrIdSucursal)
            End If
            If Not String.IsNullOrWhiteSpace(nullOrIdUsuario) Then
               .AppendFormatLine("   AND (FF.{0} IS NULL OR FF.{0} = '{1}')", Entidades.FilterManager.FuncionFiltro.Columnas.IdUsuario.ToString(), nullOrIdUsuario)
            End If

            If idSucursalParaDefault > 0 Then
               If String.IsNullOrWhiteSpace(idUsuarioParaDefault) Then
                  .AppendFormatLine("   AND EXISTS(SELECT TOP 1 * FROM FuncionesFiltrosSucursales FFU")
                  .AppendFormatLine("               WHERE FFU.IdFuncion = FF.IdFuncion")
                  .AppendFormatLine("                 AND FFU.IdSucursal = {0}", idSucursalParaDefault)
                  .AppendFormatLine("                 AND FFU.IdFiltro = FF.IdFiltro)")
               Else
                  .AppendFormatLine("   AND EXISTS(SELECT TOP 1 * FROM FuncionesFiltrosUsuarios FFU")
                  .AppendFormatLine("                  WHERE FFU.IdFuncion = FF.IdFuncion")
                  .AppendFormatLine("                 AND FFU.IdUsuario = '{0}'", idUsuarioParaDefault)
                  .AppendFormatLine("                 AND FFU.IdSucursal = {0}", idSucursalParaDefault)
                  .AppendFormatLine("                 AND FFU.IdFiltro = FF.IdFiltro)")
               End If
            End If

         End With
         Return Me.GetDataTable(myQuery.ToString())
      End Function

      Public Function FuncionesFiltros_G_Default(idFuncion As String, idSucursal As Integer, idUsuario As String) As DataTable
         Return FuncionesFiltros_G(idFuncion, idFiltro:=0, idSucursal:=0, idUsuario:=String.Empty, nullOrIdSucursal:=0, nullOrIdUsuario:=String.Empty, idUsuarioParaDefault:=idUsuario, idSucursalParaDefault:=idSucursal)
      End Function

      Public Function FuncionesFiltros_G1(idFuncion As String, idFiltro As Integer) As DataTable
         Return FuncionesFiltros_G(idFuncion, idFiltro, idSucursal:=0, idUsuario:=String.Empty, nullOrIdSucursal:=0, nullOrIdUsuario:=String.Empty, idUsuarioParaDefault:=String.Empty, idSucursalParaDefault:=0)
      End Function

      Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

         'If columna = "NombreTipoNovedad" Then
         '   columna = "TN." + columna
         'ElseIf columna = "PorDefecto_SN" Then
         '   columna = "CASE WHEN TCN.PorDefecto = 0 THEN 'NO' ELSE 'SI' END"
         'ElseIf columna = "VisibleParaCliente_SN" Then
         '   columna = "CASE WHEN TCN.VisibleParaCliente = 0 THEN 'NO' ELSE 'SI' END"
         'ElseIf columna = "VisibleParaRepresentante_SN" Then
         '   columna = "CASE WHEN TCN.VisibleParaRepresentante = 0 THEN 'NO' ELSE 'SI' END"
         'Else
         columna = "FF." + columna
         ''End If

         Dim stb As StringBuilder = New StringBuilder()
         With stb
            Me.SelectTexto(stb)
            .AppendFormatLine(FormatoBuscar, columna, valor)
         End With
         Return Me.GetDataTable(stb.ToString())
      End Function

      Public Overloads Function GetCodigoMaximo(idFuncion As String) As Integer
         Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.FilterManager.FuncionFiltro.Columnas.IdFiltro.ToString(), Entidades.FilterManager.FuncionFiltro.NombreTabla,
                                                       String.Format("{0} = '{1}'", Entidades.FilterManager.FuncionFiltro.Columnas.IdFuncion.ToString(), idFuncion)))
      End Function

   End Class
End Namespace