using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class SpawnPoint : MonoBehaviour, ISpawnPoint
    {
        [SerializeField]
        private SpawnPointData _spawnPointData;

        private int _spawnedCount;

        public SpawnPointData Data
        {
            get { return _spawnPointData; }
        }

        public void Spawn()
        {

            Bounds b = new Bounds(transform.position, Vector3.one);
            for (int i = 0; i < Data.Amount; ++i)
            {
                
                var position = transform.position + i * Data.Spacing;
                var go = Instantiate(Data.EntityData.Prefab, position, Quaternion.identity);
                go.transform.parent = transform;
                
                var movement = go.GetComponent<IMovement>();
                movement.Init();
                movement.SetPosition();

                var childBounds = go.GetComponent<Collider>().bounds;
                
                b.Encapsulate(childBounds);
            }

            var collider = GetComponent<BoxCollider>();
            collider.size = b.size;
            collider.center = transform.InverseTransformPoint(b.center);
        }
    }
}