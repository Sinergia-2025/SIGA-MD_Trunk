Imports System.ComponentModel

Public Class TimeSpanBox
   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      dtpHora.Value = dtpHora.MinDate.Date
      txtDias.Value = 0
   End Sub


   <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Eniac")>
   Public Property ValueDecimal() As Decimal
      Get
         Return Convert.ToDecimal(dtpHora.Value.TimeOfDay.TotalHours + (txtDias.Value * 24))
      End Get
      Set(value As Decimal)
         SetValores(value)
      End Set
   End Property

   <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Category("Eniac")>
   Public Property ValueTimeSpan() As TimeSpan
      Get
         Return ConvertToTimeSpan(ValueDecimal)
      End Get
      Set(value As TimeSpan)
         ValueDecimal = Convert.ToDecimal(value.TotalHours)
      End Set
   End Property

   <Category("Eniac"), DefaultValue("HH:mm:ss")>
   Public Property FormatoHora() As String
      Get
         Return dtpHora.CustomFormat
      End Get
      Set(value As String)
         dtpHora.CustomFormat = value
      End Set
   End Property
   <Category("Eniac"), DefaultValue(True)>
   Public Property DiasVisible() As Boolean
      Get
         Return txtDias.Visible
      End Get
      Set(value As Boolean)
         txtDias.Visible = value
      End Set
   End Property

   Private Sub SetValores(value As Decimal)
      Dim dias = Math.Truncate(value / 24)
      Dim hora = value - (dias * 24)
      txtDias.Value = dias
      dtpHora.Value = dtpHora.MinDate.Date.AddHours(hora)
   End Sub
   Private Function ConvertToTimeSpan(value As Decimal) As TimeSpan
      Return dtpHora.MinDate.Date.AddHours(value).Subtract(dtpHora.MinDate.Date)
   End Function

#Region "Evento ValueChanged"
   Public Event ValueChanged As EventHandler(Of EventArgs)
   Protected Sub OnValueChanged(e As EventArgs)
      RaiseEvent ValueChanged(Me, e)
   End Sub
   Private Sub txtDias_ValueChanged(sender As Object, e As EventArgs) Handles txtDias.ValueChanged
      OnValueChanged(Nothing)
   End Sub
   Private Sub dtpHora_ValueChanged(sender As Object, e As EventArgs) Handles dtpHora.ValueChanged
      OnValueChanged(Nothing)
   End Sub
#End Region

   Protected Overrides ReadOnly Property DefaultSize As Size
      Get
         Return New Size(110, 20)
      End Get
   End Property

End Class