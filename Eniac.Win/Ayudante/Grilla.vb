Imports System.Runtime.CompilerServices
Namespace Ayudante
   Public Module Grilla

      Public Const FormatoTotals2Decimales As String = "{0:N2}"
      Public Const FormatoTotals0Decimales As String = "{0:N0}"

      Public Const FormatoDefaultTotales As String = FormatoTotals2Decimales
      Public Const FormatoDefaultContar As String = FormatoTotals0Decimales

#Region "Generales"
      ''' <summary>
      ''' Inicializa las propiedades comunes de una grilla
      ''' </summary>
      ''' <param name="grilla">Grilla a inicializar</param>
      ''' <param name="editable">Indica si la grilla es editable (opcional - false)</param>
      ''' <param name="groupBy">Indica si se muestra el área de Group By (opcional - true)</param>
      ''' <returns>La instancia de la grilla que se pasó como parámetro</returns>
      ''' <remarks></remarks>
      <Extension()>
      Public Function InicializaGrilla(grilla As UltraGrid, Optional editable As Boolean = False, Optional groupBy As Boolean = True) As UltraGrid

         'Indico si se permite Agregar(No)/Borrar(No)/Editar(editable) los registros de la grilla
         grilla.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
         grilla.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False
         If editable Then
            grilla.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
         Else
            grilla.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
         End If

         'Indico si se muestra el indicador de filas
         'grilla.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True
         grilla.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False

         'Muestro el área de Group By (groupBy)
         If groupBy Then
            grilla.DisplayLayout.Override.AllowGroupBy = DefaultableBoolean.True
            grilla.DisplayLayout.GroupByBox.Hidden = False
         Else
            grilla.DisplayLayout.Override.AllowGroupBy = DefaultableBoolean.False
            grilla.DisplayLayout.GroupByBox.Hidden = True
         End If

         'Titulo para el área de Group By
         grilla.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
         Return grilla
      End Function

      ''' <summary>
      ''' Oculta todas las columnas de la banda 0 de una grilla
      ''' </summary>
      ''' <param name="grilla">Grilla a la que se le ocultaran las columnas</param>
      ''' <returns>La instancia de la grilla que se pasó como parámetro</returns>
      ''' <remarks></remarks>
      <Extension()>
      Public Function OcultaTodasLasColumnas(grilla As UltraGrid) As UltraGrid
         OcultaTodasLasColumnas(grilla.DisplayLayout.Bands(0))
         Return grilla
      End Function

      ''' <summary>
      ''' Oculta todas las columnas de una banda
      ''' </summary>
      ''' <param name="banda">Banda a la que se le ocultaran las columnas</param>
      ''' <returns>La instancia de la banda que se pasó como parámetro</returns>
      ''' <remarks></remarks>
      <Extension()>
      Public Function OcultaTodasLasColumnas(banda As UltraGridBand) As UltraGridBand
         For Each columna As UltraGridColumn In banda.Columns
            columna.Hidden = True
         Next
         Return banda
      End Function

      ''' <summary>
      ''' Oculta todas las columnas de la banda 0 de una grilla
      ''' </summary>
      ''' <param name="grilla">Grilla a la que se le ocultaran las columnas</param>
      ''' <returns>La instancia de la grilla que se pasó como parámetro</returns>
      ''' <remarks></remarks>
      <Extension()>
      Public Function ActivationTodasLasColumnas(grilla As UltraGrid, activation As Activation) As UltraGrid
         ActivationTodasLasColumnas(grilla.DisplayLayout.Bands(0), activation)
         Return grilla
      End Function

      ''' <summary>
      ''' Oculta todas las columnas de una banda
      ''' </summary>
      ''' <param name="banda">Banda a la que se le ocultaran las columnas</param>
      ''' <returns>La instancia de la banda que se pasó como parámetro</returns>
      ''' <remarks></remarks>
      <Extension()>
      Public Function ActivationTodasLasColumnas(banda As UltraGridBand, activation As Activation) As UltraGridBand
         For Each columna As UltraGridColumn In banda.Columns
            columna.CellActivation = activation
         Next
         Return banda
      End Function

      <Extension>
      Public Function SetGroupByVisible(grillas As UltraGrid, visible As Boolean) As UltraGrid

         If visible Then
            grillas.DisplayLayout.Override.AllowGroupBy = DefaultableBoolean.True
            grillas.DisplayLayout.GroupByBox.Hidden = False
         Else
            grillas.DisplayLayout.Override.AllowGroupBy = DefaultableBoolean.False
            grillas.DisplayLayout.GroupByBox.Hidden = True
         End If

         Return grillas
      End Function

      <Extension()>
      Public Function ActivateFirstVisibleRow(grilla As UltraGrid) As UltraGrid
         If grilla IsNot Nothing AndAlso grilla.Rows IsNot Nothing Then
            Dim rows = grilla.Rows.GetFilteredInNonGroupByRows()
            If rows.Length > 0 Then
               grilla.ActiveRow = rows(0)
            End If
         End If
         Return grilla
      End Function
#End Region

#Region "Filtros"
      ''' <summary>
      ''' Agrega los filtros en la primer fila de la grilla
      ''' </summary>
      ''' <param name="grilla">Grilla a inicializar</param>
      ''' <param name="columnasContains">Array con las keys de las columnas que tendrán Contains por defecto</param>
      ''' <returns>La instancia de la grilla que se pasó como parámetro</returns>
      ''' <remarks></remarks>
      <Extension()>
      Public Function AgregarFiltroEnLinea(grilla As UltraGrid, columnasContains As String()) As UltraGrid
         Return AgregarFiltroEnLineaMultiBanda(grilla, {columnasContains}, {})
      End Function
      <Extension()>
      Public Function AgregarFiltroEnLineaMultiBanda(grilla As UltraGrid, columnasContainsPorBanda As String()()) As UltraGrid
         Return AgregarFiltroEnLineaMultiBanda(grilla, columnasContainsPorBanda, {})
      End Function
      <Extension()>
      Public Function AgregarFiltroEnLinea(grilla As UltraGrid, columnasContains As String(), columnasSinFiltro As String()) As UltraGrid
         Return AgregarFiltroEnLineaMultiBanda(grilla, {columnasContains}, columnasSinFiltro)
      End Function
      <Extension()>
      Public Function AgregarFiltroEnLineaMultiBanda(grilla As UltraGrid, columnasContainsPorBanda As String()(), columnasSinFiltro As String()) As UltraGrid
         grilla.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
         grilla.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
         grilla.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
         grilla.DisplayLayout.Override.FilterRowAppearance.BackColor = Color.AntiqueWhite

         'Appearance Active
         grilla.DisplayLayout.Override.FilterRowAppearanceActive.BackColor = Color.LightGreen
         grilla.DisplayLayout.Override.FilterCellAppearanceActive.BackColor = Color.LightSkyBlue

         For banda As Integer = 0 To columnasContainsPorBanda.Length - 1
            Dim columnasContains As String() = columnasContainsPorBanda(banda)
            For Each columna As String In columnasContains
               With grilla.DisplayLayout.Bands(banda)
                  If .Columns.Exists(columna) Then
                     .Columns(columna).FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains
                  End If
               End With
            Next
         Next
         For Each columna As String In columnasSinFiltro
            With grilla.DisplayLayout.Bands(0)
               If .Columns.Exists(columna) Then
                  .Columns(columna).AllowRowFiltering = DefaultableBoolean.False
               End If
            End With
         Next
         Return grilla
      End Function
#End Region

#Region "Totales"

      ''' <summary>
      ''' Inicializa la configuración de totales de la grilla
      ''' </summary>
      ''' <param name="grilla">Grilla a inicializar</param>
      ''' <returns>La instancia de la grilla que se pasó como parámetro</returns>
      ''' <remarks>Setea donde se ven los totales, el color y el texto a mostrar "Totales:".</remarks>
      <Extension()>
      Public Function InicializaTotales(grilla As UltraGrid) As UltraGrid

         If Reglas.Publicos.Generales.SubtotalesEnGrillas = Reglas.Publicos.Generales.UbicacionSubtotalesEnGrillas.InGroupByRows Then
            grilla.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.InGroupByRows Or
                                                               SummaryDisplayAreas.BottomFixed Or
                                                               SummaryDisplayAreas.RootRowsFootersOnly
         Else
            grilla.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed Or
                                                               SummaryDisplayAreas.GroupByRowsFooter
         End If


         grilla.DisplayLayout.Override.GroupBySummaryDisplayStyle = GroupBySummaryDisplayStyle.SummaryCells
         grilla.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow
         grilla.DisplayLayout.Override.GroupBySummaryValueAppearance.BackColor = Color.Cyan
         grilla.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"
         Return grilla
      End Function

      Public Function ArmarColumnaFormatoParaTotales(columna As String, formato As String) As String
         Return String.Format("{0};{1}", columna, formato)
      End Function


      ''' <summary>
      ''' Inicializa los totales de la grilla y agrega los que se pasan como parámetro
      ''' </summary>
      ''' <param name="grilla">Grilla donde agregar los totales</param>
      ''' <param name="columnas">Array con las keys de las columnas a totalizar</param>
      ''' <returns>La instancia de la grilla que se pasó como parámetro</returns>
      ''' <remarks></remarks>
      <Extension()>
      Public Function AgregarTotalesSuma(grilla As UltraGrid, columnas As String()) As UltraGrid
         InicializaTotales(grilla)
         For Each columnaFormato As String In columnas
            Dim splitColumnaFormato As String() = columnaFormato.Split(";"c)
            Dim columna As String = splitColumnaFormato(0)
            Dim formato As String = If(splitColumnaFormato.Length > 1, splitColumnaFormato(1), FormatoDefaultTotales)
            AgregarTotalSumaColumna(grilla, columna, formato)
         Next
         Return grilla
      End Function
      ''' <summary>
      ''' Inicializa los totales de la grilla y agrega los que se pasan como parámetro
      ''' </summary>
      ''' <param name="grilla">Grilla donde agregar los totales</param>
      ''' <param name="columnas">Array con las keys de las columnas a totalizar</param>
      ''' <returns>La instancia de la grilla que se pasó como parámetro</returns>
      ''' <remarks></remarks>
      <Extension()>
      Public Function AgregarTotalesContar(grilla As UltraGrid, columnas As String()) As UltraGrid
         InicializaTotales(grilla)
         For Each columnaFormato In columnas
            Dim splitColumnaFormato = columnaFormato.Split(";"c)
            Dim columna = splitColumnaFormato(0)
            Dim formato = If(splitColumnaFormato.Length > 1, splitColumnaFormato(1), FormatoDefaultTotales)
            AgregarTotalContarColumna(grilla, columna, formato)
         Next
         Return grilla
      End Function

      ''' <summary>
      ''' Inicializa los totales de la grilla y agrega los que se pasan como parámetro
      ''' </summary>
      ''' <param name="grilla">Grilla donde agregar los totales</param>
      ''' <param name="columnas">Array con las keys de las columnas a totalizar</param>
      ''' <returns>La instancia de la grilla que se pasó como parámetro</returns>
      ''' <remarks></remarks>
      <Extension()>
      Public Function AgregarTotalesPromedio(grilla As UltraGrid, columnas As String()) As UltraGrid
         InicializaTotales(grilla)
         For Each columna As String In columnas
            AgregarTotalPromedioColumna(grilla, columna, FormatoDefaultTotales)
         Next
         Return grilla
      End Function

      ''' <summary>
      ''' Inicializa los totales de la grilla y agrega los que se pasan como parámetro
      ''' </summary>
      ''' <param name="grilla">Grilla donde agregar los totales</param>
      ''' <param name="columnas">Array con las keys de las columnas a totalizar</param>
      ''' <returns>La instancia de la grilla que se pasó como parámetro</returns>
      ''' <remarks></remarks>
      <Extension()>
      Public Function AgregarTotalesExterno(grilla As UltraGrid, columnas As String()) As UltraGrid
         InicializaTotales(grilla)
         For Each columna As String In columnas
            AgregarTotalExternoColumna(grilla, columna, FormatoDefaultTotales)
         Next
         Return grilla
      End Function

#Region "Total Suma Columna"
      ''' <summary>
      ''' Agrega un total de suma para la columna indicada
      ''' </summary>
      ''' <param name="grilla">Grilla donde agregar la suma</param>
      ''' <param name="columna">Key de la columna a sumarizar</param>
      ''' <returns>La instancia de la grilla que se pasó como parámetro</returns>
      ''' <remarks></remarks>
      <Extension()>
      Public Function AgregarTotalSumaColumna(grilla As UltraGrid, columna As String) As SummarySettings
         Return AgregarTotalSumaColumna(grilla, columna, FormatoDefaultTotales)
      End Function
      <Extension()>
      Public Function AgregarTotalSumaColumna(grilla As UltraGrid, columna As String, formato As String) As SummarySettings
         If grilla.DisplayLayout.Bands(0).Columns.Exists(columna) Then
            Return AgregarTotalSumaColumna(grilla, grilla.DisplayLayout.Bands(0).Columns(columna), formato)
         End If
         Return Nothing
      End Function

      ''' <summary>
      ''' Agrega un total de suma para la columna indicada
      ''' </summary>
      ''' <param name="grilla">Grilla donde agregar la suma</param>
      ''' <param name="columna">Instancia de la columna a sumarizar</param>
      ''' <returns>La instancia de la grilla que se pasó como parámetro</returns>
      ''' <remarks></remarks>
      <Extension()>
      Public Function AgregarTotalSumaColumna(grilla As UltraGrid, columna As UltraGridColumn) As SummarySettings
         Return AgregarTotalSumaColumna(grilla, columna, FormatoDefaultTotales)
      End Function
      <Extension()>
      Public Function AgregarTotalSumaColumna(grilla As UltraGrid, columna As UltraGridColumn, formato As String) As SummarySettings
         If grilla.DisplayLayout.Bands(0).Summaries.Exists(columna.Key) AndAlso Not grilla.DisplayLayout.Bands(0).Summaries(columna.Key).SourceColumn.Equals(columna) Then
            grilla.DisplayLayout.Bands(0).Summaries.Remove(grilla.DisplayLayout.Bands(0).Summaries(columna.Key))
         End If
         If Not grilla.DisplayLayout.Bands(0).Summaries.Exists(columna.Key) Then
            Return AgregarSummaryColumna(grilla, grilla.DisplayLayout.Bands(0).Summaries.Add(columna.Key, SummaryType.Sum, columna), formato)
         End If
         Return Nothing
      End Function
#End Region

#Region "Total Contar Columna"
      <Extension()>
      Public Function AgregarTotalContarColumna(grilla As UltraGrid, columna As String) As SummarySettings
         Return AgregarTotalSumaColumna(grilla, columna, FormatoDefaultContar)
      End Function
      <Extension()>
      Public Function AgregarTotalContarColumna(grilla As UltraGrid, columna As String, formato As String) As SummarySettings
         If grilla.DisplayLayout.Bands(0).Columns.Exists(columna) Then
            Return AgregarTotalContarColumna(grilla, grilla.DisplayLayout.Bands(0).Columns(columna), formato)
         End If
         Return Nothing
      End Function
      <Extension()>
      Public Function AgregarTotalContarColumna(grilla As UltraGrid, columna As UltraGridColumn) As SummarySettings
         Return AgregarTotalContarColumna(grilla, columna, FormatoDefaultContar)
      End Function
      <Extension()>
      Public Function AgregarTotalContarColumna(grilla As UltraGrid, columna As UltraGridColumn, formato As String) As SummarySettings
         If grilla.DisplayLayout.Bands(0).Summaries.Exists(columna.Key) AndAlso Not grilla.DisplayLayout.Bands(0).Summaries(columna.Key).SourceColumn.Equals(columna) Then
            grilla.DisplayLayout.Bands(0).Summaries.Remove(grilla.DisplayLayout.Bands(0).Summaries(columna.Key))
         End If
         If Not grilla.DisplayLayout.Bands(0).Summaries.Exists(columna.Key) Then
            Return AgregarSummaryColumna(grilla, grilla.DisplayLayout.Bands(0).Summaries.Add(columna.Key, SummaryType.Count, columna), formato)
         End If
         Return Nothing
      End Function
#End Region

#Region "Total Promedio Columna"
      ''' <summary>
      ''' Agrega un total de suma para la columna indicada
      ''' </summary>
      ''' <param name="grilla">Grilla donde agregar la suma</param>
      ''' <param name="columna">Key de la columna a sumarizar</param>
      ''' <returns>La instancia de la grilla que se pasó como parámetro</returns>
      ''' <remarks></remarks>
      <Extension()>
      Public Function AgregarTotalPromedioColumna(grilla As UltraGrid, columna As String, formato As String) As SummarySettings
         If grilla.DisplayLayout.Bands(0).Columns.Exists(columna) Then
            Return AgregarTotalPromedioColumna(grilla, grilla.DisplayLayout.Bands(0).Columns(columna), formato)
         End If
         Return Nothing
      End Function
      ''' <summary>
      ''' Agrega un total de promedio para la columna indicada
      ''' </summary>
      ''' <param name="grilla">Grilla donde agregar la suma</param>
      ''' <param name="columna">Instancia de la columna a sumarizar</param>
      ''' <returns>La instancia de la grilla que se pasó como parámetro</returns>
      ''' <remarks></remarks>
      <Extension()>
      Private Function AgregarTotalPromedioColumna(grilla As UltraGrid, columna As UltraGridColumn, formato As String) As SummarySettings
         If Not grilla.DisplayLayout.Bands(0).Summaries.Exists(columna.Key) Then
            Return AgregarSummaryColumna(grilla, grilla.DisplayLayout.Bands(0).Summaries.Add(columna.Key, SummaryType.Average, columna), formato)
         End If
         Return Nothing
      End Function
#End Region

#Region "Total External Columna"
      ''' <summary>
      ''' Agrega un total de external para la columna indicada
      ''' </summary>
      ''' <param name="grilla">Grilla donde agregar la suma</param>
      ''' <param name="columna">Key de la columna a sumarizar</param>
      ''' <returns>La instancia de la grilla que se pasó como parámetro</returns>
      ''' <remarks></remarks>
      <Extension()>
      Public Function AgregarTotalExternoColumna(grilla As UltraGrid, columna As String, formato As String) As SummarySettings
         If grilla.DisplayLayout.Bands(0).Columns.Exists(columna) Then
            Return AgregarTotalExternoColumna(grilla, grilla.DisplayLayout.Bands(0).Columns(columna), formato)
         End If
         Return Nothing
      End Function
      ''' <summary>
      ''' Agrega un total de external para la columna indicada
      ''' </summary>
      ''' <param name="grilla">Grilla donde agregar la suma</param>
      ''' <param name="columna">Instancia de la columna a sumarizar</param>
      ''' <returns>La instancia de la grilla que se pasó como parámetro</returns>
      ''' <remarks></remarks>
      <Extension()>
      Private Function AgregarTotalExternoColumna(grilla As UltraGrid, columna As UltraGridColumn, formato As String) As SummarySettings
         If Not grilla.DisplayLayout.Bands(0).Summaries.Exists(columna.Key) Then
            Return AgregarSummaryColumna(grilla, grilla.DisplayLayout.Bands(0).Summaries.Add(columna.Key, SummaryType.External, columna), formato)
         End If
         Return Nothing
      End Function
#End Region

#Region "Count Columna"
      ''' <summary>
      ''' Agrega un count para la columna indicada
      ''' </summary>
      ''' <param name="grilla">Grilla donde agregar el count</param>
      ''' <param name="columna">Instancia de la columna a sumarizar</param>
      ''' <returns>La instancia de la grilla que se pasó como parámetro</returns>
      ''' <remarks></remarks>
      <Extension()>
      Public Function AgregarCountColumna(grilla As UltraGrid, columna As UltraGridColumn) As SummarySettings
         Return AgregarCountColumna(grilla, columna, FormatoDefaultTotales)
      End Function
      <Extension()>
      Private Function AgregarCountColumna(grilla As UltraGrid, columna As UltraGridColumn, formato As String) As SummarySettings
         If Not grilla.DisplayLayout.Bands(0).Summaries.Exists(columna.Key) Then
            Return AgregarSummaryColumna(grilla, grilla.DisplayLayout.Bands(0).Summaries.Add(columna.Key, SummaryType.Count, columna), formato)
         End If
         Return Nothing
      End Function
#End Region

#Region "Quitar Total"
      <Extension()>
      Public Function QuitarTotalSumaColumna(grilla As UltraGrid, columna As UltraGridColumn) As UltraGrid
         Return QuitarTotalSumaColumna(grilla, columna.Key)
      End Function
      <Extension()>
      Public Function QuitarTotalSumaColumna(grilla As UltraGrid, columna As String) As UltraGrid
         If grilla.DisplayLayout.Bands(0).Summaries.Exists(columna) Then
            Return QuitarTotalSumaColumna(grilla, grilla.DisplayLayout.Bands(0).Summaries(columna))
         End If
         Return grilla
      End Function
      <Extension()>
      Public Function QuitarTotalSumaColumna(grilla As UltraGrid, summary As SummarySettings) As UltraGrid
         grilla.DisplayLayout.Bands(0).Summaries.Remove(summary)
         Return grilla
      End Function
#End Region

#Region "CustomSummary"
      <Extension()>
      Public Function AgregarTotalCustomColumna(grilla As UltraGrid, columna As String, customSummary As ICustomSummaryCalculator) As SummarySettings
         If grilla.DisplayLayout.Bands(0).Columns.Exists(columna) Then
            Return AgregarTotalCustomColumna(grilla, grilla.DisplayLayout.Bands(0).Columns(columna), customSummary, FormatoDefaultTotales)
         End If
         Return Nothing
      End Function
      <Extension()>
      Private Function AgregarTotalCustomColumna(grilla As UltraGrid, columna As UltraGridColumn, customSummary As ICustomSummaryCalculator, formato As String) As SummarySettings
         If Not grilla.DisplayLayout.Bands(0).Summaries.Exists(columna.Key) Then
            Return AgregarSummaryColumna(grilla,
                                         grilla.DisplayLayout.Bands(0).Summaries.Add(columna.Key, SummaryType.Custom, customSummary, columna,
                                                                                     SummaryPosition.UseSummaryPositionColumn, columna),
                                         formato)
         End If
         Return Nothing
      End Function
#End Region
      <Extension()>
      Public Function AgregarSummaryColumna(grilla As UltraGrid, summary As SummarySettings, formato As String) As SummarySettings
         If String.IsNullOrWhiteSpace(formato) Then formato = FormatoDefaultTotales
         summary = summary
         summary.DisplayFormat = formato
         summary.Appearance.TextHAlign = HAlign.Right
         summary.GroupBySummaryValueAppearance.TextHAlign = HAlign.Right
         Return summary
      End Function
#End Region

#Region "Formateo de columnas"
      ''' <summary>
      ''' Permite formatear rápidamente una columna de la grilla
      ''' </summary>
      ''' <param name="col">Columna a formatear</param>
      ''' <param name="caption">Titulo para la columna</param>
      ''' <param name="posicion">Posición en la grilla</param>
      ''' <param name="ancho">Ancho de la columna</param>
      ''' <param name="alineacion">Alineación (opcional)</param>
      ''' <param name="hidden">Oculto o Visible (opcional)</param>
      ''' <returns>La instancia de la columna que se pasó como parámetro</returns>
      ''' <remarks></remarks>
      <Extension()>
      Public Function FormatearColumna(col As UltraGridColumn, caption As String,
                                       ByRef posicion As Integer, ancho As Integer,
                                       Optional alineacion As HAlign = HAlign.Default,
                                       Optional hidden As Boolean = False,
                                       Optional format As String = "",
                                       Optional maskInput As String = "",
                                       Optional cellActivation As Activation = Activation.ActivateOnly,
                                       Optional promptChar As String = " ") As UltraGridColumn
         col.Hidden = hidden
         col.Header.Caption = caption
         If posicion > -1 Then
            col.Header.VisiblePosition = posicion
         End If
         col.Width = ancho
         col.CellAppearance.TextHAlign = alineacion

         If Not String.IsNullOrWhiteSpace(format) Then
            col.Format = format
         End If
         If Not String.IsNullOrWhiteSpace(maskInput) Then
            col.MaskInput = maskInput
            col.PromptChar = promptChar(0)
         End If

         col.CellActivation = cellActivation

         posicion += 1
         Return col
      End Function
      <Extension()>
      Public Function AnchoMinimoMaximo(col As UltraGridColumn,
                                        minWidth As Integer?,
                                        maxWidth As Integer?) As UltraGridColumn
         If minWidth.HasValue Then
            col.MinWidth = minWidth.Value
         End If
         If maxWidth.HasValue Then
            col.MaxWidth = maxWidth.Value
         End If

         Return col
      End Function
      <Extension()>
      Public Function OcultoPosicion(col As UltraGridColumn,
                                     hidden As Boolean,
                                     ByRef posicion As Integer) As UltraGridColumn
         col.Hidden = hidden
         col.Header.VisiblePosition = posicion

         posicion += 1
         Return col
      End Function


      <Extension()>
      Public Function FormatoMaskInput(col As UltraGridColumn,
                                       formato As String,
                                       maskInput As String) As UltraGridColumn
         col.Format = formato
         col.MaskInput = maskInput
         col.PromptChar = " "c

         Return col
      End Function

#End Region

#Region "Generales"
      ''' <summary>
      ''' Agrega los filtros en la primer fila de la grilla
      ''' </summary>
      ''' <param name="grilla">Grilla a inicializar</param>
      ''' <param name="columnasParaFijar">Array con las keys de las columnas que estarán fijas por defecto</param>
      ''' <returns>La instancia de la grilla que se pasó como parámetro</returns>
      ''' <remarks></remarks>
      <Extension()>
      Public Function ColumnasFijas(grilla As UltraGrid, columnasParaFijar As String()) As UltraGrid

         grilla.DisplayLayout.UseFixedHeaders = True
         grilla.DisplayLayout.Override.FixedCellSeparatorColor = Color.Red
         grilla.DisplayLayout.Bands(0).Override.FixedHeaderIndicator = FixedHeaderIndicator.None

         For Each columna As String In columnasParaFijar
            With grilla.DisplayLayout.Bands(0)
               If .Columns.Exists(columna) Then
                  .Columns(columna).Header.Fixed = True
               End If
            End With
         Next

         Return grilla
      End Function

#End Region

   End Module
End Namespace