using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletoneBehaviour
{
    #region 플레이어관련

    public float PlayerSpeed;


    #endregion



    #region 포탑관련
    public int TowerDamage;
    public float TowerAttackArea;
    public float TowerAttackSpeed;

    public int TowerHP;
    public int TowerLevel;

    public int TowerPrice;

    #endregion





    #region 적관련
    public float EnemySpeed;
    public int EnemyHP;
    public float EnemyAttackSpeed;

    public int EnemyExp;
    public int EnemyGold;
    public float EnemyAttackArea;

    #endregion




    #region 웨이브
    public int RespawnTime;
    public int RespawnEnemyCount;

    #endregion
}
