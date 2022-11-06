using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    [SerializeField]
    private float rotCamXAxisSpeed = 5; //Ä«¸Ş¶ó xÃà È¸Àü¼Óµµ
    [SerializeField]
    private float rotCamYAxisSpeed = 3; //Ä«¸Ş¶ó yÃà È¸Àü¼Óµµ

    private float limitMinX = -80; //Ä«¸Ş¶ó XÃà È¸Àü ¹üÀ§(ÃÖ¼Ò)
    private float limitMaxX = 50; //Ä«¸Ş¶ó xÃà È¸Àü ¹üÀ§(ÃÖ´ë)
    private float eulerAngleX;
    private float eulerAngleY;

    public void UpdateRotate(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX * rotCamYAxisSpeed; //¸¶¿ì½º ÁÂ/¿ì ÀÌµ¿À¸·Î Ä«¸Ş¶ó Y®‚ È¸Àü
        eulerAngleX -= mouseY * rotCamXAxisSpeed; //¸¶¿ì½º À§.¾î·¡ ÀÌµ¿À¸·Î ¸¶ÄÉ¶ó xÃà È¸Àü

        //Ä«¸Ş¶ó xÃà È¸ÀüÀÇ °æ¿ì È¸Àü ¹üÀ§¸¦ ¼³Á¤
        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX);

        transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);

    }


    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
