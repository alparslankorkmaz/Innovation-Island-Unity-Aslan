using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IslandManager : MonoBehaviour
{
    public Button EnterButton;

    private void Awake()
    {
        Time.timeScale = 0f;
    }

    private void OnEnable()
    {
        EnterButton.onClick.AddListener(StartGame);
    }
    private void OnDisable()
    {
        EnterButton.onClick.RemoveListener(StartGame);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {

    }

    public void StartGame()
    {
        Time.timeScale = 1f;
    }
}
