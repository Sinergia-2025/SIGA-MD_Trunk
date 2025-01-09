<Serializable()>
<Description("UnidadesDeMedidas")>
Public Class UnidadDeMedida
   Inherits Entidad

   Public Const NombreTabla As String = "UnidadesDeMedidas"

   Public Enum Columnas
      IdUnidadDeMedida
      NombreUnidadDeMedida
      ConversionAKilos
      IdAFIP
   End Enum

   Public Sub New()
      IdUnidadDeMedida = String.Empty
      NombreUnidadDeMedida = String.Empty
      ConversionAKilos = 0
   End Sub

#Region "Propiedades"

   Public Property IdUnidadDeMedida As String
   Public Property NombreUnidadDeMedida As String
   Public Property ConversionAKilos As Decimal
   ''' <summary>Es el Id que se utiliza para identificar una unidad de Medida en el AFIP.</summary>
   Public Property IdAFIP As Integer

#End Region

   Public Function GetCopia() As UnidadDeMedida
      Dim copia = New UnidadDeMedida With {
         .ConversionAKilos = ConversionAKilos,
         .IdSucursal = IdSucursal,
         .IdUnidadDeMedida = IdUnidadDeMedida,
         .NombreUnidadDeMedida = NombreUnidadDeMedida,
         .Password = Password,
         .Usuario = Usuario
      }
      Return copia
   End Function

End Class