Public Class ClientesHistorias
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ClientesHistorias"
      da = New Eniac.Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.New()
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
      Dim sql As SqlServer.ClientesHistorias = New SqlServer.ClientesHistorias(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ClientesHistorias(Me.da).ClientesHistorias_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.ClienteHistoria = DirectCast(entidad, Entidades.ClienteHistoria)

      Dim sql As SqlServer.ClientesHistorias = New SqlServer.ClientesHistorias(Me.da)
      Select Case tipo
         Case TipoSP._I
            sql.ClientesHistorias_I(en.Cliente.IdCliente, en.FechaHoraItem, en.Item, en.Usuario)
         Case TipoSP._U
            sql.ClientesHistorias_U()
         Case TipoSP._D
            sql.ClientesHistorias_D(en.Cliente.IdCliente, en.FechaHoraItem)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.ClienteHistoria, ByVal dr As DataRow)
      With o
         o.Cliente = New Reglas.Clientes(Me.da).GetUno(Long.Parse(dr("IdCliente").ToString()), False)
         o.Usuario = dr("Usuario").ToString()
         o.Item = dr("Item").ToString()
         o.FechaHoraItem = DateTime.Parse(dr("FechaHoraItem").ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.ClienteHistoria)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.ClienteHistoria
      Dim oLis As List(Of Entidades.ClienteHistoria) = New List(Of Entidades.ClienteHistoria)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ClienteHistoria()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUno(ByVal id As Integer) As Entidades.ClienteHistoria
      Dim sql As SqlServer.ClientesHistorias = New SqlServer.ClientesHistorias(Me.da)

      Dim dt As DataTable = sql.ClientesHistorias_G1(id)

      Dim o As Entidades.ClienteHistoria = New Entidades.ClienteHistoria()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe el Registro.")
      End If
      Return o
   End Function

   Public Function GetHistorialDeUnCliente(ByVal IdCliente As Long) As List(Of Entidades.ClienteHistoria)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.ClientesHistorias = New SqlServer.ClientesHistorias(Me.da)

         Dim dt As DataTable = sql.GetHistorialDeUnCliente(IdCliente)
         Dim o As Entidades.ClienteHistoria
         Dim oLis As List(Of Entidades.ClienteHistoria) = New List(Of Entidades.ClienteHistoria)
         For Each dr As DataRow In dt.Rows
            o = New Entidades.ClienteHistoria()
            o.Cliente = New Reglas.Clientes().GetUno(IdCliente)
            o.Usuario = dr("Usuario").ToString()
            o.Item = dr("Item").ToString()
            o.FechaHoraItem = DateTime.Parse(dr("FechaHoraItem").ToString())
            oLis.Add(o)
         Next

         Me.da.CommitTransaction()

         Return oLis

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

#End Region

End Class
