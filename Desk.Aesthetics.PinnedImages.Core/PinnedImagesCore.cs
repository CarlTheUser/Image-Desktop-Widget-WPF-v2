using System;

namespace Desk.Aesthetics.PinnedImages.Core
{
    internal sealed class PinnedImagesCore
    {
        public static void Require(Func<bool> invariant, string message)
        {
            if (!invariant.Invoke()) throw new PinnedImagesException(message);
        }
    }
}
