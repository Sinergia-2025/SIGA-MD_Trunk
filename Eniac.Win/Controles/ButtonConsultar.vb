Imports System.ComponentModel

Public Class ButtonConsultar
   Inherits Controles.Button
   Private _leftMaxPosition As Integer?

   Private _anchoredControl As Control
   <DefaultValue(DirectCast(Nothing, Object)), Category("Eniac")>
   Public Property AnchoredControl() As Control
      Get
         Return _anchoredControl
      End Get
      Set(value As Control)
         If Not DesignMode Then
            If value Is Nothing AndAlso _anchoredControl IsNot Nothing Then
               RemoveHandler _anchoredControl.SizeChanged, AddressOf AnchoredControl_SizeChanged
               _leftMaxPosition = Nothing
               RemoveHandler _anchoredControl.VisibleChanged, AddressOf AnchoredControl_VisibleChanged
            End If
         End If
         _anchoredControl = value
         If Not DesignMode Then
            If _anchoredControl IsNot Nothing Then
               AddHandler _anchoredControl.VisibleChanged, AddressOf AnchoredControl_VisibleChanged
               AddHandler _anchoredControl.SizeChanged, AddressOf AnchoredControl_SizeChanged
            End If
         End If
      End Set
   End Property

   Private Sub AnchoredControl_VisibleChanged(sender As Object, e As EventArgs)
      _leftMaxPosition = CalculateLeftPosition(_anchoredControl)
   End Sub

   Private Sub AnchoredControl_SizeChanged(sender As Object, e As EventArgs)
      FindForm().TryCatched(Sub() If AnchoredControl IsNot Nothing Then Location = New Point(CalculateLeftPosition(AnchoredControl), CalculateTopPosition(AnchoredControl)))
   End Sub

   Private Function CalculateLeftPosition(anchoredControl As Control) As Integer
      Dim calculado = anchoredControl.Width + anchoredControl.Left - Width - 4
      If _leftMaxPosition.HasValue AndAlso calculado > _leftMaxPosition Then calculado = _leftMaxPosition.Value
      Return calculado
   End Function
   Private Function CalculateTopPosition(anchoredControl As Control) As Integer
      Return anchoredControl.Top + 2
   End Function
End Class