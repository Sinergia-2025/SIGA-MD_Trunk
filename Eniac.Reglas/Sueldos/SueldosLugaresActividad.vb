Public Class SueldosLugaresActividad
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "SueldosLugaresActividad"
      da = New Eniac.Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "SueldosLugaresActividad"
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
      Dim sql As SqlServer.SueldosLugaresActividad = New SqlServer.SueldosLugaresActividad(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.SueldosLugaresActividad(Me.da).SueldosLugaresActividad_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.SueldosLugarActividad = DirectCast(entidad, Entidades.SueldosLugarActividad)

      Dim sql As SqlServer.SueldosLugaresActividad = New SqlServer.SueldosLugaresActividad(Me.da)

      Select Case tipo
         Case TipoSP._I
            sql.SueldosLugaresActividad_I(en.IdLugarActividad, en.NombreLugarActividad)
         Case TipoSP._U
            sql.SueldosLugaresActividad_U(en.IdLugarActividad, en.NombreLugarActividad)
         Case TipoSP._D
            sql.SueldosLugaresActividad_D(en.IdLugarActividad)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.SueldosLugarActividad, ByVal dr As DataRow)
      With o
         .IdLugarActividad = Int32.Parse(dr(Entidades.SueldosLugarActividad.Columnas.IdLugarActividad.ToString()).ToString())
         .NombreLugarActividad = dr(Entidades.SueldosLugarActividad.Columnas.NombreLugarActividad.ToString()).ToString()
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.SueldosLugarActividad)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim dt As DataTable = Me.GetAll()
         Dim o As Entidades.SueldosLugarActividad
         Dim oLis As List(Of Entidades.SueldosLugarActividad) = New List(Of Entidades.SueldosLugarActividad)
         For Each dr As DataRow In dt.Rows
            o = New Entidades.SueldosLugarActividad()
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

   Public Function GetUno(ByVal id As Integer) As Entidades.SueldosLugarActividad
      Try
         Me.da.OpenConection()

         Return Me._GetUno(id)

      Catch ex As Exception
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Friend Function _GetUno(ByVal id As Integer) As Entidades.SueldosLugarActividad

      Dim sql As SqlServer.SueldosLugaresActividad = New SqlServer.SueldosLugaresActividad(Me.da)

      Dim dt As DataTable = sql.SueldosLugaresActividad_G1(id)

      Dim o As Entidades.SueldosLugarActividad = New Entidades.SueldosLugarActividad()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe la SueldosLugarActividad.")
      End If

      Return o

   End Function

   Public Function GetCodigoMaximo() As Long
      Return New SqlServer.SueldosLugaresActividad(Me.da).GetCodigoMaximo()
   End Function

#End Region

End Class
