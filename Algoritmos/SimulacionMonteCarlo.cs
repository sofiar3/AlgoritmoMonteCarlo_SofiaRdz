using AlgoritmoMonteCarlo.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoMonteCarlo.Algoritmos
{
    public class SimulacionMonteCarlo
    {
        public List<PanelSolar> ListaPaneles = new List<PanelSolar>();

        public List<PanelSolar> GenerarValoresAleatorios(double limiteInferior,
            double limiteSuperior, int totalPaneles, int totalExperimentos)
        {
            List<PanelSolar> listaSalida = new List<PanelSolar>();
            for (int i = 0; i < totalExperimentos; i++)
            {
                for (int j = 0; j < totalPaneles; j++)
                {
                    Random random = new Random();
                    double valor = (limiteSuperior - limiteInferior) * random.NextDouble();
                    Console.WriteLine($"Valor sorteado para Panel {j}, Experimento {i}: {valor}");
                    PanelSolar panel = new PanelSolar(j, i, valor);
                    listaSalida.Add(panel);
                }
            }
            return listaSalida;
        }

        public void CalcularValoresMediaVarianza(List<PanelSolar> listaEntrada,
            int totalExperimentos, int seleccionado, List<double> listaSalida)
        {
            if (seleccionado < 0 || seleccionado >= listaEntrada.Count)
            {
                Console.WriteLine("Error: El valor 'seleccionado' no es válido.");
                return;
            }

            double sumaParcial = 0;
            double media = 0;
            List<PanelSolar> listaParcial = new List<PanelSolar>();
            for (int i = 0; i < totalExperimentos; i++)
            {
                List<PanelSolar> listaFiltrada = listaEntrada.FindAll(z => z.IdExperimento.Equals(i));
                if (listaFiltrada.Count > 0)
                {
                    listaFiltrada = listaFiltrada.OrderBy(z => z.VidaUtil).ToList();

                    if (seleccionado >= listaFiltrada.Count)
                    {
                        Console.WriteLine("Error: El índice 'seleccionado' excede el número de paneles disponibles.");
                        return;
                    }

                    PanelSolar panelSeleccionado = listaFiltrada[seleccionado];
                    listaParcial.Add(panelSeleccionado);

                    sumaParcial = sumaParcial + panelSeleccionado.VidaUtil;
                }
            }

            media = sumaParcial / totalExperimentos;

            double varianza = 0;
            foreach (PanelSolar panelSolar in listaParcial)
            {
                varianza += Math.Pow(panelSolar.VidaUtil - media, 2);
            }

            if (listaParcial.Count != 1)
                varianza = varianza / (listaParcial.Count - 1);

            double desviacionEstandar = Math.Sqrt(varianza);

            Console.WriteLine($"Media: {media}");
            Console.WriteLine($"Varianza: {varianza}");
            Console.WriteLine($"Desviación Estándar: {desviacionEstandar}");

            listaSalida.Add(varianza);
            listaSalida.Add(media);
            listaSalida.Add(desviacionEstandar);
        }

        public List<double> MonteCarlo(double limiteInferior,
            double limiteSuperior, int totalPaneles, int totalExperimentos, int seleccionado)
        {
            List<double> listaSalida = new List<double>();

            if (seleccionado < 0 || seleccionado >= totalPaneles)
            {
                Console.WriteLine("Error: El índice 'seleccionado' es inválido.");
                return listaSalida;
            }

            ListaPaneles = GenerarValoresAleatorios(limiteInferior,
                limiteSuperior, totalPaneles, totalExperimentos);

            CalcularValoresMediaVarianza(ListaPaneles,
                totalExperimentos, seleccionado, listaSalida);

            return listaSalida;
        }
    }
}
