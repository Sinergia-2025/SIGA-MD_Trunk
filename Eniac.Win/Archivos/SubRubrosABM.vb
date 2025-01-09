Imports Eniac.Win
Imports Infragistics.Win.UltraWinGrid

Public Class SubRubrosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Ayudante.Grilla.AgregarFiltroEnLinea(Me.dgvDatos, {"NombreRubro", "NombreSubRubro"})
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      Dim subRubro As Entidades.SubRubro = DirectCast(Me.GetEntidad(), Eniac.Entidades.SubRubro)
      Dim idRubro As Integer = 0
      If subRubro IsNot Nothing Then idRubro = subRubro.IdRubro
      If estado = StateForm.Actualizar Then
         If subRubro Is Nothing Then Throw New Exception("Seleccione un SubRubro a modificar.")
         Return New SubRubrosDetalle(idRubro, subRubro)
      End If
      Return New SubRubrosDetalle(idRubro, New Entidades.SubRubro())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.SubRubros()
   End Function
   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.SubRubros.rdlc", "SistemaDataSet_SubRubros", Me.dtDatos, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = "SubRubros"
         frmImprime.Show()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim oSubRub As Entidades.SubRubro = New Entidades.SubRubro
      If dgvDatos.ActiveRow IsNot Nothing Then
         With Me.dgvDatos.ActiveRow
            If Not IsNumeric(.Cells("IdRubro").Value) Then Return Nothing
            oSubRub.IdRubro = Integer.Parse(.Cells("IdRubro").Value.ToString())
            oSubRub.IdSubRubro = Integer.Parse(.Cells("IdSubRubro").Value.ToString())
            oSubRub = New Reglas.SubRubros().GetUno(oSubRub.IdSubRubro)
         End With
      End If
      Return oSubRub
   End Function
   Protected Overrides Sub FormatearGrilla()
      Dim _decimalesEnDescRec As Integer = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnDescRec
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0

         .Columns("IdRubro").FormatearColumna("Cod.Rub.", col, 50, HAlign.Right)
         .Columns("NombreRubro").FormatearColumna("Rubro", col, 200)
         .Columns("IdSubRubro").FormatearColumna("Código", col, 50, HAlign.Right)
         .Columns("NombreSubRubro").FormatearColumna("SubRubro", col, 200)

         .Columns("NombreRubroSubRubro").FormatearColumna("Rubro - SubRubro", col, 200,, hidden:=True)

         .Columns("DescuentoRecargoPorc1").FormatearColumna("% D/R 1", col, 90, HAlign.Right, , "N2")
         .Columns("DescuentoRecargoPorc2").FormatearColumna("% D/R 2", col, 90, HAlign.Right, , "N2")

         .Columns("UnidHasta1").FormatearColumna("A partir de unid.", col, 80, HAlign.Right)
         .Columns("UHPorc1").FormatearColumna("%", col, 80, HAlign.Right, , "N" + _decimalesEnDescRec.ToString())
         .Columns("UnidHasta2").FormatearColumna("A partir de unid.", col, 80, HAlign.Right)
         .Columns("UHPorc2").FormatearColumna("%", col, 80, HAlign.Right, , "N" + _decimalesEnDescRec.ToString())
         .Columns("UnidHasta3").FormatearColumna("A partir de unid.", col, 80, HAlign.Right)
         .Columns("UHPorc3").FormatearColumna("%", col, 80, HAlign.Right, , "N" + _decimalesEnDescRec.ToString())
         .Columns("UnidHasta4").FormatearColumna("A partir de unid.", col, 80, HAlign.Right)
         .Columns("UHPorc4").FormatearColumna("%", col, 80, HAlign.Right, , "N" + _decimalesEnDescRec.ToString())
         .Columns("UnidHasta5").FormatearColumna("A partir de unid.", col, 80, HAlign.Right)
         .Columns("UHPorc5").FormatearColumna("%", col, 80, HAlign.Right, , "N" + _decimalesEnDescRec.ToString())
         .Columns("IdSubRubroTiendaNube").FormatearColumna("Cód. SubRubro Tienda Nube", col, 80, HAlign.Right)
         .Columns("IdSubRubroMercadoLibre").FormatearColumna("Cód. SubRubro Mercado Libre", col, 80, HAlign.Right)
         .Columns("IdSubRubroArborea").FormatearColumna("Cód. SubRubro Arborea", col, 80, HAlign.Right)
         '-- REQ-34666.- -------------------------------------------------------------------------------------
         .Columns("GrupoAtributo01").FormatearColumna("GrupoAtributo01", col, 80, HAlign.Right).Hidden = True
         .Columns("TipoAtributo01").FormatearColumna("TipoAtributo01", col, 80, HAlign.Right).Hidden = True
         .Columns("GrupoAtributo02").FormatearColumna("GrupoAtributo02", col, 80, HAlign.Right).Hidden = True
         .Columns("TipoAtributo02").FormatearColumna("TipoAtributo02", col, 80, HAlign.Right).Hidden = True
         .Columns("GrupoAtributo03").FormatearColumna("GrupoAtributo03", col, 80, HAlign.Right).Hidden = True
         .Columns("TipoAtributo03").FormatearColumna("TipoAtributo03", col, 80, HAlign.Right).Hidden = True
         .Columns("GrupoAtributo04").FormatearColumna("GrupoAtributo04", col, 80, HAlign.Right).Hidden = True
         .Columns("TipoAtributo04").FormatearColumna("TipoAtributo04", col, 80, HAlign.Right).Hidden = True
         '----------------------------------------------------------------------------------------------------
         .Columns(Entidades.SubRubro.Columnas.CodigoExportacion.ToString()).FormatearColumna("Cód. Exportación", col, 80, HAlign.Left)
         .Columns(Entidades.SubRubro.Columnas.FechaActualizacionWeb.ToString()).Hidden = True
         .Columns("Atributos").Hidden = True
      End With
   End Sub

#End Region

End Class