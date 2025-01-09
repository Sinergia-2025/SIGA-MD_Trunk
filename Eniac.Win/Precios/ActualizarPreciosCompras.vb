Option Strict Off
<Obsolete("No se usa más. Se utiliza ActualizarPreciosV2", True)>
Public Class ActualizarPreciosCompras

   Private _movimientoDeCompra As Entidades.MovimientoStock
   Private _precios As List(Of Entidades.ProductoSucursal)
   Private _listasSelec As List(Of Entidades.ListaDePrecios)


   Public Sub New(ByVal movimientoDeCompra As Entidades.MovimientoStock)

      InitializeComponent()
      Me._movimientoDeCompra = movimientoDeCompra
      'Deberia sacar los productos que no cambian precio

      Me.dgvProductos.DataSource = Me._movimientoDeCompra.Productos

      Me.SeteoGrillaPrecios()

      Me.txtRedondeoPrecioVenta.Text = "2"
      Me.txtAjusteA.Text = "9"
      Me.chbAjusteA.Checked = Reglas.Publicos.ComprasActualizaPreciosUtilizaAjusteADecimales

      Me.tssRegistros.Text = Me.dgvProductos.RowCount.ToString() & " Registros"

   End Sub

#Region "Eventos"

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbActualizar.Click

      Try

         If Not Me.chbActualizarPCosto.Checked And Not Me.chbPrecioVenta.Checked Then
            MessageBox.Show("ATENCION: No Seleccionó que Precio quiere Actualizar (Costo y/o Venta) !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
         End If

         If MessageBox.Show("Usted esta por actualizar los precios de los productos. Esta seguro?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.BarraInicializa("Preparando grabación de datos...", 0, Me.dgvProductos.Rows.Count)
            Me.Cursor = Cursors.WaitCursor
            Me.CargarYGrabarPrecios()

            ' MessageBox.Show("Precios grabados con exito!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Me.Close()

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.BarraFinaliza()
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub chbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTodos.CheckedChanged

      Me.Cursor = Cursors.WaitCursor

      For Each dr As DataGridViewRow In Me.dgvProductos.Rows
         dr.Cells("Selec").Value = Me.chbTodos.Checked
      Next

      Me.Cursor = Cursors.Default

   End Sub

   Private Sub dgvProductos_CellClic(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellClick

      If e.ColumnIndex = 31 And e.RowIndex <> -1 Then
         Try
            If Me.dgvProductos.Rows(e.RowIndex).Cells("Selec").Value Is Nothing Then
               MessageBox.Show("Para modificar el Porcentaje a Aplicar debe seleccionar el Producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If
            If Not Boolean.Parse(Me.dgvProductos.Rows(e.RowIndex).Cells("Selec").Value.ToString()) Then
               MessageBox.Show("Para modificar el Porcentaje a Aplicar debe seleccionar el Producto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If

   End Sub

   Private Sub dgvProductos_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellLeave, dgvProductos.CellEndEdit, dgvProductos.CellClick

      Try
         If e.ColumnIndex = 32 And e.RowIndex <> -1 Then
            Dim Redondeo As Integer = Integer.Parse(Me.txtRedondeoPrecioVenta.Text)
            Dim precioVentaNuevo As Decimal = 0

            If Redondeo >= 2 And Not Me.chbAjusteA.Checked Then
               Redondeo = 4   'Al usuario le muestro 2 pero internamente calculo a 4.
            End If

            Dim porcentaje As Decimal
            porcentaje = (Me.dgvProductos.Rows(e.RowIndex).Cells("PorcRecarg").Value.ToString() / 100) + 1

            precioVentaNuevo = Decimal.Round((Decimal.Parse(Me.dgvProductos.Rows(e.RowIndex).Cells("PrecioCostoNuevo").Value.ToString()) * porcentaje), Redondeo)

            If Me.chbAjusteA.Checked And precioVentaNuevo > 0 Then
               'Si ajustamos a 0
               If Me.chbAjusteA.Checked And Integer.Parse(txtAjusteA.Text) = 0 Then
                  Dim PrecioTemporal As String = precioVentaNuevo.ToString("#,##0." + New String("0"c, Redondeo))
                  precioVentaNuevo = Decimal.Parse(Split(PrecioTemporal, ".")(0).Substring(0, Split(PrecioTemporal, ".")(0).Length() - 1) + txtAjusteA.Text)
               Else
                  Dim PrecioTemporal As String = precioVentaNuevo.ToString("#,##0." + New String("0"c, Redondeo))
                  precioVentaNuevo = Decimal.Parse(Strings.Mid(PrecioTemporal, 1, PrecioTemporal.Length() - 1) + txtAjusteA.Text)
               End If
            End If

            Me.dgvProductos.Rows(e.RowIndex).Cells("PrecioVentaNuevo").Value = precioVentaNuevo

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub dgvProductos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellContentClick
      If e.ColumnIndex = 0 And e.RowIndex <> -1 Then
         Me.dgvProductos.CommitEdit(DataGridViewDataErrorContexts.Display)
      End If
   End Sub

   'Private Sub chbPrecioVenta_CheckedChanged(sender As Object, e As EventArgs) Handles chbPrecioVenta.CheckedChanged
   '   Me.dgvProductos.Columns("PrecioVentaNuevo").ReadOnly = Not Me.chbPrecioVenta.Checked
   'End Sub

   Private Sub txtRedondeoPrecioVenta_Leave(sender As Object, e As EventArgs) Handles txtRedondeoPrecioVenta.Leave
      Try

         Dim precioVentaNuevo As Decimal = 0
         Dim Redondeo As Integer = Integer.Parse(Me.txtRedondeoPrecioVenta.Text)

         If Redondeo >= 2 And Not Me.chbAjusteA.Checked Then
            Redondeo = 4   'Al usuario le muestro 2 pero internamente calculo a 4.
         End If

         For Each dr As DataGridViewRow In Me.dgvProductos.Rows
            Dim porcentaje As Decimal
            porcentaje = (Decimal.Parse(dr.Cells("PorcRecarg").Value.ToString()) / 100) + 1

            precioVentaNuevo = Decimal.Round((Decimal.Parse(dr.Cells("PrecioCostoNuevo").Value.ToString()) * porcentaje), Redondeo)

            ' precioVentaNuevo = Decimal.Round(Decimal.Parse(dr.Cells("PrecioVentaNuevo").Value.ToString()), Redondeo)

            If Me.chbAjusteA.Checked And precioVentaNuevo > 0 Then
               'Si ajustamos a 0
               If Me.chbAjusteA.Checked And Integer.Parse(txtAjusteA.Text) = 0 Then
                  Dim PrecioTemporal As String = precioVentaNuevo.ToString("#,##0." + New String("0"c, Redondeo))
                  precioVentaNuevo = Decimal.Parse(Split(PrecioTemporal, ".")(0).Substring(0, Split(PrecioTemporal, ".")(0).Length() - 1) + txtAjusteA.Text)
               Else
                  Dim PrecioTemporal As String = precioVentaNuevo.ToString("#,##0." + New String("0"c, Redondeo))
                  precioVentaNuevo = Decimal.Parse(Strings.Mid(PrecioTemporal, 1, PrecioTemporal.Length() - 1) + txtAjusteA.Text)
               End If
            End If

            dr.Cells("PrecioVentaNuevo").Value = precioVentaNuevo

         Next
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub txtAjusteA_Leave(sender As Object, e As EventArgs) Handles txtAjusteA.Leave
      Try

         Dim precioVentaNuevo As Decimal = 0
         Dim Redondeo As Integer = Integer.Parse(Me.txtRedondeoPrecioVenta.Text)

         If Redondeo >= 2 And Not Me.chbAjusteA.Checked Then
            Redondeo = 4   'Al usuario le muestro 2 pero internamente calculo a 4.
         End If

         For Each dr As DataGridViewRow In Me.dgvProductos.Rows

            precioVentaNuevo = Decimal.Round(Decimal.Parse(dr.Cells("PrecioVentaNuevo").Value.ToString()), Redondeo)
            If Me.chbAjusteA.Checked And precioVentaNuevo > 0 Then
               'Si ajustamos a 0
               If Me.chbAjusteA.Checked And Integer.Parse(txtAjusteA.Text) = 0 Then
                  Dim PrecioTemporal As String = precioVentaNuevo.ToString("#,##0." + New String("0"c, Redondeo))
                  precioVentaNuevo = Decimal.Parse(Split(PrecioTemporal, ".")(0).Substring(0, Split(PrecioTemporal, ".")(0).Length() - 1) + txtAjusteA.Text)
               Else
                  Dim PrecioTemporal As String = precioVentaNuevo.ToString("#,##0." + New String("0"c, Redondeo))
                  precioVentaNuevo = Decimal.Parse(Strings.Mid(PrecioTemporal, 1, PrecioTemporal.Length() - 1) + txtAjusteA.Text)
               End If
            End If

            dr.Cells("PrecioVentaNuevo").Value = precioVentaNuevo

         Next
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub chbAjusteA_CheckedChanged(sender As Object, e As EventArgs) Handles chbAjusteA.CheckedChanged
      Try

         Dim precioVentaNuevo As Decimal = 0
         Dim Redondeo As Integer = Integer.Parse(Me.txtRedondeoPrecioVenta.Text)

         If Redondeo >= 2 And Not Me.chbAjusteA.Checked Then
            Redondeo = 4   'Al usuario le muestro 2 pero internamente calculo a 4.
         End If

         For Each dr As DataGridViewRow In Me.dgvProductos.Rows

            precioVentaNuevo = Decimal.Round(Decimal.Parse(dr.Cells("PrecioVentaNuevo").Value.ToString()), Redondeo)
            If Me.chbAjusteA.Checked And precioVentaNuevo > 0 Then
               'Si ajustamos a 0
               If Me.chbAjusteA.Checked And Integer.Parse(txtAjusteA.Text) = 0 Then
                  Dim PrecioTemporal As String = precioVentaNuevo.ToString("#,##0." + New String("0"c, Redondeo))
                  precioVentaNuevo = Decimal.Parse(Split(PrecioTemporal, ".")(0).Substring(0, Split(PrecioTemporal, ".")(0).Length() - 1) + txtAjusteA.Text)
               Else
                  Dim PrecioTemporal As String = precioVentaNuevo.ToString("#,##0." + New String("0"c, Redondeo))
                  precioVentaNuevo = Decimal.Parse(Strings.Mid(PrecioTemporal, 1, PrecioTemporal.Length() - 1) + txtAjusteA.Text)
               End If
            End If

            dr.Cells("PrecioVentaNuevo").Value = precioVentaNuevo

         Next
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

#Region "Métodos"

   Private Sub BarraInicializa(ByVal texto As String, ByVal valorInicial As Integer, ByVal maximoValor As Integer)
      Me.tspBarra.Visible = True
      Me.tspBarra.Maximum = maximoValor
      Me.tspBarra.Value = valorInicial
      Me.tssInfo.Text = texto
   End Sub

   Private Sub BarraFinaliza()
      Me.tssInfo.Text = String.Empty
      Me.tspBarra.Value = Me.tspBarra.Maximum
      Me.tspBarra.Visible = False
      Me.tspBarra.Value = 0
   End Sub

   Private Sub CargarYGrabarPrecios()

      Dim oProdS As Entidades.ProductoSucursal
      Dim oProdSP As Entidades.ProductoSucursalPrecio
      Dim precios As List(Of Entidades.ProductoSucursal) = New List(Of Entidades.ProductoSucursal)


      For Each dr As DataGridViewRow In Me.dgvProductos.Rows
         If dr.Cells("Selec").Value IsNot Nothing AndAlso Boolean.Parse(dr.Cells("Selec").Value.ToString()) Then
            If Me.CambiaronLosPrecios(dr) Then
               oProdS = New Entidades.ProductoSucursal()
               'Cargo los valores de la grilla al objeto productosSucursales
               With oProdS
                  .Producto.IdProducto = dr.Cells("IdProducto").Value.ToString.Trim()
                  .Sucursal.Id = Integer.Parse(dr.Cells("IdSucursal").Value.ToString())

                  .PrecioCosto = Decimal.Parse(dr.Cells("PrecioCostoNuevo").Value.ToString())


                  'Dim precioVentaNuevo As Decimal = 0
                  'Dim Redondeo As Integer = Integer.Parse(Me.txtRedondeoPrecioVenta.Text)

                  'If Redondeo >= 2 And Not Me.chbAjusteA.Checked Then
                  '    Redondeo = 4   'Al usuario le muestro 2 pero internamente calculo a 4.
                  'End If

                  'precioVentaNuevo = Decimal.Round(Decimal.Parse(dr.Cells("PrecioVentaNuevo").Value.ToString()), Redondeo)

                  'If Me.chbAjusteA.Checked And precioVentaNuevo > 0 Then
                  '    'Si ajustamos a 0
                  '    If Me.chbAjusteA.Checked And Integer.Parse(txtAjusteA.Text) = 0 Then
                  '        Dim PrecioTemporal As String = precioVentaNuevo.ToString("#,##0." + New String("0"c, Redondeo))
                  '        precioVentaNuevo = Decimal.Parse(Split(PrecioTemporal, ".")(0).Substring(0, Split(PrecioTemporal, ".")(0).Length() - 1) + txtAjusteA.Text)
                  '    Else
                  '        Dim PrecioTemporal As String = precioVentaNuevo.ToString("#,##0." + New String("0"c, Redondeo))
                  '        precioVentaNuevo = Decimal.Parse(Strings.Mid(PrecioTemporal, 1, PrecioTemporal.Length() - 1) + txtAjusteA.Text)
                  '    End If
                  'End If


                  ' .PrecioVenta = precioVentaNuevo

                  '.PrecioVenta = Decimal.Parse(dr.Cells("PrecioVentaNuevo").Value.ToString())

                  .Usuario = actual.Nombre

                  If Decimal.Parse(dr.Cells("PrecioO").Value.ToString()) > 0 And Decimal.Parse(dr.Cells("Precio").Value.ToString()) = 0 Then
                     If MessageBox.Show("El producto '" & dr.Cells("IdProducto").Value.ToString.Trim() & " - " & dr.Cells("NombreProducto").Value.ToString.Trim() & _
                                          "' tiene el precio de Costo Nuevo es 0 (cero) pero el Actual NO, continua en este caso y en los demas ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                        Return
                     End If

                  End If

                  oProdSP = New Entidades.ProductoSucursalPrecio()
                  oProdSP.ProductoSucursal = oProdS
                  oProdSP.IdSucursal = Integer.Parse(dr.Cells("IdSucursal").Value.ToString())
                  oProdSP.ListaDePrecios = New Reglas.ListasDePrecios().GetUno(0)

                  oProdSP.PrecioVenta = Decimal.Parse(dr.Cells("PrecioVentaNuevo").Value.ToString())

                  '  oProdSP.PrecioVenta = Decimal.Parse(dr.Cells(lis.NombreListaPrecios + "1").Value.ToString())
                  oProdSP.Usuario = Entidades.Usuario.Actual.Nombre
                  .Precios.Add(oProdSP)


                  If .PrecioCosto < 0 Then
                     MessageBox.Show("El producto '" & dr.Cells("IdProducto").Value.ToString.Trim() & " - " & dr.Cells("NombreProducto").Value.ToString.Trim() & _
                                          "' tiene el precio de Costo negativo, NO puede continuar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                     Return
                  End If


               End With
               'Agrego un precio a la lista
               precios.Add(oProdS)
            End If

            Me.tspBarra.Value += 1
         End If

      Next

      If precios.Count = 0 Then
         MessageBox.Show("ATENCION: NO Ajustó Ningun Precio.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Exit Sub
      End If

      Me._precios = precios

      Me.tssInfo.Text = "Grabando nuevos precios..."

      Me.GrabarPrecios()

      MessageBox.Show("Precios grabados con exito!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Me.Close()

   End Sub

   Private Sub GrabarPrecios()
      Try
         Dim oProdSucu As Reglas.ProductosSucursales = New Reglas.ProductosSucursales()

         'Envio a grabar el nuevo precio de Costo ----------------------------------------------!!!!!!!!!!!!!!!!!!!!!!!!!!!
         If Me.chbPrecioVenta.Checked Then
            oProdSucu.ModificarPrecioVenta(Me._precios)
         Else
            'For Each precio As Entidades.ProductoSucursal In Me._precios
            '   precio.PrecioVenta = 0
            'Next
         End If

         If Me.chbActualizarPCosto.Checked Then
            oProdSucu.ModificarPrecioCosto(Me._precios, IdFuncion)
         End If


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Function CambiaronLosPrecios(ByVal dr As DataGridViewRow) As Boolean


      If dr.Cells("Precio").Value Is Nothing Then
         dr.Cells("Precio").Value = "0.00"
      End If

      If Decimal.Parse(dr.Cells("PrecioO").Value.ToString()) <> Decimal.Parse(dr.Cells("Precio").Value.ToString()) Then
         Return True
      End If

      Return False
   End Function

   Private Sub SeteoGrillaPrecios()
      Dim _listasSelec As List(Of Entidades.ListaDePrecios)
      Dim oLista As Reglas.ListasDePrecios = New Reglas.ListasDePrecios()

      _listasSelec = oLista.GetTodos()

      For Each lis As Entidades.ListaDePrecios In _listasSelec
         If lis.IdListaPrecios <> 0 Then
            For Each col As DataGridViewColumn In Me.dgvProductos.Columns

               If col.Name = "Porc" & lis.IdListaPrecios Then
                  Me.dgvProductos.Columns(col.Name).HeaderText = "  %"
                  Me.dgvProductos.Columns(col.Name).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Me.dgvProductos.Columns(col.Name).ReadOnly = True
                  Me.dgvProductos.Columns(col.Name).Width = 50
                  Me.dgvProductos.Columns(col.Name).DefaultCellStyle.Format = "N2"
               End If

               If col.Name = lis.NombreListaPrecios Then
                  col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  col.DefaultCellStyle.Format = "N2"
                  col.Width = 65
                  col.ReadOnly = True
                  Dim col1 As DataGridViewColumn = New DataGridViewColumn(col.CellTemplate)
                  col1.Name = lis.NombreListaPrecios + "1"
                  col1.HeaderText = "Nuevo " + lis.NombreListaPrecios
                  col1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  col1.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(224, 224, 224)
                  col1.DefaultCellStyle.Format = "N2"
                  col1.Width = 65
                  Me.dgvProductos.Columns.Insert(col.Index + 1, col1)
                  'Me.dgvPrecios.Columns(col1.Name).SortMode = DataGridViewColumnSortMode.NotSortable
                  Me.dgvProductos.Columns(col1.Name).ReadOnly = True
                  Exit For
               End If
            Next
         End If
      Next

   End Sub


#End Region


End Class