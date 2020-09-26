/* Класс описывающий упровление самолётом. */
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class dsf : MonoBehaviour
{
    //PUBLIC
    public float maxthrust = 40.0F; //Максемальная тяга двигателя
    public float maxspeed = 200.0F; //Максемальная скорость
    public float maneuverability = 1.0F; //Манёвренность или упровляемость
    public float racing = 50.0F; //Скорость набора скорости
    public float maxangleX = 30.0F;// Нудевой угол атаки

    //PRIVATE
    private float lforce = 0.0F; //Подёмная сила
    private float clift = 0.0F; //Коэффициент подъемной силы 
    private float thrust = 0.0F; //Тяга двигателя

    private float ax = 0.0F;
    private float ay = 0.0F;
    private float az = 0.0F;
    private float anglesx = 0.0F;
    private float anglesz = 0.0F;


    void Start()
    {
    }

    void FixedUpdate()
    {
        az = 0.0F;

        if (Input.GetButton("Jump")) //Жмём пробел
        {
            if (thrust < maxthrust)
            {
                thrust += racing * Time.deltaTime;//Прибовляем тягу пока она меньше 25
            }
        }
        else
        {
            if (thrust > 0.0F)//Если клавиша не нажата и скорость больше нуля то
            {
                thrust = GetComponent<Rigidbody>().velocity.magnitude * 0.35F;
            }
        }

        if (GetComponent<Rigidbody>().rotation.eulerAngles.x < 180.0F)
        {
            anglesx = -GetComponent<Rigidbody>().rotation.eulerAngles.x;
        }
        else
        {
            anglesx = 360.0F - GetComponent<Rigidbody>().rotation.eulerAngles.x;
        }

        if (GetComponent<Rigidbody>().rotation.eulerAngles.z < 180.0F)
        {
            anglesz = -GetComponent<Rigidbody>().rotation.eulerAngles.z;
        }
        else
        {
            anglesz = 360.0F - GetComponent<Rigidbody>().rotation.eulerAngles.z;
        }

        anglesx = Mathf.Clamp(anglesx, -maxangleX, maxangleX + 5.0F);
        clift = 1.0F - (0.035F * (maxangleX - anglesx));

        if (anglesx > maxangleX - 5.0F && anglesz < 45.0F && anglesz > -45.0F)// а тут код для того, чтобы при сильном угле атаки падала тяга и подёмная сила
        {
            clift = -thrust * 0.15F;
        }
        ax = Input.GetAxisRaw("Vertical") * maneuverability;
        ay = Input.GetAxisRaw("Horizontal") * maneuverability;
        GetComponent<Rigidbody>().angularDrag = 6.0F - maneuverability;
        GetComponent<Rigidbody>().drag = 1.5F - maneuverability;
        if (Input.GetKey("q"))
        {
            az = 3.0F * maneuverability;
        }
        if (Input.GetKey("e"))
        {
            az = -3.0F * maneuverability;
        }

        lforce = (GetComponent<Rigidbody>().velocity.magnitude * 0.175F) + (GetComponent<Rigidbody>().velocity.magnitude * 0.04F * clift);//тут расчёт подъёмной силы
        GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(ax, ay, az) * Time.deltaTime, ForceMode.VelocityChange);
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(az * az, lforce, thrust) * Time.deltaTime, ForceMode.VelocityChange);
    }
    void OnGUI()
    {
        GUILayout.Label("    Height: " + transform.position.y.ToString("f2"));
        GUILayout.Label("    Speed: " + GetComponent<Rigidbody>().velocity.magnitude.ToString("f2"));
        GUILayout.Label("    Lifting force: " + lforce.ToString("f2"));
        GUILayout.Label("    Thrust: " + thrust.ToString("f2"));
        GUILayout.Label("    AnglesX: " + anglesx.ToString("f2"));
        GUILayout.Label("    Temp: " + anglesz.ToString("f2"));
        GUILayout.Label("    Clift: " + clift.ToString("f2"));
    }
}


