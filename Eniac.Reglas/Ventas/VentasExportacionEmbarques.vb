#Region "Option/Imports"
Imports Eniac.Entidades
Imports System.Web.Script.Serialization

#End Region
Public Class VentasExportacionEmbarques
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.VentaExportacionEmbarques.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Methods"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.VentaExportacionEmbarques), TipoSP._I))
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.VentaExportacionEmbarques, tipo As TipoSP)
      Dim sqlC As SqlServer.VentasExportacionEmbarques = New SqlServer.VentasExportacionEmbarques(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.VentasExportacionEmbarques_I(en.IdSucursal, en.IdTipoComprobante, en.LetraComprobante, en.CentroEmisor, en.NumeroComprobante, en.IdPermisoEmbarque, en.IdDestinoDespacho)
      End Select

   End Sub

#End Region

End Class
