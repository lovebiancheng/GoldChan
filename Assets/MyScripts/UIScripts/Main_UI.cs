using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;
using XLua;

public class Main_UI : Base_UI
{
    public override void Enter()
    {
        base.Enter();
    }
    public override void Exit() 
    {
        base.Exit();
    }

    public Button begainGame;
    public Button setting;
    public Button email;
    public Button friend;
    public Image outside;
    public Image role;
    public Transform parentTransform;
    //public Text message;
    private void Awake()
    {
        LuaManger.Instance.Initialize();
    }
    void Start()
    {
        this.Initialize();
        this.LuaInitialize();
    }
    private void OnDestroy()
    {
        LuaManger.Instance.OnDestroy();
        Debug.Log("Ïú»ÙµÇÂ¼½çÃæ");
    }
    
    public override void Initialize()
    {
        parentTransform = this.transform;
        Debug.Log(parentTransform.gameObject.name);
        begainGame = parentTransform.Find("BegainGame").transform.gameObject.GetComponent<Button>();
        setting = parentTransform.Find("Setting").gameObject.GetComponent<Button>();
        email = parentTransform.Find("Email").gameObject.GetComponent<Button>();
        friend = parentTransform.Find("Friend").gameObject.GetComponent<Button>();
        outside = parentTransform.Find("OutsideImage").gameObject.GetComponent<Image>();
        role = parentTransform.Find("RoleImage").gameObject.GetComponent<Image>();
        
    }
    public override void LuaInitialize()
    {
        LuaManger.Instance.DoStringLuaScript("MainPanel");
        LuaManger.Instance.MyLuaTable.Set("begainGameButton", begainGame);
        LuaManger.Instance.MyLuaTable.Set("settingButton", setting);
        LuaManger.Instance.MyLuaTable.Set("emailButton", email);
        LuaManger.Instance.MyLuaTable.Set("friendButton", friend);
        LuaManger.Instance.MyLuaTable.Set("outsideImage", parentTransform);
        LuaManger.Instance.MyLuaTable.Set("roleImage", role);
        //LuaManger.Instance.MyLuaTable.Set("apDic",Data.Instance.accountDic);
        LuaManger.Instance.MyLuaTable.Get<LuaFunction>("AddListener").Call();


    }
}
