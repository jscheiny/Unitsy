public static class UMathf {
    public static ufloat Sqrt(ufloat x) {
        return new ufloat(x.scalar, x.unit.NthRoot(2));
    }
}
