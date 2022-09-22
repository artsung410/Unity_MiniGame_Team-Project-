using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletoneBehaviour
{
    #region �÷��̾����

    public float PlayerSpeed;


    #endregion



    #region ��ž����
    public int TowerDamage;
    public float TowerAttackArea;
    public float TowerAttackSpeed;

    public int TowerHP;
    public int TowerLevel;

    public int TowerPrice;

    #endregion





    #region ������
    public float EnemySpeed;
    public int EnemyHP;
    public float EnemyAttackSpeed;

    public int EnemyExp;
    public int EnemyGold;
    public float EnemyAttackArea;

    #endregion




    #region ���̺�
    public int RespawnTime;
    public int RespawnEnemyCount;

    #endregion
}
