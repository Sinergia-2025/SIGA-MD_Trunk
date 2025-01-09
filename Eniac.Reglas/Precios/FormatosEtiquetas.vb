Option Strict On
Option Explicit On
Public Class FormatosEtiquetas
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.FormatoEtiqueta.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.FormatoEtiqueta), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.FormatoEtiqueta), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.FormatoEtiqueta), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.FormatosEtiquetas = New SqlServer.FormatosEtiquetas(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.FormatosEtiquetas(Me.da).FormatosEtiquetas_GA()
   End Function
   Public Overloads Function GetAll(tipo As Entidades.FormatoEtiqueta.Tipos?, activo As Boolean?) As System.Data.DataTable
      Return New SqlServer.FormatosEtiquetas(Me.da).FormatosEtiquetas_GA(tipo, activo)
   End Function
#End Region

#Region "Metodos Privados"


   Private Sub EjecutaSP(en As Entidades.FormatoEtiqueta, tipo As TipoSP)

      Dim sql As SqlServer.FormatosEtiquetas = New SqlServer.FormatosEtiquetas(Me.da)
      Select Case tipo
         Case TipoSP._I
            sql.FormatosEtiquetas_I(en.IdFormatoEtiqueta, en.NombreFormatoEtiqueta, en.Tipo, en.ArchivoAImprimir, en.ArchivoAImprimirEmbebido, en.NombreImpresora, en.ImprimeLote, en.MaximoColumnas, en.UtilizaCabecera, en.SolicitaListaPrecios2, en.Activo)

         Case TipoSP._U
            sql.FormatosEtiquetas_U(en.IdFormatoEtiqueta, en.NombreFormatoEtiqueta, en.Tipo, en.ArchivoAImprimir, en.ArchivoAImprimirEmbebido, en.NombreImpresora, en.ImprimeLote, en.MaximoColumnas, en.UtilizaCabecera, en.SolicitaListaPrecios2, en.Activo)

         Case TipoSP._D
            sql.FormatosEtiquetas_D(en.IdFormatoEtiqueta)

      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.FormatoEtiqueta, dr As DataRow)
      With o
         .IdFormatoEtiqueta = Integer.Parse(dr(Eniac.Entidades.FormatoEtiqueta.Columnas.IdFormatoEtiqueta.ToString()).ToString())
         .NombreFormatoEtiqueta = dr(Eniac.Entidades.FormatoEtiqueta.Columnas.NombreFormatoEtiqueta.ToString()).ToString()
         .Tipo = DirectCast([Enum].Parse(GetType(Entidades.FormatoEtiqueta.Tipos), dr(Eniac.Entidades.FormatoEtiqueta.Columnas.Tipo.ToString()).ToString()), Entidades.FormatoEtiqueta.Tipos)
         .ArchivoAImprimir = dr(Eniac.Entidades.FormatoEtiqueta.Columnas.ArchivoAImprimir.ToString()).ToString()
         .ArchivoAImprimirEmbebido = Boolean.Parse(dr(Eniac.Entidades.FormatoEtiqueta.Columnas.ArchivoAImprimirEmbebido.ToString()).ToString())
         .NombreImpresora = dr(Eniac.Entidades.FormatoEtiqueta.Columnas.NombreImpresora.ToString()).ToString()
         .ImprimeLote = Boolean.Parse(dr(Eniac.Entidades.FormatoEtiqueta.Columnas.ImprimeLote.ToString()).ToString())
         .MaximoColumnas = Integer.Parse(dr(Eniac.Entidades.FormatoEtiqueta.Columnas.MaximoColumnas.ToString()).ToString())
         .UtilizaCabecera = Boolean.Parse(dr(Eniac.Entidades.FormatoEtiqueta.Columnas.UtilizaCabecera.ToString()).ToString())
         .SolicitaListaPrecios2 = Boolean.Parse(dr(Eniac.Entidades.FormatoEtiqueta.Columnas.SolicitaListaPrecios2.ToString()).ToString())
         .Activo = Boolean.Parse(dr(Eniac.Entidades.FormatoEtiqueta.Columnas.Activo.ToString()).ToString())

      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodas() As List(Of Entidades.FormatoEtiqueta)
      Return CargaLista(Me.GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.FormatoEtiqueta())
   End Function
   Public Function GetTodas(tipo As Entidades.FormatoEtiqueta.Tipos?, activo As Boolean?) As List(Of Entidades.FormatoEtiqueta)
      Return CargaLista(Me.GetAll(tipo, activo), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.FormatoEtiqueta())
   End Function

   Public Function GetUno(idFormatoEtiqueta As Integer) As Entidades.FormatoEtiqueta
      Return GetUno(idFormatoEtiqueta, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idFormatoEtiqueta As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.FormatoEtiqueta
      Return CargaEntidad(New SqlServer.FormatosEtiquetas(Me.da).FormatosEtiquetas_G1(idFormatoEtiqueta),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.FormatoEtiqueta(),
                          accion, Function() String.Format("El Formato de Etiqueta {0} no existe. Por favor verifique.", idFormatoEtiqueta))
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.FormatosEtiquetas(da).GetCodigoMaximo()
   End Function

#End Region

End Class