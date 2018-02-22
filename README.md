# SimpleLocalization
A simple middleware for ASP.NET Core 2.x that abstracts localization and make things easier.

Introduction:

ASP.NET Core 2.x makes it possible to use localization in a simple way, mostly known as "Shared Resources". This middleware use that approach, offer an easy setup and abstracts the ASP.NET Core stuff away from the application.

The reason why it abstracts stuff away, is to keep things simple in the future. These days software changes a lot in short intervals. And maybe also Microsoft may change the concepts of ASP.NET Core soon again, like they did with 1.1 to 2.0.

Simple stuff like localization is easy to decouple. And since localization is a cross cutting concern, and therefore used in a lot of code files, it seems better to be dependent on an own abstraction, like an interface, instead being directly dependent on stuff that is changed from time to time.

Usage:

1. Add NuGet package or src to your ASP.NET Core 2.x project.

2. Add a folder named "Resources" to your project. Hint: This is the default, but the middleware has also a method overload, allowing you to specify name and path of the folder.

3. Add an empty class to that folder. Also add ".resx" files to that folder. They must have the same name as the class. This is a requirement of ASP.NET Core localization. The name is up to you. As example, we use "SharedResources" as name here, and we add the class and 2 resource files, for english and german languages:
    - "SharedResources.cs"
    - "SharedResources.en.resx"
    - "SharedResources.de.resx"

4) Add the middleware in the "Startup.cs" of your project:
   - services.AddSimpleLocalization<SharedResources>();
   - services.AddMvc().AddSimpleLocalizationForDataAnnotations<SharedResources>();

5) You are now able to use localization in:
   - C# classes (controllers, models, etc.)
   - Views (.cshtml files)
   - DataAnotations (i.e. "[Required(ErrorMessage = "MyErrorMessage"]")

6) Inject "ILocalizer<SharedRessources> localizer" into your controller.
  
7) With "localizer["MessageText"]" or "localizer.GetText("MessageText")" you can use it. The string "MessageText" is the name of a field in your ".resx" files.

8) You can change the culture and all text changes:

  var cultureInfo = new CultureInfo("en-US");
  CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
  CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

9)
