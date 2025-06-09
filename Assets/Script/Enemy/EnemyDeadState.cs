public class EnemyDeadState : IEnemyState
{
    private Enemy enemy;

    public EnemyDeadState(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        enemy.Die(); // You can put Die logic here
    }

    public void Update() { }

    public void Exit() { }
}
