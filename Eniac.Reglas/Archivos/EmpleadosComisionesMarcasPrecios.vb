Option Explicit On
Option Strict On

Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Reglas
Imports Eniac.Entidades

Public Class EmpleadosComisionesMarcasPrecios
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "EmpleadosComisionesMarcasPrecios"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos(IdEmpleado As Integer) As List(Of EmpleadoComisionMarcaPrecio)
      Try
         da.OpenConection()
         Return _GetTodos(IdEmpleado)
      Finally
         da.CloseConection()
      End Try
   End Function

   Friend Function _GetTodos(IdEmpleado As Integer) As List(Of EmpleadoComisionMarcaPrecio)
      Dim dt As DataTable = GetAll(IdEmpleado)
      Dim list As List(Of EmpleadoComisionMarcaPrecio) = New List(Of EmpleadoComisionMarcaPrecio)()

      For Each dr As DataRow In dt.Rows
         Dim o As EmpleadoComisionMarcaPrecio = New EmpleadoComisionMarcaPrecio()
         CargarUno(dr, o)
         list.Add(o)
      Next

      Return list
   End Function

   Public Function GetUna(IdEmpleado As Integer, IdMarca As Integer, IdListaPrecios As Integer) As Decimal
      Dim sql As SqlServer.EmpleadosComisionesMarcasPrecios = New SqlServer.EmpleadosComisionesMarcasPrecios(Me.da)
      Dim dt As DataTable = sql.GetUna(IdEmpleado, IdMarca, IdListaPrecios)
      Dim o As Entidades.EmpleadoComisionMarcaPrecio = New Entidades.EmpleadoComisionMarcaPrecio()
      If dt.Rows.Count > 0 Then
         Return Decimal.Parse(dt.Rows(0).Item("Comision").ToString())
      Else
         Return 0
      End If
   End Function

   Public Overloads Function GetAll(IdEmpleado As Integer) As System.Data.DataTable
      Return New SqlServer.EmpleadosComisionesMarcasPrecios(Me.da).GetEmpleadosComisionesMarcasPrecios(IdEmpleado)
   End Function

   Public Function GetParaABM(IdEmpleado As Integer) As System.Data.DataTable
      Dim dtResult As DataTable = CreaDTParaABM()
      Try
         da.OpenConection()

         Dim dtMarcas As List(Of Marca) = New Marcas(da)._GetTodas()
         Dim dtListas As List(Of ListaDePrecios) = New ListasDePrecios(da).GetTodos()
         Dim dtComis As List(Of EmpleadoComisionMarcaPrecio) = New EmpleadosComisionesMarcasPrecios(da)._GetTodos(IdEmpleado)
         Dim dtComisGral As DataTable = New SqlServer.EmpleadosComisionesMarcas(da).GetEmpleadosComisionesMarcas(IdEmpleado)

         For Each drLista As ListaDePrecios In dtListas
            Dim dc As DataColumn = New DataColumn("ComisionPorVenta__" + drLista.IdListaPrecios.ToString(), GetType(Decimal))

            dc.Caption = drLista.NombreListaPrecios
            dtResult.Columns.Add(dc)
         Next

         For Each drMarcas As Marca In dtMarcas
            Dim dr As DataRow = dtResult.NewRow()
            dr(EmpleadoComisionMarcaPrecio.Columnas.IdEmpleado.ToString()) = IdEmpleado
            dr(EmpleadoComisionMarcaPrecio.Columnas.IdMarca.ToString()) = drMarcas.IdMarca
            dr(Marca.Columnas.NombreMarca.ToString()) = drMarcas.NombreMarca
            dtResult.Rows.Add(dr)
         Next

         For Each drComis As EmpleadoComisionMarcaPrecio In dtComis
            For Each dr As DataRow In dtResult.Select(String.Format("{0} = {1}", EmpleadoComisionMarcaPrecio.Columnas.IdMarca.ToString(),
                                                                                 drComis.IdMarca))
               dr("ComisionPorVenta__" + drComis.IdListaPrecios.ToString()) = drComis.Comision
            Next
         Next

         For Each drComisGral As DataRow In dtComisGral.Rows
            For Each dr As DataRow In dtResult.Select(String.Format("{0} = {1}", EmpleadoComisionMarcaPrecio.Columnas.IdMarca.ToString(),
                                                                                 drComisGral("IdMarca")))
               dr("ComisionPorVenta") = drComisGral("Comision")
            Next
         Next

      Finally
         da.CloseConection()
      End Try

      dtResult.TableName = EmpleadoComisionMarcaPrecio.NombreTabla

      Return dtResult
   End Function

   Public Shared Function CreaDTParaABM() As DataTable
      Dim dt As DataTable = New DataTable()

      dt.Columns.Add(EmpleadoComisionMarcaPrecio.Columnas.IdEmpleado.ToString(), GetType(Integer))
      dt.Columns.Add(EmpleadoComisionMarcaPrecio.Columnas.IdMarca.ToString(), GetType(Integer))
      dt.Columns.Add(Marca.Columnas.NombreMarca.ToString(), GetType(String))

      dt.Columns.Add("ComisionPorVenta", GetType(Decimal))

      Return dt
   End Function

   Public Sub Grabar(IdEmpleado As Integer, dtMarcas As DataTable)
      Try
         da.OpenConection()
         da.BeginTransaction()

         _Grabar(IdEmpleado, dtMarcas)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Friend Sub _Grabar(IdEmpleado As Integer, dtMarcas As DataTable)
      Dim sql As SqlServer.EmpleadosComisionesMarcasPrecios = New SqlServer.EmpleadosComisionesMarcasPrecios(da)
      Dim sql2 As SqlServer.EmpleadosComisionesMarcas = New SqlServer.EmpleadosComisionesMarcas(da)
      Dim listECMP As List(Of EmpleadoComisionMarcaPrecio) = New List(Of EmpleadoComisionMarcaPrecio)()
      ''Dim listECM As List(Of EmpleadoComisionMarca) = New List(Of EmpleadoComisionMarca)()

      sql.EmpleadosComisionesMarcasPrecios_D(IdEmpleado)
      sql2.EmpleadosComisionesMarcas_D(IdEmpleado, 0)

      For Each drMarca As DataRow In dtMarcas.Rows
         For Each dcMarca As DataColumn In dtMarcas.Columns
            If dcMarca.ColumnName.StartsWith("ComisionPorVenta__") Then
               Dim IdListaPrecio As Integer = CInt(dcMarca.ColumnName.Replace("ComisionPorVenta__", ""))
               If IsNumeric(drMarca(dcMarca)) Then
                  Dim comision As EmpleadoComisionMarcaPrecio = New EmpleadoComisionMarcaPrecio()
                  comision.Empleado.IdEmpleado = IdEmpleado
                  comision.Marca.IdMarca = CInt(drMarca(EmpleadoComisionMarcaPrecio.Columnas.IdMarca.ToString()))
                  comision.ListaDePrecios.IdListaPrecios = IdListaPrecio
                  comision.Comision = CDec(drMarca(dcMarca))
                  listECMP.Add(comision)
               End If
            ElseIf dcMarca.ColumnName.Equals("ComisionPorVenta") Then
               If IsNumeric(drMarca(dcMarca)) AndAlso CDec(drMarca(dcMarca)) > 0 Then
                  sql2.EmpleadosComisionesMarcas_I(IdEmpleado, CInt(drMarca(EmpleadoComisionMarcaPrecio.Columnas.IdMarca.ToString())), CDec(drMarca(dcMarca)))
               End If
            End If
         Next
      Next

      _Grabar(listECMP, sql)

   End Sub

   Public Sub Grabar(lista As List(Of EmpleadoComisionMarcaPrecio))
      Try
         da.OpenConection()
         da.BeginTransaction()

         _Grabar(lista)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub
   Friend Sub _Grabar(lista As List(Of EmpleadoComisionMarcaPrecio))
      Dim sql As SqlServer.EmpleadosComisionesMarcasPrecios = New SqlServer.EmpleadosComisionesMarcasPrecios(da)
      _Grabar(lista, sql)
   End Sub

   Friend Sub _Grabar(lista As List(Of EmpleadoComisionMarcaPrecio), sql As SqlServer.EmpleadosComisionesMarcasPrecios)
      For Each comision As EmpleadoComisionMarcaPrecio In lista
         sql.EmpleadosComisionesMarcasPrecios_I(comision)
      Next
   End Sub

   'Public Function GetUno(ByVal idEmpleadoComisionMarcaPrecio As Integer) As Entidades.EmpleadoComisionMarcaPrecio
   '   Dim stb As StringBuilder = New StringBuilder("")
   '   With stb
   '      .Append("SELECT idEmpleadoComisionMarcaPrecio")
   '      .Append("      ,nombreEmpleadoComisionMarcaPrecio")
   '      .Append("    ,DebitoDirecto")
   '      .Append("    ,Empresa")
   '      .Append("    ,Convenio")
   '      .Append("    ,Servicio")
   '      .Append("  FROM EmpleadosComisionesMarcasPrecios")
   '      .AppendFormat("  WHERE idEmpleadoComisionMarcaPrecio = {0}", idEmpleadoComisionMarcaPrecio)
   '   End With
   '   Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())

   '   Dim o As Entidades.EmpleadoComisionMarcaPrecio = New Entidades.EmpleadoComisionMarcaPrecio()
   '   If dt.Rows.Count > 0 Then
   '      Me.CargarUno(dt.Rows(0), o)
   '   Else
   '      Throw New Exception("No existe el EmpleadoComisionMarcaPrecio")
   '   End If
   '   Return o
   'End Function

   'Public Function Get1(ByVal IdEmpleadoComisionMarcaPrecio As Integer) As DataTable
   '   Dim sql As SqlServer.EmpleadosComisionesMarcasPrecios = New SqlServer.EmpleadosComisionesMarcasPrecios(Me.da)
   '   Return sql.EmpleadosComisionesMarcasPrecios_G1(IdEmpleadoComisionMarcaPrecio)
   'End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim en As Entidades.EmpleadoComisionMarcaPrecio = DirectCast(entidad, Entidades.EmpleadoComisionMarcaPrecio)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sqlEmpleadosComisionesMarcasPrecios As SqlServer.EmpleadosComisionesMarcasPrecios = New SqlServer.EmpleadosComisionesMarcasPrecios(da)

         Select Case tipo
            Case TipoSP._I
               sqlEmpleadosComisionesMarcasPrecios.EmpleadosComisionesMarcasPrecios_I(en)
            Case TipoSP._U
               ''sqlEmpleadosComisionesMarcasPrecios.EmpleadosComisionesMarcasPrecios_U(EmpleadoComisionMarcaPrecio.IdEmpleadoComisionMarcaPrecio, EmpleadoComisionMarcaPrecio.NombreEmpleadoComisionMarcaPrecio, EmpleadoComisionMarcaPrecio.DebitoDirecto, EmpleadoComisionMarcaPrecio.Empresa, EmpleadoComisionMarcaPrecio.Convenio, EmpleadoComisionMarcaPrecio.Servicio)
            Case TipoSP._D
               sqlEmpleadosComisionesMarcasPrecios.EmpleadosComisionesMarcasPrecios_D(en)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal dr As DataRow, ByVal o As Entidades.EmpleadoComisionMarcaPrecio)
      With o
         .Empleado.IdEmpleado = Integer.Parse(dr(EmpleadoComisionMarcaPrecio.Columnas.IdEmpleado.ToString()).ToString())
         .Empleado.NombreEmpleado = dr("NombreEmpleado").ToString()
         '= New Empleados(da).GetUno(dr(EmpleadoComisionMarcaPrecio.Columnas.TipoDocEmpleado.ToString()).ToString(),
         '                                              dr(EmpleadoComisionMarcaPrecio.Columnas.NroDocEmpleado.ToString()).ToString())
         .Marca.IdMarca = CInt(dr(EmpleadoComisionMarcaPrecio.Columnas.IdMarca.ToString()))
         .Marca.NombreMarca = dr(Marca.Columnas.NombreMarca.ToString()).ToString()
         '= New Marcas(da).GetUna(CInt(dr(EmpleadoComisionMarcaPrecio.Columnas.IdMarca.ToString())))
         .ListaDePrecios.IdListaPrecios = CInt(dr(EmpleadoComisionMarcaPrecio.Columnas.IdListaPrecios.ToString()))
         .ListaDePrecios.NombreListaPrecios = dr(ListaDePrecios.Columnas.NombreListaPrecios.ToString()).ToString()
         '= New ListasDePrecios(da).GetUno(CInt(dr(EmpleadoComisionMarcaPrecio.Columnas.IdListaPrecios.ToString())))
         .Comision = CDec(dr(EmpleadoComisionMarcaPrecio.Columnas.Comision.ToString()))
      End With
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      'Dim stbQuery As StringBuilder = New StringBuilder("")
      'entidad.Columna = "B." + entidad.Columna
      'With stbQuery
      '   .Length = 0
      '   .AppendLine("SELECT B.IdEmpleadoComisionMarcaPrecio")
      '   .AppendLine("      ,B.NombreEmpleadoComisionMarcaPrecio")
      '   .AppendLine("      ,B.DebitoDirecto")
      '   .AppendLine("      ,B.Empresa")
      '   .AppendLine("      ,B.Convenio")
      '   .AppendLine("      ,B.Servicio")
      '   .AppendLine(" FROM EmpleadosComisionesMarcasPrecios B ")
      '   .AppendLine("  WHERE " & entidad.Columna & " LIKE '%" & entidad.Valor.ToString() & "%'")
      'End With
      'Return Me.da.GetDataTable(stbQuery.ToString())
      Return New DataTable()
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.EmpleadosComisionesMarcasPrecios(Me.da).GetEmpleadosComisionesMarcasPrecios(0)
   End Function

#End Region


End Class
