using System;
public static class GameAction
{
    public static Action<int> OnPlayerDamage;
    public static Action OnCollisionWithCoin;
    public static Action OnCollisionWithHealthBonus;
    public static Action<int> OnUpdatePlayerHealthSlider;
    public static Action<int> OnEnemyDamage;
    public static Action OnPlayerDie;
    public static Action OnGameComplete;
}