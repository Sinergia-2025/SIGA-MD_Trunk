Option Strict On
Option Explicit On

Namespace ServiciosRest.CobranzasMovil
   Public Class EmpresasConfiguraciones
      Public Function GetConfiguraciones(idEmpresa As Integer) As List(Of Entidades.JSonEntidades.CobranzasMovil.EmpresasConfiguraciones)
         Return New List(Of Entidades.JSonEntidades.CobranzasMovil.EmpresasConfiguraciones) _
                     From {New Entidades.JSonEntidades.CobranzasMovil.EmpresasConfiguraciones(idEmpresa) _
                                 With {.CorreoElectrinico1 = Publicos.ParametrosSiMovil.CorreoMovil1().ToString().ToLower(),
                                       .CorreoElectrinico2 = Publicos.ParametrosSiMovil.CorreoMovil2().ToString().ToLower(),
                                       .CorreoElectrinico3 = Publicos.ParametrosSiMovil.CorreoMovil3().ToString().ToLower(),
                                       .BusquedaCliente = Publicos.ParametrosSiMovil.BusquedaClientes().ToString().ToLower(),
                                       .OrdenProducto = Publicos.ParametrosSiMovil.OrdenarProductos().ToString().ToLower(),
                                       .FechaExportacion = Publicos.ParametrosSiMovil.UsarFechaExportacion(),
                                       .SolicitaCierre = Publicos.ParametrosSiMovil.SolicitaCierrePedidos(),
                                       .OcultarEnvioMail = Publicos.ParametrosSiMovil.OcultarCompartirVentasPorMail(),
                                       .PlazoEntregaPorDefecto = 1,
                                       .PorcMaxDescuento = Publicos.ParametrosSiMovil.PorcMaxDescuento,
                                       .PorcMaxRecargo = Publicos.ParametrosSiMovil.PorcMaxRecargo,
                                       .EnviaMailCliente = Publicos.ParametrosSiMovil.EnviaMailCliente(),
                                       .EnviaMailEmpresa = Publicos.ParametrosSiMovil.EnviaMailEmpresa(),
                                       .OcultarResumenPromedio = Publicos.ParametrosSiMovil.OcultarResumenPromedio(),
                                       .PlazoEntregaPedido = False,
                                       .PlazoEntregaLinea = False,
                                       .SolicitaTipoComprobante = Publicos.ParametrosSiMovil.SolicitaTipoComprobante()}}
         'No hay plazo de entrega en live       -> .PlazoEntregaPorDefecto = 1 // .PlazoEntregaPedido = False // .PlazoEntregaLinea = False

         '.PuedeModificarPrecio = ruta.PuedeModificarPrecio.ToString().ToLower()   ESTO TIENE QUE IR EN LA RUTA
      End Function

   End Class
End Namespace