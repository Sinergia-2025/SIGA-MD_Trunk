Option Strict On
Option Explicit On
Imports Infragistics.Win.UltraWinGrid

Public Class ProductosCalidadABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False

   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ProductosCalidadDetalle(DirectCast(Me.GetEntidad(), Entidades.Producto))
      End If
      Return New ProductosCalidadDetalle(New Eniac.Entidades.Producto())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.Productos()
   End Function

   Protected Overrides Function GetAll(rg As Reglas.Base) As DataTable
      Return DirectCast(rg, Reglas.Productos).GetProductosCalidad()
   End Function

   Protected Overrides Function Buscar(rg As Reglas.Base, bus As Entidades.Buscar) As DataTable
      Return DirectCast(rg, Reglas.Productos).Buscar(bus)
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With Me.dgvDatos.ActiveRow
         Return New Reglas.Productos().GetUno(.Cells(Entidades.Producto.Columnas.IdProducto.ToString()).Value.ToString().Trim())
      End With
   End Function

   Protected Overrides Sub Borrar()
      Try
         If Me.dgvDatos.ActiveCell Is Nothing Then
            If Me.dgvDatos.ActiveRow IsNot Nothing Then
               Me.dgvDatos.ActiveCell = Me.dgvDatos.ActiveRow.Cells(0)
            End If
         End If
         If Me.dgvDatos.ActiveCell IsNot Nothing Then
            Me._entidad = Me.GetEntidad()
            If Not ValidaBorrado(_entidad) Then Exit Sub
            If ConfirmarBorrado() = Windows.Forms.DialogResult.Yes Then
               Dim cl As Reglas.Productos = New Reglas.Productos()
               Dim Cliente As DataTable = New Reglas.ProductosClientes().GetClientexProducto(DirectCast(Me._entidad, Entidades.Producto).IdProducto)
               Dim _idCliente As Long = 0
               If Cliente.Rows.Count > 0 Then
                  _idCliente = Long.Parse(Cliente.Rows(0).Item("IdCliente").ToString())
               End If
               cl.EliminarCalidad(DirectCast(Me._entidad, Entidades.Producto), _idCliente)
               Me.RefreshGrid()
            End If
         End If
      Catch ex As Exception
         If ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint") Then
            MessageBox.Show("El registro NO se puede eliminar porque esta siendo utilizado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      End Try
   End Sub
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)

         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next

         Ayudante.Grilla.AgregarFiltroEnLinea(dgvDatos, {Entidades.Producto.Columnas.IdProducto.ToString()})
         Ayudante.Grilla.AgregarFiltroEnLinea(dgvDatos, {Entidades.Producto.Columnas.NombreProducto.ToString()})
         Ayudante.Grilla.AgregarFiltroEnLinea(dgvDatos, {Entidades.Cliente.Columnas.CodigoCliente.ToString()})
         Ayudante.Grilla.AgregarFiltroEnLinea(dgvDatos, {Entidades.Cliente.Columnas.NombreCliente.ToString()})
         Ayudante.Grilla.AgregarFiltroEnLinea(dgvDatos, {Entidades.Cliente.Columnas.NombreDeFantasia.ToString()})

         Dim col As Integer = 0

         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.IdProducto.ToString()),
                                          "Código", col, 100, HAlign.Left)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadNroCarroceria.ToString()),
                                                  "Número de Carrocería", col, 80)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.NombreProductoTipoServicio.ToString()),
                                                 "Tipo de Servicio", col, 100)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.NombreProducto.ToString()),
                                          "Nombre", col, 200)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.NombreProductoModelo.ToString()),
                          "Modelo", col, 150)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadNumeroChasis.ToString()),
                                                  "Número de Chasis", col, 130)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadNroDeMotor.ToString()),
                               "Nro. de Motor", col, 80, HAlign.Center)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()),
                                                   "Cliente", col, 60)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()),
                                                      "Nombre Cliente", col, 200)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()),
                                          "Nombre Fantasia", col, 200)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadStatusLiberado.ToString()),
                                          "Status Liberado", col, 80)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadFechaLiberado.ToString()),
                                                   "Fecha Liberado", col, 80, HAlign.Center)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadUserLiberado.ToString()),
                                                   "Usuario Liberado", col, 80)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadStatusLiberadoPDI.ToString()),
                                          "Status Liberado PDI", col, 80)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadFechaLiberadoPDI.ToString()),
                                                   "Fecha Liberado PDI", col, 80, HAlign.Center)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadUserLiberadoPDI.ToString()),
                                                   "Usuario Liberado PDI", col, 80)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadStatusEntregado.ToString()),
                                                   "Status Entregado", col, 80)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadFechaEntregado.ToString()),
                                                   "Fecha Entregado", col, 80, HAlign.Center)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadUserEntregado.ToString()),
                                                   "Usuario Entregado", col, 80)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadFechaIngreso.ToString()),
                                                   "Fecha Ingreso", col, 80, HAlign.Center)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadFechaEgreso.ToString()),
                                                   "Fecha Egreso", col, 80, HAlign.Center)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadNroCertificado.ToString()),
                                                   "Certificado", col, 100)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadFecCertificado.ToString()),
                                                   "Fecha Certificado", col, 80, HAlign.Center)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadUsrCertificado.ToString()),
                                               "Usuario Certificado", col, 80)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadObservaciones.ToString()),
                                           "Observaciones", col, 250)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadFechaEntProg.ToString()),
                                           "Fecha Ent. Programada", col, 80, HAlign.Center)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadFechaEntReProg.ToString()),
                                         "Fecha Ent. Reprogramada", col, 80, HAlign.Center)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadFechaEntregado.ToString()),
                                  "Fecha Entrega", col, 80, HAlign.Center)

         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadNroCertEntregado.ToString()),
                                                   "Certificado Entrega", col, 100)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadFecCertEntregado.ToString()),
                                                   "Fecha Certificado Entrega", col, 80, HAlign.Center)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadUsrCertEntregado.ToString()),
                                               "Usuario Certificado Entrega", col, 80)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadNroCertEObs.ToString()),
                                               "Observación Certificado Entrega", col, 100)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Producto.Columnas.CalidadNroRemito.ToString()),
                                      "Nro de Remito Certificado Entrega", col, 100)
         'Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ProductoSucursal.Columnas.Ubicacion.ToString()),
         '                      "Ubicación", col, 80, HAlign.Center)

      End With
   End Sub

#End Region
End Class