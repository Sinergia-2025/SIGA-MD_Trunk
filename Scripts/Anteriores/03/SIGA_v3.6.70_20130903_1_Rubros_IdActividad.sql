
ALTER TABLE Rubros ADD IdProvincia char(2) NULL
GO

ALTER TABLE Rubros ADD IdActividad int NULL
GO

ALTER TABLE [dbo].[Rubros]  WITH CHECK ADD  CONSTRAINT [FK_Rubros_Actividades] FOREIGN KEY([IdProvincia], [IdActividad])
REFERENCES [dbo].[Actividades] ([IdProvincia], [IdActividad])
GO

ALTER TABLE [dbo].[Rubros] CHECK CONSTRAINT [FK_Rubros_Actividades]
GO