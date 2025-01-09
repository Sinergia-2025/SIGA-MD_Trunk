Public Class TiposCheques
   Inherits Comunes
   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposCheques_I(idTipoCheque As String,
                             nombreTipoCheque As String,
                             solicitaNroOperacion As Boolean)
      Dim query As StringBuilder = New StringBuilder
      With query
            .AppendLine("INSERT INTO TiposCheques(")

            .Append("IdTipoCheque  ")
            .Append(",NombreTipoCheque   ")
            .Append(",SolicitaNroOperacion ")

            .Append(")	VALUES (")

            .Append("'" & idTipoCheque.ToString() & "', ")
            .Append("'" & nombreTipoCheque & "', ")
            .Append(GetStringFromBoolean(solicitaNroOperacion))

            .AppendLine(")")
      End With
        Me.Execute(query.ToString())
        Me.Sincroniza_I(query.ToString(), "TiposCheques")

    End Sub

   Public Sub TiposCheques_U(idTipoCheque As String,
                             nombreTipoCheque As String,
                             solicitaNroOperacion As Boolean)
      Dim query As StringBuilder = New StringBuilder
      With query
            .Append("UPDATE TiposCheques SET   ")

            .Append("NombreTipoCheque = '" & nombreTipoCheque & "',   ")
            .Append("SolicitaNroOperacion = " & GetStringFromBoolean(solicitaNroOperacion))

            .Append("   WHERE IdTipoCheque = '" & idTipoCheque.ToString() & "'")

        End With
        Me.Execute(query.ToString())
        Me.Sincroniza_I(query.ToString(), "TiposCheques")
    End Sub

   Public Sub TiposCheques_D(idTipoCheque As String)
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendLine("DELETE TiposCheques")
         .AppendFormatLine("WHERE IdTipoCheque = '{0}'", idTipoCheque)
      End With
      Me.Execute(query.ToString())
   End Sub

   Public Function TiposCheques_GA() As DataTable
      Dim query As StringBuilder = New StringBuilder
      SelectTexto(query)

      Return Me.GetDataTable(query.ToString())
   End Function

    Public Function TiposCheques_G1(idTipoCheque As String) As DataTable
        Dim query As StringBuilder = New StringBuilder
        SelectTexto(query)
        With query
            .AppendFormatLine("WHERE IdTipoCheque = '{0}'", idTipoCheque)
        End With
        Return GetDataTable(query.ToString())
    End Function

    Private Sub SelectTexto(stb As StringBuilder)
        With stb
            .AppendLine("SELECT ")
            .AppendLine("      TC.IdTipoCheque,")
            .AppendLine("      TC.NombreTipoCheque,")
            .AppendLine("      TC.SolicitaNroOperacion")
            .AppendLine("FROM TiposCheques TC")
        End With
    End Sub

    Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

        Dim stb As StringBuilder = New StringBuilder()
        With stb
            Me.SelectTexto(stb)
            .AppendFormatLine(" WHERE {0} LIKE '%{1}%'", columna, valor)
        End With
        Return Me.GetDataTable(stb.ToString())
    End Function

    'Public Overloads Function GetCodigoMaximo() As String
    '    Return (MyBase.GetCodigoMaximo(Entidades.TiposCheques.Columnas.IdTipoCheque.ToString(), "TiposCheques")).ToString()
    'End Function

End Class
