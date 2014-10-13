using UnityEngine;

public class UTransform : UComponentWrapper<Transform> {
    public static UTransform Create(Transform transform) {
        return new UTransform(transform);
    }

    private UTransform root_;
    private UTransform parent_;

    public UTransform(Transform transform) : base(transform) {
        root_ = WrapperUtils.Wrap<UTransform, Transform>(component_.root, UTransform.Create);
        parent_ = WrapperUtils.Wrap<UTransform, Transform>(component_.parent, UTransform.Create);
    }

    public int childCount {
        get { return component_.childCount; }
    }

    public Vector3 eulerAngles {
        get { return component_.eulerAngles; }
        set { component_.eulerAngles = value; }
    }

    public UVector3 forward {
        get { return new UVector3(component_.forward, Units.Distance); }
        set {
            Check(value, Units.Distance);
            component_.forward = value.vector;
        }
    }

    public bool hasChanged {
        get { return component_.hasChanged; }
        set { component_.hasChanged = value; }
    }

    public Vector3 localEulerAngles {
        get { return component_.localEulerAngles; }
        set { component_.localEulerAngles = value; }
    }

    public UVector3 localPosition {
        get { return new UVector3(component_.localPosition, Units.Distance); }
        set {
            Check(value, Units.Distance);
            component_.localPosition = value.vector;
        }
    }

    public Quaternion localRotation {
        get { return component_.localRotation; }
        set { component_.localRotation = value; }
    }

    public UVector3 localScale {
        get { return new UVector3(component_.localScale, Units.Distance); }
        set {
            Check(value, Units.Distance);
            component_.localPosition = value.vector;
        }
    }

    public Matrix4x4 localToWorldMatrix {
        get { return component_.localToWorldMatrix; }
    }

    public UVector3 lossyScale {
        get { return new UVector3(component_.lossyScale, Units.Distance); }
    }

    public UTransform parent {
        get { return parent_; }
        set {
            parent_ = value;
            component_.parent = parent.component_;
        }
    }

    public UVector3 position {
        get { return new UVector3(component_.position, Units.Distance); }
        set {
            Check(value, Units.Distance);
            component_.position = value.vector;
        }
    }

    public UVector3 right {
        get { return new UVector3(component_.right, Units.Distance); }
        set {
            Check(value, Units.Distance);
            component_.right = value.vector;
        }
    }

    public UTransform root {
        get { return root_; }
    }

    public Quaternion rotation {
        get { return component_.rotation; }
        set { component_.rotation = value; }
    }

    public UVector3 up {
        get { return new UVector3(component_.up, Units.Distance); }
        set {
            Check(value, Units.Distance);
            component_.up = value.vector;
        }
    }

    public Matrix4x4 worldToLocalMatrix {
        get { return component_.worldToLocalMatrix; }
    }

    private void Check<T>(T val, Unit expected) where T : HasUnit {
        if(val.unit != expected) {
            throw new IncompatibleUnitsException("Expected assigned parameter to have units " + expected);
        }
    }


}
