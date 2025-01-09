Option Strict Off
Imports Eniac.Reglas
Imports GMap.NET
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET.MapProviders

Public Class ContactosDetalle

#Region "Campos"


   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
   Private _direcciones As DataTable

#End Region

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.Contacto)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         'Seguridad del Descuento/Recargo General
         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
                 '---------------------------------------

         Me._publicos = New Publicos()

         Me._publicos.CargaComboTipoDocumento(Me.cmbTipoDoc)
         'Me._publicos.CargaComboLocalidades(Me.cmbLocalidad)
         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me._publicos.CargaComboTiposDirecciones(Me.cmbTiposDirecciones)
         Me._publicos.CargaComboCategoriasFiscales(Me.cmbCategoriaFiscal)
         Me._publicos.CargaComboTiposContactos(Me.cmbTipoContacto)

        
         Dim blnMiraUsuario As Boolean = False  'Se bien deberia controlarlo a la hora de factura no lo tiene cargado asi que no lograria hacerle un comprobante.
         Dim blnMiraPC As Boolean = False
         Dim blnCajasModificables As Boolean = False
      
         Me._liSources.Add("CategoriaFiscal", DirectCast(Me._entidad, Entidades.Contacto).CategoriaFiscal)
         Me._liSources.Add("Localidad", DirectCast(Me._entidad, Entidades.Contacto).Localidad)
         Me._liSources.Add("ZonaGeografica", DirectCast(Me._entidad, Entidades.Contacto).ZonaGeografica)

         Me.BindearControles(Me._entidad, Me._liSources)

         'If Publicos.ContactoUtilizaGeolocalizacion Then
         '   Me.cmbTipoMapa.Text = "Google Maps"
         '   GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly
         '   Me.gmcMapa.SetPositionByKeywords("Rosario, Argentina")
         '   GMapProvider.Language = LanguageType.Spanish
         '   Me.gmcMapa.Zoom = 11
         '   Me.gmcMapa.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance
         'End If

         Me._entidad.Usuario = actual.Nombre

         'If Not Publicos.ClienteTieneMultiplesDirecciones Then
         'Me.tbcContacto.TabPages.Remove(Me.tbpDirecciones)
         'End If

         Me.cmbZonaGeografica.SelectedIndex = 0

         Me.tbcContacto.TabPages.Remove(Me.tbpMapa)

         If Me.StateForm = Eniac.Win.StateForm.Actualizar Then

            ''Se usa en las pantallas que llaman directamente al editar.
            'Me.txtCodigoContacto.Tag = DirectCast(Me._entidad, Entidades.Contacto).IdContacto
            Me.cmbTipoDoc.Text = DirectCast(Me._entidad, Entidades.Contacto).TipoDocContacto

            Me.CargarDirecciones()

            Me.tbcContacto.SelectedTab = Me.tbpFoto
            Me.pcbFoto.Image = DirectCast(Me._entidad, Entidades.Contacto).Foto

            'Navego los tabs para activar los controles combobox y que luego se validen, sino, no sucede.
            Me.tbcContacto.SelectedTab = Me.tbpOtros

            Me.tbcContacto.SelectedTab = Me.tbpMapa

            Me.tbcContacto.SelectedTab = Me.tbpDatos
            Me.bscCodigoLocalidad.PresionarBoton()
            Me.dtpFechaAlta.Enabled = False


         Else

            'Insertar

            Me.chbPrivado.Checked = Eniac.Reglas.Publicos.ContactosAgendaPrivada

            Me.ChequeaEstructuraDirecciones()

            Me.chbActivo.Checked = True

            Me.tbcContacto.SelectedTab = Me.tbpOtros

            Me.tbcContacto.SelectedTab = Me.tbpDatos

            'Me.bscCodigoLocalidad.Text = actual.Sucursal.Localidad.IdLocalidad.ToString()
            Me.bscCodigoLocalidad.Text = actual.Sucursal.LocalidadComercial.IdLocalidad.ToString()
            Me.bscCodigoLocalidad.PresionarBoton()

            If Me.cmbZonaGeografica.Items.Count = 1 Then
               Me.cmbZonaGeografica.SelectedIndex = 0
            End If

            Me.CargarProximoCodigo()

         End If

         Me._estaCargando = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Contactos
   End Function

   Protected Overrides Function ValidarDetalle() As String

      
      If Long.Parse("0" & Me.txtNroDoc.Text) > 0 And Me.cmbTipoDoc.SelectedIndex = -1 Then
         Return "Falta Indicar el Tipo de Documento."
      End If

      If Long.Parse("0" & Me.txtNroDoc.Text) <> 0 And Me.cmbTipoDoc.SelectedIndex <> -1 Then
         If Long.Parse(Me.txtNroDoc.Text.ToString()) < 1000000 Then
            Return "Numero de documento no válido"
         End If
      End If

      If Not Me.bscCodigoLocalidad.Selecciono And Not Me.bscNombreLocalidad.Selecciono Then
         Me.tbcContacto.SelectedTab = Me.tbpDatos
         Me.bscCodigoLocalidad.Focus()
         Return "No selecciono la Localidad."
      End If

      If Me.cmbTipoContacto.SelectedIndex = -1 Then
         Return "Falta Indicar el Tipo de Contacto."
      End If

      If Me.cmbCategoriaFiscal.SelectedIndex = -1 Then
         Return "Falta Indicar la categoría fiscal."
      End If

      'Return vacio
      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()


      DirectCast(Me._entidad, Entidades.Contacto).Direcciones = Me._direcciones

      DirectCast(Me._entidad, Entidades.Contacto).Usuario = actual.Nombre
      Me.cmbZonaGeografica.SelectedIndex = 0
      DirectCast(Me._entidad, Entidades.Contacto).ZonaGeografica = New Reglas.ZonasGeograficas().GetUno(Me.cmbZonaGeografica.SelectedValue.ToString())
      MyBase.Aceptar()

      If Not Me.HayError Then Me.Close()
      Me.txtCodigoContacto.Focus()

   End Sub

   'Protected Overrides Sub LimpiarControles()
   '   MyBase.LimpiarControles()
   '   Me.cmbTipoDoc.Text = Publicos.TipoDocumentoContacto()
   '   Me.cmbLocalidad.SelectedIndex = -1
   '   Me.cmbZonaGeografica.SelectedIndex = -1
   '   Me.cmbCategoriaFiscal.SelectedIndex = -1
   '   Me.cmbCategorias.SelectedIndex = -1
   '   Me.cmbVendedor.SelectedIndex = -1
   '   Me.cmbListasDePrecios.SelectedIndex = 0   'Pongo la lista Base.
   '   Me.cmbLocalidadTrabajo.SelectedIndex = -1
   '   Me.chbActivo.Checked = True
   'End Sub

#End Region

#Region "Eventos"

   Private Sub ContactosDetalle_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
      Try
         If Me.StateForm = Eniac.Win.StateForm.Actualizar Then
            Me.txtNombre.Focus()
         Else
            Me.txtCodigoContacto.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lnkLocalidad_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkLocalidad.LinkClicked
      Try
         Dim PantLocalidad As LocalidadesDetalle = New LocalidadesDetalle(New Entidades.Localidad())
         PantLocalidad.StateForm = Win.StateForm.Insertar
         PantLocalidad.CierraAutomaticamente = True
         If PantLocalidad.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.bscCodigoLocalidad.Text = PantLocalidad.IdLocalidad.ToString()
            Me.bscCodigoLocalidad.PresionarBoton()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoLocalidad_BuscadorClick() Handles bscCodigoLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscCodigoLocalidad)
         Me.bscCodigoLocalidad.Datos = oLocalidades.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoLocalidad.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoLocalidad_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
            Me.cmbCategoriaFiscal.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreLocalidad_BuscadorClick() Handles bscNombreLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscNombreLocalidad)
         Me.bscNombreLocalidad.Datos = oLocalidades.GetPorNombre(Me.bscNombreLocalidad.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreLocalidad_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
            Me.cmbCategoriaFiscal.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnLimpiarImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarImagen.Click
      Try
         DirectCast(Me._entidad, Entidades.Contacto).Foto = Nothing
         Me.pcbFoto.Image = Nothing
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnBuscarImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarImagen.Click
      Try
         If Me.ofdArchivos.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.ofdArchivos.FileName) Then
               If System.IO.File.ReadAllBytes(Me.ofdArchivos.FileName).Length > Publicos.TamañoMaximoImagenes Then
                  MessageBox.Show("El tamaño de la imagen no puede ser mayor a " + (Publicos.TamañoMaximoImagenes / 1000).ToString() + "KB", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If
               Me.pcbFoto.Image = New System.Drawing.Bitmap(Me.ofdArchivos.FileName)
               DirectCast(Me._entidad, Entidades.Contacto).Foto = Me.pcbFoto.Image
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtNroDoc.Focus()
   End Sub

   Private Sub cmbCategoriaFiscal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoriaFiscal.SelectedIndexChanged
      If Me._estaCargando Then Exit Sub
      DirectCast(Me._entidad, Entidades.Contacto).CategoriaFiscal = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal)
   End Sub

   Private Sub lnkLocalidadDir_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkLocalidadDir.LinkClicked
      Try
         Dim PantLocalidad As LocalidadesDetalle = New LocalidadesDetalle(New Entidades.Localidad())
         PantLocalidad.StateForm = Win.StateForm.Insertar
         PantLocalidad.CierraAutomaticamente = True
         If PantLocalidad.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.bscCodigoLocalidadDir.Text = PantLocalidad.IdLocalidad.ToString()
            Me.bscCodigoLocalidadDir.PresionarBoton()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoLocalidadDir_BuscadorClick() Handles bscCodigoLocalidadDir.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscCodigoLocalidadDir)
         Me.bscCodigoLocalidadDir.Datos = oLocalidades.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoLocalidadDir.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoLocalidadDir_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidadDir.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidadDir(e.FilaDevuelta)
            Me.cmbTiposDirecciones.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreLocalidadDir_BuscadorClick() Handles bscNombreLocalidadDir.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscNombreLocalidadDir)
         Me.bscNombreLocalidadDir.Datos = oLocalidades.GetPorNombre(Me.bscNombreLocalidadDir.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreLocalidadDir_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreLocalidadDir.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidadDir(e.FilaDevuelta)
            Me.cmbTiposDirecciones.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnInsertarDir_Click(sender As Object, e As EventArgs) Handles btnInsertarDir.Click
      Try
         If Me.bscCodigoLocalidadDir.Text <> "" Then
            If Me.txtDirecciones.Text <> "" Then
               Me.AgregarDireccion()
               Me.RefrescarDirecciones()
            Else
               MessageBox.Show("No ingreso la Dirección", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
         Else
            MessageBox.Show("No ingreso la Localidad", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminarDir_Click(sender As Object, e As EventArgs) Handles btnEliminarDir.Click
      Try
         If Me.dgvDirecciones.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar la Dirección seleccionada?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaDireccion()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnRefreshDir_Click(sender As Object, e As EventArgs) Handles btnRefreshDir.Click
      Try
         Me.RefrescarDirecciones()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvDirecciones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDirecciones.CellDoubleClick
      Try

         Me.LimpiarCampos()
         Me.CargarLineaCompleta(Me.dgvDirecciones.Rows(e.RowIndex))
         Me.EliminarLinea()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtCodigoContacto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoContacto.KeyDown
      If e.KeyCode = Keys.Enter Then
         PresionarTab(e)
      End If
   End Sub

   Private Sub txtNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyDown
      If e.KeyCode = Keys.Enter Then
         PresionarTab(e)
         Me.chbActivo.Focus()
      End If
   End Sub

   Private Sub chbActivo_KeyDown(sender As Object, e As KeyEventArgs) Handles chbActivo.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.cmbTipoContacto.Focus()
         Me.cmbTipoContacto.DroppedDown = True
      End If
   End Sub

   Private Sub cmbTipoContacto_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTipoContacto.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.chbPrivado.Focus()
      End If
   End Sub

   Private Sub chbPrivado_KeyDown(sender As Object, e As KeyEventArgs) Handles chbPrivado.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtDireccion.Focus()
      End If
   End Sub

   Private Sub txtDireccion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDireccion.KeyDown
      If e.KeyCode = Keys.Enter Then
         PresionarTab(e)
      End If
   End Sub

   Private Sub dtpFechaAlta_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFechaAlta.KeyDown
      If e.KeyCode = Keys.Enter Then
         PresionarTab(e)
      End If
   End Sub

   Private Sub cmbCategoriaFiscal_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCategoriaFiscal.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtCUIT.Focus()
      End If
   End Sub

   Private Sub txtCUIT_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCUIT.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.dtpFechaNacimiento.Focus()
      End If
   End Sub

   Private Sub dtpFechaNacimiento_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFechaNacimiento.KeyDown
      If e.KeyCode = Keys.Enter Then
         PresionarTab(e)
         Me.cmbTipoDoc.Focus()
         Me.cmbTipoDoc.DroppedDown = True
      End If
   End Sub

   Private Sub cmbTipoDoc_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTipoDoc.KeyDown
      If e.KeyCode = Keys.Enter Then
         PresionarTab(e)
      End If
   End Sub

   Private Sub txtNroDoc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNroDoc.KeyDown
      If e.KeyCode = Keys.Enter Then
         PresionarTab(e)
      End If
   End Sub

   Private Sub txtTelefonos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTelefonos.KeyDown
      If e.KeyCode = Keys.Enter Then
         PresionarTab(e)
      End If
   End Sub

   Private Sub txtCelular_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCelular.KeyDown
      If e.KeyCode = Keys.Enter Then
         PresionarTab(e)
      End If
   End Sub

   Private Sub txtCorreoElectronico_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorreoElectronico.KeyDown
      If e.KeyCode = Keys.Enter Then
         PresionarTab(e)
      End If
   End Sub

   Private Sub txtPaginaWeb_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPaginaWeb.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.btnAceptar.Focus()
      End If
   End Sub

   Private Sub bscNombreLocalidad_KeyDown(sender As Object, e As KeyEventArgs) Handles bscNombreLocalidad.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.cmbCategoriaFiscal.DroppedDown = True
      End If
   End Sub

   Private Sub bscCodigoLocalidad_KeyDown(sender As Object, e As KeyEventArgs) Handles bscCodigoLocalidad.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.cmbCategoriaFiscal.DroppedDown = True
      End If
   End Sub

   Private Sub txtDirecciones_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDirecciones.KeyDown
      If e.KeyCode = Keys.Enter Then
         PresionarTab(e)
      End If
   End Sub

   Private Sub cmbTiposDirecciones_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTiposDirecciones.KeyDown
      If e.KeyCode = Keys.Enter Then
         PresionarTab(e)
      End If
   End Sub

   Private Sub txtTelefonoDir_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTelefonoDir.KeyDown
      If e.KeyCode = Keys.Enter Then
         PresionarTab(e)
      End If
   End Sub

   Private Sub txtCelularDir_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCelularDir.KeyDown
      If e.KeyCode = Keys.Enter Then
         PresionarTab(e)
      End If
   End Sub

   Private Sub txtCorreoDir_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorreoDir.KeyDown
      If e.KeyCode = Keys.Enter Then
         PresionarTab(e)
      End If
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoCodigo()

      Dim oContacto As Contactos = New Contactos()
      Dim ProximoContacto As Long

      ProximoContacto = oContacto.GetCodigoContactoMaximo(Entidades.Contacto.Columnas.IdContacto.ToString()) + 1
      Me.txtCodigoContacto.Text = ProximoContacto.ToString()
      'Me.txtCodigoContacto.Tag = Me.txtCodigoContacto.Text

      If ProximoContacto > Long.Parse(Me.txtCodigoContacto.Text) Then
         Me.txtNroDoc.Text = Me.txtCodigoContacto.Text
      End If

   End Sub

   Private Sub CargarLocalidad(ByVal dr As DataGridViewRow)
      DirectCast(Me._entidad, Entidades.Contacto).Localidad = New Reglas.Localidades().GetUna(Integer.Parse(dr.Cells("IdLocalidad").Value.ToString()))
      Me.bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      Me.txtProvinciaLocalidad.Text = dr.Cells("NombreProvincia").Value.ToString()
   End Sub

   Private Sub CargarLocalidadDir(ByVal dr As DataGridViewRow)
      Me.bscCodigoLocalidadDir.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.bscNombreLocalidadDir.Text = dr.Cells("NombreLocalidad").Value.ToString()
      Me.txtProvinciaLocalidadDir.Text = dr.Cells("NombreProvincia").Value.ToString()
   End Sub

   Private Sub AgregarDireccion()

      Dim dr As DataRow = Me._direcciones.NewRow()

      dr(0) = DirectCast(Me._entidad, Entidades.Contacto).IdContacto
      dr(1) = Me.txtDirecciones.Text
      dr(2) = Me.bscCodigoLocalidadDir.Text
      dr(3) = Me.bscNombreLocalidadDir.Text
      dr(4) = Me.txtProvinciaLocalidadDir.Text
      Dim tipoDir As Entidades.TipoDireccion = New Reglas.TiposDirecciones().GetUna(Integer.Parse(Me.cmbTiposDirecciones.SelectedValue.ToString()))
      dr(5) = tipoDir.IdTipoDireccion
      dr(6) = tipoDir.NombreAbrevTipoDireccion
      dr(7) = Me.txtTelefonoDir.Text
      dr(8) = Me.txtCelularDir.Text
      dr(9) = Me.txtCorreoDir.Text

      Me._direcciones.Rows.Add(dr)

      Me.dgvDirecciones.DataSource = Me._direcciones

   End Sub

   Private Sub EliminarLineaDireccion()

      Me._direcciones.Rows(Me.dgvDirecciones.SelectedRows(0).Index).Delete()
      Me.dgvDirecciones.DataSource = Me._direcciones

      If Me.dgvDirecciones.Rows.Count > 0 Then
         Me.dgvDirecciones.FirstDisplayedScrollingRowIndex = Me.dgvDirecciones.Rows.Count - 1
         Me.dgvDirecciones.Rows(Me.dgvDirecciones.Rows.Count - 1).Selected = True
      End If

   End Sub

   Public Sub CargarDirecciones()

      Dim IdContacto As Long = 0

      IdContacto = DirectCast(Me._entidad, Entidades.Contacto).IdContacto

      Dim reg As Reglas.ContactosDirecciones

      reg = New Reglas.ContactosDirecciones()

      Me._direcciones = reg.GetContactosDirecciones(IdContacto)

      Me.dgvDirecciones.DataSource = Me._direcciones

   End Sub

   Private Sub ChequeaEstructuraDirecciones()

      If Me._direcciones Is Nothing Then
         Me._direcciones = New DataTable()
         Me._direcciones.Columns.Add("IdContacto", System.Type.GetType("System.String"))
         Me._direcciones.Columns.Add("Direccion", System.Type.GetType("System.String"))
         Me._direcciones.Columns.Add("IdLocalidad", System.Type.GetType("System.Int32"))
         Me._direcciones.Columns.Add("NombreLocalidad", System.Type.GetType("System.String"))
         Me._direcciones.Columns.Add("NombreProvincia", System.Type.GetType("System.String"))
         Me._direcciones.Columns.Add("IdTipoDireccion", System.Type.GetType("System.Int32"))
         Me._direcciones.Columns.Add("NombreAbrevTipoDireccion", System.Type.GetType("System.String"))
         Me._direcciones.Columns.Add("Telefono", System.Type.GetType("System.String"))
         Me._direcciones.Columns.Add("Celular", System.Type.GetType("System.String"))
         Me._direcciones.Columns.Add("CorreoElectronico", System.Type.GetType("System.String"))
      End If

   End Sub

   Public Sub RefrescarDirecciones()
      Me.txtDirecciones.Text = ""
      Me.bscCodigoLocalidadDir.Text = ""
      Me.bscNombreLocalidadDir.Text = ""
      Me.txtProvinciaLocalidadDir.Text = ""
      Me.txtCelularDir.Text = ""
      Me.txtTelefonoDir.Text = ""
      Me.txtCorreoDir.Text = ""
      Me.cmbTiposDirecciones.SelectedIndex = 0
      Me.txtDirecciones.Focus()
   End Sub

   Private Sub CargarMapa()

      Me.gmcMapa.Overlays.Clear()

      Dim direccion As String
      Dim nombre As String
      Dim gp As GMap.NET.GeocodingProvider = MapProviders.GMapProviders.OpenStreetMap
      Dim pt As PointLatLng
      Dim ov As GMapOverlay = New GMapOverlay("direcciones")
      Dim i As Integer = 0
      Dim provincia As String
      provincia = New Reglas.Localidades().GetUna(Integer.Parse(Me.bscCodigoLocalidad.Text.ToString())).NombreProvincia

      direccion = Me.txtDireccion.Text.ToString() + "," + Me.bscCodigoLocalidad.Text.ToString() + "," + provincia + ",Argentina"
      nombre = Me.txtNombre.Text.ToString()

      Try
         pt = gp.GetPoint(direccion, GeoCoderStatusCode.G_GEO_UNKNOWN_ADDRESS)

      Catch ex As Exception
         Me.bscNombreLocalidad.Focus()
         MessageBox.Show("No se encontro la Dirección en el Mapa.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End Try


      If Not pt.IsEmpty Then
         If Me.txtGeoLocalizacionLat.Text = "0" Then
            ov.Markers.Add(Me.GetMarca(pt.Lat, pt.Lng, Me.txtDireccion.Text.ToString(), nombre))
            Me.gmcMapa.Overlays.Add(ov)

            Me.gmcMapa.SetZoomToFitRect(Me.gmcMapa.GetRectOfAllMarkers("direcciones"))


            Me.txtGeoLocalizacionLat.Text = pt.Lat.ToString()
            Me.txtGeoLocalizacionLng.Text = pt.Lng.ToString()
         Else
            ov.Markers.Add(Me.GetMarca(Double.Parse(Me.txtGeoLocalizacionLat.Text.ToString()), Double.Parse(Me.txtGeoLocalizacionLng.Text.ToString()), Me.txtDireccion.Text.ToString(), nombre))
            Me.gmcMapa.Overlays.Add(ov)

            Me.gmcMapa.SetZoomToFitRect(Me.gmcMapa.GetRectOfAllMarkers("direcciones"))
         End If
      End If

      Me.gmcMapa.Zoom = 13

   End Sub

   Private Sub Ubicacion()

      Me.gmcMapa.Overlays.Clear()

      Dim nombre As String
      Dim ov As GMapOverlay = New GMapOverlay("direcciones")
      Dim i As Integer = 0
      nombre = Me.txtNombre.Text.ToString()
      If Not String.IsNullOrEmpty(Me.txtGeoLocalizacionLat.Text.ToString()) Then
         ov.Markers.Add(Me.GetMarca(Double.Parse(Me.txtGeoLocalizacionLat.Text.ToString()), Double.Parse(Me.txtGeoLocalizacionLng.Text.ToString()), Me.txtDireccion.Text.ToString(), nombre))
         Me.gmcMapa.Overlays.Add(ov)

         Me.gmcMapa.SetZoomToFitRect(Me.gmcMapa.GetRectOfAllMarkers("direcciones"))

         Me.gmcMapa.Zoom = 13

      End If

   End Sub

   Private Function GetMarca(ByVal latitud As Double, ByVal longitud As Double, ByVal direccion As String, ByVal nombre As String) As GMarkerGoogle
      Dim marker As GMarkerGoogle = New GMarkerGoogle(New PointLatLng(latitud, longitud), GMarkerGoogleType.green)
      marker.ToolTip = New GMap.NET.WindowsForms.GMapToolTip(marker)
      marker.ToolTipText = nombre + "-" + direccion
      Return marker
   End Function

   Private Sub LimpiarCampos()
      Me.txtDirecciones.Text = ""
      Me.bscCodigoLocalidadDir.Text = ""
      Me.bscNombreLocalidadDir.Text = ""
      Me.txtProvinciaLocalidadDir.Text = ""
      Me.cmbTiposDirecciones.SelectedIndex = 0
   End Sub

   Private Sub CargarLineaCompleta(ByVal dr As DataGridViewRow)
      Me.txtDirecciones.Text = dr.Cells("IdDireccion").Value.ToString()
      Me.bscCodigoLocalidadDir.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.bscCodigoLocalidadDir.PresionarBoton()
      Dim tipDir As Entidades.TipoDireccion = New Reglas.TiposDirecciones().GetUna(Integer.Parse(dr.Cells("IdTipoDireccion").Value.ToString()))
      Me.cmbTiposDirecciones.Text = tipDir.NombreTipoDireccion
      Me.txtCelularDir.Text = dr.Cells("Celular").Value.ToString()
      Me.txtTelefonoDir.Text = dr.Cells("Telefono").Value.ToString()
      Me.txtCorreoDir.Text = dr.Cells("CorreoElectronico").Value.ToString()

   End Sub

   Private Sub EliminarLinea()
      Me._direcciones.Rows.RemoveAt(Me.dgvDirecciones.SelectedRows(0).Index)
      Me.dgvDirecciones.DataSource = Me._direcciones

   End Sub
#End Region

End Class
