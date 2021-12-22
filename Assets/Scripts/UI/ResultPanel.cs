using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BlackAndWhite
{
    public class ResultPanel : MonoBehaviour
    {
        public TextMeshProUGUI ResultText;
        [SerializeField] private Button _restartBtn;
        [SerializeField] private Button _menuBtn;


        private void Awake()
        {
            _restartBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("CPUGame");
            });
            
            
            _menuBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Menu");
            });
                
            _restartBtn.gameObject.SetActive(false);
            _menuBtn.gameObject.SetActive(false);

        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _restartBtn.gameObject.SetActive(false);
            _menuBtn.gameObject.SetActive(false);

        }

        public void ShowFinal()
        {
            gameObject.SetActive(true);
            _restartBtn.gameObject.SetActive(true);
            _menuBtn.gameObject.SetActive(true);
        }
    }
}
