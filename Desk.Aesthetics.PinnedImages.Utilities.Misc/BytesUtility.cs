using System.Text;

namespace Desk.Aesthetics.PinnedImages.Utilities.Misc
{
    public static class BytesUtility
    {
        public static string FormatBytesString(this byte[] bytes)
        {
            StringBuilder guidBinary = new StringBuilder();
            foreach (byte guidByte in bytes)
            {
                guidBinary.AppendFormat(@"{0}", guidByte.ToString("x2"));
            }

            return guidBinary.ToString();
        }
    }
}
