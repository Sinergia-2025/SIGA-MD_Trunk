Option Strict On
Option Explicit On
Imports Eniac.Entidades

Public Class PersonalizacionDeInformes
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub PersonalizacionDeInformes_I(idInforme As String,
                                          nombreArchivo As String,
                                          embebido As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendFormat("INSERT INTO PersonalizacionDeInformes ({0}, {1}, {2})",
                       PersonalizacionDeInforme.Columnas.IdInforme.ToString(),
                       PersonalizacionDeInforme.Columnas.NombreArchivo.ToString(),
                       PersonalizacionDeInforme.Columnas.Embebido.ToString()).AppendLine()
         .AppendFormat("     VALUES ('{0}', '{1}', {2})",
                       idInforme, nombreArchivo, GetStringFromBoolean(embebido))
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub PersonalizacionDeInformes_U(idInforme As String,
                                          nombreArchivo As String,
                                          embebido As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendLine("UPDATE PersonalizacionDeInformes ")
         .AppendFormat("   SET {0} = '{1}'", PersonalizacionDeInforme.Columnas.NombreArchivo.ToString(), nombreArchivo).AppendLine()
         .AppendFormat("     , {0} =  {1} ", PersonalizacionDeInforme.Columnas.Embebido.ToString(), GetStringFromBoolean(embebido)).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", PersonalizacionDeInforme.Columnas.IdInforme.ToString(), idInforme)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub PersonalizacionDeInformes_D(idInforme As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM PersonalizacionDeInformes WHERE {0} = '{1}'", PersonalizacionDeInforme.Columnas.IdInforme.ToString(), idInforme)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT PDI.* FROM PersonalizacionDeInformes AS PDI").AppendLine()
      End With
   End Sub

   Public Function PersonalizacionDeInformes_GA() As DataTable
      Return PersonalizacionDeInformes_G(String.Empty)
   End Function
   Public Function PersonalizacionDeInformes_G(idInforme As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If Not String.IsNullOrWhiteSpace(idInforme) Then
            .AppendFormat("   AND PDI.IdInforme = '{0}'", idInforme).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function PersonalizacionDeInformes_G1(idInforme As String) As DataTable
      Return PersonalizacionDeInformes_G(idInforme)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      'If columna = "NombreTipoNovedad" Then
      '   columna = "TN." + columna
      'Else
      columna = "PDI." + columna
      'End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class