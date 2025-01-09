#Region "Imports"

Imports System.Text

#End Region

Public Class Generales
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = ""
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = ""
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub BackupEn(ByVal gene As Entidades.General)
      Try
         da.OpenConection()

         Dim sql As SqlServer.Generales = New SqlServer.Generales(Me.da)
         sql.BackupEn(gene.Base, gene.Path)

      Catch ex As Exception
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub BackupEnSegu(ByVal gene As Entidades.General)
      Try
         da.OpenConection(CadenaSegura)

         Dim sql As SqlServer.Generales = New SqlServer.Generales(Me.da)
         sql.BackupEn(gene.Base, gene.Path)

      Catch ex As Exception
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Sub RestoreEn(ByVal gene As Entidades.General)
      Try
         Me.da.OpenConection(CadenaMaster)

         Dim sql As SqlServer.Generales = New SqlServer.Generales(Me.da)
         sql.RetoreEn(gene.Base, gene.Path)

      Catch ex As Exception
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try
   End Sub

   Public Sub RestoreEnSegu(ByVal gene As Entidades.General)
      Try
         da.OpenConection(CadenaMaster)

         Dim sql As SqlServer.Generales = New SqlServer.Generales(Me.da)
         sql.RetoreEn(gene.Base, gene.Path)

      Catch ex As Exception
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Function GetDBs() As DataTable
      Try
         Me.da.OpenConection(CadenaMaster)

         Dim sql As SqlServer.Generales = New SqlServer.Generales(Me.da)
         Return sql.GetDBs()

      Catch ex As Exception
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetTotasLasDBs(ByVal filtroNombre As String) As DataTable
      Try
         Me.da.OpenConection(CadenaMaster)

         Dim sql As SqlServer.Generales = New SqlServer.Generales(Me.da)
         Return sql.GetTotasLasDBs(filtroNombre)

      Catch ex As Exception
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Sub EjecutarQuery(ByVal query As String)
      Try
         da.OpenConection()

         da.Command.Connection = da.Connection
         da.Command.Transaction = da.Transaction
         da.Command.CommandTimeout = 120
         da.Command.CommandText = query
         da.Command.CommandType = CommandType.Text

         da.Command.ExecuteNonQuery()

      Catch ex As Exception
         Throw ex
      Finally
         da.CloseConection()
      End Try
    End Sub

   Public Sub EjecutarQuerys(ByVal querys As SortedList(Of Integer, String))
      Dim i As Integer = 0
      Dim sc As String = String.Empty
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Me.da.Command.Connection = da.Connection
         Me.da.Command.Transaction = da.Transaction
         Me.da.Command.CommandTimeout = 120


         For Each sc In querys.Values
            i += 1
            Me.da.Command.CommandText = sc
            Me.da.Command.CommandType = CommandType.Text
            Me.da.Command.ExecuteNonQuery()
         Next

         Me.da.CommitTransaction()

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Dim ex1 As Exception
         ex1 = New Exception(String.Format("Fallo el Script Nro. {0} que comienza con {1}.", i, sc.Truncar(10)), ex)
         Throw ex1
      Finally
         Me.da.CloseConection()
      End Try
   End Sub

   Public Function GetTamanoDB() As Long
      Try
         Me.da.OpenConection()

         Dim sql As SqlServer.Generales = New SqlServer.Generales(Me.da)
         Return sql.GetTamanoDB()
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetServerDBFechaHora() As DateTime
      Try
         Me.da.OpenConection()

         Return Me._GetServerDBFechaHora()

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function _GetServerDBFechaHora() As DateTime
      Dim sql As SqlServer.Generales = New SqlServer.Generales(Me.da)
      Return sql.GetServerDBFechaHora()
   End Function


   Public Function GetMotorDB() As String

      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.Generales = New SqlServer.Generales(Me.da)
         Return sql.GetMotorDB()
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetMotorVersion() As String

      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.Generales = New SqlServer.Generales(Me.da)
         Return sql.GetMotorVersion()
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function


   Public Function ExisteTabla(nombreTabla As String) As Boolean
      Return ExisteTabla(String.Empty, String.Empty, nombreTabla)
   End Function
   Public Function ExisteTabla(nombreBase As String, esquema As String, nombreTabla As String) As Boolean
      Return New SqlServer.Generales(da).ExisteTabla(nombreBase, esquema, nombreTabla)
   End Function

#End Region

End Class