#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Public Class Nodos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.Nodo.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.Nodo)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.Nodo)))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.Nodo)))
   End Sub
   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.Nodos = New SqlServer.Nodos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable ' se aplica la regla para traer todos los registros asociados al cliente
      Return New SqlServer.Nodos(Me.da).Nodos_GA()
   End Function
   'Public Function InfClientesActualizaciones(idCliente As Long, fechaDesde As DateTime?, fechaHasta As DateTime?) As DataTable
   '   Return New SqlServer.ClientesActualizaciones(Me.da).GetInfClientesActualizaciones(idCliente, fechaDesde, fechaHasta)
   'End Function

#End Region

#Region "Metodos Privados"

   Public Sub _Insertar(entidad As Eniac.Entidades.Nodo)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Eniac.Entidades.Nodo)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Merge(entidad As Eniac.Entidades.Nodo)
      Me.EjecutaSP(entidad, TipoSP._M)
   End Sub

   Public Sub _Borrar(entidad As Eniac.Entidades.Nodo)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Private Sub EjecutaSP(en As Entidades.Nodo, tipo As TipoSP)

      Dim sqlC As SqlServer.Nodos = New SqlServer.Nodos(da)
      Select Case tipo
         'Case TipoSP._I
         '   sqlC.ClientesActualizaciones_I(en.IdCliente, en.NombreServidor, en.BaseDatos, en.FechaEjecucion, en.FechaInicioActualizacion, en.FechaFinActualizacion,
         '                                  en.IdUnico,
         '                                  en.Estado, en.EstadoDescargaScripts, en.EstadoDescargaInstalador,
         '                                  en.EstadoBackup, en.EstadoEjecucionScripts, en.EstadoEjecucionInstalador,
         '                                  en.Activo)
         'Case TipoSP._U
         '   sqlC.ClientesActualizaciones_U(en.IdCliente, en.NombreServidor, en.BaseDatos, en.FechaEjecucion, en.FechaInicioActualizacion, en.FechaFinActualizacion,
         '                                  en.IdUnico,
         '                                  en.Estado, en.EstadoDescargaScripts, en.EstadoDescargaInstalador,
         '                                  en.EstadoBackup, en.EstadoEjecucionScripts, en.EstadoEjecucionInstalador,
         '                                  en.Activo)
         Case TipoSP._M
            sqlC.Nodos_M(en.IdNodo, en.NombreNodo)
            'Case TipoSP._D
            '   sqlC.ClientesActualizaciones_D(en.IdCliente, en.NombreServidor, en.BaseDatos, en.FechaEjecucion)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.Nodo, dr As DataRow)
      With o
         .IdNodo = Integer.Parse(dr(Entidades.ClienteActualizacion.Columnas.IdCliente.ToString()).ToString())
         .NombreNodo = dr(Entidades.ClienteActualizacion.Columnas.NombreServidor.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(idNodo As Integer,
                          accion As AccionesSiNoExisteRegistro) As Entidades.Nodo

      Return CargaEntidad(New SqlServer.Nodos(da).Nodos_G1(idNodo),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Nodo(),
                          accion, Function() String.Format("No se encontró el Nodo"))
   End Function

   Public Function GetTodos() As List(Of Entidades.Nodo)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(DirectCast(o, Entidades.Nodo), dr), Function() New Entidades.Nodo())
   End Function

   Public Sub MigrarNodos(Nodos As DataTable, BarraProg As System.Windows.Forms.ProgressBar)
      Try

         da.OpenConection()
         da.BeginTransaction()

         Dim i As Integer = 0

         BarraProg.Maximum = Nodos.Rows.Count
         BarraProg.Minimum = 0
         BarraProg.Value = 0

         Dim Nodo As Entidades.Nodo
         For Each dr As DataRow In Nodos.Rows
            i += 1
            BarraProg.Value = i

            Nodo = New Entidades.Nodo
            Nodo.IdNodo = Integer.Parse(dr("nodCodigo").ToString())
            Nodo.NombreNodo = dr("nodDescripcion").ToString()

            _Merge(Nodo)

         Next

         da.CommitTransaction()

      Catch ex As Exception
         BarraProg.Value = 0
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

#End Region

End Class