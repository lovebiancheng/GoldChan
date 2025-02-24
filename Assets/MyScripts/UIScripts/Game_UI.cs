using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using XLua;

public class Game_UI : Base_UI
{
    public Transform parentTransform;
    public Transform leaderboradTransform;

    public Button fetter;//Óø∞Ì
    public Button equipment;
    public Button buyExperience;
    public Button buyRole;
    public Button attackDetial;
    public Button setting;
    public Button squad;//’Û»›

    public Text buyExperienceContent;
    public Text buyRoleContent;
    public Text level;
    public Text record;

    public override void Enter()
    {
        base.Enter();
    }
    public override void Exit()
    {
        base.Exit();
    }
    private void Awake()
    {
        LuaManger.Instance.Initialize();
    }
    // Start is called before the first frame update
    void Start()
    {
        this.Initialize();
        this.LuaInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Initialize()
    {
        this.parentTransform = transform;
        leaderboradTransform = parentTransform.Find("Leaderboard").gameObject.transform;
        fetter = parentTransform.Find("Bg1/Fetter").gameObject.GetComponent<Button>();
        Debug.Log(fetter.name);
        equipment = parentTransform.Find("Bg2/Equipment").gameObject.GetComponent<Button>();
        buyExperience = parentTransform.Find("Bg3/BuyExperience").gameObject.GetComponent<Button>();
        buyRole = parentTransform.Find("Bg4/BuyRole").gameObject.GetComponent<Button>();
        attackDetial = parentTransform.Find("Bg5/AttackDetial").gameObject.GetComponent<Button>();
        setting = parentTransform.Find("Bg6/Setting").gameObject.GetComponent<Button>();
        squad = parentTransform.Find("Bg7/Squad").gameObject.GetComponent<Button>();

        buyExperienceContent = parentTransform.Find("Bg3/BuyExperience/BuyExperienceContent").gameObject.GetComponent<Text>();
        buyRoleContent= parentTransform.Find("Bg4/BuyRole/BuyRoleContent").gameObject.GetComponent<Text>();
        level = parentTransform.Find("Bg3/BuyExperience/BgContent31/BgOutside32/Level").gameObject.GetComponent<Text>();
        record= parentTransform.Find("Bg4/BuyRole/BgContent41/BgOutside42/Record").gameObject.GetComponent<Text>();
    }
    public override void LuaInitialize()
    {
        LuaManger.Instance.DoStringLuaScript("GamePanel");
        LuaManger.Instance.MyLuaTable.Set("fetterButton",fetter);
        LuaManger.Instance.MyLuaTable.Set("equipmentButton", equipment);
        LuaManger.Instance.MyLuaTable.Set("buyExperienceButton", buyExperience);
        LuaManger.Instance.MyLuaTable.Set("buyRoleButton", buyRole );
        LuaManger.Instance.MyLuaTable.Set("attackDetialButton", attackDetial );
        LuaManger.Instance.MyLuaTable.Set("settingButton", setting );
        LuaManger.Instance.MyLuaTable.Set("squadButton", squad);
        LuaManger.Instance.MyLuaTable.Get<LuaFunction>("AddListener").Call();

    }
}
