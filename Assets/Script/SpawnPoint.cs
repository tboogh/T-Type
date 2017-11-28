using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class SpawnPoint : MonoBehaviour, ISpawnPoint
    {
        [SerializeField]
        private SpawnPointData _spawnPointData;

        [SerializeField]
        private bool _spawned;

        private int _spawnedCount;

        public SpawnPointData Data
        {
            get { return _spawnPointData; }
        }

        public bool Spawned
        {
            get { return _spawned; }
        }

        public IEnumerator Spawn()
        {
            if (_spawned)
                yield break;

            _spawned = true;
            do
            {
                Instantiate(Data.EntityData.Prefab, transform.position, Quaternion.identity);
                _spawnedCount++;
                yield return new WaitForSeconds(Data.Rate);
            }
            while (_spawnedCount < Data.Amount);
        }

        public void PerformSpawn()
        {
            for (int i = 0; i < Data.Amount; ++i)
            {
                var position = transform.position + i * Data.Spacing;
                var go = Instantiate(Data.EntityData.Prefab, position, Quaternion.identity);
                go.transform.parent = transform;
                
                var movement = go.GetComponent<IMovement>();
                movement.SetPosition();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            PerformSpawn();
        }
    }
}