Public Class AtributosProductosABM

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      tsbImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New AtributosProductosDetalle(DirectCast(GetEntidad(), Entidades.AtributoProducto))
      End If
      Return New AtributosProductosDetalle(New Entidades.AtributoProducto())
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.AtributosProductos()
   End Function
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim AtributoProducto = New Entidades.AtributoProducto()
      With dgvDatos.ActiveRow
         AtributoProducto = New Reglas.AtributosProductos().GetUno(Integer.Parse(.Cells("IdAtributoProducto").Value.ToString()),
                                                                   Integer.Parse(.Cells("IdGrupoTipoAtributoProducto").Value.ToString()),
                                                                   Short.Parse(.Cells("IdTipoAtributoProducto").Value.ToString()))
      End With
      Return AtributoProducto
   End Function
   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim col = 0I
         .Columns("DescripcionTipo").FormatearColumna("Descripción Tipo", col, 120, HAlign.Left)
         .Columns("DescripcionGrupo").FormatearColumna("Descripción Grupo", col, 120, HAlign.Left)
         .Columns(Entidades.AtributoProducto.Columnas.IdAtributoProducto.ToString()).FormatearColumna("Código Atributo", col, 80, HAlign.Right)
         .Columns(Entidades.AtributoProducto.Columnas.Descripcion.ToString()).FormatearColumna("Descripción Atributo", col, 200, HAlign.Left)
         .Columns(Entidades.AtributoProducto.Columnas.Orden.ToString()).FormatearColumna("Orden", col, 80, HAlign.Right)
         .Columns(Entidades.AtributoProducto.Columnas.IdaAtributoProducto.ToString()).FormatearColumna("Código Único", col, 80, HAlign.Right)

         .Columns("IdGrupoTipoAtributoProducto").FormatearColumna("Código Grupo", col, 80, HAlign.Right, hidden:=True)
         .Columns("IdTipoAtributoProducto").FormatearColumna("Código Tipo", col, 80, HAlign.Right, hidden:=True)
      End With
      dgvDatos.AgregarFiltroEnLinea({"Descripcion", "IdAtributoProducto"})
   End Sub
#End Region
End Class