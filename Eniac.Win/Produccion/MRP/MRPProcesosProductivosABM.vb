#Region "Option"
Option Strict On
Option Explicit On
Imports System.ComponentModel
#End Region
Public Class MRPProcesosProductivosABM
   Implements IConParametros

   Friend WithEvents tsbConsultar As ToolStripButton
   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      tsbConsultar = New ToolStripButton()
      '
      tsbConsultar.Image = My.Resources.view_24
      tsbConsultar.ImageTransparentColor = Color.Magenta
      tsbConsultar.Name = "tsbConsultar"
      tsbConsultar.Size = New Size(65, 26)
      tsbConsultar.Text = "Consultar"

      tstBarra.Items.Insert(tstBarra.Items.IndexOf(tsbBorrar) + 1, tsbConsultar)
   End Sub
   Private Sub tsbConsultar_Click(sender As Object, e As EventArgs) Handles tsbConsultar.Click
      Try
         If dgvDatos.ActiveRow Is Nothing OrElse dgvDatos.ActiveRow.ListObject Is Nothing Then Exit Sub

         Using frm As BaseDetalle = Me.GetDetalle(StateForm.Consultar)
            frm.StateForm = StateForm.Consultar
            If TypeOf (frm) Is IConIdFuncion Then
               DirectCast(frm, IConIdFuncion).IdFuncion = IdFuncion
            End If
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
               ExecuteRefreshGrid()
            End If
         End Using
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
      Me.tsbCopiar.Visible = True
      '-- Modo Pantalla.- ----------------------------------
      tsbConsultar.Visible = (_modo = ModoPantalla.CONSULTA)

      tsbNuevo.Visible = (_modo = ModoPantalla.ABM)
      tsbEditar.Visible = (_modo = ModoPantalla.ABM)
      tsbBorrar.Visible = (_modo = ModoPantalla.ABM)
      tsbCopiar.Visible = (_modo = ModoPantalla.ABM)
      '-----------------------------------------------------
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Or estado = StateForm.Consultar Then
         Return New MRPProcesosProductivosDetalle(DirectCast(Me.GetEntidad(), Entidades.MRPProcesoProductivo))
      End If
      Return New MRPProcesosProductivosDetalle(New Entidades.MRPProcesoProductivo)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.MRPProcesosProductivos()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim eProcProd = New Entidades.MRPProcesoProductivo
      With Me.dgvDatos.ActiveRow
         eProcProd = New Reglas.MRPProcesosProductivos().GetUno(Long.Parse(.Cells("IdProcesoProductivo").Value.ToString()), String.Empty)
      End With
      Return eProcProd
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I
         '-- Oculta todas las columnas.-
         For Each col As UltraGridColumn In .Columns
            col.Hidden = True
         Next
         '-- Setea las Columnas.- 
         .Columns(Entidades.MRPProcesoProductivo.Columnas.CodigoProcesoProductivo.ToString()).FormatearColumna("Código", pos, 80, HAlign.Right)
         .Columns(Entidades.MRPProcesoProductivo.Columnas.DescripcionProceso.ToString()).FormatearColumna("Descripcion", pos, 200)
         .Columns(Entidades.MRPProcesoProductivo.Columnas.IdProductoProceso.ToString()).FormatearColumna("Código Producto", pos, 80, HAlign.Right)
         .Columns("NombreProducto").FormatearColumna("Producto", pos, 200)
         .Columns("NombreMoneda").FormatearColumna("Moneda", pos, 80)
         .Columns(Entidades.MRPProcesoProductivo.Columnas.CostoManoObraInterna.ToString()).FormatearColumna("Costo MO Interno", pos, 80, HAlign.Right,, "N2")
         .Columns(Entidades.MRPProcesoProductivo.Columnas.CostoManoObraExterna.ToString()).FormatearColumna("Costo MO Externo", pos, 80, HAlign.Right,, "N2")
         .Columns(Entidades.MRPProcesoProductivo.Columnas.CostoMateriaPrima.ToString()).FormatearColumna("Costo Materia Prima", pos, 80, HAlign.Right,, "N2")
         .Columns(Entidades.MRPProcesoProductivo.Columnas.CostoTotalProceso.ToString()).FormatearColumna("Costo total Proceso", pos, 80, HAlign.Right,, "N2")

         .Columns(Entidades.MRPProcesoProductivo.Columnas.TiempoTotalProceso.ToString()).FormatearColumna("Tiempo Total", pos, 80, HAlign.Right)
         .Columns(Entidades.MRPProcesoProductivo.Columnas.Activo.ToString()).FormatearColumna("Activo", pos, 80)
         .Columns(Entidades.MRPProcesoProductivo.Columnas.RespetaOrden.ToString()).FormatearColumna("Respeta Orden", pos, 80)

      End With
      '-- Agrega Filtros.- ---
      dgvDatos.AgregarFiltroEnLinea({Entidades.MRPProcesoProductivo.Columnas.CodigoProcesoProductivo.ToString(),
                                     Entidades.MRPProcesoProductivo.Columnas.DescripcionProceso.ToString(),
                                     Entidades.MRPProcesoProductivo.Columnas.IdProductoProceso.ToString(),
                                     "NombreProducto", "CodigoCentroProductor", "Descripcion", "DescripSeccion", "ClaseCentroProductor"})
      '-- Agrega Totales.- ---
      dgvDatos.AgregarTotalesSuma({"CostoManoObraInterna", "CostoManoObraExterna", "CostoMateriaPrima", "CostoTotalProceso"})
   End Sub

#End Region

#Region "Metodos IConParametros"
   Private _modo As ModoPantalla
   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      Dim _parametros = New ParametrosFuncion()
      ConParametrosAyudante.Parse(parametros, GetType(ParametrosPermitidos), _parametros)
      _modo = _parametros.GetValor(Of String)(ParametrosPermitidos.Modo).StringToEnum(ModoPantalla.ABM)
   End Sub

   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return ConParametrosAyudante.ParametrosDisponiblesAyuda(GetType(ParametrosPermitidos))
   End Function
   Public Enum ParametrosPermitidos
      <DefaultValue("ABM"), Description("Modo de trabajo de la pantalla ABM/CONSULTA")> Modo
   End Enum
   Public Enum ModoPantalla
      ABM
      CONSULTA
   End Enum
#End Region

End Class