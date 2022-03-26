using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using TMPro;

public class Message : MonoBehaviourPunCallbacks {
    private TextMeshPro nameLabel;

    private void Start() {
        nameLabel = GetComponent<TextMeshPro>();
    }

    //private void Update() {
    //    // ���g�����������I�u�W�F�N�g�����Ɉړ��������s��
    //    if (photonView.IsMine) {
    //        var input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
    //        transform.Translate(6f * Time.deltaTime * input.normalized);
    //    }
    //}
    // ���v���C���[�����[���֎Q���������ɌĂ΂��R�[���o�b�N
    public override void OnPlayerEnteredRoom(Player newPlayer) {

        nameLabel.text = $"{newPlayer.NickName}���Q�����܂���";
    }

    // ���v���C���[�����[������ޏo�������ɌĂ΂��R�[���o�b�N
    public override void OnPlayerLeftRoom(Player otherPlayer) {
        nameLabel.text = $"{otherPlayer.NickName}���ޏo���܂���";
    }
}
