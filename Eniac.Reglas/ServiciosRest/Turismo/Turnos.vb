#Region "Option"
Option Explicit On
Option Strict On
Option Infer On
#End Region
Namespace ServiciosRest.Turismo
   Public Class Turnos
      Inherits BaseRest(Of Entidades.JSonEntidades.Turismo.Turnos, Entidades.TurismoTurno)


      Public Overloads Function [Get](idEmpresa As Integer) As List(Of Entidades.JSonEntidades.Turismo.Turnos)
         Return [Get](idEmpresa, New Reglas.TurismoTurnos().GetTodos())
      End Function


      Protected Overloads Overrides Function [Get](idEmpresa As Integer, col As IEnumerable(Of Entidades.TurismoTurno)) As List(Of Entidades.JSonEntidades.Turismo.Turnos)
         Return CargaLista(col, Sub(o, ent) CargarUno(o, ent), Function() New Entidades.JSonEntidades.Turismo.Turnos(idEmpresa))
      End Function

      Protected Overloads Overrides Sub CargarUno(o As Entidades.JSonEntidades.Turismo.Turnos, ent As Entidades.TurismoTurno)
         o.IdTurno = ent.IdTurno
         o.NombreTurno = ent.NombreTurno

      End Sub
   End Class
End Namespace