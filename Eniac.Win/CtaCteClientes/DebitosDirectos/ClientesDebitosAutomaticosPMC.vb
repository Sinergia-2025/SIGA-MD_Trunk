Imports System.Xml
Public Class ClientesDebitosAutomaticosPMC

#Region "Campos"

   Private _publicos As Publicos
   Private _detalle As DataTable
   Private _banco As Entidades.Banco
   Private _cobrador As Entidades.Empleado
   Private _tieneModuloCargos As Boolean
   ' Private _roela As Boolean = True
   Private _FormatoPMC As Entidades.CuentaCorriente.FormatoPMC
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            cmbCategorias.Inicializar(False)
            _publicos.CargaComboDesdeEnum(cmbFormato, GetType(Entidades.CuentaCorriente.FormatoPMC))
            cmbFormato.SelectedValue = Reglas.Publicos.CtaCte.PMCFormato

            _publicos.CargaComboDesdeEnum(cmbTodos, GetType(Reglas.Publicos.TodosEnum))

            'TODO: DB
            ' ''Dim existeAlgunaFoto As Boolean = New Reglas.Liquidaciones().ExisteFoto(0, Nothing)
            ' ''chbTomaFoto.Visible = existeAlgunaFoto
            ' ''chbTomaFoto.Checked = False ' existeAlgunaFoto
            _tieneModuloCargos = Reglas.Publicos.TieneModuloCargos

            If _tieneModuloCargos Then
               _publicos.CargaComboTiposLiquidacion(cmbTiposLiquidacion)
               cmbTiposLiquidacion.SelectedIndex = 0
               chbCargo.Checked = True
            Else
               chbCargo.Visible = False
               chbPeriodo.Visible = False
               dtpPeriodo.Visible = False
               lblTipoLiquidacion.Visible = False
               cmbTiposLiquidacion.Visible = False
            End If

            ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "Observacion"})

            tssRegistros.Text = ""
         End Sub)

   End Sub

#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, String.Empty))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, String.Empty))
   End Sub

   Private Sub tsbGenerar_Click(sender As Object, e As EventArgs) Handles tsbGenerar.Click
      TryCatched(
         Sub()
            ugDetalle.UpdateData()
            ugDetalle.EndUpdate()

            Dim Cant As Integer = 0
            For Each dr As UltraGridRow In ugDetalle.Rows
               If dr.Cells("Selec").Value IsNot Nothing AndAlso Boolean.Parse(dr.Cells("Selec").Value.ToString()) Then
                  Cant = Cant + 1
               End If
            Next

            If Cant = 0 Then
               MessageBox.Show("ATENCION: NO Seleccionó Ningún Registro !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If


            If dtpFechaVencimiento.Value.Subtract(Date.Now).Days < 2 Then
               MessageBox.Show("ATENCION: Va a Generar los Débito a Clientes con Fecha menor a 2 Dias Habiles!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            If Reglas.Publicos.CtaCte.NumeroEmpresaBanelco = 0 And _FormatoPMC = Entidades.CuentaCorriente.FormatoPMC.PMC Then
               MessageBox.Show("ATENCION: Debe ingresar el Número de Empresa Banelco en Parámetros.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If

            If chbEsRefinanciado.Checked AndAlso (String.IsNullOrEmpty(Me.txtNroRefinancion.Text.ToString()) Or Integer.Parse(Me.txtNroRefinancion.Text.ToString()) < 2) Then
               MessageBox.Show("ATENCION: Si seleccionó Es Refinanciado NO puede ingresar 0-1 !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If

            Dim stb = New StringBuilder()

            stb.AppendFormat("¿Realmente desea generar el archivo para el Banco?", Me.ugDetalle.Rows.Count.ToString())

            If MessageBox.Show(stb.ToString(), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Dim dga As SaveFileDialog = New SaveFileDialog()

               dga.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
               dga.Filter = "Todos los Archivos (*.*)|*.*" ''"Archivos de Texto (*.txt)|*.txt|Todos los Archivos (*.*)|*.*"
               dga.FilterIndex = 1

               If _FormatoPMC = Entidades.CuentaCorriente.FormatoPMC.PMC Then
                  dga.FileName = "FAC" & Reglas.Publicos.CtaCte.NumeroEmpresaBanelco & "." & dtpFechaVencimiento.Value.ToString("ddMMyy")
               ElseIf _FormatoPMC = Entidades.CuentaCorriente.FormatoPMC.ROELAPMC Then
                  dga.FileName = Reglas.Publicos.CuitEmpresa & "." & dtpFechaVencimiento.Value.ToString("yyyyMMdd")
               Else
                  dga.FileName = "envio_sirplus_" & Reglas.Publicos.TurismoSIRPLUSRazonSocial.ToString() & "_" & Date.Now.ToString("yyyyMMdd") & ".xml"
               End If


               dga.RestoreDirectory = True

               If dga.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  If Not String.IsNullOrEmpty(dga.FileName) Then
                     Me.Generar(dga.FileName)
                  End If
               End If
            Else
               MessageBox.Show("Ha cancelado la exportación.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
         End Sub)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

   Private Sub ugDetalle_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout

      e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow

      e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)

      e.Layout.Override.SpecialRowSeparatorHeight = 6

      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft

      e.Layout.ViewStyle = ViewStyle.SingleBand

      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            CargaGrillaDetalle()

            If ugDetalle.Rows.Count > 0 Then
               btnConsultar.Focus()
            Else
               MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
         End Sub)
   End Sub

   Private Sub chbPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles chbPeriodo.CheckedChanged
      TryCatched(
         Sub()
            If chbPeriodo.Checked Then
               dtpPeriodo.Enabled = True
            Else
               dtpPeriodo.Enabled = False
            End If
         End Sub)
   End Sub

   Private Sub chbCargo_CheckedChanged(sender As Object, e As EventArgs) Handles chbCargo.CheckedChanged
      TryCatched(
         Sub()
            If chbCargo.Checked Then
               cmbTiposLiquidacion.Enabled = True
               chbPeriodo.Checked = True
               chbPeriodo.Enabled = True
               'dtpPeriodo.Enabled = chbPeriodo.Checked
            Else
               cmbTiposLiquidacion.Enabled = False
               chbPeriodo.Checked = False
               chbPeriodo.Enabled = False
               'dtpPeriodo.Enabled = False
            End If
         End Sub)
   End Sub

#Region "Eventos Numero"
   Dim _numeroComprobanteDesdeAnterior As Long = 0
   Private Sub chbNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumero.CheckedChanged
      TryCatched(
         Sub()
            txtNumeroCompDesde.Enabled = chbNumero.Checked
            txtNumeroCompHasta.Enabled = txtNumeroCompDesde.Enabled
            If Not chbNumero.Checked Then
               txtNumeroCompDesde.Text = String.Empty
               txtNumeroCompHasta.Text = String.Empty
            Else
               txtNumeroCompDesde.Focus()
            End If
         End Sub)
   End Sub
   Private Sub txtNumeroCompDesde_Enter(sender As Object, e As EventArgs) Handles txtNumeroCompDesde.Enter
      TryCatched(Sub() _numeroComprobanteDesdeAnterior = txtNumeroCompDesde.ValorNumericoPorDefecto(0I))
   End Sub
   Private Sub txtNumeroCompDesde_Leave(sender As Object, e As EventArgs) Handles txtNumeroCompDesde.Leave
      TryCatched(
         Sub()
            Dim desde = txtNumeroCompDesde.ValorNumericoPorDefecto(0I)
            Dim hasta = txtNumeroCompHasta.ValorNumericoPorDefecto(0I)
            Dim delta = desde - _numeroComprobanteDesdeAnterior
            txtNumeroCompHasta.Text = (hasta + delta).ToString()
         End Sub)
   End Sub
#End Region

#Region "Marcar/Desmarcar Todos"
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(Sub() ugDetalle.MarcarDesmarcar(cmbTodos, "Selec"))
   End Sub
#End Region

#End Region

#Region "Metodos"

   Private Sub FormatearColumnas()

      With ugDetalle.DisplayLayout.Bands(0)

         'oculto todas las columnas por si en algún momento agrego mas al query de la consulta
         For Each col As UltraGridColumn In ugDetalle.DisplayLayout.Bands(0).Columns
            col.Hidden = True
            col.CellActivation = Activation.NoEdit
         Next

         Dim pos = 0I
         .Columns("Selec").FormatearColumna("Selec", pos, 40).CellActivation = Activation.AllowEdit
         .Columns("Selec").Style = UltraWinGrid.ColumnStyle.CheckBox
         .Columns("CodigoCliente").FormatearColumna("Codigo", pos, 80, HAlign.Right)
         .Columns("NombreCliente").FormatearColumna("Cliente", pos, 200)
         .Columns("NombreCategoria").FormatearColumna("Categoría", pos, 100)

         .Columns("IdTipoComprobante").FormatearColumna("Comprobante", pos, 80)
         .Columns("Letra").FormatearColumna("Letra", pos, 40, HAlign.Center)
         .Columns("CentroEmisor").FormatearColumna("Emisor", pos, 40, HAlign.Right)
         .Columns("NumeroComprobante").FormatearColumna("Número", pos, 50, HAlign.Right)

         .Columns("Saldo").FormatearColumna("Saldo C.C.", pos, 80, HAlign.Right)
         .Columns("CuotaNumero").FormatearColumna("Cuota", pos, 50, HAlign.Center)
         .Columns("Observacion").FormatearColumna("Observación", pos, 150)

         .Columns("CodigoCliente").Header.VisiblePosition = 1
         .Columns("NombreCliente").Header.VisiblePosition = 2
         .Columns("NombreCategoria").Header.VisiblePosition = 3
         .Columns("IdTipoComprobante").Header.VisiblePosition = 4
         .Columns("Letra").Header.VisiblePosition = 5
         .Columns("CentroEmisor").Header.VisiblePosition = 6
         .Columns("NumeroComprobante").Header.VisiblePosition = 7
         .Columns("CuotaNumero").Header.VisiblePosition = 8
         .Columns("Saldo").Header.VisiblePosition = 9

         ugDetalle.AgregarTotalesSuma({"Saldo"})

      End With
   End Sub

   Private Sub RefrescarDatosGrilla()
      dtpFechaVencimiento.Value = Date.Now
      cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MararTodos
      cmbFormato.SelectedValue = Reglas.Publicos.CtaCte.PMCFormato
      chbNumero.Checked = False
      chbEsRefinanciado.Checked = False
      'Limpio la Grilla.
      ugDetalle.ClearFilas()
   End Sub

   Private Sub CargaGrillaDetalle()
      _FormatoPMC = DirectCast([Enum].Parse(GetType(Entidades.CuentaCorriente.FormatoPMC), Me.cmbFormato.SelectedValue.ToString()), Entidades.CuentaCorriente.FormatoPMC)

      Dim periodo As Date?
      Dim idTipoLiquidacion As Integer?
      If _tieneModuloCargos AndAlso chbCargo.Checked Then
         If chbPeriodo.Checked Then
            periodo = Me.dtpPeriodo.Value
         End If
         idTipoLiquidacion = Integer.Parse(cmbTiposLiquidacion.SelectedValue.ToString())
      End If

      Dim rCC = New Reglas.CuentasCorrientes()
      If _FormatoPMC = Entidades.CuentaCorriente.FormatoPMC.ROELAPMC Or _FormatoPMC = Entidades.CuentaCorriente.FormatoPMC.SIRPLUS Then
         _detalle = rCC.GetCtasCtesParaPMCRoela(actual.Sucursal.IdSucursal, cmbCategorias.GetCategorias(), periodo, idTipoLiquidacion,
                                                txtNumeroCompDesde.ValorNumericoPorDefecto(0I), txtNumeroCompHasta.ValorNumericoPorDefecto(0I), _FormatoPMC)
      Else
         _detalle = rCC.GetCtasCtesParaPMC(actual.Sucursal.IdSucursal, cmbCategorias.GetCategorias(), periodo, idTipoLiquidacion,
                                           txtNumeroCompDesde.ValorNumericoPorDefecto(0I), txtNumeroCompHasta.ValorNumericoPorDefecto(0I))
      End If

      _detalle.Columns.Add("Selec", GetType(Boolean))
      _detalle.Columns("Selec").SetOrdinal(0)
      _detalle.Rows.OfType(Of DataRow)().ToList().ForEach(Sub(dr) dr("Selec") = False)

      cmbTodos.Visible = (_detalle.Count > 0)
      btnTodos.Visible = (_detalle.Count > 0)

      ugDetalle.DataSource = _detalle
      FormatearColumnas()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub Generar(nombreArchivo As String)
      Dim arc As IDebitosDirectosProceso

      If _FormatoPMC = Entidades.CuentaCorriente.FormatoPMC.ROELAPMC Then

         Dim NroRefinanciacion As Integer
         If chbEsRefinanciado.Checked Then
            NroRefinanciacion = Integer.Parse(Me.txtNroRefinancion.Text.ToString())
         Else
            NroRefinanciacion = 1
         End If

         arc = New PagoMisCuentasRoelaProceso()
         arc.CrearDD(Me._detalle, Me._banco, nombreArchivo, Me.dtpFechaVencimiento.Value, NroRefinanciacion)

      ElseIf _FormatoPMC = Entidades.CuentaCorriente.FormatoPMC.PMC Then
         arc = New PagoMisCuentasProceso()

         arc.CrearDD(Me._detalle, Me._banco, nombreArchivo, Me.dtpFechaVencimiento.Value, NroRefinanciacion:=1)
      Else

         Dim SIRPLUS As ArchivoXMLSirplus = New ArchivoXMLSirplus()
         SIRPLUS.GenerarXMLSirplus(Me._detalle, nombreArchivo)

      End If

      If _FormatoPMC = Entidades.CuentaCorriente.FormatoPMC.ROELAPMC Or _FormatoPMC = Entidades.CuentaCorriente.FormatoPMC.PMC Then
         MessageBox.Show("Se Exportaron " & arc.NumeroDeRegistros.ToString() & " comprobantes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Else
         MessageBox.Show("Se Exportaron " & _detalle.Select("Selec = True").Count & " comprobantes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End If

   End Sub

   Private Sub chbEsRefinanciado_CheckedChanged(sender As Object, e As EventArgs) Handles chbEsRefinanciado.CheckedChanged
      TryCatched(
         Sub()
            txtNroRefinancion.Enabled = chbEsRefinanciado.Checked
            If chbEsRefinanciado.Checked = False Then
               txtNroRefinancion.Text = "0"
            End If

            txtNroRefinancion.Focus()
         End Sub)
   End Sub

   Private Sub txtNroRefinancion_Leave(sender As Object, e As EventArgs) Handles txtNroRefinancion.KeyUp
      TryCatched(
        Sub()
           If chbEsRefinanciado.Checked AndAlso (String.IsNullOrEmpty(Me.txtNroRefinancion.Text.ToString()) Or Integer.Parse(Me.txtNroRefinancion.Text.ToString()) < 2) Then
              MessageBox.Show("ATENCION: Si seleccionó Es Refinanciado NO puede ingresar 0-1 !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
           End If
        End Sub)
   End Sub


#End Region

   ' Private Sub GenerarXMLSirplus(ByVal Datos As DataTable, ByVal nombreArchivo As String)

   'Dim rNumerador As Reglas.Numeradores = New Reglas.Numeradores()

   '   Dim xmlDoc As New XmlDocument()
   '   Dim rootNode As XmlNode = xmlDoc.CreateElement("recepciones")
   '   xmlDoc.AppendChild(rootNode)

   '   Dim recepcionNode As XmlNode = xmlDoc.CreateElement("recepcion")
   '   rootNode.AppendChild(recepcionNode)
   '   Dim fechaSincronizacionNode As XmlNode = xmlDoc.CreateElement("fecha_sincronizacion")
   '   fechaSincronizacionNode.InnerText = Date.Now.ToString("yyyy-MM-dd")
   '   recepcionNode.AppendChild(fechaSincronizacionNode)

   '   Dim NumeroSincro As Entidades.Numerador = rNumerador.GetUno(Entidades.Numerador.TiposNumeradores.SIRPLUS.ToString())
   '   NumeroSincro.Numero += 1

   '   Dim idSincronizacionNode As XmlNode = xmlDoc.CreateElement("id_sincronizacion")
   '   idSincronizacionNode.InnerText = NumeroSincro.Numero.ToString()
   '   recepcionNode.AppendChild(idSincronizacionNode)

   '   Dim clienteNode As XmlNode = xmlDoc.CreateElement("Cliente")
   '   recepcionNode.AppendChild(clienteNode)
   '   Dim numeroNode As XmlNode = xmlDoc.CreateElement("numero")
   '   numeroNode.InnerText = Reglas.Publicos.TurismoSIRPLUSNroCuentaEmpresa.ToString()
   '   clienteNode.AppendChild(numeroNode)
   '   Dim razonSocialNode As XmlNode = xmlDoc.CreateElement("razon_social")
   '   razonSocialNode.InnerText = Reglas.Publicos.TurismoSIRPLUSRazonSocial
   '   clienteNode.AppendChild(razonSocialNode)
   '   Dim cuitNode As XmlNode = xmlDoc.CreateElement("cuit")
   '   cuitNode.InnerText = Reglas.Publicos.CuitEmpresa.ToString()
   '   clienteNode.AppendChild(cuitNode)
   '   Dim passwordNode As XmlNode = xmlDoc.CreateElement("password")
   '   passwordNode.InnerText = Reglas.Publicos.TurismoSIRPLUSPassword
   '   clienteNode.AppendChild(passwordNode)

   '   Dim cuponesNode As XmlNode = xmlDoc.CreateElement("cupones")
   '   recepcionNode.AppendChild(cuponesNode)

   '   For Each dr As DataRow In Datos.Select("Selec = True")
   '      Dim cuponNode1 As XmlNode = xmlDoc.CreateElement("cupon")
   '      cuponesNode.AppendChild(cuponNode1)

   '      Dim fechaNode1 As XmlNode = xmlDoc.CreateElement("fecha")
   '      fechaNode1.InnerText = Date.Now.ToString("yyyy-MM-dd")
   '      cuponNode1.AppendChild(fechaNode1)
   '      Dim AnioNode1 As XmlNode = xmlDoc.CreateElement("anio")
   '      AnioNode1.InnerText = Date.Now.ToString("yyyy")
   '      cuponNode1.AppendChild(AnioNode1)
   '      Dim PeriodoNode1 As XmlNode = xmlDoc.CreateElement("periodo")
   '      PeriodoNode1.InnerText = Date.Now.ToString("MM")
   '      cuponNode1.AppendChild(PeriodoNode1)
   '      Dim numero_cuponNode1 As XmlNode = xmlDoc.CreateElement("numero_cupon")
   '      numero_cuponNode1.InnerText = Long.Parse((dr("NumeroComprobante").ToString() & dr("CuotaNumero").ToString()).ToString()).ToString()
   '      cuponNode1.AppendChild(numero_cuponNode1)
   '      Dim numero_clienteNode1 As XmlNode = xmlDoc.CreateElement("numero_cliente")
   '      numero_clienteNode1.InnerText = dr("CodigoCliente").ToString()
   '      cuponNode1.AppendChild(numero_clienteNode1)
   '      Dim razon_social_clienteNode1 As XmlNode = xmlDoc.CreateElement("razon_social_cliente")
   '      razon_social_clienteNode1.InnerText = dr("NombreCliente").ToString()
   '      cuponNode1.AppendChild(razon_social_clienteNode1)
   '      Dim mailNode1 As XmlNode = xmlDoc.CreateElement("mail")
   '      mailNode1.InnerText = dr("CorreoElectronico").ToString()
   '      cuponNode1.AppendChild(mailNode1)
   '      Dim numero_cuentaNode1 As XmlNode = xmlDoc.CreateElement("numero_cuenta")
   '      cuponNode1.AppendChild(numero_cuentaNode1)
   '      Dim cbuNode1 As XmlNode = xmlDoc.CreateElement("cbu")
   '      cuponNode1.AppendChild(cbuNode1)
   '      Dim titular_cuentaNode1 As XmlNode = xmlDoc.CreateElement("titular_cuenta")
   '      cuponNode1.AppendChild(titular_cuentaNode1)
   '      Dim numero_cuenta_empresaNode1 As XmlNode = xmlDoc.CreateElement("numero_cuenta_empresa")
   '      numero_cuenta_empresaNode1.InnerText = Reglas.Publicos.TurismoSIRPLUSIdentifCuenta.ToString()
   '      cuponNode1.AppendChild(numero_cuenta_empresaNode1)
   '      Dim cbu_empresaNode1 As XmlNode = xmlDoc.CreateElement("cbu_empresa")
   '      cbu_empresaNode1.InnerText = Reglas.Publicos.TurismoSIRPLUSCBU.ToString()
   '      cuponNode1.AppendChild(cbu_empresaNode1)
   '      Dim titular_cuenta_empresaNode1 As XmlNode = xmlDoc.CreateElement("titular_cuenta_empresa")
   '      titular_cuenta_empresaNode1.InnerText = Reglas.Publicos.TurismoSIRPLUSCBUEmpresa.ToString()
   '      cuponNode1.AppendChild(titular_cuenta_empresaNode1)
   '      Dim TotalNode1 As XmlNode = xmlDoc.CreateElement("Total")
   '      TotalNode1.InnerText = dr("Saldo").ToString()
   '      cuponNode1.AppendChild(TotalNode1)
   '      Dim id_moneda_sirplusNode1 As XmlNode = xmlDoc.CreateElement("id_moneda_sirplus")
   '      id_moneda_sirplusNode1.InnerText = "1"
   '      cuponNode1.AppendChild(id_moneda_sirplusNode1)
   '      Dim valor_pesosNode1 As XmlNode = xmlDoc.CreateElement("valor_pesos")
   '      valor_pesosNode1.InnerText = dr("Saldo").ToString()
   '      cuponNode1.AppendChild(valor_pesosNode1)
   '      Dim codigo_barrasNode1 As XmlNode = xmlDoc.CreateElement("codigo_barras")
   '      codigo_barrasNode1.InnerText = dr("CodigoDeBarraSirplus").ToString()
   '      cuponNode1.AppendChild(codigo_barrasNode1)

   '      Dim vencimientos1 As XmlNode = xmlDoc.CreateElement("vencimientos")
   '      cuponNode1.AppendChild(vencimientos1)
   '      Dim fecha_vencimientovencimientos1 As XmlNode = xmlDoc.CreateElement("fecha_vencimiento")
   '      fecha_vencimientovencimientos1.InnerText = Date.Parse(dr("FechaVencimiento").ToString()).ToString("yyyy/MM/dd")
   '      vencimientos1.AppendChild(fecha_vencimientovencimientos1)
   '      Dim importevencimientos1 As XmlNode = xmlDoc.CreateElement("importe")
   '      importevencimientos1.InnerText = dr("Saldo").ToString()
   '      vencimientos1.AppendChild(importevencimientos1)
   '      Dim id_moneda_vencimiento_sirplusvencimientos1 As XmlNode = xmlDoc.CreateElement("id_moneda_vencimiento_sirplus")
   '      id_moneda_vencimiento_sirplusvencimientos1.InnerText = "1"
   '      vencimientos1.AppendChild(id_moneda_vencimiento_sirplusvencimientos1)
   '      Dim valor_pesos_vencimientovencimientos1 As XmlNode = xmlDoc.CreateElement("valor_pesos_vencimiento")
   '      valor_pesos_vencimientovencimientos1.InnerText = dr("Saldo").ToString()
   '      vencimientos1.AppendChild(valor_pesos_vencimientovencimientos1)

   '      Dim vencimientos2 As XmlNode = xmlDoc.CreateElement("vencimientos")
   '      cuponNode1.AppendChild(vencimientos2)
   '      Dim fecha_vencimientovencimientos2 As XmlNode = xmlDoc.CreateElement("fecha_vencimiento")
   '      fecha_vencimientovencimientos2.InnerText = Date.Parse(dr("FechaVencimiento2").ToString()).ToString("yyyy/MM/dd")
   '      vencimientos2.AppendChild(fecha_vencimientovencimientos2)
   '      Dim importevencimientos2 As XmlNode = xmlDoc.CreateElement("importe")
   '      importevencimientos2.InnerText = dr("ImporteVencimiento2").ToString()
   '      vencimientos2.AppendChild(importevencimientos2)
   '      Dim id_moneda_vencimiento_sirplusvencimientos2 As XmlNode = xmlDoc.CreateElement("id_moneda_vencimiento_sirplus")
   '      id_moneda_vencimiento_sirplusvencimientos2.InnerText = "1"
   '      vencimientos2.AppendChild(id_moneda_vencimiento_sirplusvencimientos2)
   '      Dim valor_pesos_vencimientovencimientos2 As XmlNode = xmlDoc.CreateElement("valor_pesos_vencimiento")
   '      valor_pesos_vencimientovencimientos2.InnerText = dr("ImporteVencimiento2").ToString()
   '      vencimientos2.AppendChild(valor_pesos_vencimientovencimientos2)

   '      Dim vencimientos3 As XmlNode = xmlDoc.CreateElement("vencimientos")
   '      cuponNode1.AppendChild(vencimientos3)
   '      Dim fecha_vencimientovencimientos3 As XmlNode = xmlDoc.CreateElement("fecha_vencimiento")
   '      fecha_vencimientovencimientos3.InnerText = Date.Parse(dr("FechaVencimiento3").ToString()).ToString("yyyy/MM/dd")
   '      vencimientos3.AppendChild(fecha_vencimientovencimientos3)
   '      Dim importevencimientos3 As XmlNode = xmlDoc.CreateElement("importe")
   '      importevencimientos3.InnerText = dr("ImporteVencimiento3").ToString()
   '      vencimientos3.AppendChild(importevencimientos3)
   '      Dim id_moneda_vencimiento_sirplusvencimientos3 As XmlNode = xmlDoc.CreateElement("id_moneda_vencimiento_sirplus")
   '      id_moneda_vencimiento_sirplusvencimientos3.InnerText = "1"
   '      vencimientos3.AppendChild(id_moneda_vencimiento_sirplusvencimientos3)
   '      Dim valor_pesos_vencimientovencimientos3 As XmlNode = xmlDoc.CreateElement("valor_pesos_vencimiento")
   '      valor_pesos_vencimientovencimientos3.InnerText = dr("ImporteVencimiento3").ToString()
   '      vencimientos3.AppendChild(valor_pesos_vencimientovencimientos3)

   '      Dim entidades As XmlNode = xmlDoc.CreateElement("entidades")
   '      cuponNode1.AppendChild(entidades)

   '      Dim entidad As XmlNode = xmlDoc.CreateElement("entidad")
   '      entidades.AppendChild(entidad)
   '      Dim id_entidad As XmlNode = xmlDoc.CreateElement("id_entidad")
   '      id_entidad.InnerText = "2"
   '      entidad.AppendChild(id_entidad)

   '      Dim entidad1 As XmlNode = xmlDoc.CreateElement("entidad")
   '      entidades.AppendChild(entidad1)
   '      Dim id_entidad1 As XmlNode = xmlDoc.CreateElement("id_entidad")
   '      id_entidad1.InnerText = "5"
   '      entidad1.AppendChild(id_entidad1)

   '   Next

   '   xmlDoc.Save(nombreArchivo)
   '   rNumerador.Actualizar(NumeroSincro)

   'End Sub


End Class