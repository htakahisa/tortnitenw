using Photon.Pun;
using UnityEngine;

public class AvatarFireBullet : MonoBehaviourPunCallbacks {
    [SerializeField]
    

    private Bullet bulletPrefab2 = default;

    // 武器 1:ピストル , 2:マシンガン
    private int weponId = 1;

    private AvatorFireWepon1 wepon1;
    private AvatorFireWepon2 wepon2;

    private int nextBulletId = 0;

    private void Start() {
        wepon1 = GetComponent<AvatorFireWepon1>();
        wepon2 = GetComponent<AvatorFireWepon2>();
    }


    private void Update() {

        // wepon切り替え
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            weponId = 1;
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            weponId = 2;
        }


        if (photonView.IsMine) {
            //if (Input.GetMouseButtonDown(0)) {
            //    var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //    var direction = mousePosition - transform.position;
            //    float angle = Mathf.Atan2(direction.y, direction.x);

            //                    // 弾を発射するたびに弾のIDを1ずつ増やしていく
            //    photonView.RPC(nameof(FireBullet), RpcTarget.All, nextBulletId++, angle);
            //}
            if (weponId == 1) {
                wepon1.shot(photonView, nextBulletId++);
            } else if (weponId == 2) {
                wepon2.shot(photonView, nextBulletId++);
            }
        }
    }


}