#Region "Option"
Option Explicit On
Option Strict On
Option Infer On
#End Region
Namespace ServiciosRest.Turismo
   Public Class Programas
      Public Overloads Function [Get](idEmpresa As Integer) As List(Of Entidades.JSonEntidades.Turismo.Programas)
         Dim dt = New Reglas.ProductosComponentes().GetParaSincronizacionMovil(idRubro:=Reglas.Publicos.TurismoRubroPrograma, activo:=True, publicarEnWeb:=True)
         Dim result = New List(Of Entidades.JSonEntidades.Turismo.Programas)


         For Each dr As DataRow In dt.Rows
            Dim idPrograma = dr.Field(Of String)("IdPrograma")
            Dim idVisita = dr.Field(Of String)("IdVisita")
            Dim idActividades = dr.Field(Of String)("IdActividad")
            Dim idFormula = dr.Field(Of Integer)("IdFormula")

            Dim programa = result.FirstOrDefault(Function(x) x.IdPrograma = idPrograma)
            If programa Is Nothing Then
               programa = CargarPrograma(idEmpresa, dr)
               result.Add(programa)
            End If

            If idFormula = Reglas.Publicos.TurismoFormulaVisitasID Then
               Dim visita = programa.Visitas.FirstOrDefault(Function(x) x.IdVisita = idVisita)
               If visita Is Nothing Then
                  visita = CargarVisita(idEmpresa, dr)
                  programa.Visitas.Add(visita)
               End If

               If Not String.IsNullOrWhiteSpace(idActividades) Then
                  Dim actividad = visita.Actividades.FirstOrDefault(Function(x) x.IdActividad = idActividades)
                  If actividad Is Nothing Then
                     actividad = CargarActividad(idEmpresa, dr)
                     visita.Actividades.Add(actividad)
                  End If
               End If

            ElseIf idFormula = Reglas.Publicos.TurismoFormulaGastronomiaID Then
               Dim lugar = programa.LugaresGastronomicos.FirstOrDefault(Function(x) x.IdLugarGastronomico = idVisita)
               If lugar Is Nothing Then
                  lugar = CargarLugarGastronomico(idEmpresa, dr)
                  programa.LugaresGastronomicos.Add(lugar)
               End If

            End If
         Next

         Return result
      End Function

      Private Function CargarPrograma(idEmpresa As Integer, dr As DataRow) As Entidades.JSonEntidades.Turismo.Programas
         Dim o = New Entidades.JSonEntidades.Turismo.Programas(idEmpresa)
         o.IdPrograma = dr.Field(Of String)("IdPrograma")
         o.NombrePrograma = dr.Field(Of String)("NombrePrograma")
         o.Visitas = New List(Of Entidades.JSonEntidades.Turismo.Visitas)()
         o.LugaresGastronomicos = New List(Of Entidades.JSonEntidades.Turismo.LugaresGastronomicos)()
         Return o
      End Function

      Private Function CargarVisita(idEmpresa As Integer, dr As DataRow) As Entidades.JSonEntidades.Turismo.Visitas
         Dim o = New Entidades.JSonEntidades.Turismo.Visitas(idEmpresa)
         o.IdPrograma = dr.Field(Of String)("IdPrograma")
         o.IdVisita = dr.Field(Of String)("IdVisita")
         o.NombreVisita = dr.Field(Of String)("NombreVisita")
         o.Actividades = New List(Of Entidades.JSonEntidades.Turismo.Actividades)()
         Return o
      End Function

      Private Function CargarActividad(idEmpresa As Integer, dr As DataRow) As Entidades.JSonEntidades.Turismo.Actividades
         Dim o = New Entidades.JSonEntidades.Turismo.Actividades(idEmpresa)
         o.IdPrograma = dr.Field(Of String)("IdPrograma")
         o.IdVisita = dr.Field(Of String)("IdVisita")
         o.IdActividad = dr.Field(Of String)("IdActividad")
         o.NombreActividad = dr.Field(Of String)("NombreActividad")
         Return o
      End Function

      Private Function CargarLugarGastronomico(idEmpresa As Integer, dr As DataRow) As Entidades.JSonEntidades.Turismo.LugaresGastronomicos
         Dim o = New Entidades.JSonEntidades.Turismo.LugaresGastronomicos(idEmpresa)
         o.IdPrograma = dr.Field(Of String)("IdPrograma")
         o.IdLugarGastronomico = dr.Field(Of String)("IdVisita")
         o.NombreLugarGastronomico = dr.Field(Of String)("NombreVisita")
         o.IdTipo = dr.Field(Of Integer)("IdSubRubro")
         o.NombreTipo = dr.Field(Of String)("NombreSubRubro")
         Return o
      End Function

   End Class
End Namespace