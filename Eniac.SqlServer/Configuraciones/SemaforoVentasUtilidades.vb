Public Class SemaforoVentasUtilidades
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub SemaforoVentasUtilidades_I(idSemaforo As Integer,
                                         porcentajeHasta As Decimal,
                                         colorSemaforo As Integer,
                                         colorLetra As Integer,
                                         nombreColor As String,
                                         idTipoSemaforoVentaUtilidad As Entidades.SemaforoVentaUtilidad.TiposSemaforos,
                                         negrita As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO SemaforoVentasUtilidades (")
         .AppendFormatLine("      IdSemaforo")
         .AppendFormatLine("     ,PorcentajeHasta")
         .AppendFormatLine("     ,ColorSemaforo")
         .AppendFormatLine("     ,ColorLetra")
         .AppendFormatLine("     ,NombreColor")
         .AppendFormatLine("     ,IdTipoSemaforoVentaUtilidad")
         .AppendFormatLine("     ,Negrita")
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine(idSemaforo.ToString())
         .AppendFormatLine(", {0} ", porcentajeHasta)
         .AppendFormatLine(", {0} ", colorSemaforo)
         .AppendFormatLine(", {0} ", colorLetra)
         .AppendFormatLine(",'{0}'", nombreColor)
         .AppendFormatLine(",'{0}'", idTipoSemaforoVentaUtilidad)
         .AppendFormatLine(", {0}", GetStringFromBoolean(negrita))
         .AppendFormatLine(")")
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub SemaforoVentasUtilidades_U(idSemaforo As Integer,
                                         porcentajeHasta As Decimal,
                                         colorSemaforo As Integer,
                                         colorLetra As Integer,
                                         nombreColor As String,
                                         idTipoSemaforoVentaUtilidad As Entidades.SemaforoVentaUtilidad.TiposSemaforos,
                                         negrita As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE SemaforoVentasUtilidades")
         .AppendFormatLine("   SET PorcentajeHasta = {0}", porcentajeHasta)
         .AppendFormatLine("      ,ColorSemaforo = {0}", colorSemaforo)
         .AppendFormatLine("      ,ColorLetra = {0}", colorLetra)
         .AppendFormatLine("      ,NombreColor = '{0}'", nombreColor)
         .AppendFormatLine("      ,IdTipoSemaforoVentaUtilidad = '{0}'", idTipoSemaforoVentaUtilidad)
         .AppendFormatLine("      ,Negrita = {0}", GetStringFromBoolean(negrita))
         .AppendFormatLine(" WHERE IdSemaforo = {0}", idSemaforo)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub SemaforoVentasUtilidades_D(idSemaforo As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("DELETE FROM SemaforoVentasUtilidades")
         .AppendFormatLine("   WHERE IdSemaforo = {0}", idSemaforo)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT S.IdSemaforo")
         .AppendLine("      ,S.PorcentajeHasta")
         .AppendLine("      ,S.ColorSemaforo")
         .AppendLine("      ,S.ColorLetra")
         .AppendLine("      ,S.NombreColor")
         .AppendLine("      ,S.IdTipoSemaforoVentaUtilidad")
         .AppendLine("      ,S.Negrita")
         .AppendLine("  FROM SemaforoVentasUtilidades S")
      End With
   End Sub

   Public Function SemaforoVentasUtilidades_GA() As DataTable
      Return SemaforoVentasUtilidades_GA(tipo:=Nothing)
   End Function

   Public Function SemaforoVentasUtilidades_GA(tipo As Entidades.SemaforoVentaUtilidad.TiposSemaforos?) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If tipo.HasValue Then
            .AppendFormatLine("   AND S.IdTipoSemaforoVentaUtilidad = '{0}'", tipo.ToString())
         End If
         .AppendLine("  ORDER BY S.IdTipoSemaforoVentaUtilidad, S.PorcentajeHasta")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function SemaforoVentasUtilidades_G1(idSemaforo As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE S.IdSemaforo = {0}", idSemaforo)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function SemaforoVentasUtilidades_ColorSemaforo(porcentaje As Decimal,
                                                          idTipoSemaforo As Entidades.SemaforoVentaUtilidad.TiposSemaforos) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT TOP (1) ")
         .AppendLine("       S.IdSemaforo")
         .AppendLine("      ,S.PorcentajeHasta")
         .AppendLine("      ,S.ColorSemaforo")
         .AppendLine("      ,S.ColorLetra")
         .AppendLine("      ,S.NombreColor")
         .AppendLine("      ,S.IdTipoSemaforoVentaUtilidad")
         .AppendLine("      ,S.Negrita")
         .AppendLine("  FROM SemaforoVentasUtilidades S")
         .AppendFormat(" WHERE {0} <= S.PorcentajeHasta", porcentaje)
         .AppendFormatLine(" AND S.{0} = '{1}'", Entidades.SemaforoVentaUtilidad.Columnas.IdTipoSemaforoVentaUtilidad.ToString(), idTipoSemaforo)
         .AppendLine(" ORDER BY S.IdTipoSemaforoVentaUtilidad, S.PorcentajeHasta")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(columna As String, valor As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
         .AppendLine(" ORDER BY S.PorcentajeHasta")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo("IdSemaforo", "SemaforoVentasUtilidades"))
   End Function

End Class