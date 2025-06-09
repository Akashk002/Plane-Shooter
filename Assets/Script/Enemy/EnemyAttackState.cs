public class EnemyAttackState : IEnemyState
{
    private Enemy enemy;

    public EnemyAttackState(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter() { }

    public void Update()
    {
        enemy.Shooting.HandleShooting();
    }

    public void Exit() { }
}
