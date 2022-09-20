# Szkolenie Domain Driven Design

Repozytorium zawiera materiały przygotowane na potrzeby szkolenia z tematu `Domain Dirven Design`

## Przygotowanie środowiska

W celu aktywnego udziału w szkoleniu zalecane jest aby na swoim komputerze zainstalować poniższe narzędzia i biblioteki, które będą używane podczas szkolenia.

### Visual Sudio (Community)

Visual Studio to narzędzie, które umożliwi interaktywną pracę z językiem C#.

Narzędzie w darmowej wersji dostepne jest pod poniższym linkiem:

https://visualstudio.microsoft.com/pl/free-developer-offers/

Można też wybrać edycję np. Professional z tymczasową, darmową licencją. Visual Studio w płatnej edycji zawiera więcej narzędzi dla programistów. Narzędzia te nie będa jednak potrzebne podczas szkolenia.

https://visualstudio.microsoft.com/pl/downloads/

### .NET 6

.NET 6 jest instalowany razem z Visual Studio.

Jeżeli jednak Visual Studio było wcześniej zainstalowane (wersja przed 16.9) należy pobrać instalator, który znajduje się pod poniższym linkiem:

https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.401-windows-x64-installer

To czy na komupterze jest zainstalowany .NET 6 można sprawdzić wykonując poniższą komendę w narzędziu "Command Prompt" (cmd)

```cmd
> dotnet --version
(wynik powyższej komendy to np. 6.0.401)
```

### Git dla systemu Windows

Narzędzie do kontoli wersji "Git" ułatwi pracę z repozytorium używanym na potrzeby szkolenia. Dlatego zalecane jest posiadanie tego narzędzia (nie jest to jednak konieczne).

Jeżeli na komputerze nie był wczesniej instalowany Git to można go zainstalować ściągając potrzebny instalator z linku poniżej

https://git-scm.com/download/win

### Weryfikacja środowiska

W celu weryfikacji środowiska należy otworzyć przykładową solucję, skompilowac kod i uruchomić projekt aplikacji webowej `WebApp`
Solucja znajduje się tutaj: `Training.Prework/TrainingPrework.sln`
(repo: https://github.com/mjdudzic/is-csharp-async)

Jeżeli środowisko jest OK solucja skompiluje się bez błędów i zostanie uruchomiona strona startowa `/swagger/index.html`
