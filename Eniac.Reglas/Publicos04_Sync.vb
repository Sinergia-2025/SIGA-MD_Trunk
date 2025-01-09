#Region "Option/Imports"
Option Explicit On
Option Strict On
Option Infer On
'Imports System.ComponentModel
'Imports System.Globalization
'Imports System.Text.RegularExpressions
#End Region
Partial Class Publicos
   Partial Class WebArchivos

      Public Shared ReadOnly Property SyncCollection As Entidades.JSonEntidades.Sincronizacion.SyncConfig()
         Get
            Return {SyncConfigCliente,
                    SyncConfigLocalidad,
                    SyncConfigMarca,
                    SyncConfigProducto,
                    SyncConfigProductoSucursal,
                    SyncConfigProductoSucursalPrecios,
                    SyncConfigProveedor,
                    SyncConfigRubroCompra,
                    SyncConfigRubro,
                    SyncConfigSubRubro,
                    SyncConfigSubSubRubro,
                    CRM.SyncConfigSyncCategorias,
                    CRM.SyncConfigSyncEstados,
                    CRM.SyncConfigSyncMediosComunicaciones,
                    CRM.SyncConfigSyncMetodosResoluciones,
                    CRM.SyncConfigSyncPrioridades,
                    CRM.SyncConfigSyncTiposComentarios,
                    CRM.SyncConfigSyncNovedades,
                    CRM.SyncConfigSyncNovedadesSeguimiento}
         End Get
      End Property

      Public Shared ReadOnly Property SyncConfigCliente() As Entidades.JSonEntidades.Sincronizacion.SyncConfig
         Get
            Return SyncConfig("cliente",
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRSUBIDACLIENTES,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINASUBIDACLIENTES,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRDESCARGACLIENTES,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINADESCARGACLIENTES)
         End Get
      End Property
      Public Shared ReadOnly Property SyncConfigProveedor() As Entidades.JSonEntidades.Sincronizacion.SyncConfig
         Get
            Return SyncConfig("proveedor",
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRSUBIDAPROVEEDORES,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINASUBIDAPROVEEDORES,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRDESCARGAPROVEEDORES,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINADESCARGAPROVEEDORES)
         End Get
      End Property


      Public Shared ReadOnly Property SyncConfigProducto() As Entidades.JSonEntidades.Sincronizacion.SyncConfig
         Get
            Return SyncConfig("producto",
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRSUBIDAPRODUCTOS,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINASUBIDAPRODUCTOS,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRDESCARGAPRODUCTOS,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINADESCARGAPRODUCTOS)
         End Get
      End Property
      Public Shared ReadOnly Property SyncConfigProductoSucursal() As Entidades.JSonEntidades.Sincronizacion.SyncConfig
         Get
            Return SyncConfig("productosucursal",
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRSUBIDAPRODUCTOSSUCURSALES,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINASUBIDAPRODUCTOSSUCURSALES,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRDESCARGAPRODUCTOSSUCURSALES,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINADESCARGAPRODUCTOSSUCURSALES)
         End Get
      End Property
      Public Shared ReadOnly Property SyncConfigProductoSucursalPrecios() As Entidades.JSonEntidades.Sincronizacion.SyncConfig
         Get
            Return SyncConfig("productosucursalprecio",
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRSUBIDAPRODSUCPRECIOS,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINASUBIDAPRODSUCPRECIOS,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRDESCARGAPRODSUCPRECIOS,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINADESCARGAPRODSUCPRECIOS)
         End Get
      End Property


      Public Shared ReadOnly Property SyncConfigLocalidad() As Entidades.JSonEntidades.Sincronizacion.SyncConfig
         Get
            Return SyncConfig("localidad",
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRSUBIDALOCALIDADES,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINASUBIDALOCALIDADES,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRDESCARGALOCALIDADES,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINADESCARGALOCALIDADES)
         End Get
      End Property
      Public Shared ReadOnly Property SyncConfigRubroCompra() As Entidades.JSonEntidades.Sincronizacion.SyncConfig
         Get
            Return SyncConfig("rubrocompra",
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRSUBIDARUBROSCOMPRAS,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINASUBIDARUBROSCOMPRAS,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRDESCARGARUBROSCOMPRAS,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINADESCARGARUBROSCOMPRAS)
         End Get
      End Property
      Public Shared ReadOnly Property SyncConfigMarca() As Entidades.JSonEntidades.Sincronizacion.SyncConfig
         Get
            Return SyncConfig("marca",
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRSUBIDAMARCAS,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINASUBIDAMARCAS,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRDESCARGAMARCAS,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINADESCARGAMARCAS)
         End Get
      End Property
      Public Shared ReadOnly Property SyncConfigRubro() As Entidades.JSonEntidades.Sincronizacion.SyncConfig
         Get
            Return SyncConfig("rubro",
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRSUBIDARUBROS,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINASUBIDARUBROS,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRDESCARGARUBROS,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINADESCARGARUBROS)
         End Get
      End Property
      Public Shared ReadOnly Property SyncConfigSubRubro() As Entidades.JSonEntidades.Sincronizacion.SyncConfig
         Get
            Return SyncConfig("subrubro",
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRSUBIDASUBRUBROS,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINASUBIDASUBRUBROS,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRDESCARGASUBRUBROS,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINADESCARGASUBRUBROS)
         End Get
      End Property
      Public Shared ReadOnly Property SyncConfigSubSubRubro() As Entidades.JSonEntidades.Sincronizacion.SyncConfig
         Get
            Return SyncConfig("subsubrubro",
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRSUBIDASUBSUBRUBROS,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINASUBIDASUBSUBRUBROS,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRDESCARGASUBSUBRUBROS,
                              Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINADESCARGASUBSUBRUBROS)
         End Get
      End Property


      Public Class CRM
         Public Shared ReadOnly Property SyncConfigSyncCategorias() As Entidades.JSonEntidades.Sincronizacion.SyncConfig
            Get
               Return SyncConfig("crmcategorianovedad",
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRSUBIDACRMCATEGORIAS,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINASUBIDACRMCATEGORIAS,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRDESCARGACRMCATEGORIAS,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINADESCARGACRMCATEGORIAS)
            End Get
         End Property
         Public Shared ReadOnly Property SyncConfigSyncEstados() As Entidades.JSonEntidades.Sincronizacion.SyncConfig
            Get
               Return SyncConfig("crmestadonovedad",
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRSUBIDACRMESTADOS,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINASUBIDACRMESTADOS,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRDESCARGACRMESTADOS,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINADESCARGACRMESTADOS)
            End Get
         End Property
         Public Shared ReadOnly Property SyncConfigSyncMediosComunicaciones() As Entidades.JSonEntidades.Sincronizacion.SyncConfig
            Get
               Return SyncConfig("crmmediocomunicacionnovedad",
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRSUBIDACRMMEDIOS,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINASUBIDACRMMEDIOS,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRDESCARGACRMMEDIOS,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINADESCARGACRMMEDIOS)
            End Get
         End Property
         Public Shared ReadOnly Property SyncConfigSyncMetodosResoluciones() As Entidades.JSonEntidades.Sincronizacion.SyncConfig
            Get
               Return SyncConfig("crmmetodoresolucionnovedad",
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRSUBIDACRMMETODOS,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINASUBIDACRMMETODOS,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRDESCARGACRMMETODOS,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINADESCARGACRMMETODOS)
            End Get
         End Property
         Public Shared ReadOnly Property SyncConfigSyncPrioridades() As Entidades.JSonEntidades.Sincronizacion.SyncConfig
            Get
               Return SyncConfig("crmprioridadnovedad",
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRSUBIDACRMPRIORIDADES,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINASUBIDACRMPRIORIDADES,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRDESCARGACRMPRIORIDADES,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINADESCARGACRMPRIORIDADES)
            End Get
         End Property
         Public Shared ReadOnly Property SyncConfigSyncTiposComentarios() As Entidades.JSonEntidades.Sincronizacion.SyncConfig
            Get
               Return SyncConfig("crmtipocomentarionovedad",
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRSUBIDACRMTIPOSCOMENTARIOS,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINASUBIDACRMTIPOSCOMENTARIOS,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRDESCARGACRMTIPOSCOMENTARIOS,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINADESCARGACRMTIPOSCOMENTARIOS)
            End Get
         End Property

         Public Shared ReadOnly Property SyncConfigSyncNovedades() As Entidades.JSonEntidades.Sincronizacion.SyncConfig
            Get
               Return SyncConfig("crmnovedad",
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRSUBIDACRMNOVEDADES,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINASUBIDACRMNOVEDADES,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRDESCARGACRMNOVEDADES,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINADESCARGACRMNOVEDADES)
            End Get
         End Property
         Public Shared ReadOnly Property SyncConfigSyncNovedadesSeguimiento() As Entidades.JSonEntidades.Sincronizacion.SyncConfig
            Get
               Return SyncConfig("crmnovedadseguimiento",
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRSUBIDACRMNOVEDADESSEG,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINASUBIDACRMNOVEDADESSEG,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCINCLUIRDESCARGACRMNOVEDADESSEG,
                                 Entidades.Parametro.Parametros.WEBARCHIVOSSYNCPAGINADESCARGACRMNOVEDADESSEG)
            End Get
         End Property


         Public Class FechaUltimaDescarga
            Public Shared ReadOnly Property CRMCategoriasNovedades As DateTime?
               Get
                  Return GetFechaUltimaDescarga(Entidades.Parametro.Parametros.WEBARCHIVOSCRMCATEGORIASULTIMADESCARGA)
               End Get
            End Property

            Public Shared ReadOnly Property CRMEstadosNovedades As DateTime?
               Get
                  Return GetFechaUltimaDescarga(Entidades.Parametro.Parametros.WEBARCHIVOSCRMESTADOSULTIMADESCARGA)
               End Get
            End Property
            Public Shared ReadOnly Property CRMMediosComunicacionesNovedades As DateTime?
               Get
                  Return GetFechaUltimaDescarga(Entidades.Parametro.Parametros.WEBARCHIVOSCRMMEDIOSULTIMADESCARGA)
               End Get
            End Property
            Public Shared ReadOnly Property CRMMetodosResolucionesNovedades As DateTime?
               Get
                  Return GetFechaUltimaDescarga(Entidades.Parametro.Parametros.WEBARCHIVOSCRMMETODOSULTIMADESCARGA)
               End Get
            End Property
            Public Shared ReadOnly Property CRMPrioridadesNovedades As DateTime?
               Get
                  Return GetFechaUltimaDescarga(Entidades.Parametro.Parametros.WEBARCHIVOSCRMPRIORIDADESULTIMADESCARGA)
               End Get
            End Property
            Public Shared ReadOnly Property CRMTiposComentariosNovedades As DateTime?
               Get
                  Return GetFechaUltimaDescarga(Entidades.Parametro.Parametros.WEBARCHIVOSCRMTIPOSCOMENTARIOSULTIMADESCARGA)
               End Get
            End Property

            Public Shared ReadOnly Property CRMNovedades As DateTime?
               Get
                  Return GetFechaUltimaDescarga(Entidades.Parametro.Parametros.WEBARCHIVOSCRMNOVEDADESULTIMADESCARGA)
               End Get
            End Property
            Public Shared ReadOnly Property CRMNovedadesSeguimiento As DateTime?
               Get
                  Return GetFechaUltimaDescarga(Entidades.Parametro.Parametros.WEBARCHIVOSCRMNOVEDADESSEGULTIMADESCARGA)
               End Get
            End Property
         End Class

      End Class

      Public Shared ReadOnly Property SyncBaseURL As String
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.WEBARCHIVOSSYNCBASEURL, "")
         End Get
      End Property
      Public Shared ReadOnly Property SyncExportPath As String
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.WEBARCHIVOSSYNCEXPORTPATH, "")
         End Get
      End Property

      Private Shared ReadOnly Property GetFechaUltimaDescarga(param As Entidades.Parametro.Parametros) As DateTime?
         Get
            Dim strFechaUltimaDescarga As String = New Reglas.Parametros().GetValorPD(param, String.Empty)
            If IsDate(strFechaUltimaDescarga) Then
               Return DateTime.Parse(strFechaUltimaDescarga)
            End If
            Return Nothing
         End Get
      End Property


      Private Shared ReadOnly Property SyncConfig(endPointName As String,
                                                  incluidoSubidaKey As Entidades.Parametro.Parametros,
                                                  tamanioPaginaSubidaKey As Entidades.Parametro.Parametros,
                                                  incluidoDescargaKey As Entidades.Parametro.Parametros,
                                                  tamanioPaginaDescargaKey As Entidades.Parametro.Parametros) As Entidades.JSonEntidades.Sincronizacion.SyncConfig
         Get
            Dim baseURL As String = SyncBaseURL
            Dim archivoExportarPath As String = SyncExportPath

            Dim incluidoSubida As Boolean = Boolean.Parse(New Reglas.Parametros().GetValorPD(incluidoSubidaKey, Boolean.FalseString))
            Dim tamanioPaginaSubida As Integer = Integer.Parse(New Reglas.Parametros().GetValorPD(tamanioPaginaSubidaKey, "100"))

            Dim incluidoDescarga As Boolean = Boolean.Parse(New Reglas.Parametros().GetValorPD(incluidoDescargaKey, Boolean.FalseString))
            Dim tamanioPaginaDescarga As Integer = Integer.Parse(New Reglas.Parametros().GetValorPD(tamanioPaginaDescargaKey, "100"))

            'If Not String.IsNullOrWhiteSpace(baseURL) Then baseURL = String.Concat(baseURL.TrimEnd("/"c), "/", endPointName, "/")
            'If Not String.IsNullOrWhiteSpace(archivoExportarPath) Then archivoExportarPath = String.Concat(archivoExportarPath, "@@nombretabla@@\@@nombretabla@@_{0:00000000}.json").Replace("@@nombretabla@@", endPointName)

            Return New Entidades.JSonEntidades.Sincronizacion.SyncConfig(endPointName, baseURL, archivoExportarPath, incluidoSubida, tamanioPaginaSubida, incluidoDescarga, tamanioPaginaDescarga,
                                                                         incluidoSubidaKey, tamanioPaginaSubidaKey, incluidoDescargaKey, tamanioPaginaDescargaKey)
         End Get
      End Property


   End Class

End Class