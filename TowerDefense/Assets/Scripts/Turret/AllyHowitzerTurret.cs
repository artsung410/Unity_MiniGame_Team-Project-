using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyHowitzerTurret : Turret
{
    public static Vector3 Target;
    [SerializeField] float _range = 0f;
    [SerializeField] LayerMask _layerMask = 0;

    public static Transform _target = null;
    public GameObject BulletRoute;

    private void Start()
    {
        InvokeRepeating("SerchEnemy", 0f, 0.5f); // ���۰� ���ÿ� 0.5�ʸ��� �ݺ��ؼ� ȣ��
        StartCoroutine(Fire());
    }

    private void Update()
    {
        if (_target != null)
        {
            BulletRoute.transform.GetChild(2).transform.position = _target.position;
        }

        // Ÿ���� ���ٸ� ������ ȸ���� �Ѵ�
        if (_target == null)
        {
            // ������ ����ġ ��Ų��
            Gun.transform.eulerAngles = new Vector3(0f, Gun.transform.eulerAngles.y, Gun.transform.eulerAngles.z);
            //Debug.Log("�� ����");
            RotatedTurret.transform.Rotate(new Vector3(0f, 45f, 0f) * Time.deltaTime);

            onFire = false;
            isDetactive = false;
        }
        else
        {
            //Debug.Log("�� Ž��");

            onFire = true;
            isDetactive = true;

            Quaternion _lookRotation = Quaternion.LookRotation(_target.position - BulletSpawnPoint.position);
            Gun.transform.rotation = _lookRotation;

            // �ε巴�� ����ȸ��
            // RotateTowards : a���� b���� c�� �ӵ��� ȸ��
            Vector3 _euler = Quaternion.RotateTowards(RotatedTurret.transform.rotation, _lookRotation, RotateSpeed * Time.deltaTime).eulerAngles; // ���Ϸ������� ��ȯ�� ���Ϳ� ������
            RotatedTurret.transform.rotation = Quaternion.Euler(0, _euler.y, 0);
        }
    }

    private void SerchEnemy()
    {
        Collider[] _colliders = Physics.OverlapSphere(transform.position, _range, _layerMask); // ��ü �ֺ��� �ݶ��̴� �����ϰ� �����
        Transform _shortTarget = null; // �ͷ��� ���� ����� ��� �ӽ÷� ����

        //�ݶ��̴��� �ϳ��� ����Ǹ� ����
        if (_colliders.Length > 0)
        {
            // ª���Ÿ��� ���Ϸ��� ���� �� ��ü�� ����
            float _shortTempDistance = Mathf.Infinity; // ���Ѵ� ���� ����
            // ����� �ݶ��̴���ŭ �ݺ����ֱ�
            foreach (Collider _colTarget in _colliders)
            {
                // SqrMagnitude - ������ȯ(�����Ÿ� * �����Ÿ�) <- ��ġ����� ��������� ���Ե�
                // Distance - ��Ʈ������ ��ȯ(�����Ÿ�)
                float _distance = Vector3.SqrMagnitude(transform.position - _colTarget.transform.position);
                // ����� �Ÿ����� �񱳸����� ������ �۴ٸ�
                if (_shortTempDistance > _distance)
                {
                    // �� ���� �ٽ� �������� �����
                    _shortTempDistance = _distance;
                    // ���� ����� ����� transform�� �־���
                    _shortTarget = _colTarget.transform;
                }
            }

        }
        // �ݺ����� �Ϸ�Ǹ� ���� ����� ����� �����
        // ����Ÿ�ٿ� ���尡������� �־���
        // �Ÿ����� Ÿ���� ���ٸ� null�� �־���
        _target = _shortTarget;


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            onFire = true;
            isDetactive = true;
            Target = other.gameObject.transform.position;
            Vector3 dir = other.gameObject.transform.position - BulletSpawnPoint.position;
            Gun.transform.rotation = Quaternion.LookRotation(dir);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            onFire = false;
        }
    }

    public override void TakeDamage(int damage)
    {
        throw new System.NotImplementedException();
    }

    protected override IEnumerator Fire()
    {
        yield return null;
        //while (true)
        //{
        //    yield return new WaitForSeconds(1f);

        //    if (onFire)
        //    {
        //        HowitzerBullet bullet = HowitzerBulletPool.GetObject();
        //        bullet.gameObject.transform.position = BulletSpawnPoint.position;
        //        bullet.gameObject.transform.rotation = BulletSpawnPoint.rotation;
        //    }
        //}
    }
}
