Public Class VentasPercepciones
   Inherits Base
#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("VentasPercepciones", accesoDatos)
   End Sub
#End Region

#Region "Metodos"
   Public Sub GrabaCuentaCorrienteRetencion(ctacte As Entidades.CuentaCorriente, retencion As Entidades.Retencion)
      Dim sql = New SqlServer.VentasPercepciones(da)
      sql.VentasPercepciones_I(ctacte.IdSucursal,
                               ctacte.TipoComprobante.IdTipoComprobante,
                               ctacte.Letra,
                               ctacte.CentroEmisor,
                               ctacte.NumeroComprobante,
                               retencion.IdTipoImpuesto,
                               retencion.EmisorRetencion,
                               retencion.NumeroRetencion)
   End Sub
   Public Sub Eliminar(ctacte As Entidades.CuentaCorriente)
      Dim sql = New SqlServer.VentasPercepciones(da)
      sql.VentasPercepciones_D(ctacte.IdSucursal,
                               ctacte.TipoComprobante.IdTipoComprobante,
                               ctacte.Letra,
                               ctacte.CentroEmisor,
                               ctacte.NumeroComprobante)
   End Sub
   Public Sub Insertar(venta As Entidades.Venta, percepVta As Entidades.PercepcionVenta)
      Dim sql = New SqlServer.VentasPercepciones(da)
      sql.VentasPercepciones_I(venta.IdSucursal,
                               venta.TipoComprobante.IdTipoComprobante,
                               venta.LetraComprobante,
                               venta.CentroEmisor,
                               venta.NumeroComprobante,
                               percepVta.TipoImpuesto.IdTipoImpuesto,
                               percepVta.EmisorPercepcion,
                               percepVta.NumeroPercepcion)
   End Sub

#End Region

End Class