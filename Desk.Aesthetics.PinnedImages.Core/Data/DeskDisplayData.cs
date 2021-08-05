using System;

namespace Desk.Aesthetics.PinnedImages.Core.Data
{
    public class DeskDisplayData
    {
        public Guid Image { get; }
        public bool IsDisplayedToDesk { get; }

        public DeskDisplayData(Guid image, bool isDisplayedToDesk)
        {
            Image = image;
            IsDisplayedToDesk = isDisplayedToDesk;
        }
    }
}
