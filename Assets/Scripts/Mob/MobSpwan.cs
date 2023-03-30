using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpwan : MonoBehaviour
{
    public GameObject planeObject;
    public GameObject Mob;
    BoxCollider rangeCollider;
    [SerializeField] float delayTime = 1f;
    [SerializeField] float MaxMobCount = 5;
    float current_Mob_count = 1;
    
    private void Awake()
    {
        rangeCollider = planeObject.GetComponent<BoxCollider>();
    }
    
    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = planeObject.transform.position;
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;
        
        range_X = Random.Range( (range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range( (range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z); //랜덤 포지션

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }

    private void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());
    }

    private IEnumerator RandomRespawn_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayTime);

            // 생성 위치 부분에 위에서 만든 함수 Return_RandomPosition() 함수 대입
            if(current_Mob_count < MaxMobCount)
            {
                GameObject instantMob = Instantiate(Mob, Return_RandomPosition(), Quaternion.identity);  
                // Quaternion.identity == no rotation
                current_Mob_count++; //나중에 몹이 죽을때 어떻게 빼지..?
            }
        }
    }
}
