namespace Desk.Aesthetics.PinnedImages.Presentation
{
    public interface IUserPrompt<TReturn>
    {
        TReturn Prompt();
    }

    public interface IUserPrompt<TReturn, TParameter>
    {
        TReturn Prompt(TParameter parameter);
    }
}
