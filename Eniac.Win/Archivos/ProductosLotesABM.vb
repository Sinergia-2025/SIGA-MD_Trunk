Imports Eniac.Win

Public Class ProductosLotesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ProductosLotesDetalle(DirectCast(Me.GetEntidad(), Entidades.ProductoSucursal))
      End If
      Return New ProductosLotesDetalle(New Entidades.ProductoSucursal())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ProductosLotes()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim produ As Entidades.ProductoLote = New Entidades.ProductoLote()
      With Me.dgvDatos.SelectedCells(0).OwningRow
         produ = New Reglas.ProductosLotes().GetUno(.Cells(Entidades.ProductoLote.Columnas.IdLote.ToString()).Value.ToString(), Int32.Parse(.Cells(Entidades.ProductoLote.Columnas.IdSucursal.ToString()).Value.ToString()), .Cells(Entidades.ProductoLote.Columnas.IdProducto.ToString()).Value.ToString())
      End With
      Return produ
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos
         .Columns("IdProducto").HeaderText = "Cód. Producto"
         .Columns("IdProducto").Width = 100
         .Columns("IdProducto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

         .Columns("NombreProducto").HeaderText = "Producto"
         .Columns("NombreProducto").Width = 270

         .Columns("IdSucursal").Visible = False

         .Columns("NombreSucursal").HeaderText = "Sucursal"
         .Columns("NombreSucursal").Width = 150

         .Columns("PrecioFabrica").HeaderText = "Precio Compra"
         .Columns("PrecioFabrica").Width = 60
         .Columns("PrecioFabrica").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

         .Columns("PrecioCosto").HeaderText = "Precio Costo"
         .Columns("PrecioCosto").Width = 60
         .Columns("PrecioCosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

         .Columns("PrecioVenta").HeaderText = "Precio Venta"
         .Columns("PrecioVenta").Width = 60
         .Columns("PrecioVenta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

         .Columns("Stock").HeaderText = "Stock"
         .Columns("Stock").Width = 60
         .Columns("Stock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

         .Columns("FechaActualizacion").HeaderText = "Fecha Actualización"
         .Columns("FechaActualizacion").Width = 80
         .Columns("FechaActualizacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

         .Columns("CalculaPreciosSegunFormula").HeaderText = "Calcula Precios Segun Formula"
         .Columns("CalculaPreciosSegunFormula").Width = 80
         .Columns("CalculaPreciosSegunFormula").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

      End With
   End Sub

#End Region

End Class
