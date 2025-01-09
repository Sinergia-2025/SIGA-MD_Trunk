Option Strict On
Option Explicit On
Public Class PersonalizacionDeInformes
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "PersonalizacionDeInformes"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "PersonalizacionDeInformes"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.PersonalizacionDeInformes = New SqlServer.PersonalizacionDeInformes(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.PersonalizacionDeInformes(Me.da).PersonalizacionDeInformes_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.PersonalizacionDeInforme = DirectCast(entidad, Entidades.PersonalizacionDeInforme)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.PersonalizacionDeInformes = New SqlServer.PersonalizacionDeInformes(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.PersonalizacionDeInformes_I(en.IdInforme, en.NombreArchivo, en.Embebido)
            Case TipoSP._U
               sqlC.PersonalizacionDeInformes_U(en.IdInforme, en.NombreArchivo, en.Embebido)
            Case TipoSP._D
               sqlC.PersonalizacionDeInformes_D(en.IdInforme)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.PersonalizacionDeInforme, ByVal dr As DataRow)
      With o
         .IdInforme = dr(Entidades.PersonalizacionDeInforme.Columnas.IdInforme.ToString()).ToString()
         .NombreInforme = Publicos.GetEnumString(DirectCast([Enum].Parse(GetType(Entidades.PersonalizacionDeInforme.Informes), .IdInforme), Entidades.PersonalizacionDeInforme.Informes))
         .NombreArchivo = dr(Entidades.PersonalizacionDeInforme.Columnas.NombreArchivo.ToString()).ToString()
         .Embebido = Boolean.Parse(dr(Entidades.PersonalizacionDeInforme.Columnas.Embebido.ToString()).ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idInforme As String, accionSiNoExiste As AccionesSiNoExisteRegistro) As Entidades.PersonalizacionDeInforme
      Dim dt As DataTable = New SqlServer.PersonalizacionDeInformes(Me.da).PersonalizacionDeInformes_G1(idInforme)
      Dim o As Entidades.PersonalizacionDeInforme = New Entidades.PersonalizacionDeInforme()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      Else
         If accionSiNoExiste = AccionesSiNoExisteRegistro.Excepcion Then
            Throw New Exception(String.Format("No existe la Personalización de Informes con IdInforme ´{0}´.", idInforme))
         ElseIf accionSiNoExiste = AccionesSiNoExisteRegistro.Nulo Then
            Return Nothing
         End If
      End If
      Return o
   End Function

   Public Function ResolverInformePersonalizado(idInforme As Eniac.Entidades.PersonalizacionDeInforme.Informes,
                                                nombreArchivoDefault As String) As Entidades.InformePersonalizadoResuelto
      Dim result As Entidades.InformePersonalizadoResuelto = New Entidades.InformePersonalizadoResuelto(nombreArchivoDefault)
      Dim pdi As Eniac.Entidades.PersonalizacionDeInforme
      pdi = New Eniac.Reglas.PersonalizacionDeInformes().GetUno(idInforme.ToString(), Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
      If pdi IsNot Nothing Then
         result.NombreArchivo = pdi.NombreArchivo
         result.ReporteEmbebido = pdi.Embebido
      End If
      Return result
   End Function

   Public Function GetTodos() As List(Of Entidades.PersonalizacionDeInforme)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.PersonalizacionDeInforme
      Dim oLis As List(Of Entidades.PersonalizacionDeInforme) = New List(Of Entidades.PersonalizacionDeInforme)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.PersonalizacionDeInforme()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

#End Region
End Class