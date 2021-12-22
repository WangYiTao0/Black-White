using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace BlackAndWhite
{
    public class CPUGameManager : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Player _cpu;
        [SerializeField] private CPUInput _cpuInput;

        [SerializeField] private GameUI _gameUI;
        private int _battleCount = 0;

        private void Start()
        {
            InitPlayers();
            // ai 先手
            // _aiInput.Action();
        }

        private void OnDestroy()
        {
            _player.SubmitAction -= HandleSubmitAction;
            _cpu.SubmitAction -= HandleSubmitAction;
        }

        private void InitPlayers()
        {
            _player.Init();
            _player.SubmitAction += HandleSubmitAction;
            
            _cpu.Init();
            _cpu.SubmitAction += HandleSubmitAction;
        }

        private void HandleSubmitAction()
        {
            if (IsCompletedSubmit())
            {
                StartCoroutine(Battle());
            }
            else
            {
                //ai 后手
                _cpuInput.Action();
            }
        }

        IEnumerator Battle()
        {
            Debug.Log("Battle");
            int player = _player.SubmittedCard.Number;
            int CPU = _cpu.SubmittedCard.Number;

            string resultStr;
            
            if (player > CPU)
            {
                Debug.Log("获胜");
                _player.WinPoint.Value += 1;
                resultStr = "You Win";
            }
            else if (player < CPU)
            {
                Debug.Log("失败");
                _cpu.WinPoint.Value += 1;
                resultStr = "You Lose";
            }
            else
            {
                Debug.Log("平手");
                resultStr = "Draw";

            }
            
            yield return new WaitForSeconds(1f);
            _gameUI.ShowResultPanel(resultStr);
            
            _battleCount += 1;
            if (_battleCount == 9)
            {
                if (_player.WinPoint.Value > _cpu.WinPoint.Value)
                {
                    resultStr = "Draw";
                }
                else if (_player.WinPoint.Value > _cpu.WinPoint.Value)
                {
                    
                }
                else
                {
                    
                }
                yield return new WaitForSeconds(2f);
                _gameUI.ShowResultPanel(resultStr);
            }
            else
            {
                NextSetting();
            }
        }

        void NextSetting()
        {
            _player.DestroySubmitCard();
            _cpu.DestroySubmitCard();
        }

        private bool IsCompletedSubmit()
        {
            return _player.Submitted && _cpu.Submitted;
        }
    }
}