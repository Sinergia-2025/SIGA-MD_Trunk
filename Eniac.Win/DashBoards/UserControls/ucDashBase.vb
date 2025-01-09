Public Class ucDashBase
   Public Property oDashBoard As Entidades.DashBoardPaneles
   Public Property oTipoDash As Integer
   Public Property oEditando As Boolean = False
   Protected Property Inicializada As Boolean = False
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
   End Sub
   Public Event PreCargar As EventHandler(Of CancelableEventArgs)
   Protected Sub OnPreCargar(e As CancelableEventArgs)
      RaiseEvent PreCargar(Me, e)
   End Sub
   Public Event Cargando As EventHandler(Of CancelableEventArgs)
   Protected Overridable Sub OnCargando(e As CancelableEventArgs)
      RaiseEvent Cargando(Me, e)
   End Sub
   Public Event PosCargar As EventHandler(Of CancelableEventArgs)
   Protected Sub OnPosCargar(e As CancelableEventArgs)
      RaiseEvent PosCargar(Me, e)
   End Sub
   Public Class CancelableEventArgs
      Inherits EventArgs
      Public Property Cancel As Boolean = False
   End Class
   ''' <summary>
   ''' Proceso de Inicializado de DashBoards.- --
   ''' </summary>
   Public Overridable Sub GetValoresDashBoard()

   End Sub
End Class
