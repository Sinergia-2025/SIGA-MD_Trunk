UPDATE Tarjetas SET Acreditacion =  CASE WHEN IdCuentaBancaria IS NULL THEN 0 ELSE 1 END
