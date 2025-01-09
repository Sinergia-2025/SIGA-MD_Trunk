Option Strict On
Option Explicit On
Public Class Paises
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Paises_I(idPais As String,
                       nombrePais As String,
                       idAfipPais As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3})",
                        Entidades.Pais.NombreTabla,
                        Entidades.Pais.Columnas.IdPais.ToString(),
                        Entidades.Pais.Columnas.NombrePais.ToString(),
                        Entidades.Pais.Columnas.IdAfipPais.ToString()).AppendLine() '-.PE-31659.-
         .AppendFormat("     VALUES ('{1}', '{2}', {3}",
                       Entidades.Pais.NombreTabla, idPais, nombrePais, idAfipPais)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Paises_U(idPais As String,
                       nombrePais As String,
                       idAfipPais As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}", Entidades.Pais.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} = '{1}'", Entidades.Pais.Columnas.NombrePais.ToString(), nombrePais).AppendLine()
         .AppendFormat("   ,{0} = {1}", Entidades.Pais.Columnas.IdAfipPais.ToString(), idAfipPais).AppendLine() '-.PE-31659.-
         .AppendFormat(" WHERE {0} = '{1}'", Entidades.Pais.Columnas.IdPais.ToString(), idPais).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Paises_D(idPais As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = '{2}'", Entidades.Pais.NombreTabla, Entidades.Pais.Columnas.IdPais.ToString(), idPais)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT PA.* FROM {0} AS PA", Entidades.Pais.NombreTabla).AppendLine()
      End With
   End Sub

   Public Function Paises_GA() As DataTable
      Return Paises_G(idPais:=String.Empty, nombrePais:=String.Empty, nombreExacto:=False, idAfipPais:=0)
   End Function
   Private Function Paises_G(idPais As String, nombrePais As String, nombreExacto As Boolean, idAfipPais As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idPais) Then
            .AppendFormat("   AND PA.IdPais = '{0}'", idPais).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(nombrePais) Then
            If nombreExacto Then
               .AppendFormat("   AND PA.NombrePais = '{0}'", nombrePais).AppendLine()
            Else
               .AppendFormat("   AND PA.NombrePais LIKE '%{0}%'", nombrePais).AppendLine()
            End If
            '-.PE-31659.-
            If idAfipPais > 0 Then
               .AppendFormatLine("  AND PA.IdAfipPais = {0}", idAfipPais)
            End If
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function Paises_G1(idPais As String) As DataTable
      Return Paises_G(idPais:=idPais, nombrePais:=String.Empty, nombreExacto:=False, idAfipPais:=0)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      'If columna = "NombreSucursal" Then
      '   columna = "S." + columna
      'Else
      columna = "PA." + columna
      'End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class