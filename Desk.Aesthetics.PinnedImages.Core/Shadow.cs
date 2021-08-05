namespace Desk.Aesthetics.PinnedImages.Core
{
    internal class Shadow
    {
        public double Opacity { get; }
        public double Depth { get; }
        public double Direction { get; }
        public double BlurRadius { get; }
        public bool IsHidden { get; }

        public Shadow(double opacity, double depth, double direction, double blurRadius, bool isHidden)
        {
            Opacity = opacity;
            Depth = depth;
            Direction = direction;
            BlurRadius = blurRadius;
            IsHidden = isHidden;
        }
    }
}
