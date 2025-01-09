#Region "Option/Imports"
Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class ModificarComprasDetalle

   Private _tit As Dictionary(Of String, String)
   Private _Sucursal As Integer = 0
   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = Not Reglas.Publicos.ComprasIgnorarPCdeCaja
   Private _blnCajasModificables As Boolean = False

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.Compra)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

   Private _entidad As Entidades.Compra

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         _tit = GetColumnasVisiblesGrilla(ugIVAs)

         Dim pub As Publicos = New Publicos()

         pub.CargaComboTiposComprobantes(Me.cboTipoComprobante, True, "COMPRAS")

         pub.CargaComboPeriodosFiscales(Me.cboPeriodoFiscal, actual.Sucursal.IdEmpresa, "ABIERTO")
         If Me.cboPeriodoFiscal.Items.Count = 0 Then
            MessageBox.Show("NO Existen Periodos Fiscales Habilitados, no podra continuar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
         End If

         pub.CargaComboRubrosCompras(Me.cboRubro)
         pub.CargaComboEmpleados(Me.cmbComprador, Entidades.Publicos.TiposEmpleados.COMPRADOR)
         pub.CargaComboFormasDePago(Me.cboFormaPago, "COMPRAS")

         Me._Sucursal = Entidades.Usuario.Actual.Sucursal.Id

         pub.CargaComboCajas(Me.cmbCajas, Me._Sucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)

         Dim aTipoFactura As ArrayList = New ArrayList
         aTipoFactura.Insert(0, "A")
         aTipoFactura.Insert(1, "B")
         aTipoFactura.Insert(2, "C")
         aTipoFactura.Insert(3, "E")
         aTipoFactura.Insert(4, "M")
         aTipoFactura.Insert(5, "R")
         aTipoFactura.Insert(6, "X")
         Me.cboLetra.DataSource = aTipoFactura

         Me.CargarDatos()

         ugIVAs.AgregarTotalesSuma({"Bruto", "BaseImponible", "Importe"})

         Me.bscCodigoProveedor.TextBoxBackColor = txtTotalBruto.BackColor
         Me.bscProveedor.TextBoxBackColor = txtTotalBruto.BackColor

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Try
         If keyData = Keys.F4 Then
            tsbGrabar.PerformClick()
            Return True
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

#Region "Eventos"

   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click

      Try

         Dim sistema As Entidades.Sistema = Publicos.GetSistema()

         If DateDiff(DateInterval.Day, Me.dtpDesde.Value, sistema.FechaVencimiento) < 0 Then
            MessageBox.Show("La fecha es mayor a la validez del sistema, el " & sistema.FechaVencimiento.ToString("dd/MM/yyyy") & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpDesde.Focus()
            Exit Sub
         End If

         If _entidad.CentroEmisor <> Short.Parse(txtEmisorFactura.Text) Or _entidad.NumeroComprobante <> Long.Parse(txtNumeroFactura.Text) Then
            If ShowPregunta(String.Format("¿Está seguro de cambiar el Emisor y/o Número de la/el {1}?{0}{0}Esto acción va a recrear el comprobante.", Environment.NewLine, cboTipoComprobante.Text)) = Windows.Forms.DialogResult.No Then
               txtNumeroFactura.Focus()
               Exit Sub
            End If
         End If

         If Me.cmbCajas.SelectedIndex = -1 Then
            If Me._entidad.FormaPago.Dias = 0 Then
               MessageBox.Show("ATENCION: Debe Seleccionar una Caja.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Me.cmbCajas.Focus()
               Exit Sub
            End If
         End If

            Me.GrabarDatos()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnPercIIBB_Click(sender As Object, e As EventArgs) Handles btnPercIIBB.Click
      Try
         '_dtProvincias.AcceptChanges()
         Using frm As New MovimientosDeComprasPercepciones(_entidad.ComprasImpuestos.Where(Function(x) x.TipoTipoImpuesto = "PERCEPCION" And Not String.IsNullOrWhiteSpace(x.IdProvincia)).ToList())
            frm.ShowDialog()
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatos()

      Const formato As String = "#,##0.00"

      With Me._entidad

         Me.bscCodigoProveedor.Text = .Proveedor.CodigoProveedor.ToString()
         Me.bscCodigoProveedor.Tag = .Proveedor.IdProveedor.ToString()
         Me.bscProveedor.Text = .Proveedor.NombreProveedor.ToString()
         Me.txtCategoriaFiscal.Text = .Proveedor.CategoriaFiscal.NombreCategoriaFiscal

         Me.cboTipoComprobante.SelectedValue = .TipoComprobante.IdTipoComprobante.ToString()
         Me.cboLetra.Text = .Letra.ToString()
         Me.txtEmisorFactura.Text = .CentroEmisor.ToString()
         Me.txtNumeroFactura.Text = .NumeroComprobante.ToString()
         Me.dtpDesde.Value = .Fecha

         If .TipoComprobante.GrabaLibro Then
            Me.cboPeriodoFiscal.SelectedValue = .PeriodoFiscal
         Else
            Me.cboPeriodoFiscal.Enabled = False
         End If

         Me.cmbComprador.Text = .Comprador.NombreEmpleado.ToString()
         Me.cboRubro.SelectedValue = .Rubro.IdRubro.ToString()

         Me.txtObservacion.Text = .Observacion.ToString()

         Me.cboFormaPago.SelectedValue = .FormaPago.IdFormasPago

         '-- REQ-30902 --
         Me.cmbCajas.SelectedValue = .IdCaja
         Me.cmbCajas.Enabled = .FormaPago.Dias = 0
         '---------------
         ugIVAs.DataSource = .ComprasImpuestos.Where(Function(x) x.TipoTipoImpuesto = "IVA").ToArray()
         AjustarColumnasGrilla(ugIVAs, _tit)

         Me.txtPorcDescRecargoGral.Text = .DescuentoRecargoPorc.ToString()
         Me.txtPercepcionIVA.Text = .PercepcionIVA.ToString(formato)
         Me.txtPercepcionIB.Text = .PercepcionIB.ToString(formato)
         Me.txtPercepcionGanancias.Text = .PercepcionGanancias.ToString(formato)
         Me.txtPercepcionVarias.Text = .PercepcionVarias.ToString(formato)
         Me.txtPercepcionTotal.Text = (.PercepcionIVA + .PercepcionIB + .PercepcionGanancias + .PercepcionVarias).ToString(formato)
         Me.txtTotalBruto.Text = (.TotalBruto).ToString(formato)
         Me.txtTotalNeto.Text = (.TotalNeto).ToString(formato)
         Me.txtTotalPercepciones.Text = Me.txtPercepcionTotal.Text
         Me.txtTotalIVA.Text = (.TotalIVA).ToString(formato)
         Me.txtTotalGeneral.Text = .ImporteTotal.ToString(formato)


         txtEmisorFactura.Enabled = Not .IdAsiento.HasValue
         txtNumeroFactura.Enabled = Not .IdAsiento.HasValue

         '-.PE-31850.-
         Me.chbMercaderiaEnviada.Checked = .MercEnviada


         '# Si el combo está index -1 = El período fiscal está cerrado
         '# Si el combo está deshabilitado = El comprobante no graba libro
         If Me.cboPeriodoFiscal.Enabled AndAlso Me.cboPeriodoFiscal.SelectedIndex = -1 Then
            Me.cboPeriodoFiscal.Enabled = False

            '# Si el comprobante informa libro iva Y el período fiscal está cerrado, no permito modificar la numeración del comprobante.
            If .TipoComprobante.InformaLibroIVA Then
               Me.txtEmisorFactura.Enabled = False
               Me.txtNumeroFactura.Enabled = False
            End If
         End If
      End With


   End Sub

   Private Sub GrabarDatos()

      With Me._entidad
         .Fecha = Me.dtpDesde.Value
         'If .TipoComprobante.EsComercial Then

         '######################################################################################################################################
         '# Se quita la verificación de si es un comprobante comercial o no ya que el periodo es usado en contabilidad y no afecta los libros. #
         '######################################################################################################################################

         .IdEmpresa = actual.Sucursal.IdEmpresa
         If .TipoComprobante.GrabaLibro Then
            If cboPeriodoFiscal.Enabled Then
               .PeriodoFiscal = Integer.Parse(Me.cboPeriodoFiscal.SelectedValue.ToString())
            End If
         Else
            .PeriodoFiscal = Integer.Parse(.Fecha.ToString("yyyyMM"))
         End If
         'End If

         .Comprador = DirectCast(Me.cmbComprador.SelectedItem, Entidades.Empleado)
         .Rubro = New Reglas.RubrosCompras().GetUno(Integer.Parse(Me.cboRubro.SelectedValue.ToString()))
         .Observacion = Me.txtObservacion.Text
         '-.PE-31850.-
         .MercEnviada = Me.chbMercaderiaEnviada.Checked

         'Se puede cambiar la caja si es contado. 
         'GAR: 17/07/2019. Pero tambien puede pasar que venga sin caja y obligamos a cargarla.
         If .FormaPago.Dias = 0 Then
            .IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())
         End If

         With DirectCast(_entidad, Entidades.IComprobanteComprasModificable)
            If _entidad.CentroEmisor <> Short.Parse(txtEmisorFactura.Text) Or _entidad.NumeroComprobante <> Long.Parse(txtNumeroFactura.Text) Then
               .IdSucursalNuevo = _entidad.IdSucursal
               .IdTipoComprobanteNuevo = _entidad.TipoComprobante.IdTipoComprobante
               .LetraNuevo = _entidad.Letra
               .CentroEmisorNuevo = Short.Parse(txtEmisorFactura.Text)
               .NumeroComprobanteNuevo = Long.Parse(txtNumeroFactura.Text)
               .IdProveedorNuevo = _entidad.Proveedor.IdProveedor
            Else
               .LimpiaModificable()
            End If
         End With

      End With

      Dim reg As Reglas.Compras = New Reglas.Compras()

      reg.ModificaCompra(Me._entidad)

      MessageBox.Show("Se grabo correctamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Me.Close()

   End Sub

#End Region
End Class