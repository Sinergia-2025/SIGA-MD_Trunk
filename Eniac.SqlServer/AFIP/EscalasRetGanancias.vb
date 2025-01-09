Public Class EscalasRetGanancias
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EscalasRetGanancias_I(ByVal IdEscala As Integer, _
                           ByVal MontoMasDe As Decimal, _
                           ByVal MontoA As Decimal, _
                           ByVal Importe As Decimal, _
                           ByVal MasPorcentaje As Decimal, _
                           ByVal SobreExcedente As Decimal)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("INSERT INTO EscalasRetGanancias")
         .Append("           (IdEscala")
         .Append("           ,MontoMasDe")
         .Append("           ,MontoA")
         .Append("           ,Importe")
         .Append("           ,MasPorcentaje")
         .Append("           ,SobreExcedente)")
         .Append("     VALUES")
         .AppendFormat("           ({0}", IdEscala)
         .AppendFormat("           ,{0}", MontoMasDe)
         .AppendFormat("           ,{0}", MontoA)
         .AppendFormat("           ,{0}", Importe)
         .AppendFormat("           ,{0}", MasPorcentaje)
         .AppendFormat("           ,{0})", SobreExcedente)
      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "EscalasRetGanancias")
   End Sub

   Public Sub EscalasRetGanancias_U(ByVal IdEscala As Integer, _
                           ByVal MontoMasDe As Decimal, _
                           ByVal MontoA As Decimal, _
                           ByVal Importe As Decimal, _
                           ByVal MasPorcentaje As Decimal, _
                           ByVal SobreExcedente As Decimal)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("UPDATE EscalasRetGanancias")
         .Append("   SET ")
         .AppendFormat("      MontoMasDe = {0}", MontoMasDe)
         .AppendFormat("      ,MontoA = {0}", MontoA)
         .AppendFormat("      ,Importe = {0}", Importe)
         .AppendFormat("      ,MasPorcentaje = {0}", MasPorcentaje)
         .AppendFormat("      ,SobreExcedente = {0}", SobreExcedente)

         .AppendFormat(" WHERE IdEscala = {0}", IdEscala)
      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "EscalasRetGanancias")
   End Sub

   Public Sub EscalasRetGanancias_D(ByVal IdEscala As Integer)
      Dim stb As StringBuilder = New StringBuilder("")

      With stb

         .Append("DELETE FROM EscalasRetGanancias")
         .AppendFormat(" WHERE IdEscala = {0}", IdEscala)
      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "EscalasRetGanancias")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendLine("SELECT [IdEscala] ")
         .AppendLine(" ,[MontoMasDe]")
         .AppendLine(" ,[MontoA] ")
         .AppendLine(" ,[Importe] ")
         .AppendLine(" ,[MasPorcentaje] ")
         .AppendLine(" ,[SobreExcedente] ")
         .AppendLine(" FROM [dbo].[EscalasRetGanancias] ")
      End With
   End Sub

   Public Function EscalasRetGanancias_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         Me.SelectTexto(stb)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function EscalasRetGanancias_G1(ByVal IdEscala As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE IdEscala = {0}", IdEscala)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine("  WHERE ")
         .Append(columna)
         .Append(" LIKE '%")
         .Append(valor)
         .Append("%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function



End Class
