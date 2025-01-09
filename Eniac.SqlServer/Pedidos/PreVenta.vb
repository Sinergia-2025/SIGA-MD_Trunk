Public Class PreVenta
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub PreVenta_I(id As Integer, file As String, IdEmpleado As Integer, fecha As Date)
      Dim qry As StringBuilder = New StringBuilder()

      With qry
         .AppendLine("INSERT INTO PreVenta ")
         .AppendLine("           (Id")
         .AppendLine("           ,FileNamePed")
         .AppendLine("           ,IdEmpleado")
         .AppendLine("           ,Fecha")

         .AppendLine(" ) VALUES (")
         .AppendFormat("         {0} ", id).AppendLine()
         .AppendFormat("       ,'{0}'", file).AppendLine()
         .AppendFormat("       ,{0}", IdEmpleado).AppendLine()
         .AppendFormat("       ,'{0}'", ObtenerFecha(fecha, True)).AppendLine()
         .AppendLine(")")
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "PreVenta")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Append("SELECT PV.*")
         .Append("  FROM PreVenta PV")
      End With
   End Sub

   Public Function PreVenta_GA() As DataTable
      Return PreVenta_G(fileNamePed:="", fileNamePedExacto:=True)
   End Function
   Private Function PreVenta_G(fileNamePed As String, fileNamePedExacto As Boolean) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(fileNamePed) Then
            If fileNamePedExacto Then
               .AppendFormat("   AND FileNamePed = '{0}'", fileNamePed).AppendLine()
            Else
               .AppendFormat("   AND FileNamePed LIKE '%{0}%'", fileNamePed).AppendLine()
            End If
         End If
         .AppendLine(" ORDER BY Fecha DESC")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "PV." + columna

      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE {0} LIKE '%{1}%'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetArchivo(ByVal Archivo As String) As DataTable
      Return PreVenta_G(Archivo, True)
      'Dim stb As StringBuilder = New StringBuilder("")
      'With stb
      '   .Append("SELECT FileNamePed ")
      '   '.Append(" FROM ArchivosPreVenta")
      '   .Append(" FROM PreVenta")
      '   .AppendFormat(" WHERE FileNamePed = '{0}'", Archivo)
      'End With
      'Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      'If dt.Rows.Count > 0 Then
      '   Return True
      'Else
      '   Return False
      'End If
   End Function

   'Public Function GetEstadoVisita(ByVal idvisita As String) As DataTable
   '   Dim stb As StringBuilder = New StringBuilder("")
   '   With stb
   '      .Append("SELECT IdEstadoVenta, NombreEstadoVenta ")
   '      .Append(" FROM EstadosVenta")
   '      .AppendFormat(" WHERE IdEstadoVenta = {0}", idvisita)
   '   End With
   '   Dim dt As DataTable = Me.GetDataTable(stb.ToString())

   '   Return dt

   'End Function


   Public Function GetProximoId() As Integer
      Return Convert.ToInt32(GetCodigoMaximo("Id", "PreVenta")) + 1
   End Function

End Class