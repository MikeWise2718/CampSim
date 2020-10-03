using System.Collections;
using CampusSimulator;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToolTipMan : MonoBehaviour
{
    public SceneMan sman;
    public float popupDelay = 2.0f;
    bool needPopup = false;
    GameObject popupButgo;
    Vector2 popupPos;
    string popupTxt;
    string popupTip;
    bool popupDanger;
    float popupTime;

    Dictionary<string, (GameObject popgo,GameObject tipgo)> ttDict;

    public void Init0()
    {
        popupDelay = 2.0f;
        needPopup = false;
        popupTime = float.MaxValue;
        ttDict = new Dictionary<string, (GameObject,GameObject)>();
    }

    public void WireUpToolTip(GameObject bgo, string txt, string tip,bool danger=false)
    {
        // WireUp tooltip listener
        var evttrig = bgo.AddComponent<EventTrigger>();
        var pentry = new EventTrigger.Entry();
        pentry.eventID = EventTriggerType.PointerEnter;
        pentry.callback.AddListener((data) => { OnPointerEnter((PointerEventData)data, bgo,txt, tip, danger:danger); });
        evttrig.triggers.Add(pentry);
        var pexit = new EventTrigger.Entry();
        pexit.eventID = EventTriggerType.PointerExit;
        pexit.callback.AddListener((data) => { OnPointerExit((PointerEventData)data, txt); });
        evttrig.triggers.Add(pexit);
    }
    public void BringUpToolTip(GameObject butgo,Vector2 pos, string txt, string tip, bool danger=false)
    {
        if (!ttDict.ContainsKey(txt))
        {
            var go = new GameObject($"tooltip-{txt}");
            var imgo = new GameObject($"background");
            imgo.transform.parent = go.transform;
            var imgcomp = imgo.AddComponent<Image>();
            if (danger)
            {
                imgcomp.color = new Color(0.5f, 0, 0);
            }
            else
            {
                imgcomp.color = new Color(0.25f, 0.25f,0.25f);// dark gray
            }
            imgcomp.raycastTarget = false;

            var txgo = new GameObject($"text");
            txgo.transform.parent = go.transform;
            var txtcomp = txgo.AddComponent<Text>();

            txtcomp.text = tip;
            Font arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            txtcomp.font = arial;
            txtcomp.fontSize = 18;
            txtcomp.alignment = TextAnchor.MiddleCenter;
            txtcomp.horizontalOverflow = HorizontalWrapMode.Overflow;
            txtcomp.verticalOverflow = VerticalWrapMode.Overflow;
            txtcomp.raycastTarget = false;
            ttDict[txt] = (butgo,go);
            var padding = 4f;
            var popbutgo = butgo.transform.parent.gameObject;// go up a level to get peer status
            var bgsize = new Vector2(txtcomp.preferredWidth + padding*2, txtcomp.preferredHeight + padding*2);
            imgcomp.rectTransform.sizeDelta = bgsize;
            go.transform.SetParent(popbutgo.transform, worldPositionStays: true);
        }
        var (_,ttgo) = ttDict[txt];
        ttgo.transform.position = new Vector3(pos.x, pos.y-20, 0);
        ttgo.transform.SetAsLastSibling();// this makes it always visible amoung the button and its peers
        ttgo.SetActive(true);
        var txtcomp1 = ttgo.GetComponentInChildren<Text>();
        txtcomp1.raycastTarget = false;
        var imgcomp1 = ttgo.GetComponentInChildren<Image>();
        imgcomp1.raycastTarget = false;
    }
    void ShutDownTip(string txt)
    {
        if (ttDict.ContainsKey(txt))
        {
            var (_,tgo) = ttDict[txt];
            tgo.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData, GameObject butgo, string txt, string tip, bool danger=false)
    {
        //Debug.Log($"OnPointerEnter {txt}");
        CountDownToPopup(popupDelay,butgo,eventData.position, txt, tip, danger:danger);
    }
    public void OnPointerExit(PointerEventData eventData, string txt)
    {
        //Debug.Log($"OnPointerExit {txt}");
        if (needPopup)
        {
            CancelPopup();
        }
        else
        {
            ShutDownTip(txt);
        }
    }

    void CountDownToPopup(float secs,GameObject butgo,Vector2 pos,string txt,string tip,bool danger=false)
    {
        popupTime = Time.time + secs;
        popupButgo = butgo;
        popupPos = pos;
        popupTxt = txt;
        popupTip = tip;
        popupDanger = danger;
        needPopup = true;
    }
    void CancelPopup()
    {
        needPopup = false;
        popupTime = float.MaxValue;
    }
    // Update is called once per frame
    void Update()
    {
        if (needPopup && Time.time >= popupTime)
        {
            needPopup = false;
            popupTime = float.MaxValue;
            BringUpToolTip(popupButgo, popupPos,popupTxt,popupTip,danger:popupDanger);
        }
    }
}
