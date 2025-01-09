Public Class ProduccionProductosComponentesNrosSerie
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.ProduccionProductoCompNroSerie.NombreTabla, accesoDatos)
   End Sub

#End Region

#Region "Overrides"

   Public Overloads Function GetAll(idSucursal As Integer, idproduccion As Integer, orden As Integer, idProducto As String,
                                    idProductoComponente As String, secuenciaFormula As Integer) As DataTable
      Return New SqlServer.ProduccionProductosComponentesNrosSerie(da).ProduccionProductosComponentesNrosSerie_GA(idSucursal, idproduccion, orden, idProducto, idProductoComponente, secuenciaFormula)
   End Function

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.ProduccionProductoCompNroSerie)))
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos(idSucursal As Integer, idproduccion As Integer, orden As Integer, idProducto As String,
                            idProductoComponente As String, secuenciaFormula As Integer) As List(Of Entidades.ProduccionProductoCompNroSerie)
      Return CargaLista(GetAll(idSucursal, idproduccion, orden, idProducto, idProductoComponente, secuenciaFormula),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProduccionProductoCompNroSerie())
   End Function

   Public Sub _Insertar(entidad As Entidades.ProduccionProductoCompNroSerie)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Insertar(entidad As Entidades.ProduccionProductoComp)
      entidad.NrosSerie.ForEach(
         Sub(l)
            l.SetProduccionProductoComp(entidad)
            _Insertar(l)
         End Sub)
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.ProduccionProductoCompNroSerie, tipo As TipoSP)
      Dim sql = New SqlServer.ProduccionProductosComponentesNrosSerie(da)
      Select Case tipo
         Case TipoSP._I
            sql.ProduccionProductosComponentesNrosSerie_I(en.IdSucursal, en.IdProduccion, en.Orden, en.IdProducto,
                                                          en.IdProductoComponente, en.SecuenciaFormula, en.NroSerie)

         Case TipoSP._U
            Throw New NotImplementedException("El método UPDATE de la tabla ProduccionProductosComponentesNrosSerie no está implementado")

         Case TipoSP._D
            Throw New NotImplementedException("El método DELETE de la tabla ProduccionProductosComponentesNrosSerie no está implementado")

         Case TipoSP._M
            Throw New NotImplementedException("El método MERGE de la tabla ProduccionProductosComponentesNrosSerie no está implementado")

      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.ProduccionProductoCompNroSerie, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)("IdSucursal")
         .IdProduccion = dr.Field(Of Integer)("IdProduccion")
         .Orden = dr.Field(Of Integer)("Orden")
         .IdProducto = dr.Field(Of String)("IdProducto")

         .IdProductoComponente = dr.Field(Of String)("IdProductoComponente")
         .SecuenciaFormula = dr.Field(Of Integer)("SecuenciaFormula")
         .NroSerie = dr.Field(Of String)("NroSerie")
      End With
   End Sub

#End Region

End Class