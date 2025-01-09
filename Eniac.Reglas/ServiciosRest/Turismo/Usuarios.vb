#Region "Option"
Option Explicit On
Option Strict On
Option Infer On
#End Region
Namespace ServiciosRest.Turismo
   Public Class Usuarios
      Inherits BaseRest(Of Entidades.JSonEntidades.Turismo.Usuarios, Entidades.Usuario)

      Public Overloads Function [Get](idEmpresa As Integer) As List(Of Entidades.JSonEntidades.Turismo.Usuarios)
         Return [Get](idEmpresa, New Reglas.Usuarios().GetActivos(toLowerId:=True, usuarioActual:=String.Empty))
      End Function

      Protected Overloads Overrides Function [Get](idEmpresa As Integer, col As IEnumerable(Of Entidades.Usuario)) As List(Of Entidades.JSonEntidades.Turismo.Usuarios)
         Return CargaLista(col, Sub(o, ent) CargarUno(o, ent), Function() New Entidades.JSonEntidades.Turismo.Usuarios(idEmpresa))
      End Function

      Protected Overloads Overrides Sub CargarUno(o As Entidades.JSonEntidades.Turismo.Usuarios, ent As Entidades.Usuario)
         o.IdUsuario = ent.Id
         o.Clave = ent.Clave
      End Sub
   End Class
End Namespace