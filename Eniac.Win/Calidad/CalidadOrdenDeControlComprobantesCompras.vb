Public Class CalidadOrdenDeControlComprobantesCompras
   Private _comprobante As Entidades.TipoComprobante
   Private _letra As String
   Private _centroEmisor As Integer
   Private _numeroOrdenCalidad As Long
   Private _producto As Entidades.ProductoLivianoParaImportarProducto
   Private _estado As Entidades.EstadoOrdenCalidad
   Private _fecha As Date

   Public Property DataCC As DataRow

#Region "Overrides/Overloads"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() MostrarInformacionCC())
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
   Public Overloads Function ShowDialog(owner As IWin32Window,
                                        comprobante As Entidades.TipoComprobante, letra As String, centroEmisor As Integer, numeroOrdenCalidad As Long,
                                        producto As Entidades.ProductoLivianoParaImportarProducto, estado As Entidades.EstadoOrdenCalidad, fecha As Date) As DialogResult
      _comprobante = comprobante
      _letra = letra
      _centroEmisor = centroEmisor
      _numeroOrdenCalidad = numeroOrdenCalidad
      _producto = producto
      _estado = estado
      _fecha = fecha
      Return ShowDialog(owner)
   End Function
#End Region

#Region "Eventos"
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(Sub() Aceptar())
   End Sub
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub

   Private Sub ugOC_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugOC.DoubleClickCell
      TryCatched(Sub() btnAceptar.PerformClick())
   End Sub

#End Region

#Region "Metodos Privados"
   Private Sub MostrarInformacionCC()
      txtOrdenCalidad.Text = String.Format("{0} {1} {2:0000}-{3:00000000}", _comprobante.Descripcion, _letra, _centroEmisor, _numeroOrdenCalidad)
      txtProducto.Text = If(_producto IsNot Nothing, String.Format("{0} - {1}", _producto.IdProducto, _producto.NombreProducto), String.Empty)
      txtEstado.Text = _estado.IdEstadoCalidad
      dtpFecha.Value = _fecha

      Dim _tit = GetColumnasVisiblesGrilla(ugOC)
      Dim dt = New Reglas.ComprasProductos().GetComprobantesOrdenControlCalidad(If(_producto IsNot Nothing, _producto.IdProducto, String.Empty))
      ugOC.DataSource = dt
      AjustarColumnasGrilla(ugOC, _tit)
      ugOC.AgregarFiltroEnLinea({"NombreProveedor", "NombreProducto", "ObservacionCompra"})
   End Sub
   Public Sub Aceptar()
      '-- Descarga el registro marcado.- ----------------------------

      '-- Valida antes de Aceptar.- ---------------------------------
      If ValidaAceptar() Then
         _DataCC = ugOC.FilaSeleccionada(Of DataRow)()
         Close(DialogResult.OK)
      End If
   End Sub
   Private Function ValidaAceptar() As Boolean
      If ugOC.ActiveRow Is Nothing Then
         ShowMessage("No seleccionó ningun Comprobante de Compra")
         ugOC.Focus()
         Return False
      End If
      Return True
   End Function

#End Region
End Class