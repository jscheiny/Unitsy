using UnityEngine;

public static class UTime {
    private static void ThrowException() {
        throw new UnitException("Cannot set a time parameter with a non-time unit.");
    }

    public static int captureFramerate {
        get { return Time.captureFramerate; }
        set { Time.captureFramerate = value; }
    }

    public static int frameCount {
        get { return Time.frameCount; }
    }

    public static ufloat deltaTime {
        get { return Time.deltaTime * SI.Second; }
    }

    public static ufloat fixedDeltaTime {
        get { return Time.fixedDeltaTime * SI.Second; }
        set {
            if (value.unit != Units.Time)
                ThrowException();
            Time.fixedDeltaTime = value.scalar;
        }
    }

    public static ufloat fixedTime {
        get { return Time.fixedTime * SI.Second; }
    }

    public static ufloat maximumDeltaTime {
        get { return Time.maximumDeltaTime * SI.Second; }
        set {
            if (value.unit != Units.Time)
                ThrowException();
            Time.maximumDeltaTime = value.scalar;
        }
    }

    public static ufloat realtimeSinceStartup {
        get { return Time.realtimeSinceStartup * SI.Second; }
    }

    public static ufloat smoothDeltaTime {
        get { return Time.smoothDeltaTime * SI.Second; }
    }

    public static ufloat time {
        get { return Time.time * SI.Second; }
    }

    public static ufloat timeScale {
        get { return ufloat.Scalar(Time.timeScale); }
        set {
            if (!value.unit.IsScalar)
                throw new UnitException("Cannot set timeScale parameter to a non-scalar value.");
            Time.timeScale = value.scalar;
        }
    }

    public static ufloat timeSinceLevelLoad {
        get { return Time.timeSinceLevelLoad * SI.Second; }
    }

    public static ufloat unscaledDeltaTime {
        get { return Time.unscaledDeltaTime * SI.Second; }
    }

    public static ufloat unscaledTime {
        get { return Time.unscaledTime * SI.Second; }
    }



}
