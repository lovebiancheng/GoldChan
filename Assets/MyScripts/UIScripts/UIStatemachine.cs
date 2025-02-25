using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using XLua;

public enum UIState
{
    None,
    LoginState,
    MainState,
    PlayState,
    EndState,
    WaitState
}
public class UIStatemachine : Single<UIStatemachine>
{
    public GameObject loginCanvans;
    public GameObject mainCanvans;
    public GameObject playCanvans;
    public GameObject endSCanvans;
    public GameObject waitSCanvans;
    public bool isLogin;
    private UIState currentState;
    private Dictionary<UIState,GameObject> panels;
    // Start is called before the first frame update

    
    public void Init()
    {
        panels = new Dictionary<UIState, GameObject>();
        loginCanvans =Resources.Load<GameObject>("UIPrefabs/LoginPanel");
        mainCanvans = Resources.Load<GameObject>("UIPrefabs/MainPanel");
        playCanvans = Resources.Load<GameObject>("UIPrefabs/GamePanel");
        waitSCanvans= Resources.Load<GameObject>("UIPrefabs/WaitPanel");
    }
    public void InstantiatePanel(UIState s)
    {
        switch (s)
        {
            case UIState.LoginState:
                GameObject temp1 = GameObject.Instantiate(loginCanvans);
                temp1.name = UIState.LoginState.ToString();
                panels.Add(s, temp1);
                
                break;
            case UIState.MainState:
                GameObject temp2 = GameObject.Instantiate(mainCanvans);
                temp2.name = UIState.MainState.ToString();
                panels.Add(s, temp2);
                break;
            case UIState.PlayState:
                GameObject temp3 = GameObject.Instantiate(playCanvans);
                temp3.name = UIState.PlayState.ToString();
                panels.Add(s, temp3);
                break;
            case UIState.WaitState:
                GameObject temp4 = GameObject.Instantiate(waitSCanvans);
                temp4.name = UIState.WaitState.ToString();
                panels.Add(s, temp4);
            break;
                //case UIState.EndState:
                //    GameObject temp4 = Instantiate(endSCanvans);
                //    temp4.name = UIState.EndState.ToString();
                //    panels.Add(s, temp4);
                //    break;

        }
        
        
    }
    
    public void ChangeState(UIState newState)
    {
        if (currentState != UIState.None)
        {
            panels[currentState].GetComponent<Base_UI>().Exit();
        }
        
        currentState = newState;
        UpdateCanvans();
        panels[currentState].GetComponent<Base_UI>().Enter();
        
    }
    public void UpdateCanvans()
    {
        if (panels.ContainsKey(currentState)) 
        { 
            panels[currentState].SetActive(true);
        }
        else
        {
            InstantiatePanel(currentState);
            panels[currentState].SetActive(true);
        }
    }
    public void Clear()
    {
        panels.Clear();
    }
    public void CurrentStateDefult()
    {
        currentState = UIState.None;
    }
}
