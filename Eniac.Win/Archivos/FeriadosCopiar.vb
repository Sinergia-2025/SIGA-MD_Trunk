Option Strict On
Option Explicit On
Public Class FeriadosCopiar
   Private _publicos As Publicos

   Public ReadOnly Property Feriado As Entidades.Feriado
      Get
         Return DirectCast(_entidad, Entidades.Feriado)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.Feriado)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         If Feriado IsNot Nothing Then
            dtpAnoDesde.Value = New Date(Feriado.FechaFeriado.Year, 1, 1)
         Else
            dtpAnoDesde.Value = New Date(Today.Year - 1, 1, 1)
         End If
         If dtpAnoDesde.Value.Year = Today.Year Then
            dtpAnoHasta.Value = New Date(Today.Year + 1, 1, 1)
         Else
            dtpAnoHasta.Value = New Date(Today.Year, 1, 1)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Sub Aceptar()

      If ShowPregunta(String.Format("¿Está seguro de copiar los feriados del año {0} al año {1}?",
                                    dtpAnoDesde.Value.Year, dtpAnoHasta.Value.Year)) = Windows.Forms.DialogResult.Yes Then
         Dim regla As New Reglas.Feriados()
         regla.CopiarFeriados(dtpAnoDesde.Value.Year, dtpAnoHasta.Value.Year)
         Me.DialogResult = Windows.Forms.DialogResult.OK
         Me.Close()
      End If

      'MyBase.Aceptar()

      'If Not Me.HayError And Me.StateForm = Eniac.Win.StateForm.Insertar Then
      '   Me.Close()
      'End If
   End Sub

#End Region

#Region "Eventos"
   Private Sub dtp_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpAnoDesde.KeyDown, dtpAnoHasta.KeyDown
      PresionarTab(e)
   End Sub
#End Region

End Class