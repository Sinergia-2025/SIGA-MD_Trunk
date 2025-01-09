IF dbo.BaseConCUIT('30701513890') = 1
    MERGE INTO ConcesionarioTiposUnidades AS D
        USING (SELECT 1 IdTipoUnidad, 'ACOPLADO'      NombreTipoUnidad, '' DescripcionTipoUnidad, 1 MuestraEnCeroKm, 1 MuestraEnUsado UNION
               SELECT 2 IdTipoUnidad, 'CARROCERÍA'    NombreTipoUnidad, '' DescripcionTipoUnidad, 1 MuestraEnCeroKm, 1 MuestraEnUsado UNION
               SELECT 3 IdTipoUnidad, 'SEMIRREMOLQUE' NombreTipoUnidad, '' DescripcionTipoUnidad, 1 MuestraEnCeroKm, 1 MuestraEnUsado UNION
               SELECT 4 IdTipoUnidad, 'VEHICULO'      NombreTipoUnidad, '' DescripcionTipoUnidad, 0 MuestraEnCeroKm, 1 MuestraEnUsado)
            AS O ON O.IdTipoUnidad = D.IdTipoUnidad
    WHEN MATCHED THEN
        UPDATE SET D.NombreTipoUnidad       = O.NombreTipoUnidad
                 , D.DescripcionTipoUnidad  = O.DescripcionTipoUnidad
                 , D.MuestraEnCeroKm        = O.MuestraEnCeroKm
                 , D.MuestraEnUsado         = O.MuestraEnUsado
    WHEN NOT MATCHED THEN 
        INSERT (  IdTipoUnidad,   NombreTipoUnidad,   DescripcionTipoUnidad,   MuestraEnCeroKm,   MuestraEnUsado)
        VALUES (O.IdTipoUnidad, O.NombreTipoUnidad, O.DescripcionTipoUnidad, O.MuestraEnCeroKm, O.MuestraEnUsado)
;

IF dbo.BaseConCUIT('30701513890') = 1
    MERGE INTO ConcesionarioSubTiposUnidades AS D
        USING (SELECT 1 IdTipoUnidad,  1 IdSubTipoUnidad, 'BARANDA VOLCABLE'    NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'True'  SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 1 IdTipoUnidad,  2 IdSubTipoUnidad, 'TODO PUERTAS'        NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'True'  SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 1 IdTipoUnidad,  3 IdSubTipoUnidad, 'BILATERAL'            NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'True'  SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 1 IdTipoUnidad,  4 IdSubTipoUnidad, 'MIXTO'                NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'False' SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 1 IdTipoUnidad,  5 IdSubTipoUnidad, 'GANADERO'            NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'False' SolicitaCantPuertasLaterales, 'True'  SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 1 IdTipoUnidad,  6 IdSubTipoUnidad, 'PLAYO'                NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'False' SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 1 IdTipoUnidad,  7 IdSubTipoUnidad, 'CEREALERO'            NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'False' SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 1 IdTipoUnidad,  8 IdSubTipoUnidad, 'TOLVA'                NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'False' SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 1 IdTipoUnidad,  9 IdSubTipoUnidad, 'SIDER'                NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'False' SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 1 IdTipoUnidad, 10 IdSubTipoUnidad, 'OTROS'                NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'False' SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
                                                                                                                                                                                                           
               SELECT 2 IdTipoUnidad, 21 IdSubTipoUnidad, 'BARANDA VOLCABLE'     NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'True'  SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 2 IdTipoUnidad, 22 IdSubTipoUnidad, 'TODO PUERTAS'         NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'True'  SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 2 IdTipoUnidad, 23 IdSubTipoUnidad, 'BILATERAL'             NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'True'  SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 2 IdTipoUnidad, 24 IdSubTipoUnidad, 'MIXTO'                  NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'False' SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 2 IdTipoUnidad, 25 IdSubTipoUnidad, 'GANADERO'             NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'False' SolicitaCantPuertasLaterales, 'True'  SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 2 IdTipoUnidad, 26 IdSubTipoUnidad, 'CEREALERO'             NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'False' SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 2 IdTipoUnidad, 27 IdSubTipoUnidad, 'TOLVA'                 NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'False' SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 2 IdTipoUnidad, 28 IdSubTipoUnidad, 'SIDER'                 NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'False' SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 2 IdTipoUnidad, 29 IdSubTipoUnidad, 'VUELCO TRASERO'         NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'False' SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'True'  SolicitaVolumen UNION
               SELECT 2 IdTipoUnidad, 30 IdSubTipoUnidad, 'OTROS'                 NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'False' SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
                                                                                                                                                                                                           
               SELECT 3 IdTipoUnidad, 41 IdSubTipoUnidad, 'BARANDA VOLCABLE'    NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'True'  SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 3 IdTipoUnidad, 42 IdSubTipoUnidad, 'BILATERAL'            NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'True'  SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 3 IdTipoUnidad, 43 IdSubTipoUnidad, 'GANADERO'            NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'False' SolicitaCantPuertasLaterales, 'True'  SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 3 IdTipoUnidad, 44 IdSubTipoUnidad, 'VUELCO TRASERO'        NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'False' SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'True'  SolicitaVolumen UNION
               SELECT 3 IdTipoUnidad, 45 IdSubTipoUnidad, 'TOLVA'                NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'False' SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 3 IdTipoUnidad, 46 IdSubTipoUnidad, 'PLAYO'                NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'False' SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 3 IdTipoUnidad, 47 IdSubTipoUnidad, 'PORTACONTENEDOR'        NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'False' SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 3 IdTipoUnidad, 48 IdSubTipoUnidad, 'SIDER'                NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'False' SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen UNION
               SELECT 3 IdTipoUnidad, 49 IdSubTipoUnidad, 'OTROS'                NombreSubTipoUnidad, '' DescripcionSubTipoUnidad, 'False' SolicitaCantPuertasLaterales, 'False' SolicitaCantPisos, 'False' SolicitaVolumen)
           AS O ON O.IdTipoUnidad = D.IdTipoUnidad AND O.IdSubTipoUnidad = D.IdSubTipoUnidad
    WHEN MATCHED THEN
        UPDATE SET D.NombreSubTipoUnidad            = O.NombreSubTipoUnidad
                 , D.DescripcionSubTipoUnidad       = O.DescripcionSubTipoUnidad
                 , D.SolicitaCantPuertasLaterales   = O.SolicitaCantPuertasLaterales
                 , D.SolicitaCantPisos              = O.SolicitaCantPisos
                 , D.SolicitaVolumen                = O.SolicitaVolumen
    WHEN NOT MATCHED THEN 
        INSERT (  IdTipoUnidad,   IdSubTipoUnidad,   NombreSubTipoUnidad,   DescripcionSubTipoUnidad,   SolicitaCantPuertasLaterales,   SolicitaCantPisos,   SolicitaVolumen) 
        VALUES (O.IdTipoUnidad, O.IdSubTipoUnidad, O.NombreSubTipoUnidad, O.DescripcionSubTipoUnidad, O.SolicitaCantPuertasLaterales, O.SolicitaCantPisos, O.SolicitaVolumen) 
;

IF NOT EXISTS (SELECT * FROM ConcesionarioDistribucionEjes) AND dbo.BaseConCUIT('30701513890') = 1
    INSERT INTO [dbo].[ConcesionarioDistribucionEjes]
               ([IdTipoUnidad],[IdEje],[NombreEje],[DescripcionEje])
         VALUES
               (1, 1, '3 EJES',            ''),
               (1, 2, '4 EJES',            ''),
               (1, 3, '1+1',            ''),

               (3, 11, '2+1/45TT',        ''),
               (3, 12, '2+1/52,5TT',    ''),
               (3, 13, '3ET/49,5TT',    ''),
               (3, 14, '3ET/52TT',        ''),
               (3, 15, '1+1+1/55,5TT',    ''),
               (3, 16, '1+1',            ''),
               (3, 17, '2 EJES',        '')
GO

ALTER TABLE ConcesionariosAdicionales ALTER COLUMN NombreAdicional VARCHAR(50) NOT NULL
IF NOT EXISTS (SELECT * FROM ConcesionariosAdicionales) AND dbo.BaseConCUIT('30701513890') = 1
    INSERT INTO [dbo].[ConcesionariosAdicionales]
               ([IdAdicional],[NombreAdicional],[DescripcionAdicional],[SolicitaDetalle])
         VALUES
               (1, 'ALARGUES DE ARCO',                      '', 'True' ),
               (2, 'LEVANTA EJES',                          '', 'False'),
               (3, 'TAPA FACIL - COLOR LONA',               '', 'True'),
               --   123456789012345678901234567890
               (4, 'ALARGUE DE PUERTA - MARCO SUPERIOR',    '', 'False'),
               (5, 'LANZA TELESCOPIO',                      '', 'False'),
               (6, 'CAJON DE HERRAMIENTAS ADICIONAL',       '', 'False'),
               (7, 'OTROS',                                 '', 'True' )
           
GO

