using Microsoft.Win32;

namespace Desk.Aesthetics.PinnedImages.Presentation.View.Misc
{
    public class OpenFileDialogPromptParameter
    {
        public string Title { get; }
        public string Filter { get; }

        public OpenFileDialogPromptParameter(string title, string filter)
        {
            Title = title;
            Filter = filter;
        }
    }

    public class OpenFileDialogPrompt : IUserPrompt<string, OpenFileDialogPromptParameter>
    {
        public string Prompt(OpenFileDialogPromptParameter parameter)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Title = parameter.Title,
                Filter = parameter.Filter
            };

            bool? result = dialog.ShowDialog();
        
            return result.HasValue && result.Value ? dialog.FileName : null;
        }
    }
}
