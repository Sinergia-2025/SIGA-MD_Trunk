Public Class Bancos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Bancos_I(idBanco As Integer,
                       nombreBanco As String,
                       debitoDirecto As Boolean,
                       empresa As Integer,
                       convenio As Integer,
                       servicio As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO Bancos")
         .AppendFormatLine("     (IdBanco")
         .AppendFormatLine("     ,NombreBanco")
         .AppendFormatLine("     ,DebitoDirecto")
         .AppendFormatLine("     ,Empresa")
         .AppendFormatLine("     ,Convenio")
         .AppendFormatLine("     ,Servicio)")
         .AppendFormatLine(" VALUES (")
         .AppendFormatLine("      {0} ", idBanco)
         .AppendFormatLine("    ,'{0}'", nombreBanco)
         .AppendFormatLine("    , {0} ", GetStringFromBoolean(debitoDirecto))
         If debitoDirecto Then
            .AppendFormatLine("    , {0} ", empresa)
            .AppendFormatLine("    , {0} ", convenio)
            .AppendFormatLine("    ,'{0}'", servicio)
         Else
            .AppendFormatLine("    ,NULL")
            .AppendFormatLine("    ,NULL")
            .AppendFormatLine("    ,NULL")
         End If
         .AppendFormatLine(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Bancos")

   End Sub

   Public Sub Bancos_U(idBanco As Integer,
                       nombreBanco As String,
                       debitoDirecto As Boolean,
                       empresa As Integer,
                       convenio As Integer,
                       servicio As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE Bancos")
         .AppendFormatLine("   SET NombreBanco = '{0}'", nombreBanco)
         .AppendFormatLine("     , DebitoDirecto = {0}", GetStringFromBoolean(debitoDirecto))
         If debitoDirecto Then
            .AppendFormatLine("     , Empresa = {0}", empresa)
            .AppendFormatLine("     , Convenio = {0}", convenio)
            .AppendFormatLine("     , Servicio = '{0}'", servicio)
         Else
            .AppendFormatLine("     , Empresa = NULL")
            .AppendFormatLine("     , Convenio = NULL")
            .AppendFormatLine("     , Servicio = NULL")
         End If
         .AppendFormatLine(" WHERE IdBanco = {0}", idBanco)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Bancos")
   End Sub

   Public Sub Bancos_D(idBanco As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM Bancos ")
         .AppendFormatLine(" WHERE IdBanco = {0}", idBanco)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Bancos")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendLine("SELECT B.*")
         .AppendLine("  FROM Bancos B")
      End With
   End Sub

   Public Function Bancos_GA() As DataTable
      Return Bancos_G(idBanco:=0, idBancoExacto:=False, nombreBanco:=String.Empty, nombreBancoExacto:=False)
   End Function

   Private Function Bancos_G(idBanco As Integer, idBancoExacto As Boolean, nombreBanco As String, nombreBancoExacto As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If idBanco <> 0 Then
            If idBancoExacto Then
               .AppendFormatLine("   AND B.IdBanco = {0}", idBanco)
            Else
               .AppendFormatLine("   AND B.IdBanco LIKE '%{0}%'", idBanco)
            End If
         End If
         If Not String.IsNullOrWhiteSpace(nombreBanco) Then
            If nombreBancoExacto Then
               .AppendFormatLine("   AND B.NombreBanco = '{0}'", nombreBanco)
            Else
               .AppendFormatLine("   AND B.NombreBanco LIKE '%{0}%'", nombreBanco)
            End If
         End If
         .AppendLine(" ORDER BY B.NombreBanco")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Function Bancos_G_PorCodigo(idBanco As Integer, idBancoExacto As Boolean) As DataTable
      Return Bancos_G(idBanco:=idBanco, idBancoExacto:=idBancoExacto, nombreBanco:=String.Empty, nombreBancoExacto:=False)
   End Function
   Public Function Bancos_G_PorNombre(nombreBanco As String, nombreBancoExacto As Boolean) As DataTable
      Return Bancos_G(idBanco:=0, idBancoExacto:=False, nombreBanco:=nombreBanco, nombreBancoExacto:=nombreBancoExacto)
   End Function

   Public Function Bancos_G1(idBanco As Integer) As DataTable
      Return Bancos_G(idBanco:=idBanco, idBancoExacto:=True, nombreBanco:=String.Empty, nombreBancoExacto:=False)
   End Function

   Public Function Buscar(columna As String, valor As String) As DataTable
      columna = String.Concat("B.", columna)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class