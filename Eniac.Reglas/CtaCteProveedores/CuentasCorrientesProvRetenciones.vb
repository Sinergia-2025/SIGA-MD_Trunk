Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class CuentasCorrientesProvRetenciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      MyBase.New()
      Me.NombreEntidad = "CuentasCorrientesProvRetenciones"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos"

   'Friend Sub Graba(ByVal ctacte As Entidades.CuentaCorrienteProvRetencion)

   '   Dim sql As SqlServer.CuentasCorrientesProvCheques = New SqlServer.CuentasCorrientesProvCheques(Me.da)

   '   With ctacte
   '      sql.CuentasCorrientesProvCheques_I(.IdSucursal, .Proveedor.IdProveedor, _
   '                                         .TipoComprobante.IdTipoComprobante, .Letra, .CentroEmisor, .NumeroComprobante, _
   '                                         chequePropio.NumeroCheque, chequePropio.Banco.IdBanco, chequePropio.IdBancoSucursal, _
   '                                         chequePropio.Localidad.IdLocalidad)
   '   End With

   'End Sub

   Friend Sub Eliminar(ByVal ctacte As Entidades.CuentaCorrienteProv)

      Dim sql As SqlServer.CuentasCorrientesProvRetenciones = New SqlServer.CuentasCorrientesProvRetenciones(Me.da)

      With ctacte
         sql.CuentasCorrientesProvRetenciones_D(.IdSucursal, .Proveedor.IdProveedor, .TipoComprobante.IdTipoComprobante, .Letra, .CentroEmisor, .NumeroComprobante)
      End With

   End Sub

#End Region

End Class
