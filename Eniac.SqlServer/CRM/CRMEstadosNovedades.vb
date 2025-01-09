Public Class CRMEstadosNovedades
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CRMEstadosNovedades_I(idEstadoNovedad As Integer,
                                    nombreEstadoNovedad As String,
                                    posicion As Integer,
                                    solicitaUsuario As Boolean,
                                    finalizado As Boolean,
                                    idTipoNovedad As String,
                                    porDefecto As Boolean,
                                    color As Integer?,
                                    diasProximoContacto As Integer?,
                                    actualizaUsuarioResponsable As Boolean,
                                    solicitaProveedorService As Boolean,
                                    imprime As Boolean,
                                    reporte As String,
                                    embebido As Boolean,
                                    acumulaContador1 As Boolean,
                                    acumulaContador2 As Boolean,
                                    esFacturable As Boolean,
                                    cantidadCopias As Integer,
                                    idTipoEstadoNovedad As Integer,
                                    entregado As Entidades.CRMEstadoNovedad.EntregadoValores,
                                    idEstadoFacturado As Integer?,
                                    avanceEstadoFacturado As Decimal?,
                                    controlaStockConsumido As Boolean,
                                    requiereComentarios As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO CRMEstadosNovedades ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23})",
                           Entidades.CRMEstadoNovedad.Columnas.IdEstadoNovedad.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.Posicion.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.SolicitaUsuario.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.Finalizado.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.IdTipoNovedad.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.PorDefecto.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.Color.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.DiasProximoContacto.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.ActualizaUsuarioResponsable.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.SolicitaProveedorService.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.Imprime.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.Reporte.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.Embebido.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.AcumulaContador1.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.AcumulaContador2.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.EsFacturable.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.CantidadCopias.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.IdTipoEstadoNovedad.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.Entregado.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.IdEstadoFacturado.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.AvanceEstadoFacturado.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.ControlaStockConsumido.ToString(),
                           Entidades.CRMEstadoNovedad.Columnas.RequiereComentarios.ToString())

         .AppendFormatLine("     VALUES ({0}, '{1}', {2}, {3}, {4}, '{5}', {6}, {7}, {8}, {9}, {10}, {11}, '{12}', {13}, {14}, {15}, {16}, {17}, {18}, '{19}'",
                           idEstadoNovedad, nombreEstadoNovedad, posicion,
                           GetStringFromBoolean(solicitaUsuario), GetStringFromBoolean(finalizado),
                           idTipoNovedad, GetStringFromBoolean(porDefecto),
                           GetStringFromNumber(color), GetStringFromNumber(diasProximoContacto),
                           GetStringFromBoolean(actualizaUsuarioResponsable), GetStringFromBoolean(solicitaProveedorService),
                           GetStringFromBoolean(imprime), reporte, GetStringFromBoolean(embebido),
                           GetStringFromBoolean(acumulaContador1), GetStringFromBoolean(acumulaContador2),
                           GetStringFromBoolean(esFacturable),
                           cantidadCopias, idTipoEstadoNovedad,
                           entregado.ToString())

         If idEstadoFacturado.HasValue AndAlso idEstadoFacturado.Value > 0 Then
            .AppendFormatLine("  ,{0}", idEstadoFacturado.Value)
         Else
            .AppendFormatLine("  ,NULL")
         End If
         If avanceEstadoFacturado.HasValue Then
            .AppendFormatLine("  ,{0}", avanceEstadoFacturado.Value)
         Else
            .AppendFormatLine("  ,NULL")
         End If
         .AppendFormatLine("  ,{0}", GetStringFromBoolean(controlaStockConsumido))
         .AppendFormatLine("  ,{0}", GetStringFromBoolean(requiereComentarios))

         .AppendLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub CRMEstadosNovedades_U(idEstadoNovedad As Integer,
                                    nombreEstadoNovedad As String,
                                    posicion As Integer,
                                    solicitaUsuario As Boolean,
                                    finalizado As Boolean,
                                    idTipoNovedad As String,
                                    porDefecto As Boolean,
                                    color As Integer?,
                                    diasProximoContacto As Integer?,
                                    actualizaUsuarioResponsable As Boolean,
                                    solicitaProveedorService As Boolean,
                                    imprime As Boolean,
                                    reporte As String,
                                    embebido As Boolean,
                                    acumulaContador1 As Boolean,
                                    acumulaContador2 As Boolean,
                                    esFacturable As Boolean,
                                    cantidadCopias As Integer,
                                    idTipoEstadoNovedad As Integer,
                                    entregado As Entidades.CRMEstadoNovedad.EntregadoValores,
                                    idEstadoFacturado As Integer?,
                                    avanceEstadoFacturado As Decimal?,
                                    controlaStockConsumido As Boolean,
                                    requiereComentarios As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE CRMEstadosNovedades ")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString(), nombreEstadoNovedad)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMEstadoNovedad.Columnas.Posicion.ToString(), posicion)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMEstadoNovedad.Columnas.SolicitaUsuario.ToString(), GetStringFromBoolean(solicitaUsuario))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMEstadoNovedad.Columnas.Finalizado.ToString(), GetStringFromBoolean(finalizado))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMEstadoNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMEstadoNovedad.Columnas.PorDefecto.ToString(), GetStringFromBoolean(porDefecto))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMEstadoNovedad.Columnas.Color.ToString(), GetStringFromNumber(color))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMEstadoNovedad.Columnas.DiasProximoContacto.ToString(), GetStringFromNumber(diasProximoContacto))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMEstadoNovedad.Columnas.ActualizaUsuarioResponsable.ToString(), GetStringFromBoolean(actualizaUsuarioResponsable))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMEstadoNovedad.Columnas.SolicitaProveedorService.ToString(), GetStringFromBoolean(solicitaProveedorService))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMEstadoNovedad.Columnas.Imprime.ToString(), GetStringFromBoolean(imprime))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMEstadoNovedad.Columnas.Reporte.ToString(), reporte)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMEstadoNovedad.Columnas.Embebido.ToString(), GetStringFromBoolean(embebido))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMEstadoNovedad.Columnas.AcumulaContador1.ToString(), GetStringFromBoolean(acumulaContador1))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMEstadoNovedad.Columnas.AcumulaContador2.ToString(), GetStringFromBoolean(acumulaContador2))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMEstadoNovedad.Columnas.EsFacturable.ToString(), GetStringFromBoolean(esFacturable))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMEstadoNovedad.Columnas.CantidadCopias.ToString(), cantidadCopias)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMEstadoNovedad.Columnas.IdTipoEstadoNovedad.ToString(), idTipoEstadoNovedad)
         .AppendFormatLine("     , {0} =  '{1}' ", Entidades.CRMEstadoNovedad.Columnas.Entregado.ToString(), entregado.ToString())

         If idEstadoFacturado.HasValue AndAlso idEstadoFacturado.Value > 0 Then
            .AppendFormatLine("     , {0} = {1} ", Entidades.CRMEstadoNovedad.Columnas.IdEstadoFacturado.ToString(), idEstadoFacturado.Value)
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMEstadoNovedad.Columnas.IdEstadoFacturado.ToString())
         End If
         If avanceEstadoFacturado.HasValue Then
            .AppendFormatLine("     , {0} = {1} ", Entidades.CRMEstadoNovedad.Columnas.AvanceEstadoFacturado.ToString(), avanceEstadoFacturado.Value)
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMEstadoNovedad.Columnas.AvanceEstadoFacturado.ToString())
         End If
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMEstadoNovedad.Columnas.ControlaStockConsumido.ToString(), GetStringFromBoolean(controlaStockConsumido))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMEstadoNovedad.Columnas.RequiereComentarios.ToString(), GetStringFromBoolean(requiereComentarios))

         .AppendFormat(" WHERE {0} =  {1} ", Entidades.CRMEstadoNovedad.Columnas.IdEstadoNovedad.ToString(), idEstadoNovedad)

      End With
      Execute(myQuery)
   End Sub

   Public Sub CRMEstadosNovedades_D(idEstadoNovedad As Integer)
      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM CRMEstadosNovedades WHERE {0} = '{1}'", Entidades.CRMEstadoNovedad.Columnas.IdEstadoNovedad.ToString(), idEstadoNovedad)
      End With

      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT EN.*, TN.NombreTipoNovedad")
         .AppendFormatLine("     , {0}", ConvertirBitSiNo("EN", "SolicitaUsuario"))
         .AppendFormatLine("     , {0}", ConvertirBitSiNo("EN", "Finalizado"))
         .AppendFormatLine("     , {0}", ConvertirBitSiNo("EN", "PorDefecto"))
         .AppendFormatLine("     , {0}", ConvertirBitSiNo("EN", "ActualizaUsuarioResponsable"))
         .AppendFormatLine("     , {0}", ConvertirBitSiNo("EN", "SolicitaProveedorService"))
         .AppendFormatLine("     , {0}", ConvertirBitSiNo("EN", "Imprime"))
         .AppendFormatLine("     , {0}", ConvertirBitSiNo("EN", "Embebido"))
         .AppendFormatLine("     , {0}", ConvertirBitSiNo("EN", "AcumulaContador1"))
         .AppendFormatLine("     , {0}", ConvertirBitSiNo("EN", "AcumulaContador2"))
         .AppendFormatLine("     , {0}", ConvertirBitSiNo("EN", "EsFacturable"))
         .AppendFormatLine("     , {0}", ConvertirBitSiNo("EN", "RequiereComentarios"))
         .AppendFormatLine("     , CEN.NombreEstadoNovedad EstadoFacturado")
         .AppendFormatLine("     , TEN.{0}", "NombreTipoEstadoNovedad")

         .AppendFormatLine("  FROM CRMEstadosNovedades AS EN")
         .AppendFormatLine("  LEFT JOIN CRMEstadosNovedades CEN ON EN.IdEstadoFacturado = CEN.IdEstadoNovedad")
         .AppendFormatLine("  INNER JOIN CRMTiposNovedades TN ON TN.IdTipoNovedad = EN.IdTipoNovedad")
         .AppendFormatLine("  INNER JOIN CRMTiposEstadosNovedades TEN ON EN.IdTipoEstadoNovedad = TEN.IdTipoEstadoNovedad")
      End With
   End Sub

   Public Function CRMEstadosNovedades_GA() As DataTable
      Return CRMEstadosNovedades_GA(String.Empty, False)
   End Function
   Public Function CRMEstadosNovedades_GA(idTipoNovedad As String, ordenarPosicion As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormat(" WHERE EN.IdTipoNovedad = '{0}'", idTipoNovedad).AppendLine()
         End If
         If ordenarPosicion Then
            .AppendFormat(" ORDER BY TN.NombreTipoNovedad, EN.Posicion")
         Else
            .AppendFormat(" ORDER BY TN.NombreTipoNovedad, EN.NombreEstadoNovedad")
         End If
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function CRMEstadosNovedades_G1(IdEstadoNovedad As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE EN.{0} = {1}", Entidades.CRMEstadoNovedad.Columnas.IdEstadoNovedad.ToString(), IdEstadoNovedad)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb1) SelectTexto(stb1), "EN.",
                    New Dictionary(Of String, String) From
                     {{"NombreTipoNovedad", "TN.NombreTipoNovedad"},
                      {"SolicitaUsuario_SN", "CASE WHEN EN.SolicitaUsuario = 0 THEN 'NO' ELSE 'SI' END"},
                      {"Finalizado_SN", "CASE WHEN EN.Finalizado = 0 THEN 'NO' ELSE 'SI' END"},
                      {"PorDefecto_SN", "CASE WHEN EN.PorDefecto = 0 THEN 'NO' ELSE 'SI' END"},
                      {"ActualizaUsuarioResponsable_SN", "CASE WHEN EN.ActualizaUsuarioResponsable = 0 THEN 'NO' ELSE 'SI' END"},
                      {"Imprime_SN", "CASE WHEN EN.Imprime = 0 THEN 'NO' ELSE 'SI' END"},
                      {"Embebido_SN", "CASE WHEN EN.Embebido = 0 THEN 'NO' ELSE 'SI' END"},
                      {"AcumulaContador1_SN", "CASE WHEN EN.AcumulaContador1 = 0 THEN 'NO' ELSE 'SI' END"},
                      {"AcumulaContador2_SN", "CASE WHEN EN.AcumulaContador2 = 0 THEN 'NO' ELSE 'SI' END"},
                      {"NombreTipoEstadoNovedad", "TEN.NombreTipoEstadoNovedad"}})
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.CRMEstadoNovedad.Columnas.IdEstadoNovedad.ToString(), "CRMEstadosNovedades"))
   End Function
   Public Function CRMEstadosNovedades_GxCodigo(IdEstadoNovedad As Integer, idTipoNovedad As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE 1=1 ")
         If Not String.IsNullOrEmpty(idTipoNovedad) Then
            .AppendFormat(" and EN.IdTipoNovedad = '{0}'", idTipoNovedad)
         End If
         If IdEstadoNovedad <> 0 Then
            .AppendFormat(" and EN.{0} = {1}", Entidades.CRMEstadoNovedad.Columnas.IdEstadoNovedad.ToString(), IdEstadoNovedad)
         End If
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function CRMEstadosNovedades_PorNombre(nombreEstado As String, nombreExacto As Boolean, idTipoNovedad As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE 1=1 ")
         If Not String.IsNullOrEmpty(idTipoNovedad) Then
            .AppendFormat(" and EN.IdTipoNovedad = '{0}'", idTipoNovedad)
         End If
         If nombreExacto Then
            .AppendFormatLine(" and EN.NombreEstadoNovedad = '{0}'", nombreEstado)
         Else
            .AppendFormatLine(" and EN.NombreEstadoNovedad LIKE '%{0}%'", nombreEstado)
         End If
      End With
      Return GetDataTable(stb)
   End Function
End Class