Namespace FilterManager
   Public Class FuncionFiltro
      Inherits Entidad
      Implements IEqualityComparer(Of FuncionFiltro)

      Public Const NombreTabla As String = "FuncionesFiltros"

      Public Enum Columnas
         IdFuncion
         IdFiltro
         IdSucursal
         IdUsuario
         NombreFiltro

      End Enum

      Public Sub New()
         Controles = New List(Of FuncionFiltroControl)()
      End Sub

      Public Property IdFuncion As String
      Public Property IdFiltro As Integer
      Public Property NombreFiltro As String

      Public Property PorDefecto As Boolean
      Public ReadOnly Property PorDefectoResuelto As String
         Get
            Return If(PorDefecto, "Por defecto", String.Empty)
         End Get
      End Property

      Public Property Controles As List(Of FuncionFiltroControl)

#Region "IEqualityComparer"
      Public Overrides Function Equals(obj As Object) As Boolean
         Return TypeOf (obj) Is Entidades.FilterManager.FuncionFiltro AndAlso Me.Equals(Me, DirectCast(obj, Entidades.FilterManager.FuncionFiltro))
      End Function
      Public Overrides Function GetHashCode() As Integer
         Return Me.GetHashCode(Me)
      End Function

      Public Overloads Function Equals(x As FuncionFiltro, y As FuncionFiltro) As Boolean Implements IEqualityComparer(Of FuncionFiltro).Equals
         Return x IsNot Nothing AndAlso y IsNot Nothing AndAlso x.IdFuncion = x.IdFuncion AndAlso x.IdFiltro = y.IdFiltro
      End Function

      Public Overloads Function GetHashCode(obj As FuncionFiltro) As Integer Implements IEqualityComparer(Of FuncionFiltro).GetHashCode
         Return Tuple.Create(obj.IdFuncion, obj.IdFiltro).GetHashCode()
      End Function
#End Region
   End Class
End Namespace