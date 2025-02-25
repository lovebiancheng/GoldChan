
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
    
    //public Slider progressSlider; // 用于显示加载进度的滑动条

    /// <summary>
    /// 切换场景
    /// </summary>
    /// <param name="sceneName">要切换的场景名称</param>
    public void SwitchSceneAsync(string sceneName,Slider slider,Text percentText)
    {
        // 开始异步加载指定名称的场景
        StartCoroutine(LoadSceneAsync(sceneName,slider,percentText));
    }

    private System.Collections.IEnumerator LoadSceneAsync(string sceneName,Slider slider,Text percentText)
    {
        // 异步加载场景
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // 阻止场景加载完成后自动激活
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            // 获取加载进度，范围是 0 到 0.9
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            // 更新进度条的值
            if (slider != null)
            {
                slider.value = progress;
            }
            if (percentText != null) 
            { 
                percentText.text=Mathf.FloorToInt(progress*100).ToString()+"%";
            }
            // 当加载进度达到 0.9 时，表示加载完成，可以激活场景
            if (asyncLoad.progress >= 0.9f)
            {
                // 激活场景
                asyncLoad.allowSceneActivation = true;
                break;
            }

            yield return null;
        }
        Debug.Log("加载完成");
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
            Debug.Log("未激活");
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
            Debug.Log("未激活");
        }
    }

    /// <summary>
    /// 异步卸载场景
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
            Debug.LogError($"场景 {sceneName} 未加载，无法卸载。");
        }
    }
    private void OnSceneUnloaded(AsyncOperation operation)
    {
        Debug.Log($"场景  卸载完成。");
    }
}
