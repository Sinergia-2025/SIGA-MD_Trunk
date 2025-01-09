Public Class CategoriasFiscalesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CategoriasFiscalesDetalle(DirectCast(GetEntidad(), Entidades.CategoriaFiscal))
      End If
      Return New CategoriasFiscalesDetalle(New Entidades.CategoriaFiscal())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CategoriasFiscales()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      TryCatched(
      Sub()
         Dim parm = New ReportParameterCollection()
         Dim frmImprime = New VisorReportes("Eniac.Win.CategoriasFiscales.rdlc", "SistemaDataSet_CategoriasFiscales", dtDatos, parm, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Text
         frmImprime.Show()
      End Sub)
   End Sub

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      With dgvDatos.ActiveRow
         Dim rCF = New Reglas.CategoriasFiscales()
         Return rCF.GetUno(Short.Parse(.Cells(Entidades.CategoriaFiscal.Columnas.IdCategoriaFiscal).Value.ToString()))
      End With
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         .Columns(Entidades.CategoriaFiscal.Columnas.IdCategoriaFiscal.ToString()).FormatearColumna("Codigo", pos, 50, HAlign.Right)
         .Columns(Entidades.CategoriaFiscal.Columnas.NombreCategoriaFiscal.ToString()).FormatearColumna("Nombre", pos, 200)
         .Columns(Entidades.CategoriaFiscal.Columnas.NombreCategoriaFiscalAbrev.ToString()).FormatearColumna("Abrev.", pos, 80)

         .Columns(Entidades.CategoriaFiscal.Columnas.LetraFiscal.ToString()).FormatearColumna("Letra Venta", pos, 60, HAlign.Center)
         .Columns(Entidades.CategoriaFiscal.Columnas.LetraFiscalCompra.ToString()).FormatearColumna("Letra Compra", pos, 60, HAlign.Center)
         .Columns(Entidades.CategoriaFiscal.Columnas.IvaDiscriminado.ToString()).FormatearColumna("Discrimina IVA", pos, 80, HAlign.Center)

         .Columns(Entidades.CategoriaFiscal.Columnas.UtilizaImpuestos.ToString()).FormatearColumna("Util. Impuestos", pos, 85, HAlign.Center)
         .Columns(Entidades.CategoriaFiscal.Columnas.CondicionIvaImpresoraFiscalEpson.ToString()).FormatearColumna("Codigo Fiscal EPSON", pos, 60, HAlign.Center)
         .Columns(Entidades.CategoriaFiscal.Columnas.CondicionIvaImpresoraFiscalHasar.ToString()).FormatearColumna("Codigo Fiscal HASAR", pos, 60, HAlign.Center)

         .Columns(Entidades.CategoriaFiscal.Columnas.Activo.ToString()).FormatearColumna("Activo", pos, 50, HAlign.Center)
         .Columns(Entidades.CategoriaFiscal.Columnas.SolicitaCUIT.ToString()).FormatearColumna("Solicita CUIT", pos, 70, HAlign.Center)
         .Columns(Entidades.CategoriaFiscal.Columnas.EsPasiblePercIIBB.ToString()).FormatearColumna("Es Pasible Percepción IIBB", pos, 100, HAlign.Center)

         .Columns(Entidades.CategoriaFiscal.Columnas.UtilizaAlicuota2Producto.ToString()).FormatearColumna("Utiliza Alícuota 2", pos, 50, HAlign.Center, Not Reglas.Publicos.ProductoUtilizaAlicuota2)
         .Columns(Entidades.CategoriaFiscal.Columnas.CodigoExportacion.ToString()).FormatearColumna("Cód. Exportación", pos, 80, HAlign.Center)

         .Columns(Entidades.CategoriaFiscal.Columnas.LeyendaCategoriaFiscal.ToString()).FormatearColumna("Leyenda", pos, 350) '-.PE-34189.-
         '-- REQ-34587.- -------------------------------------------------------------------------------------------------------------------
         .Columns(Entidades.CategoriaFiscal.Columnas.IvaCeroCategoriaFiscal.ToString()).FormatearColumna("Iva Cero", pos, 50)
         '----------------------------------------------------------------------------------------------------------------------------------
         AgregarFiltroEnLinea(dgvDatos, {"IdCategoriaFiscal", "NombreCategoriaFiscal"})
      End With
   End Sub

#End Region

End Class