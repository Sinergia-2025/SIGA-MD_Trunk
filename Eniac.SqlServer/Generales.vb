Public Class Generales
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub BackupEn(ByVal base As String, ByVal path As String)
      Dim myQuery As StringBuilder = New StringBuilder("")
      If String.IsNullOrEmpty(path) Then
         path = Entidades.Publicos.DriverBase
      End If

      With myQuery
         .Append(" BACKUP DATABASE ")
         .Append(base)
         .Append(" TO DISK= N'")
         .Append(path)
         .Append("' with INIT")
         .Append(" , COPY_ONLY, NOFORMAT, NAME =  N'test-Full Database Backup', SKIP, NOREWIND, NOUNLOAD")
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub RetoreEn(ByVal nombreBase As String, ByVal path As String)
      Dim myQuery As StringBuilder = New StringBuilder("")
      If String.IsNullOrEmpty(path) Then
         path = Entidades.Publicos.DriverBase
      End If

      With myQuery
         .Append("ALTER DATABASE ")
         .Append(nombreBase)
         .Append(" SET SINGLE_USER WITH ROLLBACK IMMEDIATE")
      End With

      Me.Execute(myQuery.ToString())

      With myQuery
         .Length = 0
         .Append(" RESTORE DATABASE ")
         .Append(nombreBase)
         .Append(" FROM  DISK = N'")
         .Append(path)
         .Append("'")
      End With

      Me.Execute(myQuery.ToString())

      With myQuery
         .Append("ALTER DATABASE ")
         .Append(nombreBase)
         .Append(" SET MULTI_USER")
      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Function GetTamanoDB() As Long
      Dim dt As DataTable = Me.GetDataTable("sp_spaceused")
      Dim val As Decimal = Decimal.Parse(dt.Rows(0)("database_size").ToString().Replace("MB", ""))
      val = val * 1000
      Return Decimal.ToInt64(val)
   End Function

   Public Function GetDBs() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append(" SELECT name FROM master.sys.databases ")
         '.Append(" WHERE name NOT IN ('master', 'model', 'tempdb', 'msdb', 'SIGA')")
         .Append(" WHERE name LIKE 'SIGA%'")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetTotasLasDBs(ByVal filtroNombre As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append(" SELECT name FROM master.sys.databases ")
         .AppendFormat(" WHERE name LIKE '{0}%'", filtroNombre)
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetServerDBFechaHora() As DateTime
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append(" Select GETDATE() AS FechaHora ")
      End With
      Dim dt As DataTable = Me.GetDataTable(myQuery.ToString())
      My.Application.Log.WriteEntry("Generales - GetServerDBFechaHora - Dato=" + dt.Rows(0)("FechaHora").ToString(), TraceEventType.Verbose)
      Return DateTime.Parse(dt.Rows(0)("FechaHora").ToString())

   End Function

   Public Function GetMotorDB() As String
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .Append("Select @@version as motor")
      End With
      Return Me.GetDataTable(stb.ToString()).Rows(0)("motor").ToString()
   End Function

   Public Function GetMotorVersion() As String
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .Append("SELECT SERVERPROPERTY('productversion') as version")
      End With
      Return Me.GetDataTable(stb.ToString()).Rows(0)("version").ToString()
   End Function

   Public Function ExisteTabla(nombreBase As String, esquema As String, nombreTabla As String) As Boolean
      If Not String.IsNullOrWhiteSpace(nombreBase) Then
         nombreBase = String.Concat(nombreBase.Trim("."c), ".")
      End If
      If String.IsNullOrWhiteSpace(esquema) Then
         esquema = "dbo"
      End If
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT *")
         .AppendFormatLine("  FROM {0}INFORMATION_SCHEMA.TABLES", nombreBase)
         .AppendFormatLine(" WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME = '{1}'", esquema, nombreTabla)

      End With

      Return GetDataTable(stb.ToString()).Rows.Count > 0
   End Function

End Class