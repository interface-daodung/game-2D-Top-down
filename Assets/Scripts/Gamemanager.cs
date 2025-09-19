using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    private int MaxEnegryCount = 3;
    private int currentEnegryCount;
    [SerializeField] private Image EnegryBar;

    private bool bossCall = false;

    [SerializeField] private GameObject EnemySpawner;

    void Start()
    {
        currentEnegryCount = 0;
        updateEnegryBar();
    }

    public void addEnegry()
    {
        if (currentEnegryCount < MaxEnegryCount)
        {
            currentEnegryCount++;
            updateEnegryBar();
        }
        if (bossCall) return;
        if (currentEnegryCount >= MaxEnegryCount)
        {
            bossCall = true;
            EnemySpawner.GetComponent<EnemySpawner>().
            spawnBoss();
        }
    }

    void updateEnegryBar()
    {
        EnegryBar.fillAmount = (float)currentEnegryCount / MaxEnegryCount;
    }


}
