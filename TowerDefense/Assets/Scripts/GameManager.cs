using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : SingletoneBehaviour<GameManager>
{
    [SerializeField] private TextMeshProUGUI _goldText;

    #region 플레이어관련

    public float PlayerSpeed;
    private PlayerDB playerData;
    public int PlayerGold;

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

    public int EnemySpawnCount;
    public int EnemyDeathCount;

    private EnemyDB enemyData;

    #endregion




    #region 웨이브관련

    private WaveDB waveData;

    #endregion

    private void Awake()
    {
        //waveData = DataManager.Instance.GetWaveData(1);
        //enemyData = DataManager.Instance.GetEnemyData(1);
    }

    private void Start()
    {
        //Debug.Log(waveData.ID);
        //Debug.Log(enemyData.Move_Speed);
<<<<<<< HEAD
        PlayerGold = 1000;
        GameOverAvaliable = false;
=======
        PlayerGold = 10000;
>>>>>>> a128c0448eba9bfe52921307538fbe53092c341c

    }

    public bool GameOverAvaliable;

    private void Update()
    {
        _goldText.text = $"Gold : {PlayerGold}";


        if (EnemySpawnCount == EnemyDeathCount)
        {
            Debug.Log("다죽임");
            GameOverAvaliable = true;
        }

    }
}
