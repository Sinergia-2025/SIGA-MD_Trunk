#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports System.Text
Imports Eniac.Entidades.JSonEntidades
Imports Eniac.Reglas.ServiciosRest.Sincronizacion

#End Region
Public Class ProductosSucursalesPrecios
   Inherits Eniac.Reglas.BaseSync(Of Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSonTransporte, Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSon)
   Implements IRestServices
   Implements ISyncRegla(Of Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSonTransporte, Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSon)

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ProductosSucursalesPrecios"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ProductosSucursalesPrecios"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides   - Throw New NotImplementedException()"
   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Throw New NotImplementedException()
   End Sub
   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Throw New NotImplementedException()
   End Sub
   Public Sub Actualiza(ByVal prodSuc As Eniac.Entidades.ProductoSucursal)
      Throw New NotImplementedException()
   End Sub
   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Throw New NotImplementedException()
   End Sub
   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Throw New NotImplementedException()
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable
      Throw New NotImplementedException()
   End Function
#End Region

   Public Overloads Function GetAll(publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros, aplicarPreciosOferta As Boolean, soloProductosConStock As Boolean,
                                    productoActivo As Boolean?, productoModulo As String) As DataTable
      Return New SqlServer.ProductosSucursalesPrecios(da).ProductosSucursalesPrecios_GA(fechaActualizacionDesde:=Nothing, publicarEn:=publicarEn,
                                                                                        blnPreciosConIVA:=Publicos.PreciosConIVA, listaPrecioPublicarenWeb:=Entidades.Publicos.SiNoTodos.TODOS,
                                                                                        soloTraeEstoyAca:=True, publicarEnWebSucursal:=Entidades.Publicos.SiNoTodos.TODOS,
                                                                                        aplicarPreciosOferta:=aplicarPreciosOferta,
                                                                                        soloProductosConStock:=soloProductosConStock,
                                                                                        productoActivo:=productoActivo,
                                                                                        productoModulo:=productoModulo)
   End Function

End Class