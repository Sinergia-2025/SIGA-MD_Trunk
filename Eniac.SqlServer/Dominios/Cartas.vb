Public Class Cartas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Cartas_I(ByVal idCarta As Integer, _
                       ByVal nombreCarta As String, _
                       ByVal diasDefault As Integer, _
                       ByVal proximaCarta As Integer, _
                       ByVal texto As String, _
                       ByVal texto2 As String, _
                       ByVal textoRTF As String, _
                       ByVal Texto2RTF As String, _
                       ByVal firma As String, _
                       ByVal MiraAnoEnCurso As Boolean, _
                       ByVal EsHTML As Boolean, _
                       ByVal Tipo As String)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("INSERT INTO Cartas")
         .Append("           (IdCarta")
         .Append("           ,NombreCarta")
         .Append("           ,DiasDefault")
         .Append("           ,ProximaCarta")
         .Append("           ,Texto")
         .Append("           ,Texto2")
         .Append("           ,TextoRTF")
         .Append("           ,Texto2RTF")
         .Append("           ,Firma")
         .Append("           ,MiraAnoEnCurso")
         .Append("           ,EsHTML")
         .Append("           ,Tipo")
         .Append(" ) VALUES (")
         .AppendFormat("           {0}", idCarta)
         .AppendFormat("           ,'{0}'", nombreCarta)
         .AppendFormat("           ,{0}", diasDefault)
         .AppendFormat("           ,{0}", proximaCarta)
         .AppendFormat("           ,'{0}'", texto)
         .AppendFormat("           ,'{0}'", texto2)

         If Not String.IsNullOrEmpty(textoRTF) Then
            .AppendFormat("           ,'{0}'", textoRTF)
         Else
            .AppendFormat("           ,NULL")
         End If


         If Not String.IsNullOrEmpty(Texto2RTF) Then
            .AppendFormat("           ,'{0}'", saveRTF(Texto2RTF))
         Else
            .AppendFormat("           ,NULL")
         End If

         .AppendFormat("           ,'{0}'", firma)
         .AppendFormat("           ,'{0}'", MiraAnoEnCurso)
         .AppendFormat("           ,'{0}'", EsHTML)
         .AppendFormat("           ,'{0}'", Tipo)
         .Append(" ) ")
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub Cartas_U(ByVal idCarta As Integer, _
                       ByVal nombreCarta As String, _
                       ByVal diasDefault As Integer, _
                       ByVal proximaCarta As Integer, _
                       ByVal texto As String, _
                       ByVal texto2 As String, _
                       ByVal textoRTF As String, _
                       ByVal Texto2RTF As String, _
                       ByVal firma As String, _
                       ByVal MiraAnoEnCurso As Boolean, _
                       ByVal EsHTML As Boolean, _
                       ByVal Tipo As String)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("UPDATE Cartas")
         .Append("   SET ")
         .AppendFormat("      NombreCarta = '{0}'", nombreCarta)

         .AppendFormat("      ,DiasDefault = {0}", diasDefault)

         If proximaCarta = 0 Then
            .Append("      ,ProximaCarta = NULL")
         Else
            .AppendFormat("      ,ProximaCarta = {0}", proximaCarta)
         End If

         .AppendFormat("      ,Texto = '{0}'", texto)
         .AppendFormat("      ,Texto2 = '{0}'", texto2)

         If Not String.IsNullOrEmpty(textoRTF) Then
            .AppendFormat("      ,TextoRTF = '{0}'", saveRTF(textoRTF))
         Else
            .AppendFormat("      ,TextoRTF = NULL")
         End If

         If Not String.IsNullOrEmpty(Texto2RTF) Then
            .AppendFormat("      ,Texto2RTF = '{0}'", saveRTF(Texto2RTF))
         Else
            .AppendFormat("      ,Texto2RTF = NULL")
         End If

         .AppendFormat("      ,Firma = '{0}'", firma)
         .AppendFormat("      ,MiraAnoEnCurso = '{0}'", MiraAnoEnCurso)
         .AppendFormat("      ,EsHTML = '{0}'", EsHTML)
         .AppendFormat("      ,Tipo = '{0}'", Tipo)

         .AppendFormat(" WHERE IdCarta = {0}", idCarta)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Private Function saveRTF(ByVal texto As String) As String
      'Transformar la comilla guardada el SQL SERVER (lo usa x ejemplo en los acentos)
      Return texto.Replace("'", Chr(34))
   End Function

   Public Sub Cartas_D(ByVal idCarta As Integer)
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("DELETE FROM Cartas")
         .AppendFormat(" WHERE IdCarta = {0}", idCarta)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Append("SELECT C.IdCarta")
         .Append("      ,C.NombreCarta")
         .Append("      ,C.DiasDefault")
         .Append("      ,C.ProximaCarta")
         .Append("      ,C.Texto")
         .Append("      ,C.Texto2")
         .Append("      ,C.TextoRTF")
         .Append("      ,C.Texto2RTF")
         .Append("      ,C.Firma")
         .Append("      ,C.MiraAnoEnCurso")
         .Append("      ,C.EsHTML")
         .Append("      ,C.Tipo")

         .Append("  FROM Cartas C ")
      End With
   End Sub

   Public Function Cartas_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append("  ORDER BY C.IdCarta")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Cartas_GxTipo(ByVal Tipo As String, ByVal Orden As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         Me.SelectTexto(stb)
         .AppendFormat("WHERE C.Tipo = '{0}'", Tipo)
         If Orden = "Nombre" Then
            .AppendLine("  ORDER BY C.NombreCarta")
         Else
            .AppendLine("  ORDER BY C.IdCarta")
         End If
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function Cartas_G1(ByVal idCarta As Int32) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat("WHERE C.IdCarta = {0}", idCarta)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "C." + columna
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

End Class
