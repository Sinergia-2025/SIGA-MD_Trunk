GO
PRINT N'Altering [dbo].[Retenciones]...';


GO
ALTER TABLE [dbo].[Retenciones]
    ADD [IdRegimen] INT NULL;
    
    GO
PRINT N'Creating FK_Retenciones_Regimenes...';


GO
ALTER TABLE [dbo].[Retenciones] WITH NOCHECK
    ADD CONSTRAINT [FK_Retenciones_Regimenes] FOREIGN KEY ([IdRegimen]) REFERENCES [dbo].[Regimenes] ([IdRegimen]) ON DELETE NO ACTION ON UPDATE NO ACTION;

