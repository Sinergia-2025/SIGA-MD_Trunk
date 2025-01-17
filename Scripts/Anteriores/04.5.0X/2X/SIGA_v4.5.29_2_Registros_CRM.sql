
PRINT '1. CRMTiposNovedades';

/****** Object:  Table [dbo].[CRMTiposNovedades]    Script Date: 10/28/2016 14:11:22 ******/
INSERT [dbo].[CRMTiposNovedades] ([IdTipoNovedad], [NombreTipoNovedad]) VALUES ('CRM', 'CRM')
INSERT [dbo].[CRMTiposNovedades] ([IdTipoNovedad], [NombreTipoNovedad]) VALUES ('PROSP', 'Prospectos')
INSERT [dbo].[CRMTiposNovedades] ([IdTipoNovedad], [NombreTipoNovedad]) VALUES ('RECCLTE', 'Reclamos')

PRINT '2. CRMPrioridadesNovedades';

/****** Object:  Table [dbo].[CRMPrioridadesNovedades]    Script Date: 10/28/2016 14:11:22 ******/
INSERT [dbo].[CRMPrioridadesNovedades] ([IdPrioridadNovedad], [NombrePrioridadNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (1, 'ALTA', 1, 'PROSP', 0)
INSERT [dbo].[CRMPrioridadesNovedades] ([IdPrioridadNovedad], [NombrePrioridadNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (2, 'MEDIA', 2, 'PROSP', 0)
INSERT [dbo].[CRMPrioridadesNovedades] ([IdPrioridadNovedad], [NombrePrioridadNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (3, 'BAJA', 3, 'PROSP', 0)
INSERT [dbo].[CRMPrioridadesNovedades] ([IdPrioridadNovedad], [NombrePrioridadNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (4, 'ALTA', 1, 'RECCLTE', 0)
INSERT [dbo].[CRMPrioridadesNovedades] ([IdPrioridadNovedad], [NombrePrioridadNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (5, 'MEDIA', 2, 'RECCLTE', 0)
INSERT [dbo].[CRMPrioridadesNovedades] ([IdPrioridadNovedad], [NombrePrioridadNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (6, 'BAJA', 3, 'RECCLTE', 0)
INSERT [dbo].[CRMPrioridadesNovedades] ([IdPrioridadNovedad], [NombrePrioridadNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (7, 'ALTA', 1, 'CRM', 0)
INSERT [dbo].[CRMPrioridadesNovedades] ([IdPrioridadNovedad], [NombrePrioridadNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (8, 'MEDIA', 2, 'CRM', 0)
INSERT [dbo].[CRMPrioridadesNovedades] ([IdPrioridadNovedad], [NombrePrioridadNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (9, 'BAJA', 3, 'CRM', 0)

PRINT '3. CRMEstadosNovedades';

/****** Object:  Table [dbo].[CRMEstadosNovedades]    Script Date: 10/28/2016 14:11:22 ******/
INSERT [dbo].[CRMEstadosNovedades] ([IdEstadoNovedad], [NombreEstadoNovedad], [Posicion], [SolicitaUsuario], [Finalizado], [IdTipoNovedad], [PorDefecto]) VALUES (1, 'NUEVO', 1, 0, 0, 'PROSP', 1)
INSERT [dbo].[CRMEstadosNovedades] ([IdEstadoNovedad], [NombreEstadoNovedad], [Posicion], [SolicitaUsuario], [Finalizado], [IdTipoNovedad], [PorDefecto]) VALUES (2, 'EN PROCESO', 2, 1, 0, 'PROSP', 0)
INSERT [dbo].[CRMEstadosNovedades] ([IdEstadoNovedad], [NombreEstadoNovedad], [Posicion], [SolicitaUsuario], [Finalizado], [IdTipoNovedad], [PorDefecto]) VALUES (3, 'FINALIZADO', 3, 1, 1, 'PROSP', 0)
INSERT [dbo].[CRMEstadosNovedades] ([IdEstadoNovedad], [NombreEstadoNovedad], [Posicion], [SolicitaUsuario], [Finalizado], [IdTipoNovedad], [PorDefecto]) VALUES (4, 'CANCELADO', 4, 0, 1, 'PROSP', 0)
INSERT [dbo].[CRMEstadosNovedades] ([IdEstadoNovedad], [NombreEstadoNovedad], [Posicion], [SolicitaUsuario], [Finalizado], [IdTipoNovedad], [PorDefecto]) VALUES (5, 'NUEVO', 1, 0, 0, 'RECCLTE', 1)
INSERT [dbo].[CRMEstadosNovedades] ([IdEstadoNovedad], [NombreEstadoNovedad], [Posicion], [SolicitaUsuario], [Finalizado], [IdTipoNovedad], [PorDefecto]) VALUES (6, 'EN PROCESO', 2, 1, 0, 'RECCLTE', 0)
INSERT [dbo].[CRMEstadosNovedades] ([IdEstadoNovedad], [NombreEstadoNovedad], [Posicion], [SolicitaUsuario], [Finalizado], [IdTipoNovedad], [PorDefecto]) VALUES (7, 'FINALIZADO', 3, 1, 1, 'RECCLTE', 0)
INSERT [dbo].[CRMEstadosNovedades] ([IdEstadoNovedad], [NombreEstadoNovedad], [Posicion], [SolicitaUsuario], [Finalizado], [IdTipoNovedad], [PorDefecto]) VALUES (8, 'CANCELADO', 4, 0, 1, 'RECCLTE', 0)
INSERT [dbo].[CRMEstadosNovedades] ([IdEstadoNovedad], [NombreEstadoNovedad], [Posicion], [SolicitaUsuario], [Finalizado], [IdTipoNovedad], [PorDefecto]) VALUES (9, 'NUEVO', 1, 0, 0, 'CRM', 1)
INSERT [dbo].[CRMEstadosNovedades] ([IdEstadoNovedad], [NombreEstadoNovedad], [Posicion], [SolicitaUsuario], [Finalizado], [IdTipoNovedad], [PorDefecto]) VALUES (10, 'EN PROCESO', 2, 1, 0, 'CRM', 0)
INSERT [dbo].[CRMEstadosNovedades] ([IdEstadoNovedad], [NombreEstadoNovedad], [Posicion], [SolicitaUsuario], [Finalizado], [IdTipoNovedad], [PorDefecto]) VALUES (11, 'FINALIZADO', 3, 1, 1, 'CRM', 0)
INSERT [dbo].[CRMEstadosNovedades] ([IdEstadoNovedad], [NombreEstadoNovedad], [Posicion], [SolicitaUsuario], [Finalizado], [IdTipoNovedad], [PorDefecto]) VALUES (12, 'CANCELADO', 4, 0, 1, 'CRM', 0)

PRINT '4. CRMCategoriasNovedades';

/****** Object:  Table [dbo].[CRMCategoriasNovedades]    Script Date: 10/28/2016 14:11:22 ******/
INSERT [dbo].[CRMCategoriasNovedades] ([IdCategoriaNovedad], [NombreCategoriaNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (1, 'CAMPAÑA', 1, 'PROSP', 0)
INSERT [dbo].[CRMCategoriasNovedades] ([IdCategoriaNovedad], [NombreCategoriaNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (2, 'CONSULTA', 1, 'RECCLTE', 1)
INSERT [dbo].[CRMCategoriasNovedades] ([IdCategoriaNovedad], [NombreCategoriaNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (3, 'RECLAMO', 2, 'RECCLTE', 0)
INSERT [dbo].[CRMCategoriasNovedades] ([IdCategoriaNovedad], [NombreCategoriaNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (4, 'ERROR', 3, 'RECCLTE', 0)
INSERT [dbo].[CRMCategoriasNovedades] ([IdCategoriaNovedad], [NombreCategoriaNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (5, 'MEJORA', 4, 'RECCLTE', 0)
INSERT [dbo].[CRMCategoriasNovedades] ([IdCategoriaNovedad], [NombreCategoriaNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (6, 'RECLAMO DEUDA', 1, 'CRM', 1)
INSERT [dbo].[CRMCategoriasNovedades] ([IdCategoriaNovedad], [NombreCategoriaNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (7, 'NOVEDADES', 2, 'CRM', 0)

PRINT '5. CRMMediosComunicacionesNovedades';

/****** Object:  Table [dbo].[CRMMediosComunicacionesNovedades]    Script Date: 10/28/2016 14:11:22 ******/
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (1, 'CORREO', 1, 'PROSP', 0)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (2, 'TELEFONICO', 2, 'PROSP', 1)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (3, 'CELULAR', 3, 'PROSP', 0)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (4, 'WHATSAPP', 4, 'PROSP', 0)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (5, 'WEB', 5, 'PROSP', 0)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (6, 'PERSONALMENTE', 6, 'PROSP', 0)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (7, 'FACEBOOK', 7, 'PROSP', 0)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (8, 'TWITTER', 8, 'PROSP', 0)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (21, 'CORREO', 1, 'RECCLTE', 0)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (22, 'TELEFONICO', 2, 'RECCLTE', 1)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (23, 'CELULAR', 3, 'RECCLTE', 0)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (24, 'WHATSAPP', 4, 'RECCLTE', 0)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (25, 'WEB', 5, 'RECCLTE', 0)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (26, 'PERSONALMENTE', 6, 'RECCLTE', 0)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (27, 'FACEBOOK', 7, 'RECCLTE', 0)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (28, 'TWITTER', 8, 'RECCLTE', 0)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (41, 'CORREO', 1, 'CRM', 0)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (42, 'TELEFONICO', 2, 'CRM', 0)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (43, 'CELULAR', 3, 'CRM', 0)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (44, 'WHATSAPP', 4, 'CRM', 0)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (45, 'WEB', 5, 'CRM', 0)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (46, 'PERSONALMENTE', 6, 'CRM', 0)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (47, 'FACEBOOK', 7, 'CRM', 0)
INSERT [dbo].[CRMMediosComunicacionesNovedades] ([IdMedioComunicacionNovedad], [NombreMedioComunicacionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) VALUES (48, 'TWITTER', 8, 'CRM', 0)

PRINT '6. CRMTiposNovedadesDinamicos';

/****** Object:  Table [dbo].[CRMTiposNovedadesDinamicos]    Script Date: 10/28/2016 14:11:22 ******/
INSERT [dbo].[CRMTiposNovedadesDinamicos] ([IdTipoNovedad], [IdNombreDinamico], [EsRequerido]) VALUES ('CRM', 'CLIENTES', 1)
INSERT [dbo].[CRMTiposNovedadesDinamicos] ([IdTipoNovedad], [IdNombreDinamico], [EsRequerido]) VALUES ('PROSP', 'PROSPECTOS', 1)
INSERT [dbo].[CRMTiposNovedadesDinamicos] ([IdTipoNovedad], [IdNombreDinamico], [EsRequerido]) VALUES ('RECCLTE', 'CLIENTES', 1)
--INSERT [dbo].[CRMTiposNovedadesDinamicos] ([IdTipoNovedad], [IdNombreDinamico], [EsRequerido]) VALUES ('RECCLTE', 'FUNCIONES', 0)
--INSERT [dbo].[CRMTiposNovedadesDinamicos] ([IdTipoNovedad], [IdNombreDinamico], [EsRequerido]) VALUES ('RECCLTE', 'SISTEMAS', 0)
