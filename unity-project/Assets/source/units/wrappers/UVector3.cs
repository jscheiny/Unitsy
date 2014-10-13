using UnityEngine;

public class UVector3 : HasUnit {

    private readonly Unit unit_;
    private Vector3 vector_;

    public UVector3(Vector3 vec, Unit unit) {
        vector_ = vec;
        unit_ = unit;
    }

    public UVector3(float x, float y, float z, Unit unit) {
        vector_ = new Vector3(x, y, z);
        unit_ = unit;
    }

    public UVector3(ufloat x, ufloat y, ufloat z) {
        unit_ = x.unit;
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public void Assign(UVector3 vector) {
        if (unit_ != vector.unit_)
            ThrowMismatchedUnitsException();
        vector_ = vector.vector_;
    }

    public void Set(ufloat x, ufloat y, ufloat z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public override string ToString() {
        return vector_ + " " + unit_;
    }

    public void Normalize() {
        vector_.Normalize();
    }

    public Unit unit {
        get { return unit_; }
    }

    public ufloat x {
        get { return new ufloat(vector_.x, unit); }
        set {
            if (unit_ != value.unit) {
                ThrowAssignmentException();
            }
            vector_.x = value.scalar;
        }
    }

    public ufloat y {
        get { return new ufloat(vector_.y, unit); }
        set {
            if (unit_ != value.unit) {
                ThrowAssignmentException();
            }
            vector_.y = value.scalar;
        }
    }

    public ufloat z {
        get { return new ufloat(vector_.z, unit); }
        set {
            if (unit_ != value.unit) {
                ThrowAssignmentException();
            }
            vector_.z = value.scalar;
        }
    }

    public ufloat magnitude {
        get {
            return new ufloat(vector_.magnitude, unit_);
        }
    }

    public ufloat sqrMagnitude {
        get {
            return new ufloat(vector_.sqrMagnitude, unit_ * unit_);
        }
    }

    public UVector3 normalized {
        get {
            return new UVector3(vector_.normalized, unit_);
        }
    }

    public Vector3 vector {
        get { return vector_; }
    }

    public ufloat this[int index] {
        get {
            return new ufloat(vector_[index], unit_);
        }
        set {
            if (unit_ != value.unit)
                ThrowAssignmentException();
            vector_[index] = value.scalar;
        }
    }

    private static void ThrowAssignmentException() {
        throw new IncompatibleUnitsException("Cannot assign to vector component with incorrect unit.");
    }

    private static void ThrowMismatchedUnitsException() {
        throw new IncompatibleUnitsException("Mismatched UVector3 units.");
    }

    public static UVector3 operator+ (UVector3 left, UVector3 right) {
        if (left.unit_ != right.unit_) {
            ThrowMismatchedUnitsException();
        }
        return new UVector3(left.vector_ + right.vector_, left.unit_);
    }

    public static UVector3 operator- (UVector3 left, UVector3 right) {
        if (left.unit_ != right.unit_) {
            ThrowMismatchedUnitsException();
        }
        return new UVector3(left.vector_ - right.vector_, left.unit_);
    }

    public static UVector3 operator* (UVector3 left, float right) {
        return new UVector3(left.vector_ * right, left.unit_);
    }

    public static UVector3 operator* (UVector3 left, ufloat right) {
        return new UVector3(left.vector_ * right.scalar, left.unit_ * right.unit);
    }

    public static UVector3 operator* (float left, UVector3 right) {
        return new UVector3(left * right.vector_, right.unit_);
    }

    public static UVector3 operator* (ufloat left, UVector3 right) {
        return new UVector3(left.scalar * right.vector_, left.unit * right.unit_);
    }

    public static UVector3 operator/ (UVector3 left, float right) {
        return new UVector3(left.vector_ / right, left.unit_);
    }

    public static UVector3 operator/ (UVector3 left, ufloat right) {
        return new UVector3(left.vector_ / right.scalar, left.unit_ / right.unit);
    }

    public static bool operator== (UVector3 left, UVector3 right) {
        if (left.unit_ != right.unit_) {
            ThrowMismatchedUnitsException();
        }
        return left.vector_ == right.vector_;
    }

    public static bool operator!= (UVector3 left, UVector3 right) {
        return !(left == right);
    }

    public static ufloat Angle(UVector3 from, UVector3 to) {
        if (from.unit_ != to.unit_)
            ThrowMismatchedUnitsException();
        return new ufloat(Vector3.Angle(from.vector_, to.vector_), Unit.Scalar); // TODO: Return ufloat
    }

    public static UVector3 ClampMagnitude(UVector3 vector, ufloat maxLength) {
        if (vector.unit_ != maxLength.unit)
            ThrowMismatchedUnitsException();
        return new UVector3(Vector3.ClampMagnitude(vector.vector_, maxLength.scalar), vector.unit_);
    }

    public static UVector3 Cross(UVector3 left, UVector3 right) {
        if (left.unit_ != right.unit_)
            ThrowMismatchedUnitsException();
        return new UVector3(Vector3.Cross(left.vector_, right.vector_), left.unit_);
    }

    public static ufloat Distance(UVector3 a, UVector3 b) {
        return (a - b).magnitude;
    }

    public static ufloat Dot(UVector3 left, UVector3 right) {
        return new ufloat(Vector3.Dot(left.vector_, right.vector_), left.unit_ * right.unit_);
    }

    public static UVector3 Lerp(UVector3 from, UVector3 to, ufloat t) {
        if (from.unit_ != to.unit_)
            ThrowMismatchedUnitsException();
        if (!t.unit.IsScalar)
            throw new UnitException("Cannot lerp using a non-scalar t value.");
        return new UVector3(Vector3.Lerp(from.vector_, to.vector_, t.scalar), to.unit_);
    }

    public static UVector3 Max(UVector3 left, UVector3 right) {
        if (left.unit_ != right.unit_)
            ThrowMismatchedUnitsException();
        return new UVector3(Vector3.Max(left.vector_, right.vector_), left.unit_);
    }

    public static UVector3 Min(UVector3 left, UVector3 right) {
        if (left.unit_ != right.unit_)
            ThrowMismatchedUnitsException();
        return new UVector3(Vector3.Min(left.vector_, right.vector_), left.unit_);
    }

    public static UVector3 MoveTowards(UVector3 current, UVector3 target, ufloat maxDistanceDelta) {
        if (current.unit_ != target.unit_ || target.unit_ != maxDistanceDelta.unit)
            ThrowMismatchedUnitsException();
        return new UVector3(Vector3.MoveTowards(current.vector_, target.vector_, maxDistanceDelta.scalar),
                            current.unit_);
    }

    public static void OrthoNormalize(ref UVector3 normal, ref UVector3 tangent, ref UVector3 binormal) {
        if (normal.unit_ != tangent.unit_ || tangent.unit != binormal.unit_)
            ThrowMismatchedUnitsException();
        Vector3.OrthoNormalize(ref (normal.vector_), ref (tangent.vector_), ref (binormal.vector_));
    }

    public static UVector3 Project(UVector3 vector, UVector3 onNormal) {
        if (vector.unit_ != onNormal.unit_)
            ThrowMismatchedUnitsException();
        return new UVector3(Vector3.Project(vector.vector_, onNormal.vector_), vector.unit_);
    }

    public static UVector3 Reflect(UVector3 inDirection, UVector3 inNormal) {
        if (inDirection.unit_ != inNormal.unit_)
            ThrowMismatchedUnitsException();
        return new UVector3(Vector3.Reflect(inDirection.vector_, inNormal.vector_), inNormal.unit_);
    }

    // TODO: Make maxRadiansDelta ufloat
    public static UVector3 RotateTowards(UVector3 current,
                                         UVector3 target,
                                         float maxRadiansDelta,
                                         ufloat maxMagnitudeDelta) {
        if (current.unit_ != target.unit_ || target.unit_ != maxMagnitudeDelta.unit) {
            ThrowMismatchedUnitsException();
        }
        return new UVector3(Vector3.RotateTowards(current.vector_, target.vector_, maxRadiansDelta, maxMagnitudeDelta.scalar),
                            current.unit_);
    }

    public static UVector3 Scale(UVector3 a, UVector3 b) {
        return new UVector3(Vector3.Scale(a.vector_, b.vector_), a.unit_ * b.unit_);
    }

    public static UVector3 Slerp(UVector3 from, UVector3 to, ufloat t) {
        if (from.unit_ != to.unit_)
            ThrowMismatchedUnitsException();
        if (!t.unit.IsScalar)
            throw new UnitException("Cannot lerp using a non-scalar t value.");
        return new UVector3(Vector3.Slerp(from.vector_, to.vector_, t.scalar), to.unit_);
    }

    static UVector3 SmoothDamp(UVector3 current,
                               UVector3 target,
                               ref UVector3 currentVelocity,
                               ufloat smoothTime) {
        return SmoothDamp(current, target, ref currentVelocity, smoothTime,
                          new ufloat(Mathf.Infinity, current.unit_ / Units.Time));
    }

    static UVector3 SmoothDamp(UVector3 current,
                               UVector3 target,
                               ref UVector3 currentVelocity,
                               ufloat smoothTime,
                               ufloat maxSpeed) {
        return SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed,
                          UTime.deltaTime);
    }

    static UVector3 SmoothDamp(UVector3 current,
                               UVector3 target,
                               ref UVector3 currentVelocity,
                               ufloat smoothTime,
                               ufloat maxSpeed,
                               ufloat deltaTime) {
        if (current.unit_ != target.unit_)
            ThrowMismatchedUnitsException();
        if (currentVelocity.unit_ != current.unit_ / Units.Time)
            ThrowMismatchedUnitsException();
        if (smoothTime.unit != Units.Time)
            throw new UnitException("Smooth time must have a time unit.");
        if (maxSpeed.unit != current.unit_ / Units.Time)
            throw new UnitException("Max speed unit must be a velocity of the current vector.");
        if (deltaTime.unit != Units.Time)
            throw new UnitException("Delta time must have a time unit.");
        return new UVector3(Vector3.SmoothDamp(current.vector_, target.vector_, ref currentVelocity.vector_,
                                               smoothTime.scalar, maxSpeed.scalar, deltaTime.scalar),
                            current.unit_);
    }

}
