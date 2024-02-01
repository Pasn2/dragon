using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    [SerializeField] private float currentExp;
    [SerializeField] private int requireExpToNextLevel;
    [SerializeField] private int currentLevel =1;
    private const int power = 2;
    private const float constant = 0.07f;
    public static ExperienceManager instance;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    /*private void Update() {
        TestNextLevel();
    }
    */
    public void TestNextLevel()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            print("DARAs");
           currentLevel++;
           requireExpToNextLevel = CalculateNextLevel(currentLevel + 1);
        }
    }
    private void Start() {
        requireExpToNextLevel = CalculateNextLevel(currentLevel + 1);
    }
    public float AddExp(float _expAmount)
    {
        float currentExpEquals = currentExp += _expAmount;
        float remainingExp = currentExp - requireExpToNextLevel;
        if(currentExp >= requireExpToNextLevel)
        {
            NextLevel();
            return currentExp = remainingExp;
        }
        return currentExpEquals;
    }
    private void NextLevel()
    {
        print("On next level");
        currentLevel++;
        requireExpToNextLevel = CalculateNextLevel(currentLevel + 1);
    }
    private int CalculateNextLevel(float _curLevel)
    {
        float curLevelDivConst = (_curLevel/constant);
        float nextLevelRequiredExp = Mathf.Pow(curLevelDivConst,power);
        print("CAR");
        return (int) nextLevelRequiredExp;
    }
    public int GetExpAmount()
    {
        return (int) currentExp;
    }
}
