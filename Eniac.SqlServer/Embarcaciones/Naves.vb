Public Class Naves
   Inherits Comunes

   Private ReadOnly Nave As Entidades.Nave
   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Naves_I(idNave As Integer, nombreNave As String, nombrePC As String,
                      enMantenimiento As Boolean, limiteDeKilos As Integer, idTipoNave As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO Naves")
         .AppendFormatLine("           (IdNave")
         .AppendFormatLine("           ,NombreNave")
         .AppendFormatLine("           ,NombrePC")
         .AppendFormatLine("           ,EnMantenimiento")
         .AppendFormatLine("           ,LimiteDeKilos")
         .AppendFormatLine("           ,IdTipoNave)")
         .AppendFormatLine("     VALUES (")
         .AppendFormatLine("             {0} ", idNave)
         .AppendFormatLine("           ,'{0}'", nombreNave)
         .AppendFormatLine("           ,'{0}'", nombrePC)
         .AppendFormatLine("           , {0} ", GetStringFromBoolean(enMantenimiento))
         .AppendFormatLine("           , {0} ", limiteDeKilos)
         .AppendFormatLine("           , {0} ", idTipoNave)
         .AppendFormatLine(")")
      End With
      Execute(stb)
   End Sub
   Public Sub Naves_U(idNave As Integer, nombreNave As String, nombrePC As String,
                      enMantenimiento As Boolean, limiteDeKilos As Integer, idTipoNave As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE Naves")
         .AppendFormatLine("   SET NombreNave = '{0}'", nombreNave)
         .AppendFormatLine("     , NombrePC = '{0}'", nombrePC)
         .AppendFormatLine("     , EnMantenimiento = {0}", GetStringFromBoolean(enMantenimiento))
         .AppendFormatLine("     , LimiteDeKilos = {0}", limiteDeKilos)
         .AppendFormatLine("     , IdTipoNave = {0}", idTipoNave)
         .AppendFormatLine(" WHERE IdNave = {0}", idNave)
      End With

      Execute(stb)
   End Sub
   Public Sub Naves_D(idNave As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM Naves")
         .AppendFormatLine(" WHERE IdNave = {0}", idNave)
      End With
      Execute(stb)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT N.*")
         .AppendLine("      ,TN.NombreTipoNave")
         .AppendLine("  FROM Naves N")
         .AppendLine(" INNER JOIN TiposNaves TN ON TN.IdTipoNave = N.IdTipoNave")
      End With
   End Sub

   Public Function Naves_GA() As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormat(" ORDER BY {0}.{1}", "TN", Entidades.Nave.Columnas.IdTipoNave.ToString())
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function Naves_G1(idNave As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE N.IdNave = {0}", idNave)
      End With
      Return GetDataTable(stb)
   End Function
   Private Function Naves_G() As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT N.*")
         .AppendFormatLine("  FROM Naves N")
         .AppendFormatLine(" ORDER BY N.{0}", Entidades.Nave.Columnas.NombreNave)

      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetParaMovil() As DataTable
      Return Naves_G()
   End Function
   Public Function Naves_GHabilitadas(nombrePC As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendLine(" WHERE N." & Entidades.Nave.Columnas.EnMantenimiento.ToString() & " = 'False'")
         If Not String.IsNullOrEmpty(nombrePC) Then
            .AppendLine("   AND N." & Entidades.Nave.Columnas.NombrePC.ToString() & " = '" & nombrePC & "'")
         End If
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo("IdNave", "Naves").ToInteger()
   End Function

End Class