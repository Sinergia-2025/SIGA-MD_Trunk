#Region "Option/Imports"
Option Strict On
Option Explicit On
Option Infer On
#End Region
Namespace FilterManager
   Friend Interface IFilterManagerSelectorDetalle
      ReadOnly Property ListaFiltrosSeleccionados As List(Of Controles.IFilterControl)
      ReadOnly Property Nombre As String
      ReadOnly Property Usuario As UsuarioActualTodos
      ReadOnly Property Sucursal As SucursalActualTodas
   End Interface
End Namespace