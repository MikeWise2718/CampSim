using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;
using UnityEditor.Profiling.Memory.Experimental;

public class UiConfigPanel : MonoBehaviour
{
    public SceneMan sman;
    UiMan uiman;

    Text scenarioNameText;

    Toggle sampleToggle;
    Button closeButton;
    Button validationButton;
    GameObject content;

    Sprite background;
    Sprite checkmark;

    public void Init0()
    {
        LinkObjectsAndComponents();
    }

    public void LinkObjectsAndComponents()
    {
        sman = FindObjectOfType<SceneMan>();
        uiman = sman.uiman;

        scenarioNameText = transform.Find("ScenarioNameText").gameObject.GetComponent<Text>();
        sampleToggle = transform.Find("SampleToggle").gameObject.GetComponent<Toggle>();
        //background = Resources.Load<Sprite>("_sprites/BackgroundGreyGridSprite");
        //checkmark = Resources.Load<Sprite>("_sprites/BackgroundGreyGridSprite");
        background = Resources.Load<Sprite>("unity_builtin_extre/Background");
        checkmark = Resources.Load<Sprite>("unity_builtin_extre/Checkmark");

        content = transform.Find("UiConfigSettingsCanvas/Scroll View/Viewport/Content").gameObject;


        validationButton = transform.Find("ValidationButton").gameObject.GetComponent<Button>();
        validationButton.onClick.AddListener(delegate { VerifyValues(); });
        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        closeButton.onClick.AddListener(delegate { uiman.ClosePanel();  });

    }
    public bool VerifyValues()
    {
        return true;
    }

    public void InitVals()
    {
        //content.SetActive(true);
        Debug.Log("UiConfig InitVals called");
        scenarioNameText.text = $"Current Scene:{sman.curscene}";
        var rootOptions = OptionsPanel.enableStringRoot;
        var curOptions = uiman.optpan.enableString;
        var togopts = rootOptions.Split(',');
        for (int i = 0; i < togopts.Length; i++)
        {

           var uiResources = new DefaultControls.Resources();
            //Set the Toggle Background Image someBgSprite;
            //uiResources.background = background;
            //Set the Toggle Checkmark Image someCheckmarkSprite;
            //uiResources.checkmark = checkmark;



            var curRootOpt = togopts[i];
            var ison = curOptions.Contains(curRootOpt);
            var toggo = DefaultControls.CreateToggle(uiResources);
            var togcomp = toggo.GetComponentInChildren<Toggle>();
            //var toggo = new GameObject();
            //var togcomp = toggo.AddComponent<Toggle>();
            togcomp.interactable = true;
            //togcomp.targetGraphic = sampleToggle.targetGraphic;
            toggo.name = $"Toggle{i} {curRootOpt} ison:{ison}";
            var togtext = toggo.GetComponentInChildren<Text>();
            if (togtext != null)
            {
                togtext.text = curRootOpt;
            }
            togcomp.isOn = ison;
            //togcomp.graphic = sampleToggle.graphic;
            toggo.transform.SetParent(content.transform, worldPositionStays: false);
            //toggo.transform.SetParent(transform, worldPositionStays: false);
            //var pos = new Vector3(200, 200 + i * 20, 0);
            //toggo.transform.position = pos;
        }
        //sampleToggle.gameObject.SetActive(false);
        Debug.Log("Sampletoggle turned off");
    }

    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
    }
    public void UpdateText()
    {
    }

    public void SetVals(bool closing = false)
    {
        Debug.Log($"UiConfig.SetVals called - closing:{closing}");

        //sman.RequestRefresh("UiConfig-SetVals");
    }

    float checkInterval = 1f;
    float lastCheck = 0;

    private void Update()
    {
        if (Time.time-lastCheck>checkInterval)
        {
            UpdateText();
            lastCheck = Time.time;
        }
    }

}
