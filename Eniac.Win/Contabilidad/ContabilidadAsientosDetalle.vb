Public Class ContabilidadAsientosDetalle

#Region "Campos"

   Private _publicosContabilidad As ContabilidadPublicos
   Private _publicos As Publicos
   Private dtGrilla As DataTable
   Private _subSistema As String

   Private _utilizaCentroCostos As Boolean = False
   Private _permiteCambiarCentroCostos As Boolean = False

   Private _tit As Dictionary(Of String, String)

#End Region

#Region "Propiedades"
   Public ReadOnly Property Asiento As Entidades.ContabilidadAsiento
      Get
         Return DirectCast(_entidad, Entidades.ContabilidadAsiento)
      End Get
   End Property
#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.ContabilidadAsiento)
      Me.New()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            _publicosContabilidad = New ContabilidadPublicos()
            _publicos = New Publicos()

            _publicosContabilidad.CargaComboPlanes(cmbPlan, traerTodos:=False)
            _publicosContabilidad.CargaComboEstadosAsientos(cmbEstadoAsiento)

            _subSistema = Asiento.SubsiAsiento
            _publicos.CargaComboDesdeEnum(cmbSubsistema, GetType(Entidades.ContabilidadProceso.Procesos), , True)

            _publicos.CargaComboCentroCostos(cmbCentroCosto)

            _publicosContabilidad.CargaComboTiposAsiento(cmbTipo)

            BindearControles(_entidad)

            _tit = GetColumnasVisiblesGrilla(grdAsientosDetalle)

            InicializarGrilla()

            If Me.StateForm = Eniac.Win.StateForm.Insertar Then
               CargarValoresIniciales()
            Else
               getTotalesGrilla()
               lblNro.Text = "Número"
            End If

            _utilizaCentroCostos = Reglas.Publicos.TieneModuloContabilidad AndAlso Reglas.ContabilidadPublicos.UtilizaCentroCostos
            _permiteCambiarCentroCostos = _utilizaCentroCostos ''AndAlso Reglas.ContabilidadPublicos.PermiteCambiarCentroCostosVentas

            cmbCentroCosto.Visible = _utilizaCentroCostos
            cmbCentroCosto.LabelAsoc.Visible = _utilizaCentroCostos
            grdAsientosDetalle.Columns(NombreCentroCosto.Name).Visible = _utilizaCentroCostos

            ''Me.Text = "Nuevo Asiento - Sucursal: " & Eniac.Entidades.Usuario.Actual.Sucursal.Id.ToString & "-" & Eniac.Entidades.Usuario.Actual.Sucursal.Nombre

            If Asiento.EsManual Then
               lblManual.Text = "Manual"
            Else
               lblManual.Text = "Gestión"
            End If

            txtConcepto.Select()

            cmbSubsistema.SelectedValue = _subSistema
            btnAceptar.Visible = Asiento.FechaExportacion = New Date()
            lblFechaExportacion.Visible = Asiento.FechaExportacion <> New Date()
            lblFechaExportacion.Text = String.Format(lblFechaExportacion.Text, Asiento.FechaExportacion)

         End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ContabilidadAsientos()
   End Function

   Protected Overrides Sub Aceptar()

      Dim fechaAnterior As Date = dtpFecha.Value

      Try
         If VerificarDetalle() And VerificarEjercicioVigente(Me.dtpFecha.Value) And verfificarBalanceo() Then

            Asiento.DetallesAsiento = DirectCast(Me.grdAsientosDetalle.DataSource, DataTable)

            Asiento.IdSucursal = actual.Sucursal.Id

            If String.IsNullOrWhiteSpace(Asiento.SubsiAsiento) Then
               Asiento.SubsiAsiento = Entidades.ContabilidadProceso.Procesos.MANUALES.ToString()
            End If

            If StateForm = Win.StateForm.Insertar Then
               Asiento.IdAsiento = 0
            End If

            If Asiento.IdEjercicio = 0 Then
               Asiento.IdEjercicio = Asiento.IdEjercicioNuevo
            End If

            MyBase.Aceptar()

            If Me.HayError Then Exit Sub

            If Me.StateForm = Eniac.Win.StateForm.Insertar Then

               Me.CargarValoresIniciales()
               DirectCast(Me.grdAsientosDetalle.DataSource, DataTable).Rows.Clear()

            End If

            Me.dtpFecha.Value = fechaAnterior

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub getTotalesGrilla()
      Dim totalDebe As Decimal = 0
      Dim totalHaber As Decimal = 0

      For Each dr As DataRow In dtGrilla.Rows
         If Not IsDBNull(dr("debe")) Then totalDebe += CDec(dr("debe"))
         If Not IsDBNull(dr("haber")) Then totalHaber += CDec(dr("haber"))
      Next

      txtTotalDebe.Text = totalDebe.ToString("N2")
      txtTotalHaber.Text = totalHaber.ToString("N2")
      txtDiferencia.Text = (totalDebe - totalHaber).ToString("N2")

   End Sub

   Private Function ValidacionesCuenta(sender As Control) As Boolean
      If Not (Me.bscCodCuenta.Selecciono Or Me.bscDescripcion.Selecciono) Then
         MessageBox.Show("Debe seleccionar una cuenta.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodCuenta.Select()
         Return False
      End If

      If Me.bscDescripcion.Text = String.Empty Then
         MessageBox.Show("La descripción de la cuenta está incompleta", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscDescripcion.Select()
         Return False
      End If

      Dim debe As Decimal = 0
      Dim haber As Decimal = 0
      If IsNumeric(Me.txtDebe.Text) Then debe = CDec(Me.txtDebe.Text)
      If IsNumeric(Me.txtHaber.Text) Then haber = CDec(Me.txtHaber.Text)

      If (debe = 0) And (haber = 0) Then
         MessageBox.Show("Ingrese DEBE O HABER de la cuenta para continuar", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         If Not sender.Equals(txtHaber) Then
            Me.txtDebe.Select()
         End If
         Return False
      End If
      If (debe <> 0) And (haber <> 0) Then
         MessageBox.Show("Sólo debe ingresar DEBE O HABER de la cuenta para continuar", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         If Not sender.Equals(txtHaber) Then
            Me.txtDebe.Select()
         End If
         Return False
      End If

      Return True
   End Function

   Private Sub AgregarFila()

      Dim fila As DataRow

      fila = dtGrilla.NewRow
      fila("Cuenta") = Me.bscCodCuenta.Text.Trim & " - " & Me.bscDescripcion.Text.Trim
      If IsNumeric(Me.txtDebe.Text) AndAlso CDec(Me.txtDebe.Text) <> 0 Then
         fila("debe") = Me.txtDebe.Text
      End If
      If IsNumeric(Me.txtHaber.Text) AndAlso CDec(Me.txtHaber.Text) <> 0 Then
         fila("haber") = Me.txtHaber.Text
      End If
      fila("idAsiento") = Me.txtNumeroAsiento.Text
      fila("idRenglon") = 0
      fila("IdCuenta") = Me.bscCodCuenta.Text

      If _utilizaCentroCostos Then
         If cmbCentroCosto.SelectedValue IsNot Nothing Then
            fila("IdCentroCosto") = cmbCentroCosto.SelectedValue
            fila("NombreCentroCosto") = cmbCentroCosto.Text
         End If
      End If

      dtGrilla.Rows.Add(fila)
      Me.grdAsientosDetalle.DataSource = dtGrilla

      getTotalesGrilla()

   End Sub

   Private Function crearTablaGrilla() As DataTable
      Dim datosGrillas As New DataTable

      datosGrillas.Columns.Add("Cuenta", GetType(String)) 'Cuentas.CodCuenta
      datosGrillas.Columns.Add("debe", GetType(Decimal))
      datosGrillas.Columns.Add("haber", GetType(Decimal))
      datosGrillas.Columns.Add("idAsiento", GetType(Integer))
      datosGrillas.Columns.Add("idRenglon", GetType(Integer))
      datosGrillas.Columns.Add("IdCuenta", GetType(Integer))
      datosGrillas.Columns.Add("IdTipoReferencia", GetType(String))
      datosGrillas.Columns.Add("Referencia", GetType(String))
      datosGrillas.Columns.Add("IdCentroCosto", GetType(Integer))
      datosGrillas.Columns.Add("NombreCentroCosto", GetType(String))

      Return datosGrillas

   End Function

   Private Sub InicializarGrilla()
      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         dtGrilla = crearTablaGrilla()

      ElseIf Me.StateForm = Eniac.Win.StateForm.Actualizar Then
         dtGrilla = Asiento.DetallesAsiento

      End If

      grdAsientosDetalle.DataSource = dtGrilla

      AjustarColumnasGrilla(grdAsientosDetalle, _tit)


      grdAsientosDetalle.Columns("debe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
      grdAsientosDetalle.Columns("haber").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
      grdAsientosDetalle.Columns("debe").HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
      grdAsientosDetalle.Columns("haber").HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
      grdAsientosDetalle.Columns(Entidades.ContabilidadAsiento.Columnas.IdAsiento.ToString()).Visible = False
      grdAsientosDetalle.Columns("idRenglon").Visible = False
      grdAsientosDetalle.Columns(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).Visible = False

      'Me.grdAsientosDetalle.Columns("debe").DefaultCellStyle.Format = "###.###,##"
      'Me.grdAsientosDetalle.Columns("haber").DefaultCellStyle.Format = "###.###,##"

   End Sub

   Private Sub CargarValoresIniciales()
      txtDebe.Text = "0.00"
      txtHaber.Text = "0.00"
      txtConcepto.Select()
      txtTotalDebe.Text = "0.00"
      txtTotalHaber.Text = "0.00"
      dtpFecha.Value = Date.Now
      cmbSubsistema.SelectedValue = _subSistema
      cmbTipo.SelectedValue = "NORMAL"
      CargarProximoNumero()
      'cmbMarcaVehiculo.SelectedIndex = -1
   End Sub

   Private Sub CargarProximoNumero()
      If Me.cmbPlan.SelectedIndex = -1 Then Exit Sub
      If Me.StateForm = Eniac.Win.StateForm.Actualizar Then Exit Sub

      Dim oAsientos As Reglas.ContabilidadAsientos = New Reglas.ContabilidadAsientos()
      Dim idEjercicioVigente As Integer = New Reglas.ContabilidadEjercicios().GetEjercicioVigente(dtpFecha.Value)

      Dim proximoIdAsiento As Integer = oAsientos.GetIdMaximo(idEjercicioVigente, Integer.Parse(Me.cmbPlan.SelectedValue.ToString())) + 1
      Me.txtNumeroAsiento.Text = proximoIdAsiento.ToString()
   End Sub

   Private Function VerificarDetalle() As Boolean

      If Me.StateForm = Eniac.Win.StateForm.Actualizar Then
         If Me.grdAsientosDetalle.Rows.Count = 0 Then
            MessageBox.Show("No pueden quitar todas las cuentas del Asiento. Elimine el asiento completo desde la pantalla de búsqueda", "Asiento", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.btnCancelar.Select()
            Return False
         End If

      Else
         If Me.grdAsientosDetalle.Rows.Count = 0 Then
            MessageBox.Show("Debe Ingresar al menos dos Cuentas para el Asiento", "Asiento", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodCuenta.Select()
            Return False
         End If

      End If

      Return True

   End Function

   Private Function verfificarBalanceo() As Boolean

      If Me.txtTotalDebe.Text <> Me.txtTotalHaber.Text Then
         MessageBox.Show("Verificar Balanceo, la suma del Debe y el Haber debe ser cero", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtTotalDebe.Select()
         Return False
      End If

      If Me.txtTotalDebe.Text = "0.00" And Me.txtTotalHaber.Text = "0.00" Then
         MessageBox.Show("Verificar Balanceo, la suma del Debe y el Haber debe ser cero", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtTotalDebe.Select()
         Return False
      End If


      Return True
   End Function

   Private Function VerificarEjercicioVigente(fechaAsiento As Date) As Boolean
      Dim rEjercicio = New Reglas.ContabilidadEjercicios()
      Dim idEjeVigente = rEjercicio.GetEjercicioVigente(fechaAsiento)

      If idEjeVigente = 0 Then
         ShowMessage("La Fecha ingresada para el Asiento no pertenece al Ejercicio Vigente o el Período está Cerrado")
         dtpFecha.Select()
         Return False
      End If

      Asiento.IdEjercicioNuevo = idEjeVigente

      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub cmbPlan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPlan.SelectedIndexChanged
      '-- REQ-30989 --
      TryCatched(
         Sub()
            bscCodCuenta.Text = ""
            bscDescripcion.Text = ""

            bscModelo.Text = "" ''''

            txtDebe.Text = "0.00"
            txtHaber.Text = "0.00"

            If grdAsientosDetalle.Rows.Count > 0 Then
               DirectCast(grdAsientosDetalle.DataSource, DataTable).Rows.Clear()
            End If

            txtTotalDebe.Text = "0.00"
            txtTotalHaber.Text = "0.00"

            CargarProximoNumero()
         End Sub)
   End Sub

   Private Sub cmdPlan_Click(sender As Object, e As EventArgs) Handles cmdPlan.Click
      TryCatched(
         Sub()
            Using frmplan = New ContabilidadPlanesCuentasPreView()
               'frmplan.IdPlanCuenta = CInt(cmbPlan.SelectedValue)

               If frmplan.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso frmplan.Cuenta IsNot Nothing Then
                  If Not frmplan.Cuenta.EsImputable Then
                     MessageBox.Show(String.Format("La cuenta {0} - {1} no es imputable. No puede usarse para imputar un asiento. Por favor reintente.",
                                                   frmplan.Cuenta.IdCuenta, frmplan.Cuenta.NombreCuenta))
                     Exit Sub
                  End If

                  bscCodCuenta.Text = frmplan.Cuenta.IdCuenta.ToString()
                  bscCodCuenta.PresionarBoton()
                  txtDebe.Select()
               End If
            End Using
         End Sub)
   End Sub

   Private Sub grdAsientosDetalle_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAsientosDetalle.CellEndEdit
      TryCatched(Sub() getTotalesGrilla())
   End Sub

   Private Sub bsccodCuenta_BuscadorClick() Handles bscCodCuenta.BuscadorClick
      TryCatched(
         Sub()
            _publicosContabilidad.PreparaGrillaCuentas(bscCodCuenta)
            bscCodCuenta.Datos = New Reglas.ContabilidadCuentas().GetCuentasImputablesXCodigo(bscCodCuenta.Text.ValorNumericoPorDefecto(0L))
         End Sub)
   End Sub
   Private Sub bscDescripcion_BuscadorClick() Handles bscDescripcion.BuscadorClick
      TryCatched(
         Sub()
            _publicosContabilidad.PreparaGrillaCuentas(bscDescripcion)
            bscDescripcion.Datos = New Reglas.ContabilidadCuentas().GetCuentasImputablesXNombre(bscDescripcion.Text.Trim())
         End Sub)
   End Sub

   Private Sub bscCodCuenta_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodCuenta.BuscadorSeleccion, bscDescripcion.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               bscDescripcion.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).Value.ToString()
               bscCodCuenta.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).Value.ToString()
               If _permiteCambiarCentroCostos Then
                  cmbCentroCosto.Select()
               Else
                  txtDebe.Select()
               End If
            End If
         End Sub)
   End Sub


   Private Sub bscModelo_BuscadorClick() Handles bscModelo.BuscadorClick
      TryCatched(
         Sub()
            Dim rAsientos = New Reglas.ContabilidadAsientos()
            Me._publicosContabilidad.PreparaGrillaCuentas(bscDescripcion)

            Dim idPlan As Integer = -1
            If cmbPlan.SelectedIndex > -1 Then
               idPlan = Integer.Parse(Me.cmbPlan.SelectedValue.ToString())
            Else
               Throw New Exception("Debe seleccionar un Plan de Cuentas.")
            End If

            bscModelo.Datos = rAsientos.GetModelos(idPlan, bscModelo.Text.Trim())
         End Sub)
   End Sub

   Private Sub bscModelo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscModelo.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               ' Me.bscModelo.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).Value.ToString()
               If dtGrilla.Rows.Count > 0 Then
                  If MessageBox.Show(String.Format("¿Desea reemplazar el asiento actual por el asiento modelo {0}?", e.FilaDevuelta.Cells("nombreAsiento").Value), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                     Exit Sub
                  End If
               End If
               Dim rg As Reglas.ContabilidadAsientosModelos = New Reglas.ContabilidadAsientosModelos()
               Dim dt As DataTable = rg.Get1(CInt(e.FilaDevuelta.Cells("idPlanCuenta").Value), CInt(e.FilaDevuelta.Cells("idAsiento").Value))
               CargarAsientoModelo(dt.Select())

               'Me.bscCodCuenta.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).Value.ToString()
               'Me.txtDebe.Select()
            End If
         End Sub)
   End Sub

   Private Sub CargarAsientoModelo(filasCuentas As DataRow())
      'Dim renglon As Integer = 0

      dtGrilla.Clear()

      For Each fila As DataRow In filasCuentas
         Me.txtConcepto.Text = fila("nombreAsiento").ToString

         Dim filaGrilla As DataRow
         filaGrilla = dtGrilla.NewRow
         filaGrilla("Cuenta") = fila("idCuenta").ToString & " - " & fila("nombreCuenta").ToString
         filaGrilla("debe") = DBNull.Value
         filaGrilla("haber") = DBNull.Value
         filaGrilla("idAsiento") = Me.txtNumeroAsiento.Text
         filaGrilla("idRenglon") = 0
         filaGrilla("IdCuenta") = fila("idCuenta").ToString
         dtGrilla.Rows.Add(filaGrilla)
      Next
      Me.grdAsientosDetalle.DataSource = dtGrilla
      getTotalesGrilla()

      grdAsientosDetalle.EditMode = DataGridViewEditMode.EditOnKeystroke
      grdAsientosDetalle.Columns("debe").ReadOnly = False
      grdAsientosDetalle.Columns("haber").ReadOnly = False


   End Sub
   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Insertar(DirectCast(sender, Control))
   End Sub

   Private Sub Insertar(sender As Control)
      TryCatched(
         Sub()
            If ValidacionesCuenta(sender) Then

               AgregarFila()

               bscCodCuenta.Text = String.Empty
               bscDescripcion.Text = String.Empty
               txtDebe.Text = "0.00"
               txtHaber.Text = "0.00"
               cmbCentroCosto.SelectedIndex = -1
               cmbCentroCosto.Enabled = _permiteCambiarCentroCostos
               bscCodCuenta.Focus()

               If txtTotalDebe.Text <> txtTotalHaber.Text Then
                  lblTotales.ForeColor = Color.Red
               Else
                  lblTotales.ForeColor = Color.Green
               End If

            End If
         End Sub)
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      TryCatched(Sub() EliminarFila(GetSelectedRow()))
   End Sub

   Private Sub EliminarFila(row As DataGridViewRow)
      If row.DataBoundItem IsNot Nothing AndAlso TypeOf (row.DataBoundItem) Is DataRowView Then
         EliminarFila(DirectCast(row.DataBoundItem, DataRowView).Row)
      Else
         EliminarFila(DirectCast(Nothing, DataRow))
      End If
   End Sub
   Private Sub EliminarFila(row As DataRow)
      If row Is Nothing Then
         MessageBox.Show("Seleccione la cuenta a Eliminar", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Else
         dtGrilla.Rows.Remove(row)
         grdAsientosDetalle.DataSource = dtGrilla
         getTotalesGrilla()
      End If
   End Sub

   Private Sub txtDebe_GotFocus(sender As Object, e As EventArgs) Handles txtDebe.GotFocus
      TryCatched(Sub() txtDebe.SelectAll())
   End Sub

   Private Sub txtDebe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDebe.KeyPress
      TryCatched(
        Sub()
           If e.KeyChar = Convert.ToChar(Keys.Enter) Then
              If IsNumeric(txtDebe.Text) And CDec(txtDebe.Text) <> 0 Then
                 Insertar(DirectCast(sender, Control))
              Else
                 PresionarTab(e)
              End If
           End If
        End Sub)
   End Sub

   Private Sub txtHaber_GotFocus(sender As Object, e As EventArgs) Handles txtHaber.GotFocus
      TryCatched(Sub() txtHaber.SelectAll())
   End Sub

   Private Sub txtHaber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHaber.KeyPress
      TryCatched(
         Sub()
            If e.KeyChar = Convert.ToChar(Keys.Enter) Then
               If IsNumeric(txtHaber.Text) And CDec(txtHaber.Text) <> 0 Then
                  Insertar(DirectCast(sender, Control))
               Else
                  PresionarTab(e)
               End If
            End If
         End Sub)
   End Sub

#End Region

   Private Sub txtConcepto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtConcepto.KeyPress
      TryCatched(Sub() PresionarTab(e))
   End Sub

   Private Sub grdAsientosDetalle_DoubleClick(sender As Object, e As EventArgs) Handles grdAsientosDetalle.DoubleClick
      TryCatched(
         Sub()
            Dim row As DataGridViewRow = GetSelectedRow()
            If row IsNot Nothing AndAlso row.DataBoundItem IsNot Nothing AndAlso
            TypeOf (row.DataBoundItem) Is DataRowView Then
               Dim dr As DataRow = DirectCast(row.DataBoundItem, DataRowView).Row
               bscCodCuenta.Text = dr("IdCuenta").ToString()
               bscCodCuenta.PresionarBoton()
               If Not IsDBNull(dr("debe")) Then txtDebe.Text = dr("debe").ToString()
               If Not IsDBNull(dr("haber")) Then txtHaber.Text = dr("haber").ToString()
               If _utilizaCentroCostos Then
                  cmbCentroCosto.SelectedValue = dr("IdCentroCosto")
                  cmbCentroCosto.Enabled = cmbCentroCosto.SelectedIndex <> -1
               End If
               EliminarFila(dr)
            End If
         End Sub)
   End Sub

   Private Function GetSelectedRow() As DataGridViewRow
      Dim row As DataGridViewRow = Nothing
      If grdAsientosDetalle.SelectedRows.Count > 0 Then
         row = grdAsientosDetalle.SelectedRows(0)
      End If
      If grdAsientosDetalle.SelectedCells.Count > 0 Then
         row = grdAsientosDetalle.SelectedCells(0).OwningRow
      End If
      Return row
   End Function

   Private Sub dtpFecha_Leave(sender As Object, e As EventArgs) Handles dtpFecha.Leave
      TryCatched(Sub() VerificarEjercicioVigente(Me.dtpFecha.Value))
   End Sub

   Private Sub cmbCentroCosto_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCentroCosto.KeyDown
      TryCatched(Sub() PresionarTab(e))
   End Sub

   Private Sub cmbPlan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbPlan.KeyPress
      TryCatched(Sub() PresionarTab(e))
   End Sub

   Private Sub dtpFecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpFecha.KeyPress
      TryCatched(Sub() PresionarTab(e))
   End Sub

   Private Sub txtNumeroAsiento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroAsiento.KeyPress
      TryCatched(Sub() PresionarTab(e))
   End Sub

    Private Sub Label3_Click()

    End Sub
End Class