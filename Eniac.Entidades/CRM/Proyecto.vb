Public Class Proyecto
   Inherits Eniac.Entidades.Entidad

   Public Sub New()
      MyBase.New()
      Me._cliente = New Entidades.Cliente()
      Me.Clasificacion = New Clasificacion()
   End Sub
   Public Enum Columnas
      IdProyecto
      NombreProyecto
      [IdCliente]
      [FechaInicio]
      [FechaFin]
      [Estimado]
      [Presupuestado]
      IdPrioridadImporte
      IdPrioridadEstrategico
      IdPrioridadComplejidad
      IdPrioridadReplicabilidad
      IdPrioridadProyecto
      IdClasificacion
      IdEstado
      FechaFinReal
      HsRealEstimadas
      HsInformadas
      Finalizado
   End Enum

   Public Enum Estados
      Pendiente
      Ejecutando
      Abono
      Cerrado
   End Enum

   Public Property HsRealEstimadas As Decimal
   Public Property HsInformadas As Decimal
   Public Property FechaFinReal As Date?

   Private _idProyecto As Integer
   Public Property IdProyecto As Integer
      Get
         Return Me._idProyecto
      End Get
      Set(value As Integer)
         Me._idProyecto = value
      End Set
   End Property

   Private _nombreProyecto As String
   Public Property NombreProyecto As String
      Get
         Return Me._nombreProyecto
      End Get
      Set(value As String)
         Me._nombreProyecto = value
      End Set
   End Property

   Private _cliente As Entidades.Cliente
   Public Property Cliente As Entidades.Cliente
      Get
         Return Me._cliente
      End Get
      Set(value As Entidades.Cliente)
         Me._cliente = value
      End Set
   End Property

   Private _fechaInicio As DateTime
   Public Property FechaInicio As DateTime
      Get
         Return Me._fechaInicio
      End Get
      Set(value As DateTime)
         Me._fechaInicio = value
      End Set
   End Property

   Private _fechaFin As DateTime
   Public Property FechaFin As DateTime
      Get
         Return Me._fechaFin
      End Get
      Set(value As DateTime)
         Me._fechaFin = value
      End Set
   End Property

   Private _estimado As Decimal
   Public Property Estimado As Decimal
      Get
         Return Me._estimado
      End Get
      Set(value As Decimal)
         Me._estimado = value
      End Set
   End Property

   Private _presupuestado As Decimal
   Public Property Presupuestado As Decimal
      Get
         Return Me._presupuestado
      End Get
      Set(value As Decimal)
         Me._presupuestado = value
      End Set
   End Property

   Public Property Finalizado As Boolean
   Public Property IdPrioridadImporte As Integer
   Public Property IdPrioridadEstrategico As Integer
   Public Property IdPrioridadComplejidad As Integer
   Public Property IdPrioridadReplicabilidad As Integer
   Public Property IdPrioridadProyecto As Decimal
   Public Property Clasificacion As Entidades.Clasificacion
   Public Property IdEstado As Integer

End Class
