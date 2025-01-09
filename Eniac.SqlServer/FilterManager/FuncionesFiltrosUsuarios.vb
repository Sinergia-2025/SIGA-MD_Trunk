Namespace FilterManager
   Public Class FuncionesFiltrosUsuarios
      Inherits Comunes

      Public Sub New(ByVal da As Eniac.Datos.DataAccess)
         MyBase.New(da)
      End Sub

      Public Sub FuncionesFiltrosUsuarios_I(idFuncion As String,
                                            idUsuario As String,
                                            idSucursal As Integer,
                                            idFiltro As Integer)
         Dim myQuery As StringBuilder = New StringBuilder()

         With myQuery
            .AppendFormat("INSERT INTO {0} ", Entidades.FilterManager.FuncionFiltroUsuario.NombreTabla)
            .AppendFormatLine("({0}, {1}, {2}, {3})",
                              Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdFuncion.ToString(),
                              Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdUsuario.ToString(),
                              Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdSucursal.ToString(),
                              Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdFiltro.ToString())
            .AppendFormatLine("     VALUES ('{0}', '{1}', {2}, {3}",
                              idFuncion,
                              idUsuario,
                              idSucursal,
                              idFiltro)
            .AppendLine(")")
         End With
         Me.Execute(myQuery.ToString())
      End Sub

      Public Sub FuncionesFiltrosUsuarios_M(idFuncion As String,
                                            idUsuario As String,
                                            idSucursal As Integer,
                                            idFiltro As Integer)

         Dim myQuery As StringBuilder = New StringBuilder()

         With myQuery
            .AppendFormatLine("MERGE INTO FuncionesFiltrosUsuarios AS DEST")
            .AppendFormatLine("        USING (SELECT '{1}' {0}", Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdFuncion.ToString(), idFuncion)
            .AppendFormatLine("                    , '{1}' {0}", Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdUsuario.ToString(), idUsuario)
            .AppendFormatLine("                    ,  {1}  {0}", Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdSucursal.ToString(), idSucursal)
            .AppendFormatLine("                    ,  {1}  {0}", Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdFiltro.ToString(), idFiltro)
            .AppendFormatLine("               ) AS ORIG")
            .AppendFormatLine("    ON DEST.{0} = ORIG.{0} AND DEST.{1} = ORIG.{1} AND DEST.{2} = ORIG.{2}",
                              Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdFuncion.ToString(),
                              Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdUsuario.ToString(),
                              Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdSucursal.ToString())
            .AppendFormatLine("    WHEN MATCHED THEN")
            .AppendFormatLine("        UPDATE SET DEST.{0} = ORIG.{0}", Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdFiltro.ToString())
            .AppendFormatLine("    WHEN NOT MATCHED THEN ")
            .AppendFormatLine("        INSERT ({0}, {1}, {2}, {3}) VALUES (ORIG.{0}, ORIG.{1}, ORIG.{2}, ORIG.{3})",
                              Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdFuncion.ToString(),
                              Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdUsuario.ToString(),
                              Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdSucursal.ToString(),
                              Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdFiltro.ToString())
            .AppendFormatLine(";")
         End With
         Me.Execute(myQuery.ToString())
      End Sub

      Public Sub FuncionesFiltrosUsuarios_U(idFuncion As String,
                                            idUsuario As String,
                                            idSucursal As Integer,
                                            idFiltro As Integer)

         Dim myQuery As StringBuilder = New StringBuilder()

         With myQuery
            .AppendFormatLine("UPDATE {0} ", Entidades.FilterManager.FuncionFiltroUsuario.NombreTabla)
            .AppendFormatLine("   SET {0} =  {1} ", Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdFiltro.ToString(), idFiltro)
            .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdFuncion.ToString(), idFuncion)
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdUsuario.ToString(), idUsuario)
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdSucursal.ToString(), idSucursal)
         End With
         Me.Execute(myQuery.ToString())
      End Sub

      Public Sub FuncionesFiltrosUsuarios_D(idFuncion As String, idUsuario As String, idSucursal As Integer)
         Dim myQuery As StringBuilder = New StringBuilder()

         With myQuery
            .AppendFormatLine("DELETE FROM {0}", Entidades.FilterManager.FuncionFiltroUsuario.NombreTabla)
            .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdFuncion.ToString(), idFuncion)
            If Not String.IsNullOrWhiteSpace(idUsuario) Then
               .AppendFormatLine("   AND {0} = '{1}'", Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdUsuario.ToString(), idUsuario)
            End If
            If idSucursal > 0 Then
               .AppendFormatLine("   AND {0} =  {1} ", Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdSucursal.ToString(), idSucursal)
            End If
         End With

         Me.Execute(myQuery.ToString())
      End Sub

      Private Sub SelectTexto(stb As StringBuilder)
         With stb
            .AppendFormatLine("SELECT FFU.*")
            .AppendFormatLine("  FROM {0} AS FFU", Entidades.FilterManager.FuncionFiltroUsuario.NombreTabla)
         End With
      End Sub

      Public Function FuncionesFiltrosUsuarios_GA() As DataTable
         Return FuncionesFiltrosUsuarios_G(idFuncion:=String.Empty, idUsuario:=String.Empty, idSucursal:=0)
      End Function
      Private Function FuncionesFiltrosUsuarios_G(idFuncion As String,
                                                  idUsuario As String,
                                                  idSucursal As Integer) As DataTable
         Dim myQuery As StringBuilder = New StringBuilder()
         With myQuery
            Me.SelectTexto(myQuery)
            .AppendFormatLine(" WHERE 1 = 1")

            If Not String.IsNullOrWhiteSpace(idFuncion) Then
               .AppendFormatLine("   AND FFU.{0} = '{1}'", Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdFuncion.ToString(), idFuncion)
            End If
            If Not String.IsNullOrWhiteSpace(idUsuario) Then
               .AppendFormatLine("   AND FFU.{0} = '{1}'", Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdUsuario.ToString(), idUsuario)
            End If
            If idSucursal > 0 Then
               .AppendFormatLine("   AND FFU.{0} =  {1} ", Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdSucursal.ToString(), idSucursal)
            End If

         End With
         Return Me.GetDataTable(myQuery.ToString())
      End Function

      Public Function FuncionesFiltrosUsuarios_G1(idFuncion As String, idUsuario As String, idSucursal As Integer) As DataTable
         Return FuncionesFiltrosUsuarios_G(idFuncion, idUsuario, idSucursal)
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
         columna = "FFU." + columna
         ''End If

         Dim stb As StringBuilder = New StringBuilder()
         With stb
            Me.SelectTexto(stb)
            .AppendFormatLine(FormatoBuscar, columna, valor)
         End With
         Return Me.GetDataTable(stb.ToString())
      End Function

   End Class
End Namespace