Public Class ComboBoxGrupoTiposComprobantes
   Inherits ComboBoxMultipleSeleccion

   Private _listaGrupo As List(Of Entidades.Grupo)
   Private _publicos As Publicos
   Private _initialized As Boolean = False
   Private _permiteSinSeleccion As Boolean
   Private _seleccionMultiple As Boolean
   Private _seleccionTodos As Boolean

   Private _idGrupo As String
   Private _nombreGrupo As String

   Public Sub New()
      MyBase.New()
      _listaGrupo = New List(Of Entidades.Grupo)()
   End Sub

   Public Function GetGruposTiposComprobantes() As Entidades.Grupo()
      Return GetGruposTiposComprobantes(True)
   End Function
   Public Function GetGruposTiposComprobantes(todosVacio As Boolean) As Entidades.Grupo()
      If SelectedValue IsNot Nothing AndAlso SelectedValue.Equals(Convert.ToInt32(Entidades.Grupo.ValoresFijosGrupos.Todos).ToString()) Then
         If todosVacio Then Return {}
         Return MFGrupoTipoComprobantes.GetTodas().ToArray()
      End If
      If _listaGrupo.Count = 1 AndAlso _listaGrupo(0) Is Nothing Then Return {}
      Return _listaGrupo.ToArray()
   End Function

   Public Sub Inicializar()
      Inicializar(True)
   End Sub
   Public Sub Inicializar(permiteSinSeleccion As Boolean)
      Inicializar(permiteSinSeleccion, True, True)
   End Sub
   Public Sub Inicializar(permiteSinSeleccion As Boolean, seleccionMultiple As Boolean, seleccionTodos As Boolean)

      ctxMenu = New System.Windows.Forms.ContextMenuStrip(components)
      ctxMenu.Name = "ctxMenu"
      ctxMenu.Text = "Filtros guardados"

      _seleccionMultiple = seleccionMultiple
      _seleccionTodos = seleccionTodos
      _publicos = New Publicos()
      _publicos.CargaComboGrupos(Me, seleccionMultiple, seleccionTodos)
      Refrescar()
      _initialized = True
      _permiteSinSeleccion = permiteSinSeleccion
      _listaGrupo.Clear()
      _listaGrupo.Add(DirectCast(SelectedItem, Entidades.Grupo))

      If seleccionMultiple Then
         ContextMenuStrip = ctxMenu
      End If

      CargarOpcionesContextuales()

   End Sub
   Public Sub Refrescar()
      SelectedValue = Convert.ToInt32(Entidades.Grupo.ValoresFijosGrupos.Todos).ToString()
   End Sub

   Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
      MyBase.OnSelectedIndexChanged(e)

      If _initialized And Enabled Then
         If SelectedIndex > -1 Then
            Using filtromultiplecomprobantes As New MFGrupoTipoComprobantes(_permiteSinSeleccion, _idGrupo, _nombreGrupo)
               If SelectedValue.Equals(Convert.ToInt32(Entidades.Grupo.ValoresFijosGrupos.SeleccionMultiple).ToString()) Then
                  If _listaGrupo IsNot Nothing AndAlso _listaGrupo.Count > 0 AndAlso _listaGrupo(0) IsNot Nothing Then
                     If _listaGrupo.Any() AndAlso _listaGrupo(0).IdGrupo.Equals(Convert.ToInt32(Entidades.Grupo.ValoresFijosGrupos.Todos).ToString()) Then
                        filtromultiplecomprobantes.Filtros.AddRange(MFGrupoTipoComprobantes.GetTodas())
                     Else
                        filtromultiplecomprobantes.Filtros.AddRange(_listaGrupo)
                     End If
                  End If
                  filtromultiplecomprobantes.ShowDialog()
                  _listaGrupo.Clear()
                  If filtromultiplecomprobantes.Filtros.Count = 0 Then
                     SelectedIndex = -1
                  Else
                     _listaGrupo.AddRange(filtromultiplecomprobantes.Filtros)
                  End If
                  If _listaGrupo.Count = 1 Then
                     SelectedValue = _listaGrupo(0).IdGrupo
                  End If
               ElseIf SelectedIndex > -1 Then
                  _listaGrupo.Clear()
                  _listaGrupo.Add(DirectCast(SelectedItem, Entidades.Grupo))
               End If
               CargarOpcionesContextuales()
            End Using
         End If
      End If
   End Sub

   Public Sub CargarFiltrosImpresionTiposComprobantes(filtro As System.Text.StringBuilder, muestraId As Boolean, muestraNombre As Boolean)
      If SelectedIndex > -1 AndAlso Enabled Then
         With filtro
            Dim GrupotiposComprobantes As Entidades.Grupo() = GetGruposTiposComprobantes()
            Dim formato As String = ""
            If muestraId And muestraNombre Then formato = "{0} - {1}"
            If muestraId And Not muestraNombre Then formato = "{0}"
            If Not muestraId And muestraNombre Then formato = "{1}"
            If Not muestraId And Not muestraNombre Then formato = ""
            If SelectedValue.Equals(Convert.ToInt32(Entidades.Grupo.ValoresFijosGrupos.Todos).ToString()) Then
               .AppendFormat("Grupos de Comprobante: {0}", Publicos.GetEnumString(Entidades.Grupo.ValoresFijosGrupos.Todos))
            Else
               If GrupotiposComprobantes.Count = 1 Then
                  .AppendFormat("Grupos de Comprobante: ").AppendFormat(formato, GrupotiposComprobantes(0).IdGrupo, GrupotiposComprobantes(0).NombreGrupo)
               ElseIf GrupotiposComprobantes.Count > 1 Then
                  .AppendFormat("Grupos de Comprobantee: ")
                  Dim primera As Boolean = True
                  For Each tpCom As Entidades.Grupo In GrupotiposComprobantes
                     If Not primera Then .AppendFormat(", ")
                     .AppendFormat(formato, tpCom.IdGrupo, tpCom.NombreGrupo)
                     primera = False
                  Next
               End If
            End If
            .AppendFormat(" ")
         End With
      End If
   End Sub

   Private Overloads Sub CargarOpcionesContextuales()
      CargarOpcionesContextuales(MFGrupoTipoComprobantes.TipoFiltroKey)
   End Sub

   Protected Overrides Sub CargaFiltrosGuardados(nombreFiltro As String)
      Try
         Using frm As MFGrupoTipoComprobantes = New MFGrupoTipoComprobantes(_permiteSinSeleccion)
            frm.CargarClase(nombreFiltro)
            Enabled = False
            _listaGrupo.Clear()
            SelectedValue = Convert.ToInt32(Entidades.Grupo.ValoresFijosGrupos.SeleccionMultiple).ToString()
            _listaGrupo.AddRange(frm.Filtros)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Enabled = True
      End Try
   End Sub
End Class