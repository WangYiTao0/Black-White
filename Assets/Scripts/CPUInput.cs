using UnityEngine;

namespace BlackAndWhite
{
    public class CPUInput : MonoBehaviour
    {
        private Player _player;

        private void Start()
        {
            _player = GetComponent<Player>();
            _player.ShuffleCard();
        }

        public void Action()
        {
            //随机 选择卡牌
            _player.RandomSelectCard();
            _player.SubmitCard();
        }
    }
}