using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

using UnitsDict = System.Collections.Generic.Dictionary<Dimension, int>;

public class Unit {

    public static readonly Unit Scalar = new Unit(new UnitsDict());

    private readonly UnitsDict units_;

    public Unit(Dimension unit) {
        units_ = new UnitsDict();
        units_.Add(unit, 1);
    }

    public override string ToString() {
        if (units_.Count == 0) {
            return "Scalar";
        }
        List<string> positive_dims = new List<string>();
        List<string> negative_dims = new List<string>();
        foreach (var pair in units_) {
            if (pair.Value > 0) {
                string exp = (pair.Value > 1 ? "^" + pair.Value : "");
                positive_dims.Add(pair.Key.BaseUnit + exp);
            } else {
                string exp = (pair.Value < -1 ? "^" + -pair.Value : "");
                negative_dims.Add(pair.Key.BaseUnit + exp);
            }
        }

        string numerator;
        if (positive_dims.Count == 0) {
            numerator = "1";
        } else if (positive_dims.Count == 1) {
            numerator = positive_dims[0];
        } else {
            numerator = "(" + string.Join(" * ", positive_dims.ToArray()) + ")";
        }

        string denominator;
        if (negative_dims.Count == 0) {
            denominator = "";
        } else if (negative_dims.Count == 1) {
            denominator = "/" + negative_dims[0];
        } else {
            denominator = "/(" + string.Join(" * ", negative_dims.ToArray()) + ")";
        }

        return numerator + denominator;
    }

    public bool IsScalar {
        get { return units_.Count == 0; }
    }

    private bool ExponentsDivisibleBy(int n) {
        foreach (var pair in units_) {
            if (pair.Value % n != 0) {
                return false;
            }
        }
        return true;
    }

    public Unit NthRoot(int n) {
        if (!ExponentsDivisibleBy(n)) {
            throw new UnitMathException("Cannot take the " + n + "-root of unit " + this);
        }
        return new Unit(units_.ToDictionary((pair) => pair.Key, (pair) => pair.Value / n));
    }

    public override bool Equals(System.Object other) {
        if (!(other is Unit))
            return false;
        return this == (other as Unit);
    }

    public override int GetHashCode() {
        return units_.GetHashCode();
    }

    public static Unit operator* (Unit left, Unit right) {
        return new Unit(multiply(left.units_, right.units_));
    }

    public static Unit operator/ (Unit left, Unit right) {
        return new Unit(divide(left.units_, right.units_));
    }

    public static Unit operator^ (Unit unit, int power) {
        return new Unit(exponentiate(unit.units_, power));
    }

    public static bool operator== (Unit left, Unit right) {
        if (left.units_.Count != right.units_.Count) {
            return false;
        }
        foreach (var pair in left.units_) {
            if (!right.units_.ContainsKey(pair.Key)) {
                return false;
            }
            if (right.units_[pair.Key] != pair.Value) {
                return false;
            }
        }
        return true;
    }

    public static ufloat operator* (float n, Unit u) {
        return new ufloat(n, u);
    }

    public static bool operator!= (Unit left, Unit right) {
        return !(left == right);
    }

    private Unit(UnitsDict units) {
        units_ = units;
    }

    private static UnitsDict exponentiate(UnitsDict units, int power) {
        return units
            .Where((source) => source.Value * power != 0)
            .ToDictionary((source) => source.Key,
                          (source) => source.Value * power);
    }

    private static UnitsDict multiply(UnitsDict left, UnitsDict right) {
        UnitsDict result = new UnitsDict(left);
        foreach (var pair in right) {
            Dimension dim = pair.Key;
            if (result.ContainsKey(dim)) {
                int left_power = result[dim];
                int right_power = pair.Value;
                int power = left_power + right_power;
                if (power == 0) {
                    result.Remove(dim);
                } else {
                    result[dim] = power;

                }
            } else {
                result[dim] = pair.Value;
            }
        }
        return result;
    }

    private static UnitsDict divide(UnitsDict left, UnitsDict right) {
        return multiply(left, exponentiate(right, -1));
    }

}
