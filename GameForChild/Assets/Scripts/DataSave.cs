using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataSave : MonoBehaviour
{
    public static string path;
    public TextMeshProUGUI IDNumber;
    
    
    private void Start() 
    {
        path = @"C:\GameForChild\Test.txt";
        string sceneName = SceneManager.GetActiveScene().name;
        SaveSceneName(sceneName);
    }

    public void SaveData(int mode,int levelNumber, int totalNumber, int winNumber)
    {
        // 写入数据
        float p = (float)winNumber / totalNumber;
        string data = string.Format("\n难度：{0},总数：{1},正确：{2}, 正确率 ：{3}，模式：{4}", levelNumber, totalNumber, winNumber,p,mode);
        File.AppendAllText(path, data);
        Debug.Log("数据写入成功：" + path);
    }

    public void SaveIDNumber()
    {
        string data = string.Format("\nID: {0}", IDNumber.text);
        File.AppendAllText(path, data); 
        Debug.Log("数据写入成功：" + path);
    }   
    public void SaveSceneName(string name)
    {
        string data = string.Format("\n关卡 {0}", name);
        File.AppendAllText(path, data);
        Debug.Log("数据写入成功：" + path);
    }

}
