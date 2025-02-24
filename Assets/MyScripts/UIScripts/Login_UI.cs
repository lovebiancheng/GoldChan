using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using XLua;

public class Login_UI :Base_UI,IInitialize
{
    public InputField account;
    public InputField password;
    public Button login;
    public Button registered;

    public Button close;
    public Text errorMessage;
    public GameObject error;

    public Transform parentTransform;

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
        Initialize();
        LuaInitialize();
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
        account = parentTransform.Find("Bg/Account").transform.gameObject.GetComponent<InputField>();
        password = parentTransform.Find("Bg/Password").gameObject.GetComponent<InputField>();
        login = parentTransform.Find("Bg/Login").gameObject.GetComponent<Button>();
        registered=parentTransform.Find("Bg/Registered").gameObject.GetComponent<Button> ();
        close=parentTransform.Find("TextBg/CloseButton").gameObject.GetComponent <Button> ();
        errorMessage=parentTransform.Find("TextBg/ErrorMessage").gameObject.GetComponent<Text>();
        error = parentTransform.Find("TextBg").gameObject;
        error.SetActive(false);
    }
    public override void LuaInitialize()
    {
        LuaManger.Instance.DoStringLuaScript("LoginPanel");
        LuaManger.Instance.MyLuaTable.Set("account", account);
        LuaManger.Instance.MyLuaTable.Set("password", password);
        LuaManger.Instance.MyLuaTable.Set("loginButton", login);
        LuaManger.Instance.MyLuaTable.Set("registeredButton", registered);
        LuaManger.Instance.MyLuaTable.Set("partentTransform",parentTransform);
        LuaManger.Instance.MyLuaTable.Set("closeButton",close);
        LuaManger.Instance.MyLuaTable.Set("error", error);
        LuaManger.Instance.MyLuaTable.Set("errotText",errorMessage);
        //LuaManger.Instance.MyLuaTable.Set("apDic",Data.Instance.accountDic);
        LuaManger.Instance.MyLuaTable.Get<LuaFunction>("AddListener").Call();
        
        
    }
    

}
