using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Indica la ronda en la que estamos
/// Este script nos va a indicar cuantos zombis por ronda deben de salir
/// Cuando es ronda especial
/// Cuando pasa de ronda
/// </summary>
public class WaveManager : MonoBehaviour
{
    /// <summary>
    /// TAREA:
    /// 
    /// Empezar la comunicacion entre el Wave Manager y el Spawn Manager
    /// Empezar a spawnear N cantidad de zombies, en la ronda 1, y que todos hagan spawn
    /// en el tiempo definido en totalSpawnTime del SpawnManager
    /// El spawnRate lo conseguiran usando la cantidad total de zombies y el tiempo total de spawn
    /// Y deben de aparecer en un spawn random de la spawnPoint list
    /// 
    /// 
    /// PROYECTO FINAL
    /// 
    /// Para que la ronda termine, deben de morir todos los zombies spawneados
    /// Cada vez que muera un zombie se le resta 1 a zombiesInWave
    /// Cada vez que avance la ronda, se le suman 4 zombies
    /// Y el totalSpawnTime del SpawnManager se le suma 3 con cada paso de ronda
    /// 
    /// </summary>
    [SerializeField] private int actualRound = 1;

    [SerializeField, Tooltip("Cantidad de zombies que deben de aparecer en la ronda")] 
    private int zombiesToSpawn;
    private int zombiesInWave;//Cantidad de zombies que se deben de matar para pasar de ronda

    [Tooltip("Indica si es ronda especial de perros")]
    [SerializeField] private bool isSpecialRound;

    [SerializeField, Range(8,15),Tooltip("Tiempo de descanso entre fin e inicio de ronda")] 
    private float timeBetweenRounds;

    [SerializeField] private UnityEvent onWaveStart;
    [SerializeField] private UnityEvent<int> startWave;
    [SerializeField] private UnityEvent onWaveEnd;
    
    private void Start()    
    {
        //StartWave();
    }

    [ContextMenu("Start Wave")]
    private void StartWave()
    {
        onWaveStart?.Invoke();
        startWave?.Invoke(zombiesToSpawn);

        zombiesInWave = zombiesToSpawn;
    }

    public void SetZombiesToSpawn()
    {
        zombiesToSpawn += 4;
    }
    
    public void ZombieKilled()
    {
        zombiesInWave--;
        if(zombiesInWave == 0)
        {
            onWaveEnd.Invoke();
        }
    }

}
