Public Class Publicos

   Public Sub CargaComboSueldosTiposRecibos(ByVal combo As Eniac.Controles.ComboBox)
      Dim oTipoDoc As Reglas.SueldosTiposRecibos = New Reglas.SueldosTiposRecibos()
      With combo
         .DisplayMember = Entidades.SueldosTipoRecibo.Columnas.NombreTipoRecibo.ToString()
         .ValueMember = Entidades.SueldosTipoRecibo.Columnas.IdTipoRecibo.ToString()
         .DataSource = oTipoDoc.GetTodos()
      End With
   End Sub

   Public Sub CargaComboSueldosEstadoCivil(ByVal combo As Eniac.Controles.ComboBox)
      With combo
         .DisplayMember = "NombreEstadoCivil"
         .ValueMember = "IdEstadoCivil"
         .DataSource = New Reglas.SueldosEstadoCivil().GetTodas()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboEstadosCiviles(combo As Eniac.Controles.ComboBox)
      With combo
         .DisplayMember = "NombreEstadoCivil"
         .ValueMember = "IdEstadoCivil"
         .DataSource = New Reglas.EstadosCiviles().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboObraSocial(ByVal combo As Eniac.Controles.ComboBox)
      With combo
         .DisplayMember = "NombreObraSocial"
         .ValueMember = "IdObraSocial"
         .DataSource = New Reglas.SueldosObraSocial().GetTodas()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboSueldosCategorias(ByVal combo As Eniac.Controles.ComboBox)
      With combo
         .DisplayMember = "NombreCategoria"
         .ValueMember = "IdCategoria"
         .DataSource = New Reglas.SueldosCategorias().GetTodas()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboSueldosLugaresActividad(ByVal combo As Eniac.Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.SueldosLugarActividad.Columnas.NombreLugarActividad.ToString()
         .ValueMember = Entidades.SueldosLugarActividad.Columnas.IdLugarActividad.ToString()
         .DataSource = New Reglas.SueldosLugaresActividad().GetTodos()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboVinculoFamiliar(ByVal combo As Eniac.Controles.ComboBox)
      With combo
         .DisplayMember = "NombreVinculoFamiliar"
         .ValueMember = "IdTipoVinculoFamiliar"
         .DataSource = New Reglas.SueldosTiposVinculoFamiliar().GetTodas()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub PreparaGrillaSueldosConceptos(ByVal buscador As Eniac.Controles.Buscador)
      With buscador
         'CAMPOS: C.idConcepto, C.NombreConcepto, C.idTipoConcepto, TC.NombreTipoConcepto, C.IdQuepide, Q.NombreQuePide, C.Valor, C.Tipo, C.Aguinaldo, C.LiquidacionAnual, C.LiquidacionMeses, C.Formula 
         .ColumnasTitulos = New String() {"Codigo", "Nombre Concepto", "", "Tipo Concepto", "", "Que Pide", "Valor", "Tipo", "", "", "", "Formula"}
         .ColumnasOcultas = New String() {"idTipoConcepto", "IdQuepide", "Aguinaldo", "LiquidacionAnual", "LiquidacionMeses", "idConcepto"}
         .ColumnasAncho = New Integer() {60, 200, 0, 120, 0, 80, 70, 40, 0, 0, 0, 200}
         .Titulo = "Conceptos"
         .AyudaAncho = 600
      End With
   End Sub

   Public Sub PreparaGrillaPersonal(ByVal buscador As Eniac.Controles.Buscador)
      With buscador
         .ColumnasTitulos = New String() {"Legajo", "Nombre", "Domicilio", "", "Localidad", "T.Doc.", "Nro. Documento", "", "Sexo", "", "Estado Civil"}
         .ColumnasOcultas = New String() {"IdLocalidad", "idNacionalidad", "idEstadoCivil", "Cuil", "LegajoMinTrabajo", "A.NombreCategoria", "idObraSocial", "CodObraSocial", "NombreObraSocial", "FechaNacimiento", "FechaIngreso", "FechaEgreso", "idCategoria", "CentroCosto", "SueldoBasico", "MejorSueldo", "AcumuladoAnual", "AcumuladoSalarioFamiliar", "SueldoActual", "SalarioFamiliarActual", "AFJP", "AnteriorAcumuladoAnual", "AnteriorMejorSueldo", "AnteriorSalarioFamiliar"}
         .ColumnasAncho = New Integer() {70, 200, 200, 0, 150, 40, 100, 0, 50, 0, 100}
         .Titulo = "Personal"
         .AyudaAncho = 600
      End With
   End Sub

   Public Sub CargaComboSueldosMotivosBaja(ByVal combo As Eniac.Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.SueldosMotivoBaja.Columnas.NombreMotivoBaja.ToString()
         .ValueMember = Entidades.SueldosMotivoBaja.Columnas.IdMotivoBaja.ToString()
         .DataSource = New Reglas.SueldosMotivosBaja().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboSueldosPeriodosLiquidacion(ByVal combo As Eniac.Controles.ComboBox)
      Dim oTipoDoc As Reglas.SueldosLiquidacion = New Reglas.SueldosLiquidacion()
      With combo
         .DisplayMember = "PeriodoLiquidacion"
         .ValueMember = "PeriodoLiquidacion"
         .DataSource = oTipoDoc.GetTodosLosPeriodosLiquidacion()
      End With
   End Sub

   Public Sub CargaComboSueldosNroLiquidacion(ByVal combo As Eniac.Controles.ComboBox,
                                              ByVal IdTipoRecibo As Integer?,
                                              ByVal PeriodoLiquidacion As Integer)
      Dim oTipoDoc As Reglas.SueldosLiquidacion = New Reglas.SueldosLiquidacion()
      With combo
         .DisplayMember = "NroLiquidacion"
         .ValueMember = "NroLiquidacion"
         .DataSource = oTipoDoc.GetTodosNroLiquidacion(IdTipoRecibo, PeriodoLiquidacion)
      End With
   End Sub

   Public Shared ReadOnly Property SueldosDomicilioEmpresa() As String
      Get
         Return (New Eniac.Reglas.Parametros().GetValor(Eniac.Entidades.Parametro.Parametros.SUELDOS_DOMICILIO_EMPRESA))

      End Get
   End Property

   Public Shared ReadOnly Property SueldosLugarDePago() As String
      Get
         Return (New Eniac.Reglas.Parametros().GetValor("SUELDOS_LUGAR_DE_PAGO"))

      End Get
   End Property

   Public Shared ReadOnly Property SueldosFechaDePago() As String
      Get
         Return (New Eniac.Reglas.Parametros().GetValor("SUELDOS_FECHA_DE_PAGO"))

      End Get
   End Property

   Public Shared ReadOnly Property SueldosBancodeDeposito() As String
      Get
         Return (New Eniac.Reglas.Parametros().GetValor("SUELDOS_BANCO_DEPOSITO"))

      End Get
   End Property

   Public Shared ReadOnly Property ListaPreciosPredeterminada() As Integer
      Get
         Return Integer.Parse((New Eniac.Reglas.Parametros().GetValorPD("LISTAPRECIOSPREDETERMINADA", "0")))

      End Get
   End Property

   Public Shared ReadOnly Property SueldosRecibosImpresos() As String
      Get
         Return New Eniac.Reglas.Parametros().GetValor("SUELDOS_RECIBOS_IMPRESOS")
      End Get
   End Property

End Class
