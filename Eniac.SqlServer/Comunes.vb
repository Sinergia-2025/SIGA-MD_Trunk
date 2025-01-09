Imports Eniac.Entidades

Public Class Comunes

   Protected _da As Datos.DataAccess
   Protected Const ColumnAlias As String = "Maximo"
   Protected Const FormatoBuscar As String = " WHERE {0} LIKE '%{1}%'"
   Protected Const FormatoBuscarAnd As String = " AND {0} LIKE '%{1}%'"

   Public Sub New(da As Datos.DataAccess)
      Me._da = da
   End Sub

   Protected Function Execute(query As StringBuilder) As Integer
      Return Execute(query.ToString())
   End Function
   Protected Function Execute(query As String) As Integer

      Try
         With Me._da
            .Command.Connection = .Connection
            If .Transaction IsNot Nothing Then
               .Command.Transaction = .Transaction
            End If
            .Command.CommandText = query
            .Command.CommandType = CommandType.Text
            Dim cantidadRegistrosAfectados As Integer
            cantidadRegistrosAfectados = .Command.ExecuteNonQuery()
            Debug.WriteLine(String.Format("Cantidad de registros {0}", cantidadRegistrosAfectados))
            Return cantidadRegistrosAfectados
         End With
      Catch ex1 As SqlClient.SqlException

         Me.LgoError(ex1, query)
         Dim erro As Entidades.EniacException = New Entidades.EniacException(ex1.Message & vbNewLine & query)

         Select Case ex1.Number
            Case 547
               'If ex1.ErrorCode = -2146232060 Then
               '   Throw
               'End If
               If query.Trim.Substring(0, 6) = "UPDATE" Then
                  Throw New Exception("No se puede Actualizar el registro porque alguna caracteristica esta inconsistente.", ex1)
               ElseIf query.Trim.Substring(0, 6) = "INSERT" Then
                  Throw New Exception("No se puede Agregar el registro porque alguna caracteristica esta inconsistente.", ex1)
               ElseIf query.Contains("INSERT INTO") Or query.Contains("MERGE INTO") Then
                  Throw New Exception(ex1.Message + Convert.ToChar(13) + query.ToString(), ex1)
               Else
                  'controlo el error y trato de mandar mas información
                  Dim men As String
                  Dim peda As String
                  Dim comi As Integer
                  men = "No se puede Eliminar porque esta siendo utilizado"
                  If ex1.Message.Contains("FK_") Then
                     men += " en "
                     comi = ex1.Message.IndexOf("dbo.") + 4
                     peda = ex1.Message.Substring(comi, ex1.Message.Length - comi)
                     If peda.IndexOf(",") > 1 Then
                        peda = peda.Substring(0, peda.IndexOf(",") - 1)
                     End If
                     men += peda
                  End If
                  Throw New Exception(men, ex1)
               End If

            Case 2627
               Dim nombrePK = String.Empty
               If ex1.Message.Contains("PK_") Then
                  nombrePK = String.Format(" ({0})", ex1.Message.Substring(ex1.Message.IndexOf("PK_"), ex1.Message.IndexOf("'.", ex1.Message.IndexOf("PK_")) - ex1.Message.IndexOf("PK_")))
               ElseIf ex1.Message.Contains("AK_") Then
                  nombrePK = String.Format(" ({0})", ex1.Message.Substring(ex1.Message.IndexOf("AK_"), ex1.Message.IndexOf("'.", ex1.Message.IndexOf("AK_")) - ex1.Message.IndexOf("AK_")))
               Else

               End If

               Throw New Exception(String.Format("El código ingresado ya existe.{0}", nombrePK), ex1)
            Case Else
               Throw
         End Select
      Catch
         Throw
      End Try

   End Function

   Protected Function ExecuteLimpio(query As String) As Integer

      Try
         With Me._da
            .Command.Connection = .Connection
            If .Transaction IsNot Nothing Then
               .Command.Transaction = .Transaction
            End If
            .Command.CommandText = query
            .Command.CommandType = CommandType.Text
            Dim cantidadRegistrosAfectados As Integer
            cantidadRegistrosAfectados = .Command.ExecuteNonQuery()
            Debug.WriteLine(String.Format("Cantidad de registros {0}", cantidadRegistrosAfectados))
            Return cantidadRegistrosAfectados
         End With
      Catch
         Throw
      End Try

   End Function

   Public Function AgregarParametro(nombreParametro As String, valor As Byte()) As Data.Common.DbParameter
      Return AgregarParametro(nombreParametro, DbType.Binary, valor.Length, valor)
   End Function
   Public Function AgregarParametro(nombreParametro As String, valor As String) As Data.Common.DbParameter
      Return AgregarParametro(nombreParametro, DbType.String, Nothing, valor)
   End Function
   Public Function AgregarParametro(nombreParametro As String, valor As Long) As Data.Common.DbParameter
      Return AgregarParametro(nombreParametro, DbType.Int64, Nothing, valor)
   End Function
   Public Function AgregarParametro(nombreParametro As String, valor As Integer) As Data.Common.DbParameter
      Return AgregarParametro(nombreParametro, DbType.Int32, Nothing, valor)
   End Function
   Public Function AgregarParametro(nombreParametro As String, dataType As System.Data.DbType, size As Integer?, valor As Object) As Data.Common.DbParameter
      Dim oParameter As Data.Common.DbParameter = Me._da.Command.CreateParameter()
      oParameter.ParameterName = nombreParametro
      oParameter.DbType = dataType
      If size.HasValue Then
         oParameter.Size = size.Value
      End If
      oParameter.Value = valor
      Me._da.Command.Parameters.Add(oParameter)
      Return oParameter
   End Function

   Private Sub LgoError(Problema As Exception, Comentario As String)
      Try
         Dim mensaje As String = String.Format("Error: {1}{0}{2}{0} Stack Trace: {3}", Environment.NewLine, Problema.Message, Comentario, Problema.StackTrace).Replace("'", "´")

         Try
            My.Application.Log.WriteEntry(mensaje, TraceEventType.Error)
         Catch ex As Exception
         End Try

         GrabarErrorEnBitacora(mensaje)

      Catch ex As Exception

      End Try
   End Sub

   Protected Overridable Sub GrabarErrorEnBitacora(mensaje As String)
      Try
         Dim da As Eniac.Datos.DataAccess = New Datos.DataAccess()
         Try
            da.OpenConection()

            Dim dt = New Parametros(da).GetValorPD(actual.Sucursal.IdEmpresa, "IDAPLICACION")
            Dim valor = If(dt.Rows.Count = 0, "SIGA", dt.Rows(0)("ValorParametro").ToString().Trim())
            Dim aplicacion = valor
            Dim sqlBitacora = New Bitacora(da)
            sqlBitacora.Bitacora_I(actual.Sucursal.Id, -1, Now, aplicacion, actual.Nombre, My.Computer.Name, Entidades.Bitacora.TipoBitacora.SucedioError.ToString(), mensaje)

         Finally
            da.CloseConection()
         End Try

      Catch ex As Exception
      End Try
   End Sub

   Protected Function ExecuteReadear(query As String) As System.Data.Common.DbDataReader
      Me._da.Command.Connection = Me._da.Connection
      Me._da.Command.Transaction = Me._da.Transaction
      Me._da.Command.CommandText = query
      Return Me._da.Command.ExecuteReader()
   End Function

   Protected Function ExecuteScalar(query As String) As Object
      Me._da.Command.Connection = Me._da.Connection
      Me._da.Command.CommandText = query
      Return Me._da.Command.ExecuteScalar()
   End Function

   Protected Function GetDataTable(query As String) As DataTable
      Return Me._da.GetDataTable(query)
   End Function
   Protected Function GetDataTable(query As StringBuilder) As DataTable
      Return GetDataTable(query.ToString())
   End Function

   Protected Sub Sincroniza_I(query As String, tabla As String)
      Exit Sub       'SE ANULA - DE MOMENTO NO HACEMOS SINCRONIZACIONES Y ESTÁ ACUMULANDO UNA CANTIDAD INMENSA DE REGISTROS SIN SENTIDO


      'Dim myQuery As StringBuilder = New StringBuilder("")
      'Dim dt As DataTable = New DataTable()

      'With myQuery
      '   .Append("select count(*) as valor from Parametros ")
      '   .Append("where idParametro = 'SINCRONIZA' ")
      '   .Append("and ValorParametro = 'True'")
      'End With
      'dt = Me.GetDataTable(myQuery.ToString())

      ''si no esta seteado no sincroniza
      'If Int32.Parse(dt.Rows(0)("valor").ToString()) = 0 Then
      '   Exit Sub
      'End If

      'With myQuery
      '   .Length = 0
      '   .Append("SELECT * ")
      '   .Append(" FROM SincronizaTablas")
      '   .Append(" WHERE ")
      '   .Append("	IdSucursal = (SELECT idsucursal FROM Sucursales WHERE estoyaca = 1)")
      '   .Append(" and")
      '   .Append("	NombreTabla = '")
      '   .Append(tabla)
      '   .Append("'")
      'End With


      'dt.Columns.Add("Id")
      'dt.Columns.Add("Nombre")
      'dt.Columns.Add("Tipo")

      'Dim dr As DataRow

      'Me._da.Command.CommandText = myQuery.ToString()
      'Me._da.Command.CommandType = CommandType.Text
      'Dim reader As System.Data.Common.DbDataReader = Me._da.Command.ExecuteReader()

      'Using reader
      '   Do While reader.Read()
      '      dr = dt.NewRow()
      '      dr(0) = reader.GetInt32(0)
      '      dr(1) = reader.GetString(1)
      '      dr(2) = reader.GetString(2)
      '      dt.Rows.Add(dr)
      '   Loop
      'End Using

      'If dt.Rows.Count > 0 Then
      '   With myQuery
      '      .Length = 0
      '      .Append("INSERT INTO SincronizaRegistros")
      '      .Append("           (FechaHora")
      '      .Append("           ,SucursalOrigen")
      '      .Append("           ,SucursalDestino")
      '      .Append("           ,Query")
      '      .Append("           ,Tabla")
      '      .Append("           ,FechaHoraProceso")
      '      .Append("           ,Estado)")
      '      .Append("	SELECT ")
      '      .Append(" '" & Me.ObtenerFecha(DateTime.Now, True) & "' fechaHora,")
      '      .Append("			(SELECT idsucursal FROM Sucursales WHERE estoyaca = 1) origen,")
      '      .Append("			idsucursal destino,")
      '      .Append("	'" & query.Replace("'", "´") & "' query,")
      '      .Append("	'" & tabla & "' tabla,")
      '      .Append("			null proceso,")
      '      .Append("			'I' estado")
      '      .Append("	FROM Sucursales")
      '      Select Case dt.Rows(0)("Tipo").ToString()
      '         Case "C" 'solo replica hacia la central
      '            .Append("	WHERE soylacentral = 1")
      '         Case "T" 'replica a todas lados menos la actual
      '            .Append("	WHERE estoyaca <> 1")
      '         Case "S" 'replica solo a las sucursales, siempre y cuando este en la central
      '            .Append("	WHERE (SELECT idsucursal FROM Sucursales WHERE estoyaca =1)")
      '            .Append("			= (SELECT idsucursal FROM Sucursales WHERE soylacentral =1)")
      '            .Append(" AND idsucursal <> (SELECT idsucursal FROM Sucursales WHERE estoyaca =1)")
      '      End Select
      '   End With

      '   Me.Execute(myQuery.ToString())
      'End If
   End Sub

   Protected Function ObtenerFecha(fecha As Date?, traerHoraReal As Boolean, Optional conMilisegundos As Boolean = False) As String
      If fecha.HasValue Then
         Return GetStringParaQueryConComillas(ObtenerFecha(fecha.Value, traerHoraReal, conMilisegundos))
      End If
      Return "NULL"
   End Function
   Protected Function ObtenerFecha(fecha As Date, traerHoraReal As Boolean, Optional conMilisegundos As Boolean = False) As String
      Dim myQuery = New StringBuilder()
      With myQuery
         .Append(fecha.Year.ToString("0000"))
         .Append(fecha.Month.ToString("00"))
         .Append(fecha.Day.ToString("00"))
         If traerHoraReal Then
            .Append(" ")
            .Append(fecha.Hour.ToString("00"))
            .Append(":")
            .Append(fecha.Minute.ToString("00"))
            .Append(":")
            .Append(fecha.Second.ToString("00"))
            If conMilisegundos Then
               .Append(".")
               .Append(fecha.Millisecond.ToString("000"))
            End If
         Else
            .Append(" 00:00:00")
            If conMilisegundos Then
               .Append(".000")
            End If
         End If
      End With
      Return myQuery.ToString()
   End Function

   'Protected Function GetCurrenCultura() As System.Globalization.CultureInfo
   '   Dim MiCultura As System.Globalization.CultureInfo = DirectCast(System.Globalization.CultureInfo.CurrentCulture.Clone(), System.Globalization.CultureInfo)
   '   Dim MiFormato As System.Globalization.NumberFormatInfo = New System.Globalization.CultureInfo(System.Globalization.CultureInfo.CurrentCulture.ToString(), False).NumberFormat
   '   MiFormato.NumberDecimalSeparator = "."
   '   MiFormato.NumberGroupSeparator = ","
   '   MiFormato.NumberDecimalDigits = 2
   '   MiFormato.CurrencyDecimalDigits = 2
   '   MiFormato.CurrencyDecimalSeparator = "."
   '   MiFormato.CurrencyGroupSeparator = ","
   '   MiCultura.NumberFormat = MiFormato
   '   Return MiCultura
   'End Function

   Public Function GetAnchoCampo(tabla As String, campo As String) As Integer
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE ")
         .AppendFormatLine(" FROM INFORMATION_SCHEMA.COLUMNS")
         .AppendFormatLine(" WHERE TABLE_NAME = '{0}'", tabla)
         .AppendFormatLine("   AND COLUMN_NAME = '{0}'", campo)
      End With

      Dim dt As DataTable = Me.GetDataTable(myQuery.ToString())
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Dim dataType As String = dr("DATA_TYPE").ToString()
         Select Case dataType
            Case "bigint", "Int", "smallint"
               Return Integer.Parse(dr("NUMERIC_PRECISION").ToString())
            Case "decimal"
               Return Integer.Parse(dr("NUMERIC_PRECISION").ToString()) - Integer.Parse(dr("NUMERIC_SCALE").ToString())
            Case "char", "nvarchar", "varchar"
               Return Integer.Parse(dr("CHARACTER_MAXIMUM_LENGTH").ToString())
            Case "bit"
               Return 1
            Case "DateTime"
               Return 19
            Case Else
               Throw New Exception(String.Format("ATENCION: el campo '{1}' de la Tabla '{2}' tiene el tipo de dato '{3}' y NO podrá continuar.{0}{0}Por favor contáctese con Sistemas.",
                                                 Environment.NewLine, campo, tabla, dataType))
         End Select
      Else
         Throw New Exception(String.Format("ATENCION: NO existe el campo '{1}' de la Tabla '{2}' y NO podrá continuar.{0}{0}Por favor contáctese con Sistemas.",
                                           Environment.NewLine, campo, tabla))
      End If
   End Function

   Protected Function GetStringFromNumber(valor As Long?) As String
      If valor.HasValue Then
         Return valor.ToString()
      Else
         Return "NULL"
      End If
   End Function

   Protected Function GetStringFromNumber(valor As Long) As String
      Return GetStringFromNumber(valor, 0)
   End Function

   Protected Function GetStringFromNumber(valor As Long, valorParaNull As Long) As String
      If valor = valorParaNull Then
         Return "NULL"
      Else
         Return valor.ToString()
      End If
   End Function

   Protected Function GetStringFromDecimal(valor As Decimal?) As String
      If valor.HasValue Then
         Return valor.ToString()
      Else
         Return "NULL"
      End If
   End Function

   Protected Function GetStringFromDecimal(valor As Decimal) As String
      Return GetStringFromDecimal(valor, 0)
   End Function

   Protected Function GetStringFromDecimal(valor As Decimal, valorParaNull As Decimal) As String
      If valor = valorParaNull Then
         Return "NULL"
      Else
         Return valor.ToString()
      End If
   End Function

   Protected Function GetStringFromBoolean(valor As Boolean?) As String
      If valor.HasValue Then
         Return GetStringFromBoolean(valor.Value)
      Else
         Return "NULL"
      End If
   End Function
   Public Shared Function GetStringFromBoolean(valor As Boolean) As String
      If valor Then
         Return "1"
      Else
         Return "0"
      End If
   End Function

   Protected Function ConvertirBitSiNo(aliasTabla As String, nombreColumna As String) As String
      Return String.Format("CASE WHEN {0}.{1} IS NULL THEN '' ELSE CASE WHEN {0}.{1} = 0 THEN 'NO' ELSE 'SI' END END AS {1}_SN", aliasTabla, nombreColumna)
   End Function

   Public Sub SincronizaRegistros_I(fechaHora As DateTime,
                          sucursalOrigen As Int32,
                          sucursalDestino As Int32,
                          query As String,
                          tabla As String,
                          fechaHoraProceso As DateTime,
                          estado As String)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO  ")
         .Append(" SincronizaRegistros  ")
         .Append(" (FechaHora ")
         .Append(" ,SucursalOrigen  ")
         .Append(" ,SucursalDestino  ")
         .Append(" ,Query  ")
         .Append(" ,Tabla  ")
         .Append(" ,FechaHoraProceso  ")
         .Append(" ,Estado)  ")
         .Append(" VALUES( ")
         If fechaHora = Nothing Then
            .Append("null, ")
         Else
            .Append("'" & Me.ObtenerFecha(fechaHora, True) & "', ")
         End If
         .Append(sucursalOrigen & ", ")
         .Append(sucursalDestino & ", ")
         .Append(" '" & query & "', ")
         .Append(" '" & tabla & "', ")
         If fechaHoraProceso <= New DateTime(1900, 1, 1) Then
            .Append(" null, ")
         Else
            .Append(" '" & Me.ObtenerFecha(fechaHoraProceso, True) & "', ")
         End If
         .Append(" '" & estado & "') ")
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub SincronizaRegistros_D(idSucursalDestino As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM  ")
         .Append("SincronizaRegistros  ")
         .Append("WHERE  ")
         .Append("SucursalDestino = " & idSucursalDestino)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub SincronizaRegistros_UEstado(idSucursalDestino As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("UPDATE SincronizaRegistros ")
         .Append("   SET Estado = 'T'")
         .Append("WHERE  ")
         .Append("SucursalDestino = " & idSucursalDestino)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub SincronizaRegistro_D(id As Long)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM  ")
         .Append("SincronizaRegistros  ")
         .Append("WHERE  ")
         .Append("Id = " & id)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub SincronizaQuery_I(query As String)
      Me.Execute(query)
   End Sub

   Public Function GetStringParaQueryConComillas(cadena As String) As String
      Dim cad As String = Me.GetStringParaQuery(cadena)
      If cad = "NULL" Then
         Return cad
      Else
         Return "'" + cad + "'"
      End If
   End Function

   Public Function GetStringParaQuery(cadena As String) As String
      If String.IsNullOrEmpty(cadena) Then
         Return "NULL"
      End If
      cadena.Replace("'", "´")
      Return cadena
   End Function

   Public Function GetInt32ParaQuery(entero As Int32) As String
      If entero = 0 Then
         Return "NULL"
      End If
      Return entero.ToString()
   End Function
   Public Function GetCodigoMinimo(campo As String, tabla As String) As Long
      Return GetCodigoMinimo(campo, tabla, String.Empty)
   End Function
   Public Function GetCodigoMinimo(campo As String, tabla As String, condicion As String) As Long
      Dim result As Long = 0

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormat("SELECT MIN({0}) AS {1} FROM {2}", campo, ColumnAlias, tabla)
         If Not String.IsNullOrWhiteSpace(condicion) Then
            .AppendFormat(" WHERE {0}", condicion)
         End If
      End With
      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 AndAlso dt.Columns.Contains(ColumnAlias) Then
         If Not IsDBNull(dt.Rows(0)(ColumnAlias)) AndAlso Not String.IsNullOrWhiteSpace(dt.Rows(0)(ColumnAlias).ToString()) Then
            If Not Long.TryParse(dt.Rows(0)(ColumnAlias).ToString(), result) Then
               result = 0
            End If
         End If
      End If
      Return result
   End Function


   Public Function GetCodigoMaximo(campo As String, tabla As String) As Long
      Return GetCodigoMaximo(campo, tabla, String.Empty)
   End Function
   Public Function GetCodigoMaximo(campo As String, tabla As String, condicion As String) As Long
      Dim result As Long = 0

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormat("SELECT MAX({0}) AS {1} FROM {2}", campo, ColumnAlias, tabla)
         If Not String.IsNullOrWhiteSpace(condicion) Then
            .AppendFormat(" WHERE {0}", condicion)
         End If
      End With
      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 AndAlso dt.Columns.Contains(ColumnAlias) Then
         If Not IsDBNull(dt.Rows(0)(ColumnAlias)) AndAlso Not String.IsNullOrWhiteSpace(dt.Rows(0)(ColumnAlias).ToString()) Then
            If Not Long.TryParse(dt.Rows(0)(ColumnAlias).ToString(), result) Then
               result = 0
            End If
         End If
      End If
      Return result
   End Function

   Protected Function ProductoPublicarEn(stb As StringBuilder, filtro As Entidades.Filtros.ProductosPublicarEnFiltros, aliasTablaProducto As String) As StringBuilder
      If filtro IsNot Nothing Then
         stb.AppendFormat("      AND (")
         If filtro.AndOr = Entidades.Publicos.AndOr.And Then
            stb.AppendFormatLine("1 = 1")
         Else
            stb.AppendFormatLine("0 = 1")
         End If
         If filtro.Web <> Entidades.Publicos.SiNoTodos.TODOS Then
            ProductoPublicarEn(stb, filtro.Web, aliasTablaProducto, Entidades.Producto.Columnas.PublicarEnWeb, filtro.AndOr)
         End If
         If filtro.TiendaNube <> Entidades.Publicos.SiNoTodos.TODOS Then
            ProductoPublicarEn(stb, filtro.TiendaNube, aliasTablaProducto, Entidades.Producto.Columnas.PublicarEnTiendaNube, filtro.AndOr)
         End If
         If filtro.MercadoLibre <> Entidades.Publicos.SiNoTodos.TODOS Then
            ProductoPublicarEn(stb, filtro.MercadoLibre, aliasTablaProducto, Entidades.Producto.Columnas.PublicarEnMercadoLibre, filtro.AndOr)
         End If
         If filtro.Arborea <> Entidades.Publicos.SiNoTodos.TODOS Then
            ProductoPublicarEn(stb, filtro.Arborea, aliasTablaProducto, Entidades.Producto.Columnas.PublicarEnArborea, filtro.AndOr)
         End If
         If filtro.Gestion <> Entidades.Publicos.SiNoTodos.TODOS Then
            ProductoPublicarEn(stb, filtro.Gestion, aliasTablaProducto, Entidades.Producto.Columnas.PublicarEnGestion, filtro.AndOr)
         End If
         If filtro.Empresarial <> Entidades.Publicos.SiNoTodos.TODOS Then
            ProductoPublicarEn(stb, filtro.Empresarial, aliasTablaProducto, Entidades.Producto.Columnas.PublicarEnEmpresarial, filtro.AndOr)
         End If

         If filtro.Balanza <> Entidades.Publicos.SiNoTodos.TODOS Then
            ProductoPublicarEn(stb, filtro.Balanza, aliasTablaProducto, Entidades.Producto.Columnas.PublicarEnBalanza, filtro.AndOr)
         End If
         If filtro.SincronizacionSucursal <> Entidades.Publicos.SiNoTodos.TODOS Then
            ProductoPublicarEn(stb, filtro.SincronizacionSucursal, aliasTablaProducto, Entidades.Producto.Columnas.PublicarEnSincronizacionSucursal, filtro.AndOr)
         End If
         If filtro.ListaPrecioCliente <> Entidades.Publicos.SiNoTodos.TODOS Then
            ProductoPublicarEn(stb, filtro.ListaPrecioCliente, aliasTablaProducto, Entidades.Producto.Columnas.PublicarListaDePreciosClientes, filtro.AndOr)
         End If
         stb.AppendFormatLine(")")
      End If
      Return stb
   End Function

   Private Function ProductoPublicarEn(stb As StringBuilder, publicar As Entidades.Publicos.SiNoTodos, aliasTablaProducto As String, campo As Entidades.Producto.Columnas, andOr As Entidades.Publicos.AndOr) As StringBuilder
      stb.AppendFormatLine("      {0} {1}.{2} = '{3}'",
                           If(andOr = Entidades.Publicos.AndOr.And, "AND", "OR"), aliasTablaProducto, campo, publicar = Entidades.Publicos.SiNoTodos.SI)
      Return stb
   End Function

   Public Shared Function GetListaSucursalesMultiples(stb As StringBuilder, sucursales As IEnumerable(Of Entidades.Sucursal), aliasTabla As String) As StringBuilder
      If sucursales IsNot Nothing AndAlso sucursales.Any() Then
         stb.AppendFormatLine("   AND {0}.IdSucursal IN ({1})", aliasTabla, String.Join(",", sucursales.ToList().ConvertAll(Function(s) s.Id)))
      End If
      Return stb
   End Function
   Public Shared Function GetListaSucursalesNovedadesMultiples(stb As StringBuilder, sucursales As IEnumerable(Of Entidades.Sucursal), aliasTabla As String) As StringBuilder
      If sucursales IsNot Nothing AndAlso sucursales.Any() Then
         stb.AppendFormatLine("   AND {0}.IdSucursalNovedad IN ({1})", aliasTabla, String.Join(",", sucursales.ToList().ConvertAll(Function(s) s.Id)))
      End If
      Return stb
   End Function
   Public Shared Function GetListaEmpresasMultiples(stb As StringBuilder, empresas As Entidades.Empresa(), aliasTabla As String) As StringBuilder
      Return GetListaIntegerMultiples(stb, empresas.ToList().ConvertAll(Function(e) e.IdEmpresa), aliasTabla, nombreCampo:="IdEmpresa", notIn:=False)
   End Function

   Public Shared Function GetListaEstadosOrdenCalidadMultiples(stb As StringBuilder, estados As Entidades.EstadoOrdenCalidad(), aliasTabla As String) As StringBuilder
      If estados IsNot Nothing AndAlso estados.Length > 0 Then
         stb.AppendFormat("   AND {0}.IdEstadoCalidad IN (", aliasTabla)
         For Each estado As Entidades.EstadoOrdenCalidad In estados
            stb.AppendFormat("'{0}',", estado.IdEstadoCalidad)
         Next
         stb.AppendFormat("'{0}')", estados(0).IdEstadoCalidad)
      End If
      Return stb
   End Function
   Public Shared Function GetListaIntegerMultiples(stb As StringBuilder, numeros As IEnumerable(Of Integer), aliasTabla As String, nombreCampo As String, notIn As Boolean) As StringBuilder
      If numeros IsNot Nothing AndAlso numeros.Count > 0 Then
         stb.AppendFormatLine("   AND {0}.{1} {2} IN ({3})", aliasTabla, nombreCampo, If(notIn, "NOT", ""), String.Join(",", numeros))
      End If
      Return stb
   End Function

   Public Shared Function GetListaTiposClienteMultiples(stb As StringBuilder, tiposCliente As Entidades.TipoCliente(), aliasTabla As String) As StringBuilder
      If tiposCliente IsNot Nothing AndAlso tiposCliente.Length > 0 Then
         stb.AppendFormat("   AND {0}.IdTipoCliente IN (", aliasTabla)
         For Each tipoc As Entidades.TipoCliente In tiposCliente
            stb.AppendFormat("{0},", tipoc.IdTipoCliente)
         Next
         stb.AppendFormat("{0})", tiposCliente(0).IdTipoCliente)
      End If
      Return stb
   End Function

   Public Shared Function GetListaDePreciosMultiples(stb As StringBuilder, listaPrecios As Entidades.ListaDePrecios(), aliasTabla As String,
                                                     Optional abrirParentesis As String = "") As StringBuilder
      '# El parámetro opcional sirve para cuando se lo llama desde el Historial de Precios, para el uso de una de sus variantes.
      If listaPrecios IsNot Nothing AndAlso listaPrecios.Length > 0 Then
         stb.AppendFormat("   AND {0}{1}.IdListaPrecios IN (", abrirParentesis, aliasTabla)
         For Each list As Entidades.ListaDePrecios In listaPrecios
            stb.AppendFormat("{0},", list.IdListaPrecios)
         Next
         stb.AppendFormat("{0})", listaPrecios(0).IdListaPrecios)
      End If
      Return stb
   End Function

   Public Shared Sub GetListaCategoriasMultiples(stb As StringBuilder, categorias As ICollection(Of Entidades.Categoria), aliasTabla As String)
      If categorias IsNot Nothing AndAlso categorias.Count > 0 Then
         stb.AppendFormat("   AND {0}.IdCategoria IN (", aliasTabla)
         For Each cat As Entidades.Categoria In categorias
            stb.AppendFormat("{0},", cat.IdCategoria)
         Next
         stb.AppendFormat("{0})", categorias(0).IdCategoria)
      End If
   End Sub

   Public Shared Sub GetListaCategoriasFiscalesMultiples(stb As StringBuilder, categorias As ICollection(Of Entidades.CategoriaFiscal), aliasTabla As String)
      If categorias IsNot Nothing AndAlso categorias.Count > 0 Then
         stb.AppendFormat("   AND {0}.IdCategoriaFiscal IN (", aliasTabla)
         For Each cat As Entidades.CategoriaFiscal In categorias
            stb.AppendFormat("{0},", cat.IdCategoriaFiscal)
         Next
         stb.AppendFormat("{0})", categorias(0).IdCategoriaFiscal)
      End If
   End Sub


   Public Shared Sub GetListaMarcasMultiples(stb As StringBuilder, marcas As IEnumerable(Of Entidades.Marca), aliasTabla As String)
      If marcas IsNot Nothing AndAlso marcas.Any() Then
         stb.AppendFormatLine("   AND {0}.IdMarca IN ({1})", aliasTabla, String.Join(",", marcas.ToList().ConvertAll(Function(m) m.IdMarca)))
      End If
   End Sub
   Public Shared Sub GetListaModelosMultiples(stb As StringBuilder, modelos As IEnumerable(Of Entidades.Modelo), aliasTabla As String)
      If modelos IsNot Nothing AndAlso modelos.Any() Then
         stb.AppendFormatLine("   AND {0}.IdModelo IN ({1})", aliasTabla, String.Join(",", modelos.ToList().ConvertAll(Function(m) m.IdModelo)))
      End If
   End Sub
   Public Shared Sub GetListaCategoriasNovedadesMultiples(stb As StringBuilder, CategoriasNovedades As IEnumerable(Of Entidades.CRMCategoriaNovedad), aliasTabla As String)
      If CategoriasNovedades IsNot Nothing AndAlso CategoriasNovedades.Any() Then
         stb.AppendFormatLine("   AND {0}.IdCategoriaNovedad IN ({1})", aliasTabla, String.Join(",", CategoriasNovedades.ToList().ConvertAll(Function(m) m.IdCategoriaNovedad)))
      End If
   End Sub
   Public Shared Sub GetListaEstadosNovedadesMultiples(stb As StringBuilder, EstadosNovedades As IEnumerable(Of Entidades.CRMEstadoNovedad), aliasTabla As String)
      If EstadosNovedades IsNot Nothing AndAlso EstadosNovedades.Any() Then
         stb.AppendFormatLine("   AND {0}.IdEstadoNovedad IN ({1})", aliasTabla, String.Join(",", EstadosNovedades.ToList().ConvertAll(Function(m) m.IdEstadoNovedad)))
      End If
   End Sub
   Public Shared Sub GetListaMediosNovedadesMultiples(stb As StringBuilder, MediosNovedades As IEnumerable(Of Entidades.CRMMedioComunicacionNovedad), aliasTabla As String)
      If MediosNovedades IsNot Nothing AndAlso MediosNovedades.Any() Then
         stb.AppendFormatLine("   AND {0}.IdMedioComunicacionNovedad IN ({1})", aliasTabla, String.Join(",", MediosNovedades.ToList().ConvertAll(Function(m) m.IdMedioComunicacionNovedad)))
      End If
   End Sub
   Public Shared Sub GetListaMetodoNovedadesMultiples(stb As StringBuilder, MetodoNovedades As IEnumerable(Of Entidades.CRMMetodoResolucionNovedad), aliasTabla As String)
      If MetodoNovedades IsNot Nothing AndAlso MetodoNovedades.Any() Then
         stb.AppendFormatLine("   AND ({0}.IdMetodoResolucionNovedad IN ({1}) OR {0}.IdMetodoResolucionNovedad IS NULL)", aliasTabla, String.Join(",", MetodoNovedades.ToList().ConvertAll(Function(m) m.IdMetodoResolucionNovedad)))
      End If
   End Sub
   Public Shared Sub GetListaEstadosChequesMultiples(stb As StringBuilder, estados As Entidades.EstadoCheque(), aliasTabla As String)
      If estados IsNot Nothing AndAlso estados.Length > 0 Then
         stb.AppendFormat("   AND {0}.IdEstadoCheque IN (", aliasTabla)
         For Each ent As Entidades.EstadoCheque In estados
            stb.AppendFormat("'{0}',", ent.IdEstadoCheque)
         Next
         stb.AppendFormat("'{0}')", estados(0).IdEstadoCheque)
      End If
   End Sub
   Public Shared Sub GetListaMultiples(stb As StringBuilder, productos As Entidades.Producto(), aliasTabla As String)
      If productos IsNot Nothing AndAlso productos.Length > 0 Then
         stb.AppendFormat("   AND {0}.IdProducto IN (", aliasTabla)
         For Each ent As Entidades.Producto In productos
            stb.AppendFormat("'{0}',", ent.IdProducto)
         Next
         stb.AppendFormat("'{0}')", productos(0).IdProducto)
      End If
   End Sub
   Public Shared Sub GetListaMultiples(stb As StringBuilder, grupo As Entidades.Grupo(), aliasTabla As String)
      If grupo IsNot Nothing AndAlso grupo.Length > 0 Then
         stb.AppendFormat("   AND {0}.Grupo IN (", aliasTabla)
         For Each ent As Entidades.Grupo In grupo
            stb.AppendFormat("'{0}',", ent.IdGrupo)
         Next
         stb.AppendFormat("'{0}')", grupo(0).IdGrupo)
      End If
   End Sub
   Public Shared Sub GetListaMultiples(stb As StringBuilder, rutas As Entidades.MovilRuta(), aliasTabla As String)
      If rutas IsNot Nothing AndAlso rutas.Length > 0 Then
         stb.AppendFormat("   AND {0}.IdRuta IN (", aliasTabla)
         For Each ent As Entidades.MovilRuta In rutas
            stb.AppendFormat("'{0}',", ent.IdRuta)
         Next
         stb.AppendFormat("'{0}')", rutas(0).IdRuta)
      End If
   End Sub
   Public Shared Sub GetListaMultiples(stb As StringBuilder, formaPago As Entidades.VentaFormaPago(), aliasTabla As String)
      If formaPago IsNot Nothing AndAlso formaPago.Length > 0 Then
         stb.AppendFormat("   AND {0}.IdFormasPago IN (", aliasTabla)
         For Each ent As Entidades.VentaFormaPago In formaPago
            stb.AppendFormat("'{0}',", ent.IdFormasPago)
         Next
         stb.AppendFormat("'{0}')", formaPago(0).IdFormasPago)
      End If
   End Sub

   Public Shared Sub GetListaMultiples(stb As StringBuilder, cajas As Entidades.CajaNombre(), aliasTabla As String)
      GetListaMultiples(stb, cajas, aliasTabla, aliasCampo:="IdCaja")
   End Sub
   Public Shared Sub GetListaMultiples(stb As StringBuilder, cajas As Entidades.CajaNombre(), aliasTabla As String, aliasCampo As String)
      If cajas IsNot Nothing AndAlso cajas.Length > 0 Then
         stb.AppendFormat("   AND (")
         For Each ent As Entidades.CajaNombre In cajas
            stb.AppendFormat("({2}.IdSucursal = {0} AND {2}.{3} = {1}) OR", ent.IdSucursal, ent.IdCaja, aliasTabla, aliasCampo)
         Next
         stb.AppendFormatLine("({2}.IdSucursal = {0} AND {2}.{3} = {1}))", cajas(0).IdSucursal, cajas(0).IdCaja, aliasTabla, aliasCampo)
      End If
   End Sub

   Public Shared Sub GetListaMultiples(stb As StringBuilder, valores As String(), aliasTabla As String, nombreCampo As String)
      GetListaMultiples(stb, valores, aliasTabla, nombreCampo, True)
   End Sub
   Public Shared Sub GetListaMultiples(stb As StringBuilder, valores As IEnumerable(Of String), aliasTabla As String, nombreCampo As String, [in] As Boolean)
      If valores IsNot Nothing AndAlso valores.Count > 0 Then
         stb.AppendFormat("   AND {0}.{1} {2} IN (", aliasTabla, nombreCampo, If([in], "", "NOT"))
         For Each ent As String In valores
            If Not String.IsNullOrWhiteSpace(ent) Then
               stb.AppendFormat("'{0}',", ent)
            End If
         Next
         stb.AppendFormat("'{0}')", valores(0))
      End If
   End Sub

   Public Shared Sub GetListaEmpleadosMultiples(stb As StringBuilder, empleados As Entidades.Empleado(), aliasTabla As String)
      If empleados IsNot Nothing AndAlso empleados.Length > 0 Then
         stb.AppendFormat("   AND {0}.IdVendedor IN (", aliasTabla)
         For Each ent As Entidades.Empleado In empleados
            stb.AppendFormat("{0},", ent.IdEmpleado)
         Next
         stb.AppendFormat("{0})", empleados(0).IdEmpleado)
      End If
   End Sub

   Public Shared Sub GetListaDepositosMultiples(stb As StringBuilder, depositos As IEnumerable(Of Entidades.SucursalDeposito), aliasTabla As String)
      If depositos IsNot Nothing AndAlso depositos.Any() Then
         stb.AppendFormatLine("   AND {0}.IdDeposito IN ({1})", aliasTabla, String.Join(",", depositos.ToList().ConvertAll(Function(r) r.IdDeposito)))
      End If
   End Sub

   Public Shared Sub GetListaRubrosMultiples(stb As StringBuilder, rubros As IEnumerable(Of Entidades.Rubro), aliasTabla As String)
      If rubros IsNot Nothing AndAlso rubros.Any() Then
         stb.AppendFormatLine("   AND {0}.IdRubro IN ({1})", aliasTabla, String.Join(",", rubros.ToList().ConvertAll(Function(r) r.IdRubro)))
      End If
   End Sub

   Public Shared Sub GetListaRubrosComprasMultiples(stb As StringBuilder, rubrosCompra As IEnumerable(Of Entidades.RubroCompra), aliasTabla As String)
      If rubrosCompra IsNot Nothing AndAlso rubrosCompra.Any() Then
         stb.AppendFormatLine("   AND {0}.IdRubro IN ({1})", aliasTabla, String.Join(",", rubrosCompra.ToList().ConvertAll(Function(r) r.IdRubro)))
      End If
   End Sub

   Public Shared Sub GetListaSubRubrosMultiples(stb As StringBuilder, subRubros As IEnumerable(Of Entidades.SubRubro), aliasTabla As String)
      If subRubros IsNot Nothing AndAlso subRubros.Any() Then
         stb.AppendFormatLine("   AND {0}.IdSubRubro IN ({1})", aliasTabla, String.Join(",", subRubros.ToList().ConvertAll(Function(r) r.IdSubRubro)))
      End If
   End Sub
   Public Shared Sub GetListaSubSubRubrosMultiples(stb As StringBuilder, subSubRubros As IEnumerable(Of Entidades.SubSubRubro), aliasTabla As String)
      If subSubRubros IsNot Nothing AndAlso subSubRubros.Any() Then
         stb.AppendFormatLine("   AND {0}.IdSubSubRubro IN ({1})", aliasTabla, String.Join(",", subSubRubros.ToList().ConvertAll(Function(r) r.IdSubSubRubro)))
      End If
   End Sub

   Public Shared Sub GetListaTiposComprobantesMultiples(stb As StringBuilder, tiposComprobantes As Entidades.TipoComprobante(), aliasTabla As String)
      GetListaTiposComprobantesMultiples(stb, tiposComprobantes, aliasTabla, "IdTipoComprobante")
   End Sub
   Public Shared Sub GetListaTiposComprobantesMultiples(stb As StringBuilder, tiposComprobantes As Entidades.TipoComprobante(), aliasTabla As String, nombreColumna As String)
      If tiposComprobantes.AnySecure() Then
         stb.AppendFormat("   AND {0}.{1} IN (", aliasTabla, nombreColumna)
         For Each tpCom As Entidades.TipoComprobante In tiposComprobantes
            stb.AppendFormat("'{0}',", tpCom.IdTipoComprobante)
         Next
         stb.AppendFormat("'{0}')", tiposComprobantes(0).IdTipoComprobante)
      End If
   End Sub

   Public Shared Sub GetListaImpresorasMultiples(stb As StringBuilder, idImpresoras As String(), aliasTabla As String, nombreColumna As String)
      If idImpresoras.Length > 0 Then
         stb.AppendFormat("   AND {0}.{1} IN (", aliasTabla, nombreColumna)
         For Each impresora As String In idImpresoras
            stb.AppendFormat("'{0}',", impresora)
         Next
         stb.AppendFormat("'{0}')", idImpresoras(0))
      End If
   End Sub

   Protected Sub NivelAutorizacionClienteTipoComprobante(stb As StringBuilder, aliasCliente As String, aliasCategoria As String, aliasTipoComprobante As String, nivelAutorizacion As Short)
      NivelAutorizacionCliente(stb, aliasCliente, aliasCategoria, nivelAutorizacion)
      NivelAutorizacionTipoComprobante(stb, aliasTipoComprobante, nivelAutorizacion)
   End Sub
   Protected Sub NivelAutorizacionProveedorTipoComprobante(stb As StringBuilder, aliasProveedor As String, aliasTipoComprobante As String, nivelAutorizacion As Short)
      NivelAutorizacionProveedor(stb, aliasProveedor, nivelAutorizacion)
      NivelAutorizacionTipoComprobante(stb, aliasTipoComprobante, nivelAutorizacion)
   End Sub

   Protected Sub NivelAutorizacionCliente(stb As StringBuilder, aliasCliente As String, aliasCategoria As String, nivelAutorizacion As Short)
      stb.AppendFormatLine("    AND CASE WHEN {0}.NivelAutorizacion > 0 THEN {0}.NivelAutorizacion ELSE {1}.NivelAutorizacion END <= {2}",
                           aliasCliente, aliasCategoria, nivelAutorizacion)
   End Sub
   Protected Sub NivelAutorizacionTipoComprobante(stb As StringBuilder, aliasTipoComprobante As String, nivelAutorizacion As Short)
      stb.AppendFormatLine("    AND {0}.NivelAutorizacion <= {1}", aliasTipoComprobante, nivelAutorizacion)
   End Sub
   Protected Sub NivelAutorizacionProveedor(stb As StringBuilder, aliasProveedor As String, nivelAutorizacion As Short)
      stb.AppendFormatLine("    AND {0}.NivelAutorizacion <= {1}", aliasProveedor, nivelAutorizacion)
   End Sub

   'Public Function GetInsertSelectQuery(nombreTabla As String, valoresReemplazar As Dictionary(Of String, String), valoresPK As Dictionary(Of String, String)) As String
   Private Function GetInsertSelectQuery(nombreTabla As String, valoresReemplazar As Dictionary(Of String, String), whereClause As String) As String
      Dim dtColumnas As DataTable = GetDataTable(String.Format("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='{0}'", nombreTabla))

      Dim camposInsert As StringBuilder = New StringBuilder()
      Dim camposSelect As StringBuilder = New StringBuilder()

      Dim primero As Boolean = True

      For Each drColumna As DataRow In dtColumnas.Rows
         Dim nombreColumna As String = drColumna("COLUMN_NAME").ToString()

         camposInsert.AppendFormat(If(primero, " {0}", ",{0}"), nombreColumna)

         If valoresReemplazar.ContainsKey(nombreColumna) Then
            camposSelect.AppendFormat(If(primero, " '{0}'", ",'{0}'"), valoresReemplazar(nombreColumna))
         Else
            camposSelect.AppendFormat(If(primero, " {0}", ",{0}"), nombreColumna)
         End If

         primero = False
      Next

      Dim qry As StringBuilder = New StringBuilder()
      qry.AppendFormatLine("INSERT INTO {0} ({1}) SELECT {2} FROM {0} {3}", nombreTabla, camposInsert.ToString(), camposSelect.ToString(), whereClause)

      'primero = True
      'For Each drPK As KeyValuePair(Of String, String) In valoresPK
      '   qry.AppendFormat(If(primero, "WHERE", "AND"))
      '   qry.AppendFormat(" {0} = '{1}'", drPK.Key, drPK.Value)
      '   primero = False
      'Next

      Return qry.ToString()
   End Function
   Public Function InsertSelect(nombreTabla As String, valoresReemplazar As Dictionary(Of String, String), whereClause As String) As Integer
      Return Execute(GetInsertSelectQuery(nombreTabla, valoresReemplazar, whereClause))
   End Function


   Private Function GetUpdatePrimaryKeyQuery(nombreTabla As String, valoresReemplazar As Dictionary(Of String, String), whereClause As String) As String
      Dim camposUpdate As StringBuilder = New StringBuilder()

      Dim primero As Boolean = True

      For Each valores As KeyValuePair(Of String, String) In valoresReemplazar
         camposUpdate.AppendFormat(If(primero, "   SET", "     ,"))
         camposUpdate.AppendFormatLine(" {0} = '{1}'", valores.Key, valores.Value)

         primero = False
      Next

      Dim qry As StringBuilder = New StringBuilder()
      qry.AppendFormatLine("UPDATE {0} {1} {2}", nombreTabla, camposUpdate.ToString(), whereClause)

      Return qry.ToString()
   End Function
   Public Function UpdatePrimaryKey(nombreTabla As String, valoresReemplazar As Dictionary(Of String, String), whereClause As String) As Integer
      Return Execute(GetUpdatePrimaryKeyQuery(nombreTabla, valoresReemplazar, whereClause))
   End Function

   Public Function DeleteGenerico(nombreTabla As String, valoresReemplazar As Dictionary(Of String, String), whereClause As String) As Integer
      Return Execute(String.Format("DELETE {0} {1}", nombreTabla, whereClause))
   End Function

   Public Function ObtenerOperadorRelacional(valor As Entidades.Publicos.OperadoresRelacionales) As String
      Select Case valor
         Case Entidades.Publicos.OperadoresRelacionales.MAYOR
            Return ">"
         Case Entidades.Publicos.OperadoresRelacionales.MENOR
            Return "<"
         Case Entidades.Publicos.OperadoresRelacionales.MAYORIGUAL
            Return ">="
         Case Entidades.Publicos.OperadoresRelacionales.MENORIGUAL
            Return "<="
         Case Entidades.Publicos.OperadoresRelacionales.DISTINTO
            Return "<>"
         Case Entidades.Publicos.OperadoresRelacionales.IGUAL
            Return "="
      End Select
      Return Nothing
   End Function

   Protected Function ArmarOrderBy(stb As StringBuilder, camposOrderBy As String()) As StringBuilder
      Dim primero As Boolean = True
      For Each campo As String In camposOrderBy
         If primero Then
            stb.AppendFormat(" ORDER BY {0}", campo)
            primero = False
         Else
            stb.AppendFormat(", {0}", campo)
         End If
      Next

      If Not primero Then
         stb.AppendLine()
      End If

      Return stb
   End Function

   Protected Function ValidarRango(desde As Integer,
                                   hasta As Integer,
                                   nombreTabla As String,
                                   nombreCampoDesde As String,
                                   nombreCampoHasta As String) As DataTable
      Return ValidarRango(desde, hasta, nombreTabla, nombreCampoDesde, nombreCampoHasta, condicion:=Nothing)
   End Function

   Protected Function ValidarRango(desde As Integer,
                                   hasta As Integer,
                                   nombreTabla As String,
                                   nombreCampoDesde As String,
                                   nombreCampoHasta As String,
                                   condicion As String) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT * FROM {0} ", nombreTabla)
         .AppendFormatLine("	WHERE (({0} >= {2} AND {0} <= {3}) OR ({1} >= {2} AND {1} <= {3}) OR ({0} <= {2} AND {1} >= {3}))", desde, hasta, nombreCampoDesde, nombreCampoHasta)

         If Not String.IsNullOrEmpty(condicion) Then .AppendFormatLine("	AND {0}", condicion)

      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function GetIdByNumeroDeCheque(idSucursal As Integer,
                                         numeroCheque As Long,
                                         idBanco As Integer,
                                         idBancoSucursal As Integer,
                                         idLocalidad As Integer) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT C.IdCheque FROM Cheques C")
         .AppendFormatLine("	WHERE C.IdSucursal = {0} AND C.NumeroCheque = {1} AND C.IdBanco = {2} AND C.IdBancoSucursal = {3} AND C.IdLocalidad = {4}",
                                    idSucursal, numeroCheque, idBanco, idBancoSucursal, idLocalidad)
      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   Protected Overridable Function Buscar(columna As String, valor As String, selectTexto As Action(Of StringBuilder),
                                         prefijoTabla As String) As DataTable
      Return Buscar(columna, valor, selectTexto, prefijoTabla, mapColumnas:=Nothing, mapearColumnaCustom:=Nothing, agregarCondicionAdicional:=Nothing)
   End Function
   Protected Overridable Function Buscar(columna As String, valor As String, selectTexto As Action(Of StringBuilder),
                                         prefijoTabla As String, mapColumnas As Dictionary(Of String, String)) As DataTable
      Return Buscar(columna, valor, selectTexto, prefijoTabla, mapColumnas, mapearColumnaCustom:=Nothing, agregarCondicionAdicional:=Nothing)
   End Function

   Protected Overridable Function Buscar(columna As String, valor As String, selectTexto As Action(Of StringBuilder),
                                         prefijoTabla As String, mapColumnas As Dictionary(Of String, String),
                                         mapearColumnaCustom As Func(Of String, String)) As DataTable
      Return Buscar(columna, valor, selectTexto, prefijoTabla, mapColumnas, mapearColumnaCustom, agregarCondicionAdicional:=Nothing)
   End Function

   Protected Overridable Sub OrdenPredeterminado(stb As StringBuilder)

   End Sub

   Protected Overridable Function Buscar(columna As String, valor As String, selectTexto As Action(Of StringBuilder),
                                         prefijoTabla As String, mapColumnas As Dictionary(Of String, String),
                                         mapearColumnaCustom As Func(Of String, String),
                                         agregarCondicionAdicional As Action(Of StringBuilder)) As DataTable

      If mapearColumnaCustom Is Nothing Then
         mapearColumnaCustom = Function(col) col
      End If

      Dim columnaMapeada = mapearColumnaCustom(columna)
      If columna.Equals(columnaMapeada) Then
         If mapColumnas IsNot Nothing AndAlso mapColumnas.ContainsKey(columna) Then
            columnaMapeada = mapColumnas(columna)
         Else
            columnaMapeada = String.Concat(prefijoTabla, columna)
         End If
      End If

      Dim stb = New StringBuilder()
      With stb
         selectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columnaMapeada, valor)
         If agregarCondicionAdicional IsNot Nothing Then
            agregarCondicionAdicional(stb)
         End If
      End With

      OrdenPredeterminado(stb)

      Return GetDataTable(stb)

      Return Nothing
   End Function
End Class