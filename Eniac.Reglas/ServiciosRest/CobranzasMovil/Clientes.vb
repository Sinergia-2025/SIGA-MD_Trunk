Imports System.ComponentModel
Namespace ServiciosRest.CobranzasMovil
   Public Class Clientes
      Public Function GetClientes(idEmpresa As Integer,
                                  nombreCliente As NombreCliente,
                                  tipoDireccion As Entidades.TipoDireccion,
                                  incluirClientes As IncluirClientes) As List(Of Entidades.JSonEntidades.CobranzasMovil.Clientes)
         Dim result = New List(Of Entidades.JSonEntidades.CobranzasMovil.Clientes)()

         Using dtClientes = New Reglas.Clientes().GetParaSincronizacionMovil(tipoDireccion, incluirClientes.ToString(), incluidoEnRuta:=False, idCategoria:=0)
            For Each dr In dtClientes.Rows.OfType(Of DataRow)()
               Dim o = New Entidades.JSonEntidades.CobranzasMovil.Clientes(idEmpresa)
               o.IdCliente = Long.Parse(dr(Entidades.Cliente.Columnas.IdCliente.ToString()).ToString())
               o.CodigoCliente = Long.Parse(dr(Entidades.Cliente.Columnas.CodigoCliente.ToString()).ToString())
               If Not String.IsNullOrEmpty(dr(nombreCliente.ToString()).ToString()) Then
                  o.NombreCliente = dr(nombreCliente.ToString()).ToString()
               Else
                  o.NombreCliente = dr(Entidades.Cliente.Columnas.NombreCliente.ToString()).ToString()
               End If

               If tipoDireccion.IdTipoDireccion > 0 And Not String.IsNullOrEmpty(dr("DireccionSecundaria").ToString()) Then
                  o.Direccion = dr("DireccionSecundaria").ToString()
                  o.NombreLocalidad = dr("NombreLocalidadSecundaria").ToString()
               Else
                  o.Direccion = dr(Entidades.Cliente.Columnas.Direccion.ToString()).ToString()
                  o.NombreLocalidad = dr(Entidades.Localidad.Columnas.NombreLocalidad.ToString()).ToString()
               End If

               o.Telefono = dr(Entidades.Cliente.Columnas.Telefono.ToString()).ToString()
               o.Celular = dr(Entidades.Cliente.Columnas.Celular.ToString()).ToString()
               o.Cuit = dr(Entidades.Cliente.Columnas.Cuit.ToString()).ToString()
               o.NombreVendedor = dr("NombreVendedor").ToString()

               o.IdCategoriaFiscal = Short.Parse(dr(Entidades.Cliente.Columnas.IdCategoriaFiscal.ToString()).ToString())
               o.NombreCategoriaFiscal = dr(Entidades.Cliente.Columnas.NombreCategoriaFiscal.ToString()).ToString()

               o.IdListaPrecios = dr.Field(Of Integer?)(Entidades.Cliente.Columnas.IdListaPrecios.ToString())
               o.NombreListaPrecios = dr.Field(Of String)(Entidades.ListaDePrecios.Columnas.NombreListaPrecios.ToString())

               o.Observacion = dr(Entidades.Cliente.Columnas.Observacion.ToString()).ToString()
               o.CorreoElectronico = dr(Entidades.Cliente.Columnas.CorreoElectronico.ToString()).ToString()

               o.IdUsuario = dr(Entidades.Cliente.Columnas.SiMovilIdUsuario.ToString()).ToString()
               o.Clave = dr(Entidades.Cliente.Columnas.SiMovilClave.ToString()).ToString()

               o.EstadoDeVisita = ""

               result.Add(o)
            Next
         End Using

         Return result
      End Function

      Public Enum NombreCliente
         <Description("Razón Social")> NombreCliente
         <Description("Nombre de Fantasia")> NombreDeFantasia
      End Enum

      Public Enum IncluirClientes
         <Description("Todos los Clientes")> TodosLosClientes
         <Description("Solo Clientes con Deuda")> SoloClientesConDeuda
      End Enum

   End Class
End Namespace