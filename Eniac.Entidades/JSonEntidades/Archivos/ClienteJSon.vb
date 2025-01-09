Namespace JSonEntidades.Archivos
   Public Class ClienteJSon
      Implements IValidable
      Public Property CuitEmpresa As String
      Public Property NombreCliente As String
      Public Property Direccion As String
      Public Property DireccionAdicional As String
      Public Property IdLocalidad As Integer
      Public Property Telefono As String
      Public Property FechaNacimiento As String
      Public Property NroOperacion As Integer?
      Public Property CorreoElectronico As String
      Public Property Celular As String
      Public Property NombreTrabajo As String
      Public Property DireccionTrabajo As String
      Public Property IdLocalidadTrabajo As Integer?
      Public Property TelefonoTrabajo As String
      Public Property CorreoTrabajo As String
      Public Property FechaIngresoTrabajo As String
      Public Property FechaAlta As String
      Public Property SaldoPendiente As Decimal?
      Public Property IdCategoria As Integer
      Public Property IdCategoriaFiscal As Short
      Public Property Cuit As String
      Public Property IdVendedor As Integer
      Public Property Observacion As String
      Public Property IdListaPrecios As Integer
      Public Property IdZonaGeografica As String
      Public Property Activo As Boolean
      Public Property LimiteDeCredito As Decimal
      Public Property SaldoLimiteDeCredito As Decimal
      Public Property IdSucursalAsociada As Integer?
      Public Property NombreDeFantasia As String
      Public Property DescuentoRecargoPorc As Decimal
      Public Property IdTipoComprobante As String
      Public Property IdFormasPago As Integer?
      Public Property IdTransportista As Integer?
      Public Property IngresosBrutos As String
      Public Property InscriptoIBStaFe As Boolean
      Public Property LocalIB As Boolean
      Public Property ConvMultilateralIB As Boolean
      Public Property NumeroLote As Long?
      Public Property IdCaja As Integer?
      Public Property GeoLocalizacionLat As Decimal?
      Public Property GeoLocalizacionLng As Decimal?
      Public Property IdTipoDeExension As Short?
      Public Property AnioExension As Integer?
      Public Property NroCertExension As String
      Public Property NroCertPropio As String
      Public Property IdCliente As Long
      Public Property CodigoCliente As Long
      Public Property IdClienteGarante As Long?
      Public Property TipoDocCliente As String
      Public Property NroDocCliente As Long?
      Public Property DescuentoRecargoPorc2 As Decimal?
      Public Property IdClienteCtaCte As Long?
      Public Property PaginaWeb As String
      Public Property LimiteDiasVtoFactura As Integer
      Public Property ModificarDatos As Boolean
      Public Property EsResidente As Boolean
      Public Property CorreoAdministrativo As String
      Public Property IdEstado As Integer?
      '  Public Property IdCobrador As Integer
      Public Property IdTipoCliente As Integer
      Public Property HoraInicio As String
      Public Property HoraFin As String
      Public Property HoraInicio2 As String
      Public Property HoraFin2 As String
      Public Property HoraSabInicio As String
      Public Property HoraSabFin As String
      Public Property HoraSabInicio2 As String
      Public Property HoraSabFin2 As String
      Public Property HoraDomInicio As String
      Public Property HoraDomFin As String
      Public Property HoraDomInicio2 As String
      Public Property HoraDomFin2 As String
      Public Property HorarioCorrido As Boolean?
      Public Property HorarioCorridoSab As Boolean?
      Public Property HorarioCorridoDom As Boolean?
      Public Property NroVersion As String
      Public Property FechaInicio As String
      Public Property FechaInicioReal As String
      Public Property VencimientoLicencia As String
      Public Property BackupAutoCuenta As String
      Public Property BackupAutoConfig As Boolean?
      Public Property BackupNroVersion As String
      Public Property TienePreciosConIVA As Boolean?
      Public Property ConsultaPreciosConIVA As Boolean?
      Public Property TieneServidorDedicado As Boolean?
      Public Property MotorBaseDatos As String
      Public Property CantidadDePCs As Integer?
      Public Property HorasCapacitacionPactadas As Integer?
      Public Property HorasCapacitacionRealizadas As Integer?

      Public Property UsaArchivoAImprimir2 As Boolean
      Public Property CantidadVisitas As Integer
      Public Property CBU As String
      Public Property IdBanco As Integer?
      Public Property IdCuentaBancariaClase As Integer?
      Public Property NumeroCuentaBancaria As String
      Public Property CuitCtaBancaria As String
      Public Property FechaActualizacionVersion As String
      Public Property FechaActualizacionWeb As String

      Public Property Facebook As String
      Public Property Instagram As String
      Public Property Twitter As String


      Public Property IdAplicacion As String
      Public Property Edicion As String
      Public Property RecibeNotificaciones As Boolean
      Public Property Contacto As String
      Public Property FechaBaja As String
      Public Property VerEnConsultas As Boolean
      Public Property IdCalle As Integer
      Public Property Altura As Integer
      Public Property IdCalle2 As Integer
      Public Property Altura2 As Integer
      Public Property DireccionAdicional2 As String
      Public Property TelefonosParticulares As String
      Public Property Fax As String
      Public Property FechaSUS As String
      Public Property IdDadoAltaPor As Integer
      'Public Property TipoDocDadoAltaPor As String
      'Public Property NroDocDadoAltaPor As String
      Public Property HabilitarVisita As Boolean
      Public Property Direccion2 As String
      Public Property IdLocalidad2 As Integer
      Public Property ObservacionWeb As String
      Public Property RepartoIndependiente As Boolean
      Public Property NivelAutorizacion As Short
      Public Property IdCuentaContable As Long
      Public Property EsClienteGenerico As Boolean

      Public Property URLWebmovilPropio As String
      Public Property URLWebmovilAdminPropio As String
      Public Property URLSimovilGestionPropio As String
      Public Property URLActualizadorPropio As String
      Public Property NroVersionWebmovilPropio As String
      Public Property NroVersionWebmovilAdminPropio As String
      Public Property NroVersionSimovilGestionPropio As String
      Public Property NroVersionActualizadorPropio As String

      Public Property ObservacionAdministrativa As String
      Public Property CodigoClienteLetras As String

      Public Property SiMovilIdUsuario As String
      Public Property SiMovilClave As String

      Public Property Alicuota2deProducto As String
      Public Property IdCobrador As Integer

      Public Property Sexo As String
      Public Property HorarioClienteCompleto As String
      Public Property IdClienteTiendaNube As String
      Public Property IdClienteMercadoLibre As String
      Public Property IdClienteArborea As String

      Public Property ValorizacionFacturacionMensual As Decimal
      Public Property ValorizacionCoeficienteFacturacion As Decimal
      Public Property ValorizacionFacturacion As Decimal
      Public Property ValorizacionImporteAdeudado As Decimal
      Public Property ValorizacionCoeficienteDeuda As Decimal
      Public Property ValorizacionDeuda As Decimal
      Public Property ValorizacionProyecto As Decimal
      Public Property ValorizacionProyectoObservacion As String
      Public Property ValorizacionCliente As Decimal
      Public Property ValorizacionEstrellas As Decimal

      Public Property PublicarEnWeb As Boolean

      Public Property UtilizaAppSoporte As Boolean
      Public Property CantidadLocal As Integer
      Public Property CantidadRemota As Integer
      Public Property CantidadMovil As Integer

      Public Property CertificadoMiPyme As Boolean
      Public Property FechaDesdeCertificado As String
      Public Property FechaHastaCertificado As String

      'PE-30972
      Public Property FechaCambioCategoria As Date?
      Public Property ObservacionCambioCategoria As String
      Public Property IdCategoriaCambio As Integer?

      Public Property ActualizadorAptoParaInstalar As Boolean
      Public Property ActualizadorFunciona As String
      Public Property ActualizadorFechaInstalacion As String
      Public Property ActualizadorVersion As String
      Public Property IdImpositivoOtroPais As String
      Public Property IdConceptoCM05 As Integer?
      Public Property IdTipoComprobanteInvocacionMasiva As String
      Public Property EsExentoPercIVARes53292023 As Boolean
      Public Property IdEstadoCivil As Integer

      Public Property VarPesosCotizDolar As Decimal?

      Public Property PublicarEnTiendaNube As Boolean
      Public Property PublicarEnMercadoLibre As Boolean
      Public Property PublicarEnArborea As Boolean
      Public Property PublicarEnGestion As Boolean
      Public Property PublicarEnEmpresarial As Boolean
      Public Property PublicarEnSincronizacionSucursal As Boolean

      'Por ahora ignoramos la foto. Tenemos que ver cual es la mejor opción 
      'porque puede (y seguramente va a pasar) explotar la interfase por tamaño.
      'Public Property Foto	image

      Public Property ConErrores As Boolean Implements IValidable.ConErrores
      Public Property ___Estado As String Implements IValidable.___Estado
      Public Property ___MensajeError As String Implements IValidable.___MensajeError

      Public Property drOrigen As DataRow Implements IValidable.drOrigen
   End Class

   Public Class ClienteJSonTransporte
      Inherits BaseJSonTransporte

      'Public Property CuitEmpresa As String
      Public Property IdCliente As String
      Public Property DatosCliente As String
      'Public Property FechaActualizacion As String

      Public Sub New()
      End Sub

      Public Sub New(cuitEmpresa As String, idSucursalEmpresa As Integer, idCliente As Long, fechaActualizacion As String)
         Me.CuitEmpresa = cuitEmpresa
         Me.IdSucursalEmpresa = idSucursalEmpresa
         Me.IdCliente = idCliente.ToString()
         Me.FechaActualizacion = fechaActualizacion
      End Sub

   End Class
End Namespace