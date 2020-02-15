using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _player;
    private GameObject _enemy;
    private int _frequency = 5;
    private Enemy _enemySo;
    void Start()
    {
        _enemy = (GameObject) Resources.Load("Enemy");
        _enemySo = ScriptableObject.CreateInstance<Enemy>();
        _player = GameObject.Find("Character");
        StartCoroutine(spawnEnemy());
    }
    
    
    IEnumerator spawnEnemy() {
        for(;;)
        {
            GameObject myEnemy = Instantiate(_enemy);
            myEnemy.name = _enemySo.names[Random.Range(0, _enemySo.names.Length)];
            myEnemy.GetComponent<EnemyBehaviour>()._enemySo = _enemySo;
            yield return new WaitForSeconds(_frequency);
        }
    }
    
    public void ChangeSpawnFrequency(int amount)
    {
        if (amount > 0) _frequency = amount;
    }

    void Update()
    {
        
    }
}
