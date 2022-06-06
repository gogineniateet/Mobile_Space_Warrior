using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public const string PLAYER_SHIP_PREFAB = "PlayerShip";
    public const string PLAYER_BULLET_PREFAB = "PlayerBullet";

    public const string ENEMY_01_SHIP_PREFAB = "01_EnemyShip";
    public const string ENEMY_02_SHIP_PREFAB = "02_EnemyShip";
    public const string ENEMY_BULLET_PREFAB = "EnemyBullet";

    public const string ASTEROID_PREFAB = "Asteroid";

    //public const int PLAYER_BULLET_SPEED = 1;

    public const int ASTEROID_LAYER = 9;
    public const int PLAYER_BULLET = 8;
    public const int UI_LAYER = 5;
    public const int SHIP_LAYER = 7;
    #endregion
}
