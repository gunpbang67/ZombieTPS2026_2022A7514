using UnityEngine;

//플레이어 캐릭터를 사용자 입력에 따라 움직이는 스크립트
public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 5f; // 플레이어 이동 속도
    public float rotateSpeed = 180f; // 플레이어 좌우 회전 속도

    private PlayerInput playerInput; // 플레이어 입력을 처리하는 컴포넌트
    private Rigidbody playerRigidbody; // 플레이어의 Rigidbody 컴포넌트
    private Animator playerAnimator; // 플레이어의 Animator 컴포넌트

    private void Start()
    {
        // 사용할 컴포넌트들의 참조를 가져오기
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    //FixedUpdate는 물리 갱신 주기에 맞추어 실행함
    private void FixedUpdate()
    {
        // 물리 갱신 주기마다 움직임, 회전, 애니메이션 처리 실행
        //회전 실행
        Rotate();
        //움직임 실행
        Move();

        //입력값에 따라 애니메이터의 Move 파라미터 값을 변경
        playerAnimator.SetFloat("Move", playerInput.move);
    }

    private void Move()
    {
        // 상대적으로 이동할 거리 계산
        Vector3 moveDistace = playerInput.move * transform.forward * moveSpeed * Time.deltaTime;
        // 리지드바디로 게임 오브젝트 위치 변경
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistace);

    }

    private void Rotate()
    {
        // 상대적으로 회전할 수치 계산
        float turn = playerInput.rotate * rotateSpeed * Time.deltaTime;
        // 리지드바디로 게임 오브젝트 회전 변경
        playerRigidbody.rotation = playerRigidbody.rotation * Quaternion.Euler(0, turn, 0);
    }
}
