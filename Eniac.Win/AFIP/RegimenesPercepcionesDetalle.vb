Public Class RegimenesPercepcionesDetalle

#Region "Campos"
   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)
   Private ReadOnly Property Regimen As Entidades.RegimenPercepcion
      Get
         Return DirectCast(_entidad, Entidades.RegimenPercepcion)
      End Get
   End Property
#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.RegimenPercepcion)
      InitializeComponent()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      _publicos = New Publicos()
      _publicos.CargaComboTiposImpuestos(cmbTipoImpuesto, Entidades.TipoImpuesto.Tipos.PIVA)

      BindearControles(_entidad)

      If StateForm = Win.StateForm.Insertar Then
         cmbTipoImpuesto.SelectedIndexIfAny(index:=0)
      Else
      End If

      _tit = GetColumnasVisiblesGrilla(ugAlicuotas)
      SetDatasource()
   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.RegimenesPercepciones()
   End Function

#End Region

#Region "Eventos"

   Private Sub cmbTipoImpuesto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoImpuesto.SelectedValueChanged
      TryCatched(Sub() CargaImpuestos())
   End Sub
   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      TryCatched(Sub() InsertaAlicuota())
   End Sub
   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      TryCatched(Sub() EliminaAlicuota())
   End Sub

#End Region

#Region "Métodos"
   Private Sub SetDatasource()
      ugAlicuotas.DataSource = Regimen.Alicuotas
      AjustarColumnasGrilla(ugAlicuotas, _tit)
   End Sub

   Private Sub CargaImpuestos()
      _publicos.CargaComboImpuestos(cmbAlicutotaPercepcion, cmbTipoImpuesto.ValorSeleccionado(Of String))
   End Sub
   Private Sub InsertaAlicuota()
      Dim idTipoImpuesto = cmbTipoImpuesto.ValorSeleccionado(Of String)
      Dim alicuota = cmbAlicutotaPercepcion.ValorSeleccionado(Of Decimal)
      If Not Regimen.Alicuotas.Any(Function(a) a.IdTipoImpuesto = idTipoImpuesto And a.AlicuotaPercepcion = alicuota) Then
         Regimen.Alicuotas.Add(New Entidades.RegimenPercepcionAlicuota() With {.IdTipoImpuesto = idTipoImpuesto, .AlicuotaPercepcion = alicuota})
      End If
      ugAlicuotas.Rows.Refresh(RefreshRow.FireInitializeRow)
   End Sub
   Private Sub EliminaAlicuota()
      Dim dr = ugAlicuotas.FilaSeleccionada(Of Entidades.RegimenPercepcionAlicuota)()
      If dr IsNot Nothing Then
         If ShowPregunta(String.Format("¿Desea eliminar la alícuota {0}?", dr.AlicuotaPercepcion)) = DialogResult.Yes Then
            Regimen.Alicuotas.Remove(dr)
         End If
         ugAlicuotas.Rows.Refresh(RefreshRow.FireInitializeRow)
      End If
   End Sub
#End Region

End Class