<Serializable()>
<Description("ContabilidadEjercicio")>
Public Class ContabilidadEjercicio
   Inherits Entidad

   Public Enum Columnas
      IdEjercicio
      FechaDesde
      FechaHasta
      Cerrado
      DetallesPeriodos
   End Enum

   Public Enum ReadOnlyColumnas
      DescripcionEjercicio
   End Enum

   Public Property IdEjercicio As Integer
   Public Property FechaDesde As Date
   Public Property FechaHasta As Date
   Public Property Cerrado As Boolean
   Public Property DetallesPeriodos As DataTable


   Public Property Fuerza_VerificaAsientosPendientes As Boolean = False

#Region "Propiedades ReadOnly"
   Public ReadOnly Property DescripcionEjercicio As String
      Get
         Return String.Format("{0,-4} - {1:dd/MM/yyyy} - {2:dd/MM/yyyy} - {3}", IdEjercicio, FechaDesde, FechaHasta, If(Cerrado, "Cerrado", "Abierto"))
      End Get
   End Property
#End Region

End Class