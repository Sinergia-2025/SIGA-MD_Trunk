Public Class TiposAntecedentes
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposAntecedentes_I(ByVal idTipoAntecedente As Integer, _
                                  ByVal nombreTipoAntecedente As String)
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("INSERT INTO TiposAntecedentes")
         .Append("           (IdTipoAntecedente")
         .Append("           ,NombreTipoAntecedente)")
         .Append("     VALUES")
         .AppendFormat("           ({0}", idTipoAntecedente)
         .AppendFormat("           ,'{0}')", nombreTipoAntecedente)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub TiposAntecedentes_U(ByVal idTipoAntecedente As Integer, _
                                  ByVal nombreTipoAntecedente As String)
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("UPDATE TiposAntecedentes")
         .Append("   SET ")
         .AppendFormat("      NombreTipoAntecedente = '{0}'", nombreTipoAntecedente)
         .AppendFormat(" WHERE IdTipoAntecedente = {0}", idTipoAntecedente)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub TiposAntecedentes_D(ByVal idTipoAntecedente As Integer)
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("DELETE FROM TiposAntecedentes")
         .AppendFormat(" WHERE IdTipoAntecedente = {0}", idTipoAntecedente)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Append("SELECT TA.IdTipoAntecedente")
         .Append("      ,TA.NombreTipoAntecedente")
         .Append("  FROM TiposAntecedentes TA")
      End With
   End Sub

   Public Function TiposAntecedentes_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append("  ORDER BY TA.NombreTipoAntecedente")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function TiposAntecedentes_G1(ByVal idTipoAntecedente As Int32) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE TA.IdTipoAntecedente = {0}", idTipoAntecedente)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "TA." + columna
      'If columna = "D.NombreLocalidad" Then columna = columna.Replace("D.", "L.")
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append("  WHERE ")
         .Append(columna)
         .Append(" LIKE '%")
         .Append(valor)
         .Append("%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetProximoId() As Integer
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .Append("SELECT ")
         .Append(" MAX(IdTipoAntecedente) AS maximo ")
         .Append(" FROM TiposAntecedentes")
      End With
      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      If dt.Rows.Count > 0 Then
         If String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            Return 1
         Else
            Return Int32.Parse(dt.Rows(0)("maximo").ToString()) + 1
         End If
      Else
         Return 1
      End If

   End Function


End Class
