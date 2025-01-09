Public Class ProduccionProcesos
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ProduccionProcesos"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ProduccionProcesos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.ProduccionProcesos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ProduccionProcesos(da).ProduccionProcesos_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.ProduccionProceso = DirectCast(entidad, Entidades.ProduccionProceso)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.ProduccionProcesos = New SqlServer.ProduccionProcesos(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.ProduccionProcesos_I(en.IdProduccionProceso, en.NombreProduccionProceso)
            Case TipoSP._U
               sqlC.ProduccionProcesos_U(en.IdProduccionProceso, en.NombreProduccionProceso)
            Case TipoSP._D
               sqlC.ProduccionProcesos_D(en.IdProduccionProceso)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.ProduccionProceso, ByVal dr As DataRow)
      With o
         .IdProduccionProceso = Integer.Parse(dr(Entidades.ProduccionProceso.Columnas.IdProduccionProceso.ToString()).ToString())
         .NombreProduccionProceso = dr(Entidades.ProduccionProceso.Columnas.NombreProduccionProceso.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idEstadoNovedad As Integer) As Entidades.ProduccionProceso
      Return GetUno(idEstadoNovedad, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idEstadoNovedad As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.ProduccionProceso
      Return CargaEntidad(New SqlServer.ProduccionProcesos(da).ProduccionProcesos_G1(idEstadoNovedad),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProduccionProceso(),
                          accion, String.Format("No existe Proceso de Producción con Id {0}", idEstadoNovedad))
   End Function

   Public Function GetTodos() As List(Of Entidades.ProduccionProceso)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.ProduccionProceso
      Dim oLis As List(Of Entidades.ProduccionProceso) = New List(Of Entidades.ProduccionProceso)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ProduccionProceso()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.ProduccionProcesos(da).GetCodigoMaximo()
   End Function

#End Region
End Class