Public Class Calles
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Calles"
      da = New Eniac.Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "Calles"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Entidades.Entidad)
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

   Public Overrides Sub Borrar(ByVal entidad As Entidades.Entidad)
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

   Public Overrides Sub Actualizar(ByVal entidad As Entidades.Entidad)
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

   Public Overrides Function Buscar(ByVal entidad As Entidades.Buscar) As DataTable
      Dim sql As SqlServer.Calles = New SqlServer.Calles(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Calles(Me.da).Calles_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.Calle = DirectCast(entidad, Entidades.Calle)

      Dim sql As SqlServer.Calles = New SqlServer.Calles(Me.da)
      Dim rClientes As Clientes = New Clientes(da)
      Select Case tipo
         Case TipoSP._I
            sql.Calles_I(en.IdCalle, en.NombreCalle, en.Localidad.IdLocalidad)
         Case TipoSP._U
            Dim preCalle As Entidades.Calle = _GetUna(en.IdCalle)
            sql.Calles_U(en.IdCalle, en.NombreCalle, en.Localidad.IdLocalidad)
            If preCalle.NombreCalle <> en.NombreCalle Then
               rClientes.ActualizaCampoDireccion(en.IdCalle)
            End If
         Case TipoSP._D
            sql.Calles_D(en.IdCalle)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.Calle, ByVal dr As DataRow)
      With o
         .IdCalle = Int32.Parse(dr("IdCalle").ToString())
         If Not String.IsNullOrEmpty(dr("NombreCalle").ToString()) Then
            .NombreCalle = dr("NombreCalle").ToString()
         End If
         .Localidad = New Eniac.Reglas.Localidades(Me.da).GetUna(Int32.Parse(dr("IdLocalidad").ToString()))
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodas() As List(Of Entidades.Calle)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.Calle
      Dim oLis As List(Of Entidades.Calle) = New List(Of Entidades.Calle)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.Calle()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetPorLocalidad(ByVal idLocalidad As Integer) As List(Of Entidades.Calle)
      Dim sql As SqlServer.Calles = New SqlServer.Calles(Me.da)
      Dim dt As DataTable = sql.GetPorLocalidad(idLocalidad)
      Dim o As Entidades.Calle
      Dim oLis As List(Of Entidades.Calle) = New List(Of Entidades.Calle)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.Calle()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetPorLocalidadYNombre(ByVal idLocalidad As Int32, ByVal nombreCalle As String) As DataTable
      Return New SqlServer.Calles(Me.da).GetPorLocalidadYNombre(idLocalidad, nombreCalle)
   End Function

   Public Function GetPorId(ByVal idCalle As Int32) As DataTable
      Return New SqlServer.Calles(Me.da).GetPorId(idCalle)
   End Function

    Public Function GetPorNombre(ByVal nombreCalle As String) As DataTable
        Return New SqlServer.Calles(Me.da).GetPorNombre(nombreCalle)
    End Function

   Public Function GetUna(ByVal idCalle As Integer) As Entidades.Calle
      Try
         Me.da.OpenConection()
         Return Me._GetUna(idCalle)
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function _GetUna(ByVal idCalle As Integer) As Entidades.Calle
      Dim sql As SqlServer.Calles = New SqlServer.Calles(Me.da)

      Dim dt As DataTable = sql.Calles_G1(idCalle)

      Dim o As Entidades.Calle = New Entidades.Calle()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe la Calle.")
      End If
      Return o
   End Function

   Public Function GetCodigoMaximo() As Integer
      Dim sql As SqlServer.Calles = New SqlServer.Calles(Me.da)
      Return sql.GetCodigoMaximo()
   End Function

#End Region

End Class

