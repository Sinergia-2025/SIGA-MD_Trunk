Imports System.Runtime.CompilerServices

Public Class ComboBoxMultipleSeleccion
   Inherits Controles.ComboBox
   Protected components As System.ComponentModel.IContainer
   Protected ctxMenu As ContextMenuStrip

   Public Sub New()
      MyBase.New()
      Me.components = New System.ComponentModel.Container()
   End Sub

   Public ReadOnly Property TodosSelected As Boolean
      Get
         Try
            Return Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
         Catch ex As Exception
            Return False
         End Try
      End Get
   End Property
   Public ReadOnly Property SeleccionMultipleSelected As Boolean
      Get
         Try
            Return Convert.ToInt32(SelectedValue) = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
         Catch ex As Exception
            Return False
         End Try
      End Get
   End Property

   Protected Sub EliminarOpcionesMenuContextual()
      If ctxMenu IsNot Nothing Then
         While ctxMenu.Items.Count > 0
            Dim item As ToolStripItem = ctxMenu.Items(ctxMenu.Items.Count - 1)
            ctxMenu.Items.Remove(item)
            RemoveHandler item.Click, AddressOf ToolStripMenuItem_Click
            item.Dispose()
         End While
      End If
   End Sub

   Protected Overridable Sub ToolStripMenuItem_Click(sender As Object, e As EventArgs)
      Try
         CargaFiltrosGuardados(DirectCast(sender, ToolStripItem).Tag.ToString())
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Cargando Filtro", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Sub CargarOpcionesContextuales(idTipoFiltro As String)
      EliminarOpcionesMenuContextual()

      Dim titulo As ToolStripItem = New ToolStripLabel("Filtros guardados")
      titulo.Font = New Font(Font, FontStyle.Bold)
      ctxMenu.Items.Add(titulo)
      ctxMenu.Items.Add(New ToolStripSeparator())

      Dim regFV As Reglas.FiltrosValores = New Reglas.FiltrosValores()
      Dim archivos() As String = regFV.GetNombreFiltros(idTipoFiltro)  '"TIPOCOMPROBANTES"

      For Each archivo As String In archivos ' i As Integer = 1 To 5
         Dim item1 As ToolStripMenuItem = New ToolStripMenuItem()

         item1.Name = String.Format("Opcion__||__{0}", archivo)
         item1.Tag = archivo
         item1.Text = String.Format("{0}", archivo)

         AddHandler item1.Click, AddressOf ToolStripMenuItem_Click

         ctxMenu.Items.Add(item1)
      Next

   End Sub


   Protected Overridable Sub CargaFiltrosGuardados(nombreFiltro As String)

   End Sub

   Protected Overrides Sub Dispose(disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            EliminarOpcionesMenuContextual()
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub


End Class

Public Class CargaFiltroImpresionParams
   Public Property EtiquetaSingular As String
   Public Property EtiquetaPlural As String
   Public Property MuestraId As Boolean
   Public Property MuestraNombre As Boolean
   Public Property Prefijo As String
   Public Property Sufijo As String
   Public Property TodosVacio As Boolean

   Public Function Setter(Optional muestraId As Boolean? = Nothing, Optional muestraNombre As Boolean? = Nothing,
                          Optional prefijo As String = Nothing, Optional sufijo As String = Nothing,
                          Optional todosVacio As Boolean? = Nothing) As CargaFiltroImpresionParams
      If muestraId.HasValue Then
         Me.MuestraId = muestraId.Value
      End If
      If muestraNombre.HasValue Then
         Me.MuestraNombre = muestraNombre.Value
      End If
      If prefijo IsNot Nothing Then
         Me.Prefijo = prefijo
      End If
      If sufijo IsNot Nothing Then
         Me.Sufijo = sufijo
      End If
      If todosVacio.HasValue Then
         Me.TodosVacio = todosVacio.Value
      End If
      Return Me
   End Function

   Private Sub New(etiquetaSingular As String, etiquetaPlural As String, muestraId As Boolean, muestraNombre As Boolean, prefijo As String, sufijo As String, todosVacio As Boolean)
      Me.EtiquetaSingular = etiquetaSingular
      Me.EtiquetaPlural = etiquetaPlural
      Me.MuestraId = muestraId
      Me.MuestraNombre = muestraNombre
      Me.Prefijo = prefijo
      Me.Sufijo = sufijo
      Me.TodosVacio = todosVacio
   End Sub

   Public Sub New(etiquetaSingular As String, etiquetaPlural As String)
      Me.New(etiquetaSingular, etiquetaPlural, muestraId:=False, muestraNombre:=True, prefijo:=" - ", sufijo:="", todosVacio:=True)
   End Sub
End Class

Public MustInherit Class ComboBoxMultipleSeleccion2
   Inherits ComboBoxMultipleSeleccion

   Public MustOverride Function GetDefaultParametrosImpresion() As CargaFiltroImpresionParams

   Public MustOverride Function GetTodos() As IEnumerable(Of Entidades.IComboBoxMultipleSeleccionElement)

   Public Overridable Function CargaFiltroImpresion(filtro As StringBuilder) As StringBuilder
      Return CargaFiltroImpresion(filtro, GetDefaultParametrosImpresion())
   End Function
   Public Overridable Function CargaFiltroImpresion(filtro As StringBuilder, todosVacio As Boolean) As StringBuilder
      Return CargaFiltroImpresion(filtro, GetDefaultParametrosImpresion().Setter(todosVacio:=todosVacio))
   End Function
   Public Sub CargaFiltroImpresion(filtro As StringBuilder, muestraId As Boolean, muestraNombre As Boolean)
      CargaFiltroImpresion(filtro, GetDefaultParametrosImpresion().Setter(muestraId, muestraNombre, todosVacio:=False))
   End Sub

   Public Sub CargaFiltroImpresion(filtro As StringBuilder, muestraId As Boolean, muestraNombre As Boolean, todosVacio As Boolean)
      CargaFiltroImpresion(filtro, GetDefaultParametrosImpresion().Setter(muestraId, muestraNombre, todosVacio:=todosVacio))
   End Sub
   Public Sub CargaFiltroImpresion(filtro As StringBuilder, muestraId As Boolean, muestraNombre As Boolean, prefijo As String, sufijo As String)
      CargaFiltroImpresion(filtro, GetDefaultParametrosImpresion().Setter(muestraId, muestraNombre, prefijo, sufijo))
   End Sub
   Public Sub CargaFiltroImpresion(filtro As StringBuilder, muestraId As Boolean, muestraNombre As Boolean, prefijo As String, sufijo As String, todosVacio As Boolean)
      CargaFiltroImpresion(filtro, GetDefaultParametrosImpresion().Setter(muestraId, muestraNombre, prefijo, sufijo, todosVacio))
   End Sub
   Public Overridable Function CargaFiltroImpresion(filtro As StringBuilder, etiquetaSingular As String, etiquetaPlural As String, muestraId As Boolean, muestraNombre As Boolean, prefijo As String, sufijo As String, todosVacio As Boolean) As StringBuilder
      Return CargaFiltroImpresion(filtro, GetDefaultParametrosImpresion().Setter(muestraId, muestraNombre, prefijo, sufijo, todosVacio))
   End Function

   Public Overridable Function CargaFiltroImpresion(filtro As StringBuilder, params As CargaFiltroImpresionParams) As StringBuilder
      If Not params.TodosVacio OrElse Not TodosSelected Then
         If SelectedIndex > -1 AndAlso Enabled Then
            With filtro
               Dim formatoMarca As String = String.Empty
               If params.MuestraId And params.MuestraNombre Then formatoMarca = "{0} - {1}"
               If params.MuestraId And Not params.MuestraNombre Then formatoMarca = "{0}"
               If Not params.MuestraId And params.MuestraNombre Then formatoMarca = "{1}"
               If Not params.MuestraId And Not params.MuestraNombre Then formatoMarca = ""
               .Append(params.Prefijo)
               If TodosSelected Then
                  .AppendFormat("{0}: {1}", params.EtiquetaPlural, Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos))
               Else
                  Dim marcas = GetTodos()
                  If marcas.Count = 1 Then
                     .AppendFormat("{0}: ", params.etiquetaSingular).AppendFormat(formatoMarca, marcas(0).Id, marcas(0).Nombre)
                  ElseIf marcas.Count > 1 Then
                     .AppendFormat("{0}: {1}", params.EtiquetaPlural, String.Join(", ", marcas.ToList().ConvertAll(Function(suc) String.Format(formatoMarca, suc.Id, suc.Nombre))))
                  End If
               End If
               .Append(params.Sufijo)
            End With
         End If
      End If
      Return filtro
   End Function

End Class
