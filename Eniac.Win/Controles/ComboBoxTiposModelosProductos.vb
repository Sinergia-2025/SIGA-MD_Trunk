Public Class ComboBoxTiposModelosProductos
   Inherits ComboBoxMultipleSeleccion

   Private _listaTiposModelos As List(Of Entidades.ProductoModeloTipo)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean

   Private _tipo1 As String
   Private _tipo2 As String

   Public Sub New()
      MyBase.New()
      _listaTiposModelos = New List(Of Entidades.ProductoModeloTipo)()
   End Sub

   Public Function GetTiposModelos() As Entidades.ProductoModeloTipo()
      Return GetTiposModelos(True)
   End Function
   Public Function GetTiposModelos(todosVacio As Boolean) As Entidades.ProductoModeloTipo()
      If SelectedValue IsNot Nothing AndAlso SelectedValue.Equals(Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()) Then
         If todosVacio Then Return {}
         Return MFTipoModelo.GetTodos().ToArray()
      End If
      If _listaTiposModelos.Count = 1 AndAlso _listaTiposModelos(0) Is Nothing Then Return {}
      Return _listaTiposModelos.ToArray()
   End Function

   'Public Sub Initializar(MiraPC As Boolean,
   '                       Tipo1 As String,
   '                       Optional Tipo2 As String = "",
   '                       Optional AfectaCaja As String = "",
   '                       Optional UsaFacturacionRapida As String = "",
   '                       Optional UsaFacturacion As Boolean = False)
   '   Initializar(True, MiraPC, Tipo1, Tipo2, AfectaCaja, UsaFacturacionRapida, UsaFacturacion)
   'End Sub
   'Public Sub Initializar(permiteSinSeleccion As Boolean,
   '                       MiraPC As Boolean,
   '                       Tipo1 As String,
   '                       Optional Tipo2 As String = "",
   '                       Optional AfectaCaja As String = "",
   '                       Optional UsaFacturacionRapida As String = "",
   '                       Optional UsaFacturacion As Boolean = False)
   '   Initializar(permiteSinSeleccion, True, True)
   'End Sub
   Public Sub Initializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean)


      ctxMenu = New System.Windows.Forms.ContextMenuStrip(components)
      ctxMenu.Name = "ctxMenu"
      ctxMenu.Text = "Filtros guardados"

      _seleccionMultiple = seleccionMultiple
      _seleccionTodos = seleccionTodos
      _publicos = New Publicos()
      _publicos.CargaComboTiposModelosMultiple(Me, seleccionMultiple, seleccionTodos)

      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaTiposModelos.Clear()
      _listaTiposModelos.Add(DirectCast(SelectedItem, Entidades.ProductoModeloTipo))

      If seleccionMultiple Then
         ContextMenuStrip = ctxMenu
      End If

      CargarOpcionesContextuales()

   End Sub

   Public Sub Refrescar()
      SelectedIndex = -1
   End Sub

   Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
      MyBase.OnSelectedIndexChanged(e)

      If _initialized And Enabled Then
         If SelectedIndex > -1 Then
            Using filtromultiplecomprobantes As New MFTipoModelo(_permiteSinSeleccion)
               If SelectedValue.Equals(Convert.ToInt32(Entidades.ProductoModeloTipo.ValoresFijosIdProductoModeloTipo.SeleccionMultiple).ToString()) Then
                  If _listaTiposModelos IsNot Nothing AndAlso _listaTiposModelos.Count > 0 AndAlso _listaTiposModelos(0) IsNot Nothing Then
                     If _listaTiposModelos(0).IdProductoModeloTipo.Equals(Convert.ToInt32(Entidades.ProductoModeloTipo.ValoresFijosIdProductoModeloTipo.Todos).ToString()) Then
                        filtromultiplecomprobantes.Filtros.AddRange(MFTipoModelo.GetTodos())
                     Else
                        filtromultiplecomprobantes.Filtros.AddRange(_listaTiposModelos)
                     End If
                  End If
                  filtromultiplecomprobantes.ShowDialog()
                  _listaTiposModelos.Clear()
                  If filtromultiplecomprobantes.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaTiposModelos.AddRange(filtromultiplecomprobantes.Filtros)
                  End If
                  If _listaTiposModelos.Count = 1 Then
                     SelectedValue = _listaTiposModelos(0).IdProductoModeloTipo
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaTiposModelos.Clear()
                  _listaTiposModelos.Add(DirectCast(SelectedItem, Entidades.ProductoModeloTipo))
               End If
               CargarOpcionesContextuales()
            End Using
         End If
      End If
   End Sub

   Public Sub CargarFiltrosImpresionTiposComprobantes(filtro As System.Text.StringBuilder, muestraId As Boolean, muestraNombre As Boolean)
      If SelectedIndex > -1 AndAlso Enabled Then
         With filtro
            Dim tiposComprobantes As Entidades.ProductoModeloTipo() = GetTiposModelos()
            Dim formato As String = ""
            If muestraId And muestraNombre Then formato = "{0} - {1}"
            If muestraId And Not muestraNombre Then formato = "{0}"
            If Not muestraId And muestraNombre Then formato = "{1}"
            If Not muestraId And Not muestraNombre Then formato = ""
            If SelectedValue.Equals(Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()) Then
               .AppendFormat("Tipos de Comprobante: {0}", Publicos.GetEnumString(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos))
            Else
               If tiposComprobantes.Count = 1 Then
                  .AppendFormat("Tipo de Comprobante: ").AppendFormat(formato, tiposComprobantes(0).IdProductoModeloTipo, tiposComprobantes(0).NombreProductoModeloTipo)
               ElseIf tiposComprobantes.Count > 1 Then
                  .AppendFormat("Tipos de Comprobante: ")
                  Dim primera As Boolean = True
                  For Each tpCom As Entidades.ProductoModeloTipo In tiposComprobantes
                     If Not primera Then .AppendFormat(", ")
                     .AppendFormat(formato, tpCom.IdProductoModeloTipo, tpCom.NombreProductoModeloTipo)
                     primera = False
                  Next
               End If
            End If
            .AppendFormat(" ")
         End With
      End If
   End Sub

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFTipoModelo.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm As MFTipoModelo = New MFTipoModelo(_permiteSinSeleccion)
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaTiposModelos.Clear()
            SelectedValue = Convert.ToInt32(Entidades.ProductoModeloTipo.ValoresFijosIdProductoModeloTipo.SeleccionMultiple).ToString()
            _listaTiposModelos.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub

   Public Sub SetValoresSeleccionados(tipos As IEnumerable(Of Entidades.ProductoModeloTipo))
      If tipos.Count = 1 Then
         SelectedValue = tipos(0).IdProductoModeloTipo
      ElseIf tipos.Count > 0 Then
         Try
            Enabled = False
            _listaTiposModelos.Clear()
            SelectedValue = Convert.ToInt32(Entidades.ProductoModeloTipo.ValoresFijosIdProductoModeloTipo.SeleccionMultiple).ToString()
            _listaTiposModelos.AddRange(tipos)
         Catch ex As Exception
            FindForm().ShowError(ex)
         Finally
            Enabled = True
         End Try
      End If
   End Sub

End Class