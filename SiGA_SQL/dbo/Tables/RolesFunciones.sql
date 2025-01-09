CREATE TABLE [dbo].[RolesFunciones] (
    [IdRol]     VARCHAR (12) NOT NULL,
    [IdFuncion] VARCHAR (30) NOT NULL,
    CONSTRAINT [PK_RolesFunciones] PRIMARY KEY CLUSTERED ([IdRol] ASC, [IdFuncion] ASC),
    CONSTRAINT [FK_RolesFunciones_Funciones] FOREIGN KEY ([IdFuncion]) REFERENCES [dbo].[Funciones] ([Id]),
    CONSTRAINT [FK_RolesFunciones_Roles] FOREIGN KEY ([IdRol]) REFERENCES [dbo].[Roles] ([Id])
);

