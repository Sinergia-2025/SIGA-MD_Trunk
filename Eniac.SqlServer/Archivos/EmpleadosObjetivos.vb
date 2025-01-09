Public Class EmpleadosObjetivos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub
   Public Sub EmpleadosObjetivos_I(IdEmpleado As Integer, periodoFiscal As Integer, importeObjetivo As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO EmpleadosObjetivos")
         .AppendLine("           (IdEmpleado")
         .AppendLine("           ,PeriodoFiscal")
         .AppendLine("           ,ImporteObjetivo)")
         .AppendLine("         VALUES")
         .AppendFormat("           ({0},{1},{2})", IdEmpleado, periodoFiscal, importeObjetivo)
      End With

      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub EmpleadosObjetivos_D(IdEmpleado As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM EmpleadosObjetivos ")
         .AppendFormat(" WHERE IdEmpleado = {0}", IdEmpleado).AppendLine()
      End With

      Me.Execute(myQuery.ToString())

   End Sub
   Public Sub EmpleadosObjetivos_U(IdEmpleado As Integer, periodoFiscal As Integer, importeObjetivo As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE EmpleadosObjetivos")
         .AppendFormatLine("   SET PeriodoFiscal = {0}", periodoFiscal)
         .AppendFormatLine("      ,importeObjetivo = {0}", importeObjetivo)

         .AppendFormat(" WHERE IdEmpleado = {0}", IdEmpleado).AppendLine()
         .AppendFormat("       AND periodoFiscal = {0}", periodoFiscal).AppendLine()

      End With

      Me.Execute(myQuery.ToString())
   End Sub
   Public Function Buscar(columna As String, valor As String) As DataTable

      columna = "EO." + columna


      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT EO.* ")
         .AppendLine("  FROM EmpleadosObjetivos EO")
      End With
   End Sub
   Private Function EmpleadosObjetivos_G(IdEmpleado As Integer, periodoFiscal As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If IdEmpleado > 0 Then
            .AppendFormat("   AND EO.IdEmpleado = {0}", IdEmpleado).AppendLine()
         End If
         If periodoFiscal <> 0 Then
            .AppendFormat("   AND EO.periodoFiscal = {0}", periodoFiscal).AppendLine()
         End If
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function EmpleadosObjetivos_GA(IdEmpleado As Integer) As DataTable
      Return EmpleadosObjetivos_G(IdEmpleado:=IdEmpleado, periodoFiscal:=0)
   End Function

   Public Function EmpleadosObjetivos_G1(IdEmpleado As Integer, periodoFiscal As Integer) As DataTable
      Return EmpleadosObjetivos_G(IdEmpleado, periodoFiscal)
   End Function

   Public Function EmpleadosObjetivos_GA() As DataTable
      Return EmpleadosObjetivos_G(IdEmpleado:=Nothing, periodoFiscal:=0)
   End Function
End Class
