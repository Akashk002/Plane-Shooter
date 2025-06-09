public class EnemyIdleState : IEnemyState
{
    private Enemy enemy;

    public EnemyIdleState(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        // Optional: Play idle animation or wait
    }

    public void Update()
    {
        // Switch to Move after delay or trigger
        //enemy.StateMachine.ChangeState(new EnemyMoveState(enemy));
    }

    public void Exit() { }
}
