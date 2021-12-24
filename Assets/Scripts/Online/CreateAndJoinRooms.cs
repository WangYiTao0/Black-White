using System;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BlackAndWhite
{
    public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
    {
        
        [SerializeField] private Button _createBtn;
        [SerializeField] private Button _joinBtn;
        
        [SerializeField] private TMP_InputField _createInputField;
        [SerializeField] private TMP_InputField _joinInputField;

        private void Start()
        {
            _createBtn.onClick.AddListener(OnCreateRoom);
            _joinBtn.onClick.AddListener(OnJoinRoom);

        }

        public void OnCreateRoom()
        {
            //创建房间的同时也 加入了房间
            PhotonNetwork.CreateRoom(_createInputField.text);
        }

        public void OnJoinRoom()
        {
            PhotonNetwork.JoinRoom(_joinInputField.text);
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            //载入Online GameScene 需要调用 PhotonNetwork.LoadLevel
            PhotonNetwork.LoadLevel("OnlineGame");
        }
    }
}