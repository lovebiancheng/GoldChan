using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLua;

public class Wait_UI : Base_UI
{
    public override void Enter()
    {
        base.Enter();
        LuaManger.Instance.Initialize();
        this.Initialize();
        ChangeUIState();
    }
    public override void Exit()
    {
        gameObject.SetActive(false);
        LuaManger.Instance.OnTick();
    }
    public Text message;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {

    }

    public Transform parentTransform;
    public Slider slider;
    public Text percentText;


    public override void Initialize()
    {
        parentTransform = this.transform;
        slider=parentTransform.Find("Slider").transform.gameObject.GetComponent<Slider>();
        percentText= parentTransform.Find("Bg/Percent").transform.gameObject.GetComponent <Text>();
        
    }
    




    [LuaCallCSharp]
    public void ChangeUIState()
    {
        UIStatemachine.Instance.Clear();
        SceneShift.Instance.SwitchSceneAsync("SampleScene",slider,percentText);
        gameObject.SetActive(false);
        //SceneShift.Instance.UnloadTargetScene("NullScene");
        

    }
}
