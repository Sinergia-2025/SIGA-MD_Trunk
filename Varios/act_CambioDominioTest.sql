UPDATE Parametros
   SET ValorParametro = REPLACE(ValorParametro, 'https://bazarcelta.com.ar/rest-siga/', 'https://bazarcelta.com.ar/rest-siga-test/')
 WHERE ValorParametro LIKE '%https://bazarcelta.com.ar/rest-siga/%'