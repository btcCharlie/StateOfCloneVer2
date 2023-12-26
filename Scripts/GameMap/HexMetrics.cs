namespace StateOfClone.GameMap
{
    public enum HexDirection
    {
        N, NE, SE, S, SW, NW
    }

    public struct HexMetrics
    {
        private static float _innerToOuter = 0.866025404f;
        private static float _outerToInner = 1.154700538f;


    }
}