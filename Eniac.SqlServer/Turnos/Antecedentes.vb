Public Class Antecedentes
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Antecedentes_I(ByVal idAntecedente As Integer, _
                             ByVal nombreAntecedente As String, _
                             ByVal idTipoAntecedente As Integer)
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("INSERT INTO Antecedentes")
         .Append("           (IdAntecedente")
         .Append("           ,NombreAntecedente")
         .Append("           ,IdTipoAntecedente)")
         .Append("     VALUES")
         .AppendFormat("           ({0}", idAntecedente)
         .AppendFormat("           ,'{0}'", nombreAntecedente)
         .AppendFormat("           ,{0})", idTipoAntecedente)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub Antecedentes_U(ByVal idAntecedente As Integer, _
                             ByVal nombreAntecedente As String, _
                             ByVal idTipoAntecedente As Integer)
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("UPDATE Antecedentes")
         .Append("   SET ")
         .AppendFormat("      NombreAntecedente = '{0}'", nombreAntecedente)
         .AppendFormat("      ,IdTipoAntecedente = {0}", idTipoAntecedente)
         .AppendFormat(" WHERE IdAntecedente = {0}", idAntecedente)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub Antecedentes_D(ByVal idAntecedente As Integer)
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("DELETE FROM Antecedentes")
         .AppendFormat(" WHERE IdAntecedente = {0}", idAntecedente)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Append("SELECT A.IdAntecedente")
         .Append("      ,A.NombreAntecedente")
         .Append("      ,A.IdTipoAntecedente")
         .Append("      ,TA.NombreTipoAntecedente")
         .Append("  FROM Antecedentes A ")
         .Append("  INNER JOIN TiposAntecedentes TA ON TA.IdTipoAntecedente = A.IdTipoAntecedente ")
      End With
   End Sub

   Public Function Antecedentes_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append("  ORDER BY A.NombreAntecedente")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Antecedentes_G1(ByVal idAntecedente As Int32) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE A.IdAntecedente = {0}", idAntecedente)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "A." + columna
      If columna = "A.NombreTipoAntecedente" Then columna = columna.Replace("A.", "TA.")
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
         .Append(" MAX(IdAntecedente) AS maximo ")
         .Append(" FROM Antecedentes")
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
