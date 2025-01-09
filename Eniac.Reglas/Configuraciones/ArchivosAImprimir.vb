Public Class ArchivosAImprimir
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ArchivosAImprimir"
      da = New Eniac.Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "ArchivosAImprimir"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._I)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._D)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._U)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.ArchivosAImprimir = New SqlServer.ArchivosAImprimir(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ArchivosAImprimir(Me.da).ArchivosAImprimir_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.ArchivoAImprimir = DirectCast(entidad, Entidades.ArchivoAImprimir)

      Dim sql As SqlServer.ArchivosAImprimir = New SqlServer.ArchivosAImprimir(Me.da)

      Select Case tipo
         Case TipoSP._I
            sql.ArchivosAImprimir_I(en.IdSucursal, en.NombreReporteOriginal, en.ReporteSecundario)
         Case TipoSP._U
            sql.ArchivosAImprimir_U(en.IdSucursal, en.NombreReporteOriginal, en.ReporteSecundario)
         Case TipoSP._D
            sql.ArchivosAImprimir_D(en.IdSucursal, en.NombreReporteOriginal)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.ArchivoAImprimir, ByVal dr As DataRow)
      With o
         .IdSucursal = Int32.Parse(dr(Entidades.ArchivoAImprimir.Columnas.IdSucursal.ToString()).ToString())
         .NombreReporteOriginal = dr(Entidades.ArchivoAImprimir.Columnas.NombreReporteOriginal.ToString()).ToString()
         .ReporteSecundario = dr(Entidades.ArchivoAImprimir.Columnas.ReporteSecundario.ToString()).ToString()
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.ArchivoAImprimir)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim dt As DataTable = Me.GetAll()
         Dim o As Entidades.ArchivoAImprimir
         Dim oLis As List(Of Entidades.ArchivoAImprimir) = New List(Of Entidades.ArchivoAImprimir)
         For Each dr As DataRow In dt.Rows
            o = New Entidades.ArchivoAImprimir()
            Me.CargarUno(o, dr)
            oLis.Add(o)
         Next

         Me.da.CommitTransaction()
         Return oLis

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetUno(ByVal idSucursal As Integer, ByVal nombreReporteOriginal As String) As Entidades.ArchivoAImprimir
      Try
         Me.da.OpenConection()

         Return Me._GetUno(idSucursal, nombreReporteOriginal)

      Catch ex As Exception
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Friend Function _GetUno(ByVal idSucursal As Integer, ByVal nombreReporteOriginal As String) As Entidades.ArchivoAImprimir

      Dim sql As SqlServer.ArchivosAImprimir = New SqlServer.ArchivosAImprimir(Me.da)

      Dim dt As DataTable = sql.ArchivosAImprimir_G1(idSucursal, nombreReporteOriginal)

      Dim o As Entidades.ArchivoAImprimir = New Entidades.ArchivoAImprimir()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      End If

      Return o

   End Function

#End Region



End Class
