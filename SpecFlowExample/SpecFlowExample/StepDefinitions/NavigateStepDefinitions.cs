using Microsoft.Playwright;

namespace SpecFlowExample.StepDefinitions
{
    [Binding]
    public class NavigateStepDefinitions
    {
        private readonly IPage _page;
        private readonly ScenarioContext _scenarioContext;

        public NavigateStepDefinitions(Hooks.Hooks hooks, ScenarioContext scenarioContext)
        {
            _page = hooks.Page;
            _scenarioContext = scenarioContext;
        }

        [Given(@"I start on '([^']*)'")]
        public async Task GivenIStartOn(string startUrl)
        {
            await _page.GotoAsync(startUrl);

            // Skip cookie confirmation box
            await _page.Locator("#hs-eu-confirmation-button").ClickAsync();
        }

        [When(@"I mouse over '([^']*)'")]
        public async Task WhenIMouseOver(string mouseOverTargetText)
        {
            var mainMenuItem = _page
                .GetByRole(AriaRole.Listitem)
                .Filter(new() { HasText = mouseOverTargetText });

            _scenarioContext["mainMenuItem"] = mainMenuItem;

            await mainMenuItem.HoverAsync();
        }

        [When(@"I click on '([^']*)'")]
        public async Task WhenIClickOn(string mouseClickTargetText)
        {
            var mainMenuItem = _scenarioContext.Get<ILocator>("mainMenuItem");
            
            await mainMenuItem
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
