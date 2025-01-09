Imports Eniac.Entidades

Public Class SeleccionDeLote

   Private _idProducto As String
   Private _idDeposito As Integer
   Private _idUbicacion As Integer
   Private _loteCargado As String
   Private _publicos As Publicos
   Private _cantidad As Decimal
   Private _CoefStock As Integer
   Private _Compra As Boolean

   Private _InformeCalidad As Boolean

   Private _InformeNumero As String
   Private _InformeLink As String


   Private _loteSolicitaDespachoImportacion As Boolean
   Private _loteSolicitaFechaVencimiento As Boolean

   Public Sub New(idProducto As String, idDeposito As Integer, idUbicacion As Integer, cantidad As Decimal,
                  CoeficienteStock As Integer, Compra As Boolean, loteCargado As String, informeCalidad As Boolean,
                  informeNumero As String, informeLink As String)
      InitializeComponent()

      _idProducto = idProducto
      _idDeposito = idDeposito
      _idUbicacion = idUbicacion

      _InformeCalidad = informeCalidad
      _InformeNumero = informeNumero
      _InformeLink = informeLink

      _loteCargado = loteCargado
      _cantidad = cantidad
      _CoefStock = CoeficienteStock
      _Compra = Compra
      _publicos = New Publicos()

      _loteSolicitaFechaVencimiento = Reglas.Publicos.LoteSolicitaFechaVencimiento
      dtpFechaVencimiento.Visible = _loteSolicitaFechaVencimiento
      lblFechaVencimiento.Visible = _loteSolicitaFechaVencimiento

      _loteSolicitaDespachoImportacion = Publicos.LoteSolicitaDespachoImportacion
      grpOrigen.Visible = _Compra And _loteSolicitaDespachoImportacion

      pnlInformeCalidad.Visible = _InformeCalidad
      txtInformeCalidad.Text = _InformeNumero
      txtLinkdoc.Text = _InformeLink
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         dtpFechaVencimiento.Enabled = _Compra

         If Not String.IsNullOrEmpty(_loteCargado) Then
            bscLote.Text = _loteCargado
            btnAceptar.Focus()
         Else
            bscLote.Focus()
         End If
      End Sub)
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(
      Sub()
         If Not _Compra Then
            If bscLote.Selecciono Then
               Dim lot = New Entidades.ProductoLote()
               lot = New Reglas.ProductosLotes().GetUno(_idProducto, bscLote.Text, actual.Sucursal.IdSucursal, _idDeposito, _idUbicacion)

               If _CoefStock > 0 Then
                  Dim cantADescontar = lot.CantidadInicial - lot.CantidadActual
                  If _cantidad > cantADescontar Then
                     ShowMessage("La cantidad a devolver es mayor a la del lote.")
                     Exit Sub
                  End If
               Else
                  If lot.CantidadActual < _cantidad Then
                     ShowMessage("La cantidad ingresada es mayor a la cantidad del lote.")
                     Exit Sub
                  End If
               End If

               DialogResult = DialogResult.OK
               Close()


            Else
               If Not _Compra Then
                  ShowMessage("Debe seleccionar un lote.")
               End If
            End If
         Else
            If bscLote.Text.Trim() = "" Then
               ShowMessage("El Lote no puede estar vacio.")
               bscLote.Focus()
               Exit Sub
            End If
            DialogResult = DialogResult.OK
            Close()
         End If
      End Sub)
   End Sub

   Private Sub bscLote_BuscadorClick() Handles bscLote.BuscadorClick
      TryCatched(
      Sub()
         If _Compra And _loteSolicitaDespachoImportacion Then
            _publicos.PreparaGrillaLotesDespacho(bscLote)
            bscLote.Datos = New Reglas.Compras().GetDespachosPorCodigo(actual.Sucursal.IdSucursal, bscLote.Text)
         Else
            _publicos.PreparaGrillaLotes(bscLote)
            bscLote.Datos = New Reglas.ProductosLotes().GetPorProducto(actual.Sucursal.IdSucursal, _idDeposito, _idUbicacion, _idProducto, bscLote.Text)
         End If
      End Sub)
   End Sub

   Private Sub bscLote_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscLote.BuscadorSeleccion
      TryCatched(
      Sub()
         If Not e.FilaDevuelta Is Nothing Then
            If _Compra And _loteSolicitaDespachoImportacion Then
               bscLote.Text = e.FilaDevuelta.Cells("Despacho").Value.ToString()
               btnAceptar.Focus()
            Else
               bscLote.Text = e.FilaDevuelta.Cells("IdLote").Value.ToString()
               If Not String.IsNullOrWhiteSpace(e.FilaDevuelta.Cells("FechaVencimiento").Value.ToString()) Then
                  dtpFechaVencimiento.Value = Date.Parse(e.FilaDevuelta.Cells("FechaVencimiento").Value.ToString())
               End If
               btnAceptar.Focus()
            End If
         End If
      End Sub)
   End Sub

   Private Sub radImprotacion_CheckedChanged(sender As Object, e As EventArgs) Handles radImprotacion.CheckedChanged
      TryCatched(
      Sub()
         If radImprotacion.Checked Then
            bscLote.Enabled = True
            bscLote.Text = String.Empty
         Else
            bscLote.Enabled = False
            bscLote.Text = String.Format("ARG-{0:yyyy-MM-dd}", Today)
      End If
      End Sub)
   End Sub

   Private Sub radImprotacion_KeyDown(sender As Object, e As KeyEventArgs) Handles radNacional.KeyDown, radImprotacion.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
      DialogoAbrirArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop

      If DialogoAbrirArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            Dim fileInfo = New IO.FileInfo(DialogoAbrirArchivo.FileName)
            If fileInfo.Exists Then
               txtLinkdoc.Text = DialogoAbrirArchivo.FileName
               txtLinkdoc.Focus()
            Else
               ShowMessage(String.Format("No se puede acceder al archivo '{0}'.", DialogoAbrirArchivo.FileName))
            End If
         Catch Ex As Exception
            ShowMessage(String.Format("ATENCION: No se puede leer el Archivo. Error: {0}", Ex.Message))
         End Try
      End If
   End Sub
End Class