using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{

    static Dictionary<Color, Material> matcache = new Dictionary<Color, Material>();
    public static void SetColorNewMatTransparent(GameObject go, Color cclr)
    {
        var rend = go.GetComponent<Renderer>();
        var shader = Shader.Find("Standard");
        if (!matcache.ContainsKey(cclr))
        {
            var newmat = new Material(shader);
            newmat.enableInstancing = true;
            newmat.SetColor("_Color", cclr);
            newmat.SetFloat("_Mode", 2);
            newmat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            newmat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            newmat.SetInt("_ZWrite", 0);
            newmat.DisableKeyword("_ALPHATEST_ON");
            newmat.EnableKeyword("_ALPHABLEND_ON");
            newmat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            newmat.renderQueue = 3000;
            newmat.color = cclr;
            matcache[cclr] = newmat;
        }
        var mat = matcache[cclr];
        rend.material = mat;
    }


    public void CreatePropellorCylinder(GameObject parent,string cname,Vector3 pos,float rad = 0.4f)
    {
        var height = 0.01f;
        var clr = new Color(1, 1, 1, 0.4f);
        var cyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cyl.name = cname;
        cyl.transform.localScale = new Vector3(rad, height, rad);
        cyl.transform.position = pos;
        //SetColorNewMatTransparent(cyl, clr);
        var mat = Resources.Load<Material>("Materials/RotorSpinning");
        if (mat==null)
        {
            Debug.Log("material is null");
        }
        var rend = cyl.GetComponent<Renderer>();
        rend.material = mat;
        cyl.transform.SetParent(parent.transform, worldPositionStays: true);
    }

    #region deliverydrone
    public void MakeBaseDeliveryDroneWithRotors(string dname = "Delivery_Drone_v0spinning")
    {

        var(ngo, t) = MakeBaseDeliveryDrone(dname);
        var pof = 0.304f;
        var yof = 0.188f;
        var pl = new Vector3(-pof, yof, 0);
        var pr = new Vector3(+pof, yof, 0);
        var pf = new Vector3(0, yof, +pof);
        var pb = new Vector3(0, yof, -pof);
        var rad = 0.36f;
        var blades = t.transform.Find("Delivery_Drone_blades");
        blades.gameObject.SetActive(false);
        CreatePropellorCylinder(t, "propleft", pl, rad);
        CreatePropellorCylinder(t, "propright", pr, rad);
        CreatePropellorCylinder(t, "propfront", pf, rad);
        CreatePropellorCylinder(t, "propback", pb, rad);
    }

    public (GameObject ngo, GameObject t) MakeBaseDeliveryDrone(string dname="Delivery_Drone_v0")
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
    #endregion


















    public (GameObject ngo, GameObject t) MakeBaseMatrice600Drone(string dname = "Matrice_600_v0")
    {
        var avaname = "obj3d/matrice_600";
        var prefab = Resources.Load<GameObject>(avaname);
        var t = Instantiate<Transform>(prefab.transform);
        t.gameObject.name = "body_root";
        t.transform.position = Vector3.zero;
        Debug.Log($"position {t.transform.position}");
        var ngo = new GameObject(dname);
        t.SetParent(ngo.transform, worldPositionStays: true);
        return (ngo, t.gameObject);
    }

    public void MakeBaseMatrice600DroneWithRotors(string dname = "Matrice_600_v0spinning")
    {

        var (ngo, t) = MakeBaseMatrice600Drone(dname);
        var pof = 0.304f;
        var yof = 0.188f;
        var pl = new Vector3(-pof, yof, 0);
        var pr = new Vector3(+pof, yof, 0);
        var pf = new Vector3(0, yof, +pof);
        var pb = new Vector3(0, yof, -pof);
        var rad = 0.36f;
        //var blades = t.transform.Find("Delivery_Drone_blades");
        //blades.gameObject.SetActive(false);
        CreatePropellorCylinder(t, "propleft", pl, rad);
        CreatePropellorCylinder(t, "propright", pr, rad);
        CreatePropellorCylinder(t, "propfront", pf, rad);
        CreatePropellorCylinder(t, "propback", pb, rad);
    }

    // Start is called before the first frame update
    void Start()
    {
        //makeBaseDeliveryDrone("Deliver_Drone_v2");
        //makeBaseDeliveryDroneWithRotors("Delivery_Drone_v2spinning");
        //MakeBaseMatrice600Drone("Matrice_600_v0");
        MakeBaseMatrice600DroneWithRotors("Matrice_600_v0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
