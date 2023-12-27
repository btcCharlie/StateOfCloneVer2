using System.Reflection.Metadata;

namespace StateOfClone.GameMap
{
    public enum HexDirection
    {
        N, NE, SE, S, SW, NW
    }

    public struct HexMetrics
    {
        private const float _cornerToSide = 0.866025404f;
        private const float _sideToCorner = 1.154700538f;

        public const float hexSizeCorner = 1f;
        public const float hexSizeSide = hexSizeCorner * _cornerToSide;

        public const float innerPartPercent = 0.75f;
        public const float midCorner = innerPartPercent * hexSizeCorner;
        public const float midSide = innerPartPercent * hexSizeSide;
        public const float outerPart = (1 - innerPartPercent) * hexSizeCorner;

    }
}