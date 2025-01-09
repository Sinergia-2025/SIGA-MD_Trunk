Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class AduanasAgentesTransporte
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub AduanasAgentesTransporte_I(IdAgenteTransporte As Integer, NombreAgenteTransporte As String, Cuit As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO AduanasAgentesTransporte ({0}, {1}, {2})",
                       AduanaAgenteTransporte.Columnas.IdAgenteTransporte.ToString(),
                       AduanaAgenteTransporte.Columnas.NombreAgenteTransporte.ToString(),
                       AduanaAgenteTransporte.Columnas.Cuit.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}', '{2}')",
                       IdAgenteTransporte, NombreAgenteTransporte, Cuit)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub AduanasAgentesTransporte_U(IdAgenteTransporte As Integer, NombreAgenteTransporte As String, Cuit As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE AduanasAgentesTransporte ")
         .AppendFormat("   SET {0} = '{1}'", AduanaAgenteTransporte.Columnas.NombreAgenteTransporte.ToString(), NombreAgenteTransporte).AppendLine()
         .AppendFormat("     , {0} = '{1}'", AduanaAgenteTransporte.Columnas.Cuit.ToString(), Cuit).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", AduanaAgenteTransporte.Columnas.IdAgenteTransporte.ToString(), IdAgenteTransporte)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub AduanasAgentesTransporte_D(IdAgenteTransporte As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM AduanasAgentesTransporte WHERE {0} = {1}", AduanaAgenteTransporte.Columnas.IdAgenteTransporte.ToString(), IdAgenteTransporte)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT AGE.* FROM AduanasAgentesTransporte AS AGE").AppendLine()
      End With
   End Sub

   Public Function AduanasAgentesTransporte_GA() As DataTable
      Return AduanasAgentesTransporte_G(0, String.Empty)
   End Function
   Public Function AduanasAgentesTransporte_G(idAgenteTransporte As Integer, nombre As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" WHERE 1 = 1")
         If idAgenteTransporte > 0 Then
            .AppendFormat("   AND AGE.{0} = {1}", AduanaAgenteTransporte.Columnas.IdAgenteTransporte.ToString(), idAgenteTransporte)
         End If
         If Not String.IsNullOrWhiteSpace(nombre) Then
            .AppendFormat("   AND AGE.{0} LIKE '%{1}%'", AduanaAgenteTransporte.Columnas.NombreAgenteTransporte.ToString(), nombre)
         End If
         .AppendFormat(" ORDER BY AGE.NombreAgenteTransporte")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function AduanasAgentesTransporte_G1(IdAgenteTransporte As Integer) As DataTable
      Return AduanasAgentesTransporte_G(IdAgenteTransporte, String.Empty)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      columna = "AGE." + columna

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(AduanaAgenteTransporte.Columnas.IdAgenteTransporte.ToString(), "AduanasAgentesTransporte"))
   End Function

End Class
