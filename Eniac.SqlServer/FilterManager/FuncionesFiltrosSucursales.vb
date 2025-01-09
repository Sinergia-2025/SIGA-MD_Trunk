Namespace FilterManager
   Public Class FuncionesFiltrosSucursales
      Inherits Comunes

      Public Sub New(ByVal da As Eniac.Datos.DataAccess)
         MyBase.New(da)
      End Sub

      Public Sub FuncionesFiltrosSucursales_I(idFuncion As String,
                                              idSucursal As Integer,
                                              idFiltro As Integer)
         Dim myQuery As StringBuilder = New StringBuilder()

         With myQuery
            .AppendFormat("INSERT INTO {0} ", Entidades.FilterManager.FuncionFiltroSucursal.NombreTabla)
            .AppendFormatLine("({0}, {1}, {2})",
                              Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdFuncion.ToString(),
                              Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdSucursal.ToString(),
                              Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdFiltro.ToString())
            .AppendFormatLine("     VALUES ('{0}', {1}, {2}",
                              idFuncion,
                              idSucursal,
                              idFiltro)
            .AppendLine(")")
         End With
         Me.Execute(myQuery.ToString())
      End Sub

      Public Sub FuncionesFiltrosSucursales_M(idFuncion As String,
                                              idSucursal As Integer,
                                              idFiltro As Integer)

         Dim myQuery As StringBuilder = New StringBuilder()

         With myQuery
            .AppendFormatLine("MERGE INTO FuncionesFiltrosSucursales AS DEST")
            .AppendFormatLine("        USING (SELECT '{1}' {0}", Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdFuncion.ToString(), idFuncion)
            .AppendFormatLine("                    ,  {1}  {0}", Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdSucursal.ToString(), idSucursal)
            .AppendFormatLine("                    ,  {1}  {0}", Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdFiltro.ToString(), idFiltro)
            .AppendFormatLine("               ) AS ORIG")
            .AppendFormatLine("    ON DEST.{0} = ORIG.{0} AND DEST.{1} = ORIG.{1}",
                              Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdFuncion.ToString(),
                              Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdSucursal.ToString())
            .AppendFormatLine("    WHEN MATCHED THEN")
            .AppendFormatLine("        UPDATE SET DEST.{0} = ORIG.{0}", Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdFiltro.ToString())
            .AppendFormatLine("    WHEN NOT MATCHED THEN ")
            .AppendFormatLine("        INSERT ({0}, {1}, {2}) VALUES (ORIG.{0}, ORIG.{1}, ORIG.{2})",
                              Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdFuncion.ToString(),
                              Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdSucursal.ToString(),
                              Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdFiltro.ToString())
            .AppendFormatLine(";")
         End With
         Me.Execute(myQuery.ToString())
      End Sub

      Public Sub FuncionesFiltrosSucursales_U(idFuncion As String,
                                              idSucursal As Integer,
                                              idFiltro As Integer)

         Dim myQuery As StringBuilder = New StringBuilder()

         With myQuery
            .AppendFormatLine("UPDATE {0} ", Entidades.FilterManager.FuncionFiltroSucursal.NombreTabla)
            .AppendFormatLine("   SET {0} =  {1} ", Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdFiltro.ToString(), idFiltro)
            .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdFuncion.ToString(), idFuncion)
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdSucursal.ToString(), idSucursal)
         End With
         Me.Execute(myQuery.ToString())
      End Sub

      Public Sub FuncionesFiltrosSucursales_D(idFuncion As String, idSucursal As Integer)
         Dim myQuery As StringBuilder = New StringBuilder()

         With myQuery
            .AppendFormatLine("DELETE FROM {0}", Entidades.FilterManager.FuncionFiltroSucursal.NombreTabla)
            .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdFuncion.ToString(), idFuncion)
            If idSucursal > 0 Then
               .AppendFormatLine("   AND {0} =  {1} ", Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdSucursal.ToString(), idSucursal)
            End If
         End With

         Me.Execute(myQuery.ToString())
      End Sub

      Private Sub SelectTexto(stb As StringBuilder)
         With stb
            .AppendFormatLine("SELECT FFS.*")
            .AppendFormatLine("  FROM {0} AS FFS", Entidades.FilterManager.FuncionFiltroSucursal.NombreTabla)
         End With
      End Sub

      Public Function FuncionesFiltrosSucursales_GA() As DataTable
         Return FuncionesFiltrosSucursales_G(idFuncion:=String.Empty, idSucursal:=0)
      End Function
      Private Function FuncionesFiltrosSucursales_G(idFuncion As String, idSucursal As Integer) As DataTable
         Dim myQuery As StringBuilder = New StringBuilder()
         With myQuery
            Me.SelectTexto(myQuery)
            .AppendFormatLine(" WHERE 1 = 1")

            If Not String.IsNullOrWhiteSpace(idFuncion) Then
               .AppendFormatLine("   AND FFS.{0} = '{1}'", Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdFuncion.ToString(), idFuncion)
            End If
            If idSucursal > 0 Then
               .AppendFormatLine("   AND FFS.{0} =  {1} ", Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdSucursal.ToString(), idSucursal)
            End If

         End With
         Return Me.GetDataTable(myQuery.ToString())
      End Function

      Public Function FuncionesFiltrosSucursales_G1(idFuncion As String, idSucursal As Integer) As DataTable
         Return FuncionesFiltrosSucursales_G(idFuncion, idSucursal)
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
         columna = "FFS." + columna
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