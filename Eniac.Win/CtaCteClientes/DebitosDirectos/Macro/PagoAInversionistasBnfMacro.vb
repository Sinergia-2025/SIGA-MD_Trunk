Public Class PagoAInversionistasBnfMacro

   Private _add As ArchivoPagoAInversionistasBnfMacro

   Public Sub CrearDD(ByVal dt As System.Data.DataTable,
                      ByVal nombreArchivo As String)
      Dim i As Integer = 0

      Try
         Me._add = New ArchivoPagoAInversionistasBnfMacro()

         Dim linea As ArchivoPagoAInversionistasBnfMacroDatos

         With Me._add

            For Each dr As DataRow In dt.Rows

               If Boolean.Parse(dr("Selec").ToString()) = False Then
                  Continue For
               End If

               i += 1

               'If i = 106 Then
               '   Stop
               'End If

               linea = New ArchivoPagoAInversionistasBnfMacroDatos()

               With linea
                  'DATO	FORMATO	USO	OBSERVACION

                  'Tipo de documento del beneficiario	N 2	obligatorio
                  'por ahora queda Hardcodeado el Nro. 3 que es DNI, tenemos que ver como unificar este criterio.
                  If dr("TipoDocCliente").ToString() = "CUIT" Then
                     .TipoDocumento = 10
                  Else
                     'Es banco Macro
                     If Not String.IsNullOrEmpty(dr("CBU").ToString) AndAlso Integer.Parse(dr("CBU").ToString.Trim.Substring(0, 3)) = 285 Then
                        .TipoDocumento = 3  'DNI
                     Else
                        .TipoDocumento = 13  '13 CDI - Nueva disposicion del Banco
                     End If
                  End If

                  'Número de documento del beneficiario	N 14	obligatorio
                  .NroDocumento = Long.Parse(dr("NroDocCliente").ToString())

                  'Condición de Ingresos Brutos	N 2	obligatorio
                  If String.IsNullOrEmpty(dr("IdCondicionIngresosBrutos").ToString()) Then
                     .IdCondicionIngresosBrutos = 99 'No informado
                  Else
                     .IdCondicionIngresosBrutos = Integer.Parse(dr("IdCondicionIngresosBrutos").ToString())
                  End If

                  'Condición de Ganancias	N 2	obligatorio
                  If String.IsNullOrEmpty(dr("IdCondicionGanancias").ToString()) Then
                     .IdCondicionGanancias = 99 'No informado
                  Else
                     .IdCondicionGanancias = Integer.Parse(dr("IdCondicionGanancias").ToString())
                  End If

                  ' Condición de I.V.A.	N 2	obligatorio
                  If String.IsNullOrEmpty(dr("IdCondicionIVAMacro").ToString()) Then
                     .IdCategoriaFiscal = 99
                  Else
                     .IdCategoriaFiscal = Integer.Parse(dr("IdCondicionIVAMacro").ToString())
                  End If

                  'Razón social del beneficiario	A 40	
                  .NombreCliente = dr("NombreCliente").ToString()

                  'Calle	A 60	
                  .Calle = dr("Direccion").ToString()

                  'Número de puerta	N 8	obligatorio
                  .NumeroPuerta = 0

                  'Unidad funcional / Piso, Departamento, etc.	A 20	
                  .PisoDpto = ""

                  'Código Postal	N 6	obligatorio
                  .IdLocalidad = Integer.Parse(dr("IdLocalidad").ToString.Trim.Substring(0, 4))    'En el sistema hay localidades de 5 digitos para compensar CCPP repetidos.

                  'Número de Ingresos Brutos	A 20	
                  .IngresosBrutos = dr("IngresosBrutos").ToString()

               End With

               Me._add.Datos.Add(linea)

            Next
            .GrabarArchivo(nombreArchivo)
         End With

         MessageBox.Show("Se Exportaron " + i.ToString() + " beneficiarios EXITOSAMENTE !!!", "Beneficiarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      Catch ex As Exception
         Throw New Exception(ex.Message & " Linea " & i.ToString())
      End Try
   End Sub

   Public ReadOnly Property NumeroDeRegistros As Integer
      Get
         Return Me._add.Datos.Count
      End Get
   End Property

End Class
