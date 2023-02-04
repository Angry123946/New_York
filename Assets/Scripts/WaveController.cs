using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public int CurrentWave { get; private set; }

    [SerializeField] List<Wave> waves;
    [SerializeField] List<int> breaksBetweenWaves;

    // Start is called before the first frame update
    void Start()
    {
        StartWaves();
    }

    void StartWaves()
    {
        StartCoroutine(WavesExecution());
    }

    IEnumerator WavesExecution()
    {
        for(int i = 0; i < waves.Count; i++)
        {
            waves[i].StartWave();

            yield return new WaitForSeconds(waves[i].WaveDuration);
            yield return new WaitForSeconds(breaksBetweenWaves[i]);
        }
    }
}
