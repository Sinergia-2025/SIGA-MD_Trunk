Public Class VehiculosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      tsbImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New VehiculosDetalle(DirectCast(GetEntidad(), Entidades.Vehiculo))
      End If
      Return New VehiculosDetalle(New Entidades.Vehiculo())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Vehiculos()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim Vehiculo = New Entidades.Vehiculo()
      With Me.dgvDatos.ActiveRow
         Vehiculo = New Reglas.Vehiculos().GetUno((.Cells("PatenteVehiculo").Value.ToString()))
      End With
      Return Vehiculo
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim col = 0I

         '-- Visibiliza columnas.- ---
         .Columns(Entidades.Vehiculo.Columnas.PatenteVehiculo.ToString()).FormatearColumna("Patente", col, 80, HAlign.Right)
         .Columns(Entidades.MarcaVehiculo.Columnas.NombreMarcaVehiculo.ToString()).FormatearColumna("Marca", col, 200, HAlign.Left)
         .Columns(Entidades.ModeloVehiculo.Columnas.NombreModeloVehiculo.ToString()).FormatearColumna("Modelo", col, 200)

         .Columns(Entidades.Vehiculo.Columnas.AnioPatentamiento.ToString()).FormatearColumna("Año", col, 50)

         .Columns(Entidades.Vehiculo.Columnas.IdTipoUnidad.ToString()).OcultoPosicion(hidden:=True, col)
         .Columns(Entidades.ConcesionarioTipoUnidad.columnas.NombreTipoUnidad.ToString()).FormatearColumna("Tipo", col, 100)
         .Columns(Entidades.Vehiculo.Columnas.SubTipoUnidad.ToString()).FormatearColumna("Unidad", col, 100)

         .Columns(Entidades.Vehiculo.Columnas.Color.ToString()).FormatearColumna("Color", col, 80)
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).FormatearColumna("Nombre Cliente", col, 180, HAlign.Left)
         .Columns(Entidades.Vehiculo.Columnas.VencimientoSeguro.ToString()).FormatearColumna("Venc. Seguro", col, 120)
         .Columns(Entidades.Vehiculo.Columnas.IdEstadoVehiculo.ToString()).OcultoPosicion(hidden:=True, col)
         .Columns(Entidades.EstadoVehiculo.Columnas.NombreEstadoVehiculo.ToString()).FormatearColumna("Estado", col, 80)
         .Columns(Entidades.Vehiculo.Columnas.Activo.ToString()).FormatearColumna("Activo", col, 80)

         .Columns(Entidades.Vehiculo.Columnas.MedidasVehiculo.ToString()).FormatearColumna("Medidas", col, 80)
         .Columns(Entidades.Vehiculo.Columnas.LlantasVehiculo.ToString()).FormatearColumna("Llantas", col, 80)
         .Columns(Entidades.Vehiculo.Columnas.AuxilioVehiculo.ToString()).FormatearColumna("Auxilio", col, 80)
         .Columns(Entidades.Vehiculo.Columnas.NeumaticosVehiculo.ToString()).FormatearColumna("Neumáticos", col, 80)
         .Columns(Entidades.Vehiculo.Columnas.OtrosVehiculo.ToString()).FormatearColumna("Sapitos / Tornillos / Ruedas", col, 80)

         .Columns(Entidades.Vehiculo.Columnas.IdentificacionVehiculo.ToString()).FormatearColumna("Identificación", col, 80)
         .Columns(Entidades.Vehiculo.Columnas.ObservacionesVehiculo.ToString()).FormatearColumna("Observaciones", col, 150)
         .Columns(Entidades.Vehiculo.Columnas.LlantasVehiculo.ToString()).FormatearColumna("Llantas", col, 80)

         .Columns(Entidades.Vehiculo.Columnas.IdMarcaOperacionIngreso.ToString()).OcultoPosicion(hidden:=True, col)
         .Columns(Entidades.Vehiculo.Columnas.AnioOperacionIngreso.ToString()).OcultoPosicion(hidden:=True, col)
         .Columns(Entidades.Vehiculo.Columnas.NumeroOperacionIngreso.ToString()).OcultoPosicion(hidden:=True, col)
         .Columns(Entidades.Vehiculo.Columnas.SecuenciaOperacionIngreso.ToString()).OcultoPosicion(hidden:=True, col)
         .Columns("CodigoOperacionIngreso").FormatearColumna("Operación Ingreso", col, 150)

         .Columns(Entidades.Vehiculo.Columnas.PrecioCompra.ToString()).FormatearColumna("P. Compra", col, 80, HAlign.Right, , "N2")
         .Columns(Entidades.Vehiculo.Columnas.PrecioReferencia.ToString()).FormatearColumna("P. Referencia", col, 80, HAlign.Right, , "N2")
         .Columns(Entidades.Vehiculo.Columnas.IdProductoReferencia.ToString()).OcultoPosicion(hidden:=True, col)
         .Columns(Entidades.Producto.Columnas.NombreProducto.ToString()).FormatearColumna("Producto Referencia", col, 200)
         .Columns(Entidades.Vehiculo.Columnas.PrecioLista.ToString()).FormatearColumna("P. Lista", col, 80, HAlign.Right, , "N2")


         '-- Oculta columnas.- ---
         '.Columns(Entidades.Cliente.Columnas.IdCliente.ToString()).Hidden = True
         .Columns(Entidades.Vehiculo.Columnas.IdMarcaVehiculo.ToString()).Hidden = True
         .Columns(Entidades.Vehiculo.Columnas.IdModeloVehiculo.ToString()).Hidden = True
         .Columns(Entidades.Vehiculo.Columnas.Ruta.ToString()).Hidden = True
         .Columns(Entidades.Vehiculo.Columnas.Vtv.ToString()).Hidden = True
         .Columns(Entidades.Vehiculo.Columnas.EstaAdentro.ToString()).Hidden = True
         '------------------------
      End With

      dgvDatos.AgregarFiltroEnLinea({Entidades.Vehiculo.Columnas.PatenteVehiculo.ToString(),
                                     Entidades.Cliente.Columnas.NombreCliente.ToString(),
                                     Entidades.Vehiculo.Columnas.ObservacionesVehiculo.ToString(),
                                     Entidades.Producto.Columnas.NombreProducto.ToString()})

   End Sub

#End Region

End Class