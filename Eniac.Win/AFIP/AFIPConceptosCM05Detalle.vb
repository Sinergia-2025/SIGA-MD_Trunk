﻿Public Class AFIPConceptosCM05Detalle

#Region "Campos"

   Private _publicos As Publicos

#End Region

   Private ReadOnly Property ConceptoCM05 As Entidades.AFIPConceptoCM05
      Get
         Return DirectCast(_entidad, Entidades.AFIPConceptoCM05)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.AFIPConceptoCM05)
      Me.New()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            _publicos.CargaComboDesdeEnum(cmbTipoConceptoCM05, GetType(Entidades.AFIPConceptoCM05.TiposConceptosCM05))

            BindearControles(_entidad)

            If Me.StateForm = Eniac.Win.StateForm.Insertar Then
               CargarProximoNumero()
               ConceptoCM05.Usuario = actual.Nombre
            Else

            End If
         End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.AFIPConceptosCM05()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      Return MyBase.ValidarDetalle()
   End Function

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      txtCodigo.Text = (New Reglas.AFIPConceptosCM05().GetCodigoMaximo() + 1).ToString()
   End Sub

#End Region

End Class