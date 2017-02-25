using System.Windows;
using AuxiliarKinect.FuncoesBasicas;
using Microsoft.Kinect;
using System.Linq;

namespace Kinect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool MaoDireitaAcimaCabeca; 


        public MainWindow()
        {
            InitializeComponent();

            InicializarSensor();


        }

        private void InicializarSensor()
        {
            KinectSensor kinect = InicializadorKinect.InicializarPrimeiroSensor(0);
            kinect.SkeletonStream.Enable();

            kinect.SkeletonFrameReady += KinectEvent;
        }


        private void ExecutarRegraMaoDireitaAcimaDaCabeca(SkeletonFrame quadroAtual)
        {
            Skeleton[] esqueletos = new Skeleton[6]; quadroAtual.CopySkeletonDataTo(esqueletos);
            Skeleton usuario = esqueletos.FirstOrDefault(esqueleto => esqueleto.TrackingState == SkeletonTrackingState.Tracked);
            if (usuario != null)
            {
                Joint maoDireita = usuario.Joints[JointType.HandRight]; Joint cabeca = usuario.Joints[JointType.Head]; bool novoTesteMaoDireitaAcimaCabeca = maoDireita.Position.Y > cabeca.Position.Y;
                if (MaoDireitaAcimaCabeca != novoTesteMaoDireitaAcimaCabeca)
                {
                    MaoDireitaAcimaCabeca = novoTesteMaoDireitaAcimaCabeca;
                    if (MaoDireitaAcimaCabeca) MessageBox.Show("A mão direita está acima da cabeça!");
                }
            }
        }

        private void KinectEvent(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (SkeletonFrame quadroAtual = e.OpenSkeletonFrame())
            {
                if (quadroAtual != null)
                {
                    ExecutarRegraMaoDireitaAcimaDaCabeca(quadroAtual);
                }
            }
        }


    }
}
