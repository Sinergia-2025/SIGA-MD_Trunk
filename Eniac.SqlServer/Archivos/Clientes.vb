Public Class Clientes
   Inherits Comunes
   Private Property ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto

   Public Sub New(da As Eniac.Datos.DataAccess, ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto)
      MyBase.New(da)
      Me.ModoClienteProspecto = ModoClienteProspecto
   End Sub

   Public Sub Clientes_I(idCliente As Long,
                         codigoCliente As Long,
                         nombreCliente As String,
                         nombreDeFantasia As String,
                         direccion As String,
                         direccionAdicional As String,
                         idLocalidad As Integer,
                         telefono As String,
                         fechaNacimiento As Date,
                         nroOperacion As Integer,
                         correoElectronico As String,
                         celular As String,
                         nombreTrabajo As String,
                         direccionTrabajo As String,
                         telefonoTrabajo As String,
                         correoTrabajo As String,
                         idLocalidadTrabajo As Integer,
                         fechaIngresoTrabajo As Date,
                         fechaAlta As Date,
                         saldoPendiente As Double,
                         idClienteGarante As Long,
                         idCategoria As Integer,
                         idCategoriaFiscal As Short,
                         cuit As String,
                         IdVendedor As Integer,
                         observacion As String,
                         idListaPrecios As Integer,
                         idZonaGeografica As String,
                         limiteDeCredito As Double,
                         saldoLimiteDeCredito As Decimal,
                         idSucursalAsociada As Integer,
                         descuentoRecargoPorc As Decimal,
                         activo As Boolean,
                         idTipoComprobante As String,
                         idFormasPago As Integer,
                         idTransportista As Integer,
                         ingresosBrutos As String,
                         inscriptoIBStaFe As Boolean,
                         localIB As Boolean,
                         convMultilateralIB As Boolean,
                         numeroLote As Long,
                         idCaja As Integer,
                         geoLocalizacionLat As Double,
                         geoLocalizacionLng As Double,
                         idTipoDeExension As Short,
                         anioExension As Integer,
                         nroCertExension As String,
                         nroCertPropio As String,
                         tipoDocCliente As String,
                         nroDocCliente As Long,
                         descuentoRecargoPorc2 As Decimal,
                         idClienteCtaCte As Long,
                         paginaWeb As String,
                         limiteDiasVtoFactura As Integer,
                         modificarDatos As Boolean,
                         esResidente As Boolean,
                         correoAdministrativo As String,
                         idEstadoCliente As Integer,
                         idTipoCliente As Integer,
                         horaInicio As String,
                         horaFin As String,
                         horaInicio2 As String,
                         horaFin2 As String,
                         horaSabInicio As String,
                         horaSabFin As String,
                         horaSabInicio2 As String,
                         horaSabFin2 As String,
                         horaDomInicio As String,
                         horaDomFin As String,
                         horaDomInicio2 As String,
                         horaDomFin2 As String,
                         horarioCorrido As Boolean,
                         horarioCorridoSab As Boolean,
                         horarioCorridoDom As Boolean,
                         nroVersion As String,
                         fechaActualizacionVersion As Date?,
                         fechaInicio As Date?,
                         fechaInicioReal As Date?,
                         vencimientoLicencia As Date?,
                         backupAutoCuenta As String,
                         backupAutoConfig As Boolean?,
                         tienePreciosConIVA As Boolean?,
                         consultaPreciosConIVA As Boolean?,
                         tieneServidorDedicado As Boolean?,
                         motorBaseDatos As String,
                         cantidadDePCs As Integer,
                         horasCapacitacionPactadas As Integer,
                         horasCapacitacionRealizadas As Integer,
                         cBU As String,
                         idBanco As Integer,
                         idCuentaBancariaClase As Integer,
                         numeroCuentaBancaria As String,
                         cuitCtaBancaria As String,
                         usaArchivoAImprimir2 As Boolean,
                         cantidadVisitas As Integer,
                         backupNroVersion As String,
                         facebook As String,
                         instagram As String,
                         twitter As String,
                         idAplicacion As String,
                         edicion As String,
                         recibeNotificaciones As Boolean,
                         contacto As String,
                         fechaBaja As Date,
                         verEnConsultas As Boolean,
                         idCalle As Integer,
                         altura As Integer,
                         idCalle2 As Integer,
                         altura2 As Integer,
                         direccionAdicional2 As String,
                         telefonosParticulares As String,
                         fax As String,
                         fechaSUS As Date,
                         idDadoAltaPor As Integer,
                         habilitarVisita As Boolean,
                         direccion2 As String,
                         idLocalidad2 As Integer,
                         observacionWeb As String,
                         repartoIndependiente As Boolean,
                         nivelAutorizacion As Short,
                         idCuentaContable As Long,
                         esClienteGenerico As Boolean,
                         urlWebmovilPropio As String,
                         urlWebmovilAdminPropio As String,
                         urlSimovilGestionPropio As String,
                         urlActualizadorPropio As String,
                         nroVersionWebmovilPropio As String,
                         nroVersionWebmovilAdminPropio As String,
                         nroVersionSimovilGestionPropio As String,
                         nroVersionActualizadorPropio As String,
                         utilizaAppSoporte As Boolean,
                         cantidadLocal As Integer,
                         cantidadRemota As Integer,
                         cantidadMovil As Integer,
                         observacionAdministrativa As String,
                         codigoClienteLetras As String,
                         siMovilIdUsuario As String,
                         siMovilClave As String,
                         alicuota2deProducto As String,
                         certificadoMiPyme As Boolean,
                         fechaDesdeCertificado As Date?,
                         fechaHastaCertificado As Date?,
                         idCobrador As Integer,
                         sexo As String,
                         valorizacionFacturacionMensual As Decimal,
                         valorizacionCoeficienteFacturacion As Decimal,
                         valorizacionImporteAdeudado As Decimal,
                         valorizacionCoeficienteDeuda As Decimal,
                         valorizacionProyecto As Decimal,
                         valorizacionProyectoObservacion As String,
                         publicarEnWeb As Boolean,
                         horarioClienteCompleto As String,
                         idClienteTiendaNube As String,
                         idClienteMercadoLibre As String,
                         idClienteArborea As String,
                         fechaCambioCategoria As Date?,
                         observacionCambioCategoria As String,
                         idCategoriaCambio As Integer?,
                         actualizadorAptoParaInstalar As Boolean,
                         actualizadorFunciona As Entidades.Cliente.FuncionaActualizador,
                         actualizadorFechaInstalacion As Date?,
                         actualizadorVersion As String,
                         idImpositivoOtroPais As String,
                         idConceptoCM05 As Integer?,
                         EsExentoPercIVARes53292023 As Boolean,
                         idEstadoCivil As Integer,
                         VarPesosCotizDolar As Decimal?,
                         monedaCredito As Integer,
                          publicarEnTiendaNube As Boolean,
                          publicarEnMercadoLibre As Boolean,
                          publicarEnArborea As Boolean,
                          publicarEnGestion As Boolean,
                          publicarEnEmpresarial As Boolean,
                          publicarEnSincronizacionSucursal As Boolean)

      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0}s ", ModoClienteProspecto.ToString())
         .AppendFormat("(Id{0},", ModoClienteProspecto.ToString())
         .AppendFormat("Codigo{0},", ModoClienteProspecto.ToString())
         .AppendFormat("Nombre{0}, ", ModoClienteProspecto.ToString())
         .AppendLine("NombreDeFantasia, ")
         .AppendLine("Direccion, ")
         .AppendLine("DireccionAdicional,")
         .AppendLine("IdLocalidad, ")
         .AppendLine("Telefono, ")
         .AppendLine("FechaNacimiento, ")
         .AppendLine("NroOperacion, ")
         .AppendLine("CorreoElectronico, ")
         .AppendLine("Celular, ")
         .AppendLine("NombreTrabajo, ")
         .AppendLine("DireccionTrabajo, ")
         .AppendLine("TelefonoTrabajo, ")
         .AppendLine("CorreoTrabajo, ")
         .AppendLine("IdLocalidadTrabajo, ")
         .AppendLine("FechaIngresoTrabajo, ")
         .AppendLine("FechaAlta, ")
         .AppendLine("SaldoPendiente, ")
         .AppendFormat("Id{0}Garante,", ModoClienteProspecto.ToString())
         .AppendLine("IdCategoria,  ")
         .AppendLine("IdCategoriaFiscal, ")
         .AppendLine("Cuit, ")
         .AppendLine("IdVendedor, ")
         .AppendLine("Observacion, ")
         .AppendLine("idListaPrecios, ")
         .AppendLine("IdZonaGeografica, ")
         .AppendLine("LimiteDeCredito, ")
         .AppendLine("SaldoLimiteDeCredito,")
         .AppendLine("IdSucursalAsociada, ")
         .AppendLine("DescuentoRecargoPorc, ")
         .AppendLine("Activo, ")
         .AppendLine("IdTipoComprobante, ")
         .AppendLine("IdFormasPago, ")
         .AppendLine("IdTransportista,")
         .AppendLine("IngresosBrutos,")
         .AppendLine("InscriptoIBStaFe,")
         .AppendLine("LocalIB,")
         .AppendLine("ConvMultilateralIB,")
         .AppendLine("NumeroLote,")
         .AppendLine("IdCaja,")
         .AppendLine("GeoLocalizacionLat,")
         .AppendLine("GeoLocalizacionLng,")
         .AppendLine("IdTipoDeExension,")
         .AppendLine("AnioExension,")
         .AppendLine("NroCertExension,")
         .AppendLine("NroCertPropio,")
         .AppendFormat(" TipoDoc{0}, ", ModoClienteProspecto.ToString())
         .AppendFormat(" NroDoc{0},", ModoClienteProspecto.ToString())
         .AppendLine(" DescuentoRecargoPorc2, ")
         .AppendFormat(" Id{0}CtaCte,", ModoClienteProspecto.ToString())
         .AppendLine(" PaginaWeb,")
         .AppendLine(" LimiteDiasVtoFactura,")
         .AppendLine(" ModificarDatos,")
         .AppendLine(" EsResidente,")
         .AppendLine(" CorreoAdministrativo")
         .AppendLine(" ,IdEstado")
         .AppendLine(" ,IdTipoCliente")
         .AppendLine(" ,HoraInicio")
         .AppendLine(" ,HoraFin")
         .AppendLine(" ,HoraInicio2")
         .AppendLine(" ,HoraFin2")
         .AppendLine(" ,HoraSabInicio")
         .AppendLine(" ,HoraSabFin")
         .AppendLine(" ,HoraSabInicio2")
         .AppendLine(" ,HoraSabFin2")
         .AppendLine(" ,HoraDomInicio")
         .AppendLine(" ,HoraDomFin")
         .AppendLine(" ,HoraDomInicio2")
         .AppendLine(" ,HoraDomFin2")
         .AppendLine(" ,HorarioCorrido")
         .AppendLine(" ,HorarioCorridoSab")
         .AppendLine(" ,HorarioCorridoDom")
         .AppendLine(" ,NroVersion")
         .AppendLine(" ,FechaActualizacionVersion")
         .AppendLine(" ,FechaInicio")
         .AppendLine(" ,FechaInicioReal")
         .AppendLine(" ,VencimientoLicencia")
         .AppendLine(" ,BackupAutoCuenta")
         .AppendLine(" ,BackupAutoConfig")
         .AppendLine(" ,TienePreciosConIVA")
         .AppendLine(" ,ConsultaPreciosConIVA")
         .AppendLine(" ,TieneServidorDedicado")
         .AppendLine(" ,MotorBaseDatos")
         .AppendLine(" ,CantidadDePCs")
         .AppendLine(" ,HorasCapacitacionPactadas")
         .AppendLine(" ,HorasCapacitacionRealizadas")
         .AppendLine("           ,CBU")
         .AppendLine("           ,IdBanco")
         .AppendLine("           ,IdCuentaBancariaClase")
         .AppendLine("           ,NumeroCuentaBancaria")
         .AppendLine("           ,CuitCtaBancaria")
         .AppendLine("           ,UsaArchivoAImprimir2")
         .AppendLine("           ,CantidadVisitas")
         .AppendLine("           ,BackupNroVersion")

         .AppendLine("           ,Facebook")
         .AppendLine("           ,Instagram")
         .AppendLine("           ,Twitter")
         .AppendLine("           ,IdAplicacion")
         .AppendLine("           ,Edicion")
         .AppendLine("           ,RecibeNotificaciones")
         .AppendLine("       ,Contacto")
         .AppendLine("       ,FechaBaja")
         .AppendLine("       ,VerEnConsultas")
         .AppendLine("       ,IdCalle")
         .AppendLine("       ,Altura")
         .AppendLine("       ,IdCalle2")
         .AppendLine("       ,Altura2")
         .AppendLine("       ,DireccionAdicional2")
         .AppendLine("       ,TelefonosParticulares")
         .AppendLine("      ,Fax")
         .AppendLine("      ,FechaSUS")
         .AppendLine("      ,IdDadoAltaPor")
         .AppendLine("      ,HabilitarVisita")
         .AppendLine("      ,Direccion2")
         .AppendLine("      ,IdLocalidad2")
         .AppendLine("      ,ObservacionWeb")
         .AppendLine("      ,RepartoIndependiente")
         .AppendLine("      ,NivelAutorizacion")
         .AppendLine("      ,IdCuentaContable")
         .AppendLine("      ,EsClienteGenerico")

         .AppendLine("      ,URLWebmovilPropio")
         .AppendLine("      ,URLWebmovilAdminPropio")
         .AppendLine("      ,URLSimovilGestionPropio")
         .AppendLine("      ,URLActualizadorPropio")
         .AppendLine("      ,NroVersionWebmovilPropio")
         .AppendLine("      ,NroVersionWebmovilAdminPropio")
         .AppendLine("      ,NroVersionSimovilGestionPropio")
         .AppendLine("      ,NroVersionActualizadorPropio")

         .AppendLine("      ,UtilizaAppSoporte")
         .AppendLine("      ,CantidadLocal")
         .AppendLine("      ,CantidadRemota")
         .AppendLine("      ,CantidadMovil")
         .AppendLine("      ,ObservacionAdministrativa")
         .AppendFormat("    ,Codigo{0}Letras", ModoClienteProspecto.ToString())

         .AppendLine("      ,SiMovilIdUsuario")
         .AppendLine("      ,SiMovilClave")

         .AppendLine("      ,Alicuota2deProducto")
         .AppendLine("      ,CertificadoMiPyme")
         .AppendLine("      ,FechaDesdeCertificado")
         .AppendLine("      ,FechaHastaCertificado")
         .AppendLine("      ,IdCobrador")
         .AppendLine("      ,Sexo")

         .AppendLine("      ,ValorizacionFacturacionMensual")
         .AppendLine("      ,ValorizacionCoeficienteFacturacion")
         .AppendLine("      ,ValorizacionFacturacion")
         .AppendLine("      ,ValorizacionImporteAdeudado")
         .AppendLine("      ,ValorizacionCoeficienteDeuda")
         .AppendLine("      ,ValorizacionDeuda")
         .AppendLine("      ,ValorizacionProyecto")
         .AppendLine("      ,ValorizacionProyectoObservacion")
         .AppendFormatLine("      ,Valorizacion{0}", ModoClienteProspecto.ToString())
         .AppendLine("      ,ValorizacionEstrellas")
         .AppendLine("      ,PublicarEnWeb")
         .AppendLine("      ,HorarioClienteCompleto")
         .AppendFormatLine("      ,Id{0}TiendaNube", ModoClienteProspecto.ToString())
         .AppendFormatLine("      ,Id{0}MercadoLibre", ModoClienteProspecto.ToString())
         .AppendFormatLine("      ,Id{0}Arborea", ModoClienteProspecto.ToString())
         'PE-30972 -- 
         .AppendFormatLine("     ,FechaCambioCategoria")
         .AppendFormatLine("     ,ObservacionCambioCategoria")
         .AppendFormatLine("     ,IdCategoriaCambio")

         .AppendFormatLine("     ,ActualizadorAptoParaInstalar")
         .AppendFormatLine("     ,ActualizadorFunciona")
         .AppendFormatLine("     ,ActualizadorFechaInstalacion")
         .AppendFormatLine("     ,ActualizadorVersion")
         .AppendFormatLine("     ,IdImpositivoOtroPais")
         .AppendFormatLine("     ,IdConceptoCM05")
         .AppendFormatLine("     ,EsExentoPercIVARes53292023")
         .AppendFormatLine("     ,IdEstadoCivil")
         .AppendFormatLine("     ,VarPesosCotizDolar")
         .AppendFormatLine("     ,MonedaCredito")
         .AppendLine(" , PublicarEnTiendaNube")
         .AppendLine(" , PublicarEnMercadoLibre")
         .AppendLine(" , PublicarEnArborea")
         .AppendLine(" , PublicarEnGestion")
         .AppendLine(" , PublicarEnEmpresarial")
         .AppendLine(" , PublicarEnSincronizacionSucursal")

         .AppendLine(") VALUES (")

         .Append(idCliente.ToString() & ", ")
         .Append(codigoCliente.ToString() & ", ")

         .AppendLine("'" & nombreCliente & "', ")
         .AppendLine("'" & nombreDeFantasia & "', ")
         .AppendLine("'" & direccion & "', ")
         .AppendFormat("'{0}',", direccionAdicional)
         .AppendLine("" & idLocalidad.ToString() & ", ")
         .AppendLine("'" & telefono & "', ")
         If fechaNacimiento = Nothing Then
            .AppendLine("null, ")
         Else
            .AppendLine("'" & Me.ObtenerFecha(fechaNacimiento, False) & "', ")
         End If
         .AppendLine("'" & nroOperacion & "', ")
         .AppendLine("'" & correoElectronico & "', ")
         .AppendLine("'" & celular & "', ")
         .AppendLine("'" & nombreTrabajo & "', ")
         .AppendLine("'" & direccionTrabajo & "', ")
         .AppendLine("'" & telefonoTrabajo & "', ")
         .AppendLine("'" & correoTrabajo & "', ")
         If idLocalidadTrabajo > 0 Then
            .Append(idLocalidadTrabajo.ToString() & ", ")
         Else
            .AppendLine("NULL, ")
         End If
         .AppendLine("'" & Me.ObtenerFecha(fechaIngresoTrabajo, False) & "', ")
         .AppendLine("'" & Me.ObtenerFecha(fechaAlta, True) & "', ")
         .AppendLine("" & saldoPendiente.ToString() & ", ")

         If idClienteGarante > 0 Then
            .AppendLine("" & idClienteGarante & ", ")
         Else
            .AppendLine("null, ")
         End If

         .AppendLine(" " & idCategoria & ", ")
         .AppendLine(" " & idCategoriaFiscal & ", ")
         .AppendLine(" '" & cuit & "', ")
         .AppendLine(IdVendedor & ", ")
         .AppendLine(" '" & observacion & "', ")
         .Append(idListaPrecios.ToString() & ",")
         .AppendLine(" '" & idZonaGeografica & "', ")
         .Append(limiteDeCredito.ToString() & ", ")
         .AppendFormatLine("{0},", saldoLimiteDeCredito)
         If idSucursalAsociada > 0 Then
            .Append(idSucursalAsociada.ToString() & ", ")
         Else
            .AppendLine("NULL, ")
         End If

         .Append(descuentoRecargoPorc.ToString() & ", ")

         .AppendLine(" '" & activo.ToString() & "',")

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine(" '" & idTipoComprobante.ToString() & "', ")
         Else
            .AppendLine("NULL, ")
         End If

         If idFormasPago > 0 Then
            .Append(idFormasPago.ToString() & ", ")
         Else
            .AppendLine("NULL, ")
         End If

         If idTransportista > 0 Then
            .Append(idTransportista.ToString() & ", ")
         Else
            .AppendLine("NULL, ")
         End If
         If Not String.IsNullOrEmpty(ingresosBrutos) Then
            .AppendLine(" '" & ingresosBrutos.ToString() & "', ")
         Else
            .AppendLine("NULL, ")
         End If
         If inscriptoIBStaFe Then
            .AppendLine(" '" & inscriptoIBStaFe.ToString() & "',")
            .AppendLine(" '" & localIB.ToString() & "',")
            .AppendLine(" '" & convMultilateralIB.ToString() & "',")

         Else
            .AppendLine(" '" & inscriptoIBStaFe.ToString() & "',")
            .AppendLine(" 'False',")
            .AppendLine(" 'False',")
         End If
         If numeroLote > 0 Then
            .Append(numeroLote.ToString() & ",")
         Else
            .AppendLine("NULL, ")
         End If
         If idCaja > 0 Then
            .Append(idCaja.ToString() & ",")
         Else
            .AppendLine("NULL,")
         End If
         If geoLocalizacionLat <> 0 Then
            .Append(geoLocalizacionLat.ToString() & ",")
         Else
            .AppendLine("NULL,")
         End If
         If geoLocalizacionLng > 0 Then
            .Append(geoLocalizacionLng.ToString() & ",")
         Else
            .AppendLine("NULL,")
         End If
         'El 0 es Valido (NO Exento)
         If idTipoDeExension >= 0 Then
            .Append(idTipoDeExension.ToString() & ",")
         Else
            .AppendLine("NULL,")
         End If
         If anioExension > 0 Then
            .Append(anioExension.ToString() & ",")
         Else
            .AppendLine("NULL,")
         End If
         If Not String.IsNullOrEmpty(nroCertExension) Then
            .AppendLine(" '" & nroCertExension.ToString() & "', ")
         Else
            .AppendLine("NULL, ")
         End If
         If Not String.IsNullOrEmpty(nroCertPropio) Then
            .AppendLine(" '" & nroCertPropio.ToString() & "', ")
         Else
            .AppendLine("NULL, ")
         End If

         If nroDocCliente > 0 Then
            .AppendLine("'" & tipoDocCliente & "',")
            .AppendLine("" & nroDocCliente.ToString() & ",")
         Else
            .AppendLine("null, ")
            .AppendLine("null, ")
         End If
         .Append(descuentoRecargoPorc2.ToString() & ",")

         If idClienteCtaCte > 0 Then
            .Append(idClienteCtaCte & ",")
         Else
            .AppendLine("null, ")
         End If
         .AppendLine("'" & paginaWeb & "',")
         .Append(limiteDiasVtoFactura.ToString() & ",")
         .AppendLine("'" & modificarDatos & "',")
         .AppendLine("'" & esResidente & "', ")
         .AppendLine("'" & correoAdministrativo & "'")
         .AppendLine("," & idEstadoCliente.ToString())
         '  .AppendFormat(", {0}", idCobrador)
         .AppendFormat(", {0}", idTipoCliente)
         .AppendFormat(", '{0}'", horaInicio)
         .AppendFormat(", '{0}'", horaFin)
         .AppendFormat(", '{0}'", horaInicio2)
         .AppendFormat(", '{0}'", horaFin2)
         .AppendFormat(", '{0}'", horaSabInicio)
         .AppendFormat(", '{0}'", horaSabFin)
         .AppendFormat(", '{0}'", horaSabInicio2)
         .AppendFormat(", '{0}'", horaSabFin2)
         .AppendFormat(", '{0}'", horaDomInicio)
         .AppendFormat(", '{0}'", horaDomFin)
         .AppendFormat(", '{0}'", horaDomInicio2)
         .AppendFormat(", '{0}'", horaDomFin2)
         .AppendFormat(", '{0}'", Me.GetStringFromBoolean(horarioCorrido))
         .AppendFormat(", '{0}'", Me.GetStringFromBoolean(horarioCorridoSab))
         .AppendFormat(", '{0}'", Me.GetStringFromBoolean(horarioCorridoDom))
         .AppendFormat(", '{0}'", nroVersion)
         If fechaActualizacionVersion.HasValue Then
            .AppendFormat(", '{0}'", fechaActualizacionVersion.Value.ToString("yyyyMMdd HH:mm:ss"))
         Else
            .AppendFormat(", null")
         End If
         If fechaInicio.HasValue Then
            .AppendFormat(", '{0}'", fechaInicio.Value.ToString("yyyyMMdd HH:mm:ss"))
         Else
            .AppendFormat(", null")
         End If
         If fechaInicioReal.HasValue Then
            .AppendFormat(", '{0}'", fechaInicioReal.Value.ToString("yyyyMMdd HH:mm:ss"))
         Else
            .AppendFormat(", null")
         End If
         If vencimientoLicencia.HasValue Then
            .AppendFormat(", '{0}'", vencimientoLicencia.Value.ToString("yyyyMMdd HH:mm:ss"))
         Else
            .AppendFormat(", null")
         End If
         .AppendFormat(", '{0}'", backupAutoCuenta)
         .AppendFormat(", {0}", Me.GetStringFromBoolean(backupAutoConfig))
         .AppendFormat(", {0}", Me.GetStringFromBoolean(tienePreciosConIVA))
         .AppendFormat(", {0}", Me.GetStringFromBoolean(consultaPreciosConIVA))
         .AppendFormat(", {0}", Me.GetStringFromBoolean(tieneServidorDedicado))
         .AppendFormat(", '{0}'", motorBaseDatos)
         .AppendFormat(", {0}", cantidadDePCs)
         .AppendFormat(", {0}", horasCapacitacionPactadas)
         .AppendFormat(", {0}", horasCapacitacionRealizadas)

         If Not String.IsNullOrEmpty(cBU) Then
            .AppendFormat("           ,'{0}'", cBU)
         Else
            .AppendFormat("           ,null")
         End If

         If idBanco > 0 Then
            .AppendFormat("           ,{0}", idBanco)
         Else
            .AppendFormat("           ,null")
         End If

         If idCuentaBancariaClase > 0 Then
            .AppendFormat("           ,{0}", idCuentaBancariaClase)
         Else
            .AppendFormat("           ,null")
         End If

         If Not String.IsNullOrEmpty(numeroCuentaBancaria) Then
            .AppendFormat("           ,'{0}'", numeroCuentaBancaria)
         Else
            .AppendFormat("           ,null")
         End If

         If Not String.IsNullOrEmpty(cuitCtaBancaria) Then
            .AppendFormat("           ,'{0}'", cuitCtaBancaria)
         Else
            .AppendFormat("           ,null")
         End If

         .AppendFormat("           ,{0}", GetStringFromBoolean(usaArchivoAImprimir2))
         .AppendFormat("           ,{0}", cantidadVisitas).AppendLine()

         .AppendFormat("           ,'{0}'", backupNroVersion).AppendLine()

         .AppendFormatLine("           ,'{0}'", facebook)
         .AppendFormatLine("           ,'{0}'", instagram)
         .AppendFormatLine("           ,'{0}'", twitter)

         If Not String.IsNullOrEmpty(idAplicacion) Then
            .AppendFormatLine("           ,'{0}'", idAplicacion)
         Else
            .AppendFormat("           ,null")
         End If

         If Not String.IsNullOrEmpty(edicion) Then
            .AppendFormatLine("           ,'{0}'", edicion)
         Else
            .AppendFormat("           ,null")
         End If
         .AppendFormatLine("           ,'{0}'", recibeNotificaciones)
         If String.IsNullOrEmpty(contacto) Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", contacto)
         End If
         If fechaBaja = Nothing Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", fechaBaja.ToString("yyyyMMdd HH:mm:ss"))
         End If
         .AppendFormat("           ,{0}", Me.GetStringFromBoolean(verEnConsultas))
         .AppendFormat("           ,{0}", idCalle)
         .AppendFormat("           ,{0}", altura)
         .AppendFormat("           ,{0}", idCalle2)
         .AppendFormat("           ,{0}", altura2)
         If String.IsNullOrEmpty(direccionAdicional2) Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", direccionAdicional2)
         End If
         If String.IsNullOrEmpty(telefonosParticulares) Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", telefonosParticulares)
         End If
         If String.IsNullOrEmpty(fax) Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", fax)
         End If
         If fechaSUS = Nothing Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", fechaSUS.ToString("yyyyMMdd HH:mm:ss"))
         End If
         If String.IsNullOrEmpty(idDadoAltaPor.ToString()) Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,{0}", idDadoAltaPor)
         End If
         .AppendFormat("           ,{0}", Me.GetStringFromBoolean(habilitarVisita))
         .AppendFormat("           ,'{0}'", direccion2)
         .AppendFormat("           ,{0}", idLocalidad2)
         .AppendLine(",'" + observacionWeb + "'")
         .AppendFormat("           ,{0}", Me.GetStringFromBoolean(repartoIndependiente))
         .AppendFormatLine("  ,{0}", nivelAutorizacion)
         .AppendFormatLine("  ,{0}", GetStringFromNumber(idCuentaContable))
         .AppendFormatLine(", '{0}'", Me.GetStringFromBoolean(esClienteGenerico))

         .AppendFormatLine("      ,'{0}'", urlWebmovilPropio)
         .AppendFormatLine("      ,'{0}'", urlWebmovilAdminPropio)
         .AppendFormatLine("      ,'{0}'", urlSimovilGestionPropio)
         .AppendFormatLine("      ,'{0}'", urlActualizadorPropio)
         .AppendFormatLine("      ,'{0}'", nroVersionWebmovilPropio)
         .AppendFormatLine("      ,'{0}'", nroVersionWebmovilAdminPropio)
         .AppendFormatLine("      ,'{0}'", nroVersionSimovilGestionPropio)
         .AppendFormatLine("      ,'{0}'", nroVersionActualizadorPropio)

         .AppendFormatLine(", '{0}'", Me.GetStringFromBoolean(utilizaAppSoporte))
         .AppendFormatLine(",  {0}", cantidadLocal)
         .AppendFormatLine(",  {0}", cantidadRemota)
         .AppendFormatLine(",  {0}", cantidadMovil)
         .AppendFormatLine(", '{0}'", observacionAdministrativa)
         .AppendFormatLine(", '{0}'", codigoClienteLetras)

         .AppendFormatLine(", '{0}'", siMovilIdUsuario)
         .AppendFormatLine(", '{0}'", siMovilClave)

         .AppendFormatLine("  ,'{0}'", alicuota2deProducto)

         .AppendFormatLine(", '{0}'", Me.GetStringFromBoolean(certificadoMiPyme))

         If fechaDesdeCertificado.HasValue Then
            .AppendFormat(", '{0}'", ObtenerFecha(fechaDesdeCertificado.Value, False))
         Else
            .AppendFormat(", null")
         End If
         If fechaHastaCertificado.HasValue Then
            .AppendFormat(", '{0}'", ObtenerFecha(fechaHastaCertificado.Value, False))
         Else
            .AppendFormat(", null")
         End If

         .AppendFormat(", {0}", idCobrador)

         .AppendFormatLine("  ,'{0}'", sexo)

         .AppendFormatLine(",  {0}", valorizacionFacturacionMensual)
         .AppendFormatLine(",  {0}", valorizacionCoeficienteFacturacion)
         .AppendFormatLine(",  {0}", 0)
         .AppendFormatLine(",  {0}", valorizacionImporteAdeudado)
         .AppendFormatLine(",  {0}", valorizacionCoeficienteDeuda)
         .AppendFormatLine(",  {0}", 0)
         .AppendFormatLine(",  {0}", valorizacionProyecto)
         .AppendFormatLine(", '{0}'", valorizacionProyectoObservacion)
         .AppendFormatLine(",  {0}", 0)
         .AppendFormatLine(",  {0}", 0)

         .AppendFormatLine("  ,'{0}'", publicarEnWeb)

         If Not String.IsNullOrEmpty(horarioClienteCompleto) Then
            .AppendFormatLine("  ,'{0}'", horarioClienteCompleto)
         Else
            .AppendFormatLine("  ,NULL")
         End If

         If Not String.IsNullOrEmpty(idClienteTiendaNube) Then
            .AppendFormatLine("  ,'{0}'", idClienteTiendaNube)
         Else
            .AppendFormatLine("  , NULL")
         End If
         If Not String.IsNullOrEmpty(idClienteMercadoLibre) Then
            .AppendFormatLine("  ,'{0}'", idClienteMercadoLibre)
         Else
            .AppendFormatLine("  , NULL")
         End If
         If Not String.IsNullOrEmpty(idClienteArborea) Then
            .AppendFormatLine("  ,'{0}'", idClienteArborea)
         Else
            .AppendFormatLine("  , NULL")
         End If
         'PE-30972 -- 
         If fechaCambioCategoria.HasValue Then
            .AppendFormat("  , '{0}'", ObtenerFecha(fechaCambioCategoria.Value, False))
         Else
            .AppendFormat("  , NULL")
         End If

         If Not String.IsNullOrEmpty(observacionCambioCategoria) Then
            .AppendFormatLine("  ,'{0}'", observacionCambioCategoria)
         Else
            .AppendFormatLine("  , NULL")
         End If

         If Not String.IsNullOrEmpty(idCategoriaCambio.ToString()) Then
            .AppendFormat("  , {0}", idCategoria)
         Else
            .AppendFormat("  , NULL")
         End If

         .AppendFormatLine("  ,  {0} ", GetStringFromBoolean(actualizadorAptoParaInstalar))
         .AppendFormatLine("  , '{0}'", actualizadorFunciona.ToString())
         .AppendFormatLine("  ,  {0} ", ObtenerFecha(actualizadorFechaInstalacion, False))
         .AppendFormatLine("  , '{0}'", actualizadorVersion)

         .AppendFormatLine("  , '{0}'", idImpositivoOtroPais)

         .AppendFormatLine("  ,  {0} ", GetStringFromNumber(idConceptoCM05))

         .AppendFormatLine("  ,  {0} ", GetStringFromBoolean(EsExentoPercIVARes53292023))

         .AppendFormat("  , {0}", idEstadoCivil)
         If Not String.IsNullOrEmpty(VarPesosCotizDolar.ToString()) Then
            .AppendFormat("  , {0}", VarPesosCotizDolar)
         Else
            .AppendFormat("  , NULL")
         End If
         .AppendFormatLine("  ,  {0} ", monedaCredito)

         .AppendFormatLine(", {0}", GetStringFromBoolean(publicarEnTiendaNube))
         .AppendFormatLine(", {0}", GetStringFromBoolean(publicarEnMercadoLibre))
         .AppendFormatLine(", {0}", GetStringFromBoolean(publicarEnArborea))
         .AppendFormatLine(", {0}", GetStringFromBoolean(publicarEnGestion))
         .AppendFormatLine(", {0}", GetStringFromBoolean(publicarEnEmpresarial))
         .AppendFormatLine(", {0}", GetStringFromBoolean(publicarEnSincronizacionSucursal))
         .AppendLine(")")

      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Clientes")

   End Sub

   Public Sub Clientes_U(idCliente As Long,
                         codigoCliente As Long,
                         nombreCliente As String,
                         nombreDeFantasia As String,
                         direccion As String,
                         direccionAdicional As String,
                         idLocalidad As Integer,
                         telefono As String,
                         fechaNacimiento As Date,
                         nroOperacion As Integer,
                         correoElectronico As String,
                         celular As String,
                         nombreTrabajo As String,
                         direccionTrabajo As String,
                         telefonoTrabajo As String,
                         correoTrabajo As String,
                         idLocalidadTrabajo As Integer,
                         fechaIngresoTrabajo As Date,
                         fechaAlta As Date,
                         saldoPendiente As Double,
                         idClienteGarante As Long,
                         idCategoria As Integer,
                         idCategoriaFiscal As Short,
                         cuit As String,
                         IdVendedor As Integer,
                         observacion As String,
                         idListaPrecios As Integer,
                         idZonaGeografica As String,
                         limiteDeCredito As Double,
                         saldoLimiteDeCredito As Decimal,
                         idSucursalAsociada As Integer,
                         descuentoRecargoPorc As Decimal,
                         activo As Boolean,
                         idTipoComprobante As String,
                         idFormasPago As Integer,
                         idTransportista As Integer,
                         ingresosBrutos As String,
                         inscriptoIBStaFe As Boolean,
                         localIB As Boolean,
                         convMultilateralIB As Boolean,
                         numeroLote As Long,
                         idCaja As Integer,
                         geoLocalizacionLat As Double,
                         geoLocalizacionLng As Double,
                         idTipoDeExension As Short,
                         anioExension As Integer,
                         nroCertExension As String,
                         nroCertPropio As String,
                         tipoDocCliente As String,
                         nroDocCliente As Long,
                         descuentoRecargoPorc2 As Decimal,
                         idClienteCtaCte As Long,
                         paginaWeb As String,
                         limiteDiasVtoFactura As Integer,
                         modificarDatos As Boolean,
                         esResidente As Boolean,
                         correoAdministrativo As String,
                         idEstadoCliente As Integer,
                         idTipoCliente As Integer,
                         horaInicio As String,
                         horaFin As String,
                         horaInicio2 As String,
                         horaFin2 As String,
                         horaSabInicio As String,
                         horaSabFin As String,
                         horaSabInicio2 As String,
                         horaSabFin2 As String,
                         horaDomInicio As String,
                         horaDomFin As String,
                         horaDomInicio2 As String,
                         horaDomFin2 As String,
                         horarioCorrido As Boolean,
                         horarioCorridoSab As Boolean,
                         horarioCorridoDom As Boolean,
                         nroVersion As String,
                         fechaActualizacionVersion As Date?,
                         fechaInicio As Date?,
                         fechaInicioReal As Date?,
                         vencimientoLicencia As Date?,
                         backupAutoCuenta As String,
                         backupAutoConfig As Boolean?,
                         tienePreciosConIVA As Boolean?,
                         consultaPreciosConIVA As Boolean?,
                         tieneServidorDedicado As Boolean?,
                         motorBaseDatos As String,
                         cantidadDePCs As Integer,
                         horasCapacitacionPactadas As Integer,
                         horasCapacitacionRealizadas As Integer,
                         cBU As String,
                         idBanco As Integer,
                         idCuentaBancariaClase As Integer,
                         numeroCuentaBancaria As String,
                         cuitCtaBancaria As String,
                         usaArchivoAImprimir2 As Boolean,
                         cantidadVisitas As Integer,
                         backupNroVersion As String,
                         facebook As String,
                         instagram As String,
                         twitter As String,
                         idAplicacion As String,
                         edicion As String,
                         recibeNotificaciones As Boolean,
                         contacto As String,
                         fechaBaja As Date,
                         verEnConsultas As Boolean,
                         idCalle As Integer,
                         altura As Integer,
                         idCalle2 As Integer,
                         altura2 As Integer,
                         direccionAdicional2 As String,
                         telefonosParticulares As String,
                         fax As String,
                         fechaSUS As Date,
                         IdDadoAltaPor As Integer,
                         habilitarVisita As Boolean,
                         direccion2 As String,
                         idLocalidad2 As Integer,
                         observacionWeb As String,
                         repartoIndependiente As Boolean,
                         nivelAutorizacion As Short,
                         idCuentaContable As Long,
                         esClienteGenerico As Boolean,
                         urlWebmovilPropio As String,
                         urlWebmovilAdminPropio As String,
                         urlSimovilGestionPropio As String,
                         urlActualizadorPropio As String,
                         nroVersionWebmovilPropio As String,
                         nroVersionWebmovilAdminPropio As String,
                         nroVersionSimovilGestionPropio As String,
                         nroVersionActualizadorPropio As String,
                         utilizaAppSoporte As Boolean,
                         cantidadLocal As Integer,
                         cantidadRemota As Integer,
                         cantidadMovil As Integer,
                         observacionAdministrativa As String,
                         codigoClienteLetras As String,
                         siMovilIdUsuario As String,
                         siMovilClave As String,
                         alicuota2deProducto As String,
                         certificadoMiPyme As Boolean,
                         fechaDesdeCertificado As Date?,
                         fechaHastaCertificado As Date?,
                         idCobrador As Integer,
                         sexo As String,
                         valorizacionFacturacionMensual As Decimal,
                         valorizacionCoeficienteFacturacion As Decimal,
                         valorizacionImporteAdeudado As Decimal,
                         valorizacionCoeficienteDeuda As Decimal,
                         valorizacionProyecto As Decimal,
                         valorizacionProyectoObservacion As String,
                         publicarEnWeb As Boolean,
                         horarioClienteCompleto As String,
                         idClienteTiendaNube As String,
                         idClienteMercadoLibre As String,
                         idClienteArborea As String,
                         fechaCambioCategoria As Date?,
                         observacionCambioCategoria As String,
                         idCategoriaCambio As Integer?,
                         actualizadorAptoParaInstalar As Boolean,
                         actualizadorFunciona As Entidades.Cliente.FuncionaActualizador,
                         actualizadorFechaInstalacion As Date?,
                         actualizadorVersion As String,
                         idImpositivoOtroPais As String,
                         idConceptoCM05 As Integer?,
                         idTipoComprobanteInvocacionMasiva As String,
                         EsExentoPercIVARes53292023 As Boolean,
                         idEstadoCivil As Integer,
                         VarPesosCotizDolar As Decimal?,
                         monedaCredito As Integer,
                          publicarEnTiendaNube As Boolean,
                          publicarEnMercadoLibre As Boolean,
                          publicarEnArborea As Boolean,
                          publicarEnGestion As Boolean,
                          publicarEnEmpresarial As Boolean,
                          publicarEnSincronizacionSucursal As Boolean)

      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}s ", ModoClienteProspecto.ToString()).AppendLine()
         .AppendFormat("   SET Codigo{0} = {1}", ModoClienteProspecto.ToString(), codigoCliente.ToString()).AppendLine()
         .AppendFormat("     , Nombre{0} = '{1}'", ModoClienteProspecto.ToString(), nombreCliente).AppendLine()
         .AppendLine("     , NombreDeFantasia = '" & nombreDeFantasia & "'")
         .AppendLine("     , Direccion = '" & direccion & "'")
         .AppendFormatLine("     ,DireccionAdicional = '{0}'", direccionAdicional)
         .AppendLine("     , IdLocalidad = " & idLocalidad & "")
         .AppendLine("     , Telefono = '" & telefono & "'")
         .AppendLine("     , FechaNacimiento = '" & Me.ObtenerFecha(fechaNacimiento, False) & "'")
         .AppendLine("     , NroOperacion = " & nroOperacion.ToString())
         .AppendLine("     , CorreoElectronico = '" & correoElectronico & "'")
         .AppendLine("     , Celular = '" & celular & "'")
         .AppendLine("     , NombreTrabajo = '" & nombreTrabajo & "'")
         .AppendLine("     , DireccionTrabajo = '" & direccionTrabajo & "'")
         .AppendLine("     , TelefonoTrabajo = '" & telefonoTrabajo & "'")
         .AppendLine("     , CorreoTrabajo = '" & correoTrabajo & "'")

         .AppendLine("     , MonedaCredito = " & monedaCredito.ToString())

         If idLocalidadTrabajo > 0 Then
            .AppendLine("     , IdLocalidadTrabajo = " & idLocalidadTrabajo.ToString())
         Else
            .AppendLine("     , IdLocalidadTrabajo = NULL")
         End If

         .AppendLine("     , FechaIngresoTrabajo = '" & Me.ObtenerFecha(fechaIngresoTrabajo, False) & "'")
         .AppendLine("     , FechaAlta = '" & Me.ObtenerFecha(fechaAlta, True) & "'")
         .AppendLine("     , SaldoPendiente = " & saldoPendiente.ToString())

         If idClienteGarante > 0 Then
            .AppendFormat(", Id{0}Garante = {1}", ModoClienteProspecto.ToString(), idClienteGarante).AppendLine()
         Else
            .AppendFormat(", Id{0}Garante = NULL ", ModoClienteProspecto.ToString())
         End If

         .AppendLine(", IdCategoria = " & idCategoria.ToString())
         .AppendLine(", IdCategoriaFiscal = " & idCategoriaFiscal.ToString())

         If cuit.Trim().Length > 0 Then
            .AppendLine(", Cuit = '" & cuit & "' ")
         Else
            .AppendLine(", Cuit = NULL ")
         End If

         .AppendLine(", IdVendedor = " & IdVendedor)

         If observacion.Trim().Length > 0 Then
            .AppendLine(", Observacion = '" & observacion & "' ")
         Else
            .AppendLine(", Observacion = NULL ")
         End If

         .AppendLine(", idEstadoCivil = " & idEstadoCivil)

         .AppendLine(", idListaPrecios = " & idListaPrecios.ToString())
         .AppendLine(", IdZonaGeografica = '" & idZonaGeografica & "'")

         .AppendLine(", LimiteDeCredito = " & limiteDeCredito.ToString())
         .AppendFormatLine(", SaldoLimiteDeCredito = {0}", saldoLimiteDeCredito)

         If idSucursalAsociada > 0 Then
            .AppendLine(", idSucursalAsociada = " & idSucursalAsociada.ToString())
         Else
            .AppendLine(", idSucursalAsociada = NULL ")
         End If

         .AppendLine(", DescuentoRecargoPorc = " & descuentoRecargoPorc.ToString())

         .AppendLine(", Activo = '" & activo.ToString() & "'")

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine(", IdTipoComprobante = '" & idTipoComprobante & "'")
         Else
            .AppendLine(", IdTipoComprobante = NULL ")
         End If

         If Not String.IsNullOrEmpty(idTipoComprobanteInvocacionMasiva) Then
            .AppendLine(", IdTipoComprobanteInvocacionMasiva = '" & idTipoComprobanteInvocacionMasiva & "'")
         Else
            .AppendLine(", IdTipoComprobanteInvocacionMasiva = NULL ")
         End If

         If idFormasPago > 0 Then
            .AppendLine(", idFormasPago = " & idFormasPago.ToString())
         Else
            .AppendLine(", idFormasPago = NULL ")
         End If

         If idTransportista > 0 Then
            .AppendLine(", IdTransportista = " & idTransportista.ToString())
         Else
            .AppendLine(", IdTransportista = NULL ")

         End If
         If Not String.IsNullOrEmpty(ingresosBrutos) Then
            .AppendLine(", IngresosBrutos = '" & ingresosBrutos & "'")
         Else
            .AppendLine(", IngresosBrutos = NULL ")
         End If
         If inscriptoIBStaFe Then
            .AppendLine(", InscriptoIBStaFe = '" & inscriptoIBStaFe.ToString() & "'")
            .AppendLine(", LocalIB = '" & localIB.ToString() & "'")
            .AppendLine(", ConvMultilateralIB = '" & convMultilateralIB.ToString() & "'")
         Else
            .AppendLine(", InscriptoIBStaFe = '" & inscriptoIBStaFe.ToString() & "'")
            .AppendLine(", LocalIB = 'False'")
            .AppendLine(", ConvMultilateralIB = 'False'")
         End If
         If numeroLote > 0 Then
            .AppendLine(", NumeroLote = " & numeroLote.ToString())
         Else
            .AppendLine(", NumeroLote = NULL ")
         End If
         If idCaja > 0 Then
            .AppendLine(", IdCaja = " & idCaja.ToString())
         Else
            .AppendLine(", IdCaja = NULL ")
         End If

         If geoLocalizacionLat <> 0 Then
            .AppendLine(", GeoLocalizacionLat = " & geoLocalizacionLat.ToString())
         Else
            .AppendLine(", GeoLocalizacionLat = NULL ")
         End If

         If geoLocalizacionLng <> 0 Then
            .AppendLine(", GeoLocalizacionLng = " & geoLocalizacionLng.ToString())
         Else
            .AppendLine(", GeoLocalizacionLng = NULL ")
         End If
         'El 0 es Valido (NO Exento)
         If idTipoDeExension >= 0 Then
            .AppendLine(", IdTipoDeExension = " & idTipoDeExension.ToString())
         Else
            .AppendLine(", IdTipoDeExension = NULL ")
         End If
         If anioExension <> 0 And inscriptoIBStaFe = True Then
            .AppendLine(", AnioExension = " & anioExension.ToString())
         Else
            .AppendLine(", AnioExension = NULL ")
         End If
         If Not String.IsNullOrEmpty(nroCertExension) And inscriptoIBStaFe = True Then
            .AppendLine(", NroCertExension = '" & nroCertExension & "'")
         Else
            .AppendLine(", NroCertExension = NULL ")
         End If
         If Not String.IsNullOrEmpty(nroCertPropio) And inscriptoIBStaFe = True Then
            .AppendLine(", NroCertPropio = '" & nroCertPropio & "'")
         Else
            .AppendLine(", NroCertPropio = NULL ")
         End If

         If nroDocCliente > 0 Then
            .AppendFormat(" ,TipoDoc{0} = '{1}'", ModoClienteProspecto.ToString(), tipoDocCliente).AppendLine()
            .AppendFormat(" ,NroDoc{0} = {1}", ModoClienteProspecto.ToString(), nroDocCliente.ToString()).AppendLine()
         Else
            .AppendFormat(", TipoDoc{0} = NULL ", ModoClienteProspecto.ToString()).ToString()
            .AppendFormat(", NroDoc{0} = NULL ", ModoClienteProspecto.ToString()).ToString()
         End If

         .AppendLine(", DescuentoRecargoPorc2 = " & descuentoRecargoPorc2.ToString())

         If idClienteCtaCte > 0 Then
            .AppendFormat(" ,Id{0}CtaCte = {1}", ModoClienteProspecto.ToString(), idClienteCtaCte).AppendLine()
         Else
            .AppendFormat(", Id{0}CtaCte = NULL ", ModoClienteProspecto.ToString()).AppendLine()
         End If

         .AppendLine(", paginaWeb = '" + paginaWeb + "'")
         .AppendLine(", LimiteDiasVtoFactura = " & limiteDiasVtoFactura.ToString())
         .AppendLine(", ModificarDatos = '" & modificarDatos.ToString() & "'")
         .AppendLine(", EsResidente = '" & esResidente.ToString() & "'")
         .AppendLine(", CorreoAdministrativo = '" & correoAdministrativo & "'")
         .AppendLine(", IdEstado = " & idEstadoCliente.ToString())
         '   .AppendFormat(", IdCobrador = {0}", idCobrador)
         .AppendFormat(", IdTipoCliente = {0}", idTipoCliente)
         .AppendFormat(", HoraInicio = '{0}'", horaInicio)
         .AppendFormat(", HoraFin = '{0}'", horaFin)
         .AppendFormat(", HoraInicio2 = '{0}'", horaInicio2)
         .AppendFormat(", HoraFin2 = '{0}'", horaFin2)
         .AppendFormat(", HoraSabInicio = '{0}'", horaSabInicio)
         .AppendFormat(", HoraSabFin = '{0}'", horaSabFin)
         .AppendFormat(", HoraSabInicio2 = '{0}'", horaSabInicio2)
         .AppendFormat(", HoraSabFin2 = '{0}'", horaSabFin2)
         .AppendFormat(", HoraDomInicio = '{0}'", horaDomInicio)
         .AppendFormat(", HoraDomFin = '{0}'", horaDomFin)
         .AppendFormat(", HoraDomInicio2 = '{0}'", horaDomInicio2)
         .AppendFormat(", HoraDomFin2 = '{0}'", horaDomFin2)
         .AppendFormat(", HorarioCorrido = '{0}'", Me.GetStringFromBoolean(horarioCorrido))
         .AppendFormat(", HorarioCorridoSab = '{0}'", Me.GetStringFromBoolean(horarioCorridoSab))
         .AppendFormat(", HorarioCorridoDom = '{0}'", Me.GetStringFromBoolean(horarioCorridoDom))
         .AppendFormat(", NroVersion = '{0}'", nroVersion)
         If fechaActualizacionVersion.HasValue Then
            .AppendFormat(", FechaActualizacionVersion = '{0}'", fechaActualizacionVersion.Value.ToString("yyyyMMdd HH:mm:ss"))
         Else
            .AppendFormat(", FechaActualizacionVersion = null")
         End If
         If fechaInicio.HasValue Then
            .AppendFormat(", FechaInicio = '{0}'", fechaInicio.Value.ToString("yyyyMMdd HH:mm:ss"))
         Else
            .AppendFormat(",  FechaInicio = null")
         End If
         If fechaInicioReal.HasValue Then
            .AppendFormat(", FechaInicioReal = '{0}'", fechaInicioReal.Value.ToString("yyyyMMdd HH:mm:ss"))
         Else
            .AppendFormat(", FechaInicioReal = null")
         End If
         If vencimientoLicencia.HasValue Then
            .AppendFormat(", VencimientoLicencia = '{0}'", vencimientoLicencia.Value.ToString("yyyyMMdd HH:mm:ss"))
         Else
            .AppendFormat(", VencimientoLicencia = null")
         End If

         .AppendFormat(", BackupAutoCuenta = '{0}'", backupAutoCuenta)
         .AppendFormat(", BackupAutoConfig = {0}", Me.GetStringFromBoolean(backupAutoConfig))
         .AppendFormat(", BackupNroVersion = '{0}'", backupNroVersion)

         .AppendFormat(", TienePreciosConIVA = {0}", Me.GetStringFromBoolean(tienePreciosConIVA))
         .AppendFormat(", ConsultaPreciosConIVA = {0}", Me.GetStringFromBoolean(consultaPreciosConIVA))
         .AppendFormat(", TieneServidorDedicado = {0}", Me.GetStringFromBoolean(tieneServidorDedicado))
         .AppendFormat(", MotorBaseDatos = '{0}'", motorBaseDatos)
         .AppendFormat(", CantidadDePCs = {0}", cantidadDePCs)
         .AppendFormat(", HorasCapacitacionPactadas = {0}", horasCapacitacionPactadas)
         .AppendFormat(", HorasCapacitacionRealizadas = {0}", horasCapacitacionRealizadas)

         If Not String.IsNullOrEmpty(cBU) Then
            .AppendFormat("     ,CBU = '{0}'", cBU)
         Else
            .AppendFormat("     ,CBU = NULL")
         End If

         If idBanco > 0 Then
            .AppendFormat("     ,IdBanco = {0}", idBanco)
         Else
            .AppendFormat("     ,IdBanco = NULL")
         End If

         If idCuentaBancariaClase > 0 Then
            .AppendFormat("     ,IdCuentaBancariaClase = {0}", idCuentaBancariaClase)
         Else
            .AppendFormat("     ,IdCuentaBancariaClase = NULL")
         End If

         If Not String.IsNullOrEmpty(numeroCuentaBancaria) Then
            .AppendFormat("     ,NumeroCuentaBancaria = '{0}'", numeroCuentaBancaria)
         Else
            .AppendFormat("     ,NumeroCuentaBancaria = NULL")
         End If

         If Not String.IsNullOrEmpty(cuitCtaBancaria) Then
            .AppendFormat(" ,CuitCtaBancaria = '{0}'", cuitCtaBancaria)
         Else
            .AppendFormat(",CuitCtaBancaria = NULL ")
         End If

         .AppendFormat(" ,UsaArchivoAImprimir2 = {0}", GetStringFromBoolean(usaArchivoAImprimir2))
         .AppendFormat(" ,CantidadVisitas = {0}", cantidadVisitas).ToString()

         .AppendFormatLine(" ,Facebook = '{0}'", facebook)
         .AppendFormatLine(" ,Instagram = '{0}'", instagram)
         .AppendFormatLine(" ,Twitter = '{0}'", twitter)

         If Not String.IsNullOrEmpty(idAplicacion) Then
            .AppendFormatLine(" ,IdAplicacion = '{0}'", idAplicacion)
         Else
            .AppendFormatLine(" ,IdAplicacion = NULL")
         End If

         If Not String.IsNullOrEmpty(edicion) Then
            .AppendFormatLine(" ,Edicion = '{0}'", edicion)
         Else
            .AppendFormatLine(" ,Edicion = NULL")
         End If
         .AppendFormatLine(" ,RecibeNotificaciones = '{0}'", recibeNotificaciones)
         If String.IsNullOrEmpty(contacto) Then
            .AppendFormat("      ,Contacto = null")
         Else
            .AppendFormat("      ,Contacto = '{0}'", contacto)
         End If
         If fechaBaja = Nothing Then
            .AppendFormat("      ,FechaBaja = null")
         Else
            .AppendFormat("      ,FechaBaja = '{0}'", fechaBaja.ToString("yyyyMMdd HH:mm:ss"))
         End If
         .AppendFormat("      ,VerEnConsultas = {0}", Me.GetStringFromBoolean(verEnConsultas))
         .AppendFormat("      ,IdCalle = {0}", idCalle)
         .AppendFormat("      ,Altura = {0}", altura)
         .AppendFormat("      ,IdCalle2 = {0}", idCalle2)
         .AppendFormat("      ,Altura2 = {0}", altura2)
         If String.IsNullOrEmpty(direccionAdicional2) Then
            .AppendFormat("      ,DireccionAdicional2 = null")
         Else
            .AppendFormat("      ,DireccionAdicional2 = '{0}'", direccionAdicional2)
         End If
         If String.IsNullOrEmpty(telefonosParticulares) Then
            .AppendFormat("      ,TelefonosParticulares = null")
         Else
            .AppendFormat("      ,TelefonosParticulares = '{0}'", telefonosParticulares)
         End If
         If String.IsNullOrEmpty(fax) Then
            .AppendFormat("      ,Fax = null")
         Else
            .AppendFormat("      ,Fax = '{0}'", fax)
         End If
         If fechaSUS = Nothing Then
            .AppendFormat("      ,FechaSUS = null")
         Else
            .AppendFormat("      ,FechaSUS = '{0}'", fechaSUS.ToString("yyyyMMdd HH:mm:ss"))
         End If
         If String.IsNullOrEmpty(IdDadoAltaPor.ToString()) Then
            .AppendFormat("      ,IdDadoAltaPor = null")
         Else
            .AppendFormat("      ,IdDadoAltaPor = '{0}'", IdDadoAltaPor)

         End If
         .AppendFormat("      ,Direccion2 = '{0}'", direccion2)
         .AppendFormat("      ,idLocalidad2 = {0}", idLocalidad2)
         .AppendFormat("      ,HabilitarVisita = {0}", Me.GetStringFromBoolean(habilitarVisita))
         .AppendLine("        ,ObservacionWeb = '" + observacionWeb + "'")
         .AppendFormat("      ,RepartoIndependiente='{0}'", repartoIndependiente)
         .AppendFormat("      ,NivelAutorizacion = {0}", nivelAutorizacion)
         .AppendFormat("      ,IdCuentaContable = {0}", GetStringFromNumber(idCuentaContable))
         .AppendFormat("      ,EsClienteGenerico = {0}", Me.GetStringFromBoolean(esClienteGenerico))

         .AppendFormatLine("      ,URLWebmovilPropio = '{0}'", urlWebmovilPropio)
         .AppendFormatLine("      ,URLWebmovilAdminPropio = '{0}'", urlWebmovilAdminPropio)
         .AppendFormatLine("      ,URLSimovilGestionPropio = '{0}'", urlSimovilGestionPropio)
         .AppendFormatLine("      ,URLActualizadorPropio = '{0}'", urlActualizadorPropio)
         .AppendFormatLine("      ,NroVersionWebmovilPropio = '{0}'", nroVersionWebmovilPropio)
         .AppendFormatLine("      ,NroVersionWebmovilAdminPropio = '{0}'", nroVersionWebmovilAdminPropio)
         .AppendFormatLine("      ,NroVersionSimovilGestionPropio = '{0}'", nroVersionSimovilGestionPropio)
         .AppendFormatLine("      ,NroVersionActualizadorPropio = '{0}'", nroVersionActualizadorPropio)

         .AppendFormat("      ,UtilizaAppSoporte = {0}", Me.GetStringFromBoolean(utilizaAppSoporte))
         .AppendFormat("      , CantidadLocal = {0}", cantidadLocal)
         .AppendFormat("      , CantidadRemota = {0}", cantidadRemota)
         .AppendFormat("      , CantidadMovil = {0}", cantidadMovil)
         .AppendFormat("      , ObservacionAdministrativa = '{0}'", observacionAdministrativa)
         .AppendFormat("      ,  Codigo{0}Letras = '{1}'", ModoClienteProspecto.ToString(), codigoClienteLetras.ToString())

         .AppendFormat("      , SiMovilIdUsuario = '{0}'", siMovilIdUsuario)
         .AppendFormat("      , SiMovilClave = '{0}'", siMovilClave)


         .AppendFormat("      ,Alicuota2deProducto = '{0}'", alicuota2deProducto)

         .AppendFormat("      ,CertificadoMiPyme = {0}", Me.GetStringFromBoolean(certificadoMiPyme))

         If fechaDesdeCertificado.HasValue Then
            .AppendFormat(", FechaDesdeCertificado='{0}'", ObtenerFecha(fechaDesdeCertificado.Value, False))
         Else
            .AppendFormat(", FechaDesdeCertificado=null")
         End If

         If fechaHastaCertificado.HasValue Then
            .AppendFormat(", FechaHastaCertificado='{0}'", ObtenerFecha(fechaHastaCertificado.Value, False))
         Else
            .AppendFormat(", FechaHastaCertificado=null")
         End If
         .AppendLine(", IdCobrador = " & idCobrador)
         .AppendFormat("      ,Sexo = '{0}'", sexo)

         .AppendFormatLine("      ,ValorizacionFacturacionMensual = {0}", valorizacionFacturacionMensual)
         .AppendFormatLine("      ,ValorizacionCoeficienteFacturacion = {0}", valorizacionCoeficienteFacturacion)

         .AppendFormatLine("      ,ValorizacionImporteAdeudado = {0}", valorizacionImporteAdeudado)
         .AppendFormatLine("      ,ValorizacionCoeficienteDeuda = {0}", valorizacionCoeficienteDeuda)

         .AppendFormatLine("      ,ValorizacionProyecto = {0}", valorizacionProyecto)
         .AppendFormatLine("      ,ValorizacionProyectoObservacion = '{0}'", valorizacionProyectoObservacion)

         .AppendFormat("      ,PublicarEnWeb = '{0}'", publicarEnWeb)

         If Not String.IsNullOrEmpty(horarioClienteCompleto) Then
            .AppendFormat("      ,HorarioClienteCompleto = '{0}'", horarioClienteCompleto)
         Else
            .AppendFormat("      ,HorarioClienteCompleto = NULL")
         End If
         If Not String.IsNullOrEmpty(idClienteTiendaNube) Then
            .AppendFormat("      ,Id{1}TiendaNube = '{0}'", idClienteTiendaNube, ModoClienteProspecto.ToString())
         Else
            .AppendFormat("      ,Id{0}TiendaNube = NULL", ModoClienteProspecto.ToString())
         End If
         If Not String.IsNullOrEmpty(idClienteMercadoLibre) Then
            .AppendFormat("      ,Id{1}MercadoLibre = '{0}'", idClienteMercadoLibre, ModoClienteProspecto.ToString())
         Else
            .AppendFormat("      ,Id{0}MercadoLibre = NULL", ModoClienteProspecto.ToString())
         End If
         If Not String.IsNullOrEmpty(idClienteArborea) Then
            .AppendFormat("      ,Id{1}Arborea = '{0}'", idClienteArborea, ModoClienteProspecto.ToString())
         Else
            .AppendFormat("      ,Id{0}Arborea = NULL", ModoClienteProspecto.ToString())
         End If

         'PE-30972 -- 
         If fechaCambioCategoria.HasValue Then
            .AppendFormat(",FechaCambioCategoria = '{0}'", ObtenerFecha(fechaCambioCategoria.Value, False))
         Else
            .AppendFormat(",FechaCambioCategoria = NULL")
         End If

         If Not String.IsNullOrEmpty(observacionCambioCategoria) Then
            .AppendFormatLine("  ,ObservacionCambioCategoria = '{0}'", observacionCambioCategoria)
         Else
            .AppendFormatLine("  ,ObservacionCambioCategoria = NULL")
         End If

         If Not String.IsNullOrEmpty(idCategoriaCambio.ToString()) Then
            .AppendFormatLine("  ,IdCategoriaCambio = {0}", idCategoriaCambio)
         Else
            .AppendFormatLine("  ,IdCategoriaCambio = NULL")
         End If

         .AppendFormatLine("  ,ActualizadorAptoParaInstalar = {0}", GetStringFromBoolean(actualizadorAptoParaInstalar))
         .AppendFormatLine("  ,ActualizadorFunciona = '{0}'", actualizadorFunciona.ToString())
         .AppendFormatLine("  ,ActualizadorFechaInstalacion = {0}", ObtenerFecha(actualizadorFechaInstalacion, False))
         .AppendFormatLine("  ,ActualizadorVersion = '{0}'", actualizadorVersion)

         .AppendFormatLine("  ,IdImpositivoOtroPais = '{0}'", idImpositivoOtroPais)
         .AppendFormatLine("  ,idConceptoCM05 = {0}", GetStringFromNumber(idConceptoCM05))

         .AppendFormatLine("  ,EsExentoPercIVARes53292023 = {0}", GetStringFromBoolean(EsExentoPercIVARes53292023))

         If VarPesosCotizDolar <> 0 Then
            .AppendFormatLine("  ,VarPesosCotizDolar = {0}", VarPesosCotizDolar)
         Else
            .AppendFormatLine("  ,VarPesosCotizDolar = NULL")
         End If
         .AppendFormatLine("  ,PublicarEnTiendaNube = {0}", GetStringFromBoolean(publicarEnTiendaNube))
         .AppendFormatLine("  ,PublicarEnMercadoLibre = {0}", GetStringFromBoolean(publicarEnMercadoLibre))
         .AppendFormatLine("  ,PublicarEnArborea = {0}", GetStringFromBoolean(publicarEnArborea))
         .AppendFormatLine("  ,PublicarEnGestion = {0}", GetStringFromBoolean(publicarEnGestion))
         .AppendFormatLine("  ,PublicarEnEmpresarial = {0}", GetStringFromBoolean(publicarEnEmpresarial))
         .AppendFormatLine("  ,PublicarEnSincronizacionSucursal = {0}", GetStringFromBoolean(publicarEnSincronizacionSucursal))

         .AppendFormat(" WHERE Id{0} = {1}", ModoClienteProspecto.ToString(), idCliente.ToString()).AppendLine()
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Clientes_UVarios(idCliente As Long,
                               IdVendedor As Integer,
                               idCategoria As Integer,
                               idListaPrecios As Integer,
                               idZonaGeografica As String,
                               idFormaPago As Integer,
                               actualizaDescRecargoPor As Boolean,
                               descRecarPorc As Decimal,
                               activo As Boolean,
                               idTipoComprobante As String,
                               idEstado As Integer,
                               cantidadVisitas As Integer,
                               idLocalidad As Integer,
                               recibeNotificaciones As Boolean,
                               nivelAutorizacion As Short,
                               idTransportista As Integer,
                               alicuota2deProducto As String,
                               IdCobrador As Integer,
                               idTipoCliente As Integer,
                               publicarEnWeb As Boolean,
                               LimiteDiasVtoFactura As Integer,
                               LimiteDeCredito As Decimal,
                               idCategoriaFiscal As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("UPDATE {0}s", ModoClienteProspecto.ToString()).AppendLine()
         .AppendLine("   SET Activo = '" & activo.ToString() & "'")

         If Not activo Then
            .AppendFormat(", FechaBaja = '{0}'", ObtenerFecha(Date.Now(), False))
         End If

         If IdVendedor > 0 Then
            .AppendLine("   ,IdVendedor = " & IdVendedor)
         End If

         If idCategoria > 0 Then
            .AppendLine("     ,IdCategoria = " & idCategoria.ToString())
         End If

         If idListaPrecios >= 0 Then
            .AppendLine("     ,IdListaPrecios = " & idListaPrecios.ToString())
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendLine("     ,IdZonaGeografica = '" & idZonaGeografica & "'")
         End If

         If idFormaPago > 0 Then
            .AppendFormat("     ,IdFormasPago = {0}", idFormaPago)
         End If

         If actualizaDescRecargoPor Then
            .AppendFormat("     ,DescuentoRecargoPorc = {0}", descRecarPorc)
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("   ,IdTipoComprobante = '" & idTipoComprobante.ToString() & "' ")
         End If

         If IdCobrador > 0 Then
            .AppendFormat("     ,IdCobrador = {0}", IdCobrador)
         End If

         If idEstado > 0 Then
            .AppendFormat("     ,IdEstado = {0}", idEstado)
         End If

         If cantidadVisitas > -1 Then
            .AppendFormat("     ,CantidadVisitas = {0}", cantidadVisitas)
         End If
         If idLocalidad > 0 Then
            .AppendFormat("     ,IdLocalidad = {0}", idLocalidad)
         End If
         .AppendFormatLine(" ,RecibeNotificaciones = '{0}'", recibeNotificaciones)
         .AppendFormatLine("      ,NivelAutorizacion = {0}", nivelAutorizacion)
         If idTransportista > 0 Then
            .AppendFormatLine(" , IdTransportista = {0}", idTransportista)
         End If

         If Not String.IsNullOrWhiteSpace(alicuota2deProducto) Then
            .AppendFormat("      ,Alicuota2deProducto = '{0}'", alicuota2deProducto)
         End If

         If idTipoCliente > -1 Then
            .AppendFormat("      ,IdTipoCliente = {0}", idTipoCliente)
         End If
         .AppendFormatLine("      ,PublicarEnWeb = '{0}'", publicarEnWeb)
         .AppendFormatLine("      ,LimiteDiasVtoFactura = {0}", LimiteDiasVtoFactura)
         .AppendFormatLine("      ,LimiteDeCredito = {0}", LimiteDeCredito)

         If idCategoriaFiscal > 0 Then
            .AppendFormatLine("    ,IdCategoriaFiscal = " & idCategoriaFiscal.ToString())
         End If

         .AppendFormat(" WHERE Id{0} = {1}", ModoClienteProspecto.ToString(), idCliente.ToString()).AppendLine()
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Clientes")

   End Sub

   Public Sub Clientes_U_SaldoLimiteDeCredito(idCliente As Long, limiteDeCreditoNuevo As Decimal, saldoLimiteDeCreditoNuevo As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}s", ModoClienteProspecto.ToString())
         .AppendFormatLine("   SET {0} = {1}", Entidades.Cliente.Columnas.SaldoLimiteDeCredito.ToString(), saldoLimiteDeCreditoNuevo)
         .AppendFormatLine("     , {0} = {1}", Entidades.Cliente.Columnas.LimiteDeCredito.ToString(), limiteDeCreditoNuevo)
         .AppendFormatLine(" WHERE Id{0} = {1}", ModoClienteProspecto.ToString(), idCliente.ToString())
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Clientes")
   End Sub

   Public Sub Clientes_D(IdCliente As Long)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendFormat("DELETE FROM {0}s WHERE Id{0} = {1}", ModoClienteProspecto.ToString(), IdCliente.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Clientes")
   End Sub

   Public Function Clientes_G1(idCliente As Long, incluirFoto As Boolean, puedeVerDetalleValoracionEstrellas As Boolean, porCodigo As Boolean) As DataTable
      'Optional incluirFoto As Boolean = False
      Dim stbQuery As StringBuilder = New StringBuilder()
      'Dim consultaFoto As Boolean = False

      Me.SelectTexto(stbQuery, incluirFoto, puedeVerDetalleValoracionEstrellas)

      With stbQuery
         If Not porCodigo Then
            .AppendFormat(" WHERE C.Id{0} = {1}", ModoClienteProspecto.ToString(), idCliente.ToString()).AppendLine()
         Else
            .AppendFormat(" WHERE C.Codigo{0} = {1}", ModoClienteProspecto.ToString(), idCliente.ToString()).AppendLine()
         End If
         'SI llego a esta instancia, la validacion de activo o inactivo no corresponde.
         '.AppendLine("   AND C.Activo = 'True'")
         '-------------------------
      End With
      Dim dt As DataTable = Me.GetDataTable(stbQuery.ToString())
      Return dt
   End Function

   'Public Function Clientes_G1Todos(IdCliente As Long, Optional incluirFoto As Boolean = False) As DataTable
   '   Dim stbQuery As StringBuilder = New StringBuilder("")
   '   'Dim consultaFoto As Boolean = False

   '   Me.SelectTexto(stbQuery, incluirFoto)
   '   With stbQuery
   '      .AppendLine(" WHERE C.IdCliente = " & IdCliente.ToString())
   '   End With
   '   Dim dt As DataTable = Me.GetDataTable(stbQuery.ToString())
   '   Return dt
   'End Function

   'Public Function Clientes_G1PorCodigo(CodigoCliente As Long, Optional incluirFoto As Boolean = False) As DataTable
   '   Dim stbQuery As StringBuilder = New StringBuilder("")
   '   Me.SelectTexto(stbQuery, incluirFoto)
   '   With stbQuery
   '      .AppendLine(" WHERE C.CodigoCliente = " & CodigoCliente.ToString())
   '      .AppendLine("   AND C.Activo = 'True'")
   '   End With
   '   Dim dt As DataTable = Me.GetDataTable(stbQuery.ToString())
   '   Return dt
   'End Function

   'Public Function Clientes_G1PorCodigoTodos(CodigoCliente As Long, Optional incluirFoto As Boolean = False) As DataTable
   '   Dim stbQuery As StringBuilder = New StringBuilder("")
   '   Me.SelectTexto(stbQuery, incluirFoto)
   '   With stbQuery
   '      .AppendLine(" WHERE C.CodigoCliente = " & CodigoCliente.ToString())
   '   End With
   '   Dim dt As DataTable = Me.GetDataTable(stbQuery.ToString())
   '   Return dt
   'End Function

   Public Sub GrabarFoto(imagen As System.Drawing.Image, IdCliente As Long)

      If Not System.IO.Directory.Exists(Entidades.Publicos.DriverBase + "Eniac\") Then
         System.IO.Directory.CreateDirectory(Entidades.Publicos.DriverBase + "Eniac\")
      End If

      Dim path As String
      If ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Prospecto Then
         path = Entidades.Publicos.DriverBase + "Eniac\p" + IdCliente.ToString() + ".jpg"
      Else
         path = Entidades.Publicos.DriverBase + "Eniac\" + IdCliente.ToString() + ".jpg"
      End If

      Dim stbQuery As StringBuilder = New StringBuilder("")

      If imagen IsNot Nothing Then
         imagen.Save(path)

         Dim fsArchivo As System.IO.FileStream = New System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read)

         Dim iFileLength As Integer = Integer.Parse(fsArchivo.Length.ToString())

         Dim foto(Integer.Parse(fsArchivo.Length.ToString())) As Byte

         fsArchivo.Read(foto, 0, iFileLength)

         fsArchivo.Close()

         With stbQuery
            .AppendFormat(" UPDATE {0}s ", ModoClienteProspecto.ToString())
            .AppendFormat(" SET Foto = ")
            .AppendFormat(" @Foto ")
            .AppendFormat(" WHERE Id{1} = {0}", IdCliente.ToString(), ModoClienteProspecto.ToString())
         End With

         Me._da.Command.CommandText = stbQuery.ToString()
         Me._da.Command.CommandType = CommandType.Text
         Dim oParameter As Data.Common.DbParameter = Me._da.Command.CreateParameter()
         oParameter.ParameterName = "@Foto"
         oParameter.DbType = DbType.Binary
         oParameter.Size = foto.Length
         oParameter.Value = foto
         Me._da.Command.Parameters.Add(oParameter)
         Me._da.Command.Connection = Me._da.Connection
         Me._da.ExecuteNonQuery(Me._da.Command)
      Else
         With stbQuery
            .AppendFormat(" UPDATE {0}s ", ModoClienteProspecto.ToString())
            .AppendFormat(" SET Foto = ")
            .AppendFormat(" null ")
            .AppendFormat(" WHERE Id{1} = {0}", IdCliente.ToString(), ModoClienteProspecto.ToString())
         End With

         Me.Execute(stbQuery.ToString())
      End If

   End Sub

   Private Sub SelectTexto(stb As StringBuilder, incluirFoto As Boolean, puedeVerDetalleValoracionEstrellas As Boolean)
      SelectTexto(stb, incluirFoto, puedeVerDetalleValoracionEstrellas, auditoria:=False)
   End Sub
   Private Sub SelectTexto(stb As StringBuilder, incluirFoto As Boolean, puedeVerDetalleValoracionEstrellas As Boolean, auditoria As Boolean)
      SelectTextoCampos(stb, incluirFoto, puedeVerDetalleValoracionEstrellas, auditoria)
      SelectTextoFrom(stb, auditoria)
   End Sub
   Private Sub SelectTextoCampos(stb As StringBuilder, incluirFoto As Boolean, puedeVerDetalleValoracionEstrellas As Boolean, auditoria As Boolean)
      With stb
         .AppendFormatLine("SELECT C.Id{0}", ModoClienteProspecto.ToString())
         .AppendFormatLine("      ,C.Codigo{0}", ModoClienteProspecto.ToString())
         .AppendFormatLine("      ,C.Nombre{0}", ModoClienteProspecto.ToString())
         .AppendFormatLine("      ,C.NombreDeFantasia")

         If auditoria Then
            .AppendFormatLine("      ,' ' AS Modificado")
            .AppendFormatLine("      ,C.FechaAuditoria")
            .AppendFormatLine("      ,C.OperacionAuditoria")
            .AppendFormatLine("      ,C.UsuarioAuditoria")
         End If

         .AppendFormatLine("      ,C.Activo")
         .AppendFormatLine("      ,C.Direccion")
         .AppendFormatLine("      ,C.DireccionAdicional")
         .AppendFormatLine("      ,C.IdLocalidad")
         .AppendFormatLine("      ,L.NombreLocalidad")
         .AppendFormatLine("      ,P.NombreProvincia")
         .AppendFormatLine("      ,C.IdCategoriaFiscal")
         .AppendFormatLine("      ,CF.NombreCategoriaFiscal")
         .AppendFormatLine("      ,CFC.LetraFiscal")
         .AppendFormatLine("      ,C.Cuit")
         .AppendFormatLine("      ,C.TipoDoc{0}", ModoClienteProspecto.ToString())
         .AppendFormatLine("      ,C.NroDoc{0}", ModoClienteProspecto.ToString())
         .AppendFormatLine("      ,C.Telefono")
         .AppendFormatLine("      ,C.Celular")
         .AppendFormatLine("      ,C.IdZonaGeografica")
         .AppendFormatLine("      ,Z.NombreZonaGeografica")
         .AppendFormatLine("      ,C.FechaNacimiento")
         .AppendFormatLine("      ,C.NroOperacion")
         .AppendFormatLine("      ,C.CorreoElectronico")
         .AppendFormatLine("      ,C.CorreoAdministrativo")
         .AppendFormatLine("      ,C.NombreTrabajo")
         .AppendFormatLine("      ,C.DireccionTrabajo")
         .AppendFormatLine("      ,C.TelefonoTrabajo")
         .AppendFormatLine("      ,C.CorreoTrabajo")
         .AppendFormatLine("      ,C.IdLocalidadTrabajo")
         .AppendFormatLine("      ,L1.NombreLocalidad NombreLocalidadTrabajo")
         .AppendFormatLine("      ,C.FechaIngresoTrabajo")
         .AppendFormatLine("      ,C.FechaAlta")
         .AppendFormatLine("      ,C.SaldoPendiente")
         .AppendFormatLine("      ,C.Id{0}Garante", ModoClienteProspecto.ToString())
         .AppendFormatLine("      ,C1.Codigo{0} AS CodigoGarante", ModoClienteProspecto.ToString())
         .AppendFormatLine("      ,C1.Nombre{0} AS NombreGarante", ModoClienteProspecto.ToString())
         .AppendFormatLine("      ,C.IdCategoria")
         .AppendFormatLine("      ,Ca.NombreCategoria")
         .AppendFormatLine("      ,Ca.IdGrupoCategoria AS GrupoCategoria")
         .AppendFormatLine("      ,C.Observacion")
         .AppendFormatLine("      ,C.IdListaPrecios")
         .AppendFormatLine("      ,LdP.NombreListaPrecios")
         .AppendFormatLine("      ,C.IdVendedor")
         ' .AppendFormatLine("      ,E.IdEmpleado AS IdVendedor")
         .AppendFormatLine("      ,E.NombreEmpleado AS NombreVendedor")
         .AppendFormatLine("      ,C.LimiteDeCredito ")
         .AppendFormatLine("      ,C.SaldoLimiteDeCredito")
         .AppendFormatLine("      ,C.IdSucursalAsociada ")
         .AppendFormatLine("      ,SA.Nombre AS NombreSucursalAsociada")
         .AppendFormatLine("      ,C.IdCaja ")
         .AppendFormatLine("      ,CN.NombreCaja")
         .AppendFormatLine("      ,C.DescuentoRecargoPorc ")
         .AppendFormatLine("      ,C.DescuentoRecargoPorc2 ")
         .AppendFormatLine("      ,C.IdtipoComprobante ")
         .AppendFormatLine("      ,TC.Descripcion ")
         .AppendFormatLine("      ,C.IdFormasPago ")
         .AppendFormatLine("      ,FP.DescripcionFormasPago ")
         .AppendFormatLine("      ,C.IdTransportista")
         .AppendFormatLine("      ,T.NombreTransportista")

         'Solo la busco en el GET1 porque ahi puedo necesitarlo, en todo lo demas NO.
         'Lentifica terriblemente la consulta.
         If incluirFoto Then
            .AppendFormatLine("      ,C.Foto")
         Else
            .AppendFormatLine("      ,NULL AS Foto")
         End If

         .AppendFormatLine("      ,C.IngresosBrutos")
         .AppendFormatLine("      ,C.InscriptoIBStaFe")
         .AppendFormatLine("      ,C.LocalIB")
         .AppendFormatLine("      ,C.ConvMultilateralIB")
         .AppendFormatLine("      ,C.NumeroLote")
         .AppendFormatLine("      ,C.GeoLocalizacionLat")
         .AppendFormatLine("      ,C.GeoLocalizacionLng")
         .AppendFormatLine("      ,C.IdTipoDeExension")
         .AppendFormatLine("      ,C.AnioExension")
         .AppendFormatLine("      ,C.NroCertExension")
         .AppendFormatLine("      ,C.NroCertPropio")
         .AppendFormatLine("      ,C.PaginaWeb")
         .AppendFormatLine("      ,C.Id{0}CtaCte", ModoClienteProspecto.ToString())
         .AppendFormatLine("      ,C2.Codigo{0} AS Codigo{0}CtaCte", ModoClienteProspecto.ToString())
         .AppendFormatLine("      ,C2.Nombre{0} AS Nombre{0}CtaCte", ModoClienteProspecto.ToString())
         .AppendFormatLine("      ,C.LimiteDiasVtoFactura")
         .AppendFormatLine("      ,C.ModificarDatos")
         .AppendFormatLine("      ,C.EsResidente")
         .AppendFormatLine("      ,C.IdEstado")
         .AppendFormatLine("		 ,EC.NombreEstadoCliente")
         .AppendFormatLine("		 ,EC.Color ColorEstadoCliente")
         ' .AppendFormatLine("		 ,C.IdCobrador")
         .AppendFormatLine("       ,Cob.IdEmpleado As IdCobrador ")
         .AppendFormatLine("		 ,Cob.NombreEmpleado As NombreCobrador")

         .AppendFormatLine("		 ,C.IdTipoCliente")
         .AppendFormatLine("		 ,TipC.NombreTipoCliente")
         .AppendFormatLine("		 ,C.HorarioCorrido")
         .AppendFormatLine("		 ,C.HoraInicio")
         .AppendFormatLine("		 ,C.HoraFin")
         .AppendFormatLine("		 ,C.HoraInicio2")
         .AppendFormatLine("		 ,C.HoraFin2")
         .AppendFormatLine("		 ,C.HorarioCorridoSab")
         .AppendFormatLine("		 ,C.HoraSabInicio")
         .AppendFormatLine("		 ,C.HoraSabFin")
         .AppendFormatLine("		 ,C.HoraSabInicio2")
         .AppendFormatLine("		 ,C.HoraSabFin2")
         .AppendFormatLine("		 ,C.HorarioCorridoDom")
         .AppendFormatLine("		 ,C.HoraDomInicio")
         .AppendFormatLine("		 ,C.HoraDomFin")
         .AppendFormatLine("		 ,C.HoraDomInicio2")
         .AppendFormatLine("		 ,C.HoraDomFin2")
         .AppendFormatLine("		 ,C.NroVersion")
         .AppendFormatLine("		 ,C.{0}", Entidades.Cliente.Columnas.FechaActualizacionWeb.ToString())
         .AppendFormatLine("		 ,C.FechaActualizacionVersion")
         .AppendFormatLine("		 ,C.FechaInicio")
         .AppendFormatLine("		 ,C.FechaInicioReal")
         .AppendFormatLine("		 ,Ca.RequiereRevisionAdministrativa")
         .AppendFormatLine("		 ,C.VencimientoLicencia")
         .AppendFormatLine("		 ,C.BackupAutoCuenta")
         .AppendFormatLine("		 ,C.BackupAutoConfig")
         .AppendFormatLine("		 ,C.BackupNroVersion")
         .AppendFormatLine("		 ,C.TienePreciosConIVA")
         .AppendFormatLine("		 ,C.ConsultaPreciosConIVA")
         .AppendFormatLine("		 ,C.TieneServidorDedicado")
         .AppendFormatLine("		 ,C.MotorBaseDatos")
         .AppendFormatLine("		 ,C.CantidadDePCs")
         .AppendFormatLine("		 ,C.HorasCapacitacionPactadas")
         .AppendFormatLine("		 ,C.HorasCapacitacionRealizadas")
         .AppendFormatLine("      ,C.CBU")
         .AppendFormatLine("      ,C.IdBanco")
         .AppendFormatLine("      ,B.NombreBanco")
         .AppendFormatLine("      ,C.IdCuentaBancariaClase")
         .AppendFormatLine("      ,CB.NombreCuentaBancariaClase")
         .AppendFormatLine("      ,C.NumeroCuentaBancaria")
         .AppendFormatLine("      ,C.CuitCtaBancaria")
         .AppendFormatLine("      ,C.UsaArchivoAImprimir2")
         .AppendFormatLine("      ,C.CantidadVisitas")
         .AppendFormatLine("      ,C.Facebook")
         .AppendFormatLine("      ,C.Instagram")
         .AppendFormatLine("      ,C.Twitter")
         .AppendFormatLine("      ,C.IdAplicacion")
         .AppendFormatLine("      ,C.Edicion")
         .AppendFormatLine("      ,C.RecibeNotificaciones")
         .AppendLine("           ,C.Contacto")
         .AppendLine("        ,C.FechaBaja")
         .AppendLine("        ,C.VerEnConsultas")
         .AppendLine("        ,C.IdCalle")
         .AppendLine("   	   ,CL.NombreCalle")
         .AppendLine("        ,C.Altura")
         .AppendLine("        ,C.IdCalle2")
         .AppendLine("  	   ,CL2.NombreCalle AS NombreCalle2")
         .AppendLine("        ,C.Altura2")
         .AppendLine("        ,ISNULL(C.DireccionAdicional2,'') AS DireccionAdicional2")
         .AppendLine("        ,C.TelefonosParticulares")
         .AppendLine("        ,C.Fax")
         .AppendLine("        ,C.FechaSUS")
         .AppendLine("        ,C.IdDadoAltaPor")
         .AppendLine("       ,E2.NombreEmpleado as NombreDadoAltaPor")
         .AppendLine("       ,C.HabilitarVisita")
         .AppendLine("       ,C.Direccion2")
         .AppendLine("       ,C.IdLocalidad2")
         .AppendLine("       ,L2.NombreLocalidad AS NombreLocalidad2")
         .AppendLine("       ,P2.NombreProvincia AS NombreProvincia2")
         .AppendLine("       ,C.ObservacionWeb")
         .AppendLine("       ,C.RepartoIndependiente")
         .AppendLine("       ,C.NivelAutorizacion")
         .AppendLine("       ,C.IdCuentaContable")
         .AppendLine("       ,CCBL.NombreCuenta NombreCuentaContable")
         .AppendLine("       ,C.EsClienteGenerico")

         .AppendLine("       ,C.URLWebmovilPropio")
         .AppendLine("       ,C.URLWebmovilAdminPropio")
         .AppendLine("       ,C.URLSimovilGestionPropio")
         .AppendLine("       ,C.URLActualizadorPropio")
         .AppendLine("       ,C.NroVersionWebmovilPropio")
         .AppendLine("       ,C.NroVersionWebmovilAdminPropio")
         .AppendLine("       ,C.NroVersionSimovilGestionPropio")
         .AppendLine("       ,C.NroVersionActualizadorPropio")

         .AppendLine("		 ,Ca.ActualizarAplicacion")
         .AppendLine("		 ,Ca.ControlaBackup")
         .AppendLine("		 ,Ca.BackColor")
         .AppendLine("		 ,Ca.ForeColor")
         .AppendLine("		 ,C.UtilizaAppSoporte")
         .AppendLine("		 ,C.CantidadLocal")
         .AppendLine("		 ,C.CantidadRemota")
         .AppendLine("		 ,C.CantidadMovil")
         .AppendLine("		 ,C.ObservacionAdministrativa")
         .AppendLine("		 ,C.SiMovilIdUsuario")
         .AppendLine("		 ,C.SiMovilClave")
         .AppendLine("		 ,C.Alicuota2deProducto")
         .AppendLine("		 ,C.CertificadoMiPyme")
         .AppendLine("		 ,C.FechaDesdeCertificado")
         .AppendLine("		 ,C.FechaHastaCertificado")
         .AppendFormatLine("      ,C.Codigo{0}Letras", ModoClienteProspecto.ToString())
         .AppendLine("		 ,C.Sexo")
         .AppendLine("		 ,C.HorarioClienteCompleto")

         If puedeVerDetalleValoracionEstrellas Then
            .AppendFormatLine("		 ,C.ValorizacionFacturacionMensual")
            .AppendFormatLine("		 ,C.ValorizacionFacturacion")
            .AppendFormatLine("		 ,C.ValorizacionImporteAdeudado")
            .AppendFormatLine("		 ,C.ValorizacionDeuda")
            .AppendFormatLine("		 ,C.Valorizacion{0}", ModoClienteProspecto.ToString())
         Else
            .AppendFormatLine("		 ,CONVERT(Decimal(12, 2), 0) ValorizacionFacturacionMensual")
            .AppendFormatLine("		 ,CONVERT(Decimal(18, 4), 0) ValorizacionFacturacion")
            .AppendFormatLine("		 ,CONVERT(Decimal(12, 2), 0) ValorizacionImporteAdeudado")
            .AppendFormatLine("		 ,CONVERT(Decimal(18, 4), 0) ValorizacionDeuda")
            .AppendFormatLine("		 ,CONVERT(Decimal(18, 4), 0) Valorizacion{0}", ModoClienteProspecto.ToString())
         End If
         .AppendFormatLine("		 ,C.ValorizacionCoeficienteFacturacion")
         .AppendFormatLine("		 ,C.ValorizacionCoeficienteDeuda")
         .AppendFormatLine("		 ,C.ValorizacionProyecto")
         .AppendFormatLine("      ,C.ValorizacionProyectoObservacion")
         .AppendFormatLine("		 ,C.ValorizacionEstrellas")
         .AppendLine("		 ,C.PublicarEnWeb")
         .AppendFormatLine("		 ,C.Id{0}TiendaNube", ModoClienteProspecto.ToString())
         .AppendFormatLine("		 ,C.Id{0}MercadoLibre", ModoClienteProspecto.ToString())
         .AppendFormatLine("		 ,C.Id{0}Arborea", ModoClienteProspecto.ToString())
         'PE-30972
         .AppendFormatLine("     ,C.FechaCambioCategoria")
         .AppendFormatLine("     ,C.ObservacionCambioCategoria")
         .AppendFormatLine("     ,C.IdCategoriaCambio")
         .AppendFormatLine("     ,Ca2.NombreCategoria AS NombreCategoriaCambio")

         '.AppendFormatLine("     ,C.IdCategoriaCambio")
         '--REQ-33586.- -- Valores de Embarcacion por Defecto.- --
         .AppendFormatLine("     ,'' as NombreEmbarcacion")
         .AppendFormatLine("     ,'0' as IDEmbarcacion")
         '--REQ-36328.- -- Valores de Cama por Defecto.- --
         .AppendFormatLine("     ,'0' as IdCama")
         .AppendFormatLine("     ,'0' as CodigoCama")

         .AppendFormatLine("     ,C.ActualizadorAptoParaInstalar")
         .AppendFormatLine("     ,C.ActualizadorFunciona")
         .AppendFormatLine("     ,C.ActualizadorFechaInstalacion")
         .AppendFormatLine("     ,C.ActualizadorVersion")
         .AppendFormatLine("     ,C.IdImpositivoOtroPais")
         .AppendFormatLine("     ,C.IdConceptoCM05")
         .AppendFormatLine("     ,CM05.DescripcionConceptoCM05")
         .AppendFormatLine("     ,CM05.TipoConceptoCM05")

         .AppendFormatLine("     ,C.MonedaCredito")
         .AppendFormatLine("     ,MN.NombreMoneda")

         .AppendFormatLine("      ,C.IdTipoComprobanteInvocacionMasiva")
         .AppendFormatLine("      ,TC2.Descripcion DescripcionInvocacionMasiva")
         .AppendFormatLine("      ,C.EsExentoPercIVARes53292023")
         .AppendFormatLine("      ,C.IdEstadoCivil")
         .AppendFormatLine("      ,C.VarPesosCotizDolar")
         .AppendLine("      ,C.PublicarEnWeb")
         .AppendLine("      ,C.PublicarEnTiendaNube")
         .AppendLine("      ,C.PublicarEnMercadoLibre")
         .AppendLine("      ,C.PublicarEnArborea")
         .AppendLine("      ,C.PublicarEnGestion")
         .AppendLine("      ,C.PublicarEnEmpresarial")
         .AppendLine("      ,C.PublicarEnSincronizacionSucursal")

      End With
   End Sub

   Private Sub SelectTextoFrom(stb As StringBuilder, auditoria As Boolean)

      With stb
         If Not auditoria Then
            .AppendFormatLine(" FROM {0}s C", ModoClienteProspecto.ToString())
         Else
            .AppendFormatLine(" FROM Auditoria{0}s C", ModoClienteProspecto.ToString())
         End If
         .AppendLine(" LEFT JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad ")
         .AppendLine(" LEFT JOIN Provincias P ON P.IdProvincia = L.IdProvincia ")
         .AppendLine(" LEFT JOIN Localidades L1 ON L1.IdLocalidad = C.IdLocalidadTrabajo ")
         .AppendLine(" LEFT JOIN ZonasGeograficas Z  ON Z.IdZonaGeografica = C.IdZonaGeografica ")
         .AppendLine(" LEFT JOIN Categorias Ca ON C.IdCategoria = Ca.IdCategoria ")
         .AppendLine(" LEFT JOIN Monedas MN ON C.MonedaCredito = MN.IdMoneda ")

         'PE-30972
         .AppendLine(" LEFT JOIN Categorias Ca2 ON C.IdCategoriaCambio = Ca2.IdCategoria ")
         .AppendLine(" LEFT JOIN CategoriasFiscales CF ON C.IdCategoriaFiscal = CF.IdCategoriaFiscal ")

         .AppendFormatLine(" CROSS JOIN (SELECT * FROM Parametros WHERE IdParametro = 'CATEGORIAFISCALEMPRESA' AND IdEmpresa = {0}) PAR", actual.Sucursal.IdEmpresa)
         .AppendFormatLine("  LEFT JOIN CategoriasFiscalesConfiguraciones CFC ON CFC.IdCategoriaFiscalCliente = CF.IdCategoriaFiscal AND CFC.IdCategoriaFiscalEmpresa = ISNULL(PAR.ValorParametro, 0)")

         .AppendFormat(" LEFT JOIN {0}s C1 ON C1.Id{0} = C.Id{0}Garante ", ModoClienteProspecto.ToString()).AppendLine()
         .AppendFormat(" LEFT JOIN {0}s C2 ON C2.Id{0} = C.Id{0}CtaCte", ModoClienteProspecto.ToString()).AppendLine()
         .AppendLine(" LEFT JOIN Empleados E ON C.IdVendedor = E.IdEmpleado ")
         .AppendLine(" LEFT JOIN ListasDePrecios LdP ON C.IdListaPrecios = LdP.IdListaPrecios ")
         .AppendLine(" LEFT JOIN EstadosClientes EC ON EC.IdEstadoCliente = C.IdEstado")
         .AppendLine(" LEFT OUTER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante ")
         .AppendLine(" LEFT OUTER JOIN Sucursales SA ON C.IdSucursalAsociada = SA.IdSucursal")
         .AppendLine(" LEFT OUTER JOIN VentasFormasPago FP ON FP.IdFormasPago = C.IdFormasPago")
         .AppendLine(" LEFT OUTER JOIN Transportistas T ON T.IdTransportista = C.IdTransportista")
         .AppendLine(" LEFT OUTER JOIN CajasNombres CN ON CN.IdSucursal = " & actual.Sucursal.IdSucursal.ToString() & " AND CN.IdCaja = C.IdCaja")

         .AppendLine(" LEFT OUTER JOIN TiposComprobantes TC2 ON TC2.IdTipoComprobante = C.IdTipoComprobanteInvocacionMasiva ")

         .AppendFormat(" LEFT OUTER JOIN Empleados Cob ON Cob.IdEmpleado = C.IdCobrador")

         .AppendFormat(" LEFT OUTER JOIN TiposClientes TipC ON TipC.IdTipoCliente = C.IdTipoCliente")
         .AppendLine("  LEFT JOIN Calles CL ON CL.idCalle = C.IdCalle")
         .AppendLine("  LEFT JOIN Calles CL2 ON CL2.idCalle = C.IdCalle2")
         .AppendLine("  LEFT JOIN Empleados E2 ON C.IdDadoAltaPor = E2.IdEmpleado ")
         .AppendLine(" LEFT JOIN Localidades L2 ON L2.IdLocalidad = C.IdLocalidad2 ")
         .AppendLine(" LEFT JOIN Provincias P2 ON P2.IdProvincia = L2.IdProvincia ")
         .AppendLine(" LEFT JOIN ContabilidadCuentas CCBL ON CCBL.IdCuenta = C.IdCuentaContable")
         .AppendLine(" LEFT JOIN TiposClientes TCL ON C.IdTipoCliente = TCL.IdTipoCliente")
         .AppendLine(" LEFT JOIN CuentasBancariasClase CB ON CB.IdCuentaBancariaClase = C.IdCuentaBancariaClase ")
         .AppendLine(" LEFT JOIN Bancos B ON B.IdBanco = C.Idbanco ")

         .AppendLine(" LEFT JOIN AFIPConceptosCM05 CM05 ON CM05.IdConceptoCM05 = C.IdConceptoCM05")
      End With

   End Sub

   Public Function Clientes_GA_Ids() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("SELECT C.Id{0}, C.Codigo{0} FROM {0}s C", ModoClienteProspecto.ToString()).AppendLine()
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function Clientes_GA(filtro As Entidades.Filtros.ClientesABMFiltros, puedeVerDetalleValoracionEstrellas As Boolean) As DataTable
      Return Clientes_GA(Nothing, filtro, puedeVerDetalleValoracionEstrellas)
   End Function

   Public Function Clientes_GA(fechaActualizacionDesde As Date?, filtro As Entidades.Filtros.ClientesABMFiltros, puedeVerDetalleValoracionEstrellas As Boolean) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")
      Dim blnIncluirFoto As Boolean = False

      Me.SelectTexto(myQuery, blnIncluirFoto, puedeVerDetalleValoracionEstrellas)

      With myQuery
         .AppendLine(" WHERE 1 = 1")
         If fechaActualizacionDesde.HasValue Then
            .AppendFormat("   AND C.{0} > '{1}'",
                          Entidades.Cliente.Columnas.FechaActualizacionWeb.ToString(), ObtenerFecha(fechaActualizacionDesde.Value, True, True)).AppendLine()
         End If

         AplicarClientesABMFiltros(myQuery, filtro)

         .AppendFormat(" ORDER BY C.Nombre{0} ", ModoClienteProspecto.ToString()).AppendLine()
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function Clientes_GetAsignacionCargos(idCategoria As Integer?,
                                                idZonaGeografica As String,
                                                 FiltroPcs As String,
                                                CantidadPcs As Integer,
                                                idcliente As Long,
                                                IdCobrador As Integer,
                                                filtroActivos As Entidades.Publicos.SiNoTodos, idTipoCliente As Integer) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder()
      Dim blnIncluirFoto As Boolean = False

      Me.SelectTexto(myQuery, blnIncluirFoto, puedeVerDetalleValoracionEstrellas:=False)

      With myQuery
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendLine("   AND C.IdZonaGeografica = '" & idZonaGeografica & "'")
         End If

         If idCategoria > 0 Then
            .AppendLine("   AND C.IdCategoria = " & idCategoria.ToString())
         End If

         If IdCobrador > 0 Then
            .AppendFormat("   AND C.IdCobrador = {0} ", IdCobrador)
         End If

         If CantidadPcs > 0 Then
            .AppendFormat("   AND C.CantidadDePCs {0} {1}", FiltroPcs, CantidadPcs)
         End If
         If idcliente > 0 Then
            .AppendFormat("   AND C.IdCliente = {0} ", idcliente)
         End If

         If idTipoCliente > 0 Then
            .AppendFormat("   AND C.IdTipoCliente = {0} ", idTipoCliente)
         End If

         Select Case filtroActivos
            Case Entidades.Publicos.SiNoTodos.SI
               .AppendLine("   AND C.Activo = 'True' ")
            Case Entidades.Publicos.SiNoTodos.NO
               .AppendLine("   AND C.Activo = 'False' ")
         End Select

         .AppendFormat(" ORDER BY C.Nombre{0} ", ModoClienteProspecto.ToString()).AppendLine()
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function
   Public Sub AplicarClientesABMFiltros(stb As StringBuilder, filtro As Entidades.Filtros.ClientesABMFiltros)
      If filtro IsNot Nothing Then
         With stb
            If filtro.FechaAltaDesde.HasValue Then
               .AppendFormatLine("   AND C.FechaAlta >= '{0}'", ObtenerFecha(filtro.FechaAltaDesde.Value, True))
            End If
            If filtro.FechaAltaHasta.HasValue Then
               .AppendFormatLine("   AND C.FechaAlta <= '{0}'", ObtenerFecha(filtro.FechaAltaHasta.Value, True))
            End If
            Dim formatoFechaNacimientoDesde As String = "   AND C.FechaNacimiento >= '{0:yyyyMMdd HH:mm:ss}'"
            Dim formatoFechaNacimientoHasta As String = "   AND C.FechaNacimiento <= '{0:yyyyMMdd HH:mm:ss}'"
            If Not filtro.FechaNacimientoIncluirAnio Then
               formatoFechaNacimientoDesde = "   AND DATEPART(DAYOFYEAR,C.FechaNacimiento) >= DATEPART(DAYOFYEAR,'{0:yyyyMMdd}')"
               formatoFechaNacimientoHasta = "   AND DATEPART(DAYOFYEAR,C.FechaNacimiento) <= DATEPART(DAYOFYEAR,'{0:yyyyMMdd}')"
            End If
            If filtro.FechaNacimientoDesde.HasValue Then
               .AppendFormatLine(formatoFechaNacimientoDesde, filtro.FechaNacimientoDesde.Value)
            End If
            If filtro.FechaNacimientoHasta.HasValue Then
               .AppendFormatLine(formatoFechaNacimientoHasta, filtro.FechaNacimientoHasta.Value)
            End If
            If filtro.IdVendedor <> 0 Then
               .AppendFormatLine("	 AND C.IdVendedor = {0}", filtro.IdVendedor)
            End If

            If Not String.IsNullOrWhiteSpace(filtro.IdZonaGeografica) Then
               .AppendFormatLine("   AND C.IdZonaGeografica = '{0}'", filtro.IdZonaGeografica)
            End If
            If Not String.IsNullOrWhiteSpace(filtro.NombreCliente) Then
               If filtro.NombreClienteExacto Then
                  .AppendFormatLine("   AND C.NombreCliente = '{0}'", filtro.NombreCliente)
               Else
                  .AppendFormatLine("   AND C.NombreCliente LIKE '%{0}%'", filtro.NombreCliente)
               End If
            End If

         End With
      End If
   End Sub

   Public Function GetPorFiltrosVarios(idVendedor As Integer,
                                       idCliente As Long,
                                       idZonaGeografica As String,
                                       idCategoria As Integer,
                                       idListaDePrecios As Integer,
                                       idFormaPago As Integer,
                                       descPorRecargo As Decimal?,
                                       activo As String,
                                       idTipoComprobante As String,
                                       idEstado As Integer,
                                       recibeNotificaciones As String,
                                       nivelAutorizacion As Short?,
                                       alicuota2deProducto As String,
                                       idCobrador As Integer,
                                       tiposCliente As Entidades.TipoCliente(),
                                       publicarEnWeb As String,
                                       idCategoriaFiscal As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      Dim consultaFoto As Boolean = False
      With stb
         Me.SelectTexto(stb, consultaFoto, puedeVerDetalleValoracionEstrellas:=False)

         .AppendLine("	WHERE 1 = 1")

         If idVendedor > 0 Then
            .AppendLine("	AND C.IdVendedor = " & idVendedor)
         End If

         If idCliente <> 0 Then
            .AppendFormat("    AND C.Id{1} = {0}", idCliente, ModoClienteProspecto.ToString()).AppendLine()
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendLine("   AND C.IdZonaGeografica = '" & idZonaGeografica & "'")
         End If

         If idCategoria > 0 Then
            .AppendLine("   AND C.IdCategoria = " & idCategoria.ToString())
         End If

         If idListaDePrecios > -1 Then
            .AppendLine("   AND C.IdListaPrecios = " & idListaDePrecios.ToString())
         End If

         If idFormaPago > 0 Then
            .AppendFormat("   AND C.IdFormasPago = {0} ", idFormaPago)
         End If

         If descPorRecargo.HasValue Then
            .AppendFormat("   AND C.DescuentoRecargoPorc = {0} ", descPorRecargo.Value)
         End If

         If activo <> "TODOS" Then
            .AppendLine("   AND C.Activo = " & IIf(activo = "SI", "1", "0").ToString())
         End If

         If idTipoComprobante <> "" Then
            .AppendFormat("   AND C.IdTipoComprobante = '{0}' ", idTipoComprobante.ToString())
         End If

         If idCobrador > 0 Then
            .AppendLine("   AND C.IdCobrador = " & idCobrador)
         End If


         'If idCobrador > 0 Then
         '   .AppendFormat("   AND C.IdCobrador = {0} ", idCobrador)
         'End If

         If idEstado > 0 Then
            .AppendFormat("   AND C.IdEstado = {0} ", idEstado)

         End If
         If recibeNotificaciones <> "TODOS" Then
            .AppendLine("   AND C.RecibeNotificaciones = " & IIf(recibeNotificaciones = "SI", "1", "0").ToString())
         End If
         If nivelAutorizacion.HasValue Then
            NivelAutorizacionCliente(stb, "C", "CA", nivelAutorizacion.Value)
         End If

         If Not String.IsNullOrWhiteSpace(alicuota2deProducto) Then
            .AppendFormat("   AND C.Alicuota2deProducto = '{0}' ", alicuota2deProducto)
         End If

         If publicarEnWeb <> "TODOS" Then
            .AppendLine("   AND C.PublicarEnWeb = " & IIf(publicarEnWeb = "SI", "1", "0").ToString())
         End If

         If idCategoriaFiscal > 0 Then
            .AppendLine("   AND C.IdCategoriaFiscal = " & idCategoriaFiscal.ToString())
         End If

         ' # Filtrar por los multiples Tipos Cliente
         GetListaTiposClienteMultiples(stb, tiposCliente, "TCL")

         .AppendFormat(" ORDER BY C.Nombre{0}, C.Codigo{0} ", ModoClienteProspecto.ToString()).AppendLine()

      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorClientesVinculados(idCliente As Long?) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .AppendFormatLine("SELECT IdCliente FROM Clientes WHERE IdClienteCtaCte = {0}", idCliente)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function GetContactosClientes() As DataTable

      Dim stb As StringBuilder = New StringBuilder("")
      Dim consultaFoto As Boolean = False

      With stb

         .AppendLine(" SELECT  Cd.IdCliente ,C.CodigoCliente ,C.NombreCliente ,C.Direccion")
         .AppendLine(" ,C.IdLocalidad,L.NombreLocalidad,P.NombreProvincia ,C.Cuit ,C.CorreoElectronico")
         .AppendLine(" ,C.IdCategoria,Ca.NombreCategoria,CC.Telefono,CC.IdTipoContacto,TC.NombreTipoContacto")
         .AppendLine(" ,CC.Observacion,CD.empresa , sum(cd.deuda_exigible) from ClientesDeudas CD ")
         .AppendLine(" INNER JOIN  Clientes C on c.IdCliente = cd.IdCliente")
         .AppendLine(" LEFT JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad ")
         .AppendLine(" LEFT JOIN Provincias P ON P.IdProvincia = L.IdProvincia ")
         .AppendLine(" LEFT JOIN Categorias Ca ON C.IdCategoria = Ca.IdCategoria ")
         .AppendLine(" LEFT JOIN ClientesContactos CC ON CC.IdCliente = C.IdCliente")
         .AppendLine(" LEFT JOIN TiposContactos TC ON TC.IdTipoContacto = CC.IdTipoContacto ")
         .AppendLine(" GROUP BY  CD.IdCliente ,C.CodigoCliente,C.NombreCliente,C.Direccion,C.IdLocalidad")
         .AppendLine(" ,L.NombreLocalidad,P.NombreProvincia,C.Cuit,C.CorreoElectronico,C.IdCategoria,Ca.NombreCategoria")
         .AppendLine(" ,CC.Telefono,CC.IdTipoContacto,TC.NombreTipoContacto,CC.Observacion,CD.empresa")
         .AppendLine(" ORDER BY cd.IdCliente")

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function
   Public Function GetCantidadProspectoSinCRM() As DataTable

      Dim stb As StringBuilder = New StringBuilder("")
      Dim consultaFoto As Boolean = False

      With stb

         .AppendLine(" SELECT Count(1) Cantidad ")
         .AppendLine("        FROM Prospectos ")
         .AppendLine(" WHERE NOT EXISTS")
         .AppendLine("        (SELECT * ")
         .AppendLine("              FROM CRMNovedades CRMNov ")
         .AppendLine("         WHERE CRMNov.IdTipoNovedad = 'PROSP' ")
         .AppendLine("         AND CRMNov.IdProspecto = Prospectos.IdProspecto) ")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetProspectoSinCRM() As DataTable

      Dim stb As StringBuilder = New StringBuilder("")
      Dim consultaFoto As Boolean = False

      With stb

         .AppendLine(" SELECT P.CodigoProspecto As Código")
         .AppendLine("        ,P.NombreProspecto As Prospecto")
         .AppendLine("        ,P.NombreDeFantasia As Fantasia")
         .AppendLine("        ,TipC.NombreTipoCliente As Tipo")
         .AppendLine("        , Z.NombreZonaGeografica As ZonaGeografica")
         .AppendLine("        ,P.FechaAlta As Alta")
         .AppendLine("      ,E.NombreEmpleado AS Vendedor")
         .AppendLine("        ,P.Observacion As Observación")
         .AppendLine(" FROM Prospectos P ")
         .AppendLine("      LEFT JOIN CRMNovedades AS N ON N.IdProspecto = P.IdProspecto")
         .AppendLine("      LEFT JOIN ZonasGeograficas Z  ON Z.IdZonaGeografica = P.IdZonaGeografica ")
         .AppendLine("      LEFT JOIN Empleados E ON P.IdVendedor = E.IdEmpleado ")
         .AppendFormat("    LEFT OUTER JOIN TiposClientes TipC ON TipC.IdTipoCliente = P.IdTipoCliente")
         .AppendLine(" WHERE NOT EXISTS")
         .AppendLine("        (SELECT * ")
         .AppendLine("              FROM CRMNovedades CRMNov ")
         .AppendLine("         WHERE CRMNov.IdTipoNovedad = 'PROSP' ")
         .AppendLine("         AND CRMNov.IdProspecto = P.IdProspecto) ")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function
   Public Function GetParaEnvioMasivoCorreo(IdVendedor As Integer,
                                            idCliente As Long,
                                            idZonaGeografica As String,
                                            idCategoria As Integer,
                                            idListaDePrecios As Integer,
                                            idFormaPago As Integer,
                                            descPorRecargo As Decimal?,
                                            activo As String,
                                            idTipoComprobante As String,
                                            configMail As String,
                                            RecibeNotificaciones As String,
                                            FiltrarPorEmbarcaciones As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      Dim consultaFoto As Boolean = False

      With stb
         .AppendFormat("SELECT C.Id{0}", ModoClienteProspecto.ToString()).AppendLine()
         .AppendFormat("      ,C.Codigo{0}", ModoClienteProspecto.ToString()).AppendLine()
         .AppendFormat("      ,C.Nombre{0}", ModoClienteProspecto.ToString()).AppendLine()
         .AppendLine("      ,C.NombreDeFantasia")
         .AppendLine("      ,C.Direccion")
         .AppendLine("      ,C.DireccionAdicional")
         .AppendLine("      ,C.IdLocalidad")
         .AppendLine("      ,L.NombreLocalidad")
         .AppendLine("      ,P.NombreProvincia")
         .AppendLine("      ,C.IdCategoriaFiscal")
         .AppendLine("      ,CF.NombreCategoriaFiscal")
         .AppendLine("      ,CFC.LetraFiscal")
         .AppendLine("      ,C.Cuit")
         .AppendFormat("      ,C.TipoDoc{0}", ModoClienteProspecto.ToString()).AppendLine()
         .AppendFormat("      ,C.NroDoc{0}", ModoClienteProspecto.ToString()).AppendLine()
         .AppendLine("      ,C.Telefono")
         .AppendLine("      ,C.Celular")
         .AppendLine("      ,C.IdZonaGeografica")
         .AppendLine("      ,Z.NombreZonaGeografica")
         .AppendLine("      ,C.FechaNacimiento")
         .AppendLine("      ,C.NroOperacion")

         If configMail = Entidades.Cliente.ConfiguracionMail.Principal.ToString() Then
            .AppendLine("     ,C.CorreoElectronico")
         ElseIf configMail = Entidades.Cliente.ConfiguracionMail.Administrativo.ToString() Then
            .AppendLine("     ,C.CorreoAdministrativo AS CorreoElectronico")
         ElseIf configMail = Entidades.Cliente.ConfiguracionMail.AdminyPrincipal.ToString() Then
            .AppendLine("     ,C.CorreoElectronico + ';' + C.CorreoAdministrativo AS CorreoElectronico")
         ElseIf configMail = Entidades.Cliente.ConfiguracionMail.AdminoPrincipal.ToString() Then
            .AppendLine("     ,CASE WHEN ISNULL(C.CorreoAdministrativo, '') = '' THEN C.CorreoElectronico ELSE C.CorreoAdministrativo END AS CorreoElectronico")
         End If

         ' .AppendLine("      ,C.CorreoElectronico")
         ' .AppendLine("      ,C.CorreoAdministrativo")
         .AppendLine("      ,C.NombreTrabajo")
         .AppendLine("      ,C.DireccionTrabajo")
         .AppendLine("      ,C.TelefonoTrabajo")
         .AppendLine("      ,C.CorreoTrabajo")
         .AppendLine("      ,C.IdLocalidadTrabajo")
         .AppendLine("      ,L1.NombreLocalidad NombreLocalidadTrabajo")
         .AppendLine("      ,C.FechaIngresoTrabajo")
         .AppendLine("      ,C.FechaAlta")
         .AppendLine("      ,C.SaldoPendiente")
         .AppendFormat("      ,C.Id{0}Garante", ModoClienteProspecto.ToString()).AppendLine()
         .AppendFormat("      ,C1.Codigo{0} AS CodigoGarante", ModoClienteProspecto.ToString()).AppendLine()
         .AppendFormat("      ,C1.Nombre{0} AS NombreGarante", ModoClienteProspecto.ToString()).AppendLine()
         .AppendLine("      ,C.IdCategoria")
         .AppendLine("      ,Ca.NombreCategoria")
         .AppendLine("      ,C.Observacion")
         .AppendLine("      ,C.IdListaPrecios")
         .AppendLine("      ,LdP.NombreListaPrecios")
         .AppendLine("      ,C.IdVendedor")
         .AppendLine("      ,E.IdEmpleado AS IdVendedor")
         .AppendLine("      ,E.NombreEmpleado AS NombreVendedor")
         .AppendLine("      ,C.LimiteDeCredito ")
         .AppendLine("      ,C.IdSucursalAsociada ")
         .AppendLine("      ,SA.Nombre AS NombreSucursalAsociada")
         .AppendLine("      ,C.IdCaja ")
         .AppendLine("      ,CN.NombreCaja")
         .AppendLine("      ,C.DescuentoRecargoPorc ")
         .AppendLine("      ,C.DescuentoRecargoPorc2 ")
         .AppendLine("      ,C.IdtipoComprobante ")
         .AppendLine("      ,TC.Descripcion ")
         .AppendLine("      ,C.IdFormasPago ")
         .AppendLine("      ,FP.DescripcionFormasPago ")
         .AppendLine("      ,C.IdTransportista")
         .AppendLine("      ,T.NombreTransportista")

         'Solo la busco en el GET1 porque ahi puedo necesitarlo, en todo lo demas NO.
         'Lentifica terriblemente la consulta.
         If consultaFoto Then
            .AppendLine("      ,C.Foto")
         Else
            .AppendLine("      ,NULL AS Foto")
         End If

         .AppendLine("      ,C.Activo ")
         .AppendLine("      ,C.IngresosBrutos")
         .AppendLine("      ,C.InscriptoIBStaFe")
         .AppendLine("      ,C.LocalIB")
         .AppendLine("      ,C.ConvMultilateralIB")
         .AppendLine("      ,C.NumeroLote")
         .AppendLine("      ,C.GeoLocalizacionLat")
         .AppendLine("      ,C.GeoLocalizacionLng")
         .AppendLine("      ,C.IdTipoDeExension")
         .AppendLine("      ,C.AnioExension")
         .AppendLine("      ,C.NroCertExension")
         .AppendLine("      ,C.NroCertPropio")
         .AppendLine("      ,C.PaginaWeb")
         .AppendFormat("      ,C.Id{0}CtaCte", ModoClienteProspecto.ToString()).AppendLine()
         .AppendFormat("      ,C2.Codigo{0} AS Codigo{0}CtaCte", ModoClienteProspecto.ToString()).AppendLine()
         .AppendFormat("      ,C2.Nombre{0} AS Nombre{0}CtaCte", ModoClienteProspecto.ToString()).AppendLine()
         .AppendLine("      ,C.LimiteDiasVtoFactura")
         .AppendLine("      ,C.ModificarDatos")
         .AppendLine("      ,C.EsResidente")
         .AppendLine("      ,C.IdEstado")
         .AppendLine("		 ,EC.NombreEstadoCliente")
         .AppendLine("      ,C.UsaArchivoAImprimir2")
         .AppendLine("      ,C.CantidadVisitas")

         .AppendLine("      ,CONVERT(bit, 0) AS Envio")

         .AppendLine("      ,C.RecibeNotificaciones")

         .AppendLine("      ,C.NombreDeFantasia")
         .AppendLine("      ,C.SiMovilIdUsuario")
         .AppendLine("      ,C.SiMovilClave")
         .AppendLine("      ,C.HorarioClienteCompleto")
         .AppendFormatLine("      ,C.Id{0}TiendaNube", ModoClienteProspecto.ToString())
         .AppendFormatLine("      ,C.Id{0}MercadoLibre", ModoClienteProspecto.ToString())


         .AppendFormat(" FROM {0}s C", ModoClienteProspecto.ToString()).AppendLine()
         .AppendLine(" LEFT JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad ")
         .AppendLine(" LEFT JOIN Provincias P ON P.IdProvincia = L.IdProvincia ")
         .AppendLine(" LEFT JOIN Localidades L1 ON L1.IdLocalidad = C.IdLocalidadTrabajo ")
         .AppendLine(" LEFT JOIN ZonasGeograficas Z  ON Z.IdZonaGeografica = C.IdZonaGeografica ")
         .AppendLine(" LEFT JOIN Categorias Ca ON C.IdCategoria = Ca.IdCategoria ")
         .AppendLine(" LEFT JOIN CategoriasFiscales Cf ON C.IdCategoriaFiscal = Cf.IdCategoriaFiscal ")

         .AppendFormatLine(" CROSS JOIN (SELECT * FROM Parametros WHERE IdParametro = 'CATEGORIAFISCALEMPRESA' AND IdEmpresa = {0}) PAR", actual.Sucursal.IdEmpresa)
         .AppendFormatLine("  LEFT JOIN CategoriasFiscalesConfiguraciones CFC ON CFC.IdCategoriaFiscalCliente = CF.IdCategoriaFiscal AND CFC.IdCategoriaFiscalEmpresa = ISNULL(PAR.ValorParametro, 0)")

         .AppendFormat(" LEFT JOIN {0}s C1 ON C1.Id{0} = C.Id{0}Garante ", ModoClienteProspecto.ToString()).AppendLine()
         .AppendFormat(" LEFT JOIN {0}s C2 ON C2.Id{0} = C.Id{0}CtaCte", ModoClienteProspecto.ToString()).AppendLine()
         .AppendLine(" LEFT JOIN Empleados E ON C.IdVendedor = E.IdEmpleado ")
         .AppendLine(" LEFT JOIN ListasDePrecios LdP ON C.IdListaPrecios = LdP.IdListaPrecios ")
         .AppendLine(" LEFT JOIN EstadosClientes EC ON EC.IdEstadoCliente = C.IdEstado")
         .AppendLine(" LEFT OUTER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante ")
         .AppendLine(" LEFT OUTER JOIN Sucursales SA ON C.IdSucursalAsociada = SA.IdSucursal")
         .AppendLine(" LEFT OUTER JOIN VentasFormasPago FP ON FP.IdFormasPago = C.IdFormasPago")
         .AppendLine(" LEFT OUTER JOIN Transportistas T ON T.IdTransportista = C.IdTransportista")
         .AppendLine(" LEFT OUTER JOIN CajasNombres CN ON CN.IdSucursal = " & actual.Sucursal.IdSucursal.ToString() & " AND CN.IdCaja = C.IdCaja")

         .AppendLine("	WHERE 1 = 1")

         If IdVendedor > 0 Then
            .AppendLine("	AND C.IdVendedor = " & IdVendedor)
         End If

         If idCliente <> 0 Then
            .AppendFormat("    AND C.Id{1} = {0}", idCliente, ModoClienteProspecto.ToString()).AppendLine()
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendLine("   AND C.IdZonaGeografica = '" & idZonaGeografica & "'")
         End If

         If idCategoria > 0 Then
            .AppendLine("   AND C.IdCategoria = " & idCategoria.ToString())
         End If

         If idListaDePrecios > -1 Then
            .AppendLine("   AND C.IdListaPrecios = " & idListaDePrecios.ToString())
         End If

         If idFormaPago > 0 Then
            .AppendFormat("   AND C.IdFormasPago = {0} ", idFormaPago)
         End If

         If descPorRecargo.HasValue Then
            .AppendFormat("   AND C.DescuentoRecargoPorc = {0} ", descPorRecargo.Value)
         End If

         If activo <> "TODOS" Then
            .AppendLine("   AND C.Activo = " & IIf(activo = "SI", "1", "0").ToString())
         End If

         If idTipoComprobante <> "" Then
            .AppendFormat("   AND C.IdTipoComprobante = '{0}' ", idTipoComprobante.ToString())
         End If

         If RecibeNotificaciones <> "TODOS" Then
            .AppendLine("   AND C.RecibeNotificaciones = " & IIf(RecibeNotificaciones = "SI", "1", "0").ToString())
         End If

         '# Solo aplica para SISEN si el filto de Embarcaciones es <> a TODOS
         If FiltrarPorEmbarcaciones <> "TODOS" Then
            .AppendLine("   AND EXISTS (")
            .AppendLine("SELECT DISTINCT EC.IdCliente FROM EmbarcacionesClientes EC")
            .AppendLine("         WHERE 1=1")
            .AppendLine("   AND EC.IdCliente = C.IdCliente")

            Select Case FiltrarPorEmbarcaciones
               Case "Responsable de Cargos"
                  .AppendLine("   AND EC.ResponsableCargos = 1")
               Case "Titulares"
                  .AppendLine("   AND EC.Tipo = 'T'")
               Case "Autorizados"
                  .AppendLine("   AND EC.Tipo = 'A'")
            End Select
            .AppendLine(")")

         End If

         .AppendFormat(" ORDER BY C.Nombre{0}, C.Codigo{0} ", ModoClienteProspecto.ToString()).AppendLine()

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetUnoPorTipoYNroDocumento(tipoDocCliente As String, nroDocCliente As Long) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      Dim consultaFoto As Boolean = False

      Me.SelectTexto(stb, consultaFoto, puedeVerDetalleValoracionEstrellas:=False)

      With stb
         .AppendFormat(" WHERE C.TipoDoc{1} = '{0}'", tipoDocCliente, ModoClienteProspecto.ToString()).AppendLine()
         .AppendFormat("   AND C.NroDoc{1} = {0}", nroDocCliente.ToString(), ModoClienteProspecto.ToString()).AppendLine()
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetUnoPorCUIT(cuit As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      Dim consultaFoto As Boolean = False

      Me.SelectTexto(stb, consultaFoto, puedeVerDetalleValoracionEstrellas:=False)

      With stb
         .AppendFormat(" WHERE C.Cuit = '{0}'", cuit.Replace("-", ""))
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetAuditoriaClientes(fechaDesde As Date, fechaHasta As Date, idCliente As Long, tipoOperacion As String, puedeVerDetalleValoracionEstrellas As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, incluirFoto:=False, puedeVerDetalleValoracionEstrellas, auditoria:=True)

         .AppendFormatLine(" WHERE C.FechaAuditoria >= '{0}'", ObtenerFecha(fechaDesde, False))
         .AppendFormatLine("   AND C.FechaAuditoria <= '{0}'", ObtenerFecha(fechaHasta.UltimoSegundoDelDia, True))
         If tipoOperacion <> "" Then
            .AppendFormatLine("   AND C.OperacionAuditoria = '{0}'", tipoOperacion.Substring(0, 1))
         End If
         If idCliente > 0 Then
            .AppendFormatLine("   AND C.Id{1} = {0}", idCliente.ToString(), ModoClienteProspecto.ToString())
         End If
         .AppendFormatLine(" ORDER BY C.Id{0}, C.FechaAuditoria", ModoClienteProspecto.ToString())
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetClientesExternos(Base As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder

      With stb
         .Length() = 0
         .AppendLine("SELECT * FROM " & Base & ".[dbo].[Clientes]")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Overloads Function Buscar(columna As String, valor As String, filtro As Entidades.Filtros.ClientesABMFiltros, puedeVerDetalleValoracionEstrellas As Boolean) As DataTable
      Select Case columna
         Case "NombreCalle"
            columna = "CL." + columna.Replace("C.", "")
         Case "NombreLocalidad"
            columna = "L." + columna.Replace("C.", "")
         Case "NombreZonaGeografica"
            columna = "Z." + columna.Replace("C.", "")
         Case "NombreLocalidadTrabajo"
            columna = "L1.NombreLocalidad"
         Case "NombreGarante"
            columna = "C1.Nombre" + ModoClienteProspecto.ToString()
         Case "NombreCategoria"
            columna = "Ca." + columna.Replace("C.", "")
         Case "NombreCategoriaCambio"
            columna = "Ca2.NombreCategoria"
         Case "GrupoCategoria"
            columna = "Ca.IdGrupoCategoria"
         Case "NombreCategoriaFiscal"
            columna = "Cf." + columna.Replace("C.", "")
         Case "NombreVendedor"
            columna = "E.NombreEmpleado"
         Case "NombreListaPrecios"
            columna = "LdP.NombreListaPrecios"
         Case "NombreSucursalAsociada"
            columna = "SA.Nombre"
         Case "NombreCaja"
            columna = columna.Replace("C.", "CN.")
         Case "DescripcionFormasPago"
            columna = "FP.DescripcionFormasPago"
         Case "NombreTransportista"
            columna = "T.NombreTransportista"
         Case "NombreProvincia"
            columna = "P.NombreProvincia"
         Case "Nombre" + ModoClienteProspecto.ToString() + "CtaCte"
            columna = "C2.Nombre" + ModoClienteProspecto.ToString()
         Case "Codigo" + ModoClienteProspecto.ToString() + "CtaCte"
            columna = "C2.Codigo" + ModoClienteProspecto.ToString()
         Case "Descripcion"
            columna = "TC.Descripcion"
         Case "IdVendedor"
            columna = "E.IdEmpleado"
         Case "NombreEstadoCliente"
            columna = "EC." + columna.Replace("C.", "")
         Case "NombreTipoCliente"
            columna = "TipC." + columna.Replace("C.", "")
         Case "NombreEmpleado"
            columna = "Cob." + columna.Replace("C.", "")
         Case "NombreCuenta"
            columna = "CCBL.NombreCuenta"
         Case Else
            columna = "C." & columna
      End Select

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb, False, puedeVerDetalleValoracionEstrellas)
         .AppendLine("  WHERE 1=1 ")
         For Each palabra As String In valor.ToString.Split(" "c)
            .AppendLine("   AND " & columna & " LIKE '%" & palabra & "%'")
         Next

         AplicarClientesABMFiltros(stb, filtro)

         .AppendLine(" ORDER BY C.Nombre" + ModoClienteProspecto.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetFiltradoPorVendedor(IdVendedor As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      Me.SelectTexto(stb, False, puedeVerDetalleValoracionEstrellas:=False)
      With stb
         .AppendFormat(" WHERE C.{0} = '{1}'", Entidades.Cliente.Columnas.IdVendedor.ToString(), IdVendedor)
         .AppendFormat(" ORDER BY C.Nombre{0} ", ModoClienteProspecto.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetFiltradoPorCodigo(codigoCliente As Long?, busquedaParcial As Boolean, nombreCliente As String, soloActivos As Boolean,
                                        codigoYDocumento As Boolean, nivelAutorizacion As Short, idCategoria As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      Me.SelectTexto(stb, False, puedeVerDetalleValoracionEstrellas:=False)
      With stb
         If soloActivos Then
            .AppendLine(" WHERE C.Activo = 1 ")
         Else
            .AppendLine(" WHERE 1=1 ")
         End If
         If codigoCliente.HasValue AndAlso codigoCliente.Value > -1 Then
            If busquedaParcial Then
               If codigoYDocumento Then
                  .AppendFormat(" AND (C.Codigo{1} LIKE '%{0}%' OR C.NroDoc{1} LIKE '%{0}%')", codigoCliente.Value, ModoClienteProspecto.ToString())
               Else
                  .AppendFormat(" AND C.Codigo{1} LIKE '%{0}%'", codigoCliente.Value, ModoClienteProspecto.ToString())
               End If
            Else
               If codigoYDocumento Then
                  .AppendFormat(" AND (C.Codigo{1} = {0} OR C.NroDoc{1} = {0})", codigoCliente.Value, ModoClienteProspecto.ToString())
               Else
                  .AppendFormat(" AND C.Codigo{1} = {0}", codigoCliente.Value, ModoClienteProspecto.ToString())
               End If
            End If
         End If

         If Not String.IsNullOrWhiteSpace(nombreCliente) Then
            For Each palabra As String In nombreCliente.Split(" "c)
               If Not String.IsNullOrWhiteSpace(palabra) Then
                  .AppendFormat("   AND (C.Nombre{1} LIKE '%{0}%' OR C.NombreDeFantasia LIKE '%{0}%')", palabra, ModoClienteProspecto.ToString()).AppendLine()
               End If
            Next
         End If

         If idCategoria > 0 Then
            .AppendFormatLine(" AND C.IdCategoria = {0}", idCategoria)
         End If

         NivelAutorizacionCliente(stb, "C", "CA", nivelAutorizacion)

         .AppendFormat(" ORDER BY C.Nombre{0} ", ModoClienteProspecto.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetFiltradoPorDireccion(Direccion As String, nivelAutorizacion As Short) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder()
      Me.SelectTexto(stbQuery, False, puedeVerDetalleValoracionEstrellas:=False)
      With stbQuery
         .AppendLine("  WHERE C.Activo = 1")
         For Each palabra As String In Direccion.Split(" "c)
            .AppendFormat("   AND C.Direccion LIKE '%{0}%'", palabra).AppendLine()
         Next
         NivelAutorizacionCliente(stbQuery, "C", "CA", nivelAutorizacion)

         .AppendFormat(" ORDER BY C.Nombre{0} ", ModoClienteProspecto.ToString())
      End With
      Return Me.GetDataTable(stbQuery.ToString())
   End Function

   Public Function GetFiltradoPorTipoYNroDocumento(tipoDocCliente As String, nroDocCliente As Long) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      Dim consultaFoto As Boolean = False

      Me.SelectTexto(stb, consultaFoto, puedeVerDetalleValoracionEstrellas:=False)

      With stb
         .AppendLine("  WHERE C.Activo = 1 ")
         If Not String.IsNullOrEmpty(tipoDocCliente) Then
            .AppendFormat(" AND C.TipoDoc{1} = '{0}'", tipoDocCliente, ModoClienteProspecto.ToString()).AppendLine()
         End If
         If nroDocCliente <> 0 Then
            .AppendFormat("   AND C.NroDoc{1} = {0}", nroDocCliente.ToString(), ModoClienteProspecto.ToString()).AppendLine()
         End If
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetFiltradoPorCodigoClienteLetras(CodigoClienteLetras As String, busquedaParcial As Boolean) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      Dim consultaFoto As Boolean = False

      Me.SelectTexto(stb, consultaFoto, puedeVerDetalleValoracionEstrellas:=False)

      With stb
         .AppendLine("  WHERE C.Activo = 1 ")
         If Not String.IsNullOrEmpty(CodigoClienteLetras) Then
            If busquedaParcial Then
               .AppendFormat(" AND (C.Codigo{1}Letras Like '%{0}%' )", CodigoClienteLetras, ModoClienteProspecto.ToString())
            Else
               .AppendFormat(" AND (C.Codigo{1}Letras = '{0}' )", CodigoClienteLetras, ModoClienteProspecto.ToString())
            End If
         End If

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function
   Public Function GetFiltradoPorNombre(nombre As String) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder()
      Dim consultaFoto As Boolean = True
      Me.SelectTexto(stbQuery, consultaFoto, False)
      With stbQuery
         .AppendFormat(" WHERE C.NombreCliente LIKE '%{0}%' ", nombre)
         .AppendLine(" ORDER BY C.NombreCliente ")
      End With
      Return Me.GetDataTable(stbQuery.ToString())
   End Function

   Public Function GetFiltradoPorNombrefantasia(NombreFantasia As String, busquedaParcial As Boolean) As DataTable
      Dim stbQuery = New StringBuilder()
      SelectTexto(stbQuery, False, puedeVerDetalleValoracionEstrellas:=False)

      If NombreFantasia.Length > 100 Then
         NombreFantasia = NombreFantasia.Substring(0, 100)
      End If

      With stbQuery
         .AppendLine("  WHERE C.Activo = 1")
         If busquedaParcial Then
            .AppendFormatLine("   AND (C.NombreDeFantasia LIKE '%{0}%' OR C.Nombre{2} LIKE '%{1}%')", NombreFantasia, NombreFantasia, ModoClienteProspecto.ToString())
         Else
            .AppendFormatLine("   AND (C.NombreDeFantasia = '{0}' OR C.Nombre{2} = '{1}')", NombreFantasia, NombreFantasia, ModoClienteProspecto.ToString())
         End If
         .AppendFormat(" ORDER BY C.Nombre{0} ", ModoClienteProspecto.ToString())
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetFiltradoPorCUIT(CUIT As String, nivelAutorizacion As Short, estado As Boolean) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder()
      Me.SelectTexto(stbQuery, False, puedeVerDetalleValoracionEstrellas:=False)
      With stbQuery
         If estado Then
            .AppendLine("  WHERE C.Activo = 1")
         Else
            .AppendLine("  WHERE C.Activo IN (0, 1) ")
         End If
         For Each palabra As String In CUIT.Split(" "c)
            .AppendFormat("   AND C.CUIT LIKE '%{0}%'", palabra).AppendLine()
         Next
         NivelAutorizacionCliente(stbQuery, "C", "CA", nivelAutorizacion)

         .AppendFormat(" ORDER BY C.Nombre{0} ", ModoClienteProspecto.ToString())
      End With
      Return Me.GetDataTable(stbQuery.ToString())
   End Function

   Public Function GetMotoresDeBaseDeDatos() As DataTable

      Dim stb As StringBuilder = New StringBuilder

      With stb
         .Length() = 0
         .AppendLine("SELECT DISTINCT MotorBaseDatos")
         .AppendFormat("  FROM {0}s", ModoClienteProspecto.ToString()).AppendLine()
         .AppendLine("    WHERE MotorBaseDatos IS NOT NULL AND MotorBaseDatos <> ''")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetParaSincronizacionMovil(tipoDireccion As Entidades.TipoDireccion, incluirClientes As String, incluidoEnRuta As Boolean, idCategoria As Integer) As DataTable

      Dim stb = New StringBuilder()
      Dim consultaFoto As Boolean = False

      With stb
         SelectTextoCampos(stb, consultaFoto, puedeVerDetalleValoracionEstrellas:=False, auditoria:=False)

         .AppendLine("      ,CD.IdDireccion")
         .AppendLine("      ,CD.Direccion DireccionSecundaria")
         .AppendLine("      ,CD.IdLocalidad IdLocalidadSecundaria")
         .AppendLine("      ,L3.NombreLocalidad NombreLocalidadSecundaria")
         .AppendLine("      ,CD.IdTipoDireccion")

         '.AppendLine("      ,MRC.IdRuta")
         '.AppendLine("      ,MRC.Dia")
         '.AppendLine("      ,MRC.Orden")
         '.AppendLine("      ,MR.NombreRuta")


         SelectTextoFrom(stb, auditoria:=False)

         .AppendLine("  LEFT JOIN (SELECT CD.* FROM ClientesDirecciones CD --ON CD.IdCliente = C.IdCliente")
         .AppendLine("              INNER JOIN (SELECT IdCliente, IdTipoDireccion, MIN(IdDireccion) IdDireccion")
         .AppendLine("                            FROM ClientesDirecciones")
         .AppendLine("                           GROUP BY IdCliente, IdTipoDireccion) CDM ON CDM.IdCliente = CD.IdCliente")
         .AppendLine("                                                                   AND CDM.IdDireccion = CD.IdDireccion")
         .AppendFormat("              WHERE CD.IdTipoDireccion = {0})", tipoDireccion.IdTipoDireccion).AppendLine()
         .AppendLine("   AS CD ON CD.IdCliente = C.IdCliente")
         .AppendLine("  LEFT JOIN Localidades L3 ON L3.IdLocalidad = CD.IdLocalidad")

         '.AppendLine("  INNER JOIN MovilRutasClientes MRC ON MRC.IdCliente = C.IdCliente")
         '.AppendLine("  INNER JOIN MovilRutas MR ON MR.IdRuta = MRC.IdRuta")

         '.AppendLine("	WHERE MR.Activa = 1")
         .AppendLine("  WHERE C.Activo = 1")
         .AppendLine("  AND C.PublicarEnWeb = 'True' OR (C.PublicarEnGestion = 'True' OR C.PublicarEnEmpresarial = 'True')")
         ' .AppendFormatLine("    OR C.PublicarEnWeb = 'True'") '# Solo clientes con PublicarEnWeb

         If incluirClientes = "SoloClientesConDeuda" Then
            .AppendLine("    AND EXISTS (SELECT CC.IdSucursal")
            .AppendLine("                  FROM CuentasCorrientes CC")
            .AppendLine("         WHERE CC.IdCliente = C.IdCliente")
            .AppendLine("                   AND CC.Saldo > 0)")
         End If

         If incluidoEnRuta Then
            .AppendLine("    AND EXISTS (SELECT MRC.IdCliente")
            .AppendLine("                  FROM MovilRutasClientes MRC")
            .AppendLine("                 INNER JOIN MovilRutas MR ON MR.IdRuta = MRC.IdRuta")
            .AppendLine("         WHERE MRC.IdCliente = C.IdCliente")
            .AppendLine("                   AND MR.Activa = 1)")
         End If

         If idCategoria <> 0 Then
            .AppendFormatLine("   AND C.IdCategoria = {0}", idCategoria)
         End If

         .AppendFormat(" ORDER BY C.Id{0}, C.Nombre{0} ", ModoClienteProspecto.ToString()).AppendLine()
         '.AppendFormat(" ORDER BY MRC.IdRuta, MRC.Dia, MRC.Orden, C.Nombre{0} ", ModoClienteProspecto.ToString()).AppendLine()

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetVendCobrardor(idCliente As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder
      With stb
         .AppendLine("SELECT  IdVendedor")
         .AppendLine("        ,IdCobrador")

         .AppendLine("       FROM  Clientes")
         .AppendFormat("WHERE   (IdCliente = {0})", idCliente)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Sub ActualizarObservacion(idCliente As Long, observacion As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendFormat("UPDATE {0}s SET ", ModoClienteProspecto.ToString())
         .AppendFormat(" Observacion = '{1}'", ModoClienteProspecto.ToString(), observacion.ToString())
         .AppendFormat(" WHERE id{0} = {1}", ModoClienteProspecto.ToString(), idCliente.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Clientes")

   End Sub

   Public Sub ActualizarVersion(codigoCliente As Long,
                              nroVersion As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendFormat("UPDATE {0}s", ModoClienteProspecto.ToString()).AppendLine()
         .AppendFormat("   SET NroVersion = '{0}'", nroVersion.ToString())

         .AppendFormat(" WHERE Id{0} = {1}", ModoClienteProspecto.ToString(), codigoCliente.ToString()).AppendLine()
      End With

      Me.Execute(myQuery.ToString())
      'Me.Sincroniza_I(myQuery.ToString(), "Clientes")

   End Sub


   Public Sub ActualizaCampoDireccion(idCalle As Integer)
      Dim qry As StringBuilder = New StringBuilder()

      With qry
         .AppendLine("UPDATE Clientes")
         .AppendLine("   SET Direccion = CL.NombreCalle + ' ' + CONVERT(VARCHAR(MAX), C.Altura) + ' ' + ISNULL(C.DireccionAdicional, '') COLLATE Modern_Spanish_CI_AS")
         .AppendLine("  FROM Clientes C")
         .AppendLine(" INNER JOIN Calles CL ON CL.IdCalle = C.IdCalle")
         .AppendLine(" WHERE 1 = 1")
         If idCalle > 0 Then
            .AppendFormat("   AND C.IdCalle = {0}", idCalle).AppendLine()
         End If
      End With

      Me.Execute(qry.ToString())
   End Sub

   Public Function GetClientesConVersionApi() As DataTable
      Dim stb As StringBuilder = New StringBuilder
      With stb
         .AppendLine("SELECT IdCliente")
         .AppendLine("     , CodigoCliente")
         .AppendLine("     , NombreCliente")
         .AppendLine("     , URLWebmovilPropio")
         .AppendLine("     , URLWebmovilAdminPropio")
         .AppendLine("     , URLSimovilGestionPropio")
         .AppendLine("     , URLActualizadorPropio")
         .AppendLine("     , NroVersionWebmovilPropio")
         .AppendLine("     , NroVersionWebmovilAdminPropio")
         .AppendLine("     , NroVersionSimovilGestionPropio")
         .AppendLine("     , NroVersionActualizadorPropio")
         .AppendLine("  FROM Clientes")
         .AppendFormatLine("WHERE (ISNULL(URLWebmovilPropio, '') <> '' OR")
         .AppendFormatLine("       ISNULL(URLWebmovilAdminPropio, '') <> '' OR")
         .AppendFormatLine("       ISNULL(URLSimovilGestionPropio, '') <> '' OR")
         .AppendFormatLine("       ISNULL(URLActualizadorPropio, '') <> '')")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Sub ActualizaClientesConVersionApi(idCliente As Long, nroVersionWebmovilPropio As String, nroVersionWebmovilAdminPropio As String, nroVersionSimovilGestionPropio As String, nroVersionActualizadorPropio As String)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE Clientes")
         .AppendFormatLine("   SET NroVersionWebmovilPropio = '{0}'", nroVersionWebmovilPropio)
         .AppendFormatLine("     , NroVersionWebmovilAdminPropio = '{0}'", nroVersionWebmovilAdminPropio)
         .AppendFormatLine("     , NroVersionSimovilGestionPropio = '{0}'", nroVersionSimovilGestionPropio)
         .AppendFormatLine("     , NroVersionActualizadorPropio = '{0}'", nroVersionActualizadorPropio)
         .AppendFormatLine(" WHERE IdCliente = {0}", idCliente)
      End With

      Execute(stb.ToString())
   End Sub


   Public Sub ReCalcularValoracionFacturacion(idCliente As Long)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}s", ModoClienteProspecto.ToString())
         .AppendFormatLine("   SET ValorizacionFacturacion = ValorizacionFacturacionMensual * ValorizacionCoeficienteFacturacion")
         .AppendFormatLine(" WHERE Id{0} = {1}", ModoClienteProspecto.ToString(), idCliente.ToString())
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub ReCalcularValoracionDeuda(idCliente As Long)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}s", ModoClienteProspecto.ToString())
         .AppendFormatLine("   SET ValorizacionDeuda = ValorizacionImporteAdeudado * ValorizacionCoeficienteDeuda")
         .AppendFormatLine(" WHERE Id{0} = {1}", ModoClienteProspecto.ToString(), idCliente.ToString())
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub ReCalcularValoracionCliente(idCliente As Long)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}s", ModoClienteProspecto.ToString())
         .AppendFormatLine("   SET Valorizacion{0} = ValorizacionFacturacion + ValorizacionDeuda + ValorizacionProyecto", ModoClienteProspecto.ToString())
         .AppendFormatLine(" WHERE Id{0} = {1}", ModoClienteProspecto.ToString(), idCliente.ToString())
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub ReCalcularValoracionEstrellas()
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery

         .AppendFormatLine("UPDATE C")
         .AppendFormatLine("   SET C.ValorizacionEstrellas = CASE WHEN CT.Valorizacion{0}Maxima = 0 THEN 0 ELSE CONVERT(DECIMAL(5,2), ROUND(C.Valorizacion{0} / CT.Valorizacion{0}Maxima * 10, 2)) END", ModoClienteProspecto.ToString())
         .AppendFormatLine("  FROM {0}s C", ModoClienteProspecto.ToString())
         .AppendFormatLine(" CROSS JOIN (SELECT MAX(Valorizacion{0}) Valorizacion{0}Maxima FROM {0}s) AS CT", ModoClienteProspecto.ToString())
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Function GetClienteTiendaWeb(idClienteTiendaWeb As String, sTipoTienda As String) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         Me.SelectTexto(query, False, False)
         .AppendFormatLine(" WHERE C.IdCliente{1} = '{0}'", idClienteTiendaWeb, LCase(sTipoTienda))
      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function GetClientesTiendaWeb(fechaUltimaSincronizacion As Date?, sTipoTienda As Entidades.TiendasWeb) As DataTable
      Dim query = New StringBuilder
      With query
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("    CLI.IdCliente as IdCliente")
         .AppendFormatLine("   ,CLI.CorreoAdministrativo as email")
         .AppendFormatLine("   ,CLI.NombreCliente as first_name")
         .AppendFormatLine("   ,'' as last_name")
         .AppendFormatLine("   ,CLI.NombreCliente as username")
         .AppendFormatLine("   ,'' as company")
         .AppendFormatLine("   ,CLI.Direccion as address_1")
         .AppendFormatLine("   ,'' as address_2")
         .AppendFormatLine("   ,LOC.NombreLocalidad as city")
         .AppendFormatLine("   ,LOC.IdProvincia as [state]")
         .AppendFormatLine("   ,CLI.IdLocalidad as postcode")
         .AppendFormatLine("   ,PRO.IdPais as country")
         .AppendFormatLine("   ,CLI.Telefono as phone")
         .AppendFormatLine("   ,(CASE WHEN CLI.IdClienteArborea IS NOT NULL THEN")
         .AppendFormatLine("    (CASE WHEN (CLI.Activo = 'False' OR CLI.PublicarEnWeb = 'False') THEN  'paused' ELSE 'update' END)")
         .AppendFormatLine("    ELSE 'new' END) AS condition")
         .AppendFormatLine("   ,CLI.idclienteArborea as IdClienteArborea")
         '-- REQ-33743.- -------------------------------------------------------------------------------------------------------------------------------------------------------
         .AppendFormatLine("   ,(CASE CLI.idListaPrecios WHEN P.LP1 THEN 0 WHEN P.LP2 THEN 1 WHEN P.LP3 THEN 2 WHEN P.LP4 THEN 3 ELSE 0 END) AS OrdenPrecios ")
         '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
         .AppendFormatLine(" FROM")
         .AppendFormatLine("    Clientes  CLI")
         .AppendFormatLine("    INNER JOIN Localidades LOC ON CLI.IdLocalidad = LOC.IdLocalidad")
         .AppendFormatLine("    INNER JOIN Provincias PRO ON LOC.IdProvincia = PRO.IdProvincia")
         '-- REQ-33743.- -------------------------------------------------------------------------------------------------------------------------------------------------------
         .AppendFormatLine("    CROSS JOIN (SELECT (SELECT ValorParametro FROM Parametros WHERE IdParametro = 'ARBOREALISTAPRECIOS01') LP1,")
         .AppendFormatLine("                       (SELECT ValorParametro FROM Parametros WHERE IdParametro = 'ARBOREALISTAPRECIOS02') LP2,")
         .AppendFormatLine("                       (SELECT ValorParametro FROM Parametros WHERE IdParametro = 'ARBOREALISTAPRECIOS03') LP3,")
         .AppendFormatLine("                       (SELECT ValorParametro FROM Parametros WHERE IdParametro = 'ARBOREALISTAPRECIOS04') LP4) P ")
         '----------------------------------------------------------------------------------------------------------------------------------------------------------------------
         .AppendFormatLine(" WHERE 1=1")

         '-- REQ-34558.- ---------------------
         Select Case sTipoTienda
            Case Entidades.TiendasWeb.ARBOREA
               .AppendFormatLine("	AND ((CLI.Activo = 'True' AND (CLI.PublicarEnArborea = 'True' OR CLI.PublicarEnWeb = 'True') AND (CLI.EsClienteGenerico = 'False')))")
            Case Else
               .AppendFormatLine("	AND ((CLI.Activo = 'True' AND CLI.PublicarEnWeb = 'True') OR (CLI.idClienteArborea IS NOT NULL AND (CLI.Activo = 'False' OR CLI.PublicarEnWeb = 'False') AND (CLI.EsClienteGenerico = 'False')))")
         End Select
         '-------------------------------------

         .AppendFormatLine("	AND (CLI.CorreoAdministrativo IS NOT NULL)")
      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function ExisteClienteTiendaWeb(idClienteTiendaWeb As String, sTipoTienda As String) As Boolean
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT C.IdCliente{1} FROM Clientes C WHERE C.IdCliente{1} = '{0}'", idClienteTiendaWeb, LCase(sTipoTienda))
      End With
      Return Me.GetDataTable(query.ToString()).Rows.Count > 0
   End Function

   Public Function GetEmisionEtiquetasParaBultos(fechaDesde As Date?, fechaHasta As Date?,
                                                 sucursales As Entidades.Sucursal(),
                                                 tiposComprobantes As Entidades.TipoComprobante(),
                                                 letra As String, emisor As Short,
                                                 numeroComprobanteDesde As Long, numeroComprobanteHasta As Long,
                                                 idCliente As Long,
                                                 idTipoDireccion As Integer,
                                                 nombreComienzaPor As String,
                                                 idCategoria As Integer, origenCategoria As Entidades.OrigenFK,
                                                 idTransportista As Integer, origenTransportista As Entidades.OrigenFK,
                                                 idVendedor As Integer, origenVendedor As Entidades.OrigenFK) As DataTable

      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT DISTINCT")
         .AppendFormatLine("       CONVERT(int, 0) CantidadBultos")
         .AppendFormatLine("     , CONVERT(int, 0) CantidadBultosNuevo")
         .AppendFormatLine("     , CONVERT(int, 0) CantidadBultosDesde")
         .AppendFormatLine("     , CONVERT(int, 0) CantidadBultosHasta")
         .AppendFormatLine("     , C.IdCliente")
         .AppendFormatLine("     , C.CodigoCliente")
         .AppendFormatLine("     , C.NombreCliente")
         .AppendFormatLine("     , C.NombreDeFantasia")
         .AppendFormatLine("     , C.Telefono")
         .AppendFormatLine("     , ISNULL(CD.Direccion + ' ' + CD.DireccionAdicional, C.Direccion + ' ' + C.DireccionAdicional) Direccion")
         .AppendFormatLine("     , ISNULL(LCD.IdLocalidad, L.IdLocalidad) IdLocalidad")
         .AppendFormatLine("     , ISNULL(LCD.NombreLocalidad, L.NombreLocalidad) NombreLocalidad")
         .AppendFormatLine("     , ISNULL(PCD.NombreProvincia, P.NombreProvincia) NombreProvincia")
         .AppendFormatLine("     , CAT.IdCategoria")
         .AppendFormatLine("     , CAT.NombreCategoria")
         .AppendFormatLine("     , T.IdTransportista")
         .AppendFormatLine("     , T.NombreTransportista")
         .AppendFormatLine("     , T.DireccionTransportista")
         .AppendFormatLine("     , LT.IdLocalidad IdLocalidadTransportista")
         .AppendFormatLine("     , LT.NombreLocalidad NombreLocalidadTransportista")
         .AppendFormatLine("     , PT.NombreProvincia NombreProvinciaTransportista")
         .AppendFormatLine("     , Ve.IdEmpleado IdVendedor")
         .AppendFormatLine("     , Ve.NombreEmpleado NombreVendedor")
         .AppendFormatLine("     , C.Observacion")

         .AppendFormatLine("  FROM Clientes C")
         .AppendFormatLine("  LEFT JOIN Ventas           V   ON V.IdCliente = C.IdCliente")

         .AppendFormatLine("  LEFT JOIN Localidades      L   ON L.IdLocalidad = C.IdLocalidad")
         .AppendFormatLine("  LEFT JOIN Provincias       P   ON P.IdProvincia = L.IdProvincia")
         .AppendFormatLine("  LEFT JOIN Categorias       CAT ON CAT.IdCategoria   = {0}.IdCategoria", If(origenCategoria = Entidades.OrigenFK.Actual, "C", "V"))
         .AppendFormatLine("  LEFT JOIN Empleados        Ve  ON Ve.IdEmpleado     = {0}.IdVendedor", If(origenVendedor = Entidades.OrigenFK.Actual, "C", "V"))
         .AppendFormatLine("  LEFT JOIN Transportistas   T   ON T.IdTransportista = {0}.IdTransportista", If(origenTransportista = Entidades.OrigenFK.Actual, "C", "V"))
         .AppendFormatLine("  LEFT JOIN Localidades      LT  ON LT.IdLocalidad = T.IdLocalidadTransportista")
         .AppendFormatLine("  LEFT JOIN Provincias       PT  ON PT.IdProvincia = LT.IdProvincia")

         .AppendFormatLine("  LEFT JOIN ClientesDirecciones CD ON CD.IdCliente = C.IdCliente And CD.IdTipoDireccion = {0}", idTipoDireccion)
         .AppendFormatLine("  LEFT JOIN Localidades      LCD ON LCD.IdLocalidad = CD.IdLocalidad")
         .AppendFormatLine("  LEFT JOIN Provincias       PCD ON PCD.IdProvincia = LCD.IdProvincia")

         .AppendFormatLine(" WHERE 1 = 1")

         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND V.Fecha >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("   AND V.Fecha <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
         End If

         GetListaSucursalesMultiples(stb, sucursales, "V")
         GetListaTiposComprobantesMultiples(stb, tiposComprobantes, "V")

         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("  AND V.Letra = '{0}'", letra)
         End If

         If emisor > 0 Then
            .AppendFormatLine("  AND V.CentroEmisor = {0}", emisor)
         End If
         If numeroComprobanteDesde > 0 Then
            .AppendFormatLine("  AND V.NumeroComprobante >= {0}", numeroComprobanteDesde)
         End If
         If numeroComprobanteHasta > 0 Then
            .AppendFormatLine("  AND V.NumeroComprobante <= {0}", numeroComprobanteHasta)
         End If

         If idCliente > 0 Then
            .AppendFormatLine("  AND C.IdCliente = {0}", idCliente)
         End If
         If Not String.IsNullOrWhiteSpace(nombreComienzaPor) Then
            .AppendFormatLine("  AND C.NombreCliente >= '{0}'", nombreComienzaPor)
         End If
         If idCategoria > 0 Then
            .AppendFormatLine("  AND {1}.IdCategoria = {0}", idCategoria, If(origenCategoria = Entidades.OrigenFK.Actual, "C", "V"))
         End If
         If idTransportista > 0 Then
            .AppendFormatLine("  AND {1}.IdTransportista = {0}", idTransportista, If(origenTransportista = Entidades.OrigenFK.Actual, "C", "V"))
         End If
         If idVendedor > 0 Then
            .AppendFormatLine("  AND {1}.IdVendedor = {0}", idVendedor, If(origenVendedor = Entidades.OrigenFK.Actual, "C", "V"))
         End If

      End With
      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetClientesPorVencimientoCambioCategoria(nombreCampo As String, fechaDesde As Date?, fechaHasta As Date) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         'Mostrar Codigo Cliente, Nombre, Categoria, Zona Geografica, Fecha Cambio, Nueva Categoria y Observacion.
         .AppendFormatLine("Select C.CodigoCliente")
         .AppendFormatLine("     ,C.NombreCliente")
         .AppendFormatLine("     ,Ca.NombreCategoria")
         .AppendFormatLine("     ,ZG.NombreZonaGeografica")
         '.AppendFormatLine("     ,C.FechaCambioCategoria")
         .AppendFormatLine("     ,Ca2.NombreCategoria as NombreCategoriaCambio")

         .AppendFormatLine("     ,C.ObservacionCambioCategoria")

         .AppendFormatLine("  	  ,C.{0}", nombreCampo)

         .AppendFormatLine("     FROM Clientes C")

         .AppendFormatLine("     INNER JOIN Categorias Ca on C.IdCategoria = Ca.IdCategoria")
         .AppendFormatLine("     INNER JOIN Categorias Ca2 on C.IdCategoriaCambio = Ca2.IdCategoria")

         .AppendFormatLine("     INNER JOIN ZonasGeograficas ZG on C.IdZonaGeografica = ZG.IdZonaGeografica")

         .AppendFormatLine(" WHERE C.IdCategoriaCambio <> 0 ")

         If fechaDesde.HasValue Then
            .AppendFormat("     AND (C.{0} >= '{1}')", nombreCampo, ObtenerFecha(fechaDesde.Value, False)).AppendLine()
         End If
         .AppendFormat("     AND (C.{0} <= '{1}')", nombreCampo, ObtenerFecha(fechaHasta.Date.AddDays(1).AddSeconds(-1), False)).AppendLine()
         .AppendLine(" ORDER BY C.NombreCliente, Ca.NombreCategoria")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetInformeClientesDescuentosPMR(idProducto As String,
                                                   idMarca As Integer,
                                                   idRubro As Integer,
                                                   idSubRubro As Integer,
                                                   idCliente As Long,
                                                   maxRegistros As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT TOP {0} ", maxRegistros)
         .AppendFormatLine(" D.IdProducto")
         .AppendFormatLine("  ,D.NombreProducto")
         .AppendFormatLine("  ,D.IdMarca")
         .AppendFormatLine("  ,D.NombreMarca")
         .AppendFormatLine("  ,D.IdRubro")
         .AppendFormatLine("  ,D.NombreRubro")
         .AppendFormatLine("  ,D.IdSubRubro")
         .AppendFormatLine("  ,D.NombreSubRubro")
         .AppendFormatLine("  ,D.IdSubSubRubro")
         .AppendFormatLine("  ,D.NombreSubSubRubro")
         .AppendFormatLine("  ,D.IdCliente")
         .AppendFormatLine("  ,D.CodigoCliente")
         .AppendFormatLine("  ,D.NombreCliente")
         .AppendFormatLine("  ,D.NombreCategoria")

         '-----------------------------------------PRODUCTOS----------------------------------------------
         .AppendFormatLine("  ,MAX(D.ClienteGralDescuentoRecargoPorc) ClienteGralDescuentoRecargoPorc")
         .AppendFormatLine("  ,MAX(D.ClienteGralDescuentoRecargoPorc2) ClienteGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,MAX(D.ProductoGralDescRecProducto) ProductoGralDescRecProducto")
         .AppendFormatLine("  ,MAX(D.ProductoUHPorc1) ProductoUHPorc1")
         .AppendFormatLine("  ,MAX(D.ProductoUHPorc2) ProductoUHPorc2")
         .AppendFormatLine("  ,MAX(D.ProductoUHPorc3) ProductoUHPorc3")
         .AppendFormatLine("  ,MAX(D.ProductoUHPorc4) ProductoUHPorc4")
         .AppendFormatLine("  ,MAX(D.ProductoUHPorc5) ProductoUHPorc5")
         .AppendFormatLine("  ,MAX(D.ProductoUnidHasta1) ProductoUnidHasta1")
         .AppendFormatLine("  ,MAX(D.ProductoUnidHasta2) ProductoUnidHasta2")
         .AppendFormatLine("  ,MAX(D.ProductoUnidHasta3) ProductoUnidHasta3")
         .AppendFormatLine("  ,MAX(D.ProductoUnidHasta4) ProductoUnidHasta4")
         .AppendFormatLine("  ,MAX(D.ProductoUnidHasta5) ProductoUnidHasta5")
         .AppendFormatLine("  ,MAX(D.ListaPreciosDescuentoRecargoPorc) ListaPreciosDescuentoRecargoPorc")
         .AppendFormatLine("  ,MAX(D.CategoriaDescuentoRecargo) CategoriaDescuentoRecargo")

         '-----------------------------------------MARCAS/RUBROS/SUBRUBROS----------------------------------------------
         .AppendFormatLine("  ,MAX(D.MarcaGralDescuentoRecargoPorc1) MarcaGralDescuentoRecargoPorc1")
         .AppendFormatLine("  ,MAX(D.MarcaGralDescuentoRecargoPorc2) MarcaGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,MAX(D.RubroGralDescuentoRecargoPorc1) RubroGralDescuentoRecargoPorc1")
         .AppendFormatLine("  ,MAX(D.RubroGralDescuentoRecargoPorc2) RubroGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,MAX(D.RubroUHPorc1) RubroUHPorc1")
         .AppendFormatLine("  ,MAX(D.RubroUHPorc2) RubroUHPorc2")
         .AppendFormatLine("  ,MAX(D.RubroUHPorc3) RubroUHPorc3")
         .AppendFormatLine("  ,MAX(D.RubroUHPorc4) RubroUHPorc4")
         .AppendFormatLine("  ,MAX(D.RubroUHPorc5) RubroUHPorc5")
         .AppendFormatLine("  ,MAX(D.RubroUnidHasta1) RubroUnidHasta1")
         .AppendFormatLine("  ,MAX(D.RubroUnidHasta2) RubroUnidHasta2")
         .AppendFormatLine("  ,MAX(D.RubroUnidHasta3) RubroUnidHasta3")
         .AppendFormatLine("  ,MAX(D.RubroUnidHasta4) RubroUnidHasta4")
         .AppendFormatLine("  ,MAX(D.RubroUnidHasta5) RubroUnidHasta5")
         .AppendFormatLine("  ,MAX(D.SubRubroDescuentoRecargoPorc1) SubRubroDescuentoRecargoPorc1")
         .AppendFormatLine("  ,MAX(D.SubRubroDescuentoRecargoPorc2) SubRubroDescuentoRecargoPorc2")
         .AppendFormatLine("  ,MAX(D.SubRubroUHPorc1) SubRubroUHPorc1")
         .AppendFormatLine("  ,MAX(D.SubRubroUHPorc2) SubRubroUHPorc2")
         .AppendFormatLine("  ,MAX(D.SubRubroUHPorc3) SubRubroUHPorc3")
         .AppendFormatLine("  ,MAX(D.SubRubroUHPorc4) SubRubroUHPorc4")
         .AppendFormatLine("  ,MAX(D.SubRubroUHPorc5) SubRubroUHPorc5")
         .AppendFormatLine("  ,MAX(D.SubRubroUnidHasta1) SubRubroUnidHasta1")
         .AppendFormatLine("  ,MAX(D.SubRubroUnidHasta2) SubRubroUnidHasta2")
         .AppendFormatLine("  ,MAX(D.SubRubroUnidHasta3) SubRubroUnidHasta3")
         .AppendFormatLine("  ,MAX(D.SubRubroUnidHasta4) SubRubroUnidHasta4")
         .AppendFormatLine("  ,MAX(D.SubRubroUnidHasta5) SubRubroUnidHasta5")

         '-----------------------------------------CLIENTES----------------------------------------------
         .AppendFormatLine("  ,MAX(D.ClienteProductoDescuentoRecargoPorc1) ClienteProductoDescuentoRecargoPorc1")
         .AppendFormatLine("  ,MAX(D.ClienteProductoDescuentoRecargoPorc2) ClienteProductoDescuentoRecargoPorc2")
         .AppendFormatLine("  ,MAX(D.ClienteMarcaDescuentoRecargoPorc1) ClienteMarcaDescuentoRecargoPorc1")
         .AppendFormatLine("  ,MAX(D.ClienteMarcaDescuentoRecargoPorc2) ClienteMarcaDescuentoRecargoPorc2")
         .AppendFormatLine("  ,MAX(D.ClienteRubroDescuentoRecargoPorc1) ClienteRubroDescuentoRecargoPorc1")
         .AppendFormatLine("  ,MAX(D.ClienteRubroDescuentoRecargoPorc2) ClienteRubroDescuentoRecargoPorc2")
         .AppendFormatLine("  ,MAX(D.ClienteSubRubroDescuentoRecargo) ClienteSubRubroDescuentoRecargo")
         .AppendFormatLine("  ,MAX(D.CategoriaRubroDescuentoRecargoPorc1) CategoriaRubroDescuentoRecargoPorc1")
         .AppendFormatLine("  ,MAX(D.CategoriaSubRubroDescuentoRecargoPorc1) CategoriaSubRubroDescuentoRecargoPorc1")
         .AppendFormatLine("  ,MAX(D.CategoriaSubSubRubroDescuentoRecargoPorc1) CategoriaSubSubRubroDescuentoRecargoPorc1")

         .AppendFormatLine("FROM ")
         .AppendFormatLine(" ( ")

         .AppendFormatLine("SELECT P.IdProducto")
         .AppendFormatLine("  ,P.NombreProducto")
         .AppendFormatLine("  ,P.IdMarca")
         .AppendFormatLine("  ,M.NombreMarca")
         .AppendFormatLine("  ,P.IdRubro")
         .AppendFormatLine("  ,R.NombreRubro")
         .AppendFormatLine("  ,P.IdSubRubro")
         .AppendFormatLine("  ,SR.NombreSubRubro")
         .AppendFormatLine("  ,P.IdSubSubRubro")
         .AppendFormatLine("  ,SSR.NombreSubSubRubro")
         .AppendFormatLine("  ,C.IdCliente")
         .AppendFormatLine("  ,C.CodigoCliente")
         .AppendFormatLine("  ,C.NombreCliente")
         .AppendFormatLine("  ,Ca.NombreCategoria")

         .AppendFormatLine("  ,NULLIF(C.DescuentoRecargoPorc, 0) ClienteGralDescuentoRecargoPorc")
         .AppendFormatLine("  ,NULLIF(C.DescuentoRecargoPorc2, 0) ClienteGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoGralDescRecProducto")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc3")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc4")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta3")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta4")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta5")
         .AppendFormatLine("  ,NULLIF(LP.DescuentoRecargoPorc, 0) ListaPreciosDescuentoRecargoPorc")
         .AppendFormatLine("  ,NULLIF(Ca.DescuentoRecargo, 0) CategoriaDescuentoRecargo")

         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) MarcaGralDescuentoRecargoPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) MarcaGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroGralDescuentoRecargoPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUHPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUHPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUHPorc3")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUHPorc4")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta3")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta4")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroDescuentoRecargoPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc3")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc4")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta3")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta4")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta5")

         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteProductoDescuentoRecargoPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteProductoDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteMarcaDescuentoRecargoPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteMarcaDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteRubroDescuentoRecargoPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteRubroDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteSubRubroDescuentoRecargo")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaRubroDescuentoRecargoPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaSubRubroDescuentoRecargoPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaSubSubRubroDescuentoRecargoPorc1")

         .AppendFormatLine("     FROM Clientes C ")
         .AppendFormatLine("     CROSS JOIN (SELECT CONVERT(INT, ValorParametro) IdListaPreciosDefault FROM Parametros WHERE IdParametro = 'LISTAPRECIOSPREDETERMINADA') PR")
         .AppendFormatLine("     LEFT JOIN ListasDePrecios LP ON LP.IdListaPrecios = ISNULL(C.IdListaPrecios, PR.IdListaPreciosDefault)")
         .AppendFormatLine("     LEFT JOIN Categorias Ca ON Ca.IdCategoria = C.IdCategoria")
         .AppendFormatLine("     CROSS JOIN Productos P")
         .AppendFormatLine("     LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendFormatLine("     LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendFormatLine("     LEFT JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")
         .AppendFormatLine("     LEFT JOIN SubSubRubros SSR ON SSR.IdSubSubRubro = P.IdSubSubRubro")
         .AppendFormatLine("     WHERE P.Activo = 'True'")
         .AppendFormatLine("     AND C.Activo = 'True'")
         .AppendFormatLine("     AND (ISNULL(C.DescuentoRecargoPorc, 0) <> 0")
         .AppendFormatLine("     OR ISNULL(C.DescuentoRecargoPorc2, 0) <> 0")
         .AppendFormatLine("     OR ISNULL(LP.DescuentoRecargoPorc, 0) <> 0")
         .AppendFormatLine("     OR ISNULL(Ca.DescuentoRecargo, 0) <> 0")

         .AppendFormatLine(" ) ")

         .AppendFormatLine("UNION ALL")

         .AppendFormatLine("SELECT P.IdProducto ")
         .AppendFormatLine("  ,P.NombreProducto")
         .AppendFormatLine("  ,P.IdMarca")
         .AppendFormatLine("  ,M.NombreMarca")
         .AppendFormatLine("  ,P.IdRubro")
         .AppendFormatLine("  ,R.NombreRubro")
         .AppendFormatLine("  ,P.IdSubRubro")
         .AppendFormatLine("  ,SR.NombreSubRubro")
         .AppendFormatLine("  ,P.IdSubSubRubro")
         .AppendFormatLine("  ,SSR.NombreSubSubRubro")
         .AppendFormatLine("  ,C.IdCliente")
         .AppendFormatLine("  ,C.CodigoCliente")
         .AppendFormatLine("  ,C.NombreCliente")
         .AppendFormatLine("  ,Ca.NombreCategoria")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteGralDescuentoRecargoPorc")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,NULLIF(P.DescRecProducto, 0) ProductoGralDescRecProducto")
         .AppendFormatLine("  ,NULLIF(P.UHPorc1, 0) ProductoUHPorc1")
         .AppendFormatLine("  ,NULLIF(P.UHPorc2, 0) ProductoUHPorc2")
         .AppendFormatLine("  ,NULLIF(P.UHPorc3, 0) ProductoUHPorc3")
         .AppendFormatLine("  ,NULLIF(P.UHPorc4, 0) ProductoUHPorc4")
         .AppendFormatLine("  ,NULLIF(P.UHPorc5, 0) ProductoUHPorc5")
         .AppendFormatLine("  ,NULLIF(P.UnidHasta1, 0) ProductoUnidHasta1")
         .AppendFormatLine("  ,NULLIF(P.UnidHasta2, 0) ProductoUnidHasta2")
         .AppendFormatLine("  ,NULLIF(P.UnidHasta3, 0) ProductoUnidHasta3")
         .AppendFormatLine("  ,NULLIF(P.UnidHasta4, 0) ProductoUnidHasta4")
         .AppendFormatLine("  ,NULLIF(P.UnidHasta5, 0) ProductoUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ListaPreciosDescuentoRecargoPorc")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaDescuentoRecargo")
         .AppendFormatLine("  ,NULLIF(M.DescuentoRecargoPorc1, 0) MarcaGralDescuentoRecargoPorc1")
         .AppendFormatLine("  ,NULLIF(M.DescuentoRecargoPorc2, 0) MarcaGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,NULLIF(R.DescuentoRecargoPorc1, 0) RubroGralDescuentoRecargoPorc1")
         .AppendFormatLine("  ,NULLIF(R.DescuentoRecargoPorc2, 0) RubroGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,NULLIF(R.UHPorc1, 0) RubroUHPorc1")
         .AppendFormatLine("  ,NULLIF(R.UHPorc2, 0) RubroUHPorc2")
         .AppendFormatLine("  ,NULLIF(R.UHPorc3, 0) RubroUHPorc3")
         .AppendFormatLine("  ,NULLIF(R.UHPorc4, 0) RubroUHPorc4")
         .AppendFormatLine("  ,NULLIF(R.UHPorc5, 0) RubroUHPorc5")
         .AppendFormatLine("  ,NULLIF(R.UnidHasta1, 0) RubroUnidHasta1")
         .AppendFormatLine("  ,NULLIF(R.UnidHasta2, 0) RubroUnidHasta2")
         .AppendFormatLine("  ,NULLIF(R.UnidHasta3, 0) RubroUnidHasta3")
         .AppendFormatLine("  ,NULLIF(R.UnidHasta4, 0) RubroUnidHasta4")
         .AppendFormatLine("  ,NULLIF(R.UnidHasta5, 0) RubroUnidHasta5")
         .AppendFormatLine("  ,NULLIF(SR.DescuentoRecargoPorc1, 0) SubRubroDescuentoRecargoPorc1")
         .AppendFormatLine("  ,NULLIF(SR.DescuentoRecargoPorc2 , 0) SubRubroDescuentoRecargoPorc2")
         .AppendFormatLine("  ,NULLIF(SR.UHPorc1, 0) SubRubroUHPorc1")
         .AppendFormatLine("  ,NULLIF(SR.UHPorc2, 0) SubRubroUHPorc2")
         .AppendFormatLine("  ,NULLIF(SR.UHPorc3, 0) SubRubroUHPorc3")
         .AppendFormatLine("  ,NULLIF(SR.UHPorc4, 0) SubRubroUHPorc4")
         .AppendFormatLine("  ,NULLIF(SR.UHPorc5, 0) SubRubroUHPorc5")
         .AppendFormatLine("  ,NULLIF(SR.UnidHasta1, 0) SubRubroUnidHasta1")
         .AppendFormatLine("  ,NULLIF(SR.UnidHasta2, 0) SubRubroUnidHasta2")
         .AppendFormatLine("  ,NULLIF(SR.UnidHasta3, 0) SubRubroUnidHasta3")
         .AppendFormatLine("  ,NULLIF(SR.UnidHasta4, 0) SubRubroUnidHasta4")
         .AppendFormatLine("  ,NULLIF(SR.UnidHasta5, 0) SubRubroUnidHasta5")

         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteProductoDescuentoRecargoPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteProductoDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteMarcaDescuentoRecargoPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteMarcaDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteRubroDescuentoRecargoPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteRubroDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteSubRubroDescuentoRecargo")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaRubroDescuentoRecargoPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaSubRubroDescuentoRecargoPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaSubSubRubroDescuentoRecargoPorc1")

         .AppendFormatLine("  FROM Productos P")
         .AppendFormatLine("  LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendFormatLine("  LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendFormatLine("  LEFT JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")
         .AppendFormatLine("  LEFT JOIN SubSubRubros SSR ON SSR.IdSubSubRubro = P.IdSubSubRubro")
         .AppendFormatLine("  CROSS JOIN Clientes C")
         .AppendFormatLine("  LEFT JOIN Categorias Ca ON Ca.IdCategoria = C.IdCategoria")
         .AppendFormatLine("  WHERE P.Activo = 'True'")
         .AppendFormatLine("  AND C.Activo = 'True'")
         .AppendFormatLine("  AND ( ")
         .AppendFormatLine("  ISNULL(P.DescRecProducto, 0) <> 0 OR  ")
         .AppendFormatLine("  ISNULL(P.UnidHasta1, 0) <> 0 OR ")
         .AppendFormatLine("  ISNULL(P.UnidHasta2, 0) <> 0 OR")
         .AppendFormatLine("  ISNULL(P.UnidHasta3, 0) <> 0 OR")
         .AppendFormatLine("  ISNULL(P.UnidHasta4, 0) <> 0 OR")
         .AppendFormatLine("  ISNULL(P.UnidHasta5, 0) <> 0 OR")
         .AppendFormatLine("  ISNULL(M.DescuentoRecargoPorc1, 0) <> 0 OR")
         .AppendFormatLine("  ISNULL(M.DescuentoRecargoPorc2, 0) <> 0 OR")
         .AppendFormatLine("  ISNULL(R.DescuentoRecargoPorc1, 0) <> 0 OR")
         .AppendFormatLine("  ISNULL(R.DescuentoRecargoPorc2, 0) <> 0 OR")
         .AppendFormatLine("  ISNULL(R.UnidHasta1, 0) <> 0 OR")
         .AppendFormatLine("  ISNULL(R.UnidHasta2, 0) <> 0 OR")
         .AppendFormatLine("  ISNULL(R.UnidHasta3, 0) <> 0 OR")
         .AppendFormatLine("  ISNULL(R.UnidHasta4, 0) <> 0 OR")
         .AppendFormatLine("  ISNULL(R.UnidHasta5, 0) <> 0 OR")
         .AppendFormatLine("  ISNULL(SR.DescuentoRecargoPorc1, 0) <> 0 OR")
         .AppendFormatLine("  ISNULL(SR.DescuentoRecargoPorc2, 0) <> 0 OR")
         .AppendFormatLine("  ISNULL(SR.UnidHasta1, 0) <> 0 OR")
         .AppendFormatLine("  ISNULL(SR.UnidHasta2, 0) <> 0 OR")
         .AppendFormatLine("  ISNULL(SR.UnidHasta3, 0) <> 0 OR")
         .AppendFormatLine("  ISNULL(SR.UnidHasta4, 0) <> 0 OR")
         .AppendFormatLine("  ISNULL(SR.UnidHasta5, 0) <> 0")
         .AppendFormatLine("  ) ")


         .AppendFormatLine("UNION ALL ")
         .AppendFormatLine("SELECT P.IdProducto")
         .AppendFormatLine("  ,P.NombreProducto")
         .AppendFormatLine("  ,P.IdMarca")
         .AppendFormatLine("  ,M.NombreMarca")
         .AppendFormatLine("  ,P.IdRubro")
         .AppendFormatLine("  ,R.NombreRubro")
         .AppendFormatLine("  ,P.IdSubRubro")
         .AppendFormatLine("  ,SR.NombreSubRubro")
         .AppendFormatLine("  ,P.IdSubSubRubro")
         .AppendFormatLine("  ,SSR.NombreSubSubRubro")
         .AppendFormatLine("  ,C.IdCliente")
         .AppendFormatLine("  ,C.CodigoCliente")
         .AppendFormatLine("  ,C.NombreCliente")
         .AppendFormatLine("  ,Ca.NombreCategoria")


         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteGralDescuentoRecargoPorc")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoGralDescRecProducto")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc3")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc4")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta3")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta4")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ListaPreciosDescuentoRecargoPorc")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaDescuentoRecargo")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) MarcaGralDescuentoRecargoPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) MarcaGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroGralDescuentoRecargoPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUHPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUHPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUHPorc3")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUHPorc4")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta3")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta4")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroDescuentoRecargoPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc3")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc4")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta3")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta4")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta5")

         .AppendFormatLine("  ,NULLIF(CDP.DescuentoRecargoPorc1, 0) ClienteProductoDescuentoRecargoPorc1")
         .AppendFormatLine("  ,NULLIF(CDP.DescuentoRecargoPorc2, 0) ClienteProductoDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteMarcaDescuentoRecargoPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteMarcaDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteRubroDescuentoRecargoPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteRubroDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteSubRubroDescuentoRecargo")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaRubroDescuentoRecargoPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaSubRubroDescuentoRecargoPorc1")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaSubSubRubroDescuentoRecargoPorc1")

         .AppendFormatLine("  FROM ClientesDescuentosProductos CDP")
         .AppendFormatLine("    INNER JOIN Clientes C ON C.IdCliente = CDP.IdCliente")
         .AppendFormatLine("    INNER JOIN Productos P ON P.IdProducto= CDP.IdProducto")
         .AppendFormatLine("    INNER JOIN Categorias Ca ON Ca.IdCategoria = C.IdCategoria")
         .AppendFormatLine("    INNER JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendFormatLine("    INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendFormatLine("    LEFT JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")
         .AppendFormatLine("    LEFT JOIN SubSubRubros SSR ON SSR.IdSubSubRubro = P.IdSubSubRubro")
         .AppendFormatLine("    WHERE P.Activo = 'True'")
         .AppendFormatLine("    AND C.Activo = 'True'")

         .AppendFormatLine("UNION ALL")
         .AppendFormatLine("SELECT P.IdProducto")
         .AppendFormatLine("  ,P.NombreProducto")
         .AppendFormatLine("  ,P.IdMarca")
         .AppendFormatLine("  ,M.NombreMarca")
         .AppendFormatLine("  ,P.IdRubro")
         .AppendFormatLine("  ,R.NombreRubro")
         .AppendFormatLine("  ,P.IdSubRubro")
         .AppendFormatLine("  ,SR.NombreSubRubro")
         .AppendFormatLine("  ,P.IdSubSubRubro")
         .AppendFormatLine("  ,SSR.NombreSubSubRubro")
         .AppendFormatLine("  ,C.IdCliente")
         .AppendFormatLine("  ,C.CodigoCliente")
         .AppendFormatLine("  ,C.NombreCliente")
         .AppendFormatLine("  ,Ca.NombreCategoria")

         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteGralDescuentoRecargoPorc, CONVERT(DECIMAL(9,2), NULL) ClienteGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoGralDescRecProducto")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc1, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc2, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc3, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc4, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta1, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta2, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta3, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta4, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ListaPreciosDescuentoRecargoPorc")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaDescuentoRecargo")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) MarcaGralDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) MarcaGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroGralDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) RubroGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUHPorc1, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc2, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc3, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc4, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta1, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta2, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta3, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta4, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) SubRubroDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc1, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc2, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc3, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc4, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta1, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta2, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta3, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta4, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteProductoDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) ClienteProductoDescuentoRecargoPorc2")
         .AppendFormatLine("  ,NULLIF(CDM.DescuentoRecargoPorc1, 0) ClienteMarcaDescuentoRecargoPorc1, NULLIF(CDM.DescuentoRecargoPorc2, 0) ClienteMarcaDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteRubroDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) ClienteRubroDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteSubRubroDescuentoRecargo")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaRubroDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) CategoriaSubRubroDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) CategoriaSubSubRubroDescuentoRecargoPorc1")

         .AppendFormatLine("FROM ClientesDescuentosMarcas CDM ")
         .AppendFormatLine("  INNER JOIN Clientes C ON C.IdCliente = CDM.IdCliente")
         .AppendFormatLine("  INNER JOIN Marcas M ON M.IdMarca = CDM.IdMarca")
         .AppendFormatLine("  INNER JOIN Categorias Ca ON Ca.IdCategoria = C.IdCategoria")
         .AppendFormatLine("  INNER JOIN Productos P ON P.IdMarca = M.IdMarca")
         .AppendFormatLine("  INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendFormatLine("  LEFT JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")
         .AppendFormatLine("  LEFT JOIN SubSubRubros SSR ON SSR.IdSubSubRubro = P.IdSubSubRubro")
         .AppendFormatLine("  WHERE P.Activo = 'True'")
         .AppendFormatLine("  AND C.Activo = 'True'")

         .AppendFormatLine("  UNION ALL")
         .AppendFormatLine("SELECT P.IdProducto")
         .AppendFormatLine("  ,P.NombreProducto")
         .AppendFormatLine("  ,P.IdMarca")
         .AppendFormatLine("  ,M.NombreMarca")
         .AppendFormatLine("  ,P.IdRubro")
         .AppendFormatLine("  ,R.NombreRubro")
         .AppendFormatLine("  ,P.IdSubRubro")
         .AppendFormatLine("  ,SR.NombreSubRubro")
         .AppendFormatLine("  ,P.IdSubSubRubro")
         .AppendFormatLine("  ,SSR.NombreSubSubRubro")
         .AppendFormatLine("  ,C.IdCliente")
         .AppendFormatLine("  ,C.CodigoCliente")
         .AppendFormatLine("  ,C.NombreCliente")
         .AppendFormatLine("  ,Ca.NombreCategoria")

         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteGralDescuentoRecargoPorc, CONVERT(DECIMAL(9,2), NULL) ClienteGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoGralDescRecProducto")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc1, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc2, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc3, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc4, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta1, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta2, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta3, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta4, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ListaPreciosDescuentoRecargoPorc")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaDescuentoRecargo")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) MarcaGralDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) MarcaGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroGralDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) RubroGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUHPorc1, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc2, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc3, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc4, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta1, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta2, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta3, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta4, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) SubRubroDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc1, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc2, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc3, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc4, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta1, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta2, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta3, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta4, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteProductoDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) ClienteProductoDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteMarcaDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) ClienteMarcaDescuentoRecargoPorc2")
         .AppendFormatLine("  ,NULLIF(CDR.DescuentoRecargoPorc1, 0) ClienteRubroDescuentoRecargoPorc1, NULLIF(CDR.DescuentoRecargoPorc1, 0) ClienteRubroDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteSubRubroDescuentoRecargo")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaRubroDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) CategoriaSubRubroDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) CategoriaSubSubRubroDescuentoRecargoPorc1")

         .AppendFormatLine("  FROM ClientesDescuentosRubros CDR")
         .AppendFormatLine("  INNER JOIN Clientes C ON C.IdCliente = CDR.IdCliente")
         .AppendFormatLine("  INNER JOIN Rubros R ON R.IdRubro = CDR.IdRubro")
         .AppendFormatLine("  INNER JOIN Categorias Ca ON Ca.IdCategoria = C.IdCategoria")
         .AppendFormatLine("  INNER JOIN Productos P ON P.IdRubro = R.IdRubro")
         .AppendFormatLine("  INNER JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendFormatLine("  LEFT JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")
         .AppendFormatLine("  LEFT JOIN SubSubRubros SSR ON SSR.IdSubSubRubro = P.IdSubSubRubro")
         .AppendFormatLine("  WHERE P.Activo = 'True' ")
         .AppendFormatLine("  AND C.Activo = 'True'")

         .AppendFormatLine("UNION ALL")
         .AppendFormatLine("  SELECT P.IdProducto")
         .AppendFormatLine("  ,P.NombreProducto")
         .AppendFormatLine("  ,P.IdMarca")
         .AppendFormatLine("  ,M.NombreMarca")
         .AppendFormatLine("  ,P.IdRubro")
         .AppendFormatLine("  ,R.NombreRubro")
         .AppendFormatLine("  ,P.IdSubRubro")
         .AppendFormatLine("  ,SR.NombreSubRubro")
         .AppendFormatLine("  ,P.IdSubSubRubro")
         .AppendFormatLine("  ,SSR.NombreSubSubRubro")
         .AppendFormatLine("  ,C.IdCliente")
         .AppendFormatLine("  ,C.CodigoCliente")
         .AppendFormatLine("  ,C.NombreCliente")
         .AppendFormatLine("  ,Ca.NombreCategoria")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteGralDescuentoRecargoPorc, CONVERT(DECIMAL(9,2), NULL) ClienteGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoGralDescRecProducto")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc1, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc2, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc3, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc4, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta1, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta2, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta3, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta4, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ListaPreciosDescuentoRecargoPorc")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaDescuentoRecargo")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) MarcaGralDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) MarcaGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroGralDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) RubroGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUHPorc1, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc2, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc3, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc4, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta1, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta2, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta3, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta4, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) SubRubroDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc1, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc2, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc3, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc4, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta1, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta2, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta3, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta4, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteProductoDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) ClienteProductoDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteMarcaDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) ClienteMarcaDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteRubroDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) ClienteRubroDescuentoRecargoPorc2")
         .AppendFormatLine("  ,NULLIF(CDSR.DescuentoRecargo, 0) ClienteSubRubroDescuentoRecargo")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaRubroDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) CategoriaSubRubroDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) CategoriaSubSubRubroDescuentoRecargoPorc1")

         .AppendFormatLine("FROM ClientesDescuentosSubRubros CDSR")
         .AppendFormatLine("  INNER JOIN Clientes C ON C.IdCliente = CDSR.IdCliente")
         .AppendFormatLine("  INNER JOIN SubRubros SR ON SR.IdSubRubro = CDSR.IdSubRubro")
         .AppendFormatLine("  INNER JOIN Categorias Ca ON Ca.IdCategoria = C.IdCategoria")
         .AppendFormatLine("  INNER JOIN Productos P ON P.IdSubRubro = SR.IdSubRubro")
         .AppendFormatLine("  INNER JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendFormatLine("  INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendFormatLine("  LEFT JOIN SubSubRubros SSR ON SSR.IdSubSubRubro = P.IdSubSubRubro")
         .AppendFormatLine("  WHERE P.Activo = 'True'")
         .AppendFormatLine("  AND C.Activo = 'True'")

         .AppendFormatLine("UNION ALL")
         .AppendFormatLine("  SELECT P.IdProducto")
         .AppendFormatLine("  ,P.NombreProducto")
         .AppendFormatLine("  ,P.IdMarca")
         .AppendFormatLine("  ,M.NombreMarca")
         .AppendFormatLine("  ,P.IdRubro")
         .AppendFormatLine("  ,R.NombreRubro")
         .AppendFormatLine("  ,P.IdSubRubro")
         .AppendFormatLine("  ,SR.NombreSubRubro")
         .AppendFormatLine("  ,P.IdSubSubRubro")
         .AppendFormatLine("  ,SSR.NombreSubSubRubro")
         .AppendFormatLine("  ,C.IdCliente")
         .AppendFormatLine("  ,C.CodigoCliente")
         .AppendFormatLine("  ,C.NombreCliente")
         .AppendFormatLine("  ,Ca.NombreCategoria")

         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteGralDescuentoRecargoPorc, CONVERT(DECIMAL(9,2), NULL) ClienteGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoGralDescRecProducto")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc1, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc2, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc3, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc4, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta1, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta2, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta3, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta4, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ListaPreciosDescuentoRecargoPorc")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaDescuentoRecargo")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) MarcaGralDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) MarcaGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroGralDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) RubroGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUHPorc1, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc2, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc3, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc4, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta1, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta2, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta3, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta4, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) SubRubroDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc1, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc2, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc3, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc4, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta1, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta2, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta3, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta4, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteProductoDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) ClienteProductoDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteMarcaDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) ClienteMarcaDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteRubroDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) ClienteRubroDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteSubRubroDescuentoRecargo")
         .AppendFormatLine("  ,NULLIF(CDR.DescuentoRecargoPorc1, 0) CategoriaRubroDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) CategoriaSubRubroDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) CategoriaSubSubRubroDescuentoRecargoPorc1")

         .AppendFormatLine("FROM CategoriasDescuentosRubros CDR")
         .AppendFormatLine("  INNER JOIN Clientes C ON C.IdCategoria = CDR.IdCategoria")
         .AppendFormatLine("  INNER JOIN Productos P ON P.IdRubro = CDR.IdRubro")
         .AppendFormatLine("  INNER JOIN Categorias Ca ON Ca.IdCategoria = C.IdCategoria")
         .AppendFormatLine("  INNER JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendFormatLine("  INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendFormatLine("  LEFT JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")
         .AppendFormatLine("  LEFT JOIN SubSubRubros SSR ON SSR.IdSubSubRubro = P.IdSubSubRubro")
         .AppendFormatLine("  WHERE P.Activo = 'True'")
         .AppendFormatLine("  AND C.Activo = 'True'")

         .AppendFormatLine("UNION ALL")

         .AppendFormatLine("SELECT P.IdProducto")
         .AppendFormatLine("  ,P.NombreProducto")
         .AppendFormatLine("  ,P.IdMarca")
         .AppendFormatLine("  ,M.NombreMarca")
         .AppendFormatLine("  ,P.IdRubro")
         .AppendFormatLine("  ,R.NombreRubro")
         .AppendFormatLine("  ,P.IdSubRubro")
         .AppendFormatLine("  ,SR.NombreSubRubro")
         .AppendFormatLine("  ,P.IdSubSubRubro")
         .AppendFormatLine("  ,SSR.NombreSubSubRubro")
         .AppendFormatLine("  ,C.IdCliente")
         .AppendFormatLine("  ,C.CodigoCliente")
         .AppendFormatLine("  ,C.NombreCliente")
         .AppendFormatLine("  ,Ca.NombreCategoria")

         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteGralDescuentoRecargoPorc, CONVERT(DECIMAL(9,2), NULL) ClienteGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoGralDescRecProducto")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc1, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc2, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc3, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc4, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta1, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta2, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta3, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta4, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ListaPreciosDescuentoRecargoPorc")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaDescuentoRecargo")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) MarcaGralDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) MarcaGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroGralDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) RubroGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUHPorc1, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc2, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc3, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc4, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta1, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta2, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta3, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta4, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) SubRubroDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc1, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc2, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc3, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc4, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta1, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta2, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta3, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta4, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteProductoDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) ClienteProductoDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteMarcaDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) ClienteMarcaDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteRubroDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) ClienteRubroDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteSubRubroDescuentoRecargo")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaRubroDescuentoRecargoPorc1, NULLIF(CDSR.DescuentoRecargoPorc1, 0) CategoriaSubRubroDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) CategoriaSubSubRubroDescuentoRecargoPorc1")

         .AppendFormatLine("FROM CategoriasDescuentosSubRubros CDSR")
         .AppendFormatLine("  INNER JOIN Clientes C ON C.IdCategoria = CDSR.IdCategoria")
         .AppendFormatLine("  INNER JOIN Productos P ON P.IdSubRubro = CDSR.IdSubRubro")
         .AppendFormatLine("  INNER JOIN Categorias Ca ON Ca.IdCategoria = C.IdCategoria")
         .AppendFormatLine("  INNER JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendFormatLine("  INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendFormatLine("  LEFT JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")
         .AppendFormatLine("  LEFT JOIN SubSubRubros SSR ON SSR.IdSubSubRubro = P.IdSubSubRubro")
         .AppendFormatLine("  WHERE P.Activo = 'True'")
         .AppendFormatLine("  AND C.Activo = 'True'")

         .AppendFormatLine("UNION ALL")
         .AppendFormatLine("SELECT P.IdProducto")
         .AppendFormatLine("  ,P.NombreProducto")
         .AppendFormatLine("  ,P.IdMarca")
         .AppendFormatLine("  ,M.NombreMarca")
         .AppendFormatLine("  ,P.IdRubro")
         .AppendFormatLine("  ,R.NombreRubro")
         .AppendFormatLine("  ,P.IdSubRubro")
         .AppendFormatLine("  ,SR.NombreSubRubro")
         .AppendFormatLine("  ,P.IdSubSubRubro")
         .AppendFormatLine("  ,SSR.NombreSubSubRubro")
         .AppendFormatLine("  ,C.IdCliente")
         .AppendFormatLine("  ,C.CodigoCliente")
         .AppendFormatLine("  ,C.NombreCliente")
         .AppendFormatLine("  ,Ca.NombreCategoria")

         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteGralDescuentoRecargoPorc, CONVERT(DECIMAL(9,2), NULL) ClienteGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoGralDescRecProducto")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc1, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc2, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc3, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc4, CONVERT(DECIMAL(9,2), NULL) ProductoUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta1, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta2, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta3, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta4, CONVERT(DECIMAL(9,2), NULL) ProductoUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ListaPreciosDescuentoRecargoPorc")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaDescuentoRecargo")

         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) MarcaGralDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) MarcaGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroGralDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) RubroGralDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUHPorc1, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc2, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc3, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc4, CONVERT(DECIMAL(9,2), NULL) RubroUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta1, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta2, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta3, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta4, CONVERT(DECIMAL(9,2), NULL) RubroUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) SubRubroDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc1, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc2, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc3, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc4, CONVERT(DECIMAL(9,2), NULL) SubRubroUHPorc5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta1, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta2, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta3, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta4, CONVERT(DECIMAL(9,2), NULL) SubRubroUnidHasta5")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteProductoDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) ClienteProductoDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteMarcaDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) ClienteMarcaDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteRubroDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) ClienteRubroDescuentoRecargoPorc2")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) ClienteSubRubroDescuentoRecargo")
         .AppendFormatLine("  ,CONVERT(DECIMAL(9,2), NULL) CategoriaRubroDescuentoRecargoPorc1, CONVERT(DECIMAL(9,2), NULL) CategoriaSubRubroDescuentoRecargoPorc1, NULLIF(CDSSR.DescuentoRecargoPorc1, 0) CategoriaSubSubRubroDescuentoRecargoPorc1")

         .AppendFormatLine("FROM CategoriasDescuentosSubSubRubros CDSSR")
         .AppendFormatLine("  INNER JOIN Clientes C ON C.IdCategoria = CDSSR.IdCategoria")
         .AppendFormatLine("  INNER JOIN Productos P ON P.IdSubSubRubro = CDSSR.IdSubSubRubro")
         .AppendFormatLine("  INNER JOIN Categorias Ca ON Ca.IdCategoria = C.IdCategoria")
         .AppendFormatLine("  INNER JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendFormatLine("  INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendFormatLine("  LEFT JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")
         .AppendFormatLine("  LEFT JOIN SubSubRubros SSR ON SSR.IdSubSubRubro = P.IdSubSubRubro")
         .AppendFormatLine("  WHERE P.Activo = 'True'")
         .AppendFormatLine("  AND C.Activo = 'True'")
         .AppendFormatLine("  ) D")

         .AppendFormatLine("   WHERE 1 = 1")
         'PONER FILTROS NUEVOS
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("  AND D.IdProducto = '{0}'", idProducto)
         End If
         If idMarca > 0 Then
            .AppendFormatLine("  AND D.IdMarca = {0}", idMarca)
         End If
         If idRubro > 0 Then
            .AppendFormatLine("  AND D.IdRubro = {0}", idRubro)
         End If
         If idSubRubro > 0 Then
            .AppendFormatLine("  AND D.IdSubRubro = {0}", idSubRubro)
         End If
         If idCliente > 0 Then
            .AppendFormatLine("  AND D.IdCliente = {0}", idCliente)
         End If

         .AppendFormatLine(" GROUP BY D.IdProducto")
         .AppendFormatLine("  ,D.NombreProducto")
         .AppendFormatLine("  ,D.IdMarca")
         .AppendFormatLine("  ,D.NombreMarca")
         .AppendFormatLine("  ,D.IdRubro")
         .AppendFormatLine("  ,D.NombreRubro")
         .AppendFormatLine("  ,D.IdSubRubro")
         .AppendFormatLine("  ,D.NombreSubRubro")
         .AppendFormatLine("  ,D.IdSubSubRubro")
         .AppendFormatLine("  ,D.NombreSubSubRubro")
         .AppendFormatLine("  ,D.IdCliente")
         .AppendFormatLine("  ,D.CodigoCliente")
         .AppendFormatLine("  ,D.NombreCliente")
         .AppendFormatLine("  ,D.NombreCategoria")

      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Sub GuardarIdClienteTiendaWeb(idTiendaWeb As String, idCliente As String, idClienteTiendaWeb As String)
      Dim query As New StringBuilder
      With query
         .AppendFormatLine("UPDATE C SET C.idCliente" + idTiendaWeb + " = '{0}' FROM Clientes C ", idClienteTiendaWeb)
         .AppendFormatLine("	WHERE C.IdCliente = '{0}'", idCliente)
      End With
      Me.Execute(query.ToString())
   End Sub

   Public Function GetMaxFechaActualizacionWeb() As DataTable
      Dim query As New StringBuilder
      With query
         .AppendFormatLine("SELECT MAX(FechaActualizacionWeb) FechaActualizacionWeb FROM Clientes CLI")
      End With
      Return Me.GetDataTable(query.ToString())
   End Function
End Class