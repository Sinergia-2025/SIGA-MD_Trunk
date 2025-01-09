Imports System.Text

Public Class Localidades
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Localidades_I(ByVal idLocalidad As Integer, _
                            ByVal idProvincia As String, _
                            ByVal nombreLocalidad As String)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO  ")
         .Append("Localidades  ")
         .Append("(IdLocalidad, ")
         .Append("IdProvincia, ")
         .Append("NombreLocalidad)  ")
         .Append("VALUES(")
         .Append(idLocalidad & ", ")
         If idProvincia Is Nothing Then
            .Append("null, ")
         Else
            .Append("'" & idProvincia & "', ")
         End If
         .Append("'" & nombreLocalidad & "') ")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Localidades")
   End Sub

   Public Sub Localidades_U(ByVal idLocalidad As Integer, _
                               ByVal idProvincia As String, _
                               ByVal nombreLocalidad As String)
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("UPDATE  ")
         .Append("Localidades  ")
         .Append("SET  ")

         If idProvincia Is Nothing Then
            .Append("IdProvincia = null, ")
         Else
            .Append("IdProvincia = '" & idProvincia & "', ")
         End If
         .Append("NombreLocalidad = '" & nombreLocalidad & "' ")

         .Append("WHERE ")
         .Append("idLocalidad = " & idLocalidad)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Localidades")
   End Sub

   Public Sub Localidades_D(ByVal idLocalidad As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM  ")
         .Append("Localidades  ")
         .Append("WHERE  ")
         .Append("IdLocalidad = " & idLocalidad)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Localidades")
   End Sub

   Public Function Localidades_GA(fechaActualizacionDesde As DateTime?) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")

      Me.SelectTexto(myQuery)

      With myQuery
         .AppendLine(" WHERE 1 = 1")
         If fechaActualizacionDesde.HasValue Then
            .AppendFormat("   AND L.{0} > '{1}'",
                          Entidades.Localidad.Columnas.FechaActualizacionWeb.ToString(), ObtenerFecha(fechaActualizacionDesde.Value, True, True)).AppendLine()
         End If

         .AppendLine("   ORDER BY L.NombreLocalidad")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT L.IdLocalidad")
         .AppendLine("      ,L.NombreLocalidad")
         .AppendLine("      ,P.IdProvincia")
         .AppendLine("      ,P.NombreProvincia")
         .AppendFormat("      ,L.{0}", Entidades.Localidad.Columnas.FechaActualizacionWeb.ToString()).AppendLine()
         .AppendLine("  FROM Localidades L ")
         .AppendLine("  LEFT JOIN Provincias P ON L.IdProvincia = P.IdProvincia ")
         '.AppendLine(" ORDER BY L.NombreLocalidad")
      End With
   End Sub

   Public Function Localidades_G1(ByVal IdLocalidad As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         If IdLocalidad > 0 Then
            .AppendFormat("WHERE L.IdLocalidad = {0}", IdLocalidad)
         End If
         .AppendLine(" ORDER BY L.NombreLocalidad")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Localidades_GPorCodigo(ByVal Codigo As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         If Codigo > 0 Then
            If Codigo.ToString.Length < 4 Then
               .AppendFormat("WHERE L.IdLocalidad  LIKE '%{0}%'", Codigo)
            Else
               .AppendFormat("WHERE L.IdLocalidad  LIKE '{0}%'", Codigo)
            End If
         End If
         .AppendLine(" ORDER BY L.NombreLocalidad")
      End With
      Return Me.GetDataTable(stb.ToString())
    End Function

    Public Function Localidades_GPorCodigoUnico(ByVal Codigo As Integer) As DataTable
        Dim stb As StringBuilder = New StringBuilder("")
        With stb
            Me.SelectTexto(stb)
            .AppendFormat("WHERE L.IdLocalidad = '{0}'", Codigo)
            .AppendLine(" ORDER BY L.NombreLocalidad")
        End With
        Return Me.GetDataTable(stb.ToString())
    End Function

   Public Function Localidades_GPorNombre(ByVal Nombre As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat("WHERE L.NombreLocalidad  LIKE '%{0}%'", Nombre)
         .AppendLine(" ORDER BY L.NombreLocalidad")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Existe(ByVal cp As Integer) As Boolean
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append(" SELECT idLocalidad FROM Localidades ")
         .AppendFormat(" WHERE idLocalidad = {0}", cp)
      End With
      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         Return True
      Else
         Return False
      End If
   End Function

   Public Function Existe(nombreLocalidad As String, provincia As String) As Boolean
      Dim query As StringBuilder = New StringBuilder
      With query

      End With
      Return Me.GetDataTable(query.ToString()).Rows.Count > 0
   End Function

End Class
