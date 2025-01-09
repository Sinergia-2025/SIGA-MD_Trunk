Option Explicit On
Option Strict On

Public Class CriticidadOrdenesProduccion
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CriticidadOrdenesProduccion_I(ByVal IdCriticidad As String, _
                               ByVal Orden As Integer)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("INSERT INTO OrdenesProduccionCriticidades")
         .AppendLine("   (IdCriticidad")
         .AppendLine("   ,Orden")
         .AppendLine(" ) VALUES ( ")
         .AppendLine("   '" & IdCriticidad & "'")
         .AppendLine("   ," & Orden.ToString())
         .AppendLine(")")
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub CriticidadOrdenesProduccion_U(ByVal IdCriticidad As String, _
                               ByVal Orden As Integer)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine(" UPDATE OrdenesProduccionCriticidades SET ")
         .AppendLine("   ,Orden = " & Orden.ToString())
         .AppendLine(" WHERE IdCriticidad = '" & IdCriticidad & "'")
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub CriticidadOrdenesProduccion_D(ByVal IdCriticidad As String)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("DELETE FROM OrdenesProduccionCriticidades")
         .AppendLine(" WHERE IdCriticidad = '" & IdCriticidad & "'")
      End With

      Me.Execute(stb.ToString())

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT E.* ")
         .AppendLine(" FROM OrdenesProduccionCriticidades E")
      End With
   End Sub

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "E." + columna
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function CriticidadOrdenesProduccion_GA(ByVal todos As Boolean) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)

         .Append("  ORDER BY E.IdCriticidad")

      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function CriticidadOrdenesProduccion_G1(ByVal IdCriticidad As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE E.IdCriticidad = '" & IdCriticidad & "'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetTodosPorOrden() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" ORDER BY E.Orden")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
End Class

