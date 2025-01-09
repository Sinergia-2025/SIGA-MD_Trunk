#Region "Option/Imports"
Option Explicit On
Option Strict On
#End Region
Public Class FacturablesPendientesComAyuda

#Region "Campos"

   Private _publicos As Publicos

   Private _tipoComprobFacturador As Entidades.TipoComprobante
   Private _idListaPrecios As Integer
   Private _idTipoComprob As String    'No puede tener el nombre _idTipoComprobante porque coincide con el parametro.
   Private _tipoDocProveedor As String
   Private _IdProveedor As Long
   Private _comprobantes As List(Of Entidades.Compra)
   Private _comprobantesSeleccionados As List(Of Entidades.Compra)

   Private _tit As Dictionary(Of String, String)
   Public Property InvocandoDesde As OrigenInvocacion

   Private _utilizaCentroCostos As Boolean = False
#End Region

   Public Enum OrigenInvocacion
      Compras
      Ventas
      Stock
   End Enum

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me.Cursor = Cursors.WaitCursor

         Me.CargarValoresIniciales()

         If InvocandoDesde = OrigenInvocacion.Ventas Then
            dgvDetalle.Columns(NombreProveedor.Name).Visible = True
         ElseIf InvocandoDesde = OrigenInvocacion.Stock Then
            dgvDetalle.Columns(NombreProveedor.Name).Visible = True
            Me.chbProveedor.Visible = True
            Me.bscCodigoProveedor.Visible = True
            Me.bscProveedor.Visible = True
            Me.lblCodigoProveedor.Visible = True
            Me.lblNombreProveedor.Visible = True
         End If

         _tit = GetColumnasVisiblesGrilla(dgvDetalle)

         'En forma predeterminada ya no busco, el usuario debe elegir buscar, sobre todo por aquellos que tienen mucha informacion y demora demasiado.
         'Me.CargaGrillaDetalle()

         Me.Cursor = Cursors.Default

      Catch ex As Exception

         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Constructores"

   Private Sub New()
      InitializeComponent()
      InvocandoDesde = OrigenInvocacion.Compras
   End Sub

   Public Sub New(idTipoComprobanteFacturador As String, tipoComprobante As String, IdProveedor As Long, comprobantesSeleccionados As List(Of Entidades.Compra))
      Me.New()
      Me._tipoComprobFacturador = New Reglas.TiposComprobantes().GetUno(idTipoComprobanteFacturador)
      Me._idTipoComprob = tipoComprobante
      Me._IdProveedor = IdProveedor
      Me._comprobantesSeleccionados = comprobantesSeleccionados
   End Sub

   Public Sub New(idTipoComprobanteFacturador As String, tipoComprobante As String, comprobantesSeleccionados As List(Of Entidades.Compra))
      Me.New()
      Me._tipoComprobFacturador = New Reglas.TiposComprobantes().GetUno(idTipoComprobanteFacturador)
      Me._idTipoComprob = tipoComprobante
      Me._comprobantesSeleccionados = comprobantesSeleccionados
      InvocandoDesde = OrigenInvocacion.Stock
   End Sub

   Public Sub New(idTipoComprobanteFacturador As String, tipoComprobante As String, IdProveedor As Long, comprobantesSeleccionados As List(Of Entidades.Compra),
                  invocandoDesde As OrigenInvocacion)
      Me.New(idTipoComprobanteFacturador, tipoComprobante, IdProveedor, comprobantesSeleccionados)
      Me.InvocandoDesde = invocandoDesde
   End Sub

#End Region

#Region "Eventos"

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

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProveedor.CheckedChanged

      Try

         Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
         Me.bscProveedor.Enabled = Me.chbProveedor.Checked

         Me.bscCodigoProveedor.Text = String.Empty
         Me.bscCodigoProveedor.Tag = Nothing
         Me.bscProveedor.Text = String.Empty

         Me.bscCodigoProveedor.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscCodigoProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnBuscar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnBuscar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

      Try

         If Me.clbTiposComprobantes.CheckedItems.Count = 0 Then
            MessageBox.Show("ATENCION: Debe elegir al menos un Tipo de Comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.clbTiposComprobantes.Focus()
            Exit Sub
         End If

         Dim oTC As Entidades.TipoComprobante
         Dim PrimerTipoComprobante As String = String.Empty
         Dim blnAfectaCaja As Boolean = False, blnGrabaLibro As Boolean = False, blnCoeficienteStockCero As Boolean = False
         Dim intCoeficienteStock As Integer
         Dim Cont As Integer = 0

         For Each doc As DataRowView In Me.clbTiposComprobantes.CheckedItems

            oTC = New Reglas.TiposComprobantes().GetUno(doc("IdTipoComprobante").ToString())

            If InvocandoDesde <> OrigenInvocacion.Stock Then
               'Permito que un Presupuesto elija Presupuesto.
               If oTC.IdTipoComprobante = Me._tipoComprobFacturador.IdTipoComprobante And Me._tipoComprobFacturador.CoeficienteStock <> 0 Then
                  MessageBox.Show("ATENCION: no puede elegir el mismo comprobante que el Invocador.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                  Me.clbTiposComprobantes.Focus()
                  Exit Sub
               End If
            End If


            Cont += 1

            If Cont = 1 Then
               PrimerTipoComprobante = oTC.Descripcion.Trim().ToUpper()
               blnAfectaCaja = oTC.AfectaCaja
               blnGrabaLibro = oTC.GrabaLibro
               blnCoeficienteStockCero = (oTC.CoeficienteStock = 0)
               intCoeficienteStock = oTC.CoeficienteStock
            Else

               If blnGrabaLibro <> oTC.GrabaLibro Then
                  MessageBox.Show("ATENCION: el Tipo Comprobante '" & oTC.Descripcion.Trim.ToUpper() & "' tiene distinta Configuracion de IVA del '" & PrimerTipoComprobante & "'.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                  Me.clbTiposComprobantes.Focus()
                  Exit Sub
               End If

               If blnAfectaCaja <> oTC.AfectaCaja Then
                  MessageBox.Show("ATENCION: el Tipo Comprobante '" & oTC.Descripcion.Trim.ToUpper() & "' tiene distinta Configuracion de Caja del '" & PrimerTipoComprobante & "'.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                  Me.clbTiposComprobantes.Focus()
                  Exit Sub
               End If

               'If blnCoeficienteStockCero <> (oTC.CoeficienteStock = 0) Then
               '   MessageBox.Show("ATENCION: el Tipo Comprobante '" & oTC.Descripcion.Trim.ToUpper() & "' tiene distinta Configuracion de Coeficiente Stock del '" & PrimerTipoComprobante & "'.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
               '   Me.clbTiposComprobantes.Focus()
               '   Exit Sub
               'End If

               'Permito que sean -1 y 1, pero no uno que sea 0 (y 1 / -1)
               If intCoeficienteStock <> oTC.CoeficienteStock And (intCoeficienteStock = 0 Or oTC.CoeficienteStock = 0) Then
                  MessageBox.Show("ATENCION: el Tipo Comprobante '" & oTC.Descripcion.Trim.ToUpper() & "' tiene distinta Configuracion de Coeficiente Stock del '" & PrimerTipoComprobante & "' cuando algun valor es 0 (Cero).", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                  Me.clbTiposComprobantes.Focus()
                  Exit Sub
               End If

               'Permito que sean -1 y 1, pero no uno que sea 0 (y 1 / -1), pero tampoco permito distintos si el invocador es una NCRED.
               If intCoeficienteStock <> oTC.CoeficienteStock And Me._tipoComprobFacturador.CoeficienteValores = -1 Then
                  MessageBox.Show("ATENCION: el Tipo Comprobante '" & oTC.Descripcion.Trim.ToUpper() & "' tiene distinta Configuracion de Coeficiente Stock del '" & PrimerTipoComprobante & "', y NO lo permite el invocador '" & Me._tipoComprobFacturador.Descripcion.Trim.ToUpper() & "'.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                  Me.clbTiposComprobantes.Focus()
                  Exit Sub
               End If

            End If

         Next
         If chbCentroCosto.Checked Then
            If Not IsNumeric(cmbCentroCosto.SelectedValue) Then
               MessageBox.Show("Ha seleccionado el filtro por Centro de Costos pero no ha seleccionado uno. Por favor reintente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
               Exit Sub
            End If
         End If
         If Me.chbProveedor.Checked And Not Me.bscCodigoProveedor.Selecciono And Not Me.bscProveedor.Selecciono Then
            MessageBox.Show("No seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub dgvDetalle_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick

      'La situacion qeu controlo se da si tiene activado la posibilidad de Invocar Comprobantes que invocaron.
      'o bien si alguna vez lo tuvo, pero por performance (por ahora), pregunto una vez.

      If Reglas.Publicos.Facturacion.FacturacionInvocarInvocador Then

         Try

            If Me.dgvDetalle.RowCount = 0 Then Exit Sub

            'If Me.dgvDetalle.SelectedRows.Count = 0 Then Exit Sub

            'If e.RowIndex <> -1 And e.ColumnIndex = 0 Then

            '   Me.Cursor = Cursors.WaitCursor

            '   Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

            '   Dim venta As Entidades.Venta = oVentas.GetUna(actual.Sucursal.Id, _
            '               Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString(), _
            '               Me.dgvDetalle.Rows(e.RowIndex).Cells("LetraComprobante").Value.ToString(), _
            '               Short.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("CentroEmisor").Value.ToString()), _
            '               Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("NumeroComprobante").Value.ToString()))


            '   'Si invoco a uno que en el extremo movia stock, el codigo no esta previsto y vuelve a descontar stock.
            '   'Habria que ahcer el codigo recurrente en el analisis de los facturables.

            '   'Controlo si el que facturo movia stock.
            '   If Me._tipoComprobFacturador.CoeficienteStock <> 0 And venta.Facturables.Count > 0 AndAlso venta.Facturables(0).TipoComprobante.CoeficienteStock <> 0 Then
            '      MessageBox.Show("El Comprobante que intenta seleccionar Invoco a otro que afecto Stock, NO puede seleccionarlo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Question)
            '      Me.dgvDetalle.EndEdit() 'Fuerzo el fin de la edicion para poder ponerlo en falso.
            '      Me.dgvDetalle.Rows(e.RowIndex).Cells("Check").Value = False
            '      Exit Sub
            '   End If

            'End If

         Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Finally
            Me.Cursor = Cursors.Default
         End Try

      End If

   End Sub

   'Private Sub dgvDetalle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetalle.DoubleClick

   '   Try

   '      If Me.dgvDetalle.SelectedRows.Count > 0 Then
   '         Me.dgvDetalle.Rows(Me.dgvDetalle.SelectedRows(0).Index).Cells("Check").Value = True
   '      End If

   '      Me.btnAceptar_Click(sender, e)

   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try

   'End Sub

   Private Sub chbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTodos.CheckedChanged

      Me.Cursor = Cursors.WaitCursor

      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
         dr.Cells("Check").Value = Me.chbTodos.Checked
      Next

      Me.Cursor = Cursors.Default

   End Sub

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

      'Me.DialogResult = Windows.Forms.DialogResult.OK

      Try
         Me.Cursor = Cursors.WaitCursor
         Dim Cont As Integer = 0
         For Each dr As DataGridViewRow In Me.dgvDetalle.Rows

            'If dr.Cells("Check").Value IsNot Nothing Then
            '   If Boolean.Parse(dr.Cells("Check").Value.ToString()) = True Then
            '      Me._comprobantesSeleccionados.Add(Me._comprobantes(dr.Index))
            '   End If
            'End If

            If dr.Cells("Check").Value IsNot Nothing Then
               If Boolean.Parse(dr.Cells("Check").Value.ToString()) = True Then
                  If InvocandoDesde <> OrigenInvocacion.Stock Then
                     If Not Me.chbSoloCopiar.Checked And (Me._comprobantes(dr.Index).IdTipoComprobante = Me._tipoComprobFacturador.IdTipoComprobante And Me._tipoComprobFacturador.CoeficienteStock <> 0) Then
                        MessageBox.Show("ATENCION: no puede elegir el mismo comprobante que el Invocador.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.clbTiposComprobantes.Focus()
                        Exit Sub
                     End If
                  End If
                  '-- Valida la seguridad de los depositos para cada producto.-------
                  Dim rDeposito = New Reglas.SucursalesDepositosUsuarios()
                  For Each rPro In Me._comprobantes(dr.Index).ComprasProductos
                     If rDeposito.GetSeguridadUsuariosDepositos(rPro.IdDeposito, False).Rows.Count = 0 Then
                        Dim eDeposito = New Reglas.SucursalesDepositos().GetUno(rPro.IdDeposito, actual.Sucursal.IdSucursal)
                        MessageBox.Show(String.Format("ATENCION: No Posee autorización para el Deposito({4}) del Comprobante Invocado {0}-{1}-{2}-{3}.",
                                                      Me._comprobantes(dr.Index).TipoComprobante.Descripcion,
                                                      Me._comprobantes(dr.Index).Letra,
                                                      Me._comprobantes(dr.Index).CentroEmisor,
                                                      Me._comprobantes(dr.Index).NumeroComprobante,
                                                      eDeposito.NombreDeposito), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.clbTiposComprobantes.Focus()
                        Exit Sub
                     End If
                  Next
                  '------------------------------------------------------------------
                  Me._comprobantesSeleccionados.Add(Me._comprobantes(dr.Index))
                  Cont += 1
               End If

            End If

         Next
         If Cont = 0 Then
            MessageBox.Show("ATENCION: NO Selecciono Ningun Comprobante para Invocar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.dgvDetalle.Focus()
            Exit Sub
         End If

         Me.DialogResult = Windows.Forms.DialogResult.OK
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()

      Me._publicos = New Publicos()

      Dim ComprobAsoc As String
      'ComprobAsoc = New Reglas.TiposComprobantes().GetUno(Me._idTipoComprobFacturador).ComprobantesAsociados
      ComprobAsoc = Me._tipoComprobFacturador.ComprobantesAsociados

      If InvocandoDesde = OrigenInvocacion.Stock Then
         Me._publicos.CargaListaTiposComprobantesCompras(Me.clbTiposComprobantes)
      Else
         Me._publicos.CargaListaTiposComprobantesFacturablesCom(Me.clbTiposComprobantes, ComprobAsoc)
      End If



      If Me.clbTiposComprobantes.Items.Count > 0 And Me._idTipoComprob <> "" Then
         Dim Cont As Integer = 0
         For Each doc As DataRowView In Me.clbTiposComprobantes.Items
            If doc("IdTipoComprobante").ToString() = Me._idTipoComprob Then
               Me.clbTiposComprobantes.SetItemChecked(Cont, True)
               Exit For
            End If
            Cont += 1
         Next
      End If

      If Me.clbTiposComprobantes.Items.Count = 1 Then
         Me.clbTiposComprobantes.SetItemChecked(0, True)
      End If

      'Es demasiado.
      Me.dtpDesde.Value = Date.Now.AddDays(-7)
      Me.dtpHasta.Value = Date.Now

      'NO Aplica. Pertenece de Clientes.
      'Me.chbProveedor.Enabled = Publicos.FacturacionInvocarDeOtroCliente

      _utilizaCentroCostos = Publicos.TieneModuloContabilidad AndAlso Reglas.ContabilidadPublicos.UtilizaCentroCostos

      If _utilizaCentroCostos Then
         _publicos.CargaComboCentroCostos(cmbCentroCosto)
         cmbCentroCosto.Visible = True
         chbCentroCosto.Visible = True
      Else
         cmbCentroCosto.Visible = False
         chbCentroCosto.Visible = False
      End If

      _publicos.CargaComboDesdeEnum(cmbInvocados, GetType(Entidades.Publicos.SiNoTodos), Entidades.Publicos.SiNoTodos.NO)

   End Sub

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Permitido = False
      Me.bscCodigoProveedor.Permitido = False

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim idTiposComprobantes As List(Of String) = New List(Of String)()
      Dim idProveedor As Long = Me._IdProveedor

      For Each doc As DataRowView In Me.clbTiposComprobantes.CheckedItems
         idTiposComprobantes.Add(doc("IdTipoComprobante").ToString())
      Next

      'If Me.clbTiposComprobantes.Items.Count > 0 Then
      '   If Me.cmbTiposComprobantes.SelectedItem IsNot Nothing Then
      '      'strTipoComprobante = Me.cmbTiposComprobantes.SelectedItem("IdTipoComprobante").ToString()
      '      IdTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
      '   End If
      'End If

      If Me.bscCodigoProveedor.Tag IsNot Nothing Then
         idProveedor = Me._IdProveedor
      End If

      If InvocandoDesde = OrigenInvocacion.Stock Then
         If Me.chbProveedor.Checked Then
            idProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
         End If
      End If

      Dim decTotal As Decimal

      Dim oCompras As Reglas.Compras = New Reglas.Compras()

      Dim idEstadoComprobante As String = "PENDIENTE"
      Dim idTipoComprobanteVentaNULL As Boolean = False

      If InvocandoDesde = OrigenInvocacion.Ventas Or InvocandoDesde = OrigenInvocacion.Compras Then
         idEstadoComprobante = "TODOS"
         idTipoComprobanteVentaNULL = True
      End If

      Me._comprobantes = Nothing


      Dim idCentroCosto As Integer? = Nothing
      If chbCentroCosto.Checked Then
         If IsNumeric(cmbCentroCosto.SelectedValue) Then
            idCentroCosto = Integer.Parse(cmbCentroCosto.SelectedValue.ToString())
         End If
      End If

      _comprobantes = oCompras.GetFacturables(actual.Sucursal.Id,
                                              dtpDesde.Value, dtpHasta.Value, idTiposComprobantes, idProveedor,
                                              idEstadoComprobante, idTipoComprobanteVentaNULL, InvocandoDesde = OrigenInvocacion.Stock,
                                              idCentroCosto, cmbInvocados.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos))

      decTotal = 0

      Me.dgvDetalle.DataSource = Me._comprobantes
      AjustarColumnasGrilla(dgvDetalle, _tit)

      For Each row As DataGridViewRow In Me.dgvDetalle.Rows
         'row.Cells("Check").Value = False
         decTotal = decTotal + Decimal.Parse(row.Cells("Total").Value.ToString())
      Next

      Me.chbTodos.Checked = False

      Me.txtTotal.Text = decTotal.ToString("##,##0.00")

      Me.tssRegistros.Text = Me._comprobantes.Count.ToString() & " Registros"

      If Me._comprobantesSeleccionados.Count > 0 Then
         For Each row As DataGridViewRow In Me.dgvDetalle.Rows
            Dim com As Entidades.Compra = DirectCast(row.DataBoundItem, Entidades.Compra)
            For Each vent1 As Entidades.Compra In Me._comprobantesSeleccionados
               If com.TipoComprobante.IdTipoComprobante = vent1.TipoComprobante.IdTipoComprobante And
                  com.Letra = vent1.Letra And
                  com.CentroEmisor = vent1.CentroEmisor And
                  com.NumeroComprobante = vent1.NumeroComprobante And
                  com.Proveedor.IdProveedor = vent1.Proveedor.IdProveedor Then
                  row.Cells("Check").Value = True
               End If
            Next
         Next
         Me._comprobantesSeleccionados = New List(Of Entidades.Compra)
      End If

      With Me.dgvDetalle
         .Columns("Check").DisplayIndex = 0
         .Columns("Fecha").DisplayIndex = 1
         '.Columns("IdTipoComprobante").DisplayIndex = 2
         .Columns("TipoComprobanteDescripcion").DisplayIndex = 2
         .Columns("Letra").DisplayIndex = 3
         .Columns("CentroEmisor").DisplayIndex = 4
         .Columns("NumeroComprobante").DisplayIndex = 5
         .Columns("Total").DisplayIndex = 7
         .Columns("facObservacion").DisplayIndex = 9
      End With

   End Sub

#End Region

#Region "Propiedades"

   Public ReadOnly Property ComprobantesSeleccionados() As List(Of Entidades.Compra)
      Get
         Return Me._comprobantesSeleccionados
      End Get
   End Property

#End Region

   Private Sub chbCentroCosto_CheckedChanged(sender As Object, e As EventArgs) Handles chbCentroCosto.CheckedChanged
      Try
         If chbCentroCosto.Checked Then
            cmbCentroCosto.SelectedIndex = 0
            cmbCentroCosto.Enabled = True
            cmbCentroCosto.Focus()
         Else
            cmbCentroCosto.SelectedIndex = -1
            cmbCentroCosto.Enabled = False
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


End Class