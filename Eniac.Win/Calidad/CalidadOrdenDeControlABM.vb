Public Class CalidadOrdenDeControlABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CalidadOrdenDeControlDetalle(DirectCast(GetEntidad(), Entidades.CalidadOrdenDeControl))
      Else
         Return New CalidadOrdenDeControlDetalle(New Entidades.CalidadOrdenDeControl())
      End If
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CalidadOrdenDeControl()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)
      Return New Reglas.CalidadOrdenDeControl().GetUno(dr.Field(Of Integer)(Entidades.CalidadOrdenDeControl.Columnas.IdSucursal.ToString()),
                                                       dr.Field(Of String)(Entidades.CalidadOrdenDeControl.Columnas.IdTipoComprobante.ToString()),
                                                       dr.Field(Of String)(Entidades.CalidadOrdenDeControl.Columnas.Letra.ToString()),
                                                       dr.Field(Of Integer)(Entidades.CalidadOrdenDeControl.Columnas.CentroEmisor.ToString()),
                                                       dr.Field(Of Long)(Entidades.CalidadOrdenDeControl.Columnas.NumeroComprobante.ToString()))
   End Function
   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I
         .OcultaTodasLasColumnas()

         .Columns(Entidades.CalidadOrdenDeControl.Columnas.IdSucursal.ToString()).FormatearColumna("Suc", pos, 40, HAlign.Right)
         .Columns(Entidades.CalidadOrdenDeControl.Columnas.IdTipoComprobante.ToString()).FormatearColumna("Código Comprobante", pos, 120, , hidden:=True)
         .Columns("DescripcionComprobante").FormatearColumna("Comprobante", pos, 120)
         .Columns(Entidades.CalidadOrdenDeControl.Columnas.Letra.ToString()).FormatearColumna("L", pos, 60, HAlign.Center)
         .Columns(Entidades.CalidadOrdenDeControl.Columnas.CentroEmisor.ToString()).FormatearColumna("Emisor", pos, 80, HAlign.Right)
         .Columns(Entidades.CalidadOrdenDeControl.Columnas.NumeroComprobante.ToString()).FormatearColumna("Número", pos, 80, HAlign.Right)

         .Columns("NombreProveedor").FormatearColumna("Proveedor", pos, 120)
         .Columns(Entidades.CalidadOrdenDeControl.Columnas.Fecha.ToString()).FormatearColumna("Fecha", pos, 80, HAlign.Center)
         .Columns("NombreProducto").FormatearColumna("Producto", pos, 120)
         .Columns(Entidades.CalidadOrdenDeControl.Columnas.CantidadControlar.ToString()).FormatearColumna("Cantidad", pos, 80, HAlign.Right, , "N2")
         .Columns(Entidades.CalidadOrdenDeControl.Columnas.IdLote.ToString()).FormatearColumna("Lote", pos, 80)
         .Columns("NombreDeposito").FormatearColumna("Deposito", pos, 120)
         .Columns("NombreUbicacion").FormatearColumna("Ubicacion", pos, 120)
         .Columns(Entidades.CalidadOrdenDeControl.Columnas.IdEstadoCalidad.ToString()).FormatearColumna("Estado", pos, 120, HAlign.Center)

         .Columns(Entidades.CalidadOrdenDeControl.Columnas.IdSucursal.ToString()).FormatearColumna("S.C.", pos, 40, HAlign.Right, hidden:=True)
         .Columns(Entidades.CalidadOrdenDeControl.Columnas.IdTipoComprobanteCompra.ToString()).FormatearColumna("Código Comprobante Compra", pos, 120, , hidden:=True)
         .Columns("DescripcionComprobanteCompra").FormatearColumna("Comprobante Comrpa", pos, 120)
         .Columns(Entidades.CalidadOrdenDeControl.Columnas.LetraCompra.ToString()).FormatearColumna("L.C.", pos, 60, HAlign.Center)
         .Columns(Entidades.CalidadOrdenDeControl.Columnas.CentroEmisorCompra.ToString()).FormatearColumna("Emisor Compra", pos, 80, HAlign.Right)
         .Columns(Entidades.CalidadOrdenDeControl.Columnas.NumeroComprobanteCompra.ToString()).FormatearColumna("Número Compra", pos, 80, HAlign.Right)
         .Columns(Entidades.CalidadOrdenDeControl.Columnas.OrdenComprobanteCompra.ToString()).FormatearColumna("Línea Compra", pos, 80, HAlign.Right)

         .Columns(Entidades.CalidadOrdenDeControl.Columnas.Observaciones.ToString()).FormatearColumna("Observaciones", pos, 300)

         .Columns("NombreUsuarioAlta").FormatearColumna("Usuario Alta", pos, 120)
         .Columns(Entidades.CalidadOrdenDeControl.Columnas.FechaAlta.ToString()).FormatearColumna("Fecha Alta", pos, 100, HAlign.Center, , Formatos.Format.FechaCompleta)
         .Columns("NombreUsuarioActualizacion").FormatearColumna("Usuario Actualización", pos, 120)
         .Columns(Entidades.CalidadOrdenDeControl.Columnas.FechaActualizacion.ToString()).FormatearColumna("Fecha Actualización", pos, 100, HAlign.Center, , Formatos.Format.FechaCompleta)

         dgvDatos.AgregarFiltroEnLinea({"NombreProveedor", "NombreProducto", "IdLote", "Observaciones"})
      End With

   End Sub

#End Region
End Class