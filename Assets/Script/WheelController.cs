using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class WheelController : MonoBehaviour {

    [System.Serializable]
    public class InfoEje
    {
        public WheelCollider ruedaIzquierda;
        public WheelCollider ruedaDerecha;
        public bool motor;
        public bool direccion;
    }

    public List<InfoEje> infoEjes;
    public float maxMotorTorsion;
    public float maxAnguloDeGiro;

    private void FixedUpdate()
    {
        float motor = maxMotorTorsion * Input.GetAxis("Vertical");
        float direccion = maxAnguloDeGiro * Input.GetAxis("Horizontal");

        foreach (InfoEje ejesInfo in infoEjes)
        {
            if (ejesInfo.direccion)
            {
                ejesInfo.ruedaIzquierda.steerAngle = direccion;
                ejesInfo.ruedaDerecha.steerAngle = direccion;
            }
            if (ejesInfo.motor)
            {
                ejesInfo.ruedaIzquierda.motorTorque = motor;
                ejesInfo.ruedaDerecha.motorTorque = motor;
            }

            posRuedas(ejesInfo.ruedaIzquierda);
            posRuedas(ejesInfo.ruedaDerecha);
        }
    }

    void posRuedas(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform ruedaVisual = collider.transform.GetChild(0);
        Vector3 posicion;
        Quaternion rotacion;
        collider.GetWorldPose(out posicion, out rotacion);

        ruedaVisual.transform.position = posicion;
        ruedaVisual.transform.rotation = rotacion;
    }

}


