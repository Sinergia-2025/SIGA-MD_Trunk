PRINT ''
PRINT '1. Tabla EmpleadosComisionesSubRubros: Nueva tabla Empleados Comisiones SubRubros'
IF dbo.ExisteTabla('EmpleadosComisionesSubRubros') = 0 
BEGIN
	CREATE TABLE EmpleadosComisionesSubRubros(
		IdRubro int NOT NULL,
		IdSubRubro int NOT NULL,
		Comision decimal(5, 2) NULL,
		IdEmpleado int NOT NULL,
	 CONSTRAINT PK_EmpleadosComisionesSubRubros PRIMARY KEY CLUSTERED 
	(
		IdEmpleado ASC,
		IdSubRubro ASC,
		IdRubro ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE EmpleadosComisionesSubRubros  WITH CHECK ADD  CONSTRAINT FK_EmpleadosComisionesSubRubros_Empleados FOREIGN KEY(IdEmpleado)
			REFERENCES Empleados (IdEmpleado)
	ALTER TABLE EmpleadosComisionesSubRubros CHECK CONSTRAINT FK_EmpleadosComisionesSubRubros_Empleados

	ALTER TABLE EmpleadosComisionesSubRubros  WITH CHECK ADD  CONSTRAINT FK_EmpleadosComisionesSubRubros_Rubros FOREIGN KEY(IdRubro)
			REFERENCES Rubros (IdRubro)
	ALTER TABLE EmpleadosComisionesSubRubros CHECK CONSTRAINT FK_EmpleadosComisionesSubRubros_Rubros

	ALTER TABLE EmpleadosComisionesSubRubros  WITH CHECK ADD  CONSTRAINT FK_EmpleadosComisionesSubRubros_SubRubros FOREIGN KEY(IdSubRubro)
			REFERENCES SubRubros (IdSubRubro)
	ALTER TABLE EmpleadosComisionesSubRubros CHECK CONSTRAINT FK_EmpleadosComisionesSubRubros_SubRubros
END
GO

PRINT ''
PRINT '2. Tabla EmpleadosComisionesSubSubRubros: Nueva tabla Empleados Comisiones SubSubRubros'
IF dbo.ExisteTabla('EmpleadosComisionesSubSubRubros') = 0 
BEGIN
	CREATE TABLE EmpleadosComisionesSubSubRubros(
		IdRubro int NOT NULL,
		IdSubRubro int NOT NULL,
		IdSubSubRubro int NOT NULL,
		Comision decimal(5, 2) NULL,
		IdEmpleado int NOT NULL,
	 CONSTRAINT PK_EmpleadosComisionesSubSubRubros PRIMARY KEY CLUSTERED 
	(
		IdEmpleado ASC,
		IdSubRubro ASC,
		IdSubSubRubro ASC,
		IdRubro ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE EmpleadosComisionesSubSubRubros  WITH CHECK ADD  CONSTRAINT FK_EmpleadosComisionesSubSubRubros_Empleados FOREIGN KEY(IdEmpleado)
			REFERENCES Empleados (IdEmpleado)
	ALTER TABLE EmpleadosComisionesSubSubRubros CHECK CONSTRAINT FK_EmpleadosComisionesSubSubRubros_Empleados

	ALTER TABLE EmpleadosComisionesSubSubRubros  WITH CHECK ADD  CONSTRAINT FK_EmpleadosComisionesSubSubRubros_Rubros FOREIGN KEY(IdRubro)
			REFERENCES Rubros (IdRubro)
	ALTER TABLE EmpleadosComisionesSubSubRubros CHECK CONSTRAINT FK_EmpleadosComisionesSubSubRubros_Rubros

	ALTER TABLE EmpleadosComisionesSubSubRubros  WITH CHECK ADD  CONSTRAINT FK_EmpleadosComisionesSubSubRubros_SubRubros FOREIGN KEY(IdSubRubro)
			REFERENCES SubRubros (IdSubRubro)
	ALTER TABLE EmpleadosComisionesSubSubRubros CHECK CONSTRAINT FK_EmpleadosComisionesSubSubRubros_SubRubros
END
GO


