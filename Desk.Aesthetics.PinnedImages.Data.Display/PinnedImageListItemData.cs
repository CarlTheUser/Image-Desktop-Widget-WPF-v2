﻿using System;

namespace Desk.Aesthetics.PinnedImages.Data.Display
{
    public class PinnedImageListItemData
    {
        public Guid Id { get; }
        public string Directory { get; }
        public bool IsDisplayedToDesk { get; }
        public string Caption { get; }

        public PinnedImageListItemData(Guid id, string directory, bool isDisplayedToDesk, string caption)
        {
            Id = id;
            Directory = directory;
            IsDisplayedToDesk = isDisplayedToDesk;
            Caption = caption;
        }
    }
}
