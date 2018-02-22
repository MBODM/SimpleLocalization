# SimpleLocalization
A simple middleware for ASP.NET Core 2.x that abstracts localization and make things easier.

In ASP.NET Core 2.x you can use localization in a simple way, mostly known as "Shared Resources". This middleware use this approach and abstracts the ASP.NET Core stuff away from the application, to keep things simple in the future, if they change the concepts of ASP.NET Core.

Usage:

1)
Add NuGet package or src to your ASP.NET Core project.

2)
Add a folder named "Resources" to your project.
PS: There is also an overloaded method in the middleware, allowing you to specify the name and path.

3)
Add an empty class to that folder. We name the class "SharedResources" here. But that is up to you.
Add also a ".resx" file to that folder. The file must have the same name, as the class we added.
PS: The same-name-thing is a requirement of ASP.NET Core localization.

4)
Add the middleware in the Startup.cs of your project:

  services.AddSimpleLocalization<SharedResources>();
  services.AddMvc().AddSimpleLocalizationForDataAnnotations<SharedResources>();

3)
