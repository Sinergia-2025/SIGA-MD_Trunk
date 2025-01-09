Option Strict On
Option Explicit On
Imports Eniac.Entidades
Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual
Public Class EnviosOC
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.EnvioOC.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Public Sub Insertar(entidad As Eniac.Entidades.Entidad, ByVal MetodoGrabacion As String, ByVal IdFuncion As String)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         _Insertar(DirectCast(entidad, Entidades.EnvioOC), MetodoGrabacion, IdFuncion)

         Me.da.CommitTransaction()

      Catch ex As Exception
         Dim erro As Entidades.EniacException = New Entidades.EniacException(ex.Message)
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try

   End Sub
   'Public Sub Actualizar(entidad As Eniac.Entidades.Entidad)
   '   EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.EnvioOC)))
   'End Sub
   'Public Sub Borrar(entidad As Eniac.Entidades.Entidad)
   '   EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.EnvioOC)))
   'End Sub
   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.EnviosOC = New SqlServer.EnviosOC(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable ' se aplica la regla para traer todos los registros asociados al cliente
      Return New SqlServer.EnviosOC(Me.da).EnviosOC_GA(idSucursal:=0, idTipoComprobante:=String.Empty, letra:="",
                                                                           centroEmisor:=0, numeroPedido:=0)
   End Function

   '  Public Function InfClientesActualizaciones(idCliente As Long, fechaDesde As DateTime?, fechaHasta As DateTime?) As DataTable
   '   Return New SqlServer.ClientesActualizaciones(Me.da).GetInfClientesActualizaciones(idCliente, fechaDesde, fechaHasta)
   'End Function

#End Region

#Region "Metodos Privados"

   Public Sub _Insertar(entidad As Eniac.Entidades.EnvioOC, ByVal MetodoGrabacion As String, ByVal IdFuncion As String)
      Me.EjecutaSP(entidad, TipoSP._I, MetodoGrabacion, IdFuncion)
   End Sub

   Public Sub _Actualizar(entidad As Eniac.Entidades.EnvioOC, ByVal MetodoGrabacion As String, ByVal IdFuncion As String)
      Me.EjecutaSP(entidad, TipoSP._U, MetodoGrabacion, IdFuncion)
   End Sub

   Public Sub _Borrar(entidad As Eniac.Entidades.EnvioOC, ByVal MetodoGrabacion As String, ByVal IdFuncion As String)
      Me.EjecutaSP(entidad, TipoSP._D, MetodoGrabacion, IdFuncion)
   End Sub

   Private Sub EjecutaSP(en As Entidades.EnvioOC, tipo As TipoSP, ByVal MetodoGrabacion As String, ByVal IdFuncion As String)

      Dim sqlC As SqlServer.EnviosOC = New SqlServer.EnviosOC(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.EnviosOC_I(en.IdSucursal, en.TipoComprobante.IdTipoComprobante, en.Letra, en.CentroEmisor,
                                  en.NumeroPedido, en.FechaEnvio, en.IdUsuario, MetodoGrabacion, IdFuncion,
                                  en.FechaReprogramacion)
         Case TipoSP._U
            sqlC.EnviosOC_U(en.IdSucursal, en.TipoComprobante.IdTipoComprobante, en.Letra, en.CentroEmisor,
                                  en.NumeroPedido, en.FechaEnvio, en.IdUsuario, MetodoGrabacion, IdFuncion)
            'Case TipoSP._M
            '   sqlC.CategoriasLegajos_M(en.Idcategoria, en.NombreCategoria)
         Case TipoSP._D
            sqlC.EnviosOC_D(en.IdSucursal, en.TipoComprobante.IdTipoComprobante, en.Letra, en.CentroEmisor,
                                  en.NumeroPedido)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.EnvioOC, dr As DataRow)
      With o

         .IdSucursal = Integer.Parse(dr(Entidades.EnvioOC.Columnas.IdSucursal.ToString()).ToString())
         .TipoComprobante = New TiposComprobantes(da).GetUno(dr(Entidades.EnvioOC.Columnas.IdTipoComprobante.ToString()).ToString())
         .Letra = dr(Entidades.EnvioOC.Columnas.Letra.ToString()).ToString()
         .CentroEmisor = Short.Parse(dr(Entidades.EnvioOC.Columnas.CentroEmisor.ToString()).ToString())
         .NumeroPedido = Long.Parse(dr(Entidades.EnvioOC.Columnas.NumeroPedido.ToString()).ToString())
         .IdUsuario = dr(Entidades.EnvioOC.Columnas.IdUsuario.ToString()).ToString()
         .FechaEnvio = DateTime.Parse(dr("FechaEnvio").ToString())
         .FechaReprogramacion = DateTime.Parse(dr("FechaReprogramacion").ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   'Public Function GetUno(idSucursal As Integer,
   '                        idTipoComprobante As String,
   '                        letra As String,
   '                        centroEmisor As Integer,
   '                        numeroPedido As Long,
   '                         idproducto As String,
   '                         Orden As Integer,
   '                       ordenActivacion As Integer,
   '                       accion As AccionesSiNoExisteRegistro) As Entidades.ActivacionOC

   '   Return CargaEntidad(New SqlServer.ActivacionesOC(da).ActivacionesOC_G1(idSucursal, idTipoComprobante, letra,
   '                                                                          centroEmisor, numeroPedido, idproducto,
   '                                                                           Orden, ordenActivacion),
   '                       Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ActivacionOC(),
   '                       accion, Function() String.Format("No se encontró la activación"))
   'End Function

   'Public Function GetTodos() As List(Of Entidades.ActivacionOC)
   '   Return CargaLista(GetAll(), Sub(o, dr) CargarUno(DirectCast(o, Entidades.ActivacionOC), dr), Function() New Entidades.ActivacionOC())
   'End Function
   'Public Function GetTodos(idSucursal As Integer,
   '                        idTipoComprobante As String,
   '                        letra As String,
   '                        centroEmisor As Integer,
   '                        numeroPedido As Long,
   '                         idproducto As String,
   '                         Orden As Integer) As List(Of Entidades.ActivacionOC)
   '   Dim lst As List(Of Entidades.ActivacionOC) = New List(Of Entidades.ActivacionOC)()

   '   Dim dt As DataTable = GetAll(idSucursal,
   '                                idTipoComprobante,
   '                                letra,
   '                                centroEmisor,
   '                                numeroPedido,
   '                                idproducto)
   '   For Each dr As DataRow In dt.Rows
   '      Dim o As Entidades.ActivacionOC = New Entidades.ActivacionOC()
   '      CargarUno(o, dr)
   '      lst.Add(o)
   '   Next
   '   Return lst
   'End Function
   Public Overloads Function GetAll(idSucursal As Integer,
                                  idTipoComprobante As String,
                                  letra As String,
                                  centroEmisor As Integer,
                                  numeroPedido As Long,
                                  idproducto As String) As DataTable
      Return New SqlServer.ActivacionesOC(da).CalidadOCActivaciones_GA(idSucursal, idTipoComprobante,
                                                                letra, centroEmisor, numeroPedido,
                                                                idproducto)
   End Function

   Public Overloads Function GetEnviosXOC(idSucursal As Integer,
                                  idTipoComprobante As String,
                                  letra As String,
                                  centroEmisor As Integer,
                                  numeroPedido As Long) As DataTable
      Return New SqlServer.EnviosOC(da).EnviosOC_GA(idSucursal, idTipoComprobante,
                                                                letra, centroEmisor, numeroPedido)

   End Function

   Public Overloads Function GetEnviosXOCReprog(idSucursal As Integer,
                                  idTipoComprobante As String,
                                  letra As String,
                                  centroEmisor As Integer,
                                  numeroPedido As Long) As DataTable
      Return New SqlServer.EnviosOC(da).EnviosOC_GFechareprog(idSucursal, idTipoComprobante,
                                                                letra, centroEmisor, numeroPedido)

   End Function

   Public Function GetCodigoMaximo(OC As Entidades.PedidoProveedor, idProducto As String, orden As Integer) As Integer
      Return New SqlServer.ActivacionesOC(da).GetCodigoMaximo(OC, idProducto, orden)
   End Function

   Public Overloads Function GetInforme(numeroPedido As Long,
                                          Envios As String,
                                          FechaDesde As Date,
                                          FechaHasta As Date,
                                          fechaDesdeEntrega As Date,
                                          fechaHastaEntrega As Date,
                                          fechaDesdeRepEntrega As Date,
                                          fechaHastaRepEntrega As Date,
                                          tipoTipoComprobante As String,
                                          tiposComprobante As Entidades.TipoComprobante(),
                                          IdProveedor As Long,
                                          IdUsuario As String,
                                          IdEstado As String) As DataTable

      Return New SqlServer.EnviosOC(da).EnviosOC_Informe(numeroPedido,
                                                                Envios,
                                                               FechaDesde, FechaHasta,
                                                               fechaDesdeEntrega, fechaHastaEntrega,
                                                               fechaDesdeRepEntrega, fechaHastaRepEntrega,
                                                               tipoTipoComprobante, tiposComprobante,
                                                               IdProveedor, IdUsuario, IdEstado)
   End Function



#End Region

End Class
