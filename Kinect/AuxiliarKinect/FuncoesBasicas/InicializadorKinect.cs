using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace AuxiliarKinect.FuncoesBasicas
{
    public static class InicializadorKinect
    {
        public static KinectSensor InicializarPrimeiroSensor(int anguloElevacaoInicial)
        {
            KinectSensor kinect = KinectSensor.KinectSensors.FirstOrDefault(k => k.Status == KinectStatus.Connected);

            if (kinect == null)
            {
                throw new Exception("Kinect não encontrado!");       
            }

            kinect.Start();
            kinect.ElevationAngle = anguloElevacaoInicial;

            return kinect;
        }

    }
}
