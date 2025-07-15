using AutomationExercises.Common;
using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;

namespace AutomationExercises;

public class ContactUsFrom: PageTest
{
    [Fact]
    
    public async Task TestCase6_ContactUsForm()
    {
        var mainPage = new MainPage(Page);
        await mainPage.NavigateToMainAndVerify();
        await Page.GetByRole(AriaRole.Link, new PageGetByRoleOptions() { Name = " Contact us" }).ClickAsync();
        await Expect(Page.GetByText("Get In Touch")).ToBeVisibleAsync();
        await Page.Locator("[data-qa='name']").FillAsync("test");
        await Page.Locator("[data-qa='email']").FillAsync("k.sarnowska99@gmail.com");
        await Page.Locator("[data-qa='subject']").FillAsync("Testqwerty");
        await Page.Locator("[data-qa='message']").FillAsync(@"Lorem Ipsum is simply 
                dummy text of the printing and typesetting industry. 
                Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, 
                when an unknown printer took a galley of type and scrambled it to make a type specimen book. 
                It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.
                It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages,
                 and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.");
        await Page.Locator("input[type='file']").SetInputFilesAsync("C:\\Users\\pawel\\Desktop\\test photos\\test55.jpg");
        //await Page.PauseAsync();
        await Page.Locator("[data-qa='submit-button']").ClickAsync();
        Page.Dialog += async (_, dialog) =>
        {
            await dialog.AcceptAsync();
        };
        await Page.PauseAsync();
        await Expect(Page.GetByText("Get In Touch")).ToBeVisibleAsync();
        //await Expect (Page.Locator("div:has-text('Success! Your details have been submitted successfully.')")).ToBeVisibleAsync();

    }
}