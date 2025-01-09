
Imports Eniac.Entidades

Public Class ProductosSeleccionLoteMultiple
#Region "Campos"
   Private _publicos As Publicos
   Private _Producto As Entidades.NovedadProduccionMRPProducto
   Public Property novLote As ListConBorrados(Of Entidades.NovedadProduccionMRPProductoLote)
   Public Property _prodNecesario As Boolean
#End Region

#Region "New"
   Private Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(oprProducto As Entidades.NovedadProduccionMRPProducto)
      Me.New()
      _Producto = oprProducto
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()
            '---------------------------------------------------------------------------------------------
            LimpiaEntidadesNovedad()
            '---------------------------------------------------------------------------------------------
            chbLoteExistente.Checked = _prodNecesario
            chbLoteExistente.Enabled = Not _prodNecesario
            '---------------------------------------------------------------------------------------------
            bscLote.Visible = _prodNecesario
            txtLoteExistente.Visible = Not _prodNecesario
            If _prodNecesario Then
               bscLote.Focus()
            Else
               txtLoteExistente.Select()
            End If
            '---------------------------------------------------------------------------------------------
            CargaLotes()
         End Sub)
   End Sub
#End Region

#Region "Metodos"
   Private Sub CargaLotes()
      If _Producto.ProductosLotes.Count > 0 Then
         novLote = _Producto.ProductosLotes
         '-- Refresca los Datos de la Grilla.- ---------------------
         ugDetalle.DataSource = novLote
         ugDetalle.Rows.Refresh(RefreshRow.FireInitializeRow)
         '-- Formate Grilla.- --------------------------------------
         FormateGrillaLotes()
         LimpiaCampos()
      End If
   End Sub
   Private Sub InsertarProductoLote()
      Dim oLineaL = New Entidades.NovedadProduccionMRPProductoLote
      With oLineaL
         .CodigoOperacion = _Producto.CodigoOperacion
         .IdProducto = _Producto.IdProducto
         .EsProductoNecesario = _Producto.EsProductoNecesario
         .IdLote = If(chbLoteExistente.Checked, bscLote.Text, txtLoteExistente.Text)
         .Cantidad = Decimal.Parse(txtCantidad.Text)
      End With
      novLote.Add(oLineaL)
      '-- Refresca los Datos de la Grilla.- ---------------------
      ugDetalle.Rows.Refresh(RefreshRow.FireInitializeRow)
      '-- Formate Grilla.- --------------------------------------
      FormateGrillaLotes()
      LimpiaCampos()
   End Sub
#End Region

#Region "Formateo de Grillas"
   Private Sub FormateGrillaLotes()
      ugDetalle.Rows.Refresh(RefreshRow.ReloadData)
      With ugDetalle.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         '-- Oculta las Columnas.- -------------------------
         .OcultaTodasLasColumnas()
         '-- Formatea las Columnas.- -------------------------
         .Columns("IdLote").FormatearColumna("Lote", pos, 80, HAlign.Center)
         .Columns("Cantidad").FormatearColumna("Cantidad", pos, 80, HAlign.Right,, "N4")
      End With


   End Sub
#End Region

#Region "Limpieza Campos"
   Private Sub LimpiaEntidadesNovedad()
      novLote = New ListConBorrados(Of Entidades.NovedadProduccionMRPProductoLote)
      '-- Refresca los Datos de la Grilla.- ---------------------
      ugDetalle.DataSource = novLote
      ugDetalle.Rows.Refresh(RefreshRow.FireInitializeRow)
      '-- Formate Grilla.- --------------------------------------
      FormateGrillaLotes()
   End Sub

   Private Sub LimpiaCampos()
      bscLote.Text = String.Empty
      txtLoteExistente.Text = String.Empty
      txtCantidad.Text = "0.00"
      bscLote.Select()
   End Sub
#End Region

#Region "Eventos"
   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      TryCatched(
         Sub()
            If chbLoteExistente.Checked Then
               If Not bscLote.Selecciono Then
                  ShowMessage("Debe ingresar un Id de Lote!!!.")
                  bscLote.Select()
                  Exit Sub
               End If
            Else
               If String.IsNullOrEmpty(txtLoteExistente.Text) Then
                  ShowMessage("Debe ingresar un Id de Lote!!!.")
                  txtLoteExistente.Select()
                  Exit Sub
               End If
            End If
            If Decimal.Parse(txtCantidad.Text) <= 0 Then
               ShowMessage("La cantidad debe ser mayor a Cero.")
               txtCantidad.Select()
               Exit Sub
            End If
            InsertarProductoLote()
            LimpiaCampos()
         End Sub)
   End Sub
   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Dim opr = ugDetalle.FilaSeleccionada(Of NovedadProduccionMRPProductoLote)
      If opr IsNot Nothing Then
         If ShowPregunta(String.Format("¿Desea eliminar el Lote {0}", opr.IdLote)) = Windows.Forms.DialogResult.Yes Then
            novLote.Remove(opr)
            ugDetalle.Rows.Refresh(RefreshRow.FireInitializeRow)
            FormateGrillaLotes()
            bscLote.Focus()
         End If
      End If
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(Sub()
                    With _Producto
                       .ProductosLotes = novLote
                       .CantidadInformada = novLote.Sum(Function(x) x.Cantidad)
                    End With
                    Close(DialogResult.OK)
                 End Sub)
   End Sub

   Private Sub bscLote_BuscadorClick() Handles bscLote.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaLotes(bscLote)
         bscLote.Datos = New Reglas.ProductosLotes().GetPorProducto(actual.Sucursal.IdSucursal, _Producto.IdDeposito, _Producto.IdUbicacion, _Producto.IdProducto, bscLote.Text)
      End Sub)
   End Sub
   Private Sub bscLote_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscLote.BuscadorSeleccion
      TryCatched(
      Sub()
         If Not e.FilaDevuelta Is Nothing Then
            bscLote.Text = e.FilaDevuelta.Cells("IdLote").Value.ToString()
            txtCantidad.Focus()
         End If
      End Sub)
   End Sub

   Private Sub chbLoteExistente_CheckedChanged(sender As Object, e As EventArgs) Handles chbLoteExistente.CheckedChanged
      bscLote.Visible = chbLoteExistente.Checked
      txtLoteExistente.Visible = Not chbLoteExistente.Checked
      If _prodNecesario Then
         bscLote.Focus()
      Else
         txtLoteExistente.Select()
      End If
   End Sub
#End Region
End Class