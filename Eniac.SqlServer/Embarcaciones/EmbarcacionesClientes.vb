Public Class EmbarcacionesClientes
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function GetResponsablesDeCargos(idEmbarcacion As Long) As DataTable

      'Atencion: Desde el ABM no puedo guardar un responsable de cargos que no sea titular.
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT EC.IdCliente ")
         .AppendFormatLine("  FROM EmbarcacionesClientes EC ")
         .AppendFormatLine(" WHERE IdEmbarcacion = {0}", idEmbarcacion)
         .AppendFormatLine("  AND EC.ResponsableCargos = 'True'")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

End Class