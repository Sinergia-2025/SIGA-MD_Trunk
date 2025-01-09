Option Strict On
Option Explicit On
''Option Infer On
Imports Eniac.Entidades
Imports actual = Eniac.Entidades.Usuario.Actual
Public Class FichasSeleccionoNrosSerie
   Private _ventaProducto As Entidades.IVentaProducto
   Private _listaVentaProducto As Dictionary(Of Entidades.IVentaProducto, List(Of String))
   Private _tit As Dictionary(Of String, String)
   Private _dtNrosSerie As DataTable
   Private _stateForm As StateForm
   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
   End Sub
   Public Sub New(ventaProducto As Entidades.IVentaProducto,
                  listaVentaProducto As Dictionary(Of Entidades.IVentaProducto, List(Of String)),
                  stateForm As StateForm)
      Me.New()
      _ventaProducto = ventaProducto
      _listaVentaProducto = listaVentaProducto
      _stateForm = stateForm
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         ugNrosSerie.DisplayLayout.Bands(0).Columns("Selec").Hidden = _stateForm = StateForm.Consultar

         ugNrosSerie.AgregarFiltroEnLinea({"NroSerie"})

         _tit = GetColumnasVisiblesGrilla(ugNrosSerie)

         lblProducto.Text = String.Format("Producto: {0} - {1}", _ventaProducto.Producto.IdProducto, _ventaProducto.Producto.NombreProducto)
         lblCantidad.Text = String.Format("Cantidad: {0}", _ventaProducto.Cantidad)

         btnAceptar.Visible = _stateForm <> StateForm.Consultar

         CargarNumeroSerie()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub CargarNumeroSerie()
      Dim onrosSerie As Reglas.ProductosNrosSerie = New Reglas.ProductosNrosSerie()
      '-- REQ-32489.- ---------------------------------------------------------
      _dtNrosSerie = onrosSerie.GetNrosSerieProducto(actual.Sucursal, _ventaProducto.Producto.IdDeposito, _ventaProducto.Producto.IdUbicacion, _ventaProducto.Producto.IdProducto)
      If Not _dtNrosSerie.Columns.Contains("Selec") Then
         _dtNrosSerie.Columns.Add("Selec", GetType(Boolean))
      End If
      For Each dr As DataRow In _dtNrosSerie.Rows
         dr("Selec") = False
      Next

      If _listaVentaProducto.ContainsKey(_ventaProducto) Then
         For Each nroSerie As String In _listaVentaProducto(_ventaProducto)
            For Each drNrosSerie As DataRow In _dtNrosSerie.Select(String.Format("NroSerie = '{0}'", nroSerie))
               drNrosSerie("Selec") = True
            Next
         Next
      End If

      If _stateForm = StateForm.Consultar Then
         For Each drNrosSerie As DataRow In _dtNrosSerie.Select(String.Format("Selec = False"))
            drNrosSerie.Delete()
         Next
      Else
         For Each valores As List(Of String) In _listaVentaProducto.Values
            For Each nroSerie As String In valores
               For Each drNrosSerie As DataRow In _dtNrosSerie.Select(String.Format("NroSerie = '{0}' AND Selec = False", nroSerie))
                  drNrosSerie.Delete()
               Next
            Next
         Next
      End If

      _dtNrosSerie.AcceptChanges()

      ugNrosSerie.DataSource = _dtNrosSerie
      MuestraCantidadSeleccionados()

      AjustarColumnasGrilla(ugNrosSerie, _tit)
   End Sub

   Private Sub MuestraCantidadSeleccionados()
      _dtNrosSerie.AcceptChanges()
      lblSeleccionados.Text = String.Format("Seleccionados: {0}", _dtNrosSerie.Select("Selec").Length)
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      Dim nrosSerie As List(Of String) = New List(Of String)()
      Dim drCol As DataRow() = _dtNrosSerie.Select("Selec")

      If drCol.Length <> _ventaProducto.Cantidad Then
         ShowMessage(String.Format("Debe seleccionar {0} números de serie y ha seleccionado {1}. Por favor {2} {3} números de serie.",
                                   _ventaProducto.Cantidad, drCol.Length,
                                   If(_ventaProducto.Cantidad < drCol.Length, "desmarcar", "marcar"),
                                   Math.Abs(_ventaProducto.Cantidad - drCol.Length)))
         Exit Sub
      End If

      For Each drNroSerie As DataRow In drCol
         nrosSerie.Add(drNroSerie("NroSerie").ToString())
      Next
      If Not _listaVentaProducto.ContainsKey(_ventaProducto) Then
         _listaVentaProducto.Add(_ventaProducto, nrosSerie)
      Else
         _listaVentaProducto(_ventaProducto) = nrosSerie
      End If

      DialogResult = Windows.Forms.DialogResult.OK
      Close()
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      DialogResult = Windows.Forms.DialogResult.Cancel
      Close()
   End Sub


   Private Sub ugNrosSerie_AfterCellUpdate(sender As Object, e As UltraWinGrid.CellEventArgs) Handles ugNrosSerie.AfterCellUpdate
      MuestraCantidadSeleccionados()
   End Sub

   Private Sub ugNrosSerie_CellChange(sender As Object, e As UltraWinGrid.CellEventArgs) Handles ugNrosSerie.CellChange
      ugNrosSerie.UpdateData()
   End Sub
End Class
'Public Class VentaProductoComprarer
'   Implements IEqualityComparer(Of Entidades.IVentaProducto)

'   Public Overloads Function Equals(x As Entidades.IVentaProducto, y As Entidades.IVentaProducto) As Boolean Implements IEqualityComparer(Of Entidades.IVentaProducto).Equals
'      Return x.IdTipoComprobante = y.IdTipoComprobante And x.Letra = y.Letra And x.CentroEmisor = y.CentroEmisor And x.NumeroComprobante = y.NumeroComprobante And
'             x.Producto.IdProducto = y.Producto.IdProducto And x.Orden = y.Orden
'   End Function

'   Public Overloads Function GetHashCode(obj As Entidades.IVentaProducto) As Integer Implements IEqualityComparer(Of Entidades.IVentaProducto).GetHashCode
'      Return obj.IdTipoComprobante.GetHashCode() Xor obj.Letra.GetHashCode() Xor obj.CentroEmisor.GetHashCode() Xor obj.NumeroComprobante.GetHashCode Xor
'             obj.Producto.IdProducto.GetHashCode() Xor obj.Orden
'   End Function
'End Class