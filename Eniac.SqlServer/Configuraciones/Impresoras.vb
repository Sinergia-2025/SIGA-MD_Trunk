Public Class Impresoras
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Impresoras_I(idSucursal As Integer,
                           idImpresora As String,
                           tipoImpresora As String,
                           centroEmisor As Integer,
                           comprobantesHabilitados As String,
                           puerto As String,
                           velocidad As Integer,
                           maximoCaracteresItem As Integer,
                           esProtocoloExtendido As Boolean,
                           modelo As String,
                           origenPapel As String,
                           cantidadCopias As Short,
                           tipoFormulario As String,
                           tamanioLetra As Short,
                           marca As String,
                           metodo As Entidades.Impresora.MetodosFiscal?,
                           abrirCajonDinero As Boolean,
                           grabarLOGs As Boolean,
                           imprimirLineaALinea As Boolean,
                           cierreFiscalEstandar As Boolean,
                           porCtaOrden As Boolean,
                           direccionCentroEmisor As String,
                           idLocalidadCentroEmisor As Integer,
                           fiscalUltimaFechaExtraidaAuditoria As Date?,
                           fiscalUltimoZetaExtraidoAuditoria As Integer?,
                           fiscalUltimaFechaExtraidaInforme As Date?,
                           utilizaBonosFiscalesElectronicos As Boolean)

      Dim stb = New StringBuilder()

      With stb
         .AppendFormatLine("INSERT INTO Impresoras (")
         .AppendFormatLine("        IdSucursal")
         .AppendFormatLine("      , IdImpresora")
         .AppendFormatLine("      , TipoImpresora")
         .AppendFormatLine("      , CentroEmisor")
         .AppendFormatLine("      , ComprobantesHabilitados")
         .AppendFormatLine("      , Puerto")
         .AppendFormatLine("      , Velocidad")
         .AppendFormatLine("      , MaximoCaracteresItem")
         .AppendFormatLine("      , EsProtocoloExtendido")
         .AppendFormatLine("      , Modelo")
         .AppendFormatLine("      , OrigenPapel")
         .AppendFormatLine("      , CantidadCopias")
         .AppendFormatLine("      , TipoFormulario")
         .AppendFormatLine("      , TamanioLetra")
         .AppendFormatLine("      , Marca")
         .AppendFormatLine("      , Metodo")
         .AppendFormatLine("      , AbrirCajonDinero")
         .AppendFormatLine("      , GrabarLOGs")
         .AppendFormatLine("      , ImprimirLineaALinea")
         .AppendFormatLine("      , CierreFiscalEstandar")
         .AppendFormatLine("      , PorCtaOrden")
         .AppendFormatLine("      , DireccionCentroEmisor")
         .AppendFormatLine("      , IdLocalidadCentroEmisor")
         .AppendFormatLine("      , FiscalUltimaFechaExtraidaAuditoria")
         .AppendFormatLine("      , FiscalUltimoZetaExtraidoAuditoria")
         .AppendFormatLine("      , FiscalUltimaFechaExtraidaInforme")
         .AppendFormatLine("      , UtilizaBonosFiscalesElectronicos")
         .AppendFormatLine(" ) VALUES (")

         .AppendFormatLine("         {0} ", idSucursal)
         .AppendFormatLine("      , '{0}'", idImpresora)
         .AppendFormatLine("      , '{0}'", tipoImpresora)
         .AppendFormatLine("      ,  {0} ", centroEmisor)
         .AppendFormatLine("      ,  {0} ", GetStringParaQueryConComillas(comprobantesHabilitados))
         .AppendFormatLine("      ,  {0} ", GetStringParaQueryConComillas(puerto))
         .AppendFormatLine("      ,  {0} ", velocidad)
         .AppendFormatLine("      ,  {0} ", maximoCaracteresItem)
         .AppendFormatLine("      ,  {0} ", GetStringFromBoolean(esProtocoloExtendido))
         .AppendFormatLine("      ,  {0} ", GetStringParaQueryConComillas(modelo))
         .AppendFormatLine("      ,  {0} ", GetStringParaQueryConComillas(origenPapel))
         .AppendFormatLine("      ,  {0} ", cantidadCopias)
         .AppendFormatLine("      ,  {0} ", GetStringParaQueryConComillas(tipoFormulario))
         .AppendFormatLine("      ,  {0} ", tamanioLetra)
         .AppendFormatLine("      ,  {0} ", GetStringParaQueryConComillas(marca))
         If metodo.HasValue Then
            .AppendFormatLine("      , '{0}'", metodo.Value.ToString())
         Else
            .AppendFormatLine("      , NULL")
         End If
         .AppendFormatLine("      ,  {0} ", GetStringFromBoolean(abrirCajonDinero))
         .AppendFormatLine("      ,  {0} ", GetStringFromBoolean(grabarLOGs))
         .AppendFormatLine("      ,  {0} ", GetStringFromBoolean(imprimirLineaALinea))
         .AppendFormatLine("      ,  {0} ", GetStringFromBoolean(cierreFiscalEstandar))
         .AppendFormatLine("      ,  {0} ", GetStringFromBoolean(porCtaOrden))
         .AppendFormatLine("      , '{0}'", direccionCentroEmisor)

         If idLocalidadCentroEmisor > 0 AndAlso Not String.IsNullOrWhiteSpace(direccionCentroEmisor) Then
            .AppendFormatLine("      ,  {0} ", idLocalidadCentroEmisor)
         Else
            .AppendFormatLine("      , NULL")
         End If

         .AppendFormatLine("      , {0}", ObtenerFecha(fiscalUltimaFechaExtraidaAuditoria, True))
         .AppendFormatLine("      , {0}", GetStringFromNumber(fiscalUltimoZetaExtraidoAuditoria))
         .AppendFormatLine("      , {0}", ObtenerFecha(fiscalUltimaFechaExtraidaInforme, True))
         .AppendFormatLine("      ,  {0} ", GetStringFromBoolean(utilizaBonosFiscalesElectronicos))

         .AppendFormatLine(")")
      End With
      Execute(stb)
   End Sub

   Public Sub Impresoras_U(idSucursal As Integer,
                           idImpresora As String,
                           tipoImpresora As String,
                           centroEmisor As Integer,
                           comprobantesHabilitados As String,
                           puerto As String,
                           velocidad As Integer,
                           maximoCaracteresItem As Integer,
                           esProtocoloExtendido As Boolean,
                           modelo As String,
                           origenPapel As String,
                           cantidadCopias As Short,
                           tipoFormulario As String,
                           tamanioLetra As Short,
                           marca As String,
                           metodo As Entidades.Impresora.MetodosFiscal?,
                           abrirCajonDinero As Boolean,
                           grabarLOGs As Boolean,
                           imprimirLineaALinea As Boolean,
                           cierreFiscalEstandar As Boolean,
                           porCtaOrden As Boolean,
                           direccionCentroEmisor As String,
                           idLocalidadCentroEmisor As Integer,
                           fiscalUltimaFechaExtraidaAuditoria As Date?,
                           fiscalUltimoZetaExtraidoAuditoria As Integer?,
                           fiscalUltimaFechaExtraidaInforme As Date?,
                           utilizaBonosFiscalesElectronicos As Boolean)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE Impresoras")
         .AppendFormatLine("   SET TipoImpresora = '{0}'", tipoImpresora)
         .AppendFormatLine("     , CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("     , ComprobantesHabilitados = {0}", GetStringParaQueryConComillas(comprobantesHabilitados))
         .AppendFormatLine("     , Puerto = {0}", GetStringParaQueryConComillas(puerto))
         .AppendFormatLine("     , Velocidad = {0}", velocidad)
         .AppendFormatLine("     , MaximoCaracteresItem = {0}", maximoCaracteresItem)
         .AppendFormatLine("     , EsProtocoloExtendido = {0}", GetStringFromBoolean(esProtocoloExtendido))
         .AppendFormatLine("     , Modelo = {0}", GetStringParaQueryConComillas(modelo))
         .AppendFormatLine("     , OrigenPapel = {0}", GetStringParaQueryConComillas(origenPapel))
         .AppendFormatLine("     , CantidadCopias = {0}", cantidadCopias)
         .AppendFormatLine("     , TipoFormulario = {0}", GetStringParaQueryConComillas(tipoFormulario))
         .AppendFormatLine("     , TamanioLetra = {0}", tamanioLetra)
         .AppendFormatLine("     , Marca = {0}", GetStringParaQueryConComillas(marca))
         If metodo.HasValue Then
            .AppendFormatLine("     , Metodo = '{0}'", metodo.Value.ToString())
         Else
            .AppendFormatLine("     , Metodo = NULL")
         End If
         .AppendFormatLine("     , AbrirCajonDinero = {0}", GetStringFromBoolean(abrirCajonDinero))
         .AppendFormatLine("     , GrabarLOGs = {0}", GetStringFromBoolean(grabarLOGs))
         .AppendFormatLine("     , ImprimirLineaALinea = {0}", GetStringFromBoolean(imprimirLineaALinea))
         .AppendFormatLine("     , CierreFiscalEstandar = {0}", GetStringFromBoolean(cierreFiscalEstandar))
         .AppendFormatLine("     , PorCtaOrden = {0}", GetStringFromBoolean(porCtaOrden))
         .AppendFormatLine("     , UtilizaBonosFiscalesElectronicos = {0}", GetStringFromBoolean(utilizaBonosFiscalesElectronicos))

         .AppendFormatLine("     , DireccionCentroEmisor = '{0}'", direccionCentroEmisor)
         If idLocalidadCentroEmisor > 0 AndAlso Not String.IsNullOrWhiteSpace(direccionCentroEmisor) Then
            .AppendFormatLine("     , IdLocalidadCentroEmisor = {0}", idLocalidadCentroEmisor)
         Else
            .AppendFormatLine("     , IdLocalidadCentroEmisor = NULL")
         End If

         .AppendFormatLine("     , FiscalUltimaFechaExtraidaAuditoria = {0}", ObtenerFecha(fiscalUltimaFechaExtraidaAuditoria, True))
         .AppendFormatLine("     , FiscalUltimoZetaExtraidoAuditoria = {0}", GetStringFromNumber(fiscalUltimoZetaExtraidoAuditoria))
         .AppendFormatLine("     , FiscalUltimaFechaExtraidaInforme = {0}", ObtenerFecha(fiscalUltimaFechaExtraidaInforme, True))

         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdImpresora = '{0}'", idImpresora)
      End With
      Execute(stb)
   End Sub

   Public Sub Impresoras_D(idSucursal As Integer, idImpresora As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM Impresoras")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         If Not String.IsNullOrWhiteSpace(idImpresora) Then
            .AppendFormatLine("   AND IdImpresora = '{0}'", idImpresora)
         End If
      End With
      Execute(stb)
   End Sub

   Public Sub Impresoras_IPorSucursal(idSucursalOrigen As Integer, idSucursalDestino As Integer, tipoImpresora As String)
      Dim stb = New StringBuilder()
      Dim camposCambio As Dictionary(Of String, String) = New Dictionary(Of String, String)() _
                                                            From {{Entidades.Impresora.Columnas.IdSucursal.ToString(), idSucursalDestino.ToString()}}
      Dim whereClauseCompra As String = String.Format(" WHERE {0} = {1} AND {2} = '{3}'",
                                                      Entidades.Impresora.Columnas.IdSucursal.ToString(), idSucursalOrigen,
                                                      Entidades.Impresora.Columnas.TipoImpresora.ToString(), tipoImpresora)
      InsertSelect("Impresoras", camposCambio, whereClauseCompra)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT I.*")
         .AppendLine("      ,L.NombreLocalidad AS NombreLocalidadCentroEmisor")
         .AppendLine("  FROM Impresoras I")
         .AppendLine("  LEFT JOIN Localidades L ON L.IdLocalidad = I.IdLocalidadCentroEmisor")
      End With
   End Sub

   Public Function Impresoras_GA(idSucursal As Integer) As DataTable
      Dim stb = New StringBuilder()
      SelectTexto(stb)
      With stb
         .AppendFormatLine(" WHERE I.IdSucursal = {0}", idSucursal)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function Impresoras_GA(idSucursal As Integer, idImpresoras As String(), orderBy As String, usaBono As Boolean?) As DataTable
      Dim stb = New StringBuilder()
      SelectTexto(stb)
      With stb
         .AppendFormatLine(" WHERE 1 = 1")
         If idSucursal <> 0 Then
            .AppendFormatLine("   AND I.IdSucursal = {0}", idSucursal)
         End If
         If idImpresoras.AnySecure() Then
            GetListaImpresorasMultiples(stb, idImpresoras, "I", "IdImpresora")
            .AppendLine()
         End If
         If usaBono.HasValue Then
            .AppendFormatLine("   AND I.UtilizaBonosFiscalesElectronicos = {0}", GetStringFromBoolean(usaBono.Value))
         End If
         If Not String.IsNullOrWhiteSpace(orderBy) Then
            .AppendFormatLine(" ORDER BY I.{0}", orderBy)
         End If
      End With
      Return GetDataTable(stb)
   End Function

   Public Function Impresoras_G1(idSucursal As Integer, idImpresora As String) As DataTable
      Dim stb = New StringBuilder()
      Me.SelectTexto(stb)
      With stb
         .AppendFormatLine(" WHERE I.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND I.IdImpresora = '{0}'", idImpresora)
      End With
      Return GetDataTable(stb)
   End Function
   Public Function Impresoras_G1(idSucursal As Integer, centroEmisor As Integer) As DataTable
      Dim stb = New StringBuilder()
      SelectTexto(stb)
      With stb
         .AppendFormatLine(" WHERE I.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND I.CentroEmisor = {0}", centroEmisor)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(idSucursal As Integer, columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "I.",
                    New Dictionary(Of String, String) From {{"NombreLocalidadCentroEmisor", "L.NombreLocalidad"}}, mapearColumnaCustom:=Nothing,
                    agregarCondicionAdicional:=Sub(stb) stb.AppendFormat("   AND I.IdSucursal = {0}", idSucursal))
   End Function

   Public Function GetComprobantesAsociadosPorSucursalPC(idSucursal As Integer, nombrePC As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT I.IdImpresora")
         .AppendFormatLine("      ,I.ComprobantesHabilitados")
         .AppendFormatLine("  FROM Impresoras I")
         .AppendFormatLine("  INNER JOIN ImpresorasPCs IP ON IP.IdImpresora = I.IdImpresora AND IP.IdSucursal = I.IdSucursal ")
         .AppendFormatLine(" WHERE I.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IP.NombrePC = '{0}'", nombrePC)
      End With
      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetPorSucursalPC(idSucursal As Integer, nombrePC As String, esFiscal As Boolean) As DataTable
      Dim stb = New StringBuilder()
      SelectTexto(stb)
      With stb
         .AppendFormatLine(" INNER JOIN ImpresorasPCs IP ON IP.IdImpresora = I.IdImpresora AND IP.IdSucursal = I.IdSucursal ")
         .AppendFormatLine(" WHERE IP.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IP.NombrePC = '{0}'", nombrePC)
         .AppendFormatLine("   AND I.tipoImpresora = '{0}'", If(esFiscal, "FISCAL", "NORMAL"))
      End With
      Return GetDataTable(stb)
   End Function

   Public Sub ActualizaUltimaFechaExtraidaAuditoria(idSucursal As Integer, idImpresora As String, fechaHasta As DateTime)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE Impresoras")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.Impresora.Columnas.FiscalUltimaFechaExtraidaAuditoria.ToString(), ObtenerFecha(fechaHasta, True))
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdImpresora = '{0}'", idImpresora)
      End With
      Execute(stb)
   End Sub
   Public Sub ActualizaUltimoZetaExtraidoAuditoria(idSucursal As Integer, idImpresora As String, zetaHasta As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE Impresoras")
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.Impresora.Columnas.FiscalUltimoZetaExtraidoAuditoria.ToString(), zetaHasta)
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdImpresora = '{0}'", idImpresora)
      End With
      Execute(stb)
   End Sub
   Public Sub ActualizaUltimaFechaExtraidaInforme(idSucursal As Integer, idImpresora As String, fechaHasta As DateTime)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE Impresoras")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.Impresora.Columnas.FiscalUltimaFechaExtraidaInforme.ToString(), ObtenerFecha(fechaHasta, True))
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdImpresora = '{0}'", idImpresora)
      End With
      Execute(stb)
   End Sub

   Public Function DistictCentroEmisor(idSucursal As Integer) As List(Of Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT DISTINCT CentroEmisor FROM Impresoras")
         If idSucursal <> 0 Then
            .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         End If
      End With
      Using dt = GetDataTable(stb)
         Return dt.AsEnumerable().ToList().ConvertAll(Function(dr) dr.Field(Of Integer)("CentroEmisor")).ToList()
      End Using
   End Function
End Class