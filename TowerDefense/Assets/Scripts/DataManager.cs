using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDB
{
    public int ID;
    public int Gold;
    public int Level;
    public int Max_Exp;
    public float Move_Speed;

    public int Attack;
    public float Attack_Speed;
    public float Attack_Range;

    public int Hp;
    public float Build_Range;


    #region 敲饭捞绢包访 积己磊
    public PlayerDB(int iD, int gold, int level, int max_Exp, float move_Speed, int attack, float attack_Speed, float attack_Range, int hp, float build_Range)
    {
        ID = iD;
        Gold = gold;
        Level = level;
        Max_Exp = max_Exp;
        Move_Speed = move_Speed;
        Attack = attack;
        Attack_Speed = attack_Speed;
        Attack_Range = attack_Range;
        Hp = hp;
        Build_Range = build_Range;
    }


    #endregion



}
public class EnemyDB
{
    public int ID;
    public string Name;
    public int HP;
    public float Move_Speed;
    public int Attack;
    public float Attack_speed;
    public float Attack_Range;
    public int Exp;


    #region 利包访 积己磊
    public EnemyDB(int iD, string name, int hP, float move_Speed, int attack, float attack_speed, float attack_Range, int exp)
    {
        ID = iD;
        Name = name;
        HP = hP;
        Move_Speed = move_Speed;
        Attack = attack;
        Attack_speed = attack_speed;
        Attack_Range = attack_Range;
        Exp = exp;
    }


    #endregion
}
public class TowerDB
{
    public int ID;
    public string Name;
    public int Gold;
    public int Level;
    public int Upgrade;
    public int Next_Upgrade;
    
    public int Attack;
    public float Attack_range;
    public float Attack_Speed;


    #region 鸥况包访 积己磊
    public TowerDB(int iD, string name, int gold, int level, int upgrade, int next_Upgrade, int attack, float attack_range, float attack_Speed)
    {
        ID = iD;
        Name = name;
        Gold = gold;
        Level = level;
        Upgrade = upgrade;
        Next_Upgrade = next_Upgrade;
        Attack = attack;
        Attack_range = attack_range;
        Attack_Speed = attack_Speed;
    }


    #endregion
}
public class WaveDB
{
    public int ID;

    public int Enemy_ID;
    public int Enemy_Value;

    public int Enemy2_ID;
    public int Enemy2_Value;

    public int Enemy3_ID;
    public int Enemy3_Value;

    public int Spawn_Time;



    #region 傀捞宏包访 积己磊
    public WaveDB(int iD, int enemy_ID, int enemy_Value, int enemy2_ID, int enemy2_Value, int enemy3_ID, int enemy3_Value, int spawn_Time)
    {
        ID = iD;
        Enemy_ID = enemy_ID;
        Enemy_Value = enemy_Value;
        Enemy2_ID = enemy2_ID;
        Enemy2_Value = enemy2_Value;
        Enemy3_ID = enemy3_ID;
        Enemy3_Value = enemy3_Value;
        Spawn_Time = spawn_Time;
    }



    #endregion

}


public class DataManager : MonoBehaviour
{
    // 郴何俊辑父 蔼荐沥(set)啊瓷, 寇何俊急 get 啊瓷
    // public int Index { get; private set; }


    static GameObject container;
    static GameObject Container { get => container; }

    static DataManager instance;

    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                container = new GameObject();
                container.name = "DataManager";
                instance = container.AddComponent(typeof(DataManager)) as DataManager;

                // 窃荐啊 贸澜 父甸绢龙锭 wave 阂矾咳 
                instance.SetWaveDataFromCsv();
                instance.SetEnemyDataFromCsv();
                instance.SetPlayerDataFromCsv();
                instance.SetTowerDataFromCsv();



                DontDestroyOnLoad(container);
            }

            return instance;
        }
    }

    public string GameDataFileName = ".json";


    #region WAVE

    [Header("Wave包访 DB")]
    [SerializeField] TextAsset waveDB;

    public Dictionary<int, WaveDB> waveDataDict { get; set; }

    private void SetWaveDataFromCsv()
    {
        waveDB = Resources.Load<TextAsset>("Csv/WaveDB");
        if (waveDB == null)
        {
            Debug.LogError("单捞磐 厚绢乐澜");
        }

        if (waveDataDict == null)
        {
            waveDataDict = new Dictionary<int, WaveDB>();
        }

        string[] waveCsvLines = waveDB.text.Substring(0, waveDB.text.Length).Split('\n');
        for (int i = 3; i < waveCsvLines.Length; i++)
        {
            // 茄临寸 沥焊历厘吝
            // 0锅掳俊绰 汲疙捞骨肺 罐阑 鞘夸绝促
            // 1锅掳何磐 鞘夸茄何盒捞骨肺 i = 1矫累
            string[] row = waveCsvLines[i].Split(',');
            waveDataDict.Add(int.Parse(row[0]), new WaveDB
                (
                int.Parse(row[0]),
                int.Parse(row[1]),
                int.Parse(row[2]),
                int.Parse(row[3]),
                int.Parse(row[4]),
                int.Parse(row[5]),
                int.Parse(row[6]),
                int.Parse(row[7])
                ));
        }
    }

    public WaveDB GetWaveData(int idx)
    {
        Debug.Log("Wave Data 龋免");

        if (waveDataDict.ContainsKey(idx))
        {
            return waveDataDict[idx];
        }
        Debug.LogWarning("牢郸胶 单捞磐 绝澜");
        return null;
    }
    #endregion


    #region PLAYER

    [Header("Player包访 DB")]
    [SerializeField] TextAsset playerDB;

    public Dictionary<int, PlayerDB> playerDataDict { get; set; }

    private void SetPlayerDataFromCsv()
    {
        playerDB = Resources.Load<TextAsset>("Csv/PlayerDB");
        if (playerDB == null)
        {
            Debug.LogError("单捞磐 厚绢乐澜");
        }

        if (playerDataDict == null)
        {
            playerDataDict = new Dictionary<int, PlayerDB>();
        }

        string[] playerCsvLines = playerDB.text.Substring(0, playerDB.text.Length).Split('\n');
        for (int i = 3; i < playerCsvLines.Length; i++)
        {
            string[] row = playerCsvLines[i].Split(',');
            playerDataDict.Add(int.Parse(row[0]), new PlayerDB
                (
                int.Parse(row[0]),
                int.Parse(row[1]),
                int.Parse(row[2]),
                int.Parse(row[3]),
                float.Parse(row[4]),
                int.Parse(row[5]),
                float.Parse(row[6]),
                float.Parse(row[7]),
                int.Parse(row[8]),
                float.Parse(row[9])
                ));
        }
    }

    public PlayerDB GetPlayerData(int idx)
    {
        Debug.Log("Player Data 龋免");

        if (playerDataDict.ContainsKey(idx))
        {
            return playerDataDict[idx];
        }
        Debug.LogWarning("牢郸胶 单捞磐 绝澜");
        return null;
    }

    #endregion


    #region ENEMY

    [Header("Enemy包访 DB")]
    [SerializeField] TextAsset enemyDB;

    public Dictionary<int, EnemyDB> EnemyDataDict { get; set; }

    private void SetEnemyDataFromCsv()
    {
        enemyDB = Resources.Load<TextAsset>("Csv/EnemyDB");
        if (enemyDB == null)
        {
            Debug.LogError("单捞磐 厚绢乐澜");
            return;
        }

        if (EnemyDataDict == null)
        {
            EnemyDataDict = new Dictionary<int, EnemyDB>();
        }

        string[] enemyCsvLines = enemyDB.text.Substring(0, enemyDB.text.Length).Split('\n');
        for (int i = 3; i < enemyCsvLines.Length; i++)
        {
            string[] row = enemyCsvLines[i].Split('\n');
            EnemyDataDict.Add(int.Parse(row[0]), new EnemyDB(
                int.Parse(row[0]),
                row[1],
                int.Parse(row[2]),
                float.Parse(row[3]),
                int.Parse(row[4]),
                float.Parse(row[5]),
                float.Parse(row[6]),
                int.Parse(row[7])
                ));
        }
    }


    public EnemyDB GetEnemyData(int idx)
    {
        Debug.Log("Enemy Data 龋免");
        if (EnemyDataDict.ContainsKey(idx))
        {
            return EnemyDataDict[idx];
        }
        Debug.LogWarning("牢郸胶 单捞磐 绝澜");
        return null;

    }


    #endregion


    #region TOWER

    [Header("Tower包访 DB")]
    [SerializeField] TextAsset towerDB;

    public Dictionary<int, TowerDB> towerDataDict { get; set; }

    private void SetTowerDataFromCsv()
    {
        if(towerDB == null)
        {
            return;
        }

        if (towerDataDict == null)
        {
            towerDataDict = new Dictionary<int, TowerDB>();
        }

        string[] towerCsvLines = towerDB.text.Substring(0, towerDB.text.Length).Split('\n');
        for (int i = 3; i < towerCsvLines.Length; i++)
        {
            string[] row = towerCsvLines[i].Split('\n');
            towerDataDict.Add(int.Parse(row[0]), new TowerDB(
                int.Parse(row[0]),
                row[1],
                int.Parse(row[2]),
                int.Parse(row[3]),
                int.Parse(row[4]),
                int.Parse(row[5]),
                int.Parse(row[6]),
                float.Parse(row[7]),
                float.Parse(row[8])
                ));
        }
    }

    public TowerDB GetTowerData(int idx)
    {
        Debug.Log("Tower Data 龋免");

        if (towerDataDict.ContainsKey(idx))
        {
            return towerDataDict[idx];
        }

        return null;

    }

    #endregion


}
