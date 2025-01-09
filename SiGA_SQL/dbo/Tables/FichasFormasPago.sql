CREATE TABLE [dbo].[FichasFormasPago] (
    [IdFormasPago]          INT          NOT NULL,
    [DescripcionFormasPago] VARCHAR (50) NULL,
    [Dias]                  INT          NULL,
    CONSTRAINT [PK_FormaPago] PRIMARY KEY CLUSTERED ([IdFormasPago] ASC)
);

