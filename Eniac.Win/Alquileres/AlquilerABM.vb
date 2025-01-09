Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Win

Public Class AlquilerABM

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Dim frmDetalle As New AlquilerDetalle(DirectCast(Me.GetEntidad(), Entidades.Alquiler))
         Return frmDetalle
      End If
      Return New AlquilerDetalle(New Entidades.Alquiler)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Alquileres()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad

      Dim Alquiler As Entidades.Alquiler = New Entidades.Alquiler
      Dim Alquileres As Reglas.Alquileres = New Reglas.Alquileres

      With Me.dgvDatos.SelectedCells(0).OwningRow
         Alquiler = Alquileres.GetUna(actual.Sucursal.IdSucursal, Long.Parse(.Cells(Entidades.Alquiler.Columnas.NumeroContrato.ToString()).Value.ToString()))
      End With

      Return Alquiler

   End Function

   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos

         .Columns(Entidades.Alquiler.Columnas.IdSucursal.ToString()).Visible = False
         .Columns(Entidades.Alquiler.Columnas.horaE.ToString()).Visible = False
         .Columns(Entidades.Alquiler.Columnas.horaR.ToString()).Visible = False
         .Columns(Entidades.Alquiler.Columnas.LugarER.ToString()).Visible = False
         .Columns(Entidades.Alquiler.Columnas.PersonalCapacitado.ToString()).Visible = False
            .Columns(Entidades.Alquiler.Columnas.IdCliente.ToString()).Visible = False

         .Columns(Entidades.Alquiler.Columnas.NumeroContrato.ToString()).HeaderText = "Numero"
         .Columns(Entidades.Alquiler.Columnas.NumeroContrato.ToString()).Width = 60
         .Columns(Entidades.Alquiler.Columnas.NumeroContrato.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

         .Columns(Entidades.Alquiler.Columnas.FechaContrato.ToString()).HeaderText = "Fecha Contrato"
         .Columns(Entidades.Alquiler.Columnas.FechaContrato.ToString()).Width = 70
         .Columns(Entidades.Alquiler.Columnas.FechaContrato.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

         .Columns(Entidades.Alquiler.Columnas.IdProducto.ToString()).Visible = False
         .Columns(Entidades.Alquiler.Columnas.NombreProducto.ToString()).HeaderText = "Producto - Marca - Modelo - Nro. Serie"
         .Columns(Entidades.Alquiler.Columnas.NombreProducto.ToString()).Width = 500
         '.Columns(Entidades.Alquiler.Columnas.NombreProducto.ToString()).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

         .Columns(Entidades.Alquiler.Columnas.FechaDesde.ToString()).HeaderText = "Fecha Desde"
         .Columns(Entidades.Alquiler.Columnas.FechaDesde.ToString()).Width = 70
         .Columns(Entidades.Alquiler.Columnas.FechaDesde.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

         .Columns(Entidades.Alquiler.Columnas.FechaHasta.ToString()).HeaderText = "Fecha Hasta"
         .Columns(Entidades.Alquiler.Columnas.FechaHasta.ToString()).Width = 70
         .Columns(Entidades.Alquiler.Columnas.FechaHasta.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

         .Columns(Entidades.Alquiler.Columnas.esRenovable.ToString()).HeaderText = "Renov."
         .Columns(Entidades.Alquiler.Columnas.esRenovable.ToString()).Width = 50

         .Columns(Entidades.Alquiler.Columnas.NombreCliente.ToString()).HeaderText = "Cliente"
         .Columns(Entidades.Alquiler.Columnas.NombreCliente.ToString()).Width = 200

         .Columns(Entidades.Alquiler.Columnas.LocatarioNroDocumento.ToString()).Visible = False
         .Columns(Entidades.Alquiler.Columnas.LocatarioNombre.ToString()).HeaderText = "Locatario Nombre"
         .Columns(Entidades.Alquiler.Columnas.LocatarioNombre.ToString()).Width = 200
         .Columns(Entidades.Alquiler.Columnas.LocatarioCargo.ToString()).Visible = False

         .Columns(Entidades.Alquiler.Columnas.ImporteAlquiler.ToString()).HeaderText = "Alquiler"
         .Columns(Entidades.Alquiler.Columnas.ImporteAlquiler.ToString()).Width = 70
         .Columns(Entidades.Alquiler.Columnas.ImporteAlquiler.ToString()).DefaultCellStyle.Format = "N2"
         .Columns(Entidades.Alquiler.Columnas.ImporteAlquiler.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

         .Columns(Entidades.Alquiler.Columnas.ImporteTraslado.ToString()).HeaderText = "Traslado"
         .Columns(Entidades.Alquiler.Columnas.ImporteTraslado.ToString()).Width = 70
         .Columns(Entidades.Alquiler.Columnas.ImporteTraslado.ToString()).DefaultCellStyle.Format = "N2"
         .Columns(Entidades.Alquiler.Columnas.ImporteTraslado.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

         .Columns(Entidades.Alquiler.Columnas.ImporteTotal.ToString()).HeaderText = "Total"
         .Columns(Entidades.Alquiler.Columnas.ImporteTotal.ToString()).Width = 70
         .Columns(Entidades.Alquiler.Columnas.ImporteTotal.ToString()).DefaultCellStyle.Format = "N2"
         .Columns(Entidades.Alquiler.Columnas.ImporteTotal.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

         .Columns(Entidades.Alquiler.Columnas.IdEstado.ToString()).Visible = False
         .Columns(Entidades.Alquiler.Columnas.NombreEstado.ToString()).HeaderText = "Estado"
         .Columns(Entidades.Alquiler.Columnas.NombreEstado.ToString()).Width = 70

         .Columns(Entidades.Alquiler.Columnas.FechaRealFin.ToString()).HeaderText = "Fin Real"
         .Columns(Entidades.Alquiler.Columnas.FechaRealFin.ToString()).Width = 70
         .Columns(Entidades.Alquiler.Columnas.FechaRealFin.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

         .Columns(Entidades.Alquiler.Columnas.IdUsuario.ToString()).HeaderText = "Usuario"
         .Columns(Entidades.Alquiler.Columnas.IdUsuario.ToString()).Width = 75

         .Columns(Entidades.Alquiler.Columnas.IdTipoComprobante.ToString()).HeaderText = "Comprobante"
         .Columns(Entidades.Alquiler.Columnas.IdTipoComprobante.ToString()).Width = 80

         .Columns(Entidades.Alquiler.Columnas.Letra.ToString()).HeaderText = "Let."
         .Columns(Entidades.Alquiler.Columnas.Letra.ToString()).Width = 30
         .Columns(Entidades.Alquiler.Columnas.Letra.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

         .Columns(Entidades.Alquiler.Columnas.CentroEmisor.ToString()).HeaderText = "Emisor"
         .Columns(Entidades.Alquiler.Columnas.CentroEmisor.ToString()).Width = 40
         .Columns(Entidades.Alquiler.Columnas.CentroEmisor.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

         .Columns(Entidades.Alquiler.Columnas.NumeroComprobante.ToString()).HeaderText = "Numero"
         .Columns(Entidades.Alquiler.Columnas.NumeroComprobante.ToString()).Width = 55
         .Columns(Entidades.Alquiler.Columnas.NumeroComprobante.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

      End With

   End Sub

   Protected Overrides Sub RefreshGrid()
      Try
         Dim rg As Reglas.Alquileres = DirectCast(Me.GetReglas(), Reglas.Alquileres)
         If Not Me.tstBuscar.Tag Is Nothing And Me.tstBuscar.Text <> "" Then
            Dim bus As Entidades.Buscar = New Entidades.Buscar
            bus.IdSucursal = Entidades.Usuario.Actual.Sucursal.Id
            bus.Columna = Me.tstBuscar.Tag.ToString()
            bus.Valor = Me.tstBuscar.Text.Trim()
            Me.dtDatos = rg.Buscar(bus)
         Else
            Me.dtDatos = rg.GetAll2(Entidades.Usuario.Actual.Sucursal.Id)
         End If
         Me.dgvDatos.DataSource = Me.dtDatos
         If Not Me.dtDatos Is Nothing Then
            Me.FormatearGrilla()
         End If
         If Me.dgvDatos.Rows.Count > 1 Then
            Me.tssRegistros.Text = Me.dgvDatos.Rows.Count & " Registros"
         Else
            Me.tssRegistros.Text = Me.dgvDatos.Rows.Count & " Registro"
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Sub Borrar()
      Try
         If Me.dgvDatos.SelectedCells.Count > 0 Then
            If MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Dim cl As Reglas.Base = Me.GetReglas()
               Me._entidad = Me.GetEntidad()

               If Not String.IsNullOrEmpty(DirectCast(Me._entidad, Entidades.Alquiler).IdTipoComprobante) Then

                  Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
                  Dim oVenta As Entidades.Venta

                  oVenta = oVentas.GetUna(actual.Sucursal.Id, _
                                          DirectCast(Me._entidad, Entidades.Alquiler).IdTipoComprobante, _
                                          DirectCast(Me._entidad, Entidades.Alquiler).Letra, _
                                          DirectCast(Me._entidad, Entidades.Alquiler).CentroEmisor, _
                                          DirectCast(Me._entidad, Entidades.Alquiler).NumeroComprobante)

                  If Not String.IsNullOrEmpty(oVenta.IdEstadoComprobante) AndAlso oVenta.IdEstadoComprobante <> "ANULADO" Then
                     MessageBox.Show("No se puede eliminar porque el " & DirectCast(Me._entidad, Entidades.Alquiler).IdTipoComprobante & " tiene estado '" & oVenta.IdEstadoComprobante & "'", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                     Exit Sub
                  End If

               End If

               cl.Borrar(Me._entidad)

               'oVentas.EliminarComprobantes()

               Me.RefreshGrid()
            End If
         End If
      Catch ex As Exception
         If ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint") Then
            MessageBox.Show("No se puede eliminar porque esta siendo utilizado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      End Try
   End Sub

End Class