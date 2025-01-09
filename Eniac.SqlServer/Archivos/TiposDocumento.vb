Public Class TiposDocumento
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposDocumento_I(tipoDocumento As String,
                               nombreTipoDocumento As String,
                               esAutoincremental As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO  ")
         .Append("TiposDocumento  ")
         .Append("(tipoDocumento, ")
         .Append("nombreTipoDocumento, ")
         .Append("EsAutoincremental) ")
         .Append("VALUES(")
         .Append("'" & tipoDocumento & "', ")
         .Append("'" & nombreTipoDocumento & "', ")
         .Append(IIf(esAutoincremental, 1, 0).ToString() & ") ")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "TiposDocumento")
   End Sub

   Public Sub TiposDocumento_U(tipoDocumento As String,
                                nombreTipoDocumento As String,
                                esAutoincremental As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("UPDATE  ")
         .Append("TiposDocumento  ")
         .Append("SET  ")

         .Append("nombreTipoDocumento = '" & nombreTipoDocumento & "', ")
         .Append("esAutoincremental = " & IIf(esAutoincremental, 1, 0).ToString())

         .Append("WHERE ")
         .Append("tipoDocumento = '" & tipoDocumento & "'")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "TiposDocumento")
   End Sub

   Public Sub TiposDocumento_D(tipoDocumento As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Append("DELETE FROM  ")
         .Append("TiposDocumento  ")
         .Append("WHERE  ")
         .Append("tipoDocumento = '" & tipoDocumento & "'")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "TiposDocumento")
   End Sub

   Public Function TiposDocumento_GA(validoAFIP As Entidades.Publicos.SiNoTodos) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("SELECT TD.*")
         .AppendFormatLine("  FROM TiposDocumento TD")
         If validoAFIP <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  LEFT JOIN AFIPTiposDocumentos ATD ON ATD.TipoDocumento = TD.TipoDocumento")
            If validoAFIP = Entidades.Publicos.SiNoTodos.SI Then
               .AppendFormatLine(" WHERE ATD.TipoDocumento IS NOT NULL")
            Else
               .AppendFormatLine(" WHERE ATD.TipoDocumento IS NULL")
            End If
         End If
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class