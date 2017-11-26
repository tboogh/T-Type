using System.Collections;

namespace Assets.Script
{
    public interface ISpawnPoint
    {
        IEnumerator Spawn();
        bool Spawned { get; }
        SpawnPointData Data { get; }
    }
}