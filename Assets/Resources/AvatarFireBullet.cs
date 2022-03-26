using Photon.Pun;
using UnityEngine;

public class AvatarFireBullet : MonoBehaviourPunCallbacks {
    [SerializeField]
    private Bullet bulletPrefab = default;
    private int nextBulletId = 0;

    private void Update() {
        if (photonView.IsMine) {
            if (Input.GetMouseButtonDown(0)) {
                var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var direction = mousePosition - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x);

                                // �e�𔭎˂��邽�тɒe��ID��1�����₵�Ă���
                photonView.RPC(nameof(FireBullet), RpcTarget.All, nextBulletId++, angle);
            }
        }
    }

    [PunRPC]
    private void FireBullet(int id, float angle) {
        var bullet = Instantiate(bulletPrefab);
        bullet.Init(id, photonView.OwnerActorNr, transform.position, angle);
    }
}