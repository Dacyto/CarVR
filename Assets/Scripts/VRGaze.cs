using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGaze : MonoBehaviour
{
    public Image imgGaze;

    public float totalTime = 2;
    float waitTimer = 0;
    bool waitStatus;
    bool gvrStatus;
    float gvrTimer;
    

    public int distanceOfRay = 10;
    private RaycastHit _hit;

    private bool isOpenCapot = false;
    private bool isOpenTrunk = false;
    private bool isOpenLFDoor = false;
    private bool isOpenLBDoor = false;
    private bool isOpenRFDoor = false;
    private bool isOpenRBDoor = false;
    private bool isEnabledLights = false;

    // Update is called once per frame
    void Update()
    {
        if(gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }

        if(waitStatus)
        {
            waitTimer = waitTimer - Time.deltaTime;
            //Debug.Log(waitTimer);
            //Debug.Log(isOpenCapot);
            //Debug.Log("Wait Status: " + waitStatus);
            if(waitTimer <= 0)
            {
                waitStatus = false;
                waitTimer = 0;
                //Debug.Log("Ожидание закончено! Wait Status = " + waitStatus);
            }
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if(Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            // Начало логики с телепортами.
            // наземные телепорты (перемещение по гаражу)
            if(imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Teleport"))
            {
                _hit.transform.gameObject.GetComponent<Teleport>().TeleportPlayer();
            }

            // телепорты внутри машины (перемещение по разным сидениям)
            if(imgGaze.fillAmount == 1 && _hit.transform.CompareTag("CarTeleport"))
            {
                _hit.transform.gameObject.GetComponent<TeleportIntoTheCar>().TeleportInCar();
            }
            // Конец логики с телепортами.



            // Логика взаимодействия с машиной: капот, багажник, двери.
            if(imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Capot") && !isOpenCapot && waitStatus == false)
            {
                waitTimer = 5;           // задержка 5 секунд перед тем как осуществить дальнейшее взаимодействие с анимациями
                waitStatus = true;
                isOpenCapot = true;
                _hit.transform.gameObject.GetComponent<CarAnimations>().OpenCapot();
            }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Capot") && isOpenCapot && waitStatus == false)
            {
                waitTimer = 5;           // задержка 5 секунд перед тем как осуществить дальнейшее взаимодействие с анимациями
                waitStatus = true;
                isOpenCapot = false;
                _hit.transform.gameObject.GetComponent<CarAnimations>().CloseCapot();
            }


            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("CarTrunk") && !isOpenTrunk && waitStatus == false)
            {
                waitTimer = 5;
                waitStatus = true;
                isOpenTrunk = true;
                _hit.transform.gameObject.GetComponent<CarAnimations>().OpenTrunk();
            }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("CarTrunk") && isOpenTrunk && waitStatus == false)
            {
                waitTimer = 5;
                waitStatus = true;
                isOpenTrunk = false;
                _hit.transform.gameObject.GetComponent<CarAnimations>().CloseTrunk();
            }

            // Левая передняя дверь (водительская) (LFDoor)
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("LFDoor") && !isOpenLFDoor && waitStatus == false)
            {
                waitTimer = 5;
                waitStatus = true;
                isOpenLFDoor = true;
                _hit.transform.gameObject.GetComponent<CarAnimations>().OpenLFDoor();
            }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("LFDoor") && isOpenLFDoor && waitStatus == false)
            {
                waitTimer = 5;
                waitStatus = true;
                isOpenLFDoor = false;
                _hit.transform.gameObject.GetComponent<CarAnimations>().CloseLFDoor();
            }

            // Левая задняя дверь (LBDoor)
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("LBDoor") && !isOpenLBDoor && waitStatus == false)
            {
                waitTimer = 5;
                waitStatus = true;
                isOpenLBDoor = true;
                _hit.transform.gameObject.GetComponent<CarAnimations>().OpenLBDoor();
            }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("LBDoor") && isOpenLBDoor && waitStatus == false)
            {
                waitTimer = 5;
                waitStatus = true;
                isOpenLBDoor = false;
                _hit.transform.gameObject.GetComponent<CarAnimations>().CloseLBDoor();
            }

            // Правая передняя дверь (RFDoor)
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("RFDoor") && !isOpenRFDoor && waitStatus == false)
            {
                waitTimer = 5;
                waitStatus = true;
                isOpenRFDoor = true;
                _hit.transform.gameObject.GetComponent<CarAnimations>().OpenRFDoor();
            }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("RFDoor") && isOpenRFDoor && waitStatus == false)
            {
                waitTimer = 5;
                waitStatus = true;
                isOpenRFDoor = false;
                _hit.transform.gameObject.GetComponent<CarAnimations>().CloseRFDoor();
            }

            // Правая задняя дверь (RBDoor)
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("RBDoor") && !isOpenRBDoor && waitStatus == false)
            {
                waitTimer = 5;
                waitStatus = true;
                isOpenRBDoor = true;
                _hit.transform.gameObject.GetComponent<CarAnimations>().OpenRBDoor();
            }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("RBDoor") && isOpenRBDoor && waitStatus == false)
            {
                waitTimer = 5;
                waitStatus = true;
                isOpenRBDoor = false;
                _hit.transform.gameObject.GetComponent<CarAnimations>().CloseRBDoor();
            }
            // Конец логики взаимодействия с машиной (капот, двери, багажник)




            // логика включения / выключения фар машины (передние и задние сразу)
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("LightSwitch") && !isEnabledLights && waitStatus == false)
            {
                waitTimer = 2;
                waitStatus = true;
                isEnabledLights = true;
                _hit.transform.gameObject.GetComponent<CarLights>().EnableLights();
                //Debug.Log(isEnabledLights);
            }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("LightSwitch") && isEnabledLights && waitStatus == false)
            {
                waitTimer = 2;
                waitStatus = true;
                isEnabledLights = false;
                _hit.transform.gameObject.GetComponent<CarLights>().DisableLights();
                //Debug.Log(isEnabledLights);
            }
            // конец данной логики (механики) (работает!)



            // смена цвета машины (механика взаимодействия с разноцветными кубиками)
            if(imgGaze.fillAmount == 1 && _hit.transform.CompareTag("CarPaint") && _hit.transform.gameObject.name == "RedColor")
            {
                _hit.transform.gameObject.GetComponent<CarColorPainting>().REDColor();
                Debug.Log("Перекрасилось!");
            }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("CarPaint") && _hit.transform.gameObject.name == "GreenColor")
            {
                _hit.transform.gameObject.GetComponent<CarColorPainting>().GREENColor();
                Debug.Log("Перекрасилось!");
            }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("CarPaint") && _hit.transform.gameObject.name == "BlueColor")
            {
                _hit.transform.gameObject.GetComponent<CarColorPainting>().BLUEColor();
                Debug.Log("Перекрасилось!");
            }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("CarPaint") && _hit.transform.gameObject.name == "YellowColor")
            {
                _hit.transform.gameObject.GetComponent<CarColorPainting>().YELLOWColor();
                Debug.Log("Перекрасилось!");
            }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("CarPaint") && _hit.transform.gameObject.name == "WhiteColor")
            {
                _hit.transform.gameObject.GetComponent<CarColorPainting>().WHITEColor();
                Debug.Log("Перекрасилось!");
            }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("CarPaint") && _hit.transform.gameObject.name == "BlackColor")
            {
                _hit.transform.gameObject.GetComponent<CarColorPainting>().BLACKColor();
                Debug.Log("Перекрасилось!");
            }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("CarPaint") && _hit.transform.gameObject.name == "MagentaColor")
            {
                _hit.transform.gameObject.GetComponent<CarColorPainting>().MAGENTAColor();
                Debug.Log("Перекрасилось!");
            }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("CarPaint") && _hit.transform.gameObject.name == "GreyColor")
            {
                _hit.transform.gameObject.GetComponent<CarColorPainting>().GREYColor();
                Debug.Log("Перекрасилось!");
            }
            // конец механики с перекраской машины (работает)




            // смена колёс (механика взаимодействия с разными типами дисков)
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("TriggerWheel") && _hit.transform.gameObject.name == "TriggerDrift1")
            {
                _hit.transform.gameObject.GetComponent<ChangeWheels>().SelectDriftType1();
                Debug.Log("Поменяли колёса!");
            }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("TriggerWheel") && _hit.transform.gameObject.name == "TriggerDrift2")
            {
                _hit.transform.gameObject.GetComponent<ChangeWheels>().SelectDriftType2();
                Debug.Log("Поменяли колёса!");
            }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("TriggerWheel") && _hit.transform.gameObject.name == "TriggerDrift3")
            {
                _hit.transform.gameObject.GetComponent<ChangeWheels>().SelectDriftType3();
                Debug.Log("Поменяли колёса!");
            }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("TriggerWheel") && _hit.transform.gameObject.name == "TriggerDrift4")
            {
                _hit.transform.gameObject.GetComponent<ChangeWheels>().SelectDriftType4();
                Debug.Log("Поменяли колёса!");
            }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("TriggerWheel") && _hit.transform.gameObject.name == "TriggerDrift5")
            {
                _hit.transform.gameObject.GetComponent<ChangeWheels>().SelectDriftType5();
                Debug.Log("Поменяли колёса!");
            }

            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("TriggerWheel") && _hit.transform.gameObject.name == "TriggerStock")
            {
                _hit.transform.gameObject.GetComponent<ChangeWheels>().SelectStockWheels();
                Debug.Log("Поменяли колёса!");
            }
            // конец данной механики смены колес.



            // конец реализации основных механик данного проекта
        }
    }


    public void GVROn()
    {
        gvrStatus = true;
    }


    public void GVRoff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
    }
}
