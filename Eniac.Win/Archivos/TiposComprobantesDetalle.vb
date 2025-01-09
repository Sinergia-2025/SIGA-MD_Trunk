Public Class TiposComprobantesDetalle

   Private ReadOnly Property TipoComprobante As Entidades.TipoComprobante
      Get
         Return DirectCast(_entidad, Entidades.TipoComprobante)
      End Get
   End Property


#Region "Campos"

   Private _publicos As Publicos
   Private _productos As New List(Of Entidades.TipoComprobanteProducto)()
#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.TipoComprobante)
      InitializeComponent()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      _publicos = New Publicos()

      _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, False, "TODOS", "")
      _publicos.CargaComboTiposComprobantes(cmbTipoComprobanteNCred, False, "TODOS", "")
      _publicos.CargaComboTiposComprobantes(cmbTipoComprobanteNDeb, False, "TODOS", "")
      _publicos.CargaComboTiposComprobantes(cmbTipoComprobanteContraMovInvocar, False, "TODOS", "")

      _publicos.CargaComboDesdeEnum(cmbAFIPWSIncluyeFechaVencimiento, GetType(Entidades.Publicos.SiNoDefault))
      _publicos.CargaComboDesdeEnum(cmbClaseComprobante, GetType(Entidades.TipoComprobante.ClasesComprobante))

      CargarComprobantesHabilitados()
      FormatearGrillaComprobantesAsociados()

      'Dim blnMiraUsuario As Boolean = False, blnMiraPC As Boolean = False, blnCajasModificables As Boolean = False

      tbcComporbantes.SelectedTab = tbpCompAsoci
      tbcComporbantes.SelectedTab = tbpProducto
      tbcComporbantes.SelectedTab = tbpAFIP
      tbcComporbantes.SelectedTab = tbpDetalle

      BindearControles(Me._entidad)

      If Me.StateForm = Win.StateForm.Actualizar Then
         If TipoComprobante.ComprobantesAsociados IsNot Nothing Then
            CargarCampos()
         End If


         ugProductoDetalle.DataSource = TipoComprobante.Productos
         _productos = TipoComprobante.Productos
         FormatearGrilla()

         chbComprobanteSecundario.Checked = TipoComprobante.IdTipoComprobanteSecundario <> ""
         chbInformaLibroIVA.Checked = TipoComprobante.InformaLibroIVA
         chbTipoComprobanteNDeb.Checked = TipoComprobante.IdTipoComprobanteNCred <> ""
         chbTipoComprobanteNCred.Checked = TipoComprobante.IdTipoComprobanteNDeb <> ""
         chbCodigoProducto2Cred.Checked = TipoComprobante.IdProductoNCred <> ""
         chbCodigoProducto2Deb.Checked = TipoComprobante.IdProductoNDeb <> ""
         chbTipoComprobanteContraMovInvocar.Checked = TipoComprobante.IdTipoComprobanteContraMovInvocar <> ""

         bscCodigoProducto2Cred.Text = TipoComprobante.IdProductoNCred
         bscCodigoProducto2Cred.PresionarBoton()
         bscCodigoProducto2Deb.Text = TipoComprobante.IdProductoNDeb
         bscCodigoProducto2Deb.PresionarBoton()

         txtNivelAutorizacion.Visible = New Reglas.Usuarios().TienePermisos("Comprobantes-NivelAutorizacion")
         txtNivelAutorizacion.LabelAsoc.Visible = txtNivelAutorizacion.Visible

         '-- REQ-30773 --
         chbActivaTildeMercDespEnv.Checked = TipoComprobante.ActivaTildeMercDespacha

         chbColor.Checked = TipoComprobante.Color.HasValue
         If TipoComprobante.Color.HasValue Then
            txtColor.BackColor = Color.FromArgb(TipoComprobante.Color.Value)
         Else
            txtColor.BackColor = Nothing
         End If

      Else
         txtOrdenTipoComprobante.Text = "1"
         '-- REQ-30773 --
         chbActivaTildeMercDespEnv.Checked = False
         chbActivaTildeMercDespEnv.Enabled = True
         '-- REQ-40445 --
         chbSolicitaInformeCalidad.Checked = True
      End If

      If TipoComprobante.AFIPWSIncluyeFechaVencimiento.HasValue Then
         If TipoComprobante.AFIPWSIncluyeFechaVencimiento.Value Then
            cmbAFIPWSIncluyeFechaVencimiento.SelectedValue = Entidades.Publicos.SiNoDefault.SI
         Else
            cmbAFIPWSIncluyeFechaVencimiento.SelectedValue = Entidades.Publicos.SiNoDefault.NO
         End If
      Else
         cmbAFIPWSIncluyeFechaVencimiento.SelectedValue = Entidades.Publicos.SiNoDefault.DEFAULT
      End If
      '-- REQ-35059.- --------------------------------------------------------------------------
      txtCodigoRoela.Text = TipoComprobante.CodigoRoela
      '-----------------------------------------------------------------------------------------
      If Not Publicos.TieneModuloContabilidad Then
         chbUtilizaCtaSecundariaProd.Checked = False
         chbUtilizaCtaSecundariaCateg.Checked = False
         chbUtilizaCtaSecundariaProd.Enabled = False
         chbUtilizaCtaSecundariaCateg.Enabled = False
      Else
         If Not Reglas.ContabilidadPublicos.ContabilidadCuentaSecundariaProducto Then
            chbUtilizaCtaSecundariaProd.Checked = False
            chbUtilizaCtaSecundariaProd.Enabled = False
         End If
         If Not Reglas.ContabilidadPublicos.ContabilidadCuentaSecundariaCategoria Then
            chbUtilizaCtaSecundariaCateg.Checked = False
            chbUtilizaCtaSecundariaCateg.Enabled = False
         End If
      End If

      chbPermiteSeleccionarAlicuotaIVA.Enabled = Reglas.Publicos.ProductoUtilizaAlicuota2

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TiposComprobantes()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      Dim vacio = String.Empty

      If txtIdPlanCuenta.Text = "0" Then
         Return "Plan de cuenta no válido"
      End If
      If txtLargoMaximoNumero.Text = "0" Then
         Return "El valor del Largo máximo del número, no es valido"
      End If


      If txtNivelAutorizacion.Visible Then
         If Not IsNumeric(txtNivelAutorizacion.Text) Then txtNivelAutorizacion.Text = "1"
         If txtNivelAutorizacion.ValorNumericoPorDefecto(1S) > actual.NivelAutorizacion Then
            txtNivelAutorizacion.Focus()
            Return "ATENCION: El nivel de autorización ingresado es superior al suyo."
         End If         'If Short.Parse(txtNivelAutorizacion.Text) > actual.NivelAutorizacion Then
      End If            'If txtNivelAutorizacion.Visible Then

      Return vacio

   End Function
   Private Function ValidaDatosTipoComprobante() As Boolean

      '-- Valida que solo un comprobante tenga la letra.-
      If Not String.IsNullOrEmpty(txtCodigoRoela.Text) And New Reglas.TiposComprobantes().GetCodigoRoelaComprobantes(txtCodigoRoela.Text, txtCategoria.Text.ToUpper()).Count > 0 Then
         ShowMessage("El Codigo Especificado ya esta asignado!!!.")
         Return False
      End If
      Return True
   End Function

   Protected Overrides Sub Aceptar()
      If ValidaDatosTipoComprobante() Then
         Dim cmp = String.Empty
         For Each row As DataRow In DirectCast(ugComprobantesAsociados.DataSource, DataTable).Rows
            If row("Selecciono").ToString() = Boolean.TrueString Then
               cmp += String.Format("''{0}'',", row.Field(Of String)(Entidades.TipoComprobante.Columnas.IdTipoComprobante.ToString()))
            End If
         Next
         If cmp <> "" Then
            TipoComprobante.ComprobantesAsociados = cmp.Trim(","c)
         Else
            TipoComprobante.ComprobantesAsociados = String.Empty
         End If

         If chbCodigoProducto2Cred.Checked Then
            TipoComprobante.IdProductoNCred = bscCodigoProducto2Cred.Text
         Else
            TipoComprobante.IdProductoNCred = String.Empty
         End If

         If chbCodigoProducto2Deb.Checked Then
            TipoComprobante.IdProductoNDeb = bscCodigoProducto2Deb.Text
         Else
            TipoComprobante.IdProductoNDeb = String.Empty
         End If

         TipoComprobante.InformaLibroIVA = chbInformaLibroIVA.Checked

         TipoComprobante.Productos = _productos

         If cmbAFIPWSIncluyeFechaVencimiento.ValorSeleccionado(Of Entidades.Publicos.SiNoDefault) = Entidades.Publicos.SiNoDefault.DEFAULT Then
            TipoComprobante.AFIPWSIncluyeFechaVencimiento = Nothing
         Else
            TipoComprobante.AFIPWSIncluyeFechaVencimiento = cmbAFIPWSIncluyeFechaVencimiento.ValorSeleccionado(Of Entidades.Publicos.SiNoDefault) = Entidades.Publicos.SiNoDefault.SI
         End If
         '-- REQ-30773 --
         TipoComprobante.ActivaTildeMercDespacha = chbActivaTildeMercDespEnv.Checked
         TipoComprobante.CodigoRoela = txtCodigoRoela.Text.ToUpper()
         MyBase.Aceptar()
      Else
         HayError = True
         tbcComporbantes.SelectedTab = tbpExportaciones
         txtCodigoRoela.Select()
      End If

   End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtCategoria.Focus()
   End Sub

   Private Sub chbComprobanteSecundario_CheckedChanged(sender As Object, e As EventArgs) Handles chbComprobanteSecundario.CheckedChanged

      If Not chbComprobanteSecundario.Checked Then
         cmbTiposComprobantes.SelectedIndex = -1
         TipoComprobante.IdTipoComprobanteSecundario = ""
      End If

      cmbTiposComprobantes.Enabled = Me.chbComprobanteSecundario.Checked

      If chbComprobanteSecundario.Checked Then
         cmbTiposComprobantes.Focus()
      End If

   End Sub

   Private Sub chbTipoComprobanteContraMovInvocar_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobanteContraMovInvocar.CheckedChanged

      If Not chbTipoComprobanteContraMovInvocar.Checked Then
         cmbTipoComprobanteContraMovInvocar.SelectedIndex = -1
         TipoComprobante.IdTipoComprobanteContraMovInvocar = ""
      End If

      cmbTipoComprobanteContraMovInvocar.Enabled = chbTipoComprobanteContraMovInvocar.Checked

      If chbTipoComprobanteContraMovInvocar.Checked Then
         cmbTipoComprobanteContraMovInvocar.Focus()
      End If

   End Sub

   Private Sub chbTipoComprobanteNCred_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobanteNCred.CheckedChanged
      If Not chbTipoComprobanteNCred.Checked Then
         cmbTipoComprobanteNCred.SelectedIndex = -1
         TipoComprobante.IdTipoComprobanteNCred = ""
      End If

      cmbTipoComprobanteNCred.Enabled = chbTipoComprobanteNCred.Checked

      If chbTipoComprobanteNCred.Checked Then
         cmbTipoComprobanteNCred.Focus()
      End If
   End Sub

   Private Sub chbTipoComprobanteNDeb_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobanteNDeb.CheckedChanged
      If Not chbTipoComprobanteNDeb.Checked Then
         cmbTipoComprobanteNDeb.SelectedIndex = -1
         TipoComprobante.IdTipoComprobanteNDeb = ""
      End If

      cmbTipoComprobanteNDeb.Enabled = chbTipoComprobanteNDeb.Checked

      If chbTipoComprobanteNDeb.Checked Then
         cmbTipoComprobanteNDeb.Focus()
      End If
   End Sub

   Private Sub chbCodigoProducto2Cred_CheckedChanged(sender As Object, e As EventArgs) Handles chbCodigoProducto2Cred.CheckedChanged
      If Not chbCodigoProducto2Cred.Checked Then
         bscCodigoProducto2Cred.Text = ""
         bscCodigoProducto2Cred.Tag = ""
         bscProducto2Cred.Text = ""
         TipoComprobante.IdProductoNCred = ""
      End If

      bscCodigoProducto2Cred.Enabled = chbCodigoProducto2Cred.Checked
      bscProducto2Cred.Enabled = chbCodigoProducto2Cred.Checked

      If chbCodigoProducto2Cred.Checked Then
         bscCodigoProducto2Cred.Focus()
      End If
   End Sub

   Private Sub chbCodigoProducto2Deb_CheckedChanged(sender As Object, e As EventArgs) Handles chbCodigoProducto2Deb.CheckedChanged
      If Not chbCodigoProducto2Deb.Checked Then
         bscCodigoProducto2Deb.Text = ""
         bscCodigoProducto2Deb.Tag = ""
         bscProducto2Deb.Text = ""
         TipoComprobante.IdProductoNCred = ""
      End If

      bscCodigoProducto2Deb.Enabled = chbCodigoProducto2Deb.Checked
      bscProducto2Deb.Enabled = chbCodigoProducto2Deb.Checked

      If chbCodigoProducto2Deb.Checked Then
         bscCodigoProducto2Deb.Focus()
      End If
   End Sub

   Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
      TryCatched(
         Sub()
            cdColor.Color = txtColor.BackColor

            If cdColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
               TipoComprobante.Color = cdColor.Color.ToArgb()
               txtColor.Key = TipoComprobante.Color.ToString()
               txtColor.BackColor = cdColor.Color
            End If
         End Sub)
   End Sub

   Private Sub chbColor_CheckedChanged(sender As Object, e As EventArgs) Handles chbColor.CheckedChanged
      TryCatched(
         Sub()
            btnColor.Enabled = chbColor.Checked
            If Not chbColor.Checked Then
               TipoComprobante.Color = Nothing
               txtColor.Key = Nothing
               txtColor.BackColor = Nothing

            End If
         End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub FormatearGrillaComprobantesAsociados()

      Dim pos = 0I
      With ugComprobantesAsociados.DisplayLayout.Bands(0)
         For Each col As UltraGridColumn In .Columns
            col.Hidden = True
            col.CellActivation = Activation.ActivateOnly
         Next
         .Columns("Selecciono").FormatearColumna("S", pos, 30, HAlign.Center, False).CellActivation = Activation.AllowEdit
         .Columns(Entidades.TipoComprobante.Columnas.IdTipoComprobante.ToString()).FormatearColumna("Comprobante", pos, 180, HAlign.Left, False)
         .Columns(Entidades.TipoComprobante.Columnas.Descripcion.ToString()).FormatearColumna("Descripción", pos, 200, HAlign.Left, False)
         .Columns(Entidades.TipoComprobante.Columnas.Grupo.ToString()).FormatearColumna("Grupo", pos, 100, HAlign.Left, False)
         .Columns(Entidades.TipoComprobante.Columnas.Tipo.ToString()).FormatearColumna("Tipo", pos, 100, HAlign.Left, False)
         .Columns("GrabaLibro_SN").FormatearColumna("Graba Libro", pos, 75, HAlign.Center, False)
         .Columns("EsRecibo_SN").FormatearColumna("Es Recibo", pos, 75, HAlign.Center, False)

         .Columns(Entidades.TipoComprobante.Columnas.ActivaTildeMercDespacha.ToString()).FormatearColumna("Despacha", pos, 70, HAlign.Center, False)

      End With

      '# Filtros Contiene
      ugComprobantesAsociados.AgregarFiltroEnLinea({Entidades.TipoComprobante.Columnas.IdTipoComprobante.ToString(),
                                                    Entidades.TipoComprobante.Columnas.Descripcion.ToString()})
   End Sub

   Private Sub CargarComprobantesHabilitados()

      Dim rTiposComprobantes = New Reglas.TiposComprobantes()
      Dim cms = rTiposComprobantes.GetAll()

      cms.Columns.Add("Selecciono", GetType(Boolean))
      For Each dr As DataRow In cms.Rows
         dr("Selecciono") = False
      Next

      ugComprobantesAsociados.DataSource = cms

   End Sub

   Private Sub CargarCampos()

      '# Cargo los Tipos de Comprobantes Asociados
      Dim dt = DirectCast(ugComprobantesAsociados.DataSource, DataTable)
      Dim comp() As String
      comp = TipoComprobante.ComprobantesAsociados.Split(","c)

      Try
         For Each comprobante In comp
            For Each row In dt.Select(String.Format("IdTipoComprobante = {0}", comprobante))
               row("Selecciono") = True
            Next
         Next
         ugComprobantesAsociados.UpdateData()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#End Region

#Region "Credito y Debito Producto"

#Region "Producto Credito"
   Private Sub bscCodigoProducto2Cred_BuscadorClick() Handles bscCodigoProducto2Cred.BuscadorClick
      Try
         Dim rProductos = New Reglas.Productos()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto2Cred)
         bscCodigoProducto2Cred.Datos = rProductos.GetPorCodigo(bscCodigoProducto2Cred.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProducto2Cred_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2Cred.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosProductoCred(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProducto2Cred_BuscadorClick() Handles bscProducto2Cred.BuscadorClick
      Try
         Dim rProductos = New Reglas.Productos()
         _publicos.PreparaGrillaProductos2(bscProducto2Cred)
         bscProducto2Cred.Datos = rProductos.GetPorNombre(bscProducto2Cred.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProducto2Cred_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2Cred.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosProductoCred(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub CargarDatosProductoCred(dr As DataGridViewRow)
      bscProducto2Cred.Text = dr.Cells("NombreProducto").Value.ToString()
      bscCodigoProducto2Cred.Text = dr.Cells("IdProducto").Value.ToString.Trim()
   End Sub
#End Region

#Region "Producto Debito"
   Private Sub bscCodigoProducto2Deb_BuscadorClick() Handles bscCodigoProducto2Deb.BuscadorClick
      Try
         Dim rProductos = New Reglas.Productos()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto2Deb)
         bscCodigoProducto2Deb.Datos = rProductos.GetPorCodigo(bscCodigoProducto2Deb.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProducto2Deb_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2Deb.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosProductoDeb(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProducto2Deb_BuscadorClick() Handles bscProducto2Deb.BuscadorClick
      Try
         Dim oProductos = New Reglas.Productos()
         _publicos.PreparaGrillaProductos2(bscProducto2Deb)
         bscProducto2Deb.Datos = oProductos.GetPorNombre(bscProducto2Deb.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProducto2Deb_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2Deb.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosProductoDeb(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub CargarDatosProductoDeb(dr As DataGridViewRow)
      bscProducto2Deb.Text = dr.Cells("NombreProducto").Value.ToString()
      bscCodigoProducto2Deb.Text = dr.Cells("IdProducto").Value.ToString.Trim()
   End Sub
#End Region

#End Region

#Region "Metodo y Eventos de Productos Grilla"

   Public Sub FormatearGrilla()
      ugProductoDetalle.DisplayLayout.UseFixedHeaders = True
      ugProductoDetalle.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None
      Dim pos = 0I
      With ugProductoDetalle.DisplayLayout.Bands(0)

         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
            columna.CellActivation = Activation.NoEdit
         Next

         .Columns("IdProducto").FormatearColumna("Código", pos, 100)
         .Columns("NombreProducto").FormatearColumna("Producto", pos, 450)
         .Columns("Cantidad").FormatearColumna("Cantidad", pos, 90, HAlign.Right)

         ugProductoDetalle.AgregarFiltroEnLinea({"NombreProducto"})
      End With
   End Sub

   Private Sub ugProductoDetalle_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugProductoDetalle.DoubleClickRow
      Try
         Dim row = ActiveSelectProduct()
         If row IsNot Nothing Then
            bscCodigoProducto2.Text = row.IdProducto
            bscProducto2.Text = row.NombreProducto
            txtCantidad.Text = row.Cantidad.ToString()
            _productos.Remove(row)
            ugProductoDetalle.Rows.Refresh(RefreshRow.ReloadData)
            bscCodigoProducto2.PresionarBoton()
            txtCantidad.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnInsertarProducto_Click(sender As Object, e As EventArgs) Handles btnInsertarProducto.Click
      Try
         If (Not bscProducto2.FilaDevuelta Is Nothing Or Not bscCodigoProducto2.FilaDevuelta Is Nothing) And txtCantidad.Text <> "" Then
            If ValidarInsertaProducto() Then
               InsertarProducto()
               FormatearGrilla()
               LimpiarCamposProductos()
               txtCantidad.Text = "1.00"
               bscCodigoProducto2.Focus()

            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnEliminarContacto_Click(sender As Object, e As EventArgs) Handles btnEliminarContacto.Click
      Try
         Dim row = ActiveSelectProduct()
         If row IsNot Nothing Then
            If MessageBox.Show("¿Desea eliminar el registro seleccionado?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               _productos.Remove(row)
               ugProductoDetalle.Rows.Refresh(RefreshRow.ReloadData)
               bscCodigoProducto2.Focus()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub LimpiarCamposProductos()
      bscCodigoProducto2.Enabled = True
      bscCodigoProducto2.Text = ""
      bscCodigoProducto2.FilaDevuelta = Nothing
      bscProducto2.Enabled = True
      bscProducto2.Text = ""
      bscProducto2.FilaDevuelta = Nothing
      txtCantidad.Text = "1.00"
   End Sub

   Private Sub btnLimpiarProducto_Click(sender As Object, e As EventArgs) Handles btnLimpiarProducto.Click
      LimpiarCamposProductos()
      txtCantidad.Text = "1.00"
      bscCodigoProducto2.Focus()

   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim rProductos = New Reglas.Productos()
         _publicos.PreparaGrillaProductos2(Me.bscProducto2)
         bscProducto2.Datos = rProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
         txtCantidad.Text = "1.00"
         txtCantidad.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos = New Reglas.Productos()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
         bscCodigoProducto2.Datos = oProductos.GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
         txtCantidad.Text = "1.00"
         txtCantidad.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub InsertarProducto()

      For Each Row As Entidades.TipoComprobanteProducto In _productos
         If Row.IdProducto = bscCodigoProducto2.Text Then
            Throw New Exception("El producto seleccionado ya se encuentra en la colección.")
         End If
      Next

      Dim oProduct As Entidades.TipoComprobanteProducto = New Entidades.TipoComprobanteProducto()
      With oProduct
         .IdProducto = bscCodigoProducto2.Text
         .NombreProducto = bscProducto2.Text
         If Decimal.Parse(txtCantidad.Text) > 0 Then
            .Cantidad = Decimal.Parse(txtCantidad.Text)
         End If
      End With

      _productos.Add(oProduct)
      ugProductoDetalle.DataSource = _productos
      ugProductoDetalle.Rows.Refresh(RefreshRow.ReloadData)


   End Sub

   Private Function ValidarInsertaProducto() As Boolean
      If txtCantidad.Text = "" Then
         MessageBox.Show("No puede ingresar sin cantidad.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         txtCantidad.Focus()
         Return False
      End If

      If Decimal.Parse(txtCantidad.Text) = 0 Then
         MessageBox.Show("La cantidad debe ser distinta de cero.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         txtCantidad.Focus()
         Return False
      End If
      If txtCategoria.Text.Trim.Length = 0 Then
         MessageBox.Show("No puede ingresar sin Tipo de Comprobantes", Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         txtCategoria.Focus()
         Return False
      End If
      If bscCodigoProducto2.Text.Trim.Length = 0 Then
         MessageBox.Show("No puede ingresar sin Codigo de Producto.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         bscCodigoProducto2.Focus()
         Return False
      End If
      If bscProducto2.Text.Trim.Length = 0 Then
         MessageBox.Show("No puede ingresar sin Producto.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         bscProducto2.Focus()
         Return False
      End If
      Return True
   End Function

   Private Sub CargarDatosProducto(dr As DataGridViewRow)
      bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
   End Sub

   Private Function ActiveSelectProduct() As Entidades.TipoComprobanteProducto
      Return ugProductoDetalle.FilaSeleccionada(Of Entidades.TipoComprobanteProducto)()
   End Function

#End Region

End Class