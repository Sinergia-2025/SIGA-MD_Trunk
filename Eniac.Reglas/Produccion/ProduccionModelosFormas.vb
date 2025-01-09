Public Class ProduccionModelosFormas
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.ProduccionModeloForma.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ProduccionModeloForma), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ProduccionModeloForma), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ProduccionModeloForma), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return Buscar(entidad, pivotVariables:=False)
   End Function
   Public Overloads Function Buscar(entidad As Entidades.Buscar, pivotVariables As Boolean) As DataTable
      Return New SqlServer.ProduccionModelosFormas(da).Buscar(entidad.Columna, entidad.Valor.ToString(), pivotVariables)
   End Function

   Public Overrides Function GetAll() As DataTable
      Return GetAll(pivotVariables:=False)
   End Function
   Public Overloads Function GetAll(pivotVariables As Boolean) As DataTable
      Return New SqlServer.ProduccionModelosFormas(da).ProduccionModelosFormas_GA(pivotVariables)
   End Function

#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.ProduccionModelosFormas
      Return New SqlServer.ProduccionModelosFormas(da)
   End Function

   Private Sub EjecutaSP(en As Entidades.ProduccionModeloForma, tipo As TipoSP)
      Dim sqlC = GetSql()
      Dim rVariable = New ProduccionModelosFormasVariables(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.ProduccionModelosFormas_I(en.IdProduccionModeloForma, en.NombreProduccionModeloForma)
            rVariable._Insertar(en)
         Case TipoSP._U
            sqlC.ProduccionModelosFormas_U(en.IdProduccionModeloForma, en.NombreProduccionModeloForma)
            rVariable._Actualizar(en)
         Case TipoSP._D
            rVariable._Borrar(en)
            sqlC.ProduccionModelosFormas_D(en.IdProduccionModeloForma)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.ProduccionModeloForma, dr As DataRow)
      With o
         .IdProduccionModeloForma = dr.Field(Of Integer)(Entidades.ProduccionModeloForma.Columnas.IdProduccionModeloForma.ToString())
         .NombreProduccionModeloForma = dr.Field(Of String)(Entidades.ProduccionModeloForma.Columnas.NombreProduccionModeloForma.ToString())
         .Variables = New ProduccionModelosFormasVariables(da).GetTodos(.IdProduccionModeloForma)
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(idProduccionModeloForma As Integer) As Entidades.ProduccionModeloForma
      Return GetUno(idProduccionModeloForma, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idProduccionModeloForma As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.ProduccionModeloForma
      Return CargaEntidad(GetSql().ProduccionModelosFormas_G1(idProduccionModeloForma),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProduccionModeloForma(),
                          accion, String.Format("No existe Modelo de Forma de Producción con Id {0}", idProduccionModeloForma))
   End Function

   Public Function GetTodos() As List(Of Entidades.ProduccionModeloForma)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProduccionModeloForma())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return GetSql().GetCodigoMaximo()
   End Function

#End Region
End Class