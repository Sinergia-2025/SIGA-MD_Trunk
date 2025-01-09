UPDATE CRMNovedades
  SET IdUsuarioEntregado = IdUsuarioEstadoNovedad
 
WHERE IdTipoNovedad = 'Tickets'
 and IdUsuarioEntregado IN ( 'atrabajar', 'adefinir', 'soporte')
-- order by FechaNovedad desc
