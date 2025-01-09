Public Class Impresoras
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Friend Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.Impresora.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.Impresora)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.Impresora)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.Impresora)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.Impresoras(da).Buscar(entidad.IdSucursal, entidad.Columna, entidad.Valor.ToString()).Copy()
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.Impresoras(da).Impresoras_GA(actual.Sucursal.Id)
   End Function
   Public Overloads Function GetAll(idSucursal As Integer) As DataTable
      Return New SqlServer.Impresoras(da).Impresoras_GA(idSucursal)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.Impresora, tipo As TipoSP)

      Dim sql = New SqlServer.Impresoras(da)
      Dim sqlPCs = New SqlServer.ImpresorasPCs(da)
      'borro todas las PCs de esa impresora para luego insertar las que corresponden.
      sqlPCs.ImpresorasPCs_DAll(en.IdImpresora, en.IdSucursal)

      Select Case tipo
         Case TipoSP._I
            sql.Impresoras_I(en.IdSucursal, en.IdImpresora, en.TipoImpresora, en.CentroEmisor,
                             en.ComprobantesHabilitados, en.Puerto, en.Velocidad, en.MaximoCaracteresItem, en.EsProtocoloExtendido,
                             en.Modelo, en.OrigenPapel, en.CantidadCopias, en.TipoFormulario, en.TamanioLetra, en.Marca, en.Metodo,
                             en.AbrirCajonDinero, en.GrabarLOGs, en.ImprimirLineaALinea, en.CierreFiscalEstandar, en.PorCtaOrden,
                             en.DireccionCentroEmisor, en.LocalidadCentroEmisor.IdLocalidad,
                             en.FiscalUltimaFechaExtraidaAuditoria, en.FiscalUltimoZetaExtraidoAuditoria, en.FiscalUltimaFechaExtraidaInforme,
                             en.UtilizaBonosFiscalesElectronicos)
            For Each pc In en.PCs
               sqlPCs.ImpresorasPCs_I(pc, en.IdImpresora, en.IdSucursal)
            Next

            ''SE ANULA DE MOMENTO PORQUE NO ESTARÍA SIENDO NECESARIO Y GENERA PROBLEMA AL REPLICAR MISMO EMISOR EN DIFERENTE SUCURSAL.
            ''SI SE DEBE REHABILITAR ANALIZAR UNA SOLUCIÓN INTEGRAL.
            '' 'Genero la numeracion en cero, es muy importante mantener los comprobantes relacionados (FACT, NCRED, NDEB)
            ''Dim sqlVentasNumero As SqlServer.VentasNumeros = New SqlServer.VentasNumeros(da)
            ''sqlVentasNumero.VentasNumeros_GenerarNumeracion(en.IdSucursal, en.CentroEmisor)


         Case TipoSP._U
            sql.Impresoras_U(en.IdSucursal, en.IdImpresora, en.TipoImpresora, en.CentroEmisor,
                             en.ComprobantesHabilitados, en.Puerto, en.Velocidad, en.MaximoCaracteresItem, en.EsProtocoloExtendido,
                             en.Modelo, en.OrigenPapel, en.CantidadCopias, en.TipoFormulario, en.TamanioLetra, en.Marca, en.Metodo,
                             en.AbrirCajonDinero, en.GrabarLOGs, en.ImprimirLineaALinea, en.CierreFiscalEstandar, en.PorCtaOrden,
                             en.DireccionCentroEmisor, en.LocalidadCentroEmisor.IdLocalidad,
                             en.FiscalUltimaFechaExtraidaAuditoria, en.FiscalUltimoZetaExtraidoAuditoria, en.FiscalUltimaFechaExtraidaInforme,
                             en.UtilizaBonosFiscalesElectronicos)
            For Each pc In en.PCs
               sqlPCs.ImpresorasPCs_I(pc, en.IdImpresora, en.IdSucursal)
            Next

         Case TipoSP._D

            'No fue posible poner el FK.
            Dim oVentas = New Ventas(da)
            If oVentas.Emisor(en.IdSucursal, en.CentroEmisor) Then
               Throw New Exception("El Centro Emisor esta siendo utilizado en Ventas, NO puede Borrarlo.")
            End If
            '----------------------------

            Dim sqlVentasNumero = New SqlServer.VentasNumeros(da)
            sqlVentasNumero.VentasNumeros_DxEmisor(en.IdSucursal, en.CentroEmisor)

            sql.Impresoras_D(en.IdSucursal, en.IdImpresora)

      End Select

   End Sub
   Private Sub CargarVarios(dt As DataTable, lista As List(Of Entidades.Impresora))
      For Each dr As DataRow In dt.Rows
         Dim o = New Entidades.Impresora()
         CargarUno(o, dr)
         lista.Add(o)
      Next
   End Sub

   Private Sub CargarUno(o As Entidades.Impresora, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)("IdSucursal")
         .IdImpresora = dr.Field(Of String)("IdImpresora")
         .TipoImpresora = dr.Field(Of String)("TipoImpresora")
         .CentroEmisor = dr.Field(Of Integer)("CentroEmisor").ToShort()
         .ComprobantesHabilitados = dr.Field(Of String)("ComprobantesHabilitados").IfNull()
         .Puerto = dr.Field(Of String)("Puerto").IfNull()
         .Velocidad = dr.Field(Of Integer?)("Velocidad").IfNull()
         .MaximoCaracteresItem = dr.Field(Of Integer)(Entidades.Impresora.Columnas.MaximoCaracteresItem.ToString())
         .EsProtocoloExtendido = dr.Field(Of Boolean?)("EsProtocoloExtendido").IfNull()
         .Modelo = dr.Field(Of String)("Modelo").IfNull()
         .OrigenPapel = dr.Field(Of String)("OrigenPapel").IfNull()
         .CantidadCopias = dr.Field(Of Short?)("CantidadCopias").IfNull()
         .TipoFormulario = dr.Field(Of String)("TipoFormulario").IfNull()
         .Marca = dr.Field(Of String)("Marca").IfNull()
         .TamanioLetra = dr.Field(Of Short)("TamanioLetra")
         Try
            .Metodo = DirectCast([Enum].Parse(GetType(Entidades.Impresora.MetodosFiscal), dr.Field(Of String)("Metodo")), Entidades.Impresora.MetodosFiscal)
         Catch ex As Exception
            .Metodo = Nothing
         End Try
         .PCs = New Impresoras().GetLasPCs(o.IdSucursal, o.IdImpresora)
         .AbrirCajonDinero = dr.Field(Of Boolean)("AbrirCajonDinero")
         .GrabarLOGs = dr.Field(Of Boolean)("GrabarLOGs")
         .ImprimirLineaALinea = dr.Field(Of Boolean)("ImprimirLineaALinea")
         .CierreFiscalEstandar = dr.Field(Of Boolean)("CierreFiscalEstandar")
         .PorCtaOrden = dr.Field(Of Boolean)("PorCtaOrden")

         .DireccionCentroEmisor = dr.Field(Of String)(Entidades.Impresora.Columnas.DireccionCentroEmisor.ToString()).IfNull()
         Dim idLocalidad = dr.Field(Of Integer?)(Entidades.Impresora.Columnas.IdLocalidadCentroEmisor.ToString())
         If idLocalidad.HasValue Then
            .LocalidadCentroEmisor = New Localidades(da).GetUna(idLocalidad.Value)
         End If

         .FiscalUltimaFechaExtraidaAuditoria = dr.Field(Of Date?)(Entidades.Impresora.Columnas.FiscalUltimaFechaExtraidaAuditoria.ToString())
         .FiscalUltimoZetaExtraidoAuditoria = dr.Field(Of Integer?)(Entidades.Impresora.Columnas.FiscalUltimoZetaExtraidoAuditoria.ToString())
         .FiscalUltimaFechaExtraidaInforme = dr.Field(Of Date?)(Entidades.Impresora.Columnas.FiscalUltimaFechaExtraidaInforme.ToString())

         .UtilizaBonosFiscalesElectronicos = dr.Field(Of Boolean)(Entidades.Impresora.Columnas.UtilizaBonosFiscalesElectronicos.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.Impresora)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.Impresora)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.Impresora)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetPorSucursalPC(idSucursal As Integer, nombrePC As String, esFiscal As Boolean) As Entidades.Impresora
      Return CargaEntidad(New SqlServer.Impresoras(da).GetPorSucursalPC(idSucursal, nombrePC, esFiscal),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Impresora(),
                          AccionesSiNoExisteRegistro.Excepcion, "No tiene impresoras seteadas en esta computadora")
   End Function

   Public Function GetUna(idSucursal As Integer, idImpresora As String) As Entidades.Impresora
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Return _GetUna(idSucursal, idImpresora)
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Function

   Friend Function _GetUna(idSucursal As Integer, idImpresora As String) As Entidades.Impresora
      Return CargaEntidad(New SqlServer.Impresoras(da).Impresoras_G1(idSucursal, idImpresora),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Impresora(),
                          AccionesSiNoExisteRegistro.Excepcion, String.Format("No existe la impresora {0} en la sucursal {1}", idImpresora, idSucursal))
   End Function

   Public Function GetUna(idSucursal As Integer, centroEmisor As Integer) As Entidades.Impresora
      Return GetUna(idSucursal, centroEmisor, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUna(idSucursal As Integer, centroEmisor As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.Impresora
      Return CargaEntidad(New SqlServer.Impresoras(da).Impresoras_G1(idSucursal, centroEmisor),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Impresora(),
                          accion, String.Format("No existe impresora para el Centro Emisor {0} en la sucursal {1}", centroEmisor, idSucursal))
   End Function
   Public Function AlgunaUsaBonos() As Boolean
      Using dt = New SqlServer.Impresoras(da).Impresoras_GA(idSucursal:=0, idImpresoras:=Nothing, orderBy:=String.Empty, usaBono:=True)
         Return dt.Any()
      End Using
   End Function

   Public Function GetLasPCs(idSucursal As Integer, idImpresora As String) As String()
      Dim sql As SqlServer.ImpresorasPCs = New SqlServer.ImpresorasPCs(da)
      Dim dt As DataTable = sql.GetPCs(idImpresora, idSucursal)
      Dim val(dt.Rows.Count - 1) As String
      Dim i As Integer = 0
      For Each dr As DataRow In dt.Rows
         val(i) = dr("NombrePC").ToString()
         i += 1
      Next
      Return val
   End Function

   Public Function GetPorSucursalTipoComprobante(idSucursal As Integer, IdTipoComprobante As String) As Entidades.Impresora
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT DISTINCT I.IdImpresora")
         .AppendLine("      ,I.ComprobantesHabilitados")
         .AppendLine("  FROM Impresoras I")
         .AppendLine("  INNER JOIN ImpresorasPCs IP ON IP.IdImpresora = I.IdImpresora AND IP.IdSucursal = I.IdSucursal ")
         .AppendLine(" WHERE I.IdSucursal = " & idSucursal.ToString())
      End With

      Dim dt As DataTable = da.GetDataTable(stb.ToString())
      'si no existe ningun registro, significa que no se cargo el nombre de la PC y tiene que salir.
      'Pero a esta altura no deberia suceder porque debio ser controlado mas arriba en el codigo.
      If dt.Rows.Count = 0 Then
         Throw New Exception("No Existe la Configuracion de Tipo de Impresora/Emisor/Comprobantes para esta Sucursal.")
      End If

      Dim com() As String = {}
      Dim IdImpresora As String = ""

      For Each dr As DataRow In dt.Rows
         com = dr(1).ToString().Split(","c)

         For i As Integer = 0 To com.Length - 1
            If com(i) = IdTipoComprobante Then
               IdImpresora = dr(0).ToString()
            End If
         Next

      Next

      If IdImpresora = "" Then
         Throw New Exception("No Existe la Configuracion de Tipo de Impresora/Emisor para este Comprobante y esta PC.")
      End If

      Return GetUna(idSucursal, IdImpresora)
   End Function

   Public Function GetPorSucursalPCTipoComprobante(idSucursal As Integer, nombrePC As String, idTipoComprobante As String) As Entidades.Impresora
      Return EjecutaConConexion(Function() _GetPorSucursalPCTipoComprobante(idSucursal, nombrePC, idTipoComprobante))
   End Function

   Public Function _GetPorSucursalPCTipoComprobante(idSucursal As Integer, nombrePC As String, idTipoComprobante As String) As Entidades.Impresora
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT I.IdImpresora")
         .AppendLine("      ,I.ComprobantesHabilitados")
         .AppendLine("  FROM Impresoras I")
         .AppendLine("  INNER JOIN ImpresorasPCs IP ON IP.IdImpresora = I.IdImpresora AND IP.IdSucursal = I.IdSucursal ")
         .AppendLine(" WHERE I.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IP.NombrePC = '" & nombrePC & "'")
      End With

      Dim dt = da.GetDataTable(stb.ToString())
      'si no existe ningun registro, significa que no se cargo el nombre de la PC y tiene que salir.
      'Pero a esta altura no deberia suceder porque debio ser controlado mas arriba en el codigo.
      If dt.Rows.Count = 0 Then
         Throw New Exception(String.Format("No Existe la Configuracion de Tipo de Impresora/Emisor/Comprobantes para esta PC.{0}{0}Sucursal: {1}{0}Nombre PC: {2}{0}Tipo Comprobante: {3}",
                                           Environment.NewLine, idSucursal, nombrePC, idTipoComprobante))
      End If

      Dim com() As String = {}
      Dim IdImpresora = String.Empty

      For Each dr As DataRow In dt.Rows
         com = dr(1).ToString().Split(","c)

         For i As Integer = 0 To com.Length - 1
            If com(i) = idTipoComprobante Then
               IdImpresora = dr(0).ToString()
            End If
         Next
      Next

      If String.IsNullOrWhiteSpace(IdImpresora) Then
         Throw New Exception(String.Format("No Existe la Configuracion de Tipo de Impresora/Emisor en esta Sucursal ({2}) para este Comprobante ({0}) y esta PC ({1}).",
                                           idTipoComprobante, nombrePC, idSucursal))
      End If

      Return GetUna(idSucursal, IdImpresora)

   End Function

   Public Function GetPorSucursalPCTipoComprobanteMultiples(idSucursal As Integer, nombrePC As String, IdTipoComprobante As String) As List(Of Entidades.Impresora)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()

         Dim sql As SqlServer.Impresoras = New SqlServer.Impresoras(da)
         Dim dt As DataTable = sql.GetComprobantesAsociadosPorSucursalPC(idSucursal, nombrePC)

         'si no existe ningun registro, significa que no se cargo el nombre de la PC y tiene que salir.
         'Pero a esta altura no deberia suceder porque debio ser controlado mas arriba en el codigo.
         If dt.Rows.Count = 0 Then
            Throw New Exception(String.Format("No Existe la Configuracion de Tipo de Impresora/Emisor/Comprobantes para esta PC.{0}{0}Sucursal: {1}{0}Nombre PC: {2}{0}Tipo Comprobante: {3}", Environment.NewLine, idSucursal, nombrePC, IdTipoComprobante))
         End If

         Dim idImpresoras As List(Of String) = New List(Of String)()

         For Each dr As DataRow In dt.Rows
            For Each compro As String In dr("ComprobantesHabilitados").ToString().Split(","c)
               If compro = IdTipoComprobante Then
                  idImpresoras.Add(dr("IdImpresora").ToString())
               End If
            Next
         Next

         Dim impresoras As List(Of Entidades.Impresora) = New List(Of Entidades.Impresora)()
         CargarVarios(sql.Impresoras_GA(idSucursal, idImpresoras.ToArray(), Entidades.Impresora.Columnas.CentroEmisor.ToString(), usaBono:=Nothing), impresoras)

         If impresoras.Count = 0 Then
            Throw New Exception("No Existe la Configuracion de Tipo de Impresora/Emisor para este Comprobante y esta PC.")
         End If

         Return impresoras    ''Me.GetUna(idSucursal, IdImpresora)
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Function

   Public Function CentroEmisorEnUso(emisor As Short) As Boolean
      If New SqlServer.Ventas(da).AlgunRegistrosVentaPorEmisor(emisor) Then Return True
      Return New SqlServer.CuentasCorrientes(da).AlgunRegistrosCuentaCorrientePorEmisor(emisor)
   End Function

   Public Sub ActualizaUltimaFechaExtraidaAuditoria(impresora As Entidades.Impresora, fechaHasta As Date)
      EjecutaConTransaccion(Sub()
                               Dim sql = New SqlServer.Impresoras(da)
                               sql.ActualizaUltimaFechaExtraidaAuditoria(impresora.IdSucursal, impresora.IdImpresora, fechaHasta)
                            End Sub)
   End Sub
   Public Sub ActualizaUltimoZetaExtraidoAuditoria(impresora As Entidades.Impresora, zetaHasta As Integer)
      EjecutaConTransaccion(Sub()
                               Dim sql = New SqlServer.Impresoras(da)
                               sql.ActualizaUltimoZetaExtraidoAuditoria(impresora.IdSucursal, impresora.IdImpresora, zetaHasta)
                            End Sub)
   End Sub
   Public Sub ActualizaUltimaFechaExtraidaInforme(impresora As Entidades.Impresora, fechaHasta As Date)
      EjecutaConTransaccion(Sub()
                               Dim sql = New SqlServer.Impresoras(da)
                               sql.ActualizaUltimaFechaExtraidaInforme(impresora.IdSucursal, impresora.IdImpresora, fechaHasta)
                            End Sub)
   End Sub

#End Region

End Class