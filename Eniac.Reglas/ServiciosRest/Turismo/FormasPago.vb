#Region "Option"
Option Explicit On
Option Strict On
Option Infer On
#End Region
Namespace ServiciosRest.Turismo
   Public Class FormasPago
      Inherits BaseRest(Of Entidades.JSonEntidades.Turismo.FormasPago)

      Public Overloads Function [Get](idEmpresa As Integer) As List(Of Entidades.JSonEntidades.Turismo.FormasPago)
         Return [Get](idEmpresa, New Reglas.VentasFormasPago().GetPorTipo(tipo:="VENTAS", contado:=Nothing))
      End Function

      Protected Overrides Function [Get](idEmpresa As Integer, dt As DataTable) As List(Of Entidades.JSonEntidades.Turismo.FormasPago)
         Return CargaLista(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.JSonEntidades.Turismo.FormasPago(idEmpresa))
      End Function

      Protected Overrides Sub CargarUno(o As Entidades.JSonEntidades.Turismo.FormasPago, dr As DataRow)
         o.IdFormasPago = dr.Field(Of Integer)(Entidades.VentaFormaPago.Columnas.IdFormasPago.ToString())
         o.DescripcionFormasPago = dr.Field(Of String)(Entidades.VentaFormaPago.Columnas.DescripcionFormasPago.ToString())
      End Sub
   End Class
End Namespace