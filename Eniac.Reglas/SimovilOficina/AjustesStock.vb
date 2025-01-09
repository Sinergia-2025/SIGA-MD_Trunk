Namespace SimovilOficina
   Public Class AjustesStock
      Inherits Base

#Region "Constructores"
      Public Sub New()
         Me.New(New Datos.DataAccess())
      End Sub
      Public Sub New(accesoDatos As Datos.DataAccess)
         NombreEntidad = "dboOficina.AjustesStock"
         da = accesoDatos
      End Sub
#End Region

#Region "Metodos Overrides"
#End Region

#Region "Metodos Privados"
      Private Sub EjecutaSP(en As Entidades.SimovilOficina.AjusteStock, tipo As TipoSP)
         Dim sqlC = New SqlServer.SimovilOficina.AjustesStock(da)
         Select Case tipo
            Case TipoSP._U
               sqlC.AjustesStock_U(en.IdEjecucionAjusteStock, en.IdSucursal, en.IdProducto, en.Estado, en.MensajeError)
         End Select
      End Sub
      Private Sub CargarUno(o As Entidades.SimovilOficina.AjusteStock, dr As DataRow)
         With o
            .IdEjecucionAjusteStock = dr.Field(Of Guid)("IdEjecucionAjusteStock")
            .IdSucursal = dr.Field(Of Integer)("IdSucursal")
            .IdProducto = dr.Field(Of String)("IdProducto")
            .Stock = dr.Field(Of Decimal)("Stock")
            .IdUsuario = dr.Field(Of String)("IdUsuario")
            .FechaAlta = dr.Field(Of Date)("FechaAlta")
            .Estado = dr.Field(Of String)("Estado").StringToEnum(Entidades.SimovilOficina.EstadosAjusteStock.NUEVO)
            .MensajeError = dr.Field(Of String)("MensajeError")
         End With
      End Sub
#End Region

#Region "Metodos publicos"
      Public Sub _Actualizar(entidad As IEnumerable(Of Entidades.SimovilOficina.AjusteStock))
         entidad.ToList().ForEach(Sub(e) _Actualizar(e))
      End Sub
      Public Sub _Actualizar(entidad As Entidades.SimovilOficina.AjusteStock)
         EjecutaSP(entidad, TipoSP._U)
      End Sub
      Public Function GetTodos(idEjecucionAjusteStock As Guid, idSucursal As Integer) As IEnumerable(Of Entidades.SimovilOficina.AjusteStock)
         Return CargaLista(New SqlServer.SimovilOficina.AjustesStock(da).AjustesStock_GA(idEjecucionAjusteStock, idSucursal),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.SimovilOficina.AjusteStock())
      End Function
#End Region

   End Class
End Namespace