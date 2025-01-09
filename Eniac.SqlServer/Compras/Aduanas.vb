Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class Aduanas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Aduanas_I(IdAduana As Integer, NombreAduana As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO Aduanas ({0}, {1})",
                       Aduana.Columnas.IdAduana.ToString(),
                       Aduana.Columnas.NombreAduana.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}')",
                       IdAduana, NombreAduana)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Aduanas_U(IdAduana As Integer, NombreAduana As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE Aduanas ")
         .AppendFormat("   SET {0} = '{1}'", Aduana.Columnas.NombreAduana.ToString(), NombreAduana).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", Aduana.Columnas.IdAduana.ToString(), IdAduana)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Aduanas_D(IdAduana As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM Aduanas WHERE {0} = {1}", Aduana.Columnas.IdAduana.ToString(), IdAduana)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT ADU.* FROM Aduanas AS ADU").AppendLine()
      End With
   End Sub

   Public Function Aduanas_GA() As DataTable
      Return Aduanas_G(0, String.Empty)
   End Function

   Public Function Aduanas_G(idAduana As Integer, nombre As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idAduana > 0 Then
            .AppendFormat("   AND ADU.{0} = {1}", Aduana.Columnas.IdAduana.ToString(), idAduana)
         End If
         If Not String.IsNullOrWhiteSpace(nombre) Then
            .AppendFormat("   AND ADU.{0} LIKE '%{1}%'", Aduana.Columnas.NombreAduana.ToString(), nombre)
         End If
         .AppendFormat(" ORDER BY ADU.NombreAduana")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function Aduanas_G1(IdAduana As Integer) As DataTable
      Return Aduanas_G(IdAduana, String.Empty)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      columna = "ADU." + columna

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Aduana.Columnas.IdAduana.ToString(), "Aduanas"))
   End Function

End Class
