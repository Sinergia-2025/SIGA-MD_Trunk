Namespace ServiciosRest.CobranzasMovil
   Public Class Rutas
      Public Function GetRutas(idEmpresa As Integer) As List(Of Entidades.JSonEntidades.CobranzasMovil.Rutas)

         Dim lstRutas = New Reglas.MovilRutas().GetAll(True)
         Dim o As Entidades.JSonEntidades.CobranzasMovil.Rutas

         Dim result = New List(Of Entidades.JSonEntidades.CobranzasMovil.Rutas)()
         For Each ruta As DataRow In lstRutas.Rows
            o = New Entidades.JSonEntidades.CobranzasMovil.Rutas(idEmpresa)
            o.IdRuta = ruta.Field(Of Integer)(Entidades.MovilRuta.Columnas.IdRuta.ToString())
            o.NombreRuta = ruta.Field(Of String)(Entidades.MovilRuta.Columnas.NombreRuta.ToString())
            o.IdDispositivoPorDefecto = ruta.Field(Of String)(Entidades.MovilRuta.Columnas.IdDispositivoPorDefecto.ToString())
            o.PuedeModificarPrecios = ruta.Field(Of Boolean)(Entidades.MovilRuta.Columnas.PuedeModificarPrecio.ToString())
            o.PermiteIngresarPorcentajeDescuentos = ruta.Field(Of Boolean)(Entidades.MovilRuta.Columnas.PermiteIngresarPorcentajeDescuentos.ToString())
            o.PermiteCobroParcial = ruta.Field(Of Boolean)(Entidades.MovilRuta.Columnas.PermiteCobroParcial.ToString())
            o.EsDeCobranza = ruta.Field(Of Boolean)(Entidades.MovilRuta.Columnas.EsDeCobranza.ToString())
            o.EsDePedidos = ruta.Field(Of Boolean)(Entidades.MovilRuta.Columnas.EsDePedidos.ToString())
            o.EsDeGestion = ruta.Field(Of Boolean)(Entidades.MovilRuta.Columnas.EsDeGestion.ToString())
            o.IdUsuario = ruta.Field(Of String)("IdUsuarioMovilVendedor")

            result.Add(o)
         Next

         Return result
      End Function
   End Class
End Namespace