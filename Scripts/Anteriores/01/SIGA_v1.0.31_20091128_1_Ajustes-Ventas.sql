
/* Corrige movimientos viejos  */

UPDATE Ventas SET ImportePesos = 0
 WHERE ImportePesos IS NULL
 GO
 
UPDATE Ventas SET ImporteTarjetas = 0
 WHERE ImporteTarjetas IS NULL
 GO
 
UPDATE Ventas SET ImporteTickets = 0
 WHERE ImporteTickets IS NULL
 GO
 
UPDATE Ventas SET ImporteCheques = 0
 WHERE ImporteCheques IS NULL
 GO
 