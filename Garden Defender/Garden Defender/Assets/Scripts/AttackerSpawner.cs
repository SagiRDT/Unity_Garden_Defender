/*
 *  AttackerSpawner
 *  Handle the spawning of attackers (enemies)
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    // Config params
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackersPrefabsArray;

    // Variables
    bool spawn = true;

    // Start the attacker spawning, theres a random delay between each spwan
    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    // Stop the spawning
    public void StopSpawning()
    {
        spawn = false;
    }

    // Spawn a random attcker from the attackers array
    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackersPrefabsArray.Length);
        Spawn(attackersPrefabsArray[attackerIndex]);
    }

    // Spawn the attacker we get a param
    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

}
