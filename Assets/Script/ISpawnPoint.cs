using System.Collections;

namespace Assets.Script
{
    public interface ISpawnPoint
    {
        void Spawn();
        SpawnPointData Data { get; }
    }
}