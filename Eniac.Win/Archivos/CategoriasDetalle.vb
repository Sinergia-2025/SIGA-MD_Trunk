Public Class CategoriasDetalle

#Region "Campos"

   Private _publicos As Publicos

   Private ReadOnly Property Categoria As Entidades.Categoria
      Get
         Return DirectCast(_entidad, Entidades.Categoria)
      End Get
   End Property

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.Categoria)
      Me.New()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      _tituloNuevo = "Nueva"

      MyBase.OnLoad(e)
      'Se agregó try catch
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboCajas(cmbCajas, actual.Sucursal.Id, miraUsuario:=False, miraPC:=False, cajasModificables:=False)
         cmbCajas.SelectedIndex = -1

         _publicos.CargaComboIntereses(cmbIntereses)
         cmbIntereses.SelectedIndex = -1

         _publicos.CargaComboIntereses(cmbInteresesCuotas)
         cmbInteresesCuotas.SelectedIndex = -1

         _publicos.CargaComboAdquiereAcciones(cmbAdquiereAcciones)
         _publicos.CargaComboAdquiereCamas(cmbAdquiereCamas)
         _publicos.CargaComboPideEmbarcacion(cmbPideEmbarcacion)
         _publicos.CargaComboCategorias(cmbCategoriaInversionista)

         _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, MiraPC:=False, "CTACTECLIE")

         _liSources.Add("Interes", Categoria.Interes)

         BindearControles(_entidad, _liSources)

         If StateForm = Eniac.Win.StateForm.Insertar Then
            CargarProximoNumero()

            If Reglas.Publicos.TieneModuloContabilidad Then
               Dim idCuenta As Long = Reglas.ContabilidadPublicos.ContabilidadCuentaVentas
               If idCuenta > 0 Then
                  UcCuentas1.Cuenta = New Reglas.ContabilidadCuentas().GetUna(idCuenta)
               End If
            Else
               UcCuentas1.Visible = False
               UcCuentas2.Visible = False
               lblCuentaSecundaria.Visible = False
            End If
         Else

            chbBackColor.Checked = Categoria.BackColor.HasValue
            chbForeColor.Checked = Categoria.ForeColor.HasValue

            SetColor1()

            Dim oUsuario = New Reglas.Usuarios()

            txtNivelAutorizacion.Visible = oUsuario.TienePermisos("Categoria-NivelAutorizacion")
            txtNivelAutorizacion.LabelAsoc.Visible = txtNivelAutorizacion.Visible

            'If Me.cmbCajas.SelectedIndex >= 0 Then
            If Categoria.IdCaja > 0 And cmbCajas.SelectedIndex >= 0 Then
               chbCaja.Checked = True
            End If

            If Categoria.IdTipoComprobante <> "" Then
               chbTipoDeComprobante.Checked = True
            End If

            If Categoria.IdInteres <> 0 Then
               cmbIntereses.SelectedValue = Categoria.IdInteres
               chbIntereses.Checked = True
            Else
               chbIntereses.Checked = False
            End If

            cmbIntereses.SelectedValue = Categoria.IdInteres
            chbIntereses.Checked = Categoria.Interes IsNot Nothing

            cmbInteresesCuotas.SelectedValue = Categoria.IdInteresCuotas
            chbInteresesCuotas.Checked = Categoria.InteresCuotas IsNot Nothing

            If Reglas.Publicos.TieneModuloContabilidad Then
               UcCuentas1.Cuenta = Categoria.Cuenta
               UcCuentas2.Cuenta = Categoria.CuentaSecundaria
            Else
               UcCuentas1.Visible = False
               UcCuentas2.Visible = False
               lblCuentaSecundaria.Visible = False
            End If

            If Categoria.LimiteMesesDeudaBotado.HasValue Then
               chbLimiteMesesDeudaBotado.Checked = True
               txtLimiteMesesDeudaBotado.Text = Categoria.LimiteMesesDeudaBotado.Value.ToString()
            Else
               chbLimiteMesesDeudaBotado.Checked = False
               txtLimiteMesesDeudaBotado.Enabled = chbLimiteMesesDeudaBotado.Checked
            End If

            If Not String.IsNullOrWhiteSpace(Categoria.IdProducto) Then
               bscCodigoProducto2.Text = Categoria.IdProducto
               bscCodigoProducto2.PresionarBoton()
            End If

            dgvComisionesRubros.DataSource = DescuentosRubros
            dgvComisionesSubRubros.DataSource = DescuentosSubRubros
            dgvComisionesSubSubRubros.DataSource = DescuentosSubSubRubros
         End If

         'CAMBIAR
         'If Not Publicos.ExtrasSinergia Then
         '   Me.tbcCategoria.TabPages.Remove(tbpLicencias)
         'End If

         If Not Reglas.Publicos.TieneModuloControlDeLicencias Then
            tbcCategoria.TabPages.Remove(tbpLicencias)
         End If

         If (Reglas.Publicos.ProductoTieneSubRubro = False) Then
            tbcDescuentosDetalle.TabPages.Remove(tbpSubRubro)
            tbcDescuentosDetalle.TabPages.Remove(tbpSubSubRubro)
         End If
         If (Reglas.Publicos.ProductoTieneSubSubRubro = False) Then
            tbcDescuentosDetalle.TabPages.Remove(tbpSubSubRubro)
         End If

         If Publicos.IDAplicacionSinergia <> "SICLUB" Then
            lblConcepto.Visible = False
            bscCodigoProducto2.Visible = False
            bscProducto2.Visible = False
         End If

         If Not Reglas.Publicos.TieneModuloContabilidad OrElse Not Reglas.ContabilidadPublicos.ContabilidadCuentaSecundariaCategoria Then
            UcCuentas2.Visible = False
            lblCuentaSecundaria.Visible = False
         End If

         'NUEVA COND MARINA
         If Publicos.IDAplicacionSinergia <> "SISEN" Then
            tbcCategoria.TabPages.Remove(tbpMarina)
         Else
            tbcCategoria.SelectedTab = tbpMarina
            tbcCategoria.SelectedTab = tbpDetalle
         End If

         If Publicos.CargosCalcularPor = "ACCION" Then
            lblAdquiereCamas.Visible = False
            cmbAdquiereCamas.Visible = False
            cmbAdquiereCamas.IsRequired = False
            chbCategoriaInversionista.Checked = True
            chbCategoriaInversionista.Checked = Categoria.IdCategoriaInversionista.HasValue
         Else
            lblAdquiereAcciones.Visible = False
            cmbAdquiereAcciones.Visible = False
            cmbAdquiereAcciones.IsRequired = False
         End If
      End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Categorias()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      If Math.Abs(txtDescuentoRecargo.ValorNumericoPorDefecto(0D)) >= 100 Then
         Return "El Descuento/Recargo NO es Válido."
      End If
      If chbCaja.Checked And cmbCajas.SelectedIndex = -1 Then
         cmbCajas.Focus()
         Return "ATENCION: Activo la Caja por Defecto. Debe elegir una."
      End If
      If chbTipoDeComprobante.Checked And cmbTiposComprobantes.SelectedIndex = -1 Then
         cmbTiposComprobantes.Focus()
         Return "ATENCION: Activo el Comprobante de Facturación por Defecto. Debe elegir uno."
      End If
      If chbIntereses.Checked And cmbIntereses.SelectedIndex = -1 Then
         cmbIntereses.Focus()
         Return "ATENCION: Activo el Interés para Cobranza por Defecto. Debe elegir uno."
      End If
      If chbInteresesCuotas.Checked And cmbInteresesCuotas.SelectedIndex = -1 Then
         cmbInteresesCuotas.Focus()
         Return "ATENCION: Activo el Interés para Cuotas por Defecto. Debe elegir uno."
      End If
      If Reglas.Publicos.TieneModuloContabilidad Then
         If UcCuentas1.Cuenta Is Nothing OrElse UcCuentas1.Cuenta.IdCuenta = 0 Then
            UcCuentas1.Focus()
            Return "Debe indicar una cuenta contable para la categoría."
         End If
      End If
      If txtNivelAutorizacion.Visible Then
         If Not IsNumeric(txtNivelAutorizacion.Text) Then txtNivelAutorizacion.Text = "1"
         If Short.Parse(txtNivelAutorizacion.Text) > actual.NivelAutorizacion Then
            tbcCategoria.SelectedTab = tbpDetalle
            txtNivelAutorizacion.Focus()
            Return "ATENCION: El nivel de autorización ingresado es superior al suyo."
         End If
      End If
      If chbCategoriaInversionista.Checked And cmbCategoriaInversionista.SelectedIndex = -1 Then
         cmbCategoriaInversionista.Focus()
         Return "ATENCION: Activó la Categoría Inversionista. Debe elegir una."
      End If
      Return String.Empty
   End Function

   Protected Overrides Sub Aceptar()
      If Reglas.Publicos.TieneModuloContabilidad Then
         Categoria.Cuenta = UcCuentas1.Cuenta

         If Reglas.ContabilidadPublicos.ContabilidadCuentaSecundariaCategoria Then
            Categoria.CuentaSecundaria = UcCuentas2.Cuenta
         Else
            Categoria.CuentaSecundaria = Nothing
         End If
      Else
         Categoria.Cuenta = Nothing
         Categoria.CuentaSecundaria = Nothing
      End If

      If chbIntereses.Checked Then
         Categoria.Interes = DirectCast(cmbIntereses.SelectedItem, Entidades.Interes)
      Else
         Categoria.Interes = Nothing
      End If

      If chbInteresesCuotas.Checked Then
         Categoria.InteresCuotas = DirectCast(cmbInteresesCuotas.SelectedItem, Entidades.Interes)
      Else
         Categoria.InteresCuotas = Nothing
      End If

      Categoria.IdProducto = bscCodigoProducto2.Text

      If chbCategoriaInversionista.Checked Then
         Categoria.IdCategoriaInversionista = CInt(cmbCategoriaInversionista.SelectedValue)
      Else
         Categoria.IdCategoriaInversionista = Nothing
      End If
      If chbLimiteMesesDeudaBotado.Checked Then
         Categoria.LimiteMesesDeudaBotado = Integer.Parse(txtLimiteMesesDeudaBotado.Text)
      Else
         Categoria.LimiteMesesDeudaBotado = Nothing
      End If
      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"

   Private Sub chbCaja_CheckedChanged(sender As Object, e As EventArgs) Handles chbCaja.CheckedChanged
      TryCatched(
      Sub()
         If Not chbCaja.Checked Then
            cmbCajas.SelectedIndex = -1
            Categoria.IdCaja = 0
         End If
         cmbCajas.Enabled = chbCaja.Checked
      End Sub)
   End Sub

   Private Sub chbTipoDeComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoDeComprobante.CheckedChanged
      TryCatched(
      Sub()
         If Not chbTipoDeComprobante.Checked Then
            cmbTiposComprobantes.SelectedIndex = -1
            Categoria.IdTipoComprobante = ""
         End If
         cmbTiposComprobantes.Enabled = chbTipoDeComprobante.Checked
         If chbTipoDeComprobante.Checked Then
            cmbTiposComprobantes.Focus()
         End If
      End Sub)
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      If Not HayError Then Close()
      txtCategoria.Focus()
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
         bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscProducto2)
         bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion, bscProducto2.BuscadorSeleccion
      TryCatched(Sub() CargarProducto(e.FilaDevuelta))
   End Sub
   Private Sub chbIntereses_CheckedChanged(sender As Object, e As EventArgs) Handles chbIntereses.CheckedChanged
      TryCatched(
      Sub()
         If Not chbIntereses.Checked Then
            cmbIntereses.SelectedIndex = -1
            Categoria.Interes = Nothing
         End If
         cmbIntereses.Enabled = chbIntereses.Checked
      End Sub)
   End Sub

   Private Sub chbInteresesCuotas_CheckedChanged(sender As Object, e As EventArgs) Handles chbInteresesCuotas.CheckedChanged
      TryCatched(
      Sub()
         If Not chbInteresesCuotas.Checked Then
            cmbInteresesCuotas.SelectedIndex = -1
            Categoria.InteresCuotas = Nothing
         End If
         cmbInteresesCuotas.Enabled = chbInteresesCuotas.Checked
      End Sub)
   End Sub

   Private Sub chbCategoriaInversionista_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoriaInversionista.CheckedChanged
      TryCatched(
      Sub()
         If Not chbCategoriaInversionista.Checked Then
            cmbCategoriaInversionista.SelectedIndex = -1
         Else
            If Categoria.IdCategoriaInversionista.HasValue Then
               cmbCategoriaInversionista.SelectedValue = Categoria.IdCategoriaInversionista.Value
            Else
               cmbCategoriaInversionista.SelectedIndex = -1
            End If
         End If
         cmbCategoriaInversionista.Enabled = chbCategoriaInversionista.Checked
         If chbCategoriaInversionista.Checked Then
            cmbCategoriaInversionista.Focus()
         End If
      End Sub)
   End Sub

   Private Sub chbInteresesMarina_CheckedChanged(sender As Object, e As EventArgs)
      TryCatched(
      Sub()
         If Not chbIntereses.Checked Then
            cmbIntereses.SelectedIndex = -1
            Categoria.Interes = Nothing
         End If
         cmbIntereses.Enabled = chbIntereses.Checked
      End Sub)
   End Sub

   Private Sub chbLimiteMesesDeudaBotado_CheckedChanged(sender As Object, e As EventArgs) Handles chbLimiteMesesDeudaBotado.CheckedChanged
      TryCatched(
      Sub()
         If Not chbLimiteMesesDeudaBotado.Checked Then
            txtLimiteMesesDeudaBotado.Text = "0"
         Else
            txtLimiteMesesDeudaBotado.Text = Reglas.Publicos.ReservaSemaforoAmarillo.ToString()
         End If
         txtLimiteMesesDeudaBotado.Enabled = chbLimiteMesesDeudaBotado.Checked
      End Sub)
   End Sub

   Private Sub txtDescuentoRubros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescuentoRubros.KeyPress, txtDescuentoSubRubros.KeyPress, txtDescuentoSubSubRubro.KeyPress
      PresionarTab(e)
   End Sub

#End Region

#Region "Metodos"
   Private Sub CargarProximoNumero()
      txtCategoria.Text = (New Reglas.Categorias().GetIdMaximo() + 1).ToString()
   End Sub

   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      End If
   End Sub

   Private _estaCargando As Boolean
   Private Sub CargarRubro(dr As DataGridViewRow, bscCodigo As Eniac.Controles.Buscador2, bscNombre As Eniac.Controles.Buscador2, ctrlFocus As Control)
      If dr IsNot Nothing Then
         bscCodigo.Text = dr.Cells("IdRubro").Value.ToString()
         bscNombre.Text = dr.Cells("NombreRubro").Value.ToString()
         ctrlFocus.Focus()
      End If
   End Sub
   Private Sub CargarSubRubro(dr As DataGridViewRow, bscCodigo As Controles.Buscador2, bscNombre As Controles.Buscador2, bscRubro As Controles.Buscador2, ctrlFocus As Control)
      If dr IsNot Nothing Then
         bscCodigo.Text = dr.Cells("IdSubRubro").Value.ToString()
         bscNombre.Text = dr.Cells("NombreSubRubro").Value.ToString()

         If bscRubro.Text.ValorNumericoPorDefecto(0I) = 0 Then
            Dim tempEstaCargando As Boolean = _estaCargando
            _estaCargando = True
            bscRubro.Text = dr.Cells("IdRubro").Value.ToString()
            bscRubro.PresionarBoton()
            _estaCargando = tempEstaCargando
         End If
         ctrlFocus.Focus()
      End If
   End Sub
   Private Sub CargarSubSubRubro(dr As DataGridViewRow, bscCodigo As Controles.Buscador2, bscNombre As Controles.Buscador2, bscSubRubro As Controles.Buscador2, ctrlFocus As Control)
      If dr IsNot Nothing Then
         bscCodigo.Text = dr.Cells("IdSubSubRubro").Value.ToString()
         bscNombre.Text = dr.Cells("NombreSubSubRubro").Value.ToString()

         If bscSubRubro.Text.ValorNumericoPorDefecto(0I) = 0 Then
            Dim tempEstaCargando As Boolean = _estaCargando
            _estaCargando = True
            bscSubRubro.Text = dr.Cells("IdSubRubro").Value.ToString()
            bscSubRubro.PresionarBoton()
            _estaCargando = tempEstaCargando
         End If
      End If
      ctrlFocus.Focus()
   End Sub
#End Region

#Region "--------------Eventos Rubros----------------"

   Private Sub AgregarRubro()
      Dim dr = DescuentosRubros.NewRow()
      dr("IdRubro") = bscCodigoRubro0.Text
      dr("NombreRubro") = bscNombreRubro0.Text
      dr("DescuentoRecargoPorc1") = txtDescuentoRubros.Text

      DescuentosRubros.Rows.Add(dr)
      dgvComisionesRubros.DataSource = DescuentosRubros
   End Sub

   Private Sub EditarRubro(dr As DataGridViewRow)
      bscCodigoRubro0.Text = dr.Cells("Codigo").Value.ToString()
      bscCodigoRubro0.PresionarBoton()
      txtDescuentoRubros.Text = dr.Cells("DescuentoRecargoPorc1").Value.ToString()
      EliminarLinea(dgvComisionesRubros)
   End Sub

   Private Sub EditarSubRubro(dr As DataGridViewRow)
      bscCodigoRubro1.Text = dr.Cells("IdRubro").Value.ToString()
      bscCodigoRubro1.PresionarBoton()
      bscCodigoSubRubro1.Text = dr.Cells("IdSubRubro").Value.ToString()
      bscCodigoSubRubro1.PresionarBoton()
      txtDescuentoSubRubros.Text = dr.Cells("DescuentoRecargoPorc2").Value.ToString()
      EliminarLinea(dgvComisionesSubRubros)
   End Sub

   Private Sub EditarSubSubRubro(dr As DataGridViewRow)
      bscCodigoRubro2.Text = dr.Cells("IdRubroTwo").Value.ToString()
      bscCodigoRubro2.PresionarBoton()
      bscCodigoSubRubro2.Text = dr.Cells("IdSubRubroTwo").Value.ToString()
      bscCodigoSubRubro2.PresionarBoton()
      bscCodigoSubSubRubro2.Text = dr.Cells("IdSubSubRubro").Value.ToString()
      bscCodigoSubSubRubro2.PresionarBoton()
      txtDescuentoSubSubRubro.Text = dr.Cells("DescuentoRecargoPorc3").Value.ToString()
      EliminarLinea(dgvComisionesSubSubRubros)
   End Sub

   Private Sub btnInsertarRubros_Click(sender As Object, e As EventArgs) Handles btnInsertarRubros.Click
      TryCatched(
      Sub()
         If Not Me.bscCodigoRubro0.Selecciono And Not Me.bscNombreRubro0.Selecciono Then
            MessageBox.Show("Debe seleccionar un Rubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoRubro0.Focus()
            Return
         End If
         If String.IsNullOrEmpty(Me.bscCodigoRubro0.Text) Or String.IsNullOrEmpty(Me.bscNombreRubro0.Text) Then
            MessageBox.Show("Debe seleccionar un Rubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoRubro0.Focus()
            Return
         End If

         If Me.ExisteRubro(Int32.Parse(bscCodigoRubro0.Text)) Then
            MessageBox.Show("Ya existe el Rubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
         End If
         If Decimal.Parse(Me.txtDescuentoRubros.Text) = 0 Then
            MessageBox.Show("Ingrese un valor valido de Descuento/Recargo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtDescuentoRubros.Focus()
            Return
         End If

         If Decimal.Parse(Me.txtDescuentoRubros.Text) <= -100 Or Decimal.Parse(Me.txtDescuentoRubros.Text) >= 100 Then
            MessageBox.Show("El valor del  Descuento y el Recargo no debe ser mayor a 100", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtDescuentoRubros.Focus()
            Return
         End If

         AgregarRubro()

         bscCodigoRubro0.Text = ""
         bscNombreRubro0.Text = ""
         txtDescuentoRubros.Text = "0.00"
      End Sub)
   End Sub

   Public ReadOnly Property DescuentosRubros() As DataTable
      Get
         If Categoria.DescuentoRecargoPorc1 IsNot Nothing Then
            If Categoria.DescuentoRecargoPorc1.Tables.Contains(Entidades.Categoria.DescuentosRubrosTableName) Then
               Return Categoria.DescuentoRecargoPorc1.Tables(Entidades.Categoria.DescuentosRubrosTableName)
            End If
         End If
         Return Nothing
      End Get
   End Property

   Private Function ExisteRubro(idRubro As Integer) As Boolean
      Return ExisteClavePrimaria(DescuentosRubros, "IdRubro", idRubro)
   End Function

   Private Function ExisteClavePrimaria(dt As DataTable, keyName As String, keyValue As Integer) As Boolean
      If dt IsNot Nothing Then
         For Each dr As DataRow In dt.Rows
            If dr.RowState <> DataRowState.Deleted Then
               If Int32.Parse(dr(keyName).ToString()) = keyValue Then
                  Return True
               End If
            End If
         Next
      End If
      Return False
   End Function

   Private Sub bscCodigoRubro0_BuscadorClick() Handles bscCodigoRubro0.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaRubros2(bscCodigoRubro0)
         bscCodigoRubro0.Datos = New Reglas.Rubros().GetPorCodigo(bscCodigoRubro0.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub
   Private Sub bscNombreRubro0_BuscadorClick() Handles bscNombreRubro0.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaRubros2(bscNombreRubro0)
         bscNombreRubro0.Datos = New Reglas.Rubros().GetPorNombre(bscNombreRubro0.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoRubro0_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoRubro0.BuscadorSeleccion, bscNombreRubro0.BuscadorSeleccion
      TryCatched(Sub() CargarRubro(e.FilaDevuelta, bscCodigoRubro0, bscNombreRubro0, txtDescuentoRubros))
   End Sub
   Private Sub bscCodigoRubro0_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bscCodigoRubro0.KeyPress, bscNombreRubro0.KeyPress
      PresionarTab(e)
   End Sub


   Private Sub btnEliminarRubros_Click(sender As Object, e As EventArgs) Handles btnEliminarRubros.Click
      TryCatched(
      Sub()
         If dgvComisionesRubros.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el item selecionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               EliminarLinea(dgvComisionesRubros)
            End If
         End If
      End Sub)
   End Sub

   Private Sub btnRefrescarRubros_Click(sender As Object, e As EventArgs) Handles btnRefrescarRubros.Click
      TryCatched(
      Sub()
         If bscCodigoRubro0.Selecciono Then
            bscCodigoRubro0.Text = ""
            bscNombreRubro0.Text = ""
            bscCodigoRubro0.Focus()
         End If
         txtDescuentoRubros.Text = "0.00"
      End Sub)
   End Sub

   Private Sub EliminarLinea(grilla As Eniac.Controles.DataGridView)
      '   EliminarLineaSeleccionada(grilla)
      'End Sub

      'Private Sub EliminarLineaSeleccionada(grilla As Eniac.Controles.DataGridView)
      If grilla IsNot Nothing Then
         If grilla.SelectedRows.Count > 0 AndAlso
            grilla.SelectedRows(0).DataBoundItem IsNot Nothing AndAlso
            TypeOf (grilla.SelectedRows(0).DataBoundItem) Is DataRowView AndAlso
            DirectCast(grilla.SelectedRows(0).DataBoundItem, DataRowView).Row IsNot Nothing Then
            DirectCast(grilla.SelectedRows(0).DataBoundItem, DataRowView).Row.Delete()
         End If
         If grilla.RowCount > 0 And grilla.SelectedRows.Count = 0 Then
            grilla.Rows(0).Selected = True
         End If
      End If
   End Sub

#End Region

#Region "--------------Eventos SubRubros----------------"

   Private Sub btnInsertarSubRubros_Click(sender As Object, e As EventArgs) Handles btnInsertarSubRubros.Click
      TryCatched(
      Sub()
         If Not Me.bscCodigoRubro1.Selecciono And Not Me.bscNombreRubro1.Selecciono Then
            MessageBox.Show("Debe seleccionar un Rubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoRubro1.Focus()
            Return
         End If
         If String.IsNullOrEmpty(Me.bscCodigoRubro1.Text) Or String.IsNullOrEmpty(Me.bscNombreRubro1.Text) Then
            MessageBox.Show("Debe seleccionar un Rubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoRubro1.Focus()
            Return
         End If
         If Not Me.bscCodigoSubRubro1.Selecciono And Not Me.bscNombreSubRubro1.Selecciono Then
            MessageBox.Show("Debe seleccionar un SubRubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoSubRubro1.Focus()
            Return
         End If
         If String.IsNullOrEmpty(Me.bscCodigoSubRubro1.Text) Or String.IsNullOrEmpty(bscNombreSubRubro1.Text) Then
            MessageBox.Show("Debe seleccionar un SubRubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoSubRubro1.Focus()
            Return
         End If
         If Me.ExisteSubRubro(Int32.Parse(Me.bscCodigoSubRubro1.Text), Int32.Parse(Me.bscCodigoRubro1.Text)) Then
            MessageBox.Show("Ya existe el SubRubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
         End If
         If Decimal.Parse(Me.txtDescuentoSubRubros.Text) = 0 Then
            MessageBox.Show("Ingrese un valor valido de Descuento/Recargo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtDescuentoSubRubros.Focus()
            Return
         End If
         If Decimal.Parse(Me.txtDescuentoSubRubros.Text) <= -100 Or Decimal.Parse(Me.txtDescuentoSubRubros.Text) >= 100 Then
            MessageBox.Show("El valor del  Descuento y el Recargo no debe ser mayor a 100", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtDescuentoSubRubros.Focus()
            Return
         End If

         AgregarSubRubro()

         bscCodigoRubro1.Text = ""
         bscNombreRubro1.Text = ""
         bscCodigoSubRubro1.Text = ""
         bscNombreSubRubro1.Text = ""
         txtDescuentoSubRubros.Text = "0.00"
      End Sub)
   End Sub

   Private Sub AgregarSubRubro()

      Dim dr As DataRow = Me.DescuentosSubRubros.NewRow()

      dr("IdSubRubro") = Me.bscCodigoSubRubro1.Text
      dr("NombreSubRubro") = Me.bscNombreSubRubro1.Text
      dr("IdRubro") = Me.bscCodigoRubro1.Text
      dr("NombreRubro") = Me.bscNombreRubro1.Text
      dr("DescuentoRecargoPorc1") = Me.txtDescuentoSubRubros.Text

      Me.DescuentosSubRubros.Rows.Add(dr)

      Me.dgvComisionesSubRubros.DataSource = Me.DescuentosSubRubros
   End Sub

   Public ReadOnly Property DescuentosSubRubros() As DataTable
      Get
         If Categoria.DescuentoRecargoPorc1 IsNot Nothing Then
            If Categoria.DescuentoRecargoPorc1.Tables.Contains(Entidades.Categoria.DescuentosSubRubrosTableName) Then
               Return Categoria.DescuentoRecargoPorc1.Tables(Entidades.Categoria.DescuentosSubRubrosTableName)
            End If
         End If
         Return Nothing
      End Get
   End Property

   Private Function ExisteSubRubro(idSubRubro As Integer, idRubro As Integer) As Boolean
      Return ExisteClavePrimariaSub(DescuentosSubRubros, "IdSubRubro", idSubRubro, "IdRubro", idRubro)
   End Function

   Private Function ExisteClavePrimariaSub(dt As DataTable, keyName1 As String, keyValue1 As Integer, keyName2 As String, keyValue2 As Integer) As Boolean
      If dt IsNot Nothing Then
         For Each dr As DataRow In dt.Rows
            If dr.RowState <> DataRowState.Deleted Then
               If (Int32.Parse(dr(keyName1).ToString()) = keyValue1) And (Int32.Parse(dr(keyName2).ToString()) = keyValue2) Then
                  Return True
               End If
            End If
         Next
      End If
      Return False
   End Function

   Private Sub bscCodigoRubro1_BuscadorClick() Handles bscCodigoRubro1.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaRubros2(bscCodigoRubro1)
         bscCodigoRubro1.Datos = New Reglas.Rubros().GetPorCodigo(bscCodigoRubro1.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub
   Private Sub bscNombreRubro1_BuscadorClick() Handles bscNombreRubro1.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaRubros2(bscNombreRubro1)
         bscNombreRubro1.Datos = New Reglas.Rubros().GetPorNombre(bscNombreRubro1.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoRubro1_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoRubro1.BuscadorSeleccion, bscNombreRubro1.BuscadorSeleccion
      TryCatched(Sub() CargarRubro(e.FilaDevuelta, bscCodigoRubro1, bscNombreRubro1, bscCodigoSubRubro1))
   End Sub
   Private Sub bscCodigoRubro1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bscCodigoRubro1.KeyPress, bscNombreRubro1.KeyPress
      PresionarTab(e)
   End Sub


   Private Sub bscCodigoSubRubro1_BuscadorClick() Handles bscCodigoSubRubro1.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaSubRubros2(bscCodigoSubRubro1)
         bscCodigoSubRubro1.Datos = New Reglas.SubRubros().GetPorCodigo(bscCodigoRubro1.Text.ValorNumericoPorDefecto(0I),
                                                                           bscCodigoSubRubro1.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub
   Private Sub bscNombreSubRubro1_BuscadorClick() Handles bscNombreSubRubro1.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaSubRubros2(bscNombreSubRubro1)
         bscNombreSubRubro1.Datos = New Reglas.SubRubros().GetPorNombre(bscCodigoRubro1.Text.ValorNumericoPorDefecto(0I),
                                                                           bscNombreSubRubro1.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoSubRubro1_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoSubRubro1.BuscadorSeleccion, bscNombreSubRubro1.BuscadorSeleccion
      TryCatched(Sub() CargarSubRubro(e.FilaDevuelta, bscCodigoSubRubro1, bscNombreSubRubro1, bscCodigoRubro1, txtDescuentoSubRubros))
   End Sub
   Private Sub bscCodigoSubRubro1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bscCodigoSubRubro1.KeyPress, bscNombreSubRubro1.KeyPress
      PresionarTab(e)
   End Sub



   Private Sub btnEliminarSubRubros_Click(sender As Object, e As EventArgs) Handles btnEliminarSubRubros.Click
      TryCatched(
      Sub()
         If dgvComisionesSubRubros.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el item selecionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               EliminarLinea(dgvComisionesSubRubros)
            End If
         End If
      End Sub)
   End Sub

   Private Sub btnRefrescarSubRubros_Click(sender As Object, e As EventArgs) Handles btnRefrescarSubRubros.Click
      TryCatched(
      Sub()
         bscCodigoRubro1.Text = ""
         bscNombreRubro1.Text = ""
         bscCodigoSubRubro1.Text = ""
         bscNombreSubRubro1.Text = ""
         bscCodigoRubro1.Focus()

         txtDescuentoSubRubros.Text = "0.00"
      End Sub)
   End Sub

#End Region

#Region "--------------Eventos SubSubRubros----------------"
   Private Sub btnInsertarSubSubRubro_Click(sender As Object, e As EventArgs) Handles btnInsertarSubSubRubro.Click
      TryCatched(
      Sub()
         If Not Me.bscCodigoRubro2.Selecciono And Not Me.bscNombreRubro2.Selecciono Then
            MessageBox.Show("Debe seleccionar un Rubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoRubro2.Focus()
            Return
         End If
         If Not Me.bscCodigoSubRubro2.Selecciono And Not Me.bscNombreSubRubro2.Selecciono Then
            MessageBox.Show("Debe seleccionar un SubRubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoSubRubro2.Focus()
            Return
         End If
         If Not Me.bscCodigoSubSubRubro2.Selecciono And Not Me.bscNombreSubSubRubro2.Selecciono Then
            MessageBox.Show("Debe seleccionar un SubSubRubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoSubSubRubro2.Focus()
            Return
         End If
         If Me.ExisteSubSubRubro(Int32.Parse(Me.bscCodigoSubSubRubro2.Text), Int32.Parse(Me.bscCodigoSubRubro2.Text), Int32.Parse(Me.bscCodigoRubro2.Text)) Then
            MessageBox.Show("Ya existe el SubSubRubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
         End If
         If Decimal.Parse(Me.txtDescuentoSubSubRubro.Text) = 0 Then
            MessageBox.Show("Ingrese un valor valido de Descuento/Recargo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtDescuentoSubSubRubro.Focus()
            Return
         End If
         If Decimal.Parse(Me.txtDescuentoSubSubRubro.Text) <= -100 Or Decimal.Parse(Me.txtDescuentoSubSubRubro.Text) >= 100 Then
            MessageBox.Show("El valor del  Descuento y el Recargo no debe ser mayor a 100", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtDescuentoSubSubRubro.Focus()
            Return
         End If
         AgregarSubSubRubro()

         bscCodigoRubro2.Text = ""
         bscNombreRubro2.Text = ""
         bscCodigoSubRubro2.Text = ""
         bscNombreSubRubro2.Text = ""
         bscCodigoSubSubRubro2.Text = ""
         bscNombreSubSubRubro2.Text = ""
         txtDescuentoSubSubRubro.Text = "0.00"
      End Sub)
   End Sub

   Private Sub AgregarSubSubRubro()

      Dim dr As DataRow = Me.DescuentosSubSubRubros.NewRow()

      dr("IdRubro") = Me.bscCodigoRubro2.Text
      dr("NombreRubro") = Me.bscNombreRubro2.Text
      dr("IdSubRubro") = Me.bscCodigoSubRubro2.Text
      dr("NombreSubRubro") = Me.bscNombreSubRubro2.Text
      dr("IdSubSubRubro") = Me.bscCodigoSubSubRubro2.Text
      dr("NombreSubSubRubro") = Me.bscNombreSubSubRubro2.Text
      dr("DescuentoRecargoPorc1") = Me.txtDescuentoSubSubRubro.Text

      Me.DescuentosSubSubRubros.Rows.Add(dr)

      Me.dgvComisionesSubSubRubros.DataSource = Me.DescuentosSubSubRubros
   End Sub
   Public ReadOnly Property DescuentosSubSubRubros() As DataTable
      Get
         If Categoria.DescuentoRecargoPorc1 IsNot Nothing Then
            If Categoria.DescuentoRecargoPorc1.Tables.Contains(Entidades.Categoria.DescuentosSubSubRubrosTableName) Then
               Return Categoria.DescuentoRecargoPorc1.Tables(Entidades.Categoria.DescuentosSubSubRubrosTableName)
            End If
         End If
         Return Nothing
      End Get
   End Property

   Private Function ExisteSubSubRubro(idSubSubRubro As Integer, idSubRubro As Integer, idRubro As Integer) As Boolean
      Return ExisteClavePrimariaSubSub(DescuentosSubSubRubros, "IdSubSubRubro", idSubSubRubro, "IdSubRubro", idSubRubro, "IdRubro", idRubro)
   End Function

   Private Function ExisteClavePrimariaSubSub(dt As DataTable, keyName0 As String, keyValue0 As Integer, keyName1 As String, keyValue1 As Integer, keyName2 As String, keyValue2 As Integer) As Boolean
      If dt IsNot Nothing Then
         For Each dr As DataRow In dt.Rows
            If dr.RowState <> DataRowState.Deleted Then
               If (Int32.Parse(dr(keyName0).ToString()) = keyValue0) And (Int32.Parse(dr(keyName1).ToString()) = keyValue1) And (Int32.Parse(dr(keyName2).ToString()) = keyValue2) Then
                  Return True
               End If
            End If
         Next
      End If
      Return False
   End Function


   Private Sub bscCodigoRubro2_BuscadorClick() Handles bscCodigoRubro2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaRubros2(bscCodigoRubro2)
         bscCodigoRubro2.Datos = New Reglas.Rubros().GetPorCodigo(bscCodigoRubro2.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub
   Private Sub bscNombreRubro2_BuscadorClick() Handles bscNombreRubro2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaRubros2(bscNombreRubro2)
         bscNombreRubro2.Datos = New Reglas.Rubros().GetPorNombre(bscNombreRubro2.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoRubro2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoRubro2.BuscadorSeleccion, bscNombreRubro2.BuscadorSeleccion
      TryCatched(Sub() CargarRubro(e.FilaDevuelta, bscCodigoRubro2, bscNombreRubro2, bscCodigoSubRubro2))
   End Sub
   Private Sub bscCodigoRubro2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bscCodigoRubro2.KeyPress, bscNombreRubro2.KeyPress
      PresionarTab(e)
   End Sub


   Private Sub bscCodigoSubRubro2_BuscadorClick() Handles bscCodigoSubRubro2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaSubRubros2(bscCodigoSubRubro2)
         bscCodigoSubRubro2.Datos = New Reglas.SubRubros().GetPorCodigo(bscCodigoRubro2.Text.ValorNumericoPorDefecto(0I),
                                                                           bscCodigoSubRubro2.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub
   Private Sub bscNombreSubRubro2_BuscadorClick() Handles bscNombreSubRubro2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaSubRubros2(bscNombreSubRubro2)
         bscNombreSubRubro2.Datos = New Reglas.SubRubros().GetPorNombre(bscCodigoRubro2.Text.ValorNumericoPorDefecto(0I), bscNombreSubRubro2.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoSubRubro2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoSubRubro2.BuscadorSeleccion, bscNombreSubRubro2.BuscadorSeleccion
      TryCatched(Sub() CargarSubRubro(e.FilaDevuelta, bscCodigoSubRubro2, bscNombreSubRubro2, bscCodigoRubro2, bscCodigoSubSubRubro2))
   End Sub
   Private Sub bscCodigoSubRubro2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bscCodigoSubRubro2.KeyPress, bscNombreSubRubro2.KeyPress
      PresionarTab(e)
   End Sub


   Private Sub bscCodigoSubSubRubro2_BuscadorClick() Handles bscCodigoSubSubRubro2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaSubSubRubros2(bscCodigoSubSubRubro2)
         bscCodigoSubSubRubro2.Datos = New Reglas.SubSubRubros().GetPorCodigo(bscCodigoRubro2.Text.ValorNumericoPorDefecto(0I),
                                                                                 bscCodigoSubRubro2.Text.ValorNumericoPorDefecto(0I),
                                                                                 bscCodigoSubSubRubro2.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub
   Private Sub bscNombreSubSubRubro2_BuscadorClick() Handles bscNombreSubSubRubro2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaSubSubRubros2(bscNombreSubSubRubro2)
         bscNombreSubSubRubro2.Datos = New Reglas.SubSubRubros().GetPorNombre(bscCodigoRubro2.Text.ValorNumericoPorDefecto(0I),
                                                                              bscCodigoSubRubro2.Text.ValorNumericoPorDefecto(0I),
                                                                              bscNombreSubSubRubro2.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoSubSubRubro2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoSubSubRubro2.BuscadorSeleccion, bscNombreSubSubRubro2.BuscadorSeleccion
      TryCatched(Sub() CargarSubSubRubro(e.FilaDevuelta, bscCodigoSubSubRubro2, bscNombreSubSubRubro2, bscCodigoSubRubro2, txtDescuentoSubSubRubro))
   End Sub
   Private Sub bscCodigoSubSubRubro2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bscCodigoSubSubRubro2.KeyPress, bscNombreSubSubRubro2.KeyPress
      PresionarTab(e)
   End Sub


   Private Sub btnRefrescarSubSubRubro_Click(sender As Object, e As EventArgs) Handles btnRefrescarSubSubRubro.Click
      TryCatched(
      Sub()
         bscCodigoRubro2.Text = ""
         bscNombreRubro2.Text = ""
         bscCodigoSubRubro2.Text = ""
         bscNombreSubRubro2.Text = ""
         bscCodigoSubSubRubro2.Text = ""
         bscNombreSubSubRubro2.Text = ""
         bscCodigoRubro2.Focus()

         txtDescuentoSubSubRubro.Text = "0.00"
      End Sub)
   End Sub
   Private Sub btnEliminarSubSubRubro_Click(sender As Object, e As EventArgs) Handles btnEliminarSubSubRubro.Click
      TryCatched(
      Sub()
         If Me.dgvComisionesSubSubRubros.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el item selecionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLinea(dgvComisionesSubSubRubros)
            End If
         End If
      End Sub)
   End Sub

   Private Sub dgvComisionesRubros_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvComisionesRubros.CellDoubleClick
      TryCatched(
      Sub()
         If Not Me.dgvComisionesRubros.Rows.Count > 0 Then Exit Sub
         '# Editar Rubro
         EditarRubro(Me.dgvComisionesRubros.Rows(e.RowIndex))
      End Sub)
   End Sub

   Private Sub dgvComisionesSubRubros_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvComisionesSubRubros.CellDoubleClick
      TryCatched(
      Sub()
         If Not Me.dgvComisionesSubRubros.Rows.Count > 0 Then Exit Sub
         '# Editar SubRubro
         EditarSubRubro(Me.dgvComisionesSubRubros.Rows(e.RowIndex))
      End Sub)
   End Sub

   Private Sub dgvComisionesSubSubRubros_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvComisionesSubSubRubros.CellDoubleClick
      TryCatched(
      Sub()
         If Not Me.dgvComisionesSubSubRubros.Rows.Count > 0 Then Exit Sub
         '# Editar SubSubRubro
         EditarSubSubRubro(Me.dgvComisionesSubSubRubros.Rows(e.RowIndex))
      End Sub)
   End Sub

#End Region

#Region "Evetos/Metodos Color"
   Private Sub chbBackColor_CheckedChanged(sender As Object, e As EventArgs) Handles chbBackColor.CheckedChanged
      TryCatched(
      Sub()
         btnBackColor.Enabled = chbBackColor.Checked
         If Not chbBackColor.Checked Then Categoria.BackColor = Nothing
         SetColor1()
      End Sub)
   End Sub
   Private Sub chbForeColor_CheckedChanged(sender As Object, e As EventArgs) Handles chbForeColor.CheckedChanged
      TryCatched(
      Sub()
         btnForeColor.Enabled = chbForeColor.Checked
         If Not chbForeColor.Checked Then Categoria.ForeColor = Nothing
         SetColor1()
      End Sub)
   End Sub



   Private Sub btnBackColor1_Click(sender As Object, e As EventArgs) Handles btnBackColor.Click
      TryCatched(
      Sub()
         Me.cdColor.Color = If(Categoria.BackColor.HasValue, Color.FromArgb(Categoria.BackColor.Value), Nothing)
         If Me.cdColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Categoria.BackColor = Me.cdColor.Color.ToArgb()
         Else
            Categoria.BackColor = Nothing
         End If
         SetColor1()
      End Sub)
   End Sub
   Private Sub btnForeColor1_Click(sender As Object, e As EventArgs) Handles btnForeColor.Click
      TryCatched(
      Sub()
         Me.cdColor.Color = If(Categoria.ForeColor.HasValue, Color.FromArgb(Categoria.ForeColor.Value), Nothing)
         If Me.cdColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Categoria.ForeColor = Me.cdColor.Color.ToArgb()
         Else
            Categoria.ForeColor = Nothing
         End If
         SetColor1()
      End Sub)
   End Sub
   Private Sub SetColor1()
      SetColor(txtColor, Categoria.BackColor, Categoria.ForeColor)
   End Sub
   Private Sub SetColor(txt As TextBox, backColor As Integer?, foreColor As Integer?)
      SetColor(txt, If(backColor.HasValue, Color.FromArgb(backColor.Value), Nothing), If(foreColor.HasValue, Color.FromArgb(foreColor.Value), Nothing))
   End Sub
   Private Sub SetColor(txt As TextBox, backColor As Color, foreColor As Color)
      txt.BackColor = backColor
      txt.ForeColor = foreColor
   End Sub

   Private Sub txtColor_Enter(sender As Object, e As EventArgs) Handles txtColor.Enter
      ProcessTabKey(True)
   End Sub

   Private Sub lblAdquiereAcciones_Click(sender As Object, e As EventArgs) Handles lblAdquiereAcciones.Click

   End Sub

#End Region

End Class