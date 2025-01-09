#Region "Option"
Option Explicit On
Option Strict On
Option Infer On
#End Region
Namespace ServiciosRest.Turismo
   Public Class TiposVehiculos
      Inherits BaseRest(Of Entidades.JSonEntidades.Turismo.TiposVehiculos, Entidades.TipoVehiculo)


      Public Overloads Function [Get](idEmpresa As Integer) As List(Of Entidades.JSonEntidades.Turismo.TiposVehiculos)
         Return [Get](idEmpresa, New Reglas.TiposVehiculos().GetTodos())
      End Function

      Protected Overloads Overrides Function [Get](idEmpresa As Integer, col As IEnumerable(Of Entidades.TipoVehiculo)) As List(Of Entidades.JSonEntidades.Turismo.TiposVehiculos)
         Return CargaLista(col, Sub(o, ent) CargarUno(o, ent), Function() New Entidades.JSonEntidades.Turismo.TiposVehiculos(idEmpresa))
      End Function

      Protected Overloads Overrides Sub CargarUno(o As Entidades.JSonEntidades.Turismo.TiposVehiculos, ent As Entidades.TipoVehiculo)
         o.IdTipoVehiculo = ent.IdTipoVehiculo
         o.NombreTipoVehiculo = ent.NombreTipoVehiculo
         o.CapacidadMaxima = ent.CapacidadMaxima
      End Sub
   End Class
End Namespace