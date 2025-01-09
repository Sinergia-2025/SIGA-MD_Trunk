Namespace ServiciosRest.CobranzasMovil
   Public Class Destinos
      Public Function GetParaMovil(idEmpresa As Integer) As List(Of Entidades.JSonEntidades.CobranzasMovil.Destinos)
         Dim result = New List(Of Entidades.JSonEntidades.CobranzasMovil.Destinos)()

         Dim dt = New Reglas.Destinos().GetParaMovil()

         If dt IsNot Nothing Then
            For Each dr As DataRow In dt.Rows
               Dim o = New Entidades.JSonEntidades.CobranzasMovil.Destinos(idEmpresa)

               o.IdDestino = dr.Field(Of Short)("IdDestino")
               o.NombreDestino = dr.Field(Of String)("NombreDestino")
               o.EsLibre = dr.Field(Of Boolean)("EsLibre")

               result.Add(o)
            Next
         End If

         Return result
      End Function

   End Class
End Namespace