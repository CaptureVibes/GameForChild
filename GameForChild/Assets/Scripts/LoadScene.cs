using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadStart()
    {
         SceneManager.LoadScene("Start");
    }
    public void LoadScene2D_1()
    {
        SceneManager.LoadScene("2D BarGame 1");
    }
    public void LoadScene3D_1()
    {
        SceneManager.LoadScene("3D BarGame 1");
    }

    public void LoadTry()
    {
        SceneManager.LoadScene("Try");
    }

    public void LoadTry3D()
    {
        SceneManager.LoadScene("3D BarGame Try");
    }


    public void LoadNextScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        Debug.Log(sceneName);
        switch(sceneName){
            case "2D BarGame 1":
                SceneManager.LoadScene("2D BarGame 2");
                break;
            case "2D BarGame 2":
                SceneManager.LoadScene("2D BarGame 3");
                break;
            case "2D BarGame 3":
                SceneManager.LoadScene("3D BarGame 1");
                break;
            case "3D BarGame 1":
                SceneManager.LoadScene("3D BarGame 2");
                break;
            case "3D BarGame 2":
                SceneManager.LoadScene("3D BarGame 3");
                break;
        }
    }
}
