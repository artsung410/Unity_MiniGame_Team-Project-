using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletoneBehaviour<GameManager>
{
    #region 플레이어관련

    public float PlayerSpeed;



    private PlayerDB playerData;

    #endregion



    #region 포탑관련
    public int TowerDamage;
    public float TowerAttackArea;
    public float TowerAttackSpeed;

    public int TowerHP;
    public int TowerLevel;

    public int TowerPrice;


    private TowerDB toweData;

    #endregion





    #region 적관련
    public float EnemySpeed;
    public int EnemyHP;
    public float EnemyAttackSpeed;

    public int EnemyExp;
    public int EnemyGold;
    public float EnemyAttackArea;



    private EnemyDB enemyData;

    #endregion




    #region 웨이브관련

    private WaveDB waveData;

    #endregion

    private void Awake()
    {
        waveData = DataManager.Instance.GetWaveData(1);
    }

    private void Start()
    {
        
    }



    private void Update()
    {
        
    }
}
