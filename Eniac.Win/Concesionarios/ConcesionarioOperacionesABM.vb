Public Class ConcesionarioOperacionesABM
#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      'Me.tsbImprimir.Visible = False
   End Sub

   'GET DETALLE
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ConcesionarioOperacionesDetalle(DirectCast(GetEntidad(), Entidades.ConcesionarioOperacion))
      End If
      Return New ConcesionarioOperacionesDetalle(New Entidades.ConcesionarioOperacion())

   End Function

   'GET REGLAS
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ConcesionarioOperaciones()
   End Function

   'GET ENTIDAD
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)()
      If dr IsNot Nothing Then
         Return New Reglas.ConcesionarioOperaciones().GetUno(dr.Field(Of Integer)(Entidades.ConcesionarioOperacion.Columnas.IdMarca.ToString()),
                                                             dr.Field(Of Integer)(Entidades.ConcesionarioOperacion.Columnas.AnioOperacion.ToString()),
                                                             dr.Field(Of Integer)(Entidades.ConcesionarioOperacion.Columnas.NumeroOperacion.ToString()),
                                                             dr.Field(Of Integer)(Entidades.ConcesionarioOperacion.Columnas.SecuenciaOperacion.ToString()))
      Else
         Return New Entidades.ConcesionariosAdicionales()
      End If
   End Function
   'FORMATEAR GRILLA
   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim col = 0I

         If Not .Columns.Exists("btnVer") Then
            .Columns.Add("btnVer", "Ver")
         End If

         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         .Columns("btnVer").FormatearColumna("Ver", col, 30).Style = UltraWinGrid.ColumnStyle.Button
         .Columns("btnVer").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always

         .Columns(Entidades.ConcesionarioOperacion.Columnas.IdMarca.ToString()).FormatearColumna("Código Marca", col, 80, HAlign.Right, hidden:=True)
         .Columns(Entidades.Marca.Columnas.NombreMarca.ToString()).FormatearColumna("Marca", col, 80, hidden:=True)
         .Columns(Entidades.ConcesionarioOperacion.Columnas.AnioOperacion.ToString()).FormatearColumna("Año", col, 40, HAlign.Right, hidden:=True)
         .Columns(Entidades.ConcesionarioOperacion.Columnas.NumeroOperacion.ToString()).FormatearColumna("Número", col, 60, HAlign.Right, hidden:=True)
         .Columns(Entidades.ConcesionarioOperacion.Columnas.SecuenciaOperacion.ToString()).FormatearColumna("Sec", col, 40, HAlign.Right, hidden:=True)
         .Columns(Entidades.ConcesionarioOperacion.Columnas.CodigoOperacion.ToString()).FormatearColumna("Operación", col, 120)

         .Columns(Entidades.ConcesionarioOperacion.Columnas.FechaOperacion.ToString()).FormatearColumna("Fecha", col, 80, HAlign.Center, , "dd/MM/yyyy")

         .Columns(Entidades.ConcesionarioOperacion.Columnas.IdCliente.ToString()).FormatearColumna("Id Cliente", col, 80, , hidden:=True)
         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()).FormatearColumna("Código Cliente", col, 80, HAlign.Right)
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).FormatearColumna("Cliente", col, 200)
         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).FormatearColumna("Nombre de Fantasia", col, 200, , hidden:=True)

         .Columns(Entidades.ConcesionarioOperacion.Columnas.TipoOperacion.ToString()).FormatearColumna("Tipo Operación", col, 80, , hidden:=True)

         .Columns(Entidades.ConcesionarioOperacion.Columnas.IdProductoCeroKilometro.ToString()).FormatearColumna("Código Producto", col, 80, , hidden:=True)
         .Columns(Entidades.Producto.Columnas.NombreProducto.ToString()).FormatearColumna("Producto 0 Km", col, 200)

         .Columns(Entidades.ConcesionarioOperacion.Columnas.CantidadCeroKilometro.ToString()).FormatearColumna("Cantidad 0 Km", col, 80, HAlign.Right, , "N0")
         .Columns(Entidades.ConcesionarioOperacion.Columnas.PrecioCeroKilometro.ToString()).FormatearColumna("Precio 0 Km", col, 80, HAlign.Right, , "N2")
         .Columns(Entidades.ConcesionarioOperacion.Columnas.ImporteCeroKilometro.ToString()).FormatearColumna("Importe 0 Km", col, 80, HAlign.Right, , "N2")

         .Columns(Entidades.ConcesionarioOperacion.Columnas.PatenteVehiculoUsado.ToString()).FormatearColumna("Patente Usado", col, 80)
         .Columns(Entidades.ConcesionarioOperacion.Columnas.PrecioListaUsado.ToString()).FormatearColumna("Precio Lista", col, 80, HAlign.Right, , "N0")
         .Columns(Entidades.ConcesionarioOperacion.Columnas.ImporteUsado.ToString()).FormatearColumna("Importe", col, 80, HAlign.Right, , "N2")

         .Columns(Entidades.ConcesionarioOperacion.Columnas.IdTipoUnidadCeroKilometro.ToString()).FormatearColumna("Id Tipo Unidad", col, 80, , hidden:=True)
         .Columns(Entidades.ConcesionarioTipoUnidad.columnas.NombreTipoUnidad.ToString()).FormatearColumna("Tipo Unidad", col, 120)
         .Columns(Entidades.ConcesionarioOperacion.Columnas.IdSubTipoUnidadCeroKilometro.ToString()).FormatearColumna("Id Sub Tipo Unidad", col, 80, , hidden:=True)
         .Columns(Entidades.ConcesionarioSubTipoUnidad.columnas.NombreSubTipoUnidad.ToString()).FormatearColumna("Sub Tipo Unidad", col, 120)
         .Columns(Entidades.ConcesionarioOperacion.Columnas.IdEjeCeroKilometro.ToString()).FormatearColumna("Id Distrib. Ejes", col, 80, , hidden:=True)
         .Columns(Entidades.ConcesionarioDistribucionEje.columnas.NombreEje.ToString()).FormatearColumna("Distrib. Ejes", col, 120)
         .Columns(Entidades.ConcesionarioOperacion.Columnas.CaracteristicaAdicionalCeroKilometro.ToString()).FormatearColumna("Datos Adicionales", col, 120)


         .Columns(Entidades.ConcesionarioOperacion.Columnas.ImporteTotalAdicionales.ToString()).FormatearColumna("Importe Adicionales", col, 80, HAlign.Right, , "N2")
         .Columns(Entidades.ConcesionarioOperacion.Columnas.ImporteTotalCaracteristicas.ToString()).FormatearColumna("Importe Características", col, 80, HAlign.Right, , "N2")
         .Columns(Entidades.ConcesionarioOperacion.Columnas.ImporteTotal.ToString()).FormatearColumna("Importe Total", col, 80, HAlign.Right, , "N2")

         .Columns(Entidades.ConcesionarioOperacion.Columnas.CotizacionDolar.ToString()).FormatearColumna("Cot. Dolar", col, 80, HAlign.Right, , "N4")


         .Columns(Entidades.ConcesionarioOperacion.Columnas.LargoCeroKilometro.ToString()).FormatearColumna("Largo", col, 100)
         .Columns(Entidades.ConcesionarioOperacion.Columnas.AltoCargaCeroKilometro.ToString()).FormatearColumna("Alto Carga", col, 100)
         .Columns(Entidades.ConcesionarioOperacion.Columnas.AltoPuertaLateralCeroKilometro.ToString()).FormatearColumna("Alto Puerta Lateral", col, 100)

         .Columns(Entidades.ConcesionarioOperacion.Columnas.ColorCarroceriaCeroKilometro.ToString()).FormatearColumna("Color Carroceria", col, 100)
         .Columns(Entidades.ConcesionarioOperacion.Columnas.ColorZocaloCeroKilometro.ToString()).FormatearColumna("Color Zocalo", col, 100)
         .Columns(Entidades.ConcesionarioOperacion.Columnas.ColorBaseCeroKilometro.ToString()).FormatearColumna("Color Base", col, 100)

         .Columns(Entidades.ConcesionarioOperacion.Columnas.PuertaTraseraCeroKilometro.ToString()).FormatearColumna("Puerta Trasera", col, 100)
         .Columns(Entidades.ConcesionarioOperacion.Columnas.ParanteCeroKilometro.ToString()).FormatearColumna("Parante", col, 100)
         .Columns(Entidades.ConcesionarioOperacion.Columnas.PisoCeroKilometro.ToString()).FormatearColumna("Piso", col, 100)
         .Columns(Entidades.ConcesionarioOperacion.Columnas.MarcoCeroKilometro.ToString()).FormatearColumna("Marco", col, 100)
         .Columns(Entidades.ConcesionarioOperacion.Columnas.HerrajeCeroKilometro.ToString()).FormatearColumna("Herraje", col, 100)

         .Columns(Entidades.ConcesionarioOperacion.Columnas.OtrasObservacionesCeroKilometro.ToString()).FormatearColumna("Otras Observaciones", col, 150)

         .Columns(Entidades.ConcesionarioOperacion.Columnas.ImportePesos.ToString()).FormatearColumna("Pesos", col, 80, HAlign.Right, , "N2")
         .Columns(Entidades.ConcesionarioOperacion.Columnas.ImporteTarjetas.ToString()).FormatearColumna("Tarjetas", col, 80, HAlign.Right, , "N2")
         .Columns(Entidades.ConcesionarioOperacion.Columnas.ImporteCheques.ToString()).FormatearColumna("Cheques", col, 80, HAlign.Right, , "N2")
         .Columns(Entidades.ConcesionarioOperacion.Columnas.ImporteTransferencia.ToString()).FormatearColumna("Transferencia", col, 80, HAlign.Right, , "N2")
         .Columns("NombreBanco").FormatearColumna("Banco", col, 120)
         .Columns(Entidades.ConcesionarioOperacion.Columnas.IdCuentaBancaria.ToString()).FormatearColumna("Id Cuenta Bancaria", col, 80, , hidden:=True)
         .Columns(Entidades.CuentaBancaria.Columnas.NombreCuenta.ToString()).FormatearColumna("Cuenta Bancaria", col, 120)
         .Columns(Entidades.CuentaBancaria.Columnas.CodigoBancario.ToString()).FormatearColumna("Código Bancaria", col, 120, , hidden:=True)
         .Columns(Entidades.ConcesionarioOperacion.Columnas.FechaTransferencia.ToString()).FormatearColumna("Fecha Transferencia", col, 80, HAlign.Center, , "dd/MM/yyyy")

      End With

      dgvDatos.AgregarFiltroEnLinea({Entidades.Cliente.Columnas.NombreCliente.ToString(),
                                     Entidades.Cliente.Columnas.NombreDeFantasia.ToString(),
                                     Entidades.Producto.Columnas.NombreProducto.ToString(),
                                     Entidades.ConcesionarioOperacion.Columnas.OtrasObservacionesCeroKilometro.ToString()})

   End Sub

#End Region

   Private Sub dgvDatos_ClickCellButton(sender As Object, e As CellEventArgs) Handles dgvDatos.ClickCellButton
      TryCatched(
         Sub()
            If dgvDatos.ActiveRow IsNot Nothing Then
               If e.Cell.Column.Key = "btnVer" Then
                  Dim op = DirectCast(GetEntidad(), Entidades.ConcesionarioOperacion)
                  Dim imp = New ImprimirConcesionarioOperaciones()
                  imp.Ver(op)
               End If
            End If
         End Sub)
   End Sub

End Class