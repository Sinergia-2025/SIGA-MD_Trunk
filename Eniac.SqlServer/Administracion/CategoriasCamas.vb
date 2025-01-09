Imports System.Text

Public Class CategoriasCamas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CategoriasCamas_I(ByVal IdCategoriaCama As Integer, _
                                ByVal NombreCategoriaCama As String, _
                                ByVal CantidadAccionesRequeridas As Integer, _
                                ByVal Alto As Decimal, _
                                ByVal Ancho As Decimal, _
                                ByVal Largo As Decimal, _
                                ByVal TasaMunicipal As Decimal, _
                                ByVal ImporteExpensas As Decimal, _
                                ByVal ImporteAlquiler As Decimal, _
                                ByVal PorcDescAlquiler As Decimal, _
                                ByVal ImporteGastosAdmin As Decimal, _
                                ByVal ImporteGastosIntermAlq As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO CategoriasCamas ")
         .AppendLine("   (IdCategoriaCama")
         .AppendLine("   ,NombreCategoriaCama")
         .AppendLine("   ,CantidadAccionesRequeridas")
         .AppendLine("   ,Alto")
         .AppendLine("   ,Ancho")
         .AppendLine("   ,Largo")
         .AppendLine("   ,TasaMunicipal")
         .AppendLine("   ,ImporteExpensas")
         .AppendLine("   ,ImporteAlquiler")
         .AppendLine("   ,PorcDescAlquiler")
         .AppendLine("   ,ImporteGastosAdmin")
         .AppendLine("   ,ImporteGastosIntermAlq")
         .AppendLine(" ) VALUES (")
         .AppendLine(IdCategoriaCama.ToString())
         .AppendLine("  ,'" & NombreCategoriaCama & "'")
         .AppendLine("  ," & CantidadAccionesRequeridas.ToString())
         .AppendLine("  ," & Alto.ToString())
         .AppendLine("  ," & Ancho.ToString())
         .AppendLine("  ," & Largo.ToString())
         .AppendLine("  ," & TasaMunicipal.ToString())
         .AppendLine("  ," & ImporteExpensas.ToString())
         .AppendLine("  ," & ImporteAlquiler.ToString())
         .AppendLine("  ," & PorcDescAlquiler.ToString())
         .AppendLine("  ," & ImporteGastosAdmin.ToString())
         .AppendLine("  ," & ImporteGastosIntermAlq.ToString())
         .AppendLine(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CategoriasCamas")

   End Sub

   Public Sub CategoriasCamas_U(ByVal IdCategoriaCama As Integer, _
                                ByVal NombreCategoriaCama As String, _
                                ByVal CantidadAccionesRequeridas As Integer, _
                                ByVal Alto As Decimal, _
                                ByVal Ancho As Decimal, _
                                ByVal Largo As Decimal, _
                                ByVal TasaMunicipal As Decimal, _
                                ByVal ImporteExpensas As Decimal, _
                                ByVal ImporteAlquiler As Decimal, _
                                ByVal PorcDescAlquiler As Decimal, _
                                ByVal ImporteGastosAdmin As Decimal, _
                                ByVal ImporteGastosIntermAlq As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE CategoriasCamas ")
         .AppendLine("   SET NombreCategoriaCama = '" & NombreCategoriaCama & "'")
         .AppendLine("      ,CantidadAccionesRequeridas = " & CantidadAccionesRequeridas.ToString())
         .AppendLine("      ,alto = " & Alto.ToString())
         .AppendLine("      ,ancho = " & Ancho.ToString())
         .AppendLine("      ,largo = " & Largo.ToString())
         .AppendLine("      ,TasaMunicipal = " & TasaMunicipal.ToString())
         .AppendLine("      ,ImporteExpensas = " & ImporteExpensas.ToString())
         .AppendLine("      ,ImporteAlquiler = " & ImporteAlquiler.ToString())
         .AppendLine("      ,PorcDescAlquiler = " & PorcDescAlquiler.ToString())
         .AppendLine("      ,ImporteGastosAdmin = " & ImporteGastosAdmin.ToString())
         .AppendLine("      ,ImporteGastosIntermAlq = " & ImporteGastosIntermAlq.ToString())
         .AppendLine(" WHERE IdCategoriaCama = " & IdCategoriaCama.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CategoriasCamas")

   End Sub

   Public Sub CategoriasCamas_D(ByVal IdCategoriaCama As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM CategoriasCamas ")
         .AppendLine(" WHERE IdCategoriaCama = " & IdCategoriaCama.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CategoriasCamas")

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT C.IdCategoriaCama")
         .AppendLine("      ,NombreCategoriaCama")
         .AppendLine("      ,Alto")
         .AppendLine("      ,Ancho")
         .AppendLine("      ,Largo")
         .AppendLine("      ,CantidadAccionesRequeridas")
         .AppendLine("      ,TasaMunicipal")
         .AppendLine("      ,ImporteExpensas")
         .AppendLine("      ,ImporteAlquiler")
         .AppendLine("      ,PorcDescAlquiler")
         .AppendLine("      ,ImporteGastosAdmin")
         .AppendLine("      ,ImporteGastosIntermAlq")
         .AppendLine("  FROM CategoriasCamas C")
      End With
   End Sub

   Public Function CategoriasCamas_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" ORDER BY C.NombreCategoriaCama")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CategoriasCamas_G1(ByVal IdCategoriaCama As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE C.IdCategoriaCama = " & IdCategoriaCama.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "C." + columna
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
