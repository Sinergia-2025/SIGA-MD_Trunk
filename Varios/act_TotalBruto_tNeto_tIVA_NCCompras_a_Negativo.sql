
UPDATE Compras
SET TotalNeto = TotalNeto * (-1)
where IdTIpoComprobante in ( 'NCredcom', 'REMITOCOM-NC')
and TotalNeto > 0



UPDATE Compras
SET TotalBruto = TotalBruto * (-1)
where IdTIpoComprobante in ( 'NCredcom', 'REMITOCOM-NC')
and TotalBruto > 0



UPDATE Compras
SET TotalIVA = TotalIVA * (-1)
where IdTIpoComprobante in ( 'NCredcom', 'REMITOCOM-NC')
and TotalIVA > 0

