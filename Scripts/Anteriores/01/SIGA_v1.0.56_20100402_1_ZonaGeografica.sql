
CREATE TABLE [ZonasGeograficas](
	[IdZonaGeografica] [varchar](20) NOT NULL,
	[NombreZonaGeografica] [varchar](40) NOT NULL,
 CONSTRAINT [PK_ZonaGeografica] PRIMARY KEY CLUSTERED 
(
	[IdZonaGeografica] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO ZonasGeograficas
   (IdZonaGeografica, NombreZonaGeografica)
 VALUES
   ('General', 'General')
GO
