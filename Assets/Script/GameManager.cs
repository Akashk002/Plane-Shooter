using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<LevelData> levelDataList = new List<LevelData>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

[System.Serializable]
public class LevelData
{
    public string levelName;
    public List<Objectname> EnemyType = new List<Objectname>();
    public int Count;
}
