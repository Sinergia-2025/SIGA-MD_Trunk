Public Class ClientesLIVEABM
   Protected Property ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto
   Private _StateForm As StateForm?
   Private _DireccionCorregida As Boolean = False
#Region "Overrides"
   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      If _StateForm.HasValue Then
         Name = Name + "_" + _StateForm.Value.ToString()
      End If

      MyBase.OnLoad(e)

      Text = ModoClienteProspecto.ToString() + "s"

      If _StateForm.HasValue AndAlso _StateForm.Value = StateForm.Consultar Then
         tsbEditar.Visible = False
         tsbBorrar.Visible = False
         tsbNuevo.Visible = False
         toolStripSeparator3.Visible = False
         tsbEditar.Enabled = False
         tsbBorrar.Enabled = False
         tsbNuevo.Enabled = False
         Text = "Consulta de " + Text
         'grpFiltros.Visible = True
         LimpiarFiltros()
      End If

   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Win.BaseDetalle
      If estado = StateForm.Actualizar Then

         Return New ClientesLIVEDetalle(DirectCast(Me.GetEntidad(), Entidades.Cliente), _DireccionCorregida)
      End If
      Return New ClientesLIVEDetalle(New Entidades.Cliente())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Clientes()
   End Function

   Protected Overrides Function GetAll(rg As Reglas.Base) As DataTable
      Dim Dt As DataTable = MyBase.GetAll(rg)
      Dim Dt2 As DataTable = VerficaDireccion(Dt)

      Return LimpiaPassword(Dt2)
   End Function
   Protected Overrides Function Buscar(rg As Reglas.Base, bus As Entidades.Buscar) As DataTable
      Dim Dt As DataTable = MyBase.Buscar(rg, bus)
      Dim Dt2 As DataTable = VerficaDireccion(Dt)

      Return LimpiaPassword(Dt2)
   End Function
   Private Function VerficaDireccion(dt As DataTable) As DataTable


      Dim columnComparar As DataColumn = New DataColumn()
      Dim columnVerificada As DataColumn = New DataColumn()

      columnComparar.ColumnName = "DireccionComparar"
      columnComparar.Expression = "NombreCalle +' '+ Altura +' '+ DireccionAdicional"
      dt.Columns.Add(columnComparar)

      columnVerificada.ColumnName = "DireccionVerificada"
      columnVerificada.Expression = "IIf(Direccion = DireccionComparar, 'SI', 'NO')"

      dt.Columns.Add(columnVerificada)

      _DireccionCorregida = False

      Return dt
   End Function
   Private Function LimpiaPassword(dt As DataTable) As DataTable
      For Each dr As DataRow In dt.Rows
         dr("SiMovilClave") = "****************"
      Next
      Return dt
   End Function


   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Clientes.rdlc", "SistemaDataSet_Clientes", Me.dtDatos, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = "Clientes"
         frmImprime.ShowDialog()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim clie As Entidades.Cliente = New Entidades.Cliente()
      With Me.dgvDatos.ActiveCell.Row
         clie.IdCliente = Long.Parse(.Cells(Entidades.Cliente.Columnas.IdCliente.ToString()).Value.ToString())
         clie = New Reglas.Clientes().GetUno(clie.IdCliente)
         clie.Usuario = actual.Nombre
         _DireccionCorregida = .Cells("DireccionVerificada").Value.ToString() = "SI"
      End With
      Return clie
   End Function

   Protected Overrides Sub FormatearGrilla()

      Dim hiddenExtrasSinergia As Boolean = Not Reglas.Publicos.ExtrasSinergia

      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0

         Grilla.FormatearColumna(.Columns("IdCliente"), "IdCliente", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("CodigoCliente"), "Código", col, 60, HAlign.Right)
         Grilla.FormatearColumna(.Columns("NombreCliente"), "Nombre", col, 180)
         Grilla.FormatearColumna(.Columns("NombreDeFantasia"), "Nombre de Fantasia", col, 180)

         Grilla.FormatearColumna(.Columns("IdTipoCliente"), "IdTipoCliente", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("NombreTipoCliente"), "Tipo Cliente", col, 100)

         Grilla.FormatearColumna(.Columns("IdCategoria"), "IdCategoria", col, 60, HAlign.Right, True)

         Grilla.FormatearColumna(.Columns("IdCalle"), "IdCalle", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("NombreCalle"), "Calle", col, 120)
         Grilla.FormatearColumna(.Columns("Altura"), "Altura", col, 60, HAlign.Right)
         Grilla.FormatearColumna(.Columns("DireccionAdicional"), "Dir. Adicional", col, 100)

         Grilla.FormatearColumna(.Columns("Direccion"), "Dirección", col, 180, , True)
         Grilla.FormatearColumna(.Columns("DireccionVerificada"), "Direcc. Igual", col, 80, HAlign.Center, True)

         Grilla.FormatearColumna(.Columns("IdLocalidad"), "C.P.", col, 45)
         Grilla.FormatearColumna(.Columns("NombreLocalidad"), "Localidad", col, 100)
         Grilla.FormatearColumna(.Columns("NombreProvincia"), "Provincia", col, 100)

         Grilla.FormatearColumna(.Columns("Cuit"), "CUIT", col, 80)
         Grilla.FormatearColumna(.Columns("IdCategoriaFiscal"), "IdCategoriaFiscal", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("NombreCategoriaFiscal"), "Categoría Fiscal", col, 120)

         Grilla.FormatearColumna(.Columns("Celular"), "Celular", col, 120)
         Grilla.FormatearColumna(.Columns("Telefono"), "Teléfono", col, 120)
         Grilla.FormatearColumna(.Columns("TelefonosParticulares"), "Teléfonos Particulares", col, 120)
         Grilla.FormatearColumna(.Columns("Fax"), "Fax", col, 120)

         Grilla.FormatearColumna(.Columns("CorreoElectronico"), "E-Mail", col, 120)
         Grilla.FormatearColumna(.Columns("PaginaWeb"), "Pagina Web", col, 120)

         Grilla.FormatearColumna(.Columns("IdCalle2"), "IdCalle2", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("NombreCalle2"), "Calle Part.", col, 120)
         Grilla.FormatearColumna(.Columns("Altura2"), "Altura Part.", col, 60, HAlign.Right)
         Grilla.FormatearColumna(.Columns("DireccionAdicional2"), "Dir. Adicional Part.", col, 100)
         Grilla.FormatearColumna(.Columns("Direccion2"), "Dirección Part.", col, 180, , True)
         Grilla.FormatearColumna(.Columns("IdLocalidad2"), "C.P.", col, 45)
         Grilla.FormatearColumna(.Columns("NombreLocalidad2"), "Localidad Part.", col, 100)
         Grilla.FormatearColumna(.Columns("NombreProvincia2"), "Provincia Part.", col, 100)

         Grilla.FormatearColumna(.Columns("LimiteDeCredito"), "Límite de Credito", col, 80, HAlign.Right, , "N2")

         Grilla.FormatearColumna(.Columns("IdCategoria"), "IdCategoria", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("NombreCategoria"), "Nombre Categoría", col, 120)

         Grilla.FormatearColumna(.Columns("IdListaPrecios"), "IdListaPrecios", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("NombreListaPrecios"), "Lista de Precios", col, 120)

         'Grilla.FormatearColumna(.Columns("TipoDocVendedor"), "TipoDocVendedor", col, 60, , True)
         'Grilla.FormatearColumna(.Columns("NroDocVendedor"), "NroDocVendedor", col, 60, , True)
         Grilla.FormatearColumna(.Columns("NombreVendedor"), "Nombre Vendedor", col, 150)
         Grilla.FormatearColumna(.Columns("IdVendedor"), "IdVendedor", col, 150, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("IdCobrador"), "IdCobrador", col, 150, HAlign.Right, True)

         Grilla.FormatearColumna(.Columns("IdDadoAltaPor"), "IdDadoAltaPor", col, 60, , True)
         ' Grilla.FormatearColumna(.Columns("NroDocDadoAltaPor"), "NroDocDadoAltaPor", col, 60, , True)
         Grilla.FormatearColumna(.Columns("NombreDadoAltaPor"), "Nombre Dado Alta Por", col, 150)

         Grilla.FormatearColumna(.Columns("DescuentoRecargoPorc"), "Desc/Rec. %", col, 70, HAlign.Right, , "N2")
         Grilla.FormatearColumna(.Columns("DescuentoRecargoPorc2"), "Desc/Rec. % 2", col, 70, HAlign.Right, , "N2")
         Grilla.FormatearColumna(.Columns("IdTipoComprobante"), "Comprob. Facturación", col, 70)
         Grilla.FormatearColumna(.Columns("Descripcion"), "Descripción Compr. Fact.", col, 70)

         Grilla.FormatearColumna(.Columns("IdFormasPago"), "IdFormasPago", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("DescripcionFormasPago"), "Forma Pago", col, 70)

         Grilla.FormatearColumna(.Columns("IdTransportista"), "IdTransportista", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("NombreTransportista"), "Nombre Transportista", col, 70)

         Grilla.FormatearColumna(.Columns("Activo"), "Activo", col, 40, HAlign.Center)

         Grilla.FormatearColumna(.Columns("TipoDocCliente"), "Tipo Doc.", col, 40)
         Grilla.FormatearColumna(.Columns("NroDocCliente"), "Nro. Doc.", col, 80, HAlign.Right)

         Grilla.FormatearColumna(.Columns("IdEstado"), "IdEstado", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("NombreEstadoCliente"), "Estado", col, 100)

         Grilla.FormatearColumna(.Columns("IdZonaGeografica"), "IdZonaGeografica", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("NombreZonaGeografica"), "Zona Geográfica", col, 120)
         Grilla.FormatearColumna(.Columns("CorreoAdministrativo"), "Correo Administrativo", col, 120)
         Grilla.FormatearColumna(.Columns("LimiteDiasVtoFactura"), "Limite Dias Vencimiento Factura", col, 120, HAlign.Right)

         Grilla.FormatearColumna(.Columns("IdCaja"), "IdCaja", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("NombreCaja"), "Nombre Caja", col, 60)

         Grilla.FormatearColumna(.Columns("FechaAlta"), "Fecha Alta", col, 100, HAlign.Center)
         Grilla.FormatearColumna(.Columns("FechaBaja"), "Fecha Baja", col, 100, HAlign.Center)
         Grilla.FormatearColumna(.Columns("FechaNacimiento"), "Fecha Nacimiento", col, 100, HAlign.Center)

         Grilla.FormatearColumna(.Columns("Observacion"), "Observación", col, 100)
         Grilla.FormatearColumna(.Columns("ObservacionWeb"), "Observ. Web", col, 100)

         Grilla.FormatearColumna(.Columns("IngresosBrutos"), "Ingresos Brutos", col, 100)
         Grilla.FormatearColumna(.Columns("InscriptoIBStaFe"), "Incr. IIBB Sta. Fe", col, 80, HAlign.Center)
         Grilla.FormatearColumna(.Columns("LocalIB"), "IIBB Local", col, 80, HAlign.Center)
         Grilla.FormatearColumna(.Columns("ConvMultilateralIB"), "IIBB Conv. Multilateral", col, 80, HAlign.Center)

         Grilla.FormatearColumna(.Columns("IdTipoDeExension"), "Tipo Exension", col, 100)
         Grilla.FormatearColumna(.Columns("AnioExension"), "Año", col, 80, HAlign.Right)
         Grilla.FormatearColumna(.Columns("NroCertExension"), "Nro. Cert. Exensión", col, 150, HAlign.Right)
         Grilla.FormatearColumna(.Columns("NroCertPropio"), "Nro. Cert. Propio", col, 150, HAlign.Right)

         .Columns("EsExentoPercIVARes53292023").FormatearColumna("Exento Perc. IVA Res. 5329/2023", col, 80, HAlign.Center)

         Grilla.FormatearColumna(.Columns("FechaSUS"), "Fecha SUS", col, 100, HAlign.Center)

         Grilla.FormatearColumna(.Columns("IdClienteCtaCte"), "IdClienteCtaCte", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("CodigoClienteCtaCte"), "Código Cta.Cte.", col, 60, HAlign.Right)
         Grilla.FormatearColumna(.Columns("NombreClienteCtaCte"), "Nombre Cta.Cte.", col, 180)



         .Columns("HoraInicio").FormatearColumna("Hora Inicio", col, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraFin").FormatearColumna("Hora Fin", col, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraInicio2").FormatearColumna("Hora Inicio 2", col, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraFin2").FormatearColumna("Hora Fin 2", col, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HorarioCorrido").FormatearColumna("Horario Corrido", col, 60, HAlign.Center, hiddenExtrasSinergia)


         .Columns("HoraSabInicio").FormatearColumna("Hora Sab Inicio", col, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraSabFin").FormatearColumna("Hora Sab Fin", col, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraSabInicio2").FormatearColumna("Hora Sab Inicio 2", col, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraSabFin2").FormatearColumna("Hora Sab Fin 2", col, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HorarioCorridoSab").FormatearColumna("Horario Corrido Sab", col, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraDomInicio").FormatearColumna("Hora Dom Inicio", col, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraDomFin").FormatearColumna("Hora Dom Fin", col, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraDomInicio2").FormatearColumna("Hora Dom Inic.2", col, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraDomFin2").FormatearColumna("Hora Dom Fin 2", col, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HorarioCorridoDom").FormatearColumna("Hora Dom H. Corrido", col, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HorarioClienteCompleto").FormatearColumna("Horario Completo", col, 120, HAlign.Left)
         .Columns("NroVersion").FormatearColumna("Nro. Versión", col, 80, , hiddenExtrasSinergia)
         .Columns("FechaActualizacionVersion").FormatearColumna("Fecha Actualización Versión", col, 100, HAlign.Center, hiddenExtrasSinergia, "dd/MM/yyyy")
         .Columns("FechaInicio").FormatearColumna("Fecha Inicio", col, 70, HAlign.Center, hiddenExtrasSinergia, "dd/MM/yyyy")
         .Columns("FechaInicioReal").FormatearColumna("Fecha Inicio Real", col, 70, HAlign.Center, hiddenExtrasSinergia, "dd/MM/yyyy")
         .Columns("VencimientoLicencia").FormatearColumna("Vencimiento Licencia", col, 70, HAlign.Center, hiddenExtrasSinergia, "dd/MM/yyyy")
         .Columns("BackupAutoCuenta").FormatearColumna("Cuenta Backup Automático", col, 120, , hiddenExtrasSinergia)
         .Columns("BackupAutoConfig").FormatearColumna("Backup Automático Configurado", col, 80, HAlign.Center, hiddenExtrasSinergia)
         .Columns("BackupNroVersion").FormatearColumna("Versión Backup Automático", col, 80, , hiddenExtrasSinergia)
         .Columns("TienePreciosConIVA").FormatearColumna("Tiene Precios Con IVA", col, 80, , hiddenExtrasSinergia)
         .Columns("ConsultaPreciosConIVA").FormatearColumna("Consulta Precios Con IVA", col, 80, , hiddenExtrasSinergia)
         .Columns("TieneServidorDedicado").FormatearColumna("Tiene Servidor Dedicado", col, 80, , hiddenExtrasSinergia)
         .Columns("MotorBaseDatos").FormatearColumna("Motor Base Datos", col, 80, , hiddenExtrasSinergia)
         .Columns("CantidadLocal").FormatearColumna("Cantidad Lic. Local", col, 80, HAlign.Right, hiddenExtrasSinergia)
         .Columns("CantidadRemota").FormatearColumna("Cantidad Lic. Remota", col, 80, HAlign.Right, hiddenExtrasSinergia)
         .Columns("CantidadDePCs").FormatearColumna("Cantidad De PCs", col, 80, , hiddenExtrasSinergia)
         .Columns("CantidadMovil").FormatearColumna("Cantidad Lic. Movil", col, 80, HAlign.Right, Not Reglas.Publicos.ExtrasSinergia)
         .Columns("HorasCapacitacionPactadas").FormatearColumna("Hs. Capac. Pactadas", col, 80, HAlign.Right, hiddenExtrasSinergia)
         .Columns("HorasCapacitacionRealizadas").FormatearColumna("Hs. Capac. Realizadas", col, 80, HAlign.Right, hiddenExtrasSinergia)
         .Columns("IdAplicacion").FormatearColumna("Aplicacion", col, 80, , hiddenExtrasSinergia)
         .Columns("Edicion").FormatearColumna("Edicion", col, 80, , hiddenExtrasSinergia)
         .Columns("URLWebmovilPropio").FormatearColumna("URL Webmovil propio", col, 200, , hiddenExtrasSinergia)
         .Columns("URLWebmovilAdminPropio").FormatearColumna("URL Webmovil Admin propio", col, 200, , hiddenExtrasSinergia)
         .Columns("URLSimovilGestionPropio").FormatearColumna("URL Simovil Gestión propio", col, 200, , hiddenExtrasSinergia)
         .Columns("URLActualizadorPropio").FormatearColumna("URL Actualizador Automático propio", col, 200, , hiddenExtrasSinergia)
         .Columns("NroVersionWebmovilPropio").FormatearColumna("Nro. Version Webmovil propio", col, 80, , hiddenExtrasSinergia)
         .Columns("NroVersionWebmovilAdminPropio").FormatearColumna("Nro. Version Webmovil Admin propio", col, 80, , hiddenExtrasSinergia)
         .Columns("NroVersionSimovilGestionPropio").FormatearColumna("Nro. Version Simovil Gestión propio", col, 80, , hiddenExtrasSinergia)
         .Columns("NroVersionActualizadorPropio").FormatearColumna("Nro. Version Actualizador Automático propio", col, 80, , hiddenExtrasSinergia)
         .Columns("ActualizarAplicacion").FormatearColumna("Actualizar Aplicacion", col, 80, HAlign.Center, hiddenExtrasSinergia)
         .Columns("ControlaBackup").FormatearColumna("Controla Backup", col, 80, HAlign.Center, hiddenExtrasSinergia)
         .Columns("UtilizaAppSoporte").FormatearColumna("Utiliza App Soporte", col, 80, HAlign.Center, hiddenExtrasSinergia)
         .Columns("ObservacionAdministrativa").FormatearColumna("Observacion Administrativa", col, 150, HAlign.Left, hiddenExtrasSinergia)



         Grilla.FormatearColumna(.Columns("HabilitarVisita"), "Habilitar Visita", col, 80, HAlign.Center)
         Grilla.FormatearColumna(.Columns("CantidadVisitas"), "Cantidad Visitas", col, 80, HAlign.Right)
         Grilla.FormatearColumna(.Columns("VerEnConsultas"), "Ver En Consultas", col, 80, HAlign.Center)


         Grilla.FormatearColumna(.Columns("GeoLocalizacionLat"), "GeoLocalizacionLat", col, 60, , True)
         Grilla.FormatearColumna(.Columns("GeoLocalizacionLng"), "GeoLocalizacionLng", col, 60, , True)
         Grilla.FormatearColumna(.Columns("Foto"), "Foto", col, 60, , True)

         'No se usan
         Grilla.FormatearColumna(.Columns("NombreTrabajo"), "NombreTrabajo", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("DireccionTrabajo"), "DireccionTrabajo", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("TelefonoTrabajo"), "TelefonoTrabajo", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("CorreoTrabajo"), "CorreoTrabajo", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("IdLocalidadTrabajo"), "IdLocalidadTrabajo", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("NombreLocalidadTrabajo"), "NombreLocalidadTrabajo", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("FechaIngresoTrabajo"), "FechaIngresoTrabajo", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("IdClienteGarante"), "IdClienteGarante", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("CodigoGarante"), "CodigoGarante", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("NombreGarante"), "NombreGarante", col, 60, HAlign.Right, True)

         Grilla.FormatearColumna(.Columns("IdSucursalAsociada"), "IdSucursalAsociada", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("NombreSucursalAsociada"), "NombreSucursalAsociada", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("NumeroLote"), "NumeroLote", col, 60, HAlign.Right, True)


         Grilla.FormatearColumna(.Columns("LetraFiscal"), "LetraFiscal", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("NroOperacion"), "NroOperacion", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("SaldoPendiente"), "SaldoPendiente", col, 60, HAlign.Right, True)
         Grilla.FormatearColumna(.Columns("RepartoIndependiente"), "Reparto Independiente", col, 80, HAlign.Center)
         Grilla.FormatearColumna(.Columns("NivelAutorizacion"), "Nivel de Autorizacion", col, 80, HAlign.Right)

         .Columns("SiMovilIdUsuario").FormatearColumna("Usuario SiMovil", col, 80, )
         .Columns("SiMovilClave").FormatearColumna("Clave SiMovil", col, 80, , True)

         Grilla.FormatearColumna(.Columns("Alicuota2deProducto"), "Alicuota 2 de Producto", col, 150, HAlign.Left, Not Reglas.Publicos.ProductoUtilizaAlicuota2)
         Grilla.FormatearColumna(.Columns("CertificadoMiPyme"), "Certificado MiPyme", col, 60, HAlign.Center)
         Grilla.FormatearColumna(.Columns("FechaDesdeCertificado"), "Desde Certificado", col, 80, HAlign.Left)
         Grilla.FormatearColumna(.Columns("FechaHastaCertificado"), "Hasta Certificado", col, 80, HAlign.Left)

         .Columns(Entidades.Cliente.Columnas.IdCuentaContable.ToString()).FormatearColumna("Cuenta", col, 90)
         .Columns("NombreCuentaContable").FormatearColumna("Nombre Cuenta", col, 280)

         If Not Reglas.Publicos.TieneModuloContabilidad Then
            .Columns(Entidades.Cliente.Columnas.IdCuentaContable.ToString()).Hidden = True
            .Columns("NombreCuentaContable").Hidden = True
         End If
         .Columns("EsClienteGenerico").Hidden = True

         .Columns("EsClienteGenerico").Hidden = True

         .Columns("DireccionComparar").Hidden = True

         .Columns(Entidades.Cliente.Columnas.RecibeNotificaciones.ToString()).FormatearColumna("Recibe Notificaciones", col, 100, HAlign.Center)
         .Columns("RequiereRevisionAdministrativa").FormatearColumna("Req. Rev. Administrativa", col, 80, HAlign.Center)
         .Columns("FechaActualizacionWeb").FormatearColumna("Fecha Act. Web", col, 130, HAlign.Center, , "dd/MM/yyyy HH:mm:ss")


         .Columns("CBU").FormatearColumna("CBU", col, 200, , Not Reglas.Publicos.ClienteUtilizaCBU)
         .Columns("IdBanco").OcultoPosicion(True, col)
         .Columns("IdCuentaBancariaClase").OcultoPosicion(True, col)
         .Columns("NumeroCuentaBancaria").OcultoPosicion(True, col)
         .Columns("CuitCtaBancaria").FormatearColumna(My.Resources.RTextos.CuitCtaBancaria, col, 80, , Not Reglas.Publicos.ClienteUtilizaCBU)

         .Columns("Sexo").Hidden = True

         Grilla.FormatearColumna(.Columns("PublicarEnWeb"), "Publicar en Web", col, 80, HAlign.Center)

      End With

      Dim rows() As DataRow = DirectCast(Me.dgvDatos.DataSource, DataTable).Select("DireccionVerificada='NO'")
      If rows.Count > 0 Then
         Me.dgvDatos.DisplayLayout.Bands(0).Columns("DireccionVerificada").Hidden = False
      End If



      Grilla.AgregarFiltroEnLinea(dgvDatos, {"NombreCliente", "NombreDeFantasia", "NombreClienteCtaCte",
                                             "NombreCalle", "NombreCalle2",
                                             "DireccionAdicional", "DireccionAdicional2",
                                             "Celular", "Telefono", "TelefonosParticulares",
                                             "Observacion", "ObservacionWeb"})

   End Sub

#End Region

End Class