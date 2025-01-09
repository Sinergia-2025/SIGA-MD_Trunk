Imports Eniac.Win
Imports Infragistics.Win.UltraWinGrid

Public Class SubSubRubrosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
      Ayudante.Grilla.AgregarFiltroEnLinea(Me.dgvDatos, {"NombreRubro", "NombreSubRubro", "NombreSubSubRubro"})
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      Dim subSubRubro As Entidades.SubSubRubro = DirectCast(Me.GetEntidad(), Eniac.Entidades.SubSubRubro)
      Dim idSubRubro As Integer = 0
      If subSubRubro IsNot Nothing Then idSubRubro = subSubRubro.IdSubRubro
      If estado = StateForm.Actualizar Then
         If subSubRubro Is Nothing Then Throw New Exception("Seleccione un SubRubro a modificar.")
         Return New SubSubRubrosDetalle(idSubRubro, subSubRubro)
      End If
      Return New SubSubRubrosDetalle(idSubRubro, New Entidades.SubSubRubro())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.SubSubRubros()
   End Function
   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.SubSubRubros.rdlc", "SistemaDataSet_SubSubRubros", Me.dtDatos, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = "SubSubRubros"
         frmImprime.Show()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim oSubRub As Entidades.SubSubRubro = New Entidades.SubSubRubro
      If Me.dgvDatos.ActiveRow IsNot Nothing Then
         With Me.dgvDatos.ActiveRow
            If Not IsNumeric(.Cells("IdSubRubro").Value) Then Return Nothing
            oSubRub.IdSubSubRubro = Integer.Parse(.Cells("IdSubSubRubro").Value.ToString())
            oSubRub.IdSubRubro = Integer.Parse(.Cells("IdSubRubro").Value.ToString())
            oSubRub = New Reglas.SubSubRubros().GetUno(oSubRub.IdSubSubRubro)
         End With
      End If
      Return oSubRub
   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)

         .Columns("IdRubro").Header.Caption = "Cod.Rub."
         .Columns("IdRubro").Width = 80
         .Columns("IdRubro").CellAppearance.TextHAlign = HAlign.Right
         .Columns("IdRubro").Header.VisiblePosition = 0

         .Columns("NombreRubro").Header.Caption = "Rubro"
         .Columns("NombreRubro").Width = 200
         .Columns("NombreRubro").Header.VisiblePosition = 1

         .Columns("IdSubRubro").Header.Caption = "Cod.SubRub."
         .Columns("IdSubRubro").Width = 80
         .Columns("IdSubRubro").CellAppearance.TextHAlign = HAlign.Right
         .Columns("IdSubRubro").Header.VisiblePosition = 2

         .Columns("NombreSubRubro").Header.Caption = "SubRubro"
         .Columns("NombreSubRubro").Width = 200
         .Columns("NombreSubRubro").Header.VisiblePosition = 3

         .Columns("IdSubSubRubro").Header.Caption = "Código"
         .Columns("IdSubSubRubro").Width = 80
         .Columns("IdSubSubRubro").CellAppearance.TextHAlign = HAlign.Right
         .Columns("IdSubSubRubro").Header.VisiblePosition = 4

         .Columns("NombreSubSubRubro").Header.Caption = "SubSubRubro"
         .Columns("NombreSubSubRubro").Width = 200
         .Columns("NombreSubSubRubro").Header.VisiblePosition = 5

         .Columns("IdSubSubRubroTiendaNube").FormatearColumna("Cód. SubSubRubro Tienda Nube", 6, 80, HAlign.Right)
         .Columns("IdSubSubRubroMercadoLibre").FormatearColumna("Cód. SubSubRubro Mercado Libre", 7, 80, HAlign.Right)
         .Columns("IdSubSubRubroArborea").FormatearColumna("Cód. SubSubRubro Arborea", 7, 80, HAlign.Right)

         .Columns(Entidades.SubSubRubro.Columnas.FechaActualizacionWeb.ToString()).Hidden = True

      End With
   End Sub

#End Region

End Class