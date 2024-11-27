using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoMonteCarlo.Clases
{
    public  class PanelSolar
    {
        public int IdPanel { get; set; }
        public int IdExperimento { get; set; }

        public double VidaUtil { get; set; }

        public PanelSolar() 
        {
        }
        public PanelSolar(int idPanel, int idExperimento, double vidaUtil) 
        {
            IdPanel = idPanel;
            IdExperimento = idExperimento;  
            VidaUtil = vidaUtil;
        }
    }
}
