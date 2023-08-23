using Microsoft.Playwright;

namespace SpecFlowExample.StepDefinitions
{
    [Binding]
    public class NavigateStepDefinitions
    {
        private readonly IPage _page;

        public NavigateStepDefinitions(Hooks.Hooks hooks)
        {
            _page = hooks.Page;
        }

        [Given(@"I start on '([^']*)'")]
        public async Task GivenIStartOn(string startUrl)
        {
            await _page.GotoAsync(startUrl);
            await _page.Locator("#hs-eu-confirmation-button").ClickAsync();
        }

        [When(@"I mouse over '([^']*)'")]
        public async Task WhenIMouseOver(string mouseOverTargetText)
        {
            await _page
                .GetByRole(AriaRole.Listitem)
                .Filter(new() { HasText = mouseOverTargetText })
                .HoverAsync();
        }

        [When(@"I click on '([^']*)'")]
        public async Task WhenIClickOn(string mouseClickTargetText)
        {
            await _page
                .GetByRole(AriaRole.Listitem)
                .Filter(new() { HasText = "Insights" })
                .GetByRole(AriaRole.Link)
                .Filter(new() { HasText = mouseClickTargetText })
                .ClickAsync();
        }

        [Then(@"I get taken to '([^']*)'")]
        public async Task ThenIGetTakenTo(string endUrl)
        {
            await _page.WaitForURLAsync(endUrl);
            _page.Url.Should().Be(endUrl);
        }
    }
}
