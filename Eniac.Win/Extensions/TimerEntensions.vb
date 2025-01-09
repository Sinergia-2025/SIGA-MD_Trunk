#Region "Option/Imports"
Option Strict On
Option Explicit On

Imports System.Runtime.CompilerServices
#End Region
Namespace Extensiones
   Public Module TimerEntensions
      <Extension>
      Public Function ReStart(timer As Timer) As Timer
         timer.Stop()
         timer.Start()
         Return timer
      End Function
   End Module
End Namespace