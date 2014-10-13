public static class Units {
    public static readonly Unit Distance = Dimensions.Distance;
    public static readonly Unit Area = Distance * Distance;
    public static readonly Unit Volume = Area * Distance;

    public static readonly Unit Time = Dimensions.Time;
    public static readonly Unit Speed = Distance / Time;
    public static readonly Unit Acceleration = Speed / Time;

    public static readonly Unit Mass = Dimensions.Mass;
}
