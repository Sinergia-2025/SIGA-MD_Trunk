#Region "Option"
Option Explicit On
Option Strict On
Option Infer On
#End Region
Namespace ServiciosRest.Turismo
   Public Class Establecimientos
      Inherits BaseRest(Of Entidades.JSonEntidades.Turismo.Establecimientos)

      Public Overloads Function [Get](idEmpresa As Integer,
                                      nombreCliente As CobranzasMovil.Clientes.NombreCliente,
                                      tipoDireccion As Entidades.TipoDireccion,
                                      incluirClientes As CobranzasMovil.Clientes.IncluirClientes) As List(Of Entidades.JSonEntidades.Turismo.Establecimientos)
         Return [Get](idEmpresa, New Reglas.Clientes().GetParaSincronizacionMovil(tipoDireccion, incluirClientes.ToString(), incluidoEnRuta:=False, idCategoria:=Reglas.Publicos.TurismoCategoriaEstablecimiento))
      End Function

      Protected Overrides Function [Get](idEmpresa As Integer, dt As DataTable) As List(Of Entidades.JSonEntidades.Turismo.Establecimientos)
         Return CargaLista(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.JSonEntidades.Turismo.Establecimientos(idEmpresa))
      End Function

      Protected Overrides Sub CargarUno(o As Entidades.JSonEntidades.Turismo.Establecimientos, dr As DataRow)
         o.IdEstablecimiento = dr.Field(Of Long)(Entidades.Cliente.Columnas.IdCliente.ToString())
         o.CodigoEstablecimiento = dr.Field(Of Long)(Entidades.Cliente.Columnas.CodigoCliente.ToString())
         o.NombreEstablecimiento = dr.Field(Of String)(Entidades.Cliente.Columnas.NombreCliente.ToString())
         o.Telefono = dr.Field(Of String)(Entidades.Cliente.Columnas.Telefono.ToString())
         o.CorreoElectronico = dr.Field(Of String)(Entidades.Cliente.Columnas.CorreoElectronico.ToString())
         o.Direccion = dr.Field(Of String)(Entidades.Cliente.Columnas.Direccion.ToString())
         o.IdLocalidad = dr.Field(Of Integer)(Entidades.Cliente.Columnas.IdLocalidad.ToString())
         o.NombreLocalidad = dr.Field(Of String)(Entidades.Localidad.Columnas.NombreLocalidad.ToString())

         o.Responsables = New ResponsablesEscolares().GetPublico(o.IdEmpresa, New Reglas.ClientesContactos().GetClientesContactos(o.IdEstablecimiento))
      End Sub

   End Class

   Public Class ResponsablesEscolares
      Inherits BaseRest(Of Entidades.JSonEntidades.Turismo.ResponsablesEscolares)


      Public Overloads Function GetPublico(idEmpresa As Integer, dt As DataTable) As List(Of Entidades.JSonEntidades.Turismo.ResponsablesEscolares)
         Return [Get](idEmpresa, dt)
      End Function
      Protected Overrides Function [Get](idEmpresa As Integer, dt As DataTable) As List(Of Entidades.JSonEntidades.Turismo.ResponsablesEscolares)
         Return CargaLista(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.JSonEntidades.Turismo.ResponsablesEscolares(idEmpresa))
      End Function

      Protected Overrides Sub CargarUno(o As Entidades.JSonEntidades.Turismo.ResponsablesEscolares, dr As DataRow)
         o.IdEstablecimiento = dr.Field(Of Long)(Entidades.ClienteContacto.Columnas.IdCliente.ToString())
         o.IdResponsableEscolar = dr.Field(Of Integer)(Entidades.ClienteContacto.Columnas.IdContacto.ToString())
         o.CodigoResponsableEscolar = o.IdResponsableEscolar
         o.NombreResponsableEscolar = dr.Field(Of String)(Entidades.ClienteContacto.Columnas.NombreContacto.ToString())
         o.Telefono = dr.Field(Of String)(Entidades.ClienteContacto.Columnas.Telefono.ToString())
         o.CorreoElectronico = dr.Field(Of String)(Entidades.ClienteContacto.Columnas.CorreoElectronico.ToString())
         o.IdCargo = dr.Field(Of Integer)(Entidades.ClienteContacto.Columnas.IdTipoContacto.ToString())
         o.NombreCargo = dr.Field(Of String)(Entidades.TipoContacto.Columnas.NombreTipoContacto.ToString())
      End Sub
   End Class

End Namespace