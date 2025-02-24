using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIState
{
    LoginState,
    MainState,
    PlayState,
    EndState
}
public class UIStatemachine : MonoBehaviour
{
    public GameObject loginCanvans;
    public GameObject mainCanvans;
    public GameObject playCanvans;
    public GameObject endSCanvans;
    private UIState currentState;
    private Dictionary<UIState,GameObject> panels;
    // Start is called before the first frame update
    void Start()
    {
        Init();
        panels= new Dictionary<UIState,GameObject>();
        currentState=UIState.LoginState;
        UpdateCanvans();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Init()
    {
        loginCanvans=Resources.Load<GameObject>("UIPrefabs/LoginPanel");
        mainCanvans = Resources.Load<GameObject>("UIPrefabs/MainPanel");
        playCanvans = Resources.Load<GameObject>("UIPrefabs/GamePanel");
        //endSCanvans = Resources.Load<GameObject>("");
        
    }
    public void InstantiatePanel(UIState s)
    {
        if (panels.ContainsKey(s))
        {
            return;
        }
        else
        {
            switch (s) 
            { 
                case UIState.LoginState:
                    GameObject temp1 = Instantiate(loginCanvans);
                    temp1.name =UIState.LoginState.ToString();
                    panels.Add(s, temp1);
                    break;
                case UIState.MainState:
                    GameObject temp2 = Instantiate(mainCanvans);
                    temp2.name = UIState.MainState.ToString();
                    panels.Add(s, temp2);
                    break;
                case UIState.PlayState:
                    GameObject temp3= Instantiate(loginCanvans);
                    temp3.name = UIState.PlayState.ToString();
                    panels.Add(s, temp3);
                    break;
                //case UIState.EndState:
                //    GameObject temp4 = Instantiate(endSCanvans);
                //    temp4.name = UIState.EndState.ToString();
                //    panels.Add(s, temp4);
                //    break;

            }
        }
        
    }
    public void UpdateCanvans()
    {
        if (panels.ContainsKey(currentState)) 
        { 
            panels[currentState].SetActive(true);
        }

    }
    public void ChangeState(UIState state)
    {
        currentState = state;
        UpdateCanvans();
    }
}
