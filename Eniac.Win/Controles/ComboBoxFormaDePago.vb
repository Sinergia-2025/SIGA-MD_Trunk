Public Class ComboBoxFormaDePago
   Inherits ComboBoxMultipleSeleccion

   Private _listaVentaFormaPago As List(Of Entidades.VentaFormaPago)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean

   Private _tipo As String
   Private _esContado As Boolean?

   Public Sub New()
      MyBase.New()
      _listaVentaFormaPago = New List(Of Entidades.VentaFormaPago)()
   End Sub

   Public Function GetVentasFormaPagos() As Entidades.VentaFormaPago()
      Return GetVentasFormaPagos(True)
   End Function
   Public Function GetVentasFormaPagos(todosVacio As Boolean) As Entidades.VentaFormaPago()
      If SelectedValue IsNot Nothing AndAlso SelectedValue.Equals(Convert.ToInt32(Entidades.VentaFormaPago.ValoresFijosIdFormasPago.Todos)) Then
         If todosVacio Then Return {}
         Return MFFormasDePago.GetTodos(_tipo, _esContado).ToArray()
      End If
      If _listaVentaFormaPago.Count = 1 AndAlso _listaVentaFormaPago(0) Is Nothing Then Return {}
      Return _listaVentaFormaPago.ToArray()
   End Function



   Public Sub Inicializar(tipo As String, Optional esContado As Boolean? = Nothing)
      Inicializar(True, True, True, tipo, Nothing)
   End Sub
   Public Sub Inicializar(permiteSinSeleccion As Boolean, tipo As String, Optional esContado As Boolean? = Nothing)
      Inicializar(permiteSinSeleccion, True, True, tipo, Nothing)
   End Sub
   Public Sub Inicializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean, tipo As String, Optional esContado As Boolean? = Nothing)

      _tipo = tipo
      _esContado = esContado

      ctxMenu = New System.Windows.Forms.ContextMenuStrip(components)
      ctxMenu.Name = "ctxMenu"
      ctxMenu.Text = "Filtros guardados"

      _seleccionMultiple = seleccionMultiple
      _seleccionTodos = seleccionTodos
      _publicos = New Publicos()
      _publicos.CargaComboFormaDePago(Me, tipo, esContado, seleccionMultiple, seleccionTodos)

      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaVentaFormaPago.Clear()
      _listaVentaFormaPago.Add(DirectCast(SelectedItem, Entidades.VentaFormaPago))

      If seleccionMultiple Then
         ContextMenuStrip = ctxMenu
      End If

      CargarOpcionesContextuales()

   End Sub

   Public Sub Refrescar()
      SelectedValue = Convert.ToInt32(Entidades.VentaFormaPago.ValoresFijosIdFormasPago.Todos)
   End Sub

   Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
      MyBase.OnSelectedIndexChanged(e)

      If _initialized And Enabled Then
         If SelectedIndex > -1 Then
            Using filtromultiple As New MFFormasDePago(_permiteSinSeleccion, _tipo, _esContado)
               If SelectedValue.Equals(Convert.ToInt32(Entidades.VentaFormaPago.ValoresFijosIdFormasPago.SeleccionMultiple)) Then
                  If _listaVentaFormaPago IsNot Nothing AndAlso _listaVentaFormaPago.Count > 0 AndAlso _listaVentaFormaPago(0) IsNot Nothing Then
                     If _listaVentaFormaPago.Any() AndAlso _listaVentaFormaPago(0).IdFormasPago.Equals(Convert.ToInt32(Entidades.VentaFormaPago.ValoresFijosIdFormasPago.Todos)) Then
                        filtromultiple.Filtros.AddRange(MFFormasDePago.GetTodos(_tipo, _esContado))
                     Else
                        filtromultiple.Filtros.AddRange(_listaVentaFormaPago)
                     End If
                  End If
                  filtromultiple.ShowDialog()
                  _listaVentaFormaPago.Clear()
                  If filtromultiple.Filtros.Count = 0 Then

                     SelectedIndex = -1
                  Else
                     _listaVentaFormaPago.AddRange(filtromultiple.Filtros)
                  End If
                  If _listaVentaFormaPago.Count = 1 Then
                     SelectedValue = _listaVentaFormaPago(0).IdFormasPago
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaVentaFormaPago.Clear()
                  _listaVentaFormaPago.Add(DirectCast(SelectedItem, Entidades.VentaFormaPago))
               End If
               CargarOpcionesContextuales()
            End Using
         End If
      End If
   End Sub

   Public Sub CargarFiltrosImpresionTiposComprobantes(filtro As System.Text.StringBuilder, muestraId As Boolean, muestraNombre As Boolean)
      If SelectedIndex > -1 AndAlso Enabled Then
         With filtro
            Dim tiposDeFormaPagos As Entidades.VentaFormaPago() = GetVentasFormaPagos()
            Dim formato As String = ""
            If muestraId And muestraNombre Then formato = "{0} - {1}"
            If muestraId And Not muestraNombre Then formato = "{0}"
            If Not muestraId And muestraNombre Then formato = "{1}"
            If Not muestraId And Not muestraNombre Then formato = ""
            If SelectedValue.Equals(Convert.ToInt32(Entidades.VentaFormaPago.ValoresFijosIdFormasPago.Todos)) Then
               .AppendFormat("Forma de Pago: {0}", Publicos.GetEnumString(Entidades.VentaFormaPago.ValoresFijosIdFormasPago.Todos))
            Else
               If tiposDeFormaPagos.Count = 1 Then
                  .AppendFormat("Forma de Pago: ").AppendFormat(formato, tiposDeFormaPagos(0).IdFormasPago, tiposDeFormaPagos(0).DescripcionFormasPago)
               ElseIf tiposDeFormaPagos.Count > 1 Then
                  .AppendFormat("Forma de Pago: ")
                  Dim primera As Boolean = True
                  For Each tpCom As Entidades.VentaFormaPago In tiposDeFormaPagos
                     If Not primera Then .AppendFormat(", ")
                     .AppendFormat(formato, tpCom.IdFormasPago, tpCom.DescripcionFormasPago)
                     primera = False
                  Next
               End If
            End If
            .AppendFormat(" ")
         End With
      End If
   End Sub

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFFormasDePago.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm As MFFormasDePago = New MFFormasDePago(_permiteSinSeleccion)
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaVentaFormaPago.Clear()
            SelectedValue = Convert.ToInt32(Entidades.VentaFormaPago.ValoresFijosIdFormasPago.SeleccionMultiple)
            _listaVentaFormaPago.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub
End Class