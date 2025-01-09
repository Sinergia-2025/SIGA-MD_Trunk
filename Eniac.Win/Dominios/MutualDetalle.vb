Option Strict Off
Imports System.Drawing
Imports System.Net
Imports System.Threading.Tasks
Imports System.Threading
Imports System
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
Imports actual = Eniac.Entidades.Usuario.Actual


Public Class MutualDetalle

#Region "Campos"

   Private _estaCargando As Boolean = True
   Private tt, tt2, tObs, tObs2 As New System.Windows.Forms.ToolTip()
   Private _Teleprom As Thread
   Private _URL As String
   Private _publicos As Publicos
   Private _contactos As DataTable
   Private _contactosBorrados As DataTable
   Private _contactoEditado As DataRow
#End Region
   Protected Property ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.ClienteDeuda)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Enumeradores"

   Private Enum Estado
      Insertar
      Modificar
      Eliminar
      ActivarDesactivar
   End Enum

   ' Private _sortColumn As New Publicos.sortColumnClass

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos = New Publicos()

         Dim oLoca As Eniac.Reglas.Localidades = New Eniac.Reglas.Localidades()
         Dim dt As DataTable = oLoca.GetAll()


         Dim p As New Eniac.Win.Publicos
         'p.CargarComboTipoTelefono(cmbTipoTelefonoTenedor)
         'p.CargarComboTipoTelefono(cmbTipoTelefonoTenedor2)
         p.CargaComboTiposContactos(Me.cmbTipoContacto)
         p.CargaComboCategorias(Me.cmbCategorias)

         '    Dim oReg As Eniac.Dominios.Reglas.EstadosRegistros = New Eniac.Dominios.Reglas.EstadosRegistros()
         Me._liSources.Add("Cliente", DirectCast(Me._entidad, Entidades.ClienteDeuda).Cliente)
         Me._liSources.Add("Localidad", DirectCast(Me._entidad, Entidades.ClienteDeuda).Cliente.Localidad)

         Me.BindearControles(Me._entidad, Me._liSources)

         If Me.StateForm = Eniac.Win.StateForm.Actualizar Then

            Me.bscCodigoLocalidad.PresionarBoton()

            Me.TotalDeuda()
            Me.CargarDeudas()
            Me.CargarColumnasASumar()
            Me.CargarAlertas()
            Me.CargarGestiones()
            Me.CargarContactos()
            Me.CargarCuentaCorriente()
         End If

         Me.btnNotificaciones.Enabled = (Me.ugDetalle.Rows.Count > 0)

         Me.lblPromesaDePagoActiva.Visible = Me.HayPromesasDePagosPendientes()
         If Me.lblPromesaDePagoActiva.Visible Then Me.lblPromesaDePagoActiva.Text = Me.TipoDePromesaActiva()

         Me._estaCargando = False

         tt.SetToolTip(txtTelefonoContacto, txtTelefonoContacto.Text)
         tObs.SetToolTip(txtObservacionContacto, txtObservacionContacto.Text)

         tt.IsBalloon = True
         tObs.IsBalloon = True

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ClientesDeudas()
   End Function

   Protected Overrides Sub Aceptar()
      If Me.StateForm = Eniac.Win.StateForm.Actualizar Then
         DirectCast(Me._entidad, Entidades.ClienteDeuda).Cliente.Contactos = Me._contactos
         DirectCast(Me._entidad, Entidades.ClienteDeuda).Cliente.ContactosBorrados = Me._contactosBorrados

      End If


      MyBase.Aceptar()

      If Not Me.HayError Then Me.Close()
      Me.txtCodigoCliente.Focus()

   End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      Me.Close()
   End Sub

   Private Sub dgvPlanPagos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
      'Try
      '   Dim Inmobiliario As Long = Long.Parse(Me.dgvPlanPagos.SelectedCells(0).OwningRow.Cells("Cuenta").Value.ToString())
      '   Dim TipoImpuesto As Integer = Integer.Parse(Me.dgvPlanPagos.SelectedCells(0).OwningRow.Cells("IdTipoImpuesto").Value.ToString())
      '   Dim IdMunicipio As Integer = Integer.Parse(Me.dgvPlanPagos.SelectedCells(0).OwningRow.Cells("IdMunicipio3").Value.ToString())
      '   Dim periodo As String = Me.dgvPlanPagos.SelectedCells(0).OwningRow.Cells("ppPeriodo").Value.ToString()

      '   Dim pago As Entidades.InmobiliarioDeuda = New Reglas.InmobiliarioDeuda().GetUno(Inmobiliario, TipoImpuesto, IdMunicipio, periodo)

      '   Dim frmDP As PlanDeCuentasInmobiliarioDetalle = New PlanDeCuentasInmobiliarioDetalle(pago)
      '   frmDP.StateForm = Eniac.Win.StateForm.Actualizar
      '   frmDP.ShowDialog()

      '   DirectCast(Me._entidad, Entidades.Inmobiliario).Deudas = New Reglas.InmobiliarioDeuda().GetDeUnDato(DirectCast(Me._entidad, Entidades.Inmobiliario).Partida,
      '                                                                                      DirectCast(Me._entidad, Entidades.Inmobiliario).IdTipoImpuesto,
      '                                                                                      DirectCast(Me._entidad, Entidades.Inmobiliario).IdMunicipio)
      '   Me.dgvPlanPagos.DataSource = DirectCast(Me._entidad, Entidades.Inmobiliario).Deudas

      '   Me.TotalDeuda()

      '   'Me.lblPromesaDePagoActiva.Visible = Me.HayPromesasDePagosPendientes()
      '   'If Me.lblPromesaDePagoActiva.Visible Then Me.lblPromesaDePagoActiva.Text = Me.TipoDePromesaActiva()
      'Catch ex As Exception
      '   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      'End Try
   End Sub

   Private Sub btnInsertarGestion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertarGestion.Click
      Try
         Dim gesti As Reglas.CRMNovedades = New Reglas.CRMNovedades()
         Dim ges As Entidades.CRMNovedad = New Entidades.CRMNovedad()
         ges.Usuario = Eniac.Entidades.Usuario.Actual.Nombre
         ges.IdCliente = DirectCast(Me._entidad, Entidades.ClienteDeuda).Cliente.IdCliente
         ges.TipoNovedad = New Reglas.CRMTiposNovedades().GetUno("GESTIONES")
         ges.Letra = "X"
         ges.CentroEmisor = 1
         Dim frmGes As GestionesMutualDetalles = New GestionesMutualDetalles(ges, ges.TipoNovedad)
         frmGes.StateForm = Eniac.Win.StateForm.Insertar
         frmGes.ShowDialog()

         Me.CargarGestiones()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnBorrarGestion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrarGestion.Click
      Try
         If Me.dgvGestiones.SelectedCells.Count > 0 Then

            If MessageBox.Show("Desea eliminar la gestion?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

               Dim ges As Entidades.CRMNovedad = (New Reglas.CRMNovedades).GetUno("GESTIONES", "X", 1, Long.Parse(Me.dgvGestiones.CurrentRow.Cells("IdNovedad").Value.ToString)) 'DirectCast(Me.dgvGestiones.SelectedCells(0).OwningRow.DataBoundItem, Entidades.Gestion)
               Dim gesti As Reglas.CRMNovedades = New Reglas.CRMNovedades()
               gesti.Borrar(ges)
               MessageBox.Show("La gestion ha sido eliminada exitosamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

               Me.CargarGestiones()

            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnInsertarAlerta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertarAlerta.Click
      Try
         Me.AlertasAdministrar(Estado.Insertar)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnBorrarAlerta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrarAlerta.Click
      Try
         If Me.dgvAlertas.SelectedCells.Count > 0 Then
            Me.AlertasAdministrar(Estado.Eliminar)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvAlertas_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAlertas.CellDoubleClick
      Try
         If Me.dgvAlertas.SelectedCells.Count > 0 Then
            Me.AlertasAdministrar(Estado.Modificar)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnNotificaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotificaciones.Click
      Try
         Dim reg As Reglas.ClientesDeudas = New Reglas.ClientesDeudas()
         'If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         '   reg.Insertar(Me._entidad)
         'Else
         '  reg.Actualizar(Me._entidad)
         'End If

         Me._entidad = New Reglas.ClientesDeudas().GetUno(DirectCast(Me._entidad, Entidades.ClienteDeuda).Cliente.IdCliente,
                                                   DirectCast(Me._entidad, Entidades.ClienteDeuda).nro_prestamo)
         Me.RefrescarPGA()

         Dim frm As NotificacionesMutual = New NotificacionesMutual(DirectCast(Me._entidad, Entidades.ClienteDeuda))
         frm.ShowDialog()

         Me.RefrescarPGA()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnActDesact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActDesact.Click
      Try
         If Me.dgvAlertas.SelectedCells.Count > 0 Then
            Me.AlertasAdministrar(Estado.ActivarDesactivar)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click

      Dim oAcuerdo As New Entidades.CuentaCorriente
      oAcuerdo.Cliente = DirectCast(Me._entidad, Entidades.ClienteDeuda).Cliente
      Dim AcuerdosDePago As New AcuerdosDePagosDetalle(oAcuerdo)
      AcuerdosDePago.ShowDialog()
      Me.RefrescarPGA()
   End Sub

   Private Sub tsbMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbMail.Click
      Dim carta As Entidades.Carta = (New Reglas.Cartas).GetUno(83)
      If carta.Texto2RTF Is Nothing Then
         MessageBox.Show("Debe ingresar Texto2 en la carta nro: 83", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If
      Dim eMail As New EnvioDeCorreo(DirectCast(Me._entidad, Entidades.ClienteDeuda).Cliente.IdCliente, DirectCast(Me._entidad, Entidades.ClienteDeuda).Cliente.CorreoElectronico,
                                     carta.Texto, carta.Texto2RTF & Chr(13) & Chr(10) & carta.Firma)
      eMail.ShowDialog()
      Me.RefrescarPGA()
   End Sub

   Private Sub dgvGestiones_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvGestiones.ColumnHeaderMouseClick
      'If dgvGestiones.Columns(e.ColumnIndex).Name = "gFechaRealizado" Then
      '   dgvGestiones.Sort(dgvGestiones.Columns(1), _sortColumn.gFechaRealizado.swap)
      'End If

      'dgvGestiones.Sort(dgvGestiones.Columns(dgvGestiones.CurrentCell.ToString), _sortColumn.alFechaAlerta.swap)
      'dgvGestiones.Columns(dgvGestiones.CurrentCell.ColumnIndex)
   End Sub

   Private Sub dgvGestiones_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGestiones.CellDoubleClick
      Try
         If Me.dgvGestiones.SelectedCells.Count > 0 Then
            Dim ges As Entidades.CRMNovedad = (New Reglas.CRMNovedades).GetUno("GESTIONES", "X", 1, Long.Parse(Me.dgvGestiones.CurrentRow.Cells("IdNovedad").Value.ToString))
            Dim frmGes As GestionesMutualDetalles = New GestionesMutualDetalles(ges, ges.TipoNovedad)
            frmGes.StateForm = Eniac.Win.StateForm.Actualizar
            frmGes.ShowDialog()

            Me.CargarGestiones()

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbOcultarAlertasPP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbOcultarAlertasPP.CheckedChanged
      If Me._estaCargando Then Exit Sub
      Me.CargarAlertas()
   End Sub

   Private Sub txtTelefono2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTelefonoContacto.TextChanged
      tt.RemoveAll()
      tt.SetToolTip(txtTelefonoContacto, txtTelefonoContacto.Text)
      tt.Show(txtTelefonoContacto.Text, Me)
   End Sub

   Private Sub lnkLocalidad_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkLocalidad.LinkClicked
      Try
         Dim PantLocalidad As LocalidadesDetalle = New LocalidadesDetalle(New Entidades.Localidad())
         PantLocalidad.StateForm = Win.StateForm.Insertar
         PantLocalidad.CierraAutomaticamente = True
         If PantLocalidad.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.bscCodigoLocalidad.Text = PantLocalidad.IdLocalidad
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
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugDetalle_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout

      e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow

      e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)

      e.Layout.Override.SpecialRowSeparatorHeight = 6

      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft

      e.Layout.ViewStyle = ViewStyle.SingleBand

      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

   End Sub

   Private Sub btnInsertarContacto_Click(sender As Object, e As EventArgs) Handles btnInsertarContacto.Click
      Try
         If Me.txtTelefonoContacto.Text <> "" Then
            If Me.cmbTipoContacto.SelectedIndex <> -1 Then

               Me.AgregarContacto()
               Me.RefrescarContactos()
            Else
               MessageBox.Show("No selecciono el tipo de Contacto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.cmbTipoContacto.Focus()
            End If
         Else
            MessageBox.Show("No ingreso el telefono del Contacto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtTelefonoContacto.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminarContacto_Click(sender As Object, e As EventArgs) Handles btnEliminarContacto.Click
      Try
         If Me.dgvContactos.SelectedRows.Count > 0 Then
            'solo controlo si esta en uso si es un Cliente, para un Prospecto no es necesario
            If ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente Then
               If Boolean.Parse(dgvContactos.SelectedRows(0).Cells("EnUso").Value.ToString()) Then
                  ShowMessage("El contacto que desea eliminar ya fue utilizado. No es posible eliminarlo. Podrá inactivar el mismo si así lo desea.")
                  Exit Sub
               End If
            End If
            If MessageBox.Show("Esta seguro de eliminar el Contacto seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaContacto(False)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvContactos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvContactos.CellDoubleClick
      Try
         If e.RowIndex > -1 Then
            'Limpia los textbox, y demas controles
            Me.RefrescarContactos()

            'Carga el Comprobante seleccionado de la grilla en los textbox 
            Me.CargarContactosCompleto(Me.dgvContactos.Rows(e.RowIndex))

            'Elimina el comprobantede la grilla
            Me.EliminarLineaContacto(True)

            Me.txtTelefonoContacto.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub controlesContactos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObservacionContacto.KeyDown, cmbTipoContacto.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub dgvContactos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvContactos.CellClick
      Try
         If e.RowIndex <> -1 And e.ColumnIndex = 0 Then
            Try
               Cursor = Cursors.WaitCursor
               If Me.dgvContactos.Rows(e.RowIndex).Cells("Telefono").Value.ToString() <> "" Then

                  _URL = Publicos.URLTeleprom & Me.dgvContactos.Rows(e.RowIndex).Cells("Telefono").Value.ToString()

                  _Teleprom = New Thread(New ThreadStart(AddressOf Me.ConectarTeleprom))
                  _Teleprom.Start()

               Else
                  MessageBox.Show("Ingrese un teléfono.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
               End If
            Catch ex As Exception
               Throw
            Finally
               Me.Cursor = Cursors.Default
            End Try
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try



   End Sub

   Private Sub tsbModificarReferencia_Click(sender As Object, e As EventArgs) Handles tsbModificarReferencia.Click
      Try
         Dim ctacte As Entidades.CuentaCorriente = New Entidades.CuentaCorriente()
         Dim octacte As Reglas.CuentasCorrientes
         For Each dr As UltraGridRow In ugDetalleCtaCte.Rows
            octacte = New Reglas.CuentasCorrientes()
            ctacte = octacte.GetUna(Integer.Parse(dr.Cells("IdSucursal").Value.ToString()), dr.Cells("IdTipoComprobante").Value.ToString(),
                                    dr.Cells("Letra").Value.ToString(), Integer.Parse(dr.Cells("CentroEmisor").Value.ToString()),
                                    Long.Parse(dr.Cells("NumeroComprobante").Value.ToString()))
            ctacte.Referencia = dr.Cells("Referencia").Value.ToString()

            octacte.ModificarCtaCte(ctacte)
         Next
         MessageBox.Show("La referencia se actualizó correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.CargarCuentaCorriente()
         Me.tsbModificarReferencia.Enabled = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugDetalleCtaCte_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles ugDetalleCtaCte.AfterCellUpdate
      If e.Cell.Column.Index = 30 Then
         Me.tsbModificarReferencia.Enabled = True
      End If
   End Sub

#End Region

#Region "Metodos"
   Private Sub RefrescarPGA()

      Me.CargarCuentaCorriente()
      Me.CargarGestiones()
      Me.CargarAlertas()

      Me.lblPromesaDePagoActiva.Visible = Me.HayPromesasDePagosPendientes()
      If Me.lblPromesaDePagoActiva.Visible Then Me.lblPromesaDePagoActiva.Text = Me.TipoDePromesaActiva()

   End Sub

   Private Sub CargarDeudas()
      Dim Deudas As List(Of Entidades.ClienteDeuda) = New List(Of Entidades.ClienteDeuda)
      Deudas = (New Reglas.ClientesDeudas).GetTotalDeuda(Long.Parse(DirectCast(Me._entidad, Entidades.ClienteDeuda).Cliente.IdCliente.ToString()))
      Me.ugDetalle.DataSource = Deudas

   End Sub

   Private Sub CargarAlertas()
      Me.dgvAlertas.DataSource = (New Reglas.CRMNovedades).GetGestionesAlertasXCliente("ALERTAS", Long.Parse(DirectCast(Me._entidad, Entidades.ClienteDeuda).Cliente.IdCliente.ToString()))
   End Sub

   Private Sub CargarGestiones()
      Me.dgvGestiones.DataSource = (New Reglas.CRMNovedades).GetGestionesAlertasXCliente("GESTIONES", Long.Parse(DirectCast(Me._entidad, Entidades.ClienteDeuda).Cliente.IdCliente.ToString()))
   End Sub

   Private Sub CargarCuentaCorriente()
      Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
      Dim oCtaCteDet As Reglas.CuentasCorrientesPagos = New Reglas.CuentasCorrientesPagos()

      Dim IdVendedor As Integer = 0

      Dim IdCliente As Long = 0
      Dim IdZonaGeografica As String = String.Empty
      Dim Desde As Date = Nothing
      Dim Hasta As Date = Nothing
      'Dim TipoComprobante As String = String.Empty
      Dim TipoSaldo As String = String.Empty
      Dim IdCategoria As Integer = 0
      Dim Grupo As String = String.Empty
      Dim ExcluirSaldosNegativos As String = "NO"
      Dim ExcluirAnticipos As String = "NO"
      Dim ExcluirPreComprobantes As String = "NO"
      Dim IdProvincia As String = String.Empty
      Dim TipoCategoria As String = String.Empty
      Dim TipoVendedor As String = String.Empty
      Dim ExcluirMinutas As String = "NO"

      Try

         IdCliente = Long.Parse(DirectCast(Me._entidad, Entidades.ClienteDeuda).Cliente.IdCliente.ToString())

         Dim tiposComprobantes As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)()

         Dim Comprobante As Entidades.TipoComprobante = New Reglas.TiposComprobantes().GetUno("MUTUAL")

         tiposComprobantes.AddRange({Comprobante})

         Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

         dtDetalle = oCtaCte.GetCtaCteMutual(actual.Sucursal.Id, _
                                                  Desde, Hasta, _
                                                  IdVendedor,
                                                  IdCliente, _
                                                  tiposComprobantes, _
                                                  TipoSaldo, _
                                                  IdZonaGeografica, _
                                                  IdCategoria, _
                                                  "TODOS", _
                                                  Grupo, _
                                                  ExcluirSaldosNegativos, _
                                                  ExcluirAnticipos, _
                                                  ExcluirPreComprobantes, _
                                                  IdProvincia, TipoCategoria, TipoVendedor, ExcluirMinutas, {actual.Sucursal})

         Dim com As CtasCtesClientesComunes = New CtasCtesClientesComunes()
         dt = com.GetDataTableParaClientesMutual(dtDetalle, TipoSaldo)

         Me.ugDetalleCtaCte.DataSource = dt


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub AlertasAdministrar(ByVal estado As Estado)
      Dim aler As Reglas.CRMNovedades = New Reglas.CRMNovedades()
      Dim ale As Entidades.CRMNovedad
      Select Case estado

         Case MutualDetalle.Estado.Insertar
            ale = New Entidades.CRMNovedad()
            ale.Usuario = Eniac.Entidades.Usuario.Actual.Nombre
            ale.IdCliente = DirectCast(Me._entidad, Entidades.ClienteDeuda).Cliente.IdCliente
            ale.TipoNovedad = New Reglas.CRMTiposNovedades().GetUno("ALERTAS")
            ale.Letra = "X"
            ale.CentroEmisor = 1
            Dim frmAle As AlertasMutualDetalle = New AlertasMutualDetalle(ale, ale.TipoNovedad)
            frmAle.StateForm = Eniac.Win.StateForm.Insertar
            frmAle.ShowDialog()

         Case MutualDetalle.Estado.Modificar
            ale = (New Reglas.CRMNovedades).GetUno("ALERTAS", "X", 1, Long.Parse(Me.dgvAlertas.CurrentRow.Cells("IdNovedad1").Value.ToString))
            Dim frmAle As AlertasMutualDetalle = New AlertasMutualDetalle(ale, ale.TipoNovedad)
            frmAle.StateForm = Eniac.Win.StateForm.Actualizar
            frmAle.ShowDialog()

         Case MutualDetalle.Estado.Eliminar
            If MessageBox.Show("Desea eliminar el alerta?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               ale = (New Reglas.CRMNovedades).GetUno("ALERTAS", "X", 1, Long.Parse(Me.dgvAlertas.CurrentRow.Cells("IdNovedad1").Value.ToString))
               aler.Borrar(ale)
               MessageBox.Show("El alerta ha sido eliminada exitosamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

         Case MutualDetalle.Estado.ActivarDesactivar
            ale = (New Reglas.CRMNovedades).GetUno("ALERTAS", "X", 1, Long.Parse(Me.dgvAlertas.CurrentRow.Cells("IdNovedad1").Value.ToString))

            'Lo doy vuelta.
            If ale.RevisionAdministrativa Then
               ale.RevisionAdministrativa = False
            Else

               If ale.FechaNovedad > Date.Now() Then
                  Dim resp As DialogResult = MessageBox.Show("La fecha de la Alerta aun no se ha cumplido. Esta seguro que desea desactivarla?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                  If resp = Windows.Forms.DialogResult.No Then
                     Exit Sub
                  End If
               End If

               ale.RevisionAdministrativa = True
            End If

            aler.Actualizar(ale)

      End Select

      Me.CargarAlertas()

   End Sub

   Private Sub CargarDgvAlertas_TipoNotificacion()
      For Each row As DataGridViewRow In dgvAlertas.Rows
         '  row.Cells("TipoNotificacion").Value = DirectCast(row.Cells("alTipoNotificacion").Value, Entidades.TipoNotificacion).IdTipoNotificacion.ToString
      Next
      dgvAlertas.Refresh()
   End Sub

   Private Function HayPromesasDePagosPendientes() As Boolean
      Dim ret As Boolean = True
      Dim CC As New Reglas.CuentasCorrientes()
      Dim ctacte As DataTable
      ctacte = CC.GetPorCliente({actual.Sucursal}, Long.Parse(DirectCast(Me._entidad, Entidades.ClienteDeuda).Cliente.IdCliente.ToString()), Nothing, Nothing, Nothing, "TODOS", "", "",
                                 Entidades.Moneda.Peso, Entidades.Moneda_TipoConversion.Comprobante, cotizDolar:=1, excluirPreComprobantes:=False)
      If Not ctacte.Rows.Count > 0 Then
         ret = False
      End If
      'Dim oPP As New Reglas.PromesasDePagosDetalles
      'Dim cuotas As Integer = oPP.cantidadCuotasPendientesPorDato(DirectCast(Me._entidad, Entidades.Dato).IdDato)
      'If Not (cuotas > 0) Then
      '   ret = False
      'End If
      Return ret
   End Function

   Private Function TipoDePromesaActiva() As String
      Dim ret As String = ""
      'Dim tipoPromesa As String = (New Reglas.PromesasDePagos).GetTipoPromesaActiva(DirectCast(Me._entidad, Entidades.Dato).IdDato)
      'ret = CStr(IIf(tipoPromesa = Entidades.PromesaDePago.TiposPromesas.Online, "Promesa de Pago - Online", "Promesa de Pago - Postal"))
      ret = "Acuerdo de Pago - ACTIVO "
      Return ret
   End Function

   Private Sub ConectarTeleprom()

      Dim myUri As New Uri(_URL)
      Dim request As WebRequest = WebRequest.CreateDefault(myUri)
      request.Method = "GET"
      Dim myWebResponse As WebResponse
      Try
         myWebResponse = request.GetResponse

      Catch exc As WebException
         myWebResponse = exc.Response
         If myWebResponse Is Nothing Then
            MessageBox.Show(CType(HttpStatusCode.NotFound, Integer) & "-No hay conexión con TELEPROM", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End If
      End Try

   End Sub

   Private Sub TotalDeuda()

      'Dim Deudas As DataTable = New DataTable()
      'Deudas = (New Reglas.InmobiliarioDeuda).GetTotalDeuda(Long.Parse(DirectCast(Me._entidad, Entidades.Inmobiliario).Partida.ToString()), _
      '                                                              Integer.Parse(DirectCast(Me._entidad, Entidades.Inmobiliario).IdTipoImpuesto.ToString()), _
      '                                                              Integer.Parse(DirectCast(Me._entidad, Entidades.Inmobiliario).IdMunicipio.ToString()))
      'Dim totalDeuda As Decimal = 0
      'For Each deuda As DataRow In Deudas.Rows

      '   totalDeuda += Decimal.Parse(deuda("Deuda").ToString())

      'Next
      'Me.txtTotalDeuda.Text = totalDeuda.ToString()

      ''Controla si la deuda es 0 desactiva las alertas
      'Dim rAler As Reglas.AlertasInmobiliario = New Reglas.AlertasInmobiliario()

      'If Deudas.Rows.Count = 0 Then

      '   rAler.GetDeUnaCuentaActivaDesactivar(Long.Parse(DirectCast(Me._entidad, Entidades.Inmobiliario).Partida.ToString()), _
      '                                                              Integer.Parse(DirectCast(Me._entidad, Entidades.Inmobiliario).IdTipoImpuesto.ToString()), _
      '                                                              Integer.Parse(DirectCast(Me._entidad, Entidades.Inmobiliario).IdMunicipio.ToString()))

      'End If

   End Sub

   Private Sub CargarLocalidad(ByVal dr As DataGridViewRow)
      DirectCast(Me._entidad, Entidades.ClienteDeuda).Cliente.Localidad = New Reglas.Localidades().GetUna(Integer.Parse(dr.Cells("IdLocalidad").Value.ToString()))
      Me.bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      Me.txtProvinciaLocalidad.Text = dr.Cells("NombreProvincia").Value.ToString()
   End Sub

   Private Sub CargarColumnasASumar()

      If Not Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Exists("deuda_exigible") Then

         Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
         Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

         Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("deuda_exigible")
         Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("deuda_exigible", SummaryType.Sum, columnToSummarize1)
         summary1.DisplayFormat = "{0:N2}"
         summary1.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("capital_total")
         Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("capital_total", SummaryType.Sum, columnToSummarize2)
         summary2.DisplayFormat = "{0:N2}"
         summary2.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize10 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("deuda_exigible_con_quita")
         Dim summary10 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("deuda_exigible_con_quita", SummaryType.Sum, columnToSummarize10)
         summary10.DisplayFormat = "{0:N2}"
         summary10.Appearance.TextHAlign = HAlign.Right

         Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"
      End If


   End Sub

   Private Sub AgregarContacto()

      Dim dr As DataRow
      If _contactoEditado IsNot Nothing Then
         dr = _contactoEditado
      Else
         dr = Me._contactos.NewRow()
         'solo voy a controlar si esta en uso si es un Cliente, para los prospectos no es necesario
         If ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente Then
            dr("EnUso") = False
         End If
      End If

      If ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Prospecto Then
         dr("IdProspecto") = DirectCast(Me._entidad, Entidades.Cliente).IdCliente
      Else
         dr("IdCliente") = DirectCast(Me._entidad, Entidades.ClienteDeuda).Cliente.IdCliente
      End If

      Dim tipoCont As Entidades.TipoContacto = New Reglas.TiposContactos().GetUna(Integer.Parse(Me.cmbTipoContacto.SelectedValue.ToString()))

      dr("IdTipoContacto") = tipoCont.IdTipoContacto
      dr("NombreTipoContacto") = tipoCont.NombreTipoContacto
      dr("Activo") = True
      dr("NombreContacto") = ""
      dr("Telefono") = Me.txtTelefonoContacto.Text
      dr("Celular") = ""
      dr("CorreoElectronico") = ""
      dr("Direccion") = ""
      dr("IdLocalidad") = 2000
      dr("NombreLocalidad") = "Rosario"
      dr("NombreProvincia") = "Santa Fe"
      dr("Observacion") = Me.txtObservacionContacto.Text
      dr("IdUsuario") = actual.Nombre

      Me._contactos.Rows.Add(dr)
      _contactoEditado = Nothing

      Me.dgvContactos.DataSource = Me._contactos

   End Sub

   Private Sub EliminarLineaContacto(paraEditar As Boolean)
      If dgvContactos.SelectedRows.Count > 0 AndAlso
         dgvContactos.SelectedRows(0).DataBoundItem IsNot Nothing AndAlso
         TypeOf (dgvContactos.SelectedRows(0).DataBoundItem) Is DataRowView AndAlso
         DirectCast(dgvContactos.SelectedRows(0).DataBoundItem, DataRowView).Row IsNot Nothing Then

         Dim index As Integer = dgvContactos.SelectedRows(0).Index

         If paraEditar Then
            _contactoEditado = _contactos.NewRow()
            _contactoEditado.ItemArray = DirectCast(dgvContactos.SelectedRows(0).DataBoundItem, DataRowView).Row.ItemArray
         Else
            Dim drParaBorrar As DataRow = _contactosBorrados.NewRow()
            drParaBorrar.ItemArray = DirectCast(dgvContactos.SelectedRows(0).DataBoundItem, DataRowView).Row.ItemArray
            _contactosBorrados.Rows.Add(drParaBorrar)
         End If
         Me._contactos.Rows.Remove(DirectCast(dgvContactos.SelectedRows(0).DataBoundItem, DataRowView).Row)
         Me.dgvContactos.DataSource = Me._contactos

         If Me.dgvContactos.Rows.Count > 0 Then
            If index > dgvContactos.Rows.Count - 1 Then
               index = dgvContactos.Rows.Count - 1
            End If

            Me.dgvContactos.Rows(index).Selected = True
            Me.dgvContactos.FirstDisplayedScrollingRowIndex = index
         End If
         '_contactos.AcceptChanges()
      End If
   End Sub

   Public Sub CargarContactos()

      Dim IdCliente As Long = 0

      IdCliente = DirectCast(Me._entidad, Entidades.ClienteDeuda).Cliente.IdCliente

      Dim reg As Reglas.ClientesContactos

      reg = New Reglas.ClientesContactos(ModoClienteProspecto)

      Me.ChequeaEstructuraContactos()

      Me._contactos = reg.GetClientesContactos(IdCliente)
      _contactosBorrados = _contactos.Clone()

      Me.dgvContactos.DataSource = Me._contactos
   End Sub

   Private Sub ChequeaEstructuraContactos()
      If Me._contactos Is Nothing Then
         Me._contactos = New DataTable()
         If ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Prospecto Then
            Me._contactos.Columns.Add("IdProspecto", System.Type.GetType("System.String"))
         Else
            Me._contactos.Columns.Add("IdCliente", System.Type.GetType("System.String"))
         End If
         Me._contactos.Columns.Add("IdTipoContacto", System.Type.GetType("System.Int32"))
         Me._contactos.Columns.Add("NombreTipoContacto", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("IdContacto", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("NombreContacto", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("Telefono", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("Celular", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("Observacion", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("CorreoElectronico", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("Direccion", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("IdLocalidad", System.Type.GetType("System.Int32"))
         Me._contactos.Columns.Add("NombreLocalidad", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("NombreProvincia", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("Activo", System.Type.GetType("System.Boolean"))
         Me._contactos.Columns.Add("IdUsuario", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("EnUso", System.Type.GetType("System.Boolean"))
         _contactosBorrados = _contactos.Clone()
      End If

   End Sub

   Private Sub EliminarLineaC()
      Me._contactos.Rows.RemoveAt(Me.dgvContactos.SelectedRows(0).Index)
      Me.dgvContactos.DataSource = Me._contactos
   End Sub

   Public Sub RefrescarContactos()
      If _contactoEditado IsNot Nothing Then
         _contactos.Rows.Add(_contactoEditado)
         _contactoEditado = Nothing
      End If
      '     Me.txtNombreContacto.Text = ""
      If Me.cmbTipoContacto.Items.Count = 1 Then
         Me.cmbTipoContacto.SelectedIndex = 0
      End If
      '   Me.txtDireccionContacto.Text = ""
      '    SetLocalidadContactoDefault()
      '     Me.txtProvinciaContacto.Text = ""
      Me.txtTelefonoContacto.Text = ""
      '    Me.txtCelularContacto.Text = ""
      '   Me.txtMailContacto.Text = ""
      Me.txtObservacionContacto.Text = ""
      Me.txtTelefonoContacto.Focus()
   End Sub

   Private Sub CargarContactosCompleto(ByVal dr As DataGridViewRow)

      'Me.txtNombreContacto.Text = dr.Cells("NombreContacto").Value.ToString()
      Me.cmbTipoContacto.SelectedValue = dr.Cells("IdTipoContacto").Value.ToString()
      '  Me.txtDireccionContacto.Text = dr.Cells("Direccion").Value.ToString()
      '   Me.bscCodigoLocalidadContacto.Text = Integer.Parse(dr.Cells("IdLocalidad1").Value.ToString())
      '  Me.bscCodigoLocalidadContacto.Selecciono = True
      '   Me.bscNombreLocalidadContacto.Text = dr.Cells("NombreLocalidad1").Value.ToString()
      '   Me.txtProvinciaContacto.Text = dr.Cells("NombreProvincia1").Value.ToString()
      Me.txtTelefonoContacto.Text = dr.Cells("Telefono").Value.ToString()
      '    Me.txtCelularContacto.Text = dr.Cells("Celular").Value.ToString()
      '    Me.txtMailContacto.Text = dr.Cells("CorreoElectronico").Value.ToString()
      Me.txtObservacionContacto.Text = dr.Cells("Observacion").Value.ToString()
      '     Me.chbActivoContacto.Checked = Boolean.Parse(dr.Cells("Activo").Value.ToString())

   End Sub

#End Region

  End Class