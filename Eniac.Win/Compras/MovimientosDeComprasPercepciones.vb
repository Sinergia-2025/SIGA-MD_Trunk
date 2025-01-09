Option Strict On
Option Explicit On
Imports Infragistics.Win.UltraWinGrid

Public Class MovimientosDeComprasPercepciones

   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private Property DtProvincias As DataTable
   Private Property ComprasImpuestos As List(Of Entidades.CompraImpuesto)

   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(dtProvincias As DataTable)
      Me.New()
      Me.DtProvincias = dtProvincias
   End Sub

   Public Sub New(comprasImpuestos As List(Of Entidades.CompraImpuesto))
      Me.New()
      Me.ComprasImpuestos = comprasImpuestos
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         _tit = New Dictionary(Of String, String)()
         For Each col As UltraGridColumn In ugDetalle.DisplayLayout.Bands(0).Columns
            If Not col.Hidden Then
               _tit.Add(col.Key, String.Empty)
            End If
         Next
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

      Try
         If DtProvincias IsNot Nothing Then
            If Not DtProvincias.Columns.Contains("_OrdenGrillaPercepciones") Then
               DtProvincias.Columns.Add("_OrdenGrillaPercepciones", GetType(Integer))
            End If

            For Each dr As DataRow In DtProvincias.Rows
               If IsNumeric(dr("Importe")) AndAlso Decimal.Parse(dr("Importe").ToString()) <> 0 Then
                  dr("_OrdenGrillaPercepciones") = 0
               Else
                  dr("_OrdenGrillaPercepciones") = 1
               End If
            Next

            ugDetalle.DataSource = DtProvincias

            With ugDetalle.DisplayLayout.Bands(0)
               .SortedColumns.Clear()
               .SortedColumns.Add("_OrdenGrillaPercepciones", False)
               .SortedColumns.Add(Entidades.Provincia.Columnas.NombreProvincia.ToString(), False)
            End With
         ElseIf ComprasImpuestos IsNot Nothing Then
            ugDetalle.DataSource = ComprasImpuestos
            ugDetalle.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
         End If

         AjustarColumnasGrilla()
         ugDetalle.Focus()
         '-- REQ-35083.- --------------------
         If ugDetalle.Count <> 0 Then
            ugDetalle.IrPrimerCeldaEditable()
         End If
         '-----------------------------------
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      Try
         If DtProvincias IsNot Nothing Then
            ugDetalle.UpdateData()

            Dim result As MovimientosDeComprasV2.ValidaProvinciasResult = MovimientosDeComprasV2.ValidaProvincias(_DtProvincias)
            If Not result.Valida Then
               ShowMessage(result.Mensaje)
               ugDetalle.Focus()
               ugDetalle.IrPrimerCeldaEditable()
               Exit Sub
            End If

            DtProvincias.AcceptChanges()
         End If
         DialogResult = Windows.Forms.DialogResult.OK
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      Try
         If DtProvincias IsNot Nothing Then
            DtProvincias.RejectChanges()
         End If
         DialogResult = Windows.Forms.DialogResult.Cancel
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


   Private Sub AjustarColumnasGrilla()
      'SI SE DESEA CAMBIAR EL TITULO DE ALGUNA COLUMNA EN PARTICULAR
      'tit("NOMBRECOLUMNA") = "NUEVO HEADER"

      For Each col As UltraGridColumn In ugDetalle.DisplayLayout.Bands(0).Columns
         col.Hidden = Not _tit.ContainsKey(col.Key)
         If _tit.ContainsKey(col.Key) Then
            If Not String.IsNullOrWhiteSpace(_tit(col.Key)) Then
               col.Header.Caption = _tit(col.Key)
            End If
         End If
      Next
   End Sub

   Private Sub ugDetalle_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalle.CellChange
      Try
         If e.Cell IsNot Nothing AndAlso e.Cell.Row IsNot Nothing AndAlso
            e.Cell.Row.ListObject IsNot Nothing AndAlso TypeOf (e.Cell.Row.ListObject) Is DataRowView AndAlso
            DirectCast(e.Cell.Row.ListObject, DataRowView).Row IsNot Nothing Then
            ''DirectCast(e.Cell.Row.ListObject, System.ComponentModel.IDataErrorInfo)
            Dim dr As DataRow = DirectCast(e.Cell.Row.ListObject, DataRowView).Row
            dr.SetColumnError(e.Cell.Column.Key, String.Empty)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      Try
         If IsNumeric(e.Row.Cells(Entidades.CompraImpuesto.Columnas.Importe.ToString()).Value) AndAlso
            Decimal.Parse(e.Row.Cells(Entidades.CompraImpuesto.Columnas.Importe.ToString()).Value.ToString()) <> 0 Then
            e.Row.Cells(Entidades.Provincia.Columnas.NombreProvincia.ToString()).Appearance.FontData.Bold = DefaultableBoolean.True
         Else
            e.Row.Cells(Entidades.Provincia.Columnas.NombreProvincia.ToString()).Appearance.FontData.Bold = DefaultableBoolean.Default
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugDetalle_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles ugDetalle.AfterCellUpdate
      Try
         If e.Cell.Column.Key = Entidades.CompraImpuesto.Columnas.BaseImponible.ToString() Or
            e.Cell.Column.Key = Entidades.CompraImpuesto.Columnas.Alicuota.ToString() Then
            Dim baseImponible As Decimal
            Dim alicuota As Decimal
            Dim importe As Decimal

            If IsNumeric(e.Cell.Row.Cells(Entidades.CompraImpuesto.Columnas.BaseImponible.ToString()).Value) Then
               baseImponible = Convert.ToDecimal(e.Cell.Row.Cells(Entidades.CompraImpuesto.Columnas.BaseImponible.ToString()).Value)
            End If
            If IsNumeric(e.Cell.Row.Cells(Entidades.CompraImpuesto.Columnas.Alicuota.ToString()).Value) Then
               alicuota = Convert.ToDecimal(e.Cell.Row.Cells(Entidades.CompraImpuesto.Columnas.Alicuota.ToString()).Value)
            End If

            importe = baseImponible * alicuota / 100

            If e.Cell.Row.ListObject IsNot Nothing AndAlso TypeOf (e.Cell.Row.ListObject) Is DataRowView AndAlso
               DirectCast(e.Cell.Row.ListObject, DataRowView).Row IsNot Nothing Then
               DirectCast(e.Cell.Row.ListObject, DataRowView).Row(Entidades.CompraImpuesto.Columnas.Importe.ToString()) = importe
            End If

         ElseIf e.Cell.Column.Key = Entidades.CompraImpuesto.Columnas.Importe.ToString() Then
            If e.Cell.DataChanged Then
               If e.Cell.Row.ListObject IsNot Nothing AndAlso TypeOf (e.Cell.Row.ListObject) Is DataRowView AndAlso
                  DirectCast(e.Cell.Row.ListObject, DataRowView).Row IsNot Nothing Then
                  DirectCast(e.Cell.Row.ListObject, DataRowView).Row(Entidades.CompraImpuesto.Columnas.BaseImponible.ToString()) = 0
                  DirectCast(e.Cell.Row.ListObject, DataRowView).Row(Entidades.CompraImpuesto.Columnas.Alicuota.ToString()) = 0
               End If

            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class