<Serializable()>
Public Class ParametroImagen
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "ParametrosImagenes"

   Public Enum Columnas
      IdEmpresa
      IdParametroImagen
      ValorParametroImagen

   End Enum

   Public Enum Parametros
      LOGOEMPRESA
   End Enum

#Region "Propiedades"
   Public Property IdEmpresa As Integer
   Public Property IdParametroImagenes As String
   Public Property ValorParametroImagenes As System.Drawing.Image

#End Region

End Class