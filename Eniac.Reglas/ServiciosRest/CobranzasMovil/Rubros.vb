#Region "Option/Imports"
Option Strict On
Option Explicit On

Imports System.ComponentModel
#End Region
Namespace ServiciosRest.CobranzasMovil
   Public Class Rubros
      Public Function GetRubros(idEmpresa As Integer) As List(Of Entidades.JSonEntidades.CobranzasMovil.Rubros)
         Dim result As List(Of Entidades.JSonEntidades.CobranzasMovil.Rubros) = New List(Of Entidades.JSonEntidades.CobranzasMovil.Rubros)()

         Dim dtClientes As DataTable = New Reglas.Rubros().GetAll()
         Dim o As Entidades.JSonEntidades.CobranzasMovil.Rubros

         For Each dr As DataRow In dtClientes.Rows
            o = New Entidades.JSonEntidades.CobranzasMovil.Rubros(idEmpresa)
            o.IdRubro = Integer.Parse(dr(Entidades.Rubro.Columnas.IdRubro.ToString()).ToString())
            o.NombreRubro = dr(Entidades.Rubro.Columnas.NombreRubro.ToString()).ToString()

            result.Add(o)
         Next

         Return result
      End Function

   End Class
End Namespace