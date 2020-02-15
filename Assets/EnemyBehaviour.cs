using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyBehaviour : MonoBehaviour
{
    public Enemy _enemySo;
    private Text _nameBox;
    private Canvas _canvas;
    private Camera _camera;
    private GameManager _gm;
    private KillCount _kc;
    private Boolean dead = false;
    void Start()
    {
        _camera = GameObject.Find("Character").GetComponentInChildren<Camera>();
        _gm = GameObject.Find("__Game").GetComponent<GameManager>();
        _kc = GameObject.Find("Kills").GetComponent<KillCount>();
        foreach (Transform child in transform)
        {
            if (child.transform.gameObject.name == "Sphere")
            {
                _canvas = child.GetChild(0).GetComponent<Canvas>();
                _nameBox =  child.GetChild(0).GetChild(0).GetComponent<Text>();
            }

        }

        _nameBox.text = transform.name;
    }

    public void Kill()
    {
        if (!dead)
        {
            StartCoroutine(DoKill());
            _kc.AddKill();
            dead = true;
        }
    }

    private IEnumerator DoKill()
    {
        _nameBox.text = _enemySo.onDeath[Random.Range(0,_enemySo.onDeath.Length)];
        yield return new WaitForSeconds(3);
        _nameBox.text = "";
        

    }
    // Update is called once per frame
    void Update()
    { 
        _nameBox.transform.LookAt(_camera.transform);
        _nameBox.transform.Rotate(0,180,0);
    }
}
