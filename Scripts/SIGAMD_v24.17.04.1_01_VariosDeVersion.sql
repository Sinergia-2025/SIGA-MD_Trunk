IF dbo.ExisteTabla('CalidadListasControlTipos') = 1 EXECUTE sp_rename 'dbo.CalidadListasControlTipos', 'Borrar_CalidadListasControlTipos', 'OBJECT' 
IF dbo.ExisteTabla('CalidadListasControlProductosItemsProceso') = 1 EXECUTE sp_rename 'dbo.CalidadListasControlProductosItemsProceso', 'Borrar_CalidadListasControlProductosItemsProceso', 'OBJECT' 
IF dbo.ExisteTabla('CalidadProgramacionProduccion') = 1 EXECUTE sp_rename 'dbo.CalidadProgramacionProduccion', 'Borrar_CalidadProgramacionProduccion', 'OBJECT' 
IF dbo.ExisteTabla('CalidadOCActivaciones') = 1 EXECUTE sp_rename 'dbo.CalidadOCActivaciones', 'Borrar_CalidadOCActivaciones', 'OBJECT' 
IF dbo.ExisteTabla('CalidadGruposListasControlItems') = 1 EXECUTE sp_rename 'dbo.CalidadGruposListasControlItems', 'Borrar_CalidadGruposListasControlItems', 'OBJECT' 
IF dbo.ExisteTabla('CalidadSubGruposListasControlItems') = 1 EXECUTE sp_rename 'dbo.CalidadSubGruposListasControlItems', 'Borrar_CalidadSubGruposListasControlItems', 'OBJECT' 
IF dbo.ExisteTabla('CalidadListasControlItems') = 1 EXECUTE sp_rename 'dbo.CalidadListasControlItems', 'Borrar_CalidadListasControlItems', 'OBJECT' 
IF dbo.ExisteTabla('CalidadListasControl') = 1 EXECUTE sp_rename 'dbo.CalidadListasControl', 'Borrar_CalidadListasControl', 'OBJECT' 
IF dbo.ExisteTabla('CalidadListasControlProductosProceso') = 1 EXECUTE sp_rename 'dbo.CalidadListasControlProductosProceso', 'Borrar_CalidadListasControlProductosProceso', 'OBJECT' 
IF dbo.ExisteTabla('CalidadListasControlConfig') = 1 EXECUTE sp_rename 'dbo.CalidadListasControlConfig', 'Borrar_CalidadListasControlConfig', 'OBJECT' 
IF dbo.ExisteTabla('CalidadListasControlUsuarios') = 1 EXECUTE sp_rename 'dbo.CalidadListasControlUsuarios', 'Borrar_CalidadListasControlUsuarios', 'OBJECT' 
IF dbo.ExisteTabla('CalidadListasControlProductos') = 1 EXECUTE sp_rename 'dbo.CalidadListasControlProductos', 'Borrar_CalidadListasControlProductos', 'OBJECT' 
IF dbo.ExisteTabla('CalidadAuditoriaLoginWebPaneles') = 1 EXECUTE sp_rename 'dbo.CalidadAuditoriaLoginWebPaneles', 'Borrar_CalidadAuditoriaLoginWebPaneles', 'OBJECT' 
IF dbo.ExisteTabla('CalidadProductosTiposServicios') = 1 EXECUTE sp_rename 'dbo.CalidadProductosTiposServicios', 'Borrar_CalidadProductosTiposServicios', 'OBJECT' 
IF dbo.ExisteTabla('CalidadExcepcionesTipos') = 1 EXECUTE sp_rename 'dbo.CalidadExcepcionesTipos', 'Borrar_CalidadExcepcionesTipos', 'OBJECT' 
IF dbo.ExisteTabla('CalidadExcepciones') = 1 EXECUTE sp_rename 'dbo.CalidadExcepciones', 'Borrar_CalidadExcepciones', 'OBJECT' 
IF dbo.ExisteTabla('CalidadProductosExcepciones') = 1 EXECUTE sp_rename 'dbo.CalidadProductosExcepciones', 'Borrar_CalidadProductosExcepciones', 'OBJECT' 
IF dbo.ExisteTabla('CalidadListasControlProductosItems') = 1 EXECUTE sp_rename 'dbo.CalidadListasControlProductosItems', 'Borrar_CalidadListasControlProductosItems', 'OBJECT' 
IF dbo.ExisteTabla('CalidadProductosModelos') = 1 EXECUTE sp_rename 'dbo.CalidadProductosModelos', 'Borrar_CalidadProductosModelos', 'OBJECT' 
IF dbo.ExisteTabla('CalidadEnviosOC') = 1 EXECUTE sp_rename 'dbo.CalidadEnviosOC', 'Borrar_CalidadEnviosOC', 'OBJECT' 
IF dbo.ExisteTabla('CalidadListasControlConfigLinks') = 1 EXECUTE sp_rename 'dbo.CalidadListasControlConfigLinks', 'Borrar_CalidadListasControlConfigLinks', 'OBJECT' 
IF dbo.ExisteTabla('CalidadMetasTiposListas') = 1 EXECUTE sp_rename 'dbo.CalidadMetasTiposListas', 'Borrar_CalidadMetasTiposListas', 'OBJECT' 
IF dbo.ExisteTabla('CalidadListasControlProductosModelos') = 1 EXECUTE sp_rename 'dbo.CalidadListasControlProductosModelos', 'Borrar_CalidadListasControlProductosModelos', 'OBJECT' 
IF dbo.ExisteTabla('CalidadListasControlRoles') = 1 EXECUTE sp_rename 'dbo.CalidadListasControlRoles', 'Borrar_CalidadListasControlRoles', 'OBJECT' 
IF dbo.ExisteTabla('CalidadDiasLaborablesNoLaborables') = 1 EXECUTE sp_rename 'dbo.CalidadDiasLaborablesNoLaborables', 'Borrar_CalidadDiasLaborablesNoLaborables', 'OBJECT' 
IF dbo.ExisteTabla('CalidadPlantillas') = 1 EXECUTE sp_rename 'dbo.CalidadPlantillas', 'Borrar_CalidadPlantillas', 'OBJECT' 
IF dbo.ExisteTabla('CalidadPlantillasListasControl') = 1 EXECUTE sp_rename 'dbo.CalidadPlantillasListasControl', 'Borrar_CalidadPlantillasListasControl', 'OBJECT' 
IF dbo.ExisteTabla('CalidadEstadosListasControl') = 1 EXECUTE sp_rename 'dbo.CalidadEstadosListasControl', 'Borrar_CalidadEstadosListasControl', 'OBJECT' 
IF dbo.ExisteTabla('CalidadProductosModelosSubTipos') = 1 EXECUTE sp_rename 'dbo.CalidadProductosModelosSubTipos', 'Borrar_CalidadProductosModelosSubTipos', 'OBJECT' 
IF dbo.ExisteTabla('CalidadEnviosOCErrores') = 1 EXECUTE sp_rename 'dbo.CalidadEnviosOCErrores', 'Borrar_CalidadEnviosOCErrores', 'OBJECT' 
IF dbo.ExisteTabla('CalidadProductosModelosTipos') = 1 EXECUTE sp_rename 'dbo.CalidadProductosModelosTipos', 'Borrar_CalidadProductosModelosTipos', 'OBJECT' 

IF dbo.ExistePK('PK_CalidadAuditoriaLoginWebPaneles') = 1 EXECUTE sp_rename 'dbo.PK_CalidadAuditoriaLoginWebPaneles', 'PK_Borrar_CalidadAuditoriaLoginWebPaneles', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadDiasLaborablesNoLaborables') = 1 EXECUTE sp_rename 'dbo.PK_CalidadDiasLaborablesNoLaborables', 'PK_Borrar_CalidadDiasLaborablesNoLaborables', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadEnviosOC') = 1 EXECUTE sp_rename 'dbo.PK_CalidadEnviosOC', 'PK_Borrar_CalidadEnviosOC', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadEnviosOCErrores') = 1 EXECUTE sp_rename 'dbo.PK_CalidadEnviosOCErrores', 'PK_Borrar_CalidadEnviosOCErrores', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadEstadosListasControl') = 1 EXECUTE sp_rename 'dbo.PK_CalidadEstadosListasControl', 'PK_Borrar_CalidadEstadosListasControl', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadExcepciones') = 1 EXECUTE sp_rename 'dbo.PK_CalidadExcepciones', 'PK_Borrar_CalidadExcepciones', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadExcepcionesTipos') = 1 EXECUTE sp_rename 'dbo.PK_CalidadExcepcionesTipos', 'PK_Borrar_CalidadExcepcionesTipos', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadGruposListasControlItems') = 1 EXECUTE sp_rename 'dbo.PK_CalidadGruposListasControlItems', 'PK_Borrar_CalidadGruposListasControlItems', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadListasControl') = 1 EXECUTE sp_rename 'dbo.PK_CalidadListasControl', 'PK_Borrar_CalidadListasControl', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadListasControlConfig') = 1 EXECUTE sp_rename 'dbo.PK_CalidadListasControlConfig', 'PK_Borrar_CalidadListasControlConfig', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadListasControlConfigLinks') = 1 EXECUTE sp_rename 'dbo.PK_CalidadListasControlConfigLinks', 'PK_Borrar_CalidadListasControlConfigLinks', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadListasControlItems') = 1 EXECUTE sp_rename 'dbo.PK_CalidadListasControlItems', 'PK_Borrar_CalidadListasControlItems', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadListasControlItemsProductos') = 1 EXECUTE sp_rename 'dbo.PK_CalidadListasControlItemsProductos', 'PK_Borrar_CalidadListasControlItemsProductos', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadListasControlItemsProductosProceso') = 1 EXECUTE sp_rename 'dbo.PK_CalidadListasControlItemsProductosProceso', 'PK_Borrar_CalidadListasControlItemsProductosProceso', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadListasControlProductos2_1') = 1 EXECUTE sp_rename 'dbo.PK_CalidadListasControlProductos2_1', 'PK_Borrar_CalidadListasControlProductos2_1', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadListasControlProductosModelos') = 1 EXECUTE sp_rename 'dbo.PK_CalidadListasControlProductosModelos', 'PK_Borrar_CalidadListasControlProductosModelos', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadListasControlProductosProceso') = 1 EXECUTE sp_rename 'dbo.PK_CalidadListasControlProductosProceso', 'PK_Borrar_CalidadListasControlProductosProceso', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadListasControlRoles') = 1 EXECUTE sp_rename 'dbo.PK_CalidadListasControlRoles', 'PK_Borrar_CalidadListasControlRoles', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadListasControlTipos') = 1 EXECUTE sp_rename 'dbo.PK_CalidadListasControlTipos', 'PK_Borrar_CalidadListasControlTipos', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadListasControlUsuarios') = 1 EXECUTE sp_rename 'dbo.PK_CalidadListasControlUsuarios', 'PK_Borrar_CalidadListasControlUsuarios', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadMetasTiposListas') = 1 EXECUTE sp_rename 'dbo.PK_CalidadMetasTiposListas', 'PK_Borrar_CalidadMetasTiposListas', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadPlantillas') = 1 EXECUTE sp_rename 'dbo.PK_CalidadPlantillas', 'PK_Borrar_CalidadPlantillas', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadPlantillasListasControl') = 1 EXECUTE sp_rename 'dbo.PK_CalidadPlantillasListasControl', 'PK_Borrar_CalidadPlantillasListasControl', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadProductosExcepciones') = 1 EXECUTE sp_rename 'dbo.PK_CalidadProductosExcepciones', 'PK_Borrar_CalidadProductosExcepciones', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadProductosModelos') = 1 EXECUTE sp_rename 'dbo.PK_CalidadProductosModelos', 'PK_Borrar_CalidadProductosModelos', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadProductosModelosSubTipos') = 1 EXECUTE sp_rename 'dbo.PK_CalidadProductosModelosSubTipos', 'PK_Borrar_CalidadProductosModelosSubTipos', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadProductosModelosTipos') = 1 EXECUTE sp_rename 'dbo.PK_CalidadProductosModelosTipos', 'PK_Borrar_CalidadProductosModelosTipos', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadProductosTiposServicios') = 1 EXECUTE sp_rename 'dbo.PK_CalidadProductosTiposServicios', 'PK_Borrar_CalidadProductosTiposServicios', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadProgramacionProduccion') = 1 EXECUTE sp_rename 'dbo.PK_CalidadProgramacionProduccion', 'PK_Borrar_CalidadProgramacionProduccion', 'OBJECT' 
IF dbo.ExistePK('PK_CalidadSubGruposListasControlItems2') = 1 EXECUTE sp_rename 'dbo.PK_CalidadSubGruposListasControlItems2', 'PK_Borrar_CalidadSubGruposListasControlItems2', 'OBJECT' 

IF dbo.ExisteFK('FK_CalidadListasControl_CalidadListasControlTipos') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControl_CalidadListasControlTipos', 'FK_Borrar_CalidadListasControl_CalidadListasControlTipos', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadProgramacionProduccion_CalidadProgramacionProduccion') = 1 EXECUTE sp_rename 'dbo.FK_CalidadProgramacionProduccion_CalidadProgramacionProduccion', 'FK_Borrar_CalidadProgramacionProduccion_CalidadProgramacionProduccion', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadProgramacionProduccion_Productos') = 1 EXECUTE sp_rename 'dbo.FK_CalidadProgramacionProduccion_Productos', 'FK_Borrar_CalidadProgramacionProduccion_Productos', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadOCActivaciones_Observaciones') = 1 EXECUTE sp_rename 'dbo.FK_CalidadOCActivaciones_Observaciones', 'FK_Borrar_CalidadOCActivaciones_Observaciones', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadOCActivaciones_PedidosProveedores') = 1 EXECUTE sp_rename 'dbo.FK_CalidadOCActivaciones_PedidosProveedores', 'FK_Borrar_CalidadOCActivaciones_PedidosProveedores', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadOCActivaciones_PedidosProveedores') = 1 EXECUTE sp_rename 'dbo.FK_CalidadOCActivaciones_PedidosProveedores', 'FK_Borrar_CalidadOCActivaciones_PedidosProveedores', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadOCActivaciones_PedidosProveedores') = 1 EXECUTE sp_rename 'dbo.FK_CalidadOCActivaciones_PedidosProveedores', 'FK_Borrar_CalidadOCActivaciones_PedidosProveedores', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadOCActivaciones_PedidosProveedores') = 1 EXECUTE sp_rename 'dbo.FK_CalidadOCActivaciones_PedidosProveedores', 'FK_Borrar_CalidadOCActivaciones_PedidosProveedores', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadOCActivaciones_PedidosProveedores') = 1 EXECUTE sp_rename 'dbo.FK_CalidadOCActivaciones_PedidosProveedores', 'FK_Borrar_CalidadOCActivaciones_PedidosProveedores', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadOCActivaciones_Usuarios') = 1 EXECUTE sp_rename 'dbo.FK_CalidadOCActivaciones_Usuarios', 'FK_Borrar_CalidadOCActivaciones_Usuarios', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadSubGruposListasControlItems_CalidadGruposListasControlItems') = 1 EXECUTE sp_rename 'dbo.FK_CalidadSubGruposListasControlItems_CalidadGruposListasControlItems', 'FK_Borrar_CalidadSubGruposListasControlItems_CalidadGruposListasControlItems', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadListasControlItems_CalidadGruposListasControlItems') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControlItems_CalidadGruposListasControlItems', 'FK_Borrar_CalidadListasControlItems_CalidadGruposListasControlItems', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadListasControlConfig_CalidadListasControlItems') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControlConfig_CalidadListasControlItems', 'FK_Borrar_CalidadListasControlConfig_CalidadListasControlItems', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadListasControlUsuarios_CalidadListasControl') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControlUsuarios_CalidadListasControl', 'FK_Borrar_CalidadListasControlUsuarios_CalidadListasControl', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadListasControlUsuarios_Usuarios') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControlUsuarios_Usuarios', 'FK_Borrar_CalidadListasControlUsuarios_Usuarios', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadListasControlConfig_CalidadListasControl') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControlConfig_CalidadListasControl', 'FK_Borrar_CalidadListasControlConfig_CalidadListasControl', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadListasControlProductos_CalidadListasControl') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControlProductos_CalidadListasControl', 'FK_Borrar_CalidadListasControlProductos_CalidadListasControl', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadListasControlProductos_Usuarios') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControlProductos_Usuarios', 'FK_Borrar_CalidadListasControlProductos_Usuarios', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadListasControlProductos2_CalidadListasControlProductos2') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControlProductos2_CalidadListasControlProductos2', 'FK_Borrar_CalidadListasControlProductos2_CalidadListasControlProductos2', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadExcepciones_CalidadExcepciones') = 1 EXECUTE sp_rename 'dbo.FK_CalidadExcepciones_CalidadExcepciones', 'FK_Borrar_CalidadExcepciones_CalidadExcepciones', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadExcepciones_CalidadListasControlTipos') = 1 EXECUTE sp_rename 'dbo.FK_CalidadExcepciones_CalidadListasControlTipos', 'FK_Borrar_CalidadExcepciones_CalidadListasControlTipos', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadExcepciones_Usuarios') = 1 EXECUTE sp_rename 'dbo.FK_CalidadExcepciones_Usuarios', 'FK_Borrar_CalidadExcepciones_Usuarios', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadExcepciones_Usuarios1') = 1 EXECUTE sp_rename 'dbo.FK_CalidadExcepciones_Usuarios1', 'FK_Borrar_CalidadExcepciones_Usuarios1', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadExcepciones_Usuarios2') = 1 EXECUTE sp_rename 'dbo.FK_CalidadExcepciones_Usuarios2', 'FK_Borrar_CalidadExcepciones_Usuarios2', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadExcepciones_Usuarios3') = 1 EXECUTE sp_rename 'dbo.FK_CalidadExcepciones_Usuarios3', 'FK_Borrar_CalidadExcepciones_Usuarios3', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadProductosExcepciones_CalidadExcepciones') = 1 EXECUTE sp_rename 'dbo.FK_CalidadProductosExcepciones_CalidadExcepciones', 'FK_Borrar_CalidadProductosExcepciones_CalidadExcepciones', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadProductosExcepciones_Productos') = 1 EXECUTE sp_rename 'dbo.FK_CalidadProductosExcepciones_Productos', 'FK_Borrar_CalidadProductosExcepciones_Productos', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadProductosExcepciones_Usuarios') = 1 EXECUTE sp_rename 'dbo.FK_CalidadProductosExcepciones_Usuarios', 'FK_Borrar_CalidadProductosExcepciones_Usuarios', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadListasControlItemsProductos_CalidadListasControlItems') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControlItemsProductos_CalidadListasControlItems', 'FK_Borrar_CalidadListasControlItemsProductos_CalidadListasControlItems', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadListasControlItemsProductos_Productos') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControlItemsProductos_Productos', 'FK_Borrar_CalidadListasControlItemsProductos_Productos', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadEnviosOC_PedidosProveedores') = 1 EXECUTE sp_rename 'dbo.FK_CalidadEnviosOC_PedidosProveedores', 'FK_Borrar_CalidadEnviosOC_PedidosProveedores', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadEnviosOC_PedidosProveedores') = 1 EXECUTE sp_rename 'dbo.FK_CalidadEnviosOC_PedidosProveedores', 'FK_Borrar_CalidadEnviosOC_PedidosProveedores', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadEnviosOC_PedidosProveedores') = 1 EXECUTE sp_rename 'dbo.FK_CalidadEnviosOC_PedidosProveedores', 'FK_Borrar_CalidadEnviosOC_PedidosProveedores', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadEnviosOC_PedidosProveedores') = 1 EXECUTE sp_rename 'dbo.FK_CalidadEnviosOC_PedidosProveedores', 'FK_Borrar_CalidadEnviosOC_PedidosProveedores', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadEnviosOC_PedidosProveedores') = 1 EXECUTE sp_rename 'dbo.FK_CalidadEnviosOC_PedidosProveedores', 'FK_Borrar_CalidadEnviosOC_PedidosProveedores', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadEnviosOC_Usuarios') = 1 EXECUTE sp_rename 'dbo.FK_CalidadEnviosOC_Usuarios', 'FK_Borrar_CalidadEnviosOC_Usuarios', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadMetasTiposListas_CalidadListasControlTipos') = 1 EXECUTE sp_rename 'dbo.FK_CalidadMetasTiposListas_CalidadListasControlTipos', 'FK_Borrar_CalidadMetasTiposListas_CalidadListasControlTipos', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadMetasTiposListas_Usuarios') = 1 EXECUTE sp_rename 'dbo.FK_CalidadMetasTiposListas_Usuarios', 'FK_Borrar_CalidadMetasTiposListas_Usuarios', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadListasControlProductosModelos_CalidadListasControl') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControlProductosModelos_CalidadListasControl', 'FK_Borrar_CalidadListasControlProductosModelos_CalidadListasControl', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadListasControlRoles_CalidadListasControl') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControlRoles_CalidadListasControl', 'FK_Borrar_CalidadListasControlRoles_CalidadListasControl', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadListasControlProductosModelos_CalidadProductosModelos') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControlProductosModelos_CalidadProductosModelos', 'FK_Borrar_CalidadListasControlProductosModelos_CalidadProductosModelos', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadListasControlRoles_Roles') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControlRoles_Roles', 'FK_Borrar_CalidadListasControlRoles_Roles', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadListasControlProductosModelos_Usuarios') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControlProductosModelos_Usuarios', 'FK_Borrar_CalidadListasControlProductosModelos_Usuarios', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadListasControlProductosItems_Usuarios') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControlProductosItems_Usuarios', 'FK_Borrar_CalidadListasControlProductosItems_Usuarios', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadListasControlProductosItems2_Usuarios') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControlProductosItems2_Usuarios', 'FK_Borrar_CalidadListasControlProductosItems2_Usuarios', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadListasControlProductosItemsProceso_Usuarios') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControlProductosItemsProceso_Usuarios', 'FK_Borrar_CalidadListasControlProductosItemsProceso_Usuarios', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadListasControlProductosItemsProceso2_Usuarios') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControlProductosItemsProceso2_Usuarios', 'FK_Borrar_CalidadListasControlProductosItemsProceso2_Usuarios', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadPlantillasListasControl_CalidadListasControl') = 1 EXECUTE sp_rename 'dbo.FK_CalidadPlantillasListasControl_CalidadListasControl', 'FK_Borrar_CalidadPlantillasListasControl_CalidadListasControl', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadPlantillasListasControl_CalidadPlantillas') = 1 EXECUTE sp_rename 'dbo.FK_CalidadPlantillasListasControl_CalidadPlantillas', 'FK_Borrar_CalidadPlantillasListasControl_CalidadPlantillas', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadListasControlConfigLinks_CalidadListasControl') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControlConfigLinks_CalidadListasControl', 'FK_Borrar_CalidadListasControlConfigLinks_CalidadListasControl', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadListasControlConfigLinks_CalidadListasControlItems') = 1 EXECUTE sp_rename 'dbo.FK_CalidadListasControlConfigLinks_CalidadListasControlItems', 'FK_Borrar_CalidadListasControlConfigLinks_CalidadListasControlItems', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadProductosModelosSubTipos_CalidadProductosModelosTipos') = 1 EXECUTE sp_rename 'dbo.FK_CalidadProductosModelosSubTipos_CalidadProductosModelosTipos', 'FK_Borrar_CalidadProductosModelosSubTipos_CalidadProductosModelosTipos', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadEnviosOCErrores_PedidosProveedores') = 1 EXECUTE sp_rename 'dbo.FK_CalidadEnviosOCErrores_PedidosProveedores', 'FK_Borrar_CalidadEnviosOCErrores_PedidosProveedores', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadEnviosOCErrores_PedidosProveedores') = 1 EXECUTE sp_rename 'dbo.FK_CalidadEnviosOCErrores_PedidosProveedores', 'FK_Borrar_CalidadEnviosOCErrores_PedidosProveedores', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadEnviosOCErrores_PedidosProveedores') = 1 EXECUTE sp_rename 'dbo.FK_CalidadEnviosOCErrores_PedidosProveedores', 'FK_Borrar_CalidadEnviosOCErrores_PedidosProveedores', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadEnviosOCErrores_PedidosProveedores') = 1 EXECUTE sp_rename 'dbo.FK_CalidadEnviosOCErrores_PedidosProveedores', 'FK_Borrar_CalidadEnviosOCErrores_PedidosProveedores', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadEnviosOCErrores_PedidosProveedores') = 1 EXECUTE sp_rename 'dbo.FK_CalidadEnviosOCErrores_PedidosProveedores', 'FK_Borrar_CalidadEnviosOCErrores_PedidosProveedores', 'OBJECT' 
IF dbo.ExisteFK('FK_CalidadProductosModelos_CalidadProductosModelosTipos') = 1 EXECUTE sp_rename 'dbo.FK_CalidadProductosModelos_CalidadProductosModelosTipos', 'FK_Borrar_CalidadProductosModelos_CalidadProductosModelosTipos', 'OBJECT' 

/****** Object:  Table dbo.Borrar_CalidadListasControlTipos    Script Date: 24/4/2024 08:41:06 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
IF dbo.ExisteTabla('CalidadListasControlTipos') = 0
BEGIN
    CREATE TABLE CalidadListasControlTipos(
	    IdListaControlTipo int NOT NULL,
	    NombreListaControlTipo varchar(100) NOT NULL,
     CONSTRAINT PK_CalidadListasControlTipos PRIMARY KEY CLUSTERED (IdListaControlTipo ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM CalidadListasControlTipos)
BEGIN
    INSERT INTO CalidadListasControlTipos (IdListaControlTipo, NombreListaControlTipo)
                                   VALUES (1, 'General')
END
GO

IF dbo.ExisteTabla('CalidadListasControl') = 0
BEGIN
    CREATE TABLE CalidadListasControl(
	    IdListaControl int NOT NULL,
	    NombreListaControl varchar(100) NOT NULL,
	    Orden int NOT NULL,
	    IdListaControlTipo int NOT NULL,
     CONSTRAINT PK_CalidadListasControl PRIMARY KEY CLUSTERED (IdListaControl ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_CalidadListasControl_CalidadListasControlTipos') = 0
BEGIN
    ALTER TABLE dbo.CalidadListasControl  WITH CHECK ADD  CONSTRAINT FK_CalidadListasControl_CalidadListasControlTipos FOREIGN KEY(IdListaControlTipo)
    REFERENCES dbo.CalidadListasControlTipos (IdListaControlTipo)
    ALTER TABLE dbo.CalidadListasControl CHECK CONSTRAINT FK_CalidadListasControl_CalidadListasControlTipos
END
GO

IF NOT EXISTS(SELECT * FROM CalidadListasControl)
BEGIN
    INSERT INTO CalidadListasControl (IdListaControl, NombreListaControl, Orden, IdListaControlTipo)
     VALUES
           (1, 'Lista 1', 1, 1),
           (2, 'Lista 2', 2, 1)
END
GO

IF dbo.ExisteTabla('CalidadListasControlItemsGrupos') = 0
BEGIN
    CREATE TABLE CalidadListasControlItemsGrupos(
	    IdListaControlItemGrupo varchar(20) NOT NULL,
	    NombreListaControlItemGrupo varchar(100) NOT NULL,
     CONSTRAINT PK_Borrar_CalidadListasControlItemsGrupos PRIMARY KEY CLUSTERED (IdListaControlItemGrupo ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM CalidadListasControlItemsGrupos)
BEGIN
    INSERT INTO CalidadListasControlItemsGrupos
               (IdListaControlItemGrupo, NombreListaControlItemGrupo)
        VALUES ('GRP-1', 'Grupo 1'),
               ('GRP-2', 'Grupo 2'),
               ('GRP-3', 'Grupo 3')
END
GO

IF dbo.ExisteTabla('CalidadListasControlItemsSubGrupos') = 0
BEGIN
    CREATE TABLE CalidadListasControlItemsSubGrupos(
	    IdListaControlItemGrupo varchar(20) NOT NULL,
	    IdListaControlItemSubGrupo varchar(20) NOT NULL,
	    NombreListaControlItemSubGrupo varchar(100) NOT NULL,
     CONSTRAINT PK_CalidadListasControlItemsSubGrupos PRIMARY KEY CLUSTERED (IdListaControlItemGrupo ASC, IdListaControlItemSubGrupo ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_CalidadListasControlItemsSubGrupos_CalidadListasControlItemsGrupos') = 0
BEGIN
    ALTER TABLE dbo.CalidadListasControlItemsSubGrupos  WITH CHECK ADD  CONSTRAINT FK_CalidadListasControlItemsSubGrupos_CalidadListasControlItemsGrupos FOREIGN KEY(IdListaControlItemGrupo)
                REFERENCES dbo.CalidadListasControlItemsGrupos (IdListaControlItemGrupo)
    ALTER TABLE dbo.CalidadListasControlItemsSubGrupos CHECK CONSTRAINT FK_CalidadListasControlItemsSubGrupos_CalidadListasControlItemsGrupos
END
GO

IF NOT EXISTS(SELECT * FROM CalidadListasControlItemsSubGrupos)
BEGIN
    INSERT INTO CalidadListasControlItemsSubGrupos
               (IdListaControlItemGrupo, IdListaControlItemSubGrupo, NombreListaControlItemSubGrupo)
        VALUES ('GRP-2', 'SGRP-2-1', 'Sub Grupo 2 / 1')
END
GO

IF dbo.SoyHAR() = 1 OR dbo.BaseConCuit('30708470550') = 1
BEGIN
    IF dbo.ExisteFuncion('Calidad') = 0
    BEGIN
        INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
        VALUES
            ('Calidad', 'Calidad', 'Calidad', 'True', 'False', 'True', 'True'
            ,NULL, 50, NULL, NULL, NULL, NULL
            ,'True', 'S', 'N', 'N', 'N', 'True')

        INSERT INTO RolesFunciones (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'Calidad' AS Pantalla FROM dbo.Roles
         WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END
END
GO

IF dbo.ExisteFuncion('Calidad') = 1 AND dbo.ExisteFuncion('CalidadListasControlABM') = 0
BEGIN
    INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
        VALUES
            ('CalidadListasControlABM', 'ABM de Listas de Control', 'ABM de Listas de Control', 'True', 'False', 'True', 'True'
            ,'Calidad', 2100, 'Eniac.Win', 'CalidadListasControlABM', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'CalidadListasControlABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

IF dbo.ExisteFuncion('Calidad') = 1 AND dbo.ExisteFuncion('CalidadListasControlItemsABM') = 0
BEGIN
    INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
        VALUES
            ('CalidadListasControlItemsABM', 'ABM Items de Listas de Control', 'ABM Items de Listas de Control', 'True', 'False', 'True', 'True'
            ,'Calidad', 2130, 'Eniac.Win', 'CalidadListasControlItemsABM', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'CalidadListasControlItemsABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

/****** Object:  Table dbo.Borrar_CalidadListasControlItems    Script Date: 25/4/2024 09:31:28 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

IF dbo.ExisteTabla('CalidadListasControlItems') = 0
BEGIN
    CREATE TABLE CalidadListasControlItems(
	    IdListaControlItem int NOT NULL,
	    NombreListaControlItem varchar(100) NOT NULL,
	    IdListaControlItemGrupo varchar(20) NOT NULL,
	    IdListaControlItemSubGrupo varchar(20) NULL,
        NivelInspeccion varchar(10) NOT NULL,
        ValorAQL decimal(6,2) NOT NULL,
        Observacion varchar(MAX) NOT NULL,
     CONSTRAINT PK_CalidadListasControlItems PRIMARY KEY CLUSTERED (IdListaControlItem ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_CalidadListasControlItems_CalidadListasControlItemsGrupos') = 0
BEGIN
    ALTER TABLE dbo.CalidadListasControlItems WITH CHECK ADD  CONSTRAINT FK_CalidadListasControlItems_CalidadListasControlItemsGrupos FOREIGN KEY(IdListaControlItemGrupo)
    REFERENCES dbo.CalidadListasControlItemsGrupos (IdListaControlItemGrupo)

    ALTER TABLE dbo.CalidadListasControlItems CHECK CONSTRAINT FK_CalidadListasControlItems_CalidadListasControlItemsGrupos
END
GO

IF dbo.ExisteFK('FK_CalidadListasControlItems_CalidadListasControlItemsSubGrupos') = 0
BEGIN
    ALTER TABLE dbo.CalidadListasControlItems WITH CHECK ADD  CONSTRAINT FK_CalidadListasControlItems_CalidadListasControlItemsSubGrupos FOREIGN KEY(IdListaControlItemGrupo, IdListaControlItemSubGrupo)
    REFERENCES dbo.CalidadListasControlItemsSubGrupos (IdListaControlItemGrupo, IdListaControlItemSubGrupo)

    ALTER TABLE dbo.CalidadListasControlItems CHECK CONSTRAINT FK_CalidadListasControlItems_CalidadListasControlItemsSubGrupos
END
GO

IF NOT EXISTS(SELECT * FROM CalidadListasControlItems)
BEGIN
    INSERT CalidadListasControlItems (IdListaControlItem, NombreListaControlItem, IdListaControlItemGrupo, IdListaControlItemSubGrupo, NivelInspeccion, ValorAQL, Observacion) 
                              VALUES (1, 'Item 1', 'GRP-1', NULL, 'I',   1, ''),
                                     (2, 'Item 2', 'GRP-1', NULL, 'II',  5, ''),
                                     (3, 'Item 3', 'GRP-3', NULL, 'III', 9, ''),
                                     (4, 'Item 4', 'GRP-3', NULL, 'SI', 10, ''),
                                     (5, 'Item 5', 'GRP-2', 'SGRP-2-1', 'S2', 15, ''),
                                     (6, 'Item 6', 'GRP-2', 'SGRP-2-1', 'S3', 20, '')
END
GO

/****** Object:  Table dbo.Borrar_CalidadListasControlConfig    Script Date: 25/4/2024 17:50:12 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

IF dbo.ExisteTabla('CalidadListasControlConfig') = 0
BEGIN
    CREATE TABLE CalidadListasControlConfig(
	    IdListaControl int NOT NULL,
	    IdListaControlItem int NOT NULL,
	    Orden int NOT NULL,
     CONSTRAINT PK_CalidadListasControlConfig PRIMARY KEY CLUSTERED (IdListaControl ASC, IdListaControlItem ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_CalidadListasControlConfig_CalidadListasControl') = 0
BEGIN
    ALTER TABLE dbo.CalidadListasControlConfig  WITH CHECK ADD  CONSTRAINT FK_CalidadListasControlConfig_CalidadListasControl FOREIGN KEY(IdListaControl)
        REFERENCES dbo.CalidadListasControl (IdListaControl)
    ALTER TABLE dbo.CalidadListasControlConfig CHECK CONSTRAINT FK_CalidadListasControlConfig_CalidadListasControl
END
GO

IF dbo.ExisteFK('FK_CalidadListasControlConfig_CalidadListasControlItems') = 0
BEGIN
    ALTER TABLE dbo.CalidadListasControlConfig  WITH CHECK ADD  CONSTRAINT FK_CalidadListasControlConfig_CalidadListasControlItems FOREIGN KEY(IdListaControlItem)
        REFERENCES dbo.CalidadListasControlItems (IdListaControlItem)
    ALTER TABLE dbo.CalidadListasControlConfig CHECK CONSTRAINT FK_CalidadListasControlConfig_CalidadListasControlItems
END
GO

IF NOT EXISTS (SELECT * FROM CalidadListasControlConfig)
BEGIN
    INSERT INTO CalidadListasControlConfig
               (IdListaControl, IdListaControlItem, Orden)
         VALUES
               (1, 1, 10), (1, 2, 20), (1, 3, 30), (1, 4, 40),
               (2, 3, 10), (2, 4, 20), (2, 5, 30), (2, 6, 40)
END
GO

IF dbo.ExisteTabla('Borrar_CalidadProductosModelos') = 1 EXECUTE sp_rename 'dbo.Borrar_CalidadProductosModelos', 'CalidadProductosModelos', 'OBJECT' 

DELETE Bitacora WHERE IdFuncion IN ('ConcesionarioOperacionesABM', 'Concesionarios')
DELETE Bitacora WHERE IdFuncion IN ('ConcesionarioSincronizacionM', 'Concesionarios')
DELETE RolesFunciones WHERE IdFuncion IN ('ConcesionarioOperacionesABM', 'Concesionarios')
DELETE RolesFunciones WHERE IdFuncion IN ('ConcesionarioSincronizacionM', 'Concesionarios')
DELETE Funciones WHERE Id IN ('ConcesionarioSincronizacionM')
DELETE Funciones WHERE Id IN ('ConcesionarioOperacionesABM')
DELETE Funciones WHERE Id IN ('Concesionarios')

PRINT ''
PRINT 'F1. Nuevo Menu Sincronizacion Movil'
IF dbo.BaseConCuit('30701513890') = 1 OR dbo.SoyHAR() = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('Concesionarios', 'Concesionarios', 'Concesionarios', 'True', 'False', 'True', 'True'
        ,NULL, 100, '', '', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'Concesionarios' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT 'F1. Nuevo Menu Sincronizacion Movil'
IF dbo.ExisteFuncion('Concesionarios') = 1 AND dbo.ExisteFuncion('ConcesionarioOperacionesABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('ConcesionarioOperacionesABM', 'Operaciones', 'Operaciones', 'True', 'False', 'True', 'True'
        ,'Concesionarios', 100, 'Eniac.Win', 'ConcesionarioOperacionesABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ConcesionarioOperacionesABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT 'F1. Nuevo Menu Sincronizacion Movil'
IF dbo.ExisteFuncion('Concesionarios') = 1 AND dbo.ExisteFuncion('ConcesionarioSincronizacionM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('ConcesionarioSincronizacionM', 'Sincronización Movil', 'Sincronización Movil', 'True', 'False', 'True', 'True'
        , 'Concesionarios', 200, 'Eniac.Win', 'SincronizacionOperaciones', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ConcesionarioSincronizacionM' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '3. Parametro: Concesionario: URL Base'
DECLARE @idParametro VARCHAR(MAX) = 'CONCESIONARIOMOVILURLBASE'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Concesionarios: Establece la URL base de conexión'
DECLARE @valorParametro VARCHAR(MAX) = 'http://alcorta_test.sinergiamovil.com.ar/api/Sync/'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, 'MRP', ORIG.DescripcionParametro)
;
GO

PRINT ''
PRINT '3. Parametro: Concesionario: Usuario Base'
DECLARE @idParametro VARCHAR(MAX) = 'CONCESIONARIOMOVILUSUARIO'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Concesionarios: Establece el Usuario base de conexión'
DECLARE @valorParametro VARCHAR(MAX) = '-'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, 'MRP', ORIG.DescripcionParametro)
;
GO

PRINT ''
PRINT '3. Parametro: Concesionario: Clave Base'
DECLARE @idParametro VARCHAR(MAX) = 'CONCESIONARIOMOVILCLAVE'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Concesionarios: Establece la Clave base de conexión'
DECLARE @valorParametro VARCHAR(MAX) = '-'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, 'MRP', ORIG.DescripcionParametro)
;
GO
