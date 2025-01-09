Public Class CuentasCorrientesRetenciones
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.CuentaCorrienteRetencion.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Metodos"

   Public Sub GrabaCuentaCorrienteRetencion(ctacte As Entidades.CuentaCorriente, retencion As Entidades.Retencion)
      Dim sql = New SqlServer.CuentasCorrientesRetenciones(da)
      sql.CuentasCorrientesRetenciones_I(ctacte.IdSucursal,
                                         ctacte.TipoComprobante.IdTipoComprobante,
                                         ctacte.Letra,
                                         ctacte.CentroEmisor,
                                         ctacte.NumeroComprobante,
                                         retencion.IdRetencion,
                                         retencion.IdTipoImpuesto,
                                         retencion.EmisorRetencion,
                                         retencion.NumeroRetencion,
                                         retencion.Cliente.IdCliente)
   End Sub

   Public Sub Eliminar(ctacte As Entidades.CuentaCorriente)
      Dim sql = New SqlServer.CuentasCorrientesRetenciones(da)
      sql.CuentasCorrientesRetenciones_D(ctacte.IdSucursal,
                                         ctacte.TipoComprobante.IdTipoComprobante,
                                         ctacte.Letra,
                                         ctacte.CentroEmisor,
                                         ctacte.NumeroComprobante,
                                         ctacte.Cliente.IdCliente)
   End Sub

#End Region

End Class