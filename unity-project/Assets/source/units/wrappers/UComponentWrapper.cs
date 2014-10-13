using UnityEngine;

public class UComponentWrapper<T>
        where T : Component {

    protected readonly T component_;

    // Wrapped fields
    private readonly UTransform transform_;

    // Unwrapped fields

    public UComponentWrapper(T component) {
        component_ = component;
        // Wrapped fields
        transform_ = WrapperUtils.Wrap<UTransform, Transform>(component_.transform, UTransform.Create);
    }

    public UTransform transform {
        get { return transform_; }
    }

    // Unwrapped properties

    public Animation animation {
        get { return component_.animation; }
    }

    public AudioSource audio {
        get { return component_.audio; }
    }

    public Camera camera {
        get { return component_.camera; }
    }

    public Collider collider {
        get { return component_.collider; }
    }

    public Collider2D collider2D {
        get { return component_.collider2D; }
    }

    public ConstantForce constantForce {
        get { return component_.constantForce; }
    }

    public GameObject gameObject {
        get { return component_.gameObject; }
    }

    public GUIText guiText {
        get { return component_.guiText; }
    }

    public GUITexture guiTexture {
        get { return component_.guiTexture; }
    }

    public HingeJoint hingeJoint {
        get { return component_.hingeJoint; }
    }

    public Light light {
        get { return component_.light; }
    }

    public NetworkView networkView {
        get { return component_.networkView; }
    }

    public ParticleEmitter particleEmitter {
        get { return component_.particleEmitter; }
    }

    public ParticleSystem particleSystem {
        get { return component_.particleSystem; }
    }

    public Renderer renderer {
        get { return component_.renderer; }
    }

    public Rigidbody rigidbody {
        get { return component_.rigidbody; }
    }

    public Rigidbody2D rigidbody2D {
        get { return component_.rigidbody2D; }
    }

    public string tag {
        get { return component_.tag; }
    }

    public HideFlags hideFlags {
        get { return component_.hideFlags; }
    }

    public string name {
        get { return component_.name; }
    }



}
