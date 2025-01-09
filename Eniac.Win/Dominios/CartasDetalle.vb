Public Class CartasDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.Carta)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me.BindearControles(Me._entidad)

      If DirectCast(Me._entidad, Entidades.Carta).EsHTML Then
         Me.txtTextoRTF.DataBindings.Add("Rtf", Me._entidad, "TextoRTF", True, DataSourceUpdateMode.OnPropertyChanged, Nothing)
         Me.txtTexto2RTF.DataBindings.Add("Rtf", Me._entidad, "Texto2RTF", True, DataSourceUpdateMode.OnPropertyChanged, Nothing)
      Else
         'Se asigna manualmente porque no tiene la propiedad para el BINDEO.
         Me.txtTextoRTF.Text = DirectCast(Me._entidad, Entidades.Carta).Texto
         Me.txtTexto2RTF.Text = DirectCast(Me._entidad, Entidades.Carta).Texto2
      End If


      'Me.bscCodigoLocalidad.Text = DirectCast(Me._entidad, Entidades.Cliente).Localidad.IdLocalidad.ToString()
      'Y a la inversa cuando se sale.

      'Me.bscCodigoLocalidad.Text = DirectCast(Me._entidad, Entidades.Cliente).Localidad.IdLocalidad.ToString()
      'Y a la inversa cuando se sale.

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Cartas()
   End Function

   Protected Overrides Sub Aceptar()
      'If Not Me.dtpVencimientoContrato.Checked Then
      '   DirectCast(Me._entidad, Entidades.Municipio).FechaVencimientoContrato = Nothing
      'End If

      'Esta oculto y no funciona el Bindeo, siempre guardo RTF y Normal.
      Me.txtTexto.Text = txtTextoRTF.Text
      Me.txtTexto2.Text = txtTexto2RTF.Text

      DirectCast(Me._entidad, Entidades.Carta).Texto = Me.txtTextoRTF.Text
      DirectCast(Me._entidad, Entidades.Carta).Texto2 = Me.txtTexto2RTF.Text

      MyBase.Aceptar()

   End Sub

#End Region

#Region "Eventos"

#End Region

End Class