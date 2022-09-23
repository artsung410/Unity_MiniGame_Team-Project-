using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Target;

    #region Private필드
    [SerializeField] float Damage; // 데미지 랜덤성 고려해볼만함
    [SerializeField] int PlayerHP;


    #endregion

}
