/// <summary>
/// Generic Mono singleton.
/// </summary>
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour
    where T : MonoSingleton<T>
{
    //2
    private static T m_Instance = null;
    //3
    //Éè¼Æ½×¶Î Ð´½Å±¾  Ã»ÓÐ¹ÒÔÚÎïÌåÉÏ   Ï£Íû½Å±¾ µ¥ÀýÄ£Ê½
    //ÔËÐÐÊ± ÐèÒªÕâ¸ö½Å±¾µÄÎ¨Ò»ÊµÀý£¬µÚ1´Î µ÷ÓÃinstance
    //µÚ2,3,4,......´Î µ÷ÓÃinstance
    public static T instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = GameObject.FindObjectOfType(typeof(T)) as T;
                if (m_Instance == null)
                {
                    m_Instance =
                    new GameObject("Singleton of " + typeof(T).ToString(), typeof(T))
                    .GetComponent<T>();
                    //1 ´´½¨Ò»¸öÓÎÏ·ÎïÌå ÔÚ²ã´ÎÃæ°åÖÐÄÜ¿´µ½
                    //2 °ÑTÕâ¸ö½Å±¾¹ÒÔÚÕâ¸öÓÎÏ·ÎïÌåÉÏ£¬×÷ÎªÓÎÏ·ÎïÌåµÄÒ»¸ö½Å±¾×é¼þ
                    //3 GetComponent<T>(). ·µ»ØÕâ¸ö½Å±¾×é¼þ£¬
                    //   Õâ¸ö½Å±¾×é¼þ¾ÍÊÇÎ¨Ò»ÊµÀý£¬´úÂëÖÐÓÃ
                    m_Instance.Init();
                }

            }
            return m_Instance;
        }
    }
    // unityÏîÄ¿ÌØµã£º
    //Éè¼Æ½×¶Î Ð´½Å±¾  ¹ÒÔÚÎïÌåÉÏ 
    //ÏîÄ¿ÔËÐÐÊ±¡¾ÏµÍ³ °ïÎÒÃÇ °Ñ½Å±¾Àà ÊµÀý»¯ÁËnew¡¿ ½Å±¾¡·¡·¶ÔÏóÁË
    //ÏîÄ¿ÔËÐÐÊ± ÔÚAwakeÊ±£¬´Ó³¡¾°ÖÐÕÒµ½ Î¨Ò»ÊµÀý ¼ÇÂ¼ÔÚ  m_InstanceÖÐ      
    private void Awake()
    {

        if (m_Instance == null)
        {
            m_Instance = this as T;
        }
    }
    //Ìá¹© ³õÊ¼»¯ Ò»ÖÖÑ¡Ôñ Init £¬Start
    public virtual void Init() { }
    //µ±Ó¦ÓÃ³ÌÐò ÍË³ö×ö ÇåÀí¹¤×÷£¡µ¥ÀýÄ£Ê½¶ÔÏó=null
    private void OnApplicationQuit()
    {
        m_Instance = null;
    }
}