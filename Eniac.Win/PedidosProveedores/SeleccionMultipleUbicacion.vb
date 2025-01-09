Public Class SeleccionMultipleUbicacion

   Private _publicos As Publicos

   Private _coeficienteStock As Integer
   Private _solicitaInformeCalidad As Boolean
   Private _producto As Entidades.ProductoLivianoParaImportarProducto
   Private _sucursal As Entidades.Sucursal
   Private _ubicaciones As List(Of Entidades.SeleccionMultipleUbicaciones)
   Private _cantidadTotal As Decimal

   Private _cache As Reglas.BusquedasCacheadas

   Private _titUbicacion As Dictionary(Of String, String)
   Private _titLotes As Dictionary(Of String, String)

   Private _defaultSize As Size

   'Private _modo As Modos

   'Public Enum Modos
   '   Ubicacion
   '   ''UbicacionSimple
   '   LoteSerie
   'End Enum

   Private _modoUbicacion As ModosUbicacion
   Private _modoLoteSerie As ModosLoteSerie


   Public Enum ModosUbicacion
      MultiplesUbicaciones
      UbicacionUnica
      UbicacionFija
   End Enum
   Public Enum ModosLoteSerie
      Visible
      Invisible
   End Enum

   Public ReadOnly Property UbicacionesSeleccionadas As List(Of Entidades.SeleccionMultipleUbicaciones)

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      _defaultSize = Size
      _cache = New Reglas.BusquedasCacheadas()
   End Sub

#Region "Overrides/Overloads"
   Public Overloads Function ShowDialog(owner As IWin32Window,
                                        coeficienteStock As Integer,
                                        solicitaInformeCalidad As Boolean,
                                        idProducto As String,
                                        idSucursal As Integer,
                                        ubicaciones As List(Of Entidades.SeleccionMultipleUbicaciones),
                                        cantidadTotal As Decimal,
                                        modoUbicacion As ModosUbicacion,
                                        modoLoteSerie As ModosLoteSerie) As DialogResult
      Return ShowDialog(owner, coeficienteStock, solicitaInformeCalidad,
                        New Reglas.Productos().GetUnoParaM(idProducto, accion:=Reglas.Base.AccionesSiNoExisteRegistro.Vacio),
                        New Reglas.Sucursales().GetUna(idSucursal, incluirLogo:=False),
                        ubicaciones, cantidadTotal, modoUbicacion, modoLoteSerie)
   End Function
   Public Overloads Function ShowDialog(owner As IWin32Window,
                                        coeficienteStock As Integer,
                                        solicitaInformeCalidad As Boolean,
                                        producto As Entidades.ProductoLivianoParaImportarProducto,
                                        sucursal As Entidades.Sucursal,
                                        ubicaciones As List(Of Entidades.SeleccionMultipleUbicaciones),
                                        cantidadTotal As Decimal,
                                        modoUbicacion As ModosUbicacion,
                                        modoLoteSerie As ModosLoteSerie) As DialogResult
      _coeficienteStock = coeficienteStock
      _solicitaInformeCalidad = solicitaInformeCalidad
      _producto = producto
      _sucursal = sucursal
      _ubicaciones = ubicaciones.ClonarColeccion()
      _ubicaciones.ForEach(
         Sub(u)
            u.Lotes.ForEach(Sub(l) l.UbicacionAdmin = u)
            u.NrosSerie.ForEach(Sub(s) s.UbicacionAdmin = u)
            u.Cantidad = cantidadTotal
         End Sub)
      _cantidadTotal = cantidadTotal
      _modoUbicacion = modoUbicacion
      _modoLoteSerie = modoLoteSerie

      Return ShowDialog(owner)
   End Function
   Protected Overrides Sub OnLoad(e As EventArgs)
      Dim ubicacionSimple As Entidades.SeleccionMultipleUbicaciones = Nothing
      TryCatched(
      Sub()
         If _modoUbicacion = ModosUbicacion.MultiplesUbicaciones Then
            ugUbicaciones.Visible = _modoLoteSerie = ModosLoteSerie.Visible OrElse _ubicaciones.Count > 0
         Else
            btnAgregarUbicacion.Visible = False
            btnEliminarUbicacion.Visible = False
            btnUbicacionesMultiples.Visible = False
            ugUbicaciones.Visible = False

            If _ubicaciones.Any() Then
               ubicacionSimple = _ubicaciones.First()
               cmbDeposito.SelectedValue = ubicacionSimple.IdDeposito
               cmbUbicacion.SelectedValue = ubicacionSimple.IdUbicacion
               If _modoUbicacion <> ModosUbicacion.UbicacionFija Then
                  _ubicaciones.Clear()
               End If
            End If
            If _modoUbicacion = ModosUbicacion.UbicacionUnica Then
               txtCantidad.SetValor(_cantidadTotal)
            End If

            cmbDeposito.Enabled = _modoUbicacion = ModosUbicacion.UbicacionUnica
            cmbUbicacion.Enabled = _modoUbicacion = ModosUbicacion.UbicacionUnica


         End If

         cmbUbicacionLote.DataSource = _ubicaciones
         cmbUbicacionLote.DisplayMember = "DisplayMember"
         cmbUbicacionLote.ValueMember = "IdUnico"

         cmbUbicacionNroSerie.DataSource = _ubicaciones
         cmbUbicacionNroSerie.DisplayMember = "DisplayMember"
         cmbUbicacionNroSerie.ValueMember = "IdUnico"

         'Si debo mostrar los Lotes/Nros Serie
         If _modoLoteSerie = Eniac.Win.SeleccionMultipleUbicacion.ModosLoteSerie.Visible Then
            'Si vengo sin elegir alguna Ubicación, agrego una a la colección.
            If _ubicaciones.Count = 0 Then
               _ubicaciones.Add(New Entidades.SeleccionMultipleUbicaciones With {
                                       .Producto = _producto,
                                       .Cantidad = _cantidadTotal,
                                       .Ubicacion = New Reglas.SucursalesUbicaciones().GetUno(_producto.IdDepositoDefecto, _sucursal.Id, _producto.IdUbicacionDefecto),
                                       .Stock = New Reglas.ProductosUbicaciones().GetUno(_producto.IdProducto, _sucursal.Id, _producto.IdDepositoDefecto, _producto.IdUbicacionDefecto).Stock
                                    })
            End If
            'Si el producto NO usa Lote, quito el tab de Lotes
            If Not _producto.Lote Then
               If tbcLotesNrosSerie.TabPages.Contains(tbpLotes) Then
                  tbcLotesNrosSerie.TabPages.Remove(tbpLotes)
               End If
            End If
            'Si el producto NO usa Nro de Serie, quito el tab de Lotes
            If Not _producto.NroSerie Then
               If tbcLotesNrosSerie.TabPages.Contains(tbpNrosSerie) Then
                  tbcLotesNrosSerie.TabPages.Remove(tbpNrosSerie)
               End If
            End If
         Else
            'Si el Lote/Ubicacion deben estar Invisible, no solo oculto el TabControl sino que ajusto el ancho de la pantalla para que se vea angosto.
            tbcLotesNrosSerie.Visible = False
            Width = pnlUbicaciones.Width + 14
         End If

         If Not ugUbicaciones.Visible And Not tbcLotesNrosSerie.Visible Then
            Height = pnlAgregarUbicaciones.Height + pnlAcciones.Height + stsStado.Height + 34
         End If



         '''''''''''''''Dim ubicMultipleVisible = True
         '''''''''''''''If _modo = Modos.UbicacionSimple Then
         '''''''''''''''   If _ubicaciones.Any() Then
         '''''''''''''''      ubicacionSimple = _ubicaciones.First()
         '''''''''''''''      cmbDeposito.SelectedValue = ubicacionSimple.IdDeposito
         '''''''''''''''      cmbUbicacion.SelectedValue = ubicacionSimple.IdUbicacion
         '''''''''''''''      _ubicaciones.Clear()
         '''''''''''''''   End If
         '''''''''''''''   ubicMultipleVisible = False
         '''''''''''''''   _modo = Modos.Ubicacion
         '''''''''''''''End If

         '''''''''''''''If (_modo = Modos.Ubicacion Or (Not _producto.Lote And Not _producto.NroSerie)) Then
         '''''''''''''''   tbcLotesNrosSerie.Visible = False
         '''''''''''''''   btnAgregarUbicacion.Visible = _ubicaciones.Count > 0
         '''''''''''''''   btnEliminarUbicacion.Visible = _ubicaciones.Count > 0
         '''''''''''''''   btnUbicacionesMultiples.Visible = ubicMultipleVisible And _ubicaciones.Count = 0

         '''''''''''''''   Width = pnlUbicaciones.Width + 14
         '''''''''''''''   If _ubicaciones.Count < 1 OrElse _modo = Modos.UbicacionSimple Then
         '''''''''''''''      Height = pnlAgregarUbicaciones.Height + pnlAcciones.Height + stsStado.Height + 34
         '''''''''''''''   End If
         '''''''''''''''Else
         '''''''''''''''   If Not _producto.Lote Then
         '''''''''''''''      If tbcLotesNrosSerie.TabPages.Contains(tbpLotes) Then
         '''''''''''''''         tbcLotesNrosSerie.TabPages.Remove(tbpLotes)
         '''''''''''''''      End If
         '''''''''''''''   End If
         '''''''''''''''   If Not _producto.NroSerie Then
         '''''''''''''''      If tbcLotesNrosSerie.TabPages.Contains(tbpNrosSerie) Then
         '''''''''''''''         tbcLotesNrosSerie.TabPages.Remove(tbpNrosSerie)
         '''''''''''''''      End If
         '''''''''''''''   End If
         '''''''''''''''End If
      End Sub)
      MyBase.OnLoad(e)
      TryCatched(Sub() _publicos = New Publicos())
      TryCatched(
      Sub()
         _publicos.CargaComboSucursales(cmbSucursal)
         _publicos.CargaComboDepositos(cmbDeposito, seleccionMultiple:=False, seleccionTodos:=False, {_sucursal})
      End Sub)
      TryCatched(
      Sub()
         txtIdProducto.Text = _producto.IdProducto
         txtNombreProducto.Text = _producto.NombreProducto

         txtCantidadTotal.SetValor(_cantidadTotal)

         cmbSucursal.SelectedValue = _sucursal.IdSucursal

         If Not Reglas.Publicos.LoteSolicitaFechaVencimiento Then
            pnlFechaVencimiento.Visible = False
            ugLotes.Column("IdLote").Width += ugLotes.Column("FechaVencimiento").Width
            ugLotes.Column("FechaVencimiento").Hidden = True
         End If

         If _producto.InformeControlCalidad AndAlso _solicitaInformeCalidad Then
            pnlInformeCalidad.Visible = True
         End If

         If _ubicaciones.Count > 1 Then
            ubicacionSimple = _ubicaciones.FirstOrDefault()
         End If

         If _ubicaciones.Count < 2 Then
            Dim ubicAdmin = ubicacionSimple ' _ubicaciones.FirstOrDefault()
            Dim ubic = If(ubicAdmin Is Nothing, New Reglas.SucursalesUbicaciones().GetUno(_producto.IdDepositoDefecto, _producto.IdSucursal, _producto.IdUbicacionDefecto), ubicAdmin.Ubicacion)
            cmbDeposito.SelectedValue = ubic.IdDeposito
            cmbUbicacion.SelectedValue = ubic.IdUbicacion
         End If


         If _coeficienteStock < 0 Then
            _ubicaciones.ForEach(
               Sub(u)
                  If _coeficienteStock < 0 Then
                     Dim lotes = New Reglas.ProductosLotes().GetTodos(u.IdSucursal, u.IdDeposito, u.IdUbicacion, u.IdProducto, parteIdLote:=String.Empty, validarStock:=True)
                     For Each l In lotes.Where(Function(l1) Not u.Lotes.Exists(Function(l2) l2.IdLote = l1.IdLote))
                        u.Lotes.Add(New Entidades.SeleccionMultipleLotes() With {
                                       .UbicacionAdmin = u,
                                       .IdLote = l.IdLote,
                                       .FechaVencimiento = l.FechaVencimiento,
                                       .Stock = l.CantidadActual,
                                       .Cantidad = 0D
                                    })
                     Next
                     u.Lotes = u.Lotes.OrderBy(Function(l) l.IdLote).ToList()
                  End If
               End Sub)
         End If


         ugUbicaciones.AgregarTotalesSuma({"Cantidad"})
         ugLotes.AgregarTotalesSuma({"Cantidad"})
         ugNrosSerie.AgregarTotalesSuma({"Cantidad"})

         ugUbicaciones.AgregarFiltroEnLinea({})
         ugLotes.AgregarFiltroEnLinea({"IdLote"})
         ugNrosSerie.AgregarFiltroEnLinea({"NroSerie"})

         LimpiarUbicacion()

         RefrecarUbicacionesDataSource()

      End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      ElseIf keyData = (Keys.Control Or Keys.Add) Then
         btnAgregarUbicacion.PerformClick()
      ElseIf keyData = (Keys.Control Or Keys.Delete) Then
         btnEliminarUbicacion.PerformClick()
      ElseIf keyData = Keys.Escape Then
         btnCancelar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"
   Private Sub cmbDeposito_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDeposito.SelectedIndexChanged
      TryCatched(Sub() _publicos.CargaComboUbicaciones(cmbUbicacion, {_sucursal}, {cmbDeposito.ItemSeleccionado(Of Entidades.SucursalDeposito)}.Where(Function(x) x IsNot Nothing).ToArray()))
   End Sub

   Private Sub cmbUbicacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUbicacion.SelectedIndexChanged
      TryCatched(
      Sub()
         Dim ubic = cmbUbicacion.ItemSeleccionado(Of Entidades.SucursalUbicacion)
         Dim rProdUbic = New Reglas.ProductosUbicaciones()
         Dim prodUbic = rProdUbic.GetUno(_producto.IdProducto, ubic.IdSucursal, ubic.IdDeposito, ubic.IdUbicacion, Reglas.Base.AccionesSiNoExisteRegistro.Vacio)

         txtStock.SetValor(prodUbic.Stock)

         If _modoUbicacion = ModosUbicacion.UbicacionUnica Or _modoUbicacion = ModosUbicacion.UbicacionFija Then
            Dim drUbicacion = ugUbicaciones.FilaSeleccionada(Of Entidades.SeleccionMultipleUbicaciones)
            If drUbicacion IsNot Nothing Then
               drUbicacion.Ubicacion = ubic
            End If
         End If

      End Sub)
   End Sub

   Private Sub controles_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStock.KeyDown, txtCantidad.KeyDown, cmbUbicacion.KeyDown, cmbSucursal.KeyDown, cmbDeposito.KeyDown,
                                                                              txtCantidadLote.KeyDown, cmbUbicacionLote.KeyDown, dtpFechaVencimiento.KeyDown, txtStockLote.KeyDown, txtLinkdoc.KeyDown, txtInformeCalidad.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
      TryCatched(
      Sub()
         DialogoAbrirArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
         If Not String.IsNullOrWhiteSpace(txtLinkdoc.Text) Then
            DialogoAbrirArchivo.FileName = txtLinkdoc.Text
         End If
         If DialogoAbrirArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtLinkdoc.Text = DialogoAbrirArchivo.FileName
            txtLinkdoc.Focus()
         End If
      End Sub)
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(Sub() Aceptar())
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub

#Region "Eventos Ubicacion"
   Private Sub btnAgregarUbicacion_Click(sender As Object, e As EventArgs) Handles btnAgregarUbicacion.Click
      TryCatched(
      Sub()
         If ValidaUbicacion() Then

            Dim ubic = cmbUbicacion.ItemSeleccionado(Of Entidades.SucursalUbicacion)
            Dim adminUbicacion = _ubicaciones.FirstOrDefaultSecure(Function(u) u.IdSucursal = ubic.IdSucursal And u.IdDeposito = ubic.IdDeposito And u.IdUbicacion = ubic.IdUbicacion)
            If adminUbicacion Is Nothing Then
               adminUbicacion = New Entidades.SeleccionMultipleUbicaciones() With
               {
                  .Producto = _producto,
                  .Ubicacion = cmbUbicacion.ItemSeleccionado(Of Entidades.SucursalUbicacion),
                  .Stock = txtStock.ValorNumericoPorDefecto(0D),
                  .Cantidad = 0
               }
               _ubicaciones.Add(adminUbicacion)
            End If

            adminUbicacion.Cantidad += txtCantidad.ValorNumericoPorDefecto(0D)

            RefrecarUbicacionesDataSource()
            LimpiarUbicacion()
         End If
      End Sub)
   End Sub
   Private Sub ugUbicaciones_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugUbicaciones.DoubleClickCell
      TryCatched(
      Sub()
         If _modoUbicacion <> ModosUbicacion.UbicacionFija Then
            Dim dr = ugUbicaciones.FilaSeleccionada(Of Entidades.SeleccionMultipleUbicaciones)
            If dr IsNot Nothing Then
               cmbDeposito.SelectedValue = dr.IdDeposito
               cmbUbicacion.SelectedValue = dr.IdUbicacion
               txtCantidad.SetValor(dr.Cantidad)
               _ubicaciones.Remove(dr)
               RefrecarUbicacionesDataSource()
            End If
         End If
      End Sub)
   End Sub
   Private Sub ugUbicaciones_AfterRowActivate(sender As Object, e As EventArgs) Handles ugUbicaciones.AfterRowActivate
      TryCatched(
      Sub()
         Dim dr = ugUbicaciones.FilaSeleccionada(Of Entidades.SeleccionMultipleUbicaciones)
         If dr IsNot Nothing Then
            ugLotes.DataSource = dr.Lotes
            ugNrosSerie.DataSource = dr.NrosSerie

            LimpiarLotes()
         End If
      End Sub)
   End Sub
   Private Sub ugUbicaciones_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugUbicaciones.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of Entidades.SeleccionMultipleUbicaciones)()
         If dr IsNot Nothing Then
            e.Row.Cells("Cantidad").Color(Color.Black, Color.LightCyan)

            If _coeficienteStock < 0 Then
               If dr.Stock < dr.Cantidad Then
                  e.Row.Cells("Cantidad").Color(Color.White, Color.Red)
               End If

               If _producto.Lote Then
                  If dr.Lotes.SumSecure(Function(l) l.Cantidad) <> dr.Cantidad Then
                     e.Row.Cells("Cantidad").Color(Color.White, Color.Red)
                  End If
               End If

            End If
         End If
      End Sub)
   End Sub
   Private Sub btnEliminarUbicacion_Click(sender As Object, e As EventArgs) Handles btnEliminarUbicacion.Click
      TryCatched(
      Sub()
         Dim dr = ugUbicaciones.FilaSeleccionada(Of Entidades.SeleccionMultipleUbicaciones)
         If dr IsNot Nothing Then
            If ShowPregunta("¿Desea eliminar la ubicación seleccionada?") = DialogResult.Yes Then
               _ubicaciones.Remove(dr)
               RefrecarUbicacionesDataSource()
               LimpiarUbicacion()
            End If
         End If
      End Sub)
   End Sub
   Private Sub btnUbicacionesMultiples_Click(sender As Object, e As EventArgs) Handles btnUbicacionesMultiples.Click
      TryCatched(
      Sub()
         Height = _defaultSize.Height
         ugUbicaciones.Visible = True
         btnAgregarUbicacion.Visible = True
         btnEliminarUbicacion.Visible = True
         btnUbicacionesMultiples.Visible = False
      End Sub)
   End Sub
#End Region

#Region "Eventos Nros de Serie"
#Region "Eventos Buscador Nros de Serie"
   Private Sub bscNrosSerie_BuscadorClick() Handles bscNrosSerie.BuscadorClick
      TryCatched(
      Sub()
         Dim ubic = cmbUbicacionNroSerie.ItemSeleccionado(Of Entidades.SeleccionMultipleUbicaciones)()
         Dim vendido = Entidades.Publicos.SiNoTodos.TODOS
         If _coeficienteStock > 0 Then
            vendido = Entidades.Publicos.SiNoTodos.SI
         ElseIf _coeficienteStock < 0 Then
            vendido = Entidades.Publicos.SiNoTodos.NO
         End If
         _publicos.PreparaGrillaNrosSerie(bscNrosSerie)
         bscNrosSerie.Datos = New Reglas.ProductosNrosSerie().GetNrosSerieProducto(_cache.BuscaSucursal(ubic.IdSucursal), ubic.IdDeposito, ubic.IdUbicacion, _producto.IdProducto, {bscNrosSerie.Text}, Entidades.Publicos.SiNoTodos.TODOS)
      End Sub)
   End Sub
   Private Sub bscNrosSerie_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNrosSerie.BuscadorSeleccion
      TryCatched(
      Sub()
         If Not e.FilaDevuelta Is Nothing Then
            bscNrosSerie.Text = e.FilaDevuelta.Cells("NroSerie").Value.ToString()
            btnAgregarNroSerie.Focus()
            btnAgregarNroSerie.PerformClick()
            bscNrosSerie.Focus()
         End If
      End Sub)
   End Sub
#End Region

   Private Sub btnAgregarNroSerie_Click(sender As Object, e As EventArgs) Handles btnAgregarNroSerie.Click
      TryCatched(
      Sub()
         Dim ubic = cmbUbicacionNroSerie.ItemSeleccionado(Of Entidades.SeleccionMultipleUbicaciones)()
         If ValidaNrosSerie(ubic) Then
            Dim ns = New Entidades.SeleccionMultipleNrosSerie(ubic, bscNrosSerie.Text)
            ubic.NrosSerie.Add(ns)
            RefrecarNrosSerieDataSource()
            LimpiarNrosSerie()
         End If
      End Sub)
   End Sub
   Private Sub btnEliminarNroSerie_Click(sender As Object, e As EventArgs) Handles btnEliminarNroSerie.Click
      TryCatched(
      Sub()
         Dim dr = ugNrosSerie.FilaSeleccionada(Of Entidades.SeleccionMultipleNrosSerie)
         If dr IsNot Nothing Then
            If ShowPregunta("Desea eliminar el nro de serie seleccionado") = DialogResult.Yes Then
               Dim ubic = cmbUbicacionNroSerie.ItemSeleccionado(Of Entidades.SeleccionMultipleUbicaciones)()
               ubic.NrosSerie.Remove(dr)
               RefrecarNrosSerieDataSource()
               LimpiarNrosSerie()
            End If
         End If
      End Sub)
   End Sub
#End Region


#Region "Eventos Lotes"
#Region "Eventos Buscador Lote"
   Private Sub bscLote_BuscadorClick() Handles bscLote.BuscadorClick
      TryCatched(
      Sub()
         Dim ubic = cmbUbicacionLote.ItemSeleccionado(Of Entidades.SeleccionMultipleUbicaciones)()

         _publicos.PreparaGrillaLotes(bscLote)
         bscLote.Datos = New Reglas.ProductosLotes().GetPorProducto(ubic.IdSucursal, ubic.IdDeposito, ubic.IdUbicacion, _producto.IdProducto, bscLote.Text)
      End Sub)
   End Sub
   Private Sub bscLote_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscLote.BuscadorSeleccion
      TryCatched(
      Sub()
         If Not e.FilaDevuelta Is Nothing Then
            bscLote.Text = e.FilaDevuelta.Cells("IdLote").Value.ToString()
            If Not String.IsNullOrWhiteSpace(e.FilaDevuelta.Cells("FechaVencimiento").Value.ToString()) Then
               dtpFechaVencimiento.Value = Date.Parse(e.FilaDevuelta.Cells("FechaVencimiento").Value.ToString())
            End If
            txtStockLote.SetValor(Decimal.Parse(e.FilaDevuelta.Cells("CantidadActual").Value.ToString()))
            txtCantidadLote.Focus()
         End If
      End Sub)
   End Sub
#End Region

   Private Sub btnAgregarLotes_Click(sender As Object, e As EventArgs) Handles btnAgregarLotes.Click
      TryCatched(
      Sub()
         If ValidaLotes() Then
            Dim ubic = cmbUbicacionLote.ItemSeleccionado(Of Entidades.SeleccionMultipleUbicaciones)()
            Dim lote = New Entidades.SeleccionMultipleLotes(ubic, bscLote.Text, dtpFechaVencimiento.Valor(dtpFechaVencimiento.Visible),
                                                            txtCantidadLote.ValorNumericoPorDefecto(0D), txtStockLote.ValorNumericoPorDefecto(0D),
                                                            txtInformeCalidad.Text, txtLinkdoc.Text)
            ubic.Lotes.Add(lote)
            RefrecarLotesDataSource()
            LimpiarLotes()
         End If
      End Sub)
   End Sub
   Private Sub btnEliminarLotes_Click(sender As Object, e As EventArgs) Handles btnEliminarLotes.Click
      TryCatched(
      Sub()
         Dim dr = ugLotes.FilaSeleccionada(Of Entidades.SeleccionMultipleLotes)
         If dr IsNot Nothing Then
            If ShowPregunta("Desea eliminar el lote seleccionado") = DialogResult.Yes Then
               Dim ubic = cmbUbicacionLote.ItemSeleccionado(Of Entidades.SeleccionMultipleUbicaciones)()
               ubic.Lotes.Remove(dr)
               RefrecarLotesDataSource()
               LimpiarLotes()
            End If
         End If
      End Sub)
   End Sub
   Private Sub ugLotes_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugLotes.DoubleClickCell
      TryCatched(
      Sub()
         Dim dr = ugLotes.FilaSeleccionada(Of Entidades.SeleccionMultipleLotes)
         If dr IsNot Nothing Then
            cmbUbicacionLote.SelectedValue = dr.UbicacionAdmin.IdUnico
            bscLote.Text = dr.IdLote
            txtCantidadLote.SetValor(dr.Cantidad)
            txtStockLote.SetValor(dr.Stock)
            dtpFechaVencimiento.Value = dr.FechaVencimiento.IfNull(dtpFechaVencimiento.MinDate)
            txtInformeCalidad.Text = dr.InformeCalidadNumero
            txtLinkdoc.Text = dr.InformeCalidadLink
            dr.UbicacionAdmin.Lotes.Remove(dr)
            RefrecarLotesDataSource()
            bscLote.Focus()
         End If
      End Sub)
   End Sub
   Private Sub ugLotes_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugLotes.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of Entidades.SeleccionMultipleLotes)()
         If dr IsNot Nothing Then
            e.Row.Cells("Cantidad").Color(Color.Black, Color.LightCyan)
            If _coeficienteStock < 0 Then
               If dr.Cantidad > dr.Stock Then
                  e.Row.Cells("Cantidad").Color(Color.White, Color.Red)
               End If
            End If
         End If
      End Sub)
   End Sub
   Private Sub ugLotes_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles ugLotes.AfterCellUpdate
      TryCatched(
      Sub()
         ugLotes.UpdateData()
         ugUbicaciones.Rows.Refresh(RefreshRow.FireInitializeRow)
      End Sub)
   End Sub
#End Region

#End Region

#Region "Metodos"
#Region "Metodos Ubicacion"
   Public Function ValidaUbicacion() As Boolean
      If cmbDeposito.SelectedIndex = -1 Then
         ShowMessage("No ha seleccionado un Depósito")
         cmbDeposito.Focus()
         Return False
      End If
      If cmbUbicacion.SelectedIndex = -1 Then
         ShowMessage("No ha seleccionado una Ubicación")
         cmbUbicacion.Focus()
         Return False
      End If
      If txtCantidad.ValorNumericoPorDefecto(0D) <= 0 Then
         ShowMessage("La cantidad no puede ser cero o negativo")
         txtCantidad.Focus()
         Return False
      End If
      Dim ubic = cmbUbicacion.ItemSeleccionado(Of Entidades.SucursalUbicacion)
      If _ubicaciones.AnySecure(Function(u) u.IdSucursal = ubic.IdSucursal And u.IdDeposito = ubic.IdDeposito And u.IdUbicacion = ubic.IdUbicacion) Then
         If ShowPregunta("La ubicación indicada ya existe. ¿Desea acumular la cantidad a la ya ingresada?") = DialogResult.No Then
            txtCantidad.Focus()
            Return False
         End If
      End If
      Return True
   End Function

   Private Sub LimpiarUbicacion()
      Dim cantidadUbicaciones = _ubicaciones.SumSecure(Function(u) u.Cantidad).IfNull()
      If _modoUbicacion = ModosUbicacion.MultiplesUbicaciones Then
         txtCantidad.SetValor(_cantidadTotal - cantidadUbicaciones)
      Else
         txtCantidad.SetValor(_cantidadTotal)
      End If
      cmbDeposito.Focus()
   End Sub
   Private Sub LimpiarLotes()
      Dim lotes = ugLotes.DataSource(Of List(Of Entidades.SeleccionMultipleLotes))()
      Dim ubic = cmbUbicacionLote.ItemSeleccionado(Of Entidades.SeleccionMultipleUbicaciones)()
      Dim cantidadLotes = lotes.SumSecure(Function(u) u.Cantidad).IfNull()
      If ubic IsNot Nothing Then
         bscLote.Text = String.Empty
         txtCantidadLote.SetValor(ubic.Cantidad - cantidadLotes)
         txtStockLote.SetValor(0D)
         cmbUbicacionLote.Focus()
      End If
   End Sub
   Private Sub LimpiarNrosSerie()
      Dim ns = ugNrosSerie.DataSource(Of List(Of Entidades.SeleccionMultipleNrosSerie))()
      Dim ubic = cmbUbicacionNroSerie.ItemSeleccionado(Of Entidades.SeleccionMultipleUbicaciones)()
      Dim cantidadNrosSerie = ns.CountSecure()
      If ubic IsNot Nothing Then
         bscNrosSerie.Text = String.Empty
         'txtCantidadLote.SetValor(ubic.Cantidad - cantidadNrosSerie)
         cmbUbicacionNroSerie.Focus()
      End If
   End Sub
#End Region
#Region "Lotes"
   Public Function ValidaLotes() As Boolean
      If _producto.InformeControlCalidad AndAlso _solicitaInformeCalidad AndAlso _producto.Lote Then
         If String.IsNullOrWhiteSpace(txtInformeCalidad.Text) Then
            ShowMessage(String.Format("El Producto requiere ingresar un {0}", lblInformeCalidad.Text))
            txtInformeCalidad.Focus()
            Return False
         End If
      End If
      Return True
   End Function
#End Region
#Region "Nros Serie"
   Public Function ValidaNrosSerie(ubic As Entidades.SeleccionMultipleUbicaciones) As Boolean
      If ubic Is Nothing Then
         ShowMessage("Debe seleccionar un Deposito/Ubicación")
         cmbUbicacionNroSerie.Focus()
         Return False
      End If
      If ubic.NrosSerie.Exists(Function(ns) ns.NroSerie = bscNrosSerie.Text) Then
         ShowMessage(String.Format("El Nro se Serie {0} ya fue cargado para el producto {1} - {2} en el {3}",
                                   bscNrosSerie.Text, txtIdProducto.Text, txtNombreProducto.Text, ubic.DisplayMember))
         bscNrosSerie.Focus()
         Return False
      End If

      If _coeficienteStock < 0 Then
         Dim rNS = New Reglas.ProductosNrosSerie()
         Dim ns = rNS.GetUno(txtIdProducto.Text, bscNrosSerie.Text, Reglas.Base.AccionesSiNoExisteRegistro.Excepcion)
         If ns.Vendido Then
            ShowMessage(String.Format("El Nro se Serie {0} del producto {1} - {2} ya fue vendido",
                                      bscNrosSerie.Text, txtIdProducto.Text, txtNombreProducto.Text))
            bscNrosSerie.Focus()
            Return False
         End If
      End If

      Return True
   End Function
#End Region

   Private Sub RefrecarUbicacionesDataSource()
      _titUbicacion = GetColumnasVisiblesGrilla(ugUbicaciones)
      ugUbicaciones.DataSource = _ubicaciones
      ugUbicaciones.Rows.Refresh(RefreshRow.ReloadData)
      AjustarColumnasGrilla(ugUbicaciones, _titUbicacion)

      Dim cantidadUbicacion = _ubicaciones.SumSecure(Function(u) u.Cantidad)
      If cantidadUbicacion > _cantidadTotal Then
         txtCantidadTotal.SetColor(Color.White, Color.Red)
      ElseIf cantidadUbicacion < _cantidadTotal Then
         txtCantidadTotal.SetColor(Color.Black, Color.Yellow)
      Else
         txtCantidadTotal.SetColor(Nothing, Nothing)
      End If
   End Sub
   Private Sub RefrecarLotesDataSource()
      ugLotes.Rows.Refresh(RefreshRow.ReloadData)
   End Sub
   Private Sub RefrecarNrosSerieDataSource()
      ugNrosSerie.Rows.Refresh(RefreshRow.ReloadData)
   End Sub

   Public Sub Aceptar()
      ugUbicaciones.UpdateData()
      ugLotes.UpdateData()
      ugNrosSerie.UpdateData()
      If Valida() Then
         If Not _ubicaciones.AnySecure() Then
            btnAgregarUbicacion.Visible = True
            btnAgregarUbicacion.PerformClick()
            btnAgregarUbicacion.Visible = False
         End If
         _UbicacionesSeleccionadas = _ubicaciones
         Close(DialogResult.OK)
      End If
   End Sub

   Public Function Valida() As Boolean
      Dim cantidadUbicacion = _ubicaciones.SumSecure(Function(u) u.Cantidad)
      If cantidadUbicacion <> _cantidadTotal Then
         ShowMessage(String.Format("La cantidad en Ubicaciones debe ser igual a la cantidad necesario. Ubicaciones {0} / Necesario {1}",
                                   cantidadUbicacion, _cantidadTotal))
         txtCantidad.Focus()
         Return False
      End If


      For Each u In _ubicaciones
         If _producto.Lote Then
            If u.Lotes.SumSecure(Function(l) l.Cantidad).IfNull() <> u.Cantidad Then
               ShowMessage(String.Format("La total cantidad de lotes seleccionados para la ubicación {0} debe ser igual a la cantidad de la ubicación", u.DisplayMember))
               ugUbicaciones.Focus()
               Return False
            End If
         End If

         If _producto.NroSerie Then
            If u.NrosSerie.SumSecure(Function(ns) ns.Cantidad).IfNull() <> u.Cantidad Then
               ShowMessage(String.Format("La total cantidad de nros de serie seleccionados para la ubicación {0} debe ser igual a la cantidad de la ubicación", u.DisplayMember))
               ugNrosSerie.Focus()
               Return False
            End If
         End If

         If _coeficienteStock < -1 Then
            If u.Cantidad <= 0 Then
               ShowMessage(String.Format("La cantidad de {0} no puede ser cero o negativo", u.DisplayMember))
               ugUbicaciones.Focus()
               Return False
            End If
            If u.Stock < u.Cantidad Then
               ShowMessage(String.Format("El {0} no tiene stock suficiente", u.DisplayMember))
               ugUbicaciones.Focus()
               Return False
            End If

            If _producto.Lote Then
               If u.Lotes.SumSecure(Function(l) l.Cantidad) <> u.Cantidad Then
                  ShowMessage(String.Format("La total cantidad de lotes seleccionados para la ubicación {0} debe ser igual a la cantidad de la ubicación", u.DisplayMember))
                  ugUbicaciones.Focus()
                  Return False
               End If

               For Each l In u.Lotes
                  If l.Cantidad > l.Stock Then
                     ShowMessage(String.Format("El Lote {0} de la {1} no tiene stock suficiente", l.IdLote, u.DisplayMember))
                     ugLotes.Focus()
                     Return False
                  End If
               Next

            End If

         End If

         If _producto.InformeControlCalidad AndAlso _solicitaInformeCalidad AndAlso _producto.Lote Then
            For Each l In u.Lotes
               If String.IsNullOrWhiteSpace(l.InformeCalidadNumero) Then
                  ShowMessage(String.Format("El Lote {0} de la {1} requiere ingresar un {2}", l.IdLote, u.DisplayMember, lblInformeCalidad.Text))
                  ugLotes.Focus()
                  Return False
               End If
            Next
         End If

      Next

      Return True
   End Function


#End Region

End Class