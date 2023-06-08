using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimeCountDown : MonoBehaviour
{
    public float countdownTime = 270f; // 4.5分钟的秒数
    public TextMeshProUGUI countdownText;
    public GameObject gameControl;
    public GameObject next;

    private float timer;

    private void Start()
    {
        timer = countdownTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Debug.Log("倒数结束！");
            next.SetActive(true);
            GameObject.Find("Sum").SetActive(false);
            enabled = false;
        }
        else
        {
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
            countdownText.text = timeString;
        }
    }
}
