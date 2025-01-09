Public Class Rubros
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Rubros_I(idRubro As Integer,
                       nombreRubro As String,
                       idProvincia As String,
                       idActividad As Integer,
                       comisionPorVenta As Decimal,
                       unidHasta1 As Decimal,
                       unidHasta2 As Decimal,
                       unidHasta3 As Decimal,
                       unidHasta4 As Decimal,
                       unidHasta5 As Decimal,
                       uHPorc1 As Decimal,
                       uHPorc2 As Decimal,
                       uHPorc3 As Decimal,
                       uHPorc4 As Decimal,
                       uHPorc5 As Decimal,
                       orden As Integer,
                       descuentoRecargoPorc1 As Decimal,
                       descuentoRecargoPorc2 As Decimal,
                       codigoExportacion As String,
                       idRubroTiendaNube As String,
                       idRubroMercadoLibre As String,
                       IdRubroArborea As String)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO Rubros ")
         .AppendFormatLine("(IdRubro,")
         .AppendFormatLine(" NombreRubro,")
         .AppendFormatLine(" IdProvincia,")
         .AppendFormatLine(" IdActividad,")
         .AppendFormatLine(" ComisionPorVenta,")
         .AppendFormatLine(" UnidHasta1,")
         .AppendFormatLine(" UnidHasta2,")
         .AppendFormatLine(" UnidHasta3,")
         .AppendFormatLine(" UnidHasta4,")
         .AppendFormatLine(" UnidHasta5,")
         .AppendFormatLine(" UHPorc1,")
         .AppendFormatLine(" UHPorc2,")
         .AppendFormatLine(" UHPorc3,")
         .AppendFormatLine(" UHPorc4,")
         .AppendFormatLine(" UHPorc5,")
         .AppendFormatLine(" Orden,")
         .AppendFormatLine(" DescuentoRecargoPorc1,")
         .AppendFormatLine(" DescuentoRecargoPorc2,")
         .AppendFormatLine(" CodigoExportacion")
         .AppendFormatLine(" ,IdRubroTiendaNube")
         .AppendFormatLine(" ,IdRubroMercadoLibre")
         .AppendFormatLine(" ,IdRubroArborea")

         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("   {0}", idRubro)
         .AppendFormatLine(" ,'{0}'", nombreRubro)
         If idActividad = 0 Then
            .AppendFormatLine(" ,NULL")
            .AppendFormatLine(" ,NULL")
         Else
            .AppendFormatLine(" ,'{0}'", idProvincia)
            .AppendFormatLine(" ,'{0}'", idActividad)
         End If
         .AppendFormatLine(" , {0} ", comisionPorVenta)

         .AppendFormatLine(" , {0} ", unidHasta1)
         .AppendFormatLine(" , {0} ", unidHasta2)
         .AppendFormatLine(" , {0} ", unidHasta3)
         .AppendFormatLine(" , {0} ", unidHasta4)
         .AppendFormatLine(" , {0} ", unidHasta5)
         .AppendFormatLine(" , {0} ", uHPorc1)
         .AppendFormatLine(" , {0} ", uHPorc2)
         .AppendFormatLine(" , {0} ", uHPorc3)
         .AppendFormatLine(" , {0} ", uHPorc4)
         .AppendFormatLine(" , {0} ", uHPorc5)
         .AppendFormatLine(" , {0} ", orden)
         .AppendFormatLine(" , {0} ", descuentoRecargoPorc1)
         .AppendFormatLine(" , {0} ", descuentoRecargoPorc2)
         .AppendFormatLine(" , '{0}' ", codigoExportacion)

         If Not String.IsNullOrEmpty(idRubroTiendaNube) Then
            .AppendFormatLine(" , '{0}' ", idRubroTiendaNube)
         Else
            .AppendFormatLine(" , NULL")
         End If
         '-- REQ-30521.- --
         If Not String.IsNullOrEmpty(idRubroMercadoLibre) Then
            .AppendFormatLine(" , '{0}' ", idRubroMercadoLibre)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If Not String.IsNullOrEmpty(IdRubroArborea) Then
            .AppendFormatLine(" , '{0}' ", IdRubroArborea)
         Else
            .AppendFormatLine(" , NULL")
         End If

         .AppendFormatLine(")")
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Rubros_U(idRubro As Integer,
                       nombreRubro As String,
                       idProvincia As String,
                       idActividad As Integer,
                       comisionPorVenta As Decimal,
                       unidHasta1 As Decimal,
                       unidHasta2 As Decimal,
                       unidHasta3 As Decimal,
                       unidHasta4 As Decimal,
                       unidHasta5 As Decimal,
                       uHPorc1 As Decimal,
                       uHPorc2 As Decimal,
                       uHPorc3 As Decimal,
                       uHPorc4 As Decimal,
                       uHPorc5 As Decimal,
                       orden As Integer,
                       descuentoRecargoPorc1 As Decimal,
                       descuentoRecargoPorc2 As Decimal,
                       codigoExportacion As String,
                       idRubroTiendaNube As String,
                       idRubroMercadoLibre As String,
                       IdRubroArborea As String)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE Rubros")
         .AppendLine("   SET nombreRubro = '" & nombreRubro & "', ")
         If idActividad = 0 Then
            .AppendLine("  IdProvincia = null, ")
            .AppendLine("  IdActividad = null, ")
         Else
            .AppendLine("  IdProvincia = '" & idProvincia & "', ")
            .AppendLine("  IdActividad = " & idActividad.ToString() & ", ")
         End If
         .Append("ComisionPorVenta = " & comisionPorVenta.ToString() & ", ")

         .AppendLine("  UnidHasta1 = " & unidHasta1.ToString() & ", ")
         .AppendLine("  UnidHasta2 = " & unidHasta2.ToString() & ", ")
         .AppendLine("  UnidHasta3 = " & unidHasta3.ToString() & ", ")
         .AppendLine("  UnidHasta4 = " & unidHasta4.ToString() & ", ")
         .AppendLine("  UnidHasta5 = " & unidHasta5.ToString() & ", ")
         .AppendLine("  UHPorc1 = " & uHPorc1.ToString() & ", ")
         .AppendLine("  UHPorc2 = " & uHPorc2.ToString() & ", ")
         .AppendLine("  UHPorc3 = " & uHPorc3.ToString() & ", ")
         .AppendLine("  UHPorc4 = " & uHPorc4.ToString() & ", ")
         .AppendLine("  UHPorc5 = " & uHPorc5.ToString() & ", ")
         .AppendLine("  Orden = " & orden.ToString() & ", ")
         .AppendLine("  DescuentoRecargoPorc1 = " & descuentoRecargoPorc1.ToString() & ", ")
         .AppendLine("  DescuentoRecargoPorc2 = " & descuentoRecargoPorc2.ToString() & ",")
         .AppendFormatLine("  CodigoExportacion = '{0}'", codigoExportacion)

         If Not String.IsNullOrEmpty(idRubroTiendaNube) Then
            .AppendFormatLine("  ,IdRubroTiendaNube = '{0}'", idRubroTiendaNube)
         Else
            .AppendFormatLine("  ,IdRubroTiendaNube = NULL")
         End If
         '-- REQ30521.- --
         If Not String.IsNullOrEmpty(idRubroMercadoLibre) Then
            .AppendFormatLine("  ,IdRubroMercadoLibre = '{0}'", idRubroMercadoLibre)
         Else
            .AppendFormatLine("  ,IdRubroMercadoLibre = NULL")
         End If

         If Not String.IsNullOrEmpty(IdRubroArborea) Then
            .AppendFormatLine("  ,IdRubroArborea = '{0}'", IdRubroArborea)
         Else
            .AppendFormatLine("  ,IdRubroArborea = NULL")
         End If

         .Append(" WHERE IdRubro = " & idRubro.ToString())
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Rubros_D(idRubro As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Append("DELETE FROM Rubros ")
         .Append(" WHERE idRubro = " & idRubro.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Rubros")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)

      With stb
         .AppendLine("SELECT R.*")
         .AppendLine("  FROM Rubros R")
      End With

   End Sub

   Public Function Rubros_GA(fechaActualizacionDesde As DateTime?) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If fechaActualizacionDesde.HasValue Then
            .AppendFormat("   AND R.{0} > '{1}'",
                          Entidades.Rubro.Columnas.FechaActualizacionWeb.ToString(), ObtenerFecha(fechaActualizacionDesde.Value, True, True)).AppendLine()
         End If

         .Append("ORDER BY R.NombreRubro ")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function Rubros_G1(ByVal IdRubro As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE R.IdRubro = " & IdRubro.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "R." + columna
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine("  WHERE {0} LIKE '%{1}%'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo("IdRubro", "Rubros"))
   End Function

   Public Overloads Function GetOrdenMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo("Orden", "Rubros"))
   End Function

   Public Function Rubros_GetPrimerRubro() As Integer
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT TOP 1 R.IdRubro")
         .AppendLine("  FROM Rubros R")
      End With
      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      Return Integer.Parse(dt.Rows(0).Item("IdRubro").ToString())
   End Function

   Public Function GetRubrosTiendasWeb(idRubroTiendaWeb As Entidades.TiendasWeb) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT R.IdRubro")
         .AppendFormatLine("	   , R.NombreRubro")
         .AppendFormatLine("	   , R.IdRubro{0}", idRubroTiendaWeb.ToString())
         .AppendFormatLine("  FROM Rubros R")
         .AppendFormatLine(" INNER JOIN Productos P ON R.IdRubro = P.IdRubro")
         .AppendFormatLine(" WHERE P.Activo = 'True'")
         .AppendFormatLine("   AND P.PublicarEn{0} = 'True'", idRubroTiendaWeb.ToString())
         .AppendFormatLine(" GROUP BY R.IdRubro, R.NombreRubro, R.IdRubro{0}", idRubroTiendaWeb.ToString())
      End With
      Return GetDataTable(query)
   End Function

   Public Sub GuardarIdRubroTiendaNube(idRubro As Integer, idRubroTiendaNube As String)
      Dim query As New StringBuilder
      With query
         .AppendFormatLine("UPDATE R SET R.IdRubroTiendaNube = '{0}' FROM Rubros R ", idRubroTiendaNube)
         .AppendFormatLine("	WHERE IdRubro = {0}", idRubro)
      End With
      Me.Execute(query.ToString())
   End Sub

   Public Sub GuardarIdRubroTiendaWeb(idTiendaWeb As String, idRubro As Integer, idRubroTiendaWeb As String)
      Dim query As New StringBuilder
      With query
         .AppendFormatLine("UPDATE R SET R.IdRubro" + idTiendaWeb + " = '{0}' FROM Rubros R ", idRubroTiendaWeb)
         .AppendFormatLine("	WHERE IdRubro = {0}", idRubro)
      End With
      Me.Execute(query.ToString())
   End Sub

End Class