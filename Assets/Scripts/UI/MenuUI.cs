using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
   [SerializeField] private Button _humanGameBtn;
   [SerializeField] private Button _CpuGameBtn;

    private void Start()
    {
        _humanGameBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Loading");
        });
        
        _CpuGameBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("CPUGame");
        });
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (_humanGameBtn == null)
        {
            _humanGameBtn =  transform.Find("HumanBtn").GetComponent<Button>();
        }
        
        if (_CpuGameBtn == null)
        {
            _CpuGameBtn = transform.Find("CpuBtn").GetComponent<Button>();
        }
    }
#endif
}