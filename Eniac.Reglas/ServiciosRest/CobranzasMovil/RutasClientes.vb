Namespace ServiciosRest.CobranzasMovil
   Public Class RutasClientes
      Public Function GetRutasClientes(idEmpresa As Integer, incluirClientes As Clientes.IncluirClientes) As List(Of Entidades.JSonEntidades.CobranzasMovil.RutasClientes)
         Dim lstRutas = New Reglas.MovilRutasClientes().GetTodosParaSincronizar()

         Dim result = New List(Of Entidades.JSonEntidades.CobranzasMovil.RutasClientes)()
         For Each ruta As DataRow In lstRutas.Rows
            Dim o = New Entidades.JSonEntidades.CobranzasMovil.RutasClientes(idEmpresa)
            o.IdRuta = ruta.Field(Of Integer)(Entidades.MovilRutaCliente.Columnas.IdRuta.ToString())
            o.Dia = ruta.Field(Of Integer)(Entidades.MovilRutaCliente.Columnas.Dia.ToString())
            o.Orden = ruta.Field(Of Integer)(Entidades.MovilRutaCliente.Columnas.Orden.ToString())
            o.IdCliente = ruta.Field(Of Long)(Entidades.MovilRutaCliente.Columnas.IdCliente.ToString())
            o.EsDePedidos = ruta.Field(Of Boolean)(Entidades.MovilRuta.Columnas.EsDePedidos.ToString())
            o.EsDeCobranza = ruta.Field(Of Boolean)(Entidades.MovilRuta.Columnas.EsDeCobranza.ToString())
            result.Add(o)
         Next

         Return result
      End Function
   End Class
End Namespace