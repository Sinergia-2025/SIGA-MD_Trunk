MERGE INTO Parametros AS P
        USING (SELECT 'SIMOVILSOPORTEURLBASE' AS IdParametro, 'http://w1021701.ferozo.com/SSSSoporte/api/' ValorParametro, 'URL Base para Simovil Soporte'  AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
    WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
;


/****** Object:  Index [IX_CRMNovedades_IdCliente]    Script Date: 06/02/2019 11:37:04 ******/
CREATE NONCLUSTERED INDEX [IX_CRMNovedades_IdCliente] ON [dbo].[CRMNovedades]
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

/****** Object:  Index [IX_CRMNovedades_EsComentario]    Script Date: 06/02/2019 11:37:19 ******/
CREATE NONCLUSTERED INDEX [IX_CRMNovedadesSeguimiento_EsComentario] ON [dbo].[CRMNovedadesSeguimiento]
(
	[EsComentario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
