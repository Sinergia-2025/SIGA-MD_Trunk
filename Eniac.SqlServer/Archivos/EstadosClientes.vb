Public Class EstadosClientes
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EstadosClientes_I(idEstadoCliente As Integer,
                                nombreEstadoCliente As String,
                                color As Integer?)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO EstadosClientes")
         .AppendFormatLine("           (IdEstadoCliente")
         .AppendFormatLine("           ,NombreEstadoCliente")
         .AppendFormatLine("           ,Color")
         .AppendFormatLine("   ) VALUES (")
         .AppendFormatLine("            {0} ", idEstadoCliente)
         .AppendFormatLine("          ,'{0}'", nombreEstadoCliente)
         .AppendFormatLine("          , {0} ", GetStringFromNumber(color))
         .AppendFormatLine(")")
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub EstadosClientes_U(idEstadoCliente As Integer,
                                nombreEstadoCliente As String,
                                color As Integer?)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE EstadosClientes")
         .AppendFormatLine("   SET NombreEstadoCliente = '{0}'", nombreEstadoCliente)
         .AppendFormatLine("     , Color = {0}", GetStringFromNumber(color))
         .AppendFormatLine(" WHERE IdEstadoCliente = {0}", idEstadoCliente)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub EstadosClientes_D(idEstadoCliente As Integer)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM EstadosClientes")
         .AppendFormatLine(" WHERE IdEstadoCliente = {0}", idEstadoCliente)
      End With
      Me.Execute(stb.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT EC.*")
         .AppendFormatLine("  FROM EstadosClientes EC ")
      End With
   End Sub

   Public Function EstadosClientes_GA() As DataTable
      Return EstadosClientes_G(idEstadoCliente:=0, nombreEstadoCliente:=String.Empty, nombreExacto:=False)
   End Function

   Private Function EstadosClientes_G(idEstadoCliente As Integer, nombreEstadoCliente As String, nombreExacto As Boolean) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE 1 = 1")
         If idEstadoCliente > 0 Then
            .AppendFormatLine("   AND EC.IdEstadoCliente = '{0}'", idEstadoCliente)
         End If
         If Not String.IsNullOrWhiteSpace(nombreEstadoCliente) Then
            If nombreExacto Then
               .AppendFormatLine("   AND EC.NombreEstadoCliente = '{0}'", nombreEstadoCliente)
            Else
               .AppendFormatLine("   AND EC.NombreEstadoCliente LIKE '%{0}%'", nombreEstadoCliente)
            End If
         End If
         .AppendFormatLine(" ORDER BY EC.NombreEstadoCliente")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetXNombre(estadoCliente As String) As DataTable
      Return EstadosClientes_G(idEstadoCliente:=0, nombreEstadoCliente:=estadoCliente, nombreExacto:=True)
   End Function

   Public Function EstadosClientes_G1(idEstadoCliente As Integer) As DataTable
      Return EstadosClientes_G(idEstadoCliente, nombreEstadoCliente:=String.Empty, nombreExacto:=True)
   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "EC." + columna
      'If columna = "D.NombreLocalidad" Then columna = columna.Replace("D.", "L.")
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine("  WHERE {0} LIKE '%{1}%'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function EstadosClientes_GetMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo("IdEstadoCliente", "EstadosClientes"))
   End Function

   Public Function GetTop1() As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT TOP(1) IdEstadoCliente FROM EstadosClientes")
      End With
      Return Me.GetDataTable(query.ToString())
   End Function

End Class