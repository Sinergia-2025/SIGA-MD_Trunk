Public Class EmpleadosComisionesProductosPrecios
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("EmpleadosComisionesProductosPrecios", accesoDatos)
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos(idEmpleado As Integer) As List(Of Entidades.EmpleadoComisionProductoPrecio)
      Return EjecutaConConexion(Function() _GetTodos(idEmpleado))
   End Function

   Friend Function _GetTodos(idEmpleado As Integer) As List(Of Entidades.EmpleadoComisionProductoPrecio)
      Return CargaLista(GetAll(idEmpleado), Sub(o, dr) CargarUno(dr, o), Function() New Entidades.EmpleadoComisionProductoPrecio())
   End Function

   Public Overloads Function GetAll(IdEmpleado As Integer) As DataTable
      Return New SqlServer.EmpleadosComisionesProductosPrecios(da).GetEmpleadosComisionesProductosPrecios(IdEmpleado)
   End Function

   Public Function GetParaABM(idEmpleado As Integer) As DataTable
      Dim dtResult As DataTable = CreaDTParaABM()
      EjecutaConConexion(
      Sub()

         Dim dtComis = New EmpleadosComisionesProductosPrecios(da)._GetTodos(idEmpleado)
         For Each drProducto In dtComis
            Dim dr As DataRow = dtResult.NewRow()
            dr(Entidades.EmpleadoComisionProductoPrecio.Columnas.IdEmpleado.ToString()) = idEmpleado
            dr(Entidades.EmpleadoComisionProductoPrecio.Columnas.IdProducto.ToString()) = drProducto.IdProducto
            dr(Entidades.Producto.Columnas.NombreProducto.ToString()) = drProducto.NombreProducto
            dr(Entidades.EmpleadoComisionProductoPrecio.Columnas.IdListaPrecios.ToString()) = drProducto.IdListaPrecios
            dr(Entidades.ListaDePrecios.Columnas.NombreListaPrecios.ToString()) = drProducto.NombreListaPrecios
            dr(Entidades.EmpleadoComisionProductoPrecio.Columnas.Comision.ToString()) = drProducto.Comision
            dtResult.Rows.Add(dr)
         Next

      End Sub)

      dtResult.TableName = Entidades.EmpleadoComisionProductoPrecio.NombreTabla

      Return dtResult
   End Function

   Public Function GetUna(idEmpleado As Integer, idProducto As String, idListaPrecios As Integer) As Decimal
      Dim sql = New SqlServer.EmpleadosComisionesProductosPrecios(da)
      Dim dt = sql.EmpleadosComisionesProductosPrecios_G1(idEmpleado, idProducto, idListaPrecios)
      Dim o = New Entidades.EmpleadoComisionProductoPrecio()
      If dt.Any() Then
         Return dt.First().Field(Of Decimal?)("Comision").IfNull()
      Else
         Return 0
      End If
   End Function
   Public Shared Function CreaDTParaABM() As DataTable
      Dim dt As DataTable = New DataTable()

      dt.Columns.Add(Entidades.EmpleadoComisionProductoPrecio.Columnas.IdEmpleado.ToString(), GetType(Integer))
      dt.Columns.Add(Entidades.EmpleadoComisionProductoPrecio.Columnas.IdProducto.ToString(), GetType(String))
      dt.Columns.Add(Entidades.Producto.Columnas.NombreProducto.ToString(), GetType(String))
      dt.Columns.Add(Entidades.EmpleadoComisionProductoPrecio.Columnas.IdListaPrecios.ToString(), GetType(Integer))
      dt.Columns.Add(Entidades.ListaDePrecios.Columnas.NombreListaPrecios.ToString(), GetType(String))
      dt.Columns.Add("Comision", GetType(Decimal))

      Return dt
   End Function

   Public Sub Grabar(IdEmpleado As Integer, dtRubros As DataTable)
      EjecutaConTransaccion(Sub() _Grabar(IdEmpleado, dtRubros))
   End Sub

   Friend Sub _Grabar(IdEmpleado As Integer, dtProductos As DataTable)
      Dim sql = New SqlServer.EmpleadosComisionesProductosPrecios(da)
      '  Dim sql2 = New SqlServer.EmpleadosComisionesRubros(da)
      Dim listECMP = New List(Of Entidades.EmpleadoComisionProductoPrecio)()
      ''Dim listECM As List(Of EmpleadoComisionRubro) = New List(Of EmpleadoComisionRubro)()

      sql.EmpleadosComisionesProductosPrecios_D(IdEmpleado)

      For Each drProducto As DataRow In dtProductos.Rows
         ' For Each dcRubro As DataColumn In dtProductos.Columns
         '  If dcRubro.ColumnName.StartsWith("ComisionPorVenta__") Then
         'Dim IdListaPrecio As Integer = CInt(dcRubro.ColumnName.Replace("ComisionPorVenta__", ""))
         '      If IsNumeric(drProducto(dcRubro)) AndAlso CDec(drProducto(dcRubro)) > 0 Then
         Dim comision = New Entidades.EmpleadoComisionProductoPrecio()
         comision.IdEmpleado = IdEmpleado
         comision.IdProducto = drProducto(Entidades.EmpleadoComisionProductoPrecio.Columnas.IdProducto.ToString()).ToString()
         comision.IdListaPrecios = Integer.Parse(drProducto(Entidades.EmpleadoComisionProductoPrecio.Columnas.IdListaPrecios.ToString()).ToString())
         comision.Comision = CDec(drProducto(Entidades.EmpleadoComisionProductoPrecio.Columnas.Comision.ToString()).ToString())
         listECMP.Add(comision)
         '        End If
         'ElseIf dcRubro.ColumnName.Equals("ComisionPorVenta") Then
         '   If IsNumeric(drRubro(dcRubro)) AndAlso CDec(drRubro(dcRubro)) > 0 Then
         '      sql2.EmpleadosComisionesRubros_I(IdEmpleado, CInt(drRubro(Entidades.EmpleadoComisionRubroPrecio.Columnas.IdRubro.ToString())), CDec(drRubro(dcRubro)))
         '   End If
         'End If
         '  Next
      Next

      _Grabar(listECMP, sql)

   End Sub

   Public Sub Grabar(lista As List(Of Entidades.EmpleadoComisionProductoPrecio))
      EjecutaConTransaccion(Sub() _Grabar(lista))
   End Sub
   Friend Sub _Grabar(lista As List(Of Entidades.EmpleadoComisionProductoPrecio))
      Dim sql = New SqlServer.EmpleadosComisionesProductosPrecios(da)
      _Grabar(lista, sql)
   End Sub

   Friend Sub _Grabar(lista As List(Of Entidades.EmpleadoComisionProductoPrecio), sql As SqlServer.EmpleadosComisionesProductosPrecios)
      For Each comision In lista
         sql.EmpleadosComisionesProductosPrecios_I(comision)
      Next
   End Sub


#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.EmpleadoComisionProductoPrecio, tipo As TipoSP)

      'Dim en = DirectCast(entidad, Entidades.EmpleadoComisionRubroPrecio)

      Dim sqlEmpleadosComisionesProductosPrecios = New SqlServer.EmpleadosComisionesProductosPrecios(da)
      Select Case tipo
         Case TipoSP._I
            sqlEmpleadosComisionesProductosPrecios.EmpleadosComisionesProductosPrecios_I(en)
         Case TipoSP._U
               ''sqlEmpleadosComisionesRubrosPrecios.EmpleadosComisionesRubrosPrecios_U(EmpleadoComisionRubroPrecio.IdEmpleadoComisionRubroPrecio, EmpleadoComisionRubroPrecio.NombreEmpleadoComisionRubroPrecio, EmpleadoComisionRubroPrecio.DebitoDirecto, EmpleadoComisionRubroPrecio.Empresa, EmpleadoComisionRubroPrecio.Convenio, EmpleadoComisionRubroPrecio.Servicio)
         Case TipoSP._D
            sqlEmpleadosComisionesProductosPrecios.EmpleadosComisionesProductosPrecios_D(en)
      End Select
   End Sub

   Private Sub CargarUno(dr As DataRow, o As Entidades.EmpleadoComisionProductoPrecio)
      With o
         .IdEmpleado = Integer.Parse(dr(Entidades.EmpleadoComisionProductoPrecio.Columnas.IdEmpleado.ToString()).ToString())
         .IdProducto = dr(Entidades.EmpleadoComisionProductoPrecio.Columnas.IdProducto.ToString()).ToString()
         .NombreProducto = dr(Entidades.Producto.Columnas.NombreProducto.ToString()).ToString()
         .IdListaPrecios = CInt(dr(Entidades.EmpleadoComisionRubroPrecio.Columnas.IdListaPrecios.ToString()))
         .NombreListaPrecios = dr(Entidades.ListaDePrecios.Columnas.NombreListaPrecios.ToString()).ToString()
         .Comision = CDec(dr(Entidades.EmpleadoComisionRubroPrecio.Columnas.Comision.ToString()))
      End With
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.EmpleadoComisionProductoPrecio), TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.EmpleadoComisionProductoPrecio), TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.EmpleadoComisionProductoPrecio), TipoSP._D)
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      'Dim stbQuery As StringBuilder = New StringBuilder("")
      'entidad.Columna = "B." + entidad.Columna
      'With stbQuery
      '   .Length = 0
      '   .AppendLine("SELECT B.IdEmpleadoComisionRubroPrecio")
      '   .AppendLine("      ,B.NombreEmpleadoComisionRubroPrecio")
      '   .AppendLine("      ,B.DebitoDirecto")
      '   .AppendLine("      ,B.Empresa")
      '   .AppendLine("      ,B.Convenio")
      '   .AppendLine("      ,B.Servicio")
      '   .AppendLine(" FROM EmpleadosComisionesRubrosPrecios B ")
      '   .AppendLine("  WHERE " & entidad.Columna & " LIKE '%" & entidad.Valor.ToString() & "%'")
      'End With
      'Return Me.da.GetDataTable(stbQuery.ToString())
      Return New DataTable()
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.EmpleadosComisionesProductosPrecios(da).GetEmpleadosComisionesProductosPrecios(0)
   End Function

#End Region
End Class
