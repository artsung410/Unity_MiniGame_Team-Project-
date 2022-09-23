using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletoneBehaviour<GameManager>
{
    #region �÷��̾����

    public float PlayerSpeed;



    private PlayerDB playerData;

    #endregion



    #region ��ž����
    public int TowerDamage;
    public float TowerAttackArea;
    public float TowerAttackSpeed;

    public int TowerHP;
    public int TowerLevel;

    public int TowerPrice;


    private TowerDB toweData;

    #endregion





    #region ������
    public float EnemySpeed;
    public int EnemyHP;
    public float EnemyAttackSpeed;

    public int EnemyExp;
    public int EnemyGold;
    public float EnemyAttackArea;



    private EnemyDB enemyData;

    #endregion




    #region ���̺����

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
