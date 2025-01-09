Option Explicit On
Option Strict On

Imports Eniac.Win

Public Class TiposMovimientosABM

   #Region "Overrides"

      Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
         MyBase.OnLoad(e)
         Me.BotonImprimir.Visible = False
      Ayudante.Grilla.AgregarFiltroEnLinea(dgvDatos, {Entidades.TipoMovimiento.Columnas.IdTipoMovimiento.ToString(),
                                                      Entidades.TipoMovimiento.Columnas.Descripcion.ToString(),
                                                      Entidades.TipoMovimiento.Columnas.ComprobantesAsociados.ToString()})
      End Sub

      Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
         If estado = StateForm.Actualizar Then
         Return New TiposMovimientosDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.TipoMovimiento))
      End If
      Return New TiposMovimientosDetalle(New Entidades.TipoMovimiento)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.TiposMovimientos()
   End Function

   'Protected Overrides Sub Imprimir()
   '   MyBase.Imprimir()
   '   Try
   '      Me.Cursor = Cursors.WaitCursor
   '      Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Categorias.rdlc", "SistemaDataSet_Categorias", Me.dtDatos, True)
   '      frmImprime.Text = "Categorias"
   '      frmImprime.Show()
   '      Me.Cursor = Cursors.Default
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim tipoComp As Entidades.TipoMovimiento = New Entidades.TipoMovimiento
      With Me.dgvDatos.ActiveCell.Row
         tipoComp.IdTipoMovimiento = .Cells(Entidades.TipoMovimiento.Columnas.IdTipoMovimiento.ToString()).Value.ToString()
         tipoComp = New Reglas.TiposMovimientos().GetUno(tipoComp.IdTipoMovimiento)
      End With
      Return tipoComp
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)

         .Columns(Entidades.TipoMovimiento.Columnas.IdTipoMovimiento.ToString()).Header.Caption = "Movimiento"
         .Columns(Entidades.TipoMovimiento.Columnas.IdTipoMovimiento.ToString()).Width = 120

         .Columns(Entidades.TipoMovimiento.Columnas.Descripcion.ToString()).Header.Caption = "Descripción"
         .Columns(Entidades.TipoMovimiento.Columnas.Descripcion.ToString()).Width = 210

         .Columns(Entidades.TipoMovimiento.Columnas.AsociaSucursal.ToString()).Header.Caption = "Asocia Sucursal"

         .Columns(Entidades.TipoMovimiento.Columnas.ComprobantesAsociados.ToString()).Header.Caption = "Comprobantes Asociados"

         .Columns(Entidades.TipoMovimiento.Columnas.CoeficienteStock.ToString()).Header.Caption = "Coef. Stock"
         .Columns(Entidades.TipoMovimiento.Columnas.CoeficienteStock.ToString()).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
         .Columns(Entidades.TipoMovimiento.Columnas.CoeficienteStock.ToString()).Width = 60

         .Columns(Entidades.TipoMovimiento.Columnas.MuestraCombo.ToString()).Header.Caption = "Muestra Combo"

         .Columns(Entidades.TipoMovimiento.Columnas.HabilitaDestinatario.ToString()).Header.Caption = "Habilita Destinatario"

         .Columns(Entidades.TipoMovimiento.Columnas.HabilitaRubro.ToString()).Header.Caption = "Habilita Rubro"

         .Columns(Entidades.TipoMovimiento.Columnas.Imprime.ToString()).Header.Caption = "Imprime"

         .Columns(Entidades.TipoMovimiento.Columnas.CargaPrecio.ToString()).Header.Caption = "Carga Precio"
         .Columns(Entidades.TipoMovimiento.Columnas.CargaPrecio.ToString()).Width = 90

         .Columns(Entidades.TipoMovimiento.Columnas.IdContraTipoMovimiento.ToString()).Header.Caption = "Contra Tipo Movimiento"
         .Columns(Entidades.TipoMovimiento.Columnas.IdContraTipoMovimiento.ToString()).Width = 120

         .Columns(Entidades.TipoMovimiento.Columnas.HabilitaEmpleado.ToString()).Header.Caption = "Habilita Empleado"

         .Columns(Entidades.TipoMovimiento.Columnas.ReservaMercaderia.ToString()).Header.Caption = "Reserva Mercaderia"
      End With
   End Sub

   #End Region

End Class