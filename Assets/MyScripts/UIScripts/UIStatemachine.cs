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
    public GameObject MainCanvans;
    public GameObject PlayCanvans;
    public GameObject EndSCanvans;
    private UIState currentState;
    private Dictionary<string,GameObject> panels;
    // Start is called before the first frame update
    void Start()
    {
        panels= new Dictionary<string,GameObject>();
        currentState=UIState.LoginState;
        UpdateCanvans();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InstantiatePanel(string str)
    {
        if (!panels.ContainsKey(str))
        {
            GameObject temp = new GameObject();
            
        }
    }
    public void UpdateCanvans()
    {
        loginCanvans.SetActive(currentState==UIState.LoginState);
        MainCanvans.SetActive(currentState==UIState.MainState);
        PlayCanvans.SetActive(currentState == UIState.PlayState);
        EndSCanvans.SetActive(currentState==UIState.EndState);
    }
    public void ChangeState(UIState state)
    {
        currentState = state;
        UpdateCanvans();
    }
}
