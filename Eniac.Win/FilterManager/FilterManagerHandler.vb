#Region "Option"
Option Strict On
Option Explicit On
Option Infer On
#End Region
Namespace FilterManager
   Public Class FilterManagerHandler

#Region "Singleton"
      Private Shared _instancia As FilterManagerHandler
      Private Shared _lockObject As New Object()
      Public Shared Function Instancia() As FilterManagerHandler
         If _instancia Is Nothing Then
            SyncLock _lockObject
               If _instancia Is Nothing Then
                  _instancia = New FilterManagerHandler()
               End If
            End SyncLock
         End If
         Return _instancia
      End Function
      Private Sub New()
      End Sub
#End Region

      Friend Sub Refrescar(baseForm As BaseForm, selectedFiltros As Entidades.FilterManager.FuncionFiltro, controles As Dictionary(Of String, Eniac.Controles.IFilterControl))
         If baseForm IsNot Nothing Then
            If selectedFiltros IsNot Nothing Then
               For Each filtro In ConvertToFilterControlList(selectedFiltros)
                  If Controles.ContainsKey(filtro.Name) Then

                     If TypeOf (Controles(filtro.Name)) Is Eniac.Controles.ISeteoControl AndAlso
                        TypeOf (DirectCast(Controles(filtro.Name), Eniac.Controles.ISeteoControl).LabelAsoc) Is Eniac.Controles.CheckBox Then
                        DirectCast(DirectCast(Controles(filtro.Name), Eniac.Controles.ISeteoControl).LabelAsoc, Eniac.Controles.CheckBox).Checked = True
                     End If

                     Controles(filtro.Name).FilterValue = FilterManagerSerializer.Instancia.Deserialize(filtro.Value)
                  End If
               Next
            End If
         End If
      End Sub

      Friend Function Guardar(idFuncion As String, valores As IFilterManagerSelectorDetalle) As Boolean
         Dim filtro = New Entidades.FilterManager.FuncionFiltro()
         filtro.IdFuncion = idFuncion
         filtro.IdFiltro = 0     'Para que obtenga el próximo de BD

         filtro.IdSucursal = If(valores.Sucursal = SucursalActualTodas.SucursalActual, actual.Sucursal.Id, 0)
         filtro.Usuario = If(valores.Usuario = UsuarioActualTodos.UsuarioActual, actual.Nombre, String.Empty)

         filtro.NombreFiltro = valores.Nombre

         For Each sel In valores.ListaFiltrosSeleccionados
            Dim ctrl = New Entidades.FilterManager.FuncionFiltroControl()
            ctrl.NombreControl = sel.FilterControlName
            ctrl.ValorControl = FilterManagerSerializer.Instancia.Serialize(sel.FilterValue)
            filtro.Controles.Add(ctrl)
         Next

         Dim regla = New Reglas.FilterManager.FuncionesFiltros()
         regla.Insertar(filtro)

         Return True
      End Function
      Friend Sub Eliminar(filtro As Entidades.FilterManager.FuncionFiltro)
         Dim regla = New Reglas.FilterManager.FuncionesFiltros()
         regla.Borrar(filtro)
      End Sub

      Friend Function GetTodos(idFuncion As String) As List(Of Entidades.FilterManager.FuncionFiltro)
         Return New Reglas.FilterManager.FuncionesFiltros().GetTodos(idFuncion)
      End Function
      Friend Function GetDefault(idFuncion As String) As Entidades.FilterManager.FuncionFiltro
         Return New Reglas.FilterManager.FuncionesFiltros().GetDefault(idFuncion)
      End Function
      Friend Function GetControles(panelFiltro As Eniac.Controles.IPanel) As Dictionary(Of String, Eniac.Controles.IFilterControl)
         Dim result = New Dictionary(Of String, Eniac.Controles.IFilterControl)()
         GetControles(result, panelFiltro.Controls)
         Return result
      End Function

      Friend Sub CambiarSoloUsuario(dr As Entidades.FilterManager.FuncionFiltro, cargaGrillaDetalle As Action)
         CambiarDefault(dr, Sub(r, dr1) r.CambiarDefaultSoloUsuario(dr1), cargaGrillaDetalle)
      End Sub
      Friend Sub CambiarTodosLosUsuario(dr As Entidades.FilterManager.FuncionFiltro, cargaGrillaDetalle As Action)
         CambiarDefault(dr, Sub(r, dr1) r.CambiarDefaultTodosLosUsuario(dr1), cargaGrillaDetalle)
      End Sub
      Friend Sub EliminarFiltroDefectoUsuario(dr As Entidades.FilterManager.FuncionFiltro, cargaGrillaDetalle As Action)
         CambiarDefault(dr, Sub(r, dr1) r.EliminarDefaultUsuario(dr1), cargaGrillaDetalle)
      End Sub



      Private Function ConvertToFilterControlList(filtros As Entidades.FilterManager.FuncionFiltro) As FilterControlValueList
         Dim result = New FilterControlValueList()
         If filtros IsNot Nothing Then
            For Each ctrls In filtros.Controles
               result.Add(New FilterControlValue() With {.Name = ctrls.NombreControl, .Value = ctrls.ValorControl})
            Next
         End If
         Return result
      End Function
      Private Sub CambiarDefault(dr As Entidades.FilterManager.FuncionFiltro,
                                 accion As Action(Of Reglas.FilterManager.FuncionesFiltros, Entidades.FilterManager.FuncionFiltro),
                                 cargaGrillaDetalle As Action)
         If dr IsNot Nothing Then
            Dim r = New Reglas.FilterManager.FuncionesFiltros()
            accion(r, dr)
            cargaGrillaDetalle()
         End If

      End Sub
      Private Sub GetControles(dicCtrl As Dictionary(Of String, Eniac.Controles.IFilterControl), ctrlCol As Control.ControlCollection)
         For Each ctrl As Control In ctrlCol
            If Not dicCtrl.ContainsKey(ctrl.Name) Then
               If TypeOf (ctrl) Is Eniac.Controles.IFilterControl Then
                  dicCtrl.Add(ctrl.Name, DirectCast(ctrl, Eniac.Controles.IFilterControl))
               End If
               GetControles(dicCtrl, ctrl.Controls)
            End If
         Next
      End Sub

   End Class
End Namespace