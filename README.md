# RunStore

Skolprojekt i kursen Programmering med C# (ITHS). Ett skrivbordsprogram byggt med Avalonia och MVVM.
Projektet växer för varje lektion, allt ligger i mappen `Client`.

## Vad ligger var

| Mapp | Vad som ska ligga här |
|---|---|
| `Models` | Klasser som bara håller data: `Product`, `Customer`. Inga metoder som gör något. |
| `Service` | Klasser som hämtar och sparar data: `ProductService`, `CustomerService`. Sidorna frågar alltid en service, aldrig filen direkt. |
| `Interface` | Kontrakt, till exempel `Istorage<T>` som säger att en lagring ska kunna `Read` och `Write`. |
| `Repositories` | `Storage<T>` som läser och skriver en lista till en json-fil. |
| `Data` | Json-filerna med data, till exempel `Product.json`. Kopieras till bin-mappen vid bygge (se `Client.csproj`). |
| `ViewModels` | En klass per sida med sidans logik och data. Ärver `ViewModelBase`. |
| `Views` | En axaml-fil per sida. `ViewLocator` hittar rätt View genom namnet: `ProductViewModel` visas med `ProductView`. |
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
  skapa en service som använder `Storage<T>` på samma sätt som `ProductService`.
- **Ny modell:** en klass i `Models` med samma fält som json-filen har.
