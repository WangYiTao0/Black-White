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
            int playerCardNumber = _player.SubmittedCard.Number;
            int cpuCardNumber = _cpu.SubmittedCard.Number;

            string resultStr;
            
            if (playerCardNumber > cpuCardNumber)
            {
                Debug.Log("获胜");
                yield return new WaitForSeconds(1f);
                _player.WinPoint.Value += 1;
                resultStr = "You Win";
            }
            else if (playerCardNumber < cpuCardNumber)
            {
                Debug.Log("失败");
                yield return new WaitForSeconds(1f);
                _cpu.WinPoint.Value += 1;
                resultStr = "You Lose";
            }
            else
            {
                Debug.Log("平手");
                yield return new WaitForSeconds(1f);
                resultStr = "Draw";

            }
            
            //显示结果
            _gameUI.ShowResultPanel(resultStr);
            
            _battleCount += 1;

            if (_battleCount >= 5 
                && Mathf.Abs(_player.WinPoint.Value - _cpu.WinPoint.Value)>(9-_battleCount))
            {
                //可以提前结束游戏   
                _battleCount = 9;
            }
            
            if (_battleCount == 9)
            {
                if (_player.WinPoint.Value > _cpu.WinPoint.Value)
                {
                    resultStr = "You Win";

                }
                else if (_player.WinPoint.Value < _cpu.WinPoint.Value)
                {
                    resultStr = "You Lose";

                }
                else
                {
                    resultStr = "Draw";
                }
                yield return new WaitForSeconds(2f);
                _gameUI.ShowFinalResultPanel(resultStr);
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