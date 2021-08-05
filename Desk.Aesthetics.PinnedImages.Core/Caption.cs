namespace Desk.Aesthetics.PinnedImages.Core
{
    internal class Caption
    {
        public string Text { get; }
        public bool IsDisplayed { get; set; }

        public Caption(string text, bool isDisplayed)
        {
            Text = text;
            IsDisplayed = isDisplayed;
        }
    }
}
