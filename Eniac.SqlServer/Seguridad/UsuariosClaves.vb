Public Class UsuariosClaves
   Inherits Eniac.SqlServer.Comunes

    Public Sub New(ByVal da As Eniac.Datos.DataAccess)
        MyBase.New(da)
    End Sub

    Public Sub UsuariosClaves_I(ByVal idUsuario As String, ByVal FechaModContraseña As DateTime, ByVal clave As String)
        Dim stb As StringBuilder = New StringBuilder("")
        With stb
            .Append("INSERT INTO UsuariosClaves")
            .Append("           (IdUsuario")
            .Append("           ,FechaModContraseña")
            .Append("           ,Clave)")
            .Append("     VALUES")
            .AppendFormat("           ('{0}'", idUsuario)
            .AppendLine(", '" & Me.ObtenerFecha(FechaModContraseña, True) & "' ")
            .AppendFormat("           ,'{0}')", clave)

        End With

        Me.Execute(stb.ToString())

    End Sub

    Public Sub UsuariosClaves_U(ByVal idUsuario As String, ByVal FechaModContraseña As DateTime, ByVal clave As String)
        Dim stb As StringBuilder = New StringBuilder("")
        With stb
            .Append("UPDATE UsuariosClaves")
            .AppendFormat("   SET ")
            .AppendFormat("      ,Clave = '{0}'", clave)
            .AppendFormat(" WHERE Id = '{0}'", idUsuario)
            .AppendFormat(" AND FechaModContraseña = '{0}'", FechaModContraseña)
        End With

        Me.Execute(stb.ToString())
    End Sub

    Public Sub UsuariosClaves_D(ByVal id As String)
        Dim stb As StringBuilder = New StringBuilder("")

        With stb
            '.Append("DELETE FROM UsuariosClaves")
            '.AppendFormat(" WHERE Id = '{0}'", id)
        End With

        Me.Execute(stb.ToString())
    End Sub

    Private Sub SelectTexto(ByVal stb As StringBuilder)
        With stb
            .Append("SELECT UC.IdUsuario")
            .Append("      ,UC.FechaModContraseña")
            .Append("      ,UC.Clave")
            .Append("  FROM UsuariosClaves UC ")
        End With
    End Sub

    Public Function UsuariosClaves_GA() As DataTable
        Dim stb As StringBuilder = New StringBuilder("")
        With stb
            Me.SelectTexto(stb)
            .Append("  ORDER BY UC.FechaModContraseña")
        End With

        Return Me.GetDataTable(stb.ToString())
    End Function

    Public Function UsuariosClaves_G1(ByVal idUsuario As String, ByVal FechaModContraseña As DateTime) As DataTable
        Dim stb As StringBuilder = New StringBuilder("")
        With stb
            Me.SelectTexto(stb)
            .AppendFormat(" WHERE U.Id = '{0}'", idUsuario)
        End With

        Return Me.GetDataTable(stb.ToString())
    End Function

    Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
        columna = "U." + columna
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

   Public Function GetUsuariosClaves(ByVal idUsuario As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         Me.SelectTexto(stb)

         .AppendLine(" WHERE UC.IdUsuario = '" & idUsuario & "'")

         .AppendLine("  ORDER BY UC.FechaModContraseña")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

End Class
