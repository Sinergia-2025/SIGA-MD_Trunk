Public Class CuentasCorrientesProvCheques
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "CuentasCorrientesProvCheques"
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos"

   Friend Sub GrabaCuentaCorrienteProvCheque(en As Entidades.CuentaCorrienteProv, chequePropio As Entidades.Cheque)
      Dim sql = New SqlServer.CuentasCorrientesProvCheques(da)
      sql.CuentasCorrientesProvCheques_I(en.IdSucursal, en.Proveedor.IdProveedor,
                                         en.TipoComprobante.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                         chequePropio.IdCheque)
   End Sub

   Friend Sub Eliminar(en As Entidades.CuentaCorrienteProv)
      Dim sql = New SqlServer.CuentasCorrientesProvCheques(da)
      sql.CuentasCorrientesProvCheques_D(en.IdSucursal, en.Proveedor.IdProveedor, en.TipoComprobante.IdTipoComprobante,
                                         en.Letra, en.CentroEmisor, en.NumeroComprobante)
   End Sub
   ''' <summary>
   ''' Recupera los Cheques para un determinado Filtro.- 
   ''' </summary>
   ''' <param name="nroOrdenPago"></param>
   ''' <param name="desdeFecha"></param>
   ''' <param name="hastaFecha"></param>
   ''' <returns></returns>
   Public Function GetCuentasCorrientesProvCheques(nroOrdenPago As Long, desdeFecha As Date?, hastaFecha As Date?) As DataTable
      Return New SqlServer.CuentasCorrientesProvCheques(da).GetCuentasCorrientesProvCheques(nroOrdenPago, desdeFecha, hastaFecha)
   End Function

#End Region

End Class