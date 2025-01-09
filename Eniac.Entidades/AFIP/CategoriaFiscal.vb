<Serializable()>
Public Class CategoriaFiscal
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdCategoriaFiscal
      NombreCategoriaFiscal
      NombreCategoriaFiscalAbrev
      LetraFiscal
      LetraFiscalCompra
      IvaDiscriminado
      UtilizaImpuestos
      CondicionIvaImpresoraFiscalEpson
      CondicionIvaImpresoraFiscalHasar
      Activo
      SolicitaCUIT
      EsPasiblePercIIBB
      UtilizaAlicuota2Producto
      CodigoExportacion
      LeyendaCategoriaFiscal
      IvaCeroCategoriaFiscal
   End Enum

   Public Sub New()
      IdCategoriaFiscal = 0
      NombreCategoriaFiscal = ""
      NombreCategoriaFiscalAbrev = ""
      LetraFiscal = ""
      LetraFiscalCompra = ""
      IvaDiscriminado = False
      UtilizaImpuestos = False
      CondicionIvaImpresoraFiscalEpson = ""
      CondicionIvaImpresoraFiscalHasar = ""
      Activo = False
      SolicitaCUIT = False
      EsPasiblePercIIBB = False
      UtilizaAlicuota2Producto = False
   End Sub

#Region "Propiedades"

   Public Property IdCategoriaFiscal As Short
   Public Property NombreCategoriaFiscal As String
   Public Property NombreCategoriaFiscalAbrev As String
   Public Property LetraFiscal As String
   Public Property LetraFiscalCompra As String
   Public Property IvaDiscriminado As Boolean
   Public Property UtilizaImpuestos As Boolean
   Public Property CondicionIvaImpresoraFiscalEpson As String
   Public Property CondicionIvaImpresoraFiscalHasar As String
   Public Property Activo As Boolean
   Public Property SolicitaCUIT As Boolean
   Public Property EsPasiblePercIIBB As Boolean
   Public Property UtilizaAlicuota2Producto As Boolean
   Public Property CodigoExportacion As String
   Public Property LeyendaCategoriaFiscal As String
   Public Property IvaCeroCategoriaFiscal As String
#End Region

   Public Function GetCopia() As Entidades.CategoriaFiscal
      Dim copia As Entidades.CategoriaFiscal = New Entidades.CategoriaFiscal()
      With copia
         .Activo = Me._Activo
         .CondicionIvaImpresoraFiscalEpson = Me._CondicionIvaImpresoraFiscalEpson
         .CondicionIvaImpresoraFiscalHasar = Me._CondicionIvaImpresoraFiscalHasar
         .IdCategoriaFiscal = Me._IdCategoriaFiscal
         .IdSucursal = Me.IdSucursal
         .IvaDiscriminado = Me._IvaDiscriminado
         .LetraFiscal = Me._LetraFiscal
         .LetraFiscalCompra = Me._LetraFiscalCompra
         .NombreCategoriaFiscal = Me._NombreCategoriaFiscal
         .NombreCategoriaFiscalAbrev = Me._NombreCategoriaFiscalAbrev
         .Password = Me.Password
         .Usuario = Me.Usuario
         .UtilizaImpuestos = Me._UtilizaImpuestos
         .SolicitaCUIT = Me._SolicitaCUIT
         .UtilizaAlicuota2Producto = Me._UtilizaAlicuota2Producto
      End With
      Return copia
   End Function

End Class