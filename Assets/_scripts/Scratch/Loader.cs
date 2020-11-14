using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var avaname = "obj3d/delivery_drone";
        var prefab = Resources.Load<GameObject>(avaname);
        var t = Instantiate<Transform>(prefab.transform, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
