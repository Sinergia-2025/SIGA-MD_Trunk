Public Class PedidosProvPendientesAyuda

#Region "Campos"

   Private _publicos As Publicos

   Private _tipoComprobFacturador As Entidades.TipoComprobante
   Private _idListaPrecios As Integer
   Private _idTipoComprob As String    'No puede tener el nombre _idTipoComprobante porque coincide con el parametro.
   Private _idProveedor As Long

   Private _comprobantes As List(Of Entidades.Compra)
   Private _comprobantesSeleccionados As List(Of Entidades.Compra)

   Private _tit As Dictionary(Of String, String)
#End Region

#Region "Propiedades"
   Public ReadOnly Property ComprobantesSeleccionados() As List(Of Entidades.Compra)
      Get
         Return _comprobantesSeleccionados
      End Get
   End Property
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         CargarValoresIniciales()
         'En forma predeterminada ya no busco, el usuario debe elegir buscar, sobre todo por aquellos que tienen mucha informacion y demora demasiado.
         'Me.CargaGrillaDetalle()

         _tit = GetColumnasVisiblesGrilla(dgvDetalle)
      End Sub)
   End Sub

#End Region

#Region "Constructores"

   Public Sub New(idTipoComprobanteFacturador As String, idTipoComprobante As String, IdProveedor As Long)
      InitializeComponent()

      _tipoComprobFacturador = New Reglas.TiposComprobantes().GetUno(idTipoComprobanteFacturador)
      _idTipoComprob = idTipoComprobante
      _idProveedor = IdProveedor

      If _comprobantesSeleccionados Is Nothing Then
         _comprobantesSeleccionados = New List(Of Entidades.Compra)()
      End If
   End Sub
   Public Sub New(idTipoComprobanteFacturador As String, tipoComprobante As String, IdProveedor As Long, comprobantesSeleccionados As List(Of Entidades.Compra))
      Me.New(idTipoComprobanteFacturador, tipoComprobante, IdProveedor)
      _comprobantesSeleccionados = comprobantesSeleccionados
   End Sub

#End Region

#Region "Eventos"

#Region "Eventos Filtros"
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(Sub() chbProveedor.FiltroCheckedChanged(bscCodigoProveedor, bscNombreProveedor))
   End Sub
#Region "Eventos Búsqueda Proveedor"
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscCodigoProveedor)
         Dim codProv = bscCodigoProveedor.Text.ValorNumericoPorDefecto(0L)
         bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codProv)
      End Sub)
   End Sub
   Private Sub bscNombreProveedor_BuscadorClick() Handles bscNombreProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscNombreProveedor)
         bscNombreProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscNombreProveedor.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscNombreProveedor.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProveedor(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub chbOrdenCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenCompra.CheckedChanged
      TryCatched(Sub() chbOrdenCompra.FiltroCheckedChanged(txtOrdenCompra))
   End Sub
#End Region

   Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
      TryCatched(
      Sub()
         If clbTiposComprobantes.CheckedItems.Count = 0 Then
            ShowMessage("ATENCION: Debe elegir al menos un Tipo de Comprobante")
            clbTiposComprobantes.Focus()
            Exit Sub
         End If

         Dim primerTipoComprobante = String.Empty
         Dim blnAfectaCaja = False, blnGrabaLibro As Boolean = False, blnCoeficienteStockCero As Boolean = False
         Dim intCoeficienteStock As Integer
         Dim primerTipo = String.Empty
         Dim cont = 0I


         For Each doc As DataRowView In clbTiposComprobantes.CheckedItems

            Dim oTC = New Reglas.TiposComprobantes().GetUno(doc("IdTipoComprobante").ToString())
            'Permito que un Presupuesto elija Presupuesto.
            If oTC.IdTipoComprobante = Me._tipoComprobFacturador.IdTipoComprobante And Me._tipoComprobFacturador.CoeficienteStock <> 0 Then
               MessageBox.Show("ATENCION: no puede elegir el mismo comprobante que el Invocador.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
               Me.clbTiposComprobantes.Focus()
               Exit Sub
            End If

            cont += 1

            If cont = 1 Then
               primerTipoComprobante = oTC.Descripcion.Trim().ToUpper()
               blnAfectaCaja = oTC.AfectaCaja
               blnGrabaLibro = oTC.GrabaLibro
               blnCoeficienteStockCero = (oTC.CoeficienteStock = 0)
               intCoeficienteStock = oTC.CoeficienteStock
               primerTipo = oTC.Tipo
            Else
               If primerTipo <> oTC.Tipo Then
                  MessageBox.Show("ATENCION: el Tipo Comprobante '" & oTC.Descripcion.Trim.ToUpper() & "' tiene distinto Tipo del  '" & primerTipoComprobante & "'.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                  Me.clbTiposComprobantes.Focus()
                  Exit Sub
               End If


               If blnGrabaLibro <> oTC.GrabaLibro Then
                  MessageBox.Show("ATENCION: el Tipo Comprobante '" & oTC.Descripcion.Trim.ToUpper() & "' tiene distinta Configuracion de IVA del '" & primerTipoComprobante & "'.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                  Me.clbTiposComprobantes.Focus()
                  Exit Sub
               End If

               If blnAfectaCaja <> oTC.AfectaCaja Then
                  MessageBox.Show("ATENCION: el Tipo Comprobante '" & oTC.Descripcion.Trim.ToUpper() & "' tiene distinta Configuracion de Caja del '" & primerTipoComprobante & "'.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
                  MessageBox.Show("ATENCION: el Tipo Comprobante '" & oTC.Descripcion.Trim.ToUpper() & "' tiene distinta Configuracion de Coeficiente Stock del '" & primerTipoComprobante & "' cuando algun valor es 0 (Cero).", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                  Me.clbTiposComprobantes.Focus()
                  Exit Sub
               End If

               'Permito que sean -1 y 1, pero no uno que sea 0 (y 1 / -1), pero tampoco permito distintos si el invocador es una NCRED.
               If intCoeficienteStock <> oTC.CoeficienteStock And Me._tipoComprobFacturador.CoeficienteValores = -1 Then
                  MessageBox.Show("ATENCION: el Tipo Comprobante '" & oTC.Descripcion.Trim.ToUpper() & "' tiene distinta Configuracion de Coeficiente Stock del '" & primerTipoComprobante & "', y NO lo permite el invocador '" & Me._tipoComprobFacturador.Descripcion.Trim.ToUpper() & "'.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                  Me.clbTiposComprobantes.Focus()
                  Exit Sub
               End If

            End If

         Next

         If Me.chbProveedor.Checked And Not Me.bscCodigoProveedor.Selecciono And Not Me.bscNombreProveedor.Selecciono Then
            MessageBox.Show("No seleccionó un Proveedor aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         CargaGrillaDetalle()
      End Sub)
   End Sub

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      TryCatched(
      Sub()
         For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
            dr.Cells("Check").Value = Me.chbTodos.Checked
         Next
      End Sub)
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(
      Sub()
         For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
            If dr.Cells("Check").Value IsNot Nothing Then
               If Boolean.Parse(dr.Cells("Check").Value.ToString()) = True Then
                  Me._comprobantesSeleccionados.Add(Me._comprobantes(dr.Index))
               End If
            End If
         Next
         DialogResult = DialogResult.OK
      End Sub)
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()

      _publicos = New Publicos()

      If Me._idTipoComprob = "" Then
         Dim ComprobAsoc As String
         'ComprobAsoc = New Reglas.TiposComprobantes().GetUno(Me._idTipoComprobFacturador).ComprobantesAsociados
         ComprobAsoc = Me._tipoComprobFacturador.ComprobantesAsociados
         Me._publicos.CargaListaTiposComprobantesFacturables(Me.clbTiposComprobantes, ComprobAsoc, False)
      Else
         Me._publicos.CargaListaTiposComprobantesPedidosProveedores(Me.clbTiposComprobantes)
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

      'Me.dtpDesde.Value = Date.Now.AddDays(-7)
      Me.dtpDesde.Value = Date.Now.AddYears(-1)
      Me.dtpHasta.Value = Date.Now

      'AR: Esta OCULTO
      'Me.chbProveedor.Enabled = Publicos.FacturacionInvocarDeOtroCliente

   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
         bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
         bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
         bscNombreProveedor.Permitido = False
         bscCodigoProveedor.Permitido = False
         btnBuscar.Focus()
      End If
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim idTiposComprobantes As List(Of String) = New List(Of String)()
      Dim idProveedor As Long = Me._idProveedor

      For Each doc As DataRowView In Me.clbTiposComprobantes.CheckedItems
         idTiposComprobantes.Add(doc("IdTipoComprobante").ToString())
      Next

      'If Me.clbTiposComprobantes.Items.Count > 0 Then
      '   If Me.cmbTiposComprobantes.SelectedItem IsNot Nothing Then
      '      'strTipoComprobante = Me.cmbTiposComprobantes.SelectedItem("IdTipoComprobante").ToString()
      '      IdTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
      '   End If
      'End If

      Dim numeroOrdenCompra As Long = 0
      If Me.chbOrdenCompra.Checked Then
         Long.TryParse(Me.txtOrdenCompra.Text.ToString(), numeroOrdenCompra)
      End If

      If Me.chbProveedor.Checked Then
         idProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
      End If

      Dim decTotal As Decimal

      Dim oPedidos As Reglas.Compras = New Reglas.Compras()

      _comprobantes = Nothing
      _comprobantes = oPedidos.GetFacturablesPedidos(actual.Sucursal.Id,
                                                     dtpDesde.Value, dtpHasta.Value, idTiposComprobantes, idProveedor,
                                                     _idListaPrecios, numeroOrdenCompra)

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
            For Each vent1 As Entidades.Compra In Me._comprobantesSeleccionados
               If Long.Parse(row.Cells("NumeroComprobante").Value.ToString()) = vent1.NumeroComprobante Then
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
         .Columns("LetraComprobante").DisplayIndex = 3
         .Columns("CentroEmisor").DisplayIndex = 4
         .Columns("NumeroComprobante").DisplayIndex = 5
         .Columns("Kilos").DisplayIndex = 6
         .Columns("Total").DisplayIndex = 7
         .Columns("facObservacion").DisplayIndex = 8
      End With

   End Sub

#End Region

End Class