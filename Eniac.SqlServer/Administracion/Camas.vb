Public Class Camas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      Me.SelectTexto(stb, False)
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder, agregarResponsableCargos As Boolean)
      SelectTexto(stb, agregarResponsableCargos, 0)
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder, agregarResponsableCargos As Boolean, clienteParaSinPosesion As Long)
      With stb
         .Length = 0
         .AppendLine("SELECT C.IdCama")
         .AppendLine("      ,C.CodigoCama")
         .AppendLine("      ,C.IdNave")
         .AppendLine("      ,N.NombreNave")
         .AppendLine("      ,C.Lado")
         .AppendLine("      ,C.Fila")
         .AppendLine("      ,C.Columna")
         .AppendLine("      ,C.Posicion")
         .AppendLine("      ,C.m3")
         .AppendLine("      ,C.Estado")
         .AppendLine("      ,C.IdCategoriaCama")
         .AppendLine("      ,CAT.NombreCategoriaCama")

         .AppendLine("      ,CL.IdCliente")
         .AppendLine("      ,CL.CodigoCliente")
         .AppendLine("      ,CL.NombreCliente")
         .AppendLine("      ,'' as Observacion")

         .AppendLine("  FROM Camas C")
         .AppendLine("  LEFT JOIN CategoriasCamas CAT ON C.IdCategoriaCama = CAT.IdCategoriaCama")
         .AppendLine("  LEFT JOIN Naves N ON C.IdNave = N.IdNave")
         .AppendLine("  LEFT JOIN GruposCamas GC ON C.IdGrupoCama = GC.IdGrupoCama")
         .AppendLine("  LEFT JOIN CamasClientes CC ON CC.IdCama = C.IdCama  AND CC.Cargos = 1")
         .AppendLine("  LEFT JOIN Clientes CL ON CL.IdCliente = CC.IdCliente")
      End With
   End Sub

   Public Function GetFiltradoCamaPorCodigo(Codigo As String) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         Me.SelectTexto(stbQuery)
         .AppendLine(" WHERE C.CodigoCama LIKE '%" & Codigo & "%'")
      End With
      Return GetDataTable(stbQuery)
   End Function

End Class
