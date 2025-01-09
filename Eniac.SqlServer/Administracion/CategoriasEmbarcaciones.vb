Imports System.Text

Public Class CategoriasEmbarcaciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CategoriasEmbarcacion_I(IdCategoriaEmbarcacion As Integer,
                                      NombreCategoriaEmbarcacion As String,
                                      IdTipoEmbarcacion As Integer,
                                      ImporteExpensas As Decimal,
                                      ImporteAlquiler As Decimal,
                                      PorcDescAlquiler As Decimal,
                                      ImporteGastosAdmin As Decimal,
                                      ImporteGastosIntermAlq As Decimal,
                                      ExpensasRelacionCategoria As Decimal,
                                      alto As Decimal,
                                      ancho As Decimal,
                                      largo As Decimal,
                                      IdInteres As Integer?)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO CategoriasEmbarcaciones ")
         .AppendLine("   (IdCategoriaEmbarcacion")
         .AppendLine("   ,NombreCategoriaEmbarcacion")
         .AppendLine("   ,IdTipoEmbarcacion")
         .AppendLine("   ,ImporteExpensas")
         .AppendLine("   ,ImporteAlquiler")
         .AppendLine("   ,PorcDescAlquiler")
         .AppendLine("   ,ImporteGastosAdmin")
         .AppendLine("   ,ImporteGastosIntermAlq")
         .AppendLine("   ,ExpensasRelacionCategoria")
         .AppendLine("   ,Alto")
         .AppendLine("   ,Ancho")
         .AppendLine("   ,Largo")
         .AppendLine("   ,IdInteres") 'PE-31303
         .AppendLine(" ) VALUES (")
         .AppendLine(IdCategoriaEmbarcacion.ToString())
         .AppendLine("   ,'" & NombreCategoriaEmbarcacion & "'")
         .AppendLine("   ," & IdTipoEmbarcacion.ToString())
         .AppendLine("   ," & ImporteExpensas.ToString())
         .AppendLine("   ," & ImporteAlquiler.ToString())
         .AppendLine("   ," & PorcDescAlquiler)
         .AppendLine("   ," & ImporteGastosAdmin.ToString())
         .AppendLine("   ," & ImporteGastosIntermAlq.ToString())
         .AppendLine("   ," & ExpensasRelacionCategoria.ToString())
         .AppendLine("   ," & alto.ToString())
         .AppendLine("   ," & ancho.ToString())
         .AppendLine("   ," & largo.ToString())
         'PE-31303
         If IdInteres.HasValue AndAlso IdInteres.Value > 0 Then
            .AppendFormat(" ,{0}", IdInteres)
         Else
            .AppendFormat(" ,NULL")
         End If
         .AppendLine(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CategoriasEmbarcaciones")

   End Sub

   Public Sub CategoriasEmbarcacion_U(IdCategoriaEmbarcacion As Integer,
                                      NombreCategoriaEmbarcacion As String,
                                      IdTipoEmbarcacion As Integer,
                                      ImporteExpensas As Decimal,
                                      ImporteAlquiler As Decimal,
                                      PorcDescAlquiler As Decimal,
                                      ImporteGastosAdmin As Decimal,
                                      ImporteGastosIntermAlq As Decimal,
                                      ExpensasRelacionCategoria As Decimal,
                                      alto As Decimal,
                                      ancho As Decimal,
                                      largo As Decimal,
                                      IdInteres As Integer?)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendLine("UPDATE CategoriasEmbarcaciones ")
         .AppendLine("   SET NombreCategoriaEmbarcacion = '" & NombreCategoriaEmbarcacion & "'")
         .AppendLine("      ,IdTipoEmbarcacion = " & IdTipoEmbarcacion.ToString())
         .AppendLine("      ,ImporteExpensas = " & ImporteExpensas.ToString())
         .AppendLine("      ,ImporteAlquiler = " & ImporteAlquiler.ToString())
         .AppendLine("      ,PorcDescAlquiler = " & PorcDescAlquiler.ToString)
         .AppendLine("      ,ImporteGastosAdmin = " & ImporteGastosAdmin.ToString())
         .AppendLine("      ,ImporteGastosIntermAlq = " & ImporteGastosIntermAlq.ToString())
         .AppendLine("      ,ExpensasRelacionCategoria = " & ExpensasRelacionCategoria.ToString())
         .AppendLine("      ,Alto = " & alto.ToString())
         .AppendLine("      ,Ancho = " & ancho.ToString())
         .AppendLine("      ,Largo = " & largo.ToString())
         'PE-31303
         If IdInteres.HasValue AndAlso IdInteres.Value > 0 Then
            .AppendLine("     ,IdInteres = " + IdInteres.ToString())
         Else
            .AppendLine("     ,IdInteres = NULL")
         End If
         .AppendLine(" WHERE IdCategoriaEmbarcacion = " & IdCategoriaEmbarcacion.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CategoriasEmbarcaciones")

   End Sub

   Public Sub CategoriasEmbarcacion_D(ByVal IdCategoriaEmbarcacion As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM CategoriasEmbarcaciones ")
         .AppendLine(" WHERE IdCategoriaEmbarcacion = " & IdCategoriaEmbarcacion.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CategoriasEmbarcaciones")

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT CE.IdCategoriaEmbarcacion")
         .AppendLine("      ,CE.NombreCategoriaEmbarcacion")
         .AppendLine("      ,CE.IdTipoEmbarcacion")
         .AppendLine("      ,TE.NombreTipoEmbarcacion")
         .AppendLine("      ,CE.ImporteExpensas")
         .AppendLine("      ,CE.ImporteAlquiler")
         .AppendLine("      ,CE.PorcDescAlquiler")
         .AppendLine("      ,CE.ImporteGastosAdmin")
         .AppendLine("      ,CE.ImporteGastosIntermAlq")
         .AppendLine("      ,CE.ExpensasRelacionCategoria")
         .AppendLine("      ,CE.Alto")
         .AppendLine("      ,CE.Ancho")
         .AppendLine("      ,CE.Largo")
         .AppendLine("      ,CE.IdInteres")
         .AppendLine("      ,I.NombreInteres")
         .AppendLine("  FROM CategoriasEmbarcaciones CE")
         .AppendLine("  INNER JOIN TiposEmbarcaciones TE ON TE.IdTipoEmbarcacion = CE.IdTipoEmbarcacion")
         'PE-31303
         .AppendLine(" LEFT OUTER JOIN Intereses I ON I.IdInteres = CE.IdInteres")
      End With
   End Sub

   Public Function CategoriasEmbarcacion_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" ORDER BY CE.NombreCategoriaEmbarcacion")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CategoriasEmbarcacion_G1(ByVal IdCategoriaEmbarcacion As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE CE.IdCategoriaEmbarcacion = " & IdCategoriaEmbarcacion.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "CE." + columna
      If columna = "CE.NombreTipoEmbarcacion" Then columna = columna.Replace("CE.", "TE.")
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function


    Public Function GetPorNombreExacto(nombreCategoriaEmbarcacion As String) As DataTable
        Dim stb As StringBuilder = New StringBuilder("")
        With stb
            Me.SelectTexto(stb)
            .AppendFormat(" WHERE {0} = '{1}'", Entidades.CategoriaEmbarcacion.Columnas.NombreCategoriaEmbarcacion.ToString(), nombreCategoriaEmbarcacion)
        End With
        Return Me.GetDataTable(stb.ToString())
    End Function

End Class
