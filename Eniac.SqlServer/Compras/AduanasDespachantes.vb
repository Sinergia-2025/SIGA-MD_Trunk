Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class AduanasDespachantes
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub AduanasDespachantes_I(IdDespachante As Integer, NombreDespachante As String, Cuit As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO AduanasDespachantes ({0}, {1}, {2})",
                       AduanaDespachante.Columnas.IdDespachante.ToString(),
                       AduanaDespachante.Columnas.NombreDespachante.ToString(),
                       AduanaDespachante.Columnas.Cuit.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}', '{2}')",
                       IdDespachante, NombreDespachante, Cuit)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub AduanasDespachantes_U(IdDespachante As Integer, NombreDespachante As String, Cuit As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE AduanasDespachantes ")
         .AppendFormat("   SET {0} = '{1}'", AduanaDespachante.Columnas.NombreDespachante.ToString(), NombreDespachante).AppendLine()
         .AppendFormat("     , {0} = '{1}'", AduanaDespachante.Columnas.Cuit.ToString(), Cuit).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", AduanaDespachante.Columnas.IdDespachante.ToString(), IdDespachante)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub AduanasDespachantes_D(IdDespachante As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM AduanasDespachantes WHERE {0} = {1}", AduanaDespachante.Columnas.IdDespachante.ToString(), IdDespachante)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT DES.* FROM AduanasDespachantes AS DES").AppendLine()
      End With
   End Sub

   Public Function AduanasDespachantes_GA() As DataTable
      Return AduanasDespachantes_G(0, String.Empty)
   End Function
   Public Function AduanasDespachantes_G(IdDespachante As Integer, nombre As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" WHERE 1 = 1")
         If IdDespachante > 0 Then
            .AppendFormat("   AND DES.{0} = {1}", AduanaDespachante.Columnas.IdDespachante.ToString(), IdDespachante)
         End If
         If Not String.IsNullOrWhiteSpace(nombre) Then
            .AppendFormat("   AND DES.{0} LIKE '%{1}%'", AduanaDespachante.Columnas.NombreDespachante.ToString(), nombre)
         End If
         .AppendFormat(" ORDER BY DES.NombreDespachante")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function AduanasDespachantes_G1(IdDespachante As Integer) As DataTable
      Return AduanasDespachantes_G(IdDespachante, String.Empty)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      columna = "DES." + columna

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(AduanaDespachante.Columnas.IdDespachante.ToString(), "AduanasDespachantes"))
   End Function

End Class
