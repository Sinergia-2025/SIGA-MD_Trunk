Public Class ClientesAntecedentes
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ClientesAntecedentes_I(ByVal idAntecedente As Int32, _
                                         ByVal IdCLiente As Long, _
                                         ByVal valor As String, _
                                         ByVal fechaActualizacion As DateTime)
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("INSERT INTO ClientesAntecedentes")
         .Append("           (IdAntecedente")
         .Append("           ,IdCLiente")
         .Append("           ,Valor")
         .Append("           ,FechaActualizacion)")
         .Append("     VALUES")
         .AppendFormat("           ({0}", idAntecedente)
         .AppendFormat("           ,{0}", IdCLiente)
         .AppendFormat("           ,'{0}'", valor)
         .AppendFormat("           ,'{0}')", fechaActualizacion.ToString("yyyyMMdd HH:mm:ss"))
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub ClientesAntecedentes_U(ByVal idAntecedente As Int32, _
                                         ByVal IdCLiente As Long, _
                                         ByVal valor As String, _
                                         ByVal fechaActualizacion As DateTime)
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("UPDATE ClientesAntecedentes")
         .Append("   SET ")
         .AppendFormat("      Valor = '{0}'", valor)
         .AppendFormat("      ,FechaActualizacion = '{0}'", fechaActualizacion.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormat(" WHERE IdAntecedente = {0}", idAntecedente)
         .AppendFormat(" AND IdCLiente = {0}", IdCLiente)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub ClientesAntecedentes_D(ByVal idAntecedente As Int32, _
                                         ByVal IdCLiente As Long)
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("DELETE FROM ClientesAntecedentes")
         .AppendFormat(" WHERE IdAntecedente = {0}", idAntecedente)
         .AppendFormat(" AND IdCLiente = {0}", IdCLiente)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Append("SELECT SA.IdAntecedente")
         .Append("      ,SA.IdCLiente")
         .Append("      ,SA.Valor")
         .Append("      ,SA.FechaActualizacion")
         .Append("  FROM ClientesAntecedentes SA")
      End With
   End Sub

   Public Function ClientesAntecedentes_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append("  ORDER BY  SA.IdCLiente, SA.IdAntecedente")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ClientesAntecedentes_G1(ByVal idAntecedente As Int32, _
                                           ByVal IdCLiente As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE SA.IdAntecedente = {0}", idAntecedente)
         .AppendFormat(" AND SA.IdCLiente = {0}", IdCLiente)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorTipoAntecedenteYCliente(ByVal idTipoAntecedente As Int32, _
                                               ByVal IdCLiente As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("SELECT A.IdAntecedente, A.NombreAntecedente, R1.Valor, R1.FechaActualizacion")
         .Append(" FROM Antecedentes A")
         .Append(" LEFT JOIN")
         .Append("			(SELECT SA.IdAntecedente, A1.NombreAntecedente, SA.Valor, SA.FechaActualizacion")
         .Append("					FROM ClientesAntecedentes SA")
         .Append("					INNER JOIN Antecedentes A1 ON SA.IdAntecedente = A1.IdAntecedente")
         .AppendFormat("					WHERE  SA.IdCLiente = {0}) R1 ON R1.IdAntecedente = A.IdAntecedente", IdCLiente)
         .AppendFormat(" WHERE A.IdTipoAntecedente = {0}", idTipoAntecedente)
         .Append(" ORDER BY A.NombreAntecedente")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "SA." + columna
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

   Public Function GetAntecedentesDeCliente(ByVal IdCLiente As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("SELECT TA.NombreTipoAntecedente, A.NombreAntecedente, SA.Valor, SA.FechaActualizacion")
         .Append("		FROM ClientesAntecedentes SA")
         .Append("		INNER JOIN Antecedentes A ON SA.IdAntecedente = A.IdAntecedente")
         .Append("		INNER JOIN TiposAntecedentes TA ON A.IdTipoAntecedente = TA.IdTipoAntecedente")
         .AppendFormat("		WHERE SA.IdCLiente = {0}", IdCLiente)
         .Append("		ORDER BY A.NombreAntecedente")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
