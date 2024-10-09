using System.Collections;
using System.Collections.Generic;
using UnityEngine;

​

public class Camera : MonoBehaviour

{
    private GameObject go_Target;    // 타겟 설정을 해 줄 객체 선언

​

    [SerializeField]
    private float speed;    //카메라가 go_Target을 쫓을 스피드 역시 수정해줄 수 있도록.

​

    private Vector3 difValue;  

 //go_Target과 카메라 사이의 거리를 항상 같게 유지해 줄 수 있도록 difValue라는 변수 사용
​

    void Start()

    {
        go_Target=
        difValue = transform.position - go_Target.transform.position;

        //difValue는 현재카메라의 위치 - 타겟의 위치여야 한다. 하지만 이 때, 음수의 값이 나올 수도 있기 때문에 아래의 절대 값 변환 식으로 항상 양수가 나올 수 있도록 해 준다.

        difValue = new Vector3(Mathf.Abs(difValue.x), Mathf.Abs(difValue.y), Mathf.Abs(difValue.z));

        // Vector 3 (x, y, z) 모두 양수가 될 수 있도록 Mathf.Abs (절대 값)을 넣어 모두 양수로 제한해 준다. 



    }​

    void Update()

    {
        this.transform.position = Vector3.Lerp(this.transform.position, go_Target.transform.position + difValue, speed);

        // 카메라의 위치는 = Vector3. Lerp (Lerp는 움직임에 부드러움을 주기 위함이다.-- ( a , b, t )의 값을 갖는데 a는 이동전의 위치, b는 이동할 위치, t는 움직임의 비율을 뜻한다.)
        // t (여기서는 speed) 의 값은 0~1의 사이가 된다. a와 b사이의 비율을 뜻하기 때문에 0.5를 기입한다면 a와 b의 중간 값을 return하여 준다. 
        // Unity 화면으로 돌아가 스크립트를 넣어준 후 speed를 0.05(적은 수)로 넣어주면 아주 부드럽게 따라 가는 모습을,
        //1(최대 수)을 넣어주면 따라가는 것인지 알 수 없을 정도의 모습을 볼 수 있다. (타겟의 움직임이 바로 카메라의 위치가 되기 때문에 화면이 정지되어 있는 것 처럼 움직인다.)​
    }

}