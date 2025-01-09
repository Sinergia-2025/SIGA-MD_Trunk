#Region "Option/Imports"
Option Explicit Off
Option Strict Off
Imports Microsoft.Reporting.WinForms
Imports System.Xml.Linq
Imports System.Xml
Imports System.Globalization
#End Region
Public Class VisorReportes

#Region "Campos"

   Private _path As String
   Private _ds1 As Microsoft.Reporting.WinForms.ReportDataSource
   Private _ds2 As Microsoft.Reporting.WinForms.ReportDataSource
   Private i As Integer = 0
   Private _nombreReporte As String

#End Region

#Region "Propiedades"

   Private _imprimeDirecto As Boolean = False
   Public Property ImprimeDirecto() As Boolean
      Get
         Return _imprimeDirecto
      End Get
      Set(ByVal value As Boolean)
         _imprimeDirecto = value
      End Set
   End Property

   Private _dllExterna As String
   Public Property DllExterna() As String
      Get
         Return _dllExterna
      End Get
      Set(ByVal value As String)
         _dllExterna = value
      End Set
   End Property

   Private _destinatarios As String = String.Empty
   Public Property Destinatarios() As String
      Get
         Return _destinatarios
      End Get
      Set(ByVal value As String)
         _destinatarios = value
      End Set
   End Property

   Public Property DisplayModeInicial() As DisplayMode
      Get
         Return rvReporte.DisplayMode
      End Get
      Set(ByVal value As DisplayMode)
         rvReporte.SetDisplayMode(value)
         If value = DisplayMode.PrintLayout Then
            rvReporte.ZoomMode = ZoomMode.PageWidth
            Me.WindowState = FormWindowState.Maximized
         End If
      End Set
   End Property

   ' # Se creo esta propiedad para poder guardar el total de páginas que tiene el reporte, aún cuando el reporte ya está cerrado.
   ' # El problema surgió en el LibroIvaComprasV2, cuando al abrir la impresión automaticamente preguntaba si se había grabado correctamente el libro.
   ' # En ese momento cuando se le daba que 'SI', se guardaba el total de páginas del reporte(cuando el reporte aún estaba abierto) y se cerraba.
   ' # Pero si el reporte estaba cerrado, ya no se podía ejecutar el método para obtener el total de páginas (rvReporte.LocalReport.GetTotalPages()).
   Private _totalPages As Integer
   Public Property GetTotalPages() As Integer
      Get
         Return _totalPages
      End Get
      Set(value As Integer)
         _totalPages = value
      End Set
   End Property

#End Region

#Region "Constructores"

   Public Sub New(cantidadCopias As Integer)
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      rvReporte.Messages = New ViewerCustomMessages()

      Me._path = System.Windows.Forms.Application.StartupPath + "\"
      Me.rvReporte.LocalReport.EnableExternalImages = True

      Dim llamador As String = New StackTrace(System.Threading.Thread.CurrentThread, True).GetFrame(2).GetMethod().Module.Assembly.GetName().Name
      Select Case llamador
         Case "Eniac.Sueldos.Win", "Eniac.Fichas.Win", "Eniac.Service.Win"
            Me.DllExterna = llamador + ".dll"
         Case Else
      End Select

      '# Asigno la cantidad de copias
      Me.rvReporte.PrinterSettings.Copies = cantidadCopias

   End Sub

   Public Sub New(reporteNombre As String,
                  parametros As IEnumerable(Of ReportParameter),
                  reporteEmbebido As Boolean,
                  cantidadCopias As Integer)
      Me.New(cantidadCopias)
      Me._nombreReporte = reporteNombre

      Me.SeteaReporte(reporteNombre, reporteEmbebido)

      Reporte.SeteaParametrosAReporte(Me.rvReporte.LocalReport, parametros)

      ' Me.rvReporte.LocalReport.SetParameters(parametros)
   End Sub

   Public Sub New(reporteNombre As String,
                  reporteDataSource As String,
                  dataSource As DataTable,
                  reporteEmbebido As Boolean,
                  cantidadCopias As Integer)
      Me.New(cantidadCopias)
      Me._nombreReporte = reporteNombre
      Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource1.Name = reporteDataSource
      ReportDataSource1.Value = dataSource

      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource1)

      Me.SeteaReporte(reporteNombre, reporteEmbebido)

   End Sub

   Public Sub New(reporteNombre As String,
                  reporteDataSource As String,
                  dataSource As DataTable,
                  parametros As IEnumerable(Of ReportParameter),
                  reporteEmbebido As Boolean,
                  cantidadCopias As Integer)
      Me.New(reporteNombre, reporteDataSource, dataSource, reporteEmbebido, cantidadCopias)
      'Me.rvReporte.LocalReport.EnableExternalImages = True

      Reporte.SeteaParametrosAReporte(Me.rvReporte.LocalReport, parametros)
      'Me.rvReporte.LocalReport.SetParameters(parametros)
   End Sub
   Public Sub New(reporteNombre As String,
                  reporteDataSource As String,
                  dataSource As DataTable,
                  reporteDataSource2 As String,
                  dataSource2 As DataTable,
                  parametros As IEnumerable(Of ReportParameter),
                  reporteEmbebido As Boolean,
                  cantidadCopias As Integer)
      Me.New(cantidadCopias)
      Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource1.Name = reporteDataSource
      ReportDataSource1.Value = dataSource
      Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource2.Name = reporteDataSource2
      ReportDataSource2.Value = dataSource2

      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource1)
      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource2)

      Me.SeteaReporte(reporteNombre, reporteEmbebido)
      Try
         Reporte.SeteaParametrosAReporte(Me.rvReporte.LocalReport, parametros)
         'Me.rvReporte.LocalReport.SetParameters(parametros)
      Catch ex As Exception
         Throw ex
      End Try
      'Me.rvReporte.LocalReport.EnableExternalImages = True
   End Sub
   Public Sub New(reporteNombre As String,
                  reporteDataSource As String,
                  dataSource As DataTable,
                  reporteDataSource2 As String,
                  dataSource2 As DataTable,
                  parametros As IEnumerable(Of ReportParameter),
                  reporteEmbebido As Boolean,
                  seteaMargenes As Boolean,
                  cantidadCopias As Integer)
      Me.New(cantidadCopias)
      Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource1.Name = reporteDataSource
      ReportDataSource1.Value = dataSource
      Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource2.Name = reporteDataSource2
      ReportDataSource2.Value = dataSource2

      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource1)
      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource2)

      AddHandler Me.rvReporte.LocalReport.SubreportProcessing, AddressOf SubReporte

      Me.SeteaReporte(reporteNombre, reporteEmbebido)

      Try
         Reporte.SeteaParametrosAReporte(Me.rvReporte.LocalReport, parametros)

         If seteaMargenes Then
            Me.SeteaMargenes()
         End If

         'Me.rvReporte.LocalReport.SetParameters(parametros)
      Catch ex As Exception
         Throw ex
      End Try
      'Me.rvReporte.LocalReport.EnableExternalImages = True
   End Sub

   Public Sub New(reporteNombre As String,
               reporteDataSource As String,
               dataSource As DataTable,
               reporteDataSource2 As String,
               dataSource2 As DataTable,
               reporteDataSource3 As String,
               dataSource3 As DataTable,
               parametros As IEnumerable(Of ReportParameter),
               reporteEmbebido As Boolean,
               seteaMargenes As Boolean,
               cantidadCopias As Integer)

      Me.New(cantidadCopias)
      Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource1.Name = reporteDataSource
      ReportDataSource1.Value = dataSource
      Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource2.Name = reporteDataSource2
      ReportDataSource2.Value = dataSource2
      Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource3.Name = reporteDataSource3
      ReportDataSource3.Value = dataSource3

      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource1)
      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource2)
      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource3)

      AddHandler Me.rvReporte.LocalReport.SubreportProcessing, AddressOf SubReporte

      Me.SeteaReporte(reporteNombre, reporteEmbebido)

      Try
         Reporte.SeteaParametrosAReporte(Me.rvReporte.LocalReport, parametros)

         If seteaMargenes Then
            Me.SeteaMargenes()
         End If

         'Me.rvReporte.LocalReport.SetParameters(parametros)
      Catch ex As Exception
         Throw ex
      End Try

   End Sub

   Public Sub New(reporteNombre As String,
               reporteDataSource As String,
               dataSource As DataTable,
               reporteDataSource2 As String,
               dataSource2 As DataTable,
               reporteDataSource3 As String,
               dataSource3 As DataTable,
               reporteDataSource4 As String,
               dataSource4 As DataTable,
               parametros As IEnumerable(Of ReportParameter),
               reporteEmbebido As Boolean,
               seteaMargenes As Boolean,
               cantidadCopias As Integer)
      Me.New(cantidadCopias)
      Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource1.Name = reporteDataSource
      ReportDataSource1.Value = dataSource
      Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource2.Name = reporteDataSource2
      ReportDataSource2.Value = dataSource2
      Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource3.Name = reporteDataSource3
      ReportDataSource3.Value = dataSource3
      Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource4.Name = reporteDataSource4
      ReportDataSource4.Value = dataSource4

      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource1)
      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource2)
      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource3)
      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource4)

      AddHandler Me.rvReporte.LocalReport.SubreportProcessing, AddressOf SubReporte

      Me.SeteaReporte(reporteNombre, reporteEmbebido)

      Try
         Reporte.SeteaParametrosAReporte(Me.rvReporte.LocalReport, parametros)

         If seteaMargenes Then
            Me.SeteaMargenes()
         End If

         'Me.rvReporte.LocalReport.SetParameters(parametros)
      Catch ex As Exception
         Throw ex
      End Try
      'Me.rvReporte.LocalReport.EnableExternalImages = True
   End Sub

   Public Sub SeteaMargenes()
      'creates a new page setting

      Dim instance As System.Drawing.Printing.PageSettings = rvReporte.GetPageSettings()

      Dim MargenIzquierdo As Integer
      Dim MargenDerecho As Integer

      If Reglas.Publicos.Facturacion.Impresion.FacturacionImpresionMargenIzquierdo = 0 Then
         MargenIzquierdo = Me.rvReporte.LocalReport.GetDefaultPageSettings.Margins.Left
      Else
         MargenIzquierdo = Reglas.Publicos.Facturacion.Impresion.FacturacionImpresionMargenIzquierdo * 3.93700787
      End If

      If Reglas.Publicos.Facturacion.Impresion.FacturacionImpresionMargenDerecho = 0 Then
         MargenDerecho = Me.rvReporte.LocalReport.GetDefaultPageSettings.Margins.Right
      Else
         MargenDerecho = Reglas.Publicos.Facturacion.Impresion.FacturacionImpresionMargenDerecho * 3.93700787
      End If

      'create the new margin values (left,right,top,bottom) 
      Dim value As New System.Drawing.Printing.Margins(MargenIzquierdo, MargenDerecho, Me.rvReporte.LocalReport.GetDefaultPageSettings.Margins.Top, Me.rvReporte.LocalReport.GetDefaultPageSettings.Margins.Bottom)


      'gives your new pagesetting a value
      instance.Margins = value

      'report viewer now sets your margins
      Me.rvReporte.SetPageSettings(instance)

   End Sub

   Public Sub New(reporteNombre As String,
                  reporteDataSource As String,
                  dataSource As DataTable,
                  reporteDataSource2 As String,
                  dataSource2 As DataTable,
                  reporteDataSource3 As String,
                  dataSource3 As DataTable,
                  parametros As IEnumerable(Of ReportParameter),
                  reporteEmbebido As Boolean,
                  cantidadCopias As Integer)
      Me.New(cantidadCopias)
      Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource1.Name = reporteDataSource
      ReportDataSource1.Value = dataSource
      Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource2.Name = reporteDataSource2
      ReportDataSource2.Value = dataSource2
      Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource3.Name = reporteDataSource3
      ReportDataSource3.Value = dataSource3

      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource1)
      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource2)
      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource3)

      Me.SeteaReporte(reporteNombre, reporteEmbebido)

      Reporte.SeteaParametrosAReporte(Me.rvReporte.LocalReport, parametros)
      'Me.rvReporte.LocalReport.SetParameters(parametros)
   End Sub

   Public Sub New(reporteNombre As String,
                  reporteDataSource As String,
                  dataSource As DataTable,
                  reporteDataSource2 As String,
                  dataSource2 As DataTable,
                  reporteDataSource3 As String,
                  dataSource3 As DataTable,
                  reporteDataSource4 As String,
                  dataSource4 As DataTable,
                  parametros As IEnumerable(Of ReportParameter),
                  reporteEmbebido As Boolean,
                  cantidadCopias As Integer)
      Me.New(cantidadCopias)
      Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource1.Name = reporteDataSource
      ReportDataSource1.Value = dataSource
      Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource2.Name = reporteDataSource2
      ReportDataSource2.Value = dataSource2
      Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource3.Name = reporteDataSource3
      ReportDataSource3.Value = dataSource3
      Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource4.Name = reporteDataSource4
      ReportDataSource4.Value = dataSource4

      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource1)
      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource2)
      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource3)
      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource4)

      Me.SeteaReporte(reporteNombre, reporteEmbebido)

      Reporte.SeteaParametrosAReporte(Me.rvReporte.LocalReport, parametros)
      'Me.rvReporte.LocalReport.SetParameters(parametros)
   End Sub

   Public Sub New(reporteNombre As String,
                  reporteDataSource As String,
                  dataSource As DataTable,
                  reporteDataSource2 As String,
                  dataSource2 As DataTable,
                  reporteDataSource3 As String,
                  dataSource3 As DataTable,
                  reporteDataSource4 As String,
                  dataSource4 As DataTable,
                  reporteDataSource5 As String,
                  dataSource5 As DataTable,
                  Parametros As IEnumerable(Of ReportParameter),
                  reporteEmbebido As Boolean,
                  cantidadCopias As Integer)
      Me.New(cantidadCopias)
      Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource1.Name = reporteDataSource
      ReportDataSource1.Value = dataSource
      Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource2.Name = reporteDataSource2
      ReportDataSource2.Value = dataSource2
      Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource3.Name = reporteDataSource3
      ReportDataSource3.Value = dataSource3
      Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource4.Name = reporteDataSource4
      ReportDataSource4.Value = dataSource4
      Dim ReportDataSource5 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource5.Name = reporteDataSource5
      ReportDataSource5.Value = dataSource5


      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource1)
      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource2)
      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource3)
      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource4)
      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource5)

      Me.SeteaReporte(reporteNombre, reporteEmbebido)

      Reporte.SeteaParametrosAReporte(Me.rvReporte.LocalReport, Parametros)
      'Me.rvReporte.LocalReport.SetParameters(parametros)
   End Sub

   Public Sub New(reporteNombre As String,
                  datasSources As DataSet,
                  parametros As IEnumerable(Of ReportParameter),
                  reporteEmbebido As Boolean,
                  cantidadCopias As Integer)
      Me.New(cantidadCopias)

      Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource
      For Each rd As DataTable In datasSources.Tables
         ReportDataSource1 = New Microsoft.Reporting.WinForms.ReportDataSource
         ReportDataSource1.Name = rd.TableName
         ReportDataSource1.Value = rd
         Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource1)
      Next

      Me.SeteaReporte(reporteNombre, reporteEmbebido)

      Reporte.SeteaParametrosAReporte(Me.rvReporte.LocalReport, parametros)
      'Me.rvReporte.LocalReport.SetParameters(parametros)
   End Sub

   Public Sub New(reporteNombre As String,
                  datasSource1 As DataTable,
                  datasSource2 As DataTable,
                  parametros As IEnumerable(Of ReportParameter),
                  reporteEmbebido As Boolean,
                  cantidadCopias As Integer)
      Me.New(cantidadCopias)

      Me._ds1 = New Microsoft.Reporting.WinForms.ReportDataSource()
      Me._ds1.Name = datasSource1.TableName
      Me._ds1.Value = datasSource1
      Me.rvReporte.LocalReport.DataSources.Add(Me._ds1)

      Me._ds2 = New Microsoft.Reporting.WinForms.ReportDataSource
      Me._ds2.Name = datasSource2.TableName
      Me._ds2.Value = datasSource2

      Me.SeteaReporte(reporteNombre, reporteEmbebido)

      AddHandler Me.rvReporte.LocalReport.SubreportProcessing, AddressOf SubReporte

      Reporte.SeteaParametrosAReporte(Me.rvReporte.LocalReport, parametros)
      'Me.rvReporte.LocalReport.SetParameters(parametros)

      Me.rvReporte.RefreshReport()
   End Sub

   Public Sub New(reporteNombre As String,
                  datasSource1 As DataTable,
                  datasSource2 As DataTable,
                  reporteEmbebido As Boolean,
                  cantidadCopias As Integer)
      Me.New(cantidadCopias)

      Me._ds1 = New Microsoft.Reporting.WinForms.ReportDataSource()
      Me._ds1.Name = datasSource1.TableName
      Me._ds1.Value = datasSource1
      Me.rvReporte.LocalReport.DataSources.Add(Me._ds1)

      Me._ds2 = New Microsoft.Reporting.WinForms.ReportDataSource
      Me._ds2.Name = datasSource2.TableName
      Me._ds2.Value = datasSource2
      Me.rvReporte.LocalReport.DataSources.Add(Me._ds2)

      Me.SeteaReporte(reporteNombre, reporteEmbebido)

      AddHandler Me.rvReporte.LocalReport.SubreportProcessing, AddressOf SubReporte

      '  Me.rvReporte.LocalReport.SetParameters(Parametros)

      Me.rvReporte.RefreshReport()
   End Sub


   'Traido de Fichas
   Public Sub New(ByVal reporteNombre As String, ByVal reporteDataSource As String, ByVal dataSource As Object, ByVal parametrs As System.Collections.Generic.IEnumerable(Of Microsoft.Reporting.WinForms.ReportParameter), cantidadCopias As Integer)
      Me.New(reporteNombre, reporteDataSource, dataSource, cantidadCopias)
      SeteaReporte(reporteNombre, True)
      Reporte.SeteaParametrosAReporte(Me.rvReporte.LocalReport, parametrs)
      '  Me.rvReporte.LocalReport.SetParameters(parametros)
   End Sub

   Public Sub New(ByVal reporteNombre As String, ByVal reporteDataSource As String, ByVal dataSource As DataTable, ByVal parametros As System.Collections.Generic.IEnumerable(Of Microsoft.Reporting.WinForms.ReportParameter), cantidadCopias As Integer)
      Me.New(reporteNombre, reporteDataSource, dataSource, cantidadCopias)
      SeteaReporte(reporteNombre, True)
      Reporte.SeteaParametrosAReporte(Me.rvReporte.LocalReport, parametros)
      'Me.rvReporte.LocalReport.SetParameters(parametros)
   End Sub

   Public Sub New(ByVal reporteNombre As String, ByVal reporteDataSource As String, ByVal dataSource As Object, cantidadCopias As Integer)
      Me.New(cantidadCopias)
      Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource1.Name = reporteDataSource
      ReportDataSource1.Value = dataSource
      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource1)
      Me.rvReporte.LocalReport.ReportEmbeddedResource = reporteNombre
   End Sub

   Public Sub New(ByVal reporteNombre As String, ByVal reporteDataSource As String, ByVal dataSource As DataTable, ByVal reporteDataSource2 As String, ByVal dataSource2 As DataTable, ByVal parametros As System.Collections.Generic.IEnumerable(Of Microsoft.Reporting.WinForms.ReportParameter), cantidadCopias As Integer)
      Me.New(cantidadCopias)
      Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource1.Name = reporteDataSource
      ReportDataSource1.Value = dataSource
      Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource2.Name = reporteDataSource2
      ReportDataSource2.Value = dataSource2

      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource1)
      Me.rvReporte.LocalReport.DataSources.Add(ReportDataSource2)
      Me.rvReporte.LocalReport.ReportEmbeddedResource = reporteNombre

      Reporte.SeteaParametrosAReporte(Me.rvReporte.LocalReport, parametros)
      '  Me.rvReporte.LocalReport.SetParameters(parametros)
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me.rvReporte.RefreshReport()

   End Sub

   Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)

      MyBase.OnClosing(e)

      'Los reportes que tienen el lenguage es-AR dan vuelta la configuracion regional. 
      Reglas.Publicos.VerificaConfiguracionRegional()

      ' # Guardo el total de páginas del reporte antes que el mismo se cierre por si se necesita utilizarlo cuando el reporte ya está cerrado.
      GetTotalPages = rvReporte.GetTotalPages()

      Me.rvReporte.Dispose()
      Me.rvReporte = Nothing
   End Sub

   Protected Overrides Sub Finalize()
      MyBase.Finalize()
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Try
         If keyData = Keys.Escape Then
            Close()
            Return True
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

#Region "Metodos"

   Public Sub SubReporte(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
      Try

         If e.DataSourceNames(0) = Me._ds1.Name Then
            e.DataSources.Add(_ds1)
            'e.DataSources.Add(_ds3)
         End If

         If e.DataSourceNames(0) = Me._ds2.Name Then
            e.DataSources.Add(_ds2)
            'e.DataSources.Add(_ds3)
         End If

         If e.DataSourceNames(0) = Me._ds2.Name Then
            Dim lr As Microsoft.Reporting.WinForms.LocalReport = DirectCast(sender, Microsoft.Reporting.WinForms.LocalReport)
            Dim dt As DataTable = DirectCast(Me._ds2.Value, DataTable)

            Dim dtS As DataTable = lr.DataSources(Me._ds1.Name).Value

            'Dim datos As EnumerableRowCollection = From conceptos In dt.AsEnumerable() _
            '            Where conceptos.Field(Of String)("idLegajo") = dtS.Rows(i)("Legajo").ToString() _
            '            Select conceptos

            'Dim dtX As DataTable = Nothing

            'dtX = dt.Clone()
            'Dim drX As DataRow

            'For Each dr As DataRow In datos
            '   drX = dtX.NewRow()
            '   drX.ItemArray = dr.ItemArray
            '   dtX.Rows.Add(drX)
            'Next

            Dim _ds3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource(dt.TableName, dt)
            'Dim _ds3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource(dtX.TableName, dtX)
            '_ds3.Name = dtX.TableName
            '_ds3.Value = dtX

            e.DataSources.Add(_ds3)
            i += 1
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         'i += 1
      End Try
   End Sub

   Private _dtTurismo As TurismoDataSet.CuotasDataTable
   Private _punteroParaTurismo As Integer
   ' # New creado para Impresión Masiva de Cuotas, con Turismo DataSet
   Public Sub New(nombreReporte As String,
                  dtTurismo As TurismoDataSet.CuotasDataTable,
                  embebido As Boolean,
                  parametros As IEnumerable(Of ReportParameter))

#Disable Warning BC42104 ' Variable is used before it has been assigned a value
      Me.New(cantidadCopias)
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
      _dtTurismo = dtTurismo
      ' # Seteo el Contador en 0
      _punteroParaTurismo = 0
      Me._ds1 = New Microsoft.Reporting.WinForms.ReportDataSource()
      Me._ds1.Name = dtTurismo.TableName
      Me._ds1.Value = dtTurismo

      ' # Agrego el set de datos al DS del LocalReport
      Me.rvReporte.LocalReport.DataSources.Add(Me._ds1)

      Me.SeteaReporte(nombreReporte, embebido)

      AddHandler Me.rvReporte.LocalReport.SubreportProcessing, AddressOf SubReporteTurismo

      Reporte.SeteaParametrosAReporte(Me.rvReporte.LocalReport, parametros)
      '  Me.rvReporte.LocalReport.SetParameters(Parametros)

      Me.rvReporte.RefreshReport()

   End Sub

   Public Sub SubReporteTurismo(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
      Try

         'Dim dsTurismo As Microsoft.Reporting.WinForms.ReportDataSource
         'dsTurismo = New Microsoft.Reporting.WinForms.ReportDataSource
         'dsTurismo.Name = _dtTurismo.TableName + "1"
         'Dim dtTemp As DataTable = _dtTurismo.Clone()
         'dtTemp.ImportRow(_dtTurismo.Rows(_punteroParaTurismo))
         'dsTurismo.Value = dtTemp

         'NumeroCuota

         e.DataSources.Add(_ds1)

         'If e.DataSourceNames(0) = Me._ds1.Name Then



         '   e.DataSources.Add(_ds1)
         '   'e.DataSources.Add(_ds3)
         'End Ifs
         _punteroParaTurismo += 1
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub SeteaReporte(ByVal reporteNombre As String, ByVal reporteEmbebido As Boolean)
      Dim ai As Reglas.ArchivosAImprimir = New Reglas.ArchivosAImprimir()
      Dim aai As Entidades.ArchivoAImprimir = ai.GetUno(actual.Sucursal.Id, reporteNombre)
      If Not String.IsNullOrEmpty(aai.NombreReporteOriginal) Then
         reporteEmbebido = False
         System.IO.File.WriteAllText(Me._path + reporteNombre, aai.ReporteSecundario)
      End If

      If reporteEmbebido Then
         'esto valida si la se ejecuta el reporte en el entorno de la aplicación o hay que ir a buscarlo a un assembly
         If String.IsNullOrEmpty(Me.DllExterna) Then
            Me.rvReporte.LocalReport.ReportEmbeddedResource = reporteNombre
         Else
            Dim asembl As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(My.Application.Info.DirectoryPath + "\" + DllExterna)
            Dim str As System.IO.Stream = asembl.GetManifestResourceStream(reporteNombre)
            Me.rvReporte.LocalReport.LoadReportDefinition(str)
            asembl = Nothing
            'Me.rvReporte.LocalReport.LoadSubreportDefinition("Eniac.Sueldos.Win.SueldosEmisionRecibosDetalle.rdlc", str)
         End If
      Else
         Me.rvReporte.LocalReport.ReportPath = Me._path + reporteNombre
      End If
   End Sub

#End Region

#Region "Eventos"

   'Private Sub rvReporte_Print(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles rvReporte.Print
   '   If Not ImprimeDirecto Then
   '      Exit Sub
   '   End If
   '   Try
   '      e.Cancel = True
   '      Dim im As Imprimir = New Imprimir()
   '      Dim printDoc As System.Drawing.Printing.PrintDocument = New System.Drawing.Printing.PrintDocument()

   '      im.Run(Me.rvReporte.LocalReport, printDoc.PrinterSettings.PrinterName, 1, False)
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub

   Private Sub rvReporte_ReportRefresh(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles rvReporte.ReportRefresh
   End Sub

   Private Sub btnEnviarPorMail_Click(sender As System.Object, e As System.EventArgs) Handles btnEnviarPorMail.Click
      Dim warn As Warning()
      Dim streamids As String()
      Dim mimeType As String = String.Empty
      Dim encoding As String = String.Empty
      Dim extension As String = String.Empty
      Dim deviceinfo As StringBuilder = New StringBuilder
      Dim settings As ReportPageSettings = rvReporte.LocalReport.GetDefaultPageSettings()
      Dim fs As System.IO.FileStream
      Try

         With deviceinfo
            .AppendFormatLine("<DeviceInfo>")
            .AppendFormatLine("  <OutputFormat>EMF</OutputFormat>")
            If settings.IsLandscape Then
               .AppendFormatLine("  <PageWidth>{0}in</PageWidth>", settings.PaperSize.Height / 100)
               .AppendFormatLine("  <PageHeight>{0}in</PageHeight>", settings.PaperSize.Width / 100)
            Else
               .AppendFormatLine("  <PageWidth>{0}in</PageWidth>", settings.PaperSize.Width / 100)
               .AppendFormatLine("  <PageHeight>{0}in</PageHeight>", settings.PaperSize.Height / 100)
            End If
            .AppendFormatLine("  <MarginTop>{0}in</MarginTop>", settings.Margins.Top / 100)
            .AppendFormatLine("  <MarginLeft>{0}in</MarginLeft>", settings.Margins.Left / 100)
            .AppendFormatLine("  <MarginRight>{0}in</MarginRight>", settings.Margins.Right / 100)
            .AppendFormatLine("  <MarginBottom>{0}in</MarginBottom>", settings.Margins.Bottom / 100)
            .AppendFormatLine("</DeviceInfo>")
         End With

         If Not System.IO.Directory.Exists("c:\Eniac\temp") Then
            System.IO.Directory.CreateDirectory("c:\Eniac\temp")
         End If

         Dim nombreArchivo As String = "C:\Eniac\temp\" + Publicos.NormalizarNombreArchivo(Me.Text) + ".pdf"

#Disable Warning BC42030 ' Variable is passed by reference before it has been assigned a value
         byteviewer = rvReporte.LocalReport.Render("PDF", deviceinfo.ToString(), mimeType, encoding, extension, streamids, warn)
#Enable Warning BC42030 ' Variable is passed by reference before it has been assigned a value
         fs = New System.IO.FileStream(nombreArchivo, IO.FileMode.Create)
         fs.Write(byteviewer, 0, byteviewer.Length)
         fs.Close()

         Dim m As MensajeMail = New MensajeMail()
         m.txtDestinatarios.Text = Me.Destinatarios
         If System.IO.File.Exists(nombreArchivo) Then
            m.ArchivoAAdjuntar = nombreArchivo
            m.lblAdjuntos.Text = "Archivo adjunto: " + nombreArchivo
         End If
         m.txtAsunto.Text = Reglas.Publicos.NombreFantasia + " - " + Me.Text
         'm.txtDestinatarios.Text = Publicos.MailDireccion
         m.ShowDialog()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         fs = Nothing
      End Try
   End Sub

#End Region


   Public Class ViewerCustomMessages
      Implements IReportViewerMessages

      Public ReadOnly Property BackButtonToolTip As String Implements IReportViewerMessages.BackButtonToolTip
         Get
            Return "Atrás"
         End Get
      End Property

      Public ReadOnly Property BackMenuItemText As String Implements IReportViewerMessages.BackMenuItemText
         Get
            Return "Atrás"
         End Get
      End Property

      Public ReadOnly Property ChangeCredentialsText As String Implements IReportViewerMessages.ChangeCredentialsText
         Get
            Return Nothing
         End Get
      End Property

      Public ReadOnly Property CurrentPageTextBoxToolTip As String Implements IReportViewerMessages.CurrentPageTextBoxToolTip
         Get
            Return "Página Actual"
         End Get
      End Property

      Public ReadOnly Property DocumentMapButtonToolTip As String Implements IReportViewerMessages.DocumentMapButtonToolTip
         Get
            Return Nothing
         End Get
      End Property

      Public ReadOnly Property DocumentMapMenuItemText As String Implements IReportViewerMessages.DocumentMapMenuItemText
         Get
            Return Nothing
         End Get
      End Property

      Public ReadOnly Property ExportButtonToolTip As String Implements IReportViewerMessages.ExportButtonToolTip
         Get
            Return "Exportar"
         End Get
      End Property

      Public ReadOnly Property ExportMenuItemText As String Implements IReportViewerMessages.ExportMenuItemText
         Get
            Return Nothing
         End Get
      End Property

      Public ReadOnly Property FalseValueText As String Implements IReportViewerMessages.FalseValueText
         Get
            Return "Falso"
         End Get
      End Property

      Public ReadOnly Property FindButtonText As String Implements IReportViewerMessages.FindButtonText
         Get
            Return "Buscar"
         End Get
      End Property

      Public ReadOnly Property FindButtonToolTip As String Implements IReportViewerMessages.FindButtonToolTip
         Get
            Return "Buscar"
         End Get
      End Property

      Public ReadOnly Property FindNextButtonText As String Implements IReportViewerMessages.FindNextButtonText
         Get
            Return "Siguiente"
         End Get
      End Property

      Public ReadOnly Property FindNextButtonToolTip As String Implements IReportViewerMessages.FindNextButtonToolTip
         Get
            Return "Buscar Siguiente"
         End Get
      End Property

      Public ReadOnly Property FirstPageButtonToolTip As String Implements IReportViewerMessages.FirstPageButtonToolTip
         Get
            Return "Primera Página"
         End Get
      End Property

      Public ReadOnly Property LastPageButtonToolTip As String Implements IReportViewerMessages.LastPageButtonToolTip
         Get
            Return "Última Página"
         End Get
      End Property

      Public ReadOnly Property NextPageButtonToolTip As String Implements IReportViewerMessages.NextPageButtonToolTip
         Get
            Return "Siguiente Página"
         End Get
      End Property

      Public ReadOnly Property NoMoreMatches As String Implements IReportViewerMessages.NoMoreMatches
         Get
            Return "No se encontraron más coincidencias"
         End Get
      End Property

      Public ReadOnly Property NullCheckBoxText As String Implements IReportViewerMessages.NullCheckBoxText
         Get
            Return Nothing
         End Get
      End Property

      Public ReadOnly Property NullCheckBoxToolTip As String Implements IReportViewerMessages.NullCheckBoxToolTip
         Get
            Return Nothing
         End Get
      End Property

      Public ReadOnly Property NullValueText As String Implements IReportViewerMessages.NullValueText
         Get
            Return Nothing
         End Get
      End Property

      Public ReadOnly Property PageOf As String Implements IReportViewerMessages.PageOf
         Get
            Return "de"
         End Get
      End Property

      Public ReadOnly Property PageSetupButtonToolTip As String Implements IReportViewerMessages.PageSetupButtonToolTip
         Get
            Return "Configuración de página"
         End Get
      End Property

      Public ReadOnly Property PageSetupMenuItemText As String Implements IReportViewerMessages.PageSetupMenuItemText
         Get
            Return Nothing
         End Get
      End Property

      Public ReadOnly Property ParameterAreaButtonToolTip As String Implements IReportViewerMessages.ParameterAreaButtonToolTip
         Get
            Return Nothing
         End Get
      End Property

      Public ReadOnly Property PasswordPrompt As String Implements IReportViewerMessages.PasswordPrompt
         Get
            Return Nothing
         End Get
      End Property

      Public ReadOnly Property PreviousPageButtonToolTip As String Implements IReportViewerMessages.PreviousPageButtonToolTip
         Get
            Return "Página Anterior"
         End Get
      End Property

      Public ReadOnly Property PrintButtonToolTip As String Implements IReportViewerMessages.PrintButtonToolTip
         Get
            Return "Imprimir"
         End Get
      End Property

      Public ReadOnly Property PrintLayoutButtonToolTip As String Implements IReportViewerMessages.PrintLayoutButtonToolTip
         Get
            Return "Formato de Impresión"
         End Get
      End Property

      Public ReadOnly Property PrintLayoutMenuItemText As String Implements IReportViewerMessages.PrintLayoutMenuItemText
         Get
            Return "Formato de Impresión"
         End Get
      End Property

      Public ReadOnly Property PrintMenuItemText As String Implements IReportViewerMessages.PrintMenuItemText
         Get
            Return "Imprimir"
         End Get
      End Property

      Public ReadOnly Property ProgressText As String Implements IReportViewerMessages.ProgressText
         Get
            Return Nothing
         End Get
      End Property

      Public ReadOnly Property RefreshButtonToolTip As String Implements IReportViewerMessages.RefreshButtonToolTip
         Get
            Return "Refrescar"
         End Get
      End Property

      Public ReadOnly Property RefreshMenuItemText As String Implements IReportViewerMessages.RefreshMenuItemText
         Get
            Return "Refrescar"
         End Get
      End Property

      Public ReadOnly Property SearchTextBoxToolTip As String Implements IReportViewerMessages.SearchTextBoxToolTip
         Get
            Return "Buscar Texto en el Reporte"
         End Get
      End Property

      Public ReadOnly Property SelectAll As String Implements IReportViewerMessages.SelectAll
         Get
            Return "Seleccionar Todo"
         End Get
      End Property

      Public ReadOnly Property SelectAValue As String Implements IReportViewerMessages.SelectAValue
         Get
            Return "Seleccione un Valor"
         End Get
      End Property

      Public ReadOnly Property StopButtonToolTip As String Implements IReportViewerMessages.StopButtonToolTip
         Get
            Return "Detener Visualización"
         End Get
      End Property

      Public ReadOnly Property StopMenuItemText As String Implements IReportViewerMessages.StopMenuItemText
         Get
            Return "Detener Visualización"
         End Get
      End Property

      Public ReadOnly Property TextNotFound As String Implements IReportViewerMessages.TextNotFound
         Get
            Return "No se encontró el texto"
         End Get
      End Property

      Public ReadOnly Property TotalPagesToolTip As String Implements IReportViewerMessages.TotalPagesToolTip
         Get
            Return "Páginas Totales"
         End Get
      End Property

      Public ReadOnly Property TrueValueText As String Implements IReportViewerMessages.TrueValueText
         Get
            Return "Verdadero"
         End Get
      End Property

      Public ReadOnly Property UserNamePrompt As String Implements IReportViewerMessages.UserNamePrompt
         Get
            Return Nothing
         End Get
      End Property

      Public ReadOnly Property ViewReportButtonText As String Implements IReportViewerMessages.ViewReportButtonText
         Get
            Return Nothing
         End Get
      End Property

      Public ReadOnly Property ViewReportButtonToolTip As String Implements IReportViewerMessages.ViewReportButtonToolTip
         Get
            Return Nothing
         End Get
      End Property

      Public ReadOnly Property ZoomControlToolTip As String Implements IReportViewerMessages.ZoomControlToolTip
         Get
            Return Nothing
         End Get
      End Property

      Public ReadOnly Property ZoomMenuItemText As String Implements IReportViewerMessages.ZoomMenuItemText
         Get
            Return Nothing
         End Get
      End Property

      Public ReadOnly Property ZoomToPageWidth As String Implements IReportViewerMessages.ZoomToPageWidth
         Get
            Return "Ancho de Página"
         End Get
      End Property

      Public ReadOnly Property ZoomToWholePage As String Implements IReportViewerMessages.ZoomToWholePage
         Get
            Return "Página Completa"
         End Get
      End Property
   End Class

End Class