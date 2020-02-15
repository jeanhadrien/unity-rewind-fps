using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    private int kills = 0;
    private TextMeshProUGUI txt;
    
    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void AddKill()
    {
        kills += 1;
        txt.text = $"{kills} kills";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
