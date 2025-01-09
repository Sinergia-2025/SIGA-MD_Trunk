Public Class AFIPReferenciaTransferenciaABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
   End Sub

   'GET DETALLE
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New AFIPReferenciaTransferenciaDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.AFIPReferenciaTransferencia))
      End If
      Return New AFIPReferenciaTransferenciaDetalle(New Eniac.Entidades.AFIPReferenciaTransferencia)
   End Function

   'GET REGLAS
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.AFIPReferenciasTransferencias()
   End Function

   'GET ENTIDAD
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim AFIPReferenciaTransferencia As Eniac.Entidades.AFIPReferenciaTransferencia = New Eniac.Entidades.AFIPReferenciaTransferencia
      With Me.dgvDatos.ActiveRow
         AFIPReferenciaTransferencia = New Eniac.Reglas.AFIPReferenciasTransferencias().GetUno(.Cells("IdAFIPReferenciaTransferencia").Value.ToString())
      End With
      Return AFIPReferenciaTransferencia
   End Function

   'FORMATEAR GRILLA
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Eniac.Entidades.AFIPReferenciaTransferencia.Columnas.IdAFIPReferenciaTransferencia.ToString()).FormatearColumna("Código", col, 80)
         .Columns(Eniac.Entidades.AFIPReferenciaTransferencia.Columnas.NombreReferenciaTransferencia.ToString()).FormatearColumna("Nombre", col, 400)
         .Columns(Eniac.Entidades.AFIPReferenciaTransferencia.Columnas.DescripcionReferenciaTransferencia.ToString()).FormatearColumna("Descripción", col, 400)
      End With
   End Sub
#End Region

End Class