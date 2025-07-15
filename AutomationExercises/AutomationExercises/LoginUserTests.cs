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
        await mainPage.GoToLogin();
        
        //6. Enter correct email address and password
        var loginPage = new LoginPage(Page);
        await loginPage.Login("k.sarnowska99@gmail.com", "test123");
        
        // 8. Verify that 'Logged in as username' is visible
        await Expect(Page.GetByText("Logged in as Test")).ToBeVisibleAsync();
        
    }

    [Fact]
    public async Task TestCase3_IncorrectEmailAndPassword()
    {
        var mainPage = new MainPage(Page);
        await mainPage.NavigateToMainAndVerify();
        await mainPage.GoToLogin();
        
    //     6. Enter incorrect email address and password
        var loginPage = new LoginPage(Page);
        await loginPage.Login("k.sarnowska19@gmail.com", "test12");
        
        
    //     8. Verify error 'Your email or password is incorrect!' is visible
    await Expect(Page.GetByText("Your email or password is incorrect!")).ToBeVisibleAsync();
    
    }
    
    [Fact]
    public async Task TestCase4_LogoutUser()
    {
        var mainPage = new MainPage(Page);
        await mainPage.NavigateToMainAndVerify();
        await mainPage.GoToLogin();
        
        var loginPage = new LoginPage(Page);
        await loginPage.Login ("k.sarnowska99@gmail.com", "test123");
        await Expect(Page.GetByText("Logged in as Test")).ToBeVisibleAsync();
        await Page.GetByText(" Logout").ClickAsync();
        await Expect(Page.GetByText("Login to your account")).ToBeVisibleAsync();
        
    }
}

