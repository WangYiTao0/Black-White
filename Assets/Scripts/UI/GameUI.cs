using System;
using System.Collections;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace BlackAndWhite
{


    public class GameUI : MonoBehaviour
    {
        [SerializeField] private Button _menuBtn;
        [SerializeField] private Button _shuffleBtn;
        [SerializeField] private Button _submitBtn;

        [SerializeField] private TextMeshProUGUI _winPointText;
        [SerializeField] private TextMeshProUGUI _cpuPointText;

        [SerializeField] private Player _player;
        [SerializeField] private Player _cpu;
        [SerializeField] private ResultPanel _resultPanel;

        private void Start()
        {
            _submitBtn.onClick.AddListener(() =>
            {
                _player.SubmitCard();
            });
            _shuffleBtn.onClick.AddListener(() =>
            {
                _player.ShuffleCard();
            });

            _player.WinPoint.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(value =>
                {
                    _winPointText.SetText(value.ToString());
                }).AddTo(this);
            _cpu.WinPoint.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(value =>
                {
                    _cpuPointText.SetText(value.ToString());
                }).AddTo(this);
        }

        public void ShowResultPanel(string resultStr)
        {
            _resultPanel.Show();
            _resultPanel.ResultText.SetText(resultStr);
            StartCoroutine(DisablePanel());
        }
        
        public void ShowFinalResultPanel(string resultStr)
        {
            _resultPanel.ShowFinal();
            _resultPanel.ResultText.SetText(resultStr);
        }


        private IEnumerator DisablePanel()
        {
            yield return new WaitForSeconds(1f);
            _resultPanel.Hide();
        }
    }
}