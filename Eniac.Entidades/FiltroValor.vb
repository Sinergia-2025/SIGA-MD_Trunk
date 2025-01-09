Public Class FiltroValor
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdTipoFiltro
      IdNombreFiltro
      IdColumna
      IdRegistro
      Valor
   End Enum

#Region "Propiedades"

   Private _idTipoFiltro As String
   Public Property IdTipoFiltro() As String
      Get
         Return _idTipoFiltro
      End Get
      Set(ByVal value As String)
         _idTipoFiltro = value
      End Set
   End Property

   Private _idNombrefiltro As String
   Public Property IdNombreFiltro() As String
      Get
         Return _idNombrefiltro
      End Get
      Set(ByVal value As String)
         _idNombrefiltro = value
      End Set
   End Property

   Private _idColumna As String
   Public Property IdColumna() As String
      Get
         Return _idColumna
      End Get
      Set(ByVal value As String)
         _idColumna = value
      End Set
   End Property

   Private _idRegistro As Integer
   Public Property IdRegistro() As Integer
      Get
         Return _idRegistro
      End Get
      Set(ByVal value As Integer)
         _idRegistro = value
      End Set
   End Property

   Private _valor As String
   Public Property Valor() As String
      Get
         Return _valor
      End Get
      Set(ByVal value As String)
         _valor = value
      End Set
   End Property

#End Region

End Class
