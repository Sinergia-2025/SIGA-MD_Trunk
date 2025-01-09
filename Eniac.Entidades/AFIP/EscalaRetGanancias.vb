Public Class EscalaRetGanancias
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdEscala
      MontoMasDe
      MontoA
      Importe
      MasPorcentaje
      SobreExcedente
   End Enum

#Region "Propiedades"

   Private _IdEscala As Integer
   Public Property IdEscala() As Integer
      Get
         Return _IdEscala
      End Get
      Set(ByVal value As Integer)
         _IdEscala = value
      End Set
   End Property

   Private _MontoMasDe As Decimal
   Public Property MontoMasDe() As Decimal
      Get
         Return _MontoMasDe
      End Get
      Set(ByVal value As Decimal)
         _MontoMasDe = value
      End Set
   End Property

   Private _MontoA As Decimal
   Public Property MontoA() As Decimal
      Get
         Return _MontoA
      End Get
      Set(ByVal value As Decimal)
         _MontoA = value
      End Set
   End Property

   Private _Importe As Decimal
   Public Property Importe() As Decimal
      Get
         Return _Importe
      End Get
      Set(ByVal value As Decimal)
         _Importe = value
      End Set
   End Property

   Private _MasPorcentaje As Decimal
   Public Property MasPorcentaje() As Decimal
      Get
         Return _MasPorcentaje
      End Get
      Set(ByVal value As Decimal)
         _MasPorcentaje = value
      End Set
   End Property


   Private _SobreExcedente As Decimal
   Public Property SobreExcedente() As Decimal
      Get
         Return _SobreExcedente
      End Get
      Set(ByVal value As Decimal)
         _SobreExcedente = value
      End Set
   End Property
#End Region

   Public Function GetCopia() As Entidades.EscalaRetGanancias
      Dim copia As Entidades.EscalaRetGanancias = New Entidades.EscalaRetGanancias()
      With copia
         .IdEscala = Me._IdEscala
         .MontoMasDe = Me._MontoMasDe
         .MontoA = Me._MontoA
         .Importe = Me._IdEscala
         .MasPorcentaje = Me._MasPorcentaje
         .SobreExcedente = Me._SobreExcedente
         .Password = Me.Password
         .Usuario = Me.Usuario
      End With
      Return copia
   End Function

End Class
