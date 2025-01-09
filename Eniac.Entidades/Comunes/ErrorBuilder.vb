Public Class ErrorBuilder
   Implements IDisposable

   Public ReadOnly Property FocusOnError As Windows.Forms.Control

   Private _errorCollection As ICollection(Of String)
   Private _warningCollection As ICollection(Of String)
   Private _messageCollection As ICollection(Of String)
   Private disposedValue As Boolean

   Public Sub New()
      _errorCollection = New List(Of String)()
      _warningCollection = New List(Of String)()
      _messageCollection = New List(Of String)()
   End Sub

   Public ReadOnly Property Any As Boolean
      Get
         CheckInstanceDisposed()
         Return _errorCollection.Any() Or _warningCollection.Any() Or _messageCollection.Any()
      End Get
   End Property
   Public ReadOnly Property AnyError As Boolean
      Get
         CheckInstanceDisposed()
         Return _errorCollection.Any()
      End Get
   End Property
   Public ReadOnly Property AnyWarning As Boolean
      Get
         CheckInstanceDisposed()
         Return _warningCollection.Any()
      End Get
   End Property
   Public ReadOnly Property AnyMessage As Boolean
      Get
         CheckInstanceDisposed()
         Return _messageCollection.Any()
      End Get
   End Property

   Public Sub AddError(mensaje As String, focusOnError As Windows.Forms.Control)
      SetFocusOnError(focusOnError)
      AddError(mensaje)
   End Sub

   Public Sub AddError(mensaje As String, ParamArray args As Object())
      AddError(String.Format(mensaje, args))
   End Sub
   Public Sub AddError(mensaje As String)
      CheckInstanceDisposed()
      _errorCollection.Add(mensaje)
   End Sub
   Public Sub AddWarning(mensaje As String)
      CheckInstanceDisposed()
      _warningCollection.Add(mensaje)
   End Sub
   Public Sub AddMessage(mensaje As String)
      CheckInstanceDisposed()
      _messageCollection.Add(mensaje)
   End Sub

   Private Sub SetFocusOnError(focusOnError As Windows.Forms.Control)
      If _FocusOnError Is Nothing Then
         _FocusOnError = focusOnError
      End If
   End Sub

   Public Function ErrorToString() As String
      CheckInstanceDisposed()
      Return String.Join(Environment.NewLine, _errorCollection.Where(Function(s) Not String.IsNullOrWhiteSpace(s)))
   End Function
   Public Function WarningToString() As String
      Return WarningToString(String.Empty)
   End Function
   Public Function WarningToString(newMessage As String) As String
      CheckInstanceDisposed()
      Dim resultColection = _warningCollection.Where(Function(s) Not String.IsNullOrWhiteSpace(s)).ToList()
      If Not String.IsNullOrWhiteSpace(newMessage) Then
         resultColection.Add(newMessage)
      End If
      Return String.Join(Environment.NewLine, resultColection)
   End Function
   Public Function MessageToString() As String
      CheckInstanceDisposed()
      Return String.Join(Environment.NewLine, _messageCollection.Where(Function(s) Not String.IsNullOrWhiteSpace(s)))
   End Function

   Public Overrides Function ToString() As String
      CheckInstanceDisposed()
      Return String.Join(Environment.NewLine, {ErrorToString(), WarningToString(), MessageToString()}.Where(Function(s) Not String.IsNullOrWhiteSpace(s)))
   End Function

   Public Sub PerformFocusOnError()
      If AnyError() And FocusOnError IsNot Nothing Then
         FocusOnError.Focus()
      End If
   End Sub

   Public Sub Clear()
      CheckInstanceDisposed()
      _errorCollection.Clear()
      _warningCollection.Clear()
      _messageCollection.Clear()
   End Sub

#Region "IDisposable"
   Protected Overridable Sub Dispose(disposing As Boolean)
      If Not disposedValue Then
         If disposing Then
            Clear()
            _FocusOnError = Nothing

            _errorCollection = Nothing
            _warningCollection = Nothing
            _messageCollection = Nothing
         End If

         disposedValue = True
      End If
   End Sub

   Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
      Dispose(disposing:=True)
      GC.SuppressFinalize(Me)
   End Sub
   Private Sub CheckInstanceDisposed()
      If disposedValue Then Throw New ObjectDisposedException(Me.GetType().FullName)
   End Sub
#End Region
End Class