public class SI {
    // Distance
    public static readonly ufloat Meter = 1 * Dimensions.Distance;
    public static readonly ufloat Kilometer = 1000 * Meter;
    public static readonly ufloat Centimeter = Meter / 100;
    public static readonly ufloat Millimeter = Centimeter / 10;

    // Mass
    public static readonly ufloat Kilogram = 1 * Dimensions.Mass;
    public static readonly ufloat Gram = Kilogram / 1000;

    // Time
    public static readonly ufloat Second = 1 * Dimensions.Time;
    public static readonly ufloat Minute = 60 * Second;
    public static readonly ufloat Hour = 60 * Minute;
    public static readonly ufloat Day = 24 * Hour;
    public static readonly ufloat Year = 365 * Day;

    // Speed
    public static readonly ufloat Mps = Meter / Second;
    public static readonly ufloat Kph = Kilometer / Hour;

    // Area
    public static readonly ufloat Sqmeter = Meter * Meter;

    // Acceleration
    public static readonly ufloat Mps2 = Meter / (Second * Second);

    // Force
    public static readonly ufloat Newton = Kilogram * Mps2;

    // Pressure
    public static readonly ufloat Pascal = Newton / Sqmeter;
}
