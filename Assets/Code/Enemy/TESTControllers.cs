using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTControllers : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private EnemyMeleeDataConfig enemyMeleeData;
    [SerializeField] private EnemyMeleeDataConfig enemyMeleeDataTWO;
    private List<EnemyMeleeData> _enemyMeleeView;
    private IEnemyFactory _enemyFactory;
    private EnemyPool enemyPool;

    [SerializeField] private float _interval = 5f; // интервал в секундах

    private void Start()
    {
        _enemyFactory = new EnemyFactory();
        enemyPool = new EnemyPool();
        _enemyMeleeView = new List<EnemyMeleeData>();

        for (int i = 0; i < 5; i++)
        {
            if ((i % 2) == 0)
                _enemyMeleeView.Add(_enemyFactory.CreateEnemy(enemyMeleeData));
            else
                _enemyMeleeView.Add(_enemyFactory.CreateEnemy(enemyMeleeDataTWO));
        }

        // запускаем корутину
        StartCoroutine(FiveSecondLoop());
    }

    private void Update()
    {
        MoveToTarget();
    }

    public void ApplyDamage(IDamageable target, int amount, GameObject source)
    {
        EnemyMeleeView enemyView = (EnemyMeleeView)target;
        EnemyMeleeData enemyMeleeData = enemyView.Data;
        enemyMeleeData.Health -= amount;
        if (enemyMeleeData.Health <= 0)
        {
            _enemyMeleeView.Remove(enemyView.Data);
            enemyPool.ReturnInPool(enemyView);
            enemyView.gameObject.SetActive(false);
        }
    }

    private void MoveToTarget()
    {
        int listCount = _enemyMeleeView.Count;
        for (int i = 0; i < listCount; i++)
        {
            EnemyMeleeData enemyMeleeData = _enemyMeleeView[i];
            Vector3 direction = (_target.position - enemyMeleeData.EnemyMeleeView.transform.position).normalized;
            enemyMeleeData.Gameobject.transform.position += direction * enemyMeleeData.EnemyDataConfigBase.Speed * Time.deltaTime;
            if (direction.x < 0)
                enemyMeleeData.EnemyMeleeView.Flip(FlipSprite.Right);
            else
                enemyMeleeData.EnemyMeleeView.Flip(FlipSprite.Left);
            ApplySeparation();
        }
    }

    private void ApplySeparation()
    {
        int listCount = _enemyMeleeView.Count;
        for (int i = 0; i < listCount; i++)
        {
            if (_enemyMeleeView[i] == null) continue;
            Transform enemyI = _enemyMeleeView[i].Gameobject.transform;
            for (int j = 0; j < listCount; j++)
            {
                if (i == j) continue;
                if (_enemyMeleeView[j] == null) continue;

                Transform enemyJ = _enemyMeleeView[j].Gameobject.transform;

                float dist = Vector3.Distance(enemyI.position, enemyJ.position);

                if (dist < enemyMeleeData.SeparationData.Radius && dist > 0.001f)
                {
                    Vector3 pushDir = (enemyI.position - enemyJ.position).normalized;
                    float force = (enemyMeleeData.SeparationData.Radius - dist) / enemyMeleeData.SeparationData.Radius;

                    enemyI.position += pushDir * (enemyMeleeData.SeparationData.Force * force * Time.deltaTime);
                }
            }
        }
    }

    // 🔹 вызывается каждые 5 секунд
    private void OnFiveSecondsTick()
    {
        Debug.Log("Прошло 5 секунд!");
        if (enemyPool.IsNotEmpty())
        {
           EnemyView objectFromPool =  enemyPool.GetObjectOrNull();
            EnemyMeleeView a = (EnemyMeleeView)objectFromPool;
            _enemyMeleeView.Add(a.Data);
            a.gameObject.SetActive(true);

        }
       

    }

    // 🔹 корутина с таймером
    private IEnumerator FiveSecondLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(_interval);
            OnFiveSecondsTick();
        }
    }
}
