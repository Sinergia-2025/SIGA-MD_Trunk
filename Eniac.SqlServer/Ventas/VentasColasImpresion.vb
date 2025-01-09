Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class VentasColasImpresion
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VentasColasImpresion_I(idColaImpresion As Integer,
                                     nombreColaImpresion As String,
                                     activa As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendFormat("INSERT INTO VentasColasImpresion ({0}, {1}, {2})",
                       VentaColaImpresion.Columnas.IdVentaColaImpresion.ToString(),
                       VentaColaImpresion.Columnas.NombreColaImpresion.ToString(),
                       VentaColaImpresion.Columnas.Activa.ToString()
                       ).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}', {2})",
                       idColaImpresion,
                       nombreColaImpresion,
                       GetStringFromBoolean(activa)
                       )
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub VentasColasImpresion_U(idColaImpresion As Integer,
                                     nombreColaImpresion As String,
                                     activa As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("UPDATE VentasColasImpresion ").AppendLine()
         .AppendFormat("   SET {0} = '{1}'", VentaColaImpresion.Columnas.NombreColaImpresion.ToString(), nombreColaImpresion).AppendLine()
         .AppendFormat("      ,{0} = {1}", VentaColaImpresion.Columnas.Activa.ToString(), GetStringFromBoolean(activa)).AppendLine()
         .AppendFormat(" WHERE {0} = {1}", VentaColaImpresion.Columnas.IdVentaColaImpresion.ToString(), idColaImpresion).AppendLine()
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub VentasColasImpresion_D(idColaImpresion As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM VentasColasImpresion ")
         .AppendFormat(" WHERE {0} = {1}", VentaColaImpresion.Columnas.IdVentaColaImpresion.ToString(), idColaImpresion).AppendLine()
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendFormat("SELECT VC.* FROM VentasColasImpresion AS VC").AppendLine()
      End With
   End Sub

   Public Function VentasColasImpresion_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" ORDER BY VC.NombreColaImpresion")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function VentasColasImpresion_G1(idColaImpresion As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE VC.{0} = {1}", VentaColaImpresion.Columnas.IdVentaColaImpresion.ToString(), idColaImpresion).AppendLine()
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "VC." + columna
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
End Class
