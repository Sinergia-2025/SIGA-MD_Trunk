Public Class ProductosFormulas
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "ProductosFormulas"
      da = accesoDatos
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Sub GrabarFormula(IdProducto As String, IdFormula As Integer, nombreFormula As String, PorcentajeGanancia As Decimal)
      GrabarFormula(IdProducto, IdFormula, nombreFormula, idFormulaCopia:=0, PorcentajeGanancia)
   End Sub
   Public Sub GrabarFormula(idProducto As String, idFormula As Integer,
                            nombreFormula As String, idFormulaCopia As Integer,
                            PorcentajeGanancia As Decimal)
      EjecutaConTransaccion(
      Sub()
         Dim sql = GetSql()
         Using dtFormulas = sql.ProductosFormulas_GA(idProducto, idFormula)
            Dim primera = dtFormulas.Empty()

            sql.ProductosFormulas_I(idProducto, idFormula, nombreFormula, PorcentajeGanancia)
            If idFormulaCopia <> 0 Then
               Dim rComp = New ProductosComponentes(da)
               rComp.CopiarComponentesFormula(idProducto, idFormulaCopia, idFormula)
            End If

            If primera Then
               Dim sqlPC = New SqlServer.ProductosComponentes(da)
               sqlPC.ProductosComponentes_U_FormulaComponenteDelProducto(idProducto, idFormula)
            End If

         End Using
      End Sub)
   End Sub
   Public Sub ModificarFormula(IdProducto As String, IdFormula As Integer, NombreFormula As String, PorcentajeGanancia As Decimal)
      EjecutaConTransaccion(Sub() GetSql().ProductosFormulas_U(IdProducto, IdFormula, NombreFormula, PorcentajeGanancia))
   End Sub
   Public Sub EliminarFormula(idProducto As String, idFormula As Integer)
      EjecutaConTransaccion(
      Sub()
         Dim sql = GetSql()

         Using dtFormulas = sql.ProductosFormulas_GA(idProducto, idFormula)
            Dim rProductos = New Productos(da)
            If dtFormulas.Empty() Then
               rProductos._ActualizarFormulaDefecto(idProducto, idFormula:=0)

               Dim sqlPC = New SqlServer.ProductosComponentes(da)
               sqlPC.ProductosComponentes_U_FormulaComponenteDelProducto(idProducto, idFormula:=0)
               Dim sqlP = New SqlServer.Productos(da)
               sqlP.Productos_U_EsCompuesto(idProducto, False, False)
            Else
               Using dtProducto = rProductos.Get1(idProducto)
                  If dtProducto.Any() AndAlso dtProducto.First().Field(Of Integer?)("IdFormula").IfNull() = idFormula Then
                     Throw New Exception(String.Format("La formula que está queriendo borrar del producto {0} está configurada como formula predeterminada. Debe cambiar la formula predeterminada antes de poder ser borrada.", idProducto))
                  End If
               End Using
            End If
         End Using
         Dim sqlcomp = New SqlServer.ProductosComponentes(da)
         sqlcomp.ProductosComponentes_D(idProducto, idFormula)
         sql.ProductosFormulas_D(idProducto, idFormula)
      End Sub)
   End Sub
   Public Sub _Merge(entidad As Entidades.ProductoFormula)
      EjecutaSP(entidad, TipoSP._M)
   End Sub

   Public Function GetFormulas(IdSucursal As Integer, IdProducto As String) As DataTable
      Return GetSql().GetFormulas(IdSucursal, IdProducto)
   End Function

   Public Function GetIdFormulaMaximo(idProducto As String) As Integer
      Return GetSql().GetCodigoMaximo(idProducto) + 1
   End Function

   Public Function GetPorNombreExacto(IdProducto As String, Nombre As String) As DataTable
      Return GetSql().GetPorNombreExacto(IdProducto, Nombre)
   End Function

   Public Function GetTodas(idSucursal As Integer, idProducto As String) As List(Of Entidades.ProductoFormula)
      Return CargaLista(GetFormulas(idSucursal, idProducto),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProductoFormula())
   End Function
   Public Function GetUna(idProducto As String, idFormula As Integer) As Entidades.ProductoFormula
      Return GetUna(idProducto, idFormula, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUna(idProducto As String, idFormula As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.ProductoFormula
      Return CargaEntidad(GetSql().ProductosFormulas_G1(idProducto, idFormula),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProductoFormula(),
                          accion, Function() String.Format("No existe una formula con IdProducto ´{0}´ y IdFormula {1}", idProducto, idFormula))
   End Function
#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.ProductosFormulas
      Return New SqlServer.ProductosFormulas(da)
   End Function
   Private Sub EjecutaSP(entidad As Entidades.ProductoFormula, tipo As TipoSP)
      Dim sql = New SqlServer.ProductosFormulas(da)
      Select Case tipo
         Case TipoSP._M
            sql.ProductosFormulas_M(entidad)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.ProductoFormula, dr As DataRow)
      With o
         .IdProducto = dr.Field(Of String)(Entidades.ProductoFormula.Columnas.IdProducto.ToString())
         .IdFormula = dr.Field(Of Integer)(Entidades.ProductoFormula.Columnas.IdFormula.ToString())
         .NombreFormula = dr.Field(Of String)(Entidades.ProductoFormula.Columnas.NombreFormula.ToString())
         .PorcentajeGanancia = dr.Field(Of Decimal)(Entidades.ProductoFormula.Columnas.PorcentajeGanancia.ToString())
      End With
   End Sub
#End Region

End Class