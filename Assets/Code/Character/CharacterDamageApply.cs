using UnityEngine;

public class CharacterDamageApply : MonoBehaviour
{
    [SerializeField] private float _radiosApplyDamage;
    [SerializeField] private int _layerEnemy;
    private HitHandelr _hitHandelr;

    private void Start()
    {
        _hitHandelr = FindAnyObjectByType<HitHandelr>();
    }

    public void Init(float radiosApplyDamage,int layerEnemy)
    {
        _radiosApplyDamage = radiosApplyDamage;
        _layerEnemy = layerEnemy;
    }

    public void CheckDamage()
    {
        Collider2D[] collider2D = Physics2D.OverlapCircleAll(transform.position, _radiosApplyDamage, _layerEnemy);
        foreach (var item in collider2D)
        {
            IEnemyHit damageDealer = item.gameObject.GetComponent<IEnemyHit>();
            if (damageDealer != null)
            {
                //_hitHandelr.ApplyCharacterHitFromEnemy();
            }
        }
    }

    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 pos = transform.position;
        pos.z = 0; // чтобы в 2D правильно отображалось
        Gizmos.DrawWireSphere(pos, _radiosApplyDamage);
        Debug.Log(" _playerDataConfig.RadiosApplyDamage + " + _radiosApplyDamage);
    }
}

