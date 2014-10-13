using System;

public struct ufloat : IComparable<ufloat>, HasUnit {

    private readonly float scalar_;
    private readonly Unit unit_;

    public static ufloat Scalar(float scalar) {
        return new ufloat(scalar, Unit.Scalar);
    }

    public ufloat(float scalar, Unit unit) {
        scalar_ = scalar;
        unit_ = unit;
    }

    public override string ToString() {
        return scalar_ + " " + unit_.ToString();
    }

    public Unit unit {
        get { return unit_; }
    }

    public float scalar {
        get { return scalar_; }
    }

    public static explicit operator float (ufloat n) {
        return n.scalar_;
    }

    public static explicit operator ufloat (float n) {
        return new ufloat(n, Unit.Scalar);
    }

    // Unary

    public static ufloat operator- (ufloat operand) {
        return new ufloat(-operand.scalar_, operand.unit_);
    }

    public static ufloat operator+ (ufloat operand) {
        return operand;
    }

    // Addition

    public static ufloat operator+ (ufloat left, ufloat right) {
        if (left.unit_ != right.unit_) {
            throw new IncompatibleUnitsException("Mismatched units for + operator: "
                + left.unit_ + " and " + right.unit_);
        }
        return new ufloat(left.scalar_ + right.scalar_, left.unit_);
    }

    public static ufloat operator+ (float left, ufloat right) {
        return new ufloat(left + right.scalar_, right.unit_);
    }

    public static ufloat operator+ (ufloat left, float right) {
        return new ufloat(left.scalar_ + right, left.unit_);
    }

    // Subtraction

    public static ufloat operator- (ufloat left, ufloat right) {
        if (left.unit_ != right.unit_) {
            throw new IncompatibleUnitsException("Mismatched units for - operator: "
                + left.unit_ + " and " + right.unit_);
        }
        return new ufloat(left.scalar_ - right.scalar_, left.unit_);
    }

    public static ufloat operator- (float left, ufloat right) {
        return new ufloat(left - right.scalar_, right.unit_);
    }

    public static ufloat operator- (ufloat left, float right) {
        return new ufloat(left.scalar_ - right, left.unit_);
    }

    // Multiplication

    public static ufloat operator* (ufloat left, ufloat right) {
        return new ufloat(left.scalar_ * right.scalar_, left.unit_ * right.unit_);
    }

    public static ufloat operator* (float left, ufloat right) {
        return new ufloat(left * right.scalar_, right.unit_);
    }

    public static ufloat operator* (ufloat left, float right) {
        return new ufloat(left.scalar_ * right, left.unit_);
    }

    // Division

    public static ufloat operator/ (ufloat left, ufloat right) {
        return new ufloat(left.scalar_ / right.scalar_, left.unit_ / right.unit_);
    }

    public static ufloat operator/ (float left, ufloat right) {
        return new ufloat(left / right.scalar_, right.unit_ ^ -1);
    }

    public static ufloat operator/ (ufloat left, float right) {
        return new ufloat(left.scalar_ / right, left.unit_);
    }

    // Comparison

    public int CompareTo(ufloat other) {
        if (unit_ != other.unit_) {
            throw new IncomparableUnitsException("Cannot compare ufloats with mismatched units: "
                + unit + " and " + other.unit_);
        }
        return scalar_.CompareTo(other.scalar_);
    }

    public static bool operator< (ufloat left, ufloat right) {
        return left.CompareTo(right) < 0;
    }

    public static bool operator<= (ufloat left, ufloat right) {
        return left.CompareTo(right) <= 0;
    }

    public static bool operator> (ufloat left, ufloat right) {
        return left.CompareTo(right) > 0;
    }

    public static bool operator>= (ufloat left, ufloat right) {
        return left.CompareTo(right) >= 0;
    }

    public static bool operator== (ufloat left, ufloat right) {
        return left.CompareTo(right) == 0;
    }

    public static bool operator!= (ufloat left, ufloat right) {
        return left.CompareTo(right) != 0;
    }

    public override bool Equals(System.Object other) {
        if (other.GetType() != typeof(ufloat))
            return false;
        return this == (ufloat) other;
    }

    public override int GetHashCode() {
        int hash = 17;
        hash = hash * 31 + scalar_.GetHashCode();
        hash = hash * 31 + unit_.GetHashCode();
        return hash;
    }
}
