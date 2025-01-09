/****** Object:  Table [dbo].[ClientesDescuentosRubros]    Script Date: 06/29/2016 16:43:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS(
    SELECT * FROM sys.columns WHERE Name = N'PorcentajeDescuento' AND Object_ID = Object_ID(N'ClientesDescuentosRubros'))
BEGIN
    CREATE TABLE [dbo].[ClientesDescuentosRubros](
	    [IdRubro] [int] NOT NULL,
	    [PorcentajeDescuento] [decimal](5, 2) NULL,
	    [IdCliente] [bigint] NOT NULL,
     CONSTRAINT [PK_ClientesDescuentosRubros] PRIMARY KEY CLUSTERED 
    (
	    [IdCliente] ASC, [IdRubro] ASC
    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
    ) ON [PRIMARY]

    ALTER TABLE [dbo].[ClientesDescuentosRubros]  WITH CHECK ADD  CONSTRAINT [FK_ClientesDescuentosRubros_Clientes] FOREIGN KEY([IdCliente])
    REFERENCES [dbo].[Clientes] ([IdCliente])

    ALTER TABLE [dbo].[ClientesDescuentosRubros] CHECK CONSTRAINT [FK_ClientesDescuentosRubros_Clientes]

    ALTER TABLE [dbo].[ClientesDescuentosRubros]  WITH NOCHECK ADD  CONSTRAINT [FK_ClientesDescuentosRubros_Rubros] FOREIGN KEY([IdRubro])
    REFERENCES [dbo].[Rubros] ([IdRubro])

    ALTER TABLE [dbo].[ClientesDescuentosRubros] CHECK CONSTRAINT [FK_ClientesDescuentosRubros_Rubros]
END
