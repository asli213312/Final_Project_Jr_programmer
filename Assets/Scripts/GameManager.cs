using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _displayText;

    // ABSTRACTION
    private void Start()
    {
        Singleton();
    }

    public void SetText(string newText)
    {
        if (!_displayText.gameObject.activeInHierarchy)
            _displayText.gameObject.SetActive(true);
        
        _displayText.SetText(newText);
    }

    private void Singleton()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}
