
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneShift : MonoBehaviour
{
    private static SceneShift instance;
    public static SceneShift Instance
    {
        get 
        { 
            if (instance == null)
            {
                instance=FindObjectOfType<SceneShift>();
                if (instance == null)
                {
                    GameObject temp=new GameObject(typeof(SceneShift).Name);
                    instance = temp.AddComponent<SceneShift>();
                }
            }
            return instance;
        }
    }
    
    //public Slider progressSlider; // ������ʾ���ؽ��ȵĻ�����

    /// <summary>
    /// �л�����
    /// </summary>
    /// <param name="sceneName">Ҫ�л��ĳ�������</param>
    public void SwitchSceneAsync(string sceneName,Slider slider,Text percentText)
    {
        // ��ʼ�첽����ָ�����Ƶĳ���
        StartCoroutine(LoadSceneAsync(sceneName,slider,percentText));
    }

    private System.Collections.IEnumerator LoadSceneAsync(string sceneName,Slider slider,Text percentText)
    {
        // �첽���س���
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // ��ֹ����������ɺ��Զ�����
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            // ��ȡ���ؽ��ȣ���Χ�� 0 �� 0.9
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            // ���½�������ֵ
            if (slider != null)
            {
                slider.value = progress;
            }
            if (percentText != null) 
            { 
                percentText.text=Mathf.FloorToInt(progress*100).ToString()+"%";
            }
            // �����ؽ��ȴﵽ 0.9 ʱ����ʾ������ɣ����Լ����
            if (asyncLoad.progress >= 0.9f)
            {
                // �����
                asyncLoad.allowSceneActivation = true;
                break;
            }

            yield return null;
        }
        Debug.Log("�������");
        //UIStatemachine.Instance.ChangeState(tempState);
    }
    public void ActiveScene(string targetSceneName)
    {
        Scene targetScene = SceneManager.GetSceneByName(targetSceneName);
        if (targetScene.isLoaded)
        {
            SceneManager.SetActiveScene(targetScene);
        }
        else
        {
            Debug.Log("δ����");
        }
    }
    public void DontActiveScene(string targetSceneName)
    {
        Scene targetScene = SceneManager.GetSceneByName(targetSceneName);
        if (targetScene.isLoaded)
        {
            SceneManager.SetActiveScene(targetScene);
        }
        else
        {
            Debug.Log("δ����");
        }
    }

    /// <summary>
    /// �첽ж�س���
    /// </summary>
    /// <param name="sceneName"></param>
    public void UnloadTargetScene(string sceneName)
    {
        
        Scene targetScene = SceneManager.GetSceneByName(sceneName);
        if (targetScene.isLoaded)
        {
            
            SceneManager.UnloadSceneAsync(targetScene).completed += OnSceneUnloaded;
        }
        else
        {
            Debug.LogError($"���� {sceneName} δ���أ��޷�ж�ء�");
        }
    }
    private void OnSceneUnloaded(AsyncOperation operation)
    {
        Debug.Log($"����  ж����ɡ�");
    }
}
