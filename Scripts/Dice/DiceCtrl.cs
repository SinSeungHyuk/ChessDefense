using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Linq;

public class DiceCtrl : MonoBehaviour
{
    [SerializeField] private List<DiceNumberCheck> diceNumberChecks = new(6);
    [SerializeField] private Camera diceCamera;
    [SerializeField] private GameObject dice;
    [SerializeField] private Database DB_Tower;

    private Vector3 originPos = new Vector3(-1000,-998,0);
    private MeshRenderer diceMeshRenderer;
    private DiceEffect diceEffect;
    private Rigidbody diceRigid;
    private PlayerCtrl player;
    private int[] angles = { 0, 90, 180, 270, 360 };



    void Awake()
    {
        player = GetComponent<PlayerCtrl>();
        diceRigid = dice.GetComponent<Rigidbody>();
        diceMeshRenderer = dice.GetComponent<MeshRenderer>();
    }

    public void DiceRoll(DiceDetailsSO diceData)
    {
        SoundEffectManager.Instance.PlaySoundEffect(ESoundEffectType.Dice);

        InitializeDice(diceData);

        // 회전 랜덤 변수
        float dirX = Random.Range(0, 1000);
        float dirY = Random.Range(0, 1000);
        float dirZ = Random.Range(0, 1000);

        // 회전 방향을 랜덤하게 양수/음수로 결정
        dirX *= Random.Range(0, 2) == 0 ? 1 : -1;
        dirY *= Random.Range(0, 2) == 0 ? 1 : -1;
        dirZ *= Random.Range(0, 2) == 0 ? 1 : -1;

        // 초기 회전값 (랜덤 부여)
        Quaternion currentRotation = transform.localRotation;
        int randomIndex_x = Random.Range(0, angles.Length);
        int randomIndex_y = Random.Range(0, angles.Length);
        int randomIndex_z = Random.Range(0, angles.Length);

        dice.transform.localRotation = Quaternion.Euler(angles[randomIndex_x], angles[randomIndex_y], angles[randomIndex_z]);
        // 윗 방향으로 힘을 가해 공중에 띄우면서, 랜덤한 방향으로 회전
        float ForceRand = Random.Range(300, 400);
        diceRigid.AddForce(Vector3.up * ForceRand);
        diceRigid.AddTorque(new Vector3(dirX, dirY, dirZ), ForceMode.VelocityChange);

        CheckDiceStopRoutine().Forget();
    }

    private void InitializeDice(DiceDetailsSO diceData)
    {
        dice.transform.position = originPos;
        diceEffect = diceData.diceEffect;
        diceEffect.player = player;
        diceEffect.DB_Tower = DB_Tower;
        diceMeshRenderer.material = diceData.diceMaterial;
        diceCamera.gameObject.SetActive(true);
    }

    private async UniTask CheckDiceStopRoutine()
    {
        await UniTask.Delay(100); // 0.1초 넘기기 (벨로시티 반영을 위해)

        while (diceRigid.velocity != Vector3.zero)
        {
            await UniTask.Yield();
        }


        await UniTask.Delay(1000);

        CheckDiceNumber();
        diceCamera.gameObject.SetActive(false);
    }

    private void CheckDiceNumber()
    {
        int number = diceNumberChecks.FirstOrDefault(dice => dice.IsGround == true).Number;

        diceEffect.ApplyDiceEffect(number - 1); // 주사위 눈금은 1부터 시작, DB는 0부터 시작
    }
}
