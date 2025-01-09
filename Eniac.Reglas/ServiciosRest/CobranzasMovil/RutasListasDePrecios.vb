#Region "Option/Imports"
Option Strict On
Option Explicit On

Imports System.ComponentModel
#End Region
Namespace ServiciosRest.CobranzasMovil
   Public Class RutasListasDePrecios
      Public Function GetRutasListasDePrecios(idEmpresa As Integer) As List(Of Entidades.JSonEntidades.CobranzasMovil.RutasListasDePrecios)
         Dim result As List(Of Entidades.JSonEntidades.CobranzasMovil.RutasListasDePrecios) = New List(Of Entidades.JSonEntidades.CobranzasMovil.RutasListasDePrecios)()

         Dim lista As List(Of Entidades.MovilRutaListaDePrecios) = New Reglas.MovilRutasListasDePrecios().GetTodos()
         Dim o As Entidades.JSonEntidades.CobranzasMovil.RutasListasDePrecios

         For Each rlp As Entidades.MovilRutaListaDePrecios In lista
            o = New Entidades.JSonEntidades.CobranzasMovil.RutasListasDePrecios(idEmpresa)

            o.IdRuta = rlp.IdRuta
            o.IdListaPrecios = rlp.ListaDePrecios.IdListaPrecios
            o.PorDefecto = rlp.PorDefecto

            result.Add(o)
         Next

         Return result
      End Function

   End Class
End Namespace