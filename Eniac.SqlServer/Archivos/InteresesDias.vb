Public Class InteresesDias
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub InteresesDias_I(idInteres As Integer,
                              diasDesde As Integer, diasHasta As Integer, porcInteres As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} ({1}, {2}, {3}, {4})",
                           Entidades.InteresDias.NombreTabla,
                           Entidades.InteresDias.Columnas.IdInteres.ToString(),
                           Entidades.InteresDias.Columnas.DiasDesde.ToString(),
                           Entidades.InteresDias.Columnas.DiasHasta.ToString(),
                           Entidades.InteresDias.Columnas.Interes.ToString())
         .AppendFormatLine("     VALUES ({0}, {1}, {2}, {3})",
                           idInteres, diasDesde, diasHasta, porcInteres)
      End With
      Execute(myQuery)
   End Sub

   Public Sub InteresesDias_U(idInteres As Integer,
                              diasDesde As Integer, diasHasta As Integer, porcInteres As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.InteresDias.NombreTabla)
         .AppendFormatLine("   SET {0} = {1}", Entidades.InteresDias.Columnas.Interes.ToString(), porcInteres)
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.InteresDias.Columnas.IdInteres.ToString(), idInteres)
         .AppendFormatLine("   AND {0} = {1}", Entidades.InteresDias.Columnas.DiasDesde.ToString(), diasDesde)
         .AppendFormatLine("   AND {0} = {1}", Entidades.InteresDias.Columnas.DiasHasta.ToString(), diasHasta)
      End With
      Execute(myQuery)
   End Sub

   Public Sub InteresesDias_D(idInteres As Integer, diasDesde As Integer?, diasHasta As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM InteresesDias ")
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.InteresDias.Columnas.IdInteres.ToString(), idInteres)
         If diasDesde.HasValue Then
            .AppendFormatLine("   AND {0} = {1}", Entidades.InteresDias.Columnas.DiasDesde.ToString(), diasDesde.Value)
         End If
         If diasHasta.HasValue Then
            .AppendFormatLine("   AND {0} = {1}", Entidades.InteresDias.Columnas.DiasHasta.ToString(), diasHasta.Value)
         End If
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT ID.*")
         .AppendFormatLine("     , I.NombreInteres")
         .AppendFormatLine("     , I.AdicionalProporcinalDias")
         .AppendFormatLine("     , I.IdInteres AS IdInteresMaster")
         .AppendFormatLine("     , I.MetodoParaDeterminarRango")
         .AppendFormatLine("     , I.FechaVigenciaDesde")
         .AppendFormatLine("     , I.FechaVigenciaHasta")
         .AppendFormatLine("     , I.VencimientoExcluyeSabado")
         .AppendFormatLine("     , I.VencimientoExcluyeDomingo")
         .AppendFormatLine("     , I.VencimientoExcluyeFeriados")
         .AppendFormatLine("  FROM InteresesDias AS ID")
         .AppendFormatLine(" RIGHT JOIN Intereses AS I ON I.IdInteres = ID.IdInteres")
      End With
   End Sub

   Public Function InteresesDias_GA() As DataTable
      Return InteresesDias_GA(Nothing)
   End Function

   Public Function InteresesDias_GA(idInteres As Integer?) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         If idInteres.HasValue Then
            .AppendFormatLine(" WHERE ID.{0} = {1}", Entidades.InteresDias.Columnas.IdInteres.ToString(), idInteres.Value)
         End If
         .AppendFormatLine(" ORDER BY I.NombreInteres, ID.DiasDesde, ID.DiasHasta")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function InteresesDias_G1(idInteres As Integer, diasDesde As Integer, diasHasta As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE ID.{0} = {1}", Entidades.InteresDias.Columnas.IdInteres.ToString(), idInteres)
         .AppendFormatLine("   AND ID.{0} = {1}", Entidades.InteresDias.Columnas.DiasDesde.ToString(), diasDesde)
         .AppendFormatLine("   AND ID.{0} = {1}", Entidades.InteresDias.Columnas.DiasHasta.ToString(), diasHasta)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "ID.", New Dictionary(Of String, String) From {
                    {"IdInteresMaster", "I.IdInteres"},
                    {"NombreInteres", "I.NombreInteres"},
                    {"AdicionalProporcinalDias", "I.AdicionalProporcinalDias"},
                    {"MetodoParaDeterminarRango", "I.MetodoParaDeterminarRango"},
                    {"FechaVigenciaDesde", "I.FechaVigenciaDesde"},
                    {"FechaVigenciaHasta", "I.FechaVigenciaHasta"},
                    {"VencimientoExcluyeSabado", "I.VencimientoExcluyeSabado"},
                    {"VencimientoExcluyeDomingo", "I.VencimientoExcluyeDomingo"},
                    {"VencimientoExcluyeFeriados", "I.VencimientoExcluyeFeriados"}
                    })
   End Function

   Public Overloads Function GetCodigoMaximo(Campo As String) As Long
      Return Convert.ToInt32(GetCodigoMaximo(Campo, Entidades.InteresDias.NombreTabla, String.Format("{0} <> 999", Campo)))
   End Function

   Public Function GetInteres(formaPago As Integer, cuotas As Integer, idInteres As Integer) As Decimal
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT *")
         .AppendFormatLine("  FROM InteresesDias I ")
         .AppendFormatLine(" WHERE ((SELECT Dias FROM FichasFormasPago FP")
         .AppendFormatLine("          WHERE IdFormasPago = {0}) * {1}) >= I.DiasDesde  ", formaPago, cuotas)
         .AppendFormatLine("            AND ((SELECT Dias FROM FichasFormasPago FP ")
         .AppendFormatLine("                   WHERE IdFormasPago = {0}) * {1}) <= I.DiasHasta ", formaPago, cuotas)
         .AppendFormatLine("   AND IdInteres = {0}", idInteres)
      End With
      Using dt = GetDataTable(stbQuery)
         Return If(Not dt.Any(), 0, dt.First().Field(Of Decimal)("Interes"))
      End Using
   End Function

   Public Function GetInteresVentas(formaPago As Integer, cuotas As Integer, IdInteres As Integer) As Decimal
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT I.* ")
         .AppendFormatLine("  FROM InteresesDias I ")
         .AppendFormatLine(" CROSS JOIN (SELECT * FROM VentasFormasPago WHERE IdFormasPago = {0}) VFP", formaPago)
         .AppendFormatLine(" WHERE (VFP.Dias * {0}) >= I.DiasDesde ", cuotas)
         .AppendFormatLine("   AND (VFP.Dias * {0}) <= I.DiasHasta ", cuotas)
         .AppendFormatLine("   AND IdInteres = {0}", IdInteres)
      End With
      Using dt = GetDataTable(stbQuery)
         Return If(Not dt.Any(), 0, dt.First().Field(Of Decimal)("Interes"))
      End Using
   End Function

   Public Function GetInteresVentasSegunDias(dias As Integer, idInteres As Integer) As Decimal
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT I.* ")
         .AppendFormatLine("  FROM InteresesDias I")
         .AppendFormatLine(" WHERE I.DiasDesde <= {0} And I.DiasHasta >= {0}", dias)
         .AppendFormatLine("   AND I.IdInteres = {0}", idInteres)
      End With
      Using dt = GetDataTable(stbQuery)
         Return If(Not dt.Any(), 0, dt.First().Field(Of Decimal)("Interes"))
      End Using
   End Function

   Public Shared Function InteresesDias_SegunFecha_Query(metodo As String, fechaComprobante As Date, fechaVencimiento As Date, fechaRecibo As Date) As String
      Dim stb = New StringBuilder()
      With stb
         If metodo = "DIAMES" Then

            .AppendFormat("SELECT *").AppendLine()
            .AppendFormat("  FROM (SELECT * FROM InteresesDias").AppendLine()
            .AppendFormat("        UNION").AppendLine()
            .AppendFormat("        SELECT TOP 1 DiasHasta + 1, 999999 ").AppendLine()
            .AppendFormat("                    ,Interes + (((SELECT CONVERT(decimal(9,2), ISNULL(ValorParametro, 0)) AS Valor ").AppendLine()
            .AppendFormat("                                    FROM Parametros WHERE IdParametro = 'InteresesDiasADICIONALPROPORCIONALDIARIO') / 30) * ").AppendLine()
            .AppendFormat("                                    (CONVERT(int, CONVERT(datetime, {0}) - CONVERT(datetime, PrimerDiaMes.PrimerDia) + 1) - ",
                          fechaComprobante, fechaVencimiento, fechaRecibo).AppendLine()
            .AppendFormat("                                     DiasHasta)) FROM InteresesDias ").AppendLine()
            .AppendFormat("                                     CROSS JOIN (SELECT dateadd([month], datediff([month], '19000101', {0}), '19000101') AS PrimerDia) AS PrimerDiaMes",
                          fechaComprobante, fechaVencimiento, fechaRecibo).AppendLine()
            .AppendFormat("                                     ORDER BY DiasHasta DESC) InteresesDias").AppendLine()
            .AppendFormat(" CROSS JOIN (SELECT dateadd([month], datediff([month], '19000101', {0}), '19000101') AS PrimerDia) AS PrimerDiaMes",
                          fechaComprobante, fechaVencimiento, fechaRecibo).AppendLine()
            .AppendFormat(" WHERE 1 = 1").AppendLine()
            .AppendFormat("   AND DiasDesde <= CONVERT(int, CONVERT(datetime, {2}) - CONVERT(datetime, PrimerDiaMes.PrimerDia) + 1)",
                          fechaComprobante, fechaVencimiento, fechaRecibo).AppendLine()
            .AppendFormat("   AND DiasHasta >= CONVERT(int, CONVERT(datetime, {2}) - CONVERT(datetime, PrimerDiaMes.PrimerDia) + 1)",
                          fechaComprobante, fechaVencimiento, fechaRecibo).AppendLine()

         ElseIf metodo = "DIASCORRIDOSEMISION" Then

            .AppendFormat("SELECT *").AppendLine()
            .AppendFormat("  FROM (SELECT * FROM InteresesDias").AppendLine()
            .AppendFormat("        UNION").AppendLine()
            .AppendFormat("        SELECT TOP 1 DiasHasta + 1, 999999 ").AppendLine()
            .AppendFormat("                    ,Interes + (((SELECT CONVERT(decimal(9,2), ISNULL(ValorParametro, 0)) AS Valor ").AppendLine()
            .AppendFormat("                                    FROM Parametros WHERE IdParametro = 'InteresesDiasADICIONALPROPORCIONALDIARIO') / 30) * ").AppendLine()
            .AppendFormat("                                    (CONVERT(int, CONVERT(datetime, {2}) - CONVERT(datetime, {0})) - ",
                          fechaComprobante, fechaVencimiento, fechaRecibo).AppendLine()
            .AppendFormat("                                     DiasHasta)) FROM InteresesDias ORDER BY DiasHasta DESC) InteresesDias").AppendLine()
            .AppendFormat(" WHERE 1 = 1").AppendLine()
            .AppendFormat("   AND DiasDesde <= CONVERT(int, CONVERT(datetime, {2}) - CONVERT(datetime, {0}))",
                          fechaComprobante, fechaVencimiento, fechaRecibo).AppendLine()
            .AppendFormat("   AND DiasHasta >= CONVERT(int, CONVERT(datetime, {2}) - CONVERT(datetime, {0}))",
                          fechaComprobante, fechaVencimiento, fechaRecibo).AppendLine()

         ElseIf metodo = "DIASCORRIDOSVENCIMIENTO" Then

            .AppendFormat("SELECT *").AppendLine()
            .AppendFormat("  FROM (SELECT * FROM InteresesDias").AppendLine()
            .AppendFormat("        UNION").AppendLine()
            .AppendFormat("        SELECT TOP 1 DiasHasta + 1, 999999 ").AppendLine()
            .AppendFormat("                    ,Interes + (((SELECT CONVERT(decimal(9,2), ISNULL(ValorParametro, 0)) AS Valor ").AppendLine()
            .AppendFormat("                                    FROM Parametros WHERE IdParametro = 'InteresesDiasADICIONALPROPORCIONALDIARIO') / 30) * ").AppendLine()
            .AppendFormat("                                    (CONVERT(int, CONVERT(datetime, {2}) - CONVERT(datetime, {1})) - ",
                          fechaComprobante, fechaVencimiento, fechaRecibo).AppendLine()
            .AppendFormat("                                     DiasHasta)) FROM InteresesDias ORDER BY DiasHasta DESC) InteresesDias").AppendLine()
            .AppendFormat(" WHERE 1 = 1").AppendLine()
            .AppendFormat("   AND DiasDesde <= CONVERT(int, CONVERT(datetime, {2}) - CONVERT(datetime, {1}))",
                          fechaComprobante, fechaVencimiento, fechaRecibo).AppendLine()
            .AppendFormat("   AND DiasHasta >= CONVERT(int, CONVERT(datetime, {2}) - CONVERT(datetime, {1}))",
                          fechaComprobante, fechaVencimiento, fechaRecibo).AppendLine()

         Else
            Return String.Empty
         End If
      End With
      Return stb.ToString()
   End Function

End Class