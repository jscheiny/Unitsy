using UnityEngine;
using System.Collections;

public class UMonoBehaviour : MonoBehaviour {

    #pragma warning disable 0108
    public readonly UTransform transform;
    #pragma warning restore 0108

    public UMonoBehaviour() {
        transform = WrapperUtils.Wrap<UTransform, Transform>(base.transform, UTransform.Create);
    }

}
