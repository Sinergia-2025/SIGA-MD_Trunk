Option Strict On
Option Explicit On
Public Class EstadosVenta
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.EstadoVenta.NombreTabla
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
      Dim sql As SqlServer.EstadosVenta = New SqlServer.EstadosVenta(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.EstadosVenta(Me.da).EstadosVenta_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.EstadoVenta = DirectCast(entidad, Entidades.EstadoVenta)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.EstadosVenta = New SqlServer.EstadosVenta(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.EstadosVenta_I(en.IdEstadoVenta, en.NombreEstadoVenta, en.IdTipoMovimiento)
            Case TipoSP._U
               sqlC.EstadosVenta_U(en.IdEstadoVenta, en.NombreEstadoVenta, en.IdTipoMovimiento)
            Case TipoSP._D
               sqlC.EstadosVenta_D(en.IdEstadoVenta)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.EstadoVenta, ByVal dr As DataRow)
      With o
         .IdEstadoVenta = Integer.Parse(dr(Entidades.EstadoVenta.Columnas.IdEstadoVenta.ToString()).ToString())
         .NombreEstadoVenta = dr(Entidades.EstadoVenta.Columnas.NombreEstadoVenta.ToString()).ToString()
         .IdTipoMovimiento = dr(Entidades.EstadoVenta.Columnas.IdTipoMovimiento.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idEstadoVenta As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.EstadoVenta
      Return CargaEntidad(New SqlServer.EstadosVenta(Me.da).EstadosVenta_G1(idEstadoVenta),
                      Sub(o, dr) CargarUno(o, dr), Function() New Entidades.EstadoVenta(),
                      accion, String.Format("No existe un estado de venta con id: {0}", idEstadoVenta))
   End Function

   Public Function GetTodos() As List(Of Entidades.EstadoVenta)
      Return CargaLista(New SqlServer.EstadosVenta(Me.da).EstadosVenta_GA(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.EstadoVenta())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.EstadosVenta(Me.da).GetCodigoMaximo()
   End Function

#End Region

End Class