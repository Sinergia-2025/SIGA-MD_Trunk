Public Class ImportarPedidosExcel

#Region "Campos"

   Private _publicos As Publicos
   'Private _dt As DataTable
   Private ConexionExcel As OleDb.OleDbConnection
   'Private RangoExcel As String

   '  Private ColumnaNombreFantasia As Integer = 0
   '  Private ColumnaCantidad As Integer = 4

   Private ColumnaNombreProducto As Integer = 0
   Private ColumnaCodigoProveedor As Integer = 1   'Predeterminado 1 Columna
   Private ColumnaNombreProducto2 As Integer = 2
   Private ColumnaPrecioVenta As Integer = 3
   Private ColumnaNombreMarca As Integer = 99
   Private ColumnaNombreRubro As Integer = 99
   Private ColumnaIVA As Integer = 99
   Private ColumnaMoneda As Integer = 99
   Private ProductosConError As Integer
   Private _estaCargando As Boolean = True
   Private _OrdenCompra As Long = 0
   'Private _formatoExcel As Entidades.Pedido.FormatoImportarPedidos

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            tslRegistroActual.Text = String.Empty
            tslTiempoActual.Text = String.Empty

            cboAccion.Items.Insert(0, "Todas")
            cboAccion.Items.Insert(1, "Altas")
            cboAccion.Items.Insert(2, "Modificar")

            cboEstado.Items.Insert(0, "Todos")
            cboEstado.Items.Insert(1, "Validos")
            cboEstado.Items.Insert(2, "Invalidos")

            _publicos.CargaComboFormasDePago(cmbFormaPago, "VENTAS")
            _publicos.CargaComboDesdeEnum(cmbFormatoArchivo, GetType(Entidades.Pedido.FormatoImportarPedidos))
            cmbFormatoArchivo.SelectedIndex = -1

            _publicos.CargaComboMonedas(cmbMoneda)
            _publicos.CargaComboImpuestos(cmbTipoImpuesto)
            chbAltaProductos.Checked = Reglas.Publicos.ImportarPedidosAltaProductos

            RefrescarDatosGrilla()

            CargarColumnasASumar()

            ugDetalle.AgregarFiltroEnLinea({"NombreProducto", "NombreFantasia", "NombreVendedor"})

            _estaCargando = False
         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbImportar_Click(sender As Object, e As EventArgs) Handles tsbImportar.Click
      TryCatched(
         Sub()
            ' Por si logra repetir la accion.
            If Not tsbImportar.Enabled Then Exit Sub
            If ugDetalle.Rows.Count = 0 Then Exit Sub
            tsbImportar.Enabled = False

            If ProductosConError > 0 AndAlso ShowPregunta("ATENCION: Existen Pedidos que NO se Importarán. ¿ Confirma el Proceso ?") = DialogResult.No Then
               tsbImportar.Enabled = True
               Exit Sub
            ElseIf ShowPregunta("ATENCION: Se importaran los Pedidos del Proveedor: " & bscProveedor.text.ToString() & " - Forma de Pago: " & cmbFormaPago.Text.ToString() & " - Orden de Compra: " & txtOrdenCompra.Text.ToString() & " - ¿ Confirma el Proceso ?") = DialogResult.No Then
               tsbImportar.Enabled = True
               Exit Sub
            End If

            ImportarDatos()

            ShowMessage("Se importaron Pedidos EXITOSAMENTE !!!")
            prbImportando.Value = 0
         End Sub)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
      TryCatched(
         Sub()
            'Dim ArchivoStream As Stream = Nothing
            Using dlg = New OpenFileDialog()
               dlg.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
               dlg.Filter = "Libro de Excel 97-2003 (*.xls)|*.xls|Libro de Excel 2007-2010 (*.xlsx)|*.xlsx|Todos los Archivos (*.*)|*.*"
               dlg.FilterIndex = 1
               dlg.RestoreDirectory = True

               If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                  txtArchivoOrigen.Text = dlg.FileName
                  'Si bien aca lo pude abrir, solo es para obtener el path.
                  'Me.txtRangoCeldas.Focus()
                  'Dim OC As Integer = DialogoAbrirArchivo.FileName.IndexOf("Nº")
                  'Me.txtOrdenCompra.Text = DialogoAbrirArchivo.FileName.Substring(32, 5)
               End If
            End Using
         End Sub)
   End Sub

   Private Sub cboEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstado.SelectedIndexChanged
      TryCatched(
         Sub()
            If Not _estaCargando Then
               tsbImportar.Enabled = (cboEstado.Text <> "Invalidos")
            End If
         End Sub)
   End Sub

   Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
      TryCatched(
         Sub()
            Me.prbImportando.Value = 0


            If GetFormatoSeleccionado().HasValue AndAlso GetFormatoSeleccionado().Value = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or GetFormatoSeleccionado().Value = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB Then



               If Not bscCodigoProveedor.Selecciono And Not bscProveedor.Selecciono Then
                  MessageBox.Show("ATENCION: Debe seleccionar el Proveedor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                  Exit Sub
               End If

               If Me.txtOrdenCompra.Text = "" Then
                  MessageBox.Show("ATENCION: Debe ingresar el numero de Orden de Compra", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                  Exit Sub
               End If

               If Me.cmbFormaPago.SelectedIndex = -1 Then
                  MessageBox.Show("ATENCION: Debe seleccionar la Forma de Pago", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                  Exit Sub
               End If

               Dim OC As DataTable = New Reglas.OrdenesCompra().Get1(actual.Sucursal.IdSucursal, Long.Parse(Me.txtOrdenCompra.Text.ToString()))

               If OC.Rows.Count <> 0 Then
                  If MessageBox.Show("Orden de compra existente. ¿Desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                     Me._OrdenCompra = Long.Parse(OC.Rows(0).Item("NumeroOrdenCompra").ToString())
                  Else
                     Exit Sub
                  End If
               Else
                  Me._OrdenCompra = 0
               End If

            End If

            If GetFormatoSeleccionado().HasValue AndAlso GetFormatoSeleccionado().Value <> Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB Then
               If Me.txtArchivoOrigen.Text.Trim() = "" Then
                  Exit Sub
               End If
               If Not My.Computer.FileSystem.FileExists(txtArchivoOrigen.Text) Then
                  MessageBox.Show("ATENCION: El archivo a Importar NO Existe", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                  Exit Sub
               End If

            End If


            If Me.chbAltaProductos.Checked Then
               If Me.cmbMoneda.SelectedIndex = -1 Then
                  MessageBox.Show("Seleccionar la Moneda ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Me.cmbMoneda.Focus()
                  Exit Sub
               End If

               If Me.cmbTipoImpuesto.SelectedIndex = -1 Then
                  MessageBox.Show("Seleccionar el IVA ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Me.cmbTipoImpuesto.Focus()
                  Exit Sub
               End If

               If Not (bscMarca.Selecciono Or bscCodigoMarca.Selecciono) Then
                  MessageBox.Show("Seleccionar el Nombre de Marca ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Me.bscMarca.Focus()
                  Exit Sub
               End If

               If Not (bscRubro.Selecciono Or bscCodigoRubro.Selecciono) Then
                  MessageBox.Show("Seleccionar el Nombre de Rubro ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Me.bscRubro.Focus()
                  Exit Sub
               End If
            End If

            tsbImportar.Enabled = True

            Mostrar()

         End Sub)

   End Sub

   Private Sub cboDescripcion_SelectedIndexChanged(sender As Object, e As EventArgs)
      Me.ColumnasGrilla()
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

   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnMostrar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Dim oProveedor As Reglas.Proveedores = New Reglas.Proveedores
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Me.bscProveedor.Datos = oProveedor.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnMostrar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugDetalle_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout

      '   e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow

      e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)

      e.Layout.Override.SpecialRowSeparatorHeight = 6

      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft

      e.Layout.ViewStyle = ViewStyle.SingleBand

      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

   End Sub


#End Region

#Region "Metodos"

   Private Sub CargarColumnasASumar()

      Me.ugDetalle.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True

      If Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Count = 0 Then

         Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed


         Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("TotalProducto")
         Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("TotalProducto", SummaryType.Sum, columnToSummarize1)
         summary1.DisplayFormat = "{0:N2}"
         summary1.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Cantidad")
         Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Cantidad", SummaryType.Sum, columnToSummarize2)
         summary2.DisplayFormat = "{0:N2}"
         summary2.Appearance.TextHAlign = HAlign.Right

         Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"

      End If

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.txtArchivoOrigen.Text = ""

      'Me.txtRangoCeldas.Text = "An : Jn"


      Me.cboAccion.SelectedIndex = 0
      Me.cboEstado.SelectedIndex = 0

      Me.bscProveedor.Text = ""
      Me.bscCodigoProveedor.Text = ""
      Me.txtOrdenCompra.Text = ""

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.prbImportando.Value = 0

      'seteo el formato con el cual trabaja el cliente
      'estandar o talkiu
      'tengo que obtener el valor de los parametros para compararlo
      cmbFormatoArchivo.SelectedValue = Reglas.Publicos.ImportarPedidosFormatoArchivo
      chbAltaProductos.Checked = Reglas.Publicos.ImportarPedidosAltaProductos

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Importa", GetType(Boolean))
         .Columns.Add("ImportaProducto", GetType(Boolean))

         '.Columns.Add("LineaExcel", System.Type.GetType("System.Int64"))
         .Columns.Add("Accion", GetType(String))

         .Columns.Add("IdTipoComprobante", GetType(String))
         .Columns.Add("NumeroPedido", GetType(Long))
         .Columns.Add("Entidades_TipoComprobante", GetType(Object))
         .Columns.Add("FechaPedido", GetType(DateTime))

         .Columns.Add("NumeroOrdenCompra", GetType(Long))

         .Columns.Add("IdCliente", GetType(Int64))
         .Columns.Add("CodigoCliente", GetType(Int64))
         .Columns.Add("NombreFantasia", GetType(String))

         .Columns.Add("TipoDocVendedor", GetType(String))
         .Columns.Add("NroDocVendedor", GetType(String))
         .Columns.Add("NombreVendedor", GetType(String))
         .Columns.Add("Entidades_Vendedor", GetType(Object))

         .Columns.Add("IdFormasPago", GetType(Integer))
         .Columns.Add("DescripcionFormasPago", GetType(String))
         .Columns.Add("Entidades_FormasPago", GetType(Object))

         .Columns.Add("IdProducto", GetType(String))
         .Columns.Add("CodigoProveedor", GetType(String))
         .Columns.Add("NombreProducto", GetType(String))
         .Columns.Add("PrecioCosto", GetType(Decimal))

         .Columns.Add("DescuentoRecargoPorc", GetType(Decimal))
         .Columns.Add("DescuentoRecargoPorc2", GetType(Decimal))

         .Columns.Add("PrecioVenta", GetType(Decimal))
         .Columns.Add("TotalProducto", GetType(Decimal))
         .Columns.Add("Cantidad", GetType(String))
         .Columns.Add("NombreListaPrecios", GetType(String))
         .Columns.Add("Entidades_ListaDePrecios", GetType(Object))
         .Columns.Add("Observaciones", GetType(String))

         .Columns.Add("NombreMarca", GetType(String))
         .Columns.Add("NombreRubro", GetType(String))
         .Columns.Add("IVA", GetType(Decimal))
         .Columns.Add("Moneda", GetType(String))

         .Columns.Add("Mensaje", GetType(String))
      End With

      Return dtTemp

   End Function

   Sub AbrirExcel(ArchivoXLS As String)

      Dim m_sConn1 As String

      If ArchivoXLS.ToUpper.EndsWith(".XLSX") Then
         m_sConn1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ArchivoXLS & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
      Else
         m_sConn1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & ArchivoXLS & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";"
      End If


      ConexionExcel = New System.Data.OleDb.OleDbConnection(m_sConn1)
      ConexionExcel.Open()

   End Sub

   Private Sub ColumnasGrilla()

      If Me._estaCargando Then Exit Sub

      Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreProducto").Width = 200

      ColumnaCodigoProveedor = 1
      ColumnaNombreProducto = 0
      ColumnaPrecioVenta = 3

   End Sub

   Private Sub Mostrar()

      Try

         Dim dt As DataTable

         Dim oPublicos As Reglas.Publicos = New Reglas.Publicos
         Dim oPedido As Reglas.Pedidos = New Reglas.Pedidos

         'Dim AnchoIdProducto As Integer
         'AnchoIdProducto = oPublicos.GetAnchoCampo("Productos", "IdProducto")

         'Dim AnchoNombreProducto As Integer
         'AnchoNombreProducto = oPublicos.GetAnchoCampo("Productos", "NombreProducto")

         'Dim AnchoNombreMarca As Integer
         'AnchoNombreMarca = oPublicos.GetAnchoCampo("Marcas", "NombreMarca")

         'Dim AnchoNombreRubro As Integer
         'AnchoNombreRubro = oPublicos.GetAnchoCampo("Rubros", "NombreRubro")

         'Dim AnchoCodigoDeBarras As Integer
         'AnchoCodigoDeBarras = oPublicos.GetAnchoCampo("Productos", "CodigoDeBarras")

         Me.tsbImportar.Enabled = False

         Me.tsbSalir.Enabled = False

         ProductosConError = 0

         'Leo el archivo y lo subo a la grilla. 

         dt = Me.CrearDT()

         'Dim dr1 As DataRow
         'aca configurar para abrir los diferente formatos que tengo seteados
         Select Case DirectCast(cmbFormatoArchivo.SelectedValue, Entidades.Pedido.FormatoImportarPedidos)
            Case Entidades.Pedido.FormatoImportarPedidos.ESTANDAR
               Me.AbrirExcel(txtArchivoOrigen.Text)
               Me.CargoFormatoEstandar(dt)
            Case Entidades.Pedido.FormatoImportarPedidos.TALKIU
               Me.AbrirExcel(txtArchivoOrigen.Text)
               Me.CargoFormatoTalkiu(dt)
            Case Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
               Me.ObtenerPedidosTalkiuWeb(dt)
            Case Else
               Throw New Exception("Formato de exportación a Excel NO Implementado.")
         End Select

         Me.ugDetalle.DataSource = dt

         Me.FormatearGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

         'Igual pudo encontrar invalidos porque no se filtran inicialmente del excel.

         If Me.cboEstado.Text = "Validos" Then
            ProductosConError = 0
         End If


      Catch ex As Exception
         Me.Cursor = Cursors.Default
         Me.tssRegistros.Text = "0 Registros"
         If ex.Message.Contains("FROM") Then
            MessageBox.Show("Rango de Celdas Invalidos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRangoCeldasFilaDesde.Focus()
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Finally
         Me.Cursor = Cursors.Default
         tsbImportar.Enabled = True
         tsbSalir.Enabled = True
         If ConexionExcel IsNot Nothing Then
            Me.ConexionExcel.Close()
            Me.ConexionExcel.Dispose()
         End If
      End Try

   End Sub

   Public Function RemoveDiacritics(stIn As String) As String

      Dim stFormD As String = stIn.Normalize(NormalizationForm.FormD)
      Dim sb As New StringBuilder()

      For ich As Integer = 0 To stFormD.Length - 1
         Dim uc = Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD(ich))
         If uc <> Globalization.UnicodeCategory.NonSpacingMark Then
            sb.Append(stFormD(ich))
         End If
      Next

      Return (sb.ToString().Normalize(NormalizationForm.FormC))

   End Function


   Private Sub CargoFormatoTalkiu(dt As DataTable)
      Dim Cliente As Integer = 4
      Dim ds As DataSet = New DataSet()
      Dim ds1 As DataSet = New DataSet()
      Dim dr As DataRow
      Dim PrimeraFila As Boolean = True
      Dim Accion As String
      Dim Importar As Boolean
      Dim Mensaje As String
      Dim drCl As DataRow
      Dim rOrdenesCompraPedido As Reglas.OrdenesCompraPedidos = New Reglas.OrdenesCompraPedidos


      Dim DA As New System.Data.OleDb.OleDbDataAdapter
      Dim DA1 As New System.Data.OleDb.OleDbDataAdapter

      DA = New System.Data.OleDb.OleDbDataAdapter("Select * From A4:CA200 ", Me.ConexionExcel)
      DA.Fill(ds)

      DA1 = New System.Data.OleDb.OleDbDataAdapter("Select * From A2:CA4", Me.ConexionExcel)
      DA1.Fill(ds1)


      Do While ds1.Tables(0).Rows(0).Item(Cliente).ToString() <> "(U.) TOTAL POR PRODUCTO"

         For Each dr In ds.Tables(0).Rows

            'If PrimeraFila Then
            '   PrimeraFila = False
            '   Continue For
            'End If

            If dr(ColumnaNombreProducto).ToString() = "(U.) TOTAL POR SOCIO" Then
               Exit For
            End If

            Accion = "A"

            System.Windows.Forms.Application.DoEvents()

            drCl = dt.NewRow()

            Importar = True

            Mensaje = ""

            Dim NombreCliente As String = Me.RemoveDiacritics(ds1.Tables(0).Rows(0).Item(Cliente).ToString().Trim.Replace(",", ""))

            drCl("NombreFantasia") = NombreCliente

            If NombreCliente = "" Then
               Continue For
            End If

            Dim CLI As DataTable = New Reglas.Clientes().GetFiltradoPorNombreFantasia(NombreCliente, True)

            If CLI.Rows.Count <> 0 Then
               drCl("IdCliente") = Long.Parse(CLI.Rows(0).Item("IdCliente").ToString())
               Accion = IIf(rOrdenesCompraPedido.ExistePedido(actual.Sucursal.IdSucursal, Long.Parse(Me.txtOrdenCompra.Text.ToString()), Long.Parse(drCl("IdCliente").ToString())), "E", "A").ToString()
               If Accion = "E" Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "El Pedido ya existe. "
               End If
            Else
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "No existe el Cliente:  " & drCl("NombreFantasia").ToString()
            End If

            drCl("Cantidad") = dr(Cliente).ToString.Trim.Replace("'", "´")
            If IsNumeric(drCl("Cantidad")) AndAlso Decimal.Parse(drCl("Cantidad").ToString()) = 0 Then
               Continue For
            End If

            drCl("CodigoProveedor") = dr(ColumnaCodigoProveedor).ToString.Trim.Replace("'", "´")

            If String.IsNullOrEmpty(drCl("CodigoProveedor").ToString()) Then
               Continue For
            End If

            Dim IdProducto As String = New Reglas.Productos().GetPorCodigoProveedor(drCl("CodigoProveedor").ToString(), Long.Parse(Me.bscCodigoProveedor.Tag.ToString()))

            If String.IsNullOrEmpty(IdProducto) Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "No existe el Codigo del Proveedor:  " & drCl("CodigoProveedor").ToString()
            Else
               drCl("IdProducto") = IdProducto.ToString()
            End If

            drCl("NombreProducto") = dr(ColumnaNombreProducto2).ToString.Trim.Replace("'", "´")

            If IsNumeric(dr(ColumnaPrecioVenta).ToString()) Then
               Dim Precio As String = dr(ColumnaPrecioVenta).ToString().Trim().Replace(",", ".").Replace("$", "")
               drCl("PrecioVenta") = Decimal.Round(Decimal.Parse(Precio.ToString()), 2)
               If Not String.IsNullOrEmpty(dr(Cliente).ToString.Trim.Replace("'", "´").ToString()) Then
                  drCl("TotalProducto") = Decimal.Parse(drCl("Cantidad").ToString()) * Decimal.Parse(drCl("PrecioVenta").ToString())
               End If

            Else
               drCl("PrecioVenta") = 0
            End If

            drCl("Importa") = Importar

            If Not Importar Then
               drCl("Mensaje") = Mensaje
               If Accion <> "E" Then
                  Accion = "X"
               End If
            Else
               drCl("Mensaje") = ""
            End If

            drCl("Accion") = Accion


            If (Me.cboEstado.Text = "Todos" Or (Me.cboEstado.Text = "Validos" And Importar) Or (Me.cboEstado.Text = "Invalidos" And Not Importar)) And
               (Me.cboAccion.Text = "Todas" Or (Me.cboAccion.Text = "Altas" And Accion = "A") Or (Me.cboAccion.Text = "Modificar" And Accion = "M")) Then
               If Not String.IsNullOrEmpty(dr(Cliente).ToString.Trim.Replace("'", "´").ToString()) Then
                  dt.Rows.Add(drCl)
               End If
            Else
               ProductosConError += 1
            End If

         Next

         Cliente += 1
      Loop
   End Sub

   Private Sub CargoFormatoTalkiuWEB(dt As DataTable, OCTalkiu As Entidades.OrdenesTalkiu)
      'Dim Cliente As Integer = 4
      Dim Accion As String
      Dim Importar As Boolean
      Dim Mensaje As String
      Dim drCl As DataRow
      Dim rOrdenesCompraPedido As Reglas.OrdenesCompraPedidos = New Reglas.OrdenesCompraPedidos

      For Each FP In OCTalkiu.payment_methods
         Dim FormaPago As DataTable = New Reglas.VentasFormasPago().GetPorDescripcion(FP.ToString(), tipo:=String.Empty, esContado:=Nothing)
         If FormaPago.Rows.Count <> 0 Then
            cmbFormaPago.SelectedValue = Integer.Parse(FormaPago.Rows(0).Item("IdFormasPago").ToString())
         End If

      Next

      'PEDIDOS DE LA PROPUESTA
      For Each Pedido In OCTalkiu.orders


         For Each pedidoline In Pedido.order_lines
            Accion = "A"

            System.Windows.Forms.Application.DoEvents()

            drCl = dt.NewRow()

            Importar = True

            Mensaje = ""

            Dim NombreCliente As String = Me.RemoveDiacritics(Pedido.retailer.name.ToString().Trim.Replace(",", ""))

            drCl("NombreFantasia") = NombreCliente

            Dim CLI As DataTable = New Reglas.Clientes().GetFiltradoPorCUIT(Pedido.retailer.cuit.Replace("-", ""), True)

            If CLI.Rows.Count <> 0 Then
               drCl("IdCliente") = Long.Parse(CLI.Rows(0).Item("IdCliente").ToString())
               Accion = IIf(rOrdenesCompraPedido.ExistePedido(actual.Sucursal.IdSucursal, Long.Parse(Me.txtOrdenCompra.Text.ToString()), Long.Parse(drCl("IdCliente").ToString())), "E", "A").ToString()
               If Accion = "E" Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "El Pedido ya existe. "
               End If
            Else
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "No existe el Cliente:  " & drCl("NombreFantasia").ToString()
            End If

            drCl("IdtipoComprobante") = Pedido.order_id.ToString()

            drCl("Cantidad") = pedidoline.quantity.ToString.Trim.Replace("'", "´")
            If IsNumeric(drCl("Cantidad")) AndAlso Decimal.Parse(drCl("Cantidad").ToString()) = 0 Then
               '  Continue For
            End If


            'Busco codigo del proveedor
            Dim IdProducto As String
            If pedidoline.gtin = Nothing Then
               If pedidoline.sku_code = Nothing Then
                  drCl("CodigoProveedor") = ""
               Else
                  drCl("CodigoProveedor") = pedidoline.sku_code.ToString.Trim.Replace("'", "´")
               End If
            Else
               If String.IsNullOrEmpty(pedidoline.gtin.ToString()) Then
                  drCl("CodigoProveedor") = ""
               Else
                  drCl("CodigoProveedor") = pedidoline.gtin.ToString.Trim.Replace("'", "´")
               End If
            End If


            IdProducto = New Reglas.Productos().GetPorCodigoProveedor(drCl("CodigoProveedor").ToString(), Long.Parse(Me.bscCodigoProveedor.Tag.ToString()))

            If String.IsNullOrEmpty(IdProducto) Then
               Dim CodBarra As DataTable = New Reglas.Productos().GetPorCodigoBarra(drCl("CodigoProveedor").ToString())
               If CodBarra.Rows.Count <> 0 Then
                  drCl("IdProducto") = CodBarra.Rows(0).Item("IdProducto").ToString()

               Else
                  Dim Producto = New Reglas.Productos().Get1(drCl("CodigoProveedor").ToString())
                  If Producto.Rows.Count <> 0 Then
                     drCl("IdProducto") = Producto.Rows(0).Item("IdProducto").ToString()
                  Else
                     Importar = False
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "No existe el Codigo de Producto:  " & drCl("CodigoProveedor").ToString()

                  End If

               End If
            Else
               drCl("IdProducto") = IdProducto.ToString()
            End If

            drCl("NombreProducto") = pedidoline.description.Trim.Replace("'", "´")

            If IsNumeric(pedidoline.total.ToString()) Then
               Dim Precio As String = pedidoline.price.ToString().Trim().Replace(",", ".").Replace("$", "")
               drCl("PrecioVenta") = Decimal.Round(Decimal.Parse(Precio.ToString()), 2)
               If Not String.IsNullOrEmpty(drCl("NombreFantasia").ToString.Trim.Replace("'", "´").ToString()) Then
                  drCl("TotalProducto") = Decimal.Parse(drCl("Cantidad").ToString()) * Decimal.Parse(drCl("PrecioVenta").ToString())
               End If

            Else
               drCl("PrecioVenta") = 0
            End If

            drCl("Importa") = Importar

            If Not Importar Then
               drCl("Mensaje") = Mensaje
               If Accion <> "E" Then
                  Accion = "X"
               End If
            Else
               drCl("Mensaje") = ""
            End If

            drCl("Accion") = Accion


            If (Me.cboEstado.Text = "Todos" Or (Me.cboEstado.Text = "Validos" And Importar) Or (Me.cboEstado.Text = "Invalidos" And Not Importar)) And
               (Me.cboAccion.Text = "Todas" Or (Me.cboAccion.Text = "Altas" And Accion = "A") Or (Me.cboAccion.Text = "Modificar" And Accion = "M")) Then
               If Not String.IsNullOrEmpty(drCl("NombreFantasia").ToString.Trim.Replace("'", "´").ToString()) Then
                  dt.Rows.Add(drCl)
               End If
            Else
               ProductosConError += 1
            End If
         Next
      Next

      '  Cliente += 1
      '  Loop
   End Sub

   Private Enum ColumnasEstandar As Integer
      NumeroPedido = 0
      FechaPedido = 1
      NumeroOrdenCompra = 2
      TipoDocVendedor = 3
      NroDocVendedor = 4
      NombreVendedor = 5
      CodigoCliente = 6
      NombreCliente = 7
      CodigoFormaPago = 8
      NombreFormaPago = 9
      CodigoProducto = 10
      NombreProducto = 11
      CantidadPedida = 12
      NombreListaPrecios = 13
      PrecioCosto = 14
      PrecioVenta = 15
      DescuentoRecargo1 = 16
      DescuentoRecargo2 = 17
      Total = 18
      Observaciones = 19

   End Enum

   Private Sub CargoFormatoEstandar(dt As DataTable)
      Dim ds As DataSet = New DataSet()
      Dim Accion As String
      Dim Importar As Boolean
      Dim ImportarProducto As Boolean
      Dim Mensaje As StringBuilder
      Dim drCl As DataRow
      Dim DA As System.Data.OleDb.OleDbDataAdapter
      Dim rango As String

      Dim _cache As Reglas.BusquedasCacheadas = New Reglas.BusquedasCacheadas()

      Dim numeroPedido As Long
      Dim fechaPedido As DateTime?
      Dim numeroOrdenCompra As Long
      Dim tipoDocVendedor As String
      Dim nroDocVendedor As String
      Dim nombreVendedor As String
      Dim vendedor As Entidades.Empleado = Nothing

      Dim idCliente As Long
      Dim codigoCliente As Long
      Dim nombreCliente As String
      Dim drCliente As DataRow

      Dim idFormaPago As Integer
      Dim nombreFormaPago As String
      Dim formaPago As Entidades.VentaFormaPago

      Dim idProducto As String
      Dim nombreProducto As String
      Dim drProducto As DataRow

      Dim cantidadPedida As Decimal
      Dim precioCosto As Decimal
      Dim precioVenta As Decimal
      Dim descuentoRecargo1 As Decimal
      Dim descuentoRecargo2 As Decimal
      Dim importeTotal As Decimal

      Dim nombreListaPrecios As String
      Dim listaPrecios As Entidades.ListaDePrecios = Nothing
      Dim dtPrecios As DataTable
      'Dim dtPrecioCosto As DataTable

      Dim observaciones As String
      Dim regProd As Reglas.Productos = New Reglas.Productos()
      Dim regProdSuc As Reglas.ProductosSucursales = New Reglas.ProductosSucursales()

      DA = New System.Data.OleDb.OleDbDataAdapter
      rango = String.Format("[{0}{1}:{2}{3}]",
                            txtRangoCeldasColumnaDesde.Text.Trim(), txtRangoCeldasFilaDesde.Text.Trim(),
                            txtRangoCeldasColumnaHasta.Text.Trim(), txtRangoCeldasFilaHasta.Text.Trim())

      DA = New System.Data.OleDb.OleDbDataAdapter(String.Format("Select * From {0} ", rango), Me.ConexionExcel)
      DA.Fill(ds)

      Dim idTipoComprobanteDefault As String = Reglas.Publicos.ImportarPedidosTipoComprobante
      Dim tipoComprobante As Entidades.TipoComprobante = New Reglas.TiposComprobantes().GetUno(idTipoComprobanteDefault)
      Dim letraComprobante As String = tipoComprobante.LetrasHabilitadas
      Dim impresora As Entidades.Impresora = New Eniac.Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, tipoComprobante.IdTipoComprobante)
      If impresora Is Nothing Then
         Throw New Exception("No Existe la PC en Configuraciones/Impresoras")
      End If
      Dim centroEmisor As Short = impresora.CentroEmisor

      Dim rPedidos As Reglas.Pedidos = New Reglas.Pedidos()

      For Each dr As DataRow In ds.Tables(0).Rows
         Accion = "A"

         formaPago = Nothing

         System.Windows.Forms.Application.DoEvents()

         Importar = True
         ImportarProducto = False

         Mensaje = New StringBuilder()

         numeroPedido = Ayudante.ImportarExcel.GetValorLong(dr, ColumnasEstandar.NumeroPedido)

         If numeroPedido > 0 Then
            If rPedidos.ExistePedido(actual.Sucursal.Id, tipoComprobante.IdTipoComprobante, letraComprobante, centroEmisor, numeroPedido) Then
               Importar = False
               Mensaje.AppendFormat("El pedido ya se encuentra en el sistema - ")
            End If
         End If

         fechaPedido = Ayudante.ImportarExcel.GetValorDateTime(dr, ColumnasEstandar.FechaPedido, "dd/MM/yyyy")
         If Not fechaPedido.HasValue Then
            Importar = False
            Mensaje.AppendFormat("Fecha inválida - ")
         End If

         numeroOrdenCompra = Ayudante.ImportarExcel.GetValorLong(dr, ColumnasEstandar.NumeroOrdenCompra)

         'If numeroPedido > 0 Then
         '   If rPedidos.ExistePedido(actual.Sucursal.Id, tipoComprobante.IdTipoComprobante, letraComprobante, centroEmisor, numeroPedido) Then
         '      Importar = False
         '      Mensaje.AppendFormat("El pedido ya se encuentra en el sistema - ")
         '   End If
         'End If

         tipoDocVendedor = Ayudante.ImportarExcel.GetValorString(dr, ColumnasEstandar.TipoDocVendedor)
         nroDocVendedor = Ayudante.ImportarExcel.GetValorString(dr, ColumnasEstandar.NroDocVendedor)
         nombreVendedor = RemoveDiacritics(Ayudante.ImportarExcel.GetValorString(dr, ColumnasEstandar.NombreVendedor))

         If String.IsNullOrWhiteSpace(tipoDocVendedor) And String.IsNullOrWhiteSpace(nroDocVendedor) And String.IsNullOrWhiteSpace(nombreVendedor) Then
            Importar = False
            Mensaje.AppendFormat("Vendedor inválido - ")
         Else
            vendedor = _cache.BuscaEmpleado(nroDocVendedor)
            If vendedor Is Nothing Then
               vendedor = _cache.BuscaEmpleado(nombreVendedor)
            End If
            If vendedor Is Nothing Then
               Importar = False
               Mensaje.AppendFormat("Vendedor no existe - ")
            Else
               tipoDocVendedor = vendedor.TipoDocEmpleado
               nroDocVendedor = vendedor.NroDocEmpleado
               nombreVendedor = vendedor.NombreEmpleado
            End If
         End If

         idCliente = 0
         codigoCliente = Ayudante.ImportarExcel.GetValorLong(dr, ColumnasEstandar.CodigoCliente)
         nombreCliente = Me.RemoveDiacritics(Ayudante.ImportarExcel.GetValorString(dr, ColumnasEstandar.NombreCliente))

         If codigoCliente = 0 And String.IsNullOrWhiteSpace(nombreCliente) Then
            Importar = False
            Mensaje.AppendFormat("Cliente inválido - ")
         Else
            drCliente = _cache.BuscaClientePorCodigo(codigoCliente)
            If drCliente Is Nothing Then
               drCliente = _cache.BuscaCliente(nombreCliente)
            End If
            If drCliente Is Nothing Then
               drCliente = _cache.BuscaClientePorFantasia(nombreCliente)
            End If
            If drCliente Is Nothing Then
               Importar = False
               Mensaje.AppendFormat("Cliente no existe - ")
            Else
               idCliente = Long.Parse(drCliente(Entidades.Cliente.Columnas.IdCliente.ToString()).ToString())
               codigoCliente = Long.Parse(drCliente(Entidades.Cliente.Columnas.CodigoCliente.ToString()).ToString())
               nombreCliente = drCliente(Entidades.Cliente.Columnas.NombreCliente.ToString()).ToString()

               If numeroPedido > 0 Then
                  If dt.Select(String.Format("IdCliente <> {0} AND NumeroPedido = {1}", idCliente, numeroPedido)).Length > 0 Then
                     Importar = False
                     Mensaje.AppendFormat("El número de pedido se encuentra repetido para dos clientes distintos - ")
                  End If
               End If
            End If
         End If

         idFormaPago = Ayudante.ImportarExcel.GetValorInteger(dr, ColumnasEstandar.CodigoFormaPago)
         nombreFormaPago = Ayudante.ImportarExcel.GetValorString(dr, ColumnasEstandar.NombreFormaPago)

         If idFormaPago = 0 And String.IsNullOrWhiteSpace(nombreFormaPago) Then
            Importar = False
            Mensaje.AppendFormat("Forma de Pago inválido - ")
         Else
            formaPago = _cache.BuscaFormasPago(idFormaPago)
            If formaPago Is Nothing Then
               formaPago = _cache.BuscaFormasPago(nombreFormaPago)
            End If
            If formaPago Is Nothing Then
               Importar = False
               Mensaje.AppendFormat("Forma de Pago no existe - ")
            Else
               idFormaPago = formaPago.IdFormasPago
               nombreFormaPago = formaPago.DescripcionFormasPago
            End If
         End If

         idProducto = Ayudante.ImportarExcel.GetValorString(dr, ColumnasEstandar.CodigoProducto).Trim()
         nombreProducto = Ayudante.ImportarExcel.GetValorString(dr, ColumnasEstandar.NombreProducto)

         Dim NombreMarca As String = String.Empty
         Dim NombreRubro As String = String.Empty
         Dim IVA As Decimal = 0
         Dim Moneda As String = String.Empty

         If String.IsNullOrWhiteSpace(idProducto) Or String.IsNullOrWhiteSpace(nombreProducto) Then
            Importar = False
            Mensaje.AppendFormat("Producto inválido - ")
         Else
            drProducto = _cache.BuscaProductoPorId(idProducto)
            If drProducto Is Nothing Then
               drProducto = _cache.BuscaProductoPorNombre(nombreProducto)
            End If
            If drProducto Is Nothing Then

               If Me.chbAltaProductos.Checked Then
                  ImportarProducto = True
                  NombreMarca = Me.bscMarca.Text.ToString()
                  NombreRubro = Me.bscRubro.Text.ToString()
                  IVA = Decimal.Parse(Me.cmbTipoImpuesto.SelectedValue.ToString())
                  Moneda = Me.cmbMoneda.Text.ToString()
               Else
                  Importar = False
               End If

               Mensaje.AppendFormat("Producto no existe - ")

            Else
               idProducto = drProducto(Entidades.Producto.Columnas.IdProducto.ToString()).ToString().Trim()
               nombreProducto = drProducto(Entidades.Producto.Columnas.NombreProducto.ToString()).ToString()
            End If
         End If


         cantidadPedida = Ayudante.ImportarExcel.GetValorDecimal(dr, ColumnasEstandar.CantidadPedida)
         If cantidadPedida = 0 Then
            Importar = False
            Mensaje.AppendFormat("La Cantidad Pedida no puede ser cero - ")
         End If

         nombreListaPrecios = Ayudante.ImportarExcel.GetValorString(dr, ColumnasEstandar.NombreListaPrecios)
         If String.IsNullOrWhiteSpace(nombreListaPrecios) Then
            Importar = False
            Mensaje.AppendFormat("Lista de Precios inválido - ")
         Else
            listaPrecios = _cache.BuscaListaDePrecios(nombreListaPrecios)
            If listaPrecios Is Nothing Then
               Importar = False
               Mensaje.AppendFormat("Lista de Precios no existe - ")
            Else
               nombreListaPrecios = listaPrecios.NombreListaPrecios
            End If
         End If

         precioVenta = Ayudante.ImportarExcel.GetValorDecimal(dr, ColumnasEstandar.PrecioVenta)

         'si viene el valor en cero pone el precio de la lista de precios por defecto
         If precioVenta = 0 Then
            If listaPrecios IsNot Nothing Then
               dtPrecios = regProd.GetPreciosSoloPorCodigoLista(Entidades.Usuario.Actual.Sucursal.Id, idProducto, listaPrecios.IdListaPrecios, activo:=Nothing)
            Else
               dtPrecios = regProd.GetPreciosSoloPorCodigoLista(Entidades.Usuario.Actual.Sucursal.Id, idProducto, Reglas.Publicos.ListaPreciosPredeterminada, activo:=Nothing)
            End If
            If dtPrecios.Rows.Count > 0 Then
               If Reglas.Publicos.PreciosConIVA Then
                  precioVenta = Decimal.Parse(dtPrecios.Rows(0)("PrecioVentaConIVA").ToString())
               Else
                  precioVenta = Decimal.Parse(dtPrecios.Rows(0)("PrecioVentaSinIVA").ToString())
               End If
            End If
         End If

         precioCosto = Ayudante.ImportarExcel.GetValorDecimal(dr, ColumnasEstandar.PrecioCosto)

         'si viene el valor en cero pone el precio de costo por defecto
         If String.IsNullOrEmpty(precioCosto.ToString()) Then
            precioCosto = 0
         End If

         ' Descuento / Recargo 1
         descuentoRecargo1 = Ayudante.ImportarExcel.GetValorDecimal(dr, ColumnasEstandar.DescuentoRecargo1)
         If String.IsNullOrEmpty(descuentoRecargo1.ToString()) Then
            descuentoRecargo1 = 0
         End If

         ' Descuento / Recargo 1
         descuentoRecargo2 = Ayudante.ImportarExcel.GetValorDecimal(dr, ColumnasEstandar.DescuentoRecargo2)
         If String.IsNullOrEmpty(descuentoRecargo2.ToString()) Then
            descuentoRecargo2 = 0
         End If

         importeTotal = Ayudante.ImportarExcel.GetValorDecimal(dr, ColumnasEstandar.Total)

         'si el importeTotal viene en cero lo calculo cantidadxPrecioVenta
         If importeTotal = 0 Then
            importeTotal = cantidadPedida * precioVenta
         End If

         observaciones = Ayudante.ImportarExcel.GetValorString(dr, ColumnasEstandar.Observaciones)

         drCl = dt.NewRow()

         drCl("IdTipoComprobante") = tipoComprobante.IdTipoComprobante
         drCl("NumeroPedido") = numeroPedido
         drCl("Entidades_TipoComprobante") = tipoComprobante

         If fechaPedido.HasValue Then
            drCl("FechaPedido") = fechaPedido
         Else
            drCl("FechaPedido") = DBNull.Value
         End If

         drCl("NumeroOrdenCompra") = numeroOrdenCompra

         drCl("TipoDocVendedor") = tipoDocVendedor
         drCl("NroDocVendedor") = nroDocVendedor
         drCl("NombreVendedor") = nombreVendedor
         drCl("Entidades_Vendedor") = vendedor

         drCl("IdCliente") = idCliente
         drCl("CodigoCliente") = codigoCliente
         drCl("NombreFantasia") = nombreCliente ' La DataColumn se llamaba así de la importación de Talkiu, para no romper lo preexistente, le dejo el nombre

         drCl("IdFormasPago") = idFormaPago
         drCl("DescripcionFormasPago") = nombreFormaPago
         drCl("Entidades_FormasPago") = formaPago

         drCl("IdProducto") = idProducto
         drCl("NombreProducto") = nombreProducto

         drCl("Cantidad") = cantidadPedida
         drCl("PrecioCosto") = precioCosto
         drCl("PrecioVenta") = precioVenta
         drCl("DescuentoRecargoPorc") = descuentoRecargo1
         drCl("DescuentoRecargoPorc2") = descuentoRecargo2
         drCl("TotalProducto") = importeTotal

         drCl("NombreListaPrecios") = nombreListaPrecios

         drCl("Entidades_ListaDePrecios") = listaPrecios

         drCl("Observaciones") = observaciones

         drCl("Importa") = Importar

         drCl("ImportaProducto") = ImportarProducto

         If ImportarProducto Then
            drCl("NombreMarca") = NombreMarca
            drCl("NombreRubro") = NombreRubro
            drCl("IVA") = IVA
            drCl("Moneda") = Moneda
         End If


         If Not Importar Then
            drCl("Mensaje") = Mensaje
            If Accion <> "E" Then
               Accion = "X"
            End If
         Else
            drCl("Mensaje") = ""
         End If

         drCl("Accion") = Accion


         If (Me.cboEstado.Text = "Todos" Or (Me.cboEstado.Text = "Validos" And Importar) Or (Me.cboEstado.Text = "Invalidos" And Not Importar)) And
            (Me.cboAccion.Text = "Todas" Or (Me.cboAccion.Text = "Altas" And Accion = "A") Or (Me.cboAccion.Text = "Modificar" And Accion = "M")) Then
            dt.Rows.Add(drCl)
         Else
            ProductosConError += 1
         End If

      Next

   End Sub

   Private Sub FormatearGrilla()
      For Each dr As UltraGridRow In Me.ugDetalle.Rows
         If dr.Cells("Accion").Value.Equals("X") Then
            dr.Cells("Importa").Appearance.BackColor = Color.Yellow
            dr.Cells("Importa").ActiveAppearance.BackColor = Color.Yellow
         ElseIf dr.Cells("Accion").Value.Equals("E") Then
            dr.Cells("Importa").Appearance.BackColor = Color.LightCoral
            dr.Cells("Importa").ActiveAppearance.BackColor = Color.LightCoral
         Else
            dr.Cells("Importa").Appearance.BackColor = Color.LimeGreen
            dr.Cells("Importa").ActiveAppearance.BackColor = Color.LimeGreen
         End If
      Next
   End Sub

   Private Sub ImportarDatos()
      Try
         Cursor = Cursors.WaitCursor

         If GetFormatoSeleccionado().HasValue Then
            Me.GrabarPedidos()
            ' MessageBox.Show("Pedidos generados exitosamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
         'Catch ex As Exception
         '   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         tslRegistroActual.Text = ""
         Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)

      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString
      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString

   End Sub

   Private Sub GrabarPedidos()
      'Try

      ' If Me.chbAltaProductos.Checked Then

      'Dim reg As Eniac.Reglas.Productos = New Eniac.Reglas.Productos()
      'Dim Productos As DataTable = Me.CrearDTProducto()
      'Dim ListasDePrecios As Integer = Publicos.ListaPreciosPredeterminada
      'Dim drCl As DataRow

      'For Each dr As UltraGridRow In ugDetalle.Rows
      '   drCl = Productos.NewRow()

      '   drCl("Importa") = dr.Cells("ImportaProducto").Value
      '   drCl("Accion") = ""
      '   drCl("CodigoProducto") = dr.Cells("IdProducto").Value
      '   drCl("NombreProducto") = dr.Cells("NombreProducto").Value
      '   drCl("NombreProducto2") = ""
      '   drCl("NombreMarca") = Me.bscMarca.Text.ToString()
      '   drCl("NombreRubro") = Me.bscRubro.Text.ToString()
      '   drCl("IVA") = Decimal.Parse(Me.cmbTipoImpuesto.SelectedValue.ToString())
      '   drCl("PrecioCosto") = Decimal.Parse(dr.Cells("PrecioCosto").Value.ToString())
      '   drCl("PrecioVenta") = Decimal.Parse(dr.Cells("PrecioVenta").Value.ToString())
      '   drCl("Moneda") = Me.cmbMoneda.Text.ToString()
      '   drCl("CodigoDeBarras") = ""
      '   drCl("Mensaje") = ""
      '   drCl("NombreProveedorHabitual") = ""
      '   drCl("CodigoProductoProveedorHabitual") = ""

      '   Productos.Rows.Add(drCl)
      'Next

      'reg.ImportarProductos(actual.Sucursal.Id, Productos, actual.Nombre, ListasDePrecios, Me.prbImportando)

      ''  MessageBox.Show("Se importaron Productos EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      'Me.prbImportando.Value = 0

      'Me.Mostrar()

      '   End If

      Dim rPedidos As Reglas.Pedidos = New Reglas.Pedidos()
      Dim Pedidos As DataTable = DirectCast(Me.ugDetalle.DataSource, DataTable)

      Dim fechaEntrega As DateTime? = Nothing
      If chbFechaEntrega.Checked Then fechaEntrega = dtpFechaEntrega.Value

      Dim ordenCompra As Long = 0
      If IsNumeric(Me.txtOrdenCompra.Text) Then ordenCompra = Long.Parse(Me.txtOrdenCompra.Text)
      Dim idProveedor As Long = 0
      If IsNumeric(bscCodigoProveedor.Tag) Then idProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())



      rPedidos.GrabarPedidosAImportar(Pedidos, GetFormatoSeleccionado().Value,
                                      ordenCompra, Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString()),
                                      idProveedor,
                                      Me.prbImportando, tslTiempoActual, tslRegistroActual, Me.chbRespetaPrecios.Checked,
                                      fechaEntrega, Me.chbAltaProductos.Checked, chbDescuentoRecargo.Checked, chbAnticipado.Checked, IdFuncion)

      'Catch ex As Exception
      '   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      'End Try

   End Sub

#End Region

   Private Function GetFormatoSeleccionado() As Entidades.Pedido.FormatoImportarPedidos?
      If cmbFormatoArchivo.SelectedIndex > -1 AndAlso TypeOf (cmbFormatoArchivo.SelectedValue) Is Entidades.Pedido.FormatoImportarPedidos Then
         Return DirectCast(cmbFormatoArchivo.SelectedValue, Entidades.Pedido.FormatoImportarPedidos)
      End If
      Return Nothing
   End Function

   Private Sub cmbFormatoArchivo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFormatoArchivo.SelectedIndexChanged
      Try
         If GetFormatoSeleccionado().HasValue Then
            MuestraControlesSegunFormato(GetFormatoSeleccionado().Value)
            Me.tsbFormatoExcel.Text = "Formato " + cmbFormatoArchivo.Text

            Select Case cmbFormatoArchivo.SelectedValue.ToString()
               Case Entidades.Pedido.FormatoImportarPedidos.ESTANDAR.ToString()
                  btnExaminar.Enabled = True
               Case Entidades.Pedido.FormatoImportarPedidos.TALKIU.ToString()
                  btnExaminar.Enabled = True
               Case Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB.ToString()
                  btnExaminar.Enabled = False
            End Select
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub MuestraControlesSegunFormato(formatoArchivo As Entidades.Pedido.FormatoImportarPedidos)
      With ugDetalle.DisplayLayout.Bands(0)
         .Columns("IdTipoComprobante").Hidden = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
         .Columns("NumeroPedido").Hidden = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
         .Columns("FechaPedido").Hidden = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
         .Columns("NumeroOrdenCompra").Hidden = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
         .Columns("CodigoCliente").Hidden = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
         .Columns("TipoDocVendedor").Hidden = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
         .Columns("NroDocVendedor").Hidden = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
         .Columns("NombreVendedor").Hidden = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
         .Columns("IdFormasPago").Hidden = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
         .Columns("DescripcionFormasPago").Hidden = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
         .Columns("IdProducto").Hidden = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
         .Columns("NombreListaPrecios").Hidden = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
         .Columns("Observaciones").Hidden = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
         .Columns("CodigoProveedor").Hidden = formatoArchivo <> Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
      End With

      lblProveedor.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
      lblCodigoProveedor.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
      lblNombre.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
      bscCodigoProveedor.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
      bscProveedor.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB

      lblOrdenCompra.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
      txtOrdenCompra.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB

      lblFormaPago.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
      cmbFormaPago.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB

      chbRespetaPrecios.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB

      chbDescuentoRecargo.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB
      chbAnticipado.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIUWEB

      chbFechaEntrega.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.ESTANDAR
      dtpFechaEntrega.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.ESTANDAR

      lblRangoCeldas.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.ESTANDAR
      txtRangoCeldasColumnaDesde.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.ESTANDAR
      txtRangoCeldasColumnaHasta.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.ESTANDAR
      txtRangoCeldasFilaDesde.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.ESTANDAR
      txtRangoCeldasFilaHasta.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.ESTANDAR
      lblEjemplos.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.ESTANDAR

      lblArchivo.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.ESTANDAR
      txtArchivoOrigen.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.ESTANDAR
      btnExaminar.Visible = formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.TALKIU Or formatoArchivo = Entidades.Pedido.FormatoImportarPedidos.ESTANDAR

   End Sub

   Private Sub chbFechaEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEntrega.CheckedChanged
      Try
         Me.dtpFechaEntrega.Enabled = Me.chbFechaEntrega.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbAltaProductos_CheckedChanged(sender As Object, e As EventArgs) Handles chbAltaProductos.CheckedChanged
      Try
         Me.grpAltaProductos.Enabled = Me.chbAltaProductos.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoMarca_BuscadorClick() Handles bscCodigoMarca.BuscadorClick
      Try
         Dim oMarcas As Reglas.Marcas = New Reglas.Marcas
         Me._publicos.PreparaGrillaMarcas(Me.bscCodigoMarca)
         Me.bscCodigoMarca.Datos = oMarcas.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoMarca.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoMarca_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoMarca.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarMarca(e.FilaDevuelta)
            Me.bscCodigoRubro.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscMarca_BuscadorClick() Handles bscMarca.BuscadorClick
      Try
         Dim oMarcas As Reglas.Marcas = New Reglas.Marcas
         Me._publicos.PreparaGrillaMarcas(Me.bscMarca)
         Me.bscMarca.Datos = oMarcas.GetPorNombre(Me.bscMarca.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscMarca_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscMarca.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarMarca(e.FilaDevuelta)
            Me.bscCodigoRubro.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoRubro_BuscadorClick() Handles bscCodigoRubro.BuscadorClick
      Try
         Dim oRubros As Reglas.Rubros = New Reglas.Rubros
         Me._publicos.PreparaGrillaRubros(Me.bscCodigoRubro)
         Me.bscCodigoRubro.Datos = oRubros.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoRubro.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoRubro_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoRubro.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarRubro(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscRubro_BuscadorClick() Handles bscRubro.BuscadorClick
      Try
         Dim oRubros As Reglas.Rubros = New Reglas.Rubros
         Me._publicos.PreparaGrillaRubros(Me.bscRubro)
         Me.bscRubro.Datos = oRubros.GetPorNombre(Me.bscRubro.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscRubro_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscRubro.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarRubro(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


   Private Sub CargarMarca(dr As DataGridViewRow)
      Me.bscCodigoMarca.Text = dr.Cells("IdMarca").Value.ToString()
      Me.bscMarca.Text = dr.Cells("NombreMarca").Value.ToString()
   End Sub

   Private Sub CargarRubro(dr As DataGridViewRow)
      Me.bscCodigoRubro.Text = dr.Cells("IdRubro").Value.ToString()
      Me.bscRubro.Text = dr.Cells("NombreRubro").Value.ToString()
   End Sub

   Private Sub btnInsertarProductos_Click(sender As Object, e As EventArgs)

   End Sub

   Private Sub ObtenerPedidosTalkiuWeb(dt As DataTable)
      If Not String.IsNullOrEmpty(Reglas.Publicos.PedidosTalkiuToken) Then
         Try

            Dim TALKIU = New Reglas.ServiciosRest.TiendasWeb.SincronizacionTALKIU(Long.Parse(Me.txtOrdenCompra.Text.ToString()))
            '-- Ejecuta proceso de Bajada de Pedidos.- --
            TALKIU.BajarInformacion(True)

            If TALKIU._OC Is Nothing Then
               MessageBox.Show("No existe la Orden de Compra", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
               Me.CargoFormatoTalkiuWEB(dt, TALKIU._OC)
            End If

         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try


      End If
   End Sub


   'Private Function CrearDTProducto() As DataTable

   '   Dim dtTemp As DataTable = New DataTable()

   '   With dtTemp
   '      .Columns.Add("Importa", System.Type.GetType("System.Boolean"))
   '      .Columns.Add("Accion", System.Type.GetType("System.String"))
   '      .Columns.Add("CodigoProducto", System.Type.GetType("System.String"))
   '      .Columns.Add("NombreProducto", System.Type.GetType("System.String"))
   '      .Columns.Add("NombreProducto2", System.Type.GetType("System.String"))
   '      .Columns.Add("NombreMarca", System.Type.GetType("System.String"))
   '      .Columns.Add("NombreRubro", System.Type.GetType("System.String"))
   '      .Columns.Add("IVA", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("PrecioCosto", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("PrecioVenta", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("Moneda", System.Type.GetType("System.String"))
   '      .Columns.Add("CodigoDeBarras", System.Type.GetType("System.String"))
   '      .Columns.Add("Mensaje", System.Type.GetType("System.String"))
   '      .Columns.Add("NombreProveedorHabitual", System.Type.GetType("System.String"))
   '      .Columns.Add("CodigoProductoProveedorHabitual", System.Type.GetType("System.String"))
   '   End With

   '   Return dtTemp

   'End Function
End Class