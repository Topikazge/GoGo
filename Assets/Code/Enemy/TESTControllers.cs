using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTControllers : MonoBehaviour, IHitEnemies
{
    [SerializeField] private Transform _target;
    [SerializeField] private EnemyMeleeDataConfig enemyMeleeData;
    [SerializeField] private EnemyMeleeDataConfig enemyMeleeDataTWO;
    [SerializeField] private int _amountEnemy;
    [SerializeField] private int _moveCount;
    [SerializeField] private float _interval = 5f;
    private List<EnemyMeleeData> _enemyMeleeView;
    private IEnemyFactory _enemyFactory;
    private EnemyPool enemyPool;

    private void Start()
    {
        _enemyFactory = new EnemyFactory();
        enemyPool = new EnemyPool();
        _enemyMeleeView = new List<EnemyMeleeData>();

        for (int i = 0; i < _amountEnemy; i++)
        {
            if ((i % 2) == 0)
                _enemyMeleeView.Add(_enemyFactory.CreateEnemy(enemyMeleeData));
            else
                _enemyMeleeView.Add(_enemyFactory.CreateEnemy(enemyMeleeDataTWO));
        }

        _moveCount = Mathf.Min(_moveCount, _amountEnemy);
        StartCoroutine(FiveSecondLoop());
    }

    private void Update()
    {
        MoveToTarget();
    }

    public void ApplyHit(IDamageable target, int amount, GameObject source)
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

    public void ApplyDamageCharacter(IEnemyHit enemyHit)
    {
        // IEnemyHit
    }

    private void MoveToTarget()
    {
        int listCount = _enemyMeleeView.Count;
        if (listCount == 0) return;

        List<int> indices = new List<int>();
        for (int i = 0; i < listCount; i++)
        {
            indices.Add(i);
        }

        List<int> movingIndices = new List<int>();
        int enemiesToMove = Mathf.Min(_moveCount, listCount);
        for (int i = 0; i < enemiesToMove; i++)
        {
            if (indices.Count == 0) break;
            int randomIndex = UnityEngine.Random.Range(0, indices.Count);
            int enemyIndex = indices[randomIndex];
            indices.RemoveAt(randomIndex);
            movingIndices.Add(enemyIndex);

            EnemyMeleeData enemyMeleeData = _enemyMeleeView[enemyIndex];
            if (enemyMeleeData == null) continue;

            Vector3 direction = (_target.position - enemyMeleeData.EnemyMeleeView.transform.position).normalized;
            enemyMeleeData.Gameobject.transform.position += direction * enemyMeleeData.EnemyDataConfigBase.Speed * Time.deltaTime;

            if (direction.x < 0)
                enemyMeleeData.EnemyMeleeView.Flip(FlipSprite.Right);
            else
                enemyMeleeData.EnemyMeleeView.Flip(FlipSprite.Left);
        }

        ApplySeparation(movingIndices);
    }

    private void ApplySeparation(List<int> movingIndices)
    {
        int movingCount = movingIndices.Count;
        for (int k = 0; k < movingCount; k++)
        {
            int i = movingIndices[k];
            if (_enemyMeleeView[i] == null) continue;
            Transform enemyI = _enemyMeleeView[i].Gameobject.transform;
            EnemyMeleeData dataI = _enemyMeleeView[i];

            for (int j = 0; j < _enemyMeleeView.Count; j++)
            {
                if (i == j) continue;
                if (_enemyMeleeView[j] == null) continue;

                Transform enemyJ = _enemyMeleeView[j].Gameobject.transform;

                float dist = Vector3.Distance(enemyI.position, enemyJ.position);

                if (dist < dataI.EnemyDataConfigBase.SeparationData.Radius && dist > 0.001f)
                {
                    Vector3 pushDir = (enemyI.position - enemyJ.position).normalized;
                    float force = (dataI.EnemyDataConfigBase.SeparationData.Radius - dist) / dataI.EnemyDataConfigBase.SeparationData.Radius;
                    enemyI.position += pushDir * (dataI.EnemyDataConfigBase.SeparationData.Force * force);

                    Debug.Log($"Отталкивание: enemy {i} от enemy {j}, dist: {dist}, force: {force * dataI.EnemyDataConfigBase.SeparationData.Force}");
                }
            }
        }
    }

    private void OnFiveSecondsTick()
    {
        Debug.Log("Прошло 5 секунд!");
        if (enemyPool.IsNotEmpty())
        {
            EnemyView objectFromPool = enemyPool.GetObjectOrNull();
            EnemyMeleeView a = (EnemyMeleeView)objectFromPool;
            _enemyMeleeView.Add(a.Data);
            a.gameObject.SetActive(true);
        }
    }

    private IEnumerator FiveSecondLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(_interval);
            OnFiveSecondsTick();
        }
    }
}