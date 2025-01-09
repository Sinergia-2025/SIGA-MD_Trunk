Option Strict On
Option Explicit On
Imports Eniac.Entidades
Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual
Public Class ActivacionesOC
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.ActivacionOC.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.ActivacionOC)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.ActivacionOC)))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.ActivacionOC)))
   End Sub
   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.ActivacionesOC = New SqlServer.ActivacionesOC(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable ' se aplica la regla para traer todos los registros asociados al cliente
      Return New SqlServer.ActivacionesOC(Me.da).CalidadOCActivaciones_GA(idSucursal:=0, idTipoComprobante:=String.Empty, letra:="",
                                                                           centroEmisor:=0, numeroPedido:=0, Idproducto:="")
   End Function
   '  Public Function InfClientesActualizaciones(idCliente As Long, fechaDesde As DateTime?, fechaHasta As DateTime?) As DataTable
   '   Return New SqlServer.ClientesActualizaciones(Me.da).GetInfClientesActualizaciones(idCliente, fechaDesde, fechaHasta)
   'End Function

#End Region

#Region "Metodos Privados"

   Public Sub _Insertar(entidad As Eniac.Entidades.ActivacionOC)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Eniac.Entidades.ActivacionOC)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Merge(entidad As Eniac.Entidades.ActivacionOC)
      Me.EjecutaSP(entidad, TipoSP._M)
   End Sub

   Public Sub _Borrar(entidad As Eniac.Entidades.ActivacionOC)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Private Sub EjecutaSP(en As Entidades.ActivacionOC, tipo As TipoSP)

      Dim sqlC As SqlServer.ActivacionesOC = New SqlServer.ActivacionesOC(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.ActivacionesOC_I(en.IdSucursal, en.TipoComprobante.IdTipoComprobante, en.Letra, en.CentroEmisor,
                                  en.NumeroPedido, en.IdProducto, en.Orden, en.OrdenActivacion, en.Contacto,
                                  en.IdUsuario, en.FechaActivacion, en.Observacion, en.IdObservacion,
                                  en.FechaReprogEntrega, en.TelefonoProveedor, en.CorreoElectronico,
                                  en.Items, en.Cantidades, en.Precio, en.FechaE, en.Criticidad)
         Case TipoSP._U
            sqlC.ActivacionesOC_U(en.IdSucursal, en.TipoComprobante.IdTipoComprobante, en.Letra, en.CentroEmisor,
                                  en.NumeroPedido, en.IdProducto, en.Orden, en.OrdenActivacion, en.Contacto,
                                  en.IdUsuario, en.FechaActivacion, en.Observacion, en.IdObservacion,
                                  en.FechaReprogEntrega, en.TelefonoProveedor, en.CorreoElectronico,
                                    en.Items, en.Cantidades, en.Precio, en.FechaE, en.Criticidad)
            'Case TipoSP._M
            '   sqlC.CategoriasLegajos_M(en.Idcategoria, en.NombreCategoria)
         Case TipoSP._D
            sqlC.ActivacionesOC_D(en.IdSucursal, en.TipoComprobante.IdTipoComprobante, en.Letra, en.CentroEmisor,
                                  en.NumeroPedido, en.IdProducto, en.Orden, en.OrdenActivacion)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.ActivacionOC, dr As DataRow)
      With o

         .IdSucursal = Integer.Parse(dr(Entidades.ActivacionOC.Columnas.IdSucursal.ToString()).ToString())
         .TipoComprobante = New TiposComprobantes(da).GetUno(dr(Entidades.ActivacionOC.Columnas.IdTipoComprobante.ToString()).ToString())
         .Letra = dr(Entidades.ActivacionOC.Columnas.Letra.ToString()).ToString()
         .CentroEmisor = Short.Parse(dr(Entidades.ActivacionOC.Columnas.CentroEmisor.ToString()).ToString())
         .NumeroPedido = Long.Parse(dr(Entidades.ActivacionOC.Columnas.NumeroPedido.ToString()).ToString())
         .Orden = Integer.Parse(dr("Orden").ToString())
         .OrdenActivacion = Integer.Parse(dr("OrdenActivacion").ToString())
         .Contacto = dr(Entidades.ActivacionOC.Columnas.Contacto.ToString()).ToString()
         If Not String.IsNullOrEmpty(dr("IdProducto").ToString()) Then
            .Producto = New Productos(da).GetUno(dr("IdProducto").ToString())
            ' .Producto.NombreProducto = dr("NombreProducto").ToString()
         End If
         .IdUsuario = dr(Entidades.ActivacionOC.Columnas.IdUsuario.ToString()).ToString()
         .FechaActivacion = DateTime.Parse(dr("FechaActivacion").ToString())
         .Observacion = dr("Observacion").ToString()
         If Not String.IsNullOrEmpty(dr("IdObservacion").ToString()) Then
            .IdObservacion = Integer.Parse(dr("IdObservacion").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("FechaReprogEntrega").ToString()) Then
            .FechaReprogEntrega = DateTime.Parse(dr(Entidades.ActivacionOC.Columnas.FechaReprogEntrega.ToString()).ToString())
         End If
         .Criticidad = dr(Entidades.ActivacionOC.Columnas.Criticidad.ToString()).ToString()
         .TelefonoProveedor = dr(Entidades.ActivacionOC.Columnas.TelefonoProveedor.ToString()).ToString()
         .CorreoElectronico = dr(Entidades.ActivacionOC.Columnas.CorreoElectronico.ToString()).ToString()
         .Items = Boolean.Parse(dr(Entidades.ActivacionOC.Columnas.Items.ToString()).ToString())
         .Cantidades = Boolean.Parse(dr(Entidades.ActivacionOC.Columnas.Cantidades.ToString()).ToString())
         .Precio = Boolean.Parse(dr(Entidades.ActivacionOC.Columnas.Precio.ToString()).ToString())
         .FechaE = Boolean.Parse(dr(Entidades.ActivacionOC.Columnas.FechaE.ToString()).ToString())

      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(idSucursal As Integer,
                           idTipoComprobante As String,
                           letra As String,
                           centroEmisor As Integer,
                           numeroPedido As Long,
                            idproducto As String,
                            Orden As Integer,
                          ordenActivacion As Integer,
                          accion As AccionesSiNoExisteRegistro) As Entidades.ActivacionOC

      Return CargaEntidad(New SqlServer.ActivacionesOC(da).ActivacionesOC_G1(idSucursal, idTipoComprobante, letra,
                                                                             centroEmisor, numeroPedido, idproducto,
                                                                              Orden, ordenActivacion),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ActivacionOC(),
                          accion, Function() String.Format("No se encontró la activación"))
   End Function

   'Public Function GetTodos() As List(Of Entidades.ActivacionOC)
   '   Return CargaLista(GetAll(), Sub(o, dr) CargarUno(DirectCast(o, Entidades.ActivacionOC), dr), Function() New Entidades.ActivacionOC())
   'End Function
   Public Function GetTodos(idSucursal As Integer,
                           idTipoComprobante As String,
                           letra As String,
                           centroEmisor As Integer,
                           numeroPedido As Long,
                            idproducto As String,
                            Orden As Integer) As List(Of Entidades.ActivacionOC)
      Dim lst As List(Of Entidades.ActivacionOC) = New List(Of Entidades.ActivacionOC)()

      Dim dt As DataTable = GetAll(idSucursal,
                                   idTipoComprobante,
                                   letra,
                                   centroEmisor,
                                   numeroPedido,
                                   idproducto)
      For Each dr As DataRow In dt.Rows
         Dim o As Entidades.ActivacionOC = New Entidades.ActivacionOC()
         CargarUno(o, dr)
         lst.Add(o)
      Next
      Return lst
   End Function
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

   Public Function GetCodigoMaximo(OC As Entidades.PedidoProveedor, idProducto As String, orden As Integer) As Integer
      Return New SqlServer.ActivacionesOC(da).GetCodigoMaximo(OC, idProducto, orden)
   End Function

   Public Function GetUltimaActivacion(idSucursal As Integer,
                                            idTipoComprobante As String,
                                            letra As String,
                                            centroEmisor As Integer,
                                            numeroPedido As Long,
                                            Orden As Integer) As DataTable
      Return New SqlServer.ActivacionesOC(da).ActivacionesOC_GetUltimaActivacion(idSucursal, idTipoComprobante, letra,
                                                                        centroEmisor, numeroPedido, Orden)
   End Function

   Public Sub ActualizarFechareprogramacion(idSucursal As Integer,
                                            idTipoComprobante As String,
                                            letra As String,
                                            centroEmisor As Integer,
                                            numeroPedido As Long,
                                            Orden As Integer,
                                            OrdenActivacion As Integer)

      Dim sqlC As SqlServer.ActivacionesOC = New SqlServer.ActivacionesOC(da)

      sqlC.ActualizaFechaReprogramacion(idSucursal, idTipoComprobante, letra,
                                        centroEmisor, numeroPedido, Orden,
                                         OrdenActivacion)

   End Sub

   Public Overloads Function GetInforme(numeroPedido As Long,
                                  idproducto As String,
                                  Activaciones As String,
                                  Criticidad As String,
                                  IdObservacion As Integer,
                                  dtpDesde As Date,
                                  dtpHasta As Date,
                                  fechaDesdeEntrega As Date,
                                  fechaHastaEntrega As Date,
                                  fechaDesdeRepEntrega As Date,
                                  fechaHastaRepEntrega As Date,
                                  tipoTipoComprobante As String,
                                  tiposComprobante As Entidades.TipoComprobante(),
                                  IdProveedor As Long,
                                  IdUsuario As String,
                                  Items As String,
                                  Cantidades As String,
                                  Precio As String,
                                  FechaE As String,
                                  IdEstado As String,
                                  VerUltimaActivacion As Boolean,
                                  FechaAutorizacionDesde As Date,
                                  FechaAutorizacionHasta As Date) As DataTable

      Return New SqlServer.ActivacionesOC(da).ActivacionesOC_Informe(numeroPedido,
                                                                idproducto, Activaciones,
                                                                Criticidad, IdObservacion,
                                                               dtpDesde, dtpHasta,
                                                               fechaDesdeEntrega, fechaHastaEntrega,
                                                               fechaDesdeRepEntrega, fechaHastaRepEntrega,
                                                               tipoTipoComprobante, tiposComprobante,
                                                               IdProveedor, IdUsuario, Items, Cantidades,
                                                               Precio, FechaE, IdEstado, VerUltimaActivacion,
                                                               FechaAutorizacionDesde, FechaAutorizacionHasta)
   End Function



#End Region

End Class
