using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Zombiee
{
    public GameObject zombiePrefab;
    public Vector2 zombieOriginPosition;
}

public class Wave : MonoBehaviour
{
    public int WaveDuration { get; private set; }
    public int CurrentZombie { get; private set; }

    [SerializeField] List<Zombiee> zombies;
    [SerializeField] List<int> timeBreaksBeforeNextZombieSpawn;

    private void Awake()
    {
        WaveDuration = timeBreaksBeforeNextZombieSpawn.Sum();
    }

    public void StartWave()
    {
        StartCoroutine(WaveExecution());
    }

    IEnumerator WaveExecution()
    {
        for (int i = 0; i < zombies.Count; i++)
        {
            yield return new WaitForSeconds(timeBreaksBeforeNextZombieSpawn[CurrentZombie]);

            Instantiate(zombies[CurrentZombie].zombiePrefab, zombies[CurrentZombie].zombieOriginPosition, Quaternion.identity);

            CurrentZombie++;
        }
    }
}
