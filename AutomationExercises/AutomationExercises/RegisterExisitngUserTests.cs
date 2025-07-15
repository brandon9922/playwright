using AutomationExercises.Common;
using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;

namespace AutomationExercises;

public class RegisterExisitngUserTests: PageTest
{
    [Fact]

    public async Task TestCase5_RegisterExisitngUser()
    {
        var mainPage = new MainPage(Page);
        await mainPage.NavigateToMainAndVerify();
        await mainPage.GoToLogin();
        await Page.Locator("[data-qa='signup-name']").FillAsync("test");
        await Page.Locator("[data-qa='signup-email']").FillAsync("k.sarnowska99@gmail.com");
        await Page.GetByRole(AriaRole.Button, new () { Name = "Signup" }).ClickAsync();
        await Expect(Page.GetByText("Email Address already exist!")).ToBeVisibleAsync();
    }
}