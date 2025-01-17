﻿CREATE TABLE [dbo].[SueldosPersonal] (
    [IdLegajo]                           INT            NOT NULL,
    [NombrePersonal]                     VARCHAR (50)   NOT NULL,
    [Domicilio]                          VARCHAR (50)   NOT NULL,
    [IdLocalidad]                        INT            NOT NULL,
    [TipoDocPersonal]                    VARCHAR (5)    NOT NULL,
    [NroDocPersonal]                     BIGINT         NOT NULL,
    [idNacionalidad]                     INT            NOT NULL,
    [Sexo]                               CHAR (1)       NOT NULL,
    [IdEstadoCivil]                      INT            NOT NULL,
    [Cuil]                               BIGINT         NULL,
    [LegajoMinTrabajo]                   BIGINT         NULL,
    [IdObraSocial]                       INT            NULL,
    [CodObraSocial]                      INT            NULL,
    [FechaNacimiento]                    DATE           NOT NULL,
    [FechaIngreso]                       DATE           NOT NULL,
    [FechaBaja]                          DATE           NULL,
    [idCategoria]                        INT            NOT NULL,
    [CentroCosto]                        INT            NOT NULL,
    [SueldoBasico]                       DECIMAL (8, 2) NOT NULL,
    [MejorSueldo]                        DECIMAL (8, 2) NOT NULL,
    [AcumuladoAnual]                     DECIMAL (8, 2) NOT NULL,
    [AcumuladoSalarioFamiliar]           DECIMAL (8, 2) NOT NULL,
    [SueldoActual]                       DECIMAL (8, 2) NOT NULL,
    [SalarioFamiliarActual]              DECIMAL (8, 2) NOT NULL,
    [AFJP]                               VARCHAR (15)   NULL,
    [AnteriorAcumuladoAnual]             DECIMAL (8, 2) NOT NULL,
    [AnteriorMejorSueldo]                DECIMAL (8, 2) NOT NULL,
    [AnteriorSalarioFamiliar]            DECIMAL (8, 2) NOT NULL,
    [IdMotivoBaja]                       INT            NULL,
    [IdLugarActividad]                   INT            NULL,
    [DatosFamiliares]                    VARCHAR (300)  NULL,
    [IdBancoCtaBancaria]                 INT            NULL,
    [IdCuentasBancariasClaseCtaBancaria] INT            NULL,
    [NumeroCuentaBancaria]               VARCHAR (30)   NULL,
    [CBU]                                CHAR (22)      NULL,
    CONSTRAINT [PK_Personal] PRIMARY KEY CLUSTERED ([IdLegajo] ASC),
    CONSTRAINT [FK_SueldosPersonal_Bancos] FOREIGN KEY ([IdBancoCtaBancaria]) REFERENCES [dbo].[Bancos] ([IdBanco]),
    CONSTRAINT [FK_SueldosPersonal_CuentasBancariasClase] FOREIGN KEY ([IdCuentasBancariasClaseCtaBancaria]) REFERENCES [dbo].[CuentasBancariasClase] ([IdCuentaBancariaClase]),
    CONSTRAINT [FK_SueldosPersonal_Localidades] FOREIGN KEY ([IdLocalidad]) REFERENCES [dbo].[Localidades] ([IdLocalidad]),
    CONSTRAINT [FK_SueldosPersonal_SueldosCategorias] FOREIGN KEY ([idCategoria]) REFERENCES [dbo].[SueldosCategorias] ([idCategoria]),
    CONSTRAINT [FK_SueldosPersonal_SueldosEstadoCivil] FOREIGN KEY ([IdEstadoCivil]) REFERENCES [dbo].[SueldosEstadoCivil] ([IdEstadoCivil]),
    CONSTRAINT [FK_SueldosPersonal_SueldosLugaresActividad] FOREIGN KEY ([IdLugarActividad]) REFERENCES [dbo].[SueldosLugaresActividad] ([IdLugarActividad]),
    CONSTRAINT [FK_SueldosPersonal_SueldosMotivosBaja] FOREIGN KEY ([IdMotivoBaja]) REFERENCES [dbo].[SueldosMotivosBaja] ([IdMotivoBaja]),
    CONSTRAINT [FK_SueldosPersonal_SueldosObraSocial] FOREIGN KEY ([IdObraSocial]) REFERENCES [dbo].[SueldosObraSocial] ([IdObraSocial])
);

