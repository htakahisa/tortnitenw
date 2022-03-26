using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AvatorFireWepon2 : MonoBehaviourPunCallbacks {

    [SerializeField]
    private Bullet bulletPrefab = default;


    private float shotInterval = 0.1f;
    private float shotDeltaTime = 999f;

    void Update() {
        shotDeltaTime += Time.deltaTime;

    }

    public void shot(PhotonView photonView, int nextBulletId) {

        if (shotDeltaTime < shotInterval) {
            return;
        }

        if (Input.GetMouseButtonDown(0)) {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var direction = mousePosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x);

            // ’e‚ð”­ŽË‚·‚é‚½‚Ñ‚É’e‚ÌID‚ð1‚¸‚Â‘‚â‚µ‚Ä‚¢‚­
            photonView.RPC(nameof(FireBullet2), RpcTarget.All, nextBulletId, angle);
            shotDeltaTime = 0;
        }
    }

    [PunRPC]
    private void FireBullet2(int id, float angle) {
        var bullet = Instantiate(bulletPrefab);
        bullet.Init(id, photonView.OwnerActorNr, transform.position, angle);
    }
}
