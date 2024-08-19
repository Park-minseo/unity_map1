
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

        /*
         요부분 구현 아이디어는 음. map마다도 ID나 번호 부여해서 구분할 수 있도록 하고, 그걸 커다란 if, elif문으로 구분한다음
        map id와 아이템 번호 id를 합쳐서 최종 아이디로 만들자.
        만들어서
        아 근데 아이템 획득을 어떤 식으로 처리 받는지를 잘 모르겠네. 조금 더 찾아봐야겠다. keydown이 들어가긴 하는데, 그때 주변에 아이템이 드랍되어있어야
        제대로 아이템을 획득하는 걸 텐데...   
  */
public class GameManager : MonoBehaviour
{
    public ItemBoxManager itemBoxManager; // 아이템 박스를 관리하는 매니저
    public ItemCollector itemCollector;   // 아이템을 수집하는 컴포넌트

    void Start()
    {
        // 게임 시작 시 아이템 박스를 로드합니다.
        itemBoxManager.LoadItemBox();
    }

    void Update()
    {
        // 아이템을 주울 수 있는 상태에서 I 키를 누르면 아이템을 수집합니다.
        if (Input.GetKeyDown(KeyCode.I) && itemCollector)
        {
            itemCollector.CollectItem();
        }
    }
}
