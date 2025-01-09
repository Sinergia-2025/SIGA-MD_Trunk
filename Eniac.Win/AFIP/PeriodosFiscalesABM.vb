Public Class PeriodosFiscalesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      tsbBorrar.Visible = False
      tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New PeriodosFiscalesDetalle(DirectCast(GetEntidad(), Entidades.PeriodoFiscal))
      End If
      Return New PeriodosFiscalesDetalle(New Entidades.PeriodoFiscal(Reglas.Publicos.AFIPHabilitaVentasPeriodoAutomaticamente))
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.PeriodosFiscales()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)
      Return New Reglas.PeriodosFiscales().GetUno(dr.Field(Of Integer)("IdEmpresa"), dr.Field(Of Integer)("PeriodoFiscal"))
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim cantidadEmpresas = New Reglas.Empresas().Count()
         Dim pos = 0I
         .Columns(Entidades.PeriodoFiscal.Columnas.IdEmpresa.ToString()).FormatearColumna("Código Empresa", pos, 70, HAlign.Right, cantidadEmpresas = 1)
         .Columns(Entidades.PeriodoFiscal.Columnas.PeriodoFiscal.ToString()).FormatearColumna("Periodo", pos, 55, HAlign.Center, , "0000/00")
         .Columns(Entidades.PeriodoFiscal.Columnas.TotalNetoVentas.ToString()).FormatearColumna("Neto Ventas", pos, 75, HAlign.Right, , "N2")
         .Columns(Entidades.PeriodoFiscal.Columnas.TotalImpuestosVentas.ToString()).FormatearColumna("IVA Ventas", pos, 75, HAlign.Right, , "N2")
         .Columns(Entidades.PeriodoFiscal.Columnas.TotalVentas.ToString()).FormatearColumna("Total Ventas", pos, 75, HAlign.Right, , "N2")
         .Columns(Entidades.PeriodoFiscal.Columnas.TotalNetoCompras.ToString()).FormatearColumna("Neto Compras", pos, 75, HAlign.Right, , "N2")
         .Columns(Entidades.PeriodoFiscal.Columnas.TotalImpuestosCompras.ToString()).FormatearColumna("IVA Compras", pos, 75, HAlign.Right, , "N2")
         .Columns(Entidades.PeriodoFiscal.Columnas.TotalCompras.ToString()).FormatearColumna("Neto Compras", pos, 75, HAlign.Right, , "N2")
         .Columns(Entidades.PeriodoFiscal.Columnas.Posicion.ToString()).FormatearColumna("Posición", pos, 75, HAlign.Right, , "N2")
         .Columns(Entidades.PeriodoFiscal.Columnas.TotalRetenciones.ToString()).FormatearColumna("Retenciones", pos, 75, HAlign.Right, , "N2")
         .Columns(Entidades.PeriodoFiscal.Columnas.TotalPercepciones.ToString()).FormatearColumna("Percepciones", pos, 75, HAlign.Right, , "N2")
         .Columns(Entidades.PeriodoFiscal.Columnas.PosicionFinal.ToString()).FormatearColumna("Neto a Pagar", pos, 75, HAlign.Right, , "N2")
         .Columns(Entidades.PeriodoFiscal.Columnas.FechaCierre.ToString()).FormatearColumna("Cierre", pos, 70, HAlign.Center, , "dd/MM/yyyy")
         .Columns(Entidades.PeriodoFiscal.Columnas.UsuarioCierre.ToString()).FormatearColumna("Usuario", pos, 70)
         .Columns(Entidades.PeriodoFiscal.Columnas.VentasHabilitadas.ToString()).FormatearColumna("Ventas Habilitadas", pos, 75, HAlign.Center)
      End With
      dgvDatos.AgregarFiltroEnLinea({})
   End Sub

#End Region

End Class