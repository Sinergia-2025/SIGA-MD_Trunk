Imports Eniac.Entidades.JSonEntidades
Imports Eniac.Entidades.JSonEntidades.Extensions
Partial Class Clientes
#Region "RestService & Json"
   Public Event AvanceValidarDatosClientes(sender As Object, e As AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceValidarDatos
   Public Event AvanceImportarDatosClientes(sender As Object, e As AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceImportarDatos

   Protected Overrides Sub OnAvanceImportarDatos(eventArgs As AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceImportarDatosClientes(Me, eventArgs)
      MyBase.OnAvanceImportarDatos(eventArgs)
   End Sub
   Protected Overrides Sub OnAvanceValidarDatos(eventArgs As AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceValidarDatosClientes(Me, eventArgs)
      MyBase.OnAvanceValidarDatos(eventArgs)
   End Sub

   Public Overrides Function Convertir(transporte As List(Of Entidades.JSonEntidades.Archivos.ClienteJSonTransporte)) As List(Of Entidades.JSonEntidades.Archivos.ClienteJSon)
      Return transporte.ConvertAll(Function(dato) New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.ClienteJSon)(dato.DatosCliente))
   End Function

   Public Function GetClientesJSon(fechaActualizacionDesde As DateTime?, modo As Entidades.Cliente.ModoClienteProspecto) As List(Of Entidades.JSonEntidades.Archivos.ClienteJSon)
      Dim lst As List(Of Entidades.JSonEntidades.Archivos.ClienteJSon) = New List(Of Entidades.JSonEntidades.Archivos.ClienteJSon)()

      Dim dt As DataTable = New SqlServer.Clientes(da, modo).Clientes_GA(fechaActualizacionDesde, Nothing, puedeVerDetalleValoracionEstrellas:=False)
      Dim o As Entidades.JSonEntidades.Archivos.ClienteJSon
      Dim cuitEmpresa As String = Publicos.CuitEmpresa
      For Each dr As DataRow In dt.Rows
         o = New Entidades.JSonEntidades.Archivos.ClienteJSon()
         CargarUno(o, dr, cuitEmpresa)
         lst.Add(o)
      Next

      Return lst
   End Function

   Private Sub CargarUno(o As Entidades.JSonEntidades.Archivos.ClienteJSon, dr As DataRow, cuitEmpresa As String)
      With o
         .CuitEmpresa = cuitEmpresa

         .IdCliente = Long.Parse(dr(Entidades.Cliente.Columnas.IdCliente.ToString()).ToString())
         .CodigoCliente = Long.Parse(dr(Entidades.Cliente.Columnas.CodigoCliente.ToString()).ToString())

         .NombreCliente = dr(Entidades.Cliente.Columnas.NombreCliente.ToString()).ToString().SacarCaracteresEspeciales()
         .Direccion = dr(Entidades.Cliente.Columnas.Direccion.ToString()).ToString().SacarCaracteresEspeciales()
         .DireccionAdicional = dr("DireccionAdicional").ToString().SacarCaracteresEspeciales()
         .IdLocalidad = Integer.Parse(dr(Entidades.Cliente.Columnas.IdLocalidad.ToString()).ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.Telefono.ToString()).ToString()) Then
            .Telefono = dr(Entidades.Cliente.Columnas.Telefono.ToString()).ToString()
         End If
         .FechaNacimiento = DateTime.Parse(dr(Entidades.Cliente.Columnas.FechaNacimiento.ToString()).ToString()).ToString(AyudanteJson.FormatoFechas)
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.NroOperacion.ToString()).ToString()) Then
            .NroOperacion = Integer.Parse(dr(Entidades.Cliente.Columnas.NroOperacion.ToString()).ToString())
         End If
         .CorreoElectronico = dr(Entidades.Cliente.Columnas.CorreoElectronico.ToString()).ToString()
         .Celular = dr(Entidades.Cliente.Columnas.Celular.ToString()).ToString()
         .NombreTrabajo = dr(Entidades.Cliente.Columnas.NombreTrabajo.ToString()).ToString().SacarCaracteresEspeciales()
         .DireccionTrabajo = dr(Entidades.Cliente.Columnas.DireccionTrabajo.ToString()).ToString().SacarCaracteresEspeciales()
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.IdLocalidadTrabajo.ToString()).ToString()) Then
            .IdLocalidadTrabajo = Integer.Parse(dr(Entidades.Cliente.Columnas.IdLocalidadTrabajo.ToString()).ToString())
         End If
         .TelefonoTrabajo = dr(Entidades.Cliente.Columnas.TelefonoTrabajo.ToString()).ToString()
         .CorreoTrabajo = dr(Entidades.Cliente.Columnas.CorreoTrabajo.ToString()).ToString()
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.FechaIngresoTrabajo.ToString()).ToString()) Then
            .FechaIngresoTrabajo = DateTime.Parse(dr(Entidades.Cliente.Columnas.FechaIngresoTrabajo.ToString()).ToString()).ToString(AyudanteJson.FormatoFechas)
         End If
         .FechaAlta = DateTime.Parse(dr(Entidades.Cliente.Columnas.FechaAlta.ToString()).ToString()).ToString(AyudanteJson.FormatoFechas)
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.SaldoPendiente.ToString()).ToString()) Then
            .SaldoPendiente = Decimal.Parse(dr(Entidades.Cliente.Columnas.SaldoPendiente.ToString()).ToString())
         End If
         .IdCategoria = Integer.Parse(dr(Entidades.Cliente.Columnas.IdCategoria.ToString()).ToString())
         .IdCategoriaFiscal = Short.Parse(dr(Entidades.Cliente.Columnas.IdCategoriaFiscal.ToString()).ToString())
         .Cuit = dr(Entidades.Cliente.Columnas.Cuit.ToString()).ToString()
         .IdVendedor = Integer.Parse(dr(Entidades.Cliente.Columnas.IdVendedor.ToString()).ToString())
         .Observacion = dr(Entidades.Cliente.Columnas.Observacion.ToString()).ToString().SacarCaracteresEspeciales()
         .IdListaPrecios = Integer.Parse(dr(Entidades.Cliente.Columnas.IdListaPrecios.ToString()).ToString())
         .IdZonaGeografica = dr(Entidades.Cliente.Columnas.IdZonaGeografica.ToString()).ToString()
         .Activo = Boolean.Parse(dr(Entidades.Cliente.Columnas.Activo.ToString()).ToString())
         .LimiteDeCredito = Decimal.Parse(dr(Entidades.Cliente.Columnas.LimiteDeCredito.ToString()).ToString())
         .SaldoLimiteDeCredito = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.SaldoLimiteDeCredito.ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.IdSucursalAsociada.ToString()).ToString()) Then
            .IdSucursalAsociada = Integer.Parse(dr(Entidades.Cliente.Columnas.IdSucursalAsociada.ToString()).ToString())
         End If
         .NombreDeFantasia = dr(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).ToString().SacarCaracteresEspeciales()
         .DescuentoRecargoPorc = Decimal.Parse(dr(Entidades.Cliente.Columnas.DescuentoRecargoPorc.ToString()).ToString())
         .IdTipoComprobante = dr(Entidades.Cliente.Columnas.IdTipoComprobante.ToString()).ToString()
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.IdFormasPago.ToString()).ToString()) Then
            .IdFormasPago = Integer.Parse(dr(Entidades.Cliente.Columnas.IdFormasPago.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.IdTransportista.ToString()).ToString()) Then
            .IdTransportista = Integer.Parse(dr(Entidades.Cliente.Columnas.IdTransportista.ToString()).ToString())
         End If
         .IngresosBrutos = dr(Entidades.Cliente.Columnas.IngresosBrutos.ToString()).ToString()
         .InscriptoIBStaFe = Boolean.Parse(dr(Entidades.Cliente.Columnas.InscriptoIBStaFe.ToString()).ToString())
         .LocalIB = Boolean.Parse(dr(Entidades.Cliente.Columnas.LocalIB.ToString()).ToString())
         .ConvMultilateralIB = Boolean.Parse(dr(Entidades.Cliente.Columnas.ConvMultilateralIB.ToString()).ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.NumeroLote.ToString()).ToString()) Then
            .NumeroLote = Long.Parse(dr(Entidades.Cliente.Columnas.NumeroLote.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.IdCaja.ToString()).ToString()) Then
            .IdCaja = Integer.Parse(dr(Entidades.Cliente.Columnas.IdCaja.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr("GeoLocalizacionLat").ToString()) Then
            .GeoLocalizacionLat = Decimal.Parse(dr("GeoLocalizacionLat").ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr("GeoLocalizacionLng").ToString()) Then
            .GeoLocalizacionLng = Decimal.Parse(dr("GeoLocalizacionLng").ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr("IdTipoDeExension").ToString()) Then
            .IdTipoDeExension = Short.Parse(dr("IdTipoDeExension").ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr("AnioExension").ToString()) Then
            .AnioExension = Integer.Parse(dr("AnioExension").ToString())
         End If
         .NroCertExension = dr("NroCertExension").ToString()
         .NroCertPropio = dr("NroCertPropio").ToString()
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.IdClienteGarante.ToString()).ToString()) Then
            .IdClienteGarante = Long.Parse(dr(Entidades.Cliente.Columnas.IdClienteGarante.ToString()).ToString())
         End If
         .TipoDocCliente = dr(Entidades.Cliente.Columnas.TipoDocCliente.ToString()).ToString()
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.NroDocCliente.ToString()).ToString()) Then
            .NroDocCliente = Long.Parse(dr(Entidades.Cliente.Columnas.NroDocCliente.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.DescuentoRecargoPorc2.ToString()).ToString()) Then
            .DescuentoRecargoPorc2 = Decimal.Parse(dr(Entidades.Cliente.Columnas.DescuentoRecargoPorc2.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr("IdClienteCtaCte").ToString()) Then
            .IdClienteCtaCte = Long.Parse(dr("IdClienteCtaCte").ToString())
         End If
         .PaginaWeb = dr(Entidades.Cliente.Columnas.PaginaWeb.ToString()).ToString()
         .LimiteDiasVtoFactura = Integer.Parse(dr("LimiteDiasVtoFactura").ToString())
         .ModificarDatos = Boolean.Parse(dr(Entidades.Cliente.Columnas.ModificarDatos.ToString()).ToString())
         .EsResidente = Boolean.Parse(dr(Entidades.Cliente.Columnas.EsResidente.ToString()).ToString())
         .CorreoAdministrativo = dr(Entidades.Cliente.Columnas.CorreoAdministrativo.ToString()).ToString()
         .IdEstado = Integer.Parse(dr(Entidades.Cliente.Columnas.IdEstado.ToString()).ToString())

         '.IdCobrador = Integer.Parse(dr(Entidades.Cliente.Columnas.IdCobrador.ToString()).ToString())
         .IdCobrador = Integer.Parse(dr(Entidades.Cliente.Columnas.IdCobrador.ToString()).ToString())

         .IdTipoCliente = Integer.Parse(dr(Entidades.Cliente.Columnas.IdTipoCliente.ToString()).ToString())
         .HoraInicio = dr(Entidades.Cliente.Columnas.HoraInicio.ToString()).ToString()
         .HoraFin = dr(Entidades.Cliente.Columnas.HoraFin.ToString()).ToString()
         .HoraInicio2 = dr(Entidades.Cliente.Columnas.HoraInicio2.ToString()).ToString()
         .HoraFin2 = dr(Entidades.Cliente.Columnas.HoraFin2.ToString()).ToString()
         .HoraSabInicio = dr(Entidades.Cliente.Columnas.HoraSabInicio.ToString()).ToString()
         .HoraSabFin = dr(Entidades.Cliente.Columnas.HoraSabFin.ToString()).ToString()
         .HoraSabInicio2 = dr(Entidades.Cliente.Columnas.HoraSabInicio2.ToString()).ToString()
         .HoraSabFin2 = dr(Entidades.Cliente.Columnas.HoraSabFin2.ToString()).ToString()
         .HoraDomInicio = dr(Entidades.Cliente.Columnas.HoraDomInicio.ToString()).ToString()
         .HoraDomFin = dr(Entidades.Cliente.Columnas.HoraDomFin.ToString()).ToString()
         .HoraDomInicio2 = dr(Entidades.Cliente.Columnas.HoraDomInicio2.ToString()).ToString()
         .HoraDomFin2 = dr(Entidades.Cliente.Columnas.HoraDomFin2.ToString()).ToString()
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.HorarioCorrido.ToString()).ToString()) Then
            .HorarioCorrido = Boolean.Parse(dr(Entidades.Cliente.Columnas.HorarioCorrido.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.HorarioCorridoSab.ToString()).ToString()) Then
            .HorarioCorridoSab = Boolean.Parse(dr(Entidades.Cliente.Columnas.HorarioCorridoSab.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.HorarioCorridoDom.ToString()).ToString()) Then
            .HorarioCorridoDom = Boolean.Parse(dr(Entidades.Cliente.Columnas.HorarioCorridoDom.ToString()).ToString())
         End If
         .NroVersion = dr(Entidades.Cliente.Columnas.NroVersion.ToString()).ToString()
         'If Not String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.FechaActualizacionWeb.ToString()).ToString()) Then
         '   .FechaActualizacion = DateTime.Parse(dr(Entidades.Cliente.Columnas.FechaActualizacionWeb.ToString()).ToString()).ToString(AyudanteJson.FormatoFechas)
         'End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.FechaInicio.ToString()).ToString()) Then
            .FechaInicio = DateTime.Parse(dr(Entidades.Cliente.Columnas.FechaInicio.ToString()).ToString()).ToString(AyudanteJson.FormatoFechas)
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.FechaInicioReal.ToString()).ToString()) Then
            .FechaInicioReal = DateTime.Parse(dr(Entidades.Cliente.Columnas.FechaInicioReal.ToString()).ToString()).ToString(AyudanteJson.FormatoFechas)
         End If
         If Not String.IsNullOrWhiteSpace(dr("VencimientoLicencia").ToString()) Then
            .VencimientoLicencia = DateTime.Parse(dr("VencimientoLicencia").ToString()).ToString(AyudanteJson.FormatoFechas)
         End If
         .BackupAutoCuenta = dr("BackupAutoCuenta").ToString()
         If Not String.IsNullOrWhiteSpace(dr("BackupAutoConfig").ToString()) Then
            .BackupAutoConfig = Boolean.Parse(dr("BackupAutoConfig").ToString())
         End If
         .BackupNroVersion = dr("BackupNroVersion").ToString()
         If Not String.IsNullOrWhiteSpace(dr("TienePreciosConIVA").ToString()) Then
            .TienePreciosConIVA = Boolean.Parse(dr("TienePreciosConIVA").ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr("ConsultaPreciosConIVA").ToString()) Then
            .ConsultaPreciosConIVA = Boolean.Parse(dr("ConsultaPreciosConIVA").ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr("TieneServidorDedicado").ToString()) Then
            .TieneServidorDedicado = Boolean.Parse(dr("TieneServidorDedicado").ToString())
         End If
         .MotorBaseDatos = dr("MotorBaseDatos").ToString()
         If Not String.IsNullOrWhiteSpace(dr("CantidadDePCs").ToString()) Then
            .CantidadDePCs = Integer.Parse(dr("CantidadDePCs").ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr("HorasCapacitacionPactadas").ToString()) Then
            .HorasCapacitacionPactadas = Integer.Parse(dr("HorasCapacitacionPactadas").ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr("HorasCapacitacionRealizadas").ToString()) Then
            .HorasCapacitacionRealizadas = Integer.Parse(dr("HorasCapacitacionRealizadas").ToString())
         End If


         .UsaArchivoAImprimir2 = Boolean.Parse(dr(Entidades.Cliente.Columnas.UsaArchivoAImprimir2.ToString()).ToString())
         .CantidadVisitas = Integer.Parse(dr(Entidades.Cliente.Columnas.CantidadVisitas.ToString()).ToString())
         .CBU = dr(Entidades.Cliente.Columnas.CBU.ToString()).ToString()
         If IsNumeric(dr(Entidades.Cliente.Columnas.IdBanco.ToString()).ToString()) Then
            .IdBanco = Integer.Parse(dr(Entidades.Cliente.Columnas.IdBanco.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.Cliente.Columnas.IdCuentaBancariaClase.ToString()).ToString()) Then
            .IdCuentaBancariaClase = Integer.Parse(dr(Entidades.Cliente.Columnas.IdCuentaBancariaClase.ToString()).ToString())
         End If
         .NumeroCuentaBancaria = dr(Entidades.Cliente.Columnas.NumeroCuentaBancaria.ToString()).ToString()
         .CuitCtaBancaria = dr(Entidades.Cliente.Columnas.CuitCtaBancaria.ToString()).ToString()
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.FechaActualizacionVersion.ToString()).ToString()) Then
            .FechaActualizacionVersion = DateTime.Parse(dr(Entidades.Cliente.Columnas.FechaActualizacionVersion.ToString()).ToString()).ToString(AyudanteJson.FormatoFechas)
         End If

         .FechaActualizacionWeb = dr.Field(Of DateTime?)(Entidades.Cliente.Columnas.FechaActualizacionWeb.ToString()).IfNull().ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechasMilisegundos)

         If IsNumeric(dr(Entidades.Cliente.Columnas.NivelAutorizacion.ToString()).ToString()) Then
            .NivelAutorizacion = Short.Parse(dr(Entidades.Cliente.Columnas.NivelAutorizacion.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.Cliente.Columnas.IdCuentaContable.ToString()).ToString()) Then
            .IdCuentaContable = Long.Parse(dr(Entidades.Cliente.Columnas.IdCuentaContable.ToString()).ToString())
         End If

         .Facebook = dr(Entidades.Cliente.Columnas.Facebook.ToString()).ToString()
         .Instagram = dr(Entidades.Cliente.Columnas.Instagram.ToString()).ToString()
         .Twitter = dr(Entidades.Cliente.Columnas.Twitter.ToString()).ToString()

         .EsClienteGenerico = Boolean.Parse(dr(Entidades.Cliente.Columnas.EsClienteGenerico.ToString()).ToString())

         .URLWebmovilPropio = dr(Entidades.Cliente.Columnas.URLWebmovilPropio.ToString()).ToString()
         .URLWebmovilAdminPropio = dr(Entidades.Cliente.Columnas.URLWebmovilAdminPropio.ToString()).ToString()
         .URLSimovilGestionPropio = dr(Entidades.Cliente.Columnas.URLSimovilGestionPropio.ToString()).ToString()
         .URLActualizadorPropio = dr(Entidades.Cliente.Columnas.URLActualizadorPropio.ToString()).ToString()

         .NroVersionWebmovilPropio = dr(Entidades.Cliente.Columnas.NroVersionWebmovilPropio.ToString()).ToString()
         .NroVersionWebmovilAdminPropio = dr(Entidades.Cliente.Columnas.NroVersionWebmovilAdminPropio.ToString()).ToString()
         .NroVersionSimovilGestionPropio = dr(Entidades.Cliente.Columnas.NroVersionSimovilGestionPropio.ToString()).ToString()
         .NroVersionActualizadorPropio = dr(Entidades.Cliente.Columnas.NroVersionActualizadorPropio.ToString()).ToString()

         .ObservacionAdministrativa = dr(Entidades.Cliente.Columnas.ObservacionAdministrativa.ToString()).ToString()
         .CodigoClienteLetras = dr(Entidades.Cliente.Columnas.CodigoCliente.ToString()).ToString()

         .SiMovilIdUsuario = dr(Entidades.Cliente.Columnas.SiMovilIdUsuario.ToString()).ToString()
         .SiMovilClave = dr(Entidades.Cliente.Columnas.SiMovilClave.ToString()).ToString()

         .Alicuota2deProducto = dr(Entidades.Cliente.Columnas.Alicuota2deProducto.ToString()).ToString()
         .Sexo = dr(Entidades.Cliente.Columnas.Sexo.ToString()).ToString()
         .HorarioClienteCompleto = dr.Field(Of String)(Entidades.Cliente.Columnas.HorarioClienteCompleto.ToString())
         .IdClienteTiendaNube = dr.Field(Of String)(Entidades.Cliente.Columnas.IdClienteTiendaNube.ToString())
         .IdClienteMercadoLibre = dr.Field(Of String)(Entidades.Cliente.Columnas.IdClienteMercadoLibre.ToString())

         .ValorizacionFacturacionMensual = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionFacturacionMensual.ToString())
         .ValorizacionCoeficienteFacturacion = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionCoeficienteFacturacion.ToString())
         .ValorizacionFacturacion = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionFacturacion.ToString())
         .ValorizacionImporteAdeudado = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionImporteAdeudado.ToString())
         .ValorizacionCoeficienteDeuda = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionCoeficienteDeuda.ToString())
         .ValorizacionDeuda = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionDeuda.ToString())
         .ValorizacionProyecto = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionProyecto.ToString())
         .ValorizacionProyectoObservacion = dr.Field(Of String)(Entidades.Cliente.Columnas.ValorizacionProyectoObservacion.ToString())
         .ValorizacionCliente = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionCliente.ToString())
         .ValorizacionEstrellas = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionEstrellas.ToString())

         .PublicarEnWeb = dr.Field(Of Boolean)(Entidades.Cliente.Columnas.PublicarEnWeb.ToString())

         .UtilizaAppSoporte = dr.Field(Of Boolean)(Entidades.Cliente.Columnas.UtilizaAppSoporte.ToString())
         .CantidadLocal = dr.Field(Of Integer)(Entidades.Cliente.Columnas.CantidadLocal.ToString())
         .CantidadRemota = dr.Field(Of Integer?)(Entidades.Cliente.Columnas.CantidadRemota.ToString()).IfNull()
         .CantidadMovil = dr.Field(Of Integer?)(Entidades.Cliente.Columnas.CantidadMovil.ToString()).IfNull()

         .CertificadoMiPyme = dr.Field(Of Boolean)(Entidades.Cliente.Columnas.CertificadoMiPyme.ToString())
         .FechaDesdeCertificado = dr.Field(Of String)(Entidades.Cliente.Columnas.FechaDesdeCertificado.ToString())
         .FechaHastaCertificado = dr.Field(Of String)(Entidades.Cliente.Columnas.FechaHastaCertificado.ToString())

         'PE-30972
         .FechaCambioCategoria = dr.Field(Of Date?)(Entidades.Cliente.Columnas.FechaCambioCategoria.ToString())
         .ObservacionCambioCategoria = dr.Field(Of String)(Entidades.Cliente.Columnas.ObservacionCambioCategoria.ToString())
         .IdCategoriaCambio = dr.Field(Of Integer?)(Entidades.Cliente.Columnas.IdCategoriaCambio.ToString())

         .ActualizadorAptoParaInstalar = dr.Field(Of Boolean)("ActualizadorAptoParaInstalar")
         .ActualizadorFunciona = dr.Field(Of String)("ActualizadorFunciona")
         .ActualizadorFechaInstalacion = dr.Field(Of Date?)("ActualizadorFechaInstalacion").ToStringFormatoPropio()
         .ActualizadorVersion = dr.Field(Of String)("ActualizadorVersion").IfNull()

         .IdImpositivoOtroPais = dr.Field(Of String)("IdImpositivoOtroPais")
         .IdConceptoCM05 = dr.Field(Of Integer?)("IdConceptoCM05")
         .EsExentoPercIVARes53292023 = dr.Field(Of Boolean)("EsExentoPercIVARes53292023")

         .PublicarEnTiendaNube = dr.Field(Of Boolean)(Entidades.Cliente.Columnas.PublicarEnTiendaNube.ToString())
         .PublicarEnMercadoLibre = dr.Field(Of Boolean)(Entidades.Cliente.Columnas.PublicarEnMercadoLibre.ToString())
         .PublicarEnArborea = dr.Field(Of Boolean)(Entidades.Cliente.Columnas.PublicarEnArborea.ToString())
         .PublicarEnGestion = dr.Field(Of Boolean)(Entidades.Cliente.Columnas.PublicarEnGestion.ToString())
         .PublicarEnEmpresarial = dr.Field(Of Boolean)(Entidades.Cliente.Columnas.PublicarEnEmpresarial.ToString())
         .PublicarEnSincronizacionSucursal = dr.Field(Of Boolean)(Entidades.Cliente.Columnas.PublicarEnSincronizacionSucursal.ToString())


      End With
   End Sub

   Public Sub CargarJSonEnDataTable(clientesJson As List(Of Entidades.JSonEntidades.Archivos.ClienteJSonTransporte), dt As DataTable)
      Dim dr As DataRow
      For Each transporte As Entidades.JSonEntidades.Archivos.ClienteJSonTransporte In clientesJson
         Dim clienteJSon As Entidades.JSonEntidades.Archivos.ClienteJSon
         clienteJSon = New System.Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.ClienteJSon)(transporte.DatosCliente)
         dr = dt.NewRow()
         SeteaValor(dr, "CuitEmpresa", clienteJSon.CuitEmpresa, GetType(String))
         SeteaValor(dr, "IdCliente", clienteJSon.IdCliente, GetType(Long))
         SeteaValor(dr, "CodigoCliente", clienteJSon.CodigoCliente, GetType(Long))
         SeteaValor(dr, "CodigoClienteLetras", clienteJSon.CodigoClienteLetras, GetType(String))

         SeteaValor(dr, "NombreCliente", clienteJSon.NombreCliente.RecuperarCaracteresEspeciales(), GetType(String))
         SeteaValor(dr, "Direccion", clienteJSon.Direccion.RecuperarCaracteresEspeciales(), GetType(String))
         SeteaValor(dr, "DireccionAdicional", clienteJSon.DireccionAdicional.RecuperarCaracteresEspeciales(), GetType(String))
         SeteaValor(dr, "IdLocalidad", clienteJSon.IdLocalidad, GetType(Integer))
         SeteaValor(dr, "Telefono", clienteJSon.Telefono, GetType(String))
         SeteaValor(dr, "FechaNacimiento", clienteJSon.FechaNacimiento, GetType(String))
         SeteaValor(dr, "NroOperacion", clienteJSon.NroOperacion, GetType(Integer))
         SeteaValor(dr, "CorreoElectronico", clienteJSon.CorreoElectronico, GetType(String))
         SeteaValor(dr, "Celular", clienteJSon.Celular, GetType(String))
         SeteaValor(dr, "NombreTrabajo", clienteJSon.NombreTrabajo.RecuperarCaracteresEspeciales(), GetType(String))
         SeteaValor(dr, "DireccionTrabajo", clienteJSon.DireccionTrabajo.RecuperarCaracteresEspeciales(), GetType(String))
         SeteaValor(dr, "IdLocalidadTrabajo", clienteJSon.IdLocalidadTrabajo, GetType(Integer))
         SeteaValor(dr, "TelefonoTrabajo", clienteJSon.TelefonoTrabajo, GetType(String))
         SeteaValor(dr, "CorreoTrabajo", clienteJSon.CorreoTrabajo, GetType(String))
         SeteaValor(dr, "FechaIngresoTrabajo", clienteJSon.FechaIngresoTrabajo, GetType(DateTime))
         SeteaValor(dr, "FechaAlta", clienteJSon.FechaAlta, GetType(String))
         SeteaValor(dr, "SaldoPendiente", clienteJSon.SaldoPendiente, GetType(Decimal))
         SeteaValor(dr, "IdCategoria", clienteJSon.IdCategoria, GetType(Integer))
         SeteaValor(dr, "IdCategoriaFiscal", clienteJSon.IdCategoriaFiscal, GetType(Integer))
         SeteaValor(dr, "Cuit", clienteJSon.Cuit, GetType(String))
         SeteaValor(dr, "IdVendedor", clienteJSon.IdVendedor, GetType(Integer))
         SeteaValor(dr, "Observacion", clienteJSon.Observacion.RecuperarCaracteresEspeciales(), GetType(String))
         SeteaValor(dr, "IdListaPrecios", clienteJSon.IdListaPrecios, GetType(Integer))
         SeteaValor(dr, "IdZonaGeografica", clienteJSon.IdZonaGeografica, GetType(String))
         SeteaValor(dr, "Activo", clienteJSon.Activo, GetType(Boolean))
         SeteaValor(dr, "LimiteDeCredito", clienteJSon.LimiteDeCredito, GetType(Decimal))
         SeteaValor(dr, "SaldoLimiteDeCredito", clienteJSon.SaldoLimiteDeCredito, GetType(Decimal))
         SeteaValor(dr, "IdSucursalAsociada", clienteJSon.IdSucursalAsociada, GetType(Integer))
         SeteaValor(dr, "NombreDeFantasia", clienteJSon.NombreDeFantasia.RecuperarCaracteresEspeciales(), GetType(String))
         SeteaValor(dr, "DescuentoRecargoPorc", clienteJSon.DescuentoRecargoPorc, GetType(Decimal))
         SeteaValor(dr, "IdTipoComprobante", clienteJSon.IdTipoComprobante, GetType(String))
         SeteaValor(dr, "IdFormasPago", clienteJSon.IdFormasPago, GetType(Integer))
         SeteaValor(dr, "IdTransportista", clienteJSon.IdTransportista, GetType(Integer))
         SeteaValor(dr, "IngresosBrutos", clienteJSon.IngresosBrutos, GetType(String))
         SeteaValor(dr, "InscriptoIBStaFe", clienteJSon.InscriptoIBStaFe, GetType(Boolean))
         SeteaValor(dr, "LocalIB", clienteJSon.LocalIB, GetType(Boolean))
         SeteaValor(dr, "ConvMultilateralIB", clienteJSon.ConvMultilateralIB, GetType(Boolean))
         SeteaValor(dr, "NumeroLote", clienteJSon.NumeroLote, GetType(Long))
         SeteaValor(dr, "IdCaja", clienteJSon.IdCaja, GetType(Integer))
         SeteaValor(dr, "GeoLocalizacionLat", clienteJSon.GeoLocalizacionLat, GetType(Decimal))
         SeteaValor(dr, "GeoLocalizacionLng", clienteJSon.GeoLocalizacionLng, GetType(Decimal))
         SeteaValor(dr, "IdTipoDeExension", clienteJSon.IdTipoDeExension, GetType(Short))
         SeteaValor(dr, "AnioExension", clienteJSon.AnioExension, GetType(Integer))
         SeteaValor(dr, "NroCertExension", clienteJSon.NroCertExension, GetType(String))
         SeteaValor(dr, "NroCertPropio", clienteJSon.NroCertPropio, GetType(String))
         SeteaValor(dr, "IdClienteGarante", clienteJSon.IdClienteGarante, GetType(Long))
         SeteaValor(dr, "TipoDocCliente", clienteJSon.TipoDocCliente, GetType(String))
         SeteaValor(dr, "NroDocCliente", clienteJSon.NroDocCliente, GetType(Long))
         SeteaValor(dr, "DescuentoRecargoPorc2", clienteJSon.DescuentoRecargoPorc2, GetType(Decimal))
         SeteaValor(dr, "IdClienteCtaCte", clienteJSon.IdClienteCtaCte, GetType(Long))
         SeteaValor(dr, "PaginaWeb", clienteJSon.PaginaWeb, GetType(String))
         SeteaValor(dr, "LimiteDiasVtoFactura", clienteJSon.LimiteDiasVtoFactura, GetType(Integer))
         SeteaValor(dr, "ModificarDatos", clienteJSon.ModificarDatos, GetType(Boolean))
         SeteaValor(dr, "EsResidente", clienteJSon.EsResidente, GetType(Boolean))
         SeteaValor(dr, "CorreoAdministrativo", clienteJSon.CorreoAdministrativo, GetType(String))
         SeteaValor(dr, "IdEstado", clienteJSon.IdEstado, GetType(Integer))
         '   SeteaValor(dr, "IdCobrador", clienteJSon.IdCobrador, GetType(Integer))
         SeteaValor(dr, "IdTipoCliente", clienteJSon.IdTipoCliente, GetType(Integer))
         SeteaValor(dr, "HoraInicio", clienteJSon.HoraInicio, GetType(String))
         SeteaValor(dr, "HoraFin", clienteJSon.HoraFin, GetType(String))
         SeteaValor(dr, "HoraInicio2", clienteJSon.HoraInicio2, GetType(String))
         SeteaValor(dr, "HoraFin2", clienteJSon.HoraFin2, GetType(String))
         SeteaValor(dr, "HoraSabInicio", clienteJSon.HoraSabInicio, GetType(String))
         SeteaValor(dr, "HoraSabFin", clienteJSon.HoraSabFin, GetType(String))
         SeteaValor(dr, "HoraSabInicio2", clienteJSon.HoraSabInicio2, GetType(String))
         SeteaValor(dr, "HoraSabFin2", clienteJSon.HoraSabFin2, GetType(String))
         SeteaValor(dr, "HoraDomInicio", clienteJSon.HoraDomInicio, GetType(String))
         SeteaValor(dr, "HoraDomFin", clienteJSon.HoraDomFin, GetType(String))
         SeteaValor(dr, "HoraDomInicio2", clienteJSon.HoraDomInicio2, GetType(String))
         SeteaValor(dr, "HoraDomFin2", clienteJSon.HoraDomFin2, GetType(String))
         SeteaValor(dr, "HorarioCorrido", clienteJSon.HorarioCorrido, GetType(Boolean))
         SeteaValor(dr, "HorarioCorridoSab", clienteJSon.HorarioCorridoSab, GetType(Boolean))
         SeteaValor(dr, "HorarioCorridoDom", clienteJSon.HorarioCorridoDom, GetType(Boolean))
         SeteaValor(dr, "NroVersion", clienteJSon.NroVersion, GetType(String))
         'SeteaValor(dr, "FechaActualizacion", clienteJSon.FechaActualizacion, GetType(String))
         SeteaValor(dr, "FechaInicio", clienteJSon.FechaInicio, GetType(String))
         SeteaValor(dr, "FechaInicioReal", clienteJSon.FechaInicioReal, GetType(String))
         SeteaValor(dr, "VencimientoLicencia", clienteJSon.VencimientoLicencia, GetType(String))

         SeteaValor(dr, "BackupAutoCuenta", clienteJSon.BackupAutoCuenta, GetType(String))
         SeteaValor(dr, "BackupAutoConfig", clienteJSon.BackupAutoConfig, GetType(Boolean))
         SeteaValor(dr, "BackupNroVersion", clienteJSon.BackupNroVersion, GetType(String))

         SeteaValor(dr, "TienePreciosConIVA", clienteJSon.TienePreciosConIVA, GetType(Boolean))
         SeteaValor(dr, "ConsultaPreciosConIVA", clienteJSon.ConsultaPreciosConIVA, GetType(Boolean))
         SeteaValor(dr, "TieneServidorDedicado", clienteJSon.TieneServidorDedicado, GetType(Boolean))
         SeteaValor(dr, "MotorBaseDatos", clienteJSon.MotorBaseDatos, GetType(String))
         SeteaValor(dr, "CantidadDePCs", clienteJSon.CantidadDePCs, GetType(Integer))
         SeteaValor(dr, "HorasCapacitacionPactadas", clienteJSon.HorasCapacitacionPactadas, GetType(Integer))
         SeteaValor(dr, "HorasCapacitacionRealizadas", clienteJSon.HorasCapacitacionRealizadas, GetType(Integer))

         SeteaValor(dr, "UsaArchivoAImprimir2", clienteJSon.UsaArchivoAImprimir2, GetType(Boolean))
         SeteaValor(dr, "CantidadVisitas", clienteJSon.CantidadVisitas, GetType(Integer))
         SeteaValor(dr, "CBU", clienteJSon.CBU, GetType(String))
         SeteaValor(dr, "IdBanco", clienteJSon.IdBanco, GetType(Integer))
         SeteaValor(dr, "IdCuentaBancariaClase", clienteJSon.IdCuentaBancariaClase, GetType(Integer))
         SeteaValor(dr, "NumeroCuentaBancaria", clienteJSon.NumeroCuentaBancaria, GetType(String))
         SeteaValor(dr, "CuitCtaBancaria", clienteJSon.CuitCtaBancaria, GetType(String))

         SeteaValor(dr, "Facebook", clienteJSon.Facebook, GetType(String))
         SeteaValor(dr, "Instagram", clienteJSon.Instagram, GetType(String))
         SeteaValor(dr, "Twitter", clienteJSon.Twitter, GetType(String))


         SeteaValor(dr, "IdAplicacion", clienteJSon.IdAplicacion, GetType(String))
         SeteaValor(dr, "Edicion", clienteJSon.Edicion, GetType(String))
         SeteaValor(dr, "RecibeNotificaciones", clienteJSon.RecibeNotificaciones, GetType(Boolean))
         SeteaValor(dr, "Contacto", clienteJSon.Contacto, GetType(String))
         SeteaValor(dr, "FechaBaja", clienteJSon.FechaBaja, GetType(String))
         SeteaValor(dr, "VerEnConsultas", clienteJSon.VerEnConsultas, GetType(Boolean))
         SeteaValor(dr, "IdCalle", clienteJSon.IdCalle, GetType(Integer))
         SeteaValor(dr, "Altura", clienteJSon.Altura, GetType(Integer))
         SeteaValor(dr, "IdCalle2", clienteJSon.IdCalle2, GetType(Integer))
         SeteaValor(dr, "Altura2", clienteJSon.Altura2, GetType(Integer))
         SeteaValor(dr, "DireccionAdicional2", clienteJSon.DireccionAdicional2, GetType(String))
         SeteaValor(dr, "TelefonosParticulares", clienteJSon.TelefonosParticulares, GetType(String))
         SeteaValor(dr, "Fax", clienteJSon.Fax, GetType(String))
         SeteaValor(dr, "FechaSUS", clienteJSon.FechaSUS, GetType(String))
         SeteaValor(dr, "IdDadoAltaPor", clienteJSon.IdDadoAltaPor, GetType(Integer))
         'SeteaValor(dr, "TipoDocDadoAltaPor", clienteJSon.TipoDocDadoAltaPor, GetType(String))
         'SeteaValor(dr, "NroDocDadoAltaPor", clienteJSon.NroDocDadoAltaPor, GetType(String))
         SeteaValor(dr, "HabilitarVisita", clienteJSon.HabilitarVisita, GetType(Boolean))
         SeteaValor(dr, "Direccion2", clienteJSon.Direccion2, GetType(String))
         SeteaValor(dr, "IdLocalidad2", clienteJSon.IdLocalidad2, GetType(Integer))
         SeteaValor(dr, "ObservacionWeb", clienteJSon.ObservacionWeb, GetType(String))
         SeteaValor(dr, "RepartoIndependiente", clienteJSon.RepartoIndependiente, GetType(Boolean))
         SeteaValor(dr, "NivelAutorizacion", clienteJSon.NivelAutorizacion, GetType(Short))
         SeteaValor(dr, "IdCuentaContable", clienteJSon.IdCuentaContable, GetType(Long))

         'ObtieneValor(dr, Entidades.Cliente.Columnas.HabilitarVisita.ToString(), False),
         'dr(Entidades.Cliente.Columnas.Direccion2.ToString()).ToString(),
         'ObtieneValor(dr, Entidades.Cliente.Columnas.IdLocalidad2.ToString(), 0I),
         'dr(Entidades.Cliente.Columnas.ObservacionWeb.ToString()).ToString(),
         'ObtieneValor(dr, Entidades.Cliente.Columnas.RepartoIndependiente.ToString(), False))

         SeteaValor(dr, "URLWebmovilPropio", clienteJSon.URLWebmovilPropio, GetType(String))
         SeteaValor(dr, "URLWebmovilAdminPropio", clienteJSon.URLWebmovilAdminPropio, GetType(String))
         SeteaValor(dr, "URLSimovilGestionPropio", clienteJSon.URLSimovilGestionPropio, GetType(String))
         SeteaValor(dr, "URLActualizadorPropio", clienteJSon.URLActualizadorPropio, GetType(String))

         SeteaValor(dr, "NroVersionWebmovilPropio", clienteJSon.NroVersionWebmovilPropio, GetType(String))
         SeteaValor(dr, "NroVersionWebmovilAdminPropio", clienteJSon.NroVersionWebmovilAdminPropio, GetType(String))
         SeteaValor(dr, "NroVersionSimovilGestionPropio", clienteJSon.NroVersionSimovilGestionPropio, GetType(String))
         SeteaValor(dr, "NroVersionActualizadorPropio", clienteJSon.NroVersionActualizadorPropio, GetType(String))

         SeteaValor(dr, "ObservacionAdministrativa", clienteJSon.ObservacionAdministrativa, GetType(String))
         SeteaValor(dr, "SiMovilIdUsuario", clienteJSon.SiMovilIdUsuario, GetType(String))
         SeteaValor(dr, "SiMovilClave", clienteJSon.SiMovilClave, GetType(String))
         SeteaValor(dr, "Alicuota2deProducto", clienteJSon.Alicuota2deProducto, GetType(String))

         SeteaValor(dr, "FechaActualizacionVersion", clienteJSon.FechaActualizacionVersion, GetType(String))
         SeteaValor(dr, "FechaActualizacionWeb", clienteJSon.FechaActualizacionWeb, GetType(String))
         SeteaValor(dr, "IdCobrador", clienteJSon.IdCobrador, GetType(Integer))
         SeteaValor(dr, "Sexo", clienteJSon.Sexo, GetType(String))
         SeteaValor(dr, "HorarioClienteCompleto", clienteJSon.HorarioClienteCompleto, GetType(String))
         SeteaValor(dr, "IdClienteTiendaNube", clienteJSon.IdClienteTiendaNube, GetType(String))
         SeteaValor(dr, "IdClienteMercadoLibre", clienteJSon.IdClienteMercadoLibre, GetType(String))

         SeteaValor(dr, "ValorizacionFacturacionMensual", clienteJSon.ValorizacionFacturacionMensual, GetType(Decimal))
         SeteaValor(dr, "ValorizacionCoeficienteFacturacion", clienteJSon.ValorizacionCoeficienteFacturacion, GetType(Decimal))
         SeteaValor(dr, "ValorizacionFacturacion", clienteJSon.ValorizacionFacturacion, GetType(Decimal))
         SeteaValor(dr, "ValorizacionImporteAdeudado", clienteJSon.ValorizacionImporteAdeudado, GetType(Decimal))
         SeteaValor(dr, "ValorizacionCoeficienteDeuda", clienteJSon.ValorizacionCoeficienteDeuda, GetType(Decimal))
         SeteaValor(dr, "ValorizacionDeuda", clienteJSon.ValorizacionDeuda, GetType(Decimal))
         SeteaValor(dr, "ValorizacionProyecto", clienteJSon.ValorizacionProyecto, GetType(Decimal))
         SeteaValor(dr, "ValorizacionProyectoObservacion", clienteJSon.ValorizacionProyectoObservacion, GetType(String))
         SeteaValor(dr, "ValorizacionCliente", clienteJSon.ValorizacionCliente, GetType(Decimal))
         SeteaValor(dr, "ValorizacionEstrellas", clienteJSon.ValorizacionEstrellas, GetType(Decimal))
         SeteaValor(dr, "PublicarEnWeb", clienteJSon.PublicarEnWeb, GetType(Boolean))
         'PE-30972
         SeteaValor(dr, "FechaCambioCategoria", clienteJSon.FechaCambioCategoria, GetType(Date))
         SeteaValor(dr, "ObservacionCambioCategoria", clienteJSon.ObservacionCambioCategoria, GetType(String))
         SeteaValor(dr, "IdCategoriaCambio", clienteJSon.IdCategoriaCambio, GetType(Integer))

         SeteaValor(dr, "ActualizadorAptoParaInstalar", clienteJSon.ActualizadorAptoParaInstalar, GetType(Boolean))
         SeteaValor(dr, "ActualizadorFunciona", clienteJSon.ActualizadorFunciona, GetType(String))
         SeteaValor(dr, "ActualizadorFechaInstalacion", clienteJSon.ActualizadorFechaInstalacion, GetType(String))
         SeteaValor(dr, "ActualizadorVersion", clienteJSon.ActualizadorVersion, GetType(String))

         SeteaValor(dr, "IdImpositivoOtroPais", clienteJSon.IdImpositivoOtroPais, GetType(String))
         SeteaValor(dr, "IdConceptoCM05", clienteJSon.IdConceptoCM05, GetType(Integer))
         SeteaValor(dr, "EsExentoPercIVARes53292023", clienteJSon.EsExentoPercIVARes53292023, GetType(Boolean))

         SeteaValor(dr, "DatosSyncronizados", clienteJSon, GetType(Object))

         clienteJSon.drOrigen = dr

         dt.Rows.Add(dr)
      Next
   End Sub

   Public Overloads Sub ValidarDatos(dt As DataTable, dtLocalidades As DataTable)
      ValidarDatos(dt.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.ClienteJSon)("DatosSyncronizados")),
                   New ServiciosRest.Sincronizacion.SyncBaseCollection().
                           AgregarDatosRecibidosCustom(GetType(Entidades.JSonEntidades.Archivos.LocalidadJSon),
                                                       dtLocalidades.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.LocalidadJSon)("DatosSyncronizados"))))
   End Sub

   Public Overrides Function ValidarDatos(col As List(Of Entidades.JSonEntidades.Archivos.ClienteJSon), syncs As ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean
      Dim cache As BusquedasCacheadas = New BusquedasCacheadas()
      Dim eventArgs As AvanceProcesarDatosEventArgs = New AvanceProcesarDatosEventArgs("Clientes")

      eventArgs.TotalRegistros = col.Count
      For Each en As Entidades.JSonEntidades.Archivos.ClienteJSon In col
         Dim stbMensajeError = New StringBuilder()
         eventArgs.RegistroActual += 1
         eventArgs.Datos = en
         OnAvanceValidarDatos(eventArgs)

         If Not cache.ExisteCategoria(en.IdCategoria) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe la Categoría con IdCategoria = {0}.", en.IdCategoria), Entidades.Cliente.Columnas.IdCategoria.ToString())
         End If

         If Not cache.ExisteCategoriaFiscal(en.IdCategoriaFiscal) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe la Categoría Fiscal con IdCategoriaFiscal = {0}.", en.IdCategoriaFiscal), Entidades.Cliente.Columnas.IdCategoriaFiscal.ToString())
         End If

         If en.IdClienteCtaCte.IfNull() > 0 AndAlso Not cache.ExisteClientePorIdRapido(en.IdClienteCtaCte.IfNull()) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Cliente Cta. Cte. con IdCliente = {0}.", en.IdClienteCtaCte.IfNull()), "IdClienteCtaCte")
         End If

         If Not cache.ExisteEmpleado(en.IdCobrador) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe Cobrador con Id = = {0}.", en.IdCobrador), Entidades.Cliente.Columnas.IdCobrador.ToString())
         End If

         If Not cache.ExisteEmpleado(en.IdVendedor) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Cobrador con Id = {0}.", en.IdVendedor), Entidades.Cliente.Columnas.IdVendedor.ToString())
         End If

         If True Then
            Dim idDadoAltaPor As Integer = If(en.IdDadoAltaPor <> 0, en.IdDadoAltaPor, en.IdVendedor)
            en.IdDadoAltaPor = idDadoAltaPor
            If Not cache.ExisteEmpleado(en.IdDadoAltaPor) Then
               en.IdDadoAltaPor = en.IdVendedor
            End If
         End If

         If Not cache.ExisteEstadosClientes(en.IdEstado.IfNull()) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Estado de Cliente con IdEstadoCliente = {0}.", en.IdEstado), Entidades.Cliente.Columnas.IdEstado.ToString())
         End If

         If Not cache.ExisteListaDePrecios(en.IdListaPrecios) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Lista de Precios con IdListaPrecios = {0}.", en.IdListaPrecios), Entidades.Cliente.Columnas.IdListaPrecios.ToString())
         End If

         Dim existeLocalidad = Function(cache1 As BusquedasCacheadas, syncs1 As ServiciosRest.Sincronizacion.SyncBaseCollection, idLocalidad As Integer)
                                  If cache1.ExisteLocalidad(en.IdLocalidad) Then
                                     Return True
                                  End If
                                  Return GetCollection(Of Entidades.JSonEntidades.Archivos.LocalidadJSon)(syncs).Any(Function(x) x.IdLocalidad = idLocalidad)
                               End Function

         If Not existeLocalidad(cache, syncs, en.IdLocalidad) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe la Localidad con IdLocalidad = {0}.", en.IdLocalidad), Entidades.Cliente.Columnas.IdLocalidad.ToString())
         End If

         If True Then
            If en.IdLocalidadTrabajo.HasValue Then
               If Not existeLocalidad(cache, syncs, en.IdLocalidadTrabajo.IfNull()) Then
                  en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe la Localidad de Trabajo con IdLocalidad = {0}.", en.IdLocalidadTrabajo), Entidades.Cliente.Columnas.IdLocalidadTrabajo.ToString())
               End If
            End If
         End If

         If Not cache.ExisteEstadosClientes(en.IdTipoCliente) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Tipo de Cliente con IdTipoCliente = {0}.", en.IdTipoCliente), Entidades.Cliente.Columnas.IdTipoCliente.ToString())
         End If

         If Not String.IsNullOrWhiteSpace(en.IdTipoComprobante) AndAlso Not cache.ExisteTipoComprobante(en.IdTipoComprobante) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Tipo de Comprobante con IdTipoComprobante = {0}.", en.IdTipoComprobante), Entidades.Cliente.Columnas.IdTipoComprobante.ToString())
         End If

         If en.IdTipoDeExension.IfNull() <> 0 AndAlso Not cache.ExisteEstadosClientes(en.IdTipoDeExension.IfNull()) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Tipo de Exension con IdTipoDeExension = {0}.", en.IdTipoDeExension), "IdTipoDeExension")
         End If

         If en.IdTransportista.IfNull() <> 0 AndAlso Not cache.ExisteTransportista(en.IdTransportista.IfNull()) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Transportista con IdTransportista = {0}.", en.IdTransportista.IfNull()), Entidades.Cliente.Columnas.IdTransportista.ToString())
         End If

         If en.IdFormasPago.IfNull() <> 0 AndAlso Not cache.ExisteFormasPago(en.IdFormasPago.IfNull()) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Forma de Pago con IdFormasPago = {0}.", en.IdFormasPago), Entidades.Cliente.Columnas.IdFormasPago.ToString())
         End If

         If Not String.IsNullOrWhiteSpace(en.IdZonaGeografica) AndAlso Not cache.ExisteZonaGeografica(en.IdZonaGeografica) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Zona Geográfica con IdZonaGeografica = {0}.", en.IdZonaGeografica), Entidades.Cliente.Columnas.IdZonaGeografica.ToString())
         End If

         If en.IdBanco.IfNull() <> 0 AndAlso Not cache.ExisteBanco(en.IdBanco.IfNull()) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Banco con IdBanco = {0}.", en.IdBanco), Entidades.Cliente.Columnas.IdBanco.ToString())
         End If

         Dim sexo As Entidades.Cliente.SexoOpciones
         If Not [Enum].TryParse(en.Sexo, sexo) Then
            en.Sexo = Entidades.Cliente.SexoOpciones.NoAplica.ToString()
         End If

         SetEstadoRow(en, stbMensajeError, Function(x) cache.ExisteClientePorIdRapido(x.IdCliente))

         OnAvanceValidarDatos(eventArgs)
      Next

      Return CheckAlgunError(col)

   End Function

   Public Overrides Function ImportarDatos(transporte As List(Of Archivos.ClienteJSon)) As Boolean
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim sClientes As SqlServer.Clientes = New SqlServer.Clientes(da, ModoClienteProspecto)
         Dim rEmpleado As Reglas.Empleados = New Reglas.Empleados(da)
         Dim eventArgs As AvanceProcesarDatosEventArgs = New AvanceProcesarDatosEventArgs("Clientes")
         eventArgs.TotalRegistros = transporte.Count
         Dim maximoFechaActualizacion As DateTime? = Nothing
         For Each dr As Archivos.ClienteJSon In transporte
            eventArgs.RegistroActual += 1
            eventArgs.Datos = dr
            OnAvanceImportarDatos(eventArgs)

            Dim ExisteDadoAltaPor As Boolean = rEmpleado.ExisteEmpleado(dr.IdDadoAltaPor)
            If Not ExisteDadoAltaPor Then
               dr.IdDadoAltaPor = dr.IdVendedor
            End If
            If dr.IdDadoAltaPor = 0 Then dr.IdDadoAltaPor = dr.IdVendedor

            If dr.___Estado = "A" Then
               sClientes.Clientes_I(dr.IdCliente,
                                    dr.CodigoCliente,
                                    dr.NombreCliente.RecuperarCaracteresEspeciales(),
                                    dr.NombreDeFantasia.RecuperarCaracteresEspeciales(),
                                    dr.Direccion.RecuperarCaracteresEspeciales(),
                                    dr.DireccionAdicional.RecuperarCaracteresEspeciales(),
                                    dr.IdLocalidad,
                                    dr.Telefono,
                                    dr.FechaNacimiento.ToDateTime().IfNull(),
                                    dr.NroOperacion.IfNull(),
                                    dr.CorreoElectronico,
                                    dr.Celular,
                                    dr.NombreTrabajo.RecuperarCaracteresEspeciales(),
                                    dr.DireccionTrabajo.RecuperarCaracteresEspeciales(),
                                    dr.TelefonoTrabajo,
                                    dr.CorreoTrabajo,
                                    dr.IdLocalidadTrabajo.IfNull(),
                                    dr.FechaIngresoTrabajo.ToDateTime().IfNull(),
                                    dr.FechaAlta.ToDateTime().IfNull(),
                                    dr.SaldoPendiente.IfNull(),
                                    dr.IdClienteGarante.IfNull(),
                                    dr.IdCategoria,
                                    dr.IdCategoriaFiscal,
                                    dr.Cuit,
                                    dr.IdVendedor,
                                    dr.Observacion.RecuperarCaracteresEspeciales(),
                                    dr.IdListaPrecios,
                                    dr.IdZonaGeografica,
                                    dr.LimiteDeCredito,
                                    dr.SaldoLimiteDeCredito,
                                    dr.IdSucursalAsociada.IfNull(),
                                    dr.DescuentoRecargoPorc,
                                    dr.Activo,
                                    dr.IdTipoComprobante,
                                    dr.IdFormasPago.IfNull(),
                                    dr.IdTransportista.IfNull(),
                                    dr.IngresosBrutos,
                                    dr.InscriptoIBStaFe,
                                    dr.LocalIB,
                                    dr.ConvMultilateralIB,
                                    dr.NumeroLote.IfNull(),
                                    dr.IdCaja.IfNull(),
                                    dr.GeoLocalizacionLat.IfNull(),
                                    dr.GeoLocalizacionLng.IfNull(),
                                    dr.IdTipoDeExension.IfNull(),
                                    dr.AnioExension.IfNull(),
                                    dr.NroCertExension,
                                    dr.NroCertPropio,
                                    dr.TipoDocCliente,
                                    dr.NroDocCliente.IfNull(),
                                    dr.DescuentoRecargoPorc2.IfNull(),
                                    dr.IdClienteCtaCte.IfNull(),
                                    dr.PaginaWeb,
                                    dr.LimiteDiasVtoFactura,
                                    dr.ModificarDatos,
                                    dr.EsResidente,
                                    dr.CorreoAdministrativo,
                                    dr.IdEstado.IfNull(),
                                    dr.IdTipoCliente,
                                    dr.HoraInicio,
                                    dr.HoraFin,
                                    dr.HoraInicio2,
                                    dr.HoraFin2,
                                    dr.HoraSabInicio,
                                    dr.HoraSabFin,
                                    dr.HoraSabInicio2,
                                    dr.HoraSabFin2,
                                    dr.HoraDomInicio,
                                    dr.HoraDomFin,
                                    dr.HoraDomInicio2,
                                    dr.HoraDomFin2,
                                    dr.HorarioCorrido.IfNull(),
                                    dr.HorarioCorridoSab.IfNull(),
                                    dr.HorarioCorridoDom.IfNull(),
                                    dr.NroVersion,
                                    dr.FechaActualizacionVersion.ToDateTime(),
                                    dr.FechaInicio.ToDateTime(),
                                    dr.FechaInicioReal.ToDateTime(),
                                    dr.VencimientoLicencia.ToDateTime(),
                                    dr.BackupAutoCuenta,
                                    dr.BackupAutoConfig,
                                    dr.TienePreciosConIVA,
                                    dr.ConsultaPreciosConIVA,
                                    dr.TieneServidorDedicado,
                                    dr.MotorBaseDatos,
                                    dr.CantidadDePCs.IfNull(),
                                    dr.HorasCapacitacionPactadas.IfNull(),
                                    dr.HorasCapacitacionRealizadas.IfNull(),
                                    dr.CBU,
                                    dr.IdBanco.IfNull(),
                                    dr.IdCuentaBancariaClase.IfNull(),
                                    dr.NumeroCuentaBancaria,
                                    dr.CuitCtaBancaria,
                                    dr.UsaArchivoAImprimir2,
                                    dr.CantidadVisitas,
                                    dr.BackupNroVersion,
                                    dr.Facebook,
                                    dr.Instagram,
                                    dr.Twitter,
                                    dr.IdAplicacion,
                                    dr.Edicion,
                                    dr.RecibeNotificaciones,
                                    dr.Contacto,
                                    dr.FechaBaja.ToDateTime().IfNull(),
                                    dr.VerEnConsultas,
                                    dr.IdCalle,
                                    dr.Altura,
                                    dr.IdCalle2,
                                    dr.Altura2,
                                    dr.DireccionAdicional2,
                                    dr.TelefonosParticulares,
                                    dr.Fax,
                                    dr.FechaSUS.ToDateTime().IfNull(),
                                    dr.IdDadoAltaPor,
                                    dr.HabilitarVisita,
                                    dr.Direccion2,
                                    dr.IdLocalidad2,
                                    dr.ObservacionWeb,
                                    dr.RepartoIndependiente,
                                    dr.NivelAutorizacion,
                                    dr.IdCuentaContable,
                                    dr.EsClienteGenerico,
                                    dr.URLWebmovilPropio,
                                    dr.URLWebmovilAdminPropio,
                                    dr.URLSimovilGestionPropio,
                                    dr.URLActualizadorPropio,
                                    dr.NroVersionWebmovilPropio,
                                    dr.NroVersionWebmovilAdminPropio,
                                    dr.NroVersionSimovilGestionPropio,
                                    dr.NroVersionActualizadorPropio,
                                    dr.UtilizaAppSoporte,
                                    dr.CantidadLocal,
                                    dr.CantidadRemota,
                                    dr.CantidadMovil,
                                    dr.ObservacionAdministrativa,
                                    dr.CodigoClienteLetras,
                                    dr.SiMovilIdUsuario,
                                    dr.SiMovilClave,
                                    dr.Alicuota2deProducto,
                                    dr.CertificadoMiPyme,
                                    dr.FechaDesdeCertificado.ToDateTime(),
                                    dr.FechaHastaCertificado.ToDateTime(),
                                    dr.IdCobrador,
                                    dr.Sexo,
                                    dr.ValorizacionFacturacionMensual,
                                    dr.ValorizacionCoeficienteFacturacion,
                                    dr.ValorizacionImporteAdeudado,
                                    dr.ValorizacionCoeficienteDeuda,
                                    dr.ValorizacionProyecto,
                                    dr.ValorizacionProyectoObservacion,
                                    dr.PublicarEnWeb,
                                    dr.HorarioClienteCompleto,
                                    dr.IdClienteTiendaNube,
                                    dr.IdClienteMercadoLibre,
                                    dr.IdClienteArborea,
                                    dr.FechaCambioCategoria,
                                    dr.ObservacionCambioCategoria,
                                    dr.IdCategoriaCambio,
                                    dr.ActualizadorAptoParaInstalar,
                                    dr.ActualizadorFunciona.StringToEnum(Entidades.Cliente.FuncionaActualizador.PENDIENTE),
                                    dr.ActualizadorFechaInstalacion.ToDateTimeFormatoPropio(),
                                    dr.ActualizadorVersion,
                                    dr.IdImpositivoOtroPais,
                                    dr.IdConceptoCM05,
                                    dr.EsExentoPercIVARes53292023,
                                    dr.IdEstadoCivil,
                                    dr.VarPesosCotizDolar,
                                    monedaCredito:=Entidades.Moneda.Peso,
                                      dr.PublicarEnTiendaNube,
                                      dr.PublicarEnMercadoLibre,
                                      dr.PublicarEnArborea,
                                      dr.PublicarEnGestion,
                                      dr.PublicarEnEmpresarial,
                                      dr.PublicarEnSincronizacionSucursal)

            ElseIf dr.___Estado = "M" Then

               sClientes.Clientes_U(dr.IdCliente,
                                    dr.CodigoCliente,
                                    dr.NombreCliente.RecuperarCaracteresEspeciales(),
                                    dr.NombreDeFantasia.RecuperarCaracteresEspeciales(),
                                    dr.Direccion.RecuperarCaracteresEspeciales(),
                                    dr.DireccionAdicional.RecuperarCaracteresEspeciales(),
                                    dr.IdLocalidad,
                                    dr.Telefono,
                                    dr.FechaNacimiento.ToDateTime().IfNull(),
                                    dr.NroOperacion.IfNull(),
                                    dr.CorreoElectronico,
                                    dr.Celular,
                                    dr.NombreTrabajo.RecuperarCaracteresEspeciales(),
                                    dr.DireccionTrabajo.RecuperarCaracteresEspeciales(),
                                    dr.TelefonoTrabajo,
                                    dr.CorreoTrabajo,
                                    dr.IdLocalidadTrabajo.IfNull(),
                                    dr.FechaIngresoTrabajo.ToDateTime().IfNull(),
                                    dr.FechaAlta.ToDateTime().IfNull(),
                                    dr.SaldoPendiente.IfNull(),
                                    dr.IdClienteGarante.IfNull(),
                                    dr.IdCategoria,
                                    dr.IdCategoriaFiscal,
                                    dr.Cuit,
                                    dr.IdVendedor,
                                    dr.Observacion.RecuperarCaracteresEspeciales(),
                                    dr.IdListaPrecios,
                                    dr.IdZonaGeografica,
                                    dr.LimiteDeCredito,
                                    dr.SaldoLimiteDeCredito,
                                    dr.IdSucursalAsociada.IfNull(),
                                    dr.DescuentoRecargoPorc,
                                    dr.Activo,
                                    dr.IdTipoComprobante,
                                    dr.IdFormasPago.IfNull(),
                                    dr.IdTransportista.IfNull(),
                                    dr.IngresosBrutos,
                                    dr.InscriptoIBStaFe,
                                    dr.LocalIB,
                                    dr.ConvMultilateralIB,
                                    dr.NumeroLote.IfNull(),
                                    dr.IdCaja.IfNull(),
                                    dr.GeoLocalizacionLat.IfNull(),
                                    dr.GeoLocalizacionLng.IfNull(),
                                    dr.IdTipoDeExension.IfNull(),
                                    dr.AnioExension.IfNull(),
                                    dr.NroCertExension,
                                    dr.NroCertPropio,
                                    dr.TipoDocCliente,
                                    dr.NroDocCliente.IfNull(),
                                    dr.DescuentoRecargoPorc2.IfNull(),
                                    dr.IdClienteCtaCte.IfNull(),
                                    dr.PaginaWeb,
                                    dr.LimiteDiasVtoFactura,
                                    dr.ModificarDatos,
                                    dr.EsResidente,
                                    dr.CorreoAdministrativo,
                                    dr.IdEstado.IfNull(),
                                    dr.IdTipoCliente,
                                    dr.HoraInicio,
                                    dr.HoraFin,
                                    dr.HoraInicio2,
                                    dr.HoraFin2,
                                    dr.HoraSabInicio,
                                    dr.HoraSabFin,
                                    dr.HoraSabInicio2,
                                    dr.HoraSabFin2,
                                    dr.HoraDomInicio,
                                    dr.HoraDomFin,
                                    dr.HoraDomInicio2,
                                    dr.HoraDomFin2,
                                    dr.HorarioCorrido.IfNull(),
                                    dr.HorarioCorridoSab.IfNull(),
                                    dr.HorarioCorridoDom.IfNull(),
                                    dr.NroVersion,
                                    dr.FechaActualizacionVersion.ToDateTime(),
                                    dr.FechaInicio.ToDateTime(),
                                    dr.FechaInicioReal.ToDateTime(),
                                    dr.VencimientoLicencia.ToDateTime(),
                                    dr.BackupAutoCuenta,
                                    dr.BackupAutoConfig,
                                    dr.TienePreciosConIVA,
                                    dr.ConsultaPreciosConIVA,
                                    dr.TieneServidorDedicado,
                                    dr.MotorBaseDatos,
                                    dr.CantidadDePCs.IfNull(),
                                    dr.HorasCapacitacionPactadas.IfNull(),
                                    dr.HorasCapacitacionRealizadas.IfNull(),
                                    dr.CBU,
                                    dr.IdBanco.IfNull(),
                                    dr.IdCuentaBancariaClase.IfNull(),
                                    dr.NumeroCuentaBancaria,
                                    dr.CuitCtaBancaria,
                                    dr.UsaArchivoAImprimir2,
                                    dr.CantidadVisitas,
                                    dr.BackupNroVersion,
                                    dr.Facebook,
                                    dr.Instagram,
                                    dr.Twitter,
                                    dr.IdAplicacion,
                                    dr.Edicion,
                                    dr.RecibeNotificaciones,
                                    dr.Contacto,
                                    dr.FechaBaja.ToDateTime().IfNull(),
                                    dr.VerEnConsultas,
                                    dr.IdCalle,
                                    dr.Altura,
                                    dr.IdCalle2,
                                    dr.Altura2,
                                    dr.DireccionAdicional2,
                                    dr.TelefonosParticulares,
                                    dr.Fax,
                                    dr.FechaSUS.ToDateTime().IfNull(),
                                    dr.IdDadoAltaPor,
                                    dr.HabilitarVisita,
                                    dr.Direccion2,
                                    dr.IdLocalidad2,
                                    dr.ObservacionWeb,
                                    dr.RepartoIndependiente,
                                    dr.NivelAutorizacion,
                                    dr.IdCuentaContable,
                                    dr.EsClienteGenerico,
                                    dr.URLWebmovilPropio,
                                    dr.URLWebmovilAdminPropio,
                                    dr.URLSimovilGestionPropio,
                                    dr.URLActualizadorPropio,
                                    dr.NroVersionWebmovilPropio,
                                    dr.NroVersionWebmovilAdminPropio,
                                    dr.NroVersionSimovilGestionPropio,
                                    dr.NroVersionActualizadorPropio,
                                    dr.UtilizaAppSoporte,
                                    dr.CantidadLocal,
                                    dr.CantidadRemota,
                                    dr.CantidadMovil,
                                    dr.ObservacionAdministrativa,
                                    dr.CodigoClienteLetras,
                                    dr.SiMovilIdUsuario,
                                    dr.SiMovilClave,
                                    dr.Alicuota2deProducto,
                                    dr.CertificadoMiPyme,
                                    dr.FechaDesdeCertificado.ToDateTime(),
                                    dr.FechaHastaCertificado.ToDateTime(),
                                    dr.IdCobrador,
                                    dr.Sexo,
                                    dr.ValorizacionFacturacionMensual,
                                    dr.ValorizacionCoeficienteFacturacion,
                                    dr.ValorizacionImporteAdeudado,
                                    dr.ValorizacionCoeficienteDeuda,
                                    dr.ValorizacionProyecto,
                                    dr.ValorizacionProyectoObservacion,
                                    dr.PublicarEnWeb,
                                    dr.HorarioClienteCompleto,
                                    dr.IdClienteTiendaNube,
                                    dr.IdClienteMercadoLibre,
                                    dr.IdClienteArborea,
                                    dr.FechaCambioCategoria,
                                    dr.ObservacionCambioCategoria,
                                    dr.IdCategoriaCambio,
                                    dr.ActualizadorAptoParaInstalar,
                                    dr.ActualizadorFunciona.StringToEnum(Entidades.Cliente.FuncionaActualizador.PENDIENTE),
                                    dr.ActualizadorFechaInstalacion.ToDateTimeFormatoPropio(),
                                    dr.ActualizadorVersion,
                                    dr.IdImpositivoOtroPais,
                                    dr.IdConceptoCM05,
                                    dr.IdTipoComprobanteInvocacionMasiva,
                                    dr.EsExentoPercIVARes53292023, dr.IdEstadoCivil,
                                    dr.VarPesosCotizDolar,
                                    monedaCredito:=Entidades.Moneda.Peso,
                                      dr.PublicarEnTiendaNube,
                                      dr.PublicarEnMercadoLibre,
                                      dr.PublicarEnArborea,
                                      dr.PublicarEnGestion,
                                      dr.PublicarEnEmpresarial,
                                      dr.PublicarEnSincronizacionSucursal)

            End If

            dr.___Estado = "I"

            Dim fechaActualizacion As String = dr.FechaActualizacionWeb
            If IsDate(fechaActualizacion) Then
               Dim fecha As DateTime = DateTime.Parse(fechaActualizacion)
               If Not maximoFechaActualizacion.HasValue Then
                  maximoFechaActualizacion = fecha
               End If

               If fecha > maximoFechaActualizacion Then
                  maximoFechaActualizacion = fecha
               End If
            End If

            OnAvanceImportarDatos(eventArgs)

         Next
         If maximoFechaActualizacion.HasValue Then
            Publicos.WebArchivos.Clientes.GuardarFechaUltimaDescarga(maximoFechaActualizacion.Value, da)
         End If
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
      Return True
   End Function

   Public Sub ImportarDesdeWebSiga(dt As DataTable) Implements IRestServices.ImportarDesdeWebSiga
      ImportarDatos(dt.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.ClienteJSon)("DatosSyncronizados")))
   End Sub

   Public Function GetClientesJSonTransporte(fechaActualizacionDesde As DateTime?, modo As Entidades.Cliente.ModoClienteProspecto) As List(Of Entidades.JSonEntidades.Archivos.ClienteJSonTransporte)
      Dim datos As List(Of Entidades.JSonEntidades.Archivos.ClienteJSon) = GetClientesJSon(fechaActualizacionDesde, modo)
      Dim result As List(Of Entidades.JSonEntidades.Archivos.ClienteJSonTransporte) = New List(Of Entidades.JSonEntidades.Archivos.ClienteJSonTransporte)()
      Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()

      For Each jEntidad As Entidades.JSonEntidades.Archivos.ClienteJSon In datos
         Dim tProducto As Entidades.JSonEntidades.Archivos.ClienteJSonTransporte
         tProducto = New Entidades.JSonEntidades.Archivos.ClienteJSonTransporte(jEntidad.CuitEmpresa, actual.Sucursal.Id, jEntidad.IdCliente, jEntidad.FechaActualizacionWeb)
         tProducto.DatosCliente = serializer.Serialize(jEntidad)
         result.Add(tProducto)
      Next

      Return result
   End Function

   Public Sub ImportarDesdeWebSiga(Of T)(dtClientes As List(Of T)) Implements IRestServices.ImportarDesdeWebSiga
      Throw New NotImplementedException()
   End Sub

#End Region

#Region "Compartido con otras clases"
   Public Class AvanceProcesarDatosEventArgs
      Public Property Modulo As String
      Public Property RegistroActual As Long
      Public Property TotalRegistros As Long
      Public Property Datos As Object
      Public Sub New(modulo As String)
         Me.Modulo = modulo
      End Sub
   End Class

   Public Shared Sub SeteaValor(Of T)(dr As DataRow, key As String, valor As T, tipo As Type)
      If Not dr.Table.Columns.Contains(key) Then
         dr.Table.Columns.Add(key, tipo)
      End If
      If valor IsNot Nothing Then
         Try
            dr(key) = valor
         Catch ex As Exception
            dr(key) = DBNull.Value
         End Try
      End If
   End Sub
   Public Shared Function ObtieneValor(Of T)(dr As DataRow, key As String, defaultValue As T) As T
      Dim valor As Object
      If Not dr.Table.Columns.Contains(key) OrElse IsDBNull(dr(key)) Then
         Return defaultValue
      Else
         valor = dr(key) '.ToString()
      End If

      Try
         Dim result As T
         result = DirectCast(Convert.ChangeType(valor, GetType(T)), T)
         Return result
      Catch ex As Exception
         Return defaultValue
      End Try
   End Function
   Public Class ObtenerValorException
      Inherits Exception
      Public Property Datos As DataRow
      Public Sub New(message As String, innerException As System.Exception, datos As DataRow)
         MyBase.New(message, innerException)
         _Datos = datos
      End Sub
   End Class
#End Region

End Class