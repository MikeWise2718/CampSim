﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BldPolyGenTest : MonoBehaviour
{
    BldPolyGen bpg;
    // Start is called before the first frame update
    void Start()
    {
        bpg = new BldPolyGen();
        var cgo = bpg.GenCircle("circle", Vector3.zero, 20, 1f, 2f, 0.5f,clr:"indigo",alf:0.5f);
        cgo.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
