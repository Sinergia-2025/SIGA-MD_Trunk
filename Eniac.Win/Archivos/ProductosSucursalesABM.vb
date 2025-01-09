Public Class ProductosSucursalesABM

#Region "Campos"

   Private _CantidadSucursales As Integer
   Private _MostrarCosto As Boolean

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Me.tsbNuevo.Visible = False
      Me.tsbBorrar.Visible = False
      Me.tsbImprimir.Visible = False

      Me._CantidadSucursales = New Reglas.Sucursales().GetAll.Rows.Count()
      Me.dgvDatos.DisplayLayout.Bands(0).Columns("NombreSucursal").Hidden = Not (Me._CantidadSucursales > 1)

      'Seguridad del campo Precio de Costo
      Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
      Me._MostrarCosto = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ConsultarPrecios-PrecioCosto")
      Me.dgvDatos.DisplayLayout.Bands(0).Columns("PrecioCosto").Hidden = Not Me._MostrarCosto

   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ProductosSucursalesDetalle(DirectCast(Me.GetEntidad(), Entidades.ProductoSucursal))
      End If
      Return New ProductosSucursalesDetalle(New Entidades.ProductoSucursal)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ProductosSucursales()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.ProductosSucursales.rdlc", "SistemaDataSet_Productos", Me.dtDatos, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = "Productos Sucursales"
         frmImprime.Show()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim produ As Entidades.ProductoSucursal = New Entidades.ProductoSucursal
      With Me.dgvDatos.ActiveCell.Row
         produ = New Reglas.ProductosSucursales().GetUno(Integer.Parse(.Cells("IdSucursal").Value.ToString()), .Cells("IdProducto").Value.ToString().Trim())
      End With
      Return produ
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns("NombreSucursal").Header.Caption = "Sucursal"
         .Columns("NombreSucursal").Width = 120
         .Columns("NombreSucursal").Header.VisiblePosition = 0

         .Columns("IdProducto").Header.Caption = "Cód. Producto"
         .Columns("IdProducto").Width = 100
         .Columns("IdProducto").CellAppearance.TextHAlign = HAlign.Right
         .Columns("IdProducto").Header.VisiblePosition = 1

         .Columns("NombreProducto").Header.Caption = "Producto"
         .Columns("NombreProducto").Width = 250
         '.Columns("NombreProducto").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
         '.Columns("IdMarca").HeaderText = "Marca"
         '.Columns("IdMarca").Width = 50
         .Columns("IdMarca").Hidden = True
         .Columns("NombreMarca").Header.Caption = "Nombre Marca"
         .Columns("NombreMarca").Width = 140
         '.Columns("IdRubro").HeaderText = "Rubro"
         '.Columns("IdRubro").Width = 50
         .Columns("IdRubro").Hidden = True
         .Columns("NombreRubro").Header.Caption = "Nombre Rubro"
         .Columns("NombreRubro").Width = 140
         .Columns("IdSucursal").Hidden = True
         '.Columns("NombreSucursal").Visible = (Me._CantidadSucursales > 1)
         .Columns("PrecioFabrica").Hidden = True
         '.Columns("PrecioFabrica").HeaderText = "Precio Compra"
         '.Columns("PrecioFabrica").Width = 60
         '.Columns("PrecioFabrica").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns("PrecioCosto").Header.Caption = "P.Costo"
         .Columns("PrecioCosto").Width = 60
         .Columns("PrecioCosto").CellAppearance.TextHAlign = HAlign.Right
         .Columns("PrecioCosto").Format = "N2"
         .Columns("PrecioVentaLista").Header.Caption = "P.Venta"
         .Columns("PrecioVentaLista").Width = 60
         .Columns("PrecioVentaLista").CellAppearance.TextHAlign = HAlign.Right
         .Columns("PrecioVentaLista").Format = "N2"


         Dim FormatoNumerico As String = If(Reglas.Publicos.ProductoUtilizaCantidadesEnteras, "N0", "N2")

         .Columns("StockInicial").Hidden = True
         .Columns("Stock").Header.Caption = "Stock"
         .Columns("Stock").Width = 60
         .Columns("Stock").CellAppearance.TextHAlign = HAlign.Right
         .Columns("Stock").Format = FormatoNumerico

         .Columns("PuntoDePedido").Header.Caption = "Punto de Pedido"
         .Columns("PuntoDePedido").Width = 60
         .Columns("PuntoDePedido").CellAppearance.TextHAlign = HAlign.Right
         .Columns("PuntoDePedido").Format = FormatoNumerico

         .Columns("StockMinimo").Header.Caption = "Stock Minimo"
         .Columns("StockMinimo").Width = 60
         .Columns("StockMinimo").CellAppearance.TextHAlign = HAlign.Right
         .Columns("StockMinimo").Format = FormatoNumerico

         .Columns("StockMaximo").Header.Caption = "Stock Maximo"
         .Columns("StockMaximo").Width = 60
         .Columns("StockMaximo").CellAppearance.TextHAlign = HAlign.Right
         .Columns("StockMaximo").Format = FormatoNumerico

         .Columns("FechaActualizacion").Header.Caption = "Fecha Actualización"
         .Columns("FechaActualizacion").Width = 100
         .Columns("FechaActualizacion").CellAppearance.TextHAlign = HAlign.Center
         .Columns("FechaActualizacion").Format = "dd/MM/yyyy HH:mm"

         .Columns("Usuario").Hidden = True
      End With
   End Sub

#End Region

End Class