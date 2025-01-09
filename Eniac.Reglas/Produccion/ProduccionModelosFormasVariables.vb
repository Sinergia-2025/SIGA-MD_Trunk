Public Class ProduccionModelosFormasVariables
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.ProduccionModeloFormaVariable.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.ProduccionModeloFormaVariable)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.ProduccionModeloFormaVariable)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.ProduccionModeloFormaVariable)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.ProduccionModelosFormasVariables(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overloads Function GetAll(idProduccionModeloForma As Integer) As DataTable
      Return New SqlServer.ProduccionModelosFormasVariables(da).ProduccionModelosFormasVariables_GA(idProduccionModeloForma)
   End Function
#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.ProduccionModelosFormasVariables
      Return New SqlServer.ProduccionModelosFormasVariables(da)
   End Function

   Private Sub EjecutaSP(en As Entidades.ProduccionModeloFormaVariable, tipo As TipoSP)
      Dim sqlC = GetSql()
      Select Case tipo
         Case TipoSP._I
            sqlC.ProduccionModelosFormasVariables_I(en.IdProduccionModeloForma, en.CodigoVariable, en.ValorDecimalVariable)
         Case TipoSP._U
            sqlC.ProduccionModelosFormasVariables_U(en.IdProduccionModeloForma, en.CodigoVariable, en.ValorDecimalVariable)
         Case TipoSP._D
            sqlC.ProduccionModelosFormasVariables_D(en.IdProduccionModeloForma, en.CodigoVariable)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.ProduccionModeloFormaVariable, dr As DataRow)
      With o
         .IdProduccionModeloForma = dr.Field(Of Integer)(Entidades.ProduccionModeloFormaVariable.Columnas.IdProduccionModeloForma.ToString())
         .CodigoVariable = dr.Field(Of String)(Entidades.ProduccionModeloFormaVariable.Columnas.CodigoVariable.ToString())
         .ValorDecimalVariable = dr.Field(Of Decimal)(Entidades.ProduccionModeloFormaVariable.Columnas.ValorDecimalVariable.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.ProduccionModeloFormaVariable)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.ProduccionModeloFormaVariable)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.ProduccionModeloFormaVariable)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub _Insertar(entidad As Entidades.ProduccionModeloForma)
      entidad.Variables.ForEach(
         Sub(v)
            v.IdProduccionModeloForma = entidad.IdProduccionModeloForma
            _Insertar(v)
         End Sub)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.ProduccionModeloForma)
      _Borrar(entidad)
      _Insertar(entidad)
   End Sub
   Public Sub _Borrar(entidad As Entidades.ProduccionModeloForma)
      _Borrar(New Entidades.ProduccionModeloFormaVariable() With {.IdProduccionModeloForma = entidad.IdProduccionModeloForma})
   End Sub


   Public Function GetUno(idProduccionModeloForma As Integer, codigoVariable As String) As Entidades.ProduccionModeloFormaVariable
      Return GetUno(idProduccionModeloForma, codigoVariable, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idProduccionModeloForma As Integer, codigoVariable As String, accion As AccionesSiNoExisteRegistro) As Entidades.ProduccionModeloFormaVariable
      Return CargaEntidad(GetSql().ProduccionModelosFormasVariables_G1(idProduccionModeloForma, codigoVariable),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProduccionModeloFormaVariable(),
                          accion, String.Format("No existe Modelo de Forma de Producción con Id {0}", idProduccionModeloForma))
   End Function

   Public Function GetTodos(idProduccionModeloForma As Integer) As List(Of Entidades.ProduccionModeloFormaVariable)
      Return CargaLista(GetAll(idProduccionModeloForma), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProduccionModeloFormaVariable())
   End Function

   Public Function GetDistinctCodigos() As List(Of String)
      Return GetSql().ProduccionModelosFormasVariables_G_DistinctVariables().AsEnumerable().ToList().
         ConvertAll(Function(dr) dr.Field(Of String)(Entidades.ProduccionModeloFormaVariable.Columnas.CodigoVariable.ToString()).IfNull())
   End Function

#End Region

End Class