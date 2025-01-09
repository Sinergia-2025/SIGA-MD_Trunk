Public Class FichasABM2

#Region "Constantes"

   Private Const funcionActual As String = "FichasABM"
   Private Const funcionDevPago As String = "DevolverPago"
#End Region

#Region "Campos"

   Private _cache As Reglas.BusquedasCacheadas

   Private eFicha As Entidades.Venta
   Private oFichaPagos As List(Of Eniac.Entidades.FichaPago)
   Private oFichaPagosDetalle As List(Of Eniac.Entidades.FichaPagoDetalle)
   Private _ventasProductos As List(Of Entidades.VentaProducto)
   Private _ventasProductosLotes As Dictionary(Of Entidades.IVentaProducto, List(Of String))
   Private _subTotales As List(Of Entidades.VentaImpuesto)

   Private _tipoImpuestoIVA As Entidades.TipoImpuesto.Tipos = Entidades.TipoImpuesto.Tipos.IVA
   Private _categoriaFiscalEmpresa As Entidades.CategoriaFiscal

   Private _estado As Estados
   Private _puedeDevolverPago As Boolean
   Private _publicos As Publicos
   Private _fichaAnulada As Boolean = False
   Private _primerSaldo As Decimal = 0
   Private _cuotanumero As Integer
   Private _comentario As String = String.Empty
   Private _numeroOrden As Integer
   Private _clienteGrilla As Entidades.Cliente
   Private _DolarCotizacion As Decimal
   Private _adjuntos As Entidades.ListConBorrados(Of Entidades.IAdjunto)

   Private _idTipoComprobante As String = "FICHAS"
   Private _letra As String = "X"

   Private _decimalesEnDescRec As Integer
   Private _decimalesAMostrarEnTotalXProducto As Integer
   Private _decimalesAMostrarEnPrecio As Integer
   Private _decimalesRedondeoEnPrecio As Integer   '4
   Private _decimalesEnCantidad As Integer = 2
   Private _decimalesMostrarEnCantidad As Integer = 2
   Private _decimalesEnTamanio As Integer = 2      'En el ABM tiene 3, habria que hacerlo seteable.
   Private _decimalesEnKilos As Integer = 3
   Private _decimalesEnTotales As Integer = 2

   Private _estaCargando As Boolean = True

   Private _titProductos As Dictionary(Of String, String)
   Private _titAdjuntos As Dictionary(Of String, String)

   Private _tipoComprobante As Entidades.TipoComprobante

#End Region

#Region "Enumeraciones"
   Private Enum Estados
      Insercion
      Modificacion
   End Enum

   Public Enum MetodoLlamador
      CambioTipoDeComprobante
      CambioListaDePrecibos
      CambioCategoriaFiscal
   End Enum
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._decimalesRedondeoEnPrecio = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio
         Me._decimalesAMostrarEnPrecio = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio
         Me._decimalesAMostrarEnTotalXProducto = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnTotalXProducto
         _decimalesEnDescRec = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnDescRec

         Me._ventasObservaciones = New List(Of Entidades.VentaObservacion)()
         tbcFichas.SelectedTab = tbpObservaciones
         _titObservaciones = GetColumnasVisiblesGrilla(ugObservaciones)

         If Reglas.Publicos.ProductoUtilizaCantidadesEnteras Then
            Me._decimalesEnCantidad = 0
         Else
            _decimalesEnCantidad = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnCantidad
            _decimalesMostrarEnCantidad = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesMostrarEnCantidad
         End If

         Me._categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

         Me._publicos = New Eniac.Win.Publicos()
         _cache = New Reglas.BusquedasCacheadas()
         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
         Me._puedeDevolverPago = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, funcionDevPago)

         Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, _idTipoComprobante, contado:=False)

         Me._publicos.CargaComboEmpleados(Me.cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)
         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Eniac.Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me._publicos.CargaComboListaDePrecios(Me.cmbListaDePrecios)

         Dim blnMiraUsuario As Boolean = True, blnMiraPC As Boolean = True, blnCajasModificables As Boolean = True
         Me._publicos.CargaComboCajas(Me.cmbCajas, Eniac.Entidades.Usuario.Actual.Sucursal.Id, blnMiraUsuario, blnMiraPC, blnCajasModificables)

         'Me._ventasProductos = New List(Of Entidades.VentaProducto)()
         _subTotales = New List(Of Entidades.VentaImpuesto)()

         'Seguridad de la Edición de Clientes (enlace a través de la etiqueta "Más info...")
         Me.llbCliente.Visible = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "Clientes-PuedeUsarMasInfo")

         _titProductos = GetColumnasVisiblesGrilla(dtgProductos)

         tbcFichas.SelectedTab = tbpAdjuntos
         _titAdjuntos = GetColumnasVisiblesGrilla(ugAdjunto)

         Me.SeteaVentaProducto()
         Me.SeteaFichaPagos()

         If Reglas.Publicos.FichasImprimeCobrosFormatoRecibo Then
            tsbImprimirFicha.Text = "Imprimir Anticipo"
         End If

         Me._estaCargando = False

         If Me.tbcFichas.Contains(Me.tbpFacturables) Then
            Me.tbcFichas.TabPages.Remove(Me.tbpFacturables)
         End If
         If Me.tbcFichas.Contains(Me.tbpObservaciones) Then
            Me.tbcFichas.TabPages.Remove(Me.tbpObservaciones)
         End If


         Me.Nuevo()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Try
         If keyData = Keys.F5 Then
            Me.tsbNuevo.PerformClick()
            Me.tsbNuevo_Click(Me.tsbNuevo, New EventArgs())
            Return True
         ElseIf keyData = (Keys.D Or Keys.Alt) Then
            Me.bscDireccion.Focus()
            Return True
         ElseIf keyData = Keys.F4 Then
            If tsbGrabar.Enabled Then
               tsbGrabar.PerformClick()
               Return True
            ElseIf tsbPago.Enabled Then
               tsbPago.PerformClick()
               Return True
            End If
         ElseIf keyData = Keys.F9 Then
            tbcFichas.SelectedTab = tbpProductos
            bscCodigoProducto2.Focus()
         ElseIf keyData = Keys.F12 Then
            tbcFichas.SelectedTab = tbpPagos
            txtAnticipo.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

#Region "Eventos"
#Region "Eventos Toolbar"
   Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
      Try
         Me.Nuevo()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      Try
         Me.GrabarFicha()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub tsbPago_Click(sender As Object, e As EventArgs) Handles tsbPago.Click
      Try
         Dim cobrador As Entidades.Empleado = Nothing
         If cmbCobrador.SelectedIndex > -1 Then
            cobrador = DirectCast(cmbCobrador.SelectedItem, Entidades.Empleado)
         End If
         Dim vendedor As Entidades.Empleado = Nothing
         If Me.cmbVendedor.SelectedIndex > -1 Then
            vendedor = DirectCast(cmbVendedor.SelectedItem, Entidades.Empleado)
         End If

         Using oPagos As Pagos2 = New Pagos2(Integer.Parse(Me.cmbCajas.SelectedValue.ToString()), Pagos2.TipoPago.Pago,
                                             Integer.Parse(txtIdSucursal.Text), txtIdTipoComprobante.Text, txtLetra.Text, Short.Parse(txtCentroEmisor.Text), Long.Parse(Me.txtNroOperacion.Text),
                                             Long.Parse(Me.bscCodigoCliente.Tag.ToString()), vendedor, cobrador, Me._primerSaldo, Me._cuotanumero, False)
            oPagos.IdFuncion = IdFuncion
            oPagos.ShowDialog()
            Me.RecuperarDatosDeFicha()
         End Using
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsbAnular_Click(sender As Object, e As EventArgs) Handles tsbAnular.Click
      Try
         If Me.ValidarAnulacionFicha() Then
            If ShowPregunta("¿Esta seguro de anular esta ficha?", MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
               Me.Cursor = Cursors.WaitCursor

               Dim rVentas As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas()

               Dim impresionFichas As ImpresionFichas = New ImpresionFichas()

               Dim ficha As Eniac.Entidades.Venta
               ficha = rVentas.GetUna(Integer.Parse(txtIdSucursal.Text), txtIdTipoComprobante.Text, txtLetra.Text, Short.Parse(txtCentroEmisor.Text), Long.Parse(Me.txtNroOperacion.Text))

               ficha.Usuario = actual.Nombre
               rVentas.AnularComprobante(ficha, Entidades.Entidad.MetodoGrabacion.Manual, IdFuncion)

               MessageBox.Show("La ficha fue anulada con exito!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.Nuevo()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimirFicha_Click(sender As Object, e As EventArgs) Handles tsbImprimirFicha.Click
      Try
         Me.ImprimirFicha()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
   Private Sub tsbImpFichaCliente_Click(sender As Object, e As EventArgs) Handles tsbImpFichaCliente.Click
      Try
         Me.ImprimirFichaCliente()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
   Private Sub tsbImprimirFichaCtaCte_Click(sender As Object, e As EventArgs) Handles tsbImprimirFichaCtaCte.Click
      Try
         Me.ImprimirFichaCtaCte()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbCerrar.Click
      Try
         Me.Close()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   'Private Sub tsbRevisado_Click(sender As Object, e As EventArgs) Handles tsbRevisado.Click
   '   Try
   '      Dim oFicha As Eniac.Reglas.Fichas = New Eniac.Reglas.Fichas()
   '      Dim oFic As Eniac.Entidades.Ficha = New Eniac.Entidades.Ficha(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
   '      With oFic
   '         .NroOperacion = Integer.Parse(Me.txtNroOperacion.Text)
   '         .IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
   '      End With
   '      oFicha.ActualizarRevisar(oFic)
   '      MessageBox.Show("Ficha revisada ok!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '      Me.tsbRevisado.Visible = False
   '   Catch ex As Exception
   '      ShowError(ex)
   '   End Try

   'End Sub

   'Private Sub tsbDevolverPago_Click(sender As Object, e As EventArgs) Handles tsbDevolverPago.Click
   '   Try
   '      Dim oPagos As Pagos
   '      If Me.cmbCobrador.SelectedIndex <> -1 Then
   '         oPagos = New Pagos(Integer.Parse(Me.cmbCajas.SelectedValue.ToString()), Pagos.TipoPago.Devolucion, Integer.Parse(Me.txtNroOperacion.Text), Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Me.cmbCobrador.SelectedValue.ToString(), 0)
   '      Else
   '         oPagos = New Pagos(Integer.Parse(Me.cmbCajas.SelectedValue.ToString()), Pagos.TipoPago.Devolucion, Integer.Parse(Me.txtNroOperacion.Text), Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Nothing, 0)
   '      End If
   '      oPagos.ShowDialog()
   '      Me.RecuperarDatosDeFicha()
   '   Catch ex As Exception
   '      ShowError(ex)
   '   End Try

   'End Sub
#End Region

#Region "Eventos Busquedas Foraneas"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes()
         Dim codigoCliente As Long = -1
         If IsNumeric(Me.bscCodigoCliente.Text) Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes()
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscDireccion_BuscadorClick() Handles bscDireccion.BuscadorClick

      Try

         Me._publicos.PreparaGrillaClientes2(Me.bscDireccion)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes()

         Dim bus As Eniac.Entidades.Buscar = New Eniac.Entidades.Buscar
         bus.Columna = Eniac.Entidades.Cliente.Columnas.Direccion.ToString()
         bus.Valor = Me.bscDireccion.Text

         'Me.bscDireccion.Datos = oClientes.Buscar(bus).Tables(0)
         Me.bscDireccion.Datos = oClientes.Buscar(bus)

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscDireccion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscDireccion.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.Nuevo()
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos()
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         ''Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS")
         Dim codProd As String = String.Empty
         'Me._codigoBarrasCompleto = Me.bscCodigoProducto2.Text.Trim()     'Esto es por si usamos precio o cantidad en el código de barras

         codProd = Me.bscCodigoProducto2.Text.Trim()

         Dim idListaPrecios As Integer = DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios

         Dim dt As DataTable
         dt = oProductos.GetPorCodigo(codProd, actual.Sucursal.Id, idListaPrecios, "VENTAS")

         'Esto es por si usamos precio o cantidad en el código de barras
         '' ''If dt.Rows.Count > 0 Then
         '' ''   Me._modalidad = Modalidades.NORMAL
         '' ''Else
         '' ''   codProd = Me.GetCodigoModalidadPeso()
         '' ''   dt = oProductos.GetPorCodigo(codProd, actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS", , Modalidades.PESO.ToString())
         '' ''   If dt.Rows.Count > 0 Then
         '' ''      Me._modalidad = DirectCast([Enum].Parse(GetType(Modalidades), dt.Rows(0)(Entidades.Producto.Columnas.ModalidadCodigoDeBarras.ToString()).ToString()), Modalidades)  ''   Modalidades.PESO
         '' ''   Else
         '' ''      'aca va la pantalla
         '' ''      '' ''Dim frm As New AvisoProductoInexistente()
         '' ''      '' ''frm.ShowDialog()
         '' ''   End If
         '' ''End If
         Me.bscCodigoProducto2.Datos = dt
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscProducto_BuscadorClick() Handles bscProducto.BuscadorClick
      Try
         Dim idListaPrecios As Integer = DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto)
         Dim oProductos As Reglas.Productos = New Reglas.Productos()
         Me.bscProducto.Datos = oProductos.GetPorNombre(Me.bscProducto.Text.Trim(), actual.Sucursal.Id, idListaPrecios, "VENTAS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProducto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Eventos Grillas"
   Private Sub dtgProductos_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgProductos.CellDoubleClick
      Try
         Select Case Me._estado
            Case Estados.Modificacion
               '' ''Dim res As DialogResult
               '' ''If Me.dtpEntrego.Checked Then
               '' ''   res = MessageBox.Show("Desea modificar la fecha de entrega al " & Me.dtpEntrego.Value.ToString("dd/MM/yyyy") & " ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               '' ''Else
               '' ''   res = MessageBox.Show("Desea anular la fecha de entrega?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               '' ''End If
               '' ''If res = Windows.Forms.DialogResult.Yes Then
               '' ''   If Me.dtpEntrego.Checked Then
               '' ''      Me.dtgProductos.Rows(e.RowIndex).Cells("FechaEntrega").Value = Me.dtpEntrego.Value
               '' ''   Else
               '' ''      Me.dtgProductos.Rows(e.RowIndex).Cells("FechaEntrega").Value = Nothing
               '' ''   End If
               '' ''   Dim oFichaProd As Eniac.Reglas.FichasProductos = New Eniac.Reglas.FichasProductos()
               '' ''   'TODO: Ver como actualizar la fecha de entrega.
               '' ''   'oFichaProd.ActualizarFechaEntrega(Me.oFichaProductos(e.RowIndex))
               '' ''End If
            Case Estados.Insercion
               'limpia los campos
               Me.LimpiarCamposProductos()
               'carga los textbox con los valores de la grilla
               Me.CargarProductoCompleto(Me.dtgProductos.Rows(e.RowIndex))
               'elimina el item de la grilla
               Me.EliminarProducto()
               'hace foco en la cantidad

               If Me._ModificaDetalle = "SOLOPRECIOS" Then
                  HabilidaPrecios(True)

                  Me.tsbGrabar.Enabled = False    'Deshabilito hasta que confirme la grabacion
                  Me.btnInsertar.Enabled = True
                  Me.txtPrecio.Focus()
                  Me.txtPrecio.SelectAll()
               Else
                  Me.txtCantidad.Focus()
                  Me.txtCantidad.SelectAll()
               End If

         End Select

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub dtgProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgProductos.CellContentClick
      Try
         If e.ColumnIndex > -1 And e.RowIndex > -1 Then
            If dtgProductos.Columns(e.ColumnIndex).Name = "verNroSeries" Then
               If TypeOf (dtgProductos.Rows(e.RowIndex).DataBoundItem) Is Entidades.VentaProducto Then
                  Dim ventaProducto As Entidades.VentaProducto = DirectCast(dtgProductos.Rows(e.RowIndex).DataBoundItem, Entidades.VentaProducto)

                  If _ventasProductosLotes.ContainsKey(ventaProducto) Then
                     Using frm As FichasSeleccionoNrosSerie = New FichasSeleccionoNrosSerie(ventaProducto, _ventasProductosLotes, StateForm.Consultar)
                        frm.ShowDialog()
                     End Using
                  End If

               End If
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Eventos Enter/Leave/LostFocus"

   Private Sub txtComentario_GotFocus(sender As Object, e As EventArgs) Handles txtComentario.GotFocus
      Try
         If Me._estado = Estados.Modificacion Then
            Me._comentario = Me.txtComentario.Text
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub txtComentario_LostFocus(sender As Object, e As EventArgs) Handles txtComentario.LostFocus
      Try
         If Me._estado = Estados.Modificacion Then
            If Me._comentario.Trim() <> Me.txtComentario.Text.Trim() Then
               If MessageBox.Show("Modifica el comentario?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                  Dim oReg As Eniac.Reglas.Fichas = New Eniac.Reglas.Fichas()

                  Dim ficha As Eniac.Entidades.Ficha = New Eniac.Entidades.Ficha(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
                  With ficha
                     .IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
                     .FechaOperacion = Me.dtpFecha.Value
                     .NroOperacion = Integer.Parse(Me.txtNroOperacion.Text)
                     .Comentario = Me.txtComentario.Text
                  End With
                  oReg.ActualizarComentario(ficha)
               Else
                  Me.txtComentario.Text = Me._comentario
               End If
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub txtAnticipo_Leave(sender As Object, e As EventArgs) Handles txtAnticipo.Leave
      Try
         If Me.txtAnticipo.Text.Trim().Length = 0 Then
            Me.txtAnticipo.Text = "0.00"
         End If
         Me.CalcularSubTotal()

         NuevoCalculoIntereses()
      Catch ex As Exception
         ShowError(ex)

      End Try

   End Sub

   Private Sub txtIntereses_Leave(sender As Object, e As EventArgs) Handles txtIntereses.Leave, txtCapitalCuota.Leave, txtInteresCuota.Leave
      Try
         If Not IsNumeric(txtIntereses.Text.Trim()) Then txtIntereses.Text = "0.00"

         Me.CalcularImporteCuota()
         Me.CalcularTotal()
         If CheckBox1.Checked Then
            DistribuyeInteresesEntreCuotas()
         Else
            Me.CargarGrillaCuotas()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub txtAnticipo_LostFocus(sender As Object, e As EventArgs) Handles txtAnticipo.LostFocus
      Try
         If Me.txtAnticipo.Text.Length = 0 Then Me.txtAnticipo.Text = "0"
         If Me.txtBruto.Text.Length = 0 Then Me.txtBruto.Text = "0"
         If Decimal.Parse(Me.txtBruto.Text) <> 0 Then
            Me.txtSubTotal.Text = (Decimal.Parse(Me.txtBruto.Text) - Decimal.Parse(Me.txtAnticipo.Text)).ToString()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub txtPrecio_LostFocus(sender As Object, e As EventArgs) Handles txtPrecio.LostFocus
      Try
         If Me.txtPrecio.Text.Trim().Length = 0 Then
            Me.txtPrecio.Text = "0"
         End If
         Me.CalcularTotalProducto()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub txtCantidad_LostFocus(sender As Object, e As EventArgs) Handles txtCantidad.LostFocus
      Try
         Me.CalcularTotalProducto()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub txtBruto_LostFocus(sender As Object, e As EventArgs) Handles txtBruto.LostFocus
      Try
         If Me.txtBruto.Text.Trim().Length = 0 Then
            Me.txtBruto.Text = "0"
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub txtCuotas_Leave(sender As Object, e As EventArgs) Handles txtCuotas.Leave, txtReferenciaCuota.Leave
      TryCatched(
         Sub()
            If Not IsNumeric(txtCuotas.Text.Trim()) Then txtCuotas.Text = "1"
         NuevoCalculoIntereses()
         End Sub)
   End Sub

#End Region

#Region "Eventos KeyDown"

   Private Sub txtCantidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
      Try
         If e.KeyCode = Keys.Enter Then
            Me.txtPrecio.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub txtPrecio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPrecio.KeyDown
      Try
         If e.KeyCode = Keys.Enter Then
            Me.dtpEntrego.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub dtpEntrego_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpEntrego.KeyDown
      Try
         If e.KeyCode = Keys.Enter Then
            Me.txtGarantia.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub txtGarantia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGarantia.KeyDown
      Try
         If e.KeyCode = Keys.Enter Then
            Me.btnInsertar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub controlesPagos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTotalCuotas.KeyDown, txtTotal.KeyDown, txtSubTotal.KeyDown, txtSaldo.KeyDown, txtIntereses.KeyDown, txtInteresCuota.KeyDown, txtImpCuota.KeyDown, txtCuotas.KeyDown, txtCapitalCuota.KeyDown, txtBruto.KeyDown, txtAnticipo.KeyDown, cmbFormaPago.KeyDown, txtReferenciaCuota.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub cmbListaDePrecios_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbListaDePrecios.KeyDown
      Me.PresionarTab(e)
   End Sub

#End Region

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If (Not Me.bscProducto.FilaDevuelta Is Nothing Or Not bscCodigoProducto2.FilaDevuelta Is Nothing) And Me.txtCantidad.Text <> "" Then
            If Me.ValidarInsertaProducto() Then
               Me.InsertarProducto()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         Me.EliminarProducto()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub llbOperacion_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbOperacion.LinkClicked
      Try
         Me._primerSaldo = 0
         Me.VerOperaciones(True)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub llbCliente_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbCliente.LinkClicked
      Try
         Dim Clie As Eniac.Entidades.Cliente
         If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then
            Clie = New Eniac.Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), incluirFoto:=True)
         Else
            Clie = New Entidades.Cliente()
         End If
         Clie.Usuario = actual.Nombre

         Using PantCliente As ClientesDetalle = New ClientesDetalle(Clie)
            PantCliente.CierraAutomaticamente = True
            If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then
               PantCliente.StateForm = Eniac.Win.StateForm.Actualizar
            Else
               PantCliente.StateForm = Eniac.Win.StateForm.Insertar
            End If
            If PantCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
               Me.bscCodigoCliente.Text = PantCliente.txtCodigoCliente.Text
               Me.bscCodigoCliente.Enabled = True
               Me.bscCodigoCliente.PresionarBoton()
               Me.bscCodigoCliente.Enabled = False
            End If
         End Using
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tbcFichas_Click(sender As Object, e As EventArgs) Handles tbcFichas.Click
      Try
         If Me.tbcFichas.SelectedTab Is Me.tbpPagos Then
            Me.txtAnticipo.Focus()
         ElseIf tbcFichas.SelectedTab Is Me.tbpProductos Then
            bscCodigoProducto2.Focus()
         ElseIf tbcFichas.SelectedTab Is tbpAdjuntos Then
            ugAdjunto.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub cmbFormaPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFormaPago.SelectedIndexChanged
      Try
         If cmbFormaPago.SelectedIndex > -1 Then
            Dim fp As Entidades.VentaFormaPago = DirectCast(cmbFormaPago.SelectedItem, Entidades.VentaFormaPago)
            If fp.CantidadCuotas > 0 Then
               txtCuotas.Text = fp.CantidadCuotas.ToString()
            End If

            If IsNumeric(bscCodigoCliente.Tag) Then
               NuevoCalculoIntereses()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbListaDePrecios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListaDePrecios.SelectedIndexChanged

      If Me._estaCargando Then Exit Sub
      If cmbListaDePrecios.SelectedIndex < 0 Then Exit Sub
      If Not cmbListaDePrecios.Enabled Then Exit Sub

      Try
         '-- REQ-35891.- -----------------------------------------------------------------------------------------------------------------------------------
         Dim idListaPrecios = New Reglas.ListasDePrecios().GetUno(DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios)

         If Reglas.Publicos.FichasActualizaPreciosDeVenta Or idListaPrecios.FormaPago IsNot Nothing Then
            Me.RecalcularTodo(MetodoLlamador.CambioListaDePrecibos)
         End If
         cmbFormaPago.Enabled = True
         If idListaPrecios.FormaPago IsNot Nothing Then
            cmbFormaPago.SelectedValue = idListaPrecios.FormaPago.IdFormasPago
            cmbFormaPago.Enabled = Reglas.Publicos.FichasPermiteCambiarFormaDePago
         End If
         '--------------------------------------------------------------------------------------------------------------------------------------------------
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub btnObservacionCliente_Click(sender As Object, e As EventArgs) Handles btnObservacionCliente.Click
      Try
         If MessageBox.Show("¿Desea ingresar nuevas observaciones ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

            Dim ocli As Reglas.Clientes = New Reglas.Clientes()
            _clienteGrilla.Observacion = Me.txtObservacion.Text
            _clienteGrilla.Usuario = actual.Nombre

            ocli.Actualizar(_clienteGrilla)

            MessageBox.Show("La observación fue registrada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Metodos"

   Private Sub CargarProducto(dr As DataGridViewRow)
      bscCodigoProducto2.Text = dr.Cells(Entidades.Producto.Columnas.IdProducto.ToString()).Value.ToString()
      Me.bscProducto.Text = dr.Cells(Entidades.Producto.Columnas.NombreProducto.ToString()).Value.ToString()
      Me.txtPrecio.Text = Decimal.Round(Decimal.Parse(dr.Cells("PrecioVenta").Value.ToString()), 2).ToString("N" + _decimalesAMostrarEnPrecio.ToString())
      Me.txtStock.Text = dr.Cells("Stock").Value.ToString()
      Me.txtCantidad.Text = "1"
      Me.txtGarantia.Text = dr.Cells("MesesGarantia").Value.ToString()

      Me.txtCantidad.Focus()
   End Sub

   Private Function ValidarAnulacionFicha() As Boolean
      If Me.bscCodigoCliente.Text.Length = 0 Then
         MessageBox.Show("Debe cargar un Nro. de documento.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoCliente.Focus()
         Return False
      End If
      Return True
   End Function

   Private Function ValidarFicha() As Boolean
      If Me.bscCodigoCliente.Text.Trim().Length = 0 Then
         MessageBox.Show("Falta cargar el Nro. de Documento.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoCliente.Focus()
         Return False
      End If
      If Me.bscCliente.Text.Trim().Length = 0 Then
         MessageBox.Show("Falta cargar el Nombre del cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCliente.Focus()
         Return False
      End If
      'If Me.dtProductos.Rows.Count = 0 Then
      If Me._ventasProductos.Count = 0 Then
         MessageBox.Show("No se cargo ningún producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscProducto.Focus()
         Return False
      End If
      If Me.txtTotal.Text.Length = 0 Then
         MessageBox.Show("No se calcularon los precios de la operación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         tbcFichas.SelectedTab = tbpPagos
         txtAnticipo.Focus()
         Return False
      End If
      If Me.cmbCobrador.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el cobrador.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbCobrador.Focus()
         Return False
      End If
      If Me.cmbVendedor.SelectedIndex = -1 Then
         MessageBox.Show("Falta cargar el vendedor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbVendedor.Focus()
         Return False
      End If
      If Me.cmbFormaPago.SelectedIndex = -1 Then
         MessageBox.Show("Debe seleccionar una forma de pago.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.tbcFichas.SelectedTab = Me.tbpPagos
         Me.cmbFormaPago.Focus()
         Return False
      End If
      If DirectCast(cmbFormaPago.SelectedItem, Entidades.VentaFormaPago).Dias = 0 Then
         MessageBox.Show(String.Format("No se puede utilizar la forma de pago ´{0}´ porque tiene 0 días de plazo.", cmbFormaPago.Text.ToUpper()), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.tbcFichas.SelectedTab = Me.tbpPagos
         Me.cmbFormaPago.Focus()
         Return False
      End If
      If Me.dgvCuotas.Rows.Count = 0 Then
         MessageBox.Show("Debe generar cuotas antes de grabar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.tbcFichas.SelectedTab = Me.tbpPagos
         Me.txtCuotas.Focus()
         Return False
      End If

      If txtReferenciaCuota.ValorNumericoPorDefecto(0L) = 0 Then
         If Reglas.Publicos.FichasSinReferenciaDeCuota = Entidades.Publicos.PermitirNoPermitir.NOPERMITIR Then
            ShowMessage("No ha ingresado referencia de 1ra cuota. No es posible continuar.")
            tbcFichas.SelectedTab = tbpPagos
            txtReferenciaCuota.Focus()
            Return False
         ElseIf Reglas.Publicos.FichasSinReferenciaDeCuota = Entidades.Publicos.PermitirNoPermitir.AVISARYPERMITIR Then
            If ShowPregunta("¿Está seguro de guardar la ficha sin referencia de primera cuota?") = DialogResult.No Then
               tbcFichas.SelectedTab = tbpPagos
               txtReferenciaCuota.Focus()
               Return False
            End If
         End If
      End If

      'Si es Consumidor Final, vendio a partir de Tope y no tiene DNI
      Dim CategoriaFiscalCliente As Entidades.CategoriaFiscal = New Entidades.CategoriaFiscal()
      CategoriaFiscalCliente = Me._clienteGrilla.CategoriaFiscal

      If Not CategoriaFiscalCliente.IvaDiscriminado And Not CategoriaFiscalCliente.SolicitaCUIT And CategoriaFiscalCliente.LetraFiscal <> "E" And
         Decimal.Parse(Me.txtTotal.Text.ToString()) >= Reglas.Publicos.Facturacion.FacturacionControlaTopeCF And Me._clienteGrilla.NroDocCliente = 0 And
         GetTipoComprobante().ControlaTopeConsumidorFinal Then

         'Si tiene el parametro Activo de DNI controla a Todos (Blanco, Negro, Remito, Presupuestos, etc, sino, solo lo Blanco/Electronico.
         If Reglas.Publicos.Facturacion.FacturacionControlaDNIClienteConsumidorFinal Or
            (Not Reglas.Publicos.Facturacion.FacturacionControlaDNIClienteConsumidorFinal And
            (GetTipoComprobante().GrabaLibro Or
            GetTipoComprobante().EsPreElectronico)) Then

            ShowMessage(String.Format("ATENCION: El Cliente es Consumidor Final y el Total de Comprobante es $ {0} o mas. El DNI es obligatorio.", Reglas.Publicos.Facturacion.FacturacionControlaTopeCF))
            If MostrarMasInfo() = Windows.Forms.DialogResult.Cancel Then
               Return False
            End If
         End If

      End If

      Return True
   End Function
   Private Function MostrarMasInfo() As DialogResult

      Dim clie As Entidades.Cliente = Nothing
      If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then
         clie = New Eniac.Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), incluirFoto:=True)
      End If
      Dim result As DialogResult = Ayudante.MasInfoCliente.MostrarMasInfo.Mostrar(clie)
      If result = Windows.Forms.DialogResult.OK Then
         Me.bscCodigoCliente.Text = clie.CodigoCliente.ToString()
         Dim prevPermitido As Boolean = bscCodigoCliente.Permitido
         Me.bscCodigoCliente.PresionarBoton()
         bscCodigoCliente.Permitido = prevPermitido
      End If
      Return result

   End Function

   Private Sub GrabarFicha()
      If Me.ValidarFicha() Then

         '------------------------------------------------------VENTAS---------------------------------------------------
         'Me.tsbGrabar.Enabled = False

         Dim oFacturacion As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas()
         Dim oVentas As New Eniac.Entidades.Venta

         ArmaVentasImpuestos()

         With oVentas
            'cargo el comprobante
            Dim otipocom = New Reglas.TiposComprobantes

            'cargo datos generales del comprobante
            .IdSucursal = actual.Sucursal.Id
            .Usuario = actual.Nombre
            .Fecha = Me.dtpFecha.Value

            .TipoComprobante = otipocom.GetUno(_idTipoComprobante)

            'cargo la impresora
            .Impresora = New Eniac.Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, .TipoComprobante.IdTipoComprobante)

            'cargo el cliente ----------
            Dim ocli As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes()
            .Cliente = ocli.GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()))

            '-- REQ-36048.- -----------------------------------------------
            If .Cliente.IdClienteCtaCte = 0 Then
               .ClienteVinculado = .Cliente
            Else
               .ClienteVinculado = ocli.GetUno(.Cliente.IdClienteCtaCte)
            End If
            '--------------------------------------------------------------

            .Direccion = .Cliente.Direccion
            .IdLocalidad = .Cliente.IdLocalidad
            .IdCategoria = .Cliente.IdCategoria
            .CategoriaFiscal = New Reglas.CategoriasFiscales().GetUno(1) 'Por el momento se usa como CF todas las categorias.  .Cliente.CategoriaFiscal
            .LetraComprobante = _letra

            .Cuit = .Cliente.Cuit
            .TipoDocCliente = .Cliente.TipoDocCliente
            .NroDocCliente = .Cliente.NroDocCliente

            Dim oventasnum As Eniac.Reglas.VentasNumeros = New Eniac.Reglas.VentasNumeros
            .NumeroComprobante = oventasnum.GetProximoNumero(actual.Sucursal, .TipoComprobante.IdTipoComprobante, .LetraComprobante, .Impresora.CentroEmisor)

            If Me.cmbVendedor.SelectedIndex <> -1 Then
               .Vendedor = DirectCast(Me.cmbVendedor.SelectedItem, Eniac.Entidades.Empleado)
            End If

            If cmbCobrador.SelectedIndex > -1 Then
               .Cobrador = DirectCast(cmbCobrador.SelectedItem, Entidades.Empleado)
            End If

            '---------------------------Forma de PAGO 
            Dim oformapago As Eniac.Reglas.VentasFormasPago = New Eniac.Reglas.VentasFormasPago()
            .FormaPago = DirectCast(cmbFormaPago.SelectedItem, Entidades.VentaFormaPago)

            'If Me.cmbFormaPago.SelectedIndex <> -1 Then
            '   Dim operiodo As Eniac.Reglas.VentasPeriodos = New Eniac.Reglas.VentasPeriodos()
            '   .Periodo = operiodo.GetUna(Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString()))
            'End If

            .Observacion = Me.txtComentario.Text

            .VentasImpuestos = Me._subTotales
            '.ImpuestosVarios = Me._ImpuestosVarios

            .DescuentoRecargo = Decimal.Parse(Me.txtIntereses.Text)
            .DescuentoRecargoPorc = (.DescuentoRecargo / Decimal.Parse(Me.txtBruto.Text)) * 100 ' Decimal.Parse(Me.txtDescRecGralPorc.Text)

            Dim ventasProductos As List(Of Entidades.VentaProducto)
            ventasProductos = _ventasProductos.ClonarColeccion()

            For Each vp As Entidades.VentaProducto In ventasProductos
               vp.DescRecGeneral = Math.Round(vp.ImporteTotal * .DescuentoRecargoPorc / 100, 2)
               vp.DescRecGeneralProducto = vp.DescRecGeneral / vp.Cantidad

               vp.ImporteTotalNeto = vp.ImporteTotalNeto + vp.DescRecGeneral
               vp.PrecioNeto = vp.Precio + vp.DescRecGeneralProducto

               vp.ImporteImpuesto += Math.Round((vp.DescRecGeneral - (vp.DescRecGeneral / (1 + (vp.AlicuotaImpuesto / 100)))), 2)

               vp.Moneda = vp.Producto.Moneda

               If vp.Producto.NroSerie And _ventasProductosLotes.ContainsKey(vp) Then
                  For Each nroSerie As String In _ventasProductosLotes(vp)
                     vp.Producto.NrosSeries.Add(New Entidades.ProductoNroSerie() With {.Producto = vp.Producto, .NroSerie = nroSerie, .Sucursal = actual.Sucursal})
                  Next
               End If
            Next

            ArmaVentasImpuestos(ventasProductos)

            Dim bruto As Decimal = 0
            Dim subTotal As Decimal = 0
            Dim impInt As Decimal = 0
            Dim iva As Decimal = 0
            Dim total As Decimal = 0
            For Each vi As Entidades.VentaImpuesto In Me._subTotales
               bruto += vi.Bruto
               subTotal += vi.Neto

               If vi.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IMINT Then
                  impInt += vi.Importe
               Else
                  iva += vi.Importe
               End If
               total += vi.Total
            Next

            'cargo valores del comprobante
            .ImporteBruto = bruto ' Decimal.Parse(Me.txtBruto.Text)

            .DescuentoRecargo = bruto * .DescuentoRecargoPorc / 100
            .Subtotal = subTotal '+ .DescuentoRecargo '.ImporteBruto + .DescuentoRecargo
            .TotalImpuestos = iva
            .ImporteTotal = Decimal.Parse(Me.txtTotal.Text)
            '.CantidadInvocados = 0
            .CantidadLotes = 0

            '   'cargo los productos
            .VentasProductos = ventasProductos

            .VentasAdjuntos = New Entidades.ListConBorrados(Of Entidades.VentaAdjunto)()
            For Each adj As Entidades.IAdjunto In _adjuntos
               If TypeOf (adj) Is Entidades.VentaAdjunto Then
                  .VentasAdjuntos.Add(DirectCast(adj, Entidades.VentaAdjunto))
               End If
            Next
            For Each adj As Entidades.IAdjunto In _adjuntos.Borrados
               If TypeOf (adj) Is Entidades.VentaAdjunto Then
                  .VentasAdjuntos.Borrados.Add(DirectCast(adj, Entidades.VentaAdjunto))
               End If
            Next
            '.VentasAdjuntos = DirectCast(_adjuntos, List(Of VentasAdjuntos))

            .ImportePesos = Decimal.Parse(Me.txtAnticipo.Text)
            .ImporteTickets = 0

            'Cargo la utilidad
            .Utilidad = 0
            For Each vp As Entidades.VentaProducto In _ventasProductos
               Dim precioNetoProducto As Decimal = (vp.PrecioNeto / (1 + (vp.AlicuotaImpuesto / 100)))
               vp.Utilidad = Decimal.Round((precioNetoProducto - vp.Costo) * vp.Cantidad, _decimalesRedondeoEnPrecio)
               .Utilidad += vp.Utilidad
            Next

            .Utilidad += .DescuentoRecargo

            .CotizacionDolar = New Reglas.Monedas().GetUna(2).FactorConversion

            .ComisionVendedor = 0  '
            .MercDespachada = False

            'grabo la caja
            .IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())

            'cargo el Remito Transportista
            .Bultos = 0
            .ValorDeclarado = 0
            .NumeroLote = 0
            .Usuario = actual.Nombre
            .ImporteTransfBancaria = 0
            .IdEstadoComprobante = ""

            If Me._comprobantesSeleccionados IsNot Nothing AndAlso Me._comprobantesSeleccionados.Count > 0 AndAlso (.TipoComprobante.CoeficienteStock <> 0 Or .TipoComprobante.EsPreElectronico) AndAlso Not Me._InvocaPedido AndAlso Not Me._SoloCopia Then
               .IdEstadoComprobante = "INVOCO"
               '.CantidadInvocados = Me._comprobantesSeleccionados.Count
            Else
               '.CantidadInvocados = 0
            End If

            'Cargo los Comprobantes Facturados (tal vez ninguno)
            .Invocados.Add(Me._comprobantesSeleccionados)
            '.Facturables = Me._comprobantesSeleccionados
            'Observaciones Detalladas
            .VentasObservaciones = Me._ventasObservaciones
         End With

         'Si el tipo de pago es cuenta corriente tengo que levantar la pantalla de Cuenta Corriente
         If oVentas.TipoComprobante.ActualizaCtaCte Then
            If oVentas.FormaPago.Dias > 0 Then
               'si el cliente compro el modulo de cuenta corriente
               If Reglas.Publicos.TieneModuloCuentaCorrienteClientes Then

                  'If Not Eniac.Win.Publicos.UtilizaCuotasVencimientoCtaCteClientes Then

                  '   Dim oCCP As Eniac.Entidades.CuentaCorrientePago
                  '   oCCP = New Eniac.Entidades.CuentaCorrientePago()
                  '   oCCP.ImporteCuota = oVentas.ImporteTotal
                  '   oCCP.SaldoCuota = oCCP.ImporteCuota
                  '   oCCP.FechaVencimiento = Me.dtpFecha.Value.AddDays(oVentas.FormaPago.Dias)
                  '   oVentas.CuentaCorriente.Pagos.Add(oCCP)

                  'Else

                  'Dim cc As CuentaCorriente = New CuentaCorriente(Me.dtpFecha.Value, Decimal.Parse(Me.txtTotalGeneral.Text), oVentas.FormaPago.Dias)
                  'If cc.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  '   recuperar los datos para armar la cuenta corriente
                  Dim oCCP As Eniac.Entidades.CuentaCorrientePago
                  For Each dr As DataGridViewRow In Me.dgvCuotas.Rows
                     Dim nroCuota As Integer = Integer.Parse(dr.Cells("NroCuota").Value.ToString())
                     If nroCuota = 0 Then
                        oVentas.CuentaCorriente.ImporteAnticipo = Decimal.Parse(dr.Cells("Saldo").Value.ToString())
                     Else
                        oCCP = New Eniac.Entidades.CuentaCorrientePago()
                        oCCP.Cuota = nroCuota
                        oCCP.ImporteCapital = Decimal.Parse(dr.Cells("ImporteCapital").Value.ToString())
                        oCCP.ImporteInteres = Decimal.Parse(dr.Cells("ImporteInteres").Value.ToString())
                        oCCP.ImporteCuota = Decimal.Parse(dr.Cells("Saldo").Value.ToString())
                        oCCP.SaldoCuota = oCCP.ImporteCuota
                        oCCP.CuentaCorriente.ImportePesos = 0
                        oCCP.FechaVencimiento = Date.Parse(dr.Cells("FechaVencimiento").Value.ToString())
                        oCCP.ReferenciaCuota = Long.Parse(dr.Cells("ReferenciaCuota").Value.ToString())
                        oVentas.CuentaCorriente.Pagos.Add(oCCP)
                     End If
                  Next
               Else
                  Me.tsbGrabar.Enabled = True
                  Throw New Exception("Debe ingresar la forma de pago para poder grabar e imprimir.")
               End If

            End If

         End If

         oFacturacion.Insertar(oVentas, Entidades.Entidad.MetodoGrabacion.Manual, Me.IdFuncion)

         Using frmConfirmar As FichasABM2Confirmacion = New FichasABM2Confirmacion()
            If frmConfirmar.ShowDialog(Me, oVentas) = Windows.Forms.DialogResult.OK Then
               If frmConfirmar.ImprimirFichaAnticipo Then
                  Me.ImprimirFicha()
               End If
               If frmConfirmar.ImprimirFichaCliente Then
                  Me.ImprimirFichaCliente()
               End If
               If frmConfirmar.ReemplazaFicha Then
                  Using frm As New CopiarComprobantes(New CopiarComprobantes.ConfiguracionAutomatica() _
                                                      With {.IdTipoComprobanteOrigen = oVentas.IdTipoComprobante,
                                                            .LetraOrigen = oVentas.LetraComprobante,
                                                            .CentroEmisorOrigen = oVentas.CentroEmisor,
                                                            .NumeroComprobanteOrigen = oVentas.NumeroComprobante,
                                                            .EliminarComprobante = True,
                                                            .IdTipoComprobanteDestino = Publicos.ReemplazarComprobanteTipoComprobanteDestino,
                                                            .Usuario = actual.Nombre,
                                                            .IdCaja = oVentas.IdCaja})
                     frm.IdFuncion = IdFuncion
                     frm.ShowDialog()
                  End Using
               End If
            End If
         End Using
         Me.Nuevo()
      End If

   End Sub

   Private Sub ArmaVentasImpuestos()
      ArmaVentasImpuestos(_ventasProductos)
   End Sub
   Private Sub ArmaVentasImpuestos(ventasProductos As List(Of Entidades.VentaProducto))
      _subTotales.Clear()
      Dim importeBruto As Decimal
      Dim importeNeto As Decimal
      Dim descRec1 As Decimal = 0 'La pantalla actualmente no permite Desc/Rec, por lo que ponemos cero fijo. Cuando lo soporte, calcular los Desc/Rec.
      Dim descRec2 As Decimal = 0 'La pantalla actualmente no permite Desc/Rec, por lo que ponemos cero fijo. Cuando lo soporte, calcular los Desc/Rec.

      Dim vi As Entidades.VentaImpuesto = Nothing
      For Each dr As Entidades.VentaProducto In ventasProductos
         vi = Nothing
         importeBruto = (dr.Precio + descRec1 + descRec2) * dr.Cantidad
         importeNeto = dr.PrecioNeto * dr.Cantidad

         importeBruto = Decimal.Round((importeBruto - dr.ImporteImpuestoInterno) / (1 + dr.AlicuotaImpuesto / 100), Me._decimalesRedondeoEnPrecio)
         importeNeto = Decimal.Round((importeNeto - dr.ImporteImpuestoInterno) / (1 + dr.AlicuotaImpuesto / 100), Me._decimalesRedondeoEnPrecio)

         For Each viTemp As Entidades.VentaImpuesto In Me._subTotales
            If viTemp.Alicuota = dr.AlicuotaImpuesto And viTemp.TipoImpuesto.IdTipoImpuesto = Me._tipoImpuestoIVA Then
               viTemp.TipoImpuesto.IdTipoImpuesto = Me._tipoImpuestoIVA
               vi = viTemp
            End If
         Next
         If vi Is Nothing Then
            vi = New Entidades.VentaImpuesto
            vi.TipoImpuesto = New Reglas.TiposImpuestos().GetUno(_tipoImpuestoIVA)
            vi.Alicuota = dr.AlicuotaImpuesto
            _subTotales.Add(vi)
         End If

         vi.Bruto += importeBruto
         vi.Neto += importeNeto

         vi.Importe += dr.ImporteImpuesto
         vi.Total += (importeNeto + dr.ImporteImpuesto)
      Next

   End Sub

   Private Sub SeteaVentaProducto()
      Me._ventasProductos = New List(Of Eniac.Entidades.VentaProducto)
      _ventasProductosLotes = New Dictionary(Of Entidades.IVentaProducto, List(Of String))(New Entidades.VentaProductoComprarer())
   End Sub

   Private Sub SeteaFichaPagos()
      oFichaPagos = New List(Of Entidades.FichaPago)
      oFichaPagosDetalle = New List(Of Entidades.FichaPagoDetalle)
   End Sub

   ''' <summary>
   ''' Calcula el total del producto a vender
   ''' </summary>
   ''' <remarks></remarks>

   Private Sub CalcularTotalProducto()
      Me.txtTotalProducto.Text = (Convert.ToDecimal(Me.txtPrecio.Text) * Convert.ToDecimal(Me.txtCantidad.Text)).ToString()
   End Sub

   Private Sub LimpiarCamposProductos()
      Me.bscProducto.Text = ""
      Me.bscProducto.FilaDevuelta = Nothing
      Me.bscCodigoProducto2.Text = ""
      Me.bscCodigoProducto2.FilaDevuelta = Nothing
      'Me.bscProveedor.Text = String.Empty
      'Me.bscProveedor.FilaDevuelta = Nothing
      Me.txtPrecio.Text = "0.00"
      Me.txtStock.Text = "0"
      Me.txtCantidad.Text = "0"
      Me.txtTotalProducto.Text = "0.00"
      Me.dtpEntrego.Value = DateTime.Now
      Me.txtGarantia.Text = "0"
   End Sub

   Private Sub CalcularBruto()
      Dim bruto As Decimal = 0
      For i As Integer = 0 To Me._ventasProductos.Count - 1
         bruto += Convert.ToDecimal(Me._ventasProductos(i).ImporteTotal)
      Next
      'For Each dr As DataRow In Me.dtProductos.Rows
      '    bruto += Convert.ToDecimal(dr("Importe"))
      'Next
      Me.txtBruto.Text = bruto.ToString("#0.00")
      CalcularSubTotal()
   End Sub

   Private Sub CalcularIntereses()
      If cmbFormaPago.SelectedIndex = -1 Then Exit Sub
      If Not IsNumeric(txtCuotas.Text) Then Me.txtCuotas.Text = "1"

      Dim result As Reglas.Ventas.Fichas.CalcularInteresesResult
      result = New Reglas.Ventas.Fichas().CalcularIntereses(Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString()),
                                                            Integer.Parse(txtCuotas.Text),
                                                            Long.Parse(Me.bscCodigoCliente.Text.ToString()),
                                                            Decimal.Parse(Me.txtSubTotal.Text))

      Me.txtIntereses.Text = result.TotalIntereses.ToString("N2")
      txtInteresCuota.Text = result.InteresesCuota.ToString("N2")
   End Sub

   Private Sub CalcularImporteCuota()
      If Not IsNumeric(txtCuotas.Text) Then txtCuotas.Text = "1"
      If Not IsNumeric(txtIntereses.Text) Then txtIntereses.Text = "0.00"

      Dim result As Reglas.Ventas.Fichas.CalcularImporteCuotaResult
      result = New Reglas.Ventas.Fichas().CalcularImporteCuota(Integer.Parse(txtCuotas.Text), Decimal.Parse(Me.txtSubTotal.Text), Decimal.Parse(Me.txtIntereses.Text))

      Me.txtImpCuota.Text = result.ImporteCuota.ToString("N2")
      Me.txtTotalCuotas.Text = result.ImporteTotalCuotas.ToString("N2")
      txtInteresCuota.Text = result.InteresesCuota.ToString("N2")
      txtCapitalCuota.Text = result.CapitalCuota.ToString("N2")
   End Sub

   Private Sub CalcularTotal()
      Dim total As Decimal = 0
      If Not IsNumeric(txtAnticipo.Text) Then txtAnticipo.Text = "0"
      If Not String.IsNullOrEmpty(Me.txtCuotas.Text) Then
         total = (Decimal.Parse(Me.txtImpCuota.Text) * Decimal.Parse(Me.txtCuotas.Text)) + Decimal.Parse(Me.txtAnticipo.Text)
      Else
         total = Decimal.Parse(Me.txtImpCuota.Text) + Decimal.Parse(Me.txtAnticipo.Text)
      End If
      Me.txtTotal.Text = total.ToString("#0.00")
   End Sub

   Private Sub CalcularSubTotal()
      If Me.txtBruto.Text.Length = 0 Then Me.txtBruto.Text = "0"
      If Not IsNumeric(txtAnticipo.Text) Then txtAnticipo.Text = "0"
      Me.txtSubTotal.Text = (Decimal.Parse(Me.txtBruto.Text) - Decimal.Parse(Me.txtAnticipo.Text)).ToString("#,##0.00")

      NuevoCalculoIntereses()

   End Sub

   Private Sub CargarGrillaCuotas()
      If cmbFormaPago.SelectedIndex = -1 Then Exit Sub
      Me.oFichaPagos.Clear()

      Dim formaPago As Entidades.VentaFormaPago = New Eniac.Reglas.VentasFormasPago().GetUna(Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString()))

      Dim totalCuotas As Decimal = 0

      If Not String.IsNullOrEmpty(Me.txtCuotas.Text) Then
         Dim DiasCC As Integer = formaPago.Dias
         Dim i As Integer = 0
         Dim anticipo As Decimal = 0
         If IsNumeric(txtAnticipo.Text) Then anticipo = Decimal.Parse(txtAnticipo.Text)
         If anticipo <> 0 Then
            Dim pag As Eniac.Entidades.FichaPago = New Eniac.Entidades.FichaPago(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
            pag.FechaVencimiento = Me.dtpFecha.Value
            pag.Importe = Decimal.Parse(Me.txtAnticipo.Text)
            pag.Saldo = Decimal.Parse(Me.txtAnticipo.Text)
            pag.IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
            pag.NroOperacion = Integer.Parse(Me.txtNroOperacion.Text)
            pag.NroCuota = i '+ 1
            Me.oFichaPagos.Add(pag)
         End If

         Dim sumaAnticipoCuotas As Decimal = Decimal.Parse(Me.txtAnticipo.Text)
         totalCuotas = 0
         Dim totalADistribuir As Decimal = Decimal.Parse(Me.txtSubTotal.Text) + Decimal.Parse(txtIntereses.Text) + sumaAnticipoCuotas

         Dim importeCuota As Decimal = 0
         If IsNumeric(txtImpCuota.Text) Then importeCuota = Decimal.Parse(txtImpCuota.Text)

         If importeCuota <> 0 Then
            Dim ultimaFecha As DateTime            'Última fecha de vencimiento calculada (contemplando Sab/Dom/Fer)
            Dim ultimaFechaTeorica As DateTime     'Última fecha de venc. TEORICA calculada (ignorando Sab/Dom/Fer)

            If dtpPrimerVencimiento.Checked Then
               ultimaFecha = dtpPrimerVencimiento.Value.AddDays(DiasCC * -1)
               ultimaFechaTeorica = ultimaFecha
            Else
               ultimaFecha = dtpFecha.Value
               ultimaFechaTeorica = ultimaFecha
            End If

            Dim referenciaCuota = txtReferenciaCuota.ValorNumericoPorDefecto(0L)
            For i = 1 To Integer.Parse(Me.txtCuotas.Text)
               Dim pag As Eniac.Entidades.FichaPago = New Eniac.Entidades.FichaPago(actual.Sucursal.Id, actual.Nombre, actual.Pwd)

               'Si tengo que seguir contando las cuotas desde la última teórica calculada (por más que haya sido feriado)
               'tomo esa fecha y la pongo como última fecha para calcular la próxima.
               If formaPago.FechaBaseProximaCuota = Entidades.VentaFormaPago.ProximaCuota.TEORICA Then
                  ultimaFecha = ultimaFechaTeorica
               End If

               'Le sumo la cantidad de días de la Forma de Pago a la última fecha de vencimiento.
               ultimaFecha = ultimaFecha.AddDays(DiasCC)
               'La copia a la TEORICA antes de analizar Sab/Dom/Fer
               ultimaFechaTeorica = ultimaFecha
               While Not EsDiaValido(ultimaFecha, formaPago)
                  'Incrmento un día si la fecha no es válida (según Exclusiones de la forma de pago)
                  ultimaFecha = ultimaFecha.AddDays(1)
               End While

               If Not dtpPrimerVencimiento.Checked And i = 1 Then
                  Try
                     dtpPrimerVencimiento_ValueChanged_interno = True
                     dtpPrimerVencimiento.Value = ultimaFecha
                     dtpPrimerVencimiento.Checked = False
                  Finally
                     dtpPrimerVencimiento_ValueChanged_interno = False
                  End Try
               End If

               'Tomo la fecha calculada como fecha de vencimiento.
               pag.FechaVencimiento = ultimaFecha
               pag.ImporteCapital = Decimal.Parse(Me.txtCapitalCuota.Text)
               pag.ImporteInteres = Decimal.Parse(Me.txtInteresCuota.Text)
               pag.Importe = importeCuota
               pag.Saldo = Decimal.Parse(Me.txtImpCuota.Text)
               pag.IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
               pag.NroOperacion = Integer.Parse(Me.txtNroOperacion.Text)
               pag.NroCuota = i '+ 1
               pag.ReferenciaCuota = referenciaCuota
               referenciaCuota += 1
               totalCuotas += pag.Importe
               Me.oFichaPagos.Add(pag)
            Next
         End If

         sumaAnticipoCuotas += totalCuotas

         If Math.Round(totalADistribuir - sumaAnticipoCuotas, 2) <> 0 Then
            oFichaPagos(oFichaPagos.Count - 1).Importe += Math.Round(totalADistribuir - sumaAnticipoCuotas, 2)
            oFichaPagos(oFichaPagos.Count - 1).Saldo += Math.Round(totalADistribuir - sumaAnticipoCuotas, 2)
            oFichaPagos(oFichaPagos.Count - 1).ImporteCapital += Math.Round(totalADistribuir - sumaAnticipoCuotas, 2)
            totalCuotas += Math.Round(totalADistribuir - sumaAnticipoCuotas, 2)
         End If
      Else
         Dim pag As Eniac.Entidades.FichaPago = New Eniac.Entidades.FichaPago(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
         pag.FechaVencimiento = Me.dtpFecha.Value
         pag.Importe = Decimal.Parse(Me.txtImpCuota.Text)
         pag.Saldo = Decimal.Parse(Me.txtImpCuota.Text)
         pag.IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         If Me.txtNroOperacion.Text.Length > 0 Then
            pag.NroOperacion = Integer.Parse(Me.txtNroOperacion.Text)
         End If
         Me.oFichaPagos.Add(pag)
      End If               'If Not String.IsNullOrEmpty(Me.txtCuotas.Text) Then
      Me.dgvCuotas.DataSource = Me.oFichaPagos.ToArray()

      txtTotalCuotas.Text = totalCuotas.ToString("N2")
      txtTotal.Text = (totalCuotas + Decimal.Parse(txtAnticipo.Text)).ToString("N2")

   End Sub

   Private Function EsDiaValido(dia As DateTime, fp As Entidades.VentaFormaPago) As Boolean
      If dia.DayOfWeek = DayOfWeek.Saturday And fp.ExcluyeSabados Then
         'Si el día es Sábado y la Forma de Pago no tiene que Incluir Sábados es un día INVALIDO
         Return False
      ElseIf dia.DayOfWeek = DayOfWeek.Sunday And fp.ExcluyeDomingos Then
         'Si el día es Domingo y la Forma de Pago no tiene que Incluir Domingos es un día INVALIDO
         Return False
      ElseIf fp.ExcluyeFeriados AndAlso _cache.EsFeriado(dia) Then
         'Si la Forma de Pago no tiene que Incluir Feriados y el día es un Feriado es un día INVALIDO
         Return False
      Else
         Return True
      End If
   End Function

   Private Function GetVendedorCombo(id As Integer) As Object
      Dim empleados As List(Of Entidades.Empleado) = DirectCast(Me.cmbVendedor.DataSource, List(Of Entidades.Empleado))
      For Each emp As Entidades.Empleado In empleados
         If id = emp.IdEmpleado Then
            Return emp
         End If
      Next
      Return Nothing
   End Function

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString.Trim()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString.Trim()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString.Trim()

      Me.cmbVendedor.SelectedValue = Integer.Parse(dr.Cells("IdVendedor").Value.ToString.Trim())
      Me.cmbCobrador.SelectedValue = Integer.Parse(dr.Cells("IdCobrador").Value.ToString.Trim())

      Me._clienteGrilla = New Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()))

      Me.bscDireccion.Text = dr.Cells("Direccion").Value.ToString.Trim()
      'Me.bscDireccion.Enabled = True
      Me.txtLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      Me.txtTelefono.Text = dr.Cells("Telefono").Value.ToString() & " " & dr.Cells("Celular").Value.ToString()
      Dim impresora As Eniac.Entidades.Impresora
      impresora = New Eniac.Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, _idTipoComprobante)
      Dim oventasnum As Eniac.Reglas.VentasNumeros = New Eniac.Reglas.VentasNumeros
      txtIdSucursal.Text = actual.Sucursal.Id.ToString()
      txtIdTipoComprobante.Text = _idTipoComprobante
      txtLetra.Text = _letra
      txtCentroEmisor.Text = impresora.CentroEmisor.ToString()
      Me.txtNroOperacion.Text = oventasnum.GetProximoNumero(actual.Sucursal, _idTipoComprobante, _letra, impresora.CentroEmisor).ToString()
      Me.txtNroOperacion.ReadOnly = False
      Me.VerOperaciones(False)
      tbcFichas.Enabled = True
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False
      Me.bscDireccion.Enabled = False

      Me.txtComentario.Focus()

      Me.txtObservacion.Text = dr.Cells("Observacion").Value.ToString()

      cmbListaDePrecios.SelectedIndex = -1
      Me.cmbListaDePrecios.SelectedValue = Integer.Parse(dr.Cells("IdListaPrecios").Value.ToString())

      CargaGrillaAdjuntos(actual.Sucursal.Id, _idTipoComprobante, _letra, impresora.CentroEmisor, Long.Parse(txtNroOperacion.Text), _clienteGrilla.IdCliente)

      If _clienteGrilla IsNot Nothing AndAlso _clienteGrilla.VarPesosCotizDolar <> 0 Then
         _DolarCotizacion = _DolarCotizacion + Decimal.Parse(_clienteGrilla.VarPesosCotizDolar.ToString())
      End If

      'Me.CambiarEstadoControlesDetalle(True)
   End Sub

   Private Sub VerOperaciones(todas As Boolean)
      If Me.bscCodigoCliente.Text <> "" Then
         Using oOperPend As FichasPendientes1 = New FichasPendientes1(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), todas)
            If oOperPend.HayRegistro Then
               If todas Then
                  oOperPend.Text += " de " & Me.bscCliente.Text
               Else
                  oOperPend.Text += " pendientes de " & Me.bscCliente.Text
               End If
               oOperPend.ShowDialog()
               If oOperPend.Selecciono Then
                  txtIdSucursal.Text = oOperPend.IdSucursalSeleccionado.ToString()
                  txtIdTipoComprobante.Text = oOperPend.IdTipoComprobanteSeleccionado
                  txtLetra.Text = oOperPend.LetraSeleccionado
                  txtCentroEmisor.Text = oOperPend.CentroEmisorSeleccionado.ToString()
                  Me.txtNroOperacion.Text = oOperPend.NumeroComprobanteSeleccionado.ToString()
                  Me.txtNroOperacion.ReadOnly = True

                  ''Alguna PC paso el control de la fecha maxima y tiene fecha larga asi que le actualizo el maximo.
                  Me.dtpFecha.MaxDate = oOperPend.FechaOperacion
                  Me.dtpFecha.Value = oOperPend.FechaOperacion
                  Me.PrepararFichaParaPago()
               Else
                  grbTotales.Enabled = True
                  btnGrabarAdjuntos.Visible = False
               End If
            Else
               grbTotales.Enabled = True
            End If
         End Using
      Else
         MessageBox.Show("Debe seleccionar un cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         bscCodigoCliente.Focus()
      End If

   End Sub

   Private Sub PrepararFichaParaPago()
      Me.RecuperarDatosDeFicha()
      Me.txtComentario.Enabled = True
      Me.cmbCobrador.Enabled = False
      Me.cmbVendedor.Enabled = False
      Me.tbcFichas.SelectedTab = Me.tbpPagos
      Me.btnInsertar.Enabled = False
      Me.btnEliminar.Enabled = False
      Me.tsbGrabar.Enabled = False
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False
      Me.dtpFecha.Enabled = False
      Me.grbTotales.Enabled = False

      cmbListaDePrecios.Enabled = False

      btnGrabarAdjuntos.Visible = True

      'btnInsertarAdjunto.Enabled = False
      'btnEliminarAdjunto.Enabled = False

   End Sub

   Private Sub RecuperarDatosDeFicha()
      ' Dim oFichas As Eniac.Fichas.Reglas.Fichas = New Eniac.Fichas.Reglas.Fichas()
      ' Dim oFicha As Eniac.Fichas.Entidades.Ficha = oFichas.GetUna(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Integer.Parse(Me.txtNroOperacion.Text), actual.Sucursal.Id)
      Me._ventasProductos.Clear()
      _ventasProductosLotes.Clear()

      Me.oFichaPagos.Clear()
      Me.oFichaPagosDetalle.Clear()
      'Dim impresora As Eniac.Entidades.Impresora
      'impresora = New Eniac.Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, _idTipoComprobante)

      Dim oVentas As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas()
      eFicha = oVentas.GetUna(Integer.Parse(txtIdSucursal.Text), txtIdTipoComprobante.Text, txtLetra.Text, Short.Parse(txtCentroEmisor.Text), Long.Parse(Me.txtNroOperacion.Text))

      Dim oCliente As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes()
      Me._clienteGrilla = oCliente.GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()))

      Dim cuotas As Eniac.Entidades.CuentaCorriente
      cuotas = eFicha.CuentaCorriente

      Dim oCuotas As Eniac.Reglas.CuentasCorrientes = New Eniac.Reglas.CuentasCorrientes
      Dim pagos As DataTable
      pagos = oCuotas.GetPagos(Integer.Parse(txtIdSucursal.Text), txtIdTipoComprobante.Text, txtLetra.Text, Short.Parse(txtCentroEmisor.Text), Long.Parse(Me.txtNroOperacion.Text))

      With eFicha
         Me._estado = Estados.Modificacion
         Me._fichaAnulada = (.IdEstadoComprobante = "ANULADO")

         Dim bruto As Decimal = 0

         'Carga los productos
         For Each prod As Eniac.Entidades.VentaProducto In eFicha.VentasProductos
            Dim oFichaProd As Entidades.VentaProducto = New Entidades.VentaProducto()
            With oFichaProd
               .Producto = prod.Producto
               .Producto.NombreProducto = prod.NombreProducto
               .Cantidad = Convert.ToInt32(prod.Cantidad)
               '.Precio = Math.Round(prod.Precio + (prod.ImporteImpuesto / .Cantidad), _decimalesAMostrarEnPrecio)
               .Precio = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(prod.Precio, prod.AlicuotaImpuesto, prod.PorcImpuestoInterno, prod.Producto.ImporteImpuestoInterno, prod.OrigenPorcImpInt), _decimalesAMostrarEnPrecio)
               '.Cliente = oFicha.Cliente
               .NumeroComprobante = eFicha.NumeroComprobante
               If Me.dtpEntrego.Checked Then
                  .FechaEntrega = Me.dtpEntrego.Value
               Else
                  .FechaEntrega = Nothing
               End If
               .Garantia = prod.Garantia
               .FechaEntrega = prod.FechaEntrega
               .ImporteTotal = .Precio * .Cantidad
               'If Not Me.bscProveedor.FilaDevuelta Is Nothing Then
               '   .Proveedor = New Proveedores().GetUno(Long.Parse(Me.bscProveedor.FilaDevuelta.Cells("IdProveedor").Value.ToString()))
               'End If

               bruto += .ImporteTotal
            End With
            _ventasProductos.Add(oFichaProd)

         Next

         Me.txtComentario.Text = .Observacion
         Me.cmbFormaPago.SelectedValue = .FormaPago.IdFormasPago

         Me.txtBruto.Text = bruto.ToString("N2")
         Me.txtAnticipo.Text = .ImportePesos.ToString("0.00")
         Me.txtSubTotal.Text = (bruto - .ImportePesos).ToString("0.00")

         Me.txtCuotas.Text = cuotas.CantidadCuotas.ToString()   ' (cuotas.CantidadCuotas - 1).ToString()
         'Estoy multiplicando por 1.21 porque no se a que IVA lo debo hacer y cambiar la lógica de todo llevaría muchas más horas de lo que debe ser.
         Me.txtIntereses.Text = (.DescuentoRecargo * 1.21).ToString("0.00")

         Me.txtTotal.Text = .ImporteTotal.ToString("0.00")

         SetDataSourceProductos()


         If pagos.Rows.Count <> 0 Then
            Me.dgvPagos.Visible = True

            For Each dr As DataRow In pagos.Rows
               Dim oFichaPagoDetalle As Eniac.Entidades.FichaPagoDetalle = New Eniac.Entidades.FichaPagoDetalle(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
               With oFichaPagoDetalle
                  .NroOperacion = Integer.Parse(dr("NumeroComprobante").ToString())
                  .NroCuota = Integer.Parse(dr("CuotaNumero").ToString())
                  .IdCliente = Long.Parse(dr("IdCliente").ToString())
                  .FechaPago = DateTime.Parse(dr("Fecha").ToString())
                  .Importe = Decimal.Parse(dr("ImporteTotal").ToString()) * -1   'El query devuelve los pagos en negativo. Los damos vuelta para que quede claro.
                  .IdCobrador = Integer.Parse(dr("IdCobrador").ToString())
                  .NombreCobrador = dr("NombreCobrador").ToString()
                  .IdCaja = Integer.Parse(dr("IdCaja").ToString())
                  .NumeroPlanilla = Integer.Parse(dr("NumeroPlanilla").ToString())
                  .NumeroMovimiento = Integer.Parse(dr("NumeroMovimiento").ToString())
               End With
               Me.oFichaPagosDetalle.Add(oFichaPagoDetalle)
            Next
            Me.dgvPagos.DataSource = oFichaPagosDetalle.ToArray()
         Else
            Me.dgvPagos.Visible = False
         End If

         Me.CalcularImporteCuota()

         oFichaPagos.Clear()

         Dim totalCuota As Decimal = 0 - Decimal.Parse(txtAnticipo.Text)
         For Each cuota As Eniac.Entidades.CuentaCorrientePago In cuotas.Pagos
            Dim pag As Eniac.Entidades.FichaPago = New Eniac.Entidades.FichaPago(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
            pag.FechaVencimiento = cuota.FechaVencimiento
            pag.Importe = cuota.ImporteCuota
            totalCuota += pag.Importe
            pag.ImporteCapital = cuota.ImporteCapital
            pag.ImporteInteres = cuota.ImporteInteres
            pag.Saldo = cuota.SaldoCuota
            ' pag.IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
            pag.NroOperacion = Integer.Parse(cuota.NumeroComprobante.ToString())
            pag.NroCuota = cuota.Cuota
            pag.ReferenciaCuota = cuota.ReferenciaCuota
            Me.oFichaPagos.Add(pag)
         Next

         txtTotalCuotas.Text = totalCuota.ToString("N2")

         Me.dgvCuotas.DataSource = oFichaPagos.ToArray()

         For i As Integer = 0 To cuotas.Pagos.Count - 1
            If cuotas.Pagos(i).SaldoCuota <> 0 Then
               Me._primerSaldo = cuotas.Pagos(i).SaldoCuota
               Me._cuotanumero = cuotas.Pagos(i).Cuota
               Me.dgvCuotas.FirstDisplayedScrollingRowIndex = i
               Me.dgvCuotas.Focus()
               Exit For
            End If
         Next

         cmbCobrador.SelectedValue = .Cobrador.IdEmpleado

         ComboBoxHelper.SetVendedorCombo(cmbVendedor, .Vendedor)
         Me.txtSaldo.Text = cuotas.Saldo.ToString("#,##0.00")
         tsbAnular.Enabled = Not _fichaAnulada And (cuotas.Saldo = eFicha.ImporteTotal)
         'Me.tsbAnular.Enabled = (Not Me._fichaAnulada) And (Double.Parse(Me.txtSaldo.Text) = Double.Parse(Me.txtTotalCuotas.Text))
         Me.tsbImprimirFicha.Enabled = Not Me._fichaAnulada
         Me.tsbImpFichaCliente.Enabled = Not Me._fichaAnulada
         Me.tsbImprimirFichaCtaCte.Enabled = Not Me._fichaAnulada
         Me.tsbPago.Enabled = Not Me._fichaAnulada
         Me.tsbCancelarFicha.Enabled = Me.tsbPago.Enabled
         If Me._fichaAnulada Then
            Me.tsbDevolverPago.Enabled = False
            Me.Text = "Fichas - ANULADA !!!!!!!!!!!!!!"
         Else
            Me.tsbDevolverPago.Enabled = Me._puedeDevolverPago
            Me.Text = "Fichas"
         End If
         .Cliente.IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())

         ' Me.tsbRevisado.Visible = oFichas.HayQueRevisar(oFicha)

         ''si esta operacion tiene cartas emitidas se van a mostrar
         'Dim dtCa As DataTable = oFichas.GetCartasEmitidas(oFicha)
         'If dtCa.Rows.Count > 0 Then
         '   If Me.tbcFichas.TabPages.IndexOf(Me.tbpCartasEmitidas) = -1 Then
         '      Me.dgvCartasEmitidas.DataSource = dtCa
         '      Me.tbcFichas.TabPages.Add(Me.tbpCartasEmitidas)
         '   End If
         'Else
         '   If Me.tbcFichas.TabPages.IndexOf(Me.tbpCartasEmitidas) > -1 Then
         '      Me.tbcFichas.TabPages.Remove(Me.tbpCartasEmitidas)
         '   End If
         'End If

         CargaGrillaAdjuntos(.IdSucursal, .IdTipoComprobante, .LetraComprobante, .CentroEmisor, .NumeroComprobante, .Cliente.IdCliente)
      End With

   End Sub

   Private Sub CargaGrillaAdjuntos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                   idCliente As Long)
      _adjuntos = New Entidades.ListConBorrados(Of Entidades.IAdjunto)()
      For Each adj As Entidades.VentaAdjunto In New Reglas.VentasAdjuntos().GetTodos(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, False)
         _adjuntos.Add(adj)
      Next

      For Each adj As Entidades.ClienteAdjunto In New Reglas.ClientesAdjuntos().GetTodos(idCliente, False)
         _adjuntos.Add(adj)
      Next

      ugAdjunto.DataSource = _adjuntos
      AjustarColumnasGrilla(ugAdjunto, _titAdjuntos)
   End Sub

   Private Sub Nuevo()
      Me._estado = Estados.Insercion
      Me.Text = "Fichas"
      Me.txtSaldo.Text = "0.00"
      Me.cmbCobrador.Enabled = True
      Me.cmbVendedor.Enabled = True
      Me.txtSubTotal.Enabled = True
      cmbListaDePrecios.Enabled = True
      Me.txtTotal.Enabled = True
      Me.txtAnticipo.Enabled = True
      Me.txtComentario.Enabled = True
      Me.tsbPago.Enabled = False
      Me.tsbCancelarFicha.Enabled = False
      Me.tsbDevolverPago.Enabled = False
      Me.tbcFichas.SelectedTab = Me.tbpProductos
      'Me.dgvPagos.DataSource = New Entidades.FichaPagoDetalle()
      Me.dgvPagos.Visible = False
      tbcFichas.Enabled = True

      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCliente.Text = String.Empty
      Me.bscCodigoCliente.Tag = Nothing
      Me._clienteGrilla = Nothing
      'Me.bscProveedor.Text = String.Empty
      'Me.bscProveedor.FilaDevuelta = Nothing
      Me.txtBruto.Enabled = True
      Me.bscCliente.Enabled = True
      Me.bscCodigoCliente.Enabled = True
      Me.bscDireccion.Enabled = True
      Me.dtpFecha.Enabled = True
      txtIdSucursal.Text = "0"
      txtIdTipoComprobante.Text = String.Empty
      txtLetra.Text = String.Empty
      txtCentroEmisor.Text = "0"
      Me.txtNroOperacion.Text = "0"
      Me.txtNroOperacion.ReadOnly = True
      Me._ventasProductos.Clear()
      _ventasProductosLotes.Clear()
      SetDataSourceProductos()
      Me.txtLocalidad.Text = String.Empty
      Me.txtTelefono.Text = String.Empty
      Me.txtBruto.Text = "0"
      Me.txtAnticipo.Text = String.Empty
      Me.txtTotal.Text = String.Empty
      Me.oFichaPagos.Clear()
      Me.oFichaPagosDetalle.Clear()
      Me.dgvCuotas.DataSource = Me.oFichaPagos.ToArray()
      Me.dgvPagos.DataSource = Me.oFichaPagosDetalle.ToArray()
      Me.bscDireccion.Text = String.Empty
      'Me.bscDireccion.Enabled = False
      Me.txtComentario.Text = String.Empty

      'valido que no puedan ingresar la fecha de la ficha mayor a 3 dias de la fecha de hoy
      'los 3 dias son por si quieren facturar el viernes las cosas del sabado o domingo
      Me.dtpFecha.MaxDate = Date.Now.AddDays(3)

      Me.dtpFecha.Value = Date.Now
      Me.txtSubTotal.Text = "0"
      Me.txtTotalCuotas.Text = String.Empty
      Me.bscProducto.Text = String.Empty
      Me.txtStock.Text = String.Empty
      Me.txtCantidad.Text = "0"
      Me.txtPrecio.Text = "0"
      Me.txtTotalProducto.Text = "0"
      Me.dtpEntrego.Enabled = True
      Me.dtpEntrego.Checked = True
      Me.txtCuotas.Text = "1"
      cmbFormaPago.SelectedIndex = -1
      Me.txtIntereses.Text = String.Empty
      txtInteresCuota.Text = String.Empty
      txtCapitalCuota.Text = String.Empty
      Me.txtImpCuota.Text = String.Empty
      Me.btnInsertar.Enabled = True
      Me.btnEliminar.Enabled = True
      Me.tsbGrabar.Enabled = True
      Me.grbTotales.Enabled = False
      tbcFichas.Enabled = False

      btnInsertarAdjunto.Enabled = True
      btnEliminarAdjunto.Enabled = True

      btnGrabarAdjuntos.Visible = False

      Me._numeroOrden = 0
      If Me.cmbCobrador.Items.Count > 0 Then
         Me.cmbCobrador.SelectedIndex = 0
      Else
         Me.cmbCobrador.SelectedIndex = -1
      End If
      If Me.cmbVendedor.Items.Count > 0 Then
         Me.cmbVendedor.SelectedIndex = 0
      Else
         Me.cmbVendedor.SelectedIndex = -1
      End If
      Me.cmbCajas.SelectedIndex = 0
      Me.tsbAnular.Enabled = False
      Me.tsbImprimirFicha.Enabled = False
      Me.tsbImpFichaCliente.Enabled = False
      Me.tsbImprimirFichaCtaCte.Enabled = False
      Me.tsbRevisado.Visible = False

      Me.cmbListaDePrecios.SelectedValue = Publicos.ListaPreciosPredeterminada

      'eliminar la pestana de las cartas emitidas
      If Me.tbcFichas.TabPages.IndexOf(Me.tbpCartasEmitidas) > -1 Then
         Me.tbcFichas.TabPages.Remove(Me.tbpCartasEmitidas)
      End If

      Me._primerSaldo = 0


      If Me.tbcFichas.SelectedTab Is tbpFacturables Then
         Me.tbcFichas.SelectedTab = tbpProductos
      End If

      If Me._comprobantesSeleccionados IsNot Nothing Then
         Me._comprobantesSeleccionados.Clear()
      End If

      Me._ventasObservaciones.Clear()

      SetDataSourceObservaciones(Me._ventasObservaciones.ToArray())

      Me.dgvFacturables.DataSource = Me._comprobantesSeleccionados


      Me.bscCliente.Permitido = True
      Me.bscCodigoCliente.Permitido = True

      Me.bscCodigoCliente.Focus()

   End Sub
   Private Sub ImprimirFichaCtaCte()
      Try
         Me.Cursor = Cursors.WaitCursor

         Dim dtCtaCte As DataTable = New DataTable()
         dtCtaCte.Columns.Add("NroCuota")
         dtCtaCte.Columns.Add("FechaVencimiento")
         dtCtaCte.Columns.Add("ImporteCapital")
         dtCtaCte.Columns.Add("ImporteInteres")
         dtCtaCte.Columns.Add("Saldo")
         dtCtaCte.Columns.Add("NroCuotaPaga")
         dtCtaCte.Columns.Add("FechaPago")
         dtCtaCte.Columns.Add("Importe")
         dtCtaCte.Columns.Add("Cobrador")
         dtCtaCte.Columns.Add("Caja")
         dtCtaCte.Columns.Add("Plan")
         dtCtaCte.Columns.Add("Movimiento")

         For Each oFicha As Entidades.FichaPago In oFichaPagos
            Dim row As DataRow = dtCtaCte.NewRow()
            row("NroCuota") = oFicha.NroCuota
            row("FechaVencimiento") = oFicha.FechaVencimiento.ToString("dd/MM/yyyy")
            row("ImporteCapital") = oFicha.ImporteCapital
            row("ImporteInteres") = oFicha.ImporteInteres
            row("Saldo") = oFicha.Saldo
            dtCtaCte.Rows.Add(row)
         Next

         For i As Integer = 0 To oFichaPagosDetalle.Count - 1
            Dim drCuota As DataRow

            If dtCtaCte.Rows.Count > i Then
               drCuota = dtCtaCte.Rows(i)
            Else
               drCuota = dtCtaCte.NewRow()
               dtCtaCte.Rows.Add(drCuota)
            End If

            drCuota("NroCuotaPaga") = oFichaPagosDetalle(i).NroCuota
            drCuota("FechaPago") = oFichaPagosDetalle(i).FechaPago.ToString("dd/MM/yyyy")
            drCuota("Importe") = oFichaPagosDetalle(i).Importe
            drCuota("Cobrador") = oFichaPagosDetalle(i).NombreCobrador
            drCuota("Caja") = oFichaPagosDetalle(i).IdCaja
            drCuota("Plan") = oFichaPagosDetalle(i).NumeroPlanilla
            drCuota("Movimiento") = oFichaPagosDetalle(i).NumeroMovimiento
         Next



         If dtCtaCte.Rows.Count > 0 Then

            Dim impresionFichas As ImpresionFichas = New ImpresionFichas()
            impresionFichas.ImprimirFichaCtaCte(Integer.Parse(txtIdSucursal.Text), txtIdTipoComprobante.Text, txtLetra.Text, Short.Parse(txtCentroEmisor.Text), Long.Parse(Me.txtNroOperacion.Text), dtCtaCte)

         End If

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub ImprimirFicha()
      Try
         Me.Cursor = Cursors.WaitCursor

         Dim impresionFichas As ImpresionFichas = New ImpresionFichas()
         impresionFichas.ImprimirFicha(Integer.Parse(txtIdSucursal.Text), txtIdTipoComprobante.Text, txtLetra.Text, Short.Parse(txtCentroEmisor.Text), Long.Parse(Me.txtNroOperacion.Text))

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub ImprimirFichaCliente()
      Try
         Me.Cursor = Cursors.WaitCursor

         Dim impresionFichas As ImpresionFichas = New ImpresionFichas()
         impresionFichas.ImprimirFichaCliente(Integer.Parse(txtIdSucursal.Text), txtIdTipoComprobante.Text, txtLetra.Text, Short.Parse(txtCentroEmisor.Text), Long.Parse(Me.txtNroOperacion.Text))
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Function ValidarInsertaProducto() As Boolean
      If Double.Parse(Me.txtPrecio.Text) <= 0 Then
         MessageBox.Show("No puede ingresar un producto con precio cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtPrecio.Focus()
         Return False
      End If
      Dim CategoriaFiscalCliente As Entidades.CategoriaFiscal = New Entidades.CategoriaFiscal()

      CategoriaFiscalCliente = Me._clienteGrilla.CategoriaFiscal

      If Not CategoriaFiscalCliente.IvaDiscriminado And Not CategoriaFiscalCliente.SolicitaCUIT And CategoriaFiscalCliente.LetraFiscal <> "E" _
             And (Decimal.Parse(Me.txtTotal.Text.ToString()) + (Decimal.Parse(Me.txtCantidad.Text.ToString()) * Decimal.Parse(Me.txtPrecio.Text.ToString()))) >= Reglas.Publicos.Facturacion.FacturacionControlaTopeCF And _clienteGrilla.NroDocCliente = 0 AndAlso
             GetTipoComprobante().ControlaTopeConsumidorFinal Then

         If Reglas.Publicos.Facturacion.FacturacionControlaDNIClienteConsumidorFinal Or (Not Reglas.Publicos.Facturacion.FacturacionControlaDNIClienteConsumidorFinal And (GetTipoComprobante().GrabaLibro Or
            GetTipoComprobante().EsPreElectronico)) Then

            ShowMessage(String.Format("ATENCION: El Cliente es Consumidor Final y el Total de Comprobante es $ {0} o mas. El DNI es obligatorio.", Reglas.Publicos.Facturacion.FacturacionControlaTopeCF))
         End If

      End If

      Return True
   End Function

   Private Sub CargarUnArticulo(linea As Eniac.Entidades.VentaProducto,
                                idProducto As String,
                                productoDescripcion As String,
                                descuentoRecargoPorc1 As Decimal,
                                descuentoRecargoPorc2 As Decimal,
                                descuentoRecargo As Decimal,
                                precio As Decimal,
                                cantidad As Decimal,
                                importeTotal As Decimal,
                                stock As Decimal,
                                costo As Decimal,
                                precioLista As Decimal,
                                kilos As Decimal,
                                idTipoImpuesto As Eniac.Entidades.TipoImpuesto.Tipos,
                                porcentajeIva As Decimal,
                                importeIva As Decimal,
                                precioNeto As Decimal,
                                FechaActualizacion As Date,
                                garantia As Integer,
                                fechaEntrega As DateTime)

      With linea
         .TipoComprobante = String.Empty
         .Letra = String.Empty
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         .Producto = New Eniac.Reglas.Productos().GetUno(idProducto)  'Luego uso ciertas caracteristicas (ej: LOTE).
         .Producto.NombreProducto = productoDescripcion   'Piso la descripcion por si tiene habilitado la posibilidad de cambiarlas.
         .DescuentoRecargoPorc1 = descuentoRecargoPorc1
         .DescuentoRecargoPorc2 = descuentoRecargoPorc2
         .DescuentoRecargo = descuentoRecargo
         .Precio = precio
         .Cantidad = cantidad
         .ImporteTotal = importeTotal
         .Stock = stock
         .Costo = costo
         .PrecioLista = precioLista
         .Kilos = kilos
         .PrecioNeto = precioNeto
         .AlicuotaImpuesto = porcentajeIva
         .ImporteImpuesto = importeIva
         .TipoImpuesto = New Eniac.Reglas.TiposImpuestos().GetUno(idTipoImpuesto)
         .ComisionVendedorPorc = 0
         .ComisionVendedor = 0
         .IdListaPrecios = Integer.Parse(Me.cmbListaDePrecios.SelectedValue.ToString())
         .NombreListaPrecios = Me.cmbListaDePrecios.Text
         .FechaActualizacion = FechaActualizacion
         .ImporteImpuestoInterno = 0
         .Garantia = garantia
         .FechaEntrega = fechaEntrega
      End With

   End Sub

   Private _nrosSerieVentaProducto As List(Of String)

   Private Sub CargarProductoCompleto(dr As DataGridViewRow)
      Dim oProductos As Reglas.Productos = New Reglas.Productos()
      Dim oProv As Reglas.Proveedores = New Reglas.Proveedores()

      Me.bscCodigoProducto2.Text = dr.Cells(Entidades.Producto.Columnas.IdProducto.ToString()).Value.ToString()
      'Me.bscProducto.Datos = oProductos.GetPorCodigo(dr.Cells("IdProducto").Value.ToString().Trim(), actual.Sucursal.Id, 0, "VENTAS")

      If Not Me.bscCodigoProducto2.Enabled Then
         bscCodigoProducto2.Enabled = True
         Me.bscCodigoProducto2.PresionarBoton()
         bscCodigoProducto2.Enabled = False
      Else
         Me.bscCodigoProducto2.PresionarBoton()
      End If


      If dr.Cells("FechaEntrega").Value IsNot Nothing Then
         Me.dtpEntrego.Value = Date.Parse(dr.Cells("FechaEntrega").Value.ToString())
      End If

      Me.txtPrecio.Text = Decimal.Round(Decimal.Parse(dr.Cells("Precio").Value.ToString()), 2).ToString("#,##0.00")
      ''Me.txtStock.Text = dr.Cells("Stock").Value.ToString()
      Me.txtCantidad.Text = dr.Cells("Cantidad").Value.ToString()
      Me.txtGarantia.Text = dr.Cells("Garantia").Value.ToString()

      'If DirectCast(dr.Cells("NombreProveedor").Value, Proveedor).IdProveedor > 0 Then
      '   Me.bscProveedor.Text = DirectCast(dr.Cells("NombreProveedor").Value, Proveedor).NombreProveedor
      '   Me.bscProveedor.Datos = oProv.GetFiltradoPorCodigo(DirectCast(dr.Cells("NombreProveedor").Value, Proveedor).CodigoProveedor, False)
      '   Me.bscProveedor.PresionarBoton()
      'End If

      Me.txtTotalProducto.Text = dr.Cells("ImporteTotal").Value.ToString()

      If _ventasProductosLotes.ContainsKey(DirectCast(dr.DataBoundItem, Entidades.VentaProducto)) Then
         _nrosSerieVentaProducto = _ventasProductosLotes(DirectCast(dr.DataBoundItem, Entidades.VentaProducto))
      Else
         _nrosSerieVentaProducto = Nothing
      End If
   End Sub

   Private Sub InsertarProducto()
      '--------------------------VENTAS--------------------------------------

      'cargo los valores de los controles a variables locales---------------------
      Dim oLineaDetalle As Eniac.Entidades.VentaProducto = New Eniac.Entidades.VentaProducto()
      Dim filaDevuelta As DataGridViewRow
      If Me.bscProducto.FilaDevuelta IsNot Nothing Then
         filaDevuelta = Me.bscProducto.FilaDevuelta
      Else
         filaDevuelta = bscCodigoProducto2.FilaDevuelta
      End If

      Dim alicuotaIVA As Decimal = Decimal.Parse(filaDevuelta.Cells("Alicuota").Value.ToString())
      Dim importeIVA As Decimal = 0
      Dim precio As Decimal = Decimal.Parse(Me.txtPrecio.Text.Trim())
      Dim costo As Decimal = Decimal.Parse(filaDevuelta.Cells("PrecioCosto").Value.ToString())

      If Reglas.Publicos.PreciosConIVA Then
         costo = Math.Round(costo / (1 + (alicuotaIVA / 100)), _decimalesRedondeoEnPrecio)
      End If

      'Fichas se asume que siempre se vende con precio IVA incluido.
      importeIVA = Math.Round((precio - (precio / (1 + (alicuotaIVA / 100)))) * Integer.Parse(Me.txtCantidad.Text), _decimalesRedondeoEnPrecio)

      Me._numeroOrden += 1
      Me.CargarUnArticulo(oLineaDetalle,
                          filaDevuelta.Cells("IdProducto").Value.ToString().Trim(),
                          filaDevuelta.Cells("NombreProducto").Value.ToString(),
                          descuentoRecargoPorc1:=0,
                          descuentoRecargoPorc2:=0,
                          descuentoRecargo:=0,
                          precio:=precio,
                          cantidad:=Integer.Parse(Me.txtCantidad.Text),
                          importeTotal:=Convert.ToDecimal(Me.txtTotalProducto.Text.Trim()),
                          stock:=Convert.ToDecimal(Me.txtStock.Text.Trim()),
                          costo:=costo,
                          precioLista:=Decimal.Parse(filaDevuelta.Cells("PrecioVentaSinIVA").Value.ToString()),
                          kilos:=0,
                          idTipoImpuesto:=Eniac.Entidades.TipoImpuesto.Tipos.IVA,
                          porcentajeIva:=alicuotaIVA,
                          importeIva:=importeIVA,
                          precioNeto:=precio,
                          FechaActualizacion:=Date.Parse(filaDevuelta.Cells("FechaActualizacion").Value.ToString()),
                          garantia:=Integer.Parse(txtGarantia.Text),
                          fechaEntrega:=dtpEntrego.Value)

      oLineaDetalle.Orden = Me._numeroOrden

      If oLineaDetalle.Producto.NroSerie Then
         If _nrosSerieVentaProducto IsNot Nothing Then
            If _ventasProductosLotes.ContainsKey(oLineaDetalle) Then
               _ventasProductosLotes(oLineaDetalle) = _nrosSerieVentaProducto
            Else
               _ventasProductosLotes.Add(oLineaDetalle, _nrosSerieVentaProducto)
            End If
         End If
         Using frm As FichasSeleccionoNrosSerie = New FichasSeleccionoNrosSerie(oLineaDetalle, _ventasProductosLotes, StateForm.Actualizar)
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
               _nrosSerieVentaProducto = Nothing
            Else
               ShowMessage(String.Format("El producto utiliza {0} - {1} requiere que seleccione {2} números de serie. Por favor reintente.",
                                         oLineaDetalle.Producto.IdCentroCosto,
                                         oLineaDetalle.Producto.NombreProducto,
                                         oLineaDetalle.Cantidad))
               Exit Sub
            End If
         End Using
      End If

      Me._ventasProductos.Add(oLineaDetalle)

      SetDataSourceProductos()
      Me.dtgProductos.FirstDisplayedScrollingRowIndex = Me.dtgProductos.Rows.Count - 1

      Me.CalcularTotalProducto()
      Me.LimpiarCamposProductos()
      Me.CalcularBruto()
      Me.Refresh()
      If bscCodigoProducto2.Visible And bscCodigoProducto2.Enabled Then
         bscCodigoProducto2.Focus()
      Else
         Me.bscProducto.Focus()
      End If

   End Sub

   Private Sub EliminarProducto()
      If Me.dtgProductos.SelectedRows.Count > 0 Then
         Me._ventasProductos.RemoveAt(Me.dtgProductos.SelectedRows(0).Index)
      End If
      If _ventasProductosLotes.ContainsKey(DirectCast(dtgProductos.SelectedRows(0).DataBoundItem, Entidades.VentaProducto)) Then
         _ventasProductosLotes.Remove(DirectCast(dtgProductos.SelectedRows(0).DataBoundItem, Entidades.VentaProducto))
      End If

      SetDataSourceProductos()
      Me.CalcularBruto()
   End Sub

   Private Sub SetDataSourceProductos()
      Me.dtgProductos.DataSource = Me._ventasProductos.ToArray()
      AjustarColumnasGrilla(dtgProductos, _titProductos)
   End Sub

   Private Sub RecalcularTodo(metodoLlamador As MetodoLlamador)

      Try

         If Me._ventasProductos IsNot Nothing Then

            'Dim oProductos As Reglas.ProductosSucursales = New Reglas.ProductosSucursales()
            'Dim pro1 As Entidades.ProductoSucursal

            Dim oProductos As Reglas.Productos = New Reglas.Productos()
            Dim ProdDT As DataTable


            Dim DescRec1 As Decimal
            Dim DescRec2 As Decimal
            Dim PrecioNeto As Decimal
            Dim PrecioPorEmbalaje As Boolean
            Dim precioParaDescuento As Decimal
            Dim precioAnterior As Decimal
            Dim seModificoElPrecioManualmente As Boolean
            Dim cargoPrecioDesdeLaBase As Boolean
            Dim precioMonedaLocalConIVA As Decimal
            Dim precioMonedaLocalConSinIVA As Decimal

            For Each pro As Entidades.VentaProducto In Me._ventasProductos

               'voy a controlar si se modifico el precio del producto manualmente
               seModificoElPrecioManualmente = False
               'redondeo el valor a 2 para despues compararlo ya que pueden haber diferencia de centavos luego.
               precioAnterior = Decimal.Round(pro.Precio, 2)

               cargoPrecioDesdeLaBase = False

               'obtengo el producto de la base de datos, incluyendo el precio de la lista que se selecciono
               ProdDT = oProductos.GetPorCodigo(pro.Producto.IdProducto, actual.Sucursal.Id, DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios, "VENTAS")

               'Fichas No tiene Cambio y Bonificación
               'If pro.TipoOperacion <> TiposOperaciones.NORMAL Then
               '   ProdDT.Rows(0)("PrecioVentaConIVA") = 0
               '   ProdDT.Rows(0)("PrecioVentaSinIVA") = 0
               'End If

               'Fichas No es MultiMoneda
               'If Integer.Parse(ProdDT.Rows(0)("IdMoneda").ToString()) = 2 Then
               '   precioMonedaLocalConIVA = Decimal.Round(Decimal.Parse(ProdDT.Rows(0)("PrecioVentaConIVA").ToString()) * Decimal.Parse(Me.txtCotizacionDolar.Text), 2)
               '   precioMonedaLocalConSinIVA = Decimal.Round(Decimal.Parse(ProdDT.Rows(0)("PrecioVentaSinIVA").ToString()) * Decimal.Parse(Me.txtCotizacionDolar.Text), 2)
               'Else
               '   precioMonedaLocalConIVA = Decimal.Round(Decimal.Parse(ProdDT.Rows(0)("PrecioVentaConIVA").ToString()), 2)
               '   precioMonedaLocalConSinIVA = Decimal.Round(Decimal.Parse(ProdDT.Rows(0)("PrecioVentaSinIVA").ToString()), 2)
               'End If

               PrecioPorEmbalaje = Boolean.Parse(ProdDT.Rows(0)("PrecioPorEmbalaje").ToString())

               If PrecioPorEmbalaje Then
                  precioMonedaLocalConIVA = Decimal.Round(precioMonedaLocalConIVA / Integer.Parse(ProdDT.Rows(0)("Embalaje").ToString()), 2)
                  precioMonedaLocalConSinIVA = Decimal.Round(precioMonedaLocalConSinIVA / Integer.Parse(ProdDT.Rows(0)("Embalaje").ToString()), 2)
               End If

               'controlo si el precio anterior es igual a alguno de los precios con o sin IVA, el redondeo es a 2 por una cuestion de comparacion
               If metodoLlamador <> FacturacionV2.MetodoLlamador.CambioListaDePrecibos Then
                  If Not (precioAnterior = precioMonedaLocalConIVA Or precioAnterior = precioMonedaLocalConSinIVA) Then
                     seModificoElPrecioManualmente = True
                  End If
               End If

               'si no se modifico el precio manualmente lo cambio
               If Not seModificoElPrecioManualmente And (metodoLlamador = FacturacionV2.MetodoLlamador.CambioListaDePrecibos Or metodoLlamador = FacturacionV2.MetodoLlamador.CambioCategoriaFiscal) Then
                  If (Not Me._clienteGrilla.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado) And
                     Me._clienteGrilla.CategoriaFiscal.UtilizaImpuestos And Me._categoriaFiscalEmpresa.UtilizaImpuestos And
                     GetTipoComprobante().UtilizaImpuestos Then
                     pro.Precio = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaConIVA").ToString())
                     cargoPrecioDesdeLaBase = True
                  Else
                     pro.Precio = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaSinIVA").ToString())
                     cargoPrecioDesdeLaBase = True
                  End If

               End If

               'Fichas No es MultiMoneda
               'If Integer.Parse(ProdDT.Rows(0)("IdMoneda").ToString()) = 2 And cargoPrecioDesdeLaBase Then
               '   pro.Precio = Decimal.Round(pro.Precio * Decimal.Parse(Me.txtCotizacionDolar.Text), Me._decimalesRedondeoEnPrecio)
               'End If

               If PrecioPorEmbalaje And cargoPrecioDesdeLaBase Then
                  pro.Precio = pro.Precio / Integer.Parse(ProdDT.Rows(0)("Embalaje").ToString())
               End If

               If Not Me._clienteGrilla.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
                  If GetTipoComprobante().GrabaLibro Or
                     GetTipoComprobante().EsPreElectronico Or
                     Reglas.Publicos.Facturacion.FacturacionDescuentoImpIntIgualado Then
                     precioParaDescuento = pro.Precio - (pro.ImporteImpuestoInterno / pro.Cantidad)
                  Else
                     precioParaDescuento = pro.Precio
                  End If
                  ''precioParaDescuento = precioProducto - (impuestoInterno / cantidad)
               Else
                  precioParaDescuento = pro.Precio
               End If

               'Calculo el Nuevo Descuento/Recargo
               DescRec1 = Decimal.Round((precioParaDescuento * pro.DescuentoRecargoPorc1 / 100), Me._decimalesRedondeoEnPrecio)
               DescRec2 = Decimal.Round(((precioParaDescuento + DescRec1) * pro.DescuentoRecargoPorc2 / 100), Me._decimalesRedondeoEnPrecio)

               pro.DescuentoRecargo = (DescRec1 + DescRec2) * pro.Cantidad

               'Calculo el Nuevo Precio Neto
               PrecioNeto = pro.Precio + DescRec1 + DescRec2
               'Fichas no tiene descuento general (ni individual)
               'PrecioNeto = Decimal.Round(PrecioNeto * (1 + (Decimal.Parse(Me.txtDescRecGralPorc.Text) / 100)), Me._decimalesRedondeoEnPrecio)

               pro.PrecioNeto = PrecioNeto

               pro.ImporteTotal = (pro.Precio * pro.Cantidad) + pro.DescuentoRecargo

            Next

            Me.dtgProductos.DataSource = _ventasProductos.ToArray()
            If Me.dtgProductos.Rows.Count > 0 Then
               Me.dtgProductos.FirstDisplayedScrollingRowIndex = Me.dtgProductos.Rows.Count - 1
            End If

            Me.dtgProductos.Refresh()

            Me.CalcularTotalProducto()

            Me.LimpiarCamposProductos()

            Me.CalcularBruto()
            ''Me.CalcularTotales()
            ''Me.CalcularDatosDetalle()
            ' '' Me.CalcularTotales()

            Me.tsbGrabar.Enabled = True
            If bscCodigoProducto2.Visible And bscCodigoProducto2.Enabled Then ''If Publicos.FacturacionPermitePosicionarNombreProducto Then
               Me.bscCodigoProducto2.Focus()
            Else
               Me.bscProducto.Focus()
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Function GetTipoComprobante() As Entidades.TipoComprobante
      If _tipoComprobante Is Nothing Then _tipoComprobante = New Reglas.TiposComprobantes().GetUno(_idTipoComprobante)
      Return _tipoComprobante
   End Function

#End Region

#Region "Adjuntos"
#Region "Eventos"
   Private Sub btnInsertarAdjunto_Click(sender As Object, e As EventArgs) Handles btnInsertarAdjunto.Click
      Dim adjunto As Entidades.VentaAdjunto = New Entidades.VentaAdjunto()
      adjunto.IdTipoComprobante = _idTipoComprobante
      Using frm As Adjunto = New Adjunto(adjunto, New Reglas.VentasAdjuntos())
         frm.StateForm = Win.StateForm.Insertar
         If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            _adjuntos.Add(adjunto)
            ugAdjunto.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
         End If
      End Using
   End Sub

   Private Sub btnEliminarAdjunto_Click(sender As Object, e As EventArgs) Handles btnEliminarAdjunto.Click
      Try
         Dim adjunto As Entidades.VentaAdjunto = GetCurrentAdjunto()
         If adjunto IsNot Nothing Then
            If ShowPregunta("¿Desea eliminar el adjunto seleccionado?") = Windows.Forms.DialogResult.Yes Then
               _adjuntos.Remove(adjunto)
               ugAdjunto.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnGrabarAdjuntos_Click(sender As Object, e As EventArgs) Handles btnGrabarAdjuntos.Click
      Try
         Dim rVentasAdjuntos As Reglas.VentasAdjuntos = New Reglas.VentasAdjuntos()
         eFicha.VentasAdjuntos = New Entidades.ListConBorrados(Of Entidades.VentaAdjunto)(_adjuntos.Where(Function(x) TypeOf (x) Is Entidades.VentaAdjunto).ToList().ConvertAll(Function(x) DirectCast(x, Entidades.VentaAdjunto)))
         eFicha.VentasAdjuntos.Borrados = _adjuntos.Borrados.Where(Function(x) TypeOf (x) Is Entidades.VentaAdjunto).ToList().ConvertAll(Function(x) DirectCast(x, Entidades.VentaAdjunto))
         rVentasAdjuntos.ActualizaDesdeVentas(eFicha)
         ShowMessage("Los adjuntos de actualizaron exitosamente.")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#Region "Eventos Grilla"
   Private Sub ugAdjunto_DoubleClickRow(sender As Object, e As UltraWinGrid.DoubleClickRowEventArgs) Handles ugAdjunto.DoubleClickRow
      Try
         'If _estado = Estados.Insercion Then
         Dim adjunto As Entidades.VentaAdjunto = GetCurrentAdjunto()
         If adjunto IsNot Nothing Then
            Using frm As Adjunto = New Adjunto(adjunto, New Reglas.VentasAdjuntos())
               frm.StateForm = Win.StateForm.Actualizar
               If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  ugAdjunto.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)
                  ugAdjunto.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
               End If
            End Using
         End If
         'End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub ugAdjunto_AfterRowActivate(sender As Object, e As EventArgs) Handles ugAdjunto.AfterRowActivate
      Dim adjunto As Entidades.IAdjunto = GetCurrentIAdjunto()
      If adjunto IsNot Nothing Then
         If adjunto.IdAdjunto > 0 Then
            If IsNothing(adjunto.Adjunto) Then
               Dim adjuntoTemp As Entidades.IAdjunto
               If TypeOf (adjunto) Is Entidades.VentaAdjunto Then
                  adjuntoTemp = New Reglas.VentasAdjuntos().GetUno(adjunto, True)
               ElseIf TypeOf (adjunto) Is Entidades.ClienteAdjunto Then
                  adjuntoTemp = New Reglas.ClientesAdjuntos().GetUno(adjunto, True)
               Else
                  Throw New Exception("El tipo de adjunto no está implementado.")
               End If

               adjunto.Adjunto = adjuntoTemp.Adjunto
            End If
            Using stream As System.IO.MemoryStream = New System.IO.MemoryStream(adjunto.Adjunto)
               Try
                  picAdjunto.Image = New System.Drawing.Bitmap(stream)
               Catch ex As Exception
                  'Si explota al querer convertir a Bitmap lo pongo en Nothing porque seguramente no es una imagen.
                  picAdjunto.Image = Nothing
               End Try
            End Using
         Else
            Dim fi As IO.FileInfo = New IO.FileInfo(adjunto.NombreAdjunto)
            If fi.Exists Then
               Try
                  picAdjunto.Load(fi.FullName)
               Catch ex As Exception
                  'Si explota al querer leer el archivo lo pongo en Nothing porque seguramente no es una imagen.
                  picAdjunto.Image = Nothing
               End Try
            End If
         End If
      End If
   End Sub
   Private Sub ugAdjunto_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles ugAdjunto.ClickCellButton
      Try
         If e.Cell.Column.Key = "ClipArchivoAdjunto" Then
            Dim adjunto As Entidades.VentaAdjunto = GetCurrentAdjunto()
            If adjunto IsNot Nothing Then
               Using frm As Adjunto = New Adjunto(adjunto, New Reglas.VentasAdjuntos())
                  frm.StateForm = Win.StateForm.Consultar
                  If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                     ugAdjunto.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)
                     ugAdjunto.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
                  End If
               End Using
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub ugAdjunto_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles ugAdjunto.InitializeRow
      Try
         If e.Row IsNot Nothing Then
            e.Row.Cells("ClipArchivoAdjunto").ButtonAppearance.Image = My.Resources.paper_clip_64
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region
#End Region
#Region "Metodos"
   Private Function GetCurrentIAdjunto() As Entidades.IAdjunto
      If ugAdjunto.ActiveRow IsNot Nothing AndAlso
         ugAdjunto.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugAdjunto.ActiveRow.ListObject) Is Entidades.IAdjunto Then
         Return DirectCast(ugAdjunto.ActiveRow.ListObject, Entidades.IAdjunto)
      End If
      Return Nothing
   End Function
   Private Function GetCurrentAdjunto() As Entidades.VentaAdjunto
      Dim temp As Entidades.IAdjunto = GetCurrentIAdjunto()
      If TypeOf (temp) Is Entidades.VentaAdjunto Then
         Return DirectCast(temp, Entidades.VentaAdjunto)
      End If
      Return Nothing
   End Function
#End Region
#End Region

   Dim dtpPrimerVencimiento_ValueChanged_interno As Boolean = False
   Private Sub dtpPrimerVencimiento_ValueChanged(sender As Object, e As EventArgs) Handles dtpPrimerVencimiento.ValueChanged
      If dtpPrimerVencimiento_ValueChanged_interno Then Exit Sub
      Try
         dtpPrimerVencimiento_ValueChanged_interno = True
         NuevoCalculoIntereses()
      Catch ex As Exception
         ShowError(ex)
      Finally
         dtpPrimerVencimiento_ValueChanged_interno = False
      End Try
   End Sub

   ''' <summary>
   ''' Para unificar los calculos de intereses.
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub NuevoCalculoIntereses()
      'El CheckBox1 lo estoy usando temporalmente para poder switchear entre el calculo viejo y el nuevo.
      'Una vez finalizadas las pruebas, se puede sacar y remover el código innecesario.
      If CheckBox1.Checked Then
         Dim ultimoVencimiento As DateTime = CalcularVencimientosCuotas()
         CalcularInteresesNuevo(ultimoVencimiento)
         CalcularImporteCuota()
         CalcularTotal()
         DistribuyeInteresesEntreCuotas()
      Else
         Me.CalcularIntereses()
         Me.CalcularImporteCuota()
         Me.CalcularTotal()
         Me.CargarGrillaCuotas()
      End If
   End Sub

   ''' <summary>
   ''' Aplica a cada cuota previamente calculada y almacenada en oFichaPagos los importes de Capital, Interes, Importe y Saldo.
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub DistribuyeInteresesEntreCuotas()
      If cmbFormaPago.SelectedIndex = -1 Then Exit Sub

      Dim sumaAnticipoCuotas As Decimal = Decimal.Parse(Me.txtAnticipo.Text)
      Dim totalCuotas As Decimal = 0
      Dim totalADistribuir As Decimal = Decimal.Parse(Me.txtSubTotal.Text) + Decimal.Parse(txtIntereses.Text) + sumaAnticipoCuotas

      Dim importeCuota As Decimal = If(IsNumeric(txtImpCuota.Text), Decimal.Parse(txtImpCuota.Text), 0)

      If importeCuota <> 0 Then
         For Each pag As Eniac.Entidades.FichaPago In oFichaPagos.Where(Function(x) x.NroCuota > 0)
            'Determino los importes de la cuotas
            pag.ImporteCapital = Decimal.Parse(Me.txtCapitalCuota.Text)
            pag.ImporteInteres = Decimal.Parse(Me.txtInteresCuota.Text)
            pag.Importe = importeCuota
            pag.Saldo = Decimal.Parse(Me.txtImpCuota.Text)
            totalCuotas += pag.Importe
         Next
      End If

      sumaAnticipoCuotas += totalCuotas

      If Math.Round(totalADistribuir - sumaAnticipoCuotas, 2) <> 0 Then
         oFichaPagos(oFichaPagos.Count - 1).Importe += Math.Round(totalADistribuir - sumaAnticipoCuotas, 2)
         oFichaPagos(oFichaPagos.Count - 1).Saldo += Math.Round(totalADistribuir - sumaAnticipoCuotas, 2)
         oFichaPagos(oFichaPagos.Count - 1).ImporteCapital += Math.Round(totalADistribuir - sumaAnticipoCuotas, 2)
         totalCuotas += Math.Round(totalADistribuir - sumaAnticipoCuotas, 2)
      End If

      txtTotalCuotas.Text = totalCuotas.ToString("N2")
      txtTotal.Text = (totalCuotas + Decimal.Parse(txtAnticipo.Text)).ToString("N2")
   End Sub

   ''' <summary>
   ''' Determina el importe total de intereses teniendo en cuenta la fecha del último vencimiento.
   ''' </summary>
   ''' <param name="ultimoVencimiento">Fecha del último vencimiento</param>
   ''' <remarks></remarks>
   Private Sub CalcularInteresesNuevo(ultimoVencimiento As DateTime)
      If cmbFormaPago.SelectedIndex = -1 Then Exit Sub
      Dim cantidadCuotas As Integer = If(IsNumeric(txtCuotas.Text), Integer.Parse(txtCuotas.Text), 1)

      Dim cliente As Entidades.Cliente = _cache.BuscaClienteEntidadPorId(Long.Parse(Me.bscCodigoCliente.Tag.ToString()))
      Dim categoria As Entidades.Categoria = _cache.BuscaCategoria(cliente.IdCategoria)

      Dim totalIntereses As Decimal = New Reglas.Ventas.Fichas().CalcularTotalInteresesNuevo(dtpFecha.Value,
                                                                                             ultimoVencimiento,
                                                                                             categoria,
                                                                                             Decimal.Parse(Me.txtSubTotal.Text))
      txtIntereses.Text = totalIntereses.ToString("N2")
      txtInteresCuota.Text = (totalIntereses / cantidadCuotas).ToString("N2")
   End Sub

   ''' <summary>
   ''' Este método calcula las fechas de vencimiento de todas las cuotas y las carga en la colección oFichaPagos
   ''' </summary>
   ''' <returns>Retorna la última fecha de vencimiento</returns>
   ''' <remarks></remarks>
   Private Function CalcularVencimientosCuotas() As Date
      Dim result As DateTime
      If cmbFormaPago.SelectedIndex = -1 Then Return Nothing

      Dim cantidadCuotas As Integer = If(IsNumeric(txtCuotas.Text), Integer.Parse(txtCuotas.Text), 1)
      If cantidadCuotas < 1 Then
         cantidadCuotas = 1
         txtCuotas.Text = cantidadCuotas.ToString()
      End If

      Dim formaPago As Entidades.VentaFormaPago = _cache.BuscaFormasPago(Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString()))

      Me.oFichaPagos.Clear()

      Dim DiasCC As Integer = formaPago.Dias
      Dim anticipo As Decimal = If(IsNumeric(txtAnticipo.Text), Decimal.Parse(txtAnticipo.Text), 0)

      If anticipo <> 0 Then
         Dim pag As Eniac.Entidades.FichaPago = New Eniac.Entidades.FichaPago(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
         pag.FechaVencimiento = Me.dtpFecha.Value
         'El anticipo lo puedo determinar ahora.
         pag.ImporteCapital = Decimal.Parse(Me.txtAnticipo.Text)
         pag.Importe = Decimal.Parse(Me.txtAnticipo.Text)
         pag.Saldo = Decimal.Parse(Me.txtAnticipo.Text)
         pag.IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         pag.NroOperacion = Integer.Parse(Me.txtNroOperacion.Text)
         pag.NroCuota = 0        'La cuota 0 es Anticipo

         result = pag.FechaVencimiento
         Me.oFichaPagos.Add(pag)
      End If

      'vvvvvv  Comienzo a calcular los dias de vencimiento de las cuotas  vvvvvv
      Dim ultimaFecha As DateTime            'Última fecha de vencimiento calculada (contemplando Sab/Dom/Fer)
      Dim ultimaFechaTeorica As DateTime     'Última fecha de venc. TEORICA calculada (ignorando Sab/Dom/Fer)

      If dtpPrimerVencimiento.Checked Then
         ultimaFecha = dtpPrimerVencimiento.Value.AddDays(DiasCC * -1)
         ultimaFechaTeorica = ultimaFecha
      Else
         ultimaFecha = dtpFecha.Value
         ultimaFechaTeorica = ultimaFecha
      End If

      Dim referenciaCuota = txtReferenciaCuota.ValorNumericoPorDefecto(0L)
      For i As Integer = 1 To cantidadCuotas
         Dim pag = New Entidades.FichaPago(actual.Sucursal.Id, actual.Nombre, actual.Pwd)

         'Si tengo que seguir contando las cuotas desde la última teórica calculada (por más que haya sido feriado)
         'tomo esa fecha y la pongo como última fecha para calcular la próxima.
         If formaPago.FechaBaseProximaCuota = Entidades.VentaFormaPago.ProximaCuota.TEORICA Then
            ultimaFecha = ultimaFechaTeorica
         End If

         'Le sumo la cantidad de días de la Forma de Pago a la última fecha de vencimiento.
         ultimaFecha = ultimaFecha.AddDays(DiasCC)
         'La copia a la TEORICA antes de analizar Sab/Dom/Fer
         ultimaFechaTeorica = ultimaFecha
         While Not EsDiaValido(ultimaFecha, formaPago)
            'Incrmento un día si la fecha no es válida (según Exclusiones de la forma de pago)
            ultimaFecha = ultimaFecha.AddDays(1)
         End While

         If Not dtpPrimerVencimiento.Checked And i = 1 Then
            Try
               dtpPrimerVencimiento_ValueChanged_interno = True
               dtpPrimerVencimiento.Value = ultimaFecha
               dtpPrimerVencimiento.Checked = False
            Finally
               dtpPrimerVencimiento_ValueChanged_interno = False
            End Try
         End If

         'Tomo la fecha calculada como fecha de vencimiento.
         pag.FechaVencimiento = ultimaFecha
         'Los importes los voy a determinar en un paso posterior
         pag.IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         pag.NroOperacion = Integer.Parse(Me.txtNroOperacion.Text)
         pag.NroCuota = i '+ 1
         pag.ReferenciaCuota = referenciaCuota
         If referenciaCuota > 0 Then referenciaCuota += 1

         result = pag.FechaVencimiento
         Me.oFichaPagos.Add(pag)
      Next
      '^^^^^^  Termino de calcular los dias de vencimiento de las cuotas  ^^^^^^

      Me.dgvCuotas.DataSource = Me.oFichaPagos.ToArray()
      Return result
   End Function
   Private _comprobantesSeleccionados As List(Of Entidades.Venta)
   Private _ventasObservaciones As List(Of Entidades.VentaObservacion)
   Private _InvocaPedido As Boolean = False
   Private _titObservaciones As Dictionary(Of String, String)
   Private _SoloCopia As Boolean
   Private _ModificaDetalle As String
   Private Sub tsbInvocarComprobantes_Click(sender As Object, e As EventArgs) Handles tsbInvocarComprobantes.Click
      Try
         If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            Exit Sub
         End If
         GetTipoComprobante()

         Dim IdTipoComprobante As String = String.Empty

         If Me.dgvFacturables.RowCount > 0 Then
            If Me._comprobantesSeleccionados IsNot Nothing Then
               If Me._comprobantesSeleccionados.Count > 0 Then
                  IdTipoComprobante = Me._comprobantesSeleccionados(0).TipoComprobante.IdTipoComprobante
               End If
            End If
         Else
            IdTipoComprobante = ""
         End If

         Using _oFactAyuda = New FacturablesPendientesAyuda(_tipoComprobante.IdTipoComprobante, cmbListaDePrecios.ValorSeleccionado(Of Integer), IdTipoComprobante, Long.Parse(bscCodigoCliente.Tag.ToString()), DirectCast(dgvFacturables.DataSource, List(Of Entidades.Venta)))
            _oFactAyuda.ShowDialog(Me)

            If Not _oFactAyuda.chbSoloCopiar.Checked Then
               CargarComprobantesFacturables(_oFactAyuda.ComprobantesSeleccionados)
            End If

            CargarProductosFacturables(_oFactAyuda.ComprobantesSeleccionados)

            If _tipoComprobante.GeneraObservConInvocados Then
               CargarObservacionesFacturables(_oFactAyuda.ComprobantesSeleccionados)
            End If

            bscCliente.Permitido = False
            bscCodigoCliente.Permitido = False


            If Not _oFactAyuda.chbSoloCopiar.Checked Then
               If _comprobantesSeleccionados.Count > 0 Then
                  If Not tbcFichas.Contains(tbpFacturables) Then
                     tbcFichas.TabPages.Add(tbpFacturables)
                     tbcFichas.TabPages.Add(tbpObservaciones)
                  End If
                  If Me._comprobantesSeleccionados(0).TipoComprobante.ModificaAlFacturar = "SOLOPRECIOS" Then
                     Me.CambiarEstadoControlesDetalle(False)
                     Me._ModificaDetalle = "SOLOPRECIOS"

                  ElseIf Me._comprobantesSeleccionados(0).TipoComprobante.ModificaAlFacturar = "NO" Then
                     Me._ModificaDetalle = "NO"
                  End If
               Else
                  If Me.tbcFichas.Contains(Me.tbpFacturables) Then
                     Me.tbcFichas.TabPages.Remove(Me.tbpFacturables)
                     Me.tbcFichas.TabPages.Remove(Me.tbpObservaciones)
                  End If
               End If
            End If



            Me._SoloCopia = _oFactAyuda.chbSoloCopiar.Checked
         End Using

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub
   Private Sub CambiarEstadoControlesDetalle(Habilitado As Boolean)

      Me.bscCodigoProducto2.Enabled = Habilitado
      Me.bscProducto.Enabled = Habilitado
      Me.txtCantidad.Enabled = Habilitado
      HabilidaPrecios(Habilitado)
      Me.btnInsertar.Enabled = Habilitado
      Me.btnEliminar.Enabled = Habilitado

   End Sub
   Private Sub HabilidaPrecios(Habilitado As Boolean)
      Me.txtPrecio.Enabled = Habilitado
   End Sub
   Private Sub CargarProductosFacturables(selec As List(Of Entidades.Venta))
      Me._ventasProductos.Clear()
      _ventasProductosLotes.Clear()
      SetDataSourceProductos()
      For Each v As Entidades.Venta In selec
         For Each vp As Entidades.VentaProducto In v.VentasProductos
            Me.bscCodigoProducto2.Text = vp.IdProducto
            Me.bscCodigoProducto2.PresionarBoton()
            Me.txtCantidad.Text = Math.Round(vp.Cantidad, 0).ToString()
            Me.txtPrecio.Text = vp.Precio.ToString()
            Me.txtTotalProducto.Text = vp.ImporteTotal.ToString()
            Me.txtGarantia.Text = vp.Garantia.ToString()
            btnInsertar.PerformClick()
         Next
      Next
   End Sub
   Private Sub CargarComprobantesFacturables(selec As List(Of Entidades.Venta))

      Me._comprobantesSeleccionados = New List(Of Entidades.Venta)

      If _tipoComprobante.GeneraObservConInvocados Then
         _ventasObservaciones.Clear()
      End If

      For Each v As Entidades.Venta In selec
         Me._comprobantesSeleccionados.Add(v)

         If Me._tipoComprobante.CantidadMaximaItemsObserv > 0 And _tipoComprobante.GeneraObservConInvocados Then

            Dim formato As String = "Invoco: {0} ´{1}´ {2:0000}-{3:00000000}. Emision: {4:dd/MM/yyyy}"
            If v.NumeroOrdenCompra <> 0 Then
               formato = String.Concat(formato, " - O. de Compra: {5}")
            End If
            Me.bscObservacionDetalle.Text = String.Format(formato,
                                                          v.TipoComprobante.Descripcion,
                                                          v.LetraComprobante,
                                                          v.CentroEmisor,
                                                          v.NumeroComprobante,
                                                          v.Fecha,
                                                          v.NumeroOrdenCompra).Truncar(100)

            Me.InsertarObservacion()
         End If

      Next

      If Me._comprobantesSeleccionados.Count <> 0 Then
         If Reglas.Publicos.Facturacion.MantieneVendedorInvocados = Entidades.Publicos.VendedorComprobanteInvocado.INVOCADO.ToString() AndAlso _comprobantesSeleccionados(0).Vendedor IsNot Nothing Then
            Me.cmbVendedor.Text = Me._comprobantesSeleccionados(0).Vendedor.NombreEmpleado
         End If
         If Me._InvocaPedido Then
            If Reglas.Publicos.MantieneFormaPagoPedidosInvocados Then
               Me.cmbFormaPago.SelectedValue = Me._comprobantesSeleccionados(0).FormaPago.IdFormasPago
            End If
         Else
            If Reglas.Publicos.MantieneFormaPagoInvocados Then
               Me.cmbFormaPago.SelectedValue = Me._comprobantesSeleccionados(0).FormaPago.IdFormasPago
            End If
         End If

      End If

      Me.dgvFacturables.DataSource = Me._comprobantesSeleccionados

      Me.OrdenarGrillaFacturables()
   End Sub

   Private Sub OrdenarGrillaFacturables()
      With Me.dgvFacturables
         .Columns("gfacFecha").DisplayIndex = 0
         .Columns("gfacTipoComprobanteDescripcion").DisplayIndex = 1
         .Columns("gfacLetraComprobante").DisplayIndex = 2
         .Columns("gfacCentroEmisor").DisplayIndex = 3
         .Columns("gfacNumeroComprobante").DisplayIndex = 4
         .Columns("gfacSubtotal").DisplayIndex = 5
         .Columns("gfacTotalImpuestos").DisplayIndex = 6
         .Columns("gfacImporteTotal").DisplayIndex = 7
         .Columns("gfacKilos").DisplayIndex = 8
         .Columns("gfacObservacion").DisplayIndex = 9
      End With
   End Sub
   Private Sub bscObservacionDetalle_BuscadorClick() Handles bscObservacionDetalle.BuscadorClick
      Try
         Dim oObservaciones As Reglas.Observaciones = New Reglas.Observaciones
         Me._publicos.PreparaGrillaObservaciones(Me.bscObservacionDetalle)
         Me.bscObservacionDetalle.Datos = oObservaciones.GetPorNombre(Me.bscObservacionDetalle.Text.Trim(), "VENTA")

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscObservacionDetalle_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscObservacionDetalle.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarObservDetalle(e.FilaDevuelta)
            Me.btnInsertarObservacion.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub
   Private Sub CargarObservDetalle(dr As DataGridViewRow)
      Me.bscObservacionDetalle.Text = dr.Cells("DetalleObservacion").Value.ToString.Trim()
   End Sub

   Private Sub btnInsertarObservacion_Click(sender As Object, e As EventArgs) Handles btnInsertarObservacion.Click
      Try
         If Me.bscObservacionDetalle.Text <> "" Then
            If Me.ValidarInsertaObservacion() Then
               Me.InsertarObservacion()
               Me.bscObservacionDetalle.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub btnEliminarObservacion_Click(sender As Object, e As EventArgs) Handles btnEliminarObservacion.Click
      Try
         If Me.ugObservaciones.ActiveRow IsNot Nothing Then
            If MessageBox.Show("Esta seguro de eliminar la Observación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaObservacion()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub
   Private Function ValidarInsertaObservacion() As Boolean

      If Me.ugObservaciones.Rows.Count = _tipoComprobante.CantidadMaximaItemsObserv Then
         MessageBox.Show("No puede ingresar mas de " & _tipoComprobante.CantidadMaximaItemsObserv.ToString() & " lineas de Observaciones para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.btnInsertarObservacion.Focus()
         Return False
      End If

      'Sumo Lineas del Comprobante + Lineas de Observaciones.

      Dim LineasDetalle As Integer = Me.dtgProductos.RowCount

      If LineasDetalle + Me.ugObservaciones.Rows.Count >= _tipoComprobante.CantidadMaximaItems Then
         MessageBox.Show("No puede ingresar mas de " & _tipoComprobante.CantidadMaximaItems.ToString() & " lineas (Productos y Observaciones) para este tipo de comprobante." + Environment.NewLine +
                         "Cantidad de líneas del comprobante " & (LineasDetalle + Me.ugObservaciones.Rows.Count).ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.btnInsertarObservacion.Focus()
         Return False
      End If

      Return True

   End Function
   Private Sub InsertarObservacion()

      Dim oLineaDetalle As Entidades.VentaObservacion = New Entidades.VentaObservacion()

      With oLineaDetalle
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         .Linea = Me.ugObservaciones.Rows.Count + 1
         .Observacion = Me.bscObservacionDetalle.Text
      End With

      Me._ventasObservaciones.Add(oLineaDetalle)

      SetDataSourceObservaciones(Me._ventasObservaciones.ToArray())

      Me.LimpiarCamposObservDetalles()

   End Sub
   Private Sub EliminarLineaObservacion()
      If ugObservaciones.ActiveRow IsNot Nothing AndAlso
         ugObservaciones.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugObservaciones.ActiveRow.ListObject) Is Entidades.VentaObservacion Then
         Me._ventasObservaciones.Remove(DirectCast(ugObservaciones.ActiveRow.ListObject, Entidades.VentaObservacion))
         SetDataSourceObservaciones(Me._ventasObservaciones.ToArray())
      End If

   End Sub
   Private Sub SetDataSourceObservaciones(datos As Object)
      Me.ugObservaciones.DataSource = datos
      AjustarColumnasGrilla(ugObservaciones, _titObservaciones)
      If ugObservaciones.Rows.Count > 0 Then
         ugObservaciones.DisplayLayout.RowScrollRegions(0).FirstRow = ugObservaciones.Rows(ugObservaciones.Rows.Count - 1)
      End If
   End Sub
   Private Sub LimpiarCamposObservDetalles()
      Me.bscObservacionDetalle.Text = ""
   End Sub
   Private Sub CargarObservacionesFacturables(selec As List(Of Entidades.Venta))

      For Each v As Entidades.Venta In selec

         For Each vp As Entidades.VentaObservacion In v.VentasObservaciones

            vp.Linea = Me._ventasObservaciones.Count + 1

            Me._ventasObservaciones.Add(vp)

         Next

      Next

      SetDataSourceObservaciones(Me._ventasObservaciones)

   End Sub

   Private Sub tsbCancelarFicha_Click(sender As Object, e As EventArgs) Handles tsbCancelarFicha.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         If MessageBox.Show("Se cancelará la totalidad del saldo de la Ficha del Cliente. ¿Desea Continuar?", "Cancelar Ficha del Cliente", MessageBoxButtons.OKCancel) = vbOK Then

            Dim cobrador As Entidades.Empleado = Nothing
            If cmbCobrador.SelectedIndex > -1 Then
               cobrador = DirectCast(cmbCobrador.SelectedItem, Entidades.Empleado)
            End If
            Dim vendedor As Entidades.Empleado = Nothing
            If Me.cmbVendedor.SelectedIndex > -1 Then
               vendedor = DirectCast(cmbVendedor.SelectedItem, Entidades.Empleado)
            End If

            Dim saldoTotal As Decimal = Decimal.Parse(Me.txtSaldo.Text)

            Using oPagos As Pagos2 = New Pagos2(Integer.Parse(Me.cmbCajas.SelectedValue.ToString()), Pagos2.TipoPago.Pago,
                                                Integer.Parse(txtIdSucursal.Text), txtIdTipoComprobante.Text, txtLetra.Text, Short.Parse(txtCentroEmisor.Text), Long.Parse(Me.txtNroOperacion.Text),
                                                Long.Parse(Me.bscCodigoCliente.Tag.ToString()), vendedor, cobrador, saldoTotal, Me._cuotanumero, cancelarFicha:=True) ' # Este último parámetro lo utilizo para identificar a la pantalla que voy a generar una NC
               oPagos.IdFuncion = IdFuncion
               oPagos.ShowDialog()
               Me.RecuperarDatosDeFicha()
            End Using

         End If
      Catch ex As Exception
         ShowError(ex, recursivo:=True)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

End Class