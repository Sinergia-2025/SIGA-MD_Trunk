Public Class ContabilidadTiposCuentas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposCuentas_I(ByVal IdTipoCuenta As Integer, _
                                 ByVal NombreTipoCuenta As String)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("INSERT INTO ContabilidadTiposCuentas")
         .AppendLine("   (IdTipoCuenta")
         .AppendLine("   ,NombreTipoCuenta")
         .AppendLine(" ) VALUES ( ")
         .AppendLine("   " & IdTipoCuenta.ToString())
         .AppendLine("   ,'" & NombreTipoCuenta & "'")
         .AppendLine(")")
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub TiposCuentas_U(ByVal IdTipoCuenta As Integer, _
                                  ByVal NombreTipoCuenta As String)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("UPDATE ContabilidadTiposCuentas SET ")
         .AppendLine("   NombreTipoCuenta = '" & NombreTipoCuenta & "'")
         .AppendLine(" WHERE IdTipoCuenta = " & IdTipoCuenta.ToString())
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub TiposCuentas_D(ByVal IdTipoCuenta As Integer)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("DELETE FROM ContabilidadTiposCuentas")
         .AppendLine(" WHERE IdTipoCuenta = " & IdTipoCuenta.ToString())
      End With

      Me.Execute(stb.ToString())

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT TP.* ")
         .AppendLine(" FROM ContabilidadTiposCuentas TP")
      End With
   End Sub

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "TP." + columna
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function TipoCuenta_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append("  ORDER BY TP.IdTipoCuenta")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function TipoCuenta_G1(ByVal IdTipoCuenta As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE IdTipoCuenta = " & IdTipoCuenta.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorNombre(ByVal NombreTipoCuenta As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE TP.NombreTipoCuenta LIKE '%" & NombreTipoCuenta & "%'")
         .AppendLine(" ORDER BY TP.NombreTipoCuenta")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function TipoCuenta_GetIdMaximo() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendLine("SELECT MAX(IdTipoCuenta) AS maximo ")
         .AppendLine(" FROM ContabilidadTiposCuentas")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
