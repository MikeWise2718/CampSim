using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    static Shader transShader = null;
    public static void SetColorOfGo(GameObject go, Color cclr)
    {
        var mat = go.GetComponent<Renderer>().material;
        mat.enableInstancing = true;
        //            var matrend = pcyl.GetComponent<Renderer>();
        if (cclr.a < 1f)
        {
            if (transShader == null)
            {
                //transShader = Shader.Find("Transparent/Diffuse");
                transShader = Shader.Find("Standard");
            }
            if (transShader != null)
            {
                mat.shader = transShader;
            }
            mat = new Material(transShader);
            mat.enableInstancing = true;
            mat.SetColor("_Color", cclr);
            mat.SetFloat("_Mode", 2);
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.SetInt("_ZWrite", 0);
            mat.DisableKeyword("_ALPHATEST_ON");
            mat.EnableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.renderQueue = 3000;
            mat.color = cclr;
        }
        else
        {
            mat.SetColor("_Color", cclr);
        }
    }

    public static void SetColorNewMatTransparent(GameObject go, Color cclr)
    {
        var rend = go.GetComponent<Renderer>();
        var shader = Shader.Find("Standard");
        rend.material = new Material(shader);
        rend.material.enableInstancing = true;
        rend.material.SetColor("_Color", cclr);
        rend.material.SetFloat("_Mode", 2);
        rend.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        rend.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        rend.material.SetInt("_ZWrite", 0);
        rend.material.DisableKeyword("_ALPHATEST_ON");
        rend.material.EnableKeyword("_ALPHABLEND_ON");
        rend.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        rend.material.renderQueue = 3000;
        rend.material.color = cclr;
    }


    public void CreatePropellorCylinder(GameObject parent,Vector3 pos,float rad = 0.4f)
    {
        var height = 0.01f;
        var clr = new Color(1, 1, 1, 0.4f);
        var cyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cyl.transform.localScale = new Vector3(rad, height, rad);
        cyl.transform.position = pos;
        SetColorOfGo(cyl, clr);
        cyl.transform.SetParent(parent.transform, worldPositionStays: true);
    }
    public void makeBaseDeliveryDroneWithRotors(string dname = "Deliver_Drone_v0spinning")
    {

        var(ngo, t) = makeBaseDeliveryDrone(dname);
        var pof = 0.304f;
        var yof = 0.188f;
        var pl = new Vector3(-pof, yof, 0);
        var pr = new Vector3(+pof, yof, 0);
        var pf = new Vector3(0, yof, +pof);
        var pb = new Vector3(0, yof, -pof);
        var rad = 0.36f;
        var blades = t.transform.Find("Delivery_Drone_blades");
        blades.gameObject.SetActive(false);
        CreatePropellorCylinder(t, pl, rad);
        CreatePropellorCylinder(t, pr, rad);
        CreatePropellorCylinder(t, pf, rad);
        CreatePropellorCylinder(t, pb, rad);
    }

    public (GameObject ngo, GameObject t) makeBaseDeliveryDrone(string dname="Deliver_Drone_v0")
    {
        var avaname = "obj3d/delivery_drone";
        var prefab = Resources.Load<GameObject>(avaname);
        var t = Instantiate<Transform>(prefab.transform);
        t.gameObject.name = "body_root";
        t.transform.position = new Vector3(-1.3142f, -0.214f, -2.1199f);
        Debug.Log($"position {t.transform.position}");
        var ngo = new GameObject(dname);
        t.SetParent(ngo.transform, worldPositionStays: true);
        return (ngo, t.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //makeBaseDeliveryDrone("Deliver_Drone_v2");
        makeBaseDeliveryDroneWithRotors("Deliver_Drone_v2spinning");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
