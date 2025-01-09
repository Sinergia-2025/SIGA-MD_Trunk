Public Class VisaDebitoCreditoProceso
    Implements IDebitosTarjetasProceso

    Private _add As ArchivoPresentacionVisa

   Public Sub CrearDT(dt As System.Data.DataTable,
                     banco As Eniac.Entidades.Banco,
                     nombreArchivo As String,
                     fechaVencimiento As Date,
                     tipoTarjeta As String) Implements IDebitosTarjetasProceso.CrearDT
      Dim i As Integer = 0

      Try
         Me._add = New ArchivoPresentacionVisa()

         Dim linea As ArchivoPresentacionVisaDatos
         Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()

         'en la primera linea tengo que cargar los datos de la cabecera****************************************************
         With Me._add

            'Número del Establecimiento que generó el archivo  
            'TODO: DB
            '''.NumeroEstablecimiento = Publicos.NumeroEstablecimientoVisa

            ' Fecha de generación del archivo.Formato: AAAAMMDD
            .FechaArchivo = DateTime.Now()

            Dim nro As Long = 0

            'desde la segunda linea en adelante tengo que cargar todos los registros.****************************************
            For Each dr As DataRow In dt.Rows
               i += 1
               If Not CBool(dr("Selec")) Then Continue For

               linea = New ArchivoPresentacionVisaDatos()

               With linea

                  ' Número de Tarjeta  
                  .NroTarjeta = dr("NroTarjeta").ToString()

                  nro += 1
                  ' Referencia o número de comprobante o Nro. Secuencial ascendente único por archivo    
                  .NroReferencia = nro

                  ' Fecha de origen o vencimiento del débito
                  .FechaVencimiento = fechaVencimiento

                  'Importe
                  .Importe = Decimal.Parse(dr("SaldoCtaCte").ToString())

                  'Identificador del débito  	
                  .IdentintificadorDebito = Long.Parse(dr("NroDocCliente").ToString()).ToString("000000000000000")

               End With

               Me._add.Datos.Add(linea)

            Next

            .GrabarArchivo(nombreArchivo, tipoTarjeta)
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
