public class EnemyMoveState : IEnemyState
{
    private Enemy enemy;

    public EnemyMoveState(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter() { }

    public void Update()
    {
        enemy.Movement.Move();

        // Transition to attack if in range or timed
        enemy.StateMachine.ChangeState(new EnemyAttackState(enemy));
    }

    public void Exit() { }
}
