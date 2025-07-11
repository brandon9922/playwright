using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;

namespace AutomationExercises;

public class RegisterUserTests: PageTest
{
    [Fact]
    public async Task TestCases1_RegisterUser()
    { 
        await Page.GotoAsync("https://automationexercise.com/");
        await Expect(Page).ToHaveTitleAsync("Automation Exercise");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Consent" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Signup / Login" }).ClickAsync();
        await Expect(Page.GetByText("New User Signup!")).ToBeVisibleAsync();
        await Page.GetByPlaceholder("Name").FillAsync("brandon");
        // await Page.GetByPlaceholder("Email Address").FillAsync("p.sarnowski99@gmail.com");
        await Page.Locator("[data-qa='signup-email']").FillAsync("p.sarnowski99@gmail.com");
        await Page.GetByRole(AriaRole.Button, new () { Name = "Signup" }).ClickAsync();

        //await Page.PauseAsync();

    }

   
}
