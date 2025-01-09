PRINT ''
PRINT '1. Nueva Tabla: ConcesionariosAdicionales'
CREATE TABLE ConcesionariosAdicionales(
    IdAdicional INT NOT NULL,
    NombreAdicional VARCHAR(30) NOT NULL,
    DescripcionAdicional VARCHAR(150) NULL,
    SolicitaDetalle BIT NOT NULL

    PRIMARY KEY(IdAdicional) )
GO

    /*CAMBIOS DE NOMBRE DE LOS REPORTES CON ABREVIATURA A CODIGO CLIENTE*/
    /*046 SEÑALAR*/
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_SENALAR.rdlc', '046_eComprobante.rdlc', 'N'
    EXECUTE [dbo].[RenombrarReporte] 'eComprabante_SeñalarV2.rdlc', '046_eComprobanteV2.rdlc', 'N'
    EXECUTE [dbo].[RenombrarReporte] 'eComprabanteDolares_Señalar.rdlc', '046_eComprobanteDolares.rdlc', 'N'
    /*077 ALMAFUERTE*/
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_Almafuerte.rdlc', '077_eComprobante.rdlc', 'N'
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_x_2_ALM.rdlc', '077_eComprobante_x_2.rdlc', 'N'
    /*101 ROSARIO JAPAN*/
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_RJ.rdlc', '101_eComprobante.rdlc', 'N'

    /*CAMBIOS DE NOMBRE DE LOS REPORTES CON ABREVIATURA A CODIGO CLIENTE*/

    /*CLIENTE 175 EJF ELECTRICIDAD*/
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_x_2_EJF.rdlc', '175_eComprobante_x_2.rdlc', 'N'

    /*CLIENTE 195 RED DEL SOL S.R.L*/
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_RDS.rdlc', '195_eComprobante.rdlc', 'N'
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_RDS_LiquidoProducto.rdlc', '195_eComprobante_LiquidoProducto.rdlc', 'N'

    /*CLIENTE 206 QUIMICA SUPERBRILL S.R.L*/
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_SupBrill.rdlc', '206_eComprobante.rdlc', 'N'
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_SupBrill_M_x_2.rdlc', '206_eComprobante_M_x_2.rdlc', 'N'
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_SupBrill_x_2.rdlc', '206_eComprobante_x_2.rdlc', 'N'

    /*CLIENTE 212 VIALPARKING S.A*/
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_x_2_VP.rdlc', '212_eComprobante_x_2.rdlc', 'N'
    EXECUTE [dbo].[RenombrarReporte] 'eComprobanteDolares_VP.rdlc', '212_eComprobanteDolares.rdlc', 'N'
    EXECUTE [dbo].[RenombrarReporte] 'eComprobanteDolares_VP_x_2.rdlc', '212_eComprobanteDolares_x_2.rdlc', 'N'

    /*CLIENTE 227 FaCMMA*/
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_x_2_Facmma.rdlc', '227_eComprobante_x_2.rdlc', 'N'

    /*CLIENTE 242 DISTRIBUIDORA ERRE S.R.L*/
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_ERRE.rdlc', '242_eComprobante.rdlc', 'N'
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_ERRE_CyO.rdlc', '242_eComprobante_CyO.rdlc', 'N'

    /*CLIENTE 272 PET WORLD*/
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_PW.rdlc', '272_eComprobante.rdlc', 'N'


    /*CLIENTE 286 AIMARO ELECTRICIDAD*/
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_Aimaro.rdlc', '286_eComprobante.rdlc', 'N'

    /*CLIENTE 290 CARDINAL SCALE (EX HPM)*/
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_Cardinal.rdlc', '290_eComprobante.rdlc', 'N'
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_Cardinal_Dolares.rdlc', '290_eComprobanteDolares.rdlc', 'N'

    /*CLIENTE 43 FERRETERIA 25 de MAYO*/
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_25M.rdlc', '043_eComprobante.rdlc', 'N'
    EXECUTE [dbo].[RenombrarReporte] 'eComprobanteDolares_F25M.rdlc', '043_eComprobanteDolares.rdlc', 'N'

    /*CLIENTE 221 Indus-Pol*/
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_x_2_IndusPol.rdlc', '221_eComprobante_x_2.rdlc', 'N'
