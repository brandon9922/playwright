using AutomationExercises.Common;
using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;

namespace AutomationExercises;

public class LoginUserTests : PageTest
{
    [Fact]
    public async Task TestCase2_CorrectEmailAndPassword()
    {
        var mainPage = new MainPage(Page);
        await mainPage.NavigateToMainAndVerify();
        
        //4. Click on 'Signup / Login' button
        await Page.GetByRole(AriaRole.Link, new() { Name = "Signup / Login" }).ClickAsync();
        
        //5. Verify 'Login to your account' is visible
        await Expect(Page.GetByText("New User Signup!")).ToBeVisibleAsync();
        
        //6. Enter correct email address and password
        await Page.Locator("[data-qa='login-email']").FillAsync("k.sarnowska99@gmail.com");
        await Page.GetByPlaceholder("Password").FillAsync("test123");
        
        //7. Click 'login' button
        await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
        
        // 8. Verify that 'Logged in as username' is visible
        await Expect(Page.GetByText("Logged in as Test")).ToBeVisibleAsync();
        
        
    }

    [Fact]
    public async Task TestCase3_IncorrectEmailAndPassword()
    {
        var mainPage = new MainPage(Page);
        await mainPage.NavigateToMainAndVerify();
        
        //4. Click on 'Signup / Login' button
        await Page.GetByRole(AriaRole.Link, new() { Name = "Signup / Login" }).ClickAsync();
        
        //5. Verify 'Login to your account' is visible
        await Expect(Page.GetByText("New User Signup")).ToBeVisibleAsync();
        
    //     6. Enter incorrect email address and password
        await Page.Locator("[data-qa='login-email']").FillAsync("k.sarnowska19@gmail.com");
        await Page.GetByPlaceholder("Password").FillAsync("test12");
        
    //     7. Click 'login' button
        await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
        
    //     8. Verify error 'Your email or password is incorrect!' is visible
    await Expect(Page.GetByText("Your email or password is incorrect!")).ToBeVisibleAsync();
    }
}

