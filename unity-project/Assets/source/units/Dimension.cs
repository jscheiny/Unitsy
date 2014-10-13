using System.Collections.Generic;

public sealed class Dimension {

    private static Dictionary<string, Dimension> unitClasses
        = new Dictionary<string, Dimension>();

    public static Unit Create(string name, string base_unit) {
        if (unitClasses.ContainsKey(name)) {
            throw new ExistingDimensionException("Cannot create existing dimension: " + name);
        } else {
            var uc = new Dimension(name, base_unit);
            unitClasses[name] = uc;
            return new Unit(uc);
        }
    }

    public static Unit Get(string name) {
        if (unitClasses.ContainsKey(name)) {
            return new Unit(unitClasses[name]);
        } else {
            throw new UnknownDimensionException("Cannot retrieve unknown dimension: " + name);
        }
    }

    private readonly string name_;
    private readonly string base_unit_;

    private Dimension(string name, string base_unit) {
        name_ = name;
        base_unit_ = base_unit;
    }

    public string Name {
        get { return name_; }
    }

    public string BaseUnit {
        get { return base_unit_; }
    }

    public override int GetHashCode() {
        return name_.GetHashCode();
    }

    public override bool Equals(System.Object other) {
        if (!(other is Dimension))
            return false;
        return Name == (other as Dimension).Name;
    }

}
