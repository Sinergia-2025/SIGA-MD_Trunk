Imports Infragistics.Win

Public Class ProduccionFormas
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("ProduccionFormas", accesoDatos)
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ProduccionForma), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ProduccionForma), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ProduccionForma), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.ProduccionFormas(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.ProduccionFormas(da).ProduccionFormas_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.ProduccionForma, tipo As TipoSP)
      Dim sqlC = New SqlServer.ProduccionFormas(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.ProduccionFormas_I(en.IdProduccionForma, en.NombreProduccionForma, en.FormulaCalculoKilaje)
         Case TipoSP._U
            sqlC.ProduccionFormas_U(en.IdProduccionForma, en.NombreProduccionForma, en.FormulaCalculoKilaje)
         Case TipoSP._D
            sqlC.ProduccionFormas_D(en.IdProduccionForma)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.ProduccionForma, dr As DataRow)
      With o
         .IdProduccionForma = Integer.Parse(dr(Entidades.ProduccionForma.Columnas.IdProduccionForma.ToString()).ToString())
         .NombreProduccionForma = dr(Entidades.ProduccionForma.Columnas.NombreProduccionForma.ToString()).ToString()
         .FormulaCalculoKilaje = dr(Entidades.ProduccionForma.Columnas.FormulaCalculoKilaje.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(idEstadoNovedad As Integer) As Entidades.ProduccionForma
      Return GetUno(idEstadoNovedad, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idEstadoNovedad As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.ProduccionForma
      Return CargaEntidad(New SqlServer.ProduccionFormas(da).ProduccionFormas_G1(idEstadoNovedad),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProduccionForma(),
                          accion, String.Format("No existe Forma de Producción con Id {0}", idEstadoNovedad))
   End Function

   Public Function GetTodos() As List(Of Entidades.ProduccionForma)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProduccionForma())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.ProduccionFormas(da).GetCodigoMaximo()
   End Function

#End Region


   Public Function EvaluarFormula(formula As String, valores As Entidades.ProduccionFormasVariablesList) As Decimal
      Dim formulaPreparada As String = PreparaFormulaParaEvaluar(formula, valores)
      Dim resultado As Decimal = 0
      Using UltraCalcManager1 = New UltraWinCalcManager.UltraCalcManager()
         Dim resultadoFormula As CalcEngine.UltraCalcValue = UltraCalcManager1.Calculate(formulaPreparada)
         Try
            resultado = resultadoFormula.ToDecimal()
         Catch
            'Si hay algún error devuelvo cero.
         End Try
      End Using
      Return resultado
   End Function

   Public Shared Function GetTodasLasValores() As Entidades.ProduccionFormasVariablesList
      Dim valores = New Entidades.ProduccionFormasVariablesList()

      valores = AgregarValoresPantalla(valores, 0, 0, 0, 0)
      valores = AgregarValoresConstantes(valores)

      Dim vars = New ProduccionModelosFormasVariables().GetDistinctCodigos().ConvertAll(Function(v) New Tuple(Of String, Decimal)(v, 0))

      valores = AgregarValoresModeloForma(valores, vars)

      Return valores
   End Function

   Public Shared Function GetValoresForma(espmm As Decimal, largoExtAlto As Decimal, anchoIntBase As Decimal, architrave As Decimal,
                                          forma As Entidades.ProduccionModeloForma) As Entidades.ProduccionFormasVariablesList
      Dim valores = New Entidades.ProduccionFormasVariablesList()

      valores = AgregarValoresPantalla(valores, espmm, largoExtAlto, anchoIntBase, architrave)
      valores = AgregarValoresModeloForma(valores, forma)

      Return valores
   End Function
   Public Shared Function AgregarValoresPantalla(valores As Entidades.ProduccionFormasVariablesList,
                                                 espmm As Decimal, largoExtAlto As Decimal, anchoIntBase As Decimal, architrave As Decimal) As Entidades.ProduccionFormasVariablesList
      valores.Add("[ESPMM]", espmm)
      valores.Add("[LARGOEXTALTO]", largoExtAlto)
      valores.Add("[ANCHOINTBASE]", anchoIntBase)
      valores.Add("[ARCHITRAVE]", architrave)
      Return valores
   End Function

   Public Shared Function AgregarValoresConstantes(valores As Entidades.ProduccionFormasVariablesList) As Entidades.ProduccionFormasVariablesList
      valores.Add("[PI]", Math.PI.ToDecimal())
      Return valores
   End Function
   Public Shared Function AgregarValoresModeloForma(valores As Entidades.ProduccionFormasVariablesList,
                                                    forma As Entidades.ProduccionModeloForma) As Entidades.ProduccionFormasVariablesList
      If forma IsNot Nothing Then
         Dim vars = forma.Variables.ConvertAll(Function(v) New Tuple(Of String, Decimal)(v.CodigoVariable, v.ValorDecimalVariable))
         AgregarValoresModeloForma(valores, vars)
         'forma.Variables.ForEachSecure(Sub(v) valores.Add(v.CodigoVariable.RodearCon("[", "]"), v.ValorDecimalVariable))
      End If
      Return valores
   End Function
   Public Shared Function AgregarValoresModeloForma(valores As Entidades.ProduccionFormasVariablesList,
                                                    variables As IEnumerable(Of Tuple(Of String, Decimal))) As Entidades.ProduccionFormasVariablesList
      variables.ForEachSecure(Sub(v) valores.Add(v.Item1.RodearCon("[", "]"), v.Item2))
      Return valores
   End Function

   Public Function PreparaFormulaParaEvaluar(formula As String, espmm As Decimal, largoExtAlto As Decimal, anchoIntBase As Decimal, architrave As Decimal,
                                             modeloForma As Entidades.ProduccionModeloForma) As String
      Dim valores = GetValoresForma(espmm, largoExtAlto, anchoIntBase, architrave, modeloForma)
      Return PreparaFormulaParaEvaluar(formula, valores)
   End Function

   Private Function PreparaFormulaParaEvaluar(formula As String, valores As Entidades.ProduccionFormasVariablesList) As String
      AgregarValoresConstantes(valores)
      For Each valor In valores
         If formula.Contains(valor.Key) Then
            formula = formula.Replace(valor.Key, valor.Value.ToString())
         End If
      Next
      Return formula
   End Function

End Class