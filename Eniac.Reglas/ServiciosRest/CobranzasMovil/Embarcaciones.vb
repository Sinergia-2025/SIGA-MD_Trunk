Namespace ServiciosRest.CobranzasMovil
   Public Class Embarcaciones
      Public Function GetParaMovil(idEmpresa As Integer) As List(Of Entidades.JSonEntidades.CobranzasMovil.Embarcaciones)
         Dim result = New List(Of Entidades.JSonEntidades.CobranzasMovil.Embarcaciones)()

         Dim rEmb = New Reglas.Embarcaciones()
         Dim dt = rEmb.GetParaMovil()
         Dim dtClientes = rEmb.GetClientesParaMovil()

         If dt IsNot Nothing Then
            For Each dr As DataRow In dt.Rows
               Dim o = New Entidades.JSonEntidades.CobranzasMovil.Embarcaciones(idEmpresa)

               o.IdEmbarcacion = dr.Field(Of Long)("IdEmbarcacion")
               o.CodigoEmbarcacion = dr.Field(Of Long)("CodigoEmbarcacion")
               o.NombreEmbarcacion = dr.Field(Of String)("NombreEmbarcacion")
               o.Matricula = dr.Field(Of String)("Matricula")

               o.Activo = dr.Field(Of Boolean)("Activo")
               o.EnMantenimiento = dr.Field(Of Boolean)("EnMantenimiento")

               o.Estado = dr.Field(Of String)("Estado")
               o.Situacion = dr.Field(Of String)("Situacion")
               o.EstadoBotado = New Reservas()._GetSemaforoBotado(actual.Sucursal.IdSucursal, 0, o.IdEmbarcacion).ToString() '  "VERDE"             '' VERDE / AMARILLO / ROJO
               o.BotadoRestringidoPrefectura = dr.Field(Of Boolean)("BotadoRestringidoPrefectura")

               o.IdCama = dr.Field(Of Long)("IdCama")
               o.CodigoCama = dr.Field(Of String)("CodigoCama")
               o.IdNave = dr.Field(Of Short)("IdNave")
               o.NombreNave = dr.Field(Of String)("NombreNave")

               o.IdCategoriaEmbarcacion = dr.Field(Of Integer)("IdCategoriaEmbarcacion")
               o.NombreCategoriaEmbarcacion = dr.Field(Of String)("NombreCategoriaEmbarcacion")
               o.IdMarcaEmbarcacion = dr.Field(Of Integer)("IdMarcaEmbarcacion")
               o.NombreMarcaEmbarcacion = dr.Field(Of String)("NombreMarcaEmbarcacion")
               o.IdModeloEmbarcacion = dr.Field(Of Integer)("IdModeloEmbarcacion")
               o.NombreModeloEmbarcacion = dr.Field(Of String)("NombreModeloEmbarcacion")

               o.TieneObservacionesTurno = dr.Field(Of Boolean)("TieneObservacionesTurno")
               o.ObservacionesTurno = dr.Field(Of String)("ObservacionesTurno")
               o.BloqueaTurno = dr.Field(Of Boolean)("BloqueaTurno")

               o.Clientes = dtClientes.Select(String.Format("IdEmbarcacion = {0}", o.IdEmbarcacion)).ToList().ConvertAll(Function(drC) drC.Field(Of Long)("IdCliente"))

               result.Add(o)
            Next
         End If

         Return result
      End Function

   End Class
End Namespace