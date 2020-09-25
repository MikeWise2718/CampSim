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

    public void DeleteStuff()
    {
    }
    public void Init0()
    {
        uiman = sman.uiman;
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
