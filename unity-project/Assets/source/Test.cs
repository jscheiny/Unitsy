using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    // Use this for initialization
    void Start () {
        var dists = new UVector3(1 * SI.Meter, 2 * SI.Meter, 3 * SI.Meter);
        print(dists / (3 * SI.Mps));
    }

    // Update is called once per frame
    void Update () {

    }
}
