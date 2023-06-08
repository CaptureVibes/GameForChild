using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CuboGameControl : MonoBehaviour
{
    public AudioSource lose;
    public AudioSource win;
    public GameObject singleNum;


    public  TextMeshPro targetNumeratorSingle;
    public  TextMeshPro targetDenominatorSingle;

    public GameObject doubleNum;
    public  TextMeshPro[] targetNumerators;
    public  TextMeshPro[] targetDenominators;


    public GameObject bingoText;
    public GameObject failText;
    public GameObject sumPanel;
    public GameObject nextPanel;

    public float targetFloatSum;
    public float myFloatSum;

    FragAddition.Fraction targetFracSum;
    public FragAddition.Fraction myFracAddend;
    public FragAddition.Fraction myFracSum;

    public float approachRatio;

    FragAddition myFragAddition;

    public int winCount = 0;  
    public int levelCount = 3;
    public int totalNumber = 0;
    public int winNumber = 0;
    
    public bool needDifficulty = false;

    public bool CuboIsIn = false;
    int mode = 1;



    void Start()
    {
        ModeSwitch();
        sumPanel.SetActive(true);
        ResetTarget();
        myFragAddition = GetComponent<FragAddition>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CuboIsIn) {
        if(winCount < 4)
            {
    //            Debug.Log(myFloatSum);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SetApproachRatio();
                    if(myFloatSum <= targetFloatSum * (1 + approachRatio) &&  myFloatSum >= targetFloatSum * (1 - approachRatio))
                    {
                        totalNumber++;
                        winNumber++;
                        winCount ++;
                        UISwitchToBingo();
                        ResetTarget();
                        ResetMyFloatSum();
                        StartCoroutine(WaitAndCallFunction());
                        gameObject.GetComponent<CuboidGenerator>().ClearTargetBars();
                    }   
                    else
                    // else if(myFloatSum > targetFloatSum * (1 + approachRatio) &&  myFloatSum < targetFloatSum * (1 - approachRatio))  
                    {
                        totalNumber++;
                        winCount = 0;
                        UISwitchToFail();
                        ResetTarget();
                        ResetMyFloatSum();
                        StartCoroutine(WaitAndCallFunction());
                        
                        gameObject.GetComponent<CuboidGenerator>().ClearTargetBars();
                    }
                }           
            }
        else 
        {
            ForDataSave();
                if(levelCount < 3) levelCount += 1;
                winCount = 0;
        }
            // 当my = target 时 bingo
        
        }

    }

    void UISwitchToBingo()
    {
        win.Play();
        sumPanel.SetActive(false);
        failText.SetActive(false); 
        bingoText.SetActive(true);
        nextPanel.SetActive(false);
    }
    void UISwitchToFail()
    {
        lose.Play();
        sumPanel.SetActive(false);
        failText.SetActive(true); 
        bingoText.SetActive(false);
        nextPanel.SetActive(false);
    }
    void UISwitchToTarget()
    {
        sumPanel.SetActive(true);
        bingoText.SetActive(false); 
        failText.SetActive(false); 
        nextPanel.SetActive(false);
    }
    void UISwitchToNext()
    {
        nextPanel.SetActive(true);
        sumPanel.SetActive(false);
        bingoText.SetActive(false); 
        failText.SetActive(false); 
    }

    IEnumerator WaitAndCallFunction() 
    {
        yield return new WaitForSeconds(3.0f); // 等待 2 秒
        UISwitchToTarget(); // 调用 MyFunction() 函数
        GetComponent<Clear>().clear();
        GetComponent<CuboidGenerator>().GenerateOnce();
    }

    
    //获取加数
    public void GetMyAddEnd(FragAddition.Fraction theAddEnd)
    {
        myFracAddend = theAddEnd;
        myFracSum  = myFragAddition.Add(myFracSum,myFracAddend);
        myFloatSum = myFracSum.ToDecimal();
        Debug.Log(myFloatSum);
    }

    void SetApproachRatio(){
        if(!needDifficulty) {approachRatio = 0.2f;}
        else {
            switch(levelCount){
                case 1 :
                    approachRatio = 0.2f;
        
                    break;
                case 2 :
                    approachRatio = 0.15f;
                    Debug.Log("0.15f");
                
                    break;
                case 3 :
                    approachRatio = 0.10f;
                
                    break;
                default:
                    break;
            }
        }

    }

    void ResetTarget(){
        myFracSum = new FragAddition.Fraction{ numerator = 0, denominator = 1};
        GetSum();
       // Debug.Log("Reset");
    }

    void GetSum()
    {
        if( ! Module.isTwoNumbers){
            GenerateFrac(targetNumeratorSingle,targetDenominatorSingle);
        }
        else{     
                GenerateFrac(targetNumerators[0],targetDenominators[0]);
                float tempSum = targetFloatSum;
                int firstDeno = int.Parse(targetDenominators[0].text);
                Debug.Log(firstDeno);
                GenerateFrac(targetNumerators[1],targetDenominators[1]);
                targetFloatSum = targetFloatSum + tempSum;
                int secondDeno = int.Parse(targetDenominators[1].text);
                Debug.Log(secondDeno);
                Debug.Log(secondDeno);
                if(secondDeno != firstDeno || targetFloatSum > 1)
                GetSum();  
        }
    }
    public void ResetMyFloatSum()
    {
        
        myFloatSum = 0;
        myFracSum = new FragAddition.Fraction{ numerator = 0, denominator = 1};
    }

    void GenerateFrac(TextMeshPro Numerator, TextMeshPro Denominator){
        float randomNum = Random.Range(0.1f, 1f);
        int targetDenominator = Random.Range(2,11);
        int targetNumerator = Mathf.RoundToInt(randomNum * targetDenominator);

                while (targetNumerator == 0)
        {
            randomNum = Random.Range(0.1f, 1f);
            targetDenominator = Random.Range(2,11);
            targetNumerator = Mathf.RoundToInt(randomNum * targetDenominator);
        }

        targetFracSum = new FragAddition.Fraction{ numerator = targetNumerator, denominator = targetDenominator };
        targetFloatSum = targetFracSum.ToDecimal();

        Numerator.text = targetNumerator.ToString();
        Denominator.text = targetDenominator.ToString();
        Debug.Log(targetDenominator + " " + targetNumerator+"    "+ targetFloatSum);
        Debug.Log(Numerator.text + "   " + Denominator.text);
    }

    public void ModeSwitch(bool flag){
        Module.isTwoNumbers = flag;
        if(Module.isTwoNumbers)
        {
            singleNum.SetActive(false);
            doubleNum.SetActive(true);
            ResetTarget();
            mode =2;
        }
        else
        {
            singleNum.SetActive(true);
            doubleNum.SetActive(false);
            ResetTarget();
            mode = 1;
        }
    }
    void ModeSwitch(){
        if(Module.isTwoNumbers)
        {
            singleNum.SetActive(false);
            doubleNum.SetActive(true);
            mode = 2;
        }
        else
        {
            singleNum.SetActive(true);
            doubleNum.SetActive(false);
            mode = 1;
        }
    }

    void GetRandomFractionWithSumLessThanOne(){
                // 随机生成两个不同的分母
        int b = Random.Range(1, 10);
        int d;
        do {
            d = Random.Range(1, 10);
        } while (d == b);

        // 随机生成分子
        int a = Random.Range(1, b);
        int c = Random.Range(1, d);

        // 计算分数的和
        float x = (float)a / b + (float)c / d;

        // 如果和大于1，则重新生成分母和分子
        if (x > 1) {
            GetRandomFractionWithSumLessThanOne();
        }
    }

    void ForDataSave()
    {
        gameObject.GetComponent<DataSave>().SaveData(mode,levelCount,totalNumber,winNumber);
        totalNumber = 0;
        winNumber = 0;
    }

}
