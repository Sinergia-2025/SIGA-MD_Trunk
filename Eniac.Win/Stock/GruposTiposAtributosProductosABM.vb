#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class GruposTiposAtributosProductosABM

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As System.EventArgs)
      MyBase.OnLoad(e)
      tsbImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New GruposTiposAtributosProductosDetalle(DirectCast(GetEntidad(), Entidades.GrupoTipoAtributoProducto))
      End If
      Return New GruposTiposAtributosProductosDetalle(New Entidades.GrupoTipoAtributoProducto)
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.GruposTiposAtributosProductos()
   End Function
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim GrupoTipoAtributoProducto = New Entidades.GrupoTipoAtributoProducto
      With Me.dgvDatos.ActiveRow
         GrupoTipoAtributoProducto = New Eniac.Reglas.GruposTiposAtributosProductos().GetUno(Integer.Parse(.Cells("IdGrupoTipoAtributoProducto").Value.ToString()), Short.Parse(.Cells("IdTipoAtributoProducto").Value.ToString()))
      End With
      Return GrupoTipoAtributoProducto
   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         .Columns(Entidades.GrupoTipoAtributoProducto.Columnas.IdGrupoTipoAtributoProducto.ToString()).FormatearColumna("Código Grupo", col, 80, HAlign.Right)
         .Columns(Entidades.GrupoTipoAtributoProducto.Columnas.Descripcion.ToString()).FormatearColumna("Descripción Grupo", col, 400)
         .Columns(Entidades.GrupoTipoAtributoProducto.Columnas.IdTipoAtributoProducto.ToString()).FormatearColumna("Código Tipo", col, 80, HAlign.Right)
         .Columns("DescripcionTipo").FormatearColumna("Descripción Tipo", col, 400)
      End With
      dgvDatos.AgregarFiltroEnLinea({"Descripcion", "IdGrupoTipoAtributoProducto"})

   End Sub
#End Region

End Class