The purpose of this solution is to demonstrate a method to implement Hello authentication into a Blazor WASM App.
I have included in parenthesis comments that have been placed in the code to denote user added code, to aid in ease of navigation from step to step.

1. Install Nuget Package Microsoft.AspNetCore.Authentication.OpenIdConnect to your application's SERVER project.

2. Install Nuget Package Microsoft.AspNetCore.Components.Authorization to your application's CLIENT project.

3. Add necessary services and configuration to Program.cs file of the Server project. (search: SERVER SERVICES AND CONFIGURATION)

4. Unlike in Blazor Server, the AuthenticationStateProvider is not automatically available, so a custom Authentication State Provider must be provided.
	The files to build the AuthenticationStateProvider are in the Client project, in a folder called Authentication.
	
5. The custom authentication requires a custom CurrentUser class, which is in the Shared project, in the Models folder.

6. The CustomStateProvider that we built then has to be added as a service in the Client Program.cs file. (search: CLIENT SERVICES AND CONFIGURATION)

7. In order to pass the authentication state to each page, edit the App.razor file in the Client project.
	a. The entire contents of the page should be wrapped in a <CascadingAuthenticationState>. (search: CASCADING AUTHENTICATION STATE IMPLEMENTATION)
	b. In order to show no content when the user is not authorized, use the AuthorizeRouteView instead of the provided RouteView. (search: CHECK AUTHORIZATION IN ROUTING)

8. Add necessary imports in index.html of the Client project.
	a. A link to the CSS page can be added in the <head> section of the page. (search: HELLO CSS)
	b. A script for the Hello Javascript functions can be inserted into the <body> section of the page. (search: HELLO JAVASCRIPT)
	
9. Add necessary authorization code to your page you wish to protect.
	a. At the top of your razor page, near your using statements and imports, add your Authorize attribute. (search: AUTHORIZATION ATTRIBUTE)
	b. At the top of your @code block of your razor page, add a cascading parameter to pass the authorization state. (search: CASCADING AUTHENTICATIONSTATE PARAMETER)
	
10. Login Page setup
	a. In the @code block of your desired login page, declare a variable to hold your RedirectURI (search: REDIRECTURI PROPERTY)
	b. In your HTML, configure your Hello button. (search: HELLO LOGIN BUTTON)