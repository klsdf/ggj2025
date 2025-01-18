/*
 * Author:      闫辰祥
 * CreateTime:  2025-01-17 晚上8点
 * 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{


    public int keyDownCount = 0;

    public string keyDownString = "";
    // 在游戏开始时调用一次
    void Start()
    {
        // 初始化代码可以放在这里
    }

    // 每帧调用一次
    void Update()
    {
        // 检查是否有按键被按下
        // if (Input.anyKeyDown)
        // {
        //     // 遍历所有可能的按键
        //     foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        //     {
        //         // 如果按键被按下
        //         if (Input.GetKeyDown(keyCode))
        //         {
        //             // 打印按键名称
        //             Debug.Log("按下的按键: " + keyCode);
        //         }
        //     }
        // }

        // 调用并打印当前按下的按键数量

        if (Input.anyKeyDown)
        {
            GetPressedKeyCount();
        }

    }

    /// <summary>
    /// 获取当前按下的按键数量
    /// </summary>
    /// <returns>按下的按键数量</returns>
    int GetPressedKeyCount()
    {
        keyDownCount = 0;
        keyDownString = "";
        // 遍历所有可能的按键
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            // 如果按键被按下
            if (Input.GetKey(keyCode))
            {
                keyDownCount++;
                keyDownString += keyCode.ToString() + " ";
            }
        }
        return keyDownCount;
    }
}
