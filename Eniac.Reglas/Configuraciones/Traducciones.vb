Option Strict On
Option Explicit On
Public Class Traducciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Eniac.Datos.DataAccess())
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "Traducciones"
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Traducciones(Me.da).Traducciones_GA()
   End Function
#End Region

#Region "Metodos Publicos"
   Public Function GetUno(idFuncion As String, pantalla As String, control As String, idIdioma As String, Optional accionSiNoExiste As AccionesSiNoExisteRegistro = AccionesSiNoExisteRegistro.Excepcion) As Entidades.Traduccion
      Return GetUnoRecursivo(idFuncion, pantalla, control, idIdioma, True, accionSiNoExiste)
   End Function
   Private Function GetUnoRecursivo(idFuncion As String, pantalla As String, control As String, idIdioma As String, continuar As Boolean, Optional accionSiNoExiste As AccionesSiNoExisteRegistro = AccionesSiNoExisteRegistro.Excepcion) As Entidades.Traduccion
      Dim sql As SqlServer.Traducciones = New SqlServer.Traducciones(Me.da)
      Dim dt As DataTable = sql.Traducciones_G1(idFuncion, pantalla, control, idIdioma)
      Dim o As Entidades.Traduccion = New Entidades.Traduccion()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Dim temp As Entidades.Traduccion
         If continuar Then
            'Si no encontró la traducción para la función/pantalla específica busco la traducción para la función específica sin importar la pantalla
            temp = GetUnoRecursivo(idFuncion, String.Empty, control, idIdioma, False, AccionesSiNoExisteRegistro.Nulo)
            If temp Is Nothing Then
               'Si no encontró para la función específica todas las pantallas busco con la aplicación (no importa función) y la pantalla específica
               Dim idAplicacion As String = Publicos.IDAplicacionSinergia
               temp = GetUnoRecursivo(idAplicacion, pantalla, control, idIdioma, False, AccionesSiNoExisteRegistro.Nulo)
               If temp Is Nothing Then
                  'Si no encontró para la aplicación con la pantalla específica busco con la aplicación (no importa función) y sin importar la pantalla
                  temp = GetUnoRecursivo(idAplicacion, String.Empty, control, idIdioma, False, AccionesSiNoExisteRegistro.Nulo)
               End If
            End If
         End If

         If temp IsNot Nothing Then
            'Si encontró algún temp, se lo asigno a o para retornar esa instancia.
            o = temp
         Else
            If accionSiNoExiste = AccionesSiNoExisteRegistro.Excepcion Then
               Throw New Exception(String.Format("No existe la Traduccion con idioma {0}, funcion '{1}', pantalla '{2}' y control {3}.", idIdioma, idFuncion, pantalla, control))
            ElseIf accionSiNoExiste = AccionesSiNoExisteRegistro.Nulo Then
               Return Nothing
            End If
         End If
      End If
      Return o
   End Function

   Public Function GetPorIdioma(ByVal idioma As String) As DataTable
      Return New SqlServer.Traducciones(Me.da).GetPorIdioma(idioma)
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub CargarUno(ByVal o As Entidades.Traduccion, ByVal dr As DataRow)
      With o
         .IdFuncion = dr(Entidades.Traduccion.Columnas.IdFuncion.ToString()).ToString()
         .Control = dr(Entidades.Traduccion.Columnas.Control.ToString()).ToString()
         .IdIdioma = dr(Entidades.Traduccion.Columnas.IdIdioma.ToString()).ToString()
         .Texto = dr(Entidades.Traduccion.Columnas.Texto.ToString()).ToString()
      End With
   End Sub
#End Region

End Class