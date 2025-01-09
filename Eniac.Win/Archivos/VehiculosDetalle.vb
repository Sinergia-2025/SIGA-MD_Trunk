Public Class VehiculosDetalle

#Region "Campos"
   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
#End Region

#Region "Propiedades"
   Public ReadOnly Property Vehiculo As Entidades.Vehiculo
      Get
         Return DirectCast(_entidad, Entidades.Vehiculo)
      End Get
   End Property
   Public Property IdPatente As String
   Public Property CodigoCliente As Long = 0

   Public Property GuardaNuevoEnBase As Boolean = True

#End Region

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.Vehiculo)
      Me.New()
      _entidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            _publicos.CargaComboMarcaVehiculo(cmbMarca)
            _publicos.CargaComboTipoDocumento(cmbTipoDoc)
            _publicos.CargaComboConcesionarioTipoUnidad(cmbTipoUnidad, Entidades.Publicos.SiNoTodos.NO)
            _publicos.CargaComboEstadosVehiculo(cmbEstadoVehiculo)
            _publicos.CargaComboDesdeEnum(cmbLlantasVehiculo, GetType(Entidades.ConcesionarioLlantasVehiculo))
            _publicos.CargaComboDesdeEnum(cmbAuxilioVehiculo, GetType(Entidades.Publicos.SiNo))
            _publicos.CargaComboDesdeEnum(cmbIdentificacionVehiculo, GetType(Entidades.Publicos.SiNo))

            _liSources.Add(NameOf(Vehiculo.EstadoVehiculo), Vehiculo.EstadoVehiculo)
            _liSources.Add(NameOf(Vehiculo.TipoUnidad), Vehiculo.TipoUnidad)

            '-- Bindea Campos.- --
            BindearControles(_entidad, _liSources)

            ugClientes.DataSource = Vehiculo.Clientes

            If Me.StateForm = Win.StateForm.Insertar Then
               If CodigoCliente <> 0 Then
                  bscCodigoCliente.Text = CodigoCliente.ToString()
                  bscCodigoCliente.PresionarBoton()
               End If
               '-- Carga Inicial.- --
               CargarValoresIniciales()
            Else
               _publicos.CargaComboModeloVehiculo(cmbModelo, Vehiculo.IdMarcaVehiculo)
               cmbModelo.SelectedValue = Vehiculo.IdModeloVehiculo

               'Me.bscCodigoCliente.Text = DirectCast(Me._entidad, Entidades.Vehiculo).IdCliente.ToString()
               'If Me.bscCodigoCliente.Text <> "0" Then
               '   Me.bscCodigoCliente.PresionarBoton()
               'End If

               Dim idModelo = Vehiculo.IdModeloVehiculo

               If Vehiculo.Ruta > Date.Parse("1901-01-01") Then
                  dtpRuta.Value = Vehiculo.Ruta.IfNull
                  chbRuta.Checked = True
               End If
               If Vehiculo.Vtv > Date.Parse("1901-01-01") Then
                  dtpVTV.Value = Vehiculo.Vtv.IfNull
                  chbVTV.Checked = True
               End If

               '-- Habilita los check
               chbRuta.Checked = Vehiculo.Ruta IsNot Nothing
               chbVTV.Checked = Vehiculo.Vtv IsNot Nothing

               If Not String.IsNullOrWhiteSpace(Vehiculo.IdProductoReferencia) Then
                  bscCodigoProducto2.PresionarBoton()
               End If

            End If

            _estaCargando = False

            '-- Posiciona el Foco.- --
            txtPatente.Focus()
         End Sub)

   End Sub
   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      txtPatente.Focus()
   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Vehiculos()
   End Function
   Protected Overrides Sub Aceptar()

      If Validar() Then
         IdPatente = txtPatente.Text

         If Not chbRuta.Checked Then
            Vehiculo.Ruta = Nothing
         Else
            Vehiculo.Ruta = dtpRuta.Value
         End If
         If Not chbVTV.Checked Then
            Vehiculo.Vtv = Nothing
         Else
            Vehiculo.Vtv = dtpVTV.Value
         End If
         _estaCargando = True

         MyBase.Aceptar()
         If Not HayError Then
            Close()
         End If
         _estaCargando = False
      End If

   End Sub

   Protected Overrides Function EjecutaInsertar(rg As Reglas.Base, en As Entidades.Entidad) As Entidades.Entidad
      If GuardaNuevoEnBase Then
         Return MyBase.EjecutaInsertar(rg, en)
      Else
         Vehiculo.DescripMarcaVehiculo = cmbMarca.Text
         Vehiculo.DescripModeloVehiculo = cmbModelo.Text
         Vehiculo.EstadoVehiculo = cmbEstadoVehiculo.ItemSeleccionado(Of Entidades.EstadoVehiculo)()
         Vehiculo.TipoUnidad = cmbTipoUnidad.ItemSeleccionado(Of Entidades.ConcesionarioTipoUnidad)()
         Return en
      End If
   End Function

   Private Function Validar() As Boolean
      If txtPatente.Text = "" Then
         ShowMessage("Atencion: Debe ingresar una Patente. Es requerida.")
         Return False
      End If
      If txtColor.Text = "" Then
         ShowMessage("Atencion: Debe ingresar un color de Vehiculo. Es requerido.")
         Return False
      End If
      If cmbMarca.SelectedIndex = -1 Then
         ShowMessage("Atencion: Debe Seleccionar una Marca de Vehiculo. Es requerida.")
         Return False
      End If
      If cmbModelo.SelectedIndex = -1 Then
         ShowMessage("Atencion: Debe Seleccionar un Modelo de Vehiculo. Es requerido.")
         Return False
      End If

      'If bscCodigoCliente.Text = "" Then
      '   ShowMessage("Atencion: Debe Seleccionar un Cliente. Es requerido.")
      '   Return False
      'End If
      Return True
   End Function
#End Region

#Region "Eventos"
   Private Sub LnkMarcaVehiculo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkMarcaVehiculo.LinkClicked
      TryCatched(
         Sub()
            Using frm = New MarcasVehiculosDetalle(New Entidades.MarcaVehiculo())
               _estaCargando = True
               frm.StateForm = StateForm.Insertar
               frm.CierraAutomaticamente = True
               If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  _publicos.CargaComboMarcaVehiculo(cmbMarca)
                  cmbMarca.SelectedValue = frm.idMarca
                  _estaCargando = False
                  '-- Carga Combo Modelos-Marcas.- --
                  _publicos.CargaComboModeloVehiculo(cmbModelo, frm.idMarca)
               End If
            End Using
         End Sub)
   End Sub
   Private Sub cmbMarca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarca.SelectedIndexChanged
      TryCatched(
         Sub()
            If Not _estaCargando Then
               '-- Carga Combo Modelos-Marcas.- --
               _publicos.CargaComboModeloVehiculo(cmbModelo, Integer.Parse(cmbMarca.SelectedValue.ToString()))
               cmbModelo.SelectedIndex = -1
               '------------------
            End If
         End Sub)
   End Sub
   Private Sub LnkModeloVehiculo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkModeloVehiculo.LinkClicked
      TryCatched(
         Sub()
            Using frm = New ModelosVehiculosDetalle(New Entidades.ModeloVehiculo())
               frm.StateForm = StateForm.Insertar
               If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  _publicos.CargaComboModeloVehiculo(cmbModelo, Integer.Parse(cmbMarca.SelectedValue.ToString()))
                  cmbModelo.SelectedIndex = frm.IdModelo
               End If
            End Using
         End Sub)
   End Sub
   Private Sub chbRuta_CheckedChanged(sender As Object, e As EventArgs) Handles chbRuta.CheckedChanged
      TryCatched(
         Sub()
            dtpRuta.Enabled = chbRuta.Checked
            If Not chbRuta.Checked Then
               dtpRuta.Value = Date.Today()
               Vehiculo.Ruta = Nothing
            Else
               Vehiculo.Ruta = dtpRuta.Value
            End If
         End Sub)
   End Sub
   Private Sub chbVTV_CheckedChanged(sender As Object, e As EventArgs) Handles chbVTV.CheckedChanged
      TryCatched(
         Sub()
            dtpVTV.Enabled = chbVTV.Checked
            If Not chbVTV.Checked Then
               dtpVTV.Value = Date.Today()
               Vehiculo.Vtv = Nothing
            Else
               Vehiculo.Vtv = dtpVTV.Value
            End If
         End Sub)
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCodigoCliente)
            Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
            bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
         End Sub)
   End Sub
   Private Sub bscNombreCliente_BuscadorClick() Handles bscNombreCliente.BuscadorClick
      TryCatched(
         Sub()
            'aca busca en la tabla de Clientes
            _publicos.PreparaGrillaClientes2(bscNombreCliente)
            bscNombreCliente.Datos = New Eniac.Reglas.Clientes().GetFiltradoPorNombre(bscNombreCliente.Text.Trim(), True)
         End Sub)
   End Sub
   Private Sub bscNumeroDoc_BuscadorClick() Handles bscNumeroDoc.BuscadorClick
      TryCatched(
         Sub()
            'aca busca en la tabla de Clientes
            _publicos.PreparaGrillaClientes2(bscNumeroDoc)
            bscNumeroDoc.Datos = New Reglas.Clientes().GetFiltradoPorTipoYNroDocumento(cmbTipoDoc.ValorSeleccionado(Of String)(),
                                                                                          bscNumeroDoc.Text.ValorNumericoPorDefecto(0L))
         End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscNombreCliente.BuscadorSeleccion, bscNumeroDoc.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
            Dim idProducto = bscCodigoProducto2.Text.Trim()
            Dim idListaPrecios = Reglas.Publicos.ListaPreciosPredeterminada
            Dim rProductos = New Reglas.Productos()
            Dim dt = rProductos.GetPorCodigo(idProducto, actual.Sucursal.Id, idListaPrecios, "VENTAS", soloCompuestos:=False, modalidad:="NORMAL",
                                             soloAlquilables:=False, Entidades.Producto.TiposOperaciones.NORMAL, publicarEn:=Nothing,
                                             esObservacion:=Nothing, permiteModificarDescripcion:=Nothing, idRubro:=0, idMarca:=0, idCLiente:=0,
                                             soloProductosConStock:=False, soloBuscaPorIdProducto:=True, idProveedor:=0, SoloTipoCalidadCompras:=False)

            bscCodigoProducto2.Datos = dt
         End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProductos2(bscProducto2)
            Dim idListaPrecios = Reglas.Publicos.ListaPreciosPredeterminada
            Dim rProductos = New Reglas.Productos()
            Dim dt = rProductos.GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, idListaPrecios, "VENTAS", soloCompuestos:=False,
                                             soloAlquilables:=False, Entidades.Producto.TiposOperaciones.NORMAL, publicarEn:=Nothing,
                                             esObservacion:=Nothing, permiteModificarDescripcion:=Nothing, idRubro:=0, idMarca:=0, idCliente:=0,
                                             idProveedor:=0, soloTipoCalidadCompras:=False)
            bscProducto2.Datos = dt
         End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion, bscCodigoProducto2.BuscadorSeleccion
      TryCatched(Sub() CargarProducto(e.FilaDevuelta))
   End Sub

   Private Sub txtPrecioCompra_Leave(sender As Object, e As EventArgs) Handles txtPrecioLista.Leave, txtPrecioCompra.Leave
      TryCatched(Sub() MuestraMinimoMaximo())
   End Sub


   Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
      TryCatched(
         Sub()
            bscCodigoCliente.Text = "0"
            bscNombreCliente.Text = String.Empty
            cmbTipoDoc.Text = Reglas.Publicos.TipoDocumentoCliente
            bscNumeroDoc.Text = "0"
         End Sub)
   End Sub
   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      TryCatched(Sub() InsertaCliente())
   End Sub
   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      TryCatched(Sub() EliminarCliente())
   End Sub
   Private Sub ugClientes_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugClientes.DoubleClickRow
      TryCatched(Sub() ActualizarCliente())
   End Sub
#End Region

#Region "Metodos"
   Private Sub CargarValoresIniciales()
      cmbMarca.SelectedIndex = -1
      cmbEstadoVehiculo.SetValorPredeterminado(Of Entidades.EstadoVehiculo)(Function(e) e.Predeterminado)
      dtpVencimientoSeguro.Value = Date.Now()
      dtpRuta.Value = Date.Today()
      dtpVTV.Value = Date.Today()
      Vehiculo.Ruta = Nothing
      Vehiculo.Vtv = Nothing
      Vehiculo.VencimientoSeguro = dtpVencimientoSeguro.Value
   End Sub
   Private Sub LimpiarCliente()
      bscCodigoCliente.Text = ""
      bscNombreCliente.Text = ""
   End Sub
   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()

         bscNombreCliente.Text = dr.Cells("NombreCliente").Value.ToString()

         cmbTipoDoc.SelectedValue = dr.Cells("TipoDocCliente").Value.ToString()

         bscNumeroDoc.Text = dr.Cells("NroDocCliente").Value.ToString()
         '-- REQ-33387.- -----
         'DirectCast(Me._entidad, Entidades.Vehiculo).IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())

         '         bscCodigoCliente.Enabled = True
         btnInsertar.Focus()

      End If
   End Sub
   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         Dim producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString.Trim())

         bscCodigoProducto2.Text = producto.IdProducto
         bscProducto2.Text = producto.NombreProducto
         Vehiculo.IdProductoReferencia = producto.IdProducto
         bscCodigoProducto2.Tag = producto

         bscCodigoProducto2.FilaDevuelta = dr
         bscProducto2.FilaDevuelta = dr

         bscCodigoProducto2.Selecciono = True
         bscProducto2.Selecciono = True

         If StateForm = StateForm.Insertar Or txtPrecioReferencia.ValorNumericoPorDefecto(0D) = 0 Then
            txtPrecioReferencia.SetValor(Decimal.Parse(dr.Cells("PrecioVentaSinIVA").Value.ToString()))
         End If
         txtPrecioReferenciaActual.SetValor(Decimal.Parse(dr.Cells("PrecioVentaSinIVA").Value.ToString()))

         MuestraMinimoMaximo()
      End If
   End Sub

   Private Sub InsertaCliente()
      Dim idCliente = If(IsNumeric(bscCodigoCliente.Tag), Long.Parse(bscCodigoCliente.Tag.ToString()), -1L)
      Dim cliente = New Reglas.Clientes().GetUnoLiviando(idCliente, Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
      If cliente IsNot Nothing Then
         Dim vc = New Entidades.VehiculoCliente()
         vc.IdCliente = cliente.IdCliente
         vc.CodigoCliente = cliente.CodigoCliente
         vc.TipoDocCliente = cliente.TipoDocCliente
         vc.NroDocCliente = cliente.NroDocCliente
         vc.NombreCliente = cliente.NombreCliente

         Vehiculo.Clientes.Add(vc)
         ugClientes.Rows.Refresh(RefreshRow.ReloadData)
      Else
         Throw New Exception("Debe seleccionar un cliente.")
      End If
   End Sub
   Private Sub EliminarCliente()
      Dim dr = ugClientes.FilaSeleccionada(Of Entidades.VehiculoCliente)()
      If dr IsNot Nothing Then
         Vehiculo.Clientes.Remove(dr)
         ugClientes.Rows.Refresh(RefreshRow.ReloadData)
      Else
         Throw New Exception("Debe seleccionar un cliente.")
      End If
   End Sub
   Private Sub ActualizarCliente()
      Dim dr = ugClientes.FilaSeleccionada(Of Entidades.VehiculoCliente)()
      If dr IsNot Nothing Then
         bscCodigoCliente.Text = dr.CodigoCliente.ToString()
         bscCodigoCliente.PresionarBoton()
         Vehiculo.Clientes.Remove(dr)
         ugClientes.Rows.Refresh(RefreshRow.ReloadData)
      Else
         Throw New Exception("Debe seleccionar un cliente.")
      End If
   End Sub

   Private Sub MuestraMinimoMaximo()
      Dim minMax = CalculaPreciosSegunReferencias(txtPrecioCompra.ValorNumericoPorDefecto(0D), txtPrecioReferencia.ValorNumericoPorDefecto(0D), txtPrecioReferenciaActual.ValorNumericoPorDefecto(0D))
      txtMinimoActualizado.SetValor(minMax.Item1)
      txtMaximoActualizado.SetValor(minMax.Item2)

      PintaColorSegunReferencia()
   End Sub
   Private Sub PintaColorSegunReferencia()
      If txtPrecioLista.ValorNumericoPorDefecto(0D) < txtMinimoActualizado.ValorNumericoPorDefecto(0D) Then
         pnlColorPrecioLista.BackColor = Color.Red
      ElseIf txtPrecioLista.ValorNumericoPorDefecto(0D) > txtMaximoActualizado.ValorNumericoPorDefecto(0D) Then
         pnlColorPrecioLista.BackColor = Color.Green
      Else
         pnlColorPrecioLista.BackColor = Nothing
      End If
   End Sub
   Private Function CalculaPreciosSegunReferencias(precioCompra As Decimal, precioReferencia As Decimal, precioReferenciaActualizado As Decimal) As Tuple(Of Decimal, Decimal)
      Dim min = If(precioReferencia = 0, 0, precioCompra * precioReferenciaActualizado / precioReferencia)
      Dim max = min * 1.2D
      Return New Tuple(Of Decimal, Decimal)(min, max)
   End Function

#End Region

End Class