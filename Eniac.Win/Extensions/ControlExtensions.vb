Imports System.Runtime.CompilerServices
Namespace Extensiones
   Public Module ControlExtensions
      <Extension>
      Public Sub LocateControlOnTabs(uc As Control, accion As Action(Of TabControl, TabPage))
         If uc.Parent IsNot Nothing Then
            If TypeOf (uc.Parent) Is TabPage Then
               Dim tc = DirectCast(uc.Parent.Parent, TabControl)
               'tc.SelectTab(DirectCast(uc.Parent, TabPage))
               If accion IsNot Nothing Then accion(tc, DirectCast(uc.Parent, TabPage))
               LocateControlOnTabs(tc, accion)
            Else
               LocateControlOnTabs(uc.Parent, accion)
            End If
         End If
      End Sub
      <Extension>
      Public Function EsEditable(ctrl As Control) As Boolean
         If TypeOf ctrl Is TextBox Then
            Return ctrl.Enabled AndAlso Not DirectCast(ctrl, TextBox).ReadOnly
         Else
            Return ctrl.Enabled
         End If
      End Function
   End Module
   Public Module ControlesExtensions
      <Extension>
      Public Sub SetVisible(ctrl As Controles.ITieneLabelAsoc, visible As Boolean)
         If TypeOf (ctrl) Is Control Then
            DirectCast(ctrl, Control).Visible = visible
         End If
         If ctrl.LabelAsoc IsNot Nothing Then
            ctrl.LabelAsoc.Visible = visible
         End If
      End Sub
   End Module

End Namespace