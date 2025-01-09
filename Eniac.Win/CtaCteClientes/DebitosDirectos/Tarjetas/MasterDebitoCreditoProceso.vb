Public Class MasterDebitoCreditoProceso
    Implements IDebitosTarjetasProceso

    Private _add As ArchivoPresentacionMaster

   Public Sub CrearDT(dt As System.Data.DataTable,
                     banco As Eniac.Entidades.Banco,
                     nombreArchivo As String,
                     fechaVencimiento As Date,
                     tipoTarjeta As String) Implements IDebitosTarjetasProceso.CrearDT
      Dim i As Integer = 0

      Try
         Me._add = New ArchivoPresentacionMaster()

         Dim linea As ArchivoPresentacionMasterDatos
         Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()

         'en la primera linea tengo que cargar los datos de la cabecera****************************************************
         With Me._add

            'Número Comercio  
            'TODO: DB
            '''.NumeroComercio = Publicos.NumeroComercioMaster

            ' Fecha de generación del archivo.Formato: AAAAMMDD
            .FechaArchivo = DateTime.Now()


            'desde la segunda linea en adelante tengo que cargar todos los registros.****************************************
            For Each dr As DataRow In dt.Rows
               If Not CBool(dr("Selec")) Then Continue For

               linea = New ArchivoPresentacionMasterDatos()

               With linea

                  'Número Comercio  
                  'TODO: DB
                  '''.NumeroComercio = Publicos.NumeroComercioMaster

                  ' Tipo Tarjeta        
                  .TipoTarjeta = dr("TipoTarjeta").ToString()

                  ' Número de Tarjeta  
                  .NroTarjeta = dr("NroTarjeta").ToString()

                  ' Referencia o número de comprobante o Nro. Secuencial ascendente único por archivo    
                  .NroReferencia = Long.Parse(dr("CodigoCLiente").ToString())

                  ' Fecha de origen o vencimiento del débito
                  .FechaVencimiento = fechaVencimiento

                  'Importe
                  .Importe = Decimal.Parse(dr("SaldoCtaCte").ToString())

               End With

               Me._add.Datos.Add(linea)

            Next

            .GrabarArchivo(nombreArchivo)
         End With

         If stb.Length > 0 Then
            MessageBox.Show(stb.ToString(), "Debitos Directos", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End If

      Catch ex As Exception
         Throw New Exception(ex.Message & " Linea " & i.ToString())
      End Try
   End Sub

    Public ReadOnly Property NumeroDeRegistros As Integer Implements IDebitosTarjetasProceso.NumeroDeRegistros
        Get
            Return Me._add.Datos.Count
        End Get
    End Property


End Class
