#Region "Option"
Option Explicit On
Option Strict On
Option Infer On
#End Region
Namespace ServiciosRest.Turismo
   Public Class Cursos
      Inherits BaseRest(Of Entidades.JSonEntidades.Turismo.Cursos, Entidades.TurismoCurso)

      Public Overloads Function [Get](idEmpresa As Integer) As List(Of Entidades.JSonEntidades.Turismo.Cursos)
         Return [Get](idEmpresa, New Reglas.TurismoCursos().GetTodos())
      End Function

      Protected Overloads Overrides Function [Get](idEmpresa As Integer, col As IEnumerable(Of Entidades.TurismoCurso)) As List(Of Entidades.JSonEntidades.Turismo.Cursos)
         Return CargaLista(col, Sub(o, ent) CargarUno(o, ent), Function() New Entidades.JSonEntidades.Turismo.Cursos(idEmpresa))
      End Function

      Protected Overloads Overrides Sub CargarUno(o As Entidades.JSonEntidades.Turismo.Cursos, ent As Entidades.TurismoCurso)
         o.IdCurso = ent.IdCurso
         o.NombreCurso = ent.NombreCurso
      End Sub
   End Class
End Namespace