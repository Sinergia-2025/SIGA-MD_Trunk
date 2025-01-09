#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class RepartosProductosSinDescargar
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.RepartoProductoSinDescargar.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Inserta(DirectCast(entidad, Entidades.RepartoProductoSinDescargar)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualiza(DirectCast(entidad, Entidades.RepartoProductoSinDescargar)))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borra(DirectCast(entidad, Entidades.RepartoProductoSinDescargar)))
   End Sub
   Public Sub Merge(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Merge(DirectCast(entidad, Entidades.RepartoProductoSinDescargar)))
   End Sub
   Public Overloads Function GetAll(idSucursal As Integer, idReparto As Integer) As System.Data.DataTable
      Return New SqlServer.RepartosProductosSinDescargar(Me.da).GetRepartosProductosSinDescargar(idSucursal, idReparto, idProducto:=String.Empty)
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.RepartoProductoSinDescargar, tipo As TipoSP)

      Dim sqlC As SqlServer.RepartosProductosSinDescargar = New SqlServer.RepartosProductosSinDescargar(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.RepartosProductosSinDescargar_I(en.IdSucursal,
                                                 en.IdReparto,
                                                 en.IdProducto,
                                                 en.Cantidad,
                                                 en.Precio)
         Case TipoSP._U
            sqlC.RepartosProductosSinDescargar_U(en.IdSucursal,
                                                 en.IdReparto,
                                                 en.IdProducto,
                                                 en.Cantidad,
                                                 en.Precio)
         Case TipoSP._D
            sqlC.RepartosProductosSinDescargar_D(en.IdSucursal, en.IdReparto)

         Case TipoSP._M
            sqlC.RepartosProductosSinDescargar_M(en.IdSucursal,
                                                 en.IdReparto,
                                                 en.IdProducto,
                                                 en.Cantidad,
                                                 en.Precio)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.RepartoProductoSinDescargar, dr As DataRow)
      With o
         .IdSucursal = dr.ValorNumericoPorDefecto(Entidades.RepartoProductoSinDescargar.Columnas.IdSucursal.ToString(), 0I)
         .IdReparto = dr.ValorNumericoPorDefecto(Entidades.RepartoProductoSinDescargar.Columnas.IdReparto.ToString(), 0I)
         .IdProducto = dr(Entidades.RepartoProductoSinDescargar.Columnas.IdProducto.ToString()).ToString()
         .NombreProducto = dr(Entidades.RepartoProductoSinDescargar.Columnas.NombreProducto.ToString()).ToString()
         .Cantidad = dr.ValorNumericoPorDefecto(Entidades.RepartoProductoSinDescargar.Columnas.Cantidad.ToString(), 0D)
         .Precio = dr.ValorNumericoPorDefecto(Entidades.RepartoProductoSinDescargar.Columnas.Precio.ToString(), 0D)
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Sub _Inserta(entidad As Entidades.RepartoProductoSinDescargar)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualiza(entidad As Entidades.RepartoProductoSinDescargar)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borra(entidad As Entidades.RepartoProductoSinDescargar)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Sub _Merge(entidad As Entidades.RepartoProductoSinDescargar)
      Me.EjecutaSP(entidad, TipoSP._M)
   End Sub

   Public Function GetUno(idSucursal As Integer, idReparto As Integer, idProducto As String, accion As AccionesSiNoExisteRegistro) As Entidades.RepartoProductoSinDescargar
      Return CargaEntidad(New SqlServer.RepartosProductosSinDescargar(da).GetRepartosProductosSinDescargar(idSucursal, idReparto, idProducto),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RepartoProductoSinDescargar(),
                          accion, Function() String.Format("No se encontró el Reparto  con Sucursal {0}, Número {1},  Producto ´{1}´ ", idSucursal, idReparto, idProducto))
   End Function

   Public Function GetTodos(idSucursal As Integer, idReparto As Integer) As List(Of Entidades.RepartoProductoSinDescargar)
      Return CargaLista(GetAll(idSucursal, idReparto), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RepartoProductoSinDescargar())
   End Function

#End Region

End Class