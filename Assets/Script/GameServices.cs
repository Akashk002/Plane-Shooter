using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using PlaneShooter.Utilities;

public class GameServices : GenericMonoSingleton<GameServices>
{
    public List<LevelData> levelDataList = new List<LevelData>();
    [SerializeField] Spawner spawner;
    [SerializeField] levelStartAnimation levelStartAnimation;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] TMP_Text coinText;
    [SerializeField] Slider playerHealthSlider;
    [SerializeField] GameObject gameOverPanel, gameCompletePanel;
    int coin;
    int currentlevel;

    private void OnEnable()
    {
        GameAction.OnCollisionWithCoin += AddCoin;
        GameAction.OnUpdatePlayerHealthSlider += UpdateHealthSlider;
        GameAction.OnPlayerDie += GameOver;
        GameAction.OnGameComplete += GameComplete;
    }

    private void OnDisable()
    {
        GameAction.OnCollisionWithCoin -= AddCoin;
        GameAction.OnUpdatePlayerHealthSlider -= UpdateHealthSlider;
        GameAction.OnPlayerDie -= GameOver;
        GameAction.OnGameComplete -= GameComplete;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Startlevel());
    }

    IEnumerator Startlevel()
    {
        yield return new WaitForSeconds(3);
        string levelName = levelDataList[currentlevel].levelName;
        var enemyList = levelDataList[currentlevel].EnemyList;
        float enemySpawnTime = levelDataList[currentlevel].spwanTime;
        float enemyCount = levelDataList[currentlevel].Count;

        levelStartAnimation.SetText(levelName);
        levelStartAnimation.gameObject.SetActive(true);
        yield return new WaitForSeconds(6);
        levelStartAnimation.gameObject.SetActive(false);

        for (int i = 0; i < enemyCount; i++)
        {
            bool lastEnemy = false;

            if (currentlevel == levelDataList.Count - 1 && i == enemyCount - 1) lastEnemy = true;

            ObjectName enemyType = enemyList[Random.Range(0, enemyList.Count)];
            spawner.SpawnEnemyAtRandomPos(enemyType, lastEnemy);

            yield return new WaitForSeconds(enemySpawnTime);
        }

        currentlevel++;
        StartCoroutine(Startlevel());
    }
  
    void AddCoin()
    {
        coin ++;
        coinText.text = coin.ToString();
    }

    public int GetCoinCount()
    {
        return coin;
    }
    
    void UpdateHealthSlider(int Value)
    {
        playerHealthSlider.value = Value ;
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
    
    void GameComplete()
    {
        gameCompletePanel.SetActive(true);
    } 
}

[System.Serializable]
public class LevelData
{
    public string levelName;
    public List<ObjectName> EnemyList = new List<ObjectName>();
    public float spwanTime;
    public int Count;
}

[System.Serializable]
public enum ObjectName
{
    PlayerBullet,
    Coin,
    Health,
    EnemyBullet1,
    EnemyBullet2,
    EnemyBullet3,
    EnemyBullet4,
    EnemyBullet5,
    Aircraft1,
    Aircraft2,
    Aircraft3,
    Aircraft4,
    Chopper,
    Chopper2,
    PlaneDestroyEffect,
    BulletDestroyEffect,
}

[System.Serializable]
public enum BonusType
{
    Coin,
    Health
}