
CREATE view [dbo].[ResPresup] as
select idpedido as nrocbt,fechapedido as feccbt,fechapedido as fecvig,0 as codcli,
nombrecliente as nomcli,0 as codven,
nombreempleado as nomven,0 as imptotcbt,'' as obscbt,'' as csid from pedidos p
left join Clientes c on p.IdCliente = c.IdCliente
left join empleados v on c.nrodocvendedor=v.nrodocempleado