Public Class EmpleadosComisionesRubrosPrecios
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("EmpleadosComisionesRubrosPrecios", accesoDatos)
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos(idEmpleado As Integer) As List(Of Entidades.EmpleadoComisionRubroPrecio)
      Return EjecutaConConexion(Function() _GetTodos(idEmpleado))
   End Function

   Friend Function _GetTodos(idEmpleado As Integer) As List(Of Entidades.EmpleadoComisionRubroPrecio)
      Return CargaLista(GetAll(idEmpleado), Sub(o, dr) CargarUno(dr, o), Function() New Entidades.EmpleadoComisionRubroPrecio())
   End Function

   Public Overloads Function GetAll(IdEmpleado As Integer) As DataTable
      Return New SqlServer.EmpleadosComisionesRubrosPrecios(da).GetEmpleadosComisionesRubrosPrecios(IdEmpleado)
   End Function

   Public Function GetParaABM(idEmpleado As Integer) As DataTable
      Dim dtResult As DataTable = CreaDTParaABM()
      EjecutaConConexion(
      Sub()
         Dim dtRubro = New Rubros(da)._GetTodos()
         Dim dtListas = New ListasDePrecios(da).GetTodos()
         Dim dtComis = New EmpleadosComisionesRubrosPrecios(da)._GetTodos(idEmpleado)
         Dim dtComisGral = New SqlServer.EmpleadosComisionesRubros(da).GetEmpleadosComisionesRubros(idEmpleado)

         For Each drLista In dtListas
            Dim dc As DataColumn = New DataColumn("ComisionPorVenta__" + drLista.IdListaPrecios.ToString(), GetType(Decimal))
            ' dc.DefaultValue = 0
            dc.Caption = drLista.NombreListaPrecios
            dtResult.Columns.Add(dc)
         Next

         For Each drRubro In dtRubro
            Dim dr As DataRow = dtResult.NewRow()
            dr(Entidades.EmpleadoComisionRubroPrecio.Columnas.IdEmpleado.ToString()) = idEmpleado
            dr(Entidades.EmpleadoComisionRubroPrecio.Columnas.IdRubro.ToString()) = drRubro.IdRubro
            dr(Entidades.Rubro.Columnas.NombreRubro.ToString()) = drRubro.NombreRubro
            dtResult.Rows.Add(dr)
         Next

         For Each drComis In dtComis
            For Each dr As DataRow In dtResult.Select(String.Format("{0} = {1}", Entidades.EmpleadoComisionRubroPrecio.Columnas.IdRubro.ToString(),
                                                                                 drComis.IdRubro))
               dr("ComisionPorVenta__" + drComis.IdListaPrecios.ToString()) = drComis.Comision
            Next
         Next

         For Each drComisGral As DataRow In dtComisGral.Rows
            For Each dr As DataRow In dtResult.Select(String.Format("{0} = {1}", Entidades.EmpleadoComisionRubroPrecio.Columnas.IdRubro.ToString(),
                                                                                 drComisGral("IdRubro")))
               dr("ComisionPorVenta") = drComisGral("Comision")
            Next
         Next
      End Sub)

      dtResult.TableName = Entidades.EmpleadoComisionRubroPrecio.NombreTabla

      Return dtResult
   End Function

   Public Function GetUna(idEmpleado As Integer, idRubro As Integer, idListaPrecios As Integer) As Decimal
      Dim sql = New SqlServer.EmpleadosComisionesRubrosPrecios(da)
      Dim dt = sql.EmpleadosComisionesRubrosPrecios_G1(idEmpleado, idRubro, idListaPrecios)
      Dim o = New Entidades.EmpleadoComisionRubroPrecio()
      If dt.Any() Then
         Return dt.First().Field(Of Decimal?)("Comision").IfNull()
      Else
         Return 0
      End If
   End Function
   Public Shared Function CreaDTParaABM() As DataTable
      Dim dt As DataTable = New DataTable()

      dt.Columns.Add(Entidades.EmpleadoComisionRubroPrecio.Columnas.IdEmpleado.ToString(), GetType(Integer))
      dt.Columns.Add(Entidades.EmpleadoComisionRubroPrecio.Columnas.IdRubro.ToString(), GetType(Integer))
      dt.Columns.Add(Entidades.Rubro.Columnas.NombreRubro.ToString(), GetType(String))

      dt.Columns.Add("ComisionPorVenta", GetType(Decimal))

      Return dt
   End Function

   Public Sub Grabar(IdEmpleado As Integer, dtRubros As DataTable)
      EjecutaConTransaccion(Sub() _Grabar(IdEmpleado, dtRubros))
   End Sub

   Friend Sub _Grabar(IdEmpleado As Integer, dtRubros As DataTable)
      Dim sql = New SqlServer.EmpleadosComisionesRubrosPrecios(da)
      Dim sql2 = New SqlServer.EmpleadosComisionesRubros(da)
      Dim listECMP = New List(Of Entidades.EmpleadoComisionRubroPrecio)()
      ''Dim listECM As List(Of EmpleadoComisionRubro) = New List(Of EmpleadoComisionRubro)()

      sql.EmpleadosComisionesRubrosPrecios_D(IdEmpleado)
      sql2.EmpleadosComisionesRubros_D(IdEmpleado, 0)

      For Each drRubro As DataRow In dtRubros.Rows
         For Each dcRubro As DataColumn In dtRubros.Columns
            If dcRubro.ColumnName.StartsWith("ComisionPorVenta__") Then
               Dim IdListaPrecio As Integer = CInt(dcRubro.ColumnName.Replace("ComisionPorVenta__", ""))
               If IsNumeric(drRubro(dcRubro)) AndAlso CDec(drRubro(dcRubro)) > 0 Then
                  Dim comision = New Entidades.EmpleadoComisionRubroPrecio()
                  comision.Empleado.IdEmpleado = IdEmpleado
                  comision.Rubro.IdRubro = CInt(drRubro(Entidades.EmpleadoComisionRubroPrecio.Columnas.IdRubro.ToString()))
                  comision.ListaDePrecios.IdListaPrecios = IdListaPrecio
                  comision.Comision = CDec(drRubro(dcRubro))
                  listECMP.Add(comision)
               End If
            ElseIf dcRubro.ColumnName.Equals("ComisionPorVenta") Then
               If IsNumeric(drRubro(dcRubro)) AndAlso CDec(drRubro(dcRubro)) > 0 Then
                  sql2.EmpleadosComisionesRubros_I(IdEmpleado, CInt(drRubro(Entidades.EmpleadoComisionRubroPrecio.Columnas.IdRubro.ToString())), CDec(drRubro(dcRubro)))
               End If
            End If
         Next
      Next

      _Grabar(listECMP, sql)

   End Sub

   Public Sub Grabar(lista As List(Of Entidades.EmpleadoComisionRubroPrecio))
      EjecutaConTransaccion(Sub() _Grabar(lista))
   End Sub
   Friend Sub _Grabar(lista As List(Of Entidades.EmpleadoComisionRubroPrecio))
      Dim sql = New SqlServer.EmpleadosComisionesRubrosPrecios(da)
      _Grabar(lista, sql)
   End Sub

   Friend Sub _Grabar(lista As List(Of Entidades.EmpleadoComisionRubroPrecio), sql As SqlServer.EmpleadosComisionesRubrosPrecios)
      For Each comision In lista
         sql.EmpleadosComisionesRubrosPrecios_I(comision)
      Next
   End Sub

   'Public Function GetUno(idEmpleadoComisionRubroPrecio As Integer) As Entidades.EmpleadoComisionRubroPrecio
   '   Dim stb As StringBuilder = New StringBuilder("")
   '   With stb
   '      .Append("SELECT idEmpleadoComisionRubroPrecio")
   '      .Append("      ,nombreEmpleadoComisionRubroPrecio")
   '      .Append("    ,DebitoDirecto")
   '      .Append("    ,Empresa")
   '      .Append("    ,Convenio")
   '      .Append("    ,Servicio")
   '      .Append("  FROM EmpleadosComisionesRubrosPrecios")
   '      .AppendFormat("  WHERE idEmpleadoComisionRubroPrecio = {0}", idEmpleadoComisionRubroPrecio)
   '   End With
   '   Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())

   '   Dim o As Entidades.EmpleadoComisionRubroPrecio = New Entidades.EmpleadoComisionRubroPrecio()
   '   If dt.Rows.Count > 0 Then
   '      Me.CargarUno(dt.Rows(0), o)
   '   Else
   '      Throw New Exception("No existe el EmpleadoComisionRubroPrecio")
   '   End If
   '   Return o
   'End Function

   'Public Function Get1(IdEmpleadoComisionRubroPrecio As Integer) As DataTable
   '   Dim sql As SqlServer.EmpleadosComisionesRubrosPrecios = New SqlServer.EmpleadosComisionesRubrosPrecios(da)
   '   Return sql.EmpleadosComisionesRubrosPrecios_G1(IdEmpleadoComisionRubroPrecio)
   'End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.EmpleadoComisionRubroPrecio, tipo As TipoSP)

      'Dim en = DirectCast(entidad, Entidades.EmpleadoComisionRubroPrecio)

      Dim sqlEmpleadosComisionesRubrosPrecios = New SqlServer.EmpleadosComisionesRubrosPrecios(da)
      Select Case tipo
         Case TipoSP._I
            sqlEmpleadosComisionesRubrosPrecios.EmpleadosComisionesRubrosPrecios_I(en)
         Case TipoSP._U
               ''sqlEmpleadosComisionesRubrosPrecios.EmpleadosComisionesRubrosPrecios_U(EmpleadoComisionRubroPrecio.IdEmpleadoComisionRubroPrecio, EmpleadoComisionRubroPrecio.NombreEmpleadoComisionRubroPrecio, EmpleadoComisionRubroPrecio.DebitoDirecto, EmpleadoComisionRubroPrecio.Empresa, EmpleadoComisionRubroPrecio.Convenio, EmpleadoComisionRubroPrecio.Servicio)
         Case TipoSP._D
            sqlEmpleadosComisionesRubrosPrecios.EmpleadosComisionesRubrosPrecios_D(en)
      End Select
   End Sub

   Private Sub CargarUno(dr As DataRow, o As Entidades.EmpleadoComisionRubroPrecio)
      With o
         .Empleado.IdEmpleado = Integer.Parse(dr(Entidades.EmpleadoComisionRubroPrecio.Columnas.IdEmpleado.ToString()).ToString())
         .Empleado.NombreEmpleado = dr("NombreEmpleado").ToString()
         .Rubro.IdRubro = CInt(dr(Entidades.EmpleadoComisionRubroPrecio.Columnas.IdRubro.ToString()))
         .Rubro.NombreRubro = dr(Entidades.Rubro.Columnas.NombreRubro.ToString()).ToString()
         .ListaDePrecios.IdListaPrecios = CInt(dr(Entidades.EmpleadoComisionRubroPrecio.Columnas.IdListaPrecios.ToString()))
         .ListaDePrecios.NombreListaPrecios = dr(Entidades.ListaDePrecios.Columnas.NombreListaPrecios.ToString()).ToString()
         .Comision = CDec(dr(Entidades.EmpleadoComisionRubroPrecio.Columnas.Comision.ToString()))
      End With
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.EmpleadoComisionRubroPrecio), TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.EmpleadoComisionRubroPrecio), TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.EmpleadoComisionRubroPrecio), TipoSP._D)
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
      Return New SqlServer.EmpleadosComisionesRubrosPrecios(da).GetEmpleadosComisionesRubrosPrecios(0)
   End Function

#End Region
End Class
