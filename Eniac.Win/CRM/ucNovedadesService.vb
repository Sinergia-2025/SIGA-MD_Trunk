Public Class ucNovedadesService

#Region "Campos & Properties"
   Public Property ModificaDescrip As Boolean

   Private _IdSucursal As Integer
   Private Property _NroDeSerie As String
   Public Property IdCliente As Long

   Public Property idMarcaProducto As Integer? = Nothing
   Public Property NombreMarcaProducto As String

   Public Property idModeloProducto As Integer? = Nothing
   Public Property NombreModeloProducto As String

   Protected _entidad As Entidades.Entidad

#End Region

#Region "Setters & Getters"
   Public Sub LimpiarComprobante()
      Me._IdSucursal = 0
      cmbTiposComprobantes.SelectedIndex = -1
      txtLetraComprobante.Text = String.Empty
      txtEmisor.Text = ""
      bscComprobante.Text = ""
      '-- PE-31244.- --
      txtFechaVenta.Text = String.Empty
   End Sub
   'Public Sub SetMarcaModelo(idMarca As Integer?, idModelo As Integer?)
   '   '-- Carga Marca y Modelo.- --
   '   If Not idMarca = 0 Then
   '      idMarcaProducto = idMarca
   '      If idModelo <> 0 Then
   '         idModeloProducto = idModelo
   '      End If
   '      Dim rMarca = New Reglas.Marcas().GetUna(idMarca.IfNull)
   '      bscMarca.Text = rMarca.NombreMarca
   '      NombreMarcaProducto = rMarca.NombreMarca
   '      bscMarca.PresionarBoton()

   '      Dim rModelo = New Reglas.Modelos().GetUno(idModelo.IfNull, Reglas.Base.AccionesSiNoExisteRegistro.Excepcion)
   '      bscModelo.Text = rModelo.NombreModelo
   '      NombreModeloProducto = rModelo.NombreModelo
   '      bscModelo.PresionarBoton()
   '   Else
   '      idMarcaProducto = Nothing
   '      idModeloProducto = Nothing
   '   End If
   '   OnSelectedChanged(Nothing)
   'End Sub

   Public Sub SetComprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long)
      Me._IdSucursal = idSucursal
      If Not String.IsNullOrEmpty(idTipoComprobante) Then
         cmbTiposComprobantes.SelectedValue = idTipoComprobante
         txtLetraComprobante.Text = letra
         txtEmisor.Text = centroEmisor.ToString()
         bscComprobante.Text = numeroComprobante.ToString()
      End If
      If numeroComprobante <> 0 Then
         bscComprobante.PresionarBoton()
      End If
      OnSelectedChanged(Nothing)
   End Sub
   Public ReadOnly Property IdSucursal() As Integer
      Get
         Return _IdSucursal
      End Get
   End Property
   Public ReadOnly Property IdTipoComprobante() As String
      Get
         Return If(cmbTiposComprobantes.SelectedValue Is Nothing, Nothing, cmbTiposComprobantes.SelectedValue.ToString())
      End Get
   End Property
   Public ReadOnly Property Letra() As String
      Get
         Return txtLetraComprobante.Text
      End Get
   End Property
   Public ReadOnly Property CentroEmisor() As Short
      Get
         Return txtEmisor.ValorNumericoPorDefecto(0S)
      End Get
   End Property
   Public ReadOnly Property NumeroComprobante() As Long
      Get
         Return bscComprobante.Text.ValorNumericoPorDefecto(0L)
      End Get
   End Property
   Public Property IdProducto() As String
      Get
         If Me.bscCodigoProducto2.Selecciono Or Me.bscProducto2.Selecciono Then
            Return Me.bscCodigoProducto2.Text.Trim()
         Else
            Return String.Empty
         End If
      End Get
      Set(ByVal value As String)
         Try
            If value <> String.Empty Then
               Me.bscCodigoProducto2.Text = value
               Me.bscCodigoProducto2.PresionarBoton()
            Else
               Me.bscCodigoProducto2.Text = String.Empty
               Me.bscProducto2.Text = String.Empty
            End If
            OnSelectedChanged(Nothing)
         Catch ex As Exception
            Me.bscCodigoProducto2.Text = String.Empty
            Me.bscProducto2.Text = String.Empty
            OnSelectedChanged(Nothing)
            MessageBox.Show(String.Format("No se pudo recuperar el Producto: {0}", ex.Message), FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try
      End Set
   End Property

   Public Property NombreProducto() As String
      Get
         Return Me.txtNombreProducto.Text
      End Get
      Set(value As String)
         Me.txtNombreProducto.Text = value
      End Set
   End Property

   Public Property NroDeSerie() As String
      Get
         Return Me.txtNroSerie.Text
      End Get
      Set(ByVal value As String)
         Try
            If value <> String.Empty Then
               Me.txtNroSerie.Text = value
            Else
               Me.txtNroSerie.Text = String.Empty
            End If
            OnSelectedChanged(Nothing)
         Catch ex As Exception
            Me.txtNroSerie.Text = String.Empty
            OnSelectedChanged(Nothing)
            MessageBox.Show(String.Format("No se pudo recuperar el Producto: {0}", ex.Message), FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try
      End Set
   End Property


   Public Property ServiceLugarCompra() As String
      Get
         Return txtServiceLugarCompra.text
      End Get
      Set(value As String)
         Try
            txtServiceLugarCompra.Text = value
            OnSelectedChanged(Nothing)
         Catch ex As Exception
            txtServiceLugarCompra.Text = String.Empty
            OnSelectedChanged(Nothing)
            FindForm().ShowMessage(String.Format("No se pudo recuperar el Lugar de Compra: {0}", ex.Message))
         End Try
      End Set
   End Property

   Public Property ServiceLugarCompraFecha() As Date?
      Get
         If dtpServiceLugarCompraFecha.Checked Then
            Return dtpServiceLugarCompraFecha.Value
         Else
            Return Nothing
         End If
      End Get
      Set(value As Date?)
         Try
            dtpServiceLugarCompraFecha.Value = value.IfNull(Today)
            dtpServiceLugarCompraFecha.Checked = value.HasValue
            OnSelectedChanged(Nothing)
         Catch ex As Exception
            dtpServiceLugarCompraFecha.Checked = False
            OnSelectedChanged(Nothing)
            FindForm().ShowMessage(String.Format("No se pudo recuperar el Fecha del Lugar de Compra: {0}", ex.Message))
         End Try
      End Set
   End Property

   Public Property ServiceLugarCompraTipoComprobante() As String
      Get
         Return txtServiceLugarCompraTipoComprobante.Text
      End Get
      Set(value As String)
         Try
            txtServiceLugarCompraTipoComprobante.Text = value
            OnSelectedChanged(Nothing)
         Catch ex As Exception
            txtServiceLugarCompraTipoComprobante.Text = String.Empty
            OnSelectedChanged(Nothing)
            FindForm().ShowMessage(String.Format("No se pudo recuperar el Tipo de Comprobante del Lugar de Compra: {0}", ex.Message))
         End Try
      End Set
   End Property

   Public Property ServiceLugarCompraNumeroComprobante() As String
      Get
         Return txtServiceLugarCompraNumeroComprobante.Text
      End Get
      Set(value As String)
         Try
            txtServiceLugarCompraNumeroComprobante.Text = value
            OnSelectedChanged(Nothing)
         Catch ex As Exception
            txtServiceLugarCompraNumeroComprobante.Text = String.Empty
            OnSelectedChanged(Nothing)
            FindForm().ShowMessage(String.Format("No se pudo recuperar el Número de Comprobante del Lugar de Compra: {0}", ex.Message))
         End Try
      End Set
   End Property

   Public Property MostrarServiceLugarCompra() As Boolean
      Get
         Return pnlServiceLugarCompra.Visible
      End Get
      Set(value As Boolean)
         pnlServiceLugarCompra.Visible = value
         pnlVentaPropia.Visible = Not value
      End Set
   End Property

#End Region


#Region "Eventos"



   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._publicos = New Publicos()

         '# Carga combos
         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "VENTAS")
         Me.cmbTiposComprobantes.SelectedIndex = -1

         If Not String.IsNullOrEmpty(IdTipoComprobante) Then

            If Not String.IsNullOrEmpty(Me.IdTipoComprobante) AndAlso
               Not String.IsNullOrEmpty(Me.Letra) AndAlso
               Me.CentroEmisor > 0 AndAlso
               Me.NumeroComprobante > 0 Then

               Me.txtLetraComprobante.Text = Me.Letra
               Me.cmbTiposComprobantes.SelectedValue = Me.IdTipoComprobante
               Me.txtEmisor.Text = Me.CentroEmisor.ToString()
               Me.bscComprobante.Text = Me.NumeroComprobante.ToString()
               Me.bscComprobante.PresionarBoton()
            End If
         End If

         If Not String.IsNullOrEmpty(IdProducto) Then
            Me.bscCodigoProducto2.Text = IdProducto
            If Not String.IsNullOrEmpty(NombreProducto) Then
               Me.bscCodigoProducto2.PresionarBoton()
            End If
         End If

         '# Modelo solo visible en caso que el producto utilice Modelo
         Me.pnlModelo.Visible = Publicos.ProductoTieneModelo

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscComprobante_BuscadorClick() Handles bscComprobante.BuscadorClick
      Try
         Dim rVentas As Reglas.Ventas = New Reglas.Ventas
         Me.PreparaGrillaComprobantes(Me.bscComprobante)
         Me.bscComprobante.Datos = rVentas.GetConsultarVentas(IdSucursal, Nothing, Nothing, 0, "TODOS", IdCliente,
                                                                     "TODOS", IdTipoComprobante, NumeroComprobante, 0, "", "TODAS", "TODOS", 0, 0, "",
                                                                     Letra, CentroEmisor, "")
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscComprobante_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscComprobante.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarComprobante(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnHistoricoVentas_Click(sender As Object, e As EventArgs) Handles btnHistoricoVentas.Click
      Try
         Cursor = Cursors.WaitCursor
         AbrirHistoricoVentas()
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Cursor = Cursors.Default
      End Try

   End Sub
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim rProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Dim oVentasProductos As Reglas.VentasProductos = New Reglas.VentasProductos()

         Me.PreparaGrillaProductos(Me.bscCodigoProducto2)
         If bscComprobante.Selecciono Then

            '# Al buscar por código de producto, dejo en blanco el nombre. Se declara la variable para que se visualice mejor en los parámetros
            Dim nombreProducto As String = Nothing

            Me.bscCodigoProducto2.Datos = rProductos.GetProductosService(Me.bscCodigoProducto2.Text, nombreProducto, IdSucursal, Me.cmbTiposComprobantes.SelectedValue.ToString(),
                                                                                            Me.txtLetraComprobante.Text, Short.Parse(Me.txtEmisor.Text.ToString()),
                                                                                            Long.Parse(Me.bscComprobante.Text.ToString()), Me.StateForm = Win.StateForm.Actualizar)
         Else
            Me.bscCodigoProducto2.Datos = rProductos.GetProductosServiceXCodigo(Me.bscCodigoProducto2.Text.Trim(), Me.StateForm = Win.StateForm.Actualizar)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim rProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Dim oVentasProductos As Eniac.Reglas.VentasProductos = New Eniac.Reglas.VentasProductos

         Me.PreparaGrillaProductos(Me.bscProducto2)
         If Me.bscComprobante.Selecciono Then
            '# Al buscar por código de producto, dejo en blanco el nombre. Se declara la variable para que se visualice mejor en los parámetros
            Dim codigoProducto As String = Nothing

            Me.bscProducto2.Datos = rProductos.GetProductosService(codigoProducto, Me.bscProducto2.Text, IdSucursal, Me.cmbTiposComprobantes.SelectedValue.ToString(),
                                                                                             Me.txtLetraComprobante.Text, Short.Parse(Me.txtEmisor.Text.ToString()),
                                                                                             Long.Parse(Me.bscComprobante.Text.ToString()), Me.StateForm = Win.StateForm.Actualizar)
         Else
            Me.bscProducto2.Datos = rProductos.GetProductosServiceXNombre(Me.bscProducto2.Text.Trim(), Me.StateForm = Win.StateForm.Actualizar)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnLimpiarComprobante_Click(sender As Object, e As EventArgs) Handles btnLimpiarComprobante.Click
      Me.LimpiarCamposComprobante()
      Me.bscCodigoProducto2.Text = ""
      Me.bscProducto2.Text = ""
      Me.txtNombreProducto.Clear() '# Campo del producto eventual (se encuentra detrás del control bscProducto2)
      Me.txtNroSerie.Clear()
      Me.txtMarca.Clear()
      Me.txtModelo.Clear()
      Me.bscComprobante.Focus()
   End Sub

#End Region

#Region "Métodos"

   Private Sub LimpiaMarcaModelo()
      '-- Limpia los ID.- --
      idMarcaProducto = Nothing
      idModeloProducto = Nothing
      bscMarca.Text = ""
      bscModelo.Text = ""
   End Sub
   Private Sub LimpiarCamposComprobante()
      If Me.cmbTiposComprobantes.Items.Count > 0 Then
         Me.cmbTiposComprobantes.SelectedIndex = -1
      End If
      Me.txtLetraComprobante.Text = ""
      Me.txtEmisor.Text = ""
      Me.bscComprobante.Text = ""
      Me.bscComprobante.FilaDevuelta = Nothing
      'PE-31244
      'Me.dtpFecha.Value = Date.Now()
      Me.txtFechaVenta.Text = String.Empty

      Me._IdSucursal = 0
      'Me.IdTipoComprobante = Nothing
      'Me.Letra = Nothing
      'Me.CentroEmisor = 0
      'Me.NumeroComprobante = 0
   End Sub

   Private Sub AbrirHistoricoVentas()
      Using frm As New InfVentasDetallePorProductos()
         Dim codigoCliente As Long? = Nothing
         Dim idProducto As String = String.Empty
         codigoCliente = New Reglas.Clientes().GetUno(IdCliente).CodigoCliente
         If bscCodigoProducto2.Selecciono Or bscProducto2.Selecciono Then
            idProducto = bscCodigoProducto2.Text
         End If
         If frm.ShowDialogParaBusqueda(IdCliente, codigoCliente, idProducto) = Windows.Forms.DialogResult.OK Then

            Me.cmbTiposComprobantes.SelectedValue = frm.IdTipoComprobante
            Me.txtEmisor.Text = frm.CentroEmisor.ToString()
            Me.txtLetraComprobante.Text = frm.Letra.ToString()
            Me.bscComprobante.Text = frm.NumeroComprobante.ToString()
            Me.bscComprobante.PresionarBoton()
            Me.bscCodigoProducto2.Text = frm.Producto
            Me.bscCodigoProducto2.PresionarBoton()
         End If
      End Using
   End Sub

   Public Sub CargaMarcaModelo()
      If txtMarca.Visible Then
         NombreMarcaProducto = txtMarca.Text()
      Else
         NombreMarcaProducto = bscMarca.Text()
      End If
      If txtModelo.Visible Then
         NombreModeloProducto = txtModelo.Text()
      Else
         NombreModeloProducto = bscModelo.Text()
      End If
   End Sub
   Private Sub CargarProducto(ByVal dr As DataGridViewRow)

      bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

      If Not String.IsNullOrEmpty(NombreProducto) Then
         bscProducto2.Text = NombreProducto
         txtNombreProducto.Text = NombreProducto
      Else
         bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      End If

      If String.IsNullOrEmpty(NombreMarcaProducto) Then
         txtMarca.Text = dr.Cells("NombreMarca").Value.ToString()
         NombreMarcaProducto = dr.Cells("NombreMarca").Value.ToString()
         bscMarca.Text = dr.Cells("NombreMarca").Value.ToString()
      Else
         txtMarca.Text = NombreMarcaProducto
         bscMarca.Text = NombreMarcaProducto
      End If
      If Not IsDBNull(dr.Cells("IdMarca").Value) Then
         idMarcaProducto = Integer.Parse(dr.Cells("IdMarca").Value.ToString())
      End If

      If String.IsNullOrEmpty(NombreModeloProducto) Then
         txtModelo.Text = dr.Cells("NombreModelo").Value.ToString()
         NombreModeloProducto = dr.Cells("NombreModelo").Value.ToString()
         bscModelo.Text = dr.Cells("NombreModelo").Value.ToString()
      Else
         txtModelo.Text = NombreModeloProducto
         bscModelo.Text = NombreModeloProducto
      End If


      If Not IsDBNull(dr.Cells("IdModelo").Value) Then
         idModeloProducto = Integer.Parse(dr.Cells("IdModelo").Value.ToString())
      End If

      Me.txtNombreProducto.Text = Me.bscProducto2.Text '# Siempre carga el nombre del producto, pero muestro el control solo si el producto permite modificar descripción 
      If Not CBool(dr.Cells(Entidades.Producto.Columnas.PermiteModificarDescripcion.ToString()).Value) Then
         ModificaDescrip = False
      Else
         ModificaDescrip = True
      End If
      txtNombreProducto.Visible = ModificaDescrip
      txtMarca.Visible = ModificaDescrip
      txtModelo.Visible = ModificaDescrip
      bscProducto2.Visible = Not ModificaDescrip
      bscMarca.Visible = Not ModificaDescrip
      bscModelo.Visible = Not ModificaDescrip

      OnSelectedChanged(Nothing)
   End Sub

   Private Sub CargarComprobante(ByVal dr As DataGridViewRow)

      Me._IdSucursal = CInt(dr.Cells("IdSucursal").Value)

      Me.cmbTiposComprobantes.SelectedValue = dr.Cells("IdTipoComprobante").Value.ToString()
      Me.txtLetraComprobante.Text = dr.Cells("Letra").Value.ToString()
      Me.txtEmisor.Text = dr.Cells("CentroEmisor").Value.ToString()
      Me.bscComprobante.Text = dr.Cells("NumeroComprobante").Value.ToString()

      'PE-31244 -- Solo se muestra cuando se utiliza el buscador de comprobante
      'Me.dtpFecha.Value = Date.Parse(dr.Cells("Fecha").Value.ToString())
      Me.txtFechaVenta.Text = DirectCast(dr.Cells("Fecha").Value, Date).ToString("dd/MM/yyyy")
   End Sub

   Private Sub PreparaGrillaComprobantes(buscador As Eniac.Controles.Buscador2)
      With buscador
         .ConfigBuscador = New Controles.ConfigBuscador() _
                          With {.Titulo = "Comprobantes",
                                .AnchoAyuda = 712}

         Dim col As Eniac.Controles.ColumnaBuscador
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 1
         col.Nombre = "IdTipoComprobante"
         col.Titulo = "Tipo"
         col.Ancho = 120
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 2
         col.Nombre = "Letra"
         col.Titulo = "L."
         col.Alineacion = DataGridViewContentAlignment.MiddleCenter
         col.Ancho = 25
         .ColumnasVisibles.Add(col)
         '-- 
         col = New Controles.ColumnaBuscador
         col.Orden = 3
         col.Nombre = "CentroEmisor"
         col.Titulo = "Emisor"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Ancho = 40
         .ColumnasVisibles.Add(col)

         col = New Controles.ColumnaBuscador
         col.Orden = 4
         col.Nombre = "NumeroComprobante"
         col.Titulo = "Número"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Ancho = 80
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 5
         col.Nombre = "Fecha"
         col.Titulo = "Fecha"
         col.Alineacion = DataGridViewContentAlignment.MiddleCenter
         col.Ancho = 80
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 6
         col.Nombre = "ImporteTotal"
         col.Titulo = "Importe Total"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Ancho = 80
         .ColumnasVisibles.Add(col)
      End With
   End Sub

   Private Sub PreparaGrillaProductos(buscador As Eniac.Controles.Buscador2)
      With buscador
         .ConfigBuscador = New Controles.ConfigBuscador() _
                          With {.Titulo = "Productos",
                                .AnchoAyuda = 712}

         Dim col As Eniac.Controles.ColumnaBuscador
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 1
         col.Nombre = "IdProducto"
         col.Titulo = "Código"
         col.Ancho = 80
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 2
         col.Nombre = "NombreProducto"
         col.Titulo = "Producto"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 300
         .ColumnasVisibles.Add(col)
         '-- 
         col = New Controles.ColumnaBuscador
         col.Orden = 3
         col.Nombre = "NombreMarca"
         col.Titulo = "Marca"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 100
         .ColumnasVisibles.Add(col)

         If Publicos.ProductoTieneModelo Then
            col = New Controles.ColumnaBuscador
            col.Orden = 4
            col.Nombre = "NombreModelo"
            col.Titulo = "Modelo"
            col.Alineacion = DataGridViewContentAlignment.MiddleLeft
            col.Ancho = 100
            .ColumnasVisibles.Add(col)
         End If
      End With
   End Sub

   Private Sub lnkMarca_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkMarca.LinkClicked
      Try
         Dim PantMarca As MarcasDetalle = New MarcasDetalle(New Entidades.Marca())
         PantMarca.StateForm = Win.StateForm.Insertar
         PantMarca.CierraAutomaticamente = True
         If PantMarca.ShowDialog() = Windows.Forms.DialogResult.OK Then
            idMarcaProducto = CInt(PantMarca.IdMarca.ToString())
            bscMarca.Text = PantMarca.txtNombreMarca.Text()
            Dim oMarcas As Reglas.Marcas = New Reglas.Marcas
            Me._publicos.PreparaGrillaMarcas(Me.bscMarca)
            Me.bscMarca.Datos = oMarcas.GetPorNombre(bscMarca.Text.Trim())

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lnkModelo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkModelo.LinkClicked
      Try
         Dim PantModelo As ModelosDetalle = New ModelosDetalle(New Entidades.Modelo())
         PantModelo.StateForm = Win.StateForm.Insertar
         PantModelo.CierraAutomaticamente = True
         If PantModelo.ShowDialog() = Windows.Forms.DialogResult.OK Then
            idModeloProducto = CInt(PantModelo.txtIdModelo.Text())
            bscModelo.Text = PantModelo.txtNombre.Text()
            Dim oModelos As Reglas.Modelos = New Reglas.Modelos
            _publicos.PreparaGrillaModelos(bscModelo)
            bscModelo.Datos = oModelos.GetPorNombre(Integer.Parse("0" & idMarcaProducto), bscModelo.Text.Trim())
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscModelo_BuscadorClick() Handles bscModelo.BuscadorClick
      Try
         Dim oModelos As Reglas.Modelos = New Reglas.Modelos
         _publicos.PreparaGrillaModelos(bscModelo)
         bscModelo.Datos = oModelos.GetPorNombre(Integer.Parse("0" & idMarcaProducto), bscModelo.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscModelo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscModelo.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarModelo(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CargarModelo(ByVal dr As DataGridViewRow)
      idModeloProducto = Int32.Parse(dr.Cells("IdModelo").Value.ToString())
      bscModelo.Text = dr.Cells("NombreModelo").Value.ToString()
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
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub CargarMarca(ByVal dr As DataGridViewRow)
      idMarcaProducto = Int32.Parse(dr.Cells("IdMarca").Value.ToString())
      bscMarca.Text = dr.Cells("NombreMarca").Value.ToString()
      '-- Inicializa Variables de Modelo.- --
      idModeloProducto = Nothing
      bscModelo.Text = String.Empty
   End Sub

   Private Sub txtModelo_Leave(sender As Object, e As EventArgs) Handles txtModelo.Leave, txtMarca.Leave
      NombreMarcaProducto = txtMarca.Text
      NombreModeloProducto = txtModelo.Text
   End Sub


#End Region

End Class
