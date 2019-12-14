using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 제작 : 신동규
 * 접근을 제한하는 스크립트입니다. 적용 객체로부터 구의 형태로 접근 제한 구역이 형성됩니다.
 * 접근 제한할 객체들은 objects배열에 넣으면 그 객체들에게 접근 제한이 적용됩니다.
 * reverse를 통해 밖에서 안으로, 안에서 밖으로 접근 제한 방향을 정할 수 있습니다.
 * (디폴트 -> false -> 안에서 밖으로 나가는 것을 제한)
 */

public class RestrictionOnMovement : MonoBehaviour
{
    public float moveSpeed = 10;
    public float RestrictDistance = 5;
    public List<GameObject> objects = new List<GameObject>();
    public bool reverse = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in objects)
        {
            if (Vector3.Distance(obj.transform.position, this.transform.position) > RestrictDistance || !reverse)
            {
                obj.transform.Translate((this.transform.position - obj.transform.position).normalized * moveSpeed * Time.deltaTime, Space.World);
            }
            if (Vector3.Distance(obj.transform.position, this.transform.position) < RestrictDistance || reverse)
            {
                obj.transform.Translate((obj.transform.position - this.transform.position).normalized * moveSpeed * Time.deltaTime, Space.World);
            }
        }

    }

    private void OnDrawGizmos()     //기즈모, 접근제한 지역을 구로 그림
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, RestrictDistance);
    }
}
