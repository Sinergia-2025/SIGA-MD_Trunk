Option Strict On
Option Explicit On
Imports Eniac.Entidades

Public Class PadronesARBA
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess, dataBase As String)
      MyBase.New(da)
      Me._database = dataBase
   End Sub

   Private _database As String = String.Empty
   Private ReadOnly Property DataBase As String
      Get
         Return Me._database
      End Get
   End Property

   Public Sub PadronARBA_I(ByVal IdPadronARBA As Long,
                           ByVal PeriodoInformado As Integer,
                           ByVal TipoRegimen As String,
                           ByVal FechaPublicacion As DateTime,
                           ByVal FechaVigenciaDesde As DateTime,
                           ByVal FechaVigenciaHasta As DateTime,
                           ByVal CUIT As Long,
                           ByVal TipoContribuyente As String,
                           ByVal AccionARBA As String,
                           ByVal CambioAlicuota As Boolean,
                           ByVal Alicuota As Decimal,
                           ByVal Grupo As Integer)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendFormat("INSERT INTO {12}.dbo.PadronARBA ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11})",
                       PadronARBA.Columnas.IdPadronARBA.ToString(),
                       PadronARBA.Columnas.PeriodoInformado.ToString(),
                       PadronARBA.Columnas.TipoRegimen.ToString(),
                       PadronARBA.Columnas.FechaPublicacion.ToString(),
                       PadronARBA.Columnas.FechaVigenciaDesde.ToString(),
                       PadronARBA.Columnas.FechaVigenciaHasta.ToString(),
                       PadronARBA.Columnas.CUIT.ToString(),
                       PadronARBA.Columnas.TipoContribuyente.ToString(),
                       PadronARBA.Columnas.AccionARBA.ToString(),
                       PadronARBA.Columnas.CambioAlicuota.ToString(),
                       PadronARBA.Columnas.Alicuota.ToString(),
                       PadronARBA.Columnas.Grupo.ToString(),
                       Me.DataBase).AppendLine()
         .AppendFormat(" VALUES ({0}, {1}, '{2}', '{3}', '{4}', '{5}', {6}, '{7}', '{8}', {9}, {10}, {11})",
                       IdPadronARBA,
                       PeriodoInformado,
                       TipoRegimen,
                       FechaPublicacion,
                       FechaVigenciaDesde,
                       FechaVigenciaHasta,
                       CUIT,
                       TipoContribuyente,
                       AccionARBA,
                       GetStringFromBoolean(CambioAlicuota),
                       Alicuota,
                       Grupo)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub PadronARBA_U(ByVal IdPadronARBA As Long,
                           ByVal PeriodoInformado As Integer,
                           ByVal TipoRegimen As String,
                           ByVal FechaPublicacion As DateTime,
                           ByVal FechaVigenciaDesde As DateTime,
                           ByVal FechaVigenciaHasta As DateTime,
                           ByVal CUIT As Long,
                           ByVal TipoContribuyente As String,
                           ByVal AccionARBA As String,
                           ByVal CambioAlicuota As Boolean,
                           ByVal Alicuota As Decimal,
                           ByVal Grupo As Integer)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendFormat("UPDATE {0}.dbo.PadronARBA SET", Me.DataBase)
         .AppendFormat("       {0} = '{1}'", PadronARBA.Columnas.TipoRegimen.ToString(), TipoRegimen).AppendLine()
         .AppendFormat("      ,{0} = '{1}'", PadronARBA.Columnas.FechaPublicacion.ToString(), FechaPublicacion).AppendLine()
         .AppendFormat("      ,{0} = '{1}'", PadronARBA.Columnas.FechaVigenciaDesde.ToString(), FechaVigenciaDesde).AppendLine()
         .AppendFormat("      ,{0} = '{1}'", PadronARBA.Columnas.FechaVigenciaHasta.ToString(), FechaVigenciaHasta).AppendLine()
         .AppendFormat("      ,{0} =  {1} ", PadronARBA.Columnas.CUIT.ToString(), CUIT).AppendLine()
         .AppendFormat("      ,{0} = '{1}'", PadronARBA.Columnas.TipoContribuyente.ToString(), TipoContribuyente).AppendLine()
         .AppendFormat("      ,{0} =  {1} ", PadronARBA.Columnas.AccionARBA.ToString(), AccionARBA).AppendLine()
         .AppendFormat("      ,{0} =  {1} ", PadronARBA.Columnas.CambioAlicuota.ToString(), CambioAlicuota).AppendLine()
         .AppendFormat("      ,{0} =  {1} ", PadronARBA.Columnas.Alicuota.ToString(), Alicuota).AppendLine()
         .AppendFormat("      ,{0} =  {1} ", PadronARBA.Columnas.Grupo.ToString(), Grupo).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", PadronARBA.Columnas.IdPadronARBA.ToString(), IdPadronARBA)
         .AppendFormat("   AND {0} =  {1} ", PadronARBA.Columnas.PeriodoInformado.ToString(), PeriodoInformado).AppendLine()
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub PadronARBA_U(ByVal PeriodoInformadoWhere As Integer,
                           ByVal PeriodoInformadoSet As Integer)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendFormat("UPDATE {0}.dbo.PadronARBA SET", Me.DataBase)
         .AppendFormat("       {0} = '{1}'", PadronARBA.Columnas.PeriodoInformado.ToString(), PeriodoInformadoSet).AppendLine()
         '.AppendFormat(" WHERE {0} =  {1} ", PadronARBA.Columnas.IdRegimen.ToString(), IdRegimen).AppendLine()
         '.AppendFormat("   AND {0} =  {1} ", RegimenExcepcion.Columnas.IdRegimenExcepcion.ToString(), IdRegimenExcepcion)
         .AppendFormat(" WHERE {0} =  {1} ", PadronARBA.Columnas.PeriodoInformado.ToString(), PeriodoInformadoWhere).AppendLine()
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub PadronARBA_D(ByVal IdPadronARBA As Long?, ByVal PeriodoInformado As Integer?)
      PadronARBA_D(IdPadronARBA, PeriodoInformado, "EQ")
   End Sub
   Public Sub PadronARBA_D(ByVal IdPadronARBA As Long?, ByVal PeriodoInformado As Integer?, condicionPeriodo As String)
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendFormat("DELETE FROM {0}.dbo.PadronARBA WHERE 1 = 1", Me.DataBase)
         If IdPadronARBA.HasValue Then
            .AppendFormat(" AND {0} = {1}", PadronARBA.Columnas.IdPadronARBA.ToString(), IdPadronARBA.Value)
         End If
         If PeriodoInformado.HasValue Then
            If condicionPeriodo = "EQ" Then
               .AppendFormat(" AND {0} = {1}", PadronARBA.Columnas.PeriodoInformado.ToString(), PeriodoInformado.Value)
            ElseIf condicionPeriodo = "LE" Then
               .AppendFormat(" AND {0} <= {1}", PadronARBA.Columnas.PeriodoInformado.ToString(), PeriodoInformado.Value)
            End If
         End If
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub PadronARBA_D_temp()
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendFormat("TRUNCATE TABLE {0}.dbo.PadronARBA_temp", Me.DataBase)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub PadronARBA_Bulk(archivo As String)
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendFormat("BULK INSERT {0}.dbo.PadronARBA_Temp ", Me.DataBase)
         .AppendFormat(" FROM '{0}' WITH (FIELDTERMINATOR =';',ROWTERMINATOR =';\n')", archivo)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub PadronARBA_ProcesarinfoARBA(periodo As Integer)
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendFormat("EXECUTE {0}.dbo.ProcesarInfoARBA @PeridodoInformado", Me.DataBase)
      End With

      Me._da.Command.CommandText = stb.ToString()
      Me._da.Command.CommandType = CommandType.Text
      Dim oParameter As Data.Common.DbParameter = Me._da.Command.CreateParameter()
      oParameter.ParameterName = "@PeridodoInformado"
      oParameter.DbType = DbType.Int32
      oParameter.Value = periodo
      Me._da.Command.Parameters.Add(oParameter)
      Me._da.Command.Connection = Me._da.Connection
      Me._da.ExecuteNonQuery(Me._da.Command)
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT {0}.{1}, {0}.{2}, {0}.{3}, {0}.{4}, {0}.{5}, {0}.{6}, {0}.{7}, {0}.{8}, {0}.{9}, {0}.{10}, {0}.{11}, {0}.{12}", "RE",
                       PadronARBA.Columnas.IdPadronARBA.ToString(),
                       PadronARBA.Columnas.PeriodoInformado.ToString(),
                       PadronARBA.Columnas.TipoRegimen.ToString(),
                       PadronARBA.Columnas.FechaPublicacion.ToString(),
                       PadronARBA.Columnas.FechaVigenciaDesde.ToString(),
                       PadronARBA.Columnas.FechaVigenciaHasta.ToString(),
                       PadronARBA.Columnas.CUIT.ToString(),
                       PadronARBA.Columnas.TipoContribuyente.ToString(),
                       PadronARBA.Columnas.AccionARBA.ToString(),
                       PadronARBA.Columnas.CambioAlicuota.ToString(),
                       PadronARBA.Columnas.Alicuota.ToString(),
                       PadronARBA.Columnas.Grupo.ToString()).AppendLine()
         .AppendFormat("  FROM {1}.dbo.PadronARBA AS {0} ", "RE", Me.DataBase).AppendLine()
      End With
   End Sub

   Public Function GetPadronARBAxCliente(ByVal CUIT As Long, PeriodoInformado As Integer, Regimen As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE CUIT = " & CUIT.ToString())
         If PeriodoInformado > 0 Then
            .AppendLine(" AND PeriodoInformado = " & PeriodoInformado.ToString())
         End If
         If Not String.IsNullOrEmpty(Regimen) Then
            .AppendLine(" AND TipoRegimen = '" & Regimen & "'")
         End If
         stb.AppendFormat(" ORDER BY {0}.{1}, {0}.{2}", "RE",
                          PadronARBA.Columnas.PeriodoInformado.ToString(),
                          PadronARBA.Columnas.CUIT.ToString())
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function


   Public Function PadronARBA_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         Me.SelectTexto(stb)
         stb.AppendFormat(" ORDER BY {0}.{1}, {0}.{2}", "RE",
                          PadronARBA.Columnas.PeriodoInformado.ToString(),
                          PadronARBA.Columnas.CUIT.ToString())
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function PadronARBA_G1(ByVal CUIT As Long, ByVal PeriodoInformado As Integer, tipoRegimen As PadronARBA.TipoRegimenEnum) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE {0}.{1} = {2} AND {0}.{3} = {4}", "RE",
                       PadronARBA.Columnas.CUIT.ToString(), CUIT,
                       PadronARBA.Columnas.PeriodoInformado.ToString(), PeriodoInformado)
         If Not String.IsNullOrWhiteSpace(PadronARBA.TipoRegimenToString(tipoRegimen)) Then
            .AppendFormat(" AND {0}.{1} = '{2}'", "RE",
                          PadronARBA.Columnas.TipoRegimen.ToString(), PadronARBA.TipoRegimenToString(tipoRegimen))
         End If
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function PadronARBA_Existe(CUIT As Long?,
                                     PeriodoInformado As Integer?,
                                     tipoRegimen As PadronARBA.TipoRegimenEnum?) As Boolean
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .AppendFormat("SELECT TOP 1 * FROM {0}.dbo.PadronARBA AS RE", Me.DataBase)
         .AppendLine(" WHERE 1 = 1")
         If CUIT.HasValue Then
            .AppendFormat("   AND RE.{0} = {1}", PadronARBA.Columnas.CUIT.ToString(), CUIT.Value)
         End If
         If PeriodoInformado.HasValue Then
            .AppendFormat("   AND RE.{0} = {1}", PadronARBA.Columnas.PeriodoInformado.ToString(), PeriodoInformado.Value)
         End If
         If tipoRegimen.HasValue Then
            If Not String.IsNullOrWhiteSpace(PadronARBA.TipoRegimenToString(tipoRegimen.Value)) Then
               .AppendFormat(" AND RE.{0} = '{1}'", "RE", PadronARBA.Columnas.TipoRegimen.ToString(), PadronARBA.TipoRegimenToString(tipoRegimen.Value))
            End If
         End If
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      Return dt.Rows.Count > 0
   End Function

   Public Function PadronARBA_Count(ByVal CUIT As Long?,
                                    ByVal PeriodoInformado As Integer?,
                                    tipoRegimen As PadronARBA.TipoRegimenEnum?) As Long
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         ''Me.SelectTexto(stb)

         .AppendFormat("SELECT COUNT(1) as Cantidad FROM {0}.dbo.PadronARBA AS RE", Me.DataBase)
         .AppendLine(" WHERE 1 = 1")
         If CUIT.HasValue Then
            .AppendFormat("   AND RE.{0} = {1}", PadronARBA.Columnas.CUIT.ToString(), CUIT.Value)
         End If

         If PeriodoInformado.HasValue Then
            .AppendFormat("   AND RE.{0} = {1}", PadronARBA.Columnas.PeriodoInformado.ToString(), PeriodoInformado.Value)
         End If

         If tipoRegimen.HasValue Then
            If Not String.IsNullOrWhiteSpace(PadronARBA.TipoRegimenToString(tipoRegimen.Value)) Then
               .AppendFormat(" AND RE.{0} = '{1}'", "RE", PadronARBA.Columnas.TipoRegimen.ToString(), PadronARBA.TipoRegimenToString(tipoRegimen.Value))
            End If
         End If
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      Dim result As Long = 0
      If dt.Rows.Count > 0 AndAlso dt.Columns.Contains("Cantidad") AndAlso IsNumeric(dt.Rows(0)("Cantidad")) Then
         result = CLng(dt.Rows(0)("Cantidad"))
      End If
      Return result
   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "RE." + columna

      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat("  WHERE {0} LIKE '%{1}%'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo(PeriodoInformado As Integer) As Long
      Dim stb As StringBuilder = New StringBuilder("")
      Dim result As Long = 0
      Dim maximo As String = "maximo"
      With stb
         stb.AppendFormat("SELECT ISNULL(MAX({0}.{3}), 0) AS {4} FROM {5}.dbo.PadronARBA AS {0} WHERE {0}.{1} = {2}",
                          "RE",
                          PadronARBA.Columnas.PeriodoInformado.ToString(), PeriodoInformado,
                          PadronARBA.Columnas.IdPadronARBA.ToString(),
                          maximo,
                          Me.DataBase)

         Dim dt As DataTable = GetDataTable(.ToString())
         If dt IsNot Nothing AndAlso dt.Rows.Count > 0 AndAlso dt.Columns.Contains(maximo) Then
            Long.TryParse(dt.Rows(0)(maximo).ToString(), result)
         End If
      End With

      Return result
   End Function

End Class
