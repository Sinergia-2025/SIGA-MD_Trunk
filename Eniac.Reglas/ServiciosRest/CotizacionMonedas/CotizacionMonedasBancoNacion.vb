#Region "Option/Imports"
Option Strict On
Option Explicit On
Option Infer On
Imports ScrapySharp.Core
Imports ScrapySharp.Html.Parsing
Imports ScrapySharp.Network
Imports HtmlAgilityPack
Imports ScrapySharp.Extensions
Imports ScrapySharp.Html.Forms
#End Region
Namespace ServiciosRest.CotizacionMonedas
   Friend Class CotizacionMonedasBancoNacion
      Implements ICotizacionMonedas
      Public Function Obtener() As Cotizacion Implements ICotizacionMonedas.Obtener
         Try
            Dim Browser As ScrapingBrowser = New ScrapingBrowser()
            Browser.AllowAutoRedirect = True  '' Browser has many settings you can access in setup
            Browser.AllowMetaRedirect = True
            Browser.Timeout = New TimeSpan(0, 0, 10)
            ''go to the home page

            Dim PageResult As WebPage = Browser.NavigateToPage(New Uri("http://www.bna.com.ar/Personas"))

            '' get first piece of data, the page title
            Dim TitleNode As HtmlNode = PageResult.Html.CssSelect(".navbar-brand").First()
            Dim PageTitle As String = TitleNode.InnerText
            '' get a list of data from a table
            Dim Names As List(Of String) = New List(Of String)()
            ''var Table = PageResult.Html.CssSelect("#PersonTable").First();
            Dim Table = PageResult.Html.CssSelect("#billetes").First()

            Dim compradorStr As String = Table.SelectNodes("table/tbody/tr[1]/td[2]")(0).InnerText.Replace(",", ".")
            Dim vendedorStr As String = Table.SelectNodes("table/tbody/tr[1]/td[3]")(0).InnerText.Replace(",", ".")

            Dim comprador As Decimal = 0
            Dim vendedor As Decimal = 0
            Dim promedio As Decimal = 0

            Decimal.TryParse(compradorStr, comprador)
            Decimal.TryParse(vendedorStr, vendedor)

            promedio = (comprador + vendedor) / 2

            Return New Cotizacion() With {.Comprador = comprador, .Vendedor = vendedor, .Promedio = promedio}
         Catch ex As Exception
            Return New Cotizacion()
         End Try
      End Function
   End Class
End Namespace