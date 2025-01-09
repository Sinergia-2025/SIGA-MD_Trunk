Public Class SueldosMotivosBaja
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "SueldosMotivosBaja"
      da = New Eniac.Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "SueldosMotivosBaja"
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
      Dim sql As SqlServer.SueldosMotivosBaja = New SqlServer.SueldosMotivosBaja(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.SueldosMotivosBaja(Me.da).SueldosMotivosBaja_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.SueldosMotivoBaja = DirectCast(entidad, Entidades.SueldosMotivoBaja)

      Dim sql As SqlServer.SueldosMotivosBaja = New SqlServer.SueldosMotivosBaja(Me.da)

      Select Case tipo
         Case TipoSP._I
            sql.SueldosMotivosBaja_I(en.IdMotivoBaja, en.NombreMotivoBaja)
         Case TipoSP._U
            sql.SueldosMotivosBaja_U(en.IdMotivoBaja, en.NombreMotivoBaja)
         Case TipoSP._D
            sql.SueldosMotivosBaja_D(en.IdMotivoBaja)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.SueldosMotivoBaja, ByVal dr As DataRow)
      With o
         .IdMotivoBaja = Int32.Parse(dr(Entidades.SueldosMotivoBaja.Columnas.IdMotivoBaja.ToString()).ToString())
         .NombreMotivoBaja = dr(Entidades.SueldosMotivoBaja.Columnas.NombreMotivoBaja.ToString()).ToString()
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.SueldosMotivoBaja)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim dt As DataTable = Me.GetAll()
         Dim o As Entidades.SueldosMotivoBaja
         Dim oLis As List(Of Entidades.SueldosMotivoBaja) = New List(Of Entidades.SueldosMotivoBaja)
         For Each dr As DataRow In dt.Rows
            o = New Entidades.SueldosMotivoBaja()
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

   Public Function GetUno(ByVal idMotivoBaja As Integer) As Entidades.SueldosMotivoBaja
      Try
         Me.da.OpenConection()

         Return Me._GetUno(idMotivoBaja)

      Catch ex As Exception
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetCodigoMaximo() As Long
      Return New SqlServer.SueldosMotivosBaja(Me.da).GetCodigoMaximo()
   End Function

   Friend Function _GetUno(ByVal idMotivoBaja As Integer) As Entidades.SueldosMotivoBaja

      Dim sql As SqlServer.SueldosMotivosBaja = New SqlServer.SueldosMotivosBaja(Me.da)

      Dim dt As DataTable = sql.SueldosMotivosBaja_G1(idMotivoBaja)

      Dim o As Entidades.SueldosMotivoBaja = New Entidades.SueldosMotivoBaja()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe la SueldosMotivoBaja.")
      End If

      Return o

   End Function

#End Region



End Class
