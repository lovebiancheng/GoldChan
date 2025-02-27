using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinarySearch 
{
    /// <summary>
    /// ��� �ұ�
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int SearchA(int[] nums,int target)//nums�Ǵ�С�������������
    {
        int left = 0;
        int right=nums.Length-1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else if (nums[mid] < target) 
            {
                left = mid + 1;
            }
        }
        return -1;//-1��˼��δ���ҵ��±�
    }
    

}
