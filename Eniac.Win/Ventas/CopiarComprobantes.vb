Public Class CopiarComprobantes
   Implements IConParametros

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos
   Private _comprobantes As List(Of Entidades.Venta)
   Private _fc As FacturacionComunes
   Private _configuracionAutomatica As ConfiguracionAutomatica
   Private _metodoGrabacion As Entidades.Entidad.MetodoGrabacion

   Private _copiaFactNCred As Boolean = False

#End Region

#Region "Constructores"
   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
   End Sub
   Public Sub New(configuracionAutomatica As ConfiguracionAutomatica)
      Me.New()
      _configuracionAutomatica = configuracionAutomatica
   End Sub
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Eniac.Win.Publicos()
         Me._comprobantes = New List(Of Entidades.Venta)

         '' ''Dim blnMiraPCTipoComp As Boolean = True
         '' ''Dim strTipo1 As String = "VENTAS"
         '' ''Dim strTipo2 As String = ""
         '' ''Dim strAfectaCaja As String = "TODOS"
         '' ''Dim blnUsaFacturacion As Boolean = True
         '' ''Dim blnPermiteElectronicos As Boolean = True
         '' ''Dim blnPermiteFiscales As Boolean = False   'Por ahora no. Luego hay que validad que para NCRED Fiscal

         If Not _copiaFactNCred Then
            Me._publicos.CargaComboTiposComprobantesReemplazar(Me.cmbTiposComprobantesOrigen, miraPC:=True, tipo1:="VENTAS", tipo2:="", afectaCaja:="TODOS", usaFacturacion:=True,
                                                               permiteElectronicos:=True, permiteFiscales:=False, idSucursal:=actual.Sucursal.Id,
                                                               grabaLibro:=Nothing, esComercial:=Nothing, coeficienteValor:=Nothing, incluyePreElectronicas:=Nothing)
         Else
            Text = "Copiar Factura a Nota de Credito"
            Me._publicos.CargaComboTiposComprobantesReemplazar(Me.cmbTiposComprobantesOrigen, miraPC:=True, tipo1:="VENTAS", tipo2:="", afectaCaja:="TODOS", usaFacturacion:=False,
                                                               permiteElectronicos:=True, permiteFiscales:=False, idSucursal:=actual.Sucursal.Id,
                                                               grabaLibro:=True, esComercial:=True, coeficienteValor:=1, incluyePreElectronicas:=Nothing)
         End If
         Me.cmbTiposComprobantesOrigen.SelectedIndex = 0

         _publicos.CargaComboSucursales(cmbSucursalNueva, False, False, IdFuncion)
         cmbSucursalNueva.SelectedValue = actual.Sucursal.Id

         'blnPermiteElectronicos = False
         'blnPermiteFiscales = True
         'Me._publicos.CargaComboTiposComprobantesReemplazar(Me.cmbTiposComprobantesDestino, blnMiraPCTipoComp, strTipo1, strTipo2, strAfectaCaja, blnUsaFacturacion, blnPermiteElectronicos, blnPermiteFiscales, actual.Sucursal.Id)

         Dim blnMiraPCCaja As Boolean = Not Publicos.FacturacionIgnorarPCdeCaja

         'Me._publicos.CargaComboCajas(Me.cmbCajas, Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal, MiraUsuario:=True, MiraPC:=blnMiraPCCaja, CajasModificables:=True)
         Me._publicos.CargaComboCajas(Me.cmbCajasOrigen, Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal, miraUsuario:=True, miraPC:=blnMiraPCCaja, cajasModificables:=True)

         With Me.cboLetra
            .DisplayMember = "LetraFiscal"
            .ValueMember = "LetraFiscal"
            .DataSource = New Reglas.VentasNumeros().GetLetrasFiscales()
            .SelectedIndex = -1
         End With

         With Me.cmbEmisor
            .DisplayMember = "CentroEmisor"
            .ValueMember = "CentroEmisor"
            .DataSource = New Reglas.VentasNumeros().GetCentrosEmisores()
            .SelectedIndex = -1
         End With

         Me._fc = New FacturacionComunes()

         Me.RefrescarDatosGrilla()

         _metodoGrabacion = Entidades.Entidad.MetodoGrabacion.Manual

         If _copiaFactNCred Then
            chbEliminarOrigen.Checked = False
            chbEliminarOrigen.Enabled = False
         End If

         If _configuracionAutomatica IsNot Nothing Then
            chbEliminarOrigen.Checked = _configuracionAutomatica.EliminarComprobante
            cmbTiposComprobantesOrigen.SelectedValue = _configuracionAutomatica.IdTipoComprobanteOrigen
            cmbTiposComprobantesDestino.SelectedValue = _configuracionAutomatica.IdTipoComprobanteDestino
            chbUsuario.Checked = True
            txtUsuario.Text = _configuracionAutomatica.Usuario
            cmbCajasOrigen.SelectedValue = _configuracionAutomatica.IdCaja
            btnBuscar.PerformClick()

            If Not String.IsNullOrWhiteSpace(_configuracionAutomatica.LetraOrigen) Then
               chbLetra.Checked = True
               cboLetra.SelectedValue = _configuracionAutomatica.LetraOrigen
            End If

            If _configuracionAutomatica.CentroEmisorOrigen > 0 Then
               chbEmisor.Checked = True
               cmbEmisor.SelectedValue = _configuracionAutomatica.CentroEmisorOrigen
            End If

            If _configuracionAutomatica.NumeroComprobanteOrigen > 0 Then
               chbNumero.Checked = True
               txtNumero.Text = _configuracionAutomatica.NumeroComprobanteOrigen.ToString()
            End If

            ugvComprobantes.DisplayLayout.Bands(0).SortedColumns.Add(_configuracionAutomatica.OrdenarPor, _configuracionAutomatica.OrdenarDescendente)
            If _configuracionAutomatica.SeleccionarPrimerRegistro And ugvComprobantes.DisplayLayout.Rows.Count > 0 Then
               ugvComprobantes.DisplayLayout.Rows(0).Cells("Ok").Value = True
               ugvComprobantes.ActiveRow = ugvComprobantes.DisplayLayout.Rows(0)
               ugvComprobantes.ActiveCell = ugvComprobantes.ActiveRow.Cells("Ok")
               ugvComprobantes.Focus()
            End If
            _metodoGrabacion = _configuracionAutomatica.MetodoGrabacion
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Try
         If keyData = Keys.F5 Then
            Me.tsbRefrescar_Click(Me.tsbRefrescar, Nothing)
            Return True
         End If
         If keyData = Keys.F4 Then
            btnCopiar.PerformClick()
            Return True
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function
#End Region

#Region "Metodos"

   Private Function ValidarTopeConsumidorFinal(venta As Entidades.Venta, nuevoComprobante As Entidades.TipoComprobante) As Boolean

      If Not venta.Cliente.CategoriaFiscal.IvaDiscriminado And Not venta.Cliente.CategoriaFiscal.SolicitaCUIT And venta.Cliente.CategoriaFiscal.LetraFiscal <> "E" And
            venta.ImporteTotal >= Reglas.Publicos.Facturacion.FacturacionControlaTopeCF And venta.Cliente.NroDocCliente = 0 And
            nuevoComprobante.ControlaTopeConsumidorFinal Then

         If Reglas.Publicos.Facturacion.FacturacionControlaDNIClienteConsumidorFinal Or
           (Not Reglas.Publicos.Facturacion.FacturacionControlaDNIClienteConsumidorFinal And
            nuevoComprobante.GrabaLibro Or nuevoComprobante.EsPreElectronico) Then

            ShowMessage(String.Format("El cliente del Comprobante {0} {1} {2:0000}-{3:00000000} es Consumidor Final y el Total de Comprobante es superior a $ {4}. El DNI es obligatorio.",
                                        venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor, venta.NumeroComprobante, Reglas.Publicos.Facturacion.FacturacionControlaTopeCF))
            Return False
         End If
      End If

      Return True
   End Function

   Protected Overridable Function GetReglaVentas() As Reglas.Ventas
      Return New Reglas.Ventas()
   End Function

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Now.AddMinutes(-30) '.AddMonths(-1)
      Me.dtpHasta.Value = Date.Today.AddDays(1).AddSeconds(-1)
      Me.chbLetra.Checked = False
      Me.chbNumero.Checked = False
      Me.chbNumeroReparto.Checked = False
      Me.chbCliente.Checked = False
      Me.chbEmisor.Checked = False
      Me.chbUtilizaFechaCompAnterior.Checked = True

      Me.dtpNuevaFecha.Value = Date.Now
      Me.dtpNuevaFecha.Enabled = False

      If Not Me.ugvComprobantes.DataSource Is Nothing Then
         DirectCast(Me.ugvComprobantes.DataSource, DataTable).Rows.Clear()
      End If

      If Not String.IsNullOrWhiteSpace(Publicos.ReemplazarComprobanteTipoComprobanteOrigen) Then
         cmbTiposComprobantesOrigen.SelectedValue = Publicos.ReemplazarComprobanteTipoComprobanteOrigen
      End If

      If Not String.IsNullOrWhiteSpace(Publicos.ReemplazarComprobanteTipoComprobanteDestino) Then
         cmbTiposComprobantesDestino.SelectedValue = Publicos.ReemplazarComprobanteTipoComprobanteDestino
      End If

      Me.dtpDesde.Focus()

   End Sub

   Private Sub FormatearGrilla()

      For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.ugvComprobantes.DisplayLayout.Bands(0).Columns
         col.Hidden = True
         col.CellActivation = UltraWinGrid.Activation.ActivateOnly
      Next

      With Me.ugvComprobantes.DisplayLayout.Bands(0)
         Dim pos As Integer = 0

         .Columns("Ok").FormatearColumna("", pos, 32, , , , , Activation.AllowEdit).CellClickAction = CellClickAction.Edit

         .Columns("Descripcion").FormatearColumna("Tipo Comprobante", pos, 105)
         .Columns(Entidades.Venta.Columnas.Letra.ToString()).FormatearColumna("Let.", pos, 30, HAlign.Center)
         .Columns(Entidades.Venta.Columnas.CentroEmisor.ToString()).FormatearColumna("Emisor", pos, 45, HAlign.Right)
         .Columns(Entidades.Venta.Columnas.NumeroComprobante.ToString()).FormatearColumna("Número", pos, 70, HAlign.Right)
         .Columns(Entidades.Venta.Columnas.Fecha.ToString()).FormatearColumna("Fecha", pos, 100, HAlign.Center, , "dd/MM/yyyy HH:mm")
         .Columns(Entidades.Venta.Columnas.ImporteTotal.ToString()).FormatearColumna("Importe", pos, 80, HAlign.Right, , "N2")
         .Columns("NombreCliente1").FormatearColumna("Cliente", pos, 180)
         .Columns(Entidades.Venta.Columnas.CodigoErrorAfip.ToString()).FormatearColumna("Error AFIP", pos, 70)
         .Columns(Entidades.Venta.Columnas.Observacion.ToString()).FormatearColumna("Observación", pos, 200)
      End With

   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub CargarGrillaDetalle()
      Dim IdCliente As Long = 0
      Dim Letra As String = ""
      Dim emisor As Integer = 0
      Dim IdTipoComprobante As String = String.Empty
      Dim NumeroComprobante As Long = 0
      Dim NumeroReparto As Integer = 0

      Dim idCaja As Integer? = Nothing

      If Me.bscCodigoCliente.Text.Length > 0 Then
         IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
      End If

      If Me.cboLetra.Enabled Then
         Letra = Me.cboLetra.SelectedValue.ToString()
      End If

      If Me.cmbEmisor.Enabled Then
         emisor = Integer.Parse(Me.cmbEmisor.SelectedValue.ToString())
      End If

      IdTipoComprobante = Me.cmbTiposComprobantesOrigen.SelectedValue.ToString()

      If Me.chbNumero.Checked Then
         NumeroComprobante = Long.Parse(Me.txtNumero.Text)
      End If

      If Me.chbNumeroReparto.Checked Then
         NumeroReparto = Integer.Parse(Me.txtNroReparto.Text)
      End If

      If cmbCajasOrigen.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbCajasOrigen.SelectedValue) Then
         idCaja = CInt(cmbCajasOrigen.SelectedValue)
      End If

      Dim reg As Reglas.Ventas = GetReglaVentas()

      Dim dtComprobantes As DataTable

      dtComprobantes = reg.GetComprobantesACopiar(Entidades.Usuario.Actual.Sucursal.Id, Me.dtpDesde.Value, Me.dtpHasta.Value, IdCliente,
                                                   IdTipoComprobante, NumeroComprobante, Letra, emisor, NumeroReparto, idCaja, txtUsuario.Text)

      Me.ugvComprobantes.DataSource = dtComprobantes

      Dim cl As DataColumn
      cl = New DataColumn("Ok", System.Type.GetType("System.Boolean"))
      cl.DefaultValue = False
      dtComprobantes.Columns.Add(cl)

      Me.FormatearGrilla()
   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbCerrar_Click(sender As Object, e As EventArgs) Handles tsbCerrar.Click
      Me.Close()
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugvComprobantes.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescandoInfo("Buscando datos...")

         Me.CargarGrillaDetalle()

         If Me.ugvComprobantes.Rows.Count > 0 Then
            Me.btnBuscar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("No hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         Me.tssRegistros.Text = Me.ugvComprobantes.Rows.Count.ToString() + " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.RefrescandoInfo("")
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub RefrescandoInfo(info As String)
      Me.tssInfo.Text = info
      Application.DoEvents()
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         Me.chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub btnCopiar_Click(sender As Object, e As EventArgs) Handles btnCopiar.Click

      Try
         ugvComprobantes.UpdateData()

         If Me.cmbTiposComprobantesOrigen.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Seleccion el Comprobante Origen.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.cmbTiposComprobantesOrigen.Focus()
            Exit Sub
         End If

         If Me.cmbTiposComprobantesDestino.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Seleccion el Comprobante Destino.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.cmbTiposComprobantesDestino.Focus()
            Exit Sub
         End If

         If Me.cmbTiposComprobantesOrigen.SelectedValue.ToString() = Me.cmbTiposComprobantesDestino.SelectedValue.ToString() AndAlso actual.Sucursal.Id = Integer.Parse(cmbSucursalNueva.SelectedValue.ToString()) Then
            MessageBox.Show("ATENCION: Tipo de comprobante Origen y Destino NO Puede ser los mismos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.cmbTiposComprobantesDestino.Focus()
            Exit Sub
         End If

         If cmbSucursalNueva.SelectedIndex < -1 Then
            ShowMessage("ATENCION: No seleccionó una sucursal destino.")
            Me.cmbSucursalNueva.Focus()
            Exit Sub
         End If

         'Si estoy copiando de Factura a NCred debo ignorar esta validación porque justamente impide este tipo de operación
         If Not _copiaFactNCred Then
            'Por ahora Si el Origen es una PRE-FACT dejo cambioar a cualquier cosa.
            'Por ahora NO permito de FC a NC, al reves, presupuestos, etc. Hay que testearlo bien.
            If DirectCast(Me.cmbTiposComprobantesOrigen.SelectedItem, Entidades.TipoComprobante).CoeficienteStock <> 0 Then
               Dim tipoComprobanteDestino As Entidades.TipoComprobante = DirectCast(Me.cmbTiposComprobantesDestino.SelectedItem, Entidades.TipoComprobante)
               If tipoComprobanteDestino.EsPreElectronico Then
                  tipoComprobanteDestino = New Reglas.TiposComprobantes().GetUno(tipoComprobanteDestino.IdTipoComprobanteSecundario)
               End If
               If DirectCast(Me.cmbTiposComprobantesOrigen.SelectedItem, Entidades.TipoComprobante).CoeficienteStock <> tipoComprobanteDestino.CoeficienteStock Then
                  MessageBox.Show("ATENCION: El Destino NO Puede ser un Comprobante de Distinto Coeficiente Stock al Origen.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                  Me.cmbTiposComprobantesDestino.Focus()
                  Exit Sub
               End If
            End If
         End If

         If Me.chbEliminarOrigen.Checked And Not DirectCast(Me.cmbTiposComprobantesOrigen.SelectedItem, Entidades.TipoComprobante).EsPreElectronico And
             DirectCast(Me.cmbTiposComprobantesOrigen.SelectedItem, Entidades.TipoComprobante).EsElectronico Then
            MessageBox.Show("ATENCION: NO Puede Reemplazar un Electronico, solo puede Copiarlo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.cmbTiposComprobantesOrigen.Focus()
            Exit Sub
         End If

         If Me.chbEliminarOrigen.Checked And DirectCast(Me.cmbTiposComprobantesOrigen.SelectedItem, Entidades.TipoComprobante).EsFiscal Then
            MessageBox.Show("ATENCION: NO Puede Reemplazar un Electronico, solo puede Copiarlo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.cmbTiposComprobantesOrigen.Focus()
            Exit Sub
         End If


         Dim cant As Integer = 0

         'validar que en la grilla este seleccionado un registro
         For Each dr As UltraGridRow In Me.ugvComprobantes.Rows
            If Boolean.Parse(dr.Cells("Ok").Value.ToString()) Then
               If Not String.IsNullOrWhiteSpace(dr.Cells("NumeroReparto").Value.ToString()) And Not chbEliminarOrigen.Checked Then
                  MessageBox.Show(String.Format("ATENCION: El comprobante {0} {1} {2:0000}-{3:00000000} pertenece a un reparto, no es posible Copiar.",
                                             dr.Cells("idTipoComprobante").Value,
                                             dr.Cells("Letra").Value,
                                             Short.Parse(dr.Cells("centroEmisor").Value.ToString()),
                                             Long.Parse(dr.Cells("NumeroComprobante").Value.ToString())), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                  Exit Sub
               End If
               cant += 1
            End If
         Next

         If cant = 0 Then
            MessageBox.Show("No selecciono ningún Comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
         End If

         Me.RefrescandoInfo("Copiando comprobante...")

         Me.Cursor = Cursors.WaitCursor

         'defino variables
         Dim comprobante As Entidades.TipoComprobante
         Dim ventas As Reglas.Ventas
         Dim idSucursal As Integer
         Dim idTipoComprobante As String 'varchar(15)
         Dim letra As String 'varchar(1)
         Dim centroEmisor As Short
         Dim numeroComprobante As Long
         Dim idCaja As Integer
         Dim tipoCompro As Entidades.TipoComprobante
         Dim eliminarComprobanteOrigen As Boolean
         Dim esFiscal As Boolean = False
         Dim numeroFiscal As Long
         Dim nuevaFecha As Date = Nothing
         Dim ComprobanteNuevo As Entidades.Venta = New Entidades.Venta()

         ventas = GetReglaVentas()

         tipoCompro = DirectCast(Me.cmbTiposComprobantesDestino.SelectedItem, Entidades.TipoComprobante)

         idCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())

         'If Not (tipoCompro.EsElectronico = False And tipoCompro.CoeficienteStock = -1) Then
         '   MessageBox.Show("No puedo copiar al tipo de comprobante seleccionado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.cmbTiposComprobantes.Focus()
         '   Exit Sub
         'End If

         If DirectCast(ugvComprobantes.DataSource, DataTable).Select("Ok").Count > 1 AndAlso chbNumeroDestino.Checked Then
            Throw New Exception("Solo se puede definir un número de destino cuando está seleccionado un solo comprobante a reemplazar.")
         End If


         'por cada comprobante seleccionado en la grilla
         For Each rw As DataRow In DirectCast(Me.ugvComprobantes.DataSource, DataTable).Select("Ok = True")


            '# Declaración de variables
            idSucursal = rw.Field(Of Integer)(Entidades.Venta.Columnas.IdSucursal.ToString())
            idTipoComprobante = rw.Field(Of String)(Entidades.Venta.Columnas.IdTipoComprobante.ToString())

            letra = rw.Field(Of String)(Entidades.Venta.Columnas.Letra.ToString())
            centroEmisor = Convert.ToInt16(rw.Field(Of Integer)(Entidades.Venta.Columnas.CentroEmisor.ToString()))
            numeroComprobante = rw.Field(Of Long)(Entidades.Venta.Columnas.NumeroComprobante.ToString())
            eliminarComprobanteOrigen = (Me.chbEliminarOrigen.Checked AndAlso String.IsNullOrEmpty(rw.Field(Of String)(Entidades.Venta.Columnas.CodigoErrorAfip.ToString())))


            Me.RefrescandoInfo("Obteniendo datos del comprobante...")
            Me.RefrescandoInfo("Modificando datos del comprobante...")
            Me.RefrescandoInfo("Agregando nuevo comprobante...")

            comprobante = New Reglas.TiposComprobantes().GetUno(Me.cmbTiposComprobantesDestino.SelectedValue.ToString())

            Dim comp As Entidades.Venta
            comp = GetReglaVentas().GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)

            '# Valido que no se esté generando un comprobante electrónico a un consumidor final por un importe > al permitido y sin que el cliente tenga un DNI asociado.
            If Not Me.ValidarTopeConsumidorFinal(venta:=comp, nuevoComprobante:=comprobante) Then Exit Sub

            If comprobante.EsFiscal And comprobante.GrabaLibro Then
               esFiscal = True

               comp.TipoComprobante = tipoCompro
               comp.Usuario = actual.Nombre
               comp.IdCaja = idCaja

               'PE-34391 / Agregar control que no permita reemplazar comprobantes que invocaron Pendientes
               '    Se detectó un error al reemplazar un comprobante que invoca un pedido en el PE-33127.
               '    Su corrección requiere que se reformule la lógica de reemplazo porque al momento de insertar el nuevo comprobante se encuentra con el
               'pedido ya consumido y no descuenta nada (porque no hay que descontar), luego de esto anula el comprobante anterior y esto libera el pedido.
               '    Para resolverlo habría que reorganizar el código subiendo la anulación previo a insertar el nuevo registro; pero hay código de la
               'anulación que requiere saber cual es el nuevo comprobante ya que el mismo se usa para hacer un UPDATE del viejo comprobante al nuevo.
               '    Es factible hacer todos estos cambios, pero el tiempo de desarrollo sería elevado. Y luego los testeos se deberían hacer para todos
               'los casos de prueba e incluso volver a ejecutar los casos de prueba de los viejos pendientes para asegurarnos que no volvieron a aparecer
               'los mismos errores.
               If comp.Invocados.Any(Function(i) i.Invocado.TipoTipoComprobante = Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString()) Then
                  Throw New Exception(String.Format("El comprobante {1} {2} {3:0000}-{4:00000000} invocó Pedidos. No es posible reemplazar comprobantes que invocan Pedidos.",
                                                 comp.IdSucursal, comp.IdTipoComprobante, comp.LetraComprobante, comp.CentroEmisor, comp.NumeroComprobante))
               End If

               If comp.TipoComprobante.LetrasHabilitadas.Length = 1 Then
                  comp.LetraComprobante = comp.TipoComprobante.LetrasHabilitadas
               Else
                  comp.LetraComprobante = comp.Cliente.CategoriaFiscal.LetraFiscal
               End If

               comp.Impresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, comprobante.IdTipoComprobante)
               comp.CentroEmisor = comp.Impresora.CentroEmisor

               'Recalculo el nuevo precio
               Dim CompAnterior As Entidades.TipoComprobante = New Reglas.TiposComprobantes().GetUno(idTipoComprobante)

               ''If comp.TipoComprobante.GrabaLibro <> CompAnterior.GrabaLibro Then
               Dim oProductos As Reglas.Productos = New Reglas.Productos()
               Dim categoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

               For Each pro As Entidades.VentaProducto In comp.VentasProductos
                  If (comp.Cliente.CategoriaFiscal.IvaDiscriminado And categoriaFiscalEmpresa.IvaDiscriminado) Or
                     Not comp.Cliente.CategoriaFiscal.UtilizaImpuestos Or Not categoriaFiscalEmpresa.UtilizaImpuestos Then
                  Else
                     pro.Precio = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(pro.Precio, pro.AlicuotaImpuesto, pro.PorcImpuestoInterno, pro.Producto.ImporteImpuestoInterno, pro.OrigenPorcImpInt), 2)
                     pro.DescRecGeneral = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(pro.DescRecGeneral, pro.AlicuotaImpuesto, pro.PorcImpuestoInterno, pro.Producto.ImporteImpuestoInterno, pro.OrigenPorcImpInt), 2)
                     pro.DescuentoRecargo = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(pro.DescuentoRecargo, pro.AlicuotaImpuesto, pro.PorcImpuestoInterno, pro.Producto.ImporteImpuestoInterno, pro.OrigenPorcImpInt), 2)
                     'pro.PrecioLista = Math.Round(pro.PrecioLista * (1 + (pro.AlicuotaImpuesto / 100)), 2)
                     pro.PrecioNeto = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(pro.PrecioNeto, pro.AlicuotaImpuesto, pro.PorcImpuestoInterno, pro.Producto.ImporteImpuestoInterno, pro.OrigenPorcImpInt), 2)
                     pro.ImporteTotal = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(pro.ImporteTotal, pro.AlicuotaImpuesto, pro.PorcImpuestoInterno, pro.Producto.ImporteImpuestoInterno * pro.Cantidad, pro.OrigenPorcImpInt), 2)
                     pro.ImporteTotalNeto = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(pro.ImporteTotalNeto, pro.AlicuotaImpuesto, pro.PorcImpuestoInterno, pro.Producto.ImporteImpuestoInterno * pro.Cantidad, pro.OrigenPorcImpInt), 2)
                     'pro.Costo = Math.Round(pro.Costo * (1 + (pro.AlicuotaImpuesto / 100)), 2)
                  End If

                  'ProdDT = oProductos.GetPorCodigo(pro.Producto.IdProducto, actual.Sucursal.Id, pro.IdListaPrecios, "VENTAS")

                  'If pro.PrecioLista = 0 Then
                  '   If Not comp.Cliente.CategoriaFiscal.IvaDiscriminado Or Not categoriaFiscalEmpresa.IvaDiscriminado Then
                  '      pro.Precio = Decimal.Round((pro.Precio * (1 + pro.AlicuotaImpuesto / 100)), 2)
                  '   End If
                  'Else
                  '   If (comp.Cliente.CategoriaFiscal.IvaDiscriminado And categoriaFiscalEmpresa.IvaDiscriminado) Or _
                  '     Not comp.Cliente.CategoriaFiscal.UtilizaImpuestos Or Not categoriaFiscalEmpresa.UtilizaImpuestos Then
                  '      pro.Precio = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaSinIVA").ToString())
                  '   Else
                  '      pro.Precio = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaConIVA").ToString())
                  '   End If

                  '   Dim PrecioPorEmbalaje As Boolean = pro.Producto.PrecioPorEmbalaje

                  '   If PrecioPorEmbalaje Then
                  '      pro.Precio = pro.Precio / pro.Producto.Embalaje
                  '   End If

                  'End If
                  ''Calculo el Nuevo Descuento/Recargo
                  'DescRec1 = Decimal.Round((pro.Precio * pro.DescuentoRecargoPorc1 / 100), 2)
                  'DescRec2 = Decimal.Round(((pro.Precio + DescRec1) * pro.DescuentoRecargoPorc2 / 100), 2)

                  'pro.DescuentoRecargo = (DescRec1 + DescRec2) * pro.Cantidad

                  ''Calculo el Nuevo Precio Neto
                  'PrecioNeto = pro.Precio + DescRec1 + DescRec2
                  'PrecioNeto = Decimal.Round(PrecioNeto * (1 + (comp.DescuentoRecargoPorc / 100)), 2)

                  'pro.PrecioNeto = PrecioNeto

                  'pro.ImporteTotal = (pro.Precio * pro.Cantidad) + pro.DescuentoRecargo


               Next
               ''End If

               '-- REQ-31369.- --
               If Not comp.Cliente.EsClienteGenerico AndAlso (rw.Field(Of Short)(Entidades.Venta.Columnas.IdCategoriaFiscal.ToString()) <> comp.CategoriaFiscal.IdCategoriaFiscal) Then
                  comp.Cuit = comp.Cliente.Cuit
                  comp.NroDocCliente = comp.Cliente.NroDocCliente
                  comp.TipoDocCliente = comp.TipoDocCliente
               End If

               If Me._fc.ImprimirComprobante(comp, comprobante.EsFiscal) Then
                  numeroFiscal = comp.NumeroComprobante
               Else
                  Throw New Exception("Error en la impresión Fiscal")
               End If
            Else

               If chbNumeroDestino.Checked Then
                  If IsNumeric(txtNumeroDestino.Text) AndAlso Long.Parse(txtNumeroDestino.Text) > 0 Then
                     numeroFiscal = Long.Parse(txtNumeroDestino.Text)
                  Else
                     txtNumeroDestino.Focus()
                     Throw New Exception("Debe ingresar un número válido.")
                  End If
               Else
                  numeroFiscal = 0
               End If
            End If

            If Not Me.chbUtilizaFechaCompAnterior.Checked Then
               nuevaFecha = dtpNuevaFecha.Value
            End If


            Dim solicitarCAE As Boolean = Reglas.Publicos.FactElectEsSincronica

            ComprobanteNuevo = ventas.CopiarReemplazarComprobante(idSucursal,
                                               idTipoComprobante,
                                               letra,
                                               centroEmisor,
                                               numeroComprobante,
                                               tipoCompro,
                                               idCaja,
                                               eliminarComprobanteOrigen,
                                               esFiscal,
                                               numeroFiscal,
                                               _metodoGrabacion,
                                               IdFuncion,
                                               nuevaFecha,
                                               True,
                                               solicitarCAE,
                                               Integer.Parse(cmbSucursalNueva.SelectedValue.ToString()))


            If ComprobanteNuevo.TipoComprobante.EsFiscal And ComprobanteNuevo.TipoComprobante.EsPreElectronico Then

               If Reglas.Publicos.Facturacion.Impresion.FacturacionImpresionFiscalSincronica Then

                  My.Application.Log.WriteEntry("FacturacionRapida.GrabarComprobante - Convierto Pre-Ticket en Ticket " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
                  '''''Armo la entidad TICKET FISCAL
                  Dim ComprobanteFiscal As Entidades.Venta = ventas.ArmarComprobanteFiscal(ComprobanteNuevo)
                  '''''Conservo pre TICKET

                  Try
                     My.Application.Log.WriteEntry("FacturacionRapida.GrabarComprobante - Comienzo Imprimir Ticket " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
                     If Me._fc.ImprimirComprobante(ComprobanteFiscal, ComprobanteFiscal.TipoComprobante.EsFiscal) Then
                        Try
                           'Guardo numero de comprobante por si falla la grabacion del TICKET
                           ventas.ActualizaNumeroComprobanteFiscal(ComprobanteNuevo.IdSucursal, ComprobanteNuevo.TipoComprobante.IdTipoComprobante,
                                                               ComprobanteNuevo.LetraComprobante, ComprobanteNuevo.Impresora.CentroEmisor,
                                                               ComprobanteNuevo.NumeroComprobante, ComprobanteFiscal.NumeroComprobante)

                           My.Application.Log.WriteEntry("FacturacionRapida.GrabarComprobante - Grabo Nuevo Ticket " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
                           '''''Si la impresion fue ok grabo el TICKET FISCAL
                           ventas.GrabarComprobanteFiscal(ComprobanteNuevo, ComprobanteFiscal, Entidades.Entidad.MetodoGrabacion.Manual, Me.IdFuncion)

                        Catch ex As Reglas.Ventas.ActualizaCAEException
                           ShowError(ex)
                        Catch
                           ShowMessage("Error en la grabación del comprobante, por favor ir a pantalla Impresion Tickets Fiscales.")
                        End Try
                     End If
                     My.Application.Log.WriteEntry("FacturacionRapida.GrabarComprobante - Finalizo Imprimir Ticket " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
                  Catch ex As Exception
                     Dim stb As StringBuilder = New StringBuilder()
                     stb.AppendLine("Error en la impresión Fiscal.")
                     ArmaErrorRecursivo(ex, stb)

                     ShowMessage(stb.ToString())

                  End Try
               End If
            End If

         Next


         If Me.chbEliminarOrigen.Checked Then
            ShowMessage("Los comprobantes se reemplazaron exitosamente!")
         Else
            ShowMessage("Los comprobantes se copiaron exitosamente!")
         End If

         If _configuracionAutomatica IsNot Nothing AndAlso _configuracionAutomatica.CerrarAutomaticamente Then
            Close()
         End If

      Catch ex As Exception
         ShowError(ex)
      Finally
         If Not (_configuracionAutomatica IsNot Nothing AndAlso _configuracionAutomatica.CerrarAutomaticamente) Then
            'limpio la grilla
            Me.btnBuscar.PerformClick()
         End If

         Me.RefrescandoInfo("")
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged
      Try
         Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
         Me.bscCliente.Enabled = Me.chbCliente.Checked


         Me.bscCodigoCliente.Text = String.Empty
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscCliente.Text = String.Empty

         Me.bscCodigoCliente.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbLetra_CheckedChanged(sender As Object, e As EventArgs) Handles chbLetra.CheckedChanged
      Me.cboLetra.Enabled = Me.chbLetra.Checked
      If Not Me.chbLetra.Checked Then
         Me.cboLetra.SelectedIndex = -1
      Else
         If Me.cboLetra.Items.Count > 0 Then
            Me.cboLetra.SelectedIndex = 0
         End If
      End If
      Me.cboLetra.Focus()

   End Sub

   Private Sub chbEmisor_CheckedChanged(sender As Object, e As EventArgs) Handles chbEmisor.CheckedChanged
      Me.cmbEmisor.Enabled = Me.chbEmisor.Checked
      If Not Me.chbEmisor.Checked Then
         Me.cmbEmisor.SelectedIndex = -1
      Else
         If Me.cmbEmisor.Items.Count > 0 Then
            Me.cmbEmisor.SelectedIndex = 0
         End If
      End If
      Me.cmbEmisor.Focus()

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnBuscar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnBuscar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      Try
         Me.Cursor = Cursors.WaitCursor

         For Each dr As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.ugvComprobantes.Rows
            dr.Cells("Ok").Value = Me.chbTodos.Checked
         Next

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub chbEliminarOrigen_CheckedChanged(sender As Object, e As EventArgs) Handles chbEliminarOrigen.CheckedChanged
      If Me.chbEliminarOrigen.Checked Then
         Me.btnCopiar.Text = "Reemplazar Comprobantes (F4)"
      Else
         Me.btnCopiar.Text = "Copiar Comprobantes (F4)"
         'VIENE DE LA MANO DE LA VALIDACION ANULADA EN EL VALUECHANGED DEL COMBO DE TIPO COMPROBANTE. SI ES NECESARIO DESCOMENTAR Y ARREGLAR (NO USAR SelectedIndex)
         'Me.cmbTiposComprobantesDestino.SelectedIndex = Me.cmbTiposComprobantesOrigen.SelectedIndex
      End If
   End Sub

   Private Sub chbNumeroReparto_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroReparto.CheckedChanged
      Me.txtNroReparto.Enabled = Me.chbNumeroReparto.Checked
      If Not Me.chbNumeroReparto.Checked Then
         Me.txtNroReparto.Text = ""
      Else
         Me.txtNroReparto.Focus()
      End If
   End Sub

   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      Me.txtUsuario.Enabled = Me.chbUsuario.Checked
      If Not Me.chbUsuario.Checked Then
         Me.txtUsuario.Text = ""
      Else
         Me.txtUsuario.Focus()
      End If
   End Sub

   Private Sub chbNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumero.CheckedChanged
      Me.txtNumero.Enabled = Me.chbNumero.Checked
      If Not Me.chbNumero.Checked Then
         Me.txtNumero.Text = ""
      Else
         Me.txtNumero.Focus()
      End If
   End Sub

   Private Sub cmbTiposComprobantes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposComprobantesDestino.SelectedIndexChanged
      'NO RECORDAMOS EL MOTIVO DE ESTA RESTRICCION. SI ES NECESARIA HAY QUE REHABILITAR UY CORREGOR (NO USAR SelectedIndex)
      'If Not Me.chbEliminarOrigen.Checked And Me.cmbTiposComprobantesDestino.SelectedIndex <> Me.cmbTiposComprobantesOrigen.SelectedIndex Then
      '   MessageBox.Show("Debe seleccionar el mismo tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Me.cmbTiposComprobantesDestino.SelectedIndex = Me.cmbTiposComprobantesOrigen.SelectedIndex
      'End If
   End Sub

   Private Sub chbUtilizaFechaCompAnterior_CheckedChanged(sender As Object, e As EventArgs) Handles chbUtilizaFechaCompAnterior.CheckedChanged

      Try
         Me.dtpNuevaFecha.Enabled = Not Me.chbUtilizaFechaCompAnterior.Checked
         If Me.dtpNuevaFecha.Enabled Then Me.dtpNuevaFecha.Value = Date.Now

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Sub-Clases"
   Public Class ConfiguracionAutomatica
      Public Property Usuario As String
      Public Property IdTipoComprobanteOrigen As String
      Public Property IdTipoComprobanteDestino As String
      Public Property IdCaja As Integer

      Public Property LetraOrigen As String
      Public Property CentroEmisorOrigen As Short
      Public Property NumeroComprobanteOrigen As Long

      'Propiedades con valores por defecto
      Public Property CerrarAutomaticamente As Boolean = True
      Public Property EliminarComprobante As Boolean = True
      Public Property OrdenarPor As String = Entidades.Venta.Columnas.Fecha.ToString()
      Public Property OrdenarDescendente As Boolean = True
      Public Property SeleccionarPrimerRegistro As Boolean = True
      Public Property MetodoGrabacion As Entidades.Entidad.MetodoGrabacion = Entidades.Entidad.MetodoGrabacion.Automatico
   End Class
#End Region

   Private Sub chbNumeroDestino_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroDestino.CheckedChanged
      Me.txtNumeroDestino.Enabled = Me.chbNumeroDestino.Checked
      If Not Me.chbNumeroDestino.Checked Then
         Me.txtNumeroDestino.Text = ""
      Else
         Me.txtNumeroDestino.Focus()
      End If
   End Sub

   Private Sub cmbTiposComprobantesDestino_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTiposComprobantesDestino.SelectedValueChanged
      Try
         Dim tpComp As Entidades.TipoComprobante = GetTipoComprobanteDestinoSeleccionado()
         If tpComp IsNot Nothing AndAlso Not tpComp.NumeracionAutomatica Then
            chbNumeroDestino.Enabled = True ' DirectCast(ugvComprobantes.DataSource, DataTable).Select("Ok").Count = 1
         Else
            chbNumeroDestino.Checked = False
            chbNumeroDestino.Enabled = False
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Function GetTipoComprobanteDestinoSeleccionado() As Entidades.TipoComprobante
      If cmbTiposComprobantesDestino.SelectedIndex > -1 AndAlso
         TypeOf (cmbTiposComprobantesDestino.SelectedItem) Is Entidades.TipoComprobante Then
         Return DirectCast(cmbTiposComprobantesDestino.SelectedItem, Entidades.TipoComprobante)
      End If
      Return Nothing
   End Function

   Private Sub cmbSucursalNueva_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursalNueva.SelectedIndexChanged
      Try
         If cmbSucursalNueva.SelectedIndex > -1 Then
            Dim suc As Entidades.Sucursal = DirectCast(cmbSucursalNueva.SelectedItem, Entidades.Sucursal)

            If Not _copiaFactNCred Then
               Me._publicos.CargaComboTiposComprobantesReemplazar(cmbTiposComprobantesDestino, miraPC:=True, tipo1:="VENTAS", tipo2:="", afectaCaja:="TODOS", usaFacturacion:=True,
                                                                  permiteElectronicos:=False, permiteFiscales:=True, idSucursal:=suc.IdSucursal,
                                                                  grabaLibro:=Nothing, esComercial:=Nothing, coeficienteValor:=Nothing, incluyePreElectronicas:=Nothing)
            Else
               Me._publicos.CargaComboTiposComprobantesReemplazar(cmbTiposComprobantesDestino, miraPC:=True, tipo1:="VENTAS", tipo2:="", afectaCaja:="TODOS", usaFacturacion:=False,
                                                                  permiteElectronicos:=False, permiteFiscales:=True, idSucursal:=suc.IdSucursal,
                                                                  grabaLibro:=True, esComercial:=True, coeficienteValor:=-1, incluyePreElectronicas:=True)
            End If

            Me._publicos.CargaComboCajas(cmbCajas, suc.IdSucursal, miraUsuario:=True, miraPC:=True, cajasModificables:=True)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _copiaFactNCred = parametros.Equals("COPIA-FACT-NCRED")
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function
End Class