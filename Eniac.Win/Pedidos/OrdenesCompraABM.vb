Option Strict On
Option Explicit On

Imports Infragistics.Win.UltraWinGrid

Public Class OrdenesCompraABM
#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      'No se permite agregar y borrar. El agregado se da desde la Importación de Pedidos.
      'tsbNuevo.Visible = False
      tsbBorrar.Visible = False

      'Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New OrdenesCompraDetalle(DirectCast(Me.GetEntidad(), Entidades.OrdenCompra))
      End If
      Return New OrdenesCompraDetalle(New Eniac.Entidades.OrdenCompra())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.OrdenesCompra()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With Me.dgvDatos.ActiveRow
         Return New Reglas.OrdenesCompra().GetUno(Integer.Parse(.Cells(Entidades.OrdenCompra.Columnas.IdSucursal.ToString()).Value.ToString()),
                                                  Integer.Parse(.Cells(Entidades.OrdenCompra.Columnas.NumeroOrdenCompra.ToString()).Value.ToString()),
                                                  True)
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
         Next
         Dim col As Integer = 0
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.OrdenCompra.Columnas.NumeroOrdenCompra.ToString()),
                                          "Id", col, 70, HAlign.Right)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Proveedor.Columnas.CodigoProveedor.ToString()),
                                          "Código", col, 70, HAlign.Right)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Proveedor.Columnas.NombreProveedor.ToString()),
                                          "Proveedor", col, 200)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.OrdenCompra.Columnas.IdFormasPago.ToString()),
                                          "Id F.P.", col, 70, HAlign.Right, True)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.VentaFormaPago.Columnas.DescripcionFormasPago.ToString()),
                                          "Forma de Pago", col, 200)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.OrdenCompra.Columnas.FechaPedidos.ToString()),
                                          "Fecha Pedidos", col, 80, HAlign.Center)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.OrdenCompra.Columnas.RespetaPreciosOrdenCompra.ToString()),
                                          "Respeta Precios", col, 80, HAlign.Center)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.OrdenCompra.Columnas.IdUsuario.ToString()),
                                          "Usuario", col, 100)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.OrdenCompra.Columnas.AplicaDescuentoRecargo.ToString()),
                                          "Aplica D/R", col, 80, HAlign.Center)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.OrdenCompra.Columnas.Anticipado.ToString()),
                                          "Anticipado", col, 80, HAlign.Center)

      End With
   End Sub

#End Region

End Class