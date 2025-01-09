Public Class TiposImpresionesFiscales
   Inherits Reglas.Base


#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = Entidades.TipoImpresionFiscal.NombreTabla
      da = New Eniac.Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = Entidades.TipoImpresionFiscal.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Métodos"

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.TiposImpresionesFiscales(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposImpresionesFiscales(da).TiposImpresionesFiscales_GA()
   End Function

#End Region
End Class
