DECLARE @tipoComprobanteExistente   VARCHAR(MAX) = 'PEDIDO'
DECLARE @tipoComprobanteNuevo       VARCHAR(MAX) = 'PEDIDOTN'

    UPDATE I
       SET ComprobantesHabilitados = ComprobantesHabilitados + ',' + @tipoComprobanteNuevo
      FROM Impresoras I
     WHERE (I.ComprobantesHabilitados LIKE @tipoComprobanteExistente + ',%' OR I.ComprobantesHabilitados LIKE '%,' + @tipoComprobanteExistente + ',%' OR I.ComprobantesHabilitados LIKE '%,' + @tipoComprobanteExistente)
