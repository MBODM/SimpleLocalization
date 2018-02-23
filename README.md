# SimpleLocalization
A simple middleware for ASP.NET Core 2.x that abstracts localization and make things easier.

### Introduction:

ASP.NET Core 2.x makes it possible to use localization in a simple way, mostly known as *"Shared Resources"*. This middleware uses that approach, offers an easy setup for that approach and abstracts the ASP.NET Core stuff away from the application.

The reason why it abstracts stuff away, is to keep things simple in the future. These days software changes a lot in short intervals. And maybe also Microsoft may change the concepts of ASP.NET Core soon again, like they did with 1.1 to 2.0.

Simple stuff like localization is easy to decouple. And since localization is a cross cutting concern, and therefore used in a lot of code files, it seems better to be dependent on an own abstraction (like an interface), instead being directly dependent on stuff in a framework, that is changed from time to time.

### Usage:

1. Add NuGet package or src to your ASP.NET Core 2.x project.

2. Add a folder named *"Resources"* to your project. **Hint:** This is the default, but the middleware also has a method overload, allowing you to specify name and path of the folder.

3. Add an empty class to that folder. Also add *".resx"* files to that folder. They must have the same name as the class. This is a requirement of ASP.NET Core localization. The name is up to you. As example, we use *"SharedResources"* as name here, for the class and 2 resource files, to support english and german:
    - `SharedResources.cs`
    - `SharedResources.en.resx`
    - `SharedResources.de.resx`

4) Add the middleware in the *"Startup.cs"* of your project:
   - `services.AddSimpleLocalization<SharedResources>();`
   - `services.AddMvc().AddSimpleLocalizationForDataAnnotations<SharedResources>();`

5) You are now able to use localization in:
   - C# classes (controllers, models, etc.)
   - Views (.cshtml files)
   - DataAnnotations (i.e. `[Required(ErrorMessage = "ErrorText5"]`)

### Used in Controller:
- Inject `ILocalizer<SharedRessources>` into your controller. We use `localizer` as variable name here.
- **Hint:** You don't have to register `ILocalizer<>` by yourself. It's already done by the middleware.
- With `localizer["MessageText1"]` or `localizer.GetText("MessageText1")` you can use it.
- The string *"MessageText1"* is the name of a field you want to have in your *".resx"* files.
- If there is no such field, the key himself returns (*"MessageText1"*). This is ASP.NET Core behaviour.

### Used in View:
- Add `@using MBODM.AspNetCore.SimpleLocalization` to your view.
- Add `@inject ILocalizer Localizer` to your view.
- Now you can use it via `<h1>@Localizer["MessageText1"]</h1>`.

### Used in DataAnnotation:
- You don't have to do anything.
- Just use normal DataAnnotations, i.e. `[Required(ErrorMessage = "ErrorText5"]`.
- The string *"ErrorText5"* is the name of a field you want to have in your *".resx"* files.
- The displayed `ErrorMessage` will now contain the value of that field.
- If there is no such field, ErrorMessage will contain the key himself (*"ErrorText5"*). This is ASP.NET Core behaviour.

### Change culture:
- You can change the culture, so all text changes, with the following 3 lines of code:
- `var cultureInfo = new CultureInfo("en-US");`
- `CultureInfo.DefaultThreadCurrentCulture = cultureInfo;`
- `CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;`

### Additional information:
The behaviour of "returning the key himself" is a concept of ASP.NET Core localization, allowing you to directly use default messages as keys, while developing. Later you can translate them into different languages. We used keys like *"MessageText1"* here, for better documentation. But consider a key like *"Thank you for using our products."*. This text will be served as default, and can be used later, as key in your *".resx"* files, for other languages.

For more information about this, and to get a better understanding of the localization process in ASP.NET Core, have a look at the official documentation at:

https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization

###### That´s it. Have fun!
