using Microsoft.Playwright;

namespace AutomationExercises.Common;

public class MainPage(IPage page)
{
    public async Task NavigateToMainAndVerify()
    {
        await page.GotoAsync("https://automationexercise.com/");
        await Assertions.Expect(page).ToHaveTitleAsync("Automation Exercise");
        await page.GetByRole(AriaRole.Button, new() { Name = "Consent" }).ClickAsync();
    }
}