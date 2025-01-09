Public Class AFIPReferenciasTransferencias
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub AFIPReferenciasTransferencias_I(idAFIPReferenciaTransferencia As String,
                                              nombreReferenciaTransferencia As String,
                                              descripcionReferenciaTransferencia As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} ({1}, {2}, {3})",
                           Entidades.AFIPReferenciaTransferencia.NombreTabla,
                           Entidades.AFIPReferenciaTransferencia.Columnas.IdAFIPReferenciaTransferencia.ToString(),
                           Entidades.AFIPReferenciaTransferencia.Columnas.NombreReferenciaTransferencia.ToString(),
                           Entidades.AFIPReferenciaTransferencia.Columnas.DescripcionReferenciaTransferencia.ToString())
         .AppendFormatLine("     VALUES ('{1}', '{2}', '{3}'",
                           Entidades.AFIPReferenciaTransferencia.NombreTabla,
                           idAFIPReferenciaTransferencia, nombreReferenciaTransferencia, descripcionReferenciaTransferencia)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub AFIPReferenciasTransferencias_U(idAFIPReferenciaTransferencia As String,
                                              nombreReferenciaTransferencia As String,
                                              descripcionReferenciaTransferencia As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.AFIPReferenciaTransferencia.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.AFIPReferenciaTransferencia.Columnas.NombreReferenciaTransferencia.ToString(), nombreReferenciaTransferencia)
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.AFIPReferenciaTransferencia.Columnas.DescripcionReferenciaTransferencia.ToString(), descripcionReferenciaTransferencia)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.AFIPReferenciaTransferencia.Columnas.IdAFIPReferenciaTransferencia.ToString(), idAFIPReferenciaTransferencia)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub AFIPReferenciasTransferencias_D(idAFIPReferenciaTransferencia As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} WHERE {1} = '{2}'", Entidades.AFIPReferenciaTransferencia.NombreTabla, Entidades.AFIPReferenciaTransferencia.Columnas.IdAFIPReferenciaTransferencia.ToString(), idAFIPReferenciaTransferencia)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT RT.* FROM {0} AS RT", Entidades.AFIPReferenciaTransferencia.NombreTabla)
      End With
   End Sub

   Public Function AFIPReferenciasTransferencias_GA() As DataTable
      Return AFIPReferenciasTransferencias_G(idAFIPReferenciaTransferencia:=String.Empty, nombreReferenciaTransferencia:=String.Empty, nombreExacto:=False)
   End Function
   Private Function AFIPReferenciasTransferencias_G(idAFIPReferenciaTransferencia As String, nombreReferenciaTransferencia As String, nombreExacto As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idAFIPReferenciaTransferencia) Then
            .AppendFormatLine("   AND RT.IdAFIPReferenciaTransferencia = '{0}'", idAFIPReferenciaTransferencia)
         End If
         If Not String.IsNullOrWhiteSpace(nombreReferenciaTransferencia) Then
            If nombreExacto Then
               .AppendFormatLine("   AND RT.NombreAFIPReferenciaTransferencia = '{0}'", nombreReferenciaTransferencia)
            Else
               .AppendFormatLine("   AND RT.NombreAFIPReferenciaTransferencia LIKE '%{0}%'", nombreReferenciaTransferencia)
            End If
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function AFIPReferenciasTransferencias_G1(idAFIPReferenciaTransferencia As String) As DataTable
      Return AFIPReferenciasTransferencias_G(idAFIPReferenciaTransferencia:=idAFIPReferenciaTransferencia, nombreReferenciaTransferencia:=String.Empty, nombreExacto:=False)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      'If columna = "NombreSucursal" Then
      '   columna = "S." + columna
      'Else
      columna = "RT." + columna
      'End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class