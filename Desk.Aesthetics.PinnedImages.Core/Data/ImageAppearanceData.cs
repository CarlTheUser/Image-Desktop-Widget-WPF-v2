﻿using System;

namespace Desk.Aesthetics.PinnedImages.Core.Data
{
    public class ImageAppearanceData
    {
        public Guid Image { get; }
        public double FrameThickness { get; }
        public double RotationAngle { get; }
        public string Caption { get; }
        public bool ShowCaption { get; }
        public double ShadowOpacity { get; }
        public double ShadowDepth { get; }
        public double ShadowDirection { get; }
        public double ShadowBlurRadius { get; }
        public bool IsShadowHidden { get; }
    }
}
