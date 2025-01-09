''' <summary>
''' Esta interfaz se implementa para crear los Procesos de armado de Archivos para los diferentes bancos.
''' </summary>
''' <remarks></remarks>
Public Interface IDebitosDirectosProceso
   ''' <summary>
   ''' Este metodo contiene la implementación de como armar el archivo para el banco.
   ''' </summary>
   ''' <param name="dt"></param>
   ''' <param name="banco"></param>
   ''' <param name="nombreArchivo"></param>
   ''' <remarks></remarks>
   Sub CrearDD(ByVal dt As DataTable, banco As Eniac.Entidades.Banco, nombreArchivo As String, fechaVencimiento As Date, NroRefinanciacion As Integer)
   ReadOnly Property NumeroDeRegistros As Integer

End Interface
