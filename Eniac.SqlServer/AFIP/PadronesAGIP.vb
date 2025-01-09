Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class PadronesAGIP
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

   Public Sub PadronAGIP_U(ByVal PeriodoInformadoWhere As Integer,
                           ByVal PeriodoInformadoSet As Integer)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendFormat("UPDATE {0}.dbo.PadronAGIP SET", Me.DataBase)
         .AppendFormat("       {0} = '{1}'", PadronAGIP.Columnas.PeriodoInformado.ToString(), PeriodoInformadoSet).AppendLine()
         '.AppendFormat(" WHERE {0} =  {1} ", PadronAGIP.Columnas.IdRegimen.ToString(), IdRegimen).AppendLine()
         '.AppendFormat("   AND {0} =  {1} ", RegimenExcepcion.Columnas.IdRegimenExcepcion.ToString(), IdRegimenExcepcion)
         .AppendFormat(" WHERE {0} =  {1} ", PadronAGIP.Columnas.PeriodoInformado.ToString(), PeriodoInformadoWhere).AppendLine()
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub PadronAGIP_D(ByVal IdPadronAGIP As Long?, ByVal PeriodoInformado As Integer?)
      PadronAGIP_D(IdPadronAGIP, PeriodoInformado, "EQ")
   End Sub
   Public Sub PadronAGIP_D(ByVal IdPadronAGIP As Long?, ByVal PeriodoInformado As Integer?, condicionPeriodo As String)
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendFormat("DELETE FROM {0}.dbo.PadronAGIP WHERE 1 = 1", Me.DataBase)
         If IdPadronAGIP.HasValue Then
            .AppendFormat(" AND {0} = {1}", PadronAGIP.Columnas.IdPadronAGIP.ToString(), IdPadronAGIP.Value)
         End If
         If PeriodoInformado.HasValue Then
            If condicionPeriodo = "EQ" Then
               .AppendFormat(" AND {0} = {1}", PadronAGIP.Columnas.PeriodoInformado.ToString(), PeriodoInformado.Value)
            ElseIf condicionPeriodo = "LE" Then
               .AppendFormat(" AND {0} <= {1}", PadronAGIP.Columnas.PeriodoInformado.ToString(), PeriodoInformado.Value)
            End If
         End If
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub PadronAGIP_D_temp()
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendFormat("TRUNCATE TABLE {0}.dbo.PadronAGIP_temp", Me.DataBase)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub PadronAGIP_Bulk(archivo As String)
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendFormat("BULK INSERT {0}.dbo.PadronAGIP_Temp ", Me.DataBase)
         .AppendFormat(" FROM '{0}' WITH (FIELDTERMINATOR =';',ROWTERMINATOR ='\n')", archivo)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub PadronAGIP_ProcesarinfoAGIP(periodo As Integer)
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendFormat("EXECUTE {0}.dbo.ProcesarInfoAGIP @PeridodoInformado", Me.DataBase)
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
         .AppendFormat("SELECT RE.{0}, RE.{1}, RE.{2}, RE.{3}, RE.{4}, RE.{5}, RE.{6}, RE.{7}, RE.{8}, RE.{9}, RE.{10}, RE.{11}, RE.{12}, RE.{13}",
                       PadronAGIP.Columnas.PeriodoInformado.ToString(),
                       PadronAGIP.Columnas.IdPadronAGIP.ToString(),
                       PadronAGIP.Columnas.FechaPublicacion.ToString(),
                       PadronAGIP.Columnas.FechaVigenciaDesde.ToString(),
                       PadronAGIP.Columnas.FechaVigenciaHasta.ToString(),
                       PadronAGIP.Columnas.CUIT.ToString(),
                       PadronAGIP.Columnas.TipoContribuyente.ToString(),
                       PadronAGIP.Columnas.MarcaAlta.ToString(),
                       PadronAGIP.Columnas.MarcaAlicuota.ToString(),
                       PadronAGIP.Columnas.AlicuotaPercepcion.ToString(),
                       PadronAGIP.Columnas.AlicuotaRetencion.ToString(),
                       PadronAGIP.Columnas.GrupoPercepcion.ToString(),
                       PadronAGIP.Columnas.GrupoRetencion.ToString(),
                       PadronAGIP.Columnas.RazonSocial.ToString()).AppendLine()
         .AppendFormat("  FROM {0}.dbo.PadronAGIP AS RE ", Me.DataBase).AppendLine()
      End With
   End Sub

   Public Function GetPadronAGIPxCliente(ByVal CUIT As Long, PeriodoInformado As Integer, Regimen As String) As DataTable

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
                          PadronAGIP.Columnas.PeriodoInformado.ToString(),
                          PadronAGIP.Columnas.CUIT.ToString())
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function


   Public Function PadronAGIP_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         Me.SelectTexto(stb)
         stb.AppendFormat(" ORDER BY {0}.{1}, {0}.{2}", "RE",
                          PadronAGIP.Columnas.PeriodoInformado.ToString(),
                          PadronAGIP.Columnas.CUIT.ToString())
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function PadronAGIP_G1(ByVal CUIT As Long, ByVal PeriodoInformado As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE {0}.{1} = {2} AND {0}.{3} = {4}", "RE",
                       PadronAGIP.Columnas.CUIT.ToString(), CUIT,
                       PadronAGIP.Columnas.PeriodoInformado.ToString(), PeriodoInformado)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function PadronAGIP_Existe(CUIT As Long?,
                                     PeriodoInformado As Integer?) As Boolean
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .AppendFormat("SELECT TOP 1 * FROM {0}.dbo.PadronAGIP AS RE", Me.DataBase)
         .AppendLine(" WHERE 1 = 1")
         If CUIT.HasValue Then
            .AppendFormat("   AND RE.{0} = {1}", PadronAGIP.Columnas.CUIT.ToString(), CUIT.Value)
         End If
         If PeriodoInformado.HasValue Then
            .AppendFormat("   AND RE.{0} = {1}", PadronAGIP.Columnas.PeriodoInformado.ToString(), PeriodoInformado.Value)
         End If
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      Return dt.Rows.Count > 0
   End Function
   Public Function PadronAGIP_Count(ByVal CUIT As Long?,
                                    ByVal PeriodoInformado As Integer?) As Long
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         ''Me.SelectTexto(stb)

         .AppendFormat("SELECT COUNT(1) as Cantidad FROM {0}.dbo.PadronAGIP AS RE", Me.DataBase)
         .AppendLine(" WHERE 1 = 1")
         If CUIT.HasValue Then
            .AppendFormat("   AND RE.{0} = {1}", PadronAGIP.Columnas.CUIT.ToString(), CUIT.Value)
         End If

         If PeriodoInformado.HasValue Then
            .AppendFormat("   AND RE.{0} = {1}", PadronAGIP.Columnas.PeriodoInformado.ToString(), PeriodoInformado.Value)
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
         stb.AppendFormat("SELECT ISNULL(MAX({0}.{3}), 0) AS {4} FROM {5}.dbo.PadronAGIP AS {0} WHERE {0}.{1} = {2}",
                          "RE",
                          PadronAGIP.Columnas.PeriodoInformado.ToString(), PeriodoInformado,
                          PadronAGIP.Columnas.IdPadronAGIP.ToString(),
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
