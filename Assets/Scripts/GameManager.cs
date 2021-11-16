using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject playerA1;
    [SerializeField] GameObject playerA2;
    [SerializeField] GameObject playerA3;

    [SerializeField] GameObject area1;
    [SerializeField] GameObject area2;
    [SerializeField] GameObject area3;
    [SerializeField] GameObject area4;

    [SerializeField] GameObject boss;
    [SerializeField] GameObject bossHealthBar;

    [SerializeField] GameObject music1;
    [SerializeField] GameObject music2;
    [SerializeField] GameObject music3;
    [SerializeField] GameObject ambient1;

    Data data;

    void Start()
    {
        data = FindObjectOfType<Data>().gameObject.GetComponent<Data>();

        if (data.getStage() == 1){
            playerA1.SetActive(true);
            area1.SetActive(true);
        }
        else if (data.getStage() == 2)
        {
            playerA2.SetActive(true);
            area2.SetActive(true);
        }
        else{
            playerA3.SetActive(true);
            area3.SetActive(true);
            boss.SetActive(true);
            bossHealthBar.SetActive(true);
        }
    }

    public void areaTrigger(int box){
        switch(box){
            case 1:
                //leaveArea1
                area2.SetActive(true);
                break;
            case 2:
                //enterArea2
                data.setStage(2);
                area1.SetActive(false);
                music2.SetActive(true);
                music1.SetActive(false);
                break;
            case 3:
                //leaveArea2
                area3.SetActive(true);
                music3.SetActive(true);
                music2.SetActive(false);
                break;
            case 4:
                //enterArea3
                data.setStage(3);
                area2.SetActive(false);
                boss.SetActive(true);
                ambient1.SetActive(false);
                break;
            case 5:
                //leaveArea3
                area3.SetActive(false);
                area4.SetActive(true);
                bossHealthBar.SetActive(false);
                break;
            default:
                Debug.Log("Unknow area value: " + box);
                break;
        }
    }
}
