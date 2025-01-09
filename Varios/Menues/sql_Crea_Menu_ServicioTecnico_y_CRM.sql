-----------------------------------------------------------------------------------------------------------------------------------------------
PRINT 'Activar Módulo CRM SIGA-MD'

IF dbo.ExisteFuncion('CRM') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRM', 'CRM', '', 1, 0, 1, 1, NULL, 175, NULL, NULL, NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRM')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRM')
    PRINT ''
    PRINT '1 Se agregó función CRM'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRM'
    PRINT ''
    PRINT '1 Ya existía la función CRM'
    END

IF dbo.ExisteFuncion('CRMAuditorias') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMAuditorias', 'Auditorias de ...', 'Auditorias de ...', 1, 0, 1, 1, 'CRM', 5, NULL, NULL, NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMAuditorias')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMAuditorias')
    PRINT ''
    PRINT '2. Se agregó función CRMAuditorias'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMAuditorias'
    PRINT ''
    PRINT '2. Ya existía la función CRMAuditorias'
    END

IF dbo.ExisteFuncion('InfAuditoriaCRMCRM') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InfAuditoriaCRMCRM', 'Inf. Auditoría de CRM', 'Inf. Auditoría de CRM', 1, 0, 1, 1, 'CRMAuditorias', 10, 'Eniac.Win', 'InfAuditoriaCRMNovedades', NULL, 'CRM', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InfAuditoriaCRMCRM')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InfAuditoriaCRMCRM')
    PRINT ''
    PRINT '2.1 Se agregó función InfAuditoriaCRMCRM'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InfAuditoriaCRMCRM'
    PRINT ''
    PRINT '2.1 Ya existía la función InfAuditoriaCRMCRM'
    END

IF dbo.ExisteFuncion('InfAuditoriaCRMPROSP') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InfAuditoriaCRMPROSP', 'Inf. Auditoría de Prospectos', 'Inf. Auditoría de Prospectos', 1, 0, 1, 1, 'CRMAuditorias', 20, 'Eniac.Win', 'InfAuditoriaCRMNovedades', NULL, 'PROSP', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InfAuditoriaCRMPROSP')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InfAuditoriaCRMPROSP')
    PRINT ''
    PRINT '2.2 Se agregó función InfAuditoriaCRMPROSP'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InfAuditoriaCRMPROSP'
    PRINT ''
    PRINT '2.2 Ya existía la función InfAuditoriaCRMPROSP'
    END

IF dbo.ExisteFuncion('InfAuditoriaCRMRECCLTE') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InfAuditoriaCRMRECCLTE', 'Inf. Auditoría de Reclamos', 'Inf. Auditoría de Reclamos', 1, 0, 1, 1, 'CRMAuditorias', 20, 'Eniac.Win', 'InfAuditoriaCRMNovedades', NULL, 'RECCLTE', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InfAuditoriaCRMRECCLTE')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InfAuditoriaCRMRECCLTE')
    PRINT ''
    PRINT '2.3 Se agregó función InfAuditoriaCRMRECCLTE'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InfAuditoriaCRMRECCLTE'
    PRINT ''
    PRINT '2.3 Ya existía la función InfAuditoriaCRMRECCLTE'
    END

IF dbo.ExisteFuncion('InfAuditoriaCRMRECPROV') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InfAuditoriaCRMRECPROV', 'Inf. Auditoría de Reclamo a Proveedores', 'Inf. Auditoría de Reclamo a Proveedores', 1, 0, 1, 1, 'CRMAuditorias', 20, 'Eniac.Win', 'InfAuditoriaCRMNovedades', NULL, 'RECPROV', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InfAuditoriaCRMRECPROV')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InfAuditoriaCRMRECPROV')
    PRINT ''
    PRINT '2.4 Se agregó función InfAuditoriaCRMRECPROV'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InfAuditoriaCRMRECPROV'
    PRINT ''
    PRINT '2.4 Ya existía la función InfAuditoriaCRMRECPROV'
    END

IF dbo.ExisteFuncion('InfAuditoriaCRMSERVICE') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InfAuditoriaCRMSERVICE', 'Inf. Auditoría de Servicio Técnico', 'Inf. Auditoría de Servicio Técnico', 1, 0, 1, 1, 'CRMAuditorias', 20, 'Eniac.Win', 'InfAuditoriaCRMNovedades', NULL, 'SERVICE', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InfAuditoriaCRMSERVICE')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InfAuditoriaCRMSERVICE')
    PRINT ''
    PRINT '2.5 Se agregó función InfAuditoriaCRMSERVICE'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InfAuditoriaCRMSERVICE'
    PRINT ''
    PRINT '2.5 Ya existía la función InfAuditoriaCRMSERVICE'
    END

IF dbo.ExisteFuncion('CRMNovedadesABMCRM') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMNovedadesABMCRM', 'CRM', 'CRM', 1, 0, 1, 1, 'CRM', 20, 'Eniac.Win', 'CRMNovedadesABM', NULL, 'TipoNovedad=CRM', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMNovedadesABMCRM')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMNovedadesABMCRM')
    PRINT ''
    PRINT '3 Se agregó función CRMNovedadesABMCRM'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMNovedadesABMCRM'
    PRINT ''
    PRINT '3 Ya existía la función CRMNovedadesABMCRM'
    END

IF dbo.ExisteFuncion('CRMNovedadesABMRECCLTE') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMNovedadesABMRECCLTE', 'Reclamos de Clientes', 'Reclamos de Clientes', 1, 0, 1, 1, 'CRM', 30, 'Eniac.Win', 'CRMNovedadesABM', NULL, 'TipoNovedad=RECCLTE', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMNovedadesABMRECCLTE')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMNovedadesABMRECCLTE')
    PRINT ''
    PRINT '4 Se agregó función CRMNovedadesABMRECCLTE'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMNovedadesABMRECCLTE'
    PRINT ''
    PRINT '4 Ya existía la función CRMNovedadesABMRECCLTE'
    END

IF dbo.ExisteFuncion('CRMNovedadesABMPROSP') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMNovedadesABMPROSP', 'Seguimiento de Prospectos', 'Seguimiento de Prospectos', 1, 0, 1, 1, 'CRM', 40, 'Eniac.Win', 'CRMNovedadesABM', NULL, 'TipoNovedad=PROSP', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMNovedadesABMPROSP')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMNovedadesABMPROSP')
    PRINT ''
    PRINT '5 Se agregó función CRMNovedadesABMPROSP'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMNovedadesABMPROSP'
    PRINT ''
    PRINT '5 Ya existía la función CRMNovedadesABMPROSP'
    END

IF dbo.ExisteFuncion('CRMNovedadesABMRECPROV') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMNovedadesABMRECPROV', 'Reclamos a Proveedores', 'Reclamos a Proveedores', 1, 0, 1, 1, 'CRM', 50, 'Eniac.Win', 'CRMNovedadesABM', NULL, 'TipoNovedad=RECPROV', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMNovedadesABMRECPROV')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMNovedadesABMRECPROV')
    PRINT ''
    PRINT '6 Se agregó función CRMNovedadesABMRECPROV'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMNovedadesABMRECPROV'
    PRINT ''
    PRINT '6 Ya existía la función CRMNovedadesABMRECPROV'
    END

IF dbo.ExisteFuncion('CRMClientesGestion') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMClientesGestion', 'Gestion de Clientes', 'Gestion de Clientes', 1, 0, 1, 1, 'CRM', 60, 'Eniac.Win', 'CRMClientesGestion', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMClientesGestion')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMClientesGestion')
    PRINT ''
    PRINT '7 Se agregó función CRMClientesGestion'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMClientesGestion'
    PRINT ''
    PRINT '7 Ya existía la función CRMClientesGestion'
    END

IF dbo.ExisteFuncion('CRMTiposEstadosNovedades') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMTiposEstadosNovedades', 'ABM  de Tipos Estados Novedades', 'ABM  de Tipos Estados Novedades', 1, 0, 1, 1, 'CRM', 595, 'Eniac.Win', 'CRMTiposEstadosNovedadesABM', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMTiposEstadosNovedades')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMTiposEstadosNovedades')
    PRINT ''
    PRINT '8 Se agregó función CRMTiposEstadosNovedades'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMTiposEstadosNovedades'
    PRINT ''
    PRINT '8 Ya existía la función CRMTiposEstadosNovedades'
    END

IF dbo.ExisteFuncion('CRMArchivarAdjuntos') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMArchivarAdjuntos', 'Archivar Adjuntos de CRM', 'Archivar Adjuntos de CRM', 1, 0, 1, 1, 'CRM', 850, 'Eniac.Win', 'CRMArchivarAdjuntos', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMArchivarAdjuntos')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMArchivarAdjuntos')
    PRINT ''
    PRINT '9 Se agregó función CRMArchivarAdjuntos'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMArchivarAdjuntos'
    PRINT ''
    PRINT '9 Ya existía la función CRMArchivarAdjuntos'
    END

IF dbo.ExisteFuncion('CRMABMs') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMABMs', 'CRM ABMs', 'CRM ABMs', 1, 0, 1, 1, 'CRM', 900, NULL, NULL, NULL, NULL, 0, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMABMs')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMABMs')
    PRINT ''
    PRINT '10 Se agregó función CRMABMs'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMABMs'
    PRINT ''
    PRINT '10 Ya existía la función CRMABMs'
    END

IF dbo.ExisteFuncion('CRMCategoriasNovedadesABM') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMCategoriasNovedadesABM', 'ABM de Categorias Novedades', 'ABM de Categorias Novedades', 1, 0, 1, 1, 'CRMABMs', 110, 'Eniac.Win', 'CRMCategoriasNovedadesABM', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMCategoriasNovedadesABM')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMCategoriasNovedadesABM')
    PRINT ''
    PRINT '10.1 Se agregó función CRMCategoriasNovedadesABM'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMCategoriasNovedadesABM'
    PRINT ''
    PRINT '10.1 Ya existía la función CRMCategoriasNovedadesABM'
    END

IF dbo.ExisteFuncion('CRMEstadosNovedadesABM') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMEstadosNovedadesABM', 'ABM de Estados Novedades', 'ABM de Estados Novedades', 1, 0, 1, 1, 'CRMABMs', 120, 'Eniac.Win', 'CRMEstadosNovedadesABM', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMEstadosNovedadesABM')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMEstadosNovedadesABM')
    PRINT ''
    PRINT '10.2 Se agregó función CRMEstadosNovedadesABM'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMEstadosNovedadesABM'
    PRINT ''
    PRINT '10.2 Ya existía la función CRMEstadosNovedadesABM'
    END

IF dbo.ExisteFuncion('CRMMediosComunicacionesABM') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMMediosComunicacionesABM', 'ABM de Medios Comunicación', 'ABM de Medios Comunicación', 1, 0, 1, 1, 'CRMABMs', 130, 'Eniac.Win', 'CRMMediosComunicacionesNovedadesABM', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMMediosComunicacionesABM')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMMediosComunicacionesABM')
    PRINT ''
    PRINT '10.3 Se agregó función CRMMediosComunicacionesABM'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMMediosComunicacionesABM'
    PRINT ''
    PRINT '10.3 Ya existía la función CRMMediosComunicacionesABM'
    END

IF dbo.ExisteFuncion('CRMMetodosResolucionesABM') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMMetodosResolucionesABM', 'ABM de Metodos Resolucion', 'ABM de Metodos Resolucion', 1, 0, 1, 1, 'CRMABMs', 140, 'Eniac.Win', 'CRMMetodosResolucionesNovedadesABM', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMMetodosResolucionesABM')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMMetodosResolucionesABM')
    PRINT ''
    PRINT '10.4 Se agregó función CRMMetodosResolucionesABM'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMMetodosResolucionesABM'
    PRINT ''
    PRINT '10.4 Ya existía la función CRMMetodosResolucionesABM'
    END

IF dbo.ExisteFuncion('CRMMotivosNovedadesABM') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMMotivosNovedadesABM', 'ABM Motivos de Novedades', 'ABM Motivos de Novedades', 1, 0, 1, 1, 'CRMABMs', 145, 'Eniac.Win', 'CRMMotivosNovedadesABM', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMMotivosNovedadesABM')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMMotivosNovedadesABM')
    PRINT ''
    PRINT '10.5 Se agregó función CRMMotivosNovedadesABM'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMMotivosNovedadesABM'
    PRINT ''
    PRINT '10.5 Ya existía la función CRMMotivosNovedadesABM'
    END

IF dbo.ExisteFuncion('CRMPrioridadesNovedadesABM') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMPrioridadesNovedadesABM', 'ABM de Prioridades', 'ABM de Prioridades', 1, 0, 1, 1, 'CRMABMs', 150, 'Eniac.Win', 'CRMPrioridadesNovedadesABM', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMPrioridadesNovedadesABM')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMPrioridadesNovedadesABM')
    PRINT ''
    PRINT '10.6 Se agregó función CRMPrioridadesNovedadesABM'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMPrioridadesNovedadesABM'
    PRINT ''
    PRINT '10.6 Ya existía la función CRMPrioridadesNovedadesABM'
    END

IF dbo.ExisteFuncion('CRMTiposComentariosNovABM') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMTiposComentariosNovABM', 'ABM de Tipos de Comentarios', 'ABM de Tipos de Comentarios', 1, 0, 1, 1, 'CRMABMs', 160, 'Eniac.Win', 'CRMTiposComentariosNovedadesABM', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMTiposComentariosNovABM')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMTiposComentariosNovABM')
    PRINT ''
    PRINT '10.7 Se agregó función CRMTiposComentariosNovABM'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMTiposComentariosNovABM'
    PRINT ''
    PRINT '10.7 Ya existía la función CRMTiposComentariosNovABM'
    END

IF dbo.ExisteFuncion('CRMTiposNovedadesABM') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMTiposNovedadesABM', 'ABM de Tipos Novedades', 'ABM de Tipos Novedades', 1, 0, 1, 1, 'CRMABMs', 170, 'Eniac.Win', 'CRMTiposNovedadesABM', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMTiposNovedadesABM')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMTiposNovedadesABM')
    PRINT ''
    PRINT '10.8 Se agregó función CRMTiposNovedadesABM'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMTiposNovedadesABM'
    PRINT ''
    PRINT '10.8 Ya existía la función CRMTiposNovedadesABM'
    END

IF dbo.ExisteFuncion('CRMTiposNovedadesObjetivosABM') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMTiposNovedadesObjetivosABM', 'ABM de Tipos Novedades Objetivo', 'ABM de Tipos Novedades Objetivo', 1, 0, 1, 1, 'CRMABMs', 180, 'Eniac.Win', 'CRMTiposNovedadesObjetivosABM', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMTiposNovedadesObjetivosABM')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMTiposNovedadesObjetivosABM')
    PRINT ''
    PRINT '10.9 Se agregó función CRMTiposNovedadesObjetivosABM'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMTiposNovedadesObjetivosABM'
    PRINT ''
    PRINT '10.9 Ya existía la función CRMTiposNovedadesObjetivosABM'
    END

IF dbo.ExisteFuncion('CRMActualizacionMasiva') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMActualizacionMasiva', 'CRM - Actualizacion Masiva', 'CRM - Actualizacion Masiva', 1, 0, 1, 1, 'CRM', 900, 'Eniac.Win', 'CRMActualizacionMasiva', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMActualizacionMasiva')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMActualizacionMasiva')
    PRINT ''
    PRINT '11 Se agregó función CRMActualizacionMasiva'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMActualizacionMasiva'
    PRINT ''
    PRINT '11 Ya existía la función CRMActualizacionMasiva'
    END

IF dbo.ExisteFuncion('ImportarCRM') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('ImportarCRM', 'Importar Novedades de CRM desde Excel', 'Importar Novedades de CRM desde Excel', 1, 0, 1, 1, 'CRM', 900, 'Eniac.Win', 'ImportarCRM', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'ImportarCRM')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'ImportarCRM')
    PRINT ''
    PRINT '12 Se agregó función ImportarCRM'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'ImportarCRM'
    PRINT ''
    PRINT '12 Ya existía la función ImportarCRM'
    END

IF dbo.ExisteFuncion('CRMInformes') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMInformes', 'CRM Informes', 'CRM Informes', 1, 0, 1, 1, 'CRM', 910, NULL, NULL, NULL, NULL, 0, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMInformes')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMInformes')
    PRINT ''
    PRINT '13 Se agregó función CRMInformes'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMInformes'
    PRINT ''
    PRINT '13 Ya existía la función CRMInformes'
    END

IF dbo.ExisteFuncion('InformeDeNovedadesCRM') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InformeDeNovedadesCRM', 'Informe de CRM', 'Informe de CRM', 1, 0, 1, 1, 'CRMInformes', 210, 'Eniac.Win', 'InformeDeNovedades', NULL, 'CRM', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InformeDeNovedadesCRM')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InformeDeNovedadesCRM')
    PRINT ''
    PRINT '13.1 Se agregó función InformeDeNovedadesCRM'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InformeDeNovedadesCRM'
    PRINT ''
    PRINT '13.1 Ya existía la función InformeDeNovedadesCRM'
    END

IF dbo.ExisteFuncion('InformeDeNovedadesPROSP') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InformeDeNovedadesPROSP', 'Informe de Seguimiento de Prospectos', 'Informe de Seguimiento de Prospectos', 1, 0, 1, 1, 'CRMInformes', 230, 'Eniac.Win', 'InformeDeNovedades', NULL, 'PROSP', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InformeDeNovedadesPROSP')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InformeDeNovedadesPROSP')
    PRINT ''
    PRINT '13.2 Se agregó función InformeDeNovedadesPROSP'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InformeDeNovedadesPROSP'
    PRINT ''
    PRINT '13.2 Ya existía la función InformeDeNovedadesPROSP'
    END

IF dbo.ExisteFuncion('InformeDeNovedadesRECCLTE') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InformeDeNovedadesRECCLTE', 'Informe de Soporte', 'Informe de Soporte', 1, 0, 1, 1, 'CRMInformes', 220, 'Eniac.Win', 'InformeDeNovedades', NULL, 'RECCLTE', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InformeDeNovedadesRECCLTE')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InformeDeNovedadesRECCLTE')
    PRINT ''
    PRINT '13.3 Se agregó función InformeDeNovedadesRECCLTE'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InformeDeNovedadesRECCLTE'
    PRINT ''
    PRINT '13.3 Ya existía la función InformeDeNovedadesRECCLTE'
    END

IF dbo.ExisteFuncion('InformeDeNovedadesRECPROV') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InformeDeNovedadesRECPROV', 'Informe de Reclamos a Proveedores', 'Informe de Reclamos a Proveedores', 1, 0, 1, 1, 'CRMInformes', 240, 'Eniac.Win', 'InformeDeNovedades', NULL, 'RECPROV', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InformeDeNovedadesRECPROV')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InformeDeNovedadesRECPROV')
    PRINT ''
    PRINT '13.4 Se agregó función InformeDeNovedadesRECPROV'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InformeDeNovedadesRECPROV'
    PRINT ''
    PRINT '13.4 Ya existía la función InformeDeNovedadesRECPROV'
    END

IF dbo.ExisteFuncion('CRMInformesDetalle') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMInformesDetalle', 'CRM Informes Detalle', 'CRM Informes Detalle', 1, 0, 1, 1, 'CRM', 920, NULL, NULL, NULL, NULL, 0, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMInformesDetalle')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMInformesDetalle')
    PRINT ''
    PRINT '14 Se agregó función CRMInformesDetalle'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMInformesDetalle'
    PRINT ''
    PRINT '14 Ya existía la función CRMInformesDetalle'
    END

IF dbo.ExisteFuncion('InformeDeNovSeguimCRM') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InformeDeNovSeguimCRM', 'Informe de CRM Detallado', 'Informe de CRM Detallado', 1, 0, 1, 1, 'CRMInformesDetalle', 210, 'Eniac.Win', 'InformeDeNovedadesDetallado', NULL, 'CRM', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InformeDeNovSeguimCRM')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InformeDeNovSeguimCRM')
    PRINT ''
    PRINT '14.1 Se agregó función InformeDeNovSeguimCRM'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InformeDeNovSeguimCRM'
    PRINT ''
    PRINT '14.1 Ya existía la función InformeDeNovSeguimCRM'
    END

IF dbo.ExisteFuncion('InformeDeNovSeguimPROSP') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InformeDeNovSeguimPROSP', 'Informe de Seguimiento de Prospectos Detallado', 'Informe de Seguimiento de Prospectos Detallado', 1, 0, 1, 1, 'CRMInformesDetalle', 230, 'Eniac.Win', 'InformeDeNovedadesDetallado', NULL, 'PROSP', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InformeDeNovSeguimPROSP')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InformeDeNovSeguimPROSP')
    PRINT ''
    PRINT '14.2 Se agregó función InformeDeNovSeguimPROSP'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InformeDeNovSeguimPROSP'
    PRINT ''
    PRINT '14.2 Ya existía la función InformeDeNovSeguimPROSP'
    END

IF dbo.ExisteFuncion('InformeDeNovSeguimRECCLTE') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InformeDeNovSeguimRECCLTE', 'Informe de Reclamos de Clientes Detallado', 'Informe de Reclamos de Clientes Detallado', 1, 0, 1, 1, 'CRMInformesDetalle', 220, 'Eniac.Win', 'InformeDeNovedadesDetallado', NULL, 'RECCLTE', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InformeDeNovSeguimRECCLTE')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InformeDeNovSeguimRECCLTE')
    PRINT ''
    PRINT '14.3 Se agregó función InformeDeNovSeguimRECCLTE'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InformeDeNovSeguimRECCLTE'
    PRINT ''
    PRINT '14.3 Ya existía la función InformeDeNovSeguimRECCLTE'
    END

IF dbo.ExisteFuncion('InformeDeNovSeguimRECPROV') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InformeDeNovSeguimRECPROV', 'Informe de Reclamos a Proveedores Detallado', 'Informe de Reclamos a Proveedores Detallado', 1, 0, 1, 1, 'CRMInformesDetalle', 240, 'Eniac.Win', 'InformeDeNovedadesDetallado', NULL, 'RECPROV', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InformeDeNovSeguimRECPROV')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InformeDeNovSeguimRECPROV')
    PRINT ''
    PRINT '14.4 Se agregó función InformeDeNovSeguimRECPROV'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InformeDeNovSeguimRECPROV'
    PRINT ''
    PRINT '14.4 Ya existía la función InformeDeNovSeguimRECPROV'
    END

IF dbo.ExisteFuncion('CRMInformesEstado') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMInformesEstado', 'CRM Informes Estado', 'CRM Informes Estado', 1, 0, 1, 1, 'CRM', 930, NULL, NULL, NULL, NULL, 0, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMInformesEstado')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMInformesEstado')
    PRINT ''
    PRINT '15 Se agregó función CRMInformesEstado'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMInformesEstado'
    PRINT ''
    PRINT '15 Ya existía la función CRMInformesEstado'
    END

IF dbo.ExisteFuncion('InformeDeNovEstadosCRM') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InformeDeNovEstadosCRM', 'Informe de CRM Cambios de Estado', 'Informe de CRM Cambios de Estado', 1, 0, 1, 1, 'CRMInformesEstado', 210, 'Eniac.Win', 'InformeDeNovedadesEstado', NULL, 'CRM', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InformeDeNovEstadosCRM')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InformeDeNovEstadosCRM')
    PRINT ''
    PRINT '15.1 Se agregó función InformeDeNovEstadosCRM'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InformeDeNovEstadosCRM'
    PRINT ''
    PRINT '15.1 Ya existía la función InformeDeNovEstadosCRM'
    END

IF dbo.ExisteFuncion('InformeDeNovEstadosPROSP') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InformeDeNovEstadosPROSP', 'Informe de Prospectos Cambios de Estado', 'Informe de Prospectos Cambios de Estado', 1, 0, 1, 1, 'CRMInformesEstado', 220, 'Eniac.Win', 'InformeDeNovedadesEstado', NULL, 'PROSP', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InformeDeNovEstadosPROSP')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InformeDeNovEstadosPROSP')
    PRINT ''
    PRINT '15.2 Se agregó función InformeDeNovEstadosPROSP'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InformeDeNovEstadosPROSP'
    PRINT ''
    PRINT '15.2 Ya existía la función InformeDeNovEstadosPROSP'
    END

IF dbo.ExisteFuncion('InformeDeNovEstadosRECCLTE') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InformeDeNovEstadosRECCLTE', 'Informe de Reclamos Cambios de Estado', 'Informe de Reclamos Cambios de Estado', 1, 0, 1, 1, 'CRMInformesEstado', 230, 'Eniac.Win', 'InformeDeNovedadesEstado', NULL, 'RECCLTE', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InformeDeNovEstadosRECCLTE')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InformeDeNovEstadosRECCLTE')
    PRINT ''
    PRINT '15.3 Se agregó función InformeDeNovEstadosRECCLTE'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InformeDeNovEstadosRECCLTE'
    PRINT ''
    PRINT '15.3 Ya existía la función InformeDeNovEstadosRECCLTE'
    END

IF dbo.ExisteFuncion('InformeDeNovEstadosRECPROV') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InformeDeNovEstadosRECPROV', 'Informe de Reclamo a Proveedores Cambios de Estado', 'Informe de Reclamo a Proveedores Cambios de Estado', 1, 0, 1, 1, 'CRMInformesEstado', 240, 'Eniac.Win', 'InformeDeNovedadesEstado', NULL, 'RECPROV', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InformeDeNovEstadosRECPROV')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InformeDeNovEstadosRECPROV')
    PRINT ''
    PRINT '15.4 Se agregó función InformeDeNovEstadosRECPROV'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InformeDeNovEstadosRECPROV'
    PRINT ''
    PRINT '15.4 Ya existía la función InformeDeNovEstadosRECPROV'
    END

IF dbo.ExisteFuncion('CRMPlanificacion') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMPlanificacion', 'Planificación', 'Planificación', 1, 0, 1, 1, 'CRM', 940, 'Eniac.Win', '', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMPlanificacion')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMPlanificacion')
    PRINT ''
    PRINT '16 Se agregó función CRMPlanificacion'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMPlanificacion'
    PRINT ''
    PRINT '16 Ya existía la función CRMPlanificacion'
    END

IF dbo.ExisteFuncion('CiclosPlanificacionNovedades') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CiclosPlanificacionNovedades', 'Novedades de Ciclos de Planificación', 'Novedades de Ciclos de Planificación', 1, 0, 1, 1, 'CRMPlanificacion', 30, 'Eniac.Win', 'CRMCiclosPlanificacionNovedadesABM', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CiclosPlanificacionNovedades')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CiclosPlanificacionNovedades')
    PRINT ''
    PRINT '16.1 Se agregó función CiclosPlanificacionNovedades'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CiclosPlanificacionNovedades'
    PRINT ''
    PRINT '16.1 Ya existía la función CiclosPlanificacionNovedades'
    END

IF dbo.ExisteFuncion('CRMCiclosPlanificacionABM') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMCiclosPlanificacionABM', 'Ciclos de Planificación', 'Ciclos de Planificación', 1, 0, 1, 1, 'CRMPlanificacion', 10, 'Eniac.Win', 'CRMCiclosPlanificacionABM', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMCiclosPlanificacionABM')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMCiclosPlanificacionABM')
    PRINT ''
    PRINT '16.2 Se agregó función CRMCiclosPlanificacionABM'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMCiclosPlanificacionABM'
    PRINT ''
    PRINT '16.2 Ya existía la función CRMCiclosPlanificacionABM'
    END

IF dbo.ExisteFuncion('EstadosCiclosPlanificacionABM') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('EstadosCiclosPlanificacionABM', 'ABM Estados de Ciclos de Planificación', 'ABM Estados de Ciclos de Planificación', 1, 0, 1, 1, 'CRMPlanificacion', 500, 'Eniac.Win', 'CRMCiclosPlanificacionABM', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'EstadosCiclosPlanificacionABM')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'EstadosCiclosPlanificacionABM')
    PRINT ''
    PRINT '16.3 Se agregó función EstadosCiclosPlanificacionABM'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'EstadosCiclosPlanificacionABM'
    PRINT ''
    PRINT '16.3 Ya existía la función EstadosCiclosPlanificacionABM'
    END

-----------------------------------------------------------------------------------------------------------------------------------------------
PRINT 'Activar Módulo Servicio Técnico'

IF dbo.ExisteFuncion('ServicioTecnico') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('ServicioTecnico', 'Servicio Tecnico', 'Servicio Tecnico', 1, 0, 1, 1, NULL, 160, '', '', NULL, '', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'ServicioTecnico')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'ServicioTecnico')
    PRINT ''
    PRINT '1 Se agregó función ServicioTecnico'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'ServicioTecnico'
    PRINT ''
    PRINT '1 Ya existía la función ServicioTecnico'
    END

IF dbo.ExisteFuncion('CRMNovedadesABMSERVICE') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('CRMNovedadesABMSERVICE', 'ABM de Servicio Técnico', 'ABM de Servicio Técnico', 1, 1, 1, 1, 'ServicioTecnico', 10, 'Eniac.Win', 'CRMNovedadesABM', NULL, 'TipoNovedad=SERVICE', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'CRMNovedadesABMSERVICE')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'CRMNovedadesABMSERVICE')
    PRINT ''
    PRINT '1.1 Se agregó función CRMNovedadesABMSERVICE'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'CRMNovedadesABMSERVICE'
    PRINT ''
    PRINT '1.1 Ya existía la función CRMNovedadesABMSERVICE'
    END

IF dbo.ExisteFuncion('InfOrdenesReparacion') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InfOrdenesReparacion', 'Informe de Ordenes de Reparacion', 'Informe de Ordenes de Reparacion', 1, 0, 1, 1, 'ServicioTecnico', 210, 'Eniac.Win', 'InfOrdenesReparacion', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InfOrdenesReparacion')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InfOrdenesReparacion')
    PRINT ''
    PRINT '1.2 Se agregó función InfOrdenesReparacion'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InfOrdenesReparacion'
    PRINT ''
    PRINT '1.2 Ya existía la función InfOrdenesReparacion'
    END

IF dbo.ExisteFuncion('InfOrdenesTalleresExternos') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InfOrdenesTalleresExternos', 'Informe de Ordenes Talleres Externos', 'Informe de Ordenes Talleres Externos', 1, 0, 1, 1, 'ServicioTecnico', 220, 'Eniac.Win', 'InfOrdenesTalleresExternos', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InfOrdenesTalleresExternos')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InfOrdenesTalleresExternos')
    PRINT ''
    PRINT '1.3 Se agregó función InfOrdenesTalleresExternos'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InfOrdenesTalleresExternos'
    PRINT ''
    PRINT '1.3 Ya existía la función InfOrdenesTalleresExternos'
    END

IF dbo.ExisteFuncion('InformeDeNovedadesService') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InformeDeNovedadesService', 'Informe de Servicio Técnico', 'Informe de Servicio Técnico', 1, 0, 1, 1, 'ServicioTecnico', 110, 'Eniac.Win', 'InformeDeNovedades', NULL, 'SERVICE', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InformeDeNovedadesService')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InformeDeNovedadesService')
    PRINT ''
    PRINT '1.4 Se agregó función InformeDeNovedadesService'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InformeDeNovedadesService'
    PRINT ''
    PRINT '1.4 Ya existía la función InformeDeNovedadesService'
    END

IF dbo.ExisteFuncion('InformeDeNovEstadosSERVICE') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InformeDeNovEstadosSERVICE', 'Informe de Servicio Técnico Cambios de Estado', 'Informe de Servicio Técnico Cambios de Estado', 1, 0, 1, 1, 'ServicioTecnico', 120, 'Eniac.Win', 'InformeDeNovedadesEstado', NULL, 'SERVICE', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InformeDeNovEstadosSERVICE')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InformeDeNovEstadosSERVICE')
    PRINT ''
    PRINT '1.5 Se agregó función InformeDeNovEstadosSERVICE'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InformeDeNovEstadosSERVICE'
    PRINT ''
    PRINT '1.5 Ya existía la función InformeDeNovEstadosSERVICE'
    END

IF dbo.ExisteFuncion('InformeDeServiceDetallado') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InformeDeServiceDetallado', 'Informe de Servicio Técnico Detallado', 'Informe de Servicio Técnico Detallado', 1, 0, 1, 1, 'ServicioTecnico', 130, 'Eniac.Win', 'InformeDeNovedadesDetallado', NULL, 'SERVICE', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InformeDeServiceDetallado')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InformeDeServiceDetallado')
    PRINT ''
    PRINT '1.6 Se agregó función InformeDeServiceDetallado'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InformeDeServiceDetallado'
    PRINT ''
    PRINT '1.6 Ya existía la función InformeDeServiceDetallado'
    END

IF dbo.ExisteFuncion('InfRetirosEntregasADomicilio') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('InfRetirosEntregasADomicilio', 'Informe de Retiros Y Entregas a Domicilio', 'Informe de Retiros Y Entregas a Domicilio', 1, 0, 1, 1, 'ServicioTecnico', 230, 'Eniac.Win', 'InfRetirosEntregasADomicilio', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'InfRetirosEntregasADomicilio')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'InfRetirosEntregasADomicilio')
    PRINT ''
    PRINT '1.7 Se agregó función InfRetirosEntregasADomicilio'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'InfRetirosEntregasADomicilio'
    PRINT ''
    PRINT '1.7 Ya existía la función InfRetirosEntregasADomicilio'
    END

IF dbo.ExisteFuncion('SERVICE-PuedeEliminar') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('SERVICE-PuedeEliminar', 'Permitir Eliminar Novedades', 'Permitir Eliminar Novedades', 0, 0, 1, 0, 'CRMNovedadesABMSERVICE', 999, 'Eniac.Win', 'Novedades-PuedeEliminar', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'SERVICE-PuedeEliminar')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'SERVICE-PuedeEliminar')
    PRINT ''
    PRINT '2 Se agregó función SERVICE-PuedeEliminar'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 0, EsBoton = 0, Enabled = 1, Visible = 0 WHERE Id = 'SERVICE-PuedeEliminar'
    PRINT ''
    PRINT '2 Ya existía la función SERVICE-PuedeEliminar'
    END

IF dbo.ExisteFuncion('SERVICE-VerOtrosUsuarios') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('SERVICE-VerOtrosUsuarios', 'Permitir ver novedades de otros usuarios', 'Permitir ver novedades de otros usuarios', 0, 0, 1, 0, 'CRMNovedadesABMSERVICE', 999, 'Eniac.Win', 'Novedades-VerOtrosUsuarios', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'SERVICE-VerOtrosUsuarios')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'SERVICE-VerOtrosUsuarios')
    PRINT ''
    PRINT '3 Se agregó función SERVICE-VerOtrosUsuarios'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 0, EsBoton = 0, Enabled = 1, Visible = 0 WHERE Id = 'SERVICE-VerOtrosUsuarios'
    PRINT ''
    PRINT '3 Ya existía la función SERVICE-VerOtrosUsuarios'
    END

IF dbo.ExisteFuncion('Service') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('Service', 'Service', '', 1, 0, 1, 0, NULL, 60, '', '', NULL, '', 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'Service')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'Service')
    PRINT ''
    PRINT '4 Se agregó función Service'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 0 WHERE Id = 'Service'
    PRINT ''
    PRINT '4 Ya existía la función Service'
    END

IF dbo.ExisteFuncion('AdministracionNotasRecepcion') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('AdministracionNotasRecepcion', 'Administración de Notas de Recepción', 'Administración de Notas de Recepción', 1, 0, 1, 1, 'Service', 30, 'Eniac.Win', 'AdministracionNotasRecepcion', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'AdministracionNotasRecepcion')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'AdministracionNotasRecepcion')
    PRINT ''
    PRINT '4.1 Se agregó función AdministracionNotasRecepcion'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'AdministracionNotasRecepcion'
    PRINT ''
    PRINT '4.1 Ya existía la función AdministracionNotasRecepcion'
    END

IF dbo.ExisteFuncion('ProductosEnReparacion') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('ProductosEnReparacion', 'Administración de Productos en Reparación', 'Administración de Productos en Reparación', 1, 0, 1, 1, 'Service', 10, 'Eniac.Win', 'ProductosEnReparacion', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'ProductosEnReparacion')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'ProductosEnReparacion')
    PRINT ''
    PRINT '4.2 Se agregó función ProductosEnReparacion'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'ProductosEnReparacion'
    PRINT ''
    PRINT '4.2 Ya existía la función ProductosEnReparacion'
    END

IF dbo.ExisteFuncion('ProductosRecepcion') = 0
    BEGIN
    INSERT INTO Funciones VALUES
    ('ProductosRecepcion', 'Recepción de productos para reparación', 'Recepción de productos para reparación', 1, 0, 1, 1, 'Service', 20, 'Eniac.Win', 'ProductosRecepcion', NULL, NULL, 1, 'S', 'N', 'N', 'N', NULL, 1)
    INSERT INTO RolesFunciones VALUES
    ('Adm', 'ProductosRecepcion')
    INSERT INTO RolesFunciones VALUES
    ('Supervisor', 'ProductosRecepcion')
    PRINT ''
    PRINT '4.3 Se agregó función ProductosRecepcion'
    END
    
    ELSE
    BEGIN
    UPDATE Funciones SET EsMenu = 1, EsBoton = 0, Enabled = 1, Visible = 1 WHERE Id = 'ProductosRecepcion'
    PRINT ''
    PRINT '4.3 Ya existía la función ProductosRecepcion'
    END
