Public Class ArchivosAImprimir
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ArchivosAImprimir_I(ByVal idSucursal As Integer, _
                 ByVal NombreReporteOriginal As String, _
                 ByVal ReporteSecundario As String)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("INSERT INTO ArchivosAImprimir")
         .Append("           (IdSucursal")
         .Append("           ,NombreReporteOriginal")
         .Append("           ,ReporteSecundario)")
         .Append("     VALUES")
         .AppendFormat("           ({0}", idSucursal)
         .AppendFormat("           ,'{0}'", NombreReporteOriginal)
         .AppendFormat("           ,'{0}')", ReporteSecundario)
      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "ArchivosAImprimir")
   End Sub

   Public Sub ArchivosAImprimir_U(ByVal idSucursal As Integer, _
                 ByVal NombreReporteOriginal As String, _
                 ByVal ReporteSecundario As String)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("UPDATE ArchivosAImprimir")
         .Append("   SET ")
         .AppendFormat("      ReporteSecundario = '{0}'", ReporteSecundario)
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat(" AND NombreReporteOriginal = '{0}'", NombreReporteOriginal)

      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "ArchivosAImprimir")
   End Sub

   Public Sub ArchivosAImprimir_D(ByVal idSucursal As Integer, _
                 ByVal NombreReporteOriginal As String)
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("DELETE FROM ArchivosAImprimir")
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat(" AND NombreReporteOriginal = '{0}'", NombreReporteOriginal)
      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "ArchivosAImprimir")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Append("SELECT IdSucursal, NombreReporteOriginal")
         .Append("      ,ReporteSecundario")
         .Append("  FROM ArchivosAImprimir ")
      End With
   End Sub

   Public Function ArchivosAImprimir_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         Me.SelectTexto(stb)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ArchivosAImprimir_G1(ByVal idSucursal As Integer, ByVal NombreReporteOriginal As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND NombreReporteOriginal = '{0}'", NombreReporteOriginal)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "R." + columna
      'If columna = "R.NombreVendedor" Then columna = "V.NombreEmpleado"
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
