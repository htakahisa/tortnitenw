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
    //    // 自身が生成したオブジェクトだけに移動処理を行う
    //    if (photonView.IsMine) {
    //        var input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
    //        transform.Translate(6f * Time.deltaTime * input.normalized);
    //    }
    //}
    // 他プレイヤーがルームへ参加した時に呼ばれるコールバック
    public override void OnPlayerEnteredRoom(Player newPlayer) {

        nameLabel.text = $"{newPlayer.NickName}が参加しました";
    }

    // 他プレイヤーがルームから退出した時に呼ばれるコールバック
    public override void OnPlayerLeftRoom(Player otherPlayer) {
        nameLabel.text = $"{otherPlayer.NickName}が退出しました";
    }
}
