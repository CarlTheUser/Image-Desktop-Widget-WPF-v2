using System;
using System.Runtime.Serialization;

namespace Desk.Aesthetics.PinnedImages.Core
{

    [Serializable]
    public class PinnedImagesException : Exception
    {
        public PinnedImagesException() { }

        public PinnedImagesException(string message) : base(message) { }

        public PinnedImagesException(string message, Exception innerException) : base(message, innerException) { }

        protected PinnedImagesException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
