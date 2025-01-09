Public Class DebitosDirectosProcesoRio
   Implements IDebitosDirectosProceso

   Private _add As ArchivoDebitoPresentacionRio

   Public Sub CrearDD(dt As DataTable,
                     banco As Eniac.Entidades.Banco,
                     nombreArchivo As String,
                     fechaVencimiento As Date,
                      nroRefinanciacion As Integer) Implements IDebitosDirectosProceso.CrearDD
      Dim i As Integer = 0

      Try
         Me._add = New ArchivoDebitoPresentacionRio()

         Dim linea As ArchivoDebitoPresentacionRioDatos
         Dim stb = New StringBuilder()

         Dim Identif As String = Date.Now.ToString("yyyyMMddHHmmss")

         Dim codigoServicio As String = Reglas.Publicos.CtaCte.DebitoAutomaticoSantanderCodigoServicio
         If String.IsNullOrWhiteSpace(codigoServicio) Then
            Throw New Exception("No está configurado el Código de Servicio en Configuraciones -> Parametros del Sistema -> C.C. Clientes -> Débito Automático")
         End If

         'en la primera linea tengo que cargar los datos de la cabecera****************************************************
         With Me._add

            ' Fijo ‘10’ 
            .TipoDeRegistro = "10"

            ' AAAAMMDD 
            .FechaPresentacion = Date.Now

            Dim CantidadReg As Integer
            Dim ImporteTotal As Decimal
            For Each dr As DataRow In dt.Rows
               If Boolean.Parse(dr("Selec").ToString()) Then
                  CantidadReg += 1
                  ImporteTotal += Decimal.Parse(dr("SaldoCtaCte").ToString())
               End If
            Next

            'Cantidad de Registros ‘11’ 
            .CantidadDeRegistros = CantidadReg

            ' 17 enteros + 2 decimales . Sin punto. Sumatoria importes registros ‘11’ 
            .ImporteTotal = ImporteTotal


            'desde la segunda linea en adelante tengo que cargar todos los registros.****************************************
            For Each dr As DataRow In dt.Rows

               If Not Boolean.Parse(dr("Selec").ToString()) Then
                  Continue For
               End If

               i += 1

               linea = New ArchivoDebitoPresentacionRioDatos()

               With linea

                  ' Fijo ‘10’ 
                  .TipoDeRegistro = "11"

                  ' Código de Servicio definido en Banco Río
                  .Servicio = codigoServicio '0 "EXPENSAS"

                  'Nro. de Cliente definido por la Empresa. Alineado a la izquierda, completado con espacios 
                  .Partida = Long.Parse(dr("CodigoCliente").ToString())

                  ' Totalmente completo 
                  .CBU = dr("CBU").ToString()

                  ' AAAAMMDD 
                  .FechaDeVencimiento = fechaVencimiento

                  ' 14 enteros + 2 decimales. Sin punto. 
                  .ImporteDebito = Decimal.Parse(dr("SaldoCtaCte").ToString())

                  ' Referencia unívoca del débito 
                  '.IdentificacionDebito = Identif
                  .IdentificacionDebito = Integer.Parse(dr("CentroEmisor").ToString()).ToString("0000") + Long.Parse(dr("NumeroComprobante").ToString()).ToString("00000000")

                  ' Nombre del Adherente 
                  .NombreAdherente = dr("NombreCliente").ToString()

                  .Filler = ""

                  ' Dato libre de la empresa. 
                  .ReferenciaEmpresa = ""


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

   Public ReadOnly Property NumeroDeRegistros As Integer Implements IDebitosDirectosProceso.NumeroDeRegistros
      Get
         Return Me._add.Datos.Count
      End Get
   End Property

End Class