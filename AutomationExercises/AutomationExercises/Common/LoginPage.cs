using Microsoft.Playwright;

namespace AutomationExercises.Common;

public class LoginPage(IPage page)
{
    public async Task Login(string username, string password)
    {
        await page.Locator("[data-qa='login-email']").FillAsync(username);
        await page.GetByPlaceholder("Password").FillAsync(password);
        await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
    }

   
}