Public Class Feriados
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Feriados_I(fechaFeriado As Date, nombreFeriado As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO Feriados ({0}, {1})",
                           Entidades.Feriado.Columnas.FechaFeriado.ToString(), Entidades.Feriado.Columnas.NombreFeriado.ToString())
         .AppendFormatLine("     VALUES ('{0}', '{1}')",
                           ObtenerFecha(fechaFeriado, False), nombreFeriado)
      End With
      Execute(myQuery)
   End Sub

   Public Sub Feriados_U(fechaFeriado As Date, nombreFeriado As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE Feriados ")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.Feriado.Columnas.NombreFeriado.ToString(), nombreFeriado)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.Feriado.Columnas.FechaFeriado.ToString(), ObtenerFecha(fechaFeriado, False))
      End With
      Execute(myQuery)
   End Sub

   Public Sub Feriados_D(fechaFeriado As Date)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM Feriados WHERE {0} = '{1}'", Entidades.Feriado.Columnas.FechaFeriado.ToString(), ObtenerFecha(fechaFeriado, False))
      End With
      Execute(myQuery)
   End Sub

   Public Sub Feriados_Copiar(anoDesde As Integer, anoHasta As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO Feriados AS D")
         .AppendFormatLine("     USING (SELECT CONVERT(DATE,'{0}-' + CONVERT(VARCHAR(2),DATEPART(MM,FechaFeriado)) + '-' + CONVERT(VARCHAR(2),DATEPART(DD,FechaFeriado))) AS FechaFeriado, NombreFeriado", anoHasta)
         .AppendFormatLine("              FROM Feriados WHERE FechaFeriado >= '{0}0101' AND FechaFeriado <= '{0}1231') AS O ON O.FechaFeriado = D.FechaFeriado", anoDesde)
         .AppendFormatLine(" WHEN NOT MATCHED THEN INSERT (   FechaFeriado,    NombreFeriado) VALUES (O.FechaFeriado, O.NombreFeriado);")
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT FE.* FROM Feriados AS FE")
      End With
   End Sub

   Public Function Feriados_GA() As DataTable
      Return Feriados_G(fechaFeriadoDesde:=Nothing, fechaFeriadoHasta:=Nothing, nombreFeriado:=String.Empty, nombreExacto:=False)
   End Function
   Private Function Feriados_G(fechaFeriadoDesde As Date?, fechaFeriadoHasta As Date?, nombreFeriado As String, nombreExacto As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If fechaFeriadoDesde.HasValue Then
            .AppendFormatLine("   AND FE.FechaFeriado >= '{0}'", ObtenerFecha(fechaFeriadoDesde.Value, False))
         End If
         If fechaFeriadoHasta.HasValue Then
            .AppendFormatLine("   AND FE.FechaFeriado <= '{0}'", ObtenerFecha(fechaFeriadoHasta.Value, True))
         End If
         If Not String.IsNullOrWhiteSpace(nombreFeriado) Then
            If nombreExacto Then
               .AppendFormatLine("   AND FE.NombreFeriado = '{0}'", nombreFeriado)
            Else
               .AppendFormatLine("   AND FE.NombreFeriado LIKE '%{0}%'", nombreFeriado)
            End If
         End If
         .AppendFormatLine(" ORDER BY FE.FechaFeriado")
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function Feriados_GA(fechaFeriadoDesde As Date?, fechaFeriadoHasta As Date?) As DataTable
      Return Feriados_G(fechaFeriadoDesde:=fechaFeriadoDesde, fechaFeriadoHasta:=fechaFeriadoHasta, nombreFeriado:=String.Empty, nombreExacto:=False)
   End Function

   Public Function Feriados_G1(fechaFeriado As Date) As DataTable
      Return Feriados_G(fechaFeriadoDesde:=fechaFeriado, fechaFeriadoHasta:=fechaFeriado.UltimoSegundoDelDia(), nombreFeriado:=String.Empty, nombreExacto:=False)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "FE.")
   End Function

   Public Function GetDiasHabiles(fechaDesde As Date, fechaHasta As Date) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SET DATEFIRST 1")
         .AppendFormatLine("-- Consulta final")
         .AppendFormatLine("SELECT  SUM(CASE WHEN F.DiaSemana = 1 THEN F.Cant ELSE 0 END) AS 'Lun',")
         .AppendFormatLine("        SUM(CASE WHEN F.DiaSemana = 2 THEN F.Cant ELSE 0 END) AS 'Mar',")
         .AppendFormatLine("        SUM(CASE WHEN F.DiaSemana = 3 THEN F.Cant ELSE 0 END) AS 'Mie',")
         .AppendFormatLine("        SUM(CASE WHEN F.DiaSemana = 4 THEN F.Cant ELSE 0 END) AS 'Jue',")
         .AppendFormatLine("        SUM(CASE WHEN F.DiaSemana = 5 THEN F.Cant ELSE 0 END) AS 'Vie',")
         .AppendFormatLine("        SUM(CASE WHEN F.DiaSemana = 6 THEN F.Cant ELSE 0 END) AS 'Sab',")
         .AppendFormatLine("        SUM(CASE WHEN F.DiaSemana = 7 THEN F.Cant ELSE 0 END) AS 'Dom',")
         .AppendFormatLine("        SUM(CASE WHEN F.Cant      < 0 THEN 1      ELSE 0 END) AS 'Fer'")
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("        SELECT  1 AS Diasemana, DATEDIFF(DAY, -7, '{1}')/7-DATEDIFF(DAY, -6, '{0}')/7 AS Cant UNION", fechaDesde, fechaHasta)
         .AppendFormatLine("        SELECT  2 AS Diasemana, DATEDIFF(DAY, -6, '{1}')/7-DATEDIFF(DAY, -5, '{0}')/7 AS Cant UNION", fechaDesde, fechaHasta)
         .AppendFormatLine("        SELECT  3 AS Diasemana, DATEDIFF(DAY, -5, '{1}')/7-DATEDIFF(DAY, -4, '{0}')/7 AS Cant UNION", fechaDesde, fechaHasta)
         .AppendFormatLine("        SELECT  4 AS Diasemana, DATEDIFF(DAY, -4, '{1}')/7-DATEDIFF(DAY, -3, '{0}')/7 AS Cant UNION", fechaDesde, fechaHasta)
         .AppendFormatLine("        SELECT  5 AS Diasemana, DATEDIFF(DAY, -3, '{1}')/7-DATEDIFF(DAY, -2, '{0}')/7 AS Cant UNION", fechaDesde, fechaHasta)
         .AppendFormatLine("        SELECT  6 AS Diasemana, DATEDIFF(DAY, -2, '{1}')/7-DATEDIFF(DAY, -1, '{0}')/7 AS Cant UNION", fechaDesde, fechaHasta)
         .AppendFormatLine("        SELECT  7 AS Diasemana, DATEDIFF(DAY, -1, '{1}')/7-DATEDIFF(DAY,  0, '{0}')/7 AS Cant UNION", fechaDesde, fechaHasta)
         .AppendFormatLine("        SELECT DATEPART(WEEKDAY, FechaFeriado) Diasemana, -1 Cant FROM Feriados WHERE FechaFeriado BETWEEN '{0}' AND '{1}'", fechaDesde, fechaHasta)
         .AppendFormatLine("       ) F")
      End With
      Return GetDataTable(stb)
   End Function
End Class