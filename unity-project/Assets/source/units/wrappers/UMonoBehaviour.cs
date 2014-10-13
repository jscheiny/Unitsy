using UnityEngine;
using System.Collections;

public class UMonoBehaviour : MonoBehaviour {

    #pragma warning disable 0108
    public readonly Transform transform;
    public readonly Camera camera;
    public readonly Collider collider;
    public readonly Collider2D collider2D;
    #pragma warning restore 0108

    public UMonoBehaviour() {
        transform = Wrap<Transform>(base.transform);
        camera = Wrap<Camera>(base.camera);
        collider = Wrap<Collider>(base.collider);
        collider2D = Wrap<Collider2D>(base.collider2D);
    }

    private static T Wrap<T>(T field) where T : class {
        if (field == null) {
            return null;
        } else {
            return field; // wrap(field);
        }
    }

}
