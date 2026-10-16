# RunStore

Skolprojekt i kursen Programmering med C# (ITHS). Ett skrivbordsprogram byggt med Avalonia och MVVM.
Projektet växer för varje lektion, allt ligger i mappen `Client`.

## Vad ligger var

| Mapp | Vad som ska ligga här |
|---|---|
| `Models` | Klasser som bara håller data: `Product`, `Customer`. Inga metoder som gör något. |
| `Services` | Klasser som hämtar och sparar data: `ProductServices`, `CustomerServices`. Sidorna frågar alltid en service, aldrig filen direkt. |
| `Interfaces` | Kontrakt: `IStorage<T>`, `IProductService`, `ICustomerService`, `IPageViewFactory`. ViewModels pratar med interfacen, inte med klasserna. |
| `Repositories` | `Storage<T>` som läser och skriver en lista till en json-fil. |
| `Helpers` | `ServiceCollectionExtensions` med `AddServices` som registrerar alla klasser för dependency injection, och `ApplicationNameEnum` med sidornas namn. |
| `Factories` | `PageViewFactory` som skapar rätt sida utifrån ett namn i enumen. |
| `Data` | Json-filerna med data, till exempel `Product.json`. Kopieras till bin-mappen vid bygge (se `Client.csproj`). |
| `ViewModels` | En klass per sida med sidans logik och data. Sidorna ärver `PageViewModel`, som ärver `ViewModelBase`. |
| `Views` | En axaml-fil per sida. `ViewLocator` hittar rätt View genom namnet: `ProductsViewModel` visas med `ProductsView`. |
| `Assets` | Bilder, typsnitt och stilfiler. `Styles/AppStyles.axaml` för hela appen, `Styles/MenuButtonStyles.axaml` för menyn. |

Färger och typsnitt finns på ett ställe: `App.axaml` under `Application.Resources`.

## Köra

    cd Client
    dotnet run

I VS Code: välj "Run RunStore" i Run and Debug och tryck F5. Det funkar oavsett vilken fil som är öppen.

## Lägga till något nytt

- **Ny sida:** en klass i `ViewModels` som slutar på `ViewModel`, en axaml i `Views` som slutar på `View`,
  ett fält och en `[RelayCommand]`-metod i `MainWindowViewModel`, en knapp i `MainWindow.axaml`.
- **Ny data i json:** lägg filen i `Data`, lägg till en rad för den i `Client.csproj` som för `Product.json`,
  skapa en service som använder `Storage<T>` på samma sätt som `ProductServices`.
- **Ny modell:** en klass i `Models` med samma fält som json-filen har.

## Ändringar, lektion för lektion

| Datum | Vad |
|---|---|
| 2026-10-02 | Projektet skapat (lektion 16). MVVM med `ViewModelBase`, `MainWindowViewModel` med `CurrentView`, `HomeView` och `ProductsView`, `ViewLocator`. Färger som resurser i `App.axaml`. |
| 2026-10-07 | Logotyp som svg (`Svg.Controls.Skia.Avalonia`), ikoner från Phosphor-fonten i menyn, Montserrat som typsnitt. Menyknapparna fick `Classes="menu"` med egen stilfil. Uppgift 1 lektion 17: sidorna `Orders` och `Customers` med egna ViewModels, Views, commands och knappar. |
| 2026-10-08 | Produktlista: `Product`, `ProductServices`, `ObservableCollection<Product>` i `ProductsViewModel`, `ItemsControl` med rubrikrad i `ProductsView`. `PageTitle` i `ViewModelBase`. `Window`-stil som sätter typsnitt och färger för hela appen. |
| 2026-10-09 | Kundlista på samma sätt. `IStorage<T>` och `Storage<T>` som läser och skriver json. `Data/products.json` och `Data/customers.json`, csproj kopierar `Data/*.json` till bin. try/catch när listorna läses in. Ändra- och Radera-knapp på varje rad. README, F5-konfiguration "Run RunStore". |
| 2026-10-12 | Lektion 20, dependency injection. Paketet `Microsoft.Extensions.DependencyInjection`, `AddServices` i `Helpers`, `IProductService` och `ICustomerService`. ViewModels får sina services i konstruktorn i stället för att skapa dem själva. `App.axaml.cs` bygger en `ServiceProvider` och hämtar `MainWindowViewModel` därifrån. |
| 2026-10-14 | Lektion 21, factory design pattern. `ApplicationNameEnum`, basklassen `PageViewModel` med `PageName`, `PageViewFactory` som skapar sidor via en `Func` som registreras i `AddServices`. `MainWindowViewModel` känner bara fabriken. `Product` är en `record` utan metoder, Ändra och Radera är commands i `ProductsViewModel` med artikelnumret som parameter. Egen konsoldemo av mönstret i `my-work/FactoryDesignPattern`. |

## Frågor jag ska kunna svara på

**Vad är MVVM?**
Model är data (`Product`, `Customer`). View är axaml-filen, det man ser. ViewModel är logiken bakom en sida: den
håller värden och commands som vyn binder till. Vyn vet inte var datan kommer ifrån och ViewModeln vet inte hur
det ser ut. Därför kan jag byta utseende utan att röra logiken, och tvärtom.

**Hur hittar ViewLocator rätt vy?**
Den tar ViewModelns fulla namn, `Client.ViewModels.ProductsViewModel`, byter ut `ViewModel` mot `View` och får
`Client.Views.ProductsView`. Den skapar vyn med `Activator.CreateInstance` och sätter vyns `DataContext` till
ViewModeln. Därför måste namnen sluta exakt på `ViewModel` och `View`.

**Hur funkar navigeringen?**
Knappen i menyn har `Command="{Binding GoToProductsCommand}"`. Metoden `GoToProducts` i `MainWindowViewModel`
sätter `CurrentView = _productViewModel`. I `MainWindow.axaml` finns `<UserControl Content="{Binding CurrentView}"/>`
som visar det som `CurrentView` pekar på, och ViewLocator byter ut ViewModeln mot rätt View.

**Vad gör `[ObservableProperty]`?**
Av fältet `_products` genereras egenskapen `Products`. När den sätts skickas `PropertyChanged`, så alla bindningar
i vyn uppdateras. Klassen måste vara `partial` för att den genererade koden ska kunna läggas till i samma klass.

**Vad gör `[RelayCommand]`?**
Av metoden `GoToHome` genereras `GoToHomeCommand`, ett `ICommand` som en knapp kan binda till. Namnet är alltid
metodnamnet plus `Command`.

**Varför `ObservableCollection` och inte `List`?**
En `ObservableCollection` säger till vyn när något läggs till eller tas bort, så raden dyker upp eller försvinner
direkt. En `List` säger ingenting. Men den säger inte till om en egenskap inuti en `Product` ändras, för `Product`
meddelar inte sina ändringar. Det blir viktigt när Ändra ska fungera på riktigt.

**Vad är `Storage<T>` och `IStorage<T>`?**
`IStorage<T>` är kontraktet: en lagring ska kunna `Read` och `Write` en lista. `Storage<T>` är klassen som gör det
med json. `T` byts mot `Product` eller `Customer`, samma klass funkar för båda. Den läser med
`JsonSerializer.Deserialize<List<T>>` och skriver med `JsonSerializer.Serialize`. Samma `JsonSerializerOptions`
används åt båda håll: camelCase, indenterat, `PropertyNameCaseInsensitive` och en `Encoder` som gör att å, ä och ö
skrivs som bokstäver i filen.

**Varför en service mellan sidan och filen?**
`ProductsViewModel` frågar `ProductServices.ListAllProducts()`, inte filen. Byter vi json mot en databas ändras bara
servicen, sidorna märker ingenting.

**Var ligger json-filen när programmet kör?**
Raden `<None Update="Data/*.json" CopyToOutputDirectory="PreserveNewest" />` i `Client.csproj` kopierar filerna
till `bin/Debug/net10.0/Data` vid bygge. Sökvägen byggs med `Path.Combine(AppContext.BaseDirectory, "Data", "Product.json")`,
så den funkar oavsett varifrån programmet startas. Sparar programmet något hamnar det i bin-mappen, inte i källfilen.

**Vad händer om filen saknas eller är trasig?**
Saknas filen ger `Read` en tom lista, det är `File.Exists`-kollen. Är filen trasig kastar `Deserialize` ett undantag.
`LoadProducts` fångar det i try/catch, skriver meddelandet i terminalen och listan blir tom. Programmet kraschar inte.

**Hur funkar knapparna på raderna?**
Varje rad har sin `Product` som `DataContext`. `Command="{Binding Edit}"` binder direkt till metoden `Edit()` på
produkten, Avalonia kan binda ett command till en metod. Just nu skriver metoderna bara i terminalen. Riktig
radering måste ligga i ViewModeln, för produkten känner inte till listan den ligger i.

**Vad är `x:DataType`?**
Det talar om vilken typ bindningarna gäller, så kompilatorn kan kontrollera att `Name` verkligen finns på `Product`.
Stavfel upptäcks när jag bygger i stället för att bindningen tyst blir tom när programmet kör. På en `DataTemplate`
sätter jag typen för raden, `models:Product`.

**Vad betyder `required` och `string?`**
`required` betyder att fältet måste få ett värde när objektet skapas med `new Product { ... }`, annars klagar
kompilatorn. `string?` betyder att värdet får vara null, till exempel en kund utan telefonnummer.

**Hur funkar stilarna?**
`AppStyles.axaml`: `Window`-stilen sätter typsnitt, textfärg och bakgrund, allt annat ärver dem. `TextBlock.h1` är
sidrubriken, `Label.icon` ikonfonten, `Button.rowIcon` de små knapparna på raderna. `MenuButtonStyles.axaml`: `Button.menu`
för menyknapparna och `Button.menu:pointerover /template/ ContentPresenter` för hur de ser ut när musen är över.
`Classes="menu"` i XAML fungerar som en css-klass, och `Selector="Button.menu"` träffar exakt de knapparna.
`{DynamicResource AccentColor}` hämtar färgen från `App.axaml`.

**Hur kommer ikonerna in?**
`Phosphor.ttf` ligger i `Assets/Fonts`. `<AvaloniaResource Include="Assets\**" />` packar in allt under Assets i
programmet. `App.axaml` gör fonten till resursen `IconFont` med adressen `avares://Client/Assets/Fonts#Phosphor`.
`&#xe2c2;` är numret på ikonen house i fonten.

**Varför är metoderna i servicen `static`?**
De tillhör klassen, inte ett objekt, så jag kan skriva `ProductServices.ListAllProducts()` utan `new`. Enkelt så länge
servicen inte har något eget tillstånd.

**Vad gör `partial`?**
Klassen är delad i flera filer. För ViewModels skriver jag en del och MVVM-toolkit genererar resten. För vyer är
`MainWindow.axaml.cs` min del och axaml-kompilatorn gör den andra.

**Vad är dependency injection?**
I stället för att en klass skapar det den behöver med `new`, får den det i konstruktorn. `ProductsViewModel(IProductService service)`
säger "ge mig något som kan lista produkter". Vem som skickar in det bestäms på ett ställe, i `AddServices`. Fördelen är att jag kan
byta `ProductServices` mot en annan klass, till exempel en som läser från en databas, utan att röra ViewModeln.

**Vad gör `AddServices` och `ServiceProvider`?**
`AddServices` är en lista över alla klasser appen kan behöva och hur de ska skapas. `BuildServiceProvider()` gör en behållare av
listan. När `App.axaml.cs` ber om `MainWindowViewModel` tittar behållaren på konstruktorn, ser att den vill ha en `PageViewFactory`,
skapar den först, och så vidare hela vägen ner. Det kallas constructor injection.

**Vad är skillnaden på `AddSingleton` och `AddTransient`?**
Singleton: ett enda objekt som alla delar, hela tiden appen kör. `MainWindowViewModel` och fabriken är singletons.
Transient: ett nytt objekt varje gång någon ber om ett. Sidorna och services är transient, så varje klick i menyn ger en färsk sida.

**Vad är ett interface till för här?**
`IProductService` lovar att det finns en metod `List()` som ger `List<Product>`. `ProductsViewModel` bryr sig bara om löftet.
Raden `AddTransient<IProductService, ProductServices>()` säger vilken klass som håller löftet just nu. Byt raden, byt beteende.

**Vad är factory design pattern?**
En klass vars enda jobb är att skapa rätt objekt. I konsoldemon säger jag `InvoiceTypeEnum.PDF` och `InvoiceFactory` ger mig en
`PDFCreator`. I RunStore säger `MainWindowViewModel` `ApplicationNameEnum.Products` och `PageViewFactory` ger tillbaka en
`ProductsViewModel`. Den som ber om något behöver inte veta vilka klasser som finns.

**Vad är `Func<ApplicationNameEnum, PageViewModel>`?**
En variabel som innehåller en funktion. Typen läses "en funktion som tar ett sidnamn och ger tillbaka en sida". I `AddServices`
registreras funktionen som en `switch`: namn in, `GetRequiredService` för rätt sida ut. Fabriken får funktionen i sin konstruktor
och gör bara `pageFactory.Invoke(pageName)`.

**Vad gör `switch` med `=>`?**
Det är en switch som är ett uttryck, inte satser. Varje rad är "värde => resultat" och `_` är default. Hela switchen blir ett värde
som kan returneras direkt. Används både i `InvoiceFactory` och i `AddServices`.

**Varför ärver sidorna `PageViewModel`?**
Alla sidor behöver veta sitt eget namn, `PageName`, så att fabriken och senare menyn kan hålla koll på vilken sida som visas.
`PageViewModel` ärver `ViewModelBase`, så `PageTitle` finns kvar också.

**Varför flyttade Ändra och Radera från `Product` till `ProductsViewModel`?**
En modell ska bara hålla data. En Radera som ligger i ViewModeln kan ta bort produkten ur `Products` och spara listan, det kan
en metod på `Product` inte. Knappen på raden når ViewModeln med `$parent[UserControl].DataContext.DeleteCommand` och skickar
med artikelnumret som `CommandParameter`.

## Nästa steg

- Låta `Delete(string id)` ta bort produkten ur `Products` och spara med `ProductServices.SaveProducts`.
- Ett formulär för att lägga till en ny produkt och en ny kund.
- Kunder på samma sätt som produkter: commands i `CustomersViewModel` i stället för metoder på `Customer`.
- Guid som id på `Customer` också, som på `Product`.
