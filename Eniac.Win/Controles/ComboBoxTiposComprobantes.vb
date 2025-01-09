Public Class ComboBoxTiposComprobantes
   Inherits ComboBoxMultipleSeleccion

   Private _listaTiposComprobantes As List(Of Entidades.TipoComprobante)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean

   Private _tipo1 As String
   Private _tipo2 As String

   Public Sub New()
      MyBase.New()
      _listaTiposComprobantes = New List(Of Entidades.TipoComprobante)()
   End Sub

   Public Function GetTiposComprobantes() As Entidades.TipoComprobante()
      Return GetTiposComprobantes(True)
   End Function
   Public Function GetTiposComprobantes(todosVacio As Boolean) As Entidades.TipoComprobante()
      If SelectedValue IsNot Nothing AndAlso SelectedValue.Equals(Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()) Then
         If todosVacio Then Return {}
         Return MFTipoComprobantes.GetTodos(_tipo1, _tipo2).ToArray()
      End If
      If _listaTiposComprobantes.Count = 1 AndAlso _listaTiposComprobantes(0) Is Nothing Then Return {}
      Return _listaTiposComprobantes.ToArray()
   End Function

   Public Sub Initializar(MiraPC As Boolean,
                          Tipo1 As String,
                          Optional Tipo2 As String = "",
                          Optional AfectaCaja As String = "",
                          Optional UsaFacturacionRapida As String = "",
                          Optional UsaFacturacion As Boolean = False,
                          Optional EsElectronico As Boolean? = Nothing,
                          Optional Clase As String = "",
                          Optional coeficionesStock As Integer? = Nothing,
                          Optional coeficienteValor As Integer? = Nothing)
      Initializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True, MiraPC, Tipo1, Tipo2, AfectaCaja, UsaFacturacionRapida, UsaFacturacion, EsElectronico, Clase,
                  defaultValue:=Nothing, coeficionesStock, coeficienteValor)
   End Sub
   Public Sub Initializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean,
                          MiraPC As Boolean,
                          Tipo1 As String,
                          Optional Tipo2 As String = "",
                          Optional AfectaCaja As String = "",
                          Optional UsaFacturacionRapida As String = "",
                          Optional UsaFacturacion As Boolean = False,
                          Optional EsElectronico As Boolean? = Nothing,
                          Optional Clase As String = "",
                          Optional defaultValue As String = Nothing,
                          Optional coeficionesStock As Integer? = Nothing,
                          Optional coeficienteValor As Integer? = Nothing)
      If String.IsNullOrWhiteSpace(defaultValue) Then defaultValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos).ToString()

      _tipo1 = Tipo1
      _tipo2 = Tipo2
      _defaultValue = defaultValue

      ctxMenu = New ContextMenuStrip(components) With {
         .Name = "ctxMenu",
         .Text = "Filtros guardados"
      }

      _seleccionMultiple = seleccionMultiple
      _seleccionTodos = seleccionTodos
      _publicos = New Publicos()
      _publicos.CargaComboTiposComprobantes(Me, MiraPC, Tipo1, Tipo2, AfectaCaja, UsaFacturacionRapida, UsaFacturacion, seleccionMultiple, seleccionTodos, esElectronico:=EsElectronico, Clase:=Clase,
                                            coeficionesStock:=coeficionesStock, coeficienteValor:=coeficienteValor)

      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaTiposComprobantes.Clear()
      _listaTiposComprobantes.Add(DirectCast(SelectedItem, Entidades.TipoComprobante))

      If seleccionMultiple Then
         ContextMenuStrip = ctxMenu
      End If

      CargarOpcionesContextuales()

   End Sub

   Private _defaultValue As String = Nothing
   Public Sub Refrescar()
      If String.IsNullOrWhiteSpace(_defaultValue) Then
         SelectedIndex = -1
      Else
         SelectedValue = _defaultValue
      End If
   End Sub

   Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
      MyBase.OnSelectedIndexChanged(e)

      If _initialized And Enabled Then
         If SelectedIndex > -1 Then
            Using filtromultiplecomprobantes As New MFTipoComprobantes(_permiteSinSeleccion, _tipo1, _tipo2)
               If SelectedValue.Equals(Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.SeleccionMultiple).ToString()) Then
                  If _listaTiposComprobantes IsNot Nothing AndAlso _listaTiposComprobantes.Count > 0 AndAlso _listaTiposComprobantes(0) IsNot Nothing Then
                     If _listaTiposComprobantes.Any() AndAlso _listaTiposComprobantes(0).IdTipoComprobante.Equals(Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()) Then
                        filtromultiplecomprobantes.Filtros.AddRange(MFTipoComprobantes.GetTodos(_tipo1, _tipo2))
                     Else
                        filtromultiplecomprobantes.Filtros.AddRange(_listaTiposComprobantes)
                     End If
                  End If
                  filtromultiplecomprobantes.ShowDialog()
                  _listaTiposComprobantes.Clear()
                  If filtromultiplecomprobantes.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaTiposComprobantes.AddRange(filtromultiplecomprobantes.Filtros)
                  End If
                  If _listaTiposComprobantes.Count = 1 Then
                     SelectedValue = _listaTiposComprobantes(0).IdTipoComprobante
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaTiposComprobantes.Clear()
                  _listaTiposComprobantes.Add(DirectCast(SelectedItem, Entidades.TipoComprobante))
               End If
               CargarOpcionesContextuales()
            End Using
         End If
      End If
   End Sub

   Public Sub CargarFiltrosImpresionTiposComprobantes(filtro As System.Text.StringBuilder, muestraId As Boolean, muestraNombre As Boolean)
      If SelectedIndex > -1 AndAlso Enabled Then
         With filtro
            Dim tiposComprobantes As Entidades.TipoComprobante() = GetTiposComprobantes()
            Dim formato As String = ""
            If muestraId And muestraNombre Then formato = "{0} - {1}"
            If muestraId And Not muestraNombre Then formato = "{0}"
            If Not muestraId And muestraNombre Then formato = "{1}"
            If Not muestraId And Not muestraNombre Then formato = ""
            If SelectedValue.Equals(Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()) Then
               .AppendFormat("Tipos de Comprobante: {0}", Publicos.GetEnumString(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos))
            Else
               If tiposComprobantes.Count = 1 Then
                  .AppendFormat("Tipo de Comprobante: ").AppendFormat(formato, tiposComprobantes(0).IdTipoComprobante, tiposComprobantes(0).Descripcion)
               ElseIf tiposComprobantes.Count > 1 Then
                  .AppendFormat("Tipos de Comprobante: ")
                  Dim primera As Boolean = True
                  For Each tpCom As Entidades.TipoComprobante In tiposComprobantes
                     If Not primera Then .AppendFormat(", ")
                     .AppendFormat(formato, tpCom.IdTipoComprobante, tpCom.Descripcion)
                     primera = False
                  Next
               End If
            End If
            .AppendFormat(" ")
         End With
      End If
   End Sub

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFTipoComprobantes.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm As MFTipoComprobantes = New MFTipoComprobantes(_permiteSinSeleccion, _tipo1, _tipo2)
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaTiposComprobantes.Clear()
            SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.SeleccionMultiple).ToString()
            _listaTiposComprobantes.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub

   Public Sub SetValoresSeleccionados(tipos As IEnumerable(Of Entidades.TipoComprobante))
      If tipos.Count = 1 Then
         SelectedValue = tipos(0).IdTipoComprobante
      ElseIf tipos.Count > 0 Then
         Try
            Enabled = False
            _listaTiposComprobantes.Clear()
            SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.SeleccionMultiple).ToString()
            _listaTiposComprobantes.AddRange(tipos)
         Catch ex As Exception
            FindForm().ShowError(ex)
         Finally
            Enabled = True
         End Try
      End If
   End Sub

End Class