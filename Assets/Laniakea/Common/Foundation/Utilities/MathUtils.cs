public static class MathUtils
{
    public static double Ranged(double min, double max, double input)
    {
        double ratio = input / (max - min);
        return Lerp(ratio > 0 ? ratio % 1 : 1 + ratio % 1, min, max);
    }

    public static double Lerp(double delta)
    {
        return 2 * delta - 1;
    }

    public static double Lerp(double delta, double from, double to)
    {
        return from + delta * (to - from);
    }
}
