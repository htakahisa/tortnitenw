using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class AvatarController : MonoBehaviourPunCallbacks, IPunObservable {
    private const float MaxStamina = 6f;

    [SerializeField]
    private Image staminaBar = default;

    private float currentStamina = MaxStamina;

    private void Update() {

        if (photonView.IsMine) {
            var input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
            if (input.sqrMagnitude > 0f) {
                transform.Translate(6f * Time.deltaTime * input.normalized);
            }
        }
            // �X�^�~�i���Q�[�W�ɔ��f����
            staminaBar.fillAmount = currentStamina / MaxStamina;
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.IsWriting) {
           
                    // ���g�̃A�o�^�[�̃X�^�~�i�𑗐M����
                    stream.SendNext(currentStamina);
        } else {
            // ���v���C���[�̃A�o�^�[�̃X�^�~�i����M����
            currentStamina = (float)stream.ReceiveNext();
        }
    }


    public void damage(float damage) {
        currentStamina = currentStamina - damage;
    }


}

   

           
        
    

   

