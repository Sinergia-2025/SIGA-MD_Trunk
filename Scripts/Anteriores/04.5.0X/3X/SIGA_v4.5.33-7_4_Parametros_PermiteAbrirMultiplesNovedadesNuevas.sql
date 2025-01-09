
-- Solo cambia en Sinergia.

IF EXISTS ( SELECT 1
            FROM Parametros AS P
            WHERE P.IdParametro = 'CUITEMPRESA'
                  AND
                  P.ValorParametro = '33711345499'
          )
    BEGIN
        INSERT INTO Parametros ( IdParametro , ValorParametro , CategoriaParametro , DescripcionParametro
                               )
        VALUES ( 'PERMITEABRIRMULTIPLESNOVEDADESNUEVAS' , 'True' , 'CRM' , 'Permite abrir múltiples Novedades nuevas'
               );
    END;
ELSE
    BEGIN
        INSERT INTO Parametros ( IdParametro , ValorParametro , CategoriaParametro , DescripcionParametro
                               )
        VALUES ( 'PERMITEABRIRMULTIPLESNOVEDADESNUEVAS' , 'False' , 'CRM' , 'Permite abrir múltiples Novedades nuevas'
               );
    END;