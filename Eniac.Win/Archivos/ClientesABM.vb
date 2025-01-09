Public Class ClientesABM
   Implements IConParametros

#Region "Campos"
   Private _MostrarVendedor As Boolean
   Private _StateForm As StateForm?
   Private _publicos As Publicos
   Private _DireccionCorregida As Boolean = False
#End Region

   Protected Property ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto

   Friend WithEvents tsbCstAfip As ToolStripButton
   Friend WithEvents tsbSepAfip As ToolStripSeparator
   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente

      '-- Nuevo Boton de Consulta AFIP.- 
      tsbSepAfip = New ToolStripSeparator()
      tstBarra.Items.Insert(tstBarra.Items.IndexOf(tsbBorrar) + 1, tsbSepAfip)

      tsbCstAfip = New ToolStripButton()
      With tsbCstAfip
         .Image = My.Resources.Afip
         .ImageTransparentColor = Color.Magenta
         .Name = "tsbCstAfip"
         .Size = New Size(65, 26)
         .Text = "AFIP"
         .ToolTipText = "Sincronizar Contribuyentes con Afip."
      End With
      tstBarra.Items.Insert(tstBarra.Items.IndexOf(tsbSepAfip) + 1, tsbCstAfip)

   End Sub
   Private Sub tsbCstAfip_Click(sender As Object, e As EventArgs) Handles tsbCstAfip.Click
      TryCatched(Sub() CallSincronizarcionAFIP())
   End Sub

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      If _StateForm.HasValue Then
         Name = Name + "_" + _StateForm.Value.ToString()
      End If

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      'Dim tsi As ToolStripButton = New ToolStripButton("Geo", Nothing, AddressOf PresionarGeo)
      'Me.tstBarra.Items.Insert(Me.tstBarra.Items.Count - 1, tsi)

      'Seguridad del campo Vendedor
      Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
      Me._MostrarVendedor = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "Clientes-MostrarVendedor")

      If Not Me._MostrarVendedor Then
         Me.dgvDatos.DisplayLayout.Bands(0).Columns("NombreVendedor").Hidden = True
         Me.tsbPreferencias.Visible = False
      End If

      Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
      Me.cmbVendedor.SelectedIndex = -1

      Dim mostrarExportarImportar As Boolean = oUsuario.TienePermisos(actual.Nombre, actual.Sucursal.Id, "Clientes-PuedeExtraerInfo")
      MuestraExportacionImpresion(mostrarExportarImportar)

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
         grpFiltros.Visible = True
         LimpiarFiltros()
      End If

      'Dim pnl As Panel = New Panel()
      'pnl.Dock = DockStyle.Top
      'Controls.Add(pnl)
      'Controls.SetChildIndex(pnl, Controls.IndexOf(dgvDatos) + 1)

   End Sub
   Protected Overrides Sub LimpiarFiltros()
      MyBase.LimpiarFiltros()

      chbFechaAlta.Checked = True
      chbFechaAlta.Checked = False
      chbFechaNacimiento.Checked = True
      chbFechaNacimiento.Checked = False
      chbFechaNacimientoIncluirAnio.Checked = True
      chbFechaNacimientoIncluirAnio.Checked = False
      chkMesCompletoFechaAlta.Checked = False
      chkMesCompletoFechaNacimiento.Checked = False

      dtpFechaAltaDesde.Value = Today
      dtpFechaAltaHasta.Value = Today.AddDays(1).AddSeconds(-1)
      dtpFechaNacimientoDesde.Value = Today
      dtpFechaNacimientoHasta.Value = Today.AddDays(1).AddSeconds(-1)

      Me.chbVendedor.Checked = False
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ClientesDetalle(DirectCast(Me.GetEntidad(), Entidades.Cliente), ModoClienteProspecto, _DireccionCorregida)
      End If
      Return New ClientesDetalle(New Entidades.Cliente, ModoClienteProspecto, _DireccionCorregida)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Clientes(ModoClienteProspecto)
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor

         Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Clientes.rdlc", "SistemaDataSet_Clientes", Me.dtDatos, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = "Clientes"
         frmImprime.Show()
         'Dim imp As Imprimir = New Imprimir()
         '        Dim path As String = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\") + 1) + "Clientes.rdlc"
         'Dim path As String = "Eniac.Win.Clientes.rdlc"
         'imp.Run(path, "SistemaDataSet_Clientes", Me.dtDatos)
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad

      MyBase.GetEntidad()

      Dim clie As Entidades.Cliente = New Entidades.Cliente
      Dim blnIncluirFoto As Boolean = True
      Dim blnIncluirAdjuntos As Entidades.ModoCargaAdjunto = Entidades.ModoCargaAdjunto.SinDatos

      With Me.dgvDatos.ActiveCell.Row
         clie = New Reglas.Clientes(ModoClienteProspecto).GetUno(Long.Parse(.Cells("Id" + ModoClienteProspecto.ToString()).Value.ToString()), blnIncluirFoto, blnIncluirAdjuntos)
         clie.Usuario = actual.Nombre
         _DireccionCorregida = .Cells("DireccionVerificada").Value.ToString() = "SI"
      End With

      Return clie

   End Function

   Protected Overrides Sub FormatearGrilla()
      FormatearGrilla(dgvDatos, ModoClienteProspecto, _MostrarVendedor)
   End Sub
   Public Overloads Shared Sub FormatearGrilla(dgvDatos As UltraGrid, ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto, _MostrarVendedor As Boolean)

      dgvDatos.AgregarFiltroEnLinea({"Codigo" + ModoClienteProspecto.ToString(), "Nombre" + ModoClienteProspecto.ToString(),
                                     "NombreDeFantasia", "Direccion", "Observacion", "Telefono", "Celular",
                                     "CorreoElectronico", "CorreoAdministrativo", "PaginaWeb"})

      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0

         If .Columns.Exists("Modificado") Then
            .Columns("Modificado").FormatearColumna(String.Empty, pos, 30)
         End If
         If .Columns.Exists("FechaAuditoria") Then
            .Columns("FechaAuditoria").FormatearColumna("Fecha", pos, 100, HAlign.Center, , "dd/MM/yyyy HH:mm")
         End If
         If .Columns.Exists("OperacionAuditoria") Then
            .Columns("OperacionAuditoria").FormatearColumna("Tipo", pos, 40, HAlign.Center)
         End If
         If .Columns.Exists("UsuarioAuditoria") Then
            .Columns("UsuarioAuditoria").FormatearColumna("Usuario", pos, 70)
         End If

         .Columns("Id" + ModoClienteProspecto.ToString()).OcultoPosicion(True, pos)
         .Columns("Codigo" + ModoClienteProspecto.ToString()).FormatearColumna("Codigo", pos, 70, HAlign.Right)

         Dim hiddenClienteMuestraCodigoLetras As Boolean = Not Reglas.Publicos.ClienteMuestraCodigoClienteLetras

         .Columns("Codigo" + ModoClienteProspecto.ToString() + "Letras").FormatearColumna("Codigo Letras", pos, 70, , hiddenClienteMuestraCodigoLetras)
         .Columns("Nombre" + ModoClienteProspecto.ToString()).FormatearColumna("Nombre", pos, 180)
         .Columns("NombreDeFantasia").FormatearColumna("Nombre de Fantasia", pos, 180)

         .Columns("NombreCalle").FormatearColumna("Calle", pos, 180, , Not Reglas.Publicos.ClienteUtilizaCalle)
         .Columns("Altura").FormatearColumna("Altura", pos, 80, HAlign.Right, Not Reglas.Publicos.ClienteUtilizaCalle)

         .Columns("Direccion").FormatearColumna("Dirección", pos, 180)
         .Columns("DireccionAdicional").FormatearColumna("Adicional", pos, 80)
         .Columns("IdLocalidad").FormatearColumna("C.P.", pos, 45)
         .Columns("NombreLocalidad").FormatearColumna("Localidad", pos, 100)
         .Columns("NombreProvincia").FormatearColumna("Provincia", pos, 100)
         '.Columns("DireccionVerificada").FormatearColumna("Direcc. Igual", pos, 80, HAlign.Center, True)

         .Columns("IdCategoriaFiscal").OcultoPosicion(True, pos)
         .Columns("NombreCategoriaFiscal").FormatearColumna("Categoría Fiscal", pos, 120)

         .Columns("Cuit").FormatearColumna(My.Resources.RTextos.Cuit, pos, 80)
         .Columns("TipoDoc" + ModoClienteProspecto.ToString()).FormatearColumna("Tipo Doc.", pos, 40)
         .Columns("NroDoc" + ModoClienteProspecto.ToString()).FormatearColumna("Nro. Documento", pos, 80, HAlign.Right)
         .Columns("Telefono").FormatearColumna("Telefono", pos, 120)
         .Columns("Celular").FormatearColumna("Celular", pos, 120)
         .Columns("IdZonaGeografica").OcultoPosicion(True, pos)
         .Columns("NombreZonaGeografica").FormatearColumna("Zona Geografica", pos, 120)
         .Columns("FechaNacimiento").FormatearColumna("Fecha Nac.", pos, 70, HAlign.Center, , "dd/MM/yyyy")
         .Columns("CorreoElectronico").FormatearColumna("Correo Electronico", pos, 150)
         .Columns("PaginaWeb").FormatearColumna("Pagina Web", pos, 120)
         .Columns("CorreoAdministrativo").FormatearColumna("Correo Administrativo", pos, 150)

         .Columns("IdImpositivoOtroPais").FormatearColumna("ID Fiscal pais de origen", pos, 100)

         Dim hiddenClienteTieneTrabajo As Boolean = Not Reglas.Publicos.ClienteTieneTrabajo

         .Columns("NombreTrabajo").FormatearColumna("Trabaja en...", pos, 200, , hiddenClienteTieneTrabajo)
         .Columns("DireccionTrabajo").FormatearColumna("Dirección Trabajo", pos, 200, , hiddenClienteTieneTrabajo)
         .Columns("TelefonoTrabajo").FormatearColumna("Telefono Trab.", pos, 120, , hiddenClienteTieneTrabajo)
         .Columns("CorreoTrabajo").FormatearColumna("E-Mail Trab.", pos, 120, , hiddenClienteTieneTrabajo)
         .Columns("FechaIngresoTrabajo").FormatearColumna("Ing. Trab.", pos, 70, HAlign.Center, hiddenClienteTieneTrabajo, "dd/MM/yyyy")
         .Columns("IdLocalidadTrabajo").FormatearColumna("C.P. Trab.", pos, 40, , hiddenClienteTieneTrabajo)
         .Columns("NombreLocalidadTrabajo").FormatearColumna("Localidad Trab.", pos, 120, , hiddenClienteTieneTrabajo)


         .Columns("Id" + ModoClienteProspecto.ToString() + "Garante").OcultoPosicion(True, pos)
         .Columns("CodigoGarante").FormatearColumna("Código Garante", pos, 65, , Not Publicos.ClienteTieneGarante)
         .Columns("NombreGarante").FormatearColumna("Nombre Garante", pos, 200, , Not Publicos.ClienteTieneGarante)

         .Columns("FechaAlta").FormatearColumna("Alta", pos, 100, HAlign.Center, , "dd/MM/yyyy HH:mm")

         .Columns("IdCategoria").OcultoPosicion(True, pos)
         .Columns("NombreCategoria").FormatearColumna("Categoría", pos, 120)
         .Columns("GrupoCategoria").FormatearColumna("Grupo Cat.", pos, 100)

         .Columns("Observacion").FormatearColumna("Observación", pos, 200)

         .Columns("IdListaPrecios").OcultoPosicion(True, pos)
         .Columns("NombreListaPrecios").FormatearColumna("Lista de Precios", pos, 150)
         '.Columns("TipoDocVendedor").OcultoPosicion(True, pos)
         '.Columns("NroDocVendedor").OcultoPosicion(True, pos)
         .Columns("IdVendedor").OcultoPosicion(True, pos)
         .Columns("NombreVendedor").FormatearColumna("Nombre Vendedor", pos, 150, , Not _MostrarVendedor)

         .Columns("LimiteDeCredito").FormatearColumna("Limite de Credito", pos, 80, HAlign.Right, , "N2")


         .Columns("IdSucursalAsociada").OcultoPosicion(True, pos)
         .Columns("NombreSucursalAsociada").FormatearColumna("Nombre Suc. Asociada", pos, 150)

         .Columns("IdCaja").OcultoPosicion(True, pos)
         .Columns("NombreCaja").FormatearColumna("Caja", pos, 150)

         .Columns("DescuentoRecargoPorc").FormatearColumna("Desc/Rec. %", pos, 70, HAlign.Right, , "N2")
         .Columns("DescuentoRecargoPorc2").FormatearColumna("Desc/Rec.2  %", pos, 80, HAlign.Right, Not Publicos.ClienteDRporGrabaLibro, "N2")

         .Columns("IdTipoComprobante").FormatearColumna("Comprob. Facturacion", pos, 70)
         .Columns("Descripcion").FormatearColumna("Tipo Comprobante Facturación", pos, 120)

         .Columns("IdTipoComprobanteInvocacionMasiva").FormatearColumna("Comprob. Inv. Masiva", pos, 70)
         .Columns("DescripcionInvocacionMasiva").FormatearColumna("Tipo Comprobante Inv. Masiva", pos, 120)

         .Columns("IdFormasPago").OcultoPosicion(True, pos)
         .Columns("DescripcionFormasPago").FormatearColumna("Forma Pago", pos, 70)

         .Columns("IdTransportista").OcultoPosicion(True, pos)
         .Columns("NombreTransportista").FormatearColumna("Transportista", pos, 200)

         .Columns("Id" + ModoClienteProspecto.ToString() + "CtaCte").OcultoPosicion(True, pos)
         .Columns("Codigo" + ModoClienteProspecto.ToString() + "CtaCte").FormatearColumna("Cod." + ModoClienteProspecto.ToString() + " Vinculado", pos, 100, HAlign.Right)
         .Columns("Nombre" + ModoClienteProspecto.ToString() + "CtaCte").FormatearColumna("Nombre " + ModoClienteProspecto.ToString() + " Vinculado", pos, 150)

         .Columns("Activo").FormatearColumna("Activo", pos, 40)
         .Columns("ModificarDatos").FormatearColumna("Modificar Datos", pos, 40)

         .Columns("NumeroLote").FormatearColumna("Lote", pos, 60, HAlign.Right)

         .Columns("GeoLocalizacionLat").FormatearColumna("GL.Latitud", pos, 60, HAlign.Right)

         .Columns("GeoLocalizacionLng").FormatearColumna("GL.Longitud", pos, 60, HAlign.Right)

         .Columns("LimiteDiasVtoFactura").FormatearColumna("Limite Dias Vto", pos, 80, HAlign.Right)

         .Columns("EsResidente").OcultoPosicion(Publicos.IDAplicacionSinergia <> "SICAP", pos)

         .Columns("IdEstado").OcultoPosicion(True, pos)
         .Columns("NombreEstadoCliente").FormatearColumna("Estado", pos, 120)

         .Columns("ColorEstadoCliente").OcultoPosicion(True, pos)

         .Columns("NombreCobrador").FormatearColumna("Cobrador", pos, 120)

         .Columns("NombreTipoCliente").FormatearColumna("Tipo", pos, 100)

         Dim hiddenExtrasSinergia As Boolean = Not Reglas.Publicos.ExtrasSinergia

         .Columns("FechaCambioCategoria").FormatearColumna("Fecha Cambio Categoría", pos, 70, HAlign.Center, hiddenExtrasSinergia, "dd/MM/yyyy")
         .Columns("IdCategoriaCambio").OcultoPosicion(hidden:=True, pos)
         .Columns("NombreCategoriaCambio").FormatearColumna("Categoría Cambio", pos, 80,, hiddenExtrasSinergia)
         .Columns("ObservacionCambioCategoria").FormatearColumna("Observaciones Categoría Cambio", pos, 200,, hiddenExtrasSinergia)

         .Columns("HorarioCorrido").FormatearColumna("LaV H. Corrido", pos, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraInicio").FormatearColumna("LaV Inicio", pos, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraFin").FormatearColumna("LaV Fin", pos, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraInicio2").FormatearColumna("LaV Inic.2", pos, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraFin2").FormatearColumna("LaV Fin 2", pos, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HorarioCorridoSab").FormatearColumna("Sab H. Corrido", pos, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraSabInicio").FormatearColumna("Sab Inicio", pos, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraSabFin").FormatearColumna("Sab Fin", pos, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraSabInicio2").FormatearColumna("Sab Inic.2", pos, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraSabFin2").FormatearColumna("Sab Fin 2", pos, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HorarioCorridoDom").FormatearColumna("Dom H. Corrido", pos, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraDomInicio").FormatearColumna("Dom Inicio", pos, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraDomFin").FormatearColumna("Dom Fin", pos, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraDomInicio2").FormatearColumna("Dom Inic.2", pos, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HoraDomFin2").FormatearColumna("Dom Fin 2", pos, 60, HAlign.Center, hiddenExtrasSinergia)
         .Columns("HorarioClienteCompleto").FormatearColumna("Horario Completo", pos, 120, HAlign.Left)

         .Columns("NroVersion").FormatearColumna("Nro. Versión", pos, 80, , hiddenExtrasSinergia)
         .Columns("FechaActualizacionVersion").FormatearColumna("Fecha Actualización Versión", pos, 100, HAlign.Center, hiddenExtrasSinergia, "dd/MM/yyyy")
         .Columns("FechaInicio").FormatearColumna("Fecha Inicio", pos, 70, HAlign.Center, hiddenExtrasSinergia, "dd/MM/yyyy")
         .Columns("FechaInicioReal").FormatearColumna("Fecha Inicio Real", pos, 70, HAlign.Center, hiddenExtrasSinergia, "dd/MM/yyyy")
         .Columns("VencimientoLicencia").FormatearColumna("Vencimiento Licencia", pos, 70, HAlign.Center, hiddenExtrasSinergia, "dd/MM/yyyy")
         .Columns("BackupAutoCuenta").FormatearColumna("Cuenta Backup Automático", pos, 120, , hiddenExtrasSinergia)
         .Columns("BackupAutoConfig").FormatearColumna("Backup Automático Configurado", pos, 80, HAlign.Center, hiddenExtrasSinergia)
         .Columns("BackupNroVersion").FormatearColumna("Versión Backup Automático", pos, 80, , hiddenExtrasSinergia)

         .Columns("ActualizadorAptoParaInstalar").FormatearColumna("Apto Para Instalar Actualizador", pos, 80, , hiddenExtrasSinergia)
         .Columns("ActualizadorFunciona").FormatearColumna("Funciona Actualizador", pos, 80, , hiddenExtrasSinergia)
         .Columns("ActualizadorFechaInstalacion").FormatearColumna("Fecha Instalación Actualizador", pos, 70, HAlign.Center, hiddenExtrasSinergia, "dd/MM/yyyy")
         .Columns("ActualizadorVersion").FormatearColumna("Versión Actualizador", pos, 80, , hiddenExtrasSinergia)

         .Columns("TienePreciosConIVA").FormatearColumna("Tiene Precios Con IVA", pos, 80, , hiddenExtrasSinergia)
         .Columns("ConsultaPreciosConIVA").FormatearColumna("Consulta Precios Con IVA", pos, 80, , hiddenExtrasSinergia)
         .Columns("TieneServidorDedicado").FormatearColumna("Tiene Servidor Dedicado", pos, 80, , hiddenExtrasSinergia)
         .Columns("MotorBaseDatos").FormatearColumna("Motor Base Datos", pos, 80, , hiddenExtrasSinergia)
         .Columns("CantidadLocal").FormatearColumna("Cantidad Lic. Local", pos, 80, HAlign.Right, True)
         .Columns("CantidadRemota").FormatearColumna("Cantidad Lic. Remota", pos, 80, HAlign.Right, True)
         .Columns("CantidadDePCs").FormatearColumna("Cantidad De PCs", pos, 80, , hiddenExtrasSinergia)
         .Columns("CantidadMovil").FormatearColumna("Cantidad Lic. Movil", pos, 80, HAlign.Right, Not Reglas.Publicos.ExtrasSinergia)
         .Columns("HorasCapacitacionPactadas").FormatearColumna("Hs. Capac. Pactadas", pos, 80, HAlign.Right, hiddenExtrasSinergia)
         .Columns("HorasCapacitacionRealizadas").FormatearColumna("Hs. Capac. Realizadas", pos, 80, HAlign.Right, hiddenExtrasSinergia)
         .Columns("IdAplicacion").FormatearColumna("Aplicacion", pos, 80, , hiddenExtrasSinergia)
         .Columns("Edicion").FormatearColumna("Edicion", pos, 80, , hiddenExtrasSinergia)

         .Columns("URLWebmovilPropio").FormatearColumna("URL Webmovil propio", pos, 200, , hiddenExtrasSinergia)
         .Columns("URLWebmovilAdminPropio").FormatearColumna("URL Webmovil Admin propio", pos, 200, , hiddenExtrasSinergia)
         .Columns("URLSimovilGestionPropio").FormatearColumna("URL Simovil Gestión propio", pos, 200, , hiddenExtrasSinergia)
         .Columns("URLActualizadorPropio").FormatearColumna("URL Actualizador Automático propio", pos, 200, , hiddenExtrasSinergia)

         .Columns("NroVersionWebmovilPropio").FormatearColumna("Nro. Version Webmovil propio", pos, 80, , hiddenExtrasSinergia)
         .Columns("NroVersionWebmovilAdminPropio").FormatearColumna("Nro. Version Webmovil Admin propio", pos, 80, , hiddenExtrasSinergia)
         .Columns("NroVersionSimovilGestionPropio").FormatearColumna("Nro. Version Simovil Gestión propio", pos, 80, , hiddenExtrasSinergia)
         .Columns("NroVersionActualizadorPropio").FormatearColumna("Nro. Version Actualizador Automático propio", pos, 80, , hiddenExtrasSinergia)

         .Columns("CBU").FormatearColumna("CBU", pos, 200, , Not Reglas.Publicos.ClienteUtilizaCBU)
         .Columns("IdBanco").OcultoPosicion(True, pos)
         .Columns("NombreBanco").FormatearColumna("Nombre Banco", pos, 80)
         .Columns("IdCuentaBancariaClase").OcultoPosicion(True, pos)
         .Columns("NombreCuentaBancariaClase").FormatearColumna("Clase Cuenta Bancaria", pos, 80)
         .Columns("NumeroCuentaBancaria").OcultoPosicion(True, pos)
         .Columns("CuitCtaBancaria").FormatearColumna(My.Resources.RTextos.CuitCtaBancaria, pos, 80, , Not Reglas.Publicos.ClienteUtilizaCBU)

         .Columns(Entidades.Cliente.Columnas.UsaArchivoAImprimir2.ToString()).FormatearColumna("Usa Impresión 2", pos, 60, HAlign.Center)
         .Columns(Entidades.Cliente.Columnas.CantidadVisitas.ToString()).FormatearColumna("Cantidad de Visitas", pos, 70, HAlign.Right)

         .Columns(Entidades.Cliente.Columnas.Facebook.ToString()).FormatearColumna("Facebook", pos, 100)
         .Columns(Entidades.Cliente.Columnas.Instagram.ToString()).FormatearColumna("Instagram", pos, 100)
         .Columns(Entidades.Cliente.Columnas.Twitter.ToString()).FormatearColumna("Twitter", pos, 100)

         .Columns(Entidades.Cliente.Columnas.RecibeNotificaciones.ToString()).FormatearColumna("Recibe Notificaciones", pos, 100, HAlign.Center)

         .Columns("RequiereRevisionAdministrativa").FormatearColumna("Req. Rev. Administrativa", pos, 80, HAlign.Center)


         .Columns("IngresosBrutos").FormatearColumna("Ingresos Brutos", pos, 100)
         .Columns("InscriptoIBStaFe").FormatearColumna("Inscripto IIBB", pos, 60)
         .Columns("LocalIB").FormatearColumna("IIBB Local", pos, 60)
         .Columns("ConvMultilateralIB").FormatearColumna("Conv. Multilat.", pos, 60)
         .Columns("IdTipoDeExension").FormatearColumna("Tipo Excension", pos, 60, HAlign.Right)
         .Columns("AnioExension").FormatearColumna("Año Excension", pos, 60, HAlign.Right)
         .Columns("NroCertExension").FormatearColumna("Nro. Cert. Exension", pos, 80, HAlign.Right)
         .Columns("NroCertPropio").FormatearColumna("Nro. Cert. Propio", pos, 80, HAlign.Right)

         .Columns("EsExentoPercIVARes53292023").FormatearColumna("Exento Perc. IVA Res. 5329/2023", pos, 80, HAlign.Center)

         .Columns("FechaActualizacionWeb").FormatearColumna("Fecha Act. Web", pos, 130, HAlign.Center, , "dd/MM/yyyy HH:mm:ss")

         .Columns("SiMovilIdUsuario").FormatearColumna("Usuario SiMovil", pos, 80, )
         .Columns("SiMovilClave").FormatearColumna("Clave SiMovil", pos, 80, , True)

         'No se usan
         .Columns("LetraFiscal").Hidden = True
         .Columns("NroOperacion").Hidden = True
         .Columns("SaldoPendiente").Hidden = True
         .Columns("IdCobrador").Hidden = True
         '.Columns("TipoDocCobrador").OcultoPosicion(True, pos)
         '.Columns("NroDocCobrador").OcultoPosicion(True, pos)
         .Columns("IdTipoCliente").Hidden = True

         'Del SiLIVE
         .Columns("Contacto").Hidden = True
         .Columns("FechaBaja").Hidden = True
         .Columns("VerEnConsultas").Hidden = True
         .Columns("IdCalle").Hidden = True
         '.Columns("NombreCalle").Hidden = True
         '.Columns("Altura").Hidden = True
         .Columns("IdCalle2").Hidden = True
         .Columns("NombreCalle2").Hidden = True
         .Columns("Altura2").Hidden = True
         .Columns("DireccionAdicional2").Hidden = True
         .Columns("TelefonosParticulares").Hidden = True
         .Columns("Fax").Hidden = True
         .Columns("FechaSUS").Hidden = True
         '.Columns("TipoDocDadoAltaPor").Hidden = True
         '.Columns("NroDocDadoAltaPor").Hidden = True
         .Columns("IdDadoAltaPor").Hidden = True
         .Columns("NombreDadoAltaPor").Hidden = True
         .Columns("HabilitarVisita").Hidden = True
         .Columns("Direccion2").Hidden = True
         .Columns("IdLocalidad2").Hidden = True
         .Columns("NombreLocalidad2").Hidden = True
         .Columns("NombreProvincia2").Hidden = True
         .Columns("ObservacionWeb").Hidden = True
         .Columns("RepartoIndependiente").Hidden = True
         .Columns("NivelAutorizacion").FormatearColumna("Nivel de Autorizacion", pos, 80, HAlign.Right)

         .Columns(Entidades.Cliente.Columnas.IdCuentaContable.ToString()).FormatearColumna("Cuenta", pos, 90)
         .Columns("NombreCuentaContable").FormatearColumna("Nombre Cuenta", pos, 280)

         If Not Reglas.Publicos.TieneModuloContabilidad Then
            .Columns(Entidades.Cliente.Columnas.IdCuentaContable.ToString()).Hidden = True
            .Columns("NombreCuentaContable").Hidden = True
         End If
         .Columns("EsClienteGenerico").Hidden = True


         .Columns("ActualizarAplicacion").FormatearColumna("Actualizar Aplicacion", pos, 80, HAlign.Center, Not Reglas.Publicos.ExtrasSinergia)
         .Columns("ControlaBackup").FormatearColumna("Controla Backup", pos, 80, HAlign.Center, Not Reglas.Publicos.ExtrasSinergia)

         .Columns("UtilizaAppSoporte").FormatearColumna("Utiliza App Soporte", pos, 80, HAlign.Center, Not Reglas.Publicos.ExtrasSinergia)
         .Columns("ObservacionAdministrativa").FormatearColumna("Observacion Administrativa", pos, 150, HAlign.Left, Not Reglas.Publicos.ExtrasSinergia)

         .Columns("Alicuota2deProducto").FormatearColumna("Alicuota 2 de Producto", pos, 150, HAlign.Left, Not Reglas.Publicos.ProductoUtilizaAlicuota2)

         .Columns("CertificadoMiPyme").FormatearColumna("Certificado MiPyme", pos, 60, HAlign.Center)

         .Columns("IdConceptoCM05").OcultoPosicion(True, pos)
         .Columns("DescripcionConceptoCM05").FormatearColumna("Concepto CM05", pos, 150)
         .Columns("TipoConceptoCM05").FormatearColumna("Tipo Concepto", pos, 100, HAlign.Center)

         .Columns("FechaDesdeCertificado").FormatearColumna("Desde Certificado", pos, 70, HAlign.Left)

         .Columns("FechaHastaCertificado").FormatearColumna("Hasta Certificado", pos, 70, HAlign.Left)

         .Columns("Sexo").FormatearColumna("Sexo", pos, 70, HAlign.Center)

         .Columns(String.Format("Id{0}TiendaNube", ModoClienteProspecto.ToString())).FormatearColumna(String.Format("Cód. {0} Tienda Nube", ModoClienteProspecto.ToString()), pos, 70, HAlign.Right)
         .Columns(String.Format("Id{0}MercadoLibre", ModoClienteProspecto.ToString())).FormatearColumna(String.Format("Cód. {0} Mercado Libre", ModoClienteProspecto.ToString()), pos, 70, HAlign.Right, True)
         .Columns(String.Format("Id{0}Arborea", ModoClienteProspecto.ToString())).FormatearColumna(String.Format("Cód. {0} Arborea", ModoClienteProspecto.ToString()), pos, 70, HAlign.Right, True)

         Dim puedeVerDetalleValoracionEstrellas As Boolean = New Reglas.Usuarios().TienePermisos("PuedeVerDetalleEstrellas")
         .Columns("ValorizacionFacturacionMensual").FormatearColumna("Facturación Mensual", pos, 80, HAlign.Right, Not puedeVerDetalleValoracionEstrellas, "N2")
         .Columns("ValorizacionCoeficienteFacturacion").FormatearColumna("Coef. Facturación", pos, 80, HAlign.Right, Not puedeVerDetalleValoracionEstrellas, "N2")
         .Columns("ValorizacionFacturacion").FormatearColumna("Valoración Facturación", pos, 80, HAlign.Right, Not puedeVerDetalleValoracionEstrellas, "N2")

         .Columns("ValorizacionImporteAdeudado").FormatearColumna("Importe Adeudado", pos, 80, HAlign.Right, Not puedeVerDetalleValoracionEstrellas, "N2")
         .Columns("ValorizacionCoeficienteDeuda").FormatearColumna("Coef. Deuda", pos, 80, HAlign.Right, Not puedeVerDetalleValoracionEstrellas, "N2")
         .Columns("ValorizacionDeuda").FormatearColumna("Valoración Deuda", pos, 80, HAlign.Right, Not puedeVerDetalleValoracionEstrellas, "N2")

         .Columns("ValorizacionProyecto").FormatearColumna("Valoración Proyecto", pos, 80, HAlign.Right, Not puedeVerDetalleValoracionEstrellas, "N2")
         .Columns("ValorizacionProyectoObservacion").FormatearColumna("Observación Valoración Proyecto", pos, 180, , Not puedeVerDetalleValoracionEstrellas)

         .Columns("Valorizacion" + ModoClienteProspecto.ToString()).FormatearColumna("Valoración", pos, 80, HAlign.Right, Not puedeVerDetalleValoracionEstrellas, "N2")
         .Columns("ValorizacionEstrellas").FormatearColumna("Estrellas", pos, 80, HAlign.Right, , "N2")

         .Columns("PublicarEnWeb").FormatearColumna("Publicar en Web", pos, 80, HAlign.Center)

         .Columns("Foto").OcultoPosicion(hidden:=True, pos)
         .Columns("BackColor").OcultoPosicion(hidden:=True, pos)
         .Columns("ForeColor").OcultoPosicion(hidden:=True, pos)

         .Columns("IDEmbarcacion").OcultoPosicion(hidden:=True, pos)
         .Columns("NombreEmbarcacion").OcultoPosicion(hidden:=True, pos)
         .Columns("IdCama").OcultoPosicion(hidden:=True, pos)
         .Columns("CodigoCama").OcultoPosicion(hidden:=True, pos)


         If Reglas.Publicos.ClienteUtilizaCalle Then
            'If dgvDatos.DataSource(Of DataTable).Any(Function(dr) dr.Field(Of String)("DireccionVerificada") = "NO") Then
            '   dgvDatos.DisplayLayout.Bands(0).Columns("DireccionVerificada").Hidden = False
            'End If

         End If

      End With

   End Sub

   Protected Overrides Sub Borrar()
      MyBase.Borrar()
   End Sub

#End Region

#Region "Metodos"

   Public Sub PresionarGeo(o As Object, e As EventArgs)
      Try
         Dim geo As ClientesGeoLocalizacion = New ClientesGeoLocalizacion()
         geo.Clientes = DirectCast(Me.dgvDatos.DataSource, DataTable)
         geo.ShowDialog()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      If Not String.IsNullOrWhiteSpace(parametros) Then
         Dim stateForm As StateForm
         If [Enum].TryParse(parametros, stateForm) Then
            _StateForm = stateForm
         End If
      End If
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try
         tsbFiltrar.PerformClick()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Function Buscar(rg As Reglas.Base, bus As Entidades.Buscar) As DataTable
      Return VerficaDireccion(LimpiaPassword(DirectCast(rg, Reglas.Clientes).Buscar(bus, GetFiltro())))
      'Return MyBase.Buscar(rg, bus)
   End Function

   Protected Overrides Function GetAll(rg As Reglas.Base) As DataTable
      Return VerficaDireccion(LimpiaPassword(DirectCast(rg, Reglas.Clientes).GetAll(GetFiltro())))
      'Return MyBase.GetAll(rg)
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

   Private Function GetFiltro() As Entidades.Filtros.ClientesABMFiltros
      Dim filtro As Entidades.Filtros.ClientesABMFiltros
      filtro = New Entidades.Filtros.ClientesABMFiltros() With {.FechaNacimientoIncluirAnio = chbFechaNacimientoIncluirAnio.Checked}

      If chbFechaAlta.Checked Then
         filtro.FechaAltaDesde = dtpFechaAltaDesde.Value
         filtro.FechaAltaHasta = dtpFechaAltaHasta.Value
      End If

      If chbFechaNacimiento.Checked Then
         filtro.FechaNacimientoDesde = dtpFechaNacimientoDesde.Value
         filtro.FechaNacimientoHasta = dtpFechaNacimientoHasta.Value
      End If

      If Me.cmbVendedor.Enabled Then
         filtro.IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
      End If

      Return filtro
   End Function

   Private Sub chbFechaAlta_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaAlta.CheckedChanged
      Try
         chkMesCompletoFechaAlta.Enabled = chbFechaAlta.Checked
         dtpFechaAltaDesde.Enabled = chbFechaAlta.Checked
         dtpFechaAltaHasta.Enabled = chbFechaAlta.Checked
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbFechaNacimiento_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaNacimiento.CheckedChanged
      Try
         chkMesCompletoFechaNacimiento.Enabled = chbFechaNacimiento.Checked
         dtpFechaNacimientoDesde.Enabled = chbFechaNacimiento.Checked
         dtpFechaNacimientoHasta.Enabled = chbFechaNacimiento.Checked
         chbFechaNacimientoIncluirAnio.Enabled = chbFechaNacimiento.Checked
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


   Private Sub chkMesCompletoFechaAlta_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkMesCompletoFechaAlta.CheckedChanged
      Try
         If chkMesCompletoFechaAlta.Checked Then
            Me.dtpFechaAltaDesde.Value = dtpFechaAltaDesde.Value.PrimerDiaMes()
            Me.dtpFechaAltaHasta.Value = dtpFechaAltaDesde.Value.UltimoDiaMes(True)
         End If
         Me.dtpFechaAltaDesde.Enabled = Not Me.chkMesCompletoFechaAlta.Checked
         Me.dtpFechaAltaHasta.Enabled = Not Me.chkMesCompletoFechaAlta.Checked
      Catch ex As Exception
         chkMesCompletoFechaAlta.Checked = False
         ShowError(ex)
      End Try
   End Sub

   Private Sub chkMesCompletoFechaNacimiento_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkMesCompletoFechaNacimiento.CheckedChanged
      Try
         If chkMesCompletoFechaNacimiento.Checked Then
            Me.dtpFechaNacimientoDesde.Value = dtpFechaNacimientoDesde.Value.PrimerDiaMes()
            Me.dtpFechaNacimientoHasta.Value = dtpFechaNacimientoDesde.Value.UltimoDiaMes(True)
         End If
         Me.dtpFechaNacimientoDesde.Enabled = Not Me.chkMesCompletoFechaNacimiento.Checked
         Me.dtpFechaNacimientoHasta.Enabled = Not Me.chkMesCompletoFechaNacimiento.Checked
      Catch ex As Exception
         chkMesCompletoFechaNacimiento.Checked = False
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbFechaNacimientoIncluirAnio_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaNacimientoIncluirAnio.CheckedChanged
      Try
         If chbFechaNacimientoIncluirAnio.Checked Then
            dtpFechaNacimientoDesde.CustomFormat = "dd/MM/yyyy HH:mm:ss"
            dtpFechaNacimientoHasta.CustomFormat = "dd/MM/yyyy HH:mm:ss"
         Else
            dtpFechaNacimientoDesde.CustomFormat = "dd/MM"
            dtpFechaNacimientoHasta.CustomFormat = "dd/MM"
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub dgvDatos_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      Dim dr As DataRow = dgvDatos.FilaSeleccionada(Of DataRow)(e.Row)
      If dr IsNot Nothing Then
         If IsNumeric(dr("ColorEstadoCliente")) Then
            Dim colorEstado As Color = Color.FromArgb(Integer.Parse(dr("ColorEstadoCliente").ToString()))
            e.Row.Cells(Entidades.EstadoCliente.Columnas.NombreEstadoCliente.ToString()).Appearance.BackColor = colorEstado
            e.Row.Cells(Entidades.EstadoCliente.Columnas.NombreEstadoCliente.ToString()).ActiveAppearance.BackColor = colorEstado

            e.Row.Cells("Nombre" + ModoClienteProspecto.ToString()).Appearance.BackColor = colorEstado
            e.Row.Cells("Nombre" + ModoClienteProspecto.ToString()).ActiveAppearance.BackColor = colorEstado
         End If
      End If
   End Sub

   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      Try
         Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

         If Not Me.chbVendedor.Checked Then
            Me.cmbVendedor.SelectedIndex = -1
         Else
            If Me.cmbVendedor.Items.Count > 0 Then
               Me.cmbVendedor.SelectedIndex = 0
            End If
         End If

         Me.cmbVendedor.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub CallSincronizarcionAFIP()
      Using frm As New SincronizarConAFIP
         '-- Define Tipo de Consulta.- --
         frm.TipoClienteProveedor = Entidades.Publicos.TipoContribuyente.CLIENTE
         frm.ShowDialog(Me)
      End Using
      MyBase.RefreshGrid()
   End Sub

End Class