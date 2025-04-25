#region Namespaces
using UnityEngine;
using TMPro;
using PlaneShooter.Utilities;
using PlaneShooter.Player;
using PlaneShooter.Enemy;
using PlaneShooter.Bullets;
using System.Collections.Generic;
#endregion


public class GameService : GenericMonoSingleton<GameService>
{
    #region Dependencies

    private PlayerService playerService;
    private EnemyService enemyService;
    private VFXService vfxService;
    [SerializeField] private UIView uiService;

    #endregion

    #region Prefabs
    [SerializeField] private PlayerView playerPrefab;
    [SerializeField] private BulletView playerBulletPrefab;
    [SerializeField] private List<EnemyView> enemyPrefabList;
    [SerializeField] private List<BulletView> enemyBulletList;
    #endregion

    #region Scriptable Objects
    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    [SerializeField] private BulletScriptableObject playerBulletScriptableObject;
    [SerializeField] private List<EnemyScriptableObject> EnemyScriptableObjectList;
    [SerializeField] private List<BulletScriptableObject> enemyBulletScriptableObject;
    [SerializeField] private VFXScriptableObject vfxScriptableObject;
    #endregion

    private void Start()
    {
        // Initialize all Services.
        playerService = new PlayerService(playerPrefab, playerScriptableObject, playerBulletPrefab, playerBulletScriptableObject);
        enemyService = new EnemyService(enemyPrefabList[0], EnemyScriptableObjectList[0], enemyBulletList[0], enemyBulletScriptableObject[0]);
    }

    private void Update()
    {
        //enemyService?.Update();
    }

    #region Getters
    public PlayerService GetPlayerService() => playerService;

    public EnemyService GetEnemyService() => enemyService;

    public VFXService GetVFXService() => vfxService;

    public UIView GetUIService() => uiService;
    #endregion

}
