#Region "Option/Imports"
Option Strict On
Option Explicit On
Option Infer On
#End Region
Namespace FilterManager
   Friend Class SeleccionableFilterControl
      Implements Controles.IFilterControl
      Public Property Filtro As Controles.IFilterControl
      Public Property Seleccionado As Boolean

      Public Sub New(filtro As Controles.IFilterControl)
         Me.Filtro = filtro
         Me.Seleccionado = False
      End Sub

      Public ReadOnly Property DataType As Type Implements Controles.IFilterControl.DataType
         Get
            Return Filtro.DataType
         End Get
      End Property

      Public ReadOnly Property Etiqueta As String Implements Controles.IFilterControl.Etiqueta
         Get
            Return Filtro.Etiqueta
         End Get
      End Property

      Public ReadOnly Property FilterControlName As String Implements Controles.IFilterControl.FilterControlName
         Get
            Return Filtro.FilterControlName
         End Get
      End Property

      Public ReadOnly Property FilterText As String Implements Controles.IFilterControl.FilterText
         Get
            Return Filtro.FilterText
         End Get
      End Property

      Public Property FilterValue As Object Implements Controles.IFilterControl.FilterValue
         Get
            Return Filtro.FilterValue
         End Get
         Set(value As Object)
            Filtro.FilterValue = value
         End Set
      End Property
   End Class
End Namespace