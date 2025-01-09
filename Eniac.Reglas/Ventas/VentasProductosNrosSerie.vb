Option Explicit On
Option Strict On
Public Class VentasProductosNrosSerie
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = Entidades.VentaProductoNroSerie.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.VentaProductoNroSerie.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Inserta(DirectCast(entidad, Entidades.VentaProductoNroSerie)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualiza(DirectCast(entidad, Entidades.VentaProductoNroSerie)))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borra(DirectCast(entidad, Entidades.VentaProductoNroSerie)))
   End Sub

   Public Sub _Inserta(entidad As Entidades.VentaProductoNroSerie)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualiza(entidad As Entidades.VentaProductoNroSerie)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borra(entidad As Entidades.VentaProductoNroSerie)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

#End Region

#Region "Metodos"

   Friend Sub EjecutaSP(ByVal ent As Entidades.VentaProductoNroSerie, ByVal tipo As TipoSP)
      Try

         Dim sVentasProductosNrosSerie As SqlServer.VentasProductosNrosSerie = New SqlServer.VentasProductosNrosSerie(Me.da)

         Select Case tipo

            Case TipoSP._I

               sVentasProductosNrosSerie.VentasProductosNrosSerie_I(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor,
                            ent.NumeroComprobante, ent.Orden, ent.IdProducto, ent.NroSerie)

            Case TipoSP._U
               sVentasProductosNrosSerie.VentasProductosNrosSerie_U(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante,
                                                                    ent.Orden, ent.IdProducto, ent.NroSerie)

            Case TipoSP._D
               sVentasProductosNrosSerie.VentasProductosNrosSerie_D(ent.IdSucursal,
                                                                    ent.IdTipoComprobante,
                                                                    ent.Letra,
                                                                    ent.CentroEmisor,
                                                                    ent.NumeroComprobante)
         End Select

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Public Function GetUno(idSucursal As Integer,
                          idTipoComprobante As String,
                          letra As String,
                          centroEmisor As Integer,
                          numeroComprobante As Long,
                          orden As Integer,
                          idProducto As String,
                          nroSerie As String,
                          accion As AccionesSiNoExisteRegistro) As Entidades.VentaProductoNroSerie
      Return CargaEntidad(New SqlServer.VentasProductosNrosSerie(Me.da).VentasProductosNrosSerie_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                                                                    orden, idProducto, nroSerie),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.VentaProductoNroSerie(),
                          accion, Function() String.Format("No existe el Producto con Nro Serie: {0}", nroSerie))
   End Function

   Public Function GetTodosPorComprobante(idSucursal As Integer,
                          idTipoComprobante As String,
                          letra As String,
                          centroEmisor As Integer,
                          numeroComprobante As Long,
                          orden As Integer,
                          idProducto As String) As List(Of Entidades.VentaProductoNroSerie)
      Dim sVPNS As SqlServer.VentasProductosNrosSerie = New SqlServer.VentasProductosNrosSerie(da)
      Return CargaLista(sVPNS.GetTodosPorComprobante(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, orden, idProducto),
                        Sub(o, dr) CargarUno(DirectCast(o, Entidades.VentaProductoNroSerie), dr),
                        Function() New Entidades.VentaProductoNroSerie())
   End Function

   Public Overrides Function GetAll() As DataTable
      Dim sVentasProductosNrosSerie As SqlServer.VentasProductosNrosSerie = New SqlServer.VentasProductosNrosSerie(da)
      Return sVentasProductosNrosSerie.VentasProductosNrosSerie_GA()
   End Function

   Private Sub CargarUno(eVentaProductoNroSerie As Entidades.VentaProductoNroSerie, dr As DataRow)
      With eVentaProductoNroSerie
         .IdSucursal = dr.Field(Of Integer)(Entidades.VentaProductoNroSerie.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.VentaProductoNroSerie.Columnas.IdTipoComprobante.ToString())
         .Letra = dr.Field(Of String)(Entidades.VentaProductoNroSerie.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.VentaProductoNroSerie.Columnas.CentroEmisor.ToString())
         .NumeroComprobante = dr.Field(Of Long)(Entidades.VentaProductoNroSerie.Columnas.NumeroComprobante.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.VentaProductoNroSerie.Columnas.Orden.ToString())
         .IdProducto = dr.Field(Of String)(Entidades.VentaProductoNroSerie.Columnas.IdProducto.ToString())
         .NroSerie = dr.Field(Of String)(Entidades.VentaProductoNroSerie.Columnas.NroSerie.ToString())
      End With
   End Sub

#End Region

End Class
