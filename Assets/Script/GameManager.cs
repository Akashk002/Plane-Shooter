using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager This;
    public List<LevelData> levelDataList = new List<LevelData>();
    [SerializeField] Spawner spawner;
    [SerializeField] levelStartAnimation levelStartAnimation;
    [SerializeField] TMP_Text coinText;
    int coin;
    int currentlevel;


    // Start is called before the first frame update
    void Start()
    {
        This = this;
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
            ObjectName enemyType = enemyList[Random.Range(0, enemyList.Count)];
            spawner.SpawnEnemyAtRandomPos(enemyType);
            yield return new WaitForSeconds(enemySpawnTime);
        }

        currentlevel++;
        StartCoroutine(Startlevel());
    }

    public void AddCoin(int val = 1)
    {
        coin += val;
        coinText.text = coin.ToString();
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
