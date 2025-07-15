using AutomationExercises.Common;
using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;

namespace AutomationExercises;

public class RegisterUserTests: PageTest
{
    [Fact]
    public async Task TestCase1_RegisterUser()
    { 
        // await Page.GotoAsync("https://automationexercise.com/");
        // await Expect(Page).ToHaveTitleAsync("Automation Exercise");
        var mainPage = new MainPage(Page);
        await mainPage.NavigateToMainAndVerify();
        await mainPage.GoToLogin();
        
        //await Page.GetByPlaceholder("Name").FillAsync("brandon");
        await Page.Locator("[data-qa='signup-name']").FillAsync("brandon");
        await Page.Locator("[data-qa='signup-email']").FillAsync("p.sarnowski99@gmail.com");
        await Page.GetByRole(AriaRole.Button, new () { Name = "Signup" }).ClickAsync();
        await Expect(Page.GetByText("Enter Account Information")).ToBeVisibleAsync();
        
        //9 Fill details: Title, Name, Email, Password, Date of birth
        await Page.GetByRole(AriaRole.Radio, new PageGetByRoleOptions(){ Name = "Mr."}).ClickAsync();
        await Page.Locator("#name").FillAsync("Pawel");
        await Page.Locator("#password").FillAsync("test123");
        await Page.SelectOptionAsync("#days","18");
        await Page.SelectOptionAsync("[data-qa='months']","3");
        await Page.SelectOptionAsync("[name='years']","1986");
        
        //10. Select checkbox 'Sign up for our newsletter!'
        await Page.GetByLabel("Sign up for our newsletter!").CheckAsync();
        await Expect(Page.GetByLabel("Sign up for our newsletter!")).ToBeCheckedAsync();
        
        //11. Select checkbox 'Receive special offers from our partners!'
        await Page.GetByLabel("Receive special offers from our partners!").CheckAsync();
        await Expect(Page.GetByLabel("Receive special offers from our partners!")).ToBeCheckedAsync();
        
        //12. Fill details: First name, Last name, Company, Address, Address2, Country, State, City, Zipcode, Mobile Number
        await Page.Locator("[data-qa='first_name']").FillAsync("Pawel");
        await Page.Locator("[data-qa='last_name']").FillAsync("Sarnowski");
        await Page.Locator("[data-qa='company']").FillAsync("QaSarTest");
        await Page.Locator("[name='address1']").FillAsync("Belżycka");
        await Page.Locator("#address2").FillAsync("13");
        await Page.GetByLabel("country").SelectOptionAsync("Canada");
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "state"}).FillAsync("California");
        await Page.GetByRole(AriaRole.Textbox, new() { Name = "City"}).FillAsync("Las Vegas");
        //await Page.GetByRole(AriaRole.Textbox, new() { Name = "zipcode"}).FillAsync("90210");
        await Page.Locator("#zipcode").FillAsync("90210");
        await Page.GetByLabel("Mobile Number").FillAsync("+48510743644");
        
        //13. Click 'Create Account button'
        await Page.GetByRole(AriaRole.Button, new() { Name = "Create Account" }).ClickAsync();
        
        //14. Verify that 'ACCOUNT CREATED!' is visible
        await Expect(Page.GetByText("Account Created!")).ToBeVisibleAsync();
        //15. Click 'Continue' button
        await Page.Locator("[data-qa='continue-button']").ClickAsync();
        
        //16. Verify that 'Logged in as username' is visible
        await Expect(Page.GetByText("Logged in as Pawel")).ToBeVisibleAsync();
        
        //17. Click 'Delete Account' button
        await Page.GetByText(" Delete Account").ClickAsync();
        
        //18. Verify that 'ACCOUNT DELETED!' is visible and click 'Continue' button
        await Expect(Page.GetByText("Account Deleted!")).ToBeVisibleAsync();
        await Page.Locator("[data-qa='continue-button']").ClickAsync();
        
        //await Page.PauseAsync();

    }

   
}
