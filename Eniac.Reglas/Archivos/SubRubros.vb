#Region "Option/Imports"
Option Explicit On
Option Strict On

Imports Eniac.Reglas.ServiciosRest.Sincronizacion

#End Region

Public Class SubRubros
   Inherits Eniac.Reglas.BaseSync(Of Entidades.JSonEntidades.Archivos.SubRubroJSonTransporte, Entidades.JSonEntidades.Archivos.SubRubroJSon)
   Implements IRestServices
   Implements ISyncRegla(Of Entidades.JSonEntidades.Archivos.SubRubroJSonTransporte, Entidades.JSonEntidades.Archivos.SubRubroJSon)

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "SubRubros"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      If entidad.Columna = "NombreRubro" Then
         entidad.Columna = "R." + entidad.Columna
      Else
         entidad.Columna = "S." + entidad.Columna
      End If

      With stbQuery
         .Length = 0
         .AppendLine("SELECT S.IdRubro")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,S.IdSubRubro")
         .AppendLine("      ,S.NombreSubRubro")
         .AppendLine("      ,S.DescuentoRecargoPorc1")
         .AppendLine("      ,S.UnidHasta1")
         .AppendLine("      ,S.UnidHasta2")
         .AppendLine("      ,S.UnidHasta3")
         .AppendLine("      ,S.UnidHasta4")
         .AppendLine("      ,S.UnidHasta5")
         .AppendLine("      ,S.UHPorc1")
         .AppendLine("      ,S.UHPorc2")
         .AppendLine("      ,S.UHPorc3")
         .AppendLine("      ,S.UHPorc4")
         .AppendLine("      ,S.UHPorc5")
         .AppendFormat("    ,S.{0}", Entidades.SubRubro.Columnas.FechaActualizacionWeb.ToString()).AppendLine()
         .AppendLine("      ,S.DescuentoRecargoPorc2")
         .AppendLine("  FROM SubRubros S ")
         .AppendLine("  INNER JOIN Rubros R ON R.IdRubro = S.IdRubro")
         .AppendLine("  WHERE " & entidad.Columna & " LIKE '%" & entidad.Valor.ToString() & "%'")
         .AppendLine(" ORDER BY R.NombreRubro, S.NombreSubRubro")
      End With
      Return Me.da.GetDataTable(stbQuery.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.SubRubros(da).SubRubros_GA(fechaActualizacionDesde:=Nothing, idRubro:=0, rubros:=Nothing)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)
      Dim SB As Entidades.SubRubro = DirectCast(entidad, Entidades.SubRubro)
      Dim rSubRubrosDescRecar As Reglas.SubRubrosComisionesPorDescuento = New Reglas.SubRubrosComisionesPorDescuento(da)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.SubRubros = New SqlServer.SubRubros(da)

         Select Case tipo
            Case TipoSP._I
               sqlC.SubRubros_I(SB.IdRubro, SB.IdSubRubro, SB.NombreSubRubro, SB.DescuentoRecargoPorc1,
                                SB.UnidHasta1, SB.UnidHasta2, SB.UnidHasta3, SB.UnidHasta4, SB.UnidHasta5,
                                SB.UHPorc1, SB.UHPorc2, SB.UHPorc3, SB.UHPorc4, SB.UHPorc5, SB.DescuentoRecargoPorc2, SB.CodigoExportacion,
                                SB.IdSubRubroTiendaNube, SB.IdSubRubroMercadoLibre, SB.IdSubRubroArborea, SB.GrupoAtributo01, SB.TipoAtributo01,
                                SB.GrupoAtributo02, SB.TipoAtributo02, SB.GrupoAtributo03, SB.TipoAtributo03, SB.GrupoAtributo04, SB.TipoAtributo04)

               rSubRubrosDescRecar.InsertaDesdeSubRubro(SB)

            Case TipoSP._U
               sqlC.SubRubros_U(SB.IdRubro, SB.IdSubRubro, SB.NombreSubRubro, SB.DescuentoRecargoPorc1,
                                SB.UnidHasta1, SB.UnidHasta2, SB.UnidHasta3, SB.UnidHasta4, SB.UnidHasta5,
                                SB.UHPorc1, SB.UHPorc2, SB.UHPorc3, SB.UHPorc4, SB.UHPorc5, SB.DescuentoRecargoPorc2, SB.CodigoExportacion,
                                SB.IdSubRubroTiendaNube, SB.IdSubRubroMercadoLibre, SB.IdSubRubroArborea, SB.GrupoAtributo01, SB.TipoAtributo01, SB.GrupoAtributo02,
                                SB.TipoAtributo02, SB.GrupoAtributo03, SB.TipoAtributo03, SB.GrupoAtributo04, SB.TipoAtributo04)

               rSubRubrosDescRecar.ActualizarDesdeSubRubro(SB)

            Case TipoSP._D

               rSubRubrosDescRecar.BorraDesdeSubRubro(SB)

               sqlC.SubRubros_D(SB.IdRubro, SB.IdSubRubro)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   'Private Function GetPorId(idRubro As Integer, idSubRubro As Integer) As DataTable
   '   Dim stbQuery As StringBuilder = New StringBuilder("")
   '   With stbQuery
   '      .Append("SELECT idRubro")
   '      .Append("      ,idSubRubro")
   '      .Append("      ,NombreSubRubro")
   '      .Append("      ,DescuentoRecargo")
   '      .Append(" FROM SubRubros ")
   '      .Append("  WHERE idRubro = " & idRubro.ToString())
   '      .Append("    AND idSubRubro = " & idSubRubro.ToString())
   '   End With
   '   Return Me.DataServer().GetDataSet(stbQuery.ToString()).Tables(0)
   'End Function

#End Region

#Region "Metodos publicos"


   Public Function GetTodos() As List(Of Entidades.SubRubro)
      Return GetTodos(idRubro:=0)
   End Function

   Public Function GetTodos(idRubro As Integer) As List(Of Entidades.SubRubro)
      Try
         Me.da.OpenConection()

         Return _GetTodos(idRubro, Nothing)
      Finally
         Me.da.CloseConection()
      End Try
   End Function
   Public Function GetTodos(rubros As Entidades.Rubro()) As List(Of Entidades.SubRubro)
      Try
         Me.da.OpenConection()

         Return _GetTodos(idRubro:=0, rubros:=rubros)
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function _GetTodos(idRubro As Integer, rubros As Entidades.Rubro()) As List(Of Entidades.SubRubro)
      Dim dt As DataTable = New SqlServer.SubRubros(da).SubRubros_GA(fechaActualizacionDesde:=Nothing, idRubro:=idRubro, rubros:=rubros)
      Dim o As Entidades.SubRubro
      Dim oLis As List(Of Entidades.SubRubro) = New List(Of Entidades.SubRubro)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.SubRubro()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Private Sub CargarUno(o As Entidades.SubRubro, dr As DataRow)
      With o
         .IdRubro = Integer.Parse(dr("IdRubro").ToString())
         .IdSubRubro = Integer.Parse(dr("IdSubRubro").ToString())
         .NombreSubRubro = dr("NombreSubRubro").ToString()
         .NombreRubro = dr("NombreRubro").ToString()
         .DescuentoRecargoPorc1 = Decimal.Parse(dr("DescuentoRecargoPorc1").ToString())

         .UnidHasta1 = Integer.Parse(dr("UnidHasta1").ToString())
         .UnidHasta2 = Integer.Parse(dr("UnidHasta2").ToString())
         .UnidHasta3 = Integer.Parse(dr("UnidHasta3").ToString())
         .UnidHasta4 = Integer.Parse(dr("UnidHasta4").ToString())
         .UnidHasta5 = Integer.Parse(dr("UnidHasta5").ToString())
         .UHPorc1 = Decimal.Parse(dr("UHPorc1").ToString())
         .UHPorc2 = Decimal.Parse(dr("UHPorc2").ToString())
         .UHPorc3 = Decimal.Parse(dr("UHPorc3").ToString())
         .UHPorc4 = Decimal.Parse(dr("UHPorc4").ToString())
         .UHPorc5 = Decimal.Parse(dr("UHPorc5").ToString())
         .IdSubRubroTiendaNube = dr.Field(Of String)(Entidades.SubRubro.Columnas.IdSubRubroTiendaNube.ToString())
         .IdSubRubroMercadoLibre = dr.Field(Of String)(Entidades.SubRubro.Columnas.IdSubRubroMercadoLibre.ToString())
         .IdSubRubroArborea = dr.Field(Of String)(Entidades.SubRubro.Columnas.IdSubRubroArborea.ToString())

         .DescuentoRecargoPorc2 = Decimal.Parse(dr("DescuentoRecargoPorc2").ToString())
         .CodigoExportacion = dr.Field(Of String)(Entidades.SubRubro.Columnas.CodigoExportacion.ToString())

         .SubRubroComisionPorDescuento = New SubRubrosComisionesPorDescuento(da).GetTodos(.IdSubRubro)
         '-- REQ-34666.- ------------------------------------------------------------------------------
         .GrupoAtributo01 = dr.Field(Of Integer?)(Entidades.SubRubro.Columnas.GrupoAtributo01.ToString())
         .TipoAtributo01 = dr.Field(Of Short?)(Entidades.SubRubro.Columnas.TipoAtributo01.ToString())
         .GrupoAtributo02 = dr.Field(Of Integer?)(Entidades.SubRubro.Columnas.GrupoAtributo02.ToString())
         .TipoAtributo02 = dr.Field(Of Short?)(Entidades.SubRubro.Columnas.TipoAtributo02.ToString())
         .GrupoAtributo03 = dr.Field(Of Integer?)(Entidades.SubRubro.Columnas.GrupoAtributo03.ToString())
         .TipoAtributo03 = dr.Field(Of Short?)(Entidades.SubRubro.Columnas.TipoAtributo03.ToString())
         .GrupoAtributo04 = dr.Field(Of Integer?)(Entidades.SubRubro.Columnas.GrupoAtributo04.ToString())
         .TipoAtributo04 = dr.Field(Of Short?)(Entidades.SubRubro.Columnas.TipoAtributo04.ToString())
      End With
   End Sub

   Public Function GetPorCodigo(idRubro As Integer, idSubRubro As Integer) As DataTable
      Return GetPorCodigo(If(idRubro = 0, {}, {New Entidades.Rubro() With {.IdRubro = idRubro}}), idSubRubro)
   End Function
   Public Function GetPorCodigo(rubros As Entidades.Rubro(), idSubRubro As Integer) As DataTable
      Return New SqlServer.SubRubros(da).SubRubros_GA(idSubRubro, "", rubros, False)

      'Dim stb As StringBuilder = New StringBuilder("")

      'With stb
      '   .AppendLine("SELECT S.IdRubro")
      '   .AppendLine("      ,R.NombreRubro")
      '   .AppendLine("      ,S.IdSubRubro")
      '   .AppendLine("      ,S.NombreSubRubro")
      '   .AppendLine("      ,S.DescuentoRecargo")
      '   .AppendLine("      ,S.UnidHasta1")
      '   .AppendLine("      ,S.UnidHasta2")
      '   .AppendLine("      ,S.UnidHasta3")
      '   .AppendLine("      ,S.UnidHasta4")
      '   .AppendLine("      ,S.UnidHasta5")
      '   .AppendLine("      ,S.UHPorc1")
      '   .AppendLine("      ,S.UHPorc2")
      '   .AppendLine("      ,S.UHPorc3")
      '   .AppendLine("      ,S.UHPorc4")
      '   .AppendLine("      ,S.UHPorc5")
      '   .AppendFormat("      ,S.{0}", Entidades.SubRubro.Columnas.FechaActualizacionWeb.ToString()).AppendLine()
      '   .AppendLine("  FROM SubRubros S ")
      '   .AppendLine("  INNER JOIN Rubros R ON R.IdRubro = S.IdRubro")
      '   .AppendLine("  WHERE 1 = 1")
      '   If idRubro > 0 Then
      '      .Append("    AND S.idRubro = " & idRubro.ToString())
      '   End If
      '   If idSubRubro > 0 Then
      '      .Append("    AND S.idSubRubro = " & idSubRubro.ToString())
      '   End If
      '   .AppendLine(" ORDER BY R.NombreRubro, S.NombreSubRubro")
      'End With

      'Return Me.DataServer.GetDataTable(stb.ToString())

   End Function

   Public Function GetPorCodigoSubrubro(idSubRubro As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT S.IdRubro")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,S.IdSubRubro")
         .AppendLine("      ,S.NombreSubRubro")
         .AppendLine("      ,S.DescuentoRecargoPorc1")
         .AppendLine("      ,S.UnidHasta1")
         .AppendLine("      ,S.UnidHasta2")
         .AppendLine("      ,S.UnidHasta3")
         .AppendLine("      ,S.UnidHasta4")
         .AppendLine("      ,S.UnidHasta5")
         .AppendLine("      ,S.UHPorc1")
         .AppendLine("      ,S.UHPorc2")
         .AppendLine("      ,S.UHPorc3")
         .AppendLine("      ,S.UHPorc4")
         .AppendLine("      ,S.UHPorc5")
         .AppendFormat("    ,S.{0}", Entidades.SubRubro.Columnas.FechaActualizacionWeb.ToString()).AppendLine()
         .AppendLine("      ,S.DescuentoRecargoPorc2")
         .AppendLine("      ,S.IdSubRubroTiendaNube")
         .AppendLine("      ,S.IdSubRubroMercadoLibre")
         .AppendLine("      ,S.IdSubRubroArborea")
         .AppendLine("      ,S.CodigoExportacion")

         .AppendLine("  FROM SubRubros S ")
         .AppendLine("  INNER JOIN Rubros R ON R.IdRubro = S.IdRubro")
         .AppendLine("  WHERE 1 = 1")
         If idSubRubro > 0 Then
            .Append("    AND S.idSubRubro = " & idSubRubro.ToString())
         End If
         .AppendLine(" ORDER BY R.NombreRubro, S.NombreSubRubro")
      End With

      Return da.GetDataTable(stb.ToString())

   End Function

   Public Function GetPorNombre(idRubro As Integer, nombreSubRubro As String) As DataTable
      Return GetPorNombre(If(idRubro > 0, {New Entidades.Rubro() With {.IdRubro = idRubro}}, {}), nombreSubRubro)
   End Function
   Public Function GetPorNombre(rubros As Entidades.Rubro(), nombreSubRubro As String) As DataTable

      Return New SqlServer.SubRubros(da).SubRubros_GA(0, nombreSubRubro, rubros, False)

      'Dim stb As StringBuilder = New StringBuilder("")

      'With stb
      '   .Length = 0
      '   .AppendLine("SELECT S.IdRubro")
      '   .AppendLine("      ,R.NombreRubro")
      '   .AppendLine("      ,S.IdSubRubro")
      '   .AppendLine("      ,S.NombreSubRubro")
      '   .AppendLine("      ,S.DescuentoRecargo")
      '   .AppendLine("      ,S.UnidHasta1")
      '   .AppendLine("      ,S.UnidHasta2")
      '   .AppendLine("      ,S.UnidHasta3")
      '   .AppendLine("      ,S.UnidHasta4")
      '   .AppendLine("      ,S.UnidHasta5")
      '   .AppendLine("      ,S.UHPorc1")
      '   .AppendLine("      ,S.UHPorc2")
      '   .AppendLine("      ,S.UHPorc3")
      '   .AppendLine("      ,S.UHPorc4")
      '   .AppendLine("      ,S.UHPorc5")
      '   .AppendFormat("      ,S.{0}", Entidades.SubRubro.Columnas.FechaActualizacionWeb.ToString()).AppendLine()
      '   .AppendLine("  FROM SubRubros S ")
      '   .AppendLine("  INNER JOIN Rubros R ON R.IdRubro = S.IdRubro")
      '   .AppendLine("	WHERE NombreSubRubro LIKE '%" & nombreSubRubro & "%' ")
      '   If idRubro > 0 Then
      '      .Append("    AND S.idRubro = " & idRubro.ToString())
      '   End If
      '   .AppendLine(" ORDER BY R.NombreRubro, S.NombreSubRubro")
      'End With

      'Return Me.DataServer.GetDataTable(stb.ToString())

   End Function
   Public Function GetPorNombreSubrubro(nombreSubRubro As String) As DataTable

      Return GetPorNombreSubrubro(Nothing, nombreSubRubro)
   End Function

   Public Function GetPorNombreSubrubro(rubro As Entidades.Rubro, nombreSubRubro As String) As DataTable

      Return New SqlServer.SubRubros(da).SubRubros_GA(0, nombreSubRubro, {rubro}, True)

   End Function

   Public Function GetUno(idSubRubro As Integer) As Entidades.SubRubro
      'Dim dt As DataTable = Me.GetPorCodigo(idRubro, idSubRubro)
      Dim sql As SqlServer.SubRubros = New SqlServer.SubRubros(da)
      Dim dt As DataTable = sql.SubRubros_G1(idSubRubro)
      Dim o As Entidades.SubRubro = New Entidades.SubRubro()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         With o
            CargarUno(o, dr)
         End With
      End If
      Return o
   End Function

   Public Function AtributoSubRubroProducto(idSubRubro As Integer) As Integer
      Dim sql = New SqlServer.SubRubros(da)
      Return sql.AtributoSubRubroProducto(idSubRubro).Rows.Count
   End Function

   Public Function TieneAtributoSubRubro(idSubRubro As Integer) As DataTable
      Dim sql = New SqlServer.SubRubros(da)
      Return sql.TieneAtributoSubRubro(idSubRubro)
   End Function

   Public Function GetCodigoMaximo(idRubro As Integer) As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT MAX(IdSubRubro) AS maximo FROM SubRubros")
         .Append("  WHERE idRubro = " & idRubro.ToString())
      End With

      'Para el Importador de Productos (Airoldi y Generico)
      'Dim dt As DataTable = Me.DataServer().GetDataTable(stb.ToString())
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())

      Dim val As Integer = idRubro * 1000 'Incorpora el Rubro y lo corre porque hay clientes con varios cientos de rubros y por las dudas que creen muchos

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return val

   End Function

   Public Function GetNombreUnido() As System.Data.DataTable
      Return New SqlServer.SubRubros(da).SubRubros_GetNombreUnido()
   End Function

   Public Sub Inserta(SB As Eniac.Entidades.SubRubro)
      Dim sqlC As SqlServer.SubRubros = New SqlServer.SubRubros(da)
      sqlC.SubRubros_I(SB.IdRubro, SB.IdSubRubro, SB.NombreSubRubro, SB.DescuentoRecargoPorc1,
                       SB.UnidHasta1, SB.UnidHasta2, SB.UnidHasta3, SB.UnidHasta4, SB.UnidHasta5,
                       SB.UHPorc1, SB.UHPorc2, SB.UHPorc3, SB.UHPorc4, SB.UHPorc5, SB.DescuentoRecargoPorc2, SB.CodigoExportacion,
                       SB.IdSubRubroTiendaNube, SB.IdSubRubroMercadoLibre, SB.IdSubRubroArborea, SB.GrupoAtributo01, SB.TipoAtributo01, SB.GrupoAtributo02,
                       SB.TipoAtributo02, SB.GrupoAtributo03, SB.TipoAtributo03, SB.GrupoAtributo04, SB.TipoAtributo04)
   End Sub

   Public Sub GuardarIdSubRubroTiendaNube(idSubRubro As Integer, idSubRubroTiendaNube As String)
      Dim sql As SqlServer.SubRubros = New SqlServer.SubRubros(da)
      Me.EjecutaSoloConTransaccion(Function()
                                      sql.GuardarIdSubRubroTiendaNube(idSubRubro, idSubRubroTiendaNube)
                                      Return True
                                   End Function)
   End Sub

   Public Function GetSubRubrosTiendaWeb(idTiendaWeb As Entidades.TiendasWeb) As DataTable
      Return New SqlServer.SubRubros(da).GetSubRubrosTiendaWeb(idTiendaWeb)
   End Function

   Public Sub GuardarIdSubRubroTiendaWeb(idTiendaWeb As String, idSubRubro As Integer, idSubRubroTiendaNube As String)
      Dim sql As SqlServer.SubRubros = New SqlServer.SubRubros(da)
      Me.EjecutaSoloConTransaccion(Function()
                                      sql.GuardarIdSubRubroTiendaWeb(idTiendaWeb, idSubRubro, idSubRubroTiendaNube)
                                      Return True
                                   End Function)
   End Sub
#End Region

End Class