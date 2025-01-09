#Region "Option/Imports"
Option Explicit On
Option Strict On
Imports Infragistics.Win.UltraWinGrid
#End Region
Public Class RubrosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Ayudante.Grilla.AgregarFiltroEnLinea(Me.dgvDatos, {"NombreRubro"})
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New RubrosDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.Rubro))
      End If
      Return New RubrosDetalle(New Entidades.Rubro)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Rubros()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Rubros.rdlc", "SistemaDataSet_Rubros", Me.dtDatos, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = "Rubros"
         frmImprime.Show()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim rubro As Entidades.Rubro = New Entidades.Rubro()
      Dim reg As Reglas.Rubros = New Reglas.Rubros()

      With Me.dgvDatos.ActiveCell.Row
         rubro.IdRubro = Integer.Parse(.Cells("IdRubro").Value.ToString())

         rubro = reg.GetUno(rubro.IdRubro)

      End With
      Return rubro
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0

         .Columns("IdRubro").FormatearColumna("Código", pos, 70, HAlign.Right)
         .Columns("NombreRubro").FormatearColumna("Nombre", pos, 200)
         .Columns("Orden").FormatearColumna("Orden", pos, 70, HAlign.Right)
         .Columns("ComisionPorVenta").FormatearColumna("Comision por Venta", pos, 70, HAlign.Right, , "N2")
         .Columns("IdProvincia").FormatearColumna("Prov.", pos, 40, HAlign.Center)
         .Columns("IdActividad").FormatearColumna("Cod. Actividad", pos, 100, HAlign.Right)

         Dim _decimalesEnDescRec As Integer = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnDescRec
         Dim formatoDescRec As String = "N" + _decimalesEnDescRec.ToString()

         .Columns(Entidades.Rubro.Columnas.UnidHasta1.ToString()).FormatearColumna("A partir de unid.", pos, 80, HAlign.Right, , "N2")
         .Columns(Entidades.Rubro.Columnas.UHPorc1.ToString()).FormatearColumna("%", pos, 80, HAlign.Right, , formatoDescRec)

         .Columns(Entidades.Rubro.Columnas.UnidHasta2.ToString()).FormatearColumna("A partir de unid.", pos, 80, HAlign.Right, , "N2")
         .Columns(Entidades.Rubro.Columnas.UHPorc2.ToString()).FormatearColumna("%", pos, 80, HAlign.Right, , formatoDescRec)

         .Columns(Entidades.Rubro.Columnas.UnidHasta3.ToString()).FormatearColumna("A partir de unid.", pos, 80, HAlign.Right, , "N2")
         .Columns(Entidades.Rubro.Columnas.UHPorc3.ToString()).FormatearColumna("%", pos, 80, HAlign.Right, , formatoDescRec)

         .Columns(Entidades.Rubro.Columnas.UnidHasta4.ToString()).FormatearColumna("A partir de unid.", pos, 80, HAlign.Right, , "N2")
         .Columns(Entidades.Rubro.Columnas.UHPorc4.ToString()).FormatearColumna("%", pos, 80, HAlign.Right, , formatoDescRec)

         .Columns(Entidades.Rubro.Columnas.UnidHasta5.ToString()).FormatearColumna("A partir de unid.", pos, 80, HAlign.Right, , "N2")
         .Columns(Entidades.Rubro.Columnas.UHPorc5.ToString()).FormatearColumna("%", pos, 80, HAlign.Right, , formatoDescRec)


         .Columns(Entidades.Rubro.Columnas.DescuentoRecargoPorc1.ToString()).FormatearColumna("% D/R 1", pos, 80, HAlign.Right, , "N2")
         .Columns(Entidades.Rubro.Columnas.DescuentoRecargoPorc2.ToString()).FormatearColumna("% D/R 2", pos, 80, HAlign.Right, , "N2")
         .Columns(Entidades.Rubro.Columnas.IdRubroTiendaNube.ToString()).FormatearColumna("Cód. Rubro Tienda Nube", pos, 80, HAlign.Right)
         '-- REQ-30521.- --
         .Columns(Entidades.Rubro.Columnas.IdRubroMercadoLibre.ToString()).FormatearColumna("Cód. Rubro Mercado Libre", pos, 80, HAlign.Right)
         '-----------------

         FormatearColumna(.Columns(Entidades.Rubro.Columnas.CodigoExportacion.ToString()), "Cód. Exportación", pos, 80, HAlign.Left)

         .Columns(Entidades.Rubro.Columnas.FechaActualizacionWeb.ToString()).Hidden = True
      End With

   End Sub

#End Region

End Class