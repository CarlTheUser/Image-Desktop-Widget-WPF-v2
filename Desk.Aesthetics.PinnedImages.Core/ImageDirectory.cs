namespace Desk.Aesthetics.PinnedImages.Core
{
    internal class ImageDirectory
    {
        public string Name { get; }

        public ImageDirectory(string name)
        {
            PinnedImagesCore.Require(() => !string.IsNullOrWhiteSpace(name), "Directory name is invalid.");
            Name = name;
        }
    }
}
