Public Class TableroControl
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "TablerosControl"
   Public Enum Columnas
      IdTableroControl
      NombreTableroControl
      IdTableroControlPanel1
      IdTableroControlPanel2
      IdTableroControlPanel3
      IdTableroControlPanel4
      IdTableroControlPanel5
      IdTableroControlPanel6
      IdControllerFiltro
   End Enum

   Public Property IdTableroControl As Integer
   Public Property NombreTableroControl As String

   Public Property TableroControlPanel1 As TableroControlPanel
   Public Property TableroControlPanel2 As TableroControlPanel
   Public Property TableroControlPanel3 As TableroControlPanel
   Public Property TableroControlPanel4 As TableroControlPanel
   Public Property TableroControlPanel5 As TableroControlPanel
   Public Property TableroControlPanel6 As TableroControlPanel
   Public Property IdControllerFiltro As String

   Public ReadOnly Property IdTableroControlPanel1 As Integer
      Get
         Return If(TableroControlPanel1 Is Nothing, 0, TableroControlPanel1.IdTableroControlPanel)
      End Get
   End Property
   Public ReadOnly Property IdTableroControlPanel2 As Integer
      Get
         Return If(TableroControlPanel2 Is Nothing, 0, TableroControlPanel2.IdTableroControlPanel)
      End Get
   End Property
   Public ReadOnly Property IdTableroControlPanel3 As Integer
      Get
         Return If(TableroControlPanel3 Is Nothing, 0, TableroControlPanel3.IdTableroControlPanel)
      End Get
   End Property
   Public ReadOnly Property IdTableroControlPanel4 As Integer
      Get
         Return If(TableroControlPanel4 Is Nothing, 0, TableroControlPanel4.IdTableroControlPanel)
      End Get
   End Property
   Public ReadOnly Property IdTableroControlPanel5 As Integer
      Get
         Return If(TableroControlPanel5 Is Nothing, 0, TableroControlPanel5.IdTableroControlPanel)
      End Get
   End Property
   Public ReadOnly Property IdTableroControlPanel6 As Integer
      Get
         Return If(TableroControlPanel6 Is Nothing, 0, TableroControlPanel6.IdTableroControlPanel)
      End Get
   End Property
End Class