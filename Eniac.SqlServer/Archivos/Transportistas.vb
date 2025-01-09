Public Class Transportistas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Transportistas_I(ByVal idTransportista As Int32, _
                               ByVal nombreTransportista As String, _
                               ByVal direccionTransportista As String, _
                               ByVal idLocalidad As Integer, _
                               ByVal cuit As String, _
                               ByVal telefono As String, _
                               ByVal idCategoriaFiscal As Int16, _
                               ByVal observacion As String,
                               ByVal kilosMaximo As Decimal,
                               ByVal paletsMaximo As Integer,
                               ByVal activo As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO  ")
         .AppendLine("Transportistas  ")
         .AppendLine("(idTransportista, ")
         .AppendLine(" Nombretransportista, ")
         .AppendLine(" DireccionTransportista, ")
         .AppendLine(" IdLocalidadTransportista, ")
         .AppendLine(" CuitTransportista, ")
         .AppendLine(" TelefonoTransportista, ")
         .AppendLine(" IdCategoriaFiscalTransportista, ")
         .AppendLine(" Observacion, ")
         .AppendLine(" kilosMaximo, ")
         .AppendLine(" paletsMaximo, ")
         .AppendLine(" Activo ")
         .AppendLine(") VALUES (")
         .AppendLine(idTransportista.ToString() & ", ")
         .AppendLine("'" & nombreTransportista & "', ")
         .AppendLine("'" & direccionTransportista & "', ")
         .AppendLine(idLocalidad.ToString() & ", ")
         .AppendLine("'" & cuit & "', ")
         .AppendLine("'" & telefono & "', ")
         .AppendLine(idCategoriaFiscal.ToString() & ", ")
         .AppendLine("'" & observacion & "', ")
         .AppendLine(kilosMaximo.ToString() & ", ")
         .AppendLine(paletsMaximo.ToString() & ", ")

         .AppendLine(Me.GetStringFromBoolean(activo) & ") ")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Transportistas")
   End Sub

   Public Sub Transportistas_U(ByVal idTransportista As Int32, _
                               ByVal nombre As String, _
                               ByVal direccion As String, _
                               ByVal idLocalidad As Integer, _
                               ByVal cuit As String, _
                               ByVal telefono As String, _
                               ByVal idCategoriaFiscal As Int16, _
                               ByVal observacion As String,
                               ByVal kilosMaximo As Decimal,
                               ByVal paletsMaximo As Integer,
                               ByVal activo As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Length = 0
         .AppendLine("UPDATE Transportistas SET ")

         .AppendLine("nombreTransportista = '" & nombre & "', ")
         .AppendLine("direccionTransportista = '" & direccion & "', ")
         .AppendLine("idLocalidadTransportista = " & idLocalidad.ToString() & ", ")
         .AppendLine("cuitTransportista = '" & cuit & "', ")
         .AppendLine("telefonoTransportista = '" & telefono & "', ")
         .AppendLine("idCategoriaFiscalTransportista = " & idCategoriaFiscal.ToString() & ", ")
         .AppendLine("observacion = '" & observacion & "', ")
         .AppendLine("kilosMaximo = " & kilosMaximo.ToString() & ", ")
         .AppendLine("PaletsMaximo = " & paletsMaximo.ToString() & ", ")
         .AppendLine("Activo = " & Me.GetStringFromBoolean(activo))
         .AppendLine("WHERE idTransportista = " & idTransportista.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Transportistas")
   End Sub

   Public Sub Transportistas_D(ByVal idtransportista As Int32)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM transportistas ")
         .AppendLine("WHERE idTransportista = " & idtransportista.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Transportistas")
   End Sub
   Public Function GetExisteTransportitasEnCliente(ByVal idTransportista As Int32) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("SELECT COUNT(*)")
         .AppendLine(" FROM Clientes ")
         .AppendLine(" WHERE  (IdTransportista = " & idTransportista & ")")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function
   Public Function GetExisteTransportitasEnRutas(ByVal idTransportista As Int32) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("SELECT COUNT(*)")
         .AppendLine(" FROM MovilRutas ")
         .AppendLine(" WHERE  (IdTransportista = " & idTransportista & ")")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function
   Private Sub SelectTexto(stb As StringBuilder)

      With stb
         .AppendLine("SELECT T.idTransportista")
         .AppendLine("      ,T.NombreTransportista")
         .AppendLine("      ,T.DireccionTransportista")
         .AppendLine("      ,T.idLocalidadTransportista")
         .AppendLine("      ,L.NombreLocalidad")
         .AppendLine("      ,T.cuitTransportista")
         .AppendLine("      ,T.telefonoTransportista")
         .AppendLine("      ,T.Observacion")
         .AppendLine("      ,T.IdCategoriaFiscalTransportista")
         .AppendLine("      ,CFC.LetraFiscal")
         .AppendLine("      ,CF.NombreCategoriaFiscal")
         .AppendLine("      ,T.KilosMaximo")
         .AppendLine("      ,T.PaletsMaximo")
         .AppendLine("      ,T.Activo")
         .AppendLine("  FROM Transportistas T ")
         .AppendLine(" LEFT JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = T.IdCategoriaFiscaltransportista ")
         .AppendLine(" LEFT JOIN Localidades L ON T.idLocalidadTransportista = L.IdLocalidad")

         .AppendFormatLine(" CROSS JOIN (SELECT * FROM Parametros WHERE IdParametro = 'CATEGORIAFISCALEMPRESA' AND IdEmpresa = {0}) PAR", actual.Sucursal.IdEmpresa)
         .AppendFormatLine("  LEFT JOIN CategoriasFiscalesConfiguraciones CFC ON CFC.IdCategoriaFiscalCliente = CF.IdCategoriaFiscal AND CFC.IdCategoriaFiscalEmpresa = ISNULL(PAR.ValorParametro, 0)")

      End With

   End Sub

   Private Function Transportista_G(idTransportista As Long, nombreTransportista As String, direccionTransportista As String, activo As Boolean?, idTransportistaExacto As Boolean) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE 1 = 1")
         If idTransportista > 0 Then
            If idTransportistaExacto Then
               .AppendFormatLine("   AND T.{0} = {1}", Entidades.Transportista.Columnas.IdTransportista.ToString(), idTransportista)
            Else
               .AppendFormatLine("   AND T.{0} LIKE '%{1}%'", Entidades.Transportista.Columnas.IdTransportista.ToString(), idTransportista)
            End If
         End If

         If Not String.IsNullOrWhiteSpace(NombreTransportista) Then
            .AppendLine(" AND T.NombreTransportista LIKE '%" & NombreTransportista & "%' ")
         End If
         If Not String.IsNullOrWhiteSpace(DireccionTransportista) Then
            .AppendLine(" AND T.DireccionTransportista LIKE '%" & DireccionTransportista & "%' ")
         End If
         If activo.HasValue Then
            .AppendFormatLine("   AND T.{0} = {1}", Entidades.Transportista.Columnas.Activo.ToString(), Me.GetStringFromBoolean(activo))
         End If
         .AppendFormatLine("  ORDER BY T.{0}", Entidades.Transportista.Columnas.NombreTransportista.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(columna As String, valor As String) As DataTable
      If columna = "NombreLocalidad" Then
         columna = "L.NombreLocalidad"
      ElseIf columna = "LetraFiscal" Then
         columna = "CFC.LetraFiscal"
      ElseIf columna = "NombreCategoriaFiscal" Then
         columna = "CF.NombreCategoriaFiscal"
      Else
         columna = "T." + columna
      End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function Transportista_GA() As DataTable
      Return Transportista_G(idTransportista:=0, NombreTransportista:=String.Empty, DireccionTransportista:=String.Empty, activo:=Nothing, idTransportistaExacto:=False)
   End Function
   Public Function Transportista_GA(ByVal soloActivos As Boolean?) As DataTable
      Return Transportista_G(idTransportista:=0, NombreTransportista:=String.Empty, DireccionTransportista:=String.Empty, activo:=soloActivos, idTransportistaExacto:=False)
   End Function
   Public Function Transportista_G1(idTransportista As Long, idTransportistaExacto As Boolean) As DataTable
      Return Transportista_G(idTransportista, NombreTransportista:=String.Empty, DireccionTransportista:=String.Empty, activo:=Nothing, idTransportistaExacto:=idTransportistaExacto)
   End Function

   Public Function GetFiltradoPorNombre(ByVal NombreTransportista As String) As DataTable
      Return Transportista_G(idTransportista:=0, NombreTransportista:=NombreTransportista, DireccionTransportista:=String.Empty, activo:=Nothing, idTransportistaExacto:=False)
   End Function
   Public Function GetFiltradoPorNombre(ByVal NombreTransportista As String, ByVal activo As Boolean?) As DataTable
      Return Transportista_G(idTransportista:=0, NombreTransportista:=NombreTransportista, DireccionTransportista:=String.Empty, activo:=activo, idTransportistaExacto:=False)
   End Function
   Public Function GetFiltradoPorDireccion(ByVal DireccionTransportista As String) As DataTable
      Return Transportista_G(idTransportista:=0, NombreTransportista:=String.Empty, DireccionTransportista:=DireccionTransportista, activo:=Nothing, idTransportistaExacto:=False)
   End Function
   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.Transportista.Columnas.IdTransportista.ToString(), Entidades.Transportista.NombreTabla))
   End Function
   Public Overloads Function GetCodigoMinimo() As Integer
      Return Convert.ToInt32(GetCodigoMinimo(Entidades.Transportista.Columnas.IdTransportista.ToString(), Entidades.Transportista.NombreTabla))
   End Function


End Class