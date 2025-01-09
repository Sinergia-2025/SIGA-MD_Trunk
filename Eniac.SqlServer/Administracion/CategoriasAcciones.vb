Public Class CategoriasAcciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CategoriasAcciones_I(IdCategoriaAccion As Integer,
                                   NombreCategoriaAccion As String,
                                   Pies As Integer,
                                   CoeficienteDistribucionExpensas As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO CategoriasAcciones ({0}, {1}, {2}, {3}) ",
                       Entidades.CategoriaAccion.Columnas.IdCategoriaAccion.ToString(),
                       Entidades.CategoriaAccion.Columnas.NombreCategoriaAccion.ToString(),
                       Entidades.CategoriaAccion.Columnas.Pies.ToString(),
                       Entidades.CategoriaAccion.Columnas.CoeficienteDistribucionExpensas.ToString())
         .AppendFormat(" VALUES ({0}, '{1}', {2}, {3})",
                       IdCategoriaAccion,
                       NombreCategoriaAccion,
                       Pies,
                       CoeficienteDistribucionExpensas)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CategoriasAcciones_U(IdCategoriaAccion As Integer,
                                   NombreCategoriaAccion As String,
                                   Pies As Integer,
                                   CoeficienteDistribucionExpensas As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE CategoriasAcciones ")
         .AppendFormat("   SET NombreCategoriaAccion = '{0}'", NombreCategoriaAccion)
         .AppendFormat("      ,Pies = {0}", Pies)
         .AppendFormat("      ,CoeficienteDistribucionExpensas = {0}", CoeficienteDistribucionExpensas)
         .AppendFormat(" WHERE IdCategoriaAccion = {0}", IdCategoriaAccion)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CategoriasAcciones_D(ByVal IdCategoriaAccion As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM CategoriasAcciones WHERE IdCategoriaAccion = {0}", IdCategoriaAccion)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendLine("SELECT CA.*")
         .AppendLine("  FROM CategoriasAcciones CA")
      End With
   End Sub

   Public Function CategoriasAcciones_GA() As DataTable
      Return CategoriasAcciones_G(0, String.Empty, False)
   End Function

   Public Function CategoriasAcciones_G1(ByVal IdCategoriaAccion As Integer) As DataTable
      Return CategoriasAcciones_G(IdCategoriaAccion, String.Empty, False)
   End Function

   Public Function GetPorNombreExacto(nombreCategoriaAccion As String) As DataTable
      Return CategoriasAcciones_G(0, nombreCategoriaAccion, True)
   End Function

   Private Function CategoriasAcciones_G(IdCategoriaAccion As Integer, nombreCategoriaAccion As String, nombreCategoriaAccionExacto As Boolean) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE 1 = 1")
         If IdCategoriaAccion > 0 Then
            .AppendFormat("   AND CA.IdCategoriaAccion = {0}", IdCategoriaAccion)
         End If
         If Not String.IsNullOrWhiteSpace(nombreCategoriaAccion) Then
            If nombreCategoriaAccionExacto Then
               .AppendFormat("   AND NombreCategoriaAccion = '{0}'", nombreCategoriaAccion)
            Else
               .AppendFormat("   AND NombreCategoriaAccion LIKE '%{0}%'", nombreCategoriaAccion)
            End If
         End If
         .AppendLine(" ORDER BY CA.NombreCategoriaAccion")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "CA." + columna
      'If columna = "CE.NombreTipoEmbarcacion" Then columna = columna.Replace("CE.", "TE.")
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.CategoriaAccion.Columnas.IdCategoriaAccion.ToString, "CategoriasAcciones"))
   End Function

End Class