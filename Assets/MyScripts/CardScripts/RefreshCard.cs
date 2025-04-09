using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshCard :MonoBehaviour
{
    private void Start()
    {
        Refresh();
    }
    public void Refresh()
    {
        // 用于存储生成的随机数的数组
        int[] randomNumbers = new int[5];

        // 循环 5 次以生成 5 个随机数
        for (int i = 0; i < 5; i++)
        {
            // 使用 Random.Range 方法生成 0 到 100 之间的随机整数
            // Random.Range 的第一个参数是最小值（包含），第二个参数是最大值（不包含）
            randomNumbers[i] = Random.Range(0, 101);
            Debug.Log("suijishu"+randomNumbers[i]);
        }
    }
}
