#Region "Imports/Option"
Option Explicit On
Option Strict On

Imports Eniac.Reglas.ServiciosRest.Sincronizacion
#End Region
Public Class SubSubRubros
   Inherits Eniac.Reglas.BaseSync(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSonTransporte, Entidades.JSonEntidades.Archivos.SubSubRubroJSon)
   Implements IRestServices
   Implements ISyncRegla(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSonTransporte, Entidades.JSonEntidades.Archivos.SubSubRubroJSon)

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "SubSubRubros"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "SubSubRubros"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.SubSubRubro)))
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.SubSubRubro)))
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.SubSubRubro)))
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      If entidad.Columna = "NombreSubRubro" Then
         entidad.Columna = "R." + entidad.Columna
      ElseIf entidad.Columna = "NombreRubro" Then
         entidad.Columna = "R1." + entidad.Columna
      ElseIf entidad.Columna = "IdRubro" Then
         entidad.Columna = "R1." + entidad.Columna
      Else
         entidad.Columna = "S." + entidad.Columna
      End If

      With stbQuery
         .Length = 0
         .AppendLine("SELECT S.IdSubRubro")
         .AppendLine("      ,R.NombreSubRubro")
         .AppendLine("      ,S.IdSubSubRubro")
         .AppendLine("      ,S.NombreSubSubRubro")
         .AppendLine("      ,R1.IdRubro")
         .AppendLine("      ,R1.NombreRubro")
         .AppendFormat("      ,S.{0}", Entidades.SubSubRubro.Columnas.FechaActualizacionWeb.ToString()).AppendLine()
         .AppendLine("  FROM SubSubRubros S ")
         .AppendLine("  INNER JOIN SubRubros R ON R.IdSubRubro = S.IdSubRubro")
         .AppendLine("    INNER JOIN Rubros R1 ON R1.idRubro = R.IdRubro")
         .AppendLine("  WHERE " & entidad.Columna & " LIKE '%" & entidad.Valor.ToString() & "%'")
         .AppendLine("  ORDER BY R.NombreSubRubro, S.NombreSubSubRubro")
      End With
      Return Me.da.GetDataTable(stbQuery.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.SubSubRubros(da).SubSubRubros_GA(fechaActualizacionDesde:=Nothing)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ssrubro As Eniac.Entidades.SubSubRubro, ByVal tipo As TipoSP)
      'Dim SB As Entidades.SubSubRubro = DirectCast(entidad, Entidades.SubSubRubro)
      'Try
      '   'da.OpenConection()
      'da.BeginTransaction()

      Dim sqlC As SqlServer.SubSubRubros = New SqlServer.SubSubRubros(da)

      Select Case tipo
         Case TipoSP._I
            sqlC.SubSubRubros_I(ssrubro.IdSubRubro, ssrubro.IdSubSubRubro, ssrubro.NombreSubSubRubro, ssrubro.IdSubSubRubroTiendaNube, ssrubro.IdSubSubRubroMercadoLibre, ssrubro.IdSubSubRubroArborea)
         Case TipoSP._U
            sqlC.SubSubRubros_U(ssrubro.IdSubRubro, ssrubro.IdSubSubRubro, ssrubro.NombreSubSubRubro, ssrubro.IdSubSubRubroTiendaNube, ssrubro.IdSubSubRubroMercadoLibre, ssrubro.IdSubSubRubroArborea)
         Case TipoSP._D
            sqlC.SubSubRubros_D(ssrubro.IdSubRubro, ssrubro.IdSubSubRubro)
      End Select

      'da.CommitTransaction()

      'Catch ex As Exception
      '   da.RollbakTransaction()
      '   Throw ex
      'Finally
      '   da.CloseConection()
      'End Try
   End Sub

   'Private Function GetPorId(ByVal idRubro As Integer, ByVal idSubRubro As Integer) As DataTable
   '   Dim stbQuery As StringBuilder = New StringBuilder("")
   '   With stbQuery
   '      .Append("SELECT idRubro")
   '      .Append("      ,idSubRubro")
   '      .Append("      ,NombreSubRubro")
   '      .Append("      ,DescuentoRecargo")
   '      .Append(" FROM SubSubRubros ")
   '      .Append("  WHERE idRubro = " & idRubro.ToString())
   '      .Append("    AND idSubRubro = " & idSubRubro.ToString())
   '   End With
   '   Return Me.DataServer().GetDataSet(stbQuery.ToString()).Tables(0)
   'End Function

#End Region

#Region "Metodos publicos"

   Public Sub _Insertar(entidad As Entidades.SubSubRubro)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.SubSubRubro)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.SubSubRubro)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Function GetTodos() As List(Of Entidades.SubSubRubro)
      Try
         Me.da.OpenConection()

         Return _GetTodos()
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function _GetTodos() As List(Of Entidades.SubSubRubro)
      Return CargaTodos(Me.GetAll())
   End Function
   Public Function _GetTodos(subrubros As Entidades.SubRubro()) As List(Of Entidades.SubSubRubro)
      Dim dt As DataTable = New SqlServer.SubSubRubros(da).SubSubRubros_G(idSubRubro:=0, idSubSubRubro:=0, nombreSubSubRubro:=String.Empty, subRubros:=subrubros)
      Dim o As Entidades.SubSubRubro
      Dim oLis As List(Of Entidades.SubSubRubro) = New List(Of Entidades.SubSubRubro)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.SubSubRubro()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetTodos(idSubRubro As Integer) As List(Of Entidades.SubSubRubro)
      Return CargaTodos(New SqlServer.SubSubRubros(da).SubSubRubros_GA(idSubRubro))
   End Function

   Public Function GetTodos(subRubros As Entidades.SubRubro()) As List(Of Entidades.SubSubRubro)
      Try
         Me.da.OpenConection()

         Return _GetTodos(subrubros:=subRubros)
      Finally
         Me.da.CloseConection()
      End Try
   End Function
   Public Function CargaTodos(dt As DataTable) As List(Of Entidades.SubSubRubro)
      Dim o As Entidades.SubSubRubro
      Dim oLis As List(Of Entidades.SubSubRubro) = New List(Of Entidades.SubSubRubro)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.SubSubRubro()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Private Sub CargarUno(ByVal o As Entidades.SubSubRubro, ByVal dr As DataRow)
      With o
         .IdRubro = Integer.Parse(dr("IdRubro").ToString())
         .IdSubRubro = Integer.Parse(dr("IdSubRubro").ToString())
         .IdSubSubRubro = Integer.Parse(dr("IdSubSubRubro").ToString())
         .NombreSubSubRubro = dr("NombreSubSubRubro").ToString()
         .NombreSubRubro = dr("NombreSubRubro").ToString()
         .NombreRubro = dr("NombreRubro").ToString()
         .IdSubSubRubroTiendaNube = dr.Field(Of String)("IdSubSubRubroTiendaNube")
         .IdSubSubRubroMercadoLibre = dr.Field(Of String)("IdSubSubRubroMercadoLibre")
         .IdSubSubRubroArborea = dr.Field(Of String)("IdSubSubRubroArborea")
      End With
   End Sub
   Public Function GetPorCodigo(idSubRubro As Integer, idSubSubRubro As Integer, nombreSubSubRubro As String, subRubros As Entidades.SubRubro()) As DataTable
      Return New SqlServer.SubSubRubros(da).SubSubRubros_G(idSubRubro:=idSubRubro, idSubSubRubro:=idSubSubRubro, nombreSubSubRubro:=nombreSubSubRubro, subRubros:=subRubros)
   End Function
   Public Function GetPorCodigo(idRubro As Integer, idSubRubro As Integer, idSubSubRubro As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT R.IdRubro")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,SR.IdSubRubro")
         .AppendLine("      ,SR.NombreSubRubro")
         .AppendLine("      ,S.IdSubSubRubro")
         .AppendLine("      ,S.NombreSubSubRubro")
         .AppendFormat("      ,S.{0}", Entidades.SubSubRubro.Columnas.FechaActualizacionWeb.ToString()).AppendLine()
         .AppendLine("      ,S.IdSubSubRubroTiendaNube")
         .AppendLine("      ,S.IdSubSubRubroMercadoLibre")
         .AppendLine("      ,S.IdSubSubRubroArborea")
         .AppendLine("  FROM SubSubRubros S ")
         .AppendLine(" INNER JOIN SubRubros SR ON SR.IdSubRubro = S.IdSubRubro")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = SR.IdRubro")
         .AppendLine(" WHERE 1 = 1")
         If idRubro > 0 Then
            .Append("   AND R.IdRubro = " & idRubro.ToString())
         End If
         If idSubRubro > 0 Then
            .Append("   AND SR.IdSubRubro = " & idSubRubro.ToString())
         End If
         If idSubSubRubro > 0 Then
            .Append("   AND S.IdSubSubRubro = " & idSubSubRubro.ToString())
         End If
         .AppendLine(" ORDER BY R.NombreRubro, SR.NombreSubRubro, S.NombreSubSubRubro")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function
   Public Function GetPorNombre(idSubRubro As Integer, idSubSubRubro As Integer, nombreSubSubRubro As String, subRubros As Entidades.SubRubro()) As DataTable
      Return New SqlServer.SubSubRubros(da).SubSubRubros_G(idSubRubro:=idSubRubro, idSubSubRubro:=idSubSubRubro, nombreSubSubRubro:=nombreSubSubRubro, subRubros:=subRubros)
   End Function
   Public Function GetPorNombre(idRubro As Integer, idSubRubro As Integer, nombreSubSubRubro As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT R.IdRubro")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,SR.IdSubRubro")
         .AppendLine("      ,SR.NombreSubRubro")
         .AppendLine("      ,S.IdSubSubRubro")
         .AppendLine("      ,S.NombreSubSubRubro")
         .AppendLine("      ,S.IdSubSubRubroTiendaNube")
         .AppendLine("      ,S.IdSubSubRubroMercadoLibre")
         .AppendLine("      ,S.IdSubSubRubroArborea")
         .AppendLine("  FROM SubSubRubros S ")
         .AppendLine(" INNER JOIN SubRubros SR ON SR.IdSubRubro = S.IdSubRubro")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = SR.IdRubro")
         .AppendLine("	WHERE S.NombreSubSubRubro LIKE '%" & nombreSubSubRubro & "%' ")
         If idRubro > 0 Then
            .Append("    AND R.IdRubro = " & idRubro.ToString())
         End If
         If idSubRubro > 0 Then
            .Append("    AND SR.IdSubRubro = " & idSubRubro.ToString())
         End If
         .AppendLine(" ORDER BY R.NombreRubro, SR.NombreSubRubro, S.NombreSubSubRubro")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetUno(ByVal idSubSubRubro As Integer) As Entidades.SubSubRubro
      'Dim dt As DataTable = Me.GetPorCodigo(idRubro, idSubRubro)
      Dim sql As SqlServer.SubSubRubros = New SqlServer.SubSubRubros(da)
      Dim dt As DataTable = sql.SubSubRubros_G1(idSubSubRubro)
      Dim o As Entidades.SubSubRubro = New Entidades.SubSubRubro()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         CargarUno(o, dr)
         'With o
         '   .IdSubRubro = Integer.Parse(dr("IdSubRubro").ToString())
         '   .IdSubSubRubro = Integer.Parse(dr("IdSubSubRubro").ToString())
         '   .NombreSubSubRubro = dr("NombreSubSubRubro").ToString()
         'End With
      End If
      Return o
   End Function

   Public Function GetCodigoMaximo(idSubSubRubro As Integer) As Long
      Return New SqlServer.SubSubRubros(da).GetCodigoMaximo(idSubSubRubro)
   End Function

   Public Function GetNombreUnido() As System.Data.DataTable
      Return New SqlServer.SubSubRubros(da).SubSubRubros_GetNombreUnido()
   End Function

   Public Sub GuardarIdSubSubRubroTiendaNube(idSubSubRubro As Integer, idSubSubRubroTiendaNube As String)
      Dim sql As SqlServer.SubSubRubros = New SqlServer.SubSubRubros(da)
      Me.EjecutaSoloConTransaccion(Function()
                                      sql.GuardarIdSubSubRubroTiendaNube(idSubSubRubro, idSubSubRubroTiendaNube)
                                      Return True
                                   End Function)
   End Sub

   Public Function GetSubSubRubrosTiendaWeb(idTiendaWeb As Entidades.TiendasWeb) As DataTable
      Return New SqlServer.SubSubRubros(da).GetSubSubRubrosTiendaWeb(idTiendaWeb)
   End Function

   Public Sub GuardarIdSubSubRubroTiendaweb(idTiendaWeb As String, idSubSubRubro As Integer, idSubSubRubroTiendaWeb As String)
      Dim sql As SqlServer.SubSubRubros = New SqlServer.SubSubRubros(da)
      Me.EjecutaSoloConTransaccion(Function()
                                      sql.GuardarIdSubSubRubroTiendaWeb(idTiendaWeb, idSubSubRubro, idSubSubRubroTiendaWeb)
                                      Return True
                                   End Function)
   End Sub

#End Region


End Class