#region Namespaces
using UnityEngine;
using TMPro;
using PlaneShooter.Utilities;
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
    [SerializeField] private EnemyView enemyPrefab;
    #endregion

    #region Scriptable Objects
    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    [SerializeField] private BulletScriptableObject playerBulletScriptableObject;
    [SerializeField] private EnemyScriptableObject enemyScriptableObject;
    [SerializeField] private VFXScriptableObject vfxScriptableObject;
    #endregion

    private void Start()
    {
        // Initialize all Services.
        //playerService = new PlayerService(playerPrefab, playerScriptableObject, playerBulletPrefab, playerBulletScriptableObject);
        //powerUpService = new PowerUpService(powerUpScriptableObject);
        //enemyService = new EnemyService(enemyPrefab, enemyScriptableObject);
        //vfxService = new VFXService(vfxScriptableObject);
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
