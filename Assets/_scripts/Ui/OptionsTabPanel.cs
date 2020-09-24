using CampusSimulator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsTabPanel : MonoBehaviour
{

    public SceneMan sman;
    UiMan uiman;

    public void FindAndDestroy(string targetname)
    {
        var tran = transform.Find(targetname);
        if (tran != null)
        {
            Destroy(tran.gameObject);
            //var butcomp = tran.GetComponent<Button>();
            //Destroy(butcomp.gameObject);
            //Debug.Log($"Destroyed {targetname}");
        }
    }
    public void DestroyFixedButtons()
    {
        FindAndDestroy("VisualsTabButton");
        FindAndDestroy("MapSetTabButton");
        FindAndDestroy("FramesTabButton");
        FindAndDestroy("FireFlyTabButton");
        FindAndDestroy("BuildingsTabButton");
        FindAndDestroy("GeneralTabButton");
        FindAndDestroy("HelpTabButton");
        FindAndDestroy("AboutTabButton");
    }

    public void Init0()
    {
        DestroyFixedButtons();
    }
    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
